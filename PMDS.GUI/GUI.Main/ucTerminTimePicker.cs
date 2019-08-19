using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.GUI;




namespace PMDS.GUI
{




	public class ucTerminTimePicker : QS2.Desktop.ControlManagment.BaseControl
	{

		private DateTime _from;
		private DateTime _to;

        public ucTermineEx mainWindowxy;
        public bool IsInitialized = false;



        

		private Infragistics.Win.Misc.UltraPopupControlContainer popupContainer;
		private QS2.Desktop.ControlManagment.BasePanel pAll;
		private Infragistics.Win.Misc.UltraDropDownButton btn;
		private QS2.Desktop.ControlManagment.BaseOptionSet optZeitraumauswahl;
		private QS2.Desktop.ControlManagment.BaseLabel lblVon;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpFrom;
		private QS2.Desktop.ControlManagment.BaseLabel lblBis;
		private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpTo;
		private QS2.Desktop.ControlManagment.BaseButton btnClose;
		private QS2.Desktop.ControlManagment.BaseLabel lblDienstzeiten;
        private PMDS.GUI.BaseControls.DienstZeitenCombo cbDienstZeiten;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsUnten;
        public QS2.Desktop.ControlManagment.BasePanel panelAktualisieren;
        public QS2.Desktop.ControlManagment.BasePanel panelClose;
        private QS2.Desktop.ControlManagment.BaseButton btnClose2;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkZeitraumFixierenJN;
		private System.ComponentModel.IContainer components;






		public ucTerminTimePicker()
		{
			InitializeComponent();

			if(DesignMode)
				return;
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

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTerminTimePicker));
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            this.btn = new Infragistics.Win.Misc.UltraDropDownButton();
            this.popupContainer = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.chkZeitraumFixierenJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelButtonsUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelClose = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelAktualisieren = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblDienstzeiten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbDienstZeiten = new PMDS.GUI.BaseControls.DienstZeitenCombo();
            this.optZeitraumauswahl = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpFrom = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpTo = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.pAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeitraumFixierenJN)).BeginInit();
            this.panelButtonsUnten.SuspendLayout();
            this.panelClose.SuspendLayout();
            this.panelAktualisieren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDienstZeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optZeitraumauswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            this.btn.Appearance = appearance1;
            this.btn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaToolbarButton;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(0, 0);
            this.btn.Name = "btn";
            this.btn.PopupItemKey = "pAll";
            this.btn.PopupItemProvider = this.popupContainer;
            this.btn.Size = new System.Drawing.Size(216, 24);
            this.btn.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btn.TabIndex = 0;
            this.btn.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // popupContainer
            // 
            this.popupContainer.PopupControl = this.pAll;
            // 
            // pAll
            // 
            this.pAll.BackColor = System.Drawing.Color.Gainsboro;
            this.pAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAll.Controls.Add(this.chkZeitraumFixierenJN);
            this.pAll.Controls.Add(this.panelButtonsUnten);
            this.pAll.Controls.Add(this.lblDienstzeiten);
            this.pAll.Controls.Add(this.cbDienstZeiten);
            this.pAll.Controls.Add(this.optZeitraumauswahl);
            this.pAll.Controls.Add(this.lblVon);
            this.pAll.Controls.Add(this.dtpFrom);
            this.pAll.Controls.Add(this.lblBis);
            this.pAll.Controls.Add(this.dtpTo);
            this.pAll.Location = new System.Drawing.Point(8, 40);
            this.pAll.Name = "pAll";
            this.pAll.Size = new System.Drawing.Size(200, 269);
            this.pAll.TabIndex = 1;
            this.pAll.Visible = false;
            // 
            // chkZeitraumFixierenJN
            // 
            this.chkZeitraumFixierenJN.Location = new System.Drawing.Point(48, 143);
            this.chkZeitraumFixierenJN.Name = "chkZeitraumFixierenJN";
            this.chkZeitraumFixierenJN.Size = new System.Drawing.Size(133, 20);
            this.chkZeitraumFixierenJN.TabIndex = 14;
            this.chkZeitraumFixierenJN.Text = "Zeitraum fixieren";
            this.chkZeitraumFixierenJN.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkZeitraumFixierenJN.CheckedChanged += new System.EventHandler(this.chkZeitraumFixierenJN_CheckedChanged);
            // 
            // panelButtonsUnten
            // 
            this.panelButtonsUnten.Controls.Add(this.panelClose);
            this.panelButtonsUnten.Controls.Add(this.panelAktualisieren);
            this.panelButtonsUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonsUnten.Location = new System.Drawing.Point(0, 229);
            this.panelButtonsUnten.Name = "panelButtonsUnten";
            this.panelButtonsUnten.Size = new System.Drawing.Size(198, 38);
            this.panelButtonsUnten.TabIndex = 13;
            // 
            // panelClose
            // 
            this.panelClose.Controls.Add(this.btnClose2);
            this.panelClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClose.Location = new System.Drawing.Point(-45, 0);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(120, 38);
            this.panelClose.TabIndex = 12;
            // 
            // btnClose2
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose2.Appearance = appearance2;
            this.btnClose2.AutoWorkLayout = false;
            this.btnClose2.IsStandardControl = false;
            this.btnClose2.Location = new System.Drawing.Point(40, 0);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(70, 25);
            this.btnClose2.TabIndex = 6;
            this.btnClose2.Text = "Schließen";
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // panelAktualisieren
            // 
            this.panelAktualisieren.Controls.Add(this.btnClose);
            this.panelAktualisieren.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAktualisieren.Location = new System.Drawing.Point(75, 0);
            this.panelAktualisieren.Name = "panelAktualisieren";
            this.panelAktualisieren.Size = new System.Drawing.Size(123, 38);
            this.panelAktualisieren.TabIndex = 11;
            this.panelAktualisieren.Visible = false;
            // 
            // btnClose
            // 
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance3;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(11, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Aktualisieren";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDienstzeiten
            // 
            this.lblDienstzeiten.AutoSize = true;
            this.lblDienstzeiten.Location = new System.Drawing.Point(12, 183);
            this.lblDienstzeiten.Name = "lblDienstzeiten";
            this.lblDienstzeiten.Size = new System.Drawing.Size(67, 14);
            this.lblDienstzeiten.TabIndex = 12;
            this.lblDienstzeiten.Text = "Dienstzeiten";
            // 
            // cbDienstZeiten
            // 
            this.cbDienstZeiten.DISPLAY_TEXT = "";
            this.cbDienstZeiten.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbDienstZeiten.Enabled = false;
            this.cbDienstZeiten.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbDienstZeiten.Location = new System.Drawing.Point(10, 200);
            this.cbDienstZeiten.Name = "cbDienstZeiten";
            this.cbDienstZeiten.Size = new System.Drawing.Size(171, 21);
            this.cbDienstZeiten.TabIndex = 11;
            this.cbDienstZeiten.ValueChanged += new System.EventHandler(this.cbDienstZeiten_ValueChanged);
            // 
            // optZeitraumauswahl
            // 
            this.optZeitraumauswahl.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optZeitraumauswahl.CheckedIndex = 1;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Gestern";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Heute";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Morgen";
            valueListItem4.DataValue = 3;
            valueListItem4.DisplayText = "Zeitraum";
            valueListItem5.DataValue = 4;
            valueListItem5.DisplayText = "Dienstzeiten";
            this.optZeitraumauswahl.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.optZeitraumauswahl.Location = new System.Drawing.Point(8, 5);
            this.optZeitraumauswahl.Name = "optZeitraumauswahl";
            this.optZeitraumauswahl.Size = new System.Drawing.Size(144, 72);
            this.optZeitraumauswahl.TabIndex = 5;
            this.optZeitraumauswahl.Text = "Heute";
            this.optZeitraumauswahl.ValueChanged += new System.EventHandler(this.ultraOptionSet1_ValueChanged);
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(8, 92);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(24, 14);
            this.lblVon.TabIndex = 6;
            this.lblVon.Text = "Von";
            // 
            // dtpFrom
            // 
            this.dtpFrom.DateTime = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Location = new System.Drawing.Point(48, 92);
            this.dtpFrom.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(134, 21);
            this.dtpFrom.TabIndex = 7;
            this.dtpFrom.Value = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.ultraOptionSet1_ValueChanged);
            // 
            // lblBis
            // 
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(8, 116);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(20, 14);
            this.lblBis.TabIndex = 8;
            this.lblBis.Text = "Bis";
            // 
            // dtpTo
            // 
            this.dtpTo.DateTime = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Location = new System.Drawing.Point(48, 116);
            this.dtpTo.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(134, 21);
            this.dtpTo.TabIndex = 9;
            this.dtpTo.Value = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.ultraOptionSet1_ValueChanged);
            // 
            // ucTerminTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pAll);
            this.Controls.Add(this.btn);
            this.Name = "ucTerminTimePicker";
            this.Size = new System.Drawing.Size(216, 312);
            this.Load += new System.EventHandler(this.ucTerminTimePicker_Load);
            this.pAll.ResumeLayout(false);
            this.pAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeitraumFixierenJN)).EndInit();
            this.panelButtonsUnten.ResumeLayout(false);
            this.panelClose.ResumeLayout(false);
            this.panelAktualisieren.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbDienstZeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optZeitraumauswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion




        private void ucTerminTimePicker_Load(object sender, EventArgs e)
        {
        }

        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    pAll.DataBindings.Add("BackColor", this, "BackColor");

                    DateTime now = DateTime.Now.Date;
                    dtpFrom.DateTime = now.AddDays(-7);

                    dtpTo.DateTime = now.AddDays(7).AddSeconds(-1);

                    cbDienstZeiten.RefreshList(ENV.ABTEILUNG, false, true);

                    if (this.mainWindowxy == null)
                    {

                    }
                    else
                    {
                        if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                        {

                        }
                        else if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Übergabe)
                        {

                        }
                        else if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs)
                        {

                        } 
                    }

                    this.BackColor = System.Drawing.Color.Gainsboro;

                    DateTime dNowTmp = DateTime.Now;
                    this.dtpFrom.DateTime = dNowTmp.Date;
                    DateTime ToTmp = new DateTime(dNowTmp.Year, dNowTmp.Month, dNowTmp.Day, 23, 59, 59);
                    this.dtpTo.DateTime = ToTmp;

                    this.IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucTerminTimePicker.initControl: " + ex.ToString());
            }
        }
        public void historieOnOff(bool bOn)
        {
            if (bOn)
            {
                this.btn.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.btn.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }


        public void RecalcRange()
        {
            try
            {
                DateTime now = DateTime.Now.Date;
                string text = optZeitraumauswahl.Items[(int)optZeitraumauswahl.Value].DisplayText;
                switch ((EFilter)optZeitraumauswahl.Value)
                {
                    case EFilter.GESTERN:
                        _from = now.AddDays(-1).Date;
                        DateTime dNowTmp = now.AddDays(-1);
                        DateTime ToTmp = new DateTime(dNowTmp.Year, dNowTmp.Month, dNowTmp.Day, 23, 59, 59);
                        _to = ToTmp;
                        break;

                    case EFilter.HEUTE:
                        _from = now.Date;
                        DateTime dNowTmp2 = now;
                        DateTime ToTmp2 = new DateTime(dNowTmp2.Year, dNowTmp2.Month, dNowTmp2.Day, 23, 59, 59);
                        _to = ToTmp2;
                        break;

                    case EFilter.MORGEN:
                        _from = now.AddDays(1).Date;
                        DateTime dNowTmp3 = now.AddDays(1);
                        DateTime ToTmp3 = new DateTime(dNowTmp3.Year, dNowTmp3.Month, dNowTmp3.Day, 23, 59, 59);
                        _to = ToTmp3;
                        break;

                    case EFilter.INTERVALL:
                    case EFilter.DIENSTZEITEN:
                        _from = dtpFrom.DateTime;
                        _to = dtpTo.DateTime;

                        // Zeit vertauschen
                        if (_from > _to)
                        {
                            DateTime help = _from;
                            _from = _to;
                            _to = help;
                        }

                        text = "*******";
                        if ((EFilter)optZeitraumauswahl.Value == EFilter.INTERVALL)
                            text = string.Format("{0} - {1}", _from.ToShortDateString(), _to.ToShortDateString());
                        else
                            if (cbDienstZeiten.SelectedItem != null)
                                text = cbDienstZeiten.SelectedItem.DisplayText;
                        break;
                }

                btn.Text = text;
            }
            catch (Exception ex)
            {
                throw new Exception("ucTerminTimePicker.RecalcRange: " + ex.ToString());
            }
        }
        private void SetTimesFromDienstZeiten()
        {
            try
            {
                if (cbDienstZeiten.Value == null)
                    return;

                DateTime dtSetFrom = new DateTime(1900, 1, 1, cbDienstZeiten.VON.Hour, cbDienstZeiten.VON.Minute, 0);
                DateTime dtSetTo = new DateTime(1900, 1, 1, cbDienstZeiten.BIS.Hour, cbDienstZeiten.BIS.Minute, 0);

                bool bOverNight = dtSetFrom > dtSetTo;

                DateTime now = DateTime.Now;
                DateTime dtFrom = new DateTime(now.Year, now.Month, now.Day, dtSetFrom.Hour, dtSetFrom.Minute, 0);
                DateTime dtTo = new DateTime(now.Year, now.Month, now.Day, dtSetTo.Hour, dtSetTo.Minute, 0);

                if (bOverNight)
                {
                    bool bAfterMidday = false;
                    if (DateTime.Now.Hour >= 12)
                        bAfterMidday = true;

                    if (bAfterMidday)
                    {
                        dtTo = dtTo.AddDays(1);
                    }
                    else
                    {
                        dtFrom = dtFrom.AddDays(-1);
                    }
                }

                dtpFrom.DateTime = dtFrom;
                dtpTo.DateTime = dtTo;

            }
            catch (Exception ex)
            {
                throw new Exception("ucTerminTimePicker.SetTimesFromDienstZeiten: " + ex.ToString());
            }
        }




		[Browsable(false)]
		public EFilter Mode			
		{	
			get	{	return (EFilter)optZeitraumauswahl.Value;	} 
			set	
			{	
				optZeitraumauswahl.Value = (int)value;		
			} 
		}

		[Browsable(false)]
		public DateTime	RangeFrom	
		{	
			get	{	return _from;				} 
			set	
			{	
				dtpFrom.DateTime = value;	
			}
		}

		[Browsable(false)]
		public DateTime	RangeTo		
		{	
			get	{	return _to;					} 
			set	
			{	
				dtpTo.DateTime = value;		
			}
		}

	
		private void ultraOptionSet1_ValueChanged(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                    // nur bei Auswahl Intervall From/TO zulassen
                    bool bIsIntervall = ((EFilter)optZeitraumauswahl.Value == EFilter.INTERVALL);
                    bool bDienstzeiten = ((EFilter)optZeitraumauswahl.Value == EFilter.DIENSTZEITEN);

                    this.dtpFrom.Enabled = bIsIntervall;
                    this.dtpTo.Enabled = bIsIntervall;


                    cbDienstZeiten.Enabled = bDienstzeiten;
                    if (bDienstzeiten)							// Bei auswahl der Dienstzeit vorbelegen und Werte setzen
                    {
                        if (cbDienstZeiten.Value == null)
                            if (cbDienstZeiten.Items.Count > 0)
                                cbDienstZeiten.SelectedIndex = 0;
                        SetTimesFromDienstZeiten();
                    }
                    
                    RecalcRange();


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

		private void btnClose_Click(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                btn.Focus();
                Application.DoEvents();
                if (this.mainWindowxy != null)
                {
                    bool LayoutFound = false;
                    //this.mainWindowxy.MainWindow.quickFilterButtons1.QButtonClicked = null;
                    this.mainWindowxy.MainWindow.quickFilterButtons1.ManuellFilterClicked = true;
                    this.mainWindowxy.MainWindow.getTermine(this.mainWindowxy.MainWindow.UITypeTermine, ref LayoutFound, true);
                }

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

		private void cbDienstZeiten_ValueChanged(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.cbDienstZeiten.Focused)
                {
                    SetTimesFromDienstZeiten();
                    RecalcRange();
                }

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

        private void btnClose2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btn.Focus();
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

        private void chkZeitraumFixierenJN_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                 this.btn.Appearance.ForeColor = chkZeitraumFixierenJN.Checked ? System.Drawing.Color.Red : System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }


        }
	}

	public enum EFilter
	{
		GESTERN = 0,
		HEUTE = 1,
		MORGEN = 2,
		INTERVALL = 3,
		DIENSTZEITEN = 4
	}
}
