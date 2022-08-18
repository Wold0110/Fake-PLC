using EasyModbus;

const string TRANSFER_FILE  = "transfer.cfg";
const string CONFIG_FILE    = "config.cfg";
int interval = 5000;
List<string> errors = new List<string>();
List<Transfer> transferList = new List<Transfer>();
#region Read-Files
    #region Read-Config
    foreach (string line in File.ReadLines(CONFIG_FILE).Where(x => x[0] != '#' && !String.IsNullOrEmpty(x)).ToList())
    {
        string[] parts = line.Split('=');
        switch (parts[0])
        {
            case "interval":
                int n;
            if (int.TryParse(parts[1], out n))
                interval = n;
            else
                errors.Add("Wrong interval: " + line);
                break;
            default:
                errors.Add("Wrong config line: " + line);
                break;
        }
    }
    #endregion
    #region Read-Transfer
    foreach (string line in File.ReadAllLines(TRANSFER_FILE))
    {
        if (Transfer.ValidLine(line))
            transferList.Add(Transfer.FromLine(line));
        else
            Console.WriteLine("Wrong transfer line: "+line);
    }
#endregion Read-Transfer
#endregion Read-Files

Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("[WARN] ");
Console.ResetColor();

errors.ForEach(x => Console.WriteLine(x));
errors.Clear();

Console.ForegroundColor = ConsoleColor.Green;
Console.Write("[START] ");
Console.ResetColor();
Console.WriteLine(NOW());

while (true)
{
    transferList.ForEach(x => x.Run());
    Thread.Sleep(interval);
}
static string NOW() => DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

struct Target
{
    internal ModbusClient client;
    internal int addr;
    internal Target(string ip, int port, int addr)
    {
        client = new(ip,port);
        this.addr = addr;
    }
    public override string ToString()
    {
        return client.IPAddress + ":" + client.Port + " - " + addr;
    }
}
internal class Transfer{
    Target source;
    Target destination;
    int length;

    static string NOW() => DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

    internal Transfer(Target source, Target destination,int length)
    {
        this.source = source;
        this.destination = destination;
        this.length = length;
    }
    internal void Run() {
        try
        {
            destination.client.Connect();
            source.client.Connect();
            destination.client.WriteMultipleRegisters(destination.addr, source.client.ReadHoldingRegisters(source.addr, length));
            source.client.Disconnect();
            destination.client.Disconnect();
        }
        catch {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR] ");
            Console.ResetColor();
            Console.WriteLine(NOW()+" Transfer problem: "+destination+" - "+(destination.client.Connected ? 'Y' : 'N')+" | "+source+" - "+ (source.client.Connected ? 'Y' : 'N'));
        }
    }
    
    #region IsValidX
    static bool IsValidIP(string ip)
    {
        if (String.IsNullOrWhiteSpace(ip)) return false;
        string[] t = ip.Split('.');
        if (t.Length != 4) return false;
        byte temp;
        return t.All(x => byte.TryParse(x, out temp));
    }
    internal static bool ValidLine(string line)
    {
        string[] t = line.Split(';');
        if (t.Length != 7) return false;
        if (!IsValidIP(t[0]) || !IsValidIP(t[4])) return false;
        foreach(int index in new int[] {1,2,3,5,6 })
        {
            int tmp;
            if (!int.TryParse(t[index],out tmp))
                return false;
        }
        return true;
    }
    #endregion IsValidX
    
    internal static Transfer FromLine(string line)
    {
        string[] arr = line.Split(';');
        Target s, d;
        s = new(arr[0], int.Parse(arr[1]), int.Parse(arr[2]));
        d = new(arr[4], int.Parse(arr[5]), int.Parse(arr[6]));
        return new Transfer(s, d, int.Parse(arr[3]));
    }
}

#region Log
internal class Log
{
    const string LOG_FILE = "log.txt";
    public static void Note(string message) => File.AppendAllText(LOG_FILE, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + " | " + message);
}
#endregion Log