using EasyModbus;
int port = 502;
int portOverride = 0;
if (args.Length > 0)
    if (int.TryParse(args[0], out portOverride))
        port = portOverride;
ModbusServer plc = new ModbusServer();
plc.Port = port;
plc.Listen();
Console.WriteLine("PLC started on port "+plc.Port);
while (true)
Thread.Sleep(1000);