using EasyModbus;
//See https://aka.ms/new-console-template for more information
const string CONFIG_FILE = "settings.txt";
List<Machine> machines = new List<Machine>();
Console.WriteLine("Starting...");
List<string> lines = File.ReadAllLines(CONFIG_FILE).Where(x => x[0] != '#').ToList();
Machine m = null;
foreach (string line in lines) {
    if (line[0] != ';')
    {
        //machine
        Machine tmp;
        if(Machine.NewMachine(line,out tmp))
        {
            machines.Add(m);
            m = tmp;
        }
    }
    else
    {
        //code
        m.AddCode(line);
    }
}
internal class Machine
{
    ModbusClient target; //fake PLC
    int targetAddr;
    ModbusClient source; //target where LDS reads from

    List<ErrorCode> codes = new List<ErrorCode>();
    List<int> buffer = new List<int>();
    
    internal Machine(string targetIP, int targetPort, string sourceIP, int sourcePort, int targetAddr)
    {
        target = new(targetIP, targetPort);
        source = new(sourceIP, sourcePort);
        this.targetAddr = targetAddr;
    }
    internal void Run()
    {
        buffer.Clear();
        codes.ForEach(x => x.Run(source).ForEach(y => buffer.Add(y)));
        target.Connect();
        if (target.Connected)
        {
            buffer.ForEach(x => {
                target.WriteSingleRegister(targetAddr, x);
                while (target.ReadHoldingRegisters(targetAddr, 1)[0] != 0)
                    Thread.Sleep(500);
            });
        }
        
    }
    #region SettingUp-ObjectCreation
    internal static bool NewMachine(string line, out Machine m)
    {
        m = null;
        string[] arr = line.Split(';');
        //correct parameter num
        if (arr.Length != 5) return false;
        //IP check
        if (!IsValidIP(arr[0]) || !IsValidIP(arr[2])) return false;
        //port and address check isINT
        int port1, port2, addr;
        if(!int.TryParse(arr[1],out port1) || !int.TryParse(arr[3],out port2)
            || !int.TryParse(arr[4], out addr)) return false;
        //port and adress
        if(0 > port1 || port1 > 65535 ||
           0 > port2 || port2 > 65535 ||
           0 > addr  || addr  > 65535) 
            return false;
        //return all are correct
        m = new(arr[0], port1, arr[2], port2, addr);
        return true;
    }
    internal bool AddCode(string line)
    {
        if (line[0]!=';')
            return false;
        string[] arr = line.Split(';');
        if (arr.Length != 3)
            return false;
        int addr,code;
        if (!int.TryParse(arr[1], out addr) || !int.TryParse(arr[2], out code))
            return false;
        if (addr < 0 || addr > 65535)
            return false;
        if (code < 0 || code > 32768)
            return false;
        codes.Add(new(addr, code));
        return true;
    }
    internal static bool IsValidIP(string ip)
    {
        if (String.IsNullOrWhiteSpace(ip)) return false;
        string[] t = ip.Split('.');
        if (t.Length != 4) return false;
        byte temp;
        return t.All(x => byte.TryParse(x, out temp));
    }
    #endregion SettingUp-ObjectCreation
}

internal class ErrorCode
{
    int addr;   //PLC address
    int code;   //error code
    int num;    //number of errors
    internal ErrorCode(int addr,int code)
    {
        this.addr = addr;
        this.code = code;
        num = 0;
    }
    internal List<int> Run(ModbusClient source)
    {
        List<int> value = new List<int>();
        source.Connect();
        if (source.Connected) {
            int read = source.ReadHoldingRegisters(addr, 1)[0];
            source.Disconnect();
            if (read < num) num = read;
            else
            {
                for (int i = 0; i < read - num; ++i)
                    value.Add(code);
                num = read;
            }
        }
        return value;
    }
} 