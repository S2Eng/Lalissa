//----------------------------------------------------------------------------
/// <summary>
///	EngineType.cs
/// Erstellt am:	20.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;

using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Engines
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Nützliche Engine Operationen
	/// </summary>
	//----------------------------------------------------------------------------
	public class EngineType
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Engine Selector ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public static EngineSelector EngineFor(Control ctrl)
		{
			if (ctrl is UltraComboEditor)
				return new EngineSelectorUCE((UltraComboEditor)ctrl);

			if (ctrl is ListBox)
				return new EngineSelectorLB((ListBox)ctrl);

			if (ctrl is ucPicker)
				return new EngineSelectorPicker((ucPicker)ctrl);

			throw new NotSupportedException(ctrl.ToString());
		}
	}
}
