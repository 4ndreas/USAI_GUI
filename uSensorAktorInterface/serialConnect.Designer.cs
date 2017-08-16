namespace uSensorAktorInterface
{
    partial class serialConnect
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSerialports = new System.Windows.Forms.ComboBox();
            this.labelSerialport = new System.Windows.Forms.Label();
            this.labelBaud = new System.Windows.Forms.Label();
            this.textBoxBaud = new System.Windows.Forms.TextBox();
            this.buttonReloadPorts = new System.Windows.Forms.Button();
            this.buttonGetALL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(553, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(83, 32);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(642, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxSerialports
            // 
            this.comboBoxSerialports.FormattingEnabled = true;
            this.comboBoxSerialports.Location = new System.Drawing.Point(68, 8);
            this.comboBoxSerialports.Name = "comboBoxSerialports";
            this.comboBoxSerialports.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialports.TabIndex = 2;
            // 
            // labelSerialport
            // 
            this.labelSerialport.AutoSize = true;
            this.labelSerialport.Location = new System.Drawing.Point(8, 11);
            this.labelSerialport.Name = "labelSerialport";
            this.labelSerialport.Size = new System.Drawing.Size(54, 13);
            this.labelSerialport.TabIndex = 3;
            this.labelSerialport.Text = "Serialport:";
            // 
            // labelBaud
            // 
            this.labelBaud.AutoSize = true;
            this.labelBaud.Location = new System.Drawing.Point(256, 12);
            this.labelBaud.Name = "labelBaud";
            this.labelBaud.Size = new System.Drawing.Size(35, 13);
            this.labelBaud.TabIndex = 4;
            this.labelBaud.Text = "Baud:";
            // 
            // textBoxBaud
            // 
            this.textBoxBaud.Location = new System.Drawing.Point(298, 8);
            this.textBoxBaud.Name = "textBoxBaud";
            this.textBoxBaud.Size = new System.Drawing.Size(81, 20);
            this.textBoxBaud.TabIndex = 5;
            this.textBoxBaud.Text = "115200";
            // 
            // buttonReloadPorts
            // 
            this.buttonReloadPorts.Location = new System.Drawing.Point(195, 6);
            this.buttonReloadPorts.Name = "buttonReloadPorts";
            this.buttonReloadPorts.Size = new System.Drawing.Size(23, 23);
            this.buttonReloadPorts.TabIndex = 6;
            this.buttonReloadPorts.Text = "R";
            this.buttonReloadPorts.UseVisualStyleBackColor = true;
            this.buttonReloadPorts.Click += new System.EventHandler(this.buttonReloadPorts_Click);
            // 
            // buttonGetALL
            // 
            this.buttonGetALL.Location = new System.Drawing.Point(504, 3);
            this.buttonGetALL.Name = "buttonGetALL";
            this.buttonGetALL.Size = new System.Drawing.Size(43, 32);
            this.buttonGetALL.TabIndex = 7;
            this.buttonGetALL.Text = "GET";
            this.buttonGetALL.UseVisualStyleBackColor = true;
            this.buttonGetALL.Click += new System.EventHandler(this.buttonGetALL_Click);
            // 
            // serialConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGetALL);
            this.Controls.Add(this.buttonReloadPorts);
            this.Controls.Add(this.textBoxBaud);
            this.Controls.Add(this.labelBaud);
            this.Controls.Add(this.labelSerialport);
            this.Controls.Add(this.comboBoxSerialports);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonConnect);
            this.Name = "serialConnect";
            this.Size = new System.Drawing.Size(682, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxSerialports;
        private System.Windows.Forms.Label labelSerialport;
        private System.Windows.Forms.Label labelBaud;
        private System.Windows.Forms.TextBox textBoxBaud;
        private System.Windows.Forms.Button buttonReloadPorts;
        private System.Windows.Forms.Button buttonGetALL;
    }
}
