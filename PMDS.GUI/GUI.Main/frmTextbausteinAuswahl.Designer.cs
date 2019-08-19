namespace PMDS.GUI.GUI.Main
{
    partial class frmTextbausteinAuswahl
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.cboTextbausteine = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblTextbausteine = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            this.textControlConvert = new TXTextControl.TextControl();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            ((System.ComponentModel.ISupportInitialize)(this.cboTextbausteine)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTextbausteine
            // 
            this.cboTextbausteine.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cboTextbausteine.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
            this.cboTextbausteine.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboTextbausteine.Location = new System.Drawing.Point(101, 17);
            this.cboTextbausteine.Name = "cboTextbausteine";
            this.cboTextbausteine.NullText = "Bitte wählen";
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.cboTextbausteine.NullTextAppearance = appearance1;
            this.cboTextbausteine.Size = new System.Drawing.Size(382, 21);
            this.cboTextbausteine.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cboTextbausteine.TabIndex = 98;
            this.cboTextbausteine.ValueChanged += new System.EventHandler(this.cboTextbausteine_ValueChanged);
            // 
            // lblTextbausteine
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblTextbausteine.Appearance = appearance2;
            this.lblTextbausteine.AutoSize = true;
            this.lblTextbausteine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextbausteine.Location = new System.Drawing.Point(11, 19);
            this.lblTextbausteine.Name = "lblTextbausteine";
            this.lblTextbausteine.Size = new System.Drawing.Size(89, 17);
            this.lblTextbausteine.TabIndex = 99;
            this.lblTextbausteine.Text = "Textbausteine";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance3;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(413, 41);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(70, 23);
            this.btnAbort.TabIndex = 105;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // textControlConvert
            // 
            this.textControlConvert.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlConvert.Location = new System.Drawing.Point(273, 94);
            this.textControlConvert.Margin = new System.Windows.Forms.Padding(4);
            this.textControlConvert.Name = "textControlConvert";
            this.textControlConvert.Size = new System.Drawing.Size(61, 43);
            this.textControlConvert.TabIndex = 106;
            this.textControlConvert.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // frmTextbausteinAuswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 67);
            this.Controls.Add(this.textControlConvert);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.cboTextbausteine);
            this.Controls.Add(this.lblTextbausteine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextbausteinAuswahl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Textbaustein wählen";
            this.Load += new System.EventHandler(this.frmTextbausteinAuswahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTextbausteine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboTextbausteine;
        private QS2.Desktop.ControlManagment.BaseLabel lblTextbausteine;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        private TXTextControl.TextControl textControlConvert;
    }
}