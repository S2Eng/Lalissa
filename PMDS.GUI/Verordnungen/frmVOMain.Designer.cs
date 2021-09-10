namespace PMDS.GUI.Verordnungen
{
    partial class frmVOMain
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
            this.ucVOMain1 = new PMDS.GUI.Verordnungen.ucVOMain();
            this.SuspendLayout();
            // 
            // ucVOMain1
            // 
            this.ucVOMain1.BackColor = System.Drawing.Color.White;
            this.ucVOMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOMain1.Location = new System.Drawing.Point(0, 0);
            this.ucVOMain1.Name = "ucVOMain1";
            this.ucVOMain1.Size = new System.Drawing.Size(1230, 711);
            this.ucVOMain1.TabIndex = 0;
            // 
            // frmVOMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1230, 711);
            this.Controls.Add(this.ucVOMain1);
            this.Name = "frmVOMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verordnungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVOMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ucVOMain ucVOMain1;
    }
}