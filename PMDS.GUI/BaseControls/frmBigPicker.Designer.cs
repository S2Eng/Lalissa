namespace PMDS.GUI.BaseControls
{
    partial class frmBigPicker
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBigPicker));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.lblHeader = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCancel = new QS2.Desktop.ControlManagment.BaseButton();
            this.lbSearch = new System.Windows.Forms.ListBox();
            this.dv = new System.Data.DataView();
            this.tbSearch = new PMDS.GUI.BaseControls.ucBigTextEditor();
            this.ucVKeyboardUniversal1 = new PMDS.GUI.BaseControls.ucVKeyboardUniversal();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            appearance1.BackColor = System.Drawing.Color.SlateGray;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblHeader.Appearance = appearance1;
            this.lblHeader.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblHeader.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ImageSize = new System.Drawing.Size(50, 50);
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(989, 63);
            this.lblHeader.TabIndex = 5;
            this.lblHeader.Text = " ****";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ImageSize = new System.Drawing.Size(40, 40);
            this.btnOK.ImageTransparentColor = System.Drawing.Color.White;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(750, 390);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(234, 220);
            this.btnOK.TabIndex = 2;
            this.btnOK.Tag = "OK";
            this.btnOK.Text = "Maßnahme auswählen";
            this.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOK.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            this.btnCancel.Appearance = appearance3;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.IsStandardControl = false;
            this.btnCancel.Location = new System.Drawing.Point(750, 615);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(234, 51);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Abbrechen";
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSearch.DataSource = this.dv;
            this.lbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.HorizontalExtent = 5000;
            this.lbSearch.HorizontalScrollbar = true;
            this.lbSearch.IntegralHeight = false;
            this.lbSearch.ItemHeight = 33;
            this.lbSearch.Location = new System.Drawing.Point(6, 130);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(976, 251);
            this.lbSearch.TabIndex = 1;
            this.lbSearch.DoubleClick += new System.EventHandler(this.lbSearch_DoubleClick);
            // 
            // dv
            // 
            this.dv.AllowDelete = false;
            this.dv.AllowEdit = false;
            this.dv.AllowNew = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(6, 69);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(976, 54);
            this.tbSearch.TabIndex = 0;
            // 
            // ucVKeyboardUniversal1
            // 
            this.ucVKeyboardUniversal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucVKeyboardUniversal1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucVKeyboardUniversal1.Location = new System.Drawing.Point(3, 388);
            this.ucVKeyboardUniversal1.Name = "ucVKeyboardUniversal1";
            this.ucVKeyboardUniversal1.Size = new System.Drawing.Size(922, 283);
            this.ucVKeyboardUniversal1.TabIndex = 4;
            // 
            // frmBigPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(989, 676);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucVKeyboardUniversal1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBigPicker";
            this.Text = "Maßnahme suchen";
            this.Load += new System.EventHandler(this.frmBigPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblHeader;
        private QS2.Desktop.ControlManagment.BaseButton btnOK;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel;
        private System.Windows.Forms.ListBox lbSearch;
        private ucBigTextEditor tbSearch;
        private System.Data.DataView dv;
        private ucVKeyboardUniversal ucVKeyboardUniversal1;
    }
}