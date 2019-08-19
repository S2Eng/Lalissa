namespace PMDS.Calc.UI
{
    partial class frmNewBooking
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewBooking));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBuchText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBuchText = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnApport = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.dtpBuchungsdatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBuchungsdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBetrag = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBetrag = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.panelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuchText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuchungsdatum)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.panelAll);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(419, 186);
            this.ultraGridBagLayoutPanel1.TabIndex = 0;
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAll.Controls.Add(this.lblInfo);
            this.panelAll.Controls.Add(this.txtBuchText);
            this.panelAll.Controls.Add(this.lblBuchText);
            this.panelAll.Controls.Add(this.btnApport);
            this.panelAll.Controls.Add(this.btnSave);
            this.panelAll.Controls.Add(this.dtpBuchungsdatum);
            this.panelAll.Controls.Add(this.lblBuchungsdatum);
            this.panelAll.Controls.Add(this.lblBetrag);
            this.panelAll.Controls.Add(this.tbBetrag);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.panelAll, gridBagConstraint1);
            this.panelAll.Location = new System.Drawing.Point(5, 5);
            this.panelAll.Name = "panelAll";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.panelAll, new System.Drawing.Size(200, 100));
            this.panelAll.Size = new System.Drawing.Size(409, 176);
            this.panelAll.TabIndex = 0;
            // 
            // lblInfo
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Appearance = appearance1;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(113, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(157, 14);
            this.lblInfo.TabIndex = 164;
            this.lblInfo.Text = "Buchung auf Konto Zahlungen";
            // 
            // txtBuchText
            // 
            this.txtBuchText.Location = new System.Drawing.Point(113, 72);
            this.txtBuchText.Name = "txtBuchText";
            this.txtBuchText.Size = new System.Drawing.Size(274, 21);
            this.txtBuchText.TabIndex = 1;
            // 
            // lblBuchText
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblBuchText.Appearance = appearance2;
            this.lblBuchText.AutoSize = true;
            this.lblBuchText.Location = new System.Drawing.Point(26, 75);
            this.lblBuchText.Name = "lblBuchText";
            this.lblBuchText.Size = new System.Drawing.Size(73, 14);
            this.lblBuchText.TabIndex = 162;
            this.lblBuchText.Text = "Buchungstext";
            // 
            // btnApport
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnApport.Appearance = appearance3;
            this.btnApport.AutoWorkLayout = false;
            this.btnApport.IsStandardControl = false;
            this.btnApport.Location = new System.Drawing.Point(199, 135);
            this.btnApport.Name = "btnApport";
            this.btnApport.Size = new System.Drawing.Size(76, 28);
            this.btnApport.TabIndex = 3;
            this.btnApport.Text = "Abbrechen";
            this.btnApport.Click += new System.EventHandler(this.btnApport_Click);
            // 
            // btnSave
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance4;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(113, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpBuchungsdatum
            // 
            this.dtpBuchungsdatum.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBuchungsdatum.FormatString = "";
            this.dtpBuchungsdatum.Location = new System.Drawing.Point(113, 46);
            this.dtpBuchungsdatum.MaskInput = "";
            this.dtpBuchungsdatum.Name = "dtpBuchungsdatum";
            this.dtpBuchungsdatum.Size = new System.Drawing.Size(93, 21);
            this.dtpBuchungsdatum.TabIndex = 0;
            this.dtpBuchungsdatum.Value = null;
            // 
            // lblBuchungsdatum
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblBuchungsdatum.Appearance = appearance5;
            this.lblBuchungsdatum.AutoSize = true;
            this.lblBuchungsdatum.Location = new System.Drawing.Point(26, 49);
            this.lblBuchungsdatum.Name = "lblBuchungsdatum";
            this.lblBuchungsdatum.Size = new System.Drawing.Size(86, 14);
            this.lblBuchungsdatum.TabIndex = 157;
            this.lblBuchungsdatum.Text = "Buchungsdatum";
            // 
            // lblBetrag
            // 
            this.lblBetrag.AutoSize = true;
            this.lblBetrag.Location = new System.Drawing.Point(26, 101);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(38, 14);
            this.lblBetrag.TabIndex = 136;
            this.lblBetrag.Text = "Betrag";
            // 
            // tbBetrag
            // 
            appearance6.BackColorDisabled = System.Drawing.Color.White;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tbBetrag.Appearance = appearance6;
            this.tbBetrag.AutoSize = false;
            this.tbBetrag.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.tbBetrag.InputMask = "{double:-9.2}";
            this.tbBetrag.Location = new System.Drawing.Point(113, 98);
            this.tbBetrag.Name = "tbBetrag";
            this.tbBetrag.NonAutoSizeHeight = 0;
            this.tbBetrag.Size = new System.Drawing.Size(93, 20);
            this.tbBetrag.TabIndex = 2;
            this.tbBetrag.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // frmNewBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(419, 186);
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewBooking";
            this.Text = "Neue Buchung";
            this.Load += new System.EventHandler(this.frmBuchNeu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuchText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuchungsdatum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        private QS2.Desktop.ControlManagment.BaseLabel lblBetrag;
        private QS2.Desktop.ControlManagment.BaseMaskEdit tbBetrag;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBuchungsdatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblBuchungsdatum;
        private QS2.Desktop.ControlManagment.BaseButton btnApport;
        private PMDS.GUI.ucButton btnSave;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBuchText;
        private QS2.Desktop.ControlManagment.BaseLabel lblBuchText;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfo;
    }
}