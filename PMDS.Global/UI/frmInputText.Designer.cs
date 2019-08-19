namespace PMDS.GUI.BaseControls
{
    partial class frmInputText
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputText));
            this.lblDescription1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnApport = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtInput1 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelButtonsUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelText1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelText2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtInput2 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.lblDescription2 = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput1)).BeginInit();
            this.panelButtonsUnten.SuspendLayout();
            this.panelText1.SuspendLayout();
            this.panelText2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription1
            // 
            this.lblDescription1.Location = new System.Drawing.Point(9, 10);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(320, 15);
            this.lblDescription1.TabIndex = 0;
            this.lblDescription1.Text = "Bitte geben Sie ein:";
            // 
            // btnApport
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnApport.Appearance = appearance2;
            this.btnApport.Location = new System.Drawing.Point(425, 5);
            this.btnApport.Name = "btnApport";
            this.btnApport.Size = new System.Drawing.Size(69, 24);
            this.btnApport.TabIndex = 1;
            this.btnApport.Text = "Abbrechen";
            this.btnApport.Click += new System.EventHandler(this.btnApport_Click);
            // 
            // btnOK
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnOK.Appearance = appearance1;
            this.btnOK.Location = new System.Drawing.Point(356, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtInput1
            // 
            this.txtInput1.Location = new System.Drawing.Point(9, 27);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(485, 21);
            this.txtInput1.TabIndex = 0;
            // 
            // panelButtonsUnten
            // 
            this.panelButtonsUnten.Controls.Add(this.btnOK);
            this.panelButtonsUnten.Controls.Add(this.btnApport);
            this.panelButtonsUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonsUnten.Location = new System.Drawing.Point(0, 208);
            this.panelButtonsUnten.Name = "panelButtonsUnten";
            this.panelButtonsUnten.Size = new System.Drawing.Size(502, 36);
            this.panelButtonsUnten.TabIndex = 2;
            // 
            // panelText1
            // 
            this.panelText1.Controls.Add(this.txtInput1);
            this.panelText1.Controls.Add(this.lblDescription1);
            this.panelText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelText1.Location = new System.Drawing.Point(0, 0);
            this.panelText1.Name = "panelText1";
            this.panelText1.Size = new System.Drawing.Size(502, 54);
            this.panelText1.TabIndex = 0;
            // 
            // panelText2
            // 
            this.panelText2.Controls.Add(this.txtInput2);
            this.panelText2.Controls.Add(this.lblDescription2);
            this.panelText2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelText2.Location = new System.Drawing.Point(0, 54);
            this.panelText2.Name = "panelText2";
            this.panelText2.Size = new System.Drawing.Size(502, 154);
            this.panelText2.TabIndex = 1;
            // 
            // txtInput2
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            appearance4.FontData.SizeInPoints = 8F;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtInput2.Appearance = appearance4;
            this.txtInput2.Location = new System.Drawing.Point(9, 17);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(485, 131);
            this.txtInput2.TabIndex = 1;
            this.txtInput2.Value = "";
            // 
            // lblDescription2
            // 
            this.lblDescription2.Location = new System.Drawing.Point(9, 3);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(320, 15);
            this.lblDescription2.TabIndex = 4;
            this.lblDescription2.Text = "Bitte geben Sie ein:";
            // 
            // frmInputText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(502, 244);
            this.Controls.Add(this.panelText2);
            this.Controls.Add(this.panelText1);
            this.Controls.Add(this.panelButtonsUnten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eingabe";
            this.Load += new System.EventHandler(this.frmInputText_Load);
            this.Activated += new System.EventHandler(this.frmInputText_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.txtInput1)).EndInit();
            this.panelButtonsUnten.ResumeLayout(false);
            this.panelText1.ResumeLayout(false);
            this.panelText1.PerformLayout();
            this.panelText2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblDescription1;
        private QS2.Desktop.ControlManagment.BaseButton btnApport;
        private QS2.Desktop.ControlManagment.BaseButton btnOK;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtInput1;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelText1;
        private QS2.Desktop.ControlManagment.BasePanel panelText2;
        private QS2.Desktop.ControlManagment.BaseLabel lblDescription2;
        public Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtInput2;
    }
}