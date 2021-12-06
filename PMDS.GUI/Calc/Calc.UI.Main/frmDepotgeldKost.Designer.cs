namespace PMDS.Klient
{
    partial class frmDepotgeldKost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepotgeldKost));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.panelButtUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucTaschengeldKostentraeger1 = new PMDS.GUI.ucDepotgeldKost();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.panelButtUnten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).BeginInit();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtUnten
            // 
            this.panelButtUnten.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtUnten.Controls.Add(this.btnClose);
            this.panelButtUnten.Controls.Add(this.btnUndo);
            this.panelButtUnten.Controls.Add(this.btnSave);
            this.panelButtUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtUnten.Location = new System.Drawing.Point(0, 348);
            this.panelButtUnten.Name = "panelButtUnten";
            this.panelButtUnten.Size = new System.Drawing.Size(942, 36);
            this.panelButtUnten.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance1;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(680, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 30);
            this.btnClose.TabIndex = 94;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.panelAll);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(954, 396);
            this.ultraGridBagLayoutPanelAll.TabIndex = 4;
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAll.Controls.Add(this.ucTaschengeldKostentraeger1);
            this.panelAll.Controls.Add(this.panelButtUnten);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.panelAll, gridBagConstraint1);
            this.panelAll.Location = new System.Drawing.Point(5, 5);
            this.panelAll.Name = "panelAll";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.panelAll, new System.Drawing.Size(771, 206));
            this.panelAll.Size = new System.Drawing.Size(944, 386);
            this.panelAll.TabIndex = 4;
            // 
            // ucTaschengeldKostentraeger1
            // 
            this.ucTaschengeldKostentraeger1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTaschengeldKostentraeger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTaschengeldKostentraeger1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTaschengeldKostentraeger1.Location = new System.Drawing.Point(0, 0);
            this.ucTaschengeldKostentraeger1.Name = "ucTaschengeldKostentraeger1";
            this.ucTaschengeldKostentraeger1.Size = new System.Drawing.Size(942, 348);
            this.ucTaschengeldKostentraeger1.TabIndex = 4;
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance2;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(753, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(95, 30);
            this.btnUndo.TabIndex = 92;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance3;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(849, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 30);
            this.btnSave.TabIndex = 93;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDepotgeldKost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(954, 396);
            this.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepotgeldKost";
            this.Text = "Depotgeld - Kostenträgerzuordnung";
            this.Load += new System.EventHandler(this.frmDepotgeldKostenträger_Load);
            this.panelButtUnten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).EndInit();
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
        private QS2.Desktop.ControlManagment.BasePanel panelButtUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        private PMDS.GUI.ucButton btnUndo;
        private PMDS.GUI.ucButton btnSave;
        public PMDS.GUI.ucDepotgeldKost ucTaschengeldKostentraeger1;
    }
}