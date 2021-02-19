namespace PMDS.GUI.BaseControls
{
    partial class frmTextVerschluesseln
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextVerschluesseln));
            this.ultraPanelMain = new Infragistics.Win.Misc.UltraPanel();
            this.pnlControls = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblDBLizenz = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblLic = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnLoadLicense = new Infragistics.Win.Misc.UltraButton();
            this.dtValidThrough = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.txtPassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnCopyToClipboard = new Infragistics.Win.Misc.UltraButton();
            this.txtVerschluesselterText = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtKlartext = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblVerschlüsselterText = new Infragistics.Win.Misc.UltraLabel();
            this.lblKlartext = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanelMain.ClientArea.SuspendLayout();
            this.ultraPanelMain.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidThrough)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerschluesselterText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlartext)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPanelMain
            // 
            // 
            // ultraPanelMain.ClientArea
            // 
            this.ultraPanelMain.ClientArea.Controls.Add(this.pnlControls);
            this.ultraPanelMain.ClientArea.Controls.Add(this.txtPassword);
            this.ultraPanelMain.ClientArea.Controls.Add(this.btnCopyToClipboard);
            this.ultraPanelMain.ClientArea.Controls.Add(this.txtVerschluesselterText);
            this.ultraPanelMain.ClientArea.Controls.Add(this.txtKlartext);
            this.ultraPanelMain.ClientArea.Controls.Add(this.lblVerschlüsselterText);
            this.ultraPanelMain.ClientArea.Controls.Add(this.lblKlartext);
            this.ultraPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanelMain.Location = new System.Drawing.Point(0, 0);
            this.ultraPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.ultraPanelMain.Name = "ultraPanelMain";
            this.ultraPanelMain.Size = new System.Drawing.Size(827, 499);
            this.ultraPanelMain.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControls.Controls.Add(this.lblDBLizenz);
            this.pnlControls.Controls.Add(this.lblLic);
            this.pnlControls.Controls.Add(this.btnLoadLicense);
            this.pnlControls.Controls.Add(this.dtValidThrough);
            this.pnlControls.Location = new System.Drawing.Point(210, 410);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(293, 81);
            this.pnlControls.TabIndex = 9;
            this.pnlControls.Visible = false;
            // 
            // lblDBLizenz
            // 
            this.lblDBLizenz.Location = new System.Drawing.Point(15, 54);
            this.lblDBLizenz.Name = "lblDBLizenz";
            this.lblDBLizenz.Size = new System.Drawing.Size(134, 20);
            this.lblDBLizenz.TabIndex = 10;
            this.lblDBLizenz.Text = "Liz. für DBLizenz";
            // 
            // lblLic
            // 
            this.lblLic.Location = new System.Drawing.Point(12, 10);
            this.lblLic.Name = "lblLic";
            this.lblLic.Size = new System.Drawing.Size(138, 27);
            this.lblLic.TabIndex = 9;
            this.lblLic.Text = "Lic für Config";
            this.lblLic.Click += new System.EventHandler(this.BaseLabel1_Click);
            // 
            // btnLoadLicense
            // 
            this.btnLoadLicense.Location = new System.Drawing.Point(164, 4);
            this.btnLoadLicense.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadLicense.Name = "btnLoadLicense";
            this.btnLoadLicense.Size = new System.Drawing.Size(116, 38);
            this.btnLoadLicense.TabIndex = 5;
            this.btnLoadLicense.Text = "Lizenz anzeigen";
            this.btnLoadLicense.Click += new System.EventHandler(this.btnLoadLicense_Click);
            // 
            // dtValidThrough
            // 
            this.dtValidThrough.Location = new System.Drawing.Point(164, 51);
            this.dtValidThrough.Name = "dtValidThrough";
            this.dtValidThrough.ownFormat = "";
            this.dtValidThrough.ownMaskInput = "";
            this.dtValidThrough.Size = new System.Drawing.Size(116, 24);
            this.dtValidThrough.TabIndex = 8;
            this.dtValidThrough.Leave += new System.EventHandler(this.DtValidThrough_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPassword.Location = new System.Drawing.Point(13, 452);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(163, 24);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Visible = false;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToClipboard.Location = new System.Drawing.Point(562, 447);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(252, 38);
            this.btnCopyToClipboard.TabIndex = 4;
            this.btnCopyToClipboard.Text = "In die Zwischenablage kopieren";
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            this.btnCopyToClipboard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnCopyToClipboard_KeyUp);
            // 
            // txtVerschluesselterText
            // 
            this.txtVerschluesselterText.AcceptsReturn = true;
            this.txtVerschluesselterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerschluesselterText.Enabled = false;
            this.txtVerschluesselterText.Location = new System.Drawing.Point(13, 240);
            this.txtVerschluesselterText.Margin = new System.Windows.Forms.Padding(4);
            this.txtVerschluesselterText.Multiline = true;
            this.txtVerschluesselterText.Name = "txtVerschluesselterText";
            this.txtVerschluesselterText.Size = new System.Drawing.Size(801, 163);
            this.txtVerschluesselterText.TabIndex = 3;
            // 
            // txtKlartext
            // 
            this.txtKlartext.AcceptsReturn = true;
            this.txtKlartext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKlartext.Location = new System.Drawing.Point(13, 33);
            this.txtKlartext.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlartext.Multiline = true;
            this.txtKlartext.Name = "txtKlartext";
            this.txtKlartext.Size = new System.Drawing.Size(801, 172);
            this.txtKlartext.TabIndex = 2;
            this.txtKlartext.ValueChanged += new System.EventHandler(this.txtKlartext_ValueChanged);
            this.txtKlartext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKlartext_KeyUp);
            // 
            // lblVerschlüsselterText
            // 
            this.lblVerschlüsselterText.Location = new System.Drawing.Point(13, 213);
            this.lblVerschlüsselterText.Margin = new System.Windows.Forms.Padding(4);
            this.lblVerschlüsselterText.Name = "lblVerschlüsselterText";
            this.lblVerschlüsselterText.Size = new System.Drawing.Size(156, 19);
            this.lblVerschlüsselterText.TabIndex = 1;
            this.lblVerschlüsselterText.Text = "Verschlüsselter Text";
            // 
            // lblKlartext
            // 
            this.lblKlartext.Location = new System.Drawing.Point(13, 12);
            this.lblKlartext.Margin = new System.Windows.Forms.Padding(4);
            this.lblKlartext.Name = "lblKlartext";
            this.lblKlartext.Size = new System.Drawing.Size(151, 21);
            this.lblKlartext.TabIndex = 0;
            this.lblKlartext.Text = "Klartext";
            this.lblKlartext.Click += new System.EventHandler(this.lblKlartext_Click);
            // 
            // frmTextVerschluesseln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 499);
            this.Controls.Add(this.ultraPanelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextVerschluesseln";
            this.Text = "Text verschlüsseln";
            this.Load += new System.EventHandler(this.frmTextVerschluesseln_Load);
            this.ultraPanelMain.ClientArea.ResumeLayout(false);
            this.ultraPanelMain.ClientArea.PerformLayout();
            this.ultraPanelMain.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidThrough)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerschluesselterText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlartext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel ultraPanelMain;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtVerschluesselterText;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtKlartext;
        private Infragistics.Win.Misc.UltraLabel lblVerschlüsselterText;
        private Infragistics.Win.Misc.UltraLabel lblKlartext;
        private Infragistics.Win.Misc.UltraButton btnCopyToClipboard;
        private Infragistics.Win.Misc.UltraButton btnLoadLicense;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPassword;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtValidThrough;
        private QS2.Desktop.ControlManagment.BasePanel pnlControls;
        private QS2.Desktop.ControlManagment.BaseLabel lblLic;
        private QS2.Desktop.ControlManagment.BaseLabel lblDBLizenz;
    }
}