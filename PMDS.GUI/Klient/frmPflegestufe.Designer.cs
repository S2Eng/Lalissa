namespace PMDS.GUI
{
    partial class frmPflegestufe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPflegestufe));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.cmbBeantragtestufe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cmbPflgestufe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dtpBescheiddatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtpAntragsdatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtpGueltigAb = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBescheiddatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBeantragsstufe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAntragsdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGültigAb = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAkuelleStufe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpGueltigBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblGültigBis = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeantragtestufe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPflgestufe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBescheiddatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAntragsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGueltigAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGueltigBis)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(293, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 27);
            this.btnOK.TabIndex = 7;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(199, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 27);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbBeantragtestufe
            // 
            editorButton1.Text = "+";
            this.cmbBeantragtestufe.ButtonsRight.Add(editorButton1);
            this.cmbBeantragtestufe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbBeantragtestufe.Location = new System.Drawing.Point(167, 116);
            this.cmbBeantragtestufe.Name = "cmbBeantragtestufe";
            this.cmbBeantragtestufe.Size = new System.Drawing.Size(176, 21);
            this.cmbBeantragtestufe.TabIndex = 4;
            this.cmbBeantragtestufe.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cmbPflgestufe_EditorButtonClick);
            // 
            // cmbPflgestufe
            // 
            editorButton2.Text = "+";
            this.cmbPflgestufe.ButtonsRight.Add(editorButton2);
            this.cmbPflgestufe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbPflgestufe.Location = new System.Drawing.Point(167, 18);
            this.cmbPflgestufe.Name = "cmbPflgestufe";
            this.cmbPflgestufe.Size = new System.Drawing.Size(176, 21);
            this.cmbPflgestufe.TabIndex = 1;
            this.cmbPflgestufe.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cmbPflgestufe_EditorButtonClick);
            // 
            // dtpBescheiddatum
            // 
            this.dtpBescheiddatum.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpBescheiddatum.FormatString = "";
            this.dtpBescheiddatum.Location = new System.Drawing.Point(167, 140);
            this.dtpBescheiddatum.MaskInput = "";
            this.dtpBescheiddatum.Name = "dtpBescheiddatum";
            this.dtpBescheiddatum.Size = new System.Drawing.Size(176, 21);
            this.dtpBescheiddatum.TabIndex = 5;
            this.dtpBescheiddatum.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // dtpAntragsdatum
            // 
            this.dtpAntragsdatum.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpAntragsdatum.FormatString = "";
            this.dtpAntragsdatum.Location = new System.Drawing.Point(167, 92);
            this.dtpAntragsdatum.MaskInput = "";
            this.dtpAntragsdatum.Name = "dtpAntragsdatum";
            this.dtpAntragsdatum.Size = new System.Drawing.Size(176, 21);
            this.dtpAntragsdatum.TabIndex = 3;
            this.dtpAntragsdatum.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // dtpGueltigAb
            // 
            this.dtpGueltigAb.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpGueltigAb.FormatString = "";
            this.dtpGueltigAb.Location = new System.Drawing.Point(167, 42);
            this.dtpGueltigAb.MaskInput = "";
            this.dtpGueltigAb.Name = "dtpGueltigAb";
            this.dtpGueltigAb.Size = new System.Drawing.Size(176, 21);
            this.dtpGueltigAb.TabIndex = 2;
            this.dtpGueltigAb.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lblBescheiddatum
            // 
            this.lblBescheiddatum.AutoSize = true;
            this.lblBescheiddatum.Location = new System.Drawing.Point(12, 144);
            this.lblBescheiddatum.Name = "lblBescheiddatum";
            this.lblBescheiddatum.Size = new System.Drawing.Size(82, 14);
            this.lblBescheiddatum.TabIndex = 148;
            this.lblBescheiddatum.Text = "Bescheiddatum";
            // 
            // lblBeantragsstufe
            // 
            this.lblBeantragsstufe.AutoSize = true;
            this.lblBeantragsstufe.Location = new System.Drawing.Point(12, 119);
            this.lblBeantragsstufe.Name = "lblBeantragsstufe";
            this.lblBeantragsstufe.Size = new System.Drawing.Size(84, 14);
            this.lblBeantragsstufe.TabIndex = 147;
            this.lblBeantragsstufe.Text = "Beantragtestufe";
            // 
            // lblAntragsdatum
            // 
            this.lblAntragsdatum.AutoSize = true;
            this.lblAntragsdatum.Location = new System.Drawing.Point(12, 96);
            this.lblAntragsdatum.Name = "lblAntragsdatum";
            this.lblAntragsdatum.Size = new System.Drawing.Size(75, 14);
            this.lblAntragsdatum.TabIndex = 146;
            this.lblAntragsdatum.Text = "Antragsdatum";
            // 
            // lblGültigAb
            // 
            this.lblGültigAb.AutoSize = true;
            this.lblGültigAb.Location = new System.Drawing.Point(12, 46);
            this.lblGültigAb.Name = "lblGültigAb";
            this.lblGültigAb.Size = new System.Drawing.Size(50, 14);
            this.lblGültigAb.TabIndex = 145;
            this.lblGültigAb.Text = "Gültig ab";
            // 
            // lblAkuelleStufe
            // 
            this.lblAkuelleStufe.AutoSize = true;
            this.lblAkuelleStufe.Location = new System.Drawing.Point(12, 21);
            this.lblAkuelleStufe.Name = "lblAkuelleStufe";
            this.lblAkuelleStufe.Size = new System.Drawing.Size(74, 14);
            this.lblAkuelleStufe.TabIndex = 144;
            this.lblAkuelleStufe.Text = "Aktuelle Stufe";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtpGueltigBis
            // 
            this.dtpGueltigBis.DateTime = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            this.dtpGueltigBis.FormatString = "";
            this.dtpGueltigBis.Location = new System.Drawing.Point(167, 67);
            this.dtpGueltigBis.MaskInput = "";
            this.dtpGueltigBis.Name = "dtpGueltigBis";
            this.dtpGueltigBis.Size = new System.Drawing.Size(176, 21);
            this.dtpGueltigBis.TabIndex = 149;
            this.dtpGueltigBis.Value = new System.DateTime(2007, 1, 22, 0, 0, 0, 0);
            // 
            // lblGültigBis
            // 
            this.lblGültigBis.AutoSize = true;
            this.lblGültigBis.Location = new System.Drawing.Point(12, 71);
            this.lblGültigBis.Name = "lblGültigBis";
            this.lblGültigBis.Size = new System.Drawing.Size(51, 14);
            this.lblGültigBis.TabIndex = 150;
            this.lblGültigBis.Text = "Gültig bis";
            // 
            // frmPflegestufe
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 208);
            this.ControlBox = false;
            this.Controls.Add(this.dtpGueltigBis);
            this.Controls.Add(this.lblGültigBis);
            this.Controls.Add(this.cmbBeantragtestufe);
            this.Controls.Add(this.cmbPflgestufe);
            this.Controls.Add(this.dtpBescheiddatum);
            this.Controls.Add(this.dtpAntragsdatum);
            this.Controls.Add(this.dtpGueltigAb);
            this.Controls.Add(this.lblBescheiddatum);
            this.Controls.Add(this.lblBeantragsstufe);
            this.Controls.Add(this.lblAntragsdatum);
            this.Controls.Add(this.lblGültigAb);
            this.Controls.Add(this.lblAkuelleStufe);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(376, 247);
            this.MinimumSize = new System.Drawing.Size(376, 220);
            this.Name = "frmPflegestufe";
            this.Text = "Pflegestufe";
            this.Load += new System.EventHandler(this.frmPflegestufe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeantragtestufe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPflgestufe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBescheiddatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAntragsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGueltigAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGueltigBis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PMDS.GUI.ucButton btnOK;
        private PMDS.GUI.ucButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbBeantragtestufe;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbPflgestufe;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBescheiddatum;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpAntragsdatum;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpGueltigAb;
        private QS2.Desktop.ControlManagment.BaseLabel lblBescheiddatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeantragsstufe;
        private QS2.Desktop.ControlManagment.BaseLabel lblAntragsdatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblGültigAb;
        private QS2.Desktop.ControlManagment.BaseLabel lblAkuelleStufe;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpGueltigBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblGültigBis;
    }
}