//----------------------------------------------------------------------------
/// <summary>
///	ucBase.cs
/// Erstellt am:	11.7.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Basisklasse für UserControls
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucBase : QS2.Desktop.ControlManagment.BaseControl
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucBase()
		{
			// Transparenz erlauben
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}
	}
}
