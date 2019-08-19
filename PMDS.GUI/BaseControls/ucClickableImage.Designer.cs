namespace PMDS.GUI.BaseControls
{
    partial class ucClickableImage
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pbMain = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.btnFocus = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelGesamt = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.panelGesamt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblInfo.Appearance = appearance1;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(0, 198);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(182, 50);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Testtext\r\n2 Zeilig";
            this.lblInfo.Click += new System.EventHandler(this.pbMain_Click);
            this.lblInfo.DoubleClick += new System.EventHandler(this.lblInfo_DoubleClick);
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.Transparent;
            this.pbMain.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(182, 198);
            this.pbMain.TabIndex = 1;
            this.pbMain.UseAppStyling = false;
            this.pbMain.Click += new System.EventHandler(this.pbMain_Click);
            this.pbMain.DoubleClick += new System.EventHandler(this.lblInfo_DoubleClick);
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            this.pbMain.MouseEnter += new System.EventHandler(this.pbMain_MouseEnter);
            this.pbMain.MouseLeave += new System.EventHandler(this.pbMain_MouseLeave);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // btnFocus
            // 
            this.btnFocus.AutoWorkLayout = false;
            this.btnFocus.IsStandardControl = false;
            this.btnFocus.Location = new System.Drawing.Point(53, 35);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(27, 13);
            this.btnFocus.TabIndex = 3;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGridBagLayoutPanel1.Controls.Add(this.panelGesamt);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(184, 250);
            this.ultraGridBagLayoutPanel1.TabIndex = 4;
            // 
            // panelGesamt
            // 
            this.panelGesamt.BackColor = System.Drawing.SystemColors.Control;
            this.panelGesamt.Controls.Add(this.pbMain);
            this.panelGesamt.Controls.Add(this.lblInfo);
            this.panelGesamt.Controls.Add(this.btnFocus);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 1;
            gridBagConstraint1.Insets.Left = 1;
            gridBagConstraint1.Insets.Right = 1;
            gridBagConstraint1.Insets.Top = 1;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.panelGesamt, gridBagConstraint1);
            this.panelGesamt.Location = new System.Drawing.Point(1, 1);
            this.panelGesamt.Name = "panelGesamt";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.panelGesamt, new System.Drawing.Size(200, 100));
            this.panelGesamt.Size = new System.Drawing.Size(182, 248);
            this.panelGesamt.TabIndex = 0;
            // 
            // ucClickableImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Name = "ucClickableImage";
            this.Size = new System.Drawing.Size(184, 250);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.panelGesamt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinEditors.UltraPictureBox pbMain;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public QS2.Desktop.ControlManagment.BaseButton btnFocus;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelGesamt;
        public QS2.Desktop.ControlManagment.BaseLabel lblInfo;
    }
}
