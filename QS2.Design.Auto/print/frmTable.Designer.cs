namespace qs2.ui.print
{
    partial class frmTable
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
            this.contTable1 = new qs2.ui.print.contTable();
            this.SuspendLayout();
            // 
            // contTable1
            // 
            this.contTable1.BackColor = System.Drawing.Color.Transparent;
            this.contTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contTable1.Location = new System.Drawing.Point(0, 0);
            this.contTable1.Name = "contTable1";
            this.contTable1.Size = new System.Drawing.Size(969, 528);
            this.contTable1.TabIndex = 0;
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 528);
            this.Controls.Add(this.contTable1);
            this.Name = "frmTable";
            this.Text = "Result Query";
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public qs2.ui.print.contTable contTable1;

    }
}