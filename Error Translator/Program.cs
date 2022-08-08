using EasyModbus;
//See https://aka.ms/new-console-template for more information
List<Machine> machines = new List<Machine>();
Console.WriteLine("Starting...");

internal class Machine
{
    ModbusClient target;
    int targetAddr;

    ModbusClient source;
    List<ErroCode> codes = new List<ErroCode>();

    internal Machine(string targetIP, int targetPort, string sourceIP, int sourcePort, int targetAddr)
    {
        target = new(targetIP, targetPort);
        source = new(sourceIP, sourcePort);
        this.targetAddr = targetAddr;
    }
    internal bool AddCode(string line)
    {

    }
}
internal class ErroCode
{
    int addr;
    int num;    
} 