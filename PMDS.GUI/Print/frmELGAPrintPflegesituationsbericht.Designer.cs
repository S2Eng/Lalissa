namespace PMDS.GUI.Print
{
    partial class frmELGAPrintPflegesituationsbericht
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmELGAPrintPflegesituationsbericht));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cDAEntlassungsbriefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cDAPflegesituationsberichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAnEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnPreview = new Infragistics.Win.Misc.UltraButton();
            this.btnCheck = new Infragistics.Win.Misc.UltraButton();
            this.ucELGAPrintPflegesituationsbericht1 = new PMDS.GUI.Print.ucELGAPrintPflegesituationsbericht();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.cbETo = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cDAEntlassungsbriefToolStripMenuItem,
            this.cDAPflegesituationsberichtToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(223, 48);
            // 
            // cDAEntlassungsbriefToolStripMenuItem
            // 
            this.cDAEntlassungsbriefToolStripMenuItem.Name = "cDAEntlassungsbriefToolStripMenuItem";
            this.cDAEntlassungsbriefToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.cDAEntlassungsbriefToolStripMenuItem.Text = "CDA Entlassungsbrief";
            // 
            // cDAPflegesituationsberichtToolStripMenuItem
            // 
            this.cDAPflegesituationsberichtToolStripMenuItem.Name = "cDAPflegesituationsberichtToolStripMenuItem";
            this.cDAPflegesituationsberichtToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.cDAPflegesituationsberichtToolStripMenuItem.Text = "CDA Pflegesituationsbericht";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblAnEinrichtung
            // 
            this.lblAnEinrichtung.AutoSize = true;
            this.lblAnEinrichtung.Location = new System.Drawing.Point(12, 15);
            this.lblAnEinrichtung.Name = "lblAnEinrichtung";
            this.lblAnEinrichtung.Size = new System.Drawing.Size(81, 14);
            this.lblAnEinrichtung.TabIndex = 2;
            this.lblAnEinrichtung.Text = "An Einrichtung:";
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Location = new System.Drawing.Point(1091, 722);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(88, 32);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "Vorschau";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(997, 722);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(88, 32);
            this.btnCheck.TabIndex = 20;
            this.btnCheck.Text = "Prüfen";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // ucELGAPrintPflegesituationsbericht1
            // 
            this.ucELGAPrintPflegesituationsbericht1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucELGAPrintPflegesituationsbericht1.AutoScroll = true;
            this.ucELGAPrintPflegesituationsbericht1.Enabled = false;
            this.ucELGAPrintPflegesituationsbericht1.Location = new System.Drawing.Point(12, 39);
            this.ucELGAPrintPflegesituationsbericht1.Name = "ucELGAPrintPflegesituationsbericht1";
            this.ucELGAPrintPflegesituationsbericht1.ReturnCode = PMDS.GUI.Print.ucELGAPrintPflegesituationsbericht.eStatusResult.Ok;
            this.ucELGAPrintPflegesituationsbericht1.sFileName = null;
            this.ucELGAPrintPflegesituationsbericht1.Size = new System.Drawing.Size(1264, 677);
            this.ucELGAPrintPflegesituationsbericht1.sMessages = "";
            this.ucELGAPrintPflegesituationsbericht1.sWarnings = "";
            this.ucELGAPrintPflegesituationsbericht1.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(800, 722);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.Enabled = false;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(1185, 722);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 32);
            this.btnOK.TabIndex = 17;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbETo
            // 
            this.cbETo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbETo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbETo.Location = new System.Drawing.Point(100, 12);
            this.cbETo.Name = "cbETo";
            this.cbETo.NotKrankenkasse = true;
            this.cbETo.Size = new System.Drawing.Size(736, 21);
            this.cbETo.TabIndex = 1;
            this.cbETo.ValueChanged += new System.EventHandler(this.cbETo_ValueChanged);
            // 
            // frmELGAPrintPflegesituationsbericht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.ucELGAPrintPflegesituationsbericht1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbETo);
            this.Controls.Add(this.lblAnEinrichtung);
            this.Name = "frmELGAPrintPflegesituationsbericht";
            this.Text = "ELGA - Pflegesituationsbericht";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmELGAPrintPflegesituationsbericht_FormClosing);
            this.Load += new System.EventHandler(this.frmELGAPrintPflegesituationsbericht_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BaseControls.EinrichtungsCombo cbETo;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnEinrichtung;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cDAEntlassungsbriefToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cDAPflegesituationsberichtToolStripMenuItem;
        private ucButton btnCancel;
        private ucButton btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucELGAPrintPflegesituationsbericht ucELGAPrintPflegesituationsbericht1;
        private Infragistics.Win.Misc.UltraButton btnPreview;
        private Infragistics.Win.Misc.UltraButton btnCheck;
    }
}