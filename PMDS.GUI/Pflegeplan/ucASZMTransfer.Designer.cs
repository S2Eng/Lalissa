namespace PMDS.GUI
{
    partial class ucASZMTransfer
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlStartDatum = new QS2.Desktop.ControlManagment.BasePanel();
            this.grbStartdatum = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.pnlUhrzeit = new QS2.Desktop.ControlManagment.BasePanel();
            this.tbUhrzeit = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblUhrZeit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblStartdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpStart = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.pnlStartZeitpunkte = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbSerie = new PMDS.GUI.BaseControls.MassnahmenSerienCombo();
            this.zp3 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp1 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp4 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp6 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp5 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.zp2 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblStartzeitpunkte = new QS2.Desktop.ControlManagment.BaseLabel();
            this.zp0 = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucPflegePlanSingleEdit1 = new PMDS.GUI.ucPflegePlanSingleEdit();
            this.pnlStartDatum.SuspendLayout();
            this.grbStartdatum.SuspendLayout();
            this.pnlUhrzeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUhrzeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            this.pnlStartZeitpunkte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStartDatum
            // 
            this.pnlStartDatum.Controls.Add(this.grbStartdatum);
            this.pnlStartDatum.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStartDatum.Location = new System.Drawing.Point(0, 0);
            this.pnlStartDatum.Name = "pnlStartDatum";
            this.pnlStartDatum.Size = new System.Drawing.Size(553, 85);
            this.pnlStartDatum.TabIndex = 45;
            // 
            // grbStartdatum
            // 
            this.grbStartdatum.Controls.Add(this.pnlUhrzeit);
            this.grbStartdatum.Controls.Add(this.lblStartdatum);
            this.grbStartdatum.Controls.Add(this.dtpStart);
            this.grbStartdatum.Controls.Add(this.pnlStartZeitpunkte);
            this.grbStartdatum.Location = new System.Drawing.Point(10, 1);
            this.grbStartdatum.Name = "grbStartdatum";
            this.grbStartdatum.Size = new System.Drawing.Size(533, 82);
            this.grbStartdatum.TabIndex = 14;
            this.grbStartdatum.TabStop = false;
            // 
            // pnlUhrzeit
            // 
            this.pnlUhrzeit.Controls.Add(this.tbUhrzeit);
            this.pnlUhrzeit.Controls.Add(this.lblUhrZeit);
            this.pnlUhrzeit.Location = new System.Drawing.Point(204, 11);
            this.pnlUhrzeit.Name = "pnlUhrzeit";
            this.pnlUhrzeit.Size = new System.Drawing.Size(106, 24);
            this.pnlUhrzeit.TabIndex = 29;
            // 
            // tbUhrzeit
            // 
            this.tbUhrzeit.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.tbUhrzeit.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.tbUhrzeit.Location = new System.Drawing.Point(48, 2);
            this.tbUhrzeit.MaskInput = "hh:mm";
            this.tbUhrzeit.Name = "tbUhrzeit";
            this.tbUhrzeit.Size = new System.Drawing.Size(40, 21);
            this.tbUhrzeit.TabIndex = 29;
            this.tbUhrzeit.Value = null;
            // 
            // lblUhrZeit
            // 
            this.lblUhrZeit.Location = new System.Drawing.Point(0, 6);
            this.lblUhrZeit.Name = "lblUhrZeit";
            this.lblUhrZeit.Size = new System.Drawing.Size(47, 16);
            this.lblUhrZeit.TabIndex = 28;
            this.lblUhrZeit.Text = "Uhrzeit";
            // 
            // lblStartdatum
            // 
            this.lblStartdatum.Location = new System.Drawing.Point(12, 17);
            this.lblStartdatum.Name = "lblStartdatum";
            this.lblStartdatum.Size = new System.Drawing.Size(64, 16);
            this.lblStartdatum.TabIndex = 27;
            this.lblStartdatum.Text = "Startdatum";
            // 
            // dtpStart
            // 
            this.dtpStart.DateTime = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            this.dtpStart.Location = new System.Drawing.Point(82, 12);
            this.dtpStart.MaskInput = "dd.mm.yyyy";
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(96, 21);
            this.dtpStart.TabIndex = 18;
            this.dtpStart.Value = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            // 
            // pnlStartZeitpunkte
            // 
            this.pnlStartZeitpunkte.Controls.Add(this.cbSerie);
            this.pnlStartZeitpunkte.Controls.Add(this.zp3);
            this.pnlStartZeitpunkte.Controls.Add(this.zp1);
            this.pnlStartZeitpunkte.Controls.Add(this.zp4);
            this.pnlStartZeitpunkte.Controls.Add(this.zp6);
            this.pnlStartZeitpunkte.Controls.Add(this.zp5);
            this.pnlStartZeitpunkte.Controls.Add(this.zp2);
            this.pnlStartZeitpunkte.Controls.Add(this.lblStartzeitpunkte);
            this.pnlStartZeitpunkte.Controls.Add(this.zp0);
            this.pnlStartZeitpunkte.Location = new System.Drawing.Point(12, 39);
            this.pnlStartZeitpunkte.Name = "pnlStartZeitpunkte";
            this.pnlStartZeitpunkte.Size = new System.Drawing.Size(488, 40);
            this.pnlStartZeitpunkte.TabIndex = 28;
            this.pnlStartZeitpunkte.Visible = false;
            // 
            // cbSerie
            // 
            this.cbSerie.DISPLAY_TEXT = "";
            this.cbSerie.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbSerie.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbSerie.Location = new System.Drawing.Point(336, 16);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.Size = new System.Drawing.Size(144, 21);
            this.cbSerie.TabIndex = 26;
            this.cbSerie.ValueChanged += new System.EventHandler(this.cbSerie_ValueChanged);
            // 
            // zp3
            // 
            this.zp3.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp3.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp3.Location = new System.Drawing.Point(144, 16);
            this.zp3.MaskInput = "hh:mm";
            this.zp3.Name = "zp3";
            this.zp3.Size = new System.Drawing.Size(40, 21);
            this.zp3.TabIndex = 22;
            this.zp3.Value = null;
            // 
            // zp1
            // 
            this.zp1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp1.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp1.Location = new System.Drawing.Point(48, 16);
            this.zp1.MaskInput = "hh:mm";
            this.zp1.Name = "zp1";
            this.zp1.Size = new System.Drawing.Size(40, 21);
            this.zp1.TabIndex = 20;
            this.zp1.Value = null;
            // 
            // zp4
            // 
            this.zp4.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp4.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp4.Location = new System.Drawing.Point(192, 16);
            this.zp4.MaskInput = "hh:mm";
            this.zp4.Name = "zp4";
            this.zp4.Size = new System.Drawing.Size(40, 21);
            this.zp4.TabIndex = 23;
            this.zp4.Value = null;
            // 
            // zp6
            // 
            this.zp6.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp6.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp6.Location = new System.Drawing.Point(288, 16);
            this.zp6.MaskInput = "hh:mm";
            this.zp6.Name = "zp6";
            this.zp6.Size = new System.Drawing.Size(40, 21);
            this.zp6.TabIndex = 25;
            this.zp6.Value = null;
            // 
            // zp5
            // 
            this.zp5.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp5.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp5.Location = new System.Drawing.Point(240, 16);
            this.zp5.MaskInput = "hh:mm";
            this.zp5.Name = "zp5";
            this.zp5.Size = new System.Drawing.Size(40, 21);
            this.zp5.TabIndex = 24;
            this.zp5.Value = null;
            // 
            // zp2
            // 
            this.zp2.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp2.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp2.Location = new System.Drawing.Point(96, 16);
            this.zp2.MaskInput = "hh:mm";
            this.zp2.Name = "zp2";
            this.zp2.Size = new System.Drawing.Size(40, 21);
            this.zp2.TabIndex = 21;
            this.zp2.Value = null;
            // 
            // lblStartzeitpunkte
            // 
            this.lblStartzeitpunkte.Location = new System.Drawing.Point(0, 0);
            this.lblStartzeitpunkte.Name = "lblStartzeitpunkte";
            this.lblStartzeitpunkte.Size = new System.Drawing.Size(416, 16);
            this.lblStartzeitpunkte.TabIndex = 1;
            this.lblStartzeitpunkte.Text = "Startzeitpunkte  (hh:mm)";
            // 
            // zp0
            // 
            this.zp0.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zp0.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.zp0.Location = new System.Drawing.Point(0, 16);
            this.zp0.MaskInput = "hh:mm";
            this.zp0.Name = "zp0";
            this.zp0.Size = new System.Drawing.Size(40, 21);
            this.zp0.TabIndex = 19;
            this.zp0.Value = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPflegePlanSingleEdit1
            // 
            this.ucPflegePlanSingleEdit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPflegePlanSingleEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPflegePlanSingleEdit1.Location = new System.Drawing.Point(0, 85);
            this.ucPflegePlanSingleEdit1.Name = "ucPflegePlanSingleEdit1";
            this.ucPflegePlanSingleEdit1.ReadOnly = false;
            this.ucPflegePlanSingleEdit1.Size = new System.Drawing.Size(553, 741);
            this.ucPflegePlanSingleEdit1.TabIndex = 46;
            this.ucPflegePlanSingleEdit1.TransferMode = true;
            // 
            // ucASZMTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ucPflegePlanSingleEdit1);
            this.Controls.Add(this.pnlStartDatum);
            this.Name = "ucASZMTransfer";
            this.Size = new System.Drawing.Size(553, 826);
            this.pnlStartDatum.ResumeLayout(false);
            this.grbStartdatum.ResumeLayout(false);
            this.grbStartdatum.PerformLayout();
            this.pnlUhrzeit.ResumeLayout(false);
            this.pnlUhrzeit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUhrzeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            this.pnlStartZeitpunkte.ResumeLayout(false);
            this.pnlStartZeitpunkte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zp0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlStartDatum;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grbStartdatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblStartdatum;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpStart;
        private QS2.Desktop.ControlManagment.BasePanel pnlStartZeitpunkte;
        private PMDS.GUI.BaseControls.MassnahmenSerienCombo cbSerie;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp3;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp1;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp4;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp6;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp5;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp2;
        private QS2.Desktop.ControlManagment.BaseLabel lblStartzeitpunkte;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor zp0;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BasePanel pnlUhrzeit;
        private QS2.Desktop.ControlManagment.BaseLabel lblUhrZeit;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor tbUhrzeit;
        public ucPflegePlanSingleEdit ucPflegePlanSingleEdit1;
    }
}
