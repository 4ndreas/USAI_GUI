namespace uSensorAktorInterface
{
    partial class usaiForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageControl = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageConnect = new System.Windows.Forms.TabPage();
            this.buttonAddUdp = new System.Windows.Forms.Button();
            this.buttonAddSerial = new System.Windows.Forms.Button();
            this.flowLayoutPanelConnections = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageControl.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.tabPageConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageControl);
            this.tabControl1.Controls.Add(this.tabPageGraph);
            this.tabControl1.Controls.Add(this.tabPageConfig);
            this.tabControl1.Controls.Add(this.tabPageConnect);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 551);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageControl
            // 
            this.tabPageControl.Controls.Add(this.flowLayoutPanel1);
            this.tabPageControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageControl.Name = "tabPageControl";
            this.tabPageControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControl.Size = new System.Drawing.Size(860, 525);
            this.tabPageControl.TabIndex = 0;
            this.tabPageControl.Text = "Control";
            this.tabPageControl.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(848, 513);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Size = new System.Drawing.Size(860, 525);
            this.tabPageGraph.TabIndex = 2;
            this.tabPageGraph.Text = "Graph";
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.flowLayoutPanelConfig);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(860, 525);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelConfig
            // 
            this.flowLayoutPanelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelConfig.AutoScroll = true;
            this.flowLayoutPanelConfig.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanelConfig.Name = "flowLayoutPanelConfig";
            this.flowLayoutPanelConfig.Size = new System.Drawing.Size(848, 513);
            this.flowLayoutPanelConfig.TabIndex = 0;
            // 
            // tabPageConnect
            // 
            this.tabPageConnect.Controls.Add(this.buttonAddUdp);
            this.tabPageConnect.Controls.Add(this.buttonAddSerial);
            this.tabPageConnect.Controls.Add(this.flowLayoutPanelConnections);
            this.tabPageConnect.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnect.Name = "tabPageConnect";
            this.tabPageConnect.Size = new System.Drawing.Size(860, 525);
            this.tabPageConnect.TabIndex = 3;
            this.tabPageConnect.Text = "Connect";
            this.tabPageConnect.UseVisualStyleBackColor = true;
            // 
            // buttonAddUdp
            // 
            this.buttonAddUdp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddUdp.Location = new System.Drawing.Point(695, 499);
            this.buttonAddUdp.Name = "buttonAddUdp";
            this.buttonAddUdp.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUdp.TabIndex = 1;
            this.buttonAddUdp.Text = "UDP";
            this.buttonAddUdp.UseVisualStyleBackColor = true;
            this.buttonAddUdp.Click += new System.EventHandler(this.buttonAddUdp_Click);
            // 
            // buttonAddSerial
            // 
            this.buttonAddSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSerial.Location = new System.Drawing.Point(776, 499);
            this.buttonAddSerial.Name = "buttonAddSerial";
            this.buttonAddSerial.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSerial.TabIndex = 1;
            this.buttonAddSerial.Text = "Serial";
            this.buttonAddSerial.UseVisualStyleBackColor = true;
            this.buttonAddSerial.Click += new System.EventHandler(this.buttonAddSerial_Click);
            // 
            // flowLayoutPanelConnections
            // 
            this.flowLayoutPanelConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelConnections.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelConnections.Name = "flowLayoutPanelConnections";
            this.flowLayoutPanelConnections.Size = new System.Drawing.Size(854, 490);
            this.flowLayoutPanelConnections.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Universal Sensor Aktor Interface";
            this.tabControl1.ResumeLayout(false);
            this.tabPageControl.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConnect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageControl;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConfig;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.TabPage tabPageConnect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConnections;
        private System.Windows.Forms.Button buttonAddUdp;
        private System.Windows.Forms.Button buttonAddSerial;
    }
}

