namespace PMDS.GUI.ELGA
{
    partial class frmSearchGDA
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
            this.contSearchGDA1 = new PMDS.GUI.ELGA.contSearchGDA();
            this.SuspendLayout();
            // 
            // contSearchGDA1
            // 
            this.contSearchGDA1.BackColor = System.Drawing.Color.Transparent;
            this.contSearchGDA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contSearchGDA1.Location = new System.Drawing.Point(0, 0);
            this.contSearchGDA1.Name = "contSearchGDA1";
            this.contSearchGDA1.Size = new System.Drawing.Size(607, 477);
            this.contSearchGDA1.TabIndex = 0;
            // 
            // frmSearchGDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 477);
            this.Controls.Add(this.contSearchGDA1);
            this.Name = "frmSearchGDA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suche GDA";
            this.Load += new System.EventHandler(this.FrmSearchGDA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private contSearchGDA contSearchGDA1;
    }
}