namespace PMDS.GUI.Misc
{
    partial class frmBlisterliste
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
            this.btnCreateBlisterliste = new Infragistics.Win.Misc.UltraButton();
            this.lbliCount = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // btnCreateBlisterliste
            // 
            this.btnCreateBlisterliste.Location = new System.Drawing.Point(611, 122);
            this.btnCreateBlisterliste.Name = "btnCreateBlisterliste";
            this.btnCreateBlisterliste.Size = new System.Drawing.Size(165, 57);
            this.btnCreateBlisterliste.TabIndex = 0;
            this.btnCreateBlisterliste.Text = "Start";
            this.btnCreateBlisterliste.Click += new System.EventHandler(this.btnCreateBlisterliste_Click_1);
            // 
            // lbliCount
            // 
            this.lbliCount.Location = new System.Drawing.Point(461, 143);
            this.lbliCount.Name = "lbliCount";
            this.lbliCount.Size = new System.Drawing.Size(90, 24);
            this.lbliCount.TabIndex = 1;
            // 
            // frmBlisterliste
            // 
            this.ClientSize = new System.Drawing.Size(1010, 467);
            this.Controls.Add(this.lbliCount);
            this.Controls.Add(this.btnCreateBlisterliste);
            this.Name = "frmBlisterliste";
            this.Text = "Blisterliste";
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnCreateBlisterliste;
        private Infragistics.Win.Misc.UltraLabel lbliCount;
    }
}