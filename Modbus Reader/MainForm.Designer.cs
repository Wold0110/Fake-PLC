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
            this.intRadio = new System.Windows.Forms.RadioButton();
            this.stringRadio = new System.Windows.Forms.RadioButton();
            this.doubleRadio = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.fromNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // intRadio
            // 
            this.intRadio.AutoSize = true;
            this.intRadio.Location = new System.Drawing.Point(12, 95);
            this.intRadio.Name = "intRadio";
            this.intRadio.Size = new System.Drawing.Size(39, 19);
            this.intRadio.TabIndex = 0;
            this.intRadio.TabStop = true;
            this.intRadio.Text = "Int";
            this.intRadio.UseVisualStyleBackColor = true;
            this.intRadio.CheckedChanged += new System.EventHandler(this.intRadio_CheckedChanged);
            // 
            // stringRadio
            // 
            this.stringRadio.AutoSize = true;
            this.stringRadio.Location = new System.Drawing.Point(12, 124);
            this.stringRadio.Name = "stringRadio";
            this.stringRadio.Size = new System.Drawing.Size(56, 19);
            this.stringRadio.TabIndex = 1;
            this.stringRadio.TabStop = true;
            this.stringRadio.Text = "String";
            this.stringRadio.UseVisualStyleBackColor = true;
            this.stringRadio.CheckedChanged += new System.EventHandler(this.stringRadio_CheckedChanged);
            // 
            // doubleRadio
            // 
            this.doubleRadio.AutoSize = true;
            this.doubleRadio.Location = new System.Drawing.Point(12, 149);
            this.doubleRadio.Name = "doubleRadio";
            this.doubleRadio.Size = new System.Drawing.Size(63, 19);
            this.doubleRadio.TabIndex = 2;
            this.doubleRadio.TabStop = true;
            this.doubleRadio.Text = "Double";
            this.doubleRadio.UseVisualStyleBackColor = true;
            this.doubleRadio.CheckedChanged += new System.EventHandler(this.doubleRadio_CheckedChanged);
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(90, 91);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(120, 23);
            this.ipText.TabIndex = 3;
            // 
            // fromNUD
            // 
            this.fromNUD.Location = new System.Drawing.Point(90, 120);
            this.fromNUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.fromNUD.Name = "fromNUD";
            this.fromNUD.Size = new System.Drawing.Size(120, 23);
            this.fromNUD.TabIndex = 4;
            // 
            // lengthNUD
            // 
            this.lengthNUD.Location = new System.Drawing.Point(90, 149);
            this.lengthNUD.Maximum = new decimal(new int[] {
            655535,
            0,
            0,
            0});
            this.lengthNUD.Name = "lengthNUD";
            this.lengthNUD.Size = new System.Drawing.Size(120, 23);
            this.lengthNUD.TabIndex = 5;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 178);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(73, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Hozzáad";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // modbusList
            // 
            this.modbusList.FormattingEnabled = true;
            this.modbusList.ItemHeight = 15;
            this.modbusList.Location = new System.Drawing.Point(216, 14);
            this.modbusList.Name = "modbusList";
            this.modbusList.Size = new System.Drawing.Size(572, 424);
            this.modbusList.TabIndex = 7;
            // 
            // portNUD
            // 
            this.portNUD.Location = new System.Drawing.Point(90, 178);
            this.portNUD.Maximum = new decimal(new int[] {
            655535,
            0,
            0,
            0});
            this.portNUD.Name = "portNUD";
            this.portNUD.Size = new System.Drawing.Size(120, 23);
            this.portNUD.TabIndex = 8;
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
            this.refreshBtn.Size = new System.Drawing.Size(198, 23);
            this.refreshBtn.TabIndex = 9;
            this.refreshBtn.Text = "Frissít";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(12, 232);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(198, 23);
            this.inputText.TabIndex = 10;
            // 
            // inputNUD
            // 
            this.inputNUD.Location = new System.Drawing.Point(12, 232);
            this.inputNUD.Name = "inputNUD";
            this.inputNUD.Size = new System.Drawing.Size(198, 23);
            this.inputNUD.TabIndex = 11;
            // 
            // writeBtn
            // 
            this.writeBtn.Location = new System.Drawing.Point(12, 262);
            this.writeBtn.Name = "writeBtn";
            this.writeBtn.Size = new System.Drawing.Size(198, 23);
            this.writeBtn.TabIndex = 12;
            this.writeBtn.Text = "Írás";
            this.writeBtn.UseVisualStyleBackColor = true;
            this.writeBtn.Click += new System.EventHandler(this.writeBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Controls.Add(this.doubleRadio);
            this.Controls.Add(this.stringRadio);
            this.Controls.Add(this.intRadio);
            this.Name = "MainForm";
            this.Text = "Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.fromNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton intRadio;
        private RadioButton stringRadio;
        private RadioButton doubleRadio;
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
    }
}