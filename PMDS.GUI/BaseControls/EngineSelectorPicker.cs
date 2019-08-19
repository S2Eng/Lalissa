//----------------------------------------------------------------------------
/// <summary>
///	EngineSelectorPicker.cs
/// Erstellt am:	7.7.2005
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
	public class EngineSelectorPicker : EngineSelector
	{
		private ucPicker _select;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public EngineSelectorPicker(ucPicker sel) : base(sel)
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
			_select.SelectionChanged += new EventHandler(OnValueChanged);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten festlegen
		/// </summary>
		//----------------------------------------------------------------------------
		public override DataTable DataSource
		{
			get	{	return _select.DataSource;		}
			set	{	_select.DataSource = value;		}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Anzahl der Elemente ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public override int Count
		{
			get	{	return _select.Count;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Selektor Wert lesen/setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public override object Value
		{
			get	{	return _select.Value;	}
			set	{	_select.Value = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Control Enabled
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool Enabled
		{
			get	{	return _select.Enabled;	}
			set	{	/* NOT OPERATION */		}
		}
	}
}
