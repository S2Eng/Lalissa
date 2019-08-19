//----------------------------------------------------------------------------------------------
//	BerufstandAuswahlCombo.cs
//  Ultracombo zum auswählen des Berufsstandes
//  Erstellt am:	6.10.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using Infragistics.Win;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;



namespace PMDS.GUI
{
	//----------------------------------------------------------------------------------------------
	/// <summary>
	/// BerufstandAuswahlCombo.
	/// </summary>
	//----------------------------------------------------------------------------------------------

	public class BerufstandAuswahlCombo : UltraCombo
	{

		private static dsAuswahlGruppe.AuswahlListeDataTable	_Table;
		private static bool										_bInit = false;
        private Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1;
		Infragistics.Win.UltraWinGrid.UltraGridBand				ultraGridBand1;

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializecomponent
		/// </summary>
		//----------------------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BerufstandAuswahlCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			
			this.AutoSize = false;
			this.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
			this.SizeChanged += new System.EventHandler(this.BerufsstandAuswahlCombo_SizeChanged);
			this.BeforeDropDown +=new CancelEventHandler(BerufstandAuswahlCombo_BeforeDropDown);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Zusätzliche Initialisierungen
		/// </summary>
		//----------------------------------------------------------------------------------------------
		private void Init2() 
		{
			ultraGridColumn1					= new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
			UltraGridColumn ultraGridColumn2	= new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
			UltraGridColumn ultraGridColumn3	= new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAuswahlListeGruppe");
			UltraGridColumn ultraGridColumn4	= new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
			ultraGridBand1						= new Infragistics.Win.UltraWinGrid.UltraGridBand("Berufstand", -1);
			ultraGridBand1.Columns.Add(ultraGridColumn1);
			ultraGridBand1.Columns.Add(ultraGridColumn2);
			ultraGridBand1.Columns.Add(ultraGridColumn3);
			ultraGridBand1.Columns.Add(ultraGridColumn4);
			ultraGridColumn2.Hidden				= true;
			ultraGridColumn3.Hidden				= true;
			ultraGridColumn4.Hidden				= true;
			ultraGridBand1.ColHeadersVisible	= false;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
			this.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.DisplayMember					= "Bezeichnung";
			this.Location						= new System.Drawing.Point(0, 24);
			this.Name							= "cbBerufsstand";
			this.ValueMember					= "ID";
			ultraGridBand1.Override.BorderStyleCell = UIElementBorderStyle.None;
			ultraGridBand1.Override.BorderStyleRow	= UIElementBorderStyle.None;


			//ultraGridColumn1.LockedWidth		= false;
			//ultraGridBand1.UnfixAllHeaders();
		}
	
		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public BerufstandAuswahlCombo()
		{
			InitializeComponent();
			Init2();
			InitBerufstandCombo();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert den Berufsstand als ID
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public Guid BERUFSSTAND 
		{
			get 
			{
				if(ActiveRow != null)
					return (Guid)ActiveRow.Cells["ID"].Value;
				else
					return Guid.Empty;
			}
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die aktuell ausgewählte Bezeichnung
		/// </summary>
		//----------------------------------------------------------------------------------------------
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

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung der Combo
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void InitBerufstandCombo() 
		{
			try 
			{
				if(!_bInit ) 
				{
					AuswahlGruppe ag	= new AuswahlGruppe("BER");
					_Table				= ag.AuswahlListe;
					_bInit				= true;
				}
				this.DataSource = _Table;
				BerufsstandAuswahlCombo_SizeChanged(this,null);
			}
			catch
			{
			}
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Größe anpassen
		/// </summary>
		//----------------------------------------------------------------------------------------------
		private void BerufsstandAuswahlCombo_SizeChanged(object sender, System.EventArgs e)
		{
			if(DisplayLayout.Bands.Count > 0 && DisplayLayout.Bands[0].Columns.Count > 0)
				DisplayLayout.Bands[0].Columns["Bezeichnung"].Width = this.Width;
		}

		private void BerufstandAuswahlCombo_BeforeDropDown(object sender, CancelEventArgs e)
		{
			BerufsstandAuswahlCombo_SizeChanged(sender,e);
		}
	}
}
