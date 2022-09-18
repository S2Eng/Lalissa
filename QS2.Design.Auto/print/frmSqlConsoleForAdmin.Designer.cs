namespace qs2.design.auto.print
{
    partial class frmSqlConsoleForAdmin
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
            this.contSqlConsoleForAdmin1 = new qs2.design.auto.print.contSqlConsoleForAdmin();
            this.SuspendLayout();
            // 
            // contSqlConsoleForAdmin1
            // 
            this.contSqlConsoleForAdmin1.BackColor = System.Drawing.Color.Transparent;
            this.contSqlConsoleForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contSqlConsoleForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.contSqlConsoleForAdmin1.Name = "contSqlConsoleForAdmin1";
            this.contSqlConsoleForAdmin1.Size = new System.Drawing.Size(1072, 678);
            this.contSqlConsoleForAdmin1.TabIndex = 0;
            // 
            // frmSqlConsoleForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 678);
            this.Controls.Add(this.contSqlConsoleForAdmin1);
            this.Name = "frmSqlConsoleForAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sql-Console";
            this.Load += new System.EventHandler(this.frmSqlConsoleForAdmin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contSqlConsoleForAdmin contSqlConsoleForAdmin1;

    }
}