//----------------------------------------------------------------------------
/// <summary>
///	EngineSelectorLB.cs
/// Erstellt am:	20.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Data;

namespace PMDS.GUI.Engines
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Engine Selector für Verwaltungsoperation
	/// </summary>
	//----------------------------------------------------------------------------
	public class EngineSelectorLB : EngineSelector
	{
		private ListBox _select;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public EngineSelectorLB(ListBox sel) : base(sel)
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
			_select.SelectedIndexChanged += new EventHandler(OnValueChanged);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten festlegen
		/// </summary>
		//----------------------------------------------------------------------------
		public override DataTable DataSource
		{
			get	{	return (DataTable)_select.DataSource;	}
			set	{	_select.DataSource = value;	}
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
			get	{	return _select.SelectedValue;	}
			set
			{
				if (value == null)
				{
					if (Count > 0)
						_select.SelectedIndex = 0;
				}
				else
					_select.SelectedValue = value;
			}
		}
	}
}
