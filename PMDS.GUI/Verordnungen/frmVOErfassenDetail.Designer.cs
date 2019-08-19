namespace PMDS.GUI.Verordnungen
{
    partial class frmVOErfassenDetail
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
            this.ucVOErfassenDetail1 = new PMDS.GUI.Verordnungen.ucVOErfassenDetail();
            this.SuspendLayout();
            // 
            // ucVOErfassenDetail1
            // 
            this.ucVOErfassenDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOErfassenDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucVOErfassenDetail1.Name = "ucVOErfassenDetail1";
            this.ucVOErfassenDetail1.Size = new System.Drawing.Size(765, 677);
            this.ucVOErfassenDetail1.TabIndex = 0;
            // 
            // frmVOErfassenDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 677);
            this.Controls.Add(this.ucVOErfassenDetail1);
            this.Name = "frmVOErfassenDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verordnungen erfassen Detail";
            this.Load += new System.EventHandler(this.frmVOErfassenDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOErfassenDetail ucVOErfassenDetail1;
    }
}