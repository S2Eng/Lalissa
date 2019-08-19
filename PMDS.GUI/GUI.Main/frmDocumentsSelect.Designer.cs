namespace PMDS.GUI.GUI.Main
{
    partial class frmDocumentsSelect
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
            this.contDocumentSelect1 = new PMDS.GUI.GUI.Main.contDocumentSelect();
            this.SuspendLayout();
            // 
            // contDocumentSelect1
            // 
            this.contDocumentSelect1.BackColor = System.Drawing.Color.Transparent;
            this.contDocumentSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contDocumentSelect1.Location = new System.Drawing.Point(0, 0);
            this.contDocumentSelect1.Name = "contDocumentSelect1";
            this.contDocumentSelect1.Size = new System.Drawing.Size(506, 366);
            this.contDocumentSelect1.TabIndex = 0;
            // 
            // frmDocumentsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 366);
            this.Controls.Add(this.contDocumentSelect1);
            this.Name = "frmDocumentsSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dokumente für Benutzer";
            this.Load += new System.EventHandler(this.frmDocumentsSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contDocumentSelect contDocumentSelect1;

    }
}