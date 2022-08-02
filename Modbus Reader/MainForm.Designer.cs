namespace Modbus_Reader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.intRadio = new System.Windows.Forms.RadioButton();
            this.stringRadio = new System.Windows.Forms.RadioButton();
            this.ipText = new System.Windows.Forms.TextBox();
            this.fromNUD = new System.Windows.Forms.NumericUpDown();
            this.lengthNUD = new System.Windows.Forms.NumericUpDown();
            this.addBtn = new System.Windows.Forms.Button();
            this.modbusList = new System.Windows.Forms.ListBox();
            this.portNUD = new System.Windows.Forms.NumericUpDown();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.inputNUD = new System.Windows.Forms.NumericUpDown();
            this.writeBtn = new System.Windows.Forms.Button();
            this.autoRefreshCB = new System.Windows.Forms.CheckBox();
            this.refreshIntervalNUD = new System.Windows.Forms.NumericUpDown();
            this.refreshLabel = new System.Windows.Forms.Label();
            this.delBtn = new System.Windows.Forms.Button();
            this.ipLabel = new System.Windows.Forms.Label();
            this.addrLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.writeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fromNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshIntervalNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // intRadio
            // 
            this.intRadio.AutoSize = true;
            this.intRadio.Location = new System.Drawing.Point(71, 208);
            this.intRadio.Name = "intRadio";
            this.intRadio.Size = new System.Drawing.Size(39, 19);
            this.intRadio.TabIndex = 5;
            this.intRadio.TabStop = true;
            this.intRadio.Text = "Int";
            this.intRadio.UseVisualStyleBackColor = true;
            this.intRadio.CheckedChanged += new System.EventHandler(this.intRadio_CheckedChanged);
            // 
            // stringRadio
            // 
            this.stringRadio.AutoSize = true;
            this.stringRadio.Location = new System.Drawing.Point(9, 208);
            this.stringRadio.Name = "stringRadio";
            this.stringRadio.Size = new System.Drawing.Size(56, 19);
            this.stringRadio.TabIndex = 4;
            this.stringRadio.TabStop = true;
            this.stringRadio.Text = "String";
            this.stringRadio.UseVisualStyleBackColor = true;
            this.stringRadio.CheckedChanged += new System.EventHandler(this.stringRadio_CheckedChanged);
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(56, 88);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(136, 23);
            this.ipText.TabIndex = 0;
            // 
            // fromNUD
            // 
            this.fromNUD.Location = new System.Drawing.Point(56, 146);
            this.fromNUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.fromNUD.Name = "fromNUD";
            this.fromNUD.Size = new System.Drawing.Size(136, 23);
            this.fromNUD.TabIndex = 2;
            // 
            // lengthNUD
            // 
            this.lengthNUD.Location = new System.Drawing.Point(56, 175);
            this.lengthNUD.Maximum = new decimal(new int[] {
            655535,
            0,
            0,
            0});
            this.lengthNUD.Name = "lengthNUD";
            this.lengthNUD.Size = new System.Drawing.Size(136, 23);
            this.lengthNUD.TabIndex = 3;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(119, 206);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(203, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Hozzáad";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // modbusList
            // 
            this.modbusList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modbusList.FormattingEnabled = true;
            this.modbusList.ItemHeight = 15;
            this.modbusList.Location = new System.Drawing.Point(331, 14);
            this.modbusList.Name = "modbusList";
            this.modbusList.Size = new System.Drawing.Size(389, 214);
            this.modbusList.TabIndex = 7;
            this.modbusList.UseTabStops = false;
            this.modbusList.DoubleClick += new System.EventHandler(this.modbusList_DoubleClick);
            // 
            // portNUD
            // 
            this.portNUD.Location = new System.Drawing.Point(56, 117);
            this.portNUD.Maximum = new decimal(new int[] {
            655535,
            0,
            0,
            0});
            this.portNUD.Name = "portNUD";
            this.portNUD.Size = new System.Drawing.Size(136, 23);
            this.portNUD.TabIndex = 1;
            this.portNUD.Value = new decimal(new int[] {
            502,
            0,
            0,
            0});
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(12, 14);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(211, 23);
            this.refreshBtn.TabIndex = 9;
            this.refreshBtn.TabStop = false;
            this.refreshBtn.Text = "Frissít";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(198, 117);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(124, 23);
            this.inputText.TabIndex = 10;
            this.inputText.TabStop = false;
            // 
            // inputNUD
            // 
            this.inputNUD.Location = new System.Drawing.Point(198, 117);
            this.inputNUD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.inputNUD.Minimum = new decimal(new int[] {
            2147483646,
            0,
            0,
            -2147483648});
            this.inputNUD.Name = "inputNUD";
            this.inputNUD.Size = new System.Drawing.Size(124, 23);
            this.inputNUD.TabIndex = 11;
            this.inputNUD.TabStop = false;
            // 
            // writeBtn
            // 
            this.writeBtn.Location = new System.Drawing.Point(198, 148);
            this.writeBtn.Name = "writeBtn";
            this.writeBtn.Size = new System.Drawing.Size(124, 23);
            this.writeBtn.TabIndex = 12;
            this.writeBtn.TabStop = false;
            this.writeBtn.Text = "Írás";
            this.writeBtn.UseVisualStyleBackColor = true;
            this.writeBtn.Click += new System.EventHandler(this.writeBtn_Click);
            // 
            // autoRefreshCB
            // 
            this.autoRefreshCB.AutoSize = true;
            this.autoRefreshCB.Location = new System.Drawing.Point(229, 18);
            this.autoRefreshCB.Name = "autoRefreshCB";
            this.autoRefreshCB.Size = new System.Drawing.Size(96, 19);
            this.autoRefreshCB.TabIndex = 13;
            this.autoRefreshCB.TabStop = false;
            this.autoRefreshCB.Text = "Auto Frissítés";
            this.autoRefreshCB.UseVisualStyleBackColor = true;
            this.autoRefreshCB.CheckStateChanged += new System.EventHandler(this.autoRefreshCB_CheckStateChanged);
            // 
            // refreshIntervalNUD
            // 
            this.refreshIntervalNUD.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.refreshIntervalNUD.Location = new System.Drawing.Point(229, 45);
            this.refreshIntervalNUD.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.refreshIntervalNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.refreshIntervalNUD.Name = "refreshIntervalNUD";
            this.refreshIntervalNUD.Size = new System.Drawing.Size(93, 23);
            this.refreshIntervalNUD.TabIndex = 14;
            this.refreshIntervalNUD.TabStop = false;
            this.refreshIntervalNUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // refreshLabel
            // 
            this.refreshLabel.AutoSize = true;
            this.refreshLabel.Location = new System.Drawing.Point(8, 47);
            this.refreshLabel.Name = "refreshLabel";
            this.refreshLabel.Size = new System.Drawing.Size(215, 15);
            this.refreshLabel.TabIndex = 15;
            this.refreshLabel.Text = "Frissítési intervallum (ezredmásodperc):";
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(198, 177);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(124, 23);
            this.delBtn.TabIndex = 16;
            this.delBtn.TabStop = false;
            this.delBtn.Text = "Törlés";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(13, 91);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(20, 15);
            this.ipLabel.TabIndex = 17;
            this.ipLabel.Text = "IP:";
            // 
            // addrLabel
            // 
            this.addrLabel.AutoSize = true;
            this.addrLabel.Location = new System.Drawing.Point(13, 148);
            this.addrLabel.Name = "addrLabel";
            this.addrLabel.Size = new System.Drawing.Size(32, 15);
            this.addrLabel.TabIndex = 18;
            this.addrLabel.Text = "Cím:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Hossz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Port:";
            // 
            // writeLabel
            // 
            this.writeLabel.AutoSize = true;
            this.writeLabel.Location = new System.Drawing.Point(229, 96);
            this.writeLabel.Name = "writeLabel";
            this.writeLabel.Size = new System.Drawing.Size(73, 15);
            this.writeLabel.TabIndex = 21;
            this.writeLabel.Text = "Írandó érték:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 234);
            this.Controls.Add(this.writeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addrLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.refreshLabel);
            this.Controls.Add(this.refreshIntervalNUD);
            this.Controls.Add(this.autoRefreshCB);
            this.Controls.Add(this.writeBtn);
            this.Controls.Add(this.inputNUD);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.portNUD);
            this.Controls.Add(this.modbusList);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.lengthNUD);
            this.Controls.Add(this.fromNUD);
            this.Controls.Add(this.ipText);
            this.Controls.Add(this.stringRadio);
            this.Controls.Add(this.intRadio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fromNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshIntervalNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton intRadio;
        private RadioButton stringRadio;
        private TextBox ipText;
        private NumericUpDown fromNUD;
        private NumericUpDown lengthNUD;
        private Button addBtn;
        private ListBox modbusList;
        private NumericUpDown portNUD;
        private Button refreshBtn;
        private TextBox inputText;
        private NumericUpDown inputNUD;
        private Button writeBtn;
        private CheckBox autoRefreshCB;
        private NumericUpDown refreshIntervalNUD;
        private Label refreshLabel;
        private Button delBtn;
        private Label ipLabel;
        private Label addrLabel;
        private Label label1;
        private Label label2;
        private Label writeLabel;
    }
}