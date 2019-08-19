namespace PMDS.GUI
{
    partial class frmAskLocalize2
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskLocalize2));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucPDXTreeView1 = new PMDS.GUI.BaseControls.ucPDXTreeView();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.pnlBody = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlRight = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblError = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucASZMTransferPDx1 = new PMDS.GUI.ucASZMTransferPDx();
            this.ucASZMTransfer1 = new PMDS.GUI.ucASZMTransfer();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlLeft = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbResourcen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlFooter = new QS2.Desktop.ControlManagment.BasePanel();
            this.line1 = new PMDS.GUI.BaseControls.Line();
            this.pnlBody.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResourcen)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(876, 70);
            this.labInfo.TabIndex = 9;
            this.labInfo.Text = "Lokalisierung und oder Startdatum angeben";
            // 
            // ucPDXTreeView1
            // 
            this.ucPDXTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPDXTreeView1.Location = new System.Drawing.Point(0, 0);
            this.ucPDXTreeView1.Name = "ucPDXTreeView1";
            this.ucPDXTreeView1.Size = new System.Drawing.Size(299, 442);
            this.ucPDXTreeView1.TabIndex = 1;
            this.ucPDXTreeView1.TreeviewBeforeNodeSelectEventArgs += new Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler(this.ucPDXTreeView1_TreeviewBeforeNodeSelectEventArgs);
            this.ucPDXTreeView1.TreeviewAfterNodeSelectEventHandler += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.ucPDXTreeView1_TreeviewAfterNodeSelectEventHandler);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(726, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(822, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlRight);
            this.pnlBody.Controls.Add(this.splitter2);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 70);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(876, 566);
            this.pnlBody.TabIndex = 16;
            // 
            // pnlRight
            // 
            this.pnlRight.AutoScroll = true;
            this.pnlRight.Controls.Add(this.lblError);
            this.pnlRight.Controls.Add(this.ucASZMTransferPDx1);
            this.pnlRight.Controls.Add(this.ucASZMTransfer1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(302, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(574, 566);
            this.pnlRight.TabIndex = 17;
            // 
            // lblError
            // 
            appearance4.BorderColor = System.Drawing.Color.LightSeaGreen;
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.lblError.Appearance = appearance4;
            this.lblError.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(74, 166);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(356, 161);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Bitte eine Pflegediagnose oder eine Ätiologie, ein Symptom oder eine Maßnahme aus" +
    "wählen!";
            // 
            // ucASZMTransferPDx1
            // 
            this.ucASZMTransferPDx1.BackColor = System.Drawing.Color.White;
            this.ucASZMTransferPDx1.Location = new System.Drawing.Point(0, 30);
            this.ucASZMTransferPDx1.Name = "ucASZMTransferPDx1";
            this.ucASZMTransferPDx1.Size = new System.Drawing.Size(556, 194);
            this.ucASZMTransferPDx1.TabIndex = 0;
            this.ucASZMTransferPDx1.PDxValueChanged += new System.EventHandler(this.ucASZMTransferPDx1_PDxValueChanged);
            this.ucASZMTransferPDx1.PDxZusaetzlicheLokalisierung += new System.EventHandler(this.ucASZMTransferPDx1_PDxZusaetzlicheLokalisierung);
            // 
            // ucASZMTransfer1
            // 
            this.ucASZMTransfer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucASZMTransfer1.Location = new System.Drawing.Point(0, 0);
            this.ucASZMTransfer1.Name = "ucASZMTransfer1";
            this.ucASZMTransfer1.Size = new System.Drawing.Size(556, 729);
            this.ucASZMTransfer1.TabIndex = 1;
            this.ucASZMTransfer1.ASZMValueChanged += new System.EventHandler(this.ucASZMTransfer1_ASZMValueChanged);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Silver;
            this.splitter2.Location = new System.Drawing.Point(299, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 566);
            this.splitter2.TabIndex = 20;
            this.splitter2.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblInfo);
            this.pnlLeft.Controls.Add(this.tbResourcen);
            this.pnlLeft.Controls.Add(this.ucPDXTreeView1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(299, 566);
            this.pnlLeft.TabIndex = 18;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(3, 445);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(68, 14);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Ressourcen:";
            // 
            // tbResourcen
            // 
            this.tbResourcen.AcceptsReturn = true;
            this.tbResourcen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.BackColorDisabled = System.Drawing.Color.White;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.tbResourcen.Appearance = appearance5;
            this.tbResourcen.BackColor = System.Drawing.SystemColors.Window;
            this.tbResourcen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResourcen.Location = new System.Drawing.Point(5, 461);
            this.tbResourcen.MaxLength = 2048;
            this.tbResourcen.Multiline = true;
            this.tbResourcen.Name = "tbResourcen";
            this.tbResourcen.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbResourcen.Size = new System.Drawing.Size(288, 99);
            this.tbResourcen.TabIndex = 5;
            this.tbResourcen.ValueChanged += new System.EventHandler(this.tbResourcen_ValueChanged);
            this.tbResourcen.Leave += new System.EventHandler(this.tbResourcen_Leave);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 636);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(876, 40);
            this.pnlFooter.TabIndex = 17;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Silver;
            this.line1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line1.Location = new System.Drawing.Point(0, 634);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(876, 2);
            this.line1.TabIndex = 18;
            // 
            // frmAskLocalize2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(876, 676);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmAskLocalize2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Startdatum und Lokalisierung angeben";
            this.Load += new System.EventHandler(this.frmAskLocalize2_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResourcen)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucButton btnCancel;
        private ucButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        private PMDS.GUI.BaseControls.ucPDXTreeView ucPDXTreeView1;
        private QS2.Desktop.ControlManagment.BasePanel pnlBody;
        private QS2.Desktop.ControlManagment.BasePanel pnlFooter;
        private QS2.Desktop.ControlManagment.BasePanel pnlRight;
        private ucASZMTransfer ucASZMTransfer1;
        private ucASZMTransferPDx ucASZMTransferPDx1;
        private QS2.Desktop.ControlManagment.BaseLabel lblError;
        private System.Windows.Forms.Splitter splitter2;
        private QS2.Desktop.ControlManagment.BasePanel pnlLeft;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfo;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbResourcen;
        private PMDS.GUI.BaseControls.Line line1;
    }
}