using EasyModbus;
ModbusServer plc = new ModbusServer();
plc.Listen();
Console.WriteLine("PLC started on port 502");
while (true)
Thread.Sleep(1000);