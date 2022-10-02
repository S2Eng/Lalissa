using System;

using PMDS.Global;using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global.db.Patient;
using PMDS.DB;

using System.Linq;


namespace PMDS.GUI.BaseControls
{




	public class AbteilungsCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		private bool _bENVAbteilung = true;
        private dsKlinik .KlinikRow _rKlinik = null;
        public PMDSBusiness b = new PMDSBusiness();




		public AbteilungsCombo()
		{
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
			RefreshList();
		}

		public bool ENVAbteilung
		{
			get	{	return _bENVAbteilung;	}
			set	
			{	
				_bENVAbteilung = value;
				RefreshList();
			}
		}
        public dsKlinik.KlinikRow rKlinik
        {
            get { return this._rKlinik; }
            set
            {
                this._rKlinik = value;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    return;
                RefreshList();
            }
        }

		public override void RefreshList()
		{
			this.Items.Clear();

			try
			{
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //this.b.UserHasRechtAufGesamteshausxyxyx()
                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                    {
                        foreach (PMDSBusiness.ResultBenutzerAbteilung r in this.b.getBenutzerAbteilung(ENV.USERID, ENV.IDKlinik, db))
                        {
                            this.Items.Add(r.IDAbteilung, r.Bezeichnung);
                        }
                    }
                    //else
                    //{
                    //    using (PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung())
                    //    {
                    //        using (dsAbteilung dsAbteilungFound = new dsAbteilung())
                    //        {
                    //            System.Linq.IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = this.b.getBenutzerAbteilung(Settings.USERID, db);
                    //            DBAbteilung1.getAbteilungenByKlinik(this.rKlinik.ID, dsAbteilungFound);
                    //            foreach (dsAbteilung.AbteilungRow r in dsAbteilungFound.Abteilung)
                    //            {
                    //                var tAbteilungRight = (from ba in tBenutzerAbteilung
                    //                                       where ba.IDAbteilung == r.ID
                    //                                       select new
                    //                                       {
                    //                                           IDAbteilung = ba.IDAbteilung
                    //                                       });
                    //                if (tAbteilungRight.Any())
                    //                {
                    //                    if (!r.ID.Equals(System.Guid.Empty))
                    //                    {
                    //                        this.Items.Add(r.ID, r.Bezeichnung);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}
}
