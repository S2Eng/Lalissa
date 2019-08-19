namespace PMDS.GUI
{
    partial class ucAskEndASZM
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
            this.pnlEndDatum = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEnd = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.lbInfo = new System.Windows.Forms.CheckedListBox();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbReason = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlEndDatum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEndDatum
            // 
            this.pnlEndDatum.Controls.Add(this.ultraLabel4);
            this.pnlEndDatum.Controls.Add(this.dtpEnd);
            this.pnlEndDatum.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEndDatum.Location = new System.Drawing.Point(0, 0);
            this.pnlEndDatum.Name = "pnlEndDatum";
            this.pnlEndDatum.Size = new System.Drawing.Size(734, 22);
            this.pnlEndDatum.TabIndex = 24;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(0, 4);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(64, 16);
            this.ultraLabel4.TabIndex = 18;
            this.ultraLabel4.Text = "Endedatum";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(72, 0);
            this.dtpEnd.MaskInput = "dd.mm.yyyy";
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(96, 21);
            this.dtpEnd.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbInfo);
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Controls.Add(this.ultraLabel2);
            this.panel1.Controls.Add(this.tbReason);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 267);
            this.panel1.TabIndex = 25;
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Location = new System.Drawing.Point(3, 96);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(728, 167);
            this.lbInfo.TabIndex = 24;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(3, 80);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(336, 16);
            this.ultraLabel1.TabIndex = 23;
            this.ultraLabel1.Text = "Markieren Sie alle zu beendenden Elemente";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(3, 3);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(168, 16);
            this.ultraLabel2.TabIndex = 22;
            this.ultraLabel2.Text = "Grund der Beendigung";
            // 
            // tbReason
            // 
            this.tbReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReason.Location = new System.Drawing.Point(2, 19);
            this.tbReason.MaxLength = 255;
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbReason.Size = new System.Drawing.Size(729, 59);
            this.tbReason.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucAskEndASZM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlEndDatum);
            this.Name = "ucAskEndASZM";
            this.Size = new System.Drawing.Size(734, 293);
            this.pnlEndDatum.ResumeLayout(false);
            this.pnlEndDatum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlEndDatum;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel4;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEnd;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel2;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbReason;
        private System.Windows.Forms.CheckedListBox lbInfo;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
