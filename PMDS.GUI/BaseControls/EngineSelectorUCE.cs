//----------------------------------------------------------------------------
/// <summary>
///	EngineSelectorUCE.cs
/// Erstellt am:	20.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Data;

using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Engines
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Engine Selector für Verwaltungsoperation
	/// </summary>
	//----------------------------------------------------------------------------
	public class EngineSelectorUCE : EngineSelector
	{
		private UltraComboEditor _select;
		private DataTable		 _dataSource = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public EngineSelectorUCE(UltraComboEditor sel) : base(sel)
		{
			_select = sel;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung des Selektors
		/// </summary>
		//----------------------------------------------------------------------------
		public override void InitSelector()
		{
			_select.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			_select.ValueChanged += new EventHandler(OnValueChanged);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten festlegen
		/// </summary>
		//----------------------------------------------------------------------------
		public override DataTable DataSource
		{
			get	{	return _dataSource;	}
			set	
			{
				_dataSource = value;

				_select.Items.Clear();
				foreach(DataRow r in value.Rows)
					_select.Items.Add(r["ID"], (string)r["TEXT"]);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Anzahl der Elemente ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public override int Count
		{
			get	{	return _select.Items.Count;	}

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Selektor Wert lesen/setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public override object Value
		{
			get	{	return _select.Value;	}
			set
			{
				if (value == null)
				{
					if (Count > 0)
						_select.SelectedIndex = 0;
					else
						_select.Value = null;
				}
				else
					_select.Value = value;
			}
		}
	}
}
