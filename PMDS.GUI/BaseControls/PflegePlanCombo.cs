//----------------------------------------------------------------------------
/// <summary>
///	PflegePlanCombo.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
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
	public class PflegePlanCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public PflegePlanCombo()
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

                            // Pflegeplan befüllen
                            PflegePlan pp = new PflegePlan(ar.ID);
                            pp.Read();
                            foreach (dsPflegePlan.PflegePlanRow ppr in pp.PFLEGEPLAN_EINTRAEGE)
                            {
                                // nur Maßnahmen
                                if (ppr.EintragGruppe != "M")
                                    continue;

                                string ps = string.Format("{0} - {1}", s, ppr.Text);
                                this.Items.Add(ppr.ID, ps);
                            }
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
