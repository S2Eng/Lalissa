using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using PMDS.Global.db.Patient;
using System.Drawing;
using PMDS.Global.db.ERSystem;
using Patagames.Pdf.Net;      
using Patagames.Pdf.Enums;
using System.Threading;
using PMDS.DB;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using static PMDS.DB.PMDSBusinessStructures;


namespace PMDS.DB
{
        
    public class PMDSBusinessRAM
    {
        public static List<PMDS.db.Entities.Klinik> tKlinik = null;
        public static List<PMDS.db.Entities.Benutzer> tBenutzer = null;
        public static List<PMDS.db.Entities.Abteilung> tAbteilung = null;
        public static List<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = null;
        public static List<PMDS.db.Entities.BenutzerEinrichtung> tBenutzerEinrichtung = null;
        public static List<PMDS.db.Entities.Bereich> tBereich = null;
        public static List<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = null;
        public static List<PMDS.db.Entities.AuswahlListe> tAuswahlListe = null;
        public static List<Guid> lstPatAbw = new List<Guid>();
   
        public static List<cPatientsAll> tPatientsAufenthaltAllAct = null;
        public static dsKlientenliste dsKlientenliste1 = new dsKlientenliste();        
        public static bool IsInitialized = false;

        public void loadDataStart(bool doRegisterClient, bool doAlways, bool WaitThreadsReady, bool startThreadLoadingData)
        {
            try
            {
                    if (!PMDSBusinessRAM.IsInitialized || doAlways)
                {
                    PMDSBusinessComm.threadsRunning = true;

                    Thread thread_loadStammdaten = new Thread(new ThreadStart(this.thread_loadStammdaten));
                    thread_loadStammdaten.IsBackground = true;
                    thread_loadStammdaten.Start();
                    
                    Thread thread_loadStammdaten2 = new Thread(new ThreadStart(this.thread_loadStammdaten2));
                    thread_loadStammdaten2.IsBackground = true;
                    thread_loadStammdaten2.Start();

                    Thread thread_getPatientenStart = new Thread(new ThreadStart(this.thread_getPatientenStart));
                    thread_getPatientenStart.IsBackground = true;
                    thread_getPatientenStart.Start();

                    if (String.IsNullOrWhiteSpace(PMDSBusinessComm.uniqueIDMachine))
                    {
                        throw new Exception("PMDSBusinessRAM.loadDataStart: PMDSBusinessRAM.uniqueIDMachine.Trim()=='' not allowed!");
                    }

                    if (doRegisterClient)
                    {
                        PMDSBusinessComm.registerClient(PMDSBusinessComm.uniqueIDMachine.Trim());
                    }

                    if (WaitThreadsReady)
                    {
                        bool allThreadsReady = false;
                        while (!allThreadsReady)
                        {
                            if (thread_loadStammdaten.ThreadState != ThreadState.Running && thread_loadStammdaten2.ThreadState != ThreadState.Running && thread_getPatientenStart.ThreadState != ThreadState.Running)
                            {
                                allThreadsReady = true;
                            }
                            else
                            {
                                PMDSBusinessComm.threadsRunning = true;
                            }
                        }
                    }
                    PMDSBusinessComm.threadsRunning = false;

                    if (startThreadLoadingData)
                    {
                        PMDSBusinessComm bComm = new PMDSBusinessComm();
                        bComm.startThreadCheckingData();
                    }

                    PMDSBusinessRAM.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                PMDSBusinessComm.threadsRunning = false;
                throw new Exception("PMDSBusinessRAM.loadDataStart: " + ex.ToString());
            }
        }

        public void thread_loadStammdaten()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDSBusinessRAM.tKlinik = db.Klinik.OrderBy(o => o.Bezeichnung).ToList();
                    PMDSBusinessRAM.tBenutzer = db.Benutzer.OrderBy(o => o.Nachname).ToList();
                    PMDSBusinessRAM.tAbteilung = db.Abteilung.OrderBy(o => o.Bezeichnung).ToList();
                    PMDSBusinessRAM.tBenutzerAbteilung = db.BenutzerAbteilung.OrderBy(o => o.IDBenutzer).ToList();
                    PMDSBusinessRAM.tBenutzerEinrichtung = db.BenutzerEinrichtung.OrderBy(o => o.IDBenutzer).ToList();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void thread_loadStammdaten2()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDSBusinessRAM.tBereich = db.Bereich.OrderBy(o => o.Bezeichnung).ToList();
                    PMDSBusinessRAM.tBereichBenutzer = db.BereichBenutzer.ToList();
                    PMDSBusinessRAM.tAuswahlListe = db.AuswahlListe.ToList();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        
        public void thread_getPatientenStart()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDSBusinessRAM.tPatientsAufenthaltAllAct = new List<cPatientsAll>();

                    PMDSBusinessRAM.lstPatAbw = new List<Guid>();
                    var tPatientsAbwesendAct = (from p in db.Patient
                                                join a in db.Aufenthalt on p.ID equals a.IDPatient
                                                from uv in db.UrlaubVerlauf.Where(uv => uv.IDAufenthalt == a.ID && uv.EndeDatum == null)
                                                where a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.Entlassungszeitpunkt == null
                                                orderby p.Nachname ascending, p.Vorname ascending
                                                select new
                                                {
                                                    p.ID,
                                                    p.Nachname
                                                }).Distinct().ToList();

                    foreach (var r in tPatientsAbwesendAct)
                    {
                        PMDSBusinessRAM.lstPatAbw.Add(r.ID);
                    }

                    List<cPatientsAll> tPatientsAufenthaltAllActTmp2 = (from p in db.Patient
                                                                        join a in db.Aufenthalt on p.ID equals a.IDPatient
                                                                        where a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.Entlassungszeitpunkt == null 
                                                                        orderby p.Nachname ascending, p.Vorname ascending
                                                                        select new cPatientsAll()
                                                                        {
                                                                            IDPatient = p.ID,
                                                                            PatientNachname = p.Nachname,
                                                                            PatientVorname = p.Vorname,
                                                                            IDAufenthalt = a.ID,
                                                                            Entlassungszeitpunkt = a.Entlassungszeitpunkt,
                                                                            IDAbteilung = a.IDAbteilung,
                                                                            IDBereich = a.IDBereich

                                                                        }).Distinct().ToList();

                    //List <cPatientsAll> tPatientsAufenthaltAllActTmp2 = (from p in db.Patient
                    //                                                     join a in db.Aufenthalt on p.ID equals a.IDPatient
                    //                                                     where a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.Entlassungszeitpunkt == null && !lstPatAbw.Contains(p.ID)
                    //                                                     orderby p.Nachname ascending, p.Vorname ascending
                    //                                                     select new cPatientsAll()
                    //                                                     {
                    //                                                        IDPatient = p.ID,
                    //                                                        PatientNachname = p.Nachname,
                    //                                                        PatientVorname = p.Vorname,
                    //                                                        IDAufenthalt = a.ID,
                    //                                                        Entlassungszeitpunkt = a.Entlassungszeitpunkt,
                    //                                                        IDAbteilung = a.IDAbteilung,
                    //                                                        IDBereich = a.IDBereich

                    //                                                     }).Distinct().ToList();

                    PMDSBusinessRAM.tPatientsAufenthaltAllAct = tPatientsAufenthaltAllActTmp2;

                    //List<cPatientsAll> tPatientsAufenthaltAllActTmp2 = (from p in db.Patient
                    //                                                   join a in db.Aufenthalt on p.ID equals a.IDPatient 
                    //                                                   from uv in db.UrlaubVerlauf.Where(uv => uv.IDAufenthalt == a.ID && uv.EndeDatum != null)  
                    //                                                   where a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.Entlassungszeitpunkt == null   
                    //                                                    orderby p.Nachname ascending, p.Vorname ascending
                    //                                                   select new cPatientsAll()
                    //                                                   {
                    //                                                       IDPatient = p.ID,
                    //                                                       PatientNachname = p.Nachname,
                    //                                                       PatientVorname = p.Vorname,
                    //                                                       IDAufenthalt = a.ID,
                    //                                                       Entlassungszeitpunkt = a.Entlassungszeitpunkt,
                    //                                                       IDAbteilung = a.IDAbteilung,
                    //                                                       IDBereich = a.IDBereich

                    //                                                   }).Distinct().ToList();
                }


                //PMDSBusinessRAM.dsKlientenliste1 = new dsKlientenliste();
                //sqlManange sqlManangeWork = new sqlManange();
                //sqlManangeWork.initControl();
                //sqlManangeWork.getPatientenStart(PMDS.Global.ENV.USERID, 0, System.Guid.Empty, ref PMDSBusinessRAM.dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void waitThreadsLoadingDataReady()
        {
            try
            {
                while (PMDSBusinessComm.threadsRunning)
                {
                    qs2.core.generic.WaitMilli(5);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.waitThreadsLoadingDataReady: " + ex.ToString());
            }
        }
        public List<Guid> getListAbwesendePatients()
        {
            try
            {
                return PMDSBusinessRAM.lstPatAbw;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getListAbwesendePatients: " + ex.ToString());
            }
        }










        public PMDS.db.Entities.Benutzer getUser(Guid IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                List<PMDS.db.Entities.Benutzer> tBenutzer = PMDSBusinessRAM.tBenutzer.Where(b => b.ID == IDBenutzer).ToList();
                return tBenutzer.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.LogggedOnUser: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Klinik getKlinik(Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                List<PMDS.db.Entities.Klinik> tKlinik = PMDSBusinessRAM.tKlinik.Where(b => b.ID == IDKlinik).ToList();
                return tKlinik.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getKlinik: " + ex.ToString());
            }
        }

        public List<cPatients> getPatientenStart(Guid IDAbteilung, Guid IDBereich, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                //thread_getPatientenStart();
                if (IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in PMDSBusinessRAM.tPatientsAufenthaltAllAct
                                      select new cPatients()
                                      {
                                          IDPatient = p.IDPatient,
                                          PatientNachname = p.PatientNachname,
                                          PatientVorname = p.PatientVorname,
                                          IDAbteilung = p.IDAbteilung,
                                          IDBereich = p.IDBereich
                                      }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in PMDSBusinessRAM.tPatientsAufenthaltAllAct
                                                  where p.IDAbteilung == IDAbteilung
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.IDPatient,
                                                      PatientNachname = p.PatientNachname,
                                                      PatientVorname = p.PatientVorname,
                                                      IDAbteilung = p.IDAbteilung,
                                                      IDBereich = p.IDBereich
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else if (IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in PMDSBusinessRAM.tPatientsAufenthaltAllAct
                                                  where p.IDBereich == IDBereich
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.IDPatient,
                                                      PatientNachname = p.PatientNachname,
                                                      PatientVorname = p.PatientVorname,
                                                      IDAbteilung = p.IDAbteilung,
                                                      IDBereich = p.IDBereich
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in PMDSBusinessRAM.tPatientsAufenthaltAllAct
                                                  where p.IDAbteilung == IDAbteilung && p.IDBereich == IDBereich
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.IDPatient,
                                                      PatientNachname = p.PatientNachname,
                                                      PatientVorname = p.PatientVorname,
                                                      IDAbteilung = p.IDAbteilung,
                                                      IDBereich = p.IDBereich
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else
                {
                    throw new Exception("PMDSBusinessRAM.getPatientenStart: IDAbteilung or IDBereich nbot allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getPatientenStart: " + ex.ToString());
            }
        }
        public List<PMDS.db.Entities.Abteilung> getAllAbteilungen(System.Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                List<PMDS.db.Entities.Abteilung> tAbteilung = PMDSBusinessRAM.tAbteilung.Where(o => o.IDKlinik == IDKlinik).OrderBy(o => o.Bezeichnung).ToList();
                return tAbteilung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllAbteilungen()"), 100300);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllAbteilungen: " + ex.ToString());
            }
        }
        public bool getAllBereichForAbteilung(System.Guid IDAbteilung, ref List<PMDS.db.Entities.Bereich> tBereichForAbteilung,
                                PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                tBereichForAbteilung = PMDSBusinessRAM.tBereich.Where(b => b.IDAbteilung == IDAbteilung).OrderBy(o => o.Bezeichnung).ToList();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllBereichForAbteilung: " + ex.ToString());
            }
        }
        public void getAllUsersKlinik(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDKlinik, ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                lstBenutzerReturn = (from b in PMDSBusinessRAM.tBenutzer
                                  join ba in PMDSBusinessRAM.tBenutzerAbteilung on b.ID equals ba.IDBenutzer
                                  join be in PMDSBusinessRAM.tBenutzerEinrichtung on b.ID equals be.IDBenutzer
                                  join a in PMDSBusinessRAM.tAbteilung on ba.IDAbteilung equals a.ID
                                  where a.IDKlinik == IDKlinik && be.IDEinrichtung == IDKlinik
                                  orderby b.Nachname ascending, b.Vorname ascending
                                  select (b.ID)).Distinct().ToList();

                //foreach (var rBenutzer in tBenutzer4)
                //{
                //    lstBenutzerReturn.Add(rBenutzer.IDBenutzer);
                //}

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllUsersKlinik()"), 100300);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllUsersKlinik: " + ex.ToString());
            }
        }
        public bool getAllUsersForAbteilung(Nullable<Guid> IDAbteilung, Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db,
                                    ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                lstBenutzerReturn = (from ba in PMDSBusinessRAM.tBenutzerAbteilung
                              join a in PMDSBusinessRAM.tAbteilung on ba.IDAbteilung equals a.ID
                              join ben in PMDSBusinessRAM.tBenutzer on ba.IDBenutzer equals ben.ID
                              join be in PMDSBusinessRAM.tBenutzerEinrichtung on ben.ID equals be.IDBenutzer
                              orderby ben.Nachname ascending, ben.Vorname ascending
                              where a.IDKlinik == IDKlinik && a.ID == IDAbteilung && be.IDEinrichtung == IDKlinik
//                              select new { IDBenutzer = ba.IDBenutzer }).Distinct().ToList();
                              select (ba.IDBenutzer)).Distinct().ToList();

                //foreach (var ben in tUsers)
                //{
                //    lstBenutzerReturn.Add(ben.IDBenutzer);
                //}

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllUsersForAbteilung()"), 100301);
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllUsersForAbteilung: " + ex.ToString());
            }
        }
        public bool getAllUsersForBereich(Nullable<Guid> IDBereich, Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db,
                            ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                lstBenutzerReturn = (from bb in PMDSBusinessRAM.tBereichBenutzer
                                  join b in PMDSBusinessRAM.tBereich on bb.IDBereich equals b.ID
                                  join a in PMDSBusinessRAM.tAbteilung on b.IDAbteilung equals a.ID
                                  join ben in PMDSBusinessRAM.tBenutzer on bb.IDBenutzer equals ben.ID
                                  join be in PMDSBusinessRAM.tBenutzerEinrichtung on ben.ID equals be.IDBenutzer
                                  where a.IDKlinik == IDKlinik && b.ID == IDBereich && be.IDEinrichtung == IDKlinik
                                  orderby ben.Nachname ascending, ben.Vorname ascending
                                  select (bb.IDBenutzer )).Distinct().ToList();

                //foreach (var rBenutzer in tBenutzer4)
                //{
                //    lstBenutzerReturn.Add(rBenutzer.IDBenutzer);
                //}

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllUsersForBereich()"), 100302);
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllUsersForBereich: " + ex.ToString());
            }
        }
        public List<PMDS.db.Entities.AuswahlListe> GetAuswahllistenByIDGruppe(string GehörtzuGruppe, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                List<PMDS.db.Entities.AuswahlListe> tAuswahlliste = PMDSBusinessRAM.tAuswahlListe.Where(a => a.GehörtzuGruppe.Contains(GehörtzuGruppe.Trim())).OrderBy(a => GehörtzuGruppe).ToList();
                return tAuswahlliste;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.GetAuswahllistenByIDGruppe: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.AuswahlListe GetAuswahllisteByID(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                List<PMDS.db.Entities.AuswahlListe> tAuswahlliste = PMDSBusinessRAM.tAuswahlListe.Where(a => a.ID == ID).OrderBy(a => a.Bezeichnung).ToList();
                return tAuswahlliste.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.GetAuswahllisteByID: " + ex.ToString());
            }
        }
        public List<PMDS.db.Entities.AuswahlListe> GetAuswahlliste(PMDS.db.Entities.ERModellPMDSEntities db, string GruppeID, int SupressLevelHierarchie)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                List<PMDS.db.Entities.AuswahlListe> tAuswahlliste = PMDSBusinessRAM.tAuswahlListe.Where(a => a.IDAuswahlListeGruppe == GruppeID && a.Hierarche >= SupressLevelHierarchie).OrderBy(a => a.Bezeichnung).ToList();
                return tAuswahlliste;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.GetAuswahlliste: " + ex.ToString());
            }
        }

        public bool checkRightAbteilungenUser(Guid IDAbteilung, System.Guid IDKlinik, Guid IDUser, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                return (from a in PMDSBusinessRAM.tAbteilung
                                          join ba in PMDSBusinessRAM.tBenutzerAbteilung on a.ID equals ba.IDAbteilung
                                          where ba.IDBenutzer == IDUser && a.IDKlinik == IDKlinik && a.ID == IDAbteilung
                                          select new
                                          {
                                              IDBenutzer = ba.IDBenutzer,
                                              IDAbteilung = ba.IDAbteilung
                                          }).Any();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.checkRightAbteilungenUser: " + ex.ToString());
            }
        }

































        public List<cPatients> getPatientenStartOld2(Guid IDAbteilung, Guid IDBereich, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.waitThreadsLoadingDataReady();

                if (IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in db.Patient
                                                  from a in db.Aufenthalt.Where(a => a.IDPatient == p.ID && a.Entlassungszeitpunkt == null && a.IDKlinik == PMDS.Global.ENV.IDKlinik)
                                                  from uv in db.UrlaubVerlauf.Where(uv => uv.IDAufenthalt == a.ID && uv.EndeDatum != null).DefaultIfEmpty()
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.ID,
                                                      PatientNachname = p.Nachname,
                                                      PatientVorname = p.Vorname,
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in db.Patient
                                                  from a in db.Aufenthalt.Where(a => a.IDPatient == p.ID && a.Entlassungszeitpunkt == null && a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.IDAbteilung == IDAbteilung)
                                                  from uv in db.UrlaubVerlauf.Where(uv => uv.IDAufenthalt == a.ID && uv.EndeDatum != null).DefaultIfEmpty()
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.ID,
                                                      PatientNachname = p.Nachname,
                                                      PatientVorname = p.Vorname,
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else if (IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in db.Patient
                                                  from a in db.Aufenthalt.Where(a => a.IDPatient == p.ID && a.Entlassungszeitpunkt == null && a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.IDBereich == IDBereich)
                                                  from uv in db.UrlaubVerlauf.Where(uv => uv.IDAufenthalt == a.ID && uv.EndeDatum != null).DefaultIfEmpty()
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.ID,
                                                      PatientNachname = p.Nachname,
                                                      PatientVorname = p.Vorname,
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    List<cPatients> tPatients2 = (from p in db.Patient
                                                  from a in db.Aufenthalt.Where(a => a.IDPatient == p.ID && a.Entlassungszeitpunkt == null && a.IDKlinik == PMDS.Global.ENV.IDKlinik && a.IDAbteilung == IDAbteilung && a.IDBereich == IDBereich)
                                                  from uv in db.UrlaubVerlauf.Where(uv => uv.IDAufenthalt == a.ID && uv.EndeDatum != null).DefaultIfEmpty()
                                                  select new cPatients()
                                                  {
                                                      IDPatient = p.ID,
                                                      PatientNachname = p.Nachname,
                                                      PatientVorname = p.Vorname,
                                                  }).Distinct().OrderBy(p => p.PatientNachname).ToList();
                    return tPatients2;
                }
                else
                {
                    throw new Exception("PMDSBusinessRAM.getPatientenStart: IDAbteilung or IDBereich nbot allowed!");
                }


            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getPatientenStart: " + ex.ToString());
            }
        }
        public List<PMDS.db.Entities.vKlientenliste> getPatientenStartOld(Guid IDAbteilung, Guid IDBereich, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    List<PMDS.db.Entities.vKlientenliste> tvKlientenliste = db.vKlientenliste.OrderBy(o => o.PatientName).ToList();
                    return tvKlientenliste;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    List<PMDS.db.Entities.vKlientenliste> tvKlientenliste = db.vKlientenliste.Where(o => o.IDAbteilung == IDAbteilung).OrderBy(o => o.PatientName).ToList();
                    return tvKlientenliste;
                }
                else if (IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    List<PMDS.db.Entities.vKlientenliste> tvKlientenliste = db.vKlientenliste.Where(o => o.IDBereich == IDBereich).OrderBy(o => o.PatientName).ToList();
                    return tvKlientenliste;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    List<PMDS.db.Entities.vKlientenliste> tvKlientenliste = db.vKlientenliste.Where(o => o.IDAbteilung == IDAbteilung && o.IDBereich == IDBereich).OrderBy(o => o.PatientName).ToList();
                    return tvKlientenliste;
                }
                else
                {
                    throw new Exception("PMDSBusinessRAM.getPatientenStart: IDAbteilung or IDBereich nbot allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getPatientenStart: " + ex.ToString());
            }
        }
        public dsKlientenliste.vKlientenlisteRow[] getPatientenStartOld(Guid IDAbteilung, Guid IDBereich)
        {
            try
            {
                if (IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    dsKlientenliste.vKlientenlisteRow[] arrKlienten = (dsKlientenliste.vKlientenlisteRow[])PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.Select("", PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " asc");
                    return arrKlienten;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && IDBereich.Equals(System.Guid.Empty))
                {
                    dsKlientenliste.vKlientenlisteRow[] arrKlienten = (dsKlientenliste.vKlientenlisteRow[])PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.Select("IDAbteilung='" + IDAbteilung.ToString() + "'", PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " asc");
                    return arrKlienten;
                }
                else if (IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    dsKlientenliste.vKlientenlisteRow[] arrKlienten = (dsKlientenliste.vKlientenlisteRow[])PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.Select("IDBereich='" + IDBereich.ToString() + "'", PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " asc");
                    return arrKlienten;
                }
                else if (!IDAbteilung.Equals(System.Guid.Empty) && !IDBereich.Equals(System.Guid.Empty))
                {
                    dsKlientenliste.vKlientenlisteRow[] arrKlienten = (dsKlientenliste.vKlientenlisteRow[])PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.Select("IDAbteilung='" + IDAbteilung.ToString() + "' and IDBereich='" + IDBereich.ToString() + "'", PMDSBusinessRAM.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " asc");
                    return arrKlienten;
                }
                else
                {
                    throw new Exception("PMDSBusinessRAM.getPatientenStart: IDAbteilung or IDBereich nbot allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getPatientenStart: " + ex.ToString());
            }
        }
        public void getAllUsersKlinikOld(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDKlinik, ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                var tBenutzer4 = (from b in db.Benutzer
                                  join ba in db.BenutzerAbteilung on b.ID equals ba.IDBenutzer
                                  join a in db.Abteilung on ba.IDAbteilung equals a.ID
                                  where a.IDKlinik == IDKlinik
                                  orderby b.Nachname ascending, b.Vorname ascending
                                  select new { IDBenutzer = b.ID }).Distinct().ToList();

                foreach (var rBenutzer in tBenutzer4)
                {
                    lstBenutzerReturn.Add(rBenutzer.IDBenutzer);
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllUsersKlinik()"), 100300);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllUsersKlinik: " + ex.ToString());
            }
        }
        public bool getAllUsersForAbteilungOld(Nullable<Guid> IDAbteilung, Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db,
                                            ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                //IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = db.BenutzerAbteilung.Where(o => o.IDAbteilung == IDAbteilung);
                //foreach (BenutzerAbteilung rBenutzerAbteilung in tBenutzerAbteilung)
                //{
                //    if (!lstBenutzerReturn.Contains(rBenutzerAbteilung.IDBenutzer))
                //    {
                //        lstBenutzerReturn.Add(rBenutzerAbteilung.IDBenutzer);
                //    }
                //}

                var tUsers = (from ba in db.BenutzerAbteilung
                              join a in db.Abteilung on ba.IDAbteilung equals a.ID
                              join ben in db.Benutzer on ba.IDBenutzer equals ben.ID
                              orderby ben.Nachname ascending, ben.Vorname ascending
                              where a.IDKlinik == IDKlinik && a.ID == IDAbteilung
                              select new { IDBenutzer = ba.IDBenutzer }).Distinct().ToList();

                foreach (var ben in tUsers)
                {
                    lstBenutzerReturn.Add(ben.IDBenutzer);
                }


                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllUsersForAbteilung()"), 100301);
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllUsersForAbteilung: " + ex.ToString());
            }
        }
        public bool getAllUsersForBereichOld(Nullable<Guid> IDBereich, Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db,
                                    ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                var tBenutzer4 = (from bb in db.BereichBenutzer
                                  join b in db.Bereich on bb.IDBereich equals b.ID
                                  join a in db.Abteilung on b.IDAbteilung equals a.ID
                                  join ben in db.Benutzer on bb.IDBenutzer equals ben.ID
                                  where a.IDKlinik == IDKlinik && b.ID == IDBereich
                                  orderby ben.Nachname ascending, ben.Vorname ascending
                                  select new { IDBenutzer = bb.IDBenutzer }).Distinct().ToList();

                foreach (var rBenutzer in tBenutzer4)
                {
                    lstBenutzerReturn.Add(rBenutzer.IDBenutzer);
                }

                //IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = db.BereichBenutzer.Where(o => o.IDBereich == IDBereich);
                //foreach (BereichBenutzer rBereichBenutzer in tBereichBenutzer)
                //{
                //    if (!lstBenutzerReturn.Contains(rBereichBenutzer.IDBenutzer))
                //    {
                //        lstBenutzerReturn.Add(rBereichBenutzer.IDBenutzer);
                //    }
                //}

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.getAllUsersForBereich()"), 100302);
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessRAM.getAllUsersForBereich: " + ex.ToString());
            }
        }

    }
    
}
