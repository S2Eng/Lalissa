using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB;
using PMDS.Global.db.Patient;
using PMDS.GUI.Calc.Calc.UI.Other;
using System.Linq;


namespace PMDS.Calc.UI.Admin.abwÜbersp
{
    public class abwÜberspSitemap
    {

        public PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
        private PMDS.Calc.Admin.DB.DBPatientAbwesenheit dbAbw = new PMDS.Calc.Admin.DB.DBPatientAbwesenheit();
        private PMDS.BusinessLogic.Patient pat;
        public PMDSBusiness b = new PMDSBusiness();



        public void searchAbw(DateTime von, DateTime bis, ref  dsAbwÜbersp ds,
                                int typAuswÜbersp, bool händischJN,System.Guid IDKlinik )
        {
            string errStartDat = "";
            dsPatientStation.PatientDataTable tRet = new dsPatientStation.PatientDataTable();
            dsPatientStation.PatientDataTable dtAllPat = sitemap.loadAllKlientenProdHist(true, PMDS.Global.ENV.IDKlinik, tRet);
            foreach (dsPatientStation.PatientRow rKlient in dtAllPat.Rows)
            {
                dsUrlaubVerlauf.UrlaubVerlaufDataTable dtUrlaub = PMDS.BusinessLogic.UrlaubVerlauf.alleUrlaube(rKlient.ID, von, bis );
                foreach (dsUrlaubVerlauf.UrlaubVerlaufRow rUrlaub in dtUrlaub)
                {
                    dsAbwÜbersp.abwRow rNew = (dsAbwÜbersp.abwRow)ds.abw.NewRow();
                    rNew.ID = System.Guid.NewGuid().ToString().ToLower();
                    rNew.Überspielen = false;

                    this.pat = new PMDS.BusinessLogic.Patient(rKlient.ID);
                    rNew.KlientName = this.pat.FullName;
                    rNew.Grund = rUrlaub.Text.Trim();
                    rNew.Händisch = this.pat.abwHändBerechJN(rKlient.ID);
                    if (!händischJN && rNew.Händisch) continue;

                    if (rUrlaub.IsStartDatumNull())
                        errStartDat += this.pat.FullName + QS2.Desktop.ControlManagment.ControlManagment.getRes(": Für eine Abwesenheit ist das Beginndatum leer!         ");


                    rNew.Von = rUrlaub.StartDatum;
                    if (rUrlaub.IsEndeDatumNull())
                        rNew.SetBisNull();
                    else
                    {
                        rNew.Bis = rUrlaub.EndeDatum;
                    }

                    rNew.IDUrlaubVerlauf = rUrlaub.ID.ToString().ToLower();

                    PMDS.Abrechnung.Global.dsPatientAbwesenheit.PatientAbwesenheitDataTable dtBereitsÜbersp = dbAbw.bereitsÜbersp(rUrlaub.ID.ToString(), PMDS.Global.ENV.IDKlinik);

                    if (dtBereitsÜbersp.Count == 0)
                    {
                        rNew.bereitsÜbersp = false;
                        rNew.Überspielen = true;
                    }
                    else if (dtBereitsÜbersp.Count == 1)                //r = in Abrechnung eingetragene Daten, rNew = in der Pflege erfasste Daten
                    {
                        rNew.bereitsÜbersp = true;
                        PMDS.Abrechnung.Global.dsPatientAbwesenheit.PatientAbwesenheitRow r = (PMDS.Abrechnung.Global.dsPatientAbwesenheit.PatientAbwesenheitRow)dtBereitsÜbersp.Rows[0];
                        DateTime dtBis =  r.IsBisNull() ? new DateTime(1900, 1, 1) : r.Bis;
                        DateTime dtrNewBis =  rNew.IsBisNull() ? new DateTime(1900, 1, 1) : rNew.Bis;
                        rNew.Überspielen = (rNew.Von.Date != r.Von.Date || (dtrNewBis.Date != dtBis.Date && dtrNewBis !=new DateTime(1900, 1, 1))  ) ? true : false;                
                    }
                    else
                        throw new Exception("Fehler: Abwesenheit mehrfach überspielt. Das ist nicht zulässig.");


                    bool anzeigen = false;

                    if (PMDS.Global.ENV.AbwesenheitenMinimalUI) 
                    {
                        anzeigen = rNew.Überspielen;
                    }
                    else
                    {
                        if (typAuswÜbersp == -1)                             //alle anzeigen
                            anzeigen = true;
                        else if (typAuswÜbersp == 0 && !rNew.bereitsÜbersp)  // nur nicht überspielte anzeigen
                            anzeigen = true;
                        else if (typAuswÜbersp == 1 && rNew.bereitsÜbersp)   // nur überspielte anzeigen
                            anzeigen = true;
                    }

                    if (rKlient.IsIDKlinikNull())
                    {
                        throw new Exception("abwÜberspSitemap.searchAbw: rKlient.IsIDKlinikNull() for IDPatient '" + rKlient.ID.ToString() + "'!");
                    }
                    if (rKlient.IDKlinik != PMDS.Global.ENV.IDKlinik)
                    {
                        throw new Exception("abwÜberspSitemap.searchAbw: rKlient.IDKlinik != rKlient .IDKlinik for IDPatient '" + rKlient.ID.ToString() + "'!");
                    }
                    rNew.IDKlinik = rKlient.IDKlinik;

                    if (anzeigen)
                    {
                        rNew.IDKlient = rKlient.ID;
                        ds.abw.Rows.Add(rNew);
                    }
               }
            }

            try
            {
                if (errStartDat != "")
                    throw new Exception(errStartDat);
            }
            catch (Exception ex)
            {
               PMDS.Global.ENV.HandleException(ex);
            }
        }

        public int überspielen(ref  dsAbwÜbersp ds, bool eingespDelete)
        {
            int anz = 0;
            PMDS.Calc.Admin.DB.DBPatientAbwesenheit dbAbwSave = new PMDS.Calc.Admin.DB.DBPatientAbwesenheit();
            PMDS.Abrechnung.Global.dsPatientAbwesenheit.PatientAbwesenheitDataTable  dtAbwNew;
            dtAbwNew = dbAbwSave.Read(System.Guid.NewGuid(), PMDS.Global.ENV.IDKlinik);
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                foreach (dsAbwÜbersp.abwRow rGef in ds.abw )
                {
                    if (rGef.Überspielen && !rGef.Händisch )
                    {
                        PMDS.Abrechnung.Global.dsPatientAbwesenheit.PatientAbwesenheitRow rNew = this.dbAbw.New(dtAbwNew, rGef.IDKlient, PMDS.Global.ENV.USERID);
                        rNew.Grund = rGef.Grund;    
                        rNew.Von = rGef.Von.Date;
                        rNew.Übersp = true;
                        if (!rGef.IsBisNull())
                            rNew.Bis = rGef.Bis.Date;
                        rNew.IDPatient = rGef.IDKlient;
                        rNew.Übersp = true;
                        rNew.IDÜber =  rGef.IDUrlaubVerlauf.ToLower();
                        rNew.IDKlinik = rGef.IDKlinik;

                        var rPatInfo = (from p in db.Patient
                                        where p.ID == rNew.IDPatient
                                        select new
                                        { p.TageAbweseneheitOhneKuerzung }
                                        ).First();

                        //PMDS.db.Entities.Patient rPatient = this.b.getPatient(rNew.IDPatient, db);
                        if (rPatInfo.TageAbweseneheitOhneKuerzung >= 0)
                        {
                            rNew.abTagN = rPatInfo.TageAbweseneheitOhneKuerzung;
                        }

                        if (eingespDelete)
                            this.dbAbw.delete(rNew.IDÜber, rGef.IDKlinik);

                        anz += 1;
                    }
                }
            }
            if (anz > 0)
                dbAbwSave.daPatientAbwesenheit.Update(dtAbwNew);

            return anz;
        }

        public bool abwHändBerech(System.Guid IDPatient)
        {
            this.pat = new PMDS.BusinessLogic.Patient();
            System.Data. DataTable dt = this.pat.abwHändBerech(IDPatient);
            if ((bool)dt.Rows[0]["abwesenheitenHändBerech"])
                return true;
            else
                return false;
        }

    }
}
