namespace PMDS.GUI.GUI.Main
{
    partial class frmTextbausteinAdd
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
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtKurzbezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKurzbezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.auswahlGruppeComboMulti1 = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.lblWichtigFürCC = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelBeschreibungTXTEditor = new System.Windows.Forms.Panel();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtKurzbezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(335, 521);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 25);
            this.btnOK.TabIndex = 103;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance2;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(401, 521);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(74, 25);
            this.btnAbort.TabIndex = 104;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // txtKurzbezeichnung
            // 
            this.txtKurzbezeichnung.Location = new System.Drawing.Point(110, 11);
            this.txtKurzbezeichnung.Name = "txtKurzbezeichnung";
            this.txtKurzbezeichnung.Size = new System.Drawing.Size(535, 21);
            this.txtKurzbezeichnung.TabIndex = 113;
            // 
            // lblKurzbezeichnung
            // 
            this.lblKurzbezeichnung.Location = new System.Drawing.Point(8, 14);
            this.lblKurzbezeichnung.Name = "lblKurzbezeichnung";
            this.lblKurzbezeichnung.Size = new System.Drawing.Size(133, 15);
            this.lblKurzbezeichnung.TabIndex = 114;
            this.lblKurzbezeichnung.Text = "Kurzbezeichnung";
            // 
            // auswahlGruppeComboMulti1
            // 
            this.auswahlGruppeComboMulti1.BackColor = System.Drawing.Color.Transparent;
            this.auswahlGruppeComboMulti1.Location = new System.Drawing.Point(110, 36);
            this.auswahlGruppeComboMulti1.Margin = new System.Windows.Forms.Padding(4);
            this.auswahlGruppeComboMulti1.Name = "auswahlGruppeComboMulti1";
            this.auswahlGruppeComboMulti1.Size = new System.Drawing.Size(535, 28);
            this.auswahlGruppeComboMulti1.TabIndex = 115;
            this.auswahlGruppeComboMulti1.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            // 
            // lblWichtigFürCC
            // 
            this.lblWichtigFürCC.AutoSize = true;
            this.lblWichtigFürCC.Location = new System.Drawing.Point(8, 41);
            this.lblWichtigFürCC.Margin = new System.Windows.Forms.Padding(4);
            this.lblWichtigFürCC.Name = "lblWichtigFürCC";
            this.lblWichtigFürCC.Size = new System.Drawing.Size(78, 14);
            this.lblWichtigFürCC.TabIndex = 116;
            this.lblWichtigFürCC.Text = "Berufsgruppen";
            // 
            // panelBeschreibungTXTEditor
            // 
            this.panelBeschreibungTXTEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBeschreibungTXTEditor.BackColor = System.Drawing.Color.Transparent;
            this.panelBeschreibungTXTEditor.Location = new System.Drawing.Point(8, 67);
            this.panelBeschreibungTXTEditor.Margin = new System.Windows.Forms.Padding(4);
            this.panelBeschreibungTXTEditor.Name = "panelBeschreibungTXTEditor";
            this.panelBeschreibungTXTEditor.Size = new System.Drawing.Size(802, 448);
            this.panelBeschreibungTXTEditor.TabIndex = 117;
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTextbausteinAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 550);
            this.Controls.Add(this.panelBeschreibungTXTEditor);
            this.Controls.Add(this.auswahlGruppeComboMulti1);
            this.Controls.Add(this.lblWichtigFürCC);
            this.Controls.Add(this.txtKurzbezeichnung);
            this.Controls.Add(this.lblKurzbezeichnung);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Name = "frmTextbausteinAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Textbaustein hinzufügen";
            this.Load += new System.EventHandler(this.frmTextbausteinAdd_Load);
            this.VisibleChanged += new System.EventHandler(this.frmTextbausteinAdd_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtKurzbezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtKurzbezeichnung;
        private QS2.Desktop.ControlManagment.BaseLabel lblKurzbezeichnung;
        public BaseControls.AuswahlGruppeComboMulti auswahlGruppeComboMulti1;
        public QS2.Desktop.ControlManagment.BaseLabel lblWichtigFürCC;
        protected System.Windows.Forms.Panel panelBeschreibungTXTEditor;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
    }
}