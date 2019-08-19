namespace PMDS.GUI
{
    partial class ucKlientEdit
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlientEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAufnahmeblatt = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelKlientenakt = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucPrintStammDatenBlatt1 = new PMDS.GUI.BaseControls.ucPrintStammDatenBlatt();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlButtons.Controls.Add(this.btnAufnahmeblatt);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.ucPrintStammDatenBlatt1);
            this.pnlButtons.Controls.Add(this.btnUndo);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 525);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(958, 40);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnAufnahmeblatt
            // 
            this.btnAufnahmeblatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAufnahmeblatt.AutoWorkLayout = false;
            this.btnAufnahmeblatt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAufnahmeblatt.IsStandardControl = false;
            this.btnAufnahmeblatt.Location = new System.Drawing.Point(182, 4);
            this.btnAufnahmeblatt.Name = "btnAufnahmeblatt";
            this.btnAufnahmeblatt.Size = new System.Drawing.Size(115, 32);
            this.btnAufnahmeblatt.TabIndex = 93;
            this.btnAufnahmeblatt.Text = "Stammdaten mailen";
            this.btnAufnahmeblatt.Click += new System.EventHandler(this.btnAufnahmeblatt_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(682, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 32);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.ultraGridBagLayoutPanel1.Controls.Add(this.panelKlientenakt);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(958, 525);
            this.ultraGridBagLayoutPanel1.TabIndex = 3;
            // 
            // panelKlientenakt
            // 
            this.panelKlientenakt.BackColor = System.Drawing.Color.WhiteSmoke;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.panelKlientenakt, gridBagConstraint1);
            this.panelKlientenakt.Location = new System.Drawing.Point(5, 5);
            this.panelKlientenakt.Name = "panelKlientenakt";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.panelKlientenakt, new System.Drawing.Size(200, 100));
            this.panelKlientenakt.Size = new System.Drawing.Size(948, 520);
            this.panelKlientenakt.TabIndex = 0;
            // 
            // ucPrintStammDatenBlatt1
            // 
            this.ucPrintStammDatenBlatt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucPrintStammDatenBlatt1.chkFreiHeitVisible = true;
            this.ucPrintStammDatenBlatt1.Location = new System.Drawing.Point(12, 5);
            this.ucPrintStammDatenBlatt1.Name = "ucPrintStammDatenBlatt1";
            this.ucPrintStammDatenBlatt1.Size = new System.Drawing.Size(168, 32);
            this.ucPrintStammDatenBlatt1.TabIndex = 88;
            this.ucPrintStammDatenBlatt1.btnPrintStammdatenKlicked += new PMDS.GUI.BaseControls.ucPrintStammDatenBlatt.PrintStammdatenDelegate(this.ucPrintStammDatenBlatt1_btnPrintStammdatenKlicked);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance1;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(754, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance2;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(849, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 8;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucKlientEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.pnlButtons);
            this.Name = "ucKlientEdit";
            this.Size = new System.Drawing.Size(958, 565);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
        private PMDS.GUI.ucButton btnUndo;
        private PMDS.GUI.ucButton btnSave;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private PMDS.GUI.BaseControls.ucPrintStammDatenBlatt ucPrintStammDatenBlatt1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelKlientenakt;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        private QS2.Desktop.ControlManagment.BaseButton btnAufnahmeblatt;
    }
}
