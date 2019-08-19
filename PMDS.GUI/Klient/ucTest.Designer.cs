namespace PMDS.GUI.Klient
{
    partial class ucTest
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnDeleteDocument = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddDocument = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblDocuStatus = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblDocuName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.UltraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.btnDeleteDocument);
            this.panelButtons.Controls.Add(this.btnAddDocument);
            this.panelButtons.Location = new System.Drawing.Point(419, 8);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(69, 29);
            this.panelButtons.TabIndex = 115;
            // 
            // btnDeleteDocument
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDeleteDocument.Appearance = appearance1;
            this.btnDeleteDocument.AutoWorkLayout = false;
            this.btnDeleteDocument.IsStandardControl = false;
            this.btnDeleteDocument.Location = new System.Drawing.Point(5, 1);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(28, 26);
            this.btnDeleteDocument.TabIndex = 108;
            this.btnDeleteDocument.Tag = "";
            this.btnDeleteDocument.Click += new System.EventHandler(this.btnDeleteDocument_Click);
            // 
            // btnAddDocument
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddDocument.Appearance = appearance2;
            this.btnAddDocument.AutoWorkLayout = false;
            this.btnAddDocument.IsStandardControl = false;
            this.btnAddDocument.Location = new System.Drawing.Point(37, 1);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(28, 26);
            this.btnAddDocument.TabIndex = 110;
            this.btnAddDocument.Tag = "";
            // 
            // lblDocuStatus
            // 
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.RoyalBlue;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblDocuStatus.Appearance = appearance3;
            this.lblDocuStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance4.FontData.UnderlineAsString = "True";
            this.lblDocuStatus.HotTrackAppearance = appearance4;
            this.lblDocuStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDocuStatus.Location = new System.Drawing.Point(252, 10);
            this.lblDocuStatus.Margin = new System.Windows.Forms.Padding(4);
            this.lblDocuStatus.Name = "lblDocuStatus";
            this.lblDocuStatus.Size = new System.Drawing.Size(157, 21);
            this.lblDocuStatus.TabIndex = 114;
            this.lblDocuStatus.Text = "Ist eingespielt";
            this.lblDocuStatus.UseAppStyling = false;
            this.lblDocuStatus.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblDocuName
            // 
            this.lblDocuName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocuName.Location = new System.Drawing.Point(3, 12);
            this.lblDocuName.Name = "lblDocuName";
            this.lblDocuName.Size = new System.Drawing.Size(242, 17);
            this.lblDocuName.TabIndex = 113;
            this.lblDocuName.Text = "[Name Dokument]";
            // 
            // UltraToolTipManager1
            // 
            this.UltraToolTipManager1.ContainingControl = this;
            // 
            // ucTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblDocuStatus);
            this.Controls.Add(this.lblDocuName);
            this.Name = "ucTest";
            this.Size = new System.Drawing.Size(580, 270);
            this.Load += new System.EventHandler(this.ucTestDokument_Load);
            this.VisibleChanged += new System.EventHandler(this.ucTest_VisibleChanged);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelButtons;
        public QS2.Desktop.ControlManagment.BaseButton btnDeleteDocument;
        public QS2.Desktop.ControlManagment.BaseButton btnAddDocument;
        internal QS2.Desktop.ControlManagment.BaseLabel lblDocuStatus;
        private QS2.Desktop.ControlManagment.BaseLabel lblDocuName;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager UltraToolTipManager1;
    }
}
