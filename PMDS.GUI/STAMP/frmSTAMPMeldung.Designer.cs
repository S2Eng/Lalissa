
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnCheck = new QS2.Desktop.ControlManagment.BaseButton();
            this.dtMonat = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.btnSenden = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMelden = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblError = new QS2.Desktop.ControlManagment.BaseLabel();
            this.rtbOhneSynonym = new System.Windows.Forms.RichTextBox();
            this.lblOhneSynonym = new QS2.Desktop.ControlManagment.BaseLabel();
            this.rtbOK = new System.Windows.Forms.RichTextBox();
            this.lblOK = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMonat = new QS2.Desktop.ControlManagment.BaseLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPrint = new QS2.Desktop.ControlManagment.BaseButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTop = new Infragistics.Win.Misc.UltraPanel();
            this.pnlLog = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlOhneSynonym = new System.Windows.Forms.Panel();
            this.pnlOK = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTop.ClientArea.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlOhneSynonym.SuspendLayout();
            this.pnlOK.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(8, 38);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(523, 737);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnCheck
            // 
            this.btnCheck.AutoWorkLayout = false;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.IsStandardControl = false;
            this.btnCheck.Location = new System.Drawing.Point(329, 38);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(185, 43);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Daten überprüfen";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dtMonat
            // 
            this.dtMonat.Location = new System.Drawing.Point(138, 46);
            this.dtMonat.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtMonat.MaskInput = "{LOC}mm.yyyy";
            this.dtMonat.MinDate = new System.DateTime(2022, 4, 1, 0, 0, 0, 0);
            this.dtMonat.Name = "dtMonat";
            this.dtMonat.ownFormat = "";
            this.dtMonat.ownMaskInput = "";
            this.dtMonat.Size = new System.Drawing.Size(113, 31);
            this.dtMonat.TabIndex = 0;
            // 
            // btnSenden
            // 
            this.btnSenden.AutoWorkLayout = false;
            this.btnSenden.Enabled = false;
            this.btnSenden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSenden.IsStandardControl = false;
            this.btnSenden.Location = new System.Drawing.Point(715, 38);
            this.btnSenden.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSenden.Name = "btnSenden";
            this.btnSenden.Size = new System.Drawing.Size(185, 43);
            this.btnSenden.TabIndex = 3;
            this.btnSenden.Text = "Daten senden";
            this.btnSenden.Click += new System.EventHandler(this.btnSenden_Click);
            // 
            // btnMelden
            // 
            this.btnMelden.AutoWorkLayout = false;
            this.btnMelden.Enabled = false;
            this.btnMelden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMelden.IsStandardControl = false;
            this.btnMelden.Location = new System.Drawing.Point(522, 38);
            this.btnMelden.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnMelden.Name = "btnMelden";
            this.btnMelden.Size = new System.Drawing.Size(185, 43);
            this.btnMelden.TabIndex = 2;
            this.btnMelden.Text = "Neue Klienten melden";
            this.btnMelden.Click += new System.EventHandler(this.btnMelden_Click);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(8, 4);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(525, 30);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "Meldungen und Hinweise";
            // 
            // rtbOhneSynonym
            // 
            this.rtbOhneSynonym.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOhneSynonym.Location = new System.Drawing.Point(5, 38);
            this.rtbOhneSynonym.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rtbOhneSynonym.Name = "rtbOhneSynonym";
            this.rtbOhneSynonym.Size = new System.Drawing.Size(347, 790);
            this.rtbOhneSynonym.TabIndex = 7;
            this.rtbOhneSynonym.Text = "";
            // 
            // lblOhneSynonym
            // 
            this.lblOhneSynonym.Location = new System.Drawing.Point(5, 4);
            this.lblOhneSynonym.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblOhneSynonym.Name = "lblOhneSynonym";
            this.lblOhneSynonym.Size = new System.Drawing.Size(347, 30);
            this.lblOhneSynonym.TabIndex = 8;
            this.lblOhneSynonym.Text = "Klienten ohne Synonym (noch nicht gemeldet)";
            // 
            // rtbOK
            // 
            this.rtbOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOK.Location = new System.Drawing.Point(5, 38);
            this.rtbOK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rtbOK.Name = "rtbOK";
            this.rtbOK.Size = new System.Drawing.Size(351, 790);
            this.rtbOK.TabIndex = 9;
            this.rtbOK.Text = "";
            // 
            // lblOK
            // 
            this.lblOK.Location = new System.Drawing.Point(5, 4);
            this.lblOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(315, 30);
            this.lblOK.TabIndex = 10;
            this.lblOK.Text = "Klienten geprüft und fertig zum Senden";
            // 
            // lblMonat
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            this.lblMonat.Appearance = appearance2;
            this.lblMonat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonat.Location = new System.Drawing.Point(23, 48);
            this.lblMonat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(96, 30);
            this.lblMonat.TabIndex = 11;
            this.lblMonat.Text = "Monat";
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint_1);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.OnPrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.IsStandardControl = false;
            this.btnPrint.Location = new System.Drawing.Point(177, 785);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(158, 43);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Drucken";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PMDS.GUI.Properties.Resources.LandSteiermark;
            this.pictureBox1.Location = new System.Drawing.Point(1080, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTop
            // 
            appearance5.BackColor = System.Drawing.Color.DarkGreen;
            this.pnlTop.Appearance = appearance5;
            // 
            // pnlTop.ClientArea
            // 
            this.pnlTop.ClientArea.Controls.Add(this.pictureBox1);
            this.pnlTop.ClientArea.Controls.Add(this.btnCheck);
            this.pnlTop.ClientArea.Controls.Add(this.dtMonat);
            this.pnlTop.ClientArea.Controls.Add(this.lblMonat);
            this.pnlTop.ClientArea.Controls.Add(this.btnSenden);
            this.pnlTop.ClientArea.Controls.Add(this.btnMelden);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1274, 121);
            this.pnlTop.TabIndex = 14;
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.lblError);
            this.pnlLog.Controls.Add(this.rtbLog);
            this.pnlLog.Controls.Add(this.btnPrint);
            this.pnlLog.Location = new System.Drawing.Point(0, 128);
            this.pnlLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(537, 1001);
            this.pnlLog.TabIndex = 15;
            this.pnlLog.Visible = false;
            // 
            // pnlOhneSynonym
            // 
            this.pnlOhneSynonym.Controls.Add(this.lblOhneSynonym);
            this.pnlOhneSynonym.Controls.Add(this.rtbOhneSynonym);
            this.pnlOhneSynonym.Location = new System.Drawing.Point(543, 128);
            this.pnlOhneSynonym.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOhneSynonym.Name = "pnlOhneSynonym";
            this.pnlOhneSynonym.Size = new System.Drawing.Size(360, 1001);
            this.pnlOhneSynonym.TabIndex = 16;
            this.pnlOhneSynonym.Visible = false;
            // 
            // pnlOK
            // 
            this.pnlOK.Controls.Add(this.lblOK);
            this.pnlOK.Controls.Add(this.rtbOK);
            this.pnlOK.Location = new System.Drawing.Point(909, 128);
            this.pnlOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(360, 1001);
            this.pnlOK.TabIndex = 17;
            this.pnlOK.Visible = false;
            // 
            // frmSTAMPMeldung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 961);
            this.Controls.Add(this.pnlOK);
            this.Controls.Add(this.pnlOhneSynonym);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmSTAMPMeldung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "STAMP-Meldung senden";
            ((System.ComponentModel.ISupportInitialize)(this.dtMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTop.ClientArea.ResumeLayout(false);
            this.pnlTop.ClientArea.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlOhneSynonym.ResumeLayout(false);
            this.pnlOK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private QS2.Desktop.ControlManagment.BaseButton btnCheck;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtMonat;
        private QS2.Desktop.ControlManagment.BaseButton btnSenden;
        private QS2.Desktop.ControlManagment.BaseButton btnMelden;
        private QS2.Desktop.ControlManagment.BaseLabel lblError;
        private System.Windows.Forms.RichTextBox rtbOhneSynonym;
        private QS2.Desktop.ControlManagment.BaseLabel lblOhneSynonym;
        private System.Windows.Forms.RichTextBox rtbOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblMonat;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private QS2.Desktop.ControlManagment.BaseButton btnPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Infragistics.Win.Misc.UltraPanel pnlTop;
        private QS2.Desktop.ControlManagment.BasePanel pnlLog;
        private System.Windows.Forms.Panel pnlOhneSynonym;
        private System.Windows.Forms.Panel pnlOK;
    }
}