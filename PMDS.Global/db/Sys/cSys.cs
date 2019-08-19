using PMDS.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace PMDS.Global.db.Sys
{
    
    public class cSys
    {

        

        public bool importRessourcenFromITSCont(string ConnStrITSCont, string FileToImport, ref int iInserted, ref int iUpdated)
        {
            try
            {
                PMDS.Global.db.Sys.dsRessourcenITSCont dsRessourcenITSContRead = new dsRessourcenITSCont();
                PMDS.Global.db.Sys.sqlSys sqlSysRead = new sqlSys();
                sqlSysRead.initControl();

                System.Data.OleDb.OleDbConnection connRead = new System.Data.OleDb.OleDbConnection();
                connRead.ConnectionString = ConnStrITSCont.Trim();
                connRead.Open();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    string[] lines = System.IO.File.ReadAllLines(@FileToImport);
                    foreach (string IDRes in lines)
                    {
                        dsRessourcenITSContRead.Clear();
                        sqlSysRead.getRessourcenITSCont(IDRes.Trim(), sqlSys.eTypeRessourcenITSCont.IDRes, ref dsRessourcenITSContRead, ref connRead);
                        if (dsRessourcenITSContRead.RessourcenITSCont.Rows.Count == 1)
                        {
                            PMDS.Global.db.Sys.dsRessourcenITSCont.RessourcenITSContRow rResITSCont = (PMDS.Global.db.Sys.dsRessourcenITSCont.RessourcenITSContRow)dsRessourcenITSContRead.RessourcenITSCont.Rows[0];
                            IQueryable<PMDS.db.Entities.Ressourcen> tRessourcen = db.Ressourcen.Where(p => p.IDRes == IDRes.Trim()).OrderByDescending(p => p.IDRes == IDRes.Trim() && p.Type == "Label");
                            if (tRessourcen.Count() == 1)
                            {
                                PMDS.db.Entities.Ressourcen rResUpdate = tRessourcen.First();
                                rResUpdate.German = rResITSCont.German.Trim();
                                rResUpdate.English = rResITSCont.English.Trim();
                                rResUpdate.LastChange = DateTime.Now;
                                db.SaveChanges();
                                iUpdated += 1;
                            }
                            else if (tRessourcen.Count() == 0)
                            {
                                PMDS.db.Entities.Ressourcen rNewRessourcen = PMDS.Global.db.ERSystem.EFEntities.newRessourcen(db);
                                //PMDS.db.Entities.Ressourcen rNewRessourcen = new PMDS.db.Entities.Ressourcen();
                                rNewRessourcen.IDRes = IDRes.Trim();
                                rNewRessourcen.IDGuid = System.Guid.NewGuid();
                                rNewRessourcen.German = rResITSCont.German.Trim();
                                rNewRessourcen.English = rResITSCont.English.Trim();
                                rNewRessourcen.Type = "Label";
                                rNewRessourcen.TypeSub = "Admin";
                                rNewRessourcen.IDApplication = "ALL";
                                rNewRessourcen.IDParticipant = "ALL";
                                rNewRessourcen.IDLanguageUser = "ALL";
                                DateTime dNow = DateTime.Now;
                                rNewRessourcen.Created = dNow;
                                rNewRessourcen.LastChange = dNow;
                                rNewRessourcen.CreatedUser = "Auto";
                                rNewRessourcen.ImageWidth = -1;
                                rNewRessourcen.ImageHeigth = -1;

                                db.Ressourcen.Add(rNewRessourcen);
                                db.SaveChanges();
                                iInserted += 1;
                            }
                            else
                            {
                                throw new Exception("importRessourcenFromITSCont: tRessourcen.Count()>1 not allowed!");
                            }
                        }
                        else if (dsRessourcenITSContRead.RessourcenITSCont.Rows.Count == 0)
                        {
                            throw new Exception("importRessourcenFromITSCont: dsRessourcenITSContRead.RessourcenITSCont.Rows.Count=0 not allowed!");
                        }
                        else
                        {
                            throw new Exception("importRessourcenFromITSCont: dsRessourcenITSContRead.RessourcenITSCont.Rows.Count>1 not allowed!");
                        }
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("cSys.importRessourcenFromITSCont: " + ex.ToString());
            }
        }

        public bool importRessourcenFromITSCont2(string ConnStrITSCont, ref int iInserted, ref int iUpdated)
        {
            try
            {
                PMDS.Global.db.Sys.dsRessourcenITSCont dsRessourcenITSContRead = new dsRessourcenITSCont();
                PMDS.Global.db.Sys.sqlSys sqlSysRead = new sqlSys();
                sqlSysRead.initControl();

                System.Data.OleDb.OleDbConnection connRead = new System.Data.OleDb.OleDbConnection();
                connRead.ConnectionString = ConnStrITSCont.Trim();
                connRead.Open();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    qs2.core.language.dsLanguage dsLanguageQS2 = new qs2.core.language.dsLanguage();
                    qs2.core.language.sqlLanguage sqlLanguageQs2 = new qs2.core.language.sqlLanguage();
                    sqlLanguageQs2.initControl();
                    sqlLanguageQs2.getLanguage("", dsLanguageQS2, qs2.core.language.sqlLanguage.eTypSelLang.all, qs2.core.Enums.eResourceType.Label, "");
                    foreach (qs2.core.language.dsLanguage.RessourcenRow rResQS2Exists in dsLanguageQS2.Ressourcen)
                    {
                        if (rResQS2Exists.IDRes.Trim().Equals(rResQS2Exists.German.Trim()))
                        {
                            dsRessourcenITSContRead.Clear();
                            sqlSysRead.getRessourcenITSCont(rResQS2Exists.IDRes.Trim(), sqlSys.eTypeRessourcenITSCont.IDRes, ref dsRessourcenITSContRead, ref connRead);
                            if (dsRessourcenITSContRead.RessourcenITSCont.Rows.Count == 1)
                            {
                                PMDS.Global.db.Sys.dsRessourcenITSCont.RessourcenITSContRow rResITSCont = (PMDS.Global.db.Sys.dsRessourcenITSCont.RessourcenITSContRow)dsRessourcenITSContRead.RessourcenITSCont.Rows[0];
                                IQueryable<PMDS.db.Entities.Ressourcen> tRessourcen = db.Ressourcen.Where(p => p.IDRes == rResQS2Exists.IDRes.Trim()).OrderByDescending(p => p.IDRes == rResQS2Exists.IDRes.Trim() && p.Type == "Label");
                                if (tRessourcen.Count() == 1)
                                {
                                    PMDS.db.Entities.Ressourcen rResUpdate = tRessourcen.First();
                                    rResUpdate.German = rResITSCont.German.Trim();
                                    rResUpdate.English = rResITSCont.English.Trim();
                                    rResUpdate.LastChange = DateTime.Now;
                                    db.SaveChanges();
                                    iUpdated += 1;
                                }
                                else if (tRessourcen.Count() == 0)
                                {
                                    PMDS.db.Entities.Ressourcen rNewRessourcen = PMDS.Global.db.ERSystem.EFEntities.newRessourcen(db);
                                    //PMDS.db.Entities.Ressourcen rNewRessourcen = new PMDS.db.Entities.Ressourcen();
                                    rNewRessourcen.IDRes = rResQS2Exists.IDRes.Trim();
                                    rNewRessourcen.IDGuid = System.Guid.NewGuid();
                                    rNewRessourcen.German = rResITSCont.German.Trim();
                                    rNewRessourcen.English = rResITSCont.English.Trim();
                                    rNewRessourcen.Type = "Label";
                                    rNewRessourcen.TypeSub = "Admin";
                                    rNewRessourcen.IDApplication = "ALL";
                                    rNewRessourcen.IDParticipant = "ALL";
                                    rNewRessourcen.IDLanguageUser = "ALL";
                                    DateTime dNow = DateTime.Now;
                                    rNewRessourcen.Created = dNow;
                                    rNewRessourcen.LastChange = dNow;
                                    rNewRessourcen.CreatedUser = "Auto";
                                    rNewRessourcen.ImageWidth = -1;
                                    rNewRessourcen.ImageHeigth = -1;

                                    db.Ressourcen.Add(rNewRessourcen);
                                    db.SaveChanges();
                                    iInserted += 1;
                                }
                                else
                                {
                                    throw new Exception("importRessourcenFromITSCont2: tRessourcen.Count()>1 not allowed!");
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("cSys.importRessourcenFromITSCont2: " + ex.ToString());
            }
        }

        public bool takeOldPlansIntoNewPlanSystemAndDelete(ref int iInserted, ref string sProt, ref int iCounterError)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();

                string sqlAufgaben = " Select * from tblAufgaben order by StartTime asc, Betreff asc ";
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = sqlAufgaben;

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                da.SelectCommand = cmd;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand.CommandTimeout = 0;

                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);


                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (System.Data.DataRow r in dt.Rows)
                    {
                        Guid IDAufgabeTmp = (Guid)r["ID"];

                        Nullable<DateTime> dErstelltAm = null;
                        if (!this.checkValueNull(r["ErstelltAm"]))
                        {
                            dErstelltAm = (DateTime)r["ErstelltAm"];
                        }
                        

                        Nullable<DateTime> dStartDate = null;
                        if (!this.checkValueNull(r["StartDate"]))
                        {
                            dStartDate = (DateTime)r["StartDate"];
                        }
                        Nullable<DateTime> dStartTime = null;
                        if (!this.checkValueNull(r["StartTime"]))
                        {
                            dStartTime = (DateTime)r["StartTime"];
                        }

                        Nullable<DateTime> dStartTmp = null;
                        if (dStartDate != null && dStartTime != null)
                        {
                            dStartTmp = new DateTime(dStartDate.Value.Year, dStartDate.Value.Month, dStartDate.Value.Day, dStartTime.Value.Hour, dStartTime.Value.Minute, dStartTime.Value.Second);
                        }
                        else if (dStartDate != null && dStartTime == null)
                        {
                            dStartTmp = new DateTime(dStartDate.Value.Year, dStartDate.Value.Month, dStartDate.Value.Day, 0, 0, 0);
                        }
                        else if (dStartDate == null && dStartTime == null)
                        {
                            if (dErstelltAm != null)
                            {
                                dStartTmp = dErstelltAm.Value;
                            }
                            else
                            {
                                throw new Exception("takeOldPlansIntoNewPlanSystemAndDelete: dStartTmp is null not allowed fir IDAufgabe '" + IDAufgabeTmp.ToString() + "'!");
                            }
                        }
                        

                        Nullable<DateTime> dEndDate = null;
                        if (!this.checkValueNull(r["EndDate"]))
                        {
                            dEndDate = (DateTime)r["EndDate"];
                        }
                        Nullable<DateTime> dEndTime = null;
                        if (!this.checkValueNull(r["EndTime"]))
                        {
                            dEndTime = (DateTime)r["EndTime"];
                        }

                        Nullable<DateTime> dEndTmp = null;
                        if (dEndDate != null && dEndTime != null)
                        {
                            dEndTmp = new DateTime(dEndDate.Value.Year, dEndDate.Value.Month, dEndDate.Value.Day, dEndTime.Value.Hour, dEndTime.Value.Minute, dEndTime.Value.Second);
                        }
                        else if (dEndDate != null && dEndTime == null)
                        {
                            dEndTmp = new DateTime(dEndDate.Value.Year, dEndDate.Value.Month, dEndDate.Value.Day, 0, 0, 0);
                        }
                        else if (dEndDate == null && dEndTime == null)
                        {
                            bool bEndeIsNull = true;
                        }



                        string sBetreff = "";
                        if (!this.checkValueNull(r["Betreff"]))
                        {
                            sBetreff = r["Betreff"].ToString().Trim();
                        }
                        string sStatus = "";
                        if (!this.checkValueNull(r["Status"]))
                        {
                            sStatus = r["Status"].ToString().Trim();
                            if (sStatus.Trim().ToLower().Equals(("Neu").Trim().ToLower()))
                            {
                                sStatus = "Offen";
                            }
                        }


                        string sErstelltVon = "";
                        if (!this.checkValueNull(r["ErstelltVon"]))
                        {
                            sErstelltVon = r["ErstelltVon"].ToString().Trim();
                        }
                        string sText = "";
                        if (!this.checkValueNull(r["Text"]))
                        {
                            sText = r["Text"].ToString();
                        }
                        bool bAlsHTML = false;
                        if (!this.checkValueNull(r["AlsHTML"]))
                        {
                            bAlsHTML = (bool)r["AlsHTML"];
                        }

                        string sFürIDPerson = "";
                        if (!this.checkValueNull(r["FürIDPerson"]))
                        {
                            sFürIDPerson = r["FürIDPerson"].ToString();
                        }

                        bool bAbgeschlossen = false;
                        if (!this.checkValueNull(r["Abgeschlossen"]))
                        {
                            bAbgeschlossen = (bool)r["Abgeschlossen"];
                        }

                        string sTeilnehmer = "";
                        if (!this.checkValueNull(r["Teilnehmer"]))
                        {
                            sTeilnehmer = r["Teilnehmer"].ToString();
                        }
                                                

                        // insert plan
                        PMDS.db.Entities.plan rNewPlan = PMDS.Global.db.ERSystem.EFEntities.newPlan(db);
                        rNewPlan.ID = System.Guid.NewGuid();
                        rNewPlan.Betreff = sBetreff.Trim();
                        rNewPlan.BeginntAm = dStartTmp;
                        if (dEndTmp != null)
                        {
                            rNewPlan.EndetAm = dEndTmp;
                        }
                        rNewPlan.Text = sText;
                        rNewPlan.html = bAlsHTML;
                        rNewPlan.ErstelltAm = dErstelltAm.Value;
                        rNewPlan.ErstelltVon = sErstelltVon.Trim();
                        rNewPlan.Status = sStatus.Trim();
                        rNewPlan.Zusatz = this.getOldPlansAnhänge(IDAufgabeTmp, rNewPlan, db, b, ref sProt, ref iCounterError); ;
                        rNewPlan.IDArt = 3;
                        rNewPlan.Teilnehmer = sTeilnehmer.Trim();
                        rNewPlan.Dauer = -1;

                        IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = b.getUserByUserName2(sFürIDPerson.Trim(), db);
                        if (tBenutzer.Count() == 1)
                        {
                            PMDS.db.Entities.Benutzer rUsr = b.getUserByUserName(sFürIDPerson.Trim(), db);
                            rNewPlan.Für = sFürIDPerson.Trim();
                        }
                        else if (tBenutzer.Count() == 0)
                        {
                            rNewPlan.Für = sFürIDPerson.Trim();
                        }
                        else
                        {
                            throw new Exception("cSys.takeOldPlansIntoNewPlanSystemAndDelete: tBenutzer.Count()>1 for Usr '" + sFürIDPerson.Trim() + "' not allowede!");
                        }
                        
                        db.plan.Add(rNewPlan);
                        db.SaveChanges();
                        iInserted += 1;

                        this.getOldPlansObjs(IDAufgabeTmp, rNewPlan, db, b, ref sProt, ref iCounterError);
                        
                    }
                }

                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "cSys.takeOldPlansIntoNewPlanSystemAndDelete"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("cSys.takeOldPlansIntoNewPlanSystemAndDelete: " + ex.ToString());
            }
        }

        public void getOldPlansObjs(Guid IDAufgabeOld, PMDS.db.Entities.plan rNewPlan, PMDS.db.Entities.ERModellPMDSEntities db, PMDS.DB.PMDSBusiness b, ref string sProt, ref int iCounterError)
        {
            try
            {
                string sqlAufgaben = " Select * from tblAufgabeZuordnung where IDAufgabe = '" + IDAufgabeOld.ToString() +"' ";
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = sqlAufgaben;

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                da.SelectCommand = cmd;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand.CommandTimeout = 0;

                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                foreach (System.Data.DataRow r in dt.Rows)
                {
                    PMDS.db.Entities.planObject rNewPlanObject = PMDS.Global.db.ERSystem.EFEntities.newPlanObject(db);
                    rNewPlanObject.ID = System.Guid.NewGuid();
                    rNewPlanObject.IDPlan = rNewPlan.ID;
                    if (!this.checkValueNull(r["IDZuordnung"]))
                    {
                        rNewPlanObject.IDObject = (Guid)r["IDZuordnung"];
                        if (b.checkPatientExists(rNewPlanObject.IDObject, db))
                        {

                            db.planObject.Add(rNewPlanObject);
                            db.SaveChanges();
                        }
                        else
                        {
                            bool bPatientNotExistsInDb = true;
                        }
                    }
                    else
                    {
                        iCounterError += 1;
                        sProt += iCounterError.ToString() + ".Error - IDZuordnung is null for IDAufgabe '" + IDAufgabeOld.ToString() + "'!" + "\r\n";
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("cSys.getOldPlansObjs: " + ex.ToString());  
            }
        }
        public string getOldPlansAnhänge(Guid IDAufgabeOld, PMDS.db.Entities.plan rNewPlan, PMDS.db.Entities.ERModellPMDSEntities db, PMDS.DB.PMDSBusiness b, ref string sProt, ref int iCounterError)
        {
            try
            {
                string sqlAufgaben = " Select * from tblAufgabenAnhang where IDAufgabe = '" + IDAufgabeOld.ToString() + "' ";
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = sqlAufgaben;

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                da.SelectCommand = cmd;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand.CommandTimeout = 0;

                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                string lstIDDocumentAnhänge = "";
                foreach (System.Data.DataRow r in dt.Rows)
                {
                    if (!this.checkValueNull(r["IDDokumenteintrag"]))
                    {
                        lstIDDocumentAnhänge += r["IDDokumenteintrag"].ToString() + ";";
                    }
                }

                return lstIDDocumentAnhänge.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("cSys.getOldPlansAnhänge: " + ex.ToString());
            }
        }

        public bool checkValueNull(object obj)
        {
            if (obj is Nullable || obj == System.DBNull.Value)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
    }

}

