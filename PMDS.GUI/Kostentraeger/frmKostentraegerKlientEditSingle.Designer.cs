namespace PMDS.GUI.Kostentraeger
{
    partial class frmKostentraegerKlientEditSingle
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
            this.ucKostentraegerKlientEditSingle1 = new PMDS.GUI.Kostentraeger.ucKostentraegerKlientEditSingle();
            this.SuspendLayout();
            // 
            // ucKostentraegerKlientEditSingle1
            // 
            this.ucKostentraegerKlientEditSingle1.abort = true;
            this.ucKostentraegerKlientEditSingle1.BackColor = System.Drawing.Color.Transparent;
            this.ucKostentraegerKlientEditSingle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKostentraegerKlientEditSingle1.FSWMode = false;
            this.ucKostentraegerKlientEditSingle1.Location = new System.Drawing.Point(0, 0);
            this.ucKostentraegerKlientEditSingle1.mainWindow = null;
            this.ucKostentraegerKlientEditSingle1.Margin = new System.Windows.Forms.Padding(4);
            this.ucKostentraegerKlientEditSingle1.Name = "ucKostentraegerKlientEditSingle1";
            this.ucKostentraegerKlientEditSingle1.Size = new System.Drawing.Size(1020, 600);
            this.ucKostentraegerKlientEditSingle1.TabIndex = 0;
            // 
            // frmKostentraegerKlientEditSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 600);
            this.Controls.Add(this.ucKostentraegerKlientEditSingle1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmKostentraegerKlientEditSingle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Klient als Kostenträger";
            this.Load += new System.EventHandler(this.frmKostentraegerKlientEditSingle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucKostentraegerKlientEditSingle ucKostentraegerKlientEditSingle1;
    }
}