using System;
using System.ComponentModel;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using Infragistics.Win;
using PMDS.Data.Patient;
using PMDS.Global;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
	/// <summary>
	/// Summary description for AbteilungsAuswahlCombo.
	/// </summary>
	public class AbteilungsAuswahlCombo : UltraCombo
	{
		private static dsAbteilung.AbteilungDataTable			_Table;
		private static bool										_bInit = false;
		private Infragistics.Win .UltraWinGrid.UltraGridColumn	ultraGridColumn1;
		Infragistics.Win.UltraWinGrid.UltraGridBand				ultraGridBand1;

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AbteilungsAuswahlCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			
			this.AutoSize = false;
			this.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
			this.SizeChanged += new System.EventHandler(this.AbteilungsAuswahlCombo_SizeChanged);
			this.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.AbteilungsAuswahlCombo_BeforeDropDown);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		private void Init2() 
		{
			ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
			UltraGridColumn ultraGridColumn2	= new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
			UltraGridColumn ultraGridColumn3	= new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
			ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
			ultraGridBand1.Columns.Add(ultraGridColumn1);
			ultraGridBand1.Columns.Add(ultraGridColumn2);
			ultraGridBand1.Columns.Add(ultraGridColumn3);
			ultraGridColumn2.Hidden				= true;
			ultraGridColumn3.Hidden				= true;
			ultraGridBand1.ColHeadersVisible	= false;
			ultraGridBand1.RowLayoutStyle			= RowLayoutStyle.ColumnLayout;
			this.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.DisplayMember					= "Bezeichnung";
			this.Location						= new System.Drawing.Point(0, 24);
			this.Name							= "cbAbteilung";
			this.ValueMember					= "ID";
			ultraGridBand1.Override.BorderStyleCell		= UIElementBorderStyle.None;
			ultraGridBand1.Override.BorderStyleRow		= UIElementBorderStyle.None;
			this.DisplayLayout.Override.RowFilterMode	= RowFilterMode.AllRowsInBand;
			this.DisplayLayout.Override.RowFilterAction = RowFilterAction.HideFilteredOutRows;
			this.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
		}
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public AbteilungsAuswahlCombo()
		{
			InitializeComponent();

			Init2();
			
			try				// hier geht DesignMode nicht da von UltraCombo geerbt und kein Load Event verfügbar
			{
                //if(!_bInit) 
                //{
					_bInit = false;
                    //Abteilung a = new Abteilung();
                    //_Table = a.ABTEILUNGLISTE;
                    
                    PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                    dsAbteilung dsAbteilung1 = new dsAbteilung();
                    DBAbteilung1.getAbteilungenByKlinik(ENV.IDKlinik, dsAbteilung1);
                    _Table = (dsAbteilung.AbteilungDataTable)dsAbteilung1.Abteilung.Copy();
                //} 
				    this.DataSource = _Table;
				
				AbteilungsAuswahlCombo_SizeChanged(this,null);
				this.SizeChanged+=new EventHandler(AbteilungsAuswahlCombo_SizeChanged);
			}
			catch(Exception ex)
			{
                ENV.HandleException(ex);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Anzahl der gelisteten Abtelungen inkl. NULL Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int ABTEILUNGS_COUNT
		{
			get 
			{
				return _Table.Rows.Count;
			}
		}
		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die ID der Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid ABTEILUNG 
		{
			get 
			{
				if(ActiveRow != null)
					return (Guid)ActiveRow.Cells["ID"].Value;
				else
					return Guid.Empty;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Bezeichnung der gewählten Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public string BEZEICHNUNG 
		{
			get 
			{
				if(ActiveRow != null)
					return (string)ActiveRow.Cells["Bezeichnung"].Value;
				else
					return "";
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Anpassung der breite
		/// </summary>
		//----------------------------------------------------------------------------
		private void AbteilungsAuswahlCombo_SizeChanged(object sender, System.EventArgs e)
		{
			if(DisplayLayout.Bands.Count > 0 && DisplayLayout.Bands[0].Columns.Count > 0) 
			{
				// Workaround
				foreach(UltraGridColumn c in DisplayLayout.Bands[0].Columns)
				{
					if(c.Key != this.DisplayMember)
						c.Hidden = true;
				}

				DisplayLayout.Bands[0].Columns["Bezeichnung"].Width = this.Width;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Größenanpassung
		/// </summary>
		//----------------------------------------------------------------------------
		private void AbteilungsAuswahlCombo_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
		{
			AbteilungsAuswahlCombo_SizeChanged(sender,e);
		}
	}
}
