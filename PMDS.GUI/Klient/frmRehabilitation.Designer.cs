namespace PMDS.GUI
{
    partial class frmRehabilitation
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRehabilitation));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.btnCancel = new PMDS.GUI.ucButton();
            this.btnOK = new PMDS.GUI.ucButton();
            this.pnlBemerkung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlEndeGrung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblEndeGrung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbEndeGrund = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlInstitution = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblInstitution = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbInstitution = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlZiel = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblZiel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbZiel = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlBeschreibung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlBeginn = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtpBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblHeader = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.pnlBemerkung.SuspendLayout();
            this.pnlEndeGrung.SuspendLayout();
            this.pnlInstitution.SuspendLayout();
            this.pnlZiel.SuspendLayout();
            this.pnlBeschreibung.SuspendLayout();
            this.pnlBeginn.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(666, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(762, 402);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlBemerkung
            // 
            this.pnlBemerkung.Controls.Add(this.lblBemerkung);
            this.pnlBemerkung.Controls.Add(this.tbBemerkung);
            this.pnlBemerkung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBemerkung.Location = new System.Drawing.Point(0, 326);
            this.pnlBemerkung.Name = "pnlBemerkung";
            this.pnlBemerkung.Size = new System.Drawing.Size(815, 62);
            this.pnlBemerkung.TabIndex = 79;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.AutoSize = true;
            this.lblBemerkung.Location = new System.Drawing.Point(12, 4);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(62, 14);
            this.lblBemerkung.TabIndex = 40;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // tbBemerkung
            // 
            this.tbBemerkung.AcceptsReturn = true;
            this.tbBemerkung.Location = new System.Drawing.Point(151, 2);
            this.tbBemerkung.MaxLength = 255;
            this.tbBemerkung.Multiline = true;
            this.tbBemerkung.Name = "tbBemerkung";
            this.tbBemerkung.Size = new System.Drawing.Size(637, 57);
            this.tbBemerkung.TabIndex = 5;
            // 
            // pnlEndeGrung
            // 
            this.pnlEndeGrung.Controls.Add(this.lblEndeGrung);
            this.pnlEndeGrung.Controls.Add(this.tbEndeGrund);
            this.pnlEndeGrung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEndeGrung.Location = new System.Drawing.Point(0, 264);
            this.pnlEndeGrung.Name = "pnlEndeGrung";
            this.pnlEndeGrung.Size = new System.Drawing.Size(815, 62);
            this.pnlEndeGrung.TabIndex = 78;
            // 
            // lblEndeGrung
            // 
            this.lblEndeGrung.AutoSize = true;
            this.lblEndeGrung.Location = new System.Drawing.Point(12, 5);
            this.lblEndeGrung.Name = "lblEndeGrung";
            this.lblEndeGrung.Size = new System.Drawing.Size(65, 14);
            this.lblEndeGrung.TabIndex = 38;
            this.lblEndeGrung.Text = "Ende Grund";
            // 
            // tbEndeGrund
            // 
            this.tbEndeGrund.AcceptsReturn = true;
            this.tbEndeGrund.Location = new System.Drawing.Point(151, 3);
            this.tbEndeGrund.MaxLength = 255;
            this.tbEndeGrund.Multiline = true;
            this.tbEndeGrund.Name = "tbEndeGrund";
            this.tbEndeGrund.Size = new System.Drawing.Size(637, 57);
            this.tbEndeGrund.TabIndex = 6;
            // 
            // pnlInstitution
            // 
            this.pnlInstitution.Controls.Add(this.lblInstitution);
            this.pnlInstitution.Controls.Add(this.tbInstitution);
            this.pnlInstitution.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInstitution.Location = new System.Drawing.Point(0, 202);
            this.pnlInstitution.Name = "pnlInstitution";
            this.pnlInstitution.Size = new System.Drawing.Size(815, 62);
            this.pnlInstitution.TabIndex = 77;
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.Location = new System.Drawing.Point(12, 5);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(53, 14);
            this.lblInstitution.TabIndex = 31;
            this.lblInstitution.Text = "Institution";
            // 
            // tbInstitution
            // 
            this.tbInstitution.AcceptsReturn = true;
            this.tbInstitution.Location = new System.Drawing.Point(151, 3);
            this.tbInstitution.MaxLength = 255;
            this.tbInstitution.Multiline = true;
            this.tbInstitution.Name = "tbInstitution";
            this.tbInstitution.Size = new System.Drawing.Size(637, 57);
            this.tbInstitution.TabIndex = 4;
            // 
            // pnlZiel
            // 
            this.pnlZiel.Controls.Add(this.lblZiel);
            this.pnlZiel.Controls.Add(this.tbZiel);
            this.pnlZiel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlZiel.Location = new System.Drawing.Point(0, 140);
            this.pnlZiel.Name = "pnlZiel";
            this.pnlZiel.Size = new System.Drawing.Size(815, 62);
            this.pnlZiel.TabIndex = 76;
            // 
            // lblZiel
            // 
            this.lblZiel.AutoSize = true;
            this.lblZiel.Location = new System.Drawing.Point(12, 4);
            this.lblZiel.Name = "lblZiel";
            this.lblZiel.Size = new System.Drawing.Size(23, 14);
            this.lblZiel.TabIndex = 29;
            this.lblZiel.Text = "Ziel";
            // 
            // tbZiel
            // 
            this.tbZiel.AcceptsReturn = true;
            this.tbZiel.Location = new System.Drawing.Point(151, 2);
            this.tbZiel.MaxLength = 255;
            this.tbZiel.Multiline = true;
            this.tbZiel.Name = "tbZiel";
            this.tbZiel.Size = new System.Drawing.Size(637, 57);
            this.tbZiel.TabIndex = 3;
            // 
            // pnlBeschreibung
            // 
            this.pnlBeschreibung.Controls.Add(this.lblBeschreibung);
            this.pnlBeschreibung.Controls.Add(this.tbBeschreibung);
            this.pnlBeschreibung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeschreibung.Location = new System.Drawing.Point(0, 78);
            this.pnlBeschreibung.Name = "pnlBeschreibung";
            this.pnlBeschreibung.Size = new System.Drawing.Size(815, 62);
            this.pnlBeschreibung.TabIndex = 75;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.AutoSize = true;
            this.lblBeschreibung.Location = new System.Drawing.Point(12, 4);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(74, 14);
            this.lblBeschreibung.TabIndex = 27;
            this.lblBeschreibung.Text = "Beschreibung";
            // 
            // tbBeschreibung
            // 
            this.tbBeschreibung.AcceptsReturn = true;
            this.tbBeschreibung.Location = new System.Drawing.Point(151, 2);
            this.tbBeschreibung.MaxLength = 255;
            this.tbBeschreibung.Multiline = true;
            this.tbBeschreibung.Name = "tbBeschreibung";
            this.tbBeschreibung.Size = new System.Drawing.Size(637, 57);
            this.tbBeschreibung.TabIndex = 2;
            // 
            // pnlBeginn
            // 
            this.pnlBeginn.Controls.Add(this.lblVon);
            this.pnlBeginn.Controls.Add(this.lblBis);
            this.pnlBeginn.Controls.Add(this.dtpVon);
            this.pnlBeginn.Controls.Add(this.dtpBis);
            this.pnlBeginn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeginn.Location = new System.Drawing.Point(0, 48);
            this.pnlBeginn.Name = "pnlBeginn";
            this.pnlBeginn.Size = new System.Drawing.Size(815, 30);
            this.pnlBeginn.TabIndex = 70;
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(12, 8);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(24, 14);
            this.lblVon.TabIndex = 25;
            this.lblVon.Text = "Von";
            // 
            // lblBis
            // 
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(283, 8);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(20, 14);
            this.lblBis.TabIndex = 33;
            this.lblBis.Text = "Bis";
            // 
            // dtpVon
            // 
            this.dtpVon.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVon.FormatString = "";
            this.dtpVon.Location = new System.Drawing.Point(151, 4);
            this.dtpVon.MaskInput = "";
            this.dtpVon.Name = "dtpVon";
            this.dtpVon.Size = new System.Drawing.Size(102, 21);
            this.dtpVon.TabIndex = 0;
            this.dtpVon.Value = null;
            // 
            // dtpBis
            // 
            this.dtpBis.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBis.FormatString = "";
            this.dtpBis.Location = new System.Drawing.Point(322, 4);
            this.dtpBis.MaskInput = "";
            this.dtpBis.Name = "dtpBis";
            this.dtpBis.Size = new System.Drawing.Size(102, 21);
            this.dtpBis.TabIndex = 1;
            this.dtpBis.Value = null;
            // 
            // lblHeader
            // 
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblHeader.Appearance = appearance3;
            this.lblHeader.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(815, 48);
            this.lblHeader.TabIndex = 69;
            this.lblHeader.Text = "--";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRehabilitation
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(815, 435);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pnlBemerkung);
            this.Controls.Add(this.pnlEndeGrung);
            this.Controls.Add(this.pnlInstitution);
            this.Controls.Add(this.pnlZiel);
            this.Controls.Add(this.pnlBeschreibung);
            this.Controls.Add(this.pnlBeginn);
            this.Controls.Add(this.lblHeader);
            this.KeyPreview = true;
            this.Name = "frmRehabilitation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rehabilitation";
            this.pnlBemerkung.ResumeLayout(false);
            this.pnlBemerkung.PerformLayout();
            this.pnlEndeGrung.ResumeLayout(false);
            this.pnlEndeGrung.PerformLayout();
            this.pnlInstitution.ResumeLayout(false);
            this.pnlInstitution.PerformLayout();
            this.pnlZiel.ResumeLayout(false);
            this.pnlZiel.PerformLayout();
            this.pnlBeschreibung.ResumeLayout(false);
            this.pnlBeschreibung.PerformLayout();
            this.pnlBeginn.ResumeLayout(false);
            this.pnlBeginn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PMDS.GUI.ucButton btnCancel;
        private PMDS.GUI.ucButton btnOK;
        private QS2.Desktop.ControlManagment.BasePanel pnlBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBemerkung;
        private QS2.Desktop.ControlManagment.BasePanel pnlEndeGrung;
        private QS2.Desktop.ControlManagment.BaseLabel lblEndeGrung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbEndeGrund;
        private QS2.Desktop.ControlManagment.BasePanel pnlInstitution;
        private QS2.Desktop.ControlManagment.BaseLabel lblInstitution;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbInstitution;
        private QS2.Desktop.ControlManagment.BasePanel pnlZiel;
        private QS2.Desktop.ControlManagment.BaseLabel lblZiel;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbZiel;
        private QS2.Desktop.ControlManagment.BasePanel pnlBeschreibung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBeschreibung;
        private QS2.Desktop.ControlManagment.BasePanel pnlBeginn;
        private QS2.Desktop.ControlManagment.BaseLabel lblVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpVon;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}