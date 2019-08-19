namespace PMDS.GUI.BaseControls
{
    partial class frmEintraegeQuickEdit
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
            this.contASZMQuickEdit1 = new PMDS.GUI.BaseControls.contEintraegeQuickEdit();
            this.SuspendLayout();
            // 
            // contASZMQuickEdit1
            // 
            this.contASZMQuickEdit1.BackColor = System.Drawing.Color.White;
            this.contASZMQuickEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contASZMQuickEdit1.Location = new System.Drawing.Point(0, 0);
            this.contASZMQuickEdit1.Name = "contASZMQuickEdit1";
            this.contASZMQuickEdit1.Size = new System.Drawing.Size(947, 670);
            this.contASZMQuickEdit1.TabIndex = 0;
            // 
            // frmEintraegeQuickEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 670);
            this.Controls.Add(this.contASZMQuickEdit1);
            this.Name = "frmEintraegeQuickEdit";
            this.Text = "ASRZM Katalog editieren";
            this.Load += new System.EventHandler(this.frmASZMQuickEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contEintraegeQuickEdit contASZMQuickEdit1;
    }
}