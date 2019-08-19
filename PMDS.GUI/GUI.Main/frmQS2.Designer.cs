namespace PMDS.GUI
{
    partial class frmQS2
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
            this.panelControl = new QS2.Desktop.ControlManagment.BasePanel();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.Transparent;
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(913, 656);
            this.panelControl.TabIndex = 0;
            // 
            // frmQS2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 656);
            this.Controls.Add(this.panelControl);
            this.Name = "frmQS2";
            this.Text = "QS2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQS2_FormClosing);
            this.Load += new System.EventHandler(this.frmQS2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BasePanel panelControl;
    }
}