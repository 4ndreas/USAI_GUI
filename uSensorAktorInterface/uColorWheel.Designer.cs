namespace uSensorAktorInterface
{
    partial class uColorWheel
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
            this.colorWheel2 = new uSensorAktorInterface.ColorWheel();
            this.SuspendLayout();
            // 
            // colorWheel2
            // 
            this.colorWheel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorWheel2.Hue = ((byte)(0));
            this.colorWheel2.Lightness = ((byte)(0));
            this.colorWheel2.Location = new System.Drawing.Point(3, 3);
            this.colorWheel2.Name = "colorWheel2";
            this.colorWheel2.Saturation = ((byte)(0));
            this.colorWheel2.SecondaryHues = null;
            this.colorWheel2.Size = new System.Drawing.Size(144, 144);
            this.colorWheel2.TabIndex = 0;
            this.colorWheel2.Text = "colorWheel2";
            // 
            // uColorWheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.colorWheel2);
            this.Name = "uColorWheel";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorWheel colorWheel2;
    }
}
