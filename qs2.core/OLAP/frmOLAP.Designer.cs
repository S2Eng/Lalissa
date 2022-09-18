namespace qs2.ui.OLAP
{
    partial class frmOLAP
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
            this.contOLAP1 = new qs2.ui.OLAP.contOLAP();
            this.SuspendLayout();
            // 
            // contOLAP1
            // 
            this.contOLAP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contOLAP1.Location = new System.Drawing.Point(0, 0);
            this.contOLAP1.Name = "contOLAP1";
            this.contOLAP1.Size = new System.Drawing.Size(894, 552);
            this.contOLAP1.TabIndex = 0;
            // 
            // frmOLAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 552);
            this.Controls.Add(this.contOLAP1);
            this.Name = "frmOLAP";
            this.Text = "OLAP";
            this.ResumeLayout(false);

        }

        #endregion

        private contOLAP contOLAP1;
    }
}