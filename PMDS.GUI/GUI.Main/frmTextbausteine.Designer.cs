namespace PMDS.GUI.GUI.Main
{
    partial class frmTextbausteine
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
            this.contTextbausteine1 = new PMDS.GUI.GUI.Main.contTextbausteine();
            this.SuspendLayout();
            // 
            // contTextbausteine1
            // 
            this.contTextbausteine1.BackColor = System.Drawing.Color.Transparent;
            this.contTextbausteine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contTextbausteine1.Location = new System.Drawing.Point(0, 0);
            this.contTextbausteine1.Name = "contTextbausteine1";
            this.contTextbausteine1.Size = new System.Drawing.Size(761, 411);
            this.contTextbausteine1.TabIndex = 0;
            // 
            // frmTextbausteine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 411);
            this.Controls.Add(this.contTextbausteine1);
            this.Name = "frmTextbausteine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Textbausteine";
            this.Load += new System.EventHandler(this.frmTextbausteine_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contTextbausteine contTextbausteine1;

    }
}