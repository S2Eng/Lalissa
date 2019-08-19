namespace PMDS.GUI.Verordnungen
{
    partial class frmVOLieferungDetail
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
            this.ucVOLieferungDetail1 = new PMDS.GUI.Verordnungen.ucVOLieferungDetail();
            this.SuspendLayout();
            // 
            // ucVOLieferungDetail1
            // 
            this.ucVOLieferungDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOLieferungDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucVOLieferungDetail1.Name = "ucVOLieferungDetail1";
            this.ucVOLieferungDetail1.Size = new System.Drawing.Size(675, 568);
            this.ucVOLieferungDetail1.TabIndex = 0;
            // 
            // frmVOLieferungDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 568);
            this.Controls.Add(this.ucVOLieferungDetail1);
            this.Name = "frmVOLieferungDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verordnungen Lieferungen Detail";
            this.Load += new System.EventHandler(this.frmVOLieferungDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOLieferungDetail ucVOLieferungDetail1;
    }
}