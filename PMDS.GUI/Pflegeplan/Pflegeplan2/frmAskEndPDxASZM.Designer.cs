namespace PMDS.GUI
{
    partial class frmAskEndPDxASZM
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskEndPDxASZM));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.pnlEndDatum = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEnd = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.grpEndASZM = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucAskEndASZM1 = new PMDS.GUI.ucAskEndASZM();
            this.grpEndPDX = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucAskEndPDX1 = new PMDS.GUI.ucAskEndPDX();
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlEndDatum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEndASZM)).BeginInit();
            this.grpEndASZM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEndPDX)).BeginInit();
            this.grpEndPDX.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(712, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 42);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(818, 0);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 42);
            this.btnOK.TabIndex = 5;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlEndDatum
            // 
            this.pnlEndDatum.Controls.Add(this.ultraLabel4);
            this.pnlEndDatum.Controls.Add(this.dtpEnd);
            this.pnlEndDatum.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEndDatum.Location = new System.Drawing.Point(0, 0);
            this.pnlEndDatum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlEndDatum.Name = "pnlEndDatum";
            this.pnlEndDatum.Size = new System.Drawing.Size(882, 29);
            this.pnlEndDatum.TabIndex = 25;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(0, 5);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(75, 21);
            this.ultraLabel4.TabIndex = 18;
            this.ultraLabel4.Text = "Endedatum";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(84, 0);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEnd.MaskInput = "dd.mm.yyyy";
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ownFormat = "";
            this.dtpEnd.ownMaskInput = "";
            this.dtpEnd.Size = new System.Drawing.Size(112, 26);
            this.dtpEnd.TabIndex = 17;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // grpEndASZM
            // 
            this.grpEndASZM.Controls.Add(this.ucAskEndASZM1);
            this.grpEndASZM.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEndASZM.Location = new System.Drawing.Point(0, 479);
            this.grpEndASZM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpEndASZM.Name = "grpEndASZM";
            this.grpEndASZM.Size = new System.Drawing.Size(882, 377);
            this.grpEndASZM.TabIndex = 27;
            this.grpEndASZM.Text = "A/S/Z/R/M beenden";
            // 
            // ucAskEndASZM1
            // 
            this.ucAskEndASZM1.HiedeEndDate = true;
            this.ucAskEndASZM1.Location = new System.Drawing.Point(6, 21);
            this.ucAskEndASZM1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucAskEndASZM1.Name = "ucAskEndASZM1";
            this.ucAskEndASZM1.Size = new System.Drawing.Size(856, 348);
            this.ucAskEndASZM1.TabIndex = 0;
            // 
            // grpEndPDX
            // 
            this.grpEndPDX.Controls.Add(this.ucAskEndPDX1);
            this.grpEndPDX.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEndPDX.Location = new System.Drawing.Point(0, 29);
            this.grpEndPDX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpEndPDX.Name = "grpEndPDX";
            this.grpEndPDX.Size = new System.Drawing.Size(882, 450);
            this.grpEndPDX.TabIndex = 26;
            this.grpEndPDX.Text = "Pflegeproblem beenden";
            // 
            // ucAskEndPDX1
            // 
            this.ucAskEndPDX1.HiedeEndDate = true;
            this.ucAskEndPDX1.Location = new System.Drawing.Point(6, 18);
            this.ucAskEndPDX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucAskEndPDX1.Name = "ucAskEndPDX1";
            this.ucAskEndPDX1.Size = new System.Drawing.Size(856, 424);
            this.ucAskEndPDX1.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 859);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(882, 42);
            this.pnlButtons.TabIndex = 28;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAskEndPDxASZM
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(882, 901);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grpEndASZM);
            this.Controls.Add(this.grpEndPDX);
            this.Controls.Add(this.pnlEndDatum);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(889, 565);
            this.Name = "frmAskEndPDxASZM";
            this.ShowInTaskbar = false;
            this.Text = "Beenden eines Pflegeproblemes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAskEndPDxASZM_FormClosing);
            this.Load += new System.EventHandler(this.frmAskEndPDxASZM_Load);
            this.pnlEndDatum.ResumeLayout(false);
            this.pnlEndDatum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEndASZM)).EndInit();
            this.grpEndASZM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpEndPDX)).EndInit();
            this.grpEndPDX.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucButton btnCancel;
        private ucButton btnOK;
        private QS2.Desktop.ControlManagment.BasePanel pnlEndDatum;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel4;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEnd;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpEndASZM;
        private ucAskEndASZM ucAskEndASZM1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpEndPDX;
        private ucAskEndPDX ucAskEndPDX1;
        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}