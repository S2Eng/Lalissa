//----------------------------------------------------------------------------
/// <summary>
///	PatientCombo.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;

using PMDS.Global;using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox für Patient-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class PatientCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public PatientCombo()
		{
			RefreshList();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void RefreshList()
		{
			this.Items.Clear();
			try
			{
                if (ENV.AppRunning)
                {
                    foreach (dsGUIDListe.IDListeRow r in Patient.All())
                        this.Items.Add(r.ID, r.TEXT);
                }

			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}

}
