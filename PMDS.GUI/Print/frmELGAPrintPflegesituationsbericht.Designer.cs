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
            this.lblAnEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cDAEntlassungsbriefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cDAPflegesituationsberichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkInsArchiv = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucELGAPrintPflegesituationsbericht1 = new PMDS.GUI.Print.ucELGAPrintPflegesituationsbericht();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.cbETo = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInsArchiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).BeginInit();
            this.SuspendLayout();
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
            // chkInsArchiv
            // 
            this.chkInsArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInsArchiv.Location = new System.Drawing.Point(925, 728);
            this.chkInsArchiv.Name = "chkInsArchiv";
            this.chkInsArchiv.Size = new System.Drawing.Size(153, 20);
            this.chkInsArchiv.TabIndex = 18;
            this.chkInsArchiv.Text = "Ins Archiv ablegen";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucELGAPrintPflegesituationsbericht1
            // 
            this.ucELGAPrintPflegesituationsbericht1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucELGAPrintPflegesituationsbericht1.AutoScroll = true;
            this.ucELGAPrintPflegesituationsbericht1.Location = new System.Drawing.Point(12, 39);
            this.ucELGAPrintPflegesituationsbericht1.Name = "ucELGAPrintPflegesituationsbericht1";
            this.ucELGAPrintPflegesituationsbericht1.Size = new System.Drawing.Size(1264, 677);
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
            this.btnCancel.Location = new System.Drawing.Point(1091, 722);
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
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(1180, 722);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 32);
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
            // 
            // frmELGAPrintPflegesituationsbericht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.ucELGAPrintPflegesituationsbericht1);
            this.Controls.Add(this.chkInsArchiv);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbETo);
            this.Controls.Add(this.lblAnEinrichtung);
            this.Name = "frmELGAPrintPflegesituationsbericht";
            this.Text = "ELGA - Pflegesituationsbericht";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmELGAPrintPflegesituationsbericht_FormClosing);
            this.Load += new System.EventHandler(this.frmELGAPrintPflegesituationsbericht_Load);
            this.Shown += new System.EventHandler(this.frmELGAPrintPflegesituationsbericht_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkInsArchiv)).EndInit();
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
        //private ucELGAPrintPflegesituationsbericht ucELGAPrintPflegesituationsbericht1;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkInsArchiv;
        private ucButton btnCancel;
        private ucButton btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucELGAPrintPflegesituationsbericht ucELGAPrintPflegesituationsbericht1;
    }
}