namespace PMDS.GUI.GUI.Main
{
    partial class frmManageDocuments
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
            this.contManageDocuments1 = new PMDS.GUI.GUI.Main.contManageDocuments();
            this.SuspendLayout();
            // 
            // contManageDocuments1
            // 
            this.contManageDocuments1.BackColor = System.Drawing.Color.Transparent;
            this.contManageDocuments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contManageDocuments1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contManageDocuments1.Location = new System.Drawing.Point(0, 0);
            this.contManageDocuments1.Margin = new System.Windows.Forms.Padding(4);
            this.contManageDocuments1.Name = "contManageDocuments1";
            this.contManageDocuments1.Size = new System.Drawing.Size(999, 696);
            this.contManageDocuments1.TabIndex = 0;
            this.contManageDocuments1.Load += new System.EventHandler(this.contManageDocuments1_Load);
            // 
            // frmManageDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 696);
            this.Controls.Add(this.contManageDocuments1);
            this.Name = "frmManageDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dokumentenverwaltung";
            this.Load += new System.EventHandler(this.frmManageDocuments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contManageDocuments contManageDocuments1;

    }
}