﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace Modbus_Reader
{
    internal class ModbusTarget
    {
        public static string CheckMark => "✅"; //✅
        public static string RedX => "❌";  // ❌
        string ip;
        public int addr;
        public int length;
        int port;
        public string Status => mc.Connected ? CheckMark : RedX;
        public ModbusClient mc;
        public ModbusTarget(string ip, int addr, int length, int port)
        {
            this.ip = ip;
            this.addr = addr;
            this.length = length;
            this.port = port;
            mc = new(ip, port);
        }
        public override string ToString() => ip + ":" + port+" "+Status+ "\t" + addr + ":" + length;
        public virtual void Read() { }
    }
    internal class ModbusIntTarget : ModbusTarget
    {
        int Value;
        public ModbusIntTarget(string ip, int addr, int length, int port) : base(ip, addr, length, port) { }
        public override void Read()
        {
            mc.Connect();
            if(mc.Connected)
                Value = mc.ReadHoldingRegisters(addr, length)[0];
            mc.Disconnect();
        }
        public override string ToString()=> base.ToString()+"\tÉrték: "+Value;
    }
    internal class ModbusStringTarget : ModbusTarget
    {
        string Value="";

        public ModbusStringTarget(string ip, int addr, int length, int port) : base(ip, addr, length, port) { }
        public override void Read()
        {
            mc.Connect();
            if (mc.Connected)
                Value = ModbusClient.ConvertRegistersToString(mc.ReadHoldingRegisters(addr, length),0,length);
            mc.Disconnect();
        }
        public override string ToString() => base.ToString() + "\tÉrték: " + Value;
    }
}