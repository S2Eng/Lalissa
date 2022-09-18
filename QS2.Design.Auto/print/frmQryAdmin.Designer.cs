namespace qs2.ui.print
{
    partial class frmQryAdmin
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
            this.components = new System.ComponentModel.Container();
            this.contQryAdmin1 = new qs2.ui.print.contQryAdmin();
            this.SuspendLayout();
            // 
            // contQryAdmin1
            // 
            this.contQryAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contQryAdmin1.Location = new System.Drawing.Point(0, 0);
            this.contQryAdmin1.MinimumSize = new System.Drawing.Size(741, 454);
            this.contQryAdmin1.Name = "contQryAdmin1";
            this.contQryAdmin1.Size = new System.Drawing.Size(972, 613);
            this.contQryAdmin1.TabIndex = 0;
            // 
            // frmQryAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(972, 613);
            this.Controls.Add(this.contQryAdmin1);
            this.MinimumSize = new System.Drawing.Size(882, 493);
            this.Name = "frmQryAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Queries";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQryAdmin_FormClosing);
            this.Load += new System.EventHandler(this.frmRessourcencs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public qs2.ui.print.contQryAdmin contQryAdmin1;


    }
}