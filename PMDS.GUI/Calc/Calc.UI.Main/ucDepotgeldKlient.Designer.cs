namespace PMDS.Calc.UI.Admin
{
    partial class ucDepotgeldKlient
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.panelButtonUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSchließen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.panelDepotgeld = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtonUnten.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtonUnten
            // 
            this.panelButtonUnten.Controls.Add(this.btnSchließen);
            this.panelButtonUnten.Controls.Add(this.btnUndo);
            this.panelButtonUnten.Controls.Add(this.btnSave);
            this.panelButtonUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonUnten.Location = new System.Drawing.Point(0, 266);
            this.panelButtonUnten.Name = "panelButtonUnten";
            this.panelButtonUnten.Size = new System.Drawing.Size(896, 37);
            this.panelButtonUnten.TabIndex = 1;
            // 
            // btnSchließen
            // 
            this.btnSchließen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSchließen.Appearance = appearance5;
            this.btnSchließen.Location = new System.Drawing.Point(632, 2);
            this.btnSchließen.Name = "btnSchließen";
            this.btnSchließen.Size = new System.Drawing.Size(74, 32);
            this.btnSchließen.TabIndex = 93;
            this.btnSchließen.Text = "Schließen";
            this.btnSchließen.Click += new System.EventHandler(this.btnSchließen_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.Image = 1;
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance10;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(707, 2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 91;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "&Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.Image = 0;
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance11;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(804, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 32);
            this.btnSave.TabIndex = 92;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelDepotgeld
            // 
            this.panelDepotgeld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDepotgeld.Location = new System.Drawing.Point(0, 0);
            this.panelDepotgeld.Name = "panelDepotgeld";
            this.panelDepotgeld.Size = new System.Drawing.Size(896, 266);
            this.panelDepotgeld.TabIndex = 2;
            // 
            // ucDepotgeldKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelDepotgeld);
            this.Controls.Add(this.panelButtonUnten);
            this.Name = "ucDepotgeldKlient";
            this.Size = new System.Drawing.Size(896, 303);
            this.panelButtonUnten.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelButtonUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelDepotgeld;
        private QS2.Desktop.ControlManagment.BaseButton btnSchließen;
        private PMDS.GUI.ucButton btnUndo;
        private PMDS.GUI.ucButton btnSave;


    }
}
