namespace PMDS.GUI.Datenerhebung
{
    partial class frmDatenErhebung
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
            this.ucDatenErhebungExtern1 = new PMDS.GUI.Datenerhebung.ucDatenErhebungExtern();
            this.SuspendLayout();
            // 
            // ucDatenErhebungExtern1
            // 
            this.ucDatenErhebungExtern1.BackColor = System.Drawing.Color.White;
            this.ucDatenErhebungExtern1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucDatenErhebungExtern1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDatenErhebungExtern1.Location = new System.Drawing.Point(0, 0);
            this.ucDatenErhebungExtern1.Name = "ucDatenErhebungExtern1";
            this.ucDatenErhebungExtern1.Size = new System.Drawing.Size(1091, 665);
            this.ucDatenErhebungExtern1.TabIndex = 0;
            // 
            // frmDatenErhebung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 665);
            this.Controls.Add(this.ucDatenErhebungExtern1);
            this.Name = "frmDatenErhebung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datenerhebung";
            this.Load += new System.EventHandler(this.frmDatenErhebung_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucDatenErhebungExtern ucDatenErhebungExtern1;
    }
}