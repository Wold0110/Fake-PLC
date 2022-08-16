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
        public MainForm(string fileName) { InitializeComponent(); importFromFile(fileName); }
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
            string name = "";
            if(!String.IsNullOrEmpty(nameText.Text))
                name = nameText.Text;
            if (IsValidIP(ip))
            {
                int addr = (int)fromNUD.Value;
                int length = (int)lengthNUD.Value;
                int port = (int)portNUD.Value;
                if(addr+length > 65535) //would overspill
                    MessageBox.Show("Túllóg a címzési tartományon (cím+hossz > 65535)");
                else
                {
                    ModbusTarget mod= null;
                    ReadType type = GetReadType();
                    switch (type)
                    {
                        case ReadType.String:
                            mod = new ModbusStringTarget(ip, addr, length,port,name);
                            break;
                        default: //INT
                            mod = new ModbusIntTarget(ip, addr, length,port,name);
                            break;
                    }
                    mtl.Add(mod);
                    MakeList();
                }
            }
            else //not valid IP
                MessageBox.Show("Hibás IP cím!");
        }
        #region radio
        void SwitchInput(bool isNumInput, int length)
        {
            lengthNUD.Enabled = !isNumInput;
            lengthNUD.Value = length;
            if (isNumInput) { inputText.Hide(); inputNUD.Show(); }
            else{ inputText.Show(); inputNUD.Hide(); }
        }
        private void intRadio_CheckedChanged(object sender, EventArgs e) => SwitchInput(true, 1);
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
                    MessageBox.Show("Túllóg a címzési tartományon (cím+hossz > 65535)");
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
                MessageBox.Show("Hibás IP cím!");
        }

        //SETTINGS STORED IN FILE
        const string EXTENSION = "wsbs";
        const string FILTER = $"Exported files (*.{EXTENSION})|*.{EXTENSION}|Every file (*.*|*.*";
        private void importBtn_Click(object sender, EventArgs e)
        {
            //import BTN
            OpenFileDialog ofd = new();
            ofd.Filter = FILTER;
            ofd.Title = "Load Modbus Tool config";
            if(DialogResult.OK == ofd.ShowDialog())
            {
                importFromFile(ofd.FileName);
            }
        }
        private void exportBtn_Click(object sender, EventArgs e)//export BTN
        {
            SaveFileDialog sfd = new();
            sfd.DefaultExt = EXTENSION;
            sfd.Filter = FILTER;
            sfd.Title = "Save Modbus Tool File";
            
            if(DialogResult.OK == sfd.ShowDialog())
            {
                string fileName = sfd.FileName;
                List<string> config = new List<string>();
                foreach (ModbusTarget m in modbusList.Items)
                {
                    //type;ip;addr;length;port;name
                    //string;10.147.16.29;0;16;502;Fake PLC Ref
                    string line = "";
                    if (m is ModbusStringTarget)
                        line += "string;";
                    if (m is ModbusIntTarget)
                        line += "int;";
                    line += m.ip + ";" + m.addr + ";" + m.length + ";" + m.port + ";" + m.name;
                    config.Add(line);
                }
                File.WriteAllLines(fileName, config);
            }
            
        }

        #endregion Button-Click
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

        void importFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string x in lines)
            {
                string[] row = x.Split(';');
                ModbusTarget mt = null;
                if (row[0] == "string")
                    mt = new ModbusStringTarget(row[1], int.Parse(row[2]), int.Parse(row[3]), int.Parse(row[4]), row[5]);
                if (row[0] == "int")
                    mt = new ModbusIntTarget(row[1], int.Parse(row[2]), int.Parse(row[3]), int.Parse(row[4]), row[5]);
                if (mt is not null)
                    mtl.Add(mt);
            }
            MakeList();
        }
    }
}