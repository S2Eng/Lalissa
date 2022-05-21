namespace PMDS.GUI
{
    partial class frmAerzteEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAerzteEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.ucArztEdit1 = new PMDS.GUI.ucArztEdit();
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.btnKlientenMehrfachauswahl = new QS2.Desktop.ControlManagment.BaseButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(872, 518);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucArztEdit1
            // 
            this.ucArztEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucArztEdit1.CanModify = true;
            this.ucArztEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucArztEdit1.Location = new System.Drawing.Point(3, 2);
            this.ucArztEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.ucArztEdit1.Name = "ucArztEdit1";
            this.ucArztEdit1.ShowAuswahlColumn = false;
            this.ucArztEdit1.Size = new System.Drawing.Size(1077, 508);
            this.ucArztEdit1.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOk.Appearance = appearance2;
            this.btnOk.AutoWorkLayout = false;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DoOnClick = true;
            this.btnOk.IsStandardControl = true;
            this.btnOk.Location = new System.Drawing.Point(991, 518);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 39);
            this.btnOk.TabIndex = 5;
            this.btnOk.TabStop = false;
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOk.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnKlientenMehrfachauswahl
            // 
            this.btnKlientenMehrfachauswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnKlientenMehrfachauswahl.Appearance = appearance3;
            this.btnKlientenMehrfachauswahl.AutoWorkLayout = false;
            this.btnKlientenMehrfachauswahl.IsStandardControl = false;
            this.btnKlientenMehrfachauswahl.Location = new System.Drawing.Point(669, 518);
            this.btnKlientenMehrfachauswahl.Name = "btnKlientenMehrfachauswahl";
            this.btnKlientenMehrfachauswahl.Size = new System.Drawing.Size(150, 38);
            this.btnKlientenMehrfachauswahl.TabIndex = 6;
            this.btnKlientenMehrfachauswahl.Text = "Klienten Mehrfachauswahl";
            this.btnKlientenMehrfachauswahl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnKlientenMehrfachauswahl.Click += new System.EventHandler(this.btnKlientenMehrfachauswahl_Click);
            // 
            // frmAerzteEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1083, 562);
            this.Controls.Add(this.btnKlientenMehrfachauswahl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ucArztEdit1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1088, 595);
            this.Name = "frmAerzteEdit";
            this.Text = "Ärzte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAerzteEdit_FormClosing);
            this.Load += new System.EventHandler(this.frmAerzteEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucArztEdit ucArztEdit1;
        private ucButton btnCancel;
        private ucButton btnOk;
        public QS2.Desktop.ControlManagment.BaseButton btnKlientenMehrfachauswahl;
    }
}