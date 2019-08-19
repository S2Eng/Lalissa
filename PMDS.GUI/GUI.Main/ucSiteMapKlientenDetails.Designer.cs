namespace PMDS.GUI
{
    partial class ucSiteMapKlientenDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSiteMapKlientenDetails));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnPrintMedBlatt = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucPrintArztbrief1 = new PMDS.GUI.BaseControls.ucPrintArztbrief();
            this.btnDiagnosenliste = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnundo2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucPrintStammDatenBlatt1 = new PMDS.GUI.BaseControls.ucPrintStammDatenBlatt();
            this.ultraGridBagLayoutPanelKlient = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelKlientenakt = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelKeinRecht = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblKeinRecht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlButtons.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelKlient)).BeginInit();
            this.ultraGridBagLayoutPanelKlient.SuspendLayout();
            this.panelKeinRecht.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnPrintMedBlatt);
            this.pnlButtons.Controls.Add(this.ucPrintArztbrief1);
            this.pnlButtons.Controls.Add(this.btnDiagnosenliste);
            this.pnlButtons.Controls.Add(this.panelButtons);
            this.pnlButtons.Controls.Add(this.ucPrintStammDatenBlatt1);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 491);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(938, 40);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnPrintMedBlatt
            // 
            this.btnPrintMedBlatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintMedBlatt.AutoWorkLayout = false;
            this.btnPrintMedBlatt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrintMedBlatt.IsStandardControl = false;
            this.btnPrintMedBlatt.Location = new System.Drawing.Point(417, 3);
            this.btnPrintMedBlatt.Name = "btnPrintMedBlatt";
            this.btnPrintMedBlatt.Size = new System.Drawing.Size(125, 33);
            this.btnPrintMedBlatt.TabIndex = 98;
            this.btnPrintMedBlatt.Text = "Medikamentenliste drucken";
            this.btnPrintMedBlatt.Click += new System.EventHandler(this.btnPrintMedBlatt_Click);
            // 
            // ucPrintArztbrief1
            // 
            this.ucPrintArztbrief1.chkFreiHeitVisible = true;
            this.ucPrintArztbrief1.Location = new System.Drawing.Point(189, 5);
            this.ucPrintArztbrief1.Name = "ucPrintArztbrief1";
            this.ucPrintArztbrief1.Size = new System.Drawing.Size(134, 167);
            this.ucPrintArztbrief1.TabIndex = 97;
            // 
            // btnDiagnosenliste
            // 
            this.btnDiagnosenliste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiagnosenliste.AutoWorkLayout = false;
            this.btnDiagnosenliste.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDiagnosenliste.IsStandardControl = false;
            this.btnDiagnosenliste.Location = new System.Drawing.Point(323, 3);
            this.btnDiagnosenliste.Name = "btnDiagnosenliste";
            this.btnDiagnosenliste.Size = new System.Drawing.Size(94, 33);
            this.btnDiagnosenliste.TabIndex = 96;
            this.btnDiagnosenliste.Text = "Diagnosenliste drucken";
            this.btnDiagnosenliste.Click += new System.EventHandler(this.btnDiagnosenliste_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnundo2);
            this.panelButtons.Controls.Add(this.btnSave2);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(719, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(219, 40);
            this.panelButtons.TabIndex = 91;
            // 
            // btnundo2
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnundo2.Appearance = appearance1;
            this.btnundo2.AutoWorkLayout = false;
            this.btnundo2.Enabled = false;
            this.btnundo2.IsStandardControl = false;
            this.btnundo2.Location = new System.Drawing.Point(17, 3);
            this.btnundo2.Name = "btnundo2";
            this.btnundo2.Size = new System.Drawing.Size(92, 31);
            this.btnundo2.TabIndex = 51;
            this.btnundo2.Text = "Rückgängig";
            this.btnundo2.Click += new System.EventHandler(this.btnundo2_Click);
            // 
            // btnSave2
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSave2.Appearance = appearance2;
            this.btnSave2.AutoWorkLayout = false;
            this.btnSave2.Enabled = false;
            this.btnSave2.IsStandardControl = false;
            this.btnSave2.Location = new System.Drawing.Point(109, 3);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(92, 31);
            this.btnSave2.TabIndex = 50;
            this.btnSave2.Text = "Speichern";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // ucPrintStammDatenBlatt1
            // 
            this.ucPrintStammDatenBlatt1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucPrintStammDatenBlatt1.chkFreiHeitVisible = true;
            this.ucPrintStammDatenBlatt1.Location = new System.Drawing.Point(21, 5);
            this.ucPrintStammDatenBlatt1.Name = "ucPrintStammDatenBlatt1";
            this.ucPrintStammDatenBlatt1.Size = new System.Drawing.Size(165, 203);
            this.ucPrintStammDatenBlatt1.TabIndex = 90;
            this.ucPrintStammDatenBlatt1.btnPrintStammdatenKlicked += new PMDS.GUI.BaseControls.ucPrintStammDatenBlatt.PrintStammdatenDelegate(this.ucPrintStammDatenBlatt1_btnPrintStammdatenKlicked);
            // 
            // ultraGridBagLayoutPanelKlient
            // 
            this.ultraGridBagLayoutPanelKlient.Controls.Add(this.panelKlientenakt);
            this.ultraGridBagLayoutPanelKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelKlient.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelKlient.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelKlient.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelKlient.Name = "ultraGridBagLayoutPanelKlient";
            this.ultraGridBagLayoutPanelKlient.Size = new System.Drawing.Size(938, 491);
            this.ultraGridBagLayoutPanelKlient.TabIndex = 4;
            // 
            // panelKlientenakt
            // 
            this.panelKlientenakt.BackColor = System.Drawing.Color.WhiteSmoke;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanelKlient.SetGridBagConstraint(this.panelKlientenakt, gridBagConstraint1);
            this.panelKlientenakt.Location = new System.Drawing.Point(5, 5);
            this.panelKlientenakt.Name = "panelKlientenakt";
            this.ultraGridBagLayoutPanelKlient.SetPreferredSize(this.panelKlientenakt, new System.Drawing.Size(200, 100));
            this.panelKlientenakt.Size = new System.Drawing.Size(928, 486);
            this.panelKlientenakt.TabIndex = 0;
            // 
            // panelKeinRecht
            // 
            this.panelKeinRecht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKeinRecht.BackColor = System.Drawing.Color.Transparent;
            this.panelKeinRecht.Controls.Add(this.lblKeinRecht);
            this.panelKeinRecht.Location = new System.Drawing.Point(223, 185);
            this.panelKeinRecht.Name = "panelKeinRecht";
            this.panelKeinRecht.Size = new System.Drawing.Size(492, 161);
            this.panelKeinRecht.TabIndex = 6;
            this.panelKeinRecht.Visible = false;
            // 
            // lblKeinRecht
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Gray;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblKeinRecht.Appearance = appearance3;
            this.lblKeinRecht.AutoSize = true;
            this.lblKeinRecht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeinRecht.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeinRecht.Location = new System.Drawing.Point(0, 0);
            this.lblKeinRecht.Name = "lblKeinRecht";
            this.lblKeinRecht.Size = new System.Drawing.Size(492, 161);
            this.lblKeinRecht.TabIndex = 0;
            this.lblKeinRecht.Text = "Sie dürfen den Klientenakt nicht einsehen";
            // 
            // ucSiteMapKlientenDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ultraGridBagLayoutPanelKlient);
            this.Controls.Add(this.panelKeinRecht);
            this.Controls.Add(this.pnlButtons);
            this.Name = "ucSiteMapKlientenDetails";
            this.Size = new System.Drawing.Size(938, 531);
            this.VisibleChanged += new System.EventHandler(this.ucSiteMapKlientenDetails_VisibleChanged);
            this.pnlButtons.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelKlient)).EndInit();
            this.ultraGridBagLayoutPanelKlient.ResumeLayout(false);
            this.panelKeinRecht.ResumeLayout(false);
            this.panelKeinRecht.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private PMDS.GUI.BaseControls.ucPrintStammDatenBlatt ucPrintStammDatenBlatt1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelKlient;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private QS2.Desktop.ControlManagment.BasePanel panelKeinRecht;
        private QS2.Desktop.ControlManagment.BaseLabel lblKeinRecht;
        private QS2.Desktop.ControlManagment.BasePanel panelKlientenakt;
        public QS2.Desktop.ControlManagment.BaseButton btnundo2;
        public QS2.Desktop.ControlManagment.BaseButton btnSave2;
        private QS2.Desktop.ControlManagment.BaseButton btnDiagnosenliste;
        private BaseControls.ucPrintArztbrief ucPrintArztbrief1;
        private QS2.Desktop.ControlManagment.BaseButton btnPrintMedBlatt;
    }
}
