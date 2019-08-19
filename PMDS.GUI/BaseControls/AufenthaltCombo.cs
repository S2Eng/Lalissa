//----------------------------------------------------------------------------
/// <summary>
///	AufenthaltCombo.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox für Aufenthalt-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class AufenthaltCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public AufenthaltCombo()
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
                    foreach (dsGUIDListe.IDListeRow pr in Patient.All())
                    {
                        foreach (dsAufenthalt.AufenthaltRow ar in Aufenthalt.ByPatient(pr.ID))
                        {
                            string s = string.Format("{1} {0}", pr.TEXT, ar.Aufnahmezeitpunkt.ToString());
                            this.Items.Add(ar.ID, s);
                        }
                    }
                }

			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}

}
