using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Data.PflegePlan;



namespace PMDS.GUI
{


    public class frmTerminEdit : QS2.Desktop.ControlManagment.baseForm, IReadOnly
	{

        public Nullable<Guid> IDExtern = null;

        public dsPflegePlan.PflegePlanRow _row = null;
        public ucPflegePlanSingleEdit ucPflegePlanSingleEdit1;
		private PMDS.GUI.ucButton btnCancel;
        public ucButton btnOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblZeitpunkt;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpZeitpunkt;
		private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        internal Infragistics.Win.Misc.UltraButton btnOpenBefund;
        internal Infragistics.Win.Misc.UltraButton btnDekursErstellen;
        private ContextMenuStrip contextMenuStripSave;
        public ToolStripMenuItem klientenmehrfachauswahlToolStripMenuItem;
        private System.ComponentModel.IContainer components;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainerDekursEntwürfe;
        private QS2.Desktop.ControlManagment.BasePanel PanelDekursEntwürfe;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellenAs;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellen;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownDekursEntwürfe;
        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected = new System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes>();



        public enum eDekursType
        {
            Dekurs = 0,
            DekursEntwurf = 1,
            DekursEntwurfAlias = 2
        }









        public frmTerminEdit(dsPflegePlan.PflegePlanRow Row)
		{
			InitializeComponent();
			_row = Row;
            if (_row.IsNächstesDatumNull())
            {
                dtpZeitpunkt.Value = _row.StartDatum;
            }
            else
            {
                dtpZeitpunkt.Value = _row.NächstesDatum;
            }
			
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminEdit));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucPflegePlanSingleEdit1 = new PMDS.GUI.ucPflegePlanSingleEdit();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.contextMenuStripSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klientenmehrfachauswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblZeitpunkt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpZeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.btnOpenBefund = new Infragistics.Win.Misc.UltraButton();
            this.btnDekursErstellen = new Infragistics.Win.Misc.UltraButton();
            this.ultraPopupControlContainerDekursEntwürfe = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.PanelDekursEntwürfe = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnDekursEntwurfErstellenAs = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDekursEntwurfErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.uDropDownDekursEntwürfe = new Infragistics.Win.Misc.UltraDropDownButton();
            this.contextMenuStripSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).BeginInit();
            this.PanelDekursEntwürfe.SuspendLayout();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(550, 48);
            this.labInfo.TabIndex = 4;
            this.labInfo.Text = "Termin";
            // 
            // ucPflegePlanSingleEdit1
            // 
            this.ucPflegePlanSingleEdit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPflegePlanSingleEdit1.Location = new System.Drawing.Point(0, 88);
            this.ucPflegePlanSingleEdit1.Name = "ucPflegePlanSingleEdit1";
            this.ucPflegePlanSingleEdit1.ReadOnly = false;
            this.ucPflegePlanSingleEdit1.Size = new System.Drawing.Size(584, 491);
            this.ucPflegePlanSingleEdit1.TabIndex = 1;
            this.ucPflegePlanSingleEdit1.TransferMode = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(387, 598);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.contextMenuStrip1 = this.contextMenuStripSave;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(477, 598);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(61, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // contextMenuStripSave
            // 
            this.contextMenuStripSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klientenmehrfachauswahlToolStripMenuItem});
            this.contextMenuStripSave.Name = "contextMenuStripSave";
            this.contextMenuStripSave.Size = new System.Drawing.Size(212, 26);
            // 
            // klientenmehrfachauswahlToolStripMenuItem
            // 
            this.klientenmehrfachauswahlToolStripMenuItem.Name = "klientenmehrfachauswahlToolStripMenuItem";
            this.klientenmehrfachauswahlToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.klientenmehrfachauswahlToolStripMenuItem.Text = "Klientenmehrfachauswahl";
            this.klientenmehrfachauswahlToolStripMenuItem.Click += new System.EventHandler(this.klientenmehrfachauswahlToolStripMenuItem_Click);
            // 
            // lblZeitpunkt
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblZeitpunkt.Appearance = appearance4;
            this.lblZeitpunkt.Location = new System.Drawing.Point(16, 56);
            this.lblZeitpunkt.Name = "lblZeitpunkt";
            this.lblZeitpunkt.Size = new System.Drawing.Size(100, 23);
            this.lblZeitpunkt.TabIndex = 8;
            this.lblZeitpunkt.Text = "Zeitpunkt";
            this.lblZeitpunkt.Visible = false;
            // 
            // dtpZeitpunkt
            // 
            this.dtpZeitpunkt.FormatString = "";
            this.dtpZeitpunkt.Location = new System.Drawing.Point(120, 56);
            this.dtpZeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpZeitpunkt.Name = "dtpZeitpunkt";
            this.dtpZeitpunkt.ownFormat = "";
            this.dtpZeitpunkt.ownMaskInput = "";
            this.dtpZeitpunkt.Size = new System.Drawing.Size(144, 21);
            this.dtpZeitpunkt.TabIndex = 0;
            // 
            // btnOpenBefund
            // 
            this.btnOpenBefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.BorderColor = System.Drawing.Color.Black;
            this.btnOpenBefund.Appearance = appearance5;
            this.btnOpenBefund.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenBefund.Location = new System.Drawing.Point(293, 598);
            this.btnOpenBefund.Name = "btnOpenBefund";
            this.btnOpenBefund.Size = new System.Drawing.Size(54, 28);
            this.btnOpenBefund.TabIndex = 71;
            this.btnOpenBefund.Tag = "";
            this.btnOpenBefund.Text = "Befund";
            this.btnOpenBefund.Visible = false;
            this.btnOpenBefund.Click += new System.EventHandler(this.btnOpenBefund_Click);
            // 
            // btnDekursErstellen
            // 
            this.btnDekursErstellen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance6.BorderColor = System.Drawing.Color.Black;
            this.btnDekursErstellen.Appearance = appearance6;
            this.btnDekursErstellen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDekursErstellen.Location = new System.Drawing.Point(6, 598);
            this.btnDekursErstellen.Name = "btnDekursErstellen";
            this.btnDekursErstellen.Size = new System.Drawing.Size(104, 28);
            this.btnDekursErstellen.TabIndex = 73;
            this.btnDekursErstellen.Tag = "";
            this.btnDekursErstellen.Text = "Dekurs erstellen";
            this.btnDekursErstellen.Click += new System.EventHandler(this.btnDekursErstellen_Click);
            // 
            // ultraPopupControlContainerDekursEntwürfe
            // 
            this.ultraPopupControlContainerDekursEntwürfe.PopupControl = this.PanelDekursEntwürfe;
            // 
            // PanelDekursEntwürfe
            // 
            this.PanelDekursEntwürfe.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelDekursEntwürfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellenAs);
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellen);
            this.PanelDekursEntwürfe.Location = new System.Drawing.Point(435, 75);
            this.PanelDekursEntwürfe.Name = "PanelDekursEntwürfe";
            this.PanelDekursEntwürfe.Size = new System.Drawing.Size(103, 54);
            this.PanelDekursEntwürfe.TabIndex = 94;
            this.PanelDekursEntwürfe.Visible = false;
            // 
            // btnDekursEntwurfErstellenAs
            // 
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellenAs.Appearance = appearance7;
            this.btnDekursEntwurfErstellenAs.AutoWorkLayout = false;
            this.btnDekursEntwurfErstellenAs.IsStandardControl = false;
            this.btnDekursEntwurfErstellenAs.Location = new System.Drawing.Point(4, 27);
            this.btnDekursEntwurfErstellenAs.Name = "btnDekursEntwurfErstellenAs";
            this.btnDekursEntwurfErstellenAs.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwurfErstellenAs.TabIndex = 96;
            this.btnDekursEntwurfErstellenAs.Text = "Erstellen als";
            this.btnDekursEntwurfErstellenAs.Click += new System.EventHandler(this.btnDekursEntwurfErstellenAs_Click);
            // 
            // btnDekursEntwurfErstellen
            // 
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellen.Appearance = appearance8;
            this.btnDekursEntwurfErstellen.AutoWorkLayout = false;
            this.btnDekursEntwurfErstellen.IsStandardControl = false;
            this.btnDekursEntwurfErstellen.Location = new System.Drawing.Point(4, 3);
            this.btnDekursEntwurfErstellen.Name = "btnDekursEntwurfErstellen";
            this.btnDekursEntwurfErstellen.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwurfErstellen.TabIndex = 95;
            this.btnDekursEntwurfErstellen.Text = "Erstellen";
            this.btnDekursEntwurfErstellen.Click += new System.EventHandler(this.btnDekursEntwurfErstellen_Click);
            // 
            // uDropDownDekursEntwürfe
            // 
            this.uDropDownDekursEntwürfe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.uDropDownDekursEntwürfe.Appearance = appearance9;
            this.uDropDownDekursEntwürfe.Location = new System.Drawing.Point(113, 599);
            this.uDropDownDekursEntwürfe.Name = "uDropDownDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemKey = "PanelDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemProvider = this.ultraPopupControlContainerDekursEntwürfe;
            this.uDropDownDekursEntwürfe.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDekursEntwürfe.Size = new System.Drawing.Size(122, 26);
            this.uDropDownDekursEntwürfe.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownDekursEntwürfe.TabIndex = 93;
            this.uDropDownDekursEntwürfe.Text = "Dekurs Entwurf";
            this.uDropDownDekursEntwürfe.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownDekursEntwürfe.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmTerminEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(550, 633);
            this.Controls.Add(this.PanelDekursEntwürfe);
            this.Controls.Add(this.uDropDownDekursEntwürfe);
            this.Controls.Add(this.btnDekursErstellen);
            this.Controls.Add(this.btnOpenBefund);
            this.Controls.Add(this.dtpZeitpunkt);
            this.Controls.Add(this.lblZeitpunkt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucPflegePlanSingleEdit1);
            this.Controls.Add(this.labInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTerminEdit";
            this.ShowInTaskbar = false;
            this.Text = "Termin";
            this.Load += new System.EventHandler(this.frmPflegePlanEdit_Load);
            this.contextMenuStripSave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).EndInit();
            this.PanelDekursEntwürfe.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ucPflegePlanSingleEdit1.AcceptChanges();
                _row.StartDatum = dtpZeitpunkt.DateTime;
                _row.NächstesDatum = dtpZeitpunkt.DateTime;
                _row.DatumGeaendert = DateTime.Now;
                _row.IDBenutzer_Geaendert = ENV.USERID;

                this.Close();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
		}

		private void frmPflegePlanEdit_Load(object sender, System.EventArgs e)
		{
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            ucPflegePlanSingleEdit1.PFLEGEPLANROW = _row;
                if (!ucPflegePlanSingleEdit1.PFLEGEPLANROW.IsIDBefundNull())
                {
                    this.btnOpenBefund.Visible = true;
                }
                else
                {
                    this.btnOpenBefund.Visible = false;
                }
		}
		#region IReadOnly Members

		public bool ReadOnly
		{
			get
			{
				return ucPflegePlanSingleEdit1.ReadOnly;
			}
			set
			{
				ucPflegePlanSingleEdit1.ReadOnly = value;
			}
		}

		#endregion

        private void btnOpenBefund_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                EDIFact1.openBefund(_row.IDBefund);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void DekursErstellen(eDekursType DekursType)
        {
            try
            {
                string DekursText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zu ");
                DekursText += (this.ucPflegePlanSingleEdit1.extEinmaligJN ? QS2.Desktop.ControlManagment.ControlManagment.getRes("einmaligem ") : "") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin "); 
                DekursText += (this.ucPflegePlanSingleEdit1.extTermin != "" ? this.ucPflegePlanSingleEdit1.extTermin : "");
                DekursText += QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ") + this.ucPflegePlanSingleEdit1.extDatum;
                DekursText += (this.ucPflegePlanSingleEdit1.extAnmerkung != "" ? "\n\r" + this.ucPflegePlanSingleEdit1.extAnmerkung : "");
                DekursText += (this.ucPflegePlanSingleEdit1.extWarnung != "" ? "\n\r" + this.ucPflegePlanSingleEdit1.extWarnung : "");

                if (DekursType == eDekursType.Dekurs)
                {
                    GuiAction.PatientVermerk(ENV.CurrentIDPatient, System.Guid.Empty, eDekursherkunft.DekursAusIntervention, DekursText, false, false, null, true, "Fct. frmTerminEdit.DekursErstellen()", false, "");
                }
                else if (DekursType == eDekursType.DekursEntwurf)
                {
                    GuiAction.PatientVermerk(ENV.CurrentIDPatient, System.Guid.Empty, Global.eDekursherkunft.DekursAusÜbergabe, DekursText, false, true, null, true, "Fct. frmTerminEdit.DekursErstellen", false, "");
                }
                else if (DekursType == eDekursType.DekursEntwurfAlias)
                {
                    GuiAction.PatientVermerk(ENV.CurrentIDPatient, System.Guid.Empty, Global.eDekursherkunft.DekursAusÜbergabe, DekursText, false, true, null, true, "Fct. frmTerminEdit.DekursErstellen", true, "");
                }
                else
                {
                    throw new Exception("DekursErstellen: DekursType '" + DekursType.ToString() + "' not allowed!");
                }
             
            }
            catch (Exception ex)
            {
                throw new Exception("frmTerminEdit.DekursErstellen: " + ex.ToString());
            }

        }

        private void btnDekursErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DekursErstellen(eDekursType.Dekurs);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void klientenmehrfachauswahlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.openMehrfachselektionPatients();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void openMehrfachselektionPatients()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl frmPatientenmehrfachauswahl1 = new GUI.Main.frmPatientenmehrfachauswahl();
                frmPatientenmehrfachauswahl1.lstPatienteSelected = this.lstPatienteSelected;
                frmPatientenmehrfachauswahl1.initControl();
                frmPatientenmehrfachauswahl1.ShowDialog(this);
                if (!frmPatientenmehrfachauswahl1.abort)
                {
                    this.lstPatienteSelected = frmPatientenmehrfachauswahl1.lstPatienteSelected;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void btnDekursEntwurfErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DekursErstellen(eDekursType.DekursEntwurf);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnDekursEntwurfErstellenAs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DekursErstellen(eDekursType.DekursEntwurfAlias);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


    }
}
