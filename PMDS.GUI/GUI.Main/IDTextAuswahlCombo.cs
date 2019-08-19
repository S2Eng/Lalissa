using System;
using System.ComponentModel;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using Infragistics.Win;

namespace PMDS.GUI
{
	/// <summary>
	/// Summary description for AbteilungsAuswahlCombo.
	/// </summary>
	public class IDTextAuswahlCombo : UltraCombo
	{
        private Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = null;
        private Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = null;
		Infragistics.Win.UltraWinGrid.UltraGridBand				ultraGridBand1;

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(IDTextAuswahlCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// IDTextAuswahlCombo
			// 
			this.AutoSize = false;
			this.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
			this.SizeChanged += new System.EventHandler(this.AbteilungsAuswahlCombo_SizeChanged);
			this.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.AbteilungsAuswahlCombo_BeforeDropDown);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt die Datasource
		/// </summary>
		//----------------------------------------------------------------------------
		public new object DataSource 
		{
			get
			{
				return base.DataSource;
			}
			set 
			{
				if(value == null)
					return;

				base.DataSource = value;

				// nur den Diaplaymebmer freischalten
				foreach(UltraGridColumn c in this.DisplayLayout.Bands[0].Columns)
					c.Hidden = true;

				if(this.DisplayMember.Length > 0)
					this.DisplayLayout.Bands[0].Columns[this.DisplayMember].Hidden = false;
				
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt den Displaymember
		/// ACHTUNG Datasource darf erst nach DISPLAYMEMBER und VALUEMEMBER gesetzt werden
		/// </summary>
		//----------------------------------------------------------------------------
		public string DISPLAYMEMBER	
		{ 
			get {return this.DisplayMember;}	
			
			set
			{
				if(value == null || value.Length == 0)
					return;
				if(ultraGridColumn1 == null) 
				{
					ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn(value);
					ultraGridColumn1.Hidden	= false;
					ultraGridBand1.Columns.Add(ultraGridColumn1);
				}
				this.DisplayMember = value;
			} 
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt den Valuemember
		/// ACHTUNG Datasource darf erst nach DISPLAYMEMBER und VALUEMEMBER gesetzt werden
		/// </summary>
		//----------------------------------------------------------------------------
		public string VALUEMEMBER
		{
			get {return this.ValueMember;}	
			
			set
			{
				if(value == null || value.Length == 0)
					return;
				if(ultraGridColumn2 == null) 
				{
					ultraGridColumn2		= new Infragistics.Win.UltraWinGrid.UltraGridColumn(value);
					ultraGridColumn2.Hidden	= true;
					ultraGridBand1.Columns.Add(ultraGridColumn2);
					
				}
				this.ValueMember = value;
			} 
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Init
		/// </summary>
		//----------------------------------------------------------------------------
		private void Init2() 
		{
			ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("IDText", -1);
			ultraGridBand1.ColHeadersVisible	= false;
			ultraGridBand1.RowLayoutStyle		= RowLayoutStyle.ColumnLayout;
			this.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.Location						= new System.Drawing.Point(0, 24);
			this.Name							= "IDTextAuswahlCombo";
			ultraGridBand1.Override.BorderStyleCell = UIElementBorderStyle.None;
			ultraGridBand1.Override.BorderStyleRow	= UIElementBorderStyle.None;
		}
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public IDTextAuswahlCombo()
		{
			InitializeComponent();

			Init2();
			
			try				// hier geht DesignMode nicht da von UltraCombo geerbt und kein Load Event verfügbar
			{
				AbteilungsAuswahlCombo_SizeChanged(this,null);
				this.SizeChanged+=new EventHandler(AbteilungsAuswahlCombo_SizeChanged);
			}
			catch
			{
			}
			
		}

		
		/// <summary>
		/// Liefert die ID 
		/// </summary>
		public Guid ID
		{
			get 
			{
				if(ActiveRow != null)
					return (Guid)ActiveRow.Cells[this.ValueMember].Value;
				else
					return Guid.Empty;
			}
		}

		/// <summary>
		/// Liefert die Bezeichnung der gewählten Abteilung
		/// </summary>
		public string TEXT 
		{
			get 
			{
				if(ActiveRow != null)
					return (string)ActiveRow.Cells[this.DisplayMember].Value;
				else
					return "";
			}
		}

		/// <summary>
		/// Anpassung der breite
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AbteilungsAuswahlCombo_SizeChanged(object sender, System.EventArgs e)
		{
			if(DisplayLayout.Bands.Count > 0 && DisplayLayout.Bands[0].Columns.Count > 0)
				DisplayLayout.Bands[0].Columns[this.DisplayMember].Width = this.Width;
			//foreach(UltraGridColumn c in this.DisplayLayout.Bands[0].Columns)
			//	c.Width = this.Width;
		}

		private void AbteilungsAuswahlCombo_BeforeDropDown(object sender, System.ComponentModel.CancelEventArgs e)
		{
			AbteilungsAuswahlCombo_SizeChanged(sender,e);
		}
	}
}
