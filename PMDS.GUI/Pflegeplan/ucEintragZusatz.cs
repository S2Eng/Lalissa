//----------------------------------------------------------------------------------------------
//	ucKatalog.cs
//  Verwaltung eines Eintrag Zusatzen
//  Erstellt am:	24.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using RBU;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
	/// <summary>
	/// Summary description for ucKatalog.
	/// </summary>
	public class ucEintragZusatz : QS2.Desktop.ControlManagment.BaseControl
	{
		private bool				_AllowEdit = true;
		private EintragZusatz		_EintragZusatz;
		private Guid				_IDEintrag;
		private Guid				_AktuelleAbteilung;

		public event EventHandler		ValueChanged;						// Wird ausgelöst wenn sich im Datagrid was ändert inkl. hinzufügen, entfernen

		private QS2.Desktop.ControlManagment.BaseGrid dgMain;
		private PMDS.GUI.ucButton btnAdd;
		private PMDS.GUI.ucButton btnDelete;
		private System.ComponentModel.IContainer components;
        private dsEintragZusatz dsEintragZusatz1;


		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucEintragZusatz()
		{
			InitializeComponent();
			
			if(!DesignMode && ENV.AppRunning) 
			{
                AllowEdit = ENV.HasRight(UserRights.Stammdatenverwaltung);

				ENABLED				= AllowEdit;
				btnAdd.Visible		&= AllowEdit;
				btnDelete.Visible	&= AllowEdit;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AllowEdit
		/// </summary>
		//----------------------------------------------------------------------------
		private bool AllowEdit
		{
			get	{	return _AllowEdit;	}
			set	{	_AllowEdit = value;	}
		}

		
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid AKTUELLEABTEILUNG
		{
			get 
			{
				return _AktuelleAbteilung;
			}
			
			set
			{
				_AktuelleAbteilung = value;
			}
		}
		
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDEINTRAG
		{
			get 
			{
				return _IDEintrag;
			}
			
			set
			{
				_IDEintrag = value;

			}
		}

		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Lesen der Zusatzwerte
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(Guid IDEintrag) 
		{
			_IDEintrag		= IDEintrag;

			_EintragZusatz.Read(IDEintrag);
            dgMain.ActiveRow = null;// dgMain.Rows[0];					// eine muss es immer geben
		}

		public void Read() 
		{
			_EintragZusatz.Read(IDEINTRAG);
            dgMain.ActiveRow = null; // dgMain.Rows[0];					// eine muss es immer geben
            this.ReadZeitbereich();
		}

        public void ReadZeitbereich()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridEintragZusatz in this.dgMain.Rows)
            {
                DataRowView v = (DataRowView)rGridEintragZusatz.ListObject;
                dsEintragZusatz.EintragZusatzRow rEintragZusatz = (dsEintragZusatz.EintragZusatzRow)v.Row;
                if (!rEintragZusatz.IsIDZeitbereichNull())
                {
                    foreach (Infragistics.Win.ValueListItem itmZeitbereich in this.dgMain.DisplayLayout.ValueLists["ZEITBEREICHSERIENZBIDS"].ValueListItems)
                    {
                        ZeitbereichHelper h = (ZeitbereichHelper)itmZeitbereich.DataValue;
                        if (h._ID.ToString() == rEintragZusatz.IDZeitbereich.ToString())
                        {
                            rGridEintragZusatz.Cells["IDZeitBereichSerienOderZB"].Value = (string)h.ToString();
                        }
                    }
                }
                if (!rEintragZusatz.IsIDZeitbereichSerienNull())
                {
                    foreach (Infragistics.Win.ValueListItem itmZeitbereich in this.dgMain.DisplayLayout.ValueLists["ZEITBEREICHSERIENZBIDS"].ValueListItems)
                    {
                        ZeitbereichHelper h = (ZeitbereichHelper)itmZeitbereich.DataValue;
                        if (h._ID.ToString() == rEintragZusatz.IDZeitbereichSerien.ToString())
                        {
                            rGridEintragZusatz.Cells["IDZeitBereichSerienOderZB"].Value = (string)h.ToString();
                        }
                    }
                }
            }
            this.dgMain.Refresh();
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Speichert die Änderungen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Save() 
		{
			_EintragZusatz.Save();			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Generelle Funktion für das setzen der Farben im Fehlerfall
		/// </summary>
		//----------------------------------------------------------------------------
		private void ErrorCell(UltraGridCell cell, string sError, ref bool bError)
		{
			cell.Appearance.BackColor2 = ENVCOLOR.ERROR_BACK_COLOR;
			cell.Appearance.BackGradientStyle = GradientStyle.Elliptical;
			if(bError == false) 
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
				dgMain.ActiveCell = cell;
				dgMain.Focus();
			}
			bError = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Führt die Prüfung der eingegebenen Werte durch
		/// </summary>
		//----------------------------------------------------------------------------
		public void ValidateFields(ref bool bError) 
		{
			try 
			{
				dgMain.PerformAction(UltraGridAction.ExitEditMode);
				dgMain.BeginUpdate();
				UltraGridCell cell;

				foreach(UltraGridRow r in dgMain.Rows) 
				{
                    cell = r.Cells["IDZeitBereichSerienOderZB"];            // Aufsplitten in Zeitbereich oder Zeitbereichserien wenn notwendig
                    if (!(cell.Value == DBNull.Value || cell.Value == null))                      // in dieser Spalte sind die zeitbereiche und die Zeitbereichserien vereint
                    {
                        ZeitbereichHelper h                     = new ZeitbereichHelper(cell.Value.ToString());
                        r.Cells["IDZeitbereich"].Value          = DBNull.Value;
                        r.Cells["IDZeitbereichSerien"].Value    = DBNull.Value;
                        if (h._ID != Guid.Empty)
                        {
                            if(h._TYP == ZeitbereichTyp.Zeitbereich)
                                r.Cells["IDZeitbereich"].Value = h._ID;
                            else
                                r.Cells["IDZeitbereichSerien"].Value = h._ID;
                        }
                        cell.Row.Update();
                    }

					foreach(UltraGridCell c in r.Cells) 
					{
						c.Appearance.ResetBackColor2();
						c.Appearance.ResetBackGradientStyle();
					}

                    Guid idZP = GetGuid(r.Cells["IDMassnahmenserien"]);
                    Guid idZB = GetGuid(r.Cells["IDZeitbereich"]);
                    Guid idZBS = GetGuid(r.Cells["IDZeitbereichSerien"]);
                    if ((idZP != Guid.Empty && idZB != Guid.Empty) || (idZP != Guid.Empty && idZBS != Guid.Empty))
                        ErrorCell(cell, ENV.String("ERROR_MS_ORZB"), ref bError);
                    

					cell = r.Cells["IDBerufsstand"];
					if(cell.Value == DBNull.Value || (Guid)cell.Value == Guid.Empty)
						ErrorCell(cell, ENV.String("ERROR_BERUFSSTAND"), ref bError);

					

					cell = r.Cells["Intervall"];
					if(cell.Value == DBNull.Value || (int)cell.Value == 0)
						ErrorCell(cell, ENV.String("ERROR_INTERVALL"), ref bError);

					// Untertägigprüfung
					cell = r.Cells["UntertaegigJN"];
					if((bool)cell.Value == true )
					{
						cell = r.Cells["IDMassnahmenserien"];
						if(cell.Value == DBNull.Value)
							ErrorCell(cell, ENV.String("ERROR_MASSNAHMENSERIE"), ref bError);
					}
					else
					{
						cell = r.Cells["IDMassnahmenserien"];
						cell.Value = DBNull.Value;
						cell.Row.Update();
					}


				}

			}
			finally 
			{
				dgMain.EndUpdate();
			}
		}

        private Guid GetGuid(UltraGridCell cell)
        {
            if (cell.Value == DBNull.Value || (Guid)cell.Value == Guid.Empty)
                return Guid.Empty;
            return (Guid)cell.Value;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Editable Grid EIN / AUS
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ENABLED 
		{
			set 
			{
				UltraGridTools.EnableColumns(dgMain, value);
				if(dgMain != null)
					dgMain.DisplayLayout.Bands[0].Columns["IDABteilung"].CellActivation = Activation.NoEdit; // Sperren Abteilung
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest den aktuellen Stand wieder ein
		/// </summary>
		//----------------------------------------------------------------------------
		public void Undo() 
		{
			_EintragZusatz.Read( _IDEintrag);
            this.ReadZeitbereich();
		}
		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Caption Text des Datengrids
		/// </summary>
		//----------------------------------------------------------------------------
		public string TEXT 
		{
			set 
			{
				dgMain.Text = value;
			}
		}

		

		//----------------------------------------------------------------------------
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("EintragZusatz", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAbteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Intervall");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WochenTage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IntervallTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EvalTage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBerufsstand");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ParalellJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dauer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LokalisierungJN");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinmaligJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RMOptionalJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UntertaegigJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMassnahmenserien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereichSerien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitBereichSerienOderZB", 0);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsEintragZusatz1 = new dsEintragZusatz();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragZusatz1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMain
            // 
            this.dgMain.DataSource = this.dsEintragZusatz1.EintragZusatz;
            this.dgMain.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance1.BackColor = System.Drawing.Color.White;
            this.dgMain.DisplayLayout.Appearance = appearance1;
            this.dgMain.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.AddButtonCaption = "Employees";
            ultraGridBand1.CardSettings.Style = Infragistics.Win.UltraWinGrid.CardStyle.StandardLabels;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Abteilung";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(93, 0);
            ultraGridColumn2.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(93, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(43, 0);
            ultraGridColumn3.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(42, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Caption = "Wochentage";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(65, 0);
            ultraGridColumn4.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(65, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Evaluierung";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.MaskInput = "999";
            ultraGridColumn6.MaxValue = ((short)(999));
            ultraGridColumn6.MinValue = ((short)(0));
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn6.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(74, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance2.BackColor2 = System.Drawing.Color.Red;
            ultraGridColumn7.CellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance3.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance3.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            ultraGridColumn7.CellButtonAppearance = appearance3;
            ultraGridColumn7.Header.Caption = "Berufsstand";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn7.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(74, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Parallel";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(46, 0);
            ultraGridColumn8.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(46, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(33, 0);
            ultraGridColumn9.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(33, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance4.TextHAlignAsString = "Left";
            ultraGridColumn10.CellAppearance = appearance4;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(45, 0);
            ultraGridColumn10.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(45, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(48, 0);
            ultraGridColumn11.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(48, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Bericht freiwillig";
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(85, 0);
            ultraGridColumn12.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(76, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Caption = "Untertägig";
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(88, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.Caption = "Zeitpunkte";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(124, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.Caption = "Zeitbereiche";
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn15.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(147, 0);
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.Header.Caption = "Zeitbereich";
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(136, 0);
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
            ultraGridColumn17});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgMain.DisplayLayout.InterBandSpacing = 0;
            this.dgMain.DisplayLayout.Key = "DL";
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.dgMain.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance6.BackColor = System.Drawing.Color.White;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance7.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgMain.DisplayLayout.Override.FixedHeaderAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.dgMain.DisplayLayout.Override.NullText = "";
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgMain.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgMain.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.Lime;
            this.dgMain.DisplayLayout.Override.SelectedCardCaptionAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.dgMain.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(720, 216);
            this.dgMain.TabIndex = 1;
            this.dgMain.Text = "Maßnahmendetails";
            this.dgMain.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_AfterCellUpdate);
            this.dgMain.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgMain_InitializeLayout);
            this.dgMain.AfterRowsDeleted += new System.EventHandler(this.dgMain_AfterRowsDeleted);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_ClickCellButton);
            // 
            // dsEintragZusatz1
            // 
            this.dsEintragZusatz1.DataSetName = "dsEintragZusatz";
            this.dsEintragZusatz1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintragZusatz1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.Image = 2;
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance14;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.Location = new System.Drawing.Point(672, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 20);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "&+";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.Image = 3;
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance15;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.Location = new System.Drawing.Point(696, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 20);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "&-";
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucEintragZusatz
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgMain);
            this.Name = "ucEintragZusatz";
            this.Size = new System.Drawing.Size(720, 216);
            this.Load += new System.EventHandler(this.ucEintragZusatz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragZusatz1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void dgMain_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
		
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Load
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucEintragZusatz_Load(object sender, System.EventArgs e)
		{
			try 
			{
				if(!DesignMode && ENV.AppRunning) 
				{
					_EintragZusatz = new EintragZusatz();
					dgMain.DataSource = _EintragZusatz.EINTRAGZUSATZ;

					UltraGridTools.SetAppearanceAndDisplayStyle(dgMain);

					ValueListsCollection vlc = dgMain.DisplayLayout.ValueLists;
				
					UltraGridTools.AddGuidTextValuListFromAuswahlGruppe("BER", dgMain, "IDBerufsstand", -100000, false);   
					UltraGridTools.AddAbteilungsValueList(dgMain, "IDAbteilung");						
					UltraGridTools.AddWochentagValueList(dgMain, "WochenTage");
					UltraGridTools.AddIntervallValueList(dgMain, "EvalTage");
					UltraGridTools.AddIntervallValueList(dgMain, "Intervall");
					UltraGridTools.AddUntertaegigSerieValueList(dgMain, "IDMassnahmenSerien");
                    UltraGridTools.AddZeitbereichSerienWithZeitBereichIdsValueList(dgMain, "IDZeitBereichSerienOderZB");

					//AddNew();
				}
				
			}
			catch(Exception ex)
			{
                throw new Exception(e.ToString());
            }
			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Signalisiert das sich was geändert hat
		/// </summary>
		//----------------------------------------------------------------------------
		private void CellUpdated() 
		{
			if(ValueChanged != null)
				ValueChanged(this, null);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Eine neue Zeile soll hinzugefügt werden
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            // Prüfen ob es überhaupt noch erlaubt ist eine Zeile hinzuzufügen (max. bis zur Anzahl der Abteilungen)
            frmAbteilungsWahl frm = new frmAbteilungsWahl();
            frm.ShowDialog();
            if (frm.abort)
                return;
            _EintragZusatz.AddNew(frm.IDABTEILUNG);
            CellUpdated();

            //// Prüfen ob es überhaupt noch erlaubt ist eine Zeile hinzuzufügen (max. bis zur Anzahl der Abteilungen)
            //frmAbteilungsWahl frm = new frmAbteilungsWahl();
            //ArrayList al = new ArrayList();

            //foreach(UltraGridRow r in dgMain.Rows)			// Ausschließungsarray bilden
            //    al.Add(r.Cells["IDAbteilung"].Value);

            //if(al.Count >= AbteilungsAuswahlCombo.ABTEILUNGS_COUNT) 
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_NO_MOREEINTRAGZUSATZ"), ENV.String("DIALOGTITLE_NO_MOREEINTRAGZUSATZ"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //CellUpdated();


            //if(al.Count == 0)								// Noch keine Werte definiert ==> zuerst mal die Defaultabteilung anlegen
            //{
            //    _EintragZusatz.AddNew(ENV.ABTEILUNG);
            //    return;
            //}

			
            //frm.HIDE_LIST	= (Guid[])al.ToArray(typeof(Guid));		// Die verbleibenden Abteilungen präsentieren und auf bestätigung warten
            //if(frm.ShowDialog() != DialogResult.OK)
            //    return;
            //_EintragZusatz.AddNew(frm.IDABTEILUNG);

		}
		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Ausgewählte Zeile soll gelöscht werden
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnDelete_Click(object sender, System.EventArgs e)
		{

			if((Guid)(dgMain.ActiveRow.Cells["IDAbteilung"].Value) == Guid.Empty)
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_CANNOT_DELETE_DEFAULT_EINTRAGZUSATZ"), ENV.String("MESSAGE_CANNOT_DELETE_DEFAULT_EINTRAGZUSATZ"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
				return;
			}
			dgMain.ActiveRow.Delete(false);
			CellUpdated();
		}

		private void dgMain_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			CellUpdated();
		}

		private void dgMain_AfterRowsDeleted(object sender, System.EventArgs e)
		{
			CellUpdated();
		}

		private void dgMain_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			CellUpdated();
			
			if(e.Cell.Column.Key == "EinmaligJN") 
			{
				e.Cell.EditorResolved.ExitEditMode(true, true);
				if((bool)e.Cell.Value == true) 
				{
					e.Cell.Row.Cells["EvalTage"].Value = 0;
				}
			}
		}

		private void dgMain_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (!AllowEdit)
				return;

			if( e.Cell.Column.Key == "WochenTage") 
			{
				frmWochentageEdit frm = new frmWochentageEdit((int)e.Cell.Value);
				DialogResult res =  frm.ShowDialog();
				if(res != DialogResult.OK)
					return;
				e.Cell.Value	= frm.WOCHENTAGE;
			} 
			else if( e.Cell.Column.Key == "Intervall" || e.Cell.Column.Key == "EvalTage") 
			{
				if((e.Cell.Column.Key == "EvalTage") && ((bool)e.Cell.Row.Cells["EinmaligJN"].Value == true))
				{
					QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.NO_EVAL_WITH_ONCE"), true);
					return;
				}
				frmIntervallEdit frm = new frmIntervallEdit((int)e.Cell.Value);
				DialogResult res =  frm.ShowDialog();
				if(res != DialogResult.OK)
					return;
				e.Cell.Value = frm.INTERVALL;
			}
			
			

		}
	}
}
