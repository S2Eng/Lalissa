using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using System.Text;
using PMDS.Data.Global;
using System.IO;
using PMDS.Global.db.Patient;


namespace PMDS.GUI.PMDSClient
{


	public class ucPatientPickerClient : QS2.Desktop.ControlManagment.BaseControl
	{
		private Guid     _idAbteilung;
		private Guid     _idBereich;

        private bool _ShowEntlassene = false;
        public bool isStartGrid = false;

        public  dsKlinik.KlinikDataTable tKlinikenUser = new dsKlinik.KlinikDataTable();
        public  dsKlinik.KlinikRow rSelectKlinik = null;
        public PMDS.DB.DBPflegePlan DBPflegePlan1 = new PMDS.DB.DBPflegePlan();

        public event EventHandler RowChanged;
        public event EventHandler Click;
        public QS2.Desktop.ControlManagment.BaseGrid dgEintrag;
		private System.ComponentModel.IContainer components;

        private PMDS.Global.historie hist = new   PMDS.Global.historie();

        public bool IsInitializedLayout = false;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;

        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
        public PMDS.Global.db.ERSystem.sqlManange sqlManangeWork = new Global.db.ERSystem.sqlManange();

        public bool ControlIsInitialized = false;

        public Nullable<Guid> IDPatientLastSelected = null;

        public UltraGridRow GridRowForSelectFound = null;
        public UIGlobal UIGlobal1 = new UIGlobal();









        public ucPatientPickerClient()
		{
			InitializeComponent();
		}
        private void ucPatientPicker_Load(object sender, EventArgs e)
        {

        }
        public void initControl()
        {
            if (!this.ControlIsInitialized)
            {
                this.dgEintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

                //compDropDownListGrid newCompDropDownListGrid = new compDropDownListGrid();
                //newCompDropDownListGrid.buildList("MT1", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_MedizinischeDiagnosen));
                //this.dgEintrag.DisplayLayout.Bands[0].Columns["MT1"].ValueList = newCompDropDownListGrid.dropDownSelList;
                //this.dgEintrag.DisplayLayout.Bands[0].Columns["MT1"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                ValueList v = this.getNewValueListForGrid("MT1", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_MedizinischeDiagnosen));
                v = this.getNewValueListForGrid("MT2", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_MedizinischeDauerdiagnosen));
                v = this.getNewValueListForGrid("MT3", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Allergien));
                v = this.getNewValueListForGrid("MT4", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Infektion));
                v = this.getNewValueListForGrid("MT5", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Kostform));
                v = this.getNewValueListForGrid("MT6", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_UnverträglichkeitenRZ));   //lthxy ico_Infektionen!.ico  Unverträglichkeiten
                v = this.getNewValueListForGrid("MT7", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Suchtmittel));
                v = this.getNewValueListForGrid("MT8", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Impfungen));
                v = this.getNewValueListForGrid("MT9", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Sonstiges));
                v = this.getNewValueListForGrid("MT10", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Katheder));
                v = this.getNewValueListForGrid("MT11", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Implantate));
                v = this.getNewValueListForGrid("MT12", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Antikaguliert));
                v = this.getNewValueListForGrid("MT13", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Diabetes));
                v = this.getNewValueListForGrid("MT14", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Nuechtern));
                v = this.getNewValueListForGrid("MT15", QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_MedizinischeTypen.ico_Befunde));

                this.setValueNotfall("Notfall");
                this.SetValueToColor("WundeJN", "W", Color.DarkTurquoise, Color.Black);
                this.SetValueToColor("DNR", "DNR", Color.Gray, Color.Black);
                this.SetValueToColor("AbwesenheitBeendet", "Ab", Color.GreenYellow, Color.Black);
                this.SetValueToColor("Datenschutz", "DS", Color.Salmon, Color.Black);
                this.SetValueToColor("Anatomie", "Ana", Color.LightGray, Color.Black);
                this.SetValueToColor("KZUeberlebender", "Hol", Color.LightBlue, Color.Black);
                this.SetValueToColor("Palliativ", "P", Color.Gray, Color.Black);

                this.ControlIsInitialized = true;
            }
        }
        public ValueList getNewValueListForGrid(string sKey, Image imgActive)
        {
            ValueList v = new ValueList ();
            v.Key = sKey;

            ValueListItem itm0 = new ValueListItem();
            itm0.DisplayText = " ";
            itm0.DataValue = 0;
            itm0.Appearance.ForeColor = System.Drawing.Color.White;
            v.ValueListItems.Add(itm0);

            ValueListItem itm1 = new ValueListItem();
            itm1.DisplayText = " ";
            itm1.DataValue = 1;
            itm1.Appearance.Image = imgActive;
            itm1.Appearance.ForeColor = System.Drawing.Color.White;
            v.ValueListItems.Add(itm1);

            this.dgEintrag.DisplayLayout.ValueLists.Add(v);

            this.dgEintrag.DisplayLayout.Bands[0].Columns[sKey].ValueList = v;
            this.dgEintrag.DisplayLayout.Bands[0].Columns[sKey].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;

            return v;
        }
        public ValueList setValueNotfall(string sKey)
        {
            ValueList v = new ValueList();
            v.Key = sKey;

            ValueListItem itm0 = new ValueListItem();
            itm0.DisplayText = " ";
            itm0.DataValue = "Nein";                                          
            itm0.Appearance.BackColor = System.Drawing.Color.Transparent;
            itm0.Appearance.ForeColor = System.Drawing.Color.White;
            v.ValueListItems.Add(itm0);

            ValueListItem itm1 = new ValueListItem();
            itm1.DisplayText = "Kein Termin offen";
            itm1.DataValue = "Ja, kein Termin offen";
            itm1.Appearance.BackColor = System.Drawing.Color.PaleTurquoise;
            v.ValueListItems.Add(itm1);

            ValueListItem itm2 = new ValueListItem();
            itm2.DisplayText = "Termin(e) offen";
            itm2.DataValue = "Ja, Termin(e) offen";
            itm2.Appearance.BackColor = System.Drawing.Color.LightYellow;
            v.ValueListItems.Add(itm2);

            ValueListItem itm3 = new ValueListItem();
            itm3.DisplayText = "Termin(e) überfällig";
            itm3.DataValue = "Ja, Termin(e) überfällig";
            itm3.Appearance.BackColor = System.Drawing.Color.MistyRose;
            v.ValueListItems.Add(itm3);

            ValueListItem itm4 = new ValueListItem();
            itm4.DisplayText = "Standardprozedur offen";
            itm4.DataValue = "Ja, Standardprozedur offen";
            itm4.Appearance.BackColor = System.Drawing.Color.PeachPuff;
            v.ValueListItems.Add(itm4);

            this.dgEintrag.DisplayLayout.ValueLists.Add(v);

            this.dgEintrag.DisplayLayout.Bands[0].Columns[sKey].ValueList = v;
            this.dgEintrag.DisplayLayout.Bands[0].Columns[sKey].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

            return v;
        }

        public ValueList SetValueToColor(string sKey, string Text, System.Drawing.Color BackColor, System.Drawing.Color ForeColor)
        {
            ValueList v = new ValueList();
            v.Key = sKey;

            ValueListItem itm0 = new ValueListItem();
            itm0.DisplayText = " ";
            itm0.DataValue = "0";
            itm0.Appearance.BackColor = System.Drawing.Color.Transparent;
            itm0.Appearance.ForeColor = System.Drawing.Color.White;
            v.ValueListItems.Add(itm0);

            ValueListItem itm1 = new ValueListItem();
            itm1.DisplayText = Text;                                        //-IntVers=NoTranslation
            itm1.DataValue = "1";
            itm1.Appearance.BackColor = BackColor;
            itm0.Appearance.ForeColor = ForeColor;
            v.ValueListItems.Add(itm1);

            this.dgEintrag.DisplayLayout.ValueLists.Add(v);

            this.dgEintrag.DisplayLayout.Bands[0].Columns[sKey].ValueList = v;
            this.dgEintrag.DisplayLayout.Bands[0].Columns[sKey].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

            return v;
        }


        public bool ShowEntlassene
        {
            get { return _ShowEntlassene; }
            set { _ShowEntlassene = value; }
        }

        public UltraGrid GRID
        {
            get
            {
                return dgEintrag;
            }
            set
            {
                // Do Nothing
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

		#region Component Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("vKlientenliste", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PatientName", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Geburtsdatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klinik");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT4");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT6");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT7");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT8");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT9");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT10");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT11");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT12");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT13");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT14");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nächste Evaluierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Notfall");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abwesenheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BezugspersonenIDs");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GesamtesHausJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MT15");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WundeJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HAG_VoraussichtichesEnde");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DNR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Verstorben");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Todeszeitpunkt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbwesenheitBeendet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Datenschutz");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anatomie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KZUeberlebender");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Palliativ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Alter", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Geburtstag", 1);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.dgEintrag = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            ((System.ComponentModel.ISupportInitialize)(this.dgEintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEintrag
            // 
            this.dgEintrag.AutoWork = false;
            this.dgEintrag.DataMember = "vKlientenliste";
            this.dgEintrag.DataSource = this.dsKlientenliste1;
            appearance1.BackColor = System.Drawing.Color.White;
            this.dgEintrag.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 226;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Width = 96;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 29;
            ultraGridColumn3.Width = 157;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 152;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 112;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 7;
            ultraGridColumn6.Width = 27;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 8;
            ultraGridColumn7.Width = 27;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 9;
            ultraGridColumn8.Width = 27;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Width = 27;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Width = 27;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn11.Width = 27;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 13;
            ultraGridColumn12.Width = 27;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 14;
            ultraGridColumn13.Width = 27;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 15;
            ultraGridColumn14.Width = 27;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 16;
            ultraGridColumn15.Width = 27;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 17;
            ultraGridColumn16.Width = 27;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 18;
            ultraGridColumn17.Width = 27;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 19;
            ultraGridColumn18.Width = 27;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 20;
            ultraGridColumn19.Width = 27;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 5;
            ultraGridColumn20.Width = 128;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 0;
            ultraGridColumn21.Width = 38;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 6;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 21;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 22;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 23;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 24;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 25;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 26;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 27;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 28;
            ultraGridColumn30.Width = 27;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 30;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 31;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 32;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 33;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 34;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 35;
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 36;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 38;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 40;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 41;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn36.Header.Appearance = appearance2;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 37;
            ultraGridColumn36.Width = 39;
            appearance3.TextHAlignAsString = "Center";
            ultraGridColumn37.Header.Appearance = appearance3;
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 39;
            ultraGridColumn37.Width = 79;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn36,
            ultraGridColumn37});
            this.dgEintrag.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgEintrag.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgEintrag.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgEintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgEintrag.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgEintrag.DisplayLayout.Override.RowSpacingAfter = 0;
            this.dgEintrag.DisplayLayout.Override.RowSpacingBefore = 0;
            this.dgEintrag.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgEintrag.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgEintrag.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgEintrag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEintrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgEintrag.Location = new System.Drawing.Point(0, 0);
            this.dgEintrag.Name = "dgEintrag";
            this.dgEintrag.Size = new System.Drawing.Size(652, 544);
            this.dgEintrag.TabIndex = 23;
            this.dgEintrag.Text = "Klienten";
            this.dgEintrag.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgEintrag_BeforeCellActivate);
            this.dgEintrag.VisibleChanged += new System.EventHandler(this.dgEintrag_VisibleChanged);
            this.dgEintrag.Click += new System.EventHandler(this.dgEintrag2_Click);
            this.dgEintrag.DoubleClick += new System.EventHandler(this.dgEintrag2_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucPatientPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dgEintrag);
            this.Name = "ucPatientPicker";
            this.Size = new System.Drawing.Size(652, 544);
            this.Load += new System.EventHandler(this.ucPatientPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

 
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid Abteilung
		{
			get	{	return _idAbteilung;	}
			set	{	_idAbteilung = value;	}
		}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid Bereich
		{
			get	{	return _idBereich;	}
			set	{	_idBereich = value;	}
		}
        
        public bool IsEmpty()
        {
            return (this.dsKlientenliste1.vKlientenliste.Rows.Count == 0 ? true : false);
        }
        
        public void RefreshList()
        {
            if (ENV._IDKlinik == ENV._IDKlinikNoKlinikSelected)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dem angemeldeten Benutzer wurde keine Klinik zugeordnet! " + "\r\n" + "PMDS wird beendet.");
                PMDS.Global.Remote.ICommunicationService ICommunicationService1 = new Global.Remote.ICommunicationService();
                ICommunicationService1.CloseIPCClient();
            }

            List<Guid> ag = new List<Guid>();
            ag.Add(Abteilung);

            this.loadData(ag.ToArray(), ENV.IDKlinik);
        }
        public void RefreshList(Guid IDPatient, Guid[] aIDAbteilungen)
        {
            this.loadData(aIDAbteilungen, ENV.IDKlinik);

            if (IDPatient == Guid.Empty)
                return;

            this.SetIDPatient(IDPatient);
        }

        public void initLayout()
        {
            if (!this.IsInitializedLayout)
            {
                if (this.isStartGrid)
                {
                    string defaultLayoutName = "Patientenauswahl";            
                    this.dgEintrag.Name = "gridSelectPatientsMain";
                    QS2.Desktop.ControlManagment.BaseGrid baseGrid = (QS2.Desktop.ControlManagment.BaseGrid)this.dgEintrag;
                    baseGrid.doBaseElements1.runControlManagmentBaseGridManual(baseGrid, defaultLayoutName);
                }
                else
                {
                    this.ShowColsGrid();
                }
                this.IsInitializedLayout = true;
            }
        }
        public void ShowColsGrid()
        {
            if (!this.isStartGrid)
            {
                this.dgEintrag.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;
                this.dgEintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                this.dgEintrag.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

                foreach (UltraGridColumn col in this.dgEintrag.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }
                this.dgEintrag.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName].Hidden = false;
            }
        }
        public void loadData(Guid[] aIDAbteilungen, System.Guid IDKlinik)
        {
            try
            {
                this.initControl();

                this.GridRowForSelectFound = null;
                ucTermine.dsKlientenlisteStartGrid.Clear();
                this.dsKlientenliste1.vKlientenliste.Clear();
                this.sqlManangeWork.getPatientenStart(ENV.USERID, (this._ShowEntlassene == true ? 1 : 0), ENV.CurrentIDBezugsPfleger, ref this.dsKlientenliste1, aIDAbteilungen[0], Bereich, System.Guid.Empty);
                if (aIDAbteilungen[0] == System.Guid.Empty)     //Wenn eine Klinik gewählt wurde und nicht Abteilung oder Bereich
                {
                    foreach (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in this.dsKlientenliste1.vKlientenliste)
                    {
                        if (!rKlient.IDKlinik.Equals(ENV.IDKlinik))
                            rKlient.Delete();
                    }
                    this.dsKlientenliste1.AcceptChanges();
                }

                bool IDFound = false;
                DateTime dNow = DateTime.Now;
                dgEintrag.Refresh();
                ucTermine.dsKlientenlisteStartGrid = this.dsKlientenliste1;
                foreach (UltraGridRow rowKlient in this.dgEintrag.Rows)
                {
                    if (rowKlient.IsGroupByRow)
                    {
                        this.showGrid_rek(rowKlient, ref dNow, false, ref IDFound);
                    }
                    else
                    {
                        this.showGridRow(rowKlient, ref dNow, false, ref IDFound);
                    }
                }

                this.initLayout();

                dgEintrag.ActiveRow = null;
                dgEintrag.Selected.Rows.Clear();

                if (this.isStartGrid)
                {
                    bool LayoutFound = false;
                    qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                    compLayout1.initControl();
                    compLayout1.doLayoutGrid(this.dgEintrag, this.dgEintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    //QS2.Desktop.ControlManagment.cLayoutManager2 cLayoutManager1 = new QS2.Desktop.ControlManagment.cLayoutManager2();
                    //cLayoutManager1.doLayoutGrid(this.dgEintrag, this.dgEintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgEintrag);
                }
                else
                {
                    this.ShowColsGrid();
                }

                this.dgEintrag.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName].Header.Caption = this.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " (" + this.dsKlientenliste1.vKlientenliste.Rows.Count.ToString() + ")";

                if (_ShowEntlassene)
                {
                    this.dgEintrag.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie");
                }
                else
                {
                    //this.dgEintrag.DisplayLayout.CaptionAppearance.Image = null;
                }

                if (!this.isStartGrid)
                {
                    //this.SetIDPatient(IDPatient);
                }

                IDFound = false;
                foreach (UltraGridRow rowKlient in this.dgEintrag.Rows)
                {
                    if (rowKlient.IsGroupByRow)
                    {
                        this.showGrid_rek(rowKlient, ref dNow, true, ref IDFound);
                    }
                    else
                    {
                        this.showGridRow(rowKlient, ref dNow, true, ref IDFound);
                    }
                }

                if (!IDFound && GridRowForSelectFound == null)
                {
                    if (this.dgEintrag.Rows.Count > 0)
                    {
                        this.dgEintrag.Rows[0].ExpandAll();
                    }
                }
                else
                {
                    IDFound = false;
                    this.expand_Rek(GridRowForSelectFound, ref IDFound);
                    if (!IDFound)
                    {
                        if (this.dgEintrag.Rows.Count > 0)
                        {
                            this.dgEintrag.Rows[0].ExpandAll();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientPicker.loadData: " + ex.ToString());
            }
            finally
            {
                //this.dgEintrag.Visible = true;
            }
        }

        public void showGrid_rek(UltraGridRow rFoundInGridParent, ref DateTime dNow, bool searchID, ref bool IDFound)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rFoundInGrid, ref dNow, searchID, ref IDFound);
                        }
                        else
                        {
                            this.showGridRow(rFoundInGrid, ref dNow, searchID, ref IDFound);

                            if (rFoundInGrid.ChildBands != null && rFoundInGrid.ChildBands.Count > 0)
                            {
                                foreach (UltraGridChildBand bnd in rFoundInGrid.ChildBands)
                                {
                                    foreach (UltraGridRow rGridRowChild in bnd.Rows)
                                    {
                                        if (rFoundInGrid.IsGroupByRow)
                                        {
                                            this.showGrid_rek(rFoundInGrid, ref dNow, searchID, ref IDFound);
                                        }
                                        else
                                        {
                                            this.showGridRow(rGridRowChild, ref dNow, searchID, ref IDFound);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientPicker.showGrid_rek: " + ex.ToString());
            }
        }

        public void showGridRow(UltraGridRow rowKlient, ref DateTime dNow, bool searchID, ref bool IDFound)
        {
            try
            {
                if (!searchID)
                {
                    DataRowView v = (DataRowView)rowKlient.ListObject;
                    PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient = (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow)v.Row;

                    string sAlter = "";
                    if (!rKlient.IsGeburtsdatumNull())
                    {
                        int iAlter = PMDS.DB.PMDSBusiness.GetAgeFromDate(rKlient.Geburtsdatum);
                        sAlter = iAlter.ToString();
                    }
                    rowKlient.Cells["Alter"].Value = sAlter;

                    DateTime dGeburtstagHeuer = new DateTime(dNow.Year, rKlient.Geburtsdatum.Date.Month, rKlient.Geburtsdatum.Date.Day, 0, 0, 0);
                    if (!DateTime.IsLeapYear(dNow.Year) && dGeburtstagHeuer.Day == 29 && dGeburtstagHeuer.Month == 2)
                    {
                        dGeburtstagHeuer = new DateTime(dGeburtstagHeuer.Year, dGeburtstagHeuer.Month, 28, 0, 0, 0);
                    }
                    if (dNow.Date.Equals(dGeburtstagHeuer.Date))
                    {
                        rowKlient.Cells["Geburtstag"].Appearance.BackColor = Color.MediumVioletRed;
                        rowKlient.Cells["Geburtstag"].Value = "";
                    }
                    else
                    {
                        rowKlient.Cells["Geburtstag"].Value = "";
                        rowKlient.Cells["Geburtstag"].Appearance.BackColor = Color.Transparent;
                    }
                }
                else
                {
                    DataRowView v = (DataRowView)rowKlient.ListObject;
                    PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient = (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow)v.Row;

                    if (this.IDPatientLastSelected != null && this.IDPatientLastSelected.Value == rKlient.IDKlient)
                    {
                        this.GridRowForSelectFound = rowKlient;
                        IDFound = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientPicker.showGridRow: " + ex.ToString());
            }
        }

        public void expand_Rek(UltraGridRow rFoundInGridParent, ref bool IDFound)
        {
            try
            {
                if (rFoundInGridParent.ParentRow != null && rFoundInGridParent.ParentRow.IsGroupByRow)
                {
                    rFoundInGridParent.ParentRow.ExpandAll();
                    IDFound = true;

                    this.expand_Rek(rFoundInGridParent.ParentRow, ref IDFound);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientPicker.expand_Rek: " + ex.ToString());
            }
        }
        public void SetFilter(FilterLogicalOperator oper, string col, object filterVal)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.FilterCondition condition = null;
                this.dgEintrag.DisplayLayout.Bands[0].ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;
                this.dgEintrag.DisplayLayout.Bands[0].ColumnFilters[col].LogicalOperator = FilterLogicalOperator.Or;

                condition = this.dgEintrag.DisplayLayout.Bands[0].ColumnFilters[col].FilterConditions.Add(FilterComparisionOperator.Contains, filterVal);

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientPicker.SetFilter: " + ex.ToString());
            }
        }
        public void ClearFilter()
        {
            try
            {
                foreach (UltraGridBand band in this.dgEintrag.DisplayLayout.Bands)
                {
                    foreach (ColumnFilter colFilter in band.ColumnFilters)
                    {
                        colFilter.ClearFilterConditions();
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("ucPatientPicker.ClearFilter: " + ex.ToString());
            }
        }
        
        public void SetIDPatient(Guid IDPatient)
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgEintrag, false))
            {
                if ((Guid)r.Cells["IDKlient"].Value == IDPatient)
                    dgEintrag.ActiveRow = r;
            }
        }
        
        public void clearData()
        {
            this.dsKlientenliste1.vKlientenliste.Clear();
            this.dgEintrag.Refresh();
        }

        public  PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow CurrentRow
		{
			get
			{
                return (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow)UltraGridTools.CurrentSelectedRow(dgEintrag);
			}
		}
        
        public Guid CURRENT_IDPATIENTxy
        {
            get
            {
                PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow r = CurrentRow;
                if (r == null)
                    return Guid.Empty;
                return r.IDKlient;
            }
        }
        public Guid CURRENT_IDAufenhaltxy
        {
            get
            {
                PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow r = CurrentRow;
                if (r == null)
                    return Guid.Empty;
                return r.IDAufenthalt ;
            }

        }
        
        private void dgEintrag2_Click(object sender, EventArgs e)
        {
            if (Click != null)
                if (dgEintrag.ActiveRow != null && !dgEintrag.ActiveRow.IsGroupByRow && !dgEintrag.ActiveRow.IsFilterRow)
                {
                    ENV.setIDAUFENTHALT = this.CurrentRow.IDAufenthalt;
                    ENV.setCurrentIDPatient = this.CurrentRow.IDKlient;
                    this.Click(sender, e);
                }
        }
        private void dgEintrag2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.dgEintrag != null && this.dgEintrag.GetType().BaseType == typeof(Infragistics.Win.UltraWinGrid.UltraGrid))
                {
                    if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgEintrag))
                    {
                        if (CurrentRow != null && this.CurrentRow.IDKlient != null && this.CurrentRow.IDKlient.GetType() == typeof(System.Guid))
                        {
                            Guid tmpIDKlient = this.CurrentRow.IDKlient;
                            this.OnDoubleClick(e);
                            this.IDPatientLastSelected = tmpIDKlient;

                            if (this.CurrentRow.IDKlient == null)
                                throw new Exception("ucPatientPicker.dgEintrag2_DoubleClick IDKlient wurde unerwarteet von " + tmpIDKlient.ToString() + " auf NULL gesetzt!");
                        }
                        else
                        {
                            if (CurrentRow == null)
                            {
                                //Zwischen die Zeilen geklickt nach dem Neustart. Klient wird nicht gewechselt, nichts tun, keine Exception.
                                //throw new Exception("ucPatientPicker.dgEintrag2_DoubleClick: CurrentRow == null");
                            }
                            else if (this.CurrentRow.IDKlient == null)
                            {
                                throw new Exception("ucPatientPicker.dgEintrag2_DoubleClick: this.CurrentRow.IDKlient == null");
                            }
                            else if (this.CurrentRow.IDKlient.GetType() != typeof(System.Guid))
                            {
                                throw new Exception("ucPatientPicker.dgEintrag2_DoubleClick: this.CurrentRow.IDKlient.GetType() != typeof(System.Guid)");
                            }
                        }
                    }
                }
                else
                {
                    if (this.dgEintrag == null)
                        throw new Exception("ucPatientPicker.dgEintrag2_DoubleClick: this.dgEintrag == null");
                    if(this.dgEintrag.GetType().BaseType != typeof(Infragistics.Win.UltraWinGrid.UltraGrid))
                        throw new Exception("ucPatientPicker.dgEintrag2_DoubleClick: this.dgEintrag.GetType().BaseType != typeof(Infragistics.Win.UltraWinGrid.UltraGrid)");
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgEintrag_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgEintrag_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (!DesignMode)
                {
                    if (this.isStartGrid)
                    {
                        this.RefreshList();  
                    }
                    this.ShowColsGrid();
                    this.dgEintrag.Selected.Rows.Clear();
                    this.dgEintrag.ActiveRow = null;
                }
            }
        }
                
	}
}
