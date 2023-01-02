
namespace PMDS.GUI.ELDA
{
    partial class frmELDA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmELDA));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnPickXlsx = new Infragistics.Win.Misc.UltraButton();
            this.btnPickTxt = new Infragistics.Win.Misc.UltraButton();
            this.lblXlsx = new Infragistics.Win.Misc.UltraLabel();
            this.lblTxt = new Infragistics.Win.Misc.UltraLabel();
            this.txtXlsx = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtTxt = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnStart = new Infragistics.Win.Misc.UltraButton();
            this.rtbTxt = new System.Windows.Forms.RichTextBox();
            this.lblLog = new Infragistics.Win.Misc.UltraLabel();
            this.lblRex = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtXlsx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(7, 131);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(914, 307);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnPickXlsx
            // 
            this.btnPickXlsx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickXlsx.Location = new System.Drawing.Point(700, 14);
            this.btnPickXlsx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPickXlsx.Name = "btnPickXlsx";
            this.btnPickXlsx.Size = new System.Drawing.Size(107, 29);
            this.btnPickXlsx.TabIndex = 1;
            this.btnPickXlsx.Text = "Suchen";
            this.btnPickXlsx.Click += new System.EventHandler(this.btnPickXlsx_Click);
            // 
            // btnPickTxt
            // 
            this.btnPickTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickTxt.Location = new System.Drawing.Point(700, 61);
            this.btnPickTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPickTxt.Name = "btnPickTxt";
            this.btnPickTxt.Size = new System.Drawing.Size(107, 27);
            this.btnPickTxt.TabIndex = 2;
            this.btnPickTxt.Text = "Suchen";
            this.btnPickTxt.Click += new System.EventHandler(this.btnPickTxt_Click);
            // 
            // lblXlsx
            // 
            this.lblXlsx.Location = new System.Drawing.Point(7, 21);
            this.lblXlsx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblXlsx.Name = "lblXlsx";
            this.lblXlsx.Size = new System.Drawing.Size(153, 22);
            this.lblXlsx.TabIndex = 3;
            this.lblXlsx.Text = "Excel-Rechnungs-Datei";
            // 
            // lblTxt
            // 
            this.lblTxt.Location = new System.Drawing.Point(7, 67);
            this.lblTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(153, 22);
            this.lblTxt.TabIndex = 4;
            this.lblTxt.Text = "Text-ELDA-Datei";
            // 
            // txtXlsx
            // 
            this.txtXlsx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXlsx.Location = new System.Drawing.Point(158, 16);
            this.txtXlsx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXlsx.Name = "txtXlsx";
            this.txtXlsx.Size = new System.Drawing.Size(536, 26);
            this.txtXlsx.TabIndex = 5;
            this.txtXlsx.ValueChanged += new System.EventHandler(this.txtXlsx_ValueChanged);
            // 
            // txtTxt
            // 
            this.txtTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTxt.Location = new System.Drawing.Point(158, 61);
            this.txtTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTxt.Name = "txtTxt";
            this.txtTxt.Size = new System.Drawing.Size(536, 26);
            this.txtTxt.TabIndex = 6;
            this.txtTxt.ValueChanged += new System.EventHandler(this.txtTxt_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(814, 60);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 27);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rtbTxt
            // 
            this.rtbTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbTxt.Location = new System.Drawing.Point(5, 481);
            this.rtbTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbTxt.Name = "rtbTxt";
            this.rtbTxt.Size = new System.Drawing.Size(914, 332);
            this.rtbTxt.TabIndex = 8;
            this.rtbTxt.Text = "";
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(7, 101);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(153, 22);
            this.lblLog.TabIndex = 9;
            this.lblLog.Text = "Log";
            // 
            // lblRex
            // 
            this.lblRex.Location = new System.Drawing.Point(7, 451);
            this.lblRex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRex.Name = "lblRex";
            this.lblRex.Size = new System.Drawing.Size(153, 22);
            this.lblRex.TabIndex = 10;
            this.lblRex.Text = "Ergebnis";
            // 
            // frmELDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 830);
            this.Controls.Add(this.lblRex);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.rtbTxt);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtTxt);
            this.Controls.Add(this.txtXlsx);
            this.Controls.Add(this.lblTxt);
            this.Controls.Add(this.lblXlsx);
            this.Controls.Add(this.btnPickTxt);
            this.Controls.Add(this.btnPickXlsx);
            this.Controls.Add(this.rtbLog);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmELDA";
            this.Text = "ELDA - Abrechnung für nässende Inkontinenzprodukte";
            ((System.ComponentModel.ISupportInitialize)(this.txtXlsx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private Infragistics.Win.Misc.UltraButton btnPickXlsx;
        private Infragistics.Win.Misc.UltraButton btnPickTxt;
        private Infragistics.Win.Misc.UltraLabel lblXlsx;
        private Infragistics.Win.Misc.UltraLabel lblTxt;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtXlsx;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTxt;
        private Infragistics.Win.Misc.UltraButton btnStart;
        private System.Windows.Forms.RichTextBox rtbTxt;
        private Infragistics.Win.Misc.UltraLabel lblLog;
        private Infragistics.Win.Misc.UltraLabel lblRex;
    }
}