namespace PMDS.GUI.Messenger
{
    partial class frmMessenger
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.contMessenger1 = new PMDS.GUI.Messenger.contMessenger();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 681);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusPanel1.Key = "UnreadedMessages";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.ultraStatusBar1.Size = new System.Drawing.Size(1044, 15);
            this.ultraStatusBar1.TabIndex = 14;
            // 
            // contMessenger1
            // 
            this.contMessenger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contMessenger1.Location = new System.Drawing.Point(0, 0);
            this.contMessenger1.Name = "contMessenger1";
            this.contMessenger1.Size = new System.Drawing.Size(1044, 681);
            this.contMessenger1.TabIndex = 15;
            // 
            // frmMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1044, 696);
            this.Controls.Add(this.contMessenger1);
            this.Controls.Add(this.ultraStatusBar1);
            this.Name = "frmMessenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Internes Nachrichtensystem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMessenger_FormClosing);
            this.Load += new System.EventHandler(this.frmMessenger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public contMessenger contMessenger1;
        public Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
    }
}