namespace PMDS.GUI.BaseControls
{
    partial class ucMedizinData
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblTxt = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblTxt
            // 
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.BorderColor2 = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTxt.Appearance = appearance1;
            this.lblTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt.Location = new System.Drawing.Point(0, 0);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(18, 18);
            this.lblTxt.TabIndex = 1;
            this.lblTxt.Visible = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.ultraToolTipManager1.InitialDelay = 0;
            this.ultraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            this.ultraToolTipManager1.ToolTipTitle = "Vorhandene Ressourcen";
            // 
            // ultraPictureBox1
            // 
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.BorderColor2 = System.Drawing.Color.Silver;
            this.ultraPictureBox1.Appearance = appearance2;
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(18, 18);
            this.ultraPictureBox1.TabIndex = 2;
            this.ultraPictureBox1.Visible = false;
            this.ultraPictureBox1.MouseEnter += new System.EventHandler(this.ultraPictureBox1_MouseEnter);
            // 
            // ucMedizinData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraPictureBox1);
            this.Controls.Add(this.lblTxt);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 3, 1);
            this.Name = "ucMedizinData";
            this.Size = new System.Drawing.Size(18, 18);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer2;
        public Infragistics.Win.Misc.UltraLabel lblTxt;
        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
    }
}
