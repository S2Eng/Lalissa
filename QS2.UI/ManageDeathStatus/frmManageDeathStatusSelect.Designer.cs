
namespace qs2.ui.ManageDeathStatus
{
    partial class frmManageDeathStatusSelect
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
            this.contManageDeathStatusSelect1 = new qs2.ui.ManageDeathStatus.contManageDeathStatusSelect();
            this.SuspendLayout();
            // 
            // contManageDeathStatusSelect1
            // 
            this.contManageDeathStatusSelect1.Location = new System.Drawing.Point(3, 1);
            this.contManageDeathStatusSelect1.Name = "contManageDeathStatusSelect1";
            this.contManageDeathStatusSelect1.Size = new System.Drawing.Size(765, 333);
            this.contManageDeathStatusSelect1.TabIndex = 0;
            // 
            // frmManageDeathStatusSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 344);
            this.Controls.Add(this.contManageDeathStatusSelect1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmManageDeathStatusSelect";
            this.Text = "Auswahl der Abgleichsmethode für den Sterbestatus";
            this.ResumeLayout(false);

        }

        #endregion

        private contManageDeathStatusSelect contManageDeathStatusSelect1;
    }
}