//----------------------------------------------------------------------------
/// <summary>
///	EngineSelector.cs
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
	public abstract class EngineSelector
	{
		private Control _ctrl;
		public event EventHandler ValueChanged;


		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public EngineSelector(Control sel)
		{
			_ctrl = sel;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung des Selektors
		/// </summary>
		//----------------------------------------------------------------------------
		public abstract void InitSelector();

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(sender, args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten festlegen
		/// </summary>
		//----------------------------------------------------------------------------
		public abstract DataTable DataSource
		{
			get;
			set;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Anzahl der Elemente ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public abstract int Count
		{
			get;

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Selektor Wert lesen/setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public abstract object Value
		{
			get;
			set;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Selektions Text ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public string Text
		{
			get	{	return _ctrl.Text;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Control Enabled
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual bool Enabled
		{
			get	{	return _ctrl.Enabled;	}
			set	{	_ctrl.Enabled = value;}
		}
	}
}
