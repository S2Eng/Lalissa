namespace PMDS.GUI.Sturzprotokoll
{
    partial class contSturz
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelBottom = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelSturzAutoUI = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnOk = new QS2.Desktop.ControlManagment.BaseButton();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.labInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(657, 53);
            this.panelTop.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 412);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(657, 38);
            this.panelBottom.TabIndex = 2;
            // 
            // panelSturzAutoUI
            // 
            this.panelSturzAutoUI.AutoScroll = true;
            this.panelSturzAutoUI.BackColor = System.Drawing.Color.Transparent;
            this.panelSturzAutoUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSturzAutoUI.Location = new System.Drawing.Point(0, 53);
            this.panelSturzAutoUI.Name = "panelSturzAutoUI";
            this.panelSturzAutoUI.Size = new System.Drawing.Size(657, 359);
            this.panelSturzAutoUI.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            this.btnOk.Appearance = appearance2;
            this.btnOk.Location = new System.Drawing.Point(591, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 28);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(657, 53);
            this.labInfo.TabIndex = 4;
            this.labInfo.Text = "Sturz";
            // 
            // contSturz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelSturzAutoUI);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "contSturz";
            this.Size = new System.Drawing.Size(657, 450);
            this.Load += new System.EventHandler(this.contSturz_Load);
            this.VisibleChanged += new System.EventHandler(this.contSturz_VisibleChanged);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private QS2.Desktop.ControlManagment.BasePanel panelBottom;
        private QS2.Desktop.ControlManagment.BasePanel panelSturzAutoUI;
        private QS2.Desktop.ControlManagment.BaseButton btnOk;
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
    }
}
