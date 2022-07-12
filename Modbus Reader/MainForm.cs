namespace Modbus_Reader
{
    public enum ReadType
    {
        Int,
        String,
        Double
    }
    public partial class MainForm : Form
    {
        List<ModbusTarget> mtl = new List<ModbusTarget>();
        public MainForm()
        {
            InitializeComponent();
        }
        void MakeList()
        {
            modbusList.Items.Clear();
            foreach(ModbusTarget m in mtl)
            {
                m.Read();
                modbusList.Items.Add(m);
            }
        }
        public ReadType GetReadType()
        {
            if (stringRadio.Checked) return ReadType.String;
            if (doubleRadio.Checked) return ReadType.Double;
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
        private void addBtn_Click(object sender, EventArgs e)
        {
            //validate IP
            string ip = ipText.Text;
            if (IsValidIP(ip))
            {
                int addr = (int)fromNUD.Value;
                int length = (int)lengthNUD.Value;
                int port = (int)portNUD.Value;
                if(addr+length > 65535)
                {
                    //TODO: overspill error
                    MessageBox.Show("Túllóg a címzési tartományon (cím+hossz > 65535)");
                }
                else
                {
                    ModbusTarget mod= null;
                    ReadType type = GetReadType();
                    switch (type)
                    {
                        case ReadType.String:
                            mod = new ModbusStringTarget(ip, addr, length,port);
                            break;
                        case ReadType.Double:
                            mod = new ModbusTarget(ip, addr, length,port);
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

        private void autoRefreshCB_CheckStateChanged(object sender, EventArgs e)
        {
            MessageBox.Show("asd");
        }
    }
}