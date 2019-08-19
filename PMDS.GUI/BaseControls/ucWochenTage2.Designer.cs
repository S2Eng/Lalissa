namespace PMDS.GUI
{
    partial class ucWochenTage2
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.cbSo = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbSa = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbFr = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbDo = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbMi = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbDi = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbMo = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.SuspendLayout();
            // 
            // cbSo
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.cbSo.Appearance = appearance1;
            this.cbSo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSo.Location = new System.Drawing.Point(123, 2);
            this.cbSo.Name = "cbSo";
            this.cbSo.Size = new System.Drawing.Size(24, 41);
            this.cbSo.TabIndex = 16;
            this.cbSo.Text = "So";
            this.cbSo.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbSa
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.cbSa.Appearance = appearance2;
            this.cbSa.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbSa.Location = new System.Drawing.Point(103, 2);
            this.cbSa.Name = "cbSa";
            this.cbSa.Size = new System.Drawing.Size(24, 41);
            this.cbSa.TabIndex = 15;
            this.cbSa.Text = "Sa";
            this.cbSa.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbFr
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.cbFr.Appearance = appearance3;
            this.cbFr.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbFr.Location = new System.Drawing.Point(83, 2);
            this.cbFr.Name = "cbFr";
            this.cbFr.Size = new System.Drawing.Size(24, 41);
            this.cbFr.TabIndex = 14;
            this.cbFr.Text = "Fr";
            this.cbFr.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbDo
            // 
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.cbDo.Appearance = appearance4;
            this.cbDo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbDo.Location = new System.Drawing.Point(63, 2);
            this.cbDo.Name = "cbDo";
            this.cbDo.Size = new System.Drawing.Size(24, 41);
            this.cbDo.TabIndex = 13;
            this.cbDo.Text = "Do";
            this.cbDo.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbMi
            // 
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.cbMi.Appearance = appearance5;
            this.cbMi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbMi.Location = new System.Drawing.Point(43, 2);
            this.cbMi.Name = "cbMi";
            this.cbMi.Size = new System.Drawing.Size(24, 41);
            this.cbMi.TabIndex = 12;
            this.cbMi.Text = "Mi";
            this.cbMi.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbDi
            // 
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.cbDi.Appearance = appearance6;
            this.cbDi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbDi.Location = new System.Drawing.Point(23, 2);
            this.cbDi.Name = "cbDi";
            this.cbDi.Size = new System.Drawing.Size(24, 41);
            this.cbDi.TabIndex = 11;
            this.cbDi.Text = "Di";
            this.cbDi.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbMo
            // 
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.cbMo.Appearance = appearance7;
            this.cbMo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbMo.Location = new System.Drawing.Point(3, 2);
            this.cbMo.Name = "cbMo";
            this.cbMo.Size = new System.Drawing.Size(24, 41);
            this.cbMo.TabIndex = 10;
            this.cbMo.Text = "Mo";
            this.cbMo.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // ucWochenTage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSo);
            this.Controls.Add(this.cbSa);
            this.Controls.Add(this.cbFr);
            this.Controls.Add(this.cbDo);
            this.Controls.Add(this.cbMi);
            this.Controls.Add(this.cbDi);
            this.Controls.Add(this.cbMo);
            this.Name = "ucWochenTage2";
            this.Size = new System.Drawing.Size(153, 49);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseCheckBox cbSo;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbSa;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbFr;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbDo;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbMi;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbDi;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbMo;
    }
}
