namespace PMDS.GUI.ELGA
{
    partial class frmCDAViewer
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
            this.contCDAViewer1 = new PMDS.GUI.ELGA.contCDAViewer();
            this.SuspendLayout();
            // 
            // contCDAViewer1
            // 
            this.contCDAViewer1.BackColor = System.Drawing.Color.White;
            this.contCDAViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contCDAViewer1.Location = new System.Drawing.Point(0, 0);
            this.contCDAViewer1.Name = "contCDAViewer1";
            this.contCDAViewer1.Size = new System.Drawing.Size(1035, 767);
            this.contCDAViewer1.TabIndex = 0;
            // 
            // frmCDAViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1035, 767);
            this.Controls.Add(this.contCDAViewer1);
            this.Name = "frmCDAViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CDA Dokumentenanzeige";
            this.Load += new System.EventHandler(this.FrmCDAViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contCDAViewer contCDAViewer1;
    }
}