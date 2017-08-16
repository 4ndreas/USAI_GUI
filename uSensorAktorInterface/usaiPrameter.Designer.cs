namespace uSensorAktorInterface
{
    partial class usaiPrameter
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
            this.checkBoxGraph = new System.Windows.Forms.CheckBox();
            this.buttonGET = new System.Windows.Forms.Button();
            this.buttonSET = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(56, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(170, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(284, 9);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(144, 20);
            this.textBoxValue.TabIndex = 2;
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.Location = new System.Drawing.Point(434, 9);
            this.numericUpDownMin.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.numericUpDownMin.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMin.TabIndex = 3;
            this.numericUpDownMin.ValueChanged += new System.EventHandler(this.numericUpDownMin_ValueChanged);
            // 
            // numericUpDownMax
            // 
            this.numericUpDownMax.Location = new System.Drawing.Point(560, 10);
            this.numericUpDownMax.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.numericUpDownMax.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numericUpDownMax.Name = "numericUpDownMax";
            this.numericUpDownMax.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMax.TabIndex = 4;
            this.numericUpDownMax.ValueChanged += new System.EventHandler(this.numericUpDownMax_ValueChanged);
            // 
            // checkBoxGraph
            // 
            this.checkBoxGraph.AutoSize = true;
            this.checkBoxGraph.Location = new System.Drawing.Point(686, 11);
            this.checkBoxGraph.Name = "checkBoxGraph";
            this.checkBoxGraph.Size = new System.Drawing.Size(55, 17);
            this.checkBoxGraph.TabIndex = 5;
            this.checkBoxGraph.Text = "Graph";
            this.checkBoxGraph.UseVisualStyleBackColor = true;
            this.checkBoxGraph.CheckedChanged += new System.EventHandler(this.checkBoxGraph_CheckedChanged);
            // 
            // buttonGET
            // 
            this.buttonGET.Location = new System.Drawing.Point(4, 4);
            this.buttonGET.Name = "buttonGET";
            this.buttonGET.Size = new System.Drawing.Size(46, 31);
            this.buttonGET.TabIndex = 6;
            this.buttonGET.Text = "GET";
            this.buttonGET.UseVisualStyleBackColor = true;
            this.buttonGET.Click += new System.EventHandler(this.buttonGET_Click);
            // 
            // buttonSET
            // 
            this.buttonSET.Location = new System.Drawing.Point(232, 3);
            this.buttonSET.Name = "buttonSET";
            this.buttonSET.Size = new System.Drawing.Size(46, 31);
            this.buttonSET.TabIndex = 6;
            this.buttonSET.Text = "SET";
            this.buttonSET.UseVisualStyleBackColor = true;
            this.buttonSET.Click += new System.EventHandler(this.buttonSET_Click);
            // 
            // usaiPrameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.buttonSET);
            this.Controls.Add(this.buttonGET);
            this.Controls.Add(this.checkBoxGraph);
            this.Controls.Add(this.numericUpDownMax);
            this.Controls.Add(this.numericUpDownMin);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxName);
            this.Name = "usaiPrameter";
            this.Size = new System.Drawing.Size(832, 35);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.NumericUpDown numericUpDownMax;
        private System.Windows.Forms.CheckBox checkBoxGraph;
        private System.Windows.Forms.Button buttonGET;
        private System.Windows.Forms.Button buttonSET;
    }
}
