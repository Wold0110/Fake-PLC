using EasyModbus;

const string CONFIG_FILE = "config.cfg";

Console.WriteLine("start");
List<Transfer> transferList = new List<Transfer>();
foreach(string line in File.ReadAllLines(CONFIG_FILE))
{
    if (Transfer.ValidLine(line))
        transferList.Add(Transfer.FromLine(line));
    else
        Console.WriteLine("Wrong config line: "+line);
}
//TODO: Transfer data fron plc 0


struct Target
{
    internal ModbusClient client;
    internal int addr;
    internal Target(string ip, int port, int addr)
    {
        client = new(ip,port);
        this.addr = addr;
    }
}
class Transfer{
    Target source;
    Target destination;
    int length;
    internal Transfer(Target source, Target destination,int length)
    {
        this.source = source;
        this.destination = destination;
        this.length = length;
    }
    void Run() => destination.client.WriteMultipleRegisters(destination.addr,source.client.ReadHoldingRegisters(source.addr,length));
    
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
/*
//beleírok
ModbusClient client = new ModbusClient("10.147.17.6", 502);
client.Connect();

string @ref = "TESZTREF";

client.WriteMultipleRegisters(3000,    ModbusClient.ConvertStringToRegisters(@ref));

client.Disconnect();


Console.WriteLine("done...");
Console.ReadKey();


#pragma warning disable
int[] ShortToInt(short[] array)
{
    int[] res = new int[array.Length];
    for(int i = 0; i < array.Length; i++)
        res[i] = array[i];
    return res;
}
short[] IntToShort(int[] array)
{
    short[] res = new short[array.Length];
    for (int i = 0; i < array.Length; ++i)
        res[i] = short.Parse(array[i]+"");
    return res;
}
*/