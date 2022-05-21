namespace PMDS.GUI.GUI.Main
{
    partial class frmLoadingWait
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblLoadingData = new Infragistics.Win.Misc.UltraLabel();
            this.lblPleaseWait = new Infragistics.Win.Misc.UltraLabel();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.panelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoadingData
            // 
            appearance1.FontData.SizeInPoints = 13F;
            appearance1.TextHAlignAsString = "Center";
            this.lblLoadingData.Appearance = appearance1;
            this.lblLoadingData.Location = new System.Drawing.Point(18, 14);
            this.lblLoadingData.Name = "lblLoadingData";
            this.lblLoadingData.Size = new System.Drawing.Size(407, 25);
            this.lblLoadingData.TabIndex = 0;
            this.lblLoadingData.Text = "Daten werden geladen";
            // 
            // lblPleaseWait
            // 
            appearance2.FontData.SizeInPoints = 13F;
            appearance2.TextHAlignAsString = "Center";
            this.lblPleaseWait.Appearance = appearance2;
            this.lblPleaseWait.Location = new System.Drawing.Point(18, 45);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(407, 25);
            this.lblPleaseWait.TabIndex = 1;
            this.lblPleaseWait.Text = "Bitte warten ...";
            // 
            // panelLoading
            // 
            this.panelLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLoading.Controls.Add(this.lblPleaseWait);
            this.panelLoading.Controls.Add(this.lblLoadingData);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(438, 86);
            this.panelLoading.TabIndex = 2;
            // 
            // frmLoadingWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 86);
            this.ControlBox = false;
            this.Controls.Add(this.panelLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadingWait";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadingWait";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLoadingWait_FormClosing);
            this.Load += new System.EventHandler(this.frmLoadingWait_Load);
            this.VisibleChanged += new System.EventHandler(this.frmLoadingWait_VisibleChanged);
            this.panelLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblLoadingData;
        private Infragistics.Win.Misc.UltraLabel lblPleaseWait;
        private System.Windows.Forms.Panel panelLoading;
    }
}