namespace PMDS.GUI.BaseControls
{
    partial class frmUsers
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.panelBottom = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAbort2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelCenter = new QS2.Desktop.ControlManagment.BasePanel();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPassword = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnAbort2);
            this.panelBottom.Controls.Add(this.btnOK2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 65);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(356, 34);
            this.panelBottom.TabIndex = 1;
            // 
            // btnAbort2
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort2.Appearance = appearance1;
            this.btnAbort2.AutoWorkLayout = false;
            this.btnAbort2.IsStandardControl = false;
            this.btnAbort2.Location = new System.Drawing.Point(171, 3);
            this.btnAbort2.Name = "btnAbort2";
            this.btnAbort2.Size = new System.Drawing.Size(73, 27);
            this.btnAbort2.TabIndex = 11;
            this.btnAbort2.Text = "Abbrechen";
            this.btnAbort2.Click += new System.EventHandler(this.btnAbort2_Click);
            // 
            // btnOK2
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK2.Appearance = appearance2;
            this.btnOK2.AutoWorkLayout = false;
            this.btnOK2.IsStandardControl = false;
            this.btnOK2.Location = new System.Drawing.Point(119, 3);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(51, 27);
            this.btnOK2.TabIndex = 10;
            this.btnOK2.Text = "OK";
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.Controls.Add(this.baseLabel1);
            this.panelCenter.Controls.Add(this.txtPassword);
            this.panelCenter.Controls.Add(this.ultraLabel1);
            this.panelCenter.Controls.Add(this.cbBenutzer);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(356, 65);
            this.panelCenter.TabIndex = 2;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Location = new System.Drawing.Point(9, 40);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(51, 14);
            this.baseLabel1.TabIndex = 226;
            this.baseLabel1.Text = "Passwort";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(76, 37);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(273, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(9, 15);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(50, 14);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "Benutzer";
            // 
            // cbBenutzer
            // 
            this.cbBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBenutzer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbBenutzer.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cbBenutzer.Location = new System.Drawing.Point(76, 12);
            this.cbBenutzer.Name = "cbBenutzer";
            this.cbBenutzer.Size = new System.Drawing.Size(273, 21);
            this.cbBenutzer.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 99);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsers";
            this.Text = "Auswahl Benutzer";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelBottom;
        private QS2.Desktop.ControlManagment.BasePanel panelCenter;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        public QS2.Desktop.ControlManagment.BaseComboEditor cbBenutzer;
        private QS2.Desktop.ControlManagment.BaseButton btnAbort2;
        private QS2.Desktop.ControlManagment.BaseButton btnOK2;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtPassword;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
    }
}