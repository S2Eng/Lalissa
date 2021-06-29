using System;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using Infragistics.Win;

namespace PMDS.GUI.BaseControls
{
	public class PflegestufenEinschaetzung : Infragistics.Win.UltraWinEditors.UltraComboEditor

    {
        public PflegestufenEinschaetzung()
        {
        }

		public string strDefault { get; set; }

		public string PSEKlasse
		{
			get
			{
				if (this.SelectedItem == null || this.Items.Count == 0)
					return "";
				else
					return this.SelectedItem.DisplayText;
			}
			set
			{
				foreach (ValueListItem i in this.Items)
				{
					if (i.DisplayText == value)
					{
						this.SelectedItem = i;
						return;
					}
				}

				this.SelectedIndex = 0;
			}
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
				int i = 0;
				System.Linq.IQueryable<PMDS.db.Entities.AuswahlListe> Auswahliste = null;
				PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
				using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
				{
					Auswahliste = PMDSBusiness1.GetAuswahllisteByAuswahllisteGruppe("PSE", db, false);

					foreach (PMDS.db.Entities.AuswahlListe rAuswahlliste in Auswahliste)
                    {
						if (i == 0)
							strDefault = rAuswahlliste.Bezeichnung;
						this.Items.Add(i, rAuswahlliste.Bezeichnung);
						i++;
					}
				}
			}
			catch (Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}
}
