namespace Modbus_Reader
{
    public enum ReadType
    {
        Int,
        String
    }
    public partial class MainForm : Form
    {

        List<ModbusTarget> mtl = new List<ModbusTarget>();
        public MainForm() => InitializeComponent();
        void MakeList()
        {
            modbusList.Items.Clear();
            foreach(ModbusTarget m in mtl) { m.Read(); modbusList.Items.Add(m); }
        }
        public ReadType GetReadType()
        {
            if (stringRadio.Checked) return ReadType.String;
            return ReadType.Int;
        }
        bool IsValidIP(string ip)
        {
            if(String.IsNullOrWhiteSpace(ip)) return false;
            string[] t = ip.Split('.');
            if(t.Length != 4) return false;
            byte temp;
            return t.All(x => byte.TryParse(x, out temp));
        }
        #region Button-Click
        private void delBtn_Click(object sender, EventArgs e)
        {
            object o = modbusList.SelectedItem;
            if(o != null)
            {
                ModbusTarget mt = (ModbusTarget)o;
                mtl.Remove(mt);
                MakeList();
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            //validate IP
            string ip = ipText.Text;
            if (IsValidIP(ip))
            {
                int addr = (int)fromNUD.Value;
                int length = (int)lengthNUD.Value;
                int port = (int)portNUD.Value;
                if(addr+length > 65535) //would overspill
                    MessageBox.Show("T�ll�g a c�mz�si tartom�nyon (c�m+hossz > 65535)");
                else
                {
                    ModbusTarget mod= null;
                    ReadType type = GetReadType();
                    switch (type)
                    {
                        case ReadType.String:
                            mod = new ModbusStringTarget(ip, addr, length,port);
                            break;
                        default: //INT
                            mod = new ModbusIntTarget(ip, addr, length,port);
                            break;
                    }
                    mtl.Add(mod);
                    MakeList();
                }
            }
            else //not valid IP
                MessageBox.Show("Hib�s IP c�m!");
        }
        #region radio
        void SwitchInput(bool isNumInput, int length)
        {
            lengthNUD.Enabled = !isNumInput;
            lengthNUD.Value = length;
            if (isNumInput) { inputText.Hide(); inputNUD.Show(); }
            else{ inputText.Show(); inputNUD.Hide(); }
        }
        private void intRadio_CheckedChanged(object sender, EventArgs e) => SwitchInput(true, 2);


        private void stringRadio_CheckedChanged(object sender, EventArgs e) => SwitchInput(false, 16);

        private void doubleRadio_CheckedChanged(object sender, EventArgs e) => SwitchInput(true, 4);

        #endregion radio
        private void refreshBtn_Click(object sender, EventArgs e) => MakeList();

        private void writeBtn_Click(object sender, EventArgs e)
        {
            //validate IP
            string ip = ipText.Text;
            if (IsValidIP(ip))
            {
                int addr = (int)fromNUD.Value;
                int length = (int)lengthNUD.Value;
                int port = (int)portNUD.Value;
                if (addr + length > 65535)
                {
                    //TODO: overspill error
                    MessageBox.Show("T�ll�g a c�mz�si tartom�nyon (c�m+hossz > 65535)");
                }
                else
                {
                    switch (GetReadType())
                    {
                        case ReadType.String:
                            ModbusTarget.WriteToPLC(ip, port, addr,inputText.Text);
                            break;
                        default:
                            ModbusTarget.WriteToPLC(ip, port, addr, (int)inputNUD.Value);
                            break;
                    }
                }
            }
            else //not valid IP
                MessageBox.Show("Hib�s IP c�m!");
        }
        #endregion
        private void autoRefreshCB_CheckStateChanged(object sender, EventArgs e)
        {
            if (autoRefreshCB.Checked)
            {
                //auto refresh bekapcsolva
                refreshIntervalNUD.Enabled = true;
                new Thread(AutomaticRefresh).Start();
            }
            else
            {
                //auto refresh kikapcsolva
                refreshIntervalNUD.Enabled = false;
            }
        }
        void AutomaticRefresh()
        {
            while(autoRefreshCB.Checked)
            {
                Thread.Sleep((int)refreshIntervalNUD.Value);
                if(autoRefreshCB.Checked)
                    MakeList();
            }
        }

        //close thread when hittin  ,X' 
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => autoRefreshCB.Checked = false;

        private void modbusList_DoubleClick(object sender, EventArgs e)
        {
            object o = modbusList.SelectedItem;
            if(o != null)
            {
                ModbusTarget mt = (ModbusTarget)o;
                lengthNUD.Value = mt.length;
                ipText.Text = mt.mc.IPAddress;
                portNUD.Value = mt.mc.Port;
                fromNUD.Value = mt.addr;
                if(o is ModbusIntTarget)    //INT
                {
                    intRadio.Checked = true;
                    inputNUD.Value = ((ModbusIntTarget)o).Value;
                }   
                if(o is ModbusStringTarget) //STRING
                {
                    stringRadio.Checked = true;
                    inputText.Text = ((ModbusStringTarget)o).Value;
                }
            }
        }
    }
}