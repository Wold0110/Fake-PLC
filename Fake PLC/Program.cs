using EasyModbus;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//PLC setup
ModbusServer plc = new ModbusServer();
plc.Listen();
Thread.Sleep(250);

//Kiolvasom a kezdetit
string register = ModbusClient.ConvertRegistersToString(ShortToInt(plc.holdingRegisters.localArray),0,16);
Console.WriteLine("register:"+register+"|");


//beleírok
ModbusClient client = new ModbusClient("127.0.0.1",502);
client.Connect();
int[] toWrite = ModbusClient.ConvertStringToRegisters("szia");
client.WriteMultipleRegisters(0,toWrite);
client.Disconnect();


//kiolvasom változott-e
register = ModbusClient.ConvertRegistersToString(ShortToInt(plc.holdingRegisters.localArray), 0, 16);
Console.WriteLine("register:" + register + "|");


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