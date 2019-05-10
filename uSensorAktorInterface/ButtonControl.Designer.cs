namespace uSensorAktorInterface
{
    partial class ButtonControl
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timerAutoReset = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItemAutoReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxklicked = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItemRCount = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(15, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 120);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripButton
            // 
            this.contextMenuStripButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAutoReset,
            this.toolStripTextBoxklicked,
            this.toolStripMenuItemRCount});
            this.contextMenuStripButton.Name = "contextMenuStripButton";
            this.contextMenuStripButton.Size = new System.Drawing.Size(181, 95);
            // 
            // timerAutoReset
            // 
            this.timerAutoReset.Tick += new System.EventHandler(this.timerAutoReset_Tick);
            // 
            // toolStripMenuItemAutoReset
            // 
            this.toolStripMenuItemAutoReset.CheckOnClick = true;
            this.toolStripMenuItemAutoReset.Name = "toolStripMenuItemAutoReset";
            this.toolStripMenuItemAutoReset.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAutoReset.Text = "AutoReset";
            // 
            // toolStripTextBoxklicked
            // 
            this.toolStripTextBoxklicked.Name = "toolStripTextBoxklicked";
            this.toolStripTextBoxklicked.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItemRCount
            // 
            this.toolStripMenuItemRCount.Name = "toolStripMenuItemRCount";
            this.toolStripMenuItemRCount.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemRCount.Text = "Reset Counter";
            this.toolStripMenuItemRCount.Click += new System.EventHandler(this.toolStripMenuItemRCount_Click);
            // 
            // ButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.button1);
            this.Name = "ButtonControl";
            this.contextMenuStripButton.ResumeLayout(false);
            this.contextMenuStripButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripButton;
        private System.Windows.Forms.Timer timerAutoReset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAutoReset;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxklicked;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRCount;
    }
}
