
namespace PMDS.GUI.STAMP
{
    partial class frmSTAMPMeldung
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnCheck = new QS2.Desktop.ControlManagment.BaseButton();
            this.dtMonat = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.btnSenden = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMelden = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonat)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(16, 158);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1033, 254);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            this.rtbLog.Visible = false;
            // 
            // btnCheck
            // 
            this.btnCheck.AutoWorkLayout = false;
            this.btnCheck.IsStandardControl = false;
            this.btnCheck.Location = new System.Drawing.Point(562, 32);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 28);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Prüfen";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dtMonat
            // 
            this.dtMonat.Location = new System.Drawing.Point(409, 33);
            this.dtMonat.Margin = new System.Windows.Forms.Padding(4);
            this.dtMonat.MinDate = new System.DateTime(2022, 4, 1, 0, 0, 0, 0);
            this.dtMonat.Name = "dtMonat";
            this.dtMonat.ownFormat = "";
            this.dtMonat.ownMaskInput = "";
            this.dtMonat.Size = new System.Drawing.Size(140, 24);
            this.dtMonat.TabIndex = 3;
            // 
            // btnSenden
            // 
            this.btnSenden.AutoWorkLayout = false;
            this.btnSenden.Enabled = false;
            this.btnSenden.IsStandardControl = false;
            this.btnSenden.Location = new System.Drawing.Point(842, 32);
            this.btnSenden.Margin = new System.Windows.Forms.Padding(4);
            this.btnSenden.Name = "btnSenden";
            this.btnSenden.Size = new System.Drawing.Size(164, 28);
            this.btnSenden.TabIndex = 4;
            this.btnSenden.Text = "Meldung senden";
            this.btnSenden.Click += new System.EventHandler(this.btnSenden_Click);
            // 
            // btnMelden
            // 
            this.btnMelden.AutoWorkLayout = false;
            this.btnMelden.Enabled = false;
            this.btnMelden.IsStandardControl = false;
            this.btnMelden.Location = new System.Drawing.Point(670, 33);
            this.btnMelden.Margin = new System.Windows.Forms.Padding(4);
            this.btnMelden.Name = "btnMelden";
            this.btnMelden.Size = new System.Drawing.Size(164, 28);
            this.btnMelden.TabIndex = 5;
            this.btnMelden.Text = "Neue Klienten melden";
            this.btnMelden.Click += new System.EventHandler(this.btnMelden_Click);
            // 
            // frmSTAMPMeldung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnMelden);
            this.Controls.Add(this.btnSenden);
            this.Controls.Add(this.dtMonat);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.rtbLog);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSTAMPMeldung";
            this.Text = "frmSTAMPMeldung";
            ((System.ComponentModel.ISupportInitialize)(this.dtMonat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private QS2.Desktop.ControlManagment.BaseButton btnCheck;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtMonat;
        private QS2.Desktop.ControlManagment.BaseButton btnSenden;
        private QS2.Desktop.ControlManagment.BaseButton btnMelden;
    }
}