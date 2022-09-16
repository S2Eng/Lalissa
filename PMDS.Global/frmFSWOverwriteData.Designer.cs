namespace PMDS.Global
{
    partial class frmFSWOverwriteData
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblInfoText = new QS2.Desktop.ControlManagment.BaseLabel();
            this.numdPflegeNettoSoll = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.numdBWNettoSoll = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.btnCancel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblPflegeNetto = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBWNetto = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBerechnet = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblSoll = new QS2.Desktop.ControlManagment.BaseLabel();
            this.numdPflegeErrechnet = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.numdBWErrechnet = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.numdNettoGesamtErrechnet = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.numdNettoGesamtSoll = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblDays = new QS2.Desktop.ControlManagment.BaseLabel();
            this.numiDays = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.numiBWDays = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblSavedData = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numdPflegeNettoSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdBWNettoSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdPflegeErrechnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdBWErrechnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdNettoGesamtErrechnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdNettoGesamtSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numiDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numiBWDays)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfoText
            // 
            this.lblInfoText.Location = new System.Drawing.Point(13, 26);
            this.lblInfoText.Margin = new System.Windows.Forms.Padding(4);
            this.lblInfoText.Name = "lblInfoText";
            this.lblInfoText.Size = new System.Drawing.Size(780, 114);
            this.lblInfoText.TabIndex = 0;
            this.lblInfoText.Text = "Es wurde eine Abweichung erkannt, die nicht automatisch behoben werden kann.";
            // 
            // numdPflegeNettoSoll
            // 
            this.numdPflegeNettoSoll.FormatString = "###,##0.00 €";
            this.numdPflegeNettoSoll.Location = new System.Drawing.Point(459, 210);
            this.numdPflegeNettoSoll.Margin = new System.Windows.Forms.Padding(4);
            this.numdPflegeNettoSoll.Name = "numdPflegeNettoSoll";
            this.numdPflegeNettoSoll.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.numdPflegeNettoSoll.Size = new System.Drawing.Size(86, 26);
            this.numdPflegeNettoSoll.TabIndex = 0;
            this.numdPflegeNettoSoll.ValueChanged += new System.EventHandler(this.numdPflegeNettoSoll_ValueChanged);
            // 
            // numdBWNettoSoll
            // 
            this.numdBWNettoSoll.FormatString = "###,##0.00 €";
            this.numdBWNettoSoll.Location = new System.Drawing.Point(459, 244);
            this.numdBWNettoSoll.Margin = new System.Windows.Forms.Padding(4);
            this.numdBWNettoSoll.Name = "numdBWNettoSoll";
            this.numdBWNettoSoll.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.numdBWNettoSoll.Size = new System.Drawing.Size(86, 26);
            this.numdBWNettoSoll.TabIndex = 2;
            this.numdBWNettoSoll.ValueChanged += new System.EventHandler(this.numdBWNettoSoll_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsStandardControl = false;
            this.btnCancel.Location = new System.Drawing.Point(459, 358);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(566, 358);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPflegeNetto
            // 
            this.lblPflegeNetto.Location = new System.Drawing.Point(13, 210);
            this.lblPflegeNetto.Margin = new System.Windows.Forms.Padding(4);
            this.lblPflegeNetto.Name = "lblPflegeNetto";
            this.lblPflegeNetto.Size = new System.Drawing.Size(278, 30);
            this.lblPflegeNetto.TabIndex = 6;
            this.lblPflegeNetto.Text = "Nettobetrag für Pflegeleistungen für FSW";
            // 
            // lblBWNetto
            // 
            this.lblBWNetto.Location = new System.Drawing.Point(13, 248);
            this.lblBWNetto.Margin = new System.Windows.Forms.Padding(4);
            this.lblBWNetto.Name = "lblBWNetto";
            this.lblBWNetto.Size = new System.Drawing.Size(274, 30);
            this.lblBWNetto.TabIndex = 7;
            this.lblBWNetto.Text = "Nettobetrag für Betreutes Wohnen für FSW";
            // 
            // lblBerechnet
            // 
            this.lblBerechnet.Location = new System.Drawing.Point(347, 181);
            this.lblBerechnet.Margin = new System.Windows.Forms.Padding(4);
            this.lblBerechnet.Name = "lblBerechnet";
            this.lblBerechnet.Size = new System.Drawing.Size(86, 21);
            this.lblBerechnet.TabIndex = 8;
            this.lblBerechnet.Text = "Berechnet";
            // 
            // lblSoll
            // 
            this.lblSoll.Location = new System.Drawing.Point(459, 181);
            this.lblSoll.Margin = new System.Windows.Forms.Padding(4);
            this.lblSoll.Name = "lblSoll";
            this.lblSoll.Size = new System.Drawing.Size(97, 21);
            this.lblSoll.TabIndex = 9;
            this.lblSoll.Text = "zu verrechnen";
            // 
            // numdPflegeErrechnet
            // 
            this.numdPflegeErrechnet.Enabled = false;
            this.numdPflegeErrechnet.FormatString = "###,##0.00 €";
            this.numdPflegeErrechnet.Location = new System.Drawing.Point(347, 210);
            this.numdPflegeErrechnet.Margin = new System.Windows.Forms.Padding(4);
            this.numdPflegeErrechnet.Name = "numdPflegeErrechnet";
            this.numdPflegeErrechnet.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.numdPflegeErrechnet.Size = new System.Drawing.Size(86, 26);
            this.numdPflegeErrechnet.TabIndex = 10;
            // 
            // numdBWErrechnet
            // 
            this.numdBWErrechnet.Enabled = false;
            this.numdBWErrechnet.FormatString = "###,##0.00 €";
            this.numdBWErrechnet.Location = new System.Drawing.Point(347, 244);
            this.numdBWErrechnet.Margin = new System.Windows.Forms.Padding(4);
            this.numdBWErrechnet.Name = "numdBWErrechnet";
            this.numdBWErrechnet.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.numdBWErrechnet.Size = new System.Drawing.Size(86, 26);
            this.numdBWErrechnet.TabIndex = 11;
            // 
            // numdNettoGesamtErrechnet
            // 
            this.numdNettoGesamtErrechnet.Enabled = false;
            this.numdNettoGesamtErrechnet.FormatString = "###,##0.00 €";
            this.numdNettoGesamtErrechnet.Location = new System.Drawing.Point(348, 282);
            this.numdNettoGesamtErrechnet.Margin = new System.Windows.Forms.Padding(4);
            this.numdNettoGesamtErrechnet.Name = "numdNettoGesamtErrechnet";
            this.numdNettoGesamtErrechnet.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.numdNettoGesamtErrechnet.Size = new System.Drawing.Size(86, 26);
            this.numdNettoGesamtErrechnet.TabIndex = 12;
            // 
            // baseLabel1
            // 
            this.baseLabel1.Location = new System.Drawing.Point(13, 287);
            this.baseLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(274, 23);
            this.baseLabel1.TabIndex = 13;
            this.baseLabel1.Text = "Nettobetrag für FSW gesamt";
            // 
            // numdNettoGesamtSoll
            // 
            this.numdNettoGesamtSoll.Enabled = false;
            this.numdNettoGesamtSoll.FormatString = "###,##0.00 €";
            this.numdNettoGesamtSoll.Location = new System.Drawing.Point(459, 282);
            this.numdNettoGesamtSoll.Margin = new System.Windows.Forms.Padding(4);
            this.numdNettoGesamtSoll.Name = "numdNettoGesamtSoll";
            this.numdNettoGesamtSoll.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.numdNettoGesamtSoll.Size = new System.Drawing.Size(86, 26);
            this.numdNettoGesamtSoll.TabIndex = 5;
            // 
            // lblDays
            // 
            this.lblDays.Location = new System.Drawing.Point(564, 179);
            this.lblDays.Margin = new System.Windows.Forms.Padding(4);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(88, 23);
            this.lblDays.TabIndex = 15;
            this.lblDays.Text = "Anzahl Tage";
            // 
            // numiDays
            // 
            this.numiDays.FormatString = "#0";
            this.numiDays.Location = new System.Drawing.Point(566, 210);
            this.numiDays.Margin = new System.Windows.Forms.Padding(4);
            this.numiDays.Name = "numiDays";
            this.numiDays.Size = new System.Drawing.Size(86, 26);
            this.numiDays.TabIndex = 1;
            this.numiDays.ValueChanged += new System.EventHandler(this.numiDays_ValueChanged);
            // 
            // numiBWDays
            // 
            this.numiBWDays.FormatString = "#0";
            this.numiBWDays.Location = new System.Drawing.Point(566, 244);
            this.numiBWDays.Margin = new System.Windows.Forms.Padding(4);
            this.numiBWDays.Name = "numiBWDays";
            this.numiBWDays.Size = new System.Drawing.Size(86, 26);
            this.numiBWDays.TabIndex = 3;
            this.numiBWDays.ValueChanged += new System.EventHandler(this.numiBWDays_ValueChanged);
            // 
            // lblSavedData
            // 
            appearance1.ForeColor = System.Drawing.Color.Red;
            this.lblSavedData.Appearance = appearance1;
            this.lblSavedData.Location = new System.Drawing.Point(459, 150);
            this.lblSavedData.Margin = new System.Windows.Forms.Padding(4);
            this.lblSavedData.Name = "lblSavedData";
            this.lblSavedData.Size = new System.Drawing.Size(334, 23);
            this.lblSavedData.TabIndex = 17;
            this.lblSavedData.Text = "Gespeicherte Daten von ";
            this.lblSavedData.UseAppStyling = false;
            this.lblSavedData.Visible = false;
            // 
            // frmFSWOverwriteData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 401);
            this.Controls.Add(this.lblSavedData);
            this.Controls.Add(this.numiBWDays);
            this.Controls.Add(this.numiDays);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.numdNettoGesamtSoll);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.numdNettoGesamtErrechnet);
            this.Controls.Add(this.numdBWErrechnet);
            this.Controls.Add(this.numdPflegeErrechnet);
            this.Controls.Add(this.lblSoll);
            this.Controls.Add(this.lblBerechnet);
            this.Controls.Add(this.lblBWNetto);
            this.Controls.Add(this.lblPflegeNetto);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numdBWNettoSoll);
            this.Controls.Add(this.numdPflegeNettoSoll);
            this.Controls.Add(this.lblInfoText);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFSWOverwriteData";
            this.Text = "frmFSWOverwriteData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFSWOverwriteData_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numdPflegeNettoSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdBWNettoSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdPflegeErrechnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdBWErrechnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdNettoGesamtErrechnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdNettoGesamtSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numiDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numiBWDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblInfoText;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numdPflegeNettoSoll;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numdBWNettoSoll;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegeNetto;
        private QS2.Desktop.ControlManagment.BaseLabel lblBWNetto;
        private QS2.Desktop.ControlManagment.BaseLabel lblBerechnet;
        private QS2.Desktop.ControlManagment.BaseLabel lblSoll;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numdPflegeErrechnet;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numdBWErrechnet;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numdNettoGesamtErrechnet;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numdNettoGesamtSoll;
        private QS2.Desktop.ControlManagment.BaseLabel lblDays;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numiDays;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numiBWDays;
        private QS2.Desktop.ControlManagment.BaseLabel lblSavedData;
    }
}