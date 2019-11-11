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

//using Ghostscript.NET;
//using Ghostscript.NET.Rasterizer;
using PMDS.Global.db.ERSystem;
using System.Linq;


using Patagames.Pdf.Net;        //https://www.youtube.com/watch?v=IF9cKSUFon8
using Patagames.Pdf.Enums;
//using System.Drawing.Imaging;

namespace PMDS.DB
{
    

    public class PMDSBusiness
    {
        public class PEs
        {
            public Guid IDPe { get; set; }
            public Guid IDBenutzer { get; set; }
            public Guid IDAufenthalt { get; set; }

        }



        public class retBusiness
        {
            public bool OK = false;
            public int countTermineFound = 0;
            public PMDS.Global.db.ERSystem.dsTermine.vInterventionenDataTable tInerventionen = null;
            public PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rvIntervention = null;
        }

        public static System.Collections.Generic.List<Guid> lstBerufsgruppenUserCanSign = new List<Guid>();

        public PMDS.Global.db.ERSystem.sqlTermine sqlTermine1 = null;
        public string sqlvInterventionen = "";
        public string sqlvÜbergabe = "";

        public static Guid IDVOStatusVorgemerkt = new System.Guid("00000000-0000-0000-0001-000000000015");
        public static Guid IDVOStatusBestellt = new System.Guid("00000000-0000-0000-0002-000000000015");
        public static Guid IDVOStatusGeliefert = new System.Guid("00000000-0000-0000-0003-000000000015");
        public static Guid IDVOStatusStorniert = new System.Guid("00000000-0000-0000-0004-000000000015");

        public static int _iFctCalled = 0;
        public bool isinitialized = false;


        public class cMedikament 
        {

            public string Medikament { get; set; }

            public Guid IDMedikament { get; set; }

        }

        public static System.Collections.Generic.Dictionary<DateTime, cClassExeptHandlerServerNotReachable> lstExeptHandlerServerNotReachable = new Dictionary<DateTime, cClassExeptHandlerServerNotReachable>();
        public class cClassExeptHandlerServerNotReachable
        {
            public DateTime IDTime = DateTime.Now;
            public int iFctCalled = 0;
        }

        public class DataFormular
        {
            public Guid key { get; set; }
            public int cnt { get; set; }
        }















        public class cField
        {
            public Nullable<System.Guid> ID = null;
            public bool BestellenJN = false;
            public bool Dringend = false;
            public DateTime ZuletztBestelltAm = DateTime.MinValue;
            public Guid ZuletztBestelltVon;
            public Infragistics.Win.UltraWinGrid.UltraGridRow rGrid = null;
            public int Packungsanzahl = -1;
        }

        public class cZeitpunkte
        {
            public Nullable<DateTime> ZeitpunktVonUI = null;
            public Nullable<DateTime> ZeitpunktBisUI = null;
            public Nullable<DateTime> ZuErledigenBis = null;
            public Nullable<System.Guid> IDZeitbereich = null;
            public string Anmerkung = "";
            public System.Guid IDPlegeplan = System.Guid.Empty;
        }
        public enum cModeDb
        {
            Insert = 0,
            Update = 1,
            Beenden = 2,

            none
        }
        
        public class cPdx
        {
            public PDxSelectionArgs pdx = null;
            public System.Collections.Generic.List<cASZM> lstAszm = new System.Collections.Generic.List<cASZM>();
            public bool AnyEditedAszmFound = false;
        }
        public class cASZM
        {
            public ASZMSelectionArgs Aszm = null;
            public cPdx pdx = null;
        }
        public class cListDoubledTmp
        {
            public System.Guid IDEintrag;
            public System.Collections.Generic.List<cDoubledTmp> lstDoubledTmp = new System.Collections.Generic.List<cDoubledTmp>();
            public bool LokalisierungJN = false;
            public cASZM AszmLokalisierung = null;
        }
        public class cDoubledTmp
        {
            public cASZM aszm = null;
            public System.Guid IDUI;
            public bool IsLast = false;
        }
        public class cListpflegepläne
        {
            public System.Collections.Generic.List<PMDS.db.Entities.PflegePlan> lstPflegepläne = new System.Collections.Generic.List<PMDS.db.Entities.PflegePlan>();
        }
        public class cInfoPdx
        {
            public string PDxBezeichnung = "";
            public Guid IDPDx;
        }
        public enum eModeUpdateNächstesDatum
        {
            GesamteDatenbank = 0,
            Abteilung = 1,
            Klient = 2,
            IDPflegeplan = 3
        }

        public class cPMDSList
        {
            public string sText = "";
            public string sDescription = "";
            public Guid IDPatient = System.Guid.Empty;
            public Guid IDAufenthalt = System.Guid.Empty;
        }
        public class cMedTypDatenCopy
        {
            public PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes = new UIGlobal.eSelectedNodes();
            public Guid IDMedDatenOrig2 = System.Guid.Empty;
            public Guid IDPatientOrig2 = System.Guid.Empty;
        }
        public class cSysUpdateData2
        {
            public Guid IDPatient;
            public string PatientName = "";

            public Guid IDAufenthalt;
            public Guid IDAbteilung;
            public Nullable<Guid> IDBereich;
        }


        public delegate void dShowInfoDelegate(string sInfo);
        public static event dShowInfoDelegate dShowInfo2;
        public static Guid IDSelListDienstübergabe = new System.Guid("00000000-0000-0000-0002-000000000006");

        public class cÄrzteMehrfachauswahl
        {
            public Nullable<Guid> IDÄrzteMehrfachauswahl = null;
            public Nullable<Guid> IDÄrztePatientMehrfachauswahl = null;
            public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected2 = new List<PMDS.Global.UIGlobal.eSelectedNodes>();

            public bool HausarztJN2 = false;
            public bool HausarztELGAJN = false;
            public bool ZuweiserJN = false;
            public bool AufnahmearztJN = false;
            public bool BehandelnderFAJN = false;
            public Nullable<DateTime> Von = null;

        }

        public class cVerordnungen
        {
            public Guid ID;
            public Guid IDAufenthalt;
            public Guid IDMedikament;
            public Guid Typ;
            public double Menge;
            public string Hinweis = "";
            public DateTime DatumVerordnetAb;
            public Nullable<DateTime> DatumVerodnetBis = null;
            public string BestaetigtVon = "";
            public DateTime DatumErstellt;
            public Guid IDBenutzerErstellt;
            public string LoginNameFreiErstellt = "";
            public DateTime DatumGeaendert;
            public Guid IDBenutzerGeaendert;
            public string LoginNameFreiGeaendert = "";

            public Guid IDPflegeplan;
            public Guid IDPflegeplanPDX;
        }












        public PMDSBusiness()
        {
            

        }


        public void initControl()
        {
            try
            {
                if (!this.isinitialized)
                {
                    this.sqlTermine1 = new PMDS.Global.db.ERSystem.sqlTermine();
                    this.sqlvInterventionen = this.sqlTermine1.davInterventionen.SelectCommand.CommandText;
                    this.sqlvÜbergabe = this.sqlTermine1.davÜbergabe.SelectCommand.CommandText;

                    this.isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.initControl: " + ex.ToString());
            }
        }
        
        public bool getTermine(ref PMDS.Global.eUITypeTermine UITypeTermine, System.Guid IDKlinik,
                                                            ref TerminlisteAnsichtsmodi Ansichtsmodi,
                                                            ref DBTerminePara dbPar,
                                                            ref PMDS.Global.db.ERSystem.dsTermine ds, 
                                                            ref string SqlCommand,
                                                            ref  PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste, ref List<Guid> lstKlienten, int iFctCalled = 0)
        {
            string sInfoExcept = "";
            try
            {
                if (UITypeTermine == eUITypeTermine.Interventionen)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                    PMDSBusiness1.getInterventionen(ref ds, ref dbPar, ref IDKlinik, ref UITypeTermine, ref SqlCommand, ref dsKlientenliste, ref lstKlienten);
                    sInfoExcept = SqlCommand;
                }
                else if (UITypeTermine == eUITypeTermine.Übergabe || UITypeTermine == eUITypeTermine.Dekurs)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                    PMDSBusiness1.getÜbergabe(ref ds, ref dbPar, ref IDKlinik, ref UITypeTermine, ref SqlCommand, ref dsKlientenliste, ref lstKlienten);
                    sInfoExcept = SqlCommand;
                }
                else
                {
                    throw new Exception("Termine.getTermine: " + "UITypeTermine '" + UITypeTermine.ToString() + "' not allowed!");
                }

                return true;

            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib2(ex.ToString()) && iFctCalled < 4)
                {
                    try
                    {
                        iFctCalled += 1;
                        if (iFctCalled >= 3)
                        {
                            Exception exTmp2 = new Exception("PMDSBusiness.getTermine: " + iFctCalled.ToString() + "th retry" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        }
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        return this.getTermine(ref UITypeTermine, IDKlinik, ref Ansichtsmodi, ref dbPar, ref ds, ref SqlCommand, ref dsKlientenliste, ref lstKlienten, iFctCalled);
                    }
                    catch (Exception ex2)
                    {
                        PMDS.Global.ENV.checkExceptionDBNetLib(ex2.ToString());
                        throw new Exception("PMDSBusiness.getTermine: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                    }
                }
                else
                {
                    throw new Exception("PMDSBusiness.getTermine: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        public void getInterventionen(ref PMDS.Global.db.ERSystem.dsTermine ds, ref DBTerminePara para, ref System.Guid IDKlinik,
                                        ref PMDS.Global.eUITypeTermine UITypeTermine, ref string SqlCommand,
                                        ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste, ref List<Guid> lstKlienten)
        {
            try
            {
                this.initControl();
                
                this.sqlTermine1.davInterventionen.SelectCommand.CommandText = this.sqlvInterventionen;
                this.sqlTermine1.davInterventionen.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.sqlTermine1.davInterventionen, RBU.DataBase.CONNECTION);

                System.Collections.Generic.List<OleDbParameter> lstPar = new System.Collections.Generic.List<OleDbParameter>();
                string sqlWhere = "";
                this.getWhereTermine(para, IDKlinik, ref sqlWhere, false, ref UITypeTermine, ref lstPar, ref dsKlientenliste, ref lstKlienten);
                this.sqlTermine1.davInterventionen.SelectCommand.CommandText += " " + sqlWhere;
                foreach(OleDbParameter arFound in lstPar)
                {
                    this.sqlTermine1.davInterventionen.SelectCommand.Parameters.Add(arFound);
                    SqlCommand += arFound.ParameterName + "\r\n" + arFound.Value.ToString() + "\r\n" + "\r\n";
                }
                this.sqlTermine1.davInterventionen.SelectCommand.CommandTimeout = 0;
                SqlCommand = this.sqlTermine1.davInterventionen.SelectCommand.CommandText + "\r\n" + "\r\n" + SqlCommand;

                this.sqlTermine1.davInterventionen.Fill(ds.vInterventionen);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getInterventionen: " + ex.ToString());
            }
        }

        public bool getInterventionenByIDs(ref List<Guid> lstInverventionen, bool bWriteLog, ref PMDS.Global.db.ERSystem.dsTermine dsTermineBack)
        {
            try
            {
                string sWhereIDsPP = "";
                if (lstInverventionen.Count == 0)
                {
                    throw new Exception("PMDSBusiness.getInterventionenByIDs: lstInverventionen.Count=0 not allowed!");
                }

                foreach (Guid IDPflegeplan in lstInverventionen)
                {
                    sWhereIDsPP += (sWhereIDsPP.Trim() == "" ? " " : " or ") + "IDPflegeplan='" + IDPflegeplan.ToString() + "' ";
                }
                sWhereIDsPP = " where (" + sWhereIDsPP + ") ";

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                PMDS.Global.db.ERSystem.dsTermine dsTermine = new PMDS.Global.db.ERSystem.dsTermine();
                string sqlCommand = "";

                b.getInterventionenByIDs(ref dsTermine, ref sqlCommand, ref sWhereIDsPP);

                List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> arInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rI in dsTermine.vInterventionen)
                {
                    arInterventionen.Add(rI);
                }

                dsTermineBack = dsTermine;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getInterventionenByIDs: " + ex.ToString());
            }
        }

        public void getInterventionenByIDs(ref PMDS.Global.db.ERSystem.dsTermine ds, ref string SqlCommand, ref string sWhereIDsPflegeplan, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = DateTime.Now;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                this.initControl();

                this.sqlTermine1.davInterventionen.SelectCommand.CommandText = this.sqlvInterventionen;
                this.sqlTermine1.davInterventionen.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.sqlTermine1.davInterventionen, RBU.DataBase.CONNECTION);

                this.sqlTermine1.davInterventionen.SelectCommand.CommandText += " " + sWhereIDsPflegeplan;
                this.sqlTermine1.davInterventionen.SelectCommand.CommandTimeout = 0;
                SqlCommand = this.sqlTermine1.davInterventionen.SelectCommand.CommandText + "\r\n" + "\r\n" + SqlCommand;

                this.sqlTermine1.davInterventionen.Fill(ds.vInterventionen);
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusiness.writeDekurs"))
                {
                    this.getInterventionenByIDs(ref ds, ref SqlCommand, ref sWhereIDsPflegeplan, IDTime);
                }
                throw new Exception("PMDSBusiness.getInterventionenByIDs: " + ex.ToString());
            }
        }

        public void getÜbergabe(ref PMDS.Global.db.ERSystem.dsTermine ds, ref DBTerminePara para, ref System.Guid IDKlinik,
                                ref PMDS.Global.eUITypeTermine UITypeTermine, ref string SqlCommand,
                                ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste, ref List<Guid> lstKlienten)
        {
            try
            {
                this.initControl();

                this.sqlTermine1.davÜbergabe.SelectCommand.CommandText = this.sqlvÜbergabe;
                this.sqlTermine1.davÜbergabe.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.sqlTermine1.davÜbergabe, RBU.DataBase.CONNECTION);

                System.Collections.Generic.List<OleDbParameter> lstPar = new System.Collections.Generic.List<OleDbParameter>();
                string sqlWhere = "";
                this.getWhereTermine(para, IDKlinik, ref sqlWhere, true, ref UITypeTermine, ref lstPar, ref dsKlientenliste, ref lstKlienten);
                this.sqlTermine1.davÜbergabe.SelectCommand.CommandText += " " + sqlWhere;
                foreach (OleDbParameter arFound in lstPar)
                {
                    this.sqlTermine1.davÜbergabe.SelectCommand.Parameters.Add(arFound);
                    SqlCommand += arFound.ParameterName + "\r\n" + arFound.Value.ToString() + "\r\n" + "\r\n";
                }
                //System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("StartSqlExecute");
                this.sqlTermine1.davÜbergabe.SelectCommand.CommandTimeout = 0;
                SqlCommand = this.sqlTermine1.davÜbergabe.SelectCommand.CommandText + "\r\n" + "\r\n" + SqlCommand;

                //this.sqlTermine1.davÜbergabe.MissingSchemaAction = MissingSchemaAction.AddWithKey;     //Geht nicht, weil man dann nicht mehr gegenzeichnen kann!
                this.sqlTermine1.davÜbergabe.Fill(ds.vÜbergabe);
                //System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("EndSqlExecute");
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getÜbergabe: " + ex.ToString());
            }
        }

        public void getWhereTermine(DBTerminePara para, System.Guid IDKlinik,
                                ref string sqlWhere,
                                bool IsÜbergabe, ref PMDS.Global.eUITypeTermine UITypeTermine, ref System.Collections.Generic.List<OleDbParameter> lstPar,
                                ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste, ref List<Guid> lstKlienten)
        {
            try
            {
                if (para.OnlyIDPflegePlan)
                {
                    string sqlTmp = " IDPflegeplan='" + para.IDPflegePlan.ToString() + "' ";
                    this.addToSqlWhere(ref sqlWhere, ref sqlTmp, false);
                }
                else
                {
                    if (IDKlinik == null)
                    {
                        throw new Exception("getWhereTermine: IDKlinik == null !");
                    }
                    if (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
                    {
                        string sqlTmp = " IDKlinik='" + IDKlinik.ToString() + "' ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        //sqlTmp = " UrlaubJN=0 ";
                        //this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        sqlTmp = " EntlassenJN=0 ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        sqlTmp = " AbgesetztJN=0 ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        sqlTmp = " ErledigtJN=0 ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        //sqlTmp = " MitPflegediagnoseAbzeichnenJN=0 ";
                        //this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        sqlTmp = " GelöschtJN=0 ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);

                        db.Entities.Benutzer usr = this.LogggedOnUser();
                        sqlTmp = " (privatJN=0 or (privatJN=1 and IDBerufsstand='" + usr.IDBerufsstand.ToString() + "'))";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                    }
                    else
                    {
                        string sqlTmp = " IDKlinik='" + IDKlinik.ToString() + "' ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                    }

                    if (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
                    {
                        string sqlWhereDatFromTo = "";
                        string sqlWhereÜberfällige = "";

                        if (!this.checkDateNull(ref para.From))
                        {
                            string sqlTmp = " Startdatum >= ? ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatFromTo, true);
                            lstPar.Add(new System.Data.OleDb.OleDbParameter("Startdatum", para.From));
                        }
                        if (!this.checkDateNull(ref para.To))
                        {
                            string sqlTmp = " Startdatum <= ? ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatFromTo, true);
                            lstPar.Add(new System.Data.OleDb.OleDbParameter("Startdatum", para.To));
                        }

                        string sqlWhereDatSumTmp = "";
                        if (para.ShowÜberfällige)
                        {
                            string sqlTmp2 = " Startdatum < ? ";
                            this.addToSqlWhere(ref sqlTmp2, ref sqlWhereÜberfällige, true);
                            lstPar.Add(new System.Data.OleDb.OleDbParameter("Startdatum", para.To));

                            if (sqlWhereDatFromTo.Trim() != "")     //lthxy -> Erl - Fehler Interventionsliste  OneNote
                            {
                                string sqlTmp = " ((" + sqlWhereDatFromTo + ") or " + sqlWhereÜberfällige + ") ";
                                this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatSumTmp, true);
                             }
                            else
                            {
                                string sqlTmp = " (" + sqlWhereÜberfällige + ") ";
                                this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatSumTmp, true);
                            }
                        }
                        else
                        {
                            if (sqlWhereDatFromTo.Trim() != "")
                            {
                                string sqlTmp = " (" + sqlWhereDatFromTo + ") ";
                                this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatSumTmp, true); 
                            }
                        }
                        string sqlWhereDatSumTmp2 = "";
                        if (para.ShowOhneZeitbezugOhneUI)
                        {
                            string sqlWhereDatUngeplante = " (Von='' and Startdatum<=? )";              //" (Von='' and Startdatum<=? )";'
                            lstPar.Add(new System.Data.OleDb.OleDbParameter("Startdatum", para.To));
                            string sqlTmp = " (( " + sqlWhereDatSumTmp + ")  or " + sqlWhereDatUngeplante + ") ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatSumTmp2, true);
                        }
                        else
                        {
                            string sqlTmp = " Von<>'' ";                                    // Für UI nicht relevant -> Für Fkt getOpenTermine
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhereDatSumTmp, true);
                            sqlWhereDatSumTmp2 = sqlWhereDatSumTmp;
                        }
                        if (sqlWhereDatSumTmp2.Trim() != "")
                        {
                            this.addToSqlWhere(ref sqlWhereDatSumTmp2, ref sqlWhere, false);
                        }
                        PMDS.db.Entities.vInterventionen vInterventionen1 = new db.Entities.vInterventionen();

                        if (para.ZeitbezugJN)
                        {
                            {
                                if (para.Zeitbezug.Count > 0)
                                {
                                    string sqlLst = "";
                                    foreach (int IDZeitbezug in para.Zeitbezug)
                                    {
                                        string sqlTmp = "";
                                        if (IDZeitbezug == 0)
                                        {
                                            sqlTmp = " OhneZeitbezugJN=0 ";
                                            this.CombineSql(ref sqlLst, ref sqlTmp, "or");
                                        }
                                        else if (IDZeitbezug == 1)
                                        {
                                            sqlTmp = " OhneZeitbezugJN=1 ";
                                            this.CombineSql(ref sqlLst, ref sqlTmp, "or");
                                        }
                                    }
                                    if (sqlLst.Trim() != "")
                                    {
                                        sqlLst = " (" + sqlLst + ") ";
                                        this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                                    }

                                    sqlLst = "";
                                    foreach (int IDZeitbezug in para.Zeitbezug)
                                    {
                                        string sqlTmp = "";
                                        if (IDZeitbezug == 2)
                                        {
                                            sqlTmp = " MitPflegediagnoseAbzeichnenJN=1 ";
                                            this.CombineSql(ref sqlLst, ref sqlTmp, "or");
                                        }
                                        else if (IDZeitbezug == 3)
                                        {
                                            sqlTmp = " MitPflegediagnoseAbzeichnenJN=0 ";
                                            this.CombineSql(ref sqlLst, ref sqlTmp, "or");
                                        }
                                    }
                                    if (sqlLst.Trim() != "")
                                    {
                                        sqlLst = " (" + sqlLst + ") ";
                                        this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                                    }
                                }
                            }
                        }
                        else
                        {
                            string sqlLst = " (" + "MitPflegediagnoseAbzeichnenJN=0 " + ") ";
                            this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                        }

                    }
                    else
                    {
                        if (!this.checkDateNull(ref para.From))
                        {
                            string sqlTmp = " ZeitpunktDatum >= ? ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                            lstPar.Add(new System.Data.OleDb.OleDbParameter("ZeitpunktDatum", para.From));
                        }
                        if (!this.checkDateNull(ref para.To))
                        {
                            string sqlTmp = " ZeitpunktDatum <= ? ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                            lstPar.Add(new System.Data.OleDb.OleDbParameter("ZeitpunktDatum", para.To));
                        }
                        if (para.Abzeichnen == 1)
                        {
                            string sqlTmp = " AbzeichnenJN=1 ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        }
                        else if (para.Abzeichnen == 0)
                        {
                            string sqlTmp = " AbzeichnenJN=0 ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        }
                        if (para.ShowCC == 1)
                        {
                            string sqlTmp = " CC=1 ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        }
                        else if (para.ShowCC == 0)
                        {
                            string sqlTmp = " CC=0 ";   //IDWichtigFür<>null
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        }
                    }



                    if (para.ansicht == PMDS.Global.TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                        if (dsKlientenliste != null)
                        {
                            string SqlWhereKlienten = "";
                            this.generateWhereKlienten(ref dsKlientenliste, ref SqlWhereKlienten);
                            this.addToSqlWhere(ref SqlWhereKlienten, ref sqlWhere, false);
                        }
                        if (lstKlienten != null)
                        {
                            if (lstKlienten.Count > 0)
                            {
                                string SqlWhereKlienten = "";
                                this.generateWhereLstKlienten(ref lstKlienten, ref SqlWhereKlienten);
                                this.addToSqlWhere(ref SqlWhereKlienten, ref sqlWhere, false);
                            }
                        }

                        if (!this.checkGuidEmpty(ref para.IDAbteilung))
                        {
                            if (!para.IDAbteilung.Equals(System.Guid.Empty) && (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen))
                            {
                                string sqlTmp = " IDAbteilung='" + para.IDAbteilung.ToString() + "' ";
                                this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                            }
                        }
                        if (!this.checkGuidEmpty(ref para.IDBereich))
                        {
                            if (!para.IDBereich.Equals(System.Guid.Empty) && (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen))
                            {
                                string sqlTmp = " IDBereich='" + para.IDBereich.ToString() + "' ";
                                this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);  
                            }
                        }
                    }
                    else if (para.ansicht == PMDS.Global.TerminlisteAnsichtsmodi.Klientanansicht)
                    {
                        if (para.IDAufenthalt == null)
                        {
                            throw new Exception("getWhereTermine: para.IDAufenthalt == null !");
                        }
                        if (!this.checkGuidEmpty(ref para.IDAufenthalt))
                        {
                            string sqlTmp = " IDAufenthalt='" + para.IDAufenthalt.ToString() + "' ";
                            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        }
                    }
                    else
                    {
                        throw new Exception("getWhereTermine: para.ansicht '" + para.ansicht.ToString() + "' not allowed");
                    }

                    //if (UITypeTermine == PMDS.Global.eUITypeTermine.Dekurs)
                    //{
                    //    string sqlTmp = " Eintragstyp=" + ((int)PMDS.Global.PflegeEintragTyp.DEKURS).ToString() + " ";
                    //    this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                    //}
                    //else
                    //{
                        //if (para.ShowPflegeEintragTyp)
                        //{
                        //    if (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
                        //    {
                        //        if (para.PflegeEintragTyp == PMDS.Global.PflegeEintragTyp.MASSNAHME)
                        //        {
                        //            string sqlTmp = " TerminJN=0 ";
                        //            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        //        }
                        //        else if (para.PflegeEintragTyp == PMDS.Global.PflegeEintragTyp.TERMIN)
                        //        {
                        //            string sqlTmp = " TerminJN=1 ";
                        //            this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        //        }
                        //        else
                        //        {
                        //            //throw new Exception("getWhereTermine: para.PflegeEintragTyp '" + para.PflegeEintragTyp.ToString() + "' not allowed");
                        //        }
                        //    }
                        //    else if (UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe)
                        //    {
                        //        string sqlTmp = " Eintragstyp=" + ((int)para.PflegeEintragTyp).ToString() + " ";
                        //        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                        //    }
                        //}
                    //}

                    if (para.aIDMaßnahme.Length > 0)
                    {
                        if (para.aIDMaßnahme.Length > 0)
                        {
                            string sqlLst = "";
                            foreach (Guid IMaßnahme in para.aIDMaßnahme)
                            {
                                string sqlTmp = " IDEintrag='" + IMaßnahme.ToString() + "' ";
                                if (sqlLst.Trim() == "")
                                {
                                    sqlLst += " " + sqlTmp + " ";
                                }
                                else
                                {
                                    sqlLst += " or " + sqlTmp + " ";
                                }
                            }
                            sqlLst = " (" + sqlLst + ") ";
                            this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                        }
                    }
                    if (para.BerufsstandJN)
                    {
                        if (para.Berufsstand.Count > 0)
                        {
                            string sqlLst = "";
                            foreach (Guid IDBerufsstand in para.Berufsstand)
                            {
                                string sqlTmp = "";
                                if (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
                                {
                                    sqlTmp = " IDBerufsstand='" + IDBerufsstand.ToString() + "' ";
                                }
                                else
                                {
                                    sqlTmp = " IDSollberufsstand='" + IDBerufsstand.ToString() + "' ";
                                }

                                if (sqlLst.Trim() == "")
                                {
                                    sqlLst += " " + sqlTmp + " ";
                                }
                                else
                                {
                                    sqlLst += " or " + sqlTmp + " ";
                                }
                            }
                            sqlLst = " (" + sqlLst + ") ";
                            this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                        }
                    }
                    if (UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen ||
                        UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe)
                    {
                        if (para.PlanungsEinträgeJN) 
                        {
                            if (para.PlanungsEinträge.Count > 0)
                            {
                                string sqlLst = "";
                                foreach (int IDInterventionstyp in para.PlanungsEinträge)
                                {
                                    string sqlTmp = " Eintragstyp=" + IDInterventionstyp.ToString() + " ";
                                    if (sqlLst.Trim() == "")
                                    {
                                        sqlLst += " " + sqlTmp + " ";
                                    }
                                    else
                                    {
                                        sqlLst += " or " + sqlTmp + " ";
                                    }
                                }
                                sqlLst = " (" + sqlLst + ") ";
                                this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                            }
                        }
                    }
                    else
                    {
                        string sqlTmp = " Eintragstyp=" + ((int)PMDS.Global.PflegeEintragTyp.DEKURS).ToString() + " ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                    }

                    if (UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe ||
                        UITypeTermine == PMDS.Global.eUITypeTermine.Dekurs)
                    {
                        if (para.ZusatzwerteJN) 
                        {
                            if (para.Zusatzwerte.Count > 0)
                            {
                                string sqlLst = "";
                                foreach (string IDZusatzwert in para.Zusatzwerte)
                                {
                                    string sqlTmp = " lstIDZusatzwerte like '%" + IDZusatzwert.ToString() + "%' ";
                                    if (sqlLst.Trim() == "")
                                    {
                                        sqlLst += " " + sqlTmp + " ";
                                    }
                                    else
                                    {
                                        sqlLst += " or " + sqlTmp + " ";
                                    }
                                }
                                sqlLst = " (" + sqlLst + ") ";
                                this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                            }
                        }
                        if (para.HerkunftPlanungsEintragJN)
                        {
                            if (para.HerkunftPlanungsEintrag.Count > 0)
                            {
                                string sqlLst = "";
                                foreach (int IDHerkunftPlanungsEintrag in para.HerkunftPlanungsEintrag)
                                {
                                    string sqlTmp = " Dekursherkunft=" + IDHerkunftPlanungsEintrag.ToString() + " ";
                                    if (sqlLst.Trim() == "")
                                    {
                                        sqlLst += " " + sqlTmp + " ";
                                    }
                                    else
                                    {
                                        sqlLst += " or " + sqlTmp + " ";
                                    }
                                }
                                sqlLst = " (" + sqlLst + ") ";
                                this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                            }
                        }
                    }
                    
                    if (UITypeTermine == PMDS.Global.eUITypeTermine.Übergabe ||
                        UITypeTermine == PMDS.Global.eUITypeTermine.Dekurs)
                    {
                        if (para.WichtigFürJN)
                        {
                            if (para.WichtigFür.Count > 0)
                            {
                                string sqlLst = "";
                                foreach (Guid IDWichtigFür in para.WichtigFür)
                                {
                                    string sqlTmp = " IDWichtigFür='" + IDWichtigFür.ToString() + "' ";
                                    if (sqlLst.Trim() == "")
                                    {
                                        sqlLst += " " + sqlTmp + " ";
                                    }
                                    else
                                    {
                                        sqlLst += " or " + sqlTmp + " ";
                                    }
                                }
                                sqlLst = " (" + sqlLst + ") ";
                                this.addToSqlWhere(ref sqlLst, ref sqlWhere, false);
                            }
                        }
                    }
                    if (para.BezugJN)
                    {
                        string sqlTmp = " IDBezug like '%" + para.IDBezug.ToString() + "%' ";
                        this.addToSqlWhere(ref sqlTmp, ref sqlWhere, false);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getWhereTermine: " + ex.ToString());
            }
        }

        public void CombineSql(ref string sqlLst, ref string sqlTmp, string Operand)
        {
            if (sqlLst.Trim() == "")
            {
                sqlLst += " " + sqlTmp + " ";
            }
            else
            {
                sqlLst += " " + Operand.Trim() + " " + sqlTmp + " ";
            }
        }
        public void generateWhereKlienten(ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste, ref string SqlWhereKlienten)
        {
            try
            {
                string SqlTmpFix = " IDKlient='" + System.Guid.NewGuid().ToString() + "' ";
                SqlWhereKlienten += SqlTmpFix;

                if (dsKlientenliste.vKlientenliste.Rows.Count > 0)
                {
                    int iCounter = 0;
                    foreach (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rvKlientenliste in dsKlientenliste.vKlientenliste)
                    {
                        string SqlTmp = " IDKlient='" + rvKlientenliste.IDKlient.ToString() + "' ";
                        if (SqlWhereKlienten.Trim() == "")
                        {
                            SqlWhereKlienten += SqlTmp;
                        }
                        else
                        {
                            SqlWhereKlienten += " or " + SqlTmp;
                        }
                    }
                }
                SqlWhereKlienten = " (" + SqlWhereKlienten + ") ";
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.generateWhereKlienten: " + ex.ToString());
            }
        }
        public void generateWhereLstKlienten(ref List<Guid> lstKlientenliste, ref string SqlWhereKlienten)
        {
            try
            {
                string SqlTmpFix = " IDKlient='" + System.Guid.NewGuid().ToString() + "' ";
                SqlWhereKlienten += SqlTmpFix;

                if (lstKlientenliste.Count > 0)
                {
                    int iCounter = 0;
                    foreach (Guid IDKlient in lstKlientenliste)
                    {
                        string SqlTmp = " IDKlient='" + IDKlient.ToString() + "' ";
                        if (SqlWhereKlienten.Trim() == "")
                        {
                            SqlWhereKlienten += SqlTmp;
                        }
                        else
                        {
                            SqlWhereKlienten += " or " + SqlTmp;
                        }
                    }
                }
                SqlWhereKlienten = " (" + SqlWhereKlienten + ") ";
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.generateWhereLstKlienten: " + ex.ToString());
            }
        }

        public void addToSqlWhere(ref string sqlTmp, ref string SqlWhere, bool onlyAnd)
        {
            if (SqlWhere.Trim() == "")
            {
                if (onlyAnd)
                {
                    SqlWhere += " " + sqlTmp + " ";
                }
                else
                {
                    SqlWhere += " where " + sqlTmp + " ";
                }
            }
            else
            {
                SqlWhere += " and " + sqlTmp + " ";
            }
        }
      
        
        
        public retBusiness EndPflegePlan(System.Guid IDPflegeplan, string sTextForPE, DateTime dNow, bool DoExcepIfIDPflegeplanNotFound,
                                         bool WritePE, bool PDXBeenden)
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                bool doSave = false;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.PflegePlan> tPflegeplan = db.PflegePlan.Where(pf => pf.ID == IDPflegeplan);
                    foreach (var rPflegeplan in tPflegeplan)
                    {
                        rPflegeplan.EndeDatum = dNow;
                        rPflegeplan.ErledigtGrund = sTextForPE;
                        if (PDXBeenden)
                        {
                            rPflegeplan.GeloeschtJN = true;
                        }
                        else
                        {
                            string xy = "";
                        }
                        if (rPflegeplan.EintragGruppe.Trim() == "T")
                        {
                            rPflegeplan.ErledigtJN = true;
                        }

                        //if (rPflegeplan.PflegePlanPDx.Count > 1)
                        //{
                        //    throw new Exception("PMDSBusiness.EndPflegeEintrag: rPflegeplan.PflegePlanPDx.Count > 0 for IDPflegeplan'" + IDPflegeplan.ToString() + "'");
                        //}

                        if (rPflegeplan.EintragGruppe.Trim() == "M" && PDXBeenden)
                        {
                            //if (rPflegeplan.PflegePlanPDx.Count > 0)
                            //{
                                IQueryable<PMDS.db.Entities.PflegePlanPDx> tPflegePlanPDx = db.PflegePlanPDx.Where(pf => pf.IDPflegePlan == rPflegeplan.ID);  //lthxy
                                foreach (PMDS.db.Entities.PflegePlanPDx rPflegePlanPDx in tPflegePlanPDx)
                                {
                                    rPflegePlanPDx.IDBenutzer_Beendet = rPflegeplan.IDBenutzer_Geaendert;
                                    rPflegePlanPDx.DatumBeendet = rPflegeplan.EndeDatum;
                                    rPflegePlanPDx.ErledigtJN = true;
                                    rPflegePlanPDx.ErledigtGrund = rPflegeplan.ErledigtGrund;
                                }
                            //}
                        }

                        if (WritePE)
                        {
                            var tAufenthaltxy = rPflegeplan.Aufenthalt;
                            PMDS.db.Entities.PflegePlanH rPflegePlanH = this.AddPflegePlanH(IDPflegeplan, sTextForPE, dNow, db, rPflegeplan, "C");
                            this.AddPflegeeintrag(db, "Planungsänderung: '" + rPflegeplan.Text + "" + "' wurde beendet!", dNow, (Guid)rPflegeplan.IDEintrag,
                                                (Guid)rPflegeplan.Aufenthalt.IDBereich, rPflegeplan.Aufenthalt.ID, rPflegeplan.ID,
                                                 PflegeEintragTyp.PLANUNG, rPflegePlanH.ID, (Guid)rPflegeplan.Aufenthalt.IDAbteilung, "Planungsänderung");
                        }

                        doSave = true;
                    }

                    if (doSave)
                    {
                        db.SaveChanges();
                    }
                }
                return retBusiness1;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.EndPflegeEintrag: " + ex.ToString());
            }
        }

        public void UpdateAufenthaltID(System.Guid IDAufenthalt, System.Guid IDBereich)
        {
            try
            {
                using(PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                    PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                    rAufenthalt.IDBereich = IDBereich;
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UpdateAufenthaltID: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.PflegePlanH AddPflegePlanH(System.Guid IDPflegeplan, string sTextForPE, DateTime dNow,
                                        PMDS.db.Entities.ERModellPMDSEntities db, PMDS.db.Entities.PflegePlan rPflegeplan,
                                            string Aktion)
        {
            try
            {
                PMDS.db.Entities.PflegePlanH rPflegePlanH = new PMDS.db.Entities.PflegePlanH();
                rPflegePlanH.ID = System.Guid.NewGuid();
                rPflegePlanH.Aktion = Aktion;
                rPflegePlanH.IDPflegePlan = IDPflegeplan ;
                rPflegePlanH.IDAufenthalt = rPflegeplan.IDAufenthalt ;
                rPflegePlanH.IDEintrag = rPflegeplan.IDEintrag;
                rPflegePlanH.IDBenutzer_Erstellt = rPflegeplan.IDBenutzer_Erstellt;          //this.LogggedOnUser().ID;  //new
                rPflegePlanH.IDBenutzer_Geaendert = rPflegeplan.IDBenutzer_Geaendert;
                rPflegePlanH.OriginalJN = rPflegeplan.OriginalJN;
                rPflegePlanH.DatumErstellt = rPflegeplan.DatumErstellt;
                rPflegePlanH.DatumGeaendert = rPflegeplan.DatumGeaendert;
                rPflegePlanH.StartDatum = rPflegeplan.StartDatum;
                rPflegePlanH.EndeDatum = rPflegeplan.EndeDatum;
                rPflegePlanH.LetztesDatum = rPflegeplan.LetztesDatum;
                rPflegePlanH.LetzteEvaluierung = rPflegeplan.LetzteEvaluierung;
                rPflegePlanH.Warnhinweis = rPflegeplan.Warnhinweis;
                rPflegePlanH.Anmerkung = rPflegeplan.Anmerkung;
                rPflegePlanH.ErledigtGrund = rPflegeplan.ErledigtGrund;
                rPflegePlanH.Text = rPflegeplan.Text;
                rPflegePlanH.Intervall = rPflegeplan.Intervall;
                rPflegePlanH.WochenTage = rPflegeplan.WochenTage;
                rPflegePlanH.IntervallTyp = rPflegeplan.IntervallTyp;
                rPflegePlanH.EvalTage = rPflegeplan.EvalTage;
                rPflegePlanH.IDBerufsstand = rPflegeplan.IDBerufsstand;
                rPflegePlanH.ParalellJN = rPflegeplan.ParalellJN;
                rPflegePlanH.Dauer = rPflegeplan.Dauer;
                rPflegePlanH.LokalisierungJN = rPflegeplan.LokalisierungJN;
                rPflegePlanH.EinmaligJN = rPflegeplan.EinmaligJN;
                rPflegePlanH.ErledigtJN = rPflegeplan.ErledigtJN;
                rPflegePlanH.GeloeschtJN = rPflegeplan.GeloeschtJN;
                rPflegePlanH.Lokalisierung = rPflegeplan.Lokalisierung;
                rPflegePlanH.LokalisierungSeite = rPflegeplan.LokalisierungSeite;
                rPflegePlanH.EintragGruppe = rPflegeplan.EintragGruppe;
                rPflegePlanH.PDXJN = rPflegeplan.PDXJN;
                rPflegePlanH.RMOptionalJN = rPflegeplan.RMOptionalJN;
                rPflegePlanH.IDEvaluierung = null;
                rPflegePlanH.NaechsteEvaluierung = rPflegeplan.NaechsteEvaluierung;
                rPflegePlanH.NaechsteEvaluierungBemerkung = rPflegeplan.NaechsteEvaluierungBemerkung;
                rPflegePlanH.OhneZeitBezug = rPflegeplan.OhneZeitBezug;
                rPflegePlanH.IDZeitbereich = rPflegeplan.IDZeitbereich;
                rPflegePlanH.ZuErledigenBis = rPflegeplan.ZuErledigenBis;
                rPflegePlanH.EintragFlag = rPflegeplan.EintragFlag;
                rPflegePlanH.IDBefund = rPflegeplan.IDBefund;

                db.PflegePlanH.Add(rPflegePlanH);
                
                return rPflegePlanH;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.AddPflegePlanH: " + ex.ToString());
            }
        }

        // Patient Entlassung Dekurs schreiben
        public void EntlassungWriteDekurs(Guid IDAufenthalt, Guid IDAbteilung, Guid IDBereich, Guid IDKlinik, DateTime Entlassungszeitpunkt, string sDekurstext)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                        this.AddPflegeeintrag(db, sDekurstext, Entlassungszeitpunkt, null, IDBereich,
                                        IDAufenthalt, null, PflegeEintragTyp.PLANUNG,
                                        null, IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassung"));           
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.EntlassungWriteDekurs: " + ex.ToString());
            }
        }


        
        // Patient Abwesenheit Ende
        public retBusiness AbwesenheitsEnde(Guid IDPatient, Guid IDAufenthalt, DateTime Urlaubsende, System.Guid IDKlinik, string sText)
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.PflegePlan> tPlegeplan = db.PflegePlan.Where(pp => pp.IDAufenthalt == IDAufenthalt && (pp.EintragGruppe == "M" || pp.EintragGruppe == "T") &&
                                                                                                pp.ErledigtJN == false &&
                                                                                                pp.GeloeschtJN == false && (pp.NächstesDatum == null || pp.NächstesDatum < Urlaubsende));

                    //IQueryable<PMDS.db.Entities.PflegePlan> tPlegeplan = db.PflegePlan.Where(pp => pp.IDAufenthalt == IDAufenthalt && (pp.EintragGruppe == "M" || pp.EintragGruppe == "T"));
                    foreach (PMDS.db.Entities.PflegePlan rPflegePlan in tPlegeplan)
                    {
                        if (rPflegePlan.EintragGruppe == "M")               //os 140314: Nur geplante Maßnahmen neu ansetzen. Termine bleiben in der Vergangenheit
                        {
                            DateTime dNächstesDatum = Urlaubsende;
                            DateTime dTmpStartdatum = new DateTime(Urlaubsende.Year, Urlaubsende.Month, Urlaubsende.Day, ((DateTime)rPflegePlan.StartDatum).Hour, ((DateTime)rPflegePlan.StartDatum).Minute, 0);

                            if (dTmpStartdatum < Urlaubsende)           //os 2013-10-11 Wenn hh:mm des Pflegeplans vor dem Rückkehrzeitpunkt liegt, kann die früheste Ausführung erst am tag nach der Rückkehr liegen.
                            {
                                dTmpStartdatum = dTmpStartdatum.AddDays(1);
                            }
                        
                            this.getNextDatePlanungsänderung(dTmpStartdatum, rPflegePlan.ID, ref dNächstesDatum, rPflegePlan.OhneZeitBezug, 
                                            (int)rPflegePlan.WochenTage, rPflegePlan.ID, (DateTime) rPflegePlan.StartDatum );
                            rPflegePlan.NächstesDatum = dNächstesDatum;
                            retBusiness1.countTermineFound += 1; 
                        }
                    }

                    PMDS.db.Entities.Benutzer rUsr = this.LogggedOnUser();

                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                    PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();

                    rAufenthalt.IDUrlaub = null;
                    if (retBusiness1.countTermineFound > 0)
                    {
                        this.AddPflegeeintrag(db, sText + QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Alle Maßnahmen ab Wiederaufnahmezeitpunkt wurden neu geplant!"), Urlaubsende, null, rAufenthalt.IDBereich,
                                        IDAufenthalt, null, PflegeEintragTyp.PLANUNG,
                                        null, rAufenthalt.IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung")); 
                    }
                    else
                    {
                        this.AddPflegeeintrag(db, sText + QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Es waren keine Maßnahmen geplant."), Urlaubsende, null, rAufenthalt.IDBereich,
                                                IDAufenthalt, null, PflegeEintragTyp.DEKURS,
                                                null, rAufenthalt.IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsende")); 
                    }
                    rAufenthalt.AbwesenheitBeendet = true;

                    db.SaveChanges();
                }
                return retBusiness1;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.EndTermine: " + ex.ToString());
            }
        }
        
        // Patient Entlassung, Urlaub bzw. Versetzung
        public retBusiness getOpenTermine(Guid IDPatient, Guid IDAufenthalt, DateTime Day, System.Guid IDKlinik)
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                PMDS.Global.db.ERSystem.dsTermine ds = new PMDS.Global.db.ERSystem.dsTermine();
                PMDS.Global.eUITypeTermine UITypeTermine = eUITypeTermine.Interventionen;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    DBTerminePara dbPar = new DBTerminePara();
                    dbPar.From = DateTime.MinValue;
                    dbPar.To = Day;
                    dbPar.IDAufenthalt = IDAufenthalt;
                    dbPar.ansicht = TerminlisteAnsichtsmodi.Klientanansicht;    //lthok erledigt   filter ohne zeitbezug lesen   >> für entlassung, usw
                    dbPar.ShowOhneZeitbezugOhneUI = false;
                    string SqlCommand = "";
   
                    PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenlisteNull = null;
                    List<Guid> LstKlienten = null;
                    PMDSBusiness1.getInterventionen(ref ds, ref dbPar, ref IDKlinik, ref UITypeTermine, ref SqlCommand, ref dsKlientenlisteNull, ref LstKlienten);
                    retBusiness1.tInerventionen = ds.vInterventionen;
                    retBusiness1.countTermineFound = ds.vInterventionen.Count;
                    return retBusiness1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CheckTermineNotDone: " + ex.ToString());
            }
        }
        public retBusiness getOnePflegeplanxy(Guid IDPflegeplan, System.Guid IDKlinik)     //not testesd
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                DateTime dNow = DateTime.Now;

                PMDS.Global.db.ERSystem.dsTermine ds = new PMDS.Global.db.ERSystem.dsTermine();
                PMDS.Global.eUITypeTermine UITypeTermine = eUITypeTermine.Interventionen;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    DBTerminePara dbPar = new DBTerminePara();
                    dbPar.From = DateTime.MinValue;
                    dbPar.OnlyIDPflegePlan = true;
                    dbPar.IDPflegePlan = IDPflegeplan;
                    dbPar.ansicht = TerminlisteAnsichtsmodi.Klientanansicht;
                    string SqlCommand = "";
                    PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenlisteNull = null;
                    List<Guid> LstKlienten = null;
                    PMDSBusiness1.getInterventionen(ref ds, ref dbPar, ref IDKlinik, ref UITypeTermine, ref SqlCommand, ref dsKlientenlisteNull, ref LstKlienten);
                    retBusiness1.tInerventionen = ds.vInterventionen;
                    retBusiness1.rvIntervention = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow)ds.vInterventionen.Rows[0];
                    return retBusiness1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getOnePflegeplan: " + ex.ToString());
            }
        }
        public bool KlientIsAbwesend(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDAufenthalt)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                foreach (PMDS.db.Entities.UrlaubVerlauf rUrlaub in rAufenthalt.UrlaubVerlauf)
                {
                    if (rUrlaub.EndeDatum == null)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.KlientIsAbwesend: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.UrlaubVerlauf getOffenenUrlaub(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDAufenthalt)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                foreach (PMDS.db.Entities.UrlaubVerlauf rUrlaub in rAufenthalt.UrlaubVerlauf)
                {
                    if (rUrlaub.EndeDatum == null)
                    {
                        return rUrlaub;
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getOffenenUrlaub: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.UrlaubVerlauf getOffenenUrlaub(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDAufenthalt, ref bool IsAbwesend)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf = db.UrlaubVerlauf.Where(a => a.IDAufenthalt == IDAufenthalt);
                PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();

                IsAbwesend = false;
                int iCounterEndeNull = 0;
                PMDS.db.Entities.UrlaubVerlauf rUrlaubReturn = null;
                foreach (PMDS.db.Entities.UrlaubVerlauf rUrlaub in tUrlaubVerlauf)
                {
                    if (rUrlaub.EndeDatum == null)
                    {
                        iCounterEndeNull += 1;
                        rUrlaubReturn = rUrlaub;
                        IsAbwesend = true;
                    }
                }
                if (iCounterEndeNull > 1)
                {
                    throw new Exception("getOffenenUrlaub: (iCounterEndeNull > 0) not allowed for IDAufenthalt '" + IDAufenthalt.ToString() + "'!");
                }
                return rUrlaubReturn;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getOffenenUrlaub: " + ex.ToString());
            }
        }

        public void sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb(ref int iCountUpdated, ref string protxy,
                                                                                PMDS.Global.db.ERSystem.FrmStatusAndProtocoll frmStatus,
                                                                                ref eModeUpdateNächstesDatum ModeUpdateNächstesDatum,
                                                                                Guid IDPflegeplan)
        {
            try
            {
                if (frmStatus != null)
                {
                    frmStatus.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Update Nächstes Datum für ges. Db");    
                    //frmStatus.TopMost = true;
                    frmStatus.Show();
                }
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    bool bSaveChanges = false;
                    var objectContext = (db as IObjectContextAdapter).ObjectContext;
                    objectContext.CommandTimeout = 120;
                    
                    //IQueryable<PMDS.db.Entities.PflegeEintrag> tAllPflegeEintrag = db.PflegeEintrag;
                    //int xyxyxyxy = tAllPflegeEintrag.Count();
                    int iCounter = 0;
                    if (ModeUpdateNächstesDatum == eModeUpdateNächstesDatum.GesamteDatenbank)
                    {
                        IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.OrderBy(p => p.Nachname);
                        foreach (PMDS.db.Entities.Patient rPatient in tPatient)
                        {
                            this.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb2(ref iCountUpdated, ref protxy, ref frmStatus, ref ModeUpdateNächstesDatum,
                                                                                                db, rPatient.ID, ref bSaveChanges, ref iCounter);
                        }
                    }
                    else if (ModeUpdateNächstesDatum == eModeUpdateNächstesDatum.Abteilung)
                    {
                        DbParameter[] args = new DbParameter[]{};
                        System.Data.Entity.Infrastructure.DbSqlQuery<PMDS.db.Entities.Patient> tPatient2 = db.Patient.SqlQuery("SELECT Patient.* FROM dbo.Aufenthalt INNER JOIN dbo.Patient ON dbo.Aufenthalt.IDPatient = dbo.Patient.ID " +
                                                                        "where dbo.Aufenthalt.idAbteilung='"+ ENV.CurrentIDAbteilung.ToString() +"' and dbo.Aufenthalt.Entlassungszeitpunkt is null", args);
                        int i = tPatient2.Count();
                        foreach (PMDS.db.Entities.Patient rPatient in tPatient2)
                        {
                            this.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb2(ref iCountUpdated, ref protxy, ref frmStatus, ref ModeUpdateNächstesDatum,
                                                                                                db, rPatient.ID, ref bSaveChanges, ref iCounter);
                        }
                    }
                    else if (ModeUpdateNächstesDatum == eModeUpdateNächstesDatum.Klient)
                    {
                        IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(p => p.ID == ENV.CurrentIDPatient);
                        PMDS.db.Entities.Patient rPatient = tPatient.First();
                        this.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb2(ref iCountUpdated, ref protxy, ref frmStatus, ref ModeUpdateNächstesDatum,
                                                                                            db, rPatient.ID, ref bSaveChanges, ref iCounter);
                    }
                    else if (ModeUpdateNächstesDatum == eModeUpdateNächstesDatum.IDPflegeplan)
                    {
                    //    IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = db.PflegePlan.Where(p => p.ID == IDPflegeplan);
                    //    PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlan.First();
                    //    this.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb2(ref iCountUpdated, ref protxy, ref frmStatus, ref ModeUpdateNächstesDatum,
                    //                                                db, rPatient.ID, ref bSaveChanges, ref iCounter);  //lthxy

                    }

                    if (bSaveChanges)
                    {
                        if (frmStatus != null)
                        {
                            frmStatus.lblStatus.Text = "Start saving changes! (" + iCountUpdated.ToString() + ")";
                            System.Windows.Forms.Application.DoEvents();
                        }
               
                        System.Windows.Forms.Application.DoEvents();
                        db.SaveChanges();
                        //prot += "changes saved " + iCountUpdated.ToString() + "\r\n";
                        if (frmStatus != null)
                        {
                            frmStatus.lblStatus.Text = "All changes saved!";
                            System.Windows.Forms.Application.DoEvents();
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb: " + ex.ToString());
            }
        }
        public void sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb2(ref int iCountUpdated, ref string protxy,
                                                                                ref PMDS.Global.db.ERSystem.FrmStatusAndProtocoll frmStatus,
                                                                                ref eModeUpdateNächstesDatum ModeUpdateNächstesDatum,
                                                                                PMDS.db.Entities.ERModellPMDSEntities db, System.Guid IDPatient, 
                                                                                ref bool bSaveChanges, ref int iCounter)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.IDPatient == IDPatient && a.Entlassungszeitpunkt == null);
                foreach (PMDS.db.Entities.Aufenthalt rAufenthalt in tAufenthalt)
                {
                    IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = db.PflegePlan.Where(p => p.IDAufenthalt == rAufenthalt.ID && p.OhneZeitBezug == false &&
                                                                                            (p.EintragGruppe.Trim() == "M" || p.EintragGruppe.Trim() == "T"));
                    foreach (PMDS.db.Entities.PflegePlan rPflegePlan in tPflegePlan)
                    {

                        IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeeinträge = db.PflegeEintrag.Where(pe => pe.IDPflegePlan == rPflegePlan.ID).OrderByDescending(pe => pe.Zeitpunkt);
                        int ab = tPflegeeinträge.Count();
                        if (ab > 0)
                        {
                            PMDS.db.Entities.PflegeEintrag rLastPflegeEintrag = tPflegeeinträge.First();
                            DateTime NächstesDatum = DateTime.MinValue;
                            this.UpdatePflegePlanBeiRückmeldung(rPflegePlan.ID, db, ref NächstesDatum, rPflegePlan, false, (DateTime)rLastPflegeEintrag.Zeitpunkt, false);
                            rPflegePlan.NächstesDatum = NächstesDatum;
                            bSaveChanges = true;
                            iCounter += 1;
                            iCountUpdated += 1;
                            if (frmStatus != null)
                            {
                                frmStatus.lblStatus.Text = iCountUpdated.ToString() + " PP updated";
                                System.Windows.Forms.Application.DoEvents();
                            }
                            //prot += "with next date " + rPflegePlan.ID.ToString() + " updated " + NächstesDatum.ToString() + "\r\n"; 
                        }
                        else
                        {
                            rPflegePlan.NächstesDatum = rPflegePlan.StartDatum;
                            //prot += "with startdatum  " + rPflegePlan.ID.ToString() + " updated " + rPflegePlan.StartDatum.ToString() + "\r\n";  
                            iCounter += 1;
                            iCountUpdated += 1;
                            if (frmStatus != null)
                            {
                                frmStatus.lblStatus.Text = iCountUpdated.ToString() + " PP updated";
                                System.Windows.Forms.Application.DoEvents();
                            }
                            bSaveChanges = true;
                        }
                        //}
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.sys_InitialisierungNächstesDatumAllerPflegepläneFürGesamteDb2: " + ex.ToString());
            }
        }
    
        
        public void UpdatePflegePlanBeiRückmeldung(Guid IDPlfegeplan, PMDS.db.Entities.ERModellPMDSEntities db,
                                                    ref DateTime NächstesDatum, PMDS.db.Entities.PflegePlan rPflegeplan, bool MorgenWieder,
                                                    DateTime Rückmeldungsdatum, bool doSaveChanges, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                DateTime dNow = DateTime.Now;

                System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegeplan = db.PflegePlan.Where(p => p.ID == IDPlfegeplan);
                rPflegeplan = tPflegeplan.First();
                if (rPflegeplan.EintragGruppe.Trim() != "M" && rPflegeplan.EintragGruppe.Trim() != "T" && rPflegeplan.EintragGruppe.Trim() != "Z")
                {
                    throw new Exception("UpdatePflegePlanBeiRückmeldung: rPflegeplan.EintragGruppe != 'M' && rPflegeplan.EintragGruppe != 'T' for IDPflegeplan '" + IDPlfegeplan.ToString() + "'!");
                }

                if (!rPflegeplan.OhneZeitBezug)
                {

                    //osxy: Prüfen, ob man LetztesDatum auf das Rückmeldedatum setzen kann (statt Planzeitpunkt).
                    //Dann könnte man die Funktion GetLastRMTimeText in ucQMButton durch die RM-Zeit ersetzen und view in SQL entfernen.
                    DateTime dStartdatumTmp = new DateTime(Rückmeldungsdatum.Year, Rückmeldungsdatum.Month, Rückmeldungsdatum.Day,
                                        ((DateTime)rPflegeplan.StartDatum).Hour, ((DateTime)rPflegeplan.StartDatum).Minute, 0);
                    rPflegeplan.LetztesDatum = dStartdatumTmp;
                    //rPflegeplan.LetztesDatum = Rückmeldungsdatum;
                                       
                    if (rPflegeplan.StartDatum == null)
                    {
                        //dLetztesDatum = (DateTime)rPflegeplan.StartDatum;
                        throw new Exception("UpdatePflegePlanBeiRückmeldung: StartDatum is null für IDPflegeplan'" + rPflegeplan.ID.ToString() + "'");
                    }

                    bool NextDateOK = false;
                    if (MorgenWieder)
                    {
                        //Morgen wieder muss zwingend morgen wieder (vom Zeitpunkt der Durchführung der Meldung an, nicht von der letzten Durchführung!)
                        DateTime SollBeginn = (DateTime)rPflegeplan.StartDatum;
                        NächstesDatum = dNow.Date.AddDays(1) + SollBeginn.TimeOfDay;
//                        NächstesDatum = ((DateTime)rPflegeplan.LetztesDatum).AddDays(1);
                        NextDateOK = true;
                    }
                    else
                    {
                        if (rPflegeplan.EinmaligJN == false)
                        {
                            if (rPflegeplan.Intervall != null && rPflegeplan.WochenTage != null)
                            {
                                int iCounterRek = 0;
                                DateTime dtLetztesDatumTmp = (DateTime)rPflegeplan.LetztesDatum;
                                this.GetNexTermin_rek(ref dtLetztesDatumTmp, (int)rPflegeplan.Intervall, ref NextDateOK,
                                                        ref NächstesDatum, ref iCounterRek, (int)rPflegeplan.WochenTage, rPflegeplan.ID, (DateTime)rPflegeplan.StartDatum);
                                NextDateOK = true;
                            }
                            else
                            {
                                throw new Exception("UpdatePflegePlanBeiRückmeldung: Intervall or WochenTage is null for IDPflageplan'" + rPflegeplan.ID.ToString() + "'");
                            }
                        }
                        else
                        {
                            NächstesDatum = dStartdatumTmp;
                            //NächstesDatum = Rückmeldungsdatum;
                            if (!(bool)rPflegeplan.ErledigtJN)
                            {
                                string sTextForPE = "";
                                PMDS.DB.PMDSBusiness.retBusiness ret = this.EndPflegePlan(rPflegeplan.ID, sTextForPE, dNow, false, false, false);
                            }
                            NextDateOK = true;
                        }
                    }

                    if (NextDateOK && doSaveChanges)
                    {
                        rPflegeplan.NächstesDatum = NächstesDatum;
                        db.SaveChanges();
                    }
                }
                else
                {
                    //if (Rückmeldungsdatum > rPflegeplan.LetztesDatum)
                    //    rPflegeplan.LetztesDatum = Rückmeldungsdatum;
                    //rPflegeplan.LetztesDatum = rPflegeplan.StartDatum;
                }

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusiness.UpdatePflegePlanBeiRückmeldung"))
                {
                    this.UpdatePflegePlanBeiRückmeldung(IDPlfegeplan, db, ref NächstesDatum, rPflegeplan, MorgenWieder, Rückmeldungsdatum, doSaveChanges, IDTimeRepeat);
                }
                throw new Exception("PMDSBusiness.UpdatePflegePlanBeiRückmeldung: " + ex.ToString());
            }
        }

        //osxy: Prüfen, ob die Funktion unten ide obige richtig ersetzt
        //public void UpdatePflegePlanBeiRückmeldung(Guid IDPlfegeplan, PMDS.db.Entities.ERModellPMDSEntities db,
        //        ref DateTime NächstesDatum, PMDS.db.Entities.PflegePlan rPflegeplan, bool MorgenWieder,
        //        DateTime Rückmeldungsdatum, bool doSaveChanges)
        //{
        //    try
        //    {
        //        DateTime dNow = DateTime.Now;

        //        System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegeplan = db.PflegePlan.Where(p => p.ID == IDPlfegeplan);
        //        rPflegeplan = tPflegeplan.First();
        //        if (rPflegeplan.EintragGruppe.Trim() != "M" && rPflegeplan.EintragGruppe.Trim() != "T" && rPflegeplan.EintragGruppe.Trim() != "Z")
        //        {
        //            throw new Exception("UpdatePflegePlanBeiRückmeldung: rPflegeplan.EintragGruppe != 'M' && rPflegeplan.EintragGruppe != 'T' for IDPflegeplan '" + IDPlfegeplan.ToString() + "'!");
        //        }

        //        if (!rPflegeplan.OhneZeitBezug)
        //        {
        //            DateTime dStartdatumTmp = new DateTime(Rückmeldungsdatum.Year, Rückmeldungsdatum.Month, Rückmeldungsdatum.Day,
        //                                ((DateTime)rPflegeplan.StartDatum).Hour, ((DateTime)rPflegeplan.StartDatum).Minute, 0);
        //            rPflegeplan.LetztesDatum = Rückmeldungsdatum;

        //            if (rPflegeplan.StartDatum == null)
        //            {
        //                //dLetztesDatum = (DateTime)rPflegeplan.StartDatum;
        //                throw new Exception("UpdatePflegePlanBeiRückmeldung: StartDatum is null für IDPflegeplan'" + rPflegeplan.ID.ToString() + "'");
        //            }

        //            bool NextDateOK = false;
        //            if (MorgenWieder)
        //            {
        //                NächstesDatum = dStartdatumTmp.AddDays(1);
        //                NextDateOK = true;
        //            }
        //            else
        //            {
        //                if (rPflegeplan.EinmaligJN == false)
        //                {
        //                    if (rPflegeplan.Intervall != null && rPflegeplan.WochenTage != null)
        //                    {
        //                        int iCounterRek = 0;
        //                        DateTime dtLetztesDatumTmp = dStartdatumTmp;
        //                        this.GetNexTermin_rek(ref dtLetztesDatumTmp, (int)rPflegeplan.Intervall, ref NextDateOK,
        //                                                ref NächstesDatum, ref iCounterRek, (int)rPflegeplan.WochenTage, rPflegeplan.ID);
        //                        NextDateOK = true;
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("UpdatePflegePlanBeiRückmeldung: Intervall or WochenTage is null für IDPflegeplan'" + rPflegeplan.ID.ToString() + "'");
        //                    }
        //                }
        //                else
        //                {
        //                    NächstesDatum = Rückmeldungsdatum;
        //                    if (!(bool)rPflegeplan.ErledigtJN)
        //                    {
        //                        string sTextForPE = "";
        //                        PMDS.DB.PMDSBusiness.retBusiness ret = this.EndPflegePlan(rPflegeplan.ID, sTextForPE, dNow, false, false, false);
        //                    }
        //                    NextDateOK = true;
        //                }
        //            }

        //            if (NextDateOK && doSaveChanges)
        //            {
        //                rPflegeplan.NächstesDatum = NächstesDatum;
        //                db.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            if (Rückmeldungsdatum > rPflegeplan.LetztesDatum)
        //                rPflegeplan.LetztesDatum = Rückmeldungsdatum;
        //        }

        //    }
        //    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
        //    {
        //        throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("PMDSBusiness.UpdatePflegePlanBeiRückmeldung: " + ex.ToString());
        //    }
        //}

        public void copyÄrzte(Guid IDArztOrig, ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatientenSelected,
                                Nullable<Guid> IDPatientOrig, PMDS.db.Entities.ERModellPMDSEntities db, PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl cÄrzteMehrfachauswahlAct)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in lstPatientenSelected)
                {
                    if (IDPatientOrig == null || !SelectedNodes.IDKlient.Equals(IDPatientOrig))
                    {
                        IQueryable<Aerzte> tAerzte = db.Aerzte.Where(pe => pe.ID == IDArztOrig);
                        PMDS.db.Entities.Aerzte rAerzteOrig = tAerzte.First();

                        //IQueryable<PatientAerzte> tPatientArzt = db.PatientAerzte.Where(pe => pe.ID == IDArztPatient);
                        //PMDS.db.Entities.PatientAerzte rPatientAerzte = tPatientArzt.First();

                        PMDS.db.Entities.PatientAerzte rNewPatientAerzte = new PMDS.db.Entities.PatientAerzte();
                        rNewPatientAerzte.ID = System.Guid.NewGuid();
                        rNewPatientAerzte.IDPatient = SelectedNodes.IDKlient.Value;
                        rNewPatientAerzte.IDAerzte = IDArztOrig;
                        //rNewPatientAerzte.HausarztJN = rPatientAerzte.HausarztJN;
                        //rNewPatientAerzte.ZuweiserJN = rPatientAerzte.ZuweiserJN;
                        //rNewPatientAerzte.AufnahmearztJN = rPatientAerzte.AufnahmearztJN;
                        //rNewPatientAerzte.BehandelnderFAJN = rPatientAerzte.BehandelnderFAJN;
                        //rNewPatientAerzte.Von = rPatientAerzte.Von;
                        //rNewPatientAerzte.Bis = rPatientAerzte.Bis;

                        rNewPatientAerzte.HausarztJN = cÄrzteMehrfachauswahlAct.HausarztJN2;
                        rNewPatientAerzte.ELGA_HausarztJN = cÄrzteMehrfachauswahlAct.HausarztELGAJN;
                        rNewPatientAerzte.ZuweiserJN = cÄrzteMehrfachauswahlAct.ZuweiserJN;
                        rNewPatientAerzte.AufnahmearztJN = cÄrzteMehrfachauswahlAct.AufnahmearztJN;
                        rNewPatientAerzte.BehandelnderFAJN = cÄrzteMehrfachauswahlAct.BehandelnderFAJN;
                        rNewPatientAerzte.Von = cÄrzteMehrfachauswahlAct.Von;

                        db.PatientAerzte.Add(rNewPatientAerzte);
                        db.SaveChanges();
                        SelectedNodes.bDone = true;
                    }
                    else
                    {
                        bool bNoCopyArzt = true;
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddPflegeeinträgeCC2: " + ex.ToString());
            }
        }


        public DateTime getNextDatePlanungsänderung(DateTime StartDatum, Guid IDPlfegeplan, 
                                                    ref DateTime NächstesDatum, bool MaßnahmeOhneZeitbezug,
                                                    int WochenTage, System.Guid IDPflegeplan, DateTime PP_StartDatum)
        {
            try
            {
                bool NextDateOK = false;
                int iCounterRek = 0;
                this.GetNexTermin_rek(ref StartDatum, 0, ref NextDateOK, ref NächstesDatum, ref iCounterRek, WochenTage, IDPflegeplan, PP_StartDatum);
                if (!NextDateOK)
                {
                    throw new Exception("getNextDatePlanungsänderung: NextDateOK==false for IDPflegeplan" + IDPlfegeplan.ToString() + "!");
                }
                return NächstesDatum;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getNextDatePlanungsänderung: " + ex.ToString());
            }
        }
        
        public void GetNexTermin_rek(ref DateTime LetztesDatumTmp, int Intervall, ref bool NextDateOK,
                                    ref DateTime NächstesDatum, ref int iCounterRek, int WochenTage, System.Guid IDPflegeplan, DateTime PP_StartDatum )
        {
            try
            {
                iCounterRek += 1;

                if (Intervall % 721 == 0 && Intervall > 0)
                {
                    int Monate = Intervall / 721;
                    LetztesDatumTmp = new DateTime(LetztesDatumTmp.Year, LetztesDatumTmp.Month, PP_StartDatum.Day, PP_StartDatum.Hour, PP_StartDatum.Minute, PP_StartDatum.Second).AddMonths(Monate);
                }
                else
                    LetztesDatumTmp = LetztesDatumTmp.AddHours(Intervall);
                
                NächstesDatum = LetztesDatumTmp;
                if (!NextDateOK)
                {
                    if (iCounterRek < 8)
                    {
                        if (this.IsAllowedWeekDay(NächstesDatum, WochenTage))
                        {
                            NextDateOK = true;
                        }
                        else
                        {
                            this.GetNexTermin_rek(ref LetztesDatumTmp, 24, ref NextDateOK, ref NächstesDatum, ref iCounterRek, WochenTage, IDPflegeplan, PP_StartDatum);
                        }
                    }
                    else
                    {
                        throw new Exception("GetNexTermin_rek: Error iCounterRek<8 --> Keine Wochentage gefunden in frmPatientRueckmeldung.Save IDPflegeplan='" + IDPflegeplan .ToString () + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetNexTermin_rek, IDPflegeplan='" + IDPflegeplan.ToString() + ": " + ex.ToString());
            }
        }
        public bool IsAllowedWeekDay(DateTime time, int wochenTage)
        {
            
            // Berücksichtigung Wochentage
            int weekBit = ((int)time.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            int weekBitVal = (1 << weekBit);

            bool bOk = ((wochenTage & weekBitVal) != 0);

            if (bOk)
            {
                string xy = "";
            }
            return bOk;
        }


        public void writeDienstübergabeForPatient(Guid IDSelListWichtigFürDienstübergabe, Guid IDPE,  
                                                    PMDS.db.Entities.ERModellPMDSEntities db, TXTextControl.TextControl TextControl1)
        {
            try
            {
                IQueryable<PflegeEintrag> tPflegeEintragOrig = db.PflegeEintrag.Where(pe => pe.ID == IDPE);
                PMDS.db.Entities.PflegeEintrag rPflegeEintragOrig = tPflegeEintragOrig.First();
                
                IQueryable<Aufenthalt> tAufenthalt = db.Aufenthalt.Where(pe => pe.ID == rPflegeEintragOrig.IDAufenthalt);
                PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                
                DateTime dNow = DateTime.Now.Date;
                dNow = new DateTime(dNow.Year, dNow.Month, dNow.Day, 23, 59, 59);
                DateTime dFrom = dNow.AddDays(-7);
                dFrom = new DateTime(dFrom.Year, dFrom.Month, dFrom.Day, 0, 0, 0);

                string InfoDienstuebergabeTmp = "";
                IQueryable<PflegeEintrag> tPflegeEintragDienstübergabe = db.PflegeEintrag.Where(pe => pe.IDAufenthalt == rAufenthalt.ID && pe.IDWichtig == IDSelListWichtigFürDienstübergabe && pe.DatumErstellt <= dNow && pe.DatumErstellt >= dFrom).OrderByDescending(pe => pe.DatumErstellt);
                foreach (PflegeEintrag rPflegeEintragForDienstübergabe in tPflegeEintragDienstübergabe)
                {
                    InfoDienstuebergabeTmp += rPflegeEintragForDienstübergabe.Zeitpunkt.Value.ToString("dd.MM.yyyy HH:mm:ss") + "," + rPflegeEintragForDienstübergabe.PflegeplanText.Trim() + "," + QS2.Desktop.ControlManagment.ControlManagment.getRes("erstellt von") + " " + rPflegeEintragForDienstübergabe.LogInNameFrei.Trim() + "\r\n" +
                                                rPflegeEintragForDienstübergabe.Text.Trim() + "\r\n" + "\r\n";
                }
                
                rAufenthalt.InfoDienstuebergabe = InfoDienstuebergabeTmp.Trim();
                db.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.writeDienstübergabeForPatient: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.PflegeEintrag AddPflegeeintrag(PMDS.db.Entities.ERModellPMDSEntities db, string PflegeeintragText, DateTime dNow,
                                      Nullable<Guid> IDEintrag, Nullable<Guid> IDBereich, Nullable<System.Guid> IDAufenthalt,
                                      Nullable<Guid> IDPflegeplan, PflegeEintragTyp PflegeEintragTyp,
                                      Nullable<Guid> IDPflegeplanH, Nullable<Guid> IDAbteilung, string PflegeplanText, Nullable<Guid> IDWichtig = null)
        {
            try
            {
                PMDS.db.Entities.PflegeEintrag rNewPE = new PMDS.db.Entities.PflegeEintrag();
                rNewPE.ID = System.Guid.NewGuid();
                rNewPE.IDAufenthalt = (Guid)IDAufenthalt;
                rNewPE.IDPflegePlan = IDPflegeplan;
                rNewPE.IDBenutzer = this.LogggedOnUser().ID;
                rNewPE.IDEintrag = IDEintrag;
                rNewPE.IDBerufsstand = this.LogggedOnUser().IDBerufsstand;
                rNewPE.DatumErstellt = dNow.Date;
                rNewPE.Zeitpunkt = dNow;
                rNewPE.Text = PflegeeintragText.Trim();
                rNewPE.IstDauer = 0;
                rNewPE.DurchgefuehrtJN = true;
                rNewPE.EintragsTyp = (int)PflegeEintragTyp;
                rNewPE.Wichtig = 0;
                rNewPE.IDWichtig = IDWichtig;
                rNewPE.IDEvaluierung = null;
                rNewPE.EvalStatus = 0;
                rNewPE.PflegeplanText = PflegeplanText.Trim();
                rNewPE.IDSollberufsstand = null;
                rNewPE.IDPflegePlanBerufsstand = null;
                rNewPE.IDPflegeplanH = IDPflegeplanH;
                rNewPE.Solldauer = 0;
                if (!IDBereich.Equals(Guid.Empty))
                {
                    rNewPE.IDBereich = IDBereich;
                }
                rNewPE.IDAbteilung = IDAbteilung;
                rNewPE.PflegePlanDauer = 0;
                rNewPE.IDDekurs = null;
                rNewPE.CC = false;
                rNewPE.TextRtf = "";
                rNewPE.Dekursherkunft = -1;
                rNewPE.AbgezeichnetJN = false;
                rNewPE.AbgezeichnetIDBenutzer = null;
                rNewPE.AbgezeichnetAm = null;
                rNewPE.HAGPflichtigJN = false;
                rNewPE.IDBefund = null;
                rNewPE.LogInNameFrei = ENV.LoginInNameFrei;
                rNewPE.TextHistorie = "";
                rNewPE.TextHistorieRtf = "";
                rNewPE.IDGruppe = null;

                db.PflegeEintrag.Add(rNewPE);
                return rNewPE;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.AddPflegeeintrag: " + ex.ToString());
            }
        }
        public retBusiness CopyAndAddPflegeeinträgeCC(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDPflegeEintrag, ref List<Guid> lstCCIDBerufsgruppe,
                                                    bool CopyAsDekurs, bool DoNoCopyOriginalPEAsDekurs, bool abzeichnenJN, Nullable<Guid> IDWichtig,
                                                    ref System.Collections.Generic.List<Guid> lstPEToCopy, bool IsNotfall, ref Guid IDGruppe)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                IQueryable<PflegeEintrag> lstPE = db.PflegeEintrag.Where(pe => pe.ID == IDPflegeEintrag);
                PMDS.db.Entities.PflegeEintrag peOriginal = lstPE.First();

                PMDS.Global.db.ERSystem.sqlManange sql = new PMDS.Global.db.ERSystem.sqlManange();
                string strZusatzwerte = sql.getS2_GetZusatzswerteAsString(IDPflegeEintrag);

                string strCC = "";

                List<Guid> WichtigFuer = lstCCIDBerufsgruppe;
                if (WichtigFuer.Count == 0 && CopyAsDekurs == true)     //Kein Wichtig für ausgewählt
                {
                    WichtigFuer.Add(System.Guid.Empty);
                }



                foreach (Guid IDBerufsgruppe in WichtigFuer)
                {
                    if (IDBerufsgruppe != IDWichtig || IDWichtig == System.Guid.Empty)
                    {

                        IQueryable<AuswahlListe> Auswahlliste = db.AuswahlListe.Where(al => al.ID == IDBerufsgruppe);
                        if (Auswahlliste.Count() > 0 )
                        {
                            PMDS.db.Entities.AuswahlListe alEintrag = Auswahlliste.First();
                            strCC += strCC == "" ? alEintrag.Bezeichnung : ", " + alEintrag.Bezeichnung;
                        }

                        PMDS.db.Entities.PflegeEintrag rNewPEDekurs = new db.Entities.PflegeEintrag();

                        this.CopyPflegeEintrag(rNewPEDekurs, peOriginal);

                        rNewPEDekurs.ID = System.Guid.NewGuid();
                        rNewPEDekurs.IDWichtig = IDBerufsgruppe;
                        rNewPEDekurs.IDGruppe = IDGruppe;
                        rNewPEDekurs.CC = true;
                        rNewPEDekurs.IDDekurs = peOriginal.ID;
                        if (CopyAsDekurs)
                        {
                            rNewPEDekurs.EintragsTyp = (int)PMDS.Global.PflegeEintragTyp.DEKURS;
                            rNewPEDekurs.PflegeplanText = "Dekurs";
                        }
                        rNewPEDekurs.IDPflegePlan = peOriginal.IDPflegePlan;
                        rNewPEDekurs.IDEintrag = peOriginal.IDEintrag;
                        rNewPEDekurs.Text = rNewPEDekurs.Text;
                        if (strZusatzwerte != "")
                            rNewPEDekurs.Text += "\r\n" + strZusatzwerte;

                        if (IsNotfall)
                            rNewPEDekurs.PflegeplanText += " (Notfall)";


                        if (peOriginal.EintragsTyp != (int)PMDS.Global.PflegeEintragTyp.DEKURS && CopyAsDekurs)
                        {
                            rNewPEDekurs.PflegeplanText += " zu " + peOriginal.PflegeplanText;
                            if (rNewPEDekurs.Zeitpunkt != null)
                            {
                                DateTime dt = (DateTime)rNewPEDekurs.Zeitpunkt;
                                rNewPEDekurs.PflegeplanText += " von " + dt.ToString("dd.MM.yyyy HH:mm");
                            }
                        }
                        rNewPEDekurs.AbzeichnenJN = abzeichnenJN;
                        rNewPEDekurs.DatumErstellt = dNow;          
                        rNewPEDekurs.Zeitpunkt = dNow;    
                        rNewPEDekurs.LogInNameFrei = ENV.LoginInNameFrei;
                        //                       rNewPEDekurs.CC = false;
                        rNewPEDekurs.TextHistorie = "";
                        rNewPEDekurs.TextHistorieRtf = "";

                        db.PflegeEintrag.Add(rNewPEDekurs);
                        db.SaveChanges();
                        lstPEToCopy.Add(rNewPEDekurs.ID);
                    }
                }

                //Original-Pflegeeintrag update (Liste der CC-Einträge hinzufügen)
                if (strCC != "")
                    peOriginal.Text = peOriginal.Text + "\r\n" + "Wichtig für " + strCC;

                //if (doSave)
                //    db.SaveChanges();

                return retBusiness1;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddPflegeeinträgeCC: " + ex.ToString());
            }
        }

        public void CopyAndAddPflegeeinträgeCC2(Guid IDPflegeEintrag, ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatientenSelected,
                                                 PMDS.db.Entities.ERModellPMDSEntities db, Guid IDAufenthaltOrig, TXTextControl.TextControl TextControl1,
                                                 string PflegeplanTextOrig, ref Guid IDGruppe)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in lstPatientenSelected)
                {
                    if (!SelectedNodes.IDAufenthalt.Equals(IDAufenthaltOrig))
                    {
                        IQueryable<PflegeEintrag> lstPE = db.PflegeEintrag.Where(pe => pe.ID == IDPflegeEintrag);
                        PMDS.db.Entities.PflegeEintrag peOriginal = lstPE.First();

                        PMDS.db.Entities.PflegeEintrag rNewPE = new db.Entities.PflegeEintrag();
                        this.CopyPflegeEintrag(rNewPE, peOriginal);
                        
                        rNewPE.ID = System.Guid.NewGuid();
                        rNewPE.IDAufenthalt = (Guid)SelectedNodes.IDAufenthalt;
                        rNewPE.IDGruppe = IDGruppe;
                        rNewPE.IDDekurs = peOriginal.ID;
                        IQueryable<Aufenthalt> tAufenthalt = db.Aufenthalt.Where(pe => pe.ID == rNewPE.IDAufenthalt);
                        Aufenthalt rAufenthalt = tAufenthalt.First();

                        if (SelectedNodes.Txt.Trim() != "")
                        {
                            this.addTxtToPE(rNewPE, null, SelectedNodes, db, TextControl1, PflegeplanTextOrig);
                        }

                        PMDS.db.Entities.Aufenthalt rAufenthaltAkt = this.getAktuellerAufenthaltPatient(rAufenthalt.IDPatient.Value, false, db);
                        if (!rAufenthalt.ID.Equals(rAufenthaltAkt.ID))
                        {
                            throw new Exception("CopyAndAddPflegeeinträgeCC2: !rAufenthalt.ID.Equals(rAufenthaltAkt.ID) - Error für IDPatient '" + rAufenthalt.IDPatient.ToString() + "'!");
                        }

                        PMDS.db.Entities.Patient rPatient = this.getPatient(rAufenthalt.IDPatient.Value, db);
                        rNewPE.IDAbteilung = rAufenthaltAkt.IDAbteilung;
                        rNewPE.IDBereich = rAufenthaltAkt.IDBereich;
                        rNewPE.TextHistorie = "";
                        rNewPE.TextHistorieRtf = "";
                        
                        db.PflegeEintrag.Add(rNewPE);
                        db.SaveChanges();
                        SelectedNodes.bDone = true;
                    }
                    else
                    {
                        if (SelectedNodes.Txt.Trim() != "" && !SelectedNodes.bDone)
                        {
                            IQueryable<PflegeEintrag> lstPE = db.PflegeEintrag.Where(pe => pe.ID == IDPflegeEintrag);
                            PMDS.db.Entities.PflegeEintrag peOriginal = lstPE.First();

                            this.addTxtToPE(peOriginal, null, SelectedNodes, db, TextControl1, PflegeplanTextOrig);
                            db.SaveChanges();
                            SelectedNodes.bDone = true;
                        }
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddPflegeeinträgeCC2: " + ex.ToString());
            }
        }
        public void addTxtToPE(PMDS.db.Entities.PflegeEintrag rNewPE, PMDS.db.Entities.PflegeEintragEntwurf rNewPEEntwurf, PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes,
                                         PMDS.db.Entities.ERModellPMDSEntities db,  TXTextControl.TextControl TextControl1, string PflegeplanTextOrig)
        {
            try
            {
                TextControl1.Text = "";
                QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                TXTextControl.LoadSettings LoadSettings1 = new TXTextControl.LoadSettings();
                TextControl1.Load(PflegeplanTextOrig.Trim(), TXTextControl.StringStreamType.PlainText, LoadSettings1);
                TXTextControl.AppendSettings appSett = new TXTextControl.AppendSettings();
                TextControl1.Append(SelectedNodes.Txt.Trim(), TXTextControl.StringStreamType.PlainText, appSett);
                string TxtTmp = "";
                TextControl1.Save(out TxtTmp, TXTextControl.StringStreamType.PlainText);

                if (rNewPE != null)
                {
                    rNewPE.PflegeplanText = TxtTmp;
                }
                if (rNewPEEntwurf != null)
                {
                    rNewPEEntwurf.PflegeplanText = TxtTmp;
                }

                //if (rNewPE.TextRtf.Trim() != "")
                //{
                //    ServerTextControl1.Load(rNewPE.TextRtf, TXTextControl.StringStreamType.RichTextFormat, LoadSettings1);
                //    TXTextControl.AppendSettings appSett = new TXTextControl.AppendSettings();
                //    ServerTextControl1.Append("\r\n" + SelectedNodes.Txt.Trim(), TXTextControl.StringStreamType.PlainText, appSett);
                //    string RtfTxtTmp = "";
                //    ServerTextControl1.Save(out RtfTxtTmp, TXTextControl.StringStreamType.RichTextFormat);
                //    rNewPE.TextRtf = RtfTxtTmp;
                //}
                //else
                //{
                //    ServerTextControl1.Load(rNewPE.Text, TXTextControl.StringStreamType.PlainText, LoadSettings1);
                //    TXTextControl.AppendSettings appSett = new TXTextControl.AppendSettings();
                //    ServerTextControl1.Append("\r\n" + "\r\n" + SelectedNodes.Txt.Trim(), TXTextControl.StringStreamType.PlainText, appSett);
                //    string TxtTmp = "";
                //    ServerTextControl1.Save(out TxtTmp, TXTextControl.StringStreamType.PlainText);
                //    rNewPE.Text = TxtTmp;
                //}


            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.addTxtToPE: " + ex.ToString());
            }
        }

        public void CopyPflegeEintrag(PMDS.db.Entities.PflegeEintrag rNewPE, PMDS.db.Entities.PflegeEintrag peOriginal)
        {
            try
            {
                rNewPE.ID = peOriginal.ID;
                rNewPE.IDAufenthalt = peOriginal.IDAufenthalt;
                rNewPE.IDPflegePlan = peOriginal.IDPflegePlan;
                rNewPE.IDBenutzer = peOriginal.IDBenutzer;
                rNewPE.IDEintrag = peOriginal.IDEintrag;
                rNewPE.IDBerufsstand = peOriginal.IDBerufsstand;
                rNewPE.DatumErstellt = peOriginal.DatumErstellt;
                rNewPE.Zeitpunkt = peOriginal.Zeitpunkt;
                rNewPE.Text = peOriginal.Text;
                rNewPE.IstDauer = peOriginal.IstDauer;
                rNewPE.DurchgefuehrtJN = peOriginal.DurchgefuehrtJN;
                rNewPE.EintragsTyp = peOriginal.EintragsTyp;
                rNewPE.Wichtig = peOriginal.Wichtig;
                rNewPE.IDWichtig = peOriginal.IDWichtig;
                rNewPE.IDEvaluierung = peOriginal.IDEvaluierung;
                rNewPE.EvalStatus = peOriginal.EvalStatus;
                rNewPE.PflegeplanText = peOriginal.PflegeplanText;
                rNewPE.IDSollberufsstand = peOriginal.IDSollberufsstand;
                rNewPE.IDPflegePlanBerufsstand = peOriginal.IDPflegePlanBerufsstand;
                rNewPE.IDPflegeplanH = peOriginal.IDPflegeplanH;
                rNewPE.Solldauer = peOriginal.Solldauer;
                rNewPE.IDBereich = peOriginal.IDBereich;
                rNewPE.IDAbteilung = peOriginal.IDAbteilung;
                rNewPE.PflegePlanDauer = peOriginal.PflegePlanDauer;
                rNewPE.IDDekurs = peOriginal.IDDekurs;
                rNewPE.CC = peOriginal.CC;
                rNewPE.HAGPflichtigJN = peOriginal.HAGPflichtigJN;
                rNewPE.IDBefund = peOriginal.IDBefund;
                rNewPE.TextRtf = peOriginal.TextRtf;
                rNewPE.Dekursherkunft = peOriginal.Dekursherkunft;
                rNewPE.AbgezeichnetJN = peOriginal.AbgezeichnetJN;
                rNewPE.AbgezeichnetIDBenutzer = peOriginal.AbgezeichnetIDBenutzer;
                rNewPE.AbgezeichnetAm = peOriginal.AbgezeichnetAm;
                rNewPE.Startdatum_Neu = peOriginal.Startdatum_Neu;
                rNewPE.AbzeichnenJN = peOriginal.AbzeichnenJN;
                rNewPE.IDExtern = peOriginal.IDExtern;
                rNewPE.LogInNameFrei = peOriginal.LogInNameFrei;
                rNewPE.TextHistorie = peOriginal.TextHistorie;
                rNewPE.TextHistorieRtf = peOriginal.TextHistorieRtf;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyPflegeEintrag: " + ex.ToString());
            }
        }
        public void CopyPflegeEintragToDekursEntwurf(PMDS.db.Entities.PflegeEintragEntwurf rNewPEEntwurf, PMDS.db.Entities.PflegeEintrag peOriginal,
                                                    PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                rNewPEEntwurf.ID = peOriginal.ID;
                rNewPEEntwurf.IDAufenthalt = peOriginal.IDAufenthalt;
                rNewPEEntwurf.IDPflegePlan = peOriginal.IDPflegePlan;
                rNewPEEntwurf.IDBenutzer = peOriginal.IDBenutzer;
                rNewPEEntwurf.IDEintrag = peOriginal.IDEintrag;
                rNewPEEntwurf.IDBerufsstand = peOriginal.IDBerufsstand;
                rNewPEEntwurf.DatumErstellt = peOriginal.DatumErstellt;
                rNewPEEntwurf.Zeitpunkt = peOriginal.Zeitpunkt;
                rNewPEEntwurf.Text = peOriginal.Text;
                rNewPEEntwurf.IstDauer = peOriginal.IstDauer;
                rNewPEEntwurf.DurchgefuehrtJN = peOriginal.DurchgefuehrtJN;
                rNewPEEntwurf.EintragsTyp = peOriginal.EintragsTyp;
                rNewPEEntwurf.Wichtig = peOriginal.Wichtig;
                rNewPEEntwurf.IDWichtig = peOriginal.IDWichtig;
                rNewPEEntwurf.IDEvaluierung = peOriginal.IDEvaluierung;
                rNewPEEntwurf.EvalStatus = peOriginal.EvalStatus;
                rNewPEEntwurf.PflegeplanText = peOriginal.PflegeplanText;
                rNewPEEntwurf.IDSollberufsstand = peOriginal.IDSollberufsstand;
                rNewPEEntwurf.IDPflegePlanBerufsstand = peOriginal.IDPflegePlanBerufsstand;
                rNewPEEntwurf.IDPflegeplanH = peOriginal.IDPflegeplanH;
                rNewPEEntwurf.Solldauer = peOriginal.Solldauer;
                rNewPEEntwurf.IDBereich = peOriginal.IDBereich;
                rNewPEEntwurf.IDAbteilung = peOriginal.IDAbteilung;
                rNewPEEntwurf.PflegePlanDauer = peOriginal.PflegePlanDauer;
                rNewPEEntwurf.IDDekurs = peOriginal.IDDekurs;
                rNewPEEntwurf.CC = peOriginal.CC;
                rNewPEEntwurf.HAGPflichtigJN = peOriginal.HAGPflichtigJN;
                rNewPEEntwurf.IDBefund = peOriginal.IDBefund;
                rNewPEEntwurf.TextRtf = peOriginal.TextRtf;
                rNewPEEntwurf.Dekursherkunft = peOriginal.Dekursherkunft;
                rNewPEEntwurf.AbgezeichnetJN = peOriginal.AbgezeichnetJN;
                rNewPEEntwurf.AbgezeichnetIDBenutzer = peOriginal.AbgezeichnetIDBenutzer;
                rNewPEEntwurf.AbgezeichnetAm = peOriginal.AbgezeichnetAm;
                rNewPEEntwurf.Startdatum_Neu = peOriginal.Startdatum_Neu;
                rNewPEEntwurf.AbzeichnenJN = peOriginal.AbzeichnenJN;
                rNewPEEntwurf.IDExtern = peOriginal.IDExtern;
                rNewPEEntwurf.LogInNameFrei = peOriginal.LogInNameFrei;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyPflegeEintragToDekursEntwurf: " + ex.ToString());
            }
        }
        public void CopyPflegeEintragEntwurf(PMDS.db.Entities.PflegeEintragEntwurf rNewPEEntwurf, PMDS.db.Entities.PflegeEintragEntwurf rPEEntwurfOrig)
        {
            try
            {
                rNewPEEntwurf.ID = rPEEntwurfOrig.ID;
                rNewPEEntwurf.IDAufenthalt = rPEEntwurfOrig.IDAufenthalt;
                rNewPEEntwurf.IDPflegePlan = rPEEntwurfOrig.IDPflegePlan;
                rNewPEEntwurf.IDBenutzer = rPEEntwurfOrig.IDBenutzer;
                rNewPEEntwurf.IDEintrag = rPEEntwurfOrig.IDEintrag;
                rNewPEEntwurf.IDBerufsstand = rPEEntwurfOrig.IDBerufsstand;
                rNewPEEntwurf.DatumErstellt = rPEEntwurfOrig.DatumErstellt;
                rNewPEEntwurf.Zeitpunkt = rPEEntwurfOrig.Zeitpunkt;
                rNewPEEntwurf.Text = rPEEntwurfOrig.Text;
                rNewPEEntwurf.IstDauer = rPEEntwurfOrig.IstDauer;
                rNewPEEntwurf.DurchgefuehrtJN = rPEEntwurfOrig.DurchgefuehrtJN;
                rNewPEEntwurf.EintragsTyp = rPEEntwurfOrig.EintragsTyp;
                rNewPEEntwurf.Wichtig = rPEEntwurfOrig.Wichtig;
                rNewPEEntwurf.IDWichtig = rPEEntwurfOrig.IDWichtig;
                rNewPEEntwurf.IDEvaluierung = rPEEntwurfOrig.IDEvaluierung;
                rNewPEEntwurf.EvalStatus = rPEEntwurfOrig.EvalStatus;
                rNewPEEntwurf.PflegeplanText = rPEEntwurfOrig.PflegeplanText;
                rNewPEEntwurf.IDSollberufsstand = rPEEntwurfOrig.IDSollberufsstand;
                rNewPEEntwurf.IDPflegePlanBerufsstand = rPEEntwurfOrig.IDPflegePlanBerufsstand;
                rNewPEEntwurf.IDPflegeplanH = rPEEntwurfOrig.IDPflegeplanH;
                rNewPEEntwurf.Solldauer = rPEEntwurfOrig.Solldauer;
                rNewPEEntwurf.IDBereich = rPEEntwurfOrig.IDBereich;
                rNewPEEntwurf.IDAbteilung = rPEEntwurfOrig.IDAbteilung;
                rNewPEEntwurf.PflegePlanDauer = rPEEntwurfOrig.PflegePlanDauer;
                rNewPEEntwurf.IDDekurs = rPEEntwurfOrig.IDDekurs;
                rNewPEEntwurf.CC = rPEEntwurfOrig.CC;
                rNewPEEntwurf.HAGPflichtigJN = rPEEntwurfOrig.HAGPflichtigJN;
                rNewPEEntwurf.IDBefund = rPEEntwurfOrig.IDBefund;
                rNewPEEntwurf.TextRtf = rPEEntwurfOrig.TextRtf;
                rNewPEEntwurf.Dekursherkunft = rPEEntwurfOrig.Dekursherkunft;
                rNewPEEntwurf.AbgezeichnetJN = rPEEntwurfOrig.AbgezeichnetJN;
                rNewPEEntwurf.AbgezeichnetIDBenutzer = rPEEntwurfOrig.AbgezeichnetIDBenutzer;
                rNewPEEntwurf.AbgezeichnetAm = rPEEntwurfOrig.AbgezeichnetAm;
                rNewPEEntwurf.Startdatum_Neu = rPEEntwurfOrig.Startdatum_Neu;
                rNewPEEntwurf.AbzeichnenJN = rPEEntwurfOrig.AbzeichnenJN;
                rNewPEEntwurf.IDExtern = rPEEntwurfOrig.IDExtern;
                rNewPEEntwurf.LogInNameFrei = rPEEntwurfOrig.LogInNameFrei;
                rNewPEEntwurf.lstSelectedCC = rPEEntwurfOrig.lstSelectedCC;
                rNewPEEntwurf.lstSelectedPatient = rPEEntwurfOrig.lstSelectedPatient;
                rNewPEEntwurf.FuerUserErstellt = rPEEntwurfOrig.FuerUserErstellt;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyPflegeEintragEntwurf: " + ex.ToString());
            }
        }
        public void DeletePflegeplan(Guid IDpflegeplan)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.PflegePlan> tPflegeplan = db.PflegePlan.Where(pp => pp.ID == IDpflegeplan);
                    PMDS.db.Entities.PflegePlan rPflegeplan = tPflegeplan.First();
                    db.PflegePlan.Remove(rPflegeplan);
                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeletePflegeplan: " + ex.ToString());
            }
        }
        public bool DeletePflegeeintrag(Guid IDPflegeEintrag)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(pp => pp.ID == IDPflegeEintrag);
                    PMDS.db.Entities.PflegeEintrag rPflegeEintrag = tPflegeEintrag.First();
                    db.PflegeEintrag.Remove(rPflegeEintrag);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeletePflegeeintrag: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.AuswahlListe> GetAuswahlliste(PMDS.db.Entities.ERModellPMDSEntities db, string GruppeID, int SupressLevelHierarchie, bool OnlyReihenfolgePlus)
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlliste = null;
                if (GruppeID == "DAS")
                {
                    tAuswahlliste = db.AuswahlListe.Where(a => a.IDAuswahlListeGruppe == GruppeID).OrderBy(a => a.Reihenfolge);
                }
                else
                {
                    if (OnlyReihenfolgePlus)
                    {
                        tAuswahlliste = db.AuswahlListe.Where(a => a.IDAuswahlListeGruppe == GruppeID && a.Hierarche >= SupressLevelHierarchie).OrderBy(a => a.Bezeichnung);
                    }
                    else
                    {
                        tAuswahlliste = db.AuswahlListe.Where(a => a.IDAuswahlListeGruppe == GruppeID).OrderBy(a => a.Bezeichnung);
                    }
                }

                //foreach (PMDS.db.Entities.AuswahlListe rAuswahlliste in tAuswahlliste)
                //{
                //}
                return tAuswahlliste;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetAuswahlliste: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.AuswahlListe GetAuswahllisteByID(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlliste = db.AuswahlListe.Where(a => a.ID == ID).OrderBy(a => a.Bezeichnung);
                return tAuswahlliste.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetAuswahllisteByID: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.AuswahlListe GetAuswahlliste(PMDS.db.Entities.ERModellPMDSEntities db, string GruppeID, string Bezeichnung)
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlliste = db.AuswahlListe.Where(a => a.IDAuswahlListeGruppe == GruppeID && a.Bezeichnung == Bezeichnung.Trim()).OrderBy(a => a.Bezeichnung);
                if (tAuswahlliste.Count() == 0)
                {
                    return null;
                }
                else if (tAuswahlliste.Count() == 1)
                {
                    PMDS.db.Entities.AuswahlListe rAuswahlListe = tAuswahlliste.First();
                    return rAuswahlListe;
                }
                else
                {
                    throw new Exception("PMDSBusiness.GetAuswahlliste: tAuswahlliste.Count() > 1 not possible for Bezeichnung '" + Bezeichnung .ToString() + "'!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetAuswahlliste: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.Eintrag GetEintrag(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDEintrag)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Eintrag> tEintrag = db.Eintrag.Where(a => a.ID == IDEintrag);
                PMDS.db.Entities.Eintrag rEintrag = tEintrag.First();
                return rEintrag;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetEintrag: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.DBVersion GetDBVersion(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.db.Entities.DBVersion rDBVersion = new DBVersion();
                IQueryable<PMDS.db.Entities.DBVersion> tDBVersion = db.DBVersion.Where(a => a.ID == 1);
                if (tDBVersion.Count() == 1)
                {
                    rDBVersion = tDBVersion.First();
                }  
                return rDBVersion;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetDBVersion: " + ex.ToString());
            }
        }

        public bool UpdateDBLizenz(string Lizenz, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                DBLizenz rDBLizenz = db.DBLizenz.Where(l => l.ID == 1).First();
                if (rDBLizenz != null)
                {
                    rDBLizenz.Lizenz = Lizenz;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UpdateDBLizenz: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.DBLizenz GetDBLizenz(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.db.Entities.DBLizenz rDBLizenz = new DBLizenz();
                IQueryable<PMDS.db.Entities.DBLizenz> tDBLizenz = db.DBLizenz.Where(a => a.ID == 1);
                if (tDBLizenz.Count() == 1)
                {
                    rDBLizenz = tDBLizenz.First();
                }
                else
                {
                    rDBLizenz.Lizenz = "";
                }
                return rDBLizenz;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetDBLizenz: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.SPPE GetSPPE(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDPE)
        {
            try
            {
                PMDS.db.Entities.SPPE rSPPE = new SPPE();
                rSPPE.ID = System.Guid.Empty;
                IQueryable<PMDS.db.Entities.SPPE> tSPPE = db.SPPE.Where(a => a.IDPflegeEintrag == IDPE);
                if (tSPPE.Count() >= 1)
                {
                    rSPPE = tSPPE.First();
                }

                return rSPPE;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetDBLizenz: " + ex.ToString());
            }
        }
        public Boolean PDXCodeExists(PMDS.db.Entities.ERModellPMDSEntities db, string PDXCode)
        {
            try
            {
                bool PDXExists = false;
                IQueryable<PMDS.db.Entities.PDX> tPDX = db.PDX.Where(a => a.Code == PDXCode);
                if (tPDX.Count() >= 1)
                {
                    PDXExists = true;
                }
                return PDXExists;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.PDXCodeExists: " + ex.ToString());
            }
        }
        public Boolean ZusatzEintragExists(PMDS.db.Entities.ERModellPMDSEntities db, string ID)
        {
            try
            {
                bool ZEExists = false;
                IQueryable<PMDS.db.Entities.ZusatzEintrag> tZusatzEintrag = db.ZusatzEintrag.Where(a => a.ID == ID);
                if (tZusatzEintrag.Count() >= 1)
                {
                    ZEExists = true;
                }
                return ZEExists;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.ZusatzEintragExists: " + ex.ToString());
            }
        }
        public Boolean MedikamentUsed(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDMedikament)
        {
            try
            {
                bool MedUsed = false;
                IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(a => a.IDMedikament == IDMedikament);
                if (tRezeptEintrag.Count() >= 1)
                {
                    MedUsed = true;
                }
                return MedUsed;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.MedikamentUsed: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Medikament GetMedikament(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDMedikament)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Medikament> tMedikament = db.Medikament.Where(a => a.ID == IDMedikament);
                PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                return rMedikament;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetMedikament: " + ex.ToString());
            }
        }
        public void getAllÄrzte(PMDS.db.Entities.ERModellPMDSEntities DBContext, ref IQueryable<PMDS.db.Entities.Aerzte> tAerzte)
        {
            try
            {
                tAerzte = DBContext.Aerzte.OrderBy(a => a.Nachname).OrderBy(a => a.Vorname);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllÄrtze: " + ex.ToString());
            }
        }

        public void getAllKostenträger(PMDS.db.Entities.ERModellPMDSEntities DBContext, ref DbSet<Kostentraeger> dbKost)
        {
            try
            {
                //var Kostenträger = DBContext.Kostentraeger.Where(k => k.Name.StartsWith("b"));
                //Kostenträger.Where(k => k.Name.StartsWith("b"));
                dbKost = DBContext.Kostentraeger;
                foreach (var Kost in dbKost)
                {
                    string xy = Kost.Name;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllKostenträger: " + ex.ToString());
            }
        }


        public bool searchMedikamenteBestellt(PMDS.db.Entities.ERModellPMDSEntities DBContext, ref IQueryable<PMDS.db.Entities.vRezeptBestellung2> tRezeptBest,
                                            Nullable<DateTime> dRezeptAnforderungDatumFrom, Nullable<DateTime> dRezeptAnforderungDatumTo,
                                            Nullable<DateTime> dRezeptAngefordertDatumFrom, Nullable<DateTime> dRezeptAngefordertDatumTo,
                                            Nullable<DateTime> dDatumBestelltFrom, Nullable<DateTime> dDatumBestelltTo, 
                                            Nullable<System.Guid> IDAbteilung, int Dringend,
                                            int Bestellt, int RezeptAngefordert, bool Mehrfachauswahl, Guid IDPatient, List<Guid> lstIDKlienten,
                                            int GedrucktJN)
        {
            try
            {
                tRezeptBest = DBContext.vRezeptBestellung2.OrderBy(rb => rb.Patient).OrderBy(rb => rb.Bezeichnung);

                DateTime dNow = DateTime.Now.Date;
                if (!Mehrfachauswahl)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.IDPatient == IDPatient);
                }
                else
                {
                    tRezeptBest = tRezeptBest.Where(p => lstIDKlienten.Contains((Guid)p.IDPatient));
                }

                if (dRezeptAnforderungDatumFrom != null)    //von Pfleger
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_RezeptAnforderungDatum >= dRezeptAnforderungDatumFrom);
                }
                if (dRezeptAnforderungDatumTo != null)
                {
                    //DateTime dToTmp = new DateTime(((DateTime)dTo).Year, ((DateTime)dTo).Month, ((DateTime)dTo).Day, 23, 59, 59);
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_RezeptAnforderungDatum <= dRezeptAnforderungDatumTo);
                }

                if (RezeptAngefordert == 1 || RezeptAngefordert == -1)
                {
                    if (dRezeptAngefordertDatumFrom != null)
                    {
                        tRezeptBest = tRezeptBest.Where(rb => rb.rbp_RezeptAngefordertDatum >= dRezeptAngefordertDatumFrom);
                    }
                    if (dRezeptAngefordertDatumTo != null)
                    {
                        tRezeptBest = tRezeptBest.Where(rb => rb.rbp_RezeptAngefordertDatum <= dRezeptAngefordertDatumTo);
                    }
                }
                if (RezeptAngefordert == 1)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_RezeptAngefordertJN == true);
                }
                if (RezeptAngefordert == 0)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_RezeptAngefordertJN == false);
                }

                if (Bestellt == 1 || Bestellt == -1)
                {
                    if (dDatumBestelltFrom != null)
                    {
                        tRezeptBest = tRezeptBest.Where(rb => rb.rbp_DatumBestellt >= dDatumBestelltFrom);
                    }
                    if (dDatumBestelltTo != null)
                    {
                        tRezeptBest = tRezeptBest.Where(rb => rb.rbp_DatumBestellt <= dDatumBestelltTo);
                    }
                }
                if (Bestellt == 1)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_BestelltJN == true);
                }
                if (Bestellt == 0)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_BestelltJN == false);
                }

                if (IDAbteilung != null)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.IDAbteilung == IDAbteilung);
                }
                if (Dringend == 1)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_Dringend == true);
                }
                if (Dringend == 0)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_Dringend == false);
                }

                if (GedrucktJN == 1)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_GedrucktJN == true);
                }
                if (GedrucktJN == 0)
                {
                    tRezeptBest = tRezeptBest.Where(rb => rb.rbp_GedrucktJN == false);
                }

                foreach (var rRezeptBest in tRezeptBest)
                {
                    string xy = rRezeptBest.Bezeichnung;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getMedikamenteBestellt: " + ex.ToString());
            }
        }
        public bool saveMedikamenteBestellt(List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBest, bool RezepteAnfordern, bool MedikamenteBestellen, 
                                            PMDS.db.Entities.ERModellPMDSEntities db,
                                            bool doSaveChanges, ref int iCountToSave, bool Order, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                DateTime dBestellDatum = DateTime.Now;
                db.Database.CommandTimeout = 360;

                bool SaveChanges = false;
                foreach (PMDS.db.Entities.vRezeptBestellung2 rvRezeptBestellung2 in tRezepteBest)
                {
                    IQueryable<RezeptBestellungPos> tRezeptBestPos = db.RezeptBestellungPos.Where(rb => rb.ID == rvRezeptBestellung2.rbp_ID);
                    RezeptBestellungPos rRezeptBestPos = tRezeptBestPos.First();

                    if (RezepteAnfordern)
                    {
                        rRezeptBestPos.RezeptAngefordertJN = true;
                        rRezeptBestPos.RezeptAngefordertDatum = dBestellDatum;
                        SaveChanges = true;
                        iCountToSave += 1;
                    }
                    if (MedikamenteBestellen)
                    {
                        rRezeptBestPos.BestelltJN = true;
                        rRezeptBestPos.DatumBestellt = dBestellDatum;
                        SaveChanges = true;
                        iCountToSave += 1;
                    }

                }
                if (doSaveChanges && SaveChanges)
                {
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusiness.saveMedikamenteBestellt"))
                {
                    return this.saveMedikamenteBestellt(tRezepteBest, RezepteAnfordern, MedikamenteBestellen, db, doSaveChanges, ref iCountToSave, Order, IDTime);
                }
                throw new Exception("PMDSBusiness.saveMedikamenteBestellt: " + ex.ToString());
            }
        }
        public bool AddBestellungen(ref List<PMDS.DB.PMDSBusiness.cField> lstData)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    DateTime dBestellDatum = DateTime.Now;
                    bool SaveChanges = false;
                    DateTime dNow = DateTime.Now;
                    string sMedikamenteBestellt = "";
                    Guid IDAufenthalt = System.Guid.Empty;

                    if (lstData.Count > 0)
                    {
                        foreach (PMDS.DB.PMDSBusiness.cField Field in lstData)
                        {
                            RezeptBestellungPos rNewRezeptBestPos = new db.Entities.RezeptBestellungPos();
                            rNewRezeptBestPos.ID = System.Guid.NewGuid();
                            rNewRezeptBestPos.BestelltJN = false;
                            rNewRezeptBestPos.DatumBestellt = null;
                            rNewRezeptBestPos.Dringend = Field.Dringend;
                            rNewRezeptBestPos.GedrucktJN = false;
                            rNewRezeptBestPos.IDRezeptEintrag = (Guid)Field.ID;
                            rNewRezeptBestPos.RezeptAnforderungDatum = dNow;
                            rNewRezeptBestPos.Packungsanzahl = Field.Packungsanzahl;

                            db.RezeptBestellungPos.Add(rNewRezeptBestPos);

                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(p => p.ID == rNewRezeptBestPos.IDRezeptEintrag);
                            PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();
                            rRezeptEintrag.BestellenJN = false;
                            rRezeptEintrag.ZuletztBestelltAm = dBestellDatum;
                            rRezeptEintrag.ZuletztBestelltVon = ENV.USERID;
                            Field.ZuletztBestelltAm = dBestellDatum;
                            Field.ZuletztBestelltVon = ENV.USERID;
                            
                            //Text für Pflegeeintrag merken
                            System.Linq.IQueryable<PMDS.db.Entities.Medikament> tMedikament = db.Medikament.Where(p => p.ID == rRezeptEintrag.IDMedikament);
                            PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                            sMedikamenteBestellt += (sMedikamenteBestellt == "") ? "" : "\r\n";
                            sMedikamenteBestellt +=  rMedikament.Bezeichnung + " (" + rMedikament.Packungsgroesse.ToString() + " " + rMedikament.Packungseinheit.ToString() + ")";
                            sMedikamenteBestellt += (Field.Dringend == true) ? QS2.Desktop.ControlManagment.ControlManagment.getRes(", dringend") : "";    
                            sMedikamenteBestellt += (rRezeptEintrag.Packungsanzahl > 0) ? ", OP" + rRezeptEintrag.Packungsanzahl.ToString() : "";
                            IDAufenthalt = (Guid) rRezeptEintrag.IDAufenthalt;

                            SaveChanges = true;
                        }
                    }
                    if (SaveChanges)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(p => p.ID == IDAufenthalt);
                        PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();

                        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.AddPflegeeintrag(db, sMedikamenteBestellt, dNow, null, rAufenthalt.IDBereich,
                                            IDAufenthalt, null, PflegeEintragTyp.MEDIKAMENT,
                                            null, rAufenthalt.IDAbteilung, "Medikamentenbestellung");

                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.AddBestellungen: " + ex.ToString());
            }
        }
        public bool DeleteBestellungen(ref List<PMDS.DB.PMDSBusiness.cField> lstData, ref int iCounterDeleted)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    DateTime dBestellDatum = DateTime.Now;
                    bool SaveChanges = false;
                    if (lstData.Count > 0)
                    {
                        foreach (PMDS.DB.PMDSBusiness.cField Field in lstData)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.RezeptBestellungPos> tRezeptBestellungPos = db.RezeptBestellungPos.Where(p => p.ID == Field.ID);
                            PMDS.db.Entities.RezeptBestellungPos rRezeptBestellungPos = tRezeptBestellungPos.First();
                            db.RezeptBestellungPos.Remove(rRezeptBestellungPos);
                            iCounterDeleted += 1;
                            SaveChanges = true;
                        }
                    }
                    if (SaveChanges)
                    {
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeleteBestellungen: " + ex.ToString());
            }
        }

        public bool UpdateMedikamenteAsGedruckt(List<PMDS.db.Entities.vRezeptBestellung2> tRezepteBestSelected)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool SaveChanges = false;
                    foreach (PMDS.db.Entities.vRezeptBestellung2 rvRezeptBestellung2 in tRezepteBestSelected)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptBestellungPos> tRezeptBestellungPos = db.RezeptBestellungPos.Where(p => p.ID == rvRezeptBestellung2.rbp_ID);
                        PMDS.db.Entities.RezeptBestellungPos rRezeptBestellungPos = tRezeptBestellungPos.First();
                        rRezeptBestellungPos.GedrucktJN = true;
                        rRezeptBestellungPos.DatumGedruckt = dNow;

                        SaveChanges = true;
                    }
                    if (SaveChanges)
                    {
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UpdateMedikamenteAsGedruckt: " + ex.ToString());
            }
        }
        public bool Gegenzeichnen(System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow> lstÜbergabe,
                                    ref int iCounterAbgezeichnet, bool WithMsgBox, bool doArztabrechnungen)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                PMDS.db.Entities.Benutzer rUsr = this.LogggedOnUser();
                int iCountNichtGegengezeichnet = 0;
                int iCounterArztabrechnungenAutoGenerated = 0;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //os-180807 - UserCanSign statt eigner Überprüfung
                    bool SaveChanges = false;
                    //bool BerufsgruppeOK = false;
                    //bool BerufsstandOK = false;
                    //bool HierarchieOK = false; 

                    PMDS.db.Entities.Benutzer rUsrLoggedOn = this.LogggedOnUser();

                    PMDS.db.Entities.AuswahlListe rBerufsstandUsrLoggedOn = db.AuswahlListe.Where(o => o.ID == rUsrLoggedOn.IDBerufsstand).First();
                    System.Collections.Generic.List<AuswahlListe> lstGruppenUsrLoggedOn = this.getBerufsgruppenFürUser(rBerufsstandUsrLoggedOn.GehörtzuGruppe.Trim());

                    foreach (PMDS.Global.db.ERSystem.dsTermine.vÜbergabeRow rÜbergabe in lstÜbergabe)
                    {
                        if (!rÜbergabe.AbgezeichnetJN)
                        {                             
                            if (ENV.adminSecure || rÜbergabe.IsIDWichtigFürNull() || rÜbergabe.IDWichtigFür == System.Guid.Empty || UserCanSignInit(rÜbergabe.IDWichtigFür, rUsrLoggedOn, rBerufsstandUsrLoggedOn, lstGruppenUsrLoggedOn))
                            {
                                System.Linq.IQueryable<PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(o => o.ID == rÜbergabe.IDPflegeEintrag);
                                PflegeEintrag rPflegeEintrag = tPflegeEintrag.First();
                                rPflegeEintrag.AbgezeichnetJN = true;
                                rPflegeEintrag.AbgezeichnetAm = dNow;
                                rPflegeEintrag.AbgezeichnetIDBenutzer = ENV.USERID;
                                if (doArztabrechnungen)
                                {
                                    string ProtocolHeader = "Gegenzeichnung Pflegeeintrag " + rPflegeEintrag.ID.ToString() + ", Zeitpunkt: " + rPflegeEintrag.Zeitpunkt.ToString();
                                    if (this.doArztabrechnungen(db, rÜbergabe.IDKlient, dNow, ref iCounterArztabrechnungenAutoGenerated, ENV.USERID, ProtocolHeader))
                                    {
                                        db.SaveChanges();
                                    }
                                }
                                iCounterAbgezeichnet += 1;
                                SaveChanges = true;
                            }
                            else
                            {
                                iCountNichtGegengezeichnet += 1;
                            }
                        }
                    }
                    if (SaveChanges)
                    {
                        db.SaveChanges();
                    }
                }

                if (WithMsgBox)
                {                   
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterAbgezeichnet.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Einträg/e wurden gegengezeichnet.") + "\r\n" +
                                                                iCountNichtGegengezeichnet.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Einträg/e wurden nicht gegengezeichnet. Berufsstand bzw. Hierarchie oder Berufsgruppe nicht passend."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Gegenzeichnen"), System.Windows.Forms.MessageBoxButtons.OK, true);
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.saveMedikamenteBestellt: " + ex.ToString());
            }
        }
        public bool doArztabrechnungen(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDPatient, DateTime dNow,
                                        ref int iCounterArztabrechnungenAutoGenerated, Guid IDUser, string ProtcolHeader)
        {
            try
            {
                //Prüfen, ob der übergebene User das Recht für die Arztabrechnung hat (AdminSecure würde sonst immer einen Arztabrechnungseintrag erzeugen)
                //PMDS.db.Entities.Benutzer UserCheck = getUser(IDUser, db);
                BenutzerRechte Rights = getBenutzerRecht(db, IDUser, (int) UserRights.AutomatischeArztabrechungseinträge);
                if (Rights == null)
                {
                    return false;
                }
                
                string strLog = ProtcolHeader + "\n\r" + "KlientID " + IDPatient.ToString() + ": \n\r";

                if (this.checkPatientExists(IDPatient, db))
                {

                    PMDS.db.Entities.Patient rPatient = this.getPatient(IDPatient, db);
                    strLog += "Klient " + rPatient.Nachname + " " + rPatient.Vorname.ToString() + ": \n\r";

                    PMDS.db.Entities.Aufenthalt rAufenthalt = this.getAktuellerAufenthaltPatient(IDPatient, true, null);

                    if (rAufenthalt == null)        //Bei Dekurs für entlassenen Klienten keinen Dekurs schreiben
                    {
                        strLog += "Kein aktueller Aufenthalt";
                    }
                    else
                    {
                        strLog += "Aktueller Aufenthalt vom " + rAufenthalt.Aufnahmezeitpunkt.ToString() + ", ID = " +  rAufenthalt.ID.ToString() + "\n\r";
                        bool bIsAbwesend = false;
                        this.getOffenenUrlaub(db, rAufenthalt.ID, ref bIsAbwesend);
                        if (bIsAbwesend)
                        {
                            strLog += "Abwesend\n\r";
                        }
                        else
                        {
                            strLog += "Anwesend\n\r";
                            PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange();
                            sqlManange1.initControl();

                            System.Linq.IQueryable<AuswahlListe> tAuswahlListe = db.AuswahlListe.Where(o => o.IDAuswahlListeGruppe == "AZA" && o.GehörtzuGruppe == "Auto" && o.Hierarche > -1);
                            strLog += "Anzahl automatische Einträge gefunden in AZA-Liste: " + tAuswahlListe.Count().ToString() + "\n\r";

                            foreach (AuswahlListe rAuswahlListe in tAuswahlListe)
                            {
                                strLog += "Automatischer Eintrag wird verarbeitet: " + rAuswahlListe.Bezeichnung + "\n\r";
                                PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenlistCheck = new PMDS.Global.db.ERSystem.dsKlientenliste();
                                sqlManange1.getArztabrechnung2(dsKlientenlistCheck, PMDS.Global.ENV.USERID, "", "", dNow.Date, dNow.Date, IDPatient, null,
                                                                    rAuswahlListe.Bezeichnung.Trim(), null);

                                strLog += "Anzahl Einträge pro Tag erlaubt: " + rAuswahlListe.Hierarche.ToString() + "\n\r";
                                strLog += "Anzahl Einträge heute gefunden: " + dsKlientenlistCheck.Arztabrechnung.Rows.Count.ToString() + "\n\r";

                                if (dsKlientenlistCheck.Arztabrechnung.Rows.Count >= rAuswahlListe.Hierarche)
                                {
                                    strLog += "Neuer Eintrag NICHT erlaubt." + "\n\r";
                                }
                                else
                                {
                                    Arztabrechnung rNewArztabrechnung = new Arztabrechnung();
                                    rNewArztabrechnung.IDBenutzer = IDUser;
                                    rNewArztabrechnung.IDPatient = IDPatient;
                                    rNewArztabrechnung.Leistung1 = rAuswahlListe.Bezeichnung.Trim();
                                    rNewArztabrechnung.Leistung2 = "";
                                    rNewArztabrechnung.Leistung3 = "";
                                    rNewArztabrechnung.Anmerkung = "Auto-generated";
                                    rNewArztabrechnung.Datum = dNow;
                                    rNewArztabrechnung.ID = System.Guid.NewGuid();
                                    rNewArztabrechnung.Anmerkung = "";
                                    rNewArztabrechnung.Krankenkasse = rPatient.KrankenKasse.Trim();
                                    rNewArztabrechnung.SVNr = rPatient.VersicherungsNr.Trim();

                                    db.Arztabrechnung.Add(rNewArztabrechnung);
                                    iCounterArztabrechnungenAutoGenerated += 1;

                                    strLog += "Neuer Abrechnungseintrag wurde hinzugefügt: " + rNewArztabrechnung.ID.ToString() + "\n\r";
                                }
                            }
                        }
                    }
                }
                    
                this.saveProtocol(db, "Arztabrechnung", strLog);
                return iCounterArztabrechnungenAutoGenerated > 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.doArztabrechnungen: " + ex.ToString());
            }
        }

        public bool getAllBereichForAbteilung(System.Guid IDAbteilung, ref System.Linq.IQueryable<PMDS.db.Entities.Bereich> tBereichForAbteilung,
                                                PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                tBereichForAbteilung = db.Bereich.Where(b => b.IDAbteilung == IDAbteilung).OrderBy(o => o.Bezeichnung);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllBereichForAbteilung: " + ex.ToString());
            }
        }
        public bool getRechtBereichUserForAbteilung(System.Guid IDBereich, System.Guid IDBenutzer, ref System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer,
                                                    PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                tBereichBenutzer = db.BereichBenutzer.Where(bu => bu.IDBereich == IDBereich && bu.IDBenutzer == IDBenutzer);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getRechtBereichUserForAbteilung: " + ex.ToString());
            }
        }
        public bool SaveBereicheZuAbteilung(System.Guid IDBereich, System.Guid IDBenutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool SaveChanges = false;
                    System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzerExists = db.BereichBenutzer.Where(bb => bb.IDBereich == IDBereich && bb.IDBenutzer == IDBenutzer);
                    if (tBereichBenutzerExists.Count() == 0)
                    {
                        PMDS.db.Entities.BereichBenutzer rBereichBenutzer = new db.Entities.BereichBenutzer();
                        rBereichBenutzer.IDBereich = IDBereich;
                        rBereichBenutzer.IDBenutzer = IDBenutzer;
                        db.BereichBenutzer.Add(rBereichBenutzer);

                        SaveChanges = true;
                    }
                    if (SaveChanges)
                    {
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SaveBereicheZuAbteilung: " + ex.ToString());
            }
        }
        public bool deleteZuordnungBereich(System.Guid IDBereich, System.Guid IDBenutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool SaveChanges = false;
                    System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzerExists = db.BereichBenutzer.Where(bb => bb.IDBereich == IDBereich && bb.IDBenutzer == IDBenutzer);
                    if (tBereichBenutzerExists.Count() == 1)
                    {
                        PMDS.db.Entities.BereichBenutzer rBereichBenutzer = tBereichBenutzerExists.First();
                        db.BereichBenutzer.Remove(rBereichBenutzer);
                        SaveChanges = true;
                    }
                    if (SaveChanges)
                    {
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SaveBereicheZuAbteilung: " + ex.ToString());
            }
        }

        public bool UserHasRechtAufGesamteshausxyxyx(System.Guid IDBenutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Guid IDAbteilungGesamtesHaus = System.Guid.Empty;
                    System.Linq.IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = db.BenutzerAbteilung.Where(ba => ba.IDBenutzer == IDBenutzer && ba.IDAbteilung == IDAbteilungGesamtesHaus);
                    if (tBenutzerAbteilung.Count() == 1)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UserHasRechtAufGesamteshaus: " + ex.ToString());
            }
        }
        public bool CheckRigthForPatientxyxyx(System.Guid IDBenutzer, System.Guid IDAufenthalt, System.Guid IDAbteilung, Nullable<System.Guid> IDBereich)
        {
            try
            {
                if (this.UserHasRechtAufGesamteshausxyxyx(IDBenutzer))
                {
                    return true;
                }
                else
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                        PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();

                        System.Linq.IQueryable<PMDS.db.Entities.AufenthaltVerlauf> tAufenthaltVerlauf = db.AufenthaltVerlauf.Where(a => a.ID == rAufenthalt.IDAufenthaltVerlauf);
                        PMDS.db.Entities.AufenthaltVerlauf rAufenthaltVerlauf = tAufenthaltVerlauf.First();

                        System.Linq.IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = db.BenutzerAbteilung.Where(ba => ba.IDAbteilung == IDAbteilung && ba.IDBenutzer == IDBenutzer);     //rAufenthaltVerlauf.IDAbteilung_Nach
                        if (tBenutzerAbteilung.Count() > 0)
                        {
                            if (IDBereich != null)
                            {
                                System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = db.BereichBenutzer.Where(bb => bb.IDBenutzer == IDBenutzer && bb.IDBereich == IDBereich);                //rAufenthaltVerlauf.IDBereich
                                int iFoundBereich = tBereichBenutzer.Count();
                                if (iFoundBereich >= 1)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    return false; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CheckRigthForPatient: " + ex.ToString());
            }
        }

        public bool correctPdxBezeichnungInInterventionen(System.Guid IDPatient, bool wundeJN, System.Guid IDAufenthalt, bool AllPatients, ref string Protocoll)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                DateTime dNow = DateTime.Now;
                dNow = dNow.AddMonths(5);
                bool AnyDataChanged = false;
                int iCounterPdxUpdated = 0;


                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(IDPatient, IDAufenthalt, dNow, ENV.IDKlinik);
                    foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rInterventionen in resCheck.tInerventionen)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = db.PflegePlan.Where(o => o.ID == rInterventionen.IDPflegeplan);
                        PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlan.First();
                        if (rPflegePlan.IDEintrag != null)
                        {
                            string lstIDPDxTmp = this.s2_GetPDxIDZuPflegeplanAsString(IDAufenthalt, rPflegePlan.IDEintrag.Value);
                            System.Collections.Generic.List<string> lstPdx = qs2.core.generic.readStrVariables(lstIDPDxTmp.Trim());
                            string lstPDxBezeichnungTmp = "";
                            foreach (string IDPdx in lstPdx)
                            {
                                Guid gIDPdx = new Guid(IDPdx.Trim());
                                System.Linq.IQueryable<PMDS.db.Entities.PDX> tPDX = db.PDX.Where(o => o.ID == gIDPdx);
                                PMDS.db.Entities.PDX rPDX = tPDX.First();
                                lstPDxBezeichnungTmp += rPDX.Klartext.Trim() + ";";
                                AnyDataChanged = true;
                                iCounterPdxUpdated += 1;
                            }
                            
                            rPflegePlan.lstIDPDx = lstIDPDxTmp;
                            rPflegePlan.lstPDxBezeichnung = lstPDxBezeichnungTmp.Trim();
                            Protocoll += "Pflegeplan for Patient '' - lstPDxBezeichnung updated! (" + rPflegePlan.lstPDxBezeichnung.Trim() + ")" + "\r\n";

                            db.SaveChanges();
                        }
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.correctPdxBezeichnungInInterventionen: " + ex.ToString());
            }
        }

        public string s2_GetPDxIDZuPflegeplanAsString(System.Guid IDAufenthalt, System.Guid IDEintrag)
        {
            try
            {
                DataTable dt = new DataTable();
                OleDbCommand cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 0;
                cmd.CommandText = "select dbo.s2_GetPDxIDZuPflegeplanAsString('" + IDAufenthalt.ToString() + "','" + IDEintrag.ToString() + "')";
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return "";
                }
                else if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    return r[0].ToString().Trim();
                }
                else
                {
                    throw new Exception("s2_GetPDxIDZuPflegeplanAsString: dt.Rows.Count>1 not allowed)!");
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.s2_GetPDXzuPflegeplanAsString: " + ex.ToString());
            }
        }
        
        public bool savePlanung(PDxSelectionArgs[] PDxs, System.Guid IDPatient, bool wundeJN, System.Guid IDAufenthalt, string ResourceklientFromUI, ref System.Collections.Generic.List<cVerordnungen> lstVerordnungen)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                DateTime dNow = DateTime.Now;
                bool AnyDataChanged = false;
                bool bWarnungsmeldung = false;

                System.Collections.Generic.List<cPdx> lstPDxToSave = new System.Collections.Generic.List<cPdx>();
                this.savePlanungSortUI(ref PDxs, ref lstPDxToSave, ref ResourceklientFromUI);

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (cPdx pdxUI in lstPDxToSave)
                    {
                        PDxSelectionArgs pdxArgUI = pdxUI.pdx;
                        PMDS.db.Entities.PDX rPDX = null;
                        PMDS.db.Entities.AufenthaltPDx rAufenthaltPDx = null;

                        if (pdxUI.AnyEditedAszmFound)
                        {
                            foreach (cASZM aszmFound in pdxUI.lstAszm)
                            {
                                ASZMSelectionArgs aszmArgUI = aszmFound.Aszm;
                                if (((aszmArgUI.IsNew || aszmArgUI.IsEditedFromuser) && !aszmArgUI.HasDoubledEintrag) ||
                                    ((aszmArgUI.IsNew || aszmArgUI.IsEditedFromuser) && aszmArgUI.HasDoubledEintrag && aszmArgUI.IsLastEditDouble))
                                {
                                    if (pdxArgUI.LokalisierungJN && aszmArgUI.HasDoubledEintrag)
                                    {
                                        throw new Exception("savePlanung: rAufenthaltPDx.LokalisierungJN && aszmArgUI.HasDoubledEintrag not allowed!");
                                    }

                                    System.Linq.IQueryable<PMDS.db.Entities.Eintrag> tEintrag = db.Eintrag.Where(o => o.ID == aszmArgUI.IDEintrag);
                                    PMDS.db.Entities.Eintrag rEintrag = tEintrag.First();

                                    System.Linq.IQueryable<PMDS.db.Entities.PDX> tPDX = db.PDX.Where(o => o.ID == pdxArgUI.IDPDX);
                                    rPDX = tPDX.First();

                                    if (!pdxArgUI.LokalisierungJN && (pdxArgUI.Lokalisierung.Trim() != "" || pdxArgUI.LokalisierungSeite.Trim() != ""))
                                    {
                                        throw new Exception("savePlanung: if (!pdxArgUI.LokalisierungJN && (pdxArgUI.Lokalisierung.Trim() != '' || pdxArgUI.LokalisierungSeite.Trim() != '')) not allowed!");
                                    }
                                    if (pdxArgUI.LokalisierungJN && (pdxArgUI.Lokalisierung.Trim() == "" || pdxArgUI.LokalisierungSeite.Trim() == ""))
                                    {
                                        throw new Exception("savePlanung: if (pdxArgUI.LokalisierungJN && (pdxArgUI.Lokalisierung.Trim() == '' || pdxArgUI.LokalisierungSeite.Trim() == '')) not allowed!");
                                    }

                                    System.Linq.IQueryable<PMDS.db.Entities.AufenthaltPDx> tAufenthaltPDx = null;
                                    tAufenthaltPDx = db.AufenthaltPDx.Where(o => o.IDAufenthalt == IDAufenthalt && o.IDPDX == pdxArgUI.IDPDX &&
                                                                                    o.ErledigtJN == false && o.LokalisierungJN == pdxArgUI.LokalisierungJN &&
                                                                                    o.Lokalisierung == pdxArgUI.Lokalisierung && o.LokalisierungSeite == pdxArgUI.LokalisierungSeite);
                                        
                                    rAufenthaltPDx = null;
                                    if (tAufenthaltPDx.Count() == 0)
                                    {
                                        rAufenthaltPDx = this.InsertAufenthaltPDx(pdxArgUI, db, dNow, wundeJN, IDAufenthalt,  pdxArgUI.Resourceklient.Trim());
                                    }
                                    else
                                    {
                                        rAufenthaltPDx = tAufenthaltPDx.First();
                                        rAufenthaltPDx.resourceklient = pdxArgUI.Resourceklient.Trim();     // ResourceklientFromUI.Trim();
                                        if (rAufenthaltPDx.ID == System.Guid.Empty)
                                        {
                                            throw new Exception("savePlanung: rAufenthaltPDx.ID == System.Guid.Empty!");
                                        }
                                    }
    
                                    Nullable<System.Guid> IDUntertaegigGruppe = null;
                                    System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlanExistsInDb = db.PflegePlan.Where(o => o.IDAufenthalt == IDAufenthalt &&
                                                                                        o.IDEintrag == rEintrag.ID && o.ErledigtJN == false && o.LokalisierungJN == rAufenthaltPDx.LokalisierungJN &&
                                                                                        o.Lokalisierung == rAufenthaltPDx.Lokalisierung && o.LokalisierungSeite == rAufenthaltPDx.LokalisierungSeite);
                                    if (tPflegePlanExistsInDb.Count() == 0)
                                    {
                                        if (aszmArgUI.IsNew)
                                        {
                                            IDUntertaegigGruppe = System.Guid.NewGuid();
                                        }
                                        else
                                        {
                                            throw new Exception("savePlanung: tPflegePlanExistsInDb.Count() == 0 and not aszmArgUI.IsNew is not allowed!");
                                        }
                                    }
                                    else
                                    {
                                        if (aszmArgUI.IsNew)
                                        {
                                            if (rAufenthaltPDx.IDPDX == pdxArgUI.IDPDX && !aszmArgUI.LokalisierungJN)
                                            {
                                                PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlanExistsInDb.First();
                                                IDUntertaegigGruppe = rPflegePlan.IDUntertaegigeGruppe;
                                            }
                                            else
                                            {
                                                IDUntertaegigGruppe = System.Guid.NewGuid();
                                            }
                                        }
                                        else
                                        {
                                            PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlanExistsInDb.First();
                                            IDUntertaegigGruppe = rPflegePlan.IDUntertaegigeGruppe;
                                        }
                                    }
                                    
                                    // Zeitpunkte
                                    System.Collections.Generic.List<cZeitpunkte> lstZeitpunkte = null;
                                    if (aszmArgUI.OhneZeitBezug || aszmArgUI.EintragGruppe != PMDS.Global.EintragGruppe.M)
                                    {
                                        lstZeitpunkte = new System.Collections.Generic.List<cZeitpunkte>();
                                        cZeitpunkte newZeitpunkte = new cZeitpunkte();
                                        newZeitpunkte.ZeitpunktVonUI = aszmArgUI.StartDatum.Date;
                                        newZeitpunkte.ZeitpunktBisUI = aszmArgUI.StartDatum.Date;
                                        newZeitpunkte.ZuErledigenBis = aszmArgUI.StartDatum.Date;
                                        lstZeitpunkte.Add(newZeitpunkte);
                                    }
                                    else
                                    {
                                        lstZeitpunkte = this.getZeitpunktePlanungMaßnahme(aszmArgUI, IDPatient, wundeJN, IDAufenthalt, db, dNow, rPDX, rAufenthaltPDx, rEintrag);
                                    }
                                    if (lstZeitpunkte.Count == 0)
                                    {
                                        throw new Exception("savePlanung: lstZeitpunkte.Count == 0!");
                                    }

                                    //PP Beenden
                                    this.PflegepläneBeenden(tPflegePlanExistsInDb, lstZeitpunkte, dNow, db);
                                    tPflegePlanExistsInDb = db.PflegePlan.Where(o => o.IDAufenthalt == IDAufenthalt &&
                                                                                o.IDEintrag == rEintrag.ID && o.ErledigtJN == false && o.LokalisierungJN == rAufenthaltPDx.LokalisierungJN &&
                                                                                o.Lokalisierung == rAufenthaltPDx.Lokalisierung && o.LokalisierungSeite == rAufenthaltPDx.LokalisierungSeite);

                                    //Insert Update PP
                                    System.Collections.Generic.List<PMDS.db.Entities.PflegePlan> lstPflegepläne = new System.Collections.Generic.List<PMDS.db.Entities.PflegePlan>();
                                    System.Collections.Generic.List<cInfoPdx> lstPDx = new System.Collections.Generic.List<cInfoPdx>();
                                    PMDS.db.Entities.PflegePlan rPflegePlanForDoubled = null;
                                    PMDS.db.Entities.PflegePlanPDx rPflegePlanPDxForDoubled = null;
                                    int counterPP = 0;
                                    foreach (cZeitpunkte Zeitpunkte in lstZeitpunkte)
                                    {
                                        System.Guid IDPflegeplan = System.Guid.Empty;
                                        cModeDb ModeDb = new cModeDb();
                                        bool PflegeplanFoundInDb = false;
                                        foreach (PMDS.db.Entities.PflegePlan rPflegePlanInDb in tPflegePlanExistsInDb)
                                        {
                                            if (rPflegePlanInDb.StartDatum == Zeitpunkte.ZeitpunktVonUI)
                                            {
                                                IDPflegeplan = rPflegePlanInDb.ID;
                                                PflegeplanFoundInDb = true;
                                            }
                                        }
                                        if (PflegeplanFoundInDb)
                                        {
                                            ModeDb = cModeDb.Update;
                                        }
                                        else if (!PflegeplanFoundInDb)
                                        {
                                            IDPflegeplan = System.Guid.NewGuid();
                                            ModeDb = cModeDb.Insert;
                                        }

                                        PMDS.db.Entities.PflegePlanPDx rPflegePlanPDxFromSave = null;
                                        PMDS.db.Entities.PflegePlan rPflegePlanFromSave = null;
                                        this.savePlanungPflegeplan(pdxArgUI, aszmArgUI, IDPatient, wundeJN, IDAufenthalt, db, dNow, rPDX, rAufenthaltPDx, rEintrag,
                                                                        Zeitpunkte, ModeDb, IDPflegeplan,
                                                                        (Guid)IDUntertaegigGruppe, tPflegePlanExistsInDb,
                                                                        ref  rPflegePlanFromSave, ref rPflegePlanPDxFromSave,
                                                                        ref counterPP, ref lstPDx, ref lstPflegepläne);
                                        rPflegePlanForDoubled = rPflegePlanFromSave;
                                        rPflegePlanPDxForDoubled = rPflegePlanPDxFromSave;
                                    }
                                    
                                    string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung für Eintrag ") + rEintrag.Text.Trim();  
                                    PMDS.db.Entities.Benutzer rUsr = this.LogggedOnUser();
                                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(a => a.ID == IDAufenthalt);
                                    PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                                    
                                    if (rAufenthalt.IDBereich != System.Guid.Empty) // Wenn der Kient einem Bereich zugeordnet ist
                                    {
                                        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.AddPflegeeintrag(db, sText, dNow, rEintrag.ID, rAufenthalt.IDBereich,
                                                                                    IDAufenthalt, null, PflegeEintragTyp.PLANUNG,
                                                                                    null, rAufenthalt.IDAbteilung, "Planungsänderung");
                                    }
                                    else
                                    {
                                        if (!bWarnungsmeldung)
                                        {
                                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist keinem Bereich zugeordnet. Planung wird durchgeführt, aber es wird kein Protokoll geschrieben! \n\r" +
                                                "Bitte ordnen Sie so rasch wie möglich einen Bereich zu.");   
                                            bWarnungsmeldung = true;
                                        }
                                    }

                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception exTmp1)
                                    {
                                        try
                                        {
                                            if (PMDS.Global.ENV.checkExceptionServerNotReachable(exTmp1.ToString()))
                                            {
                                                qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                db.SaveChanges();
                                            }
                                            else
                                            {
                                                throw new Exception("savePlanung: " + exTmp1.ToString());
                                            }
                                        }
                                        catch (Exception exTmp2)
                                        {
                                            try
                                            {
                                                if (PMDS.Global.ENV.checkExceptionServerNotReachable(exTmp2.ToString()))
                                                {
                                                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                    db.SaveChanges();
                                                }
                                                else
                                                {
                                                    throw new Exception("savePlanung: " + exTmp2.ToString());
                                                }
                                            }
                                            catch (Exception exTmp3)
                                            {
                                                throw new Exception("savePlanung: " + exTmp3.ToString());
                                            }
                                        }
                                    }

                                    // Behandlung AufenthaltPDX und PflegeplanPDX bei Mehrfacheinträgen
                                    int counterApdxDoubled = 0;
                                    if (aszmArgUI.HasDoubledEintrag)
                                    {
                                        if (aszmArgUI.lstASZMDoubled.Count() > 0)
                                        {
                                            if (rAufenthaltPDx.LokalisierungJN)
                                            {
                                                throw new Exception("savePlanung: !rAufenthaltPDx.LokalisierungJN not allowed!");
                                            }

                                            foreach (cASZM aszmDoubled in aszmArgUI.lstASZMDoubled) 
                                            {
                                                System.Linq.IQueryable<PMDS.db.Entities.AufenthaltPDx> tAufenthaltPDxDoubled = null;
                                                tAufenthaltPDxDoubled = db.AufenthaltPDx.Where(o => o.IDAufenthalt == IDAufenthalt && o.IDPDX == aszmDoubled.pdx.pdx.IDPDX &&
                                                                                                    o.ErledigtJN == false && o.LokalisierungJN == pdxArgUI.LokalisierungJN &&
                                                                                                     o.Lokalisierung == pdxArgUI.Lokalisierung && o.LokalisierungSeite == pdxArgUI.LokalisierungSeite);
                                                rAufenthaltPDx = null;
                                                if (tAufenthaltPDxDoubled.Count() == 0)
                                                {
                                                    rAufenthaltPDx = this.InsertAufenthaltPDx(aszmDoubled.pdx.pdx, db, dNow, wundeJN, IDAufenthalt, pdxArgUI.Resourceklient.Trim());
                                                }
                                                else
                                                {
                                                    rAufenthaltPDx = tAufenthaltPDxDoubled.First();
                                                    if (rAufenthaltPDx.ID == System.Guid.Empty)
                                                    {
                                                        throw new Exception("savePlanung: aszmDoubled.pdx.pdx .IDAufenthaltPDX == System.Guid.Empty!");
                                                    }
                                                }

                                                PMDS.db.Entities.PflegePlanPDx rPflegePlanPDx = null;
                                                System.Linq.IQueryable<PMDS.db.Entities.PflegePlanPDx> tPflegePlanPDxExistsDoubled = null;
                                                tPflegePlanPDxExistsDoubled = db.PflegePlanPDx.Where(o => o.IDUntertaegigeGruppe == IDUntertaegigGruppe && o.IDAufenthaltPDx == rAufenthaltPDx.ID &&
                                                                                                            o.ErledigtJN == false);
                                                if (tPflegePlanPDxExistsDoubled.Count() == 0)
                                                {
                                                    rPflegePlanPDx = this.InsertPflegeplanPDx(db, dNow, wundeJN, rAufenthaltPDx.ID, (Guid)rPflegePlanPDxForDoubled.IDPflegePlan,
                                                                                                rEintrag.ID, (Guid)rAufenthaltPDx.IDPDX, IDUntertaegigGruppe);
                                                }
                                                else
                                                {
                                                    rPflegePlanPDx = tPflegePlanPDxExistsDoubled.First();
                                                    rPflegePlanPDx.IDPflegePlan = rPflegePlanForDoubled.ID;
                                                }

                                                System.Linq.IQueryable<PMDS.db.Entities.PDX> tPDXDoubled = db.PDX.Where(o => o.ID == aszmDoubled.pdx.pdx.IDPDX);
                                                PMDS.db.Entities.PDX rPDXDoubled = tPDXDoubled.First();

                                                lstPflegepläne.Add(rPflegePlanForDoubled);
                                                if (!this.PdxExistsinList(rPDXDoubled.ID, ref lstPDx))
                                                {
                                                    cInfoPdx newInfoPdx = new cInfoPdx();
                                                    newInfoPdx.PDxBezeichnung = rPDXDoubled.Klartext.Trim();
                                                    newInfoPdx.IDPDx = rPDXDoubled.ID;
                                                    lstPDx.Add(newInfoPdx); 
                                                }
                                            }

                                            try
                                            {
                                                db.SaveChanges();
                                            }
                                            catch (Exception exTmp1)
                                            {
                                                try
                                                {
                                                    if (PMDS.Global.ENV.checkExceptionServerNotReachable(exTmp1.ToString()))
                                                    {
                                                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                        db.SaveChanges();
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("savePlanung: " + exTmp1.ToString());
                                                    }
                                                }
                                                catch (Exception exTmp2)
                                                {
                                                    try
                                                    {
                                                        if (PMDS.Global.ENV.checkExceptionServerNotReachable(exTmp2.ToString()))
                                                        {
                                                            qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                            db.SaveChanges();
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("savePlanung: " + exTmp2.ToString());
                                                        }
                                                    }
                                                    catch (Exception exTmp3)
                                                    {
                                                        throw new Exception("savePlanung: " + exTmp3.ToString());
                                                    }
                                                }
                                            }

                                            counterApdxDoubled += 1;
                                        }
                                    }
                                    foreach (PMDS.db.Entities.PflegePlan rPflegeplan in lstPflegepläne)
                                    {
                                        rPflegeplan.lstPDxBezeichnung = "";
                                        rPflegeplan.lstIDPDx = "";
                                        foreach (cInfoPdx newInfoPdx in lstPDx)
                                        {
                                            rPflegeplan.lstPDxBezeichnung += newInfoPdx.PDxBezeichnung.Trim() + ";";
                                            rPflegeplan.lstIDPDx += newInfoPdx.IDPDx.ToString().Trim() + ";";
                                        }
                                    }

                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception exTmp1)
                                    {
                                        try
                                        {
                                            if (PMDS.Global.ENV.checkExceptionServerNotReachable(exTmp1.ToString()))
                                            {
                                                qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                db.SaveChanges();
                                            }
                                            else
                                            {
                                                throw new Exception("savePlanung: " + exTmp1.ToString());
                                            }
                                        }
                                        catch (Exception exTmp2)
                                        {
                                            try
                                            {
                                                if (PMDS.Global.ENV.checkExceptionServerNotReachable(exTmp2.ToString()))
                                                {
                                                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                    db.SaveChanges();
                                                }
                                                else
                                                {
                                                    throw new Exception("savePlanung: " + exTmp2.ToString());
                                                }
                                            }
                                            catch (Exception exTmp3)
                                            {
                                                throw new Exception("savePlanung: " + exTmp3.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //if (AnyDataChanged)
                    //{
                        //db.SaveChanges();
                    //}
                }

                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.savePlanung: " + ex.ToString());
            }
        }
        public bool savePlanungVerordnungen(ref System.Collections.Generic.List<cVerordnungen> lstVerordnungen)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (PMDSBusiness.cVerordnungen cVerordnungFound in lstVerordnungen)
                    {

                    }

                }

                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.savePlanungVerordnungen: " + ex.ToString());
            }
        }

        public bool PdxExistsinList(Guid IDPdx, ref System.Collections.Generic.List<cInfoPdx> lstPDx)
        {
            foreach (cInfoPdx PdxFound in lstPDx)
            {
                if (PdxFound.IDPDx.Equals(IDPdx))
                {
                    return true;
                }
            }
            return false;
        }
        public bool PflegepläneBeenden(System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlanFoundInDb,
                                        System.Collections.Generic.List<cZeitpunkte> lstZeitpunkte,
                                        DateTime dNow,
                                        PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Collections.Generic.List<PMDS.db.Entities.PflegePlan> lstRowPflegepläneBeenden = new System.Collections.Generic.List<PMDS.db.Entities.PflegePlan>();
                foreach (PMDS.db.Entities.PflegePlan rPflegePlanInDb in tPflegePlanFoundInDb)
                {
                    bool bfoundInUI = false;
                    foreach (cZeitpunkte Zeitpunkte in lstZeitpunkte)
                    {
                        DateTime dateVergleich;
                        //if (OhneZeitbezug)
                        //{
                        //    dateVergleich = new DateTime(StartdatumFromUI.Date.Year, StartdatumFromUI.Month, StartdatumFromUI.Date.Day,
                        //                                    0, 0, 0);
                        //}
                        //else
                        //{
                        //    dateVergleich = new DateTime(StartdatumFromUI.Date.Year, StartdatumFromUI.Month, StartdatumFromUI.Date.Day,
                        //                                    Zeitpunkte.ZeitpunktVon.Value.Date.Hour, Zeitpunkte.ZeitpunktVon.Value.Date.Minute, 0);
                        //}

                        if (rPflegePlanInDb.StartDatum == Zeitpunkte.ZeitpunktVonUI)
                        {
                            bfoundInUI = true;
                        }
                    }
                    if (!bfoundInUI)
                    {
                        lstRowPflegepläneBeenden.Add(rPflegePlanInDb);
                    }
                }
                foreach (PMDS.db.Entities.PflegePlan rPflegePlanEnd in lstRowPflegepläneBeenden)
                {
                    string sTextForPE = QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme umgeplant");
                    //this.EndPflegePlan(IDPflegeplanToEnd, sTextForPE, dNow, true, true, true);

                    rPflegePlanEnd.IDBenutzer_Geaendert = ENV.USERID;
                    rPflegePlanEnd.EndeDatum = dNow; ;
                    rPflegePlanEnd.ErledigtJN = true;
                    rPflegePlanEnd.ErledigtGrund = sTextForPE;
                }

                db.SaveChanges();
                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getZeitpunktepflegepläneDbNoInPlanungsUI: " + ex.ToString());
            }
        }

        public System.Collections.Generic.List<cZeitpunkte> getZeitpunktePlanungMaßnahme(ASZMSelectionArgs aszmArgUI, System.Guid IDPatient, bool wundeJN, System.Guid IDAufenthalt,
                                     PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow,
                                     PMDS.db.Entities.PDX rPDX, PMDS.db.Entities.AufenthaltPDx rAufenthaltPDx, PMDS.db.Entities.Eintrag rEintrag)
        {
            try
            {
                System.Collections.Generic.List<cZeitpunkte> lstZeitpunkte = new System.Collections.Generic.List<cZeitpunkte>();

                if (aszmArgUI.UNTERTAEGIG != null)
                {
                    foreach (DateTime Zeitpunkt in aszmArgUI.UNTERTAEGIG)
                    {
                        cZeitpunkte newZeitpunkte = new cZeitpunkte();
                        newZeitpunkte.ZeitpunktVonUI = new DateTime(aszmArgUI.StartDatum.Date.Year, aszmArgUI.StartDatum.Date.Month, aszmArgUI.StartDatum.Date.Day,
                                                                    Zeitpunkt.Hour, Zeitpunkt.Minute, 0);
                        newZeitpunkte.ZeitpunktBisUI = newZeitpunkte.ZeitpunktVonUI;
                        newZeitpunkte.ZuErledigenBis = newZeitpunkte.ZeitpunktVonUI;
                        lstZeitpunkte.Add(newZeitpunkte);
                    }
                }
                if (aszmArgUI.ZEITBEREICH != null)
                {
                    foreach (Guid IDZeitbereich in aszmArgUI.ZEITBEREICH)
                    {
                        cZeitpunkte newZeitpunkte = new cZeitpunkte();

                        System.Linq.IQueryable<PMDS.db.Entities.Zeitbereich> tZeitbereich = db.Zeitbereich.Where(o => o.ID == IDZeitbereich);
                        PMDS.db.Entities.Zeitbereich rZeitbereich = tZeitbereich.First();
                        newZeitpunkte.ZeitpunktVonUI = rZeitbereich.von;
                        newZeitpunkte.ZeitpunktVonUI = new DateTime(aszmArgUI.StartDatum.Date.Year, aszmArgUI.StartDatum.Date.Month, aszmArgUI.StartDatum.Date.Day,
                                                                    rZeitbereich.von.Hour, rZeitbereich.von.Minute, 0);

                        newZeitpunkte.ZeitpunktBisUI = new DateTime(aszmArgUI.StartDatum.Date.Year, aszmArgUI.StartDatum.Date.Month, aszmArgUI.StartDatum.Date.Day,
                                            rZeitbereich.bis.Hour, rZeitbereich.bis.Minute, 0);
                        newZeitpunkte.ZuErledigenBis = newZeitpunkte.ZeitpunktBisUI;

                        newZeitpunkte.IDZeitbereich = rZeitbereich.ID;
                        int addDay = 0;
                        if (rZeitbereich.bis.Hour < rZeitbereich.von.Hour)
                        {
                            addDay = 1;
                        }
                        newZeitpunkte.ZeitpunktBisUI = newZeitpunkte.ZeitpunktBisUI.Value.Date.AddDays(addDay);

                        lstZeitpunkte.Add(newZeitpunkte);
                    }
                }
                if (aszmArgUI.ANMERKUNG != null)
                {
                    int iCountZeitpunkte = 0;
                    foreach (cZeitpunkte Zeitpunkt in lstZeitpunkte)
                    {
                        if (aszmArgUI.ANMERKUNG[iCountZeitpunkte] == null)
                        {
                            Zeitpunkt.Anmerkung = "";
                        }
                        else
                        {
                            Zeitpunkt.Anmerkung = aszmArgUI.ANMERKUNG[iCountZeitpunkte];
                        }
                        iCountZeitpunkte += 1;
                    }
                }

                return lstZeitpunkte;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getZeitpunktePlanungMaßnahme: Aufenthalt = " + IDAufenthalt.ToString() + ", Eintrag = " + rEintrag.ID + ", " + ex.ToString());
            }
        }

        public bool savePflegeplanH(System.Guid IDPflegeplan, ref string Aktion, ref DateTime dNow)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = null;
                    tPflegePlan = db.PflegePlan.Where(o => o.ID == IDPflegeplan);
                    PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlan.First();
                    PMDS.db.Entities.PflegePlanH rPflegePlanH = this.AddPflegePlanH(rPflegePlan.ID, "", dNow, db, rPflegePlan, Aktion);
                    db.SaveChanges();
                }
                
                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.savePlanungPflegepläne: " + ex.ToString());
            }
        }
        public bool savePlanungPflegeplan(PDxSelectionArgs pdxArgUI, ASZMSelectionArgs aszmArgUI, System.Guid IDPatient, bool wundeJN, System.Guid IDAufenthalt,
                                             PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow,
                                             PMDS.db.Entities.PDX rPDX, PMDS.db.Entities.AufenthaltPDx rAufenthaltPDx, PMDS.db.Entities.Eintrag rEintrag,
                                             cZeitpunkte Zeitpunkte, cModeDb ModeDb, System.Guid IDPflegeplan,
                                             Nullable<System.Guid> IDUntertätigeGruppe, System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlanExistsInDb,
                                             ref PMDS.db.Entities.PflegePlan rPflegePlan, ref PMDS.db.Entities.PflegePlanPDx rPflegePlanPDx,
                                             ref int counterPP,
                                             ref System.Collections.Generic.List<cInfoPdx> lstPdx,
                                             ref System.Collections.Generic.List<PMDS.db.Entities.PflegePlan> lstPflegepläne)
        {
            try
            {
                if (IDUntertätigeGruppe == System.Guid.Empty)
                {
                    string xy = "";
                }
                
                bool doInsert = false;
                
                //Insert/Update PP
                if (ModeDb == cModeDb.Insert)
                {
                    rPflegePlan = this.savePflegeplanInDb(db, dNow, wundeJN, aszmArgUI, pdxArgUI, IDAufenthalt, rEintrag.ID, rPDX.ID,
                                                            ModeDb, IDPflegeplan, Zeitpunkte, IDUntertätigeGruppe, rEintrag.Text.Trim(),
                                                            ref lstPdx, ref lstPflegepläne);
                }
                else if (ModeDb == cModeDb.Update)
                {
                    rPflegePlan = this.savePflegeplanInDb(db, dNow, wundeJN, aszmArgUI, pdxArgUI, IDAufenthalt, rEintrag.ID, rPDX.ID,
                                                            ModeDb, IDPflegeplan, Zeitpunkte, IDUntertätigeGruppe, rEintrag.Text.Trim(),
                                                            ref lstPdx, ref lstPflegepläne);
                }

                if (rPflegePlan.EintragGruppe.Trim().Equals(PMDS.Global.EintragGruppe.M.ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    DateTime dNächstesDatum = (DateTime)rPflegePlan.StartDatum;           //new DateTime(rPflegeplan.StartDatum.Year, rPflegeplan.StartDatum.Month, rPflegeplan.StartDatum.Day, rPflegeplan.StartDatum.Hour, rPflegeplan.StartDatum.Minute, 0);
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDSBusiness();
                    PMDSBusiness1.getNextDatePlanungsänderung((DateTime)rPflegePlan.StartDatum, rPflegePlan.ID, ref dNächstesDatum, rPflegePlan.OhneZeitBezug,
                                                                (int)rPflegePlan.WochenTage, rPflegePlan.ID, (DateTime)rPflegePlan.StartDatum);
                    rPflegePlan.NächstesDatum = dNächstesDatum;
                    db.SaveChanges();
                }

                System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlanExistsInDbUntertätige = null;
                tPflegePlanExistsInDbUntertätige = db.PflegePlan.Where(o => o.IDUntertaegigeGruppe == IDUntertätigeGruppe);
                if (tPflegePlanExistsInDbUntertätige.Count() > 0)
                {
                    bool PflegeplanPDXInsertedFound = false;
                    int counterPPDx = 0;
                    foreach (PMDS.db.Entities.PflegePlan rpflegeplanUntertägig in tPflegePlanExistsInDbUntertätige)
                    {
                        if (!PflegeplanPDXInsertedFound)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.PflegePlanPDx> tPflegePlanPDxExists = null;
                            tPflegePlanPDxExists = db.PflegePlanPDx.Where(o => o.IDUntertaegigeGruppe == rpflegeplanUntertägig.IDUntertaegigeGruppe &&
                                                                                o.IDAufenthaltPDx == rAufenthaltPDx.ID && o.ErledigtJN == false);
                            if (tPflegePlanPDxExists.Count() == 0)
                            {
                                rPflegePlanPDx = this.InsertPflegeplanPDx(db, dNow, wundeJN, rAufenthaltPDx.ID, rPflegePlan.ID, rEintrag.ID, rPDX.ID, IDUntertätigeGruppe);
                                PflegeplanPDXInsertedFound = true;
                            }
                            else
                            {
                                rPflegePlanPDx = tPflegePlanPDxExists.First();
                                PflegeplanPDXInsertedFound = true;
                                if (counterPP == 0 && counterPPDx == 0)
                                {
                                    rPflegePlanPDx.IDPflegePlan = IDPflegeplan;
                                }
                            }
                            counterPPDx += 1;  
                        }
                    }
                }
                else
                {
                    rPflegePlanPDx = this.InsertPflegeplanPDx(db, dNow, wundeJN, rAufenthaltPDx.ID, rPflegePlan.ID, rEintrag.ID, rPDX.ID, IDUntertätigeGruppe);
                }

                //    tPflegePlanExistsInDbUntertätige = db.PflegePlan.Where(o => o.IDAufenthalt == IDAufenthalt &&
                //                                    o.IDEintrag == rEintrag.ID && (o.ErledigtJN == false || o.GeloeschtJN == false) &&
                //                                    o.IDUntertaegigeGruppe == IDUntertätigeGruppe);

                //System.Linq.IQueryable<PMDS.db.Entities.PflegePlanPDx> tPflegePlanPDxExists = db.PflegePlanPDx.Where(o => o.IDAufenthaltPDx == aszmArg.IDAufenthaltPDX &&
                //                                    o.IDPDX == rAufenthaltPDx.IDPDX && o.IDEintrag == rPflegePlan.IDEintrag);


                if (ModeDb == cModeDb.Beenden)
                {
                    throw new Exception("savePlanungPflegeplan: ModeDb == cModeDb.Beenden not allowed for IDPflegeplan '" + IDPflegeplan.ToString()  + "'!");
                }
                PMDS.db.Entities.PflegePlanH rPflegePlanH = this.AddPflegePlanH(rPflegePlan.ID, "", dNow, db, rPflegePlan, (ModeDb == cModeDb.Insert ? "A":"C"));

                db.SaveChanges();
                counterPP += 1;

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.savePlanungPflegepläne: " + ex.ToString());
            }
        }

        public AufenthaltPDx InsertAufenthaltPDx(PDxSelectionArgs pdxArg, PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow, bool wundeJN,
                                                System.Guid IDAufenthalt, string ResourceklientFromUI)
        {
            try
            {
                AufenthaltPDx newAufenthaltPDx = new AufenthaltPDx();

                newAufenthaltPDx.ID = System.Guid.NewGuid();
                newAufenthaltPDx.IDPDX = pdxArg.IDPDX;
                newAufenthaltPDx.IDAufenthalt = IDAufenthalt;
                
                newAufenthaltPDx.StartDatum = pdxArg.StartDatum;
                newAufenthaltPDx.EndeDatum = null;
                newAufenthaltPDx.ErledigtGrund = "";
                newAufenthaltPDx.ErledigtJN = false;
                newAufenthaltPDx.IDBenutzer_Erstellt = ENV.USERID;
                newAufenthaltPDx.IDBenutzer_Beendet = null;
                newAufenthaltPDx.DatumErstellt = dNow;
                newAufenthaltPDx.DatumGeaendert = dNow;

                newAufenthaltPDx.LokalisierungJN = pdxArg.LokalisierungJN;
                newAufenthaltPDx.Lokalisierung = pdxArg.Lokalisierung;
                newAufenthaltPDx.LokalisierungSeite = pdxArg.LokalisierungSeite;
                newAufenthaltPDx.resourceklient = ResourceklientFromUI.Trim();        //pdxArg.Resourceklient;
                newAufenthaltPDx.NaechsteEvaluierung = null;
                newAufenthaltPDx.NaechsteEvaluierungBemerkung = "";
                newAufenthaltPDx.IDEvaluierung = null;
                newAufenthaltPDx.wundejn = pdxArg.WundeJN;
                
                db.AufenthaltPDx.Add(newAufenthaltPDx);
                return newAufenthaltPDx;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SaveAufenthaltPDx: " + ex.ToString());
            }
        }
      
        public PMDS.db.Entities.PflegePlan savePflegeplanInDb(PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow, bool wundeJN,
                                                            ASZMSelectionArgs aszmArgUI, PDxSelectionArgs pdxArgUI, System.Guid IDAufenthalt,
                                                            System.Guid IDEintrag, System.Guid IDPDX,
                                                            cModeDb ModeDb, System.Guid IDPflegeplan,
                                                            cZeitpunkte Zeitpunkte, Nullable<System.Guid> IDUntertätigeGruppe,
                                                            string TxtEintragOrig,
                                                            ref System.Collections.Generic.List<cInfoPdx> lstPdx,
                                                            ref System.Collections.Generic.List<PMDS.db.Entities.PflegePlan> lstPflegepläne)
        {
            try
            {
                PMDS.db.Entities.PflegePlan rPflegePlan = null;
                if (ModeDb == cModeDb.Insert)
                {
                    rPflegePlan = new db.Entities.PflegePlan();
                    db.PflegePlan.Add(rPflegePlan);
                    
                    rPflegePlan.ID = IDPflegeplan;
                    rPflegePlan.IDBenutzer_Erstellt = ENV.USERID;
                    rPflegePlan.IDBenutzer_Geaendert = null;
                    rPflegePlan.IDEintrag = IDEintrag;
                    rPflegePlan.DatumErstellt = dNow;
                    rPflegePlan.LetztesDatum = null;
                    rPflegePlan.LetzteEvaluierung = null;
                    rPflegePlan.IDDekurs = null;
                    rPflegePlan.IDExtern = null;
                    rPflegePlan.PDXJN = true;
                    rPflegePlan.EndeDatum = null;
                    rPflegePlan.wundejn = pdxArgUI.WundeJN;
                    rPflegePlan.BarcodeID = -1;
                    rPflegePlan.ErledigtGrund = "";
                    rPflegePlan.ErledigtJN = false;
                    rPflegePlan.GeloeschtJN = false;
                    rPflegePlan.Startdatum_Neu = null;
                    rPflegePlan.PrivatJN = false;
                    rPflegePlan.DatumGeaendert = null;
                    rPflegePlan.NächstesDatum = null;
                    rPflegePlan.IDUntertaegigeGruppe = IDUntertätigeGruppe;
                    rPflegePlan.SpenderAbgabeJN = false;
                    rPflegePlan.EintragGruppe = aszmArgUI.EintragGruppe.ToString();
                    rPflegePlan.IDAufenthalt = IDAufenthalt;
                    rPflegePlan.IDBefund = null;

                }
                else if (ModeDb == cModeDb.Update)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = db.PflegePlan.Where(o => o.ID == IDPflegeplan);
                    rPflegePlan = tPflegePlan.First();

                    rPflegePlan.IDBenutzer_Geaendert =  ENV.USERID;
                    rPflegePlan.DatumGeaendert = dNow;
                }
                
                rPflegePlan.StartDatum = Zeitpunkte.ZeitpunktVonUI;
                rPflegePlan.ZuErledigenBis = Zeitpunkte.ZuErledigenBis;
                rPflegePlan.IDZeitbereich = Zeitpunkte.IDZeitbereich;
                rPflegePlan.Text = aszmArgUI.Text;
                if (rPflegePlan.Text.Trim().Equals((TxtEintragOrig).Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    rPflegePlan.OriginalJN = true;
                }
                else
                {
                    rPflegePlan.OriginalJN = false;
                }

                if (rPflegePlan.EintragGruppe.Trim().Equals(PMDS.Global.EintragGruppe.M.ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    rPflegePlan.OhneZeitBezug = aszmArgUI.OhneZeitBezug;
                    rPflegePlan.EinmaligJN = aszmArgUI.EinmaligJN;
                    rPflegePlan.RMOptionalJN = aszmArgUI.RMOptionalJN;
                    rPflegePlan.EintragFlag = aszmArgUI.EintragFlag;
                    rPflegePlan.Intervall = aszmArgUI.Intervall;
                    rPflegePlan.IntervallTyp = aszmArgUI.IntervallTyp;
                    rPflegePlan.WochenTage = aszmArgUI.WochenTage;
                    rPflegePlan.Dauer = aszmArgUI.Dauer;
                    rPflegePlan.IDBerufsstand = aszmArgUI.IDBerufsstand;    //lthxy
                    if (aszmArgUI.OhneZeitBezug)
                    {
                        rPflegePlan.Anmerkung = aszmArgUI.Anmerkung;
                    }
                    else
                    {
                        rPflegePlan.Anmerkung = Zeitpunkte.Anmerkung;
                    }
                    rPflegePlan.NaechsteEvaluierung = null;
                    rPflegePlan.NaechsteEvaluierungBemerkung = "";                 
                    rPflegePlan.EvalTage = 0;
                    rPflegePlan.ParalellJN = aszmArgUI.ParalellJN;
                    rPflegePlan.UntertaegigeJN = true;    //lth reinmachen -> 
                }
                else
                {
                    rPflegePlan.OhneZeitBezug = true;
                    rPflegePlan.NaechsteEvaluierung = aszmArgUI.EvalStartDatum;
                    rPflegePlan.NaechsteEvaluierungBemerkung = aszmArgUI.EvalBemerkung;
                    rPflegePlan.ParalellJN = false;
                    rPflegePlan.EintragFlag = 0;
                    if (aszmArgUI.Anmerkung == null)
                    {
                        rPflegePlan.Anmerkung = "";
                    }
                    else
                    {
                        rPflegePlan.Anmerkung = aszmArgUI.Anmerkung;
                    }
                    rPflegePlan.Dauer = 0;
                    rPflegePlan.UntertaegigeJN  = false;
                    rPflegePlan.RMOptionalJN = false;
                    rPflegePlan.EinmaligJN = false;
                    rPflegePlan.Intervall = 0;
                    rPflegePlan.IntervallTyp = 0;
                    rPflegePlan.WochenTage = 0;
                    rPflegePlan.IDBerufsstand = aszmArgUI.IDBerufsstand;   //lthxy
                    rPflegePlan.EvalTage = aszmArgUI.EvalTage;
                }

                rPflegePlan.IDLinkDokument = aszmArgUI.IDLinkDokument;
                rPflegePlan.Warnhinweis = aszmArgUI.Warnhinweis;

                rPflegePlan.LokalisierungJN = pdxArgUI.LokalisierungJN;
                rPflegePlan.Lokalisierung = pdxArgUI.Lokalisierung;
                rPflegePlan.LokalisierungSeite = pdxArgUI.LokalisierungSeite;

                rPflegePlan.lstIDPDx = "";
                rPflegePlan.lstPDxBezeichnung = "";
                rPflegePlan.AnmerkungRtf = "";
                rPflegePlan.LogInNameFrei = ENV.LoginInNameFrei;

                lstPflegepläne.Add(rPflegePlan);
                if (!this.PdxExistsinList(pdxArgUI.IDPDX, ref lstPdx))
                {
                    cInfoPdx newInfoPdx = new cInfoPdx();
                    newInfoPdx.PDxBezeichnung = pdxArgUI.Klartext.Trim();
                    newInfoPdx.IDPDx = pdxArgUI.IDPDX;
                    lstPdx.Add(newInfoPdx);
                }
               
                return rPflegePlan;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SavePflegeplan: " + ex.ToString());
            }
        }
        
        public PflegePlanPDx InsertPflegeplanPDx(PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow, bool wundeJN,
                                        System.Guid IDAufenthaltPDx, System.Guid IDPflegePlan, System.Guid IDEintrag, System.Guid IDPDX,
                                        Nullable<System.Guid> IDUntertaegigeGruppe)
        {
            try
            {
                PflegePlanPDx newPflegePlanPDx = new PflegePlanPDx();

                newPflegePlanPDx.ID = System.Guid.NewGuid();
                newPflegePlanPDx.IDPflegePlan = IDPflegePlan;
                newPflegePlanPDx.IDEintrag = IDEintrag;
                newPflegePlanPDx.IDPDX = IDPDX;
                newPflegePlanPDx.IDBenutzer_Erstellt = ENV.USERID;
                newPflegePlanPDx.IDBenutzer_Beendet = null;
                newPflegePlanPDx.DatumErstellt = dNow;
                newPflegePlanPDx.DatumBeendet = null;
                newPflegePlanPDx.ErledigtJN = false;
                newPflegePlanPDx.ErledigtGrund = "";
                newPflegePlanPDx.IDAufenthaltPDx = IDAufenthaltPDx;
                newPflegePlanPDx.IDUntertaegigeGruppe = IDUntertaegigeGruppe;

                db.PflegePlanPDx.Add(newPflegePlanPDx);
                return newPflegePlanPDx;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.InsertPflegeplanPDx: " + ex.ToString());
            }
        }

        public PflegeEintrag InsertPflegeEintrag(PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow)
        {
            try
            {
                PflegeEintrag newPflegeEintrag = new PflegeEintrag();

                newPflegeEintrag.ID = System.Guid.NewGuid();
                newPflegeEintrag.Text = "";
                newPflegeEintrag.TextRtf = "";
                newPflegeEintrag.Dekursherkunft = (int)eDekursherkunft.none;
                newPflegeEintrag.AbgezeichnetJN = false;
                newPflegeEintrag.AbzeichnenJN = false;
                newPflegeEintrag.HAGPflichtigJN = false;
                newPflegeEintrag.CC = false;
                newPflegeEintrag.TextHistorie = "";
                newPflegeEintrag.TextHistorieRtf = "";

                db.PflegeEintrag.Add(newPflegeEintrag);
                return newPflegeEintrag;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.InsertPflegeEintrag: " + ex.ToString());
            }
        }

        
        public void savePlanungSortUI(ref PDxSelectionArgs[] PDxs, ref System.Collections.Generic.List<cPdx> lstPDxToSave, ref string resourceklient)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                DateTime dNow = DateTime.Now;
                bool AnyDataChanged = false;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //List aufbauen aus UI
                    foreach (PDxSelectionArgs pdxArg in PDxs)
                    {
                        cPdx Pdx = new cPdx();
                        Pdx.pdx = pdxArg;
                        lstPDxToSave.Add(Pdx);

                        IQueryable<PMDS.db.Entities.AufenthaltPDx> tAufenthaltPDx = db.AufenthaltPDx.Where(o => o.ID == pdxArg.IDAufenthaltPDX);
                        if (tAufenthaltPDx.Count() != 0)
                        {
                            PMDS.db.Entities.AufenthaltPDx rAufenthaltPDx = tAufenthaltPDx.First();
                            rAufenthaltPDx.resourceklient = pdxArg.Resourceklient.Trim();       //resourceklient.Trim();
                        }
                        else
                        {
                            string xy = "";
                        }
                        if (Pdx.pdx.IDPDX == null)
                        {
                            throw new Exception("savePlanungSortUI: Pdx.pdx.IDPDX == null not allowed!");
                        }
                        if (Pdx.pdx.IDPDX.Equals(System.Guid.Empty))
                        {
                            throw new Exception("savePlanungSortUI: Pdx.pdx.IDPDX.Equals(System.Guid.Empty) not allowed!");
                        }
                        bool AnyEditedAszmFound = false;
                        if (pdxArg.ARGS != null)
                        {
                            foreach (ASZMSelectionArgs aszmArg in pdxArg.ARGS)
                            {
                                cASZM ASZM = new cASZM();
                                ASZM.Aszm = aszmArg;
                                ASZM.pdx = Pdx;
                            
                                if (ASZM.Aszm.IDEintrag == null)
                                {
                                    throw new Exception("savePlanungSortUI: ASZM.Aszm.IDEintrag == null not allowed!");
                                }
                                if (ASZM.Aszm.IDEintrag.Equals(System.Guid.Empty))
                                {
                                    throw new Exception("savePlanungSortUI:ASZM.Aszm.IDEintrag.Equals(System.Guid.Empty) not allowed!");
                                }

                                if (ASZM.Aszm.IDPDXEintrag == null)
                                {
                                    string xy = "";
                                }
                                if (ASZM.Aszm.IDPDXEintrag.Equals(System.Guid.Empty))
                                {
                                    string xy = "";
                                }

                                Pdx.lstAszm.Add(ASZM);
                                if (aszmArg.IsNew || aszmArg.IsEditedFromuser)
                                {
                                    AnyEditedAszmFound = true;
                                }
                            }
                            Pdx.AnyEditedAszmFound = AnyEditedAszmFound;
                        }
                    }

                    //1. Erzeugen eindeutige Liste aus ASZM-Nodes
                    //2. Suchen aller doppelten Einträge in ASZM-Nodes und erzeugen einer Liste mit diesen Einträgen
                    //3. Ermitteln des zuletzt editieren Nodes
                    //4. Liste aller Nodes an ASZM-Node anhängen
                    System.Collections.Generic.List<cListDoubledTmp> lstIDEintragUnique = new System.Collections.Generic.List<cListDoubledTmp>();
                    this.getListEintragUnique(ref lstPDxToSave, ref lstIDEintragUnique);
                    this.getListDoubledEinträge(ref lstPDxToSave, ref lstIDEintragUnique);
                    this.MarkLastEditedInAszmList(ref lstIDEintragUnique);

                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.savePlanungSortUI: " + ex.ToString());
            }
        }
        public void getListEintragUnique(ref System.Collections.Generic.List<cPdx> lstPDxToSave,
                                         ref  System.Collections.Generic.List<cListDoubledTmp> lstIDEintragUnique)
        {
            try
            {
                System.Collections.Generic.List<cASZM> lstASZMDoubled = new List<cASZM>();
                bool ParentIsLastEditDouble = false;
                foreach (cPdx pdxFound in lstPDxToSave)
                {
                    PDxSelectionArgs pdxArg = pdxFound.pdx;
                    foreach (cASZM aszmFound in pdxFound.lstAszm)
                    {
                        ASZMSelectionArgs aszmArg = aszmFound.Aszm;
                        cListDoubledTmp IDEintragUniqueFound = null;
                        bool bIDEintragParentFound = false;
                        if (!aszmFound.pdx.pdx.LokalisierungJN)
                        {
                            foreach (cListDoubledTmp ListDoubledTmp in lstIDEintragUnique)
                            {
                                if (ListDoubledTmp.IDEintrag.Equals(aszmArg.IDEintrag))
                                {
                                    IDEintragUniqueFound = ListDoubledTmp;
                                    bIDEintragParentFound = true;
                                }
                            }
                        }
                        if (!bIDEintragParentFound)
                        {
                            IDEintragUniqueFound = new cListDoubledTmp();
                            IDEintragUniqueFound.IDEintrag = aszmArg.IDEintrag;
                            IDEintragUniqueFound.LokalisierungJN = aszmFound.pdx.pdx.LokalisierungJN;
                            if (aszmFound.pdx.pdx.LokalisierungJN)
                            {
                                IDEintragUniqueFound.AszmLokalisierung = aszmFound;
                            }
                            lstIDEintragUnique.Add(IDEintragUniqueFound);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getListEintragUnique: " + ex.ToString());
            }
        }
        public void getListDoubledEinträge(ref System.Collections.Generic.List<cPdx> lstPDxToSave,
                                         ref  System.Collections.Generic.List<cListDoubledTmp> lstIDEintragUnique)
        {
            try
            {
                foreach (cListDoubledTmp ListDoubledTmp in lstIDEintragUnique)
                {
                    foreach (cPdx pdxFound in lstPDxToSave)
                    {
                        PDxSelectionArgs pdxArg = pdxFound.pdx;
                        foreach (cASZM aszmFound in pdxFound.lstAszm)
                        {
                            ASZMSelectionArgs aszmArg = aszmFound.Aszm;
                            if (ListDoubledTmp.IDEintrag.Equals(aszmArg.IDEintrag) && !aszmArg.LokalisierungJN)
                            {
                                cDoubledTmp DoubledTmpFound = new cDoubledTmp();
                                DoubledTmpFound.aszm = aszmFound;
                                DoubledTmpFound.IDUI = aszmArg.IDUI;

                                ListDoubledTmp.lstDoubledTmp.Add(DoubledTmpFound);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getListDoubledEinträge: " + ex.ToString());
            }
        }
        public void MarkLastEditedInAszmList(ref  System.Collections.Generic.List<cListDoubledTmp> lstIDEintragUnique)
        {
            try
            {
                System.Collections.Generic.List<cASZM> lstASZMDoubled = new List<cASZM>();
                bool ParentIsLastEditDouble = false;
                foreach (cListDoubledTmp IDEintragUnique in lstIDEintragUnique)
                {
                    if (!IDEintragUnique.LokalisierungJN)
                    {
                        cDoubledTmp cMostRecentDate = null;
                        Nullable<DateTime> MostRecentDate = new DateTime(1900, 1, 1);
                        foreach (cDoubledTmp DoubledTmp in IDEintragUnique.lstDoubledTmp)
                        {
                            if (DoubledTmp.aszm.Aszm.IsEditedFromUserTime > MostRecentDate)
                            {
                                cMostRecentDate = DoubledTmp;
                                MostRecentDate = DoubledTmp.aszm.Aszm.IsEditedFromUserTime;
                            }
                        }
                        if (cMostRecentDate != null)
                        {
                            if (IDEintragUnique.lstDoubledTmp.Count == 1)
                            {
                                cMostRecentDate.aszm.Aszm.IsLastEditDouble = false;
                                cMostRecentDate.aszm.Aszm.HasDoubledEintrag = false;
                                IDEintragUnique.lstDoubledTmp.Remove(cMostRecentDate);
                            }
                            else if (IDEintragUnique.lstDoubledTmp.Count > 1)
                            {
                                cMostRecentDate.aszm.Aszm.IsLastEditDouble = true;
                                cMostRecentDate.aszm.Aszm.HasDoubledEintrag = true;
                                IDEintragUnique.lstDoubledTmp.Remove(cMostRecentDate);
                                foreach (cDoubledTmp DoubledTmp in IDEintragUnique.lstDoubledTmp)
                                {
                                    if (!cMostRecentDate.aszm.pdx.pdx.IDPDX.Equals(DoubledTmp.aszm.pdx.pdx.IDPDX))
                                    {
                                        DoubledTmp.aszm.Aszm.IsLastEditDouble = false;
                                        DoubledTmp.aszm.Aszm.HasDoubledEintrag = true;
                                        cMostRecentDate.aszm.Aszm.lstASZMDoubled.Add(DoubledTmp.aszm);
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("MarkLastEditedInAszmList: IDEintragUnique.lstDoubledTmp.Count == 0 not allowed!");
                            }
                        }
                    }
                    else
                    {
                        IDEintragUnique.AszmLokalisierung.Aszm.IsLastEditDouble = false;
                        IDEintragUnique.AszmLokalisierung.Aszm.HasDoubledEintrag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.MarkLastEditedInAszmList: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.PflegePlan addPflegeplan(PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow,
                                                            System.Guid IDAufenthalt,
                                                            Nullable<System.Guid> IDUntertätigeGruppe,
                                                            string sMasssnahme, Nullable<Guid> IDBerufsstand, PMDS.Global.EintragGruppe EintragGruppe,
                                                            Nullable<System.Guid> IDBefund, int EintragFlag, string Absender)
        {
            try
            {
                PMDS.db.Entities.PflegePlan rPflegePlan = null;
                rPflegePlan = new db.Entities.PflegePlan();

                rPflegePlan.ID = System.Guid.NewGuid();
                rPflegePlan.IDBenutzer_Erstellt = ENV.USERID;
                rPflegePlan.IDBerufsstand = IDBerufsstand;
                rPflegePlan.IDBenutzer_Geaendert = null;
                rPflegePlan.IDEintrag = null;
                rPflegePlan.DatumErstellt = dNow;
                rPflegePlan.LetztesDatum = null;
                rPflegePlan.LetzteEvaluierung = null;
                rPflegePlan.IDDekurs = null;
                rPflegePlan.IDExtern = null;
                rPflegePlan.PDXJN = true;
                rPflegePlan.EndeDatum = null;
                rPflegePlan.wundejn = false;
                rPflegePlan.BarcodeID = -1;
                rPflegePlan.ErledigtGrund = "";
                rPflegePlan.ErledigtJN = false;
                rPflegePlan.GeloeschtJN = false;
                rPflegePlan.Startdatum_Neu = null;
                rPflegePlan.PrivatJN = false;
                rPflegePlan.DatumGeaendert = null;
                rPflegePlan.NächstesDatum = null;
                
                rPflegePlan.IDUntertaegigeGruppe = IDUntertätigeGruppe;
                rPflegePlan.UntertaegigeJN = false;

                rPflegePlan.SpenderAbgabeJN = false;
                rPflegePlan.IDAufenthalt = IDAufenthalt;

                rPflegePlan.StartDatum = dNow;
                rPflegePlan.ZuErledigenBis = dNow;
                rPflegePlan.IDZeitbereich = null;
                rPflegePlan.Text = sMasssnahme.Trim();
                rPflegePlan.Anmerkung = Absender.Trim();
                rPflegePlan.AnmerkungRtf = "";
                rPflegePlan.OriginalJN = false;

                rPflegePlan.OhneZeitBezug = false;
                rPflegePlan.EinmaligJN = true;
                rPflegePlan.RMOptionalJN = true;
                rPflegePlan.EintragFlag = EintragFlag;
                rPflegePlan.EintragGruppe = EintragGruppe.ToString();
                rPflegePlan.Intervall = 24;
                rPflegePlan.IntervallTyp = 0;
                rPflegePlan.WochenTage = 127;
                rPflegePlan.Dauer = 0;
                
                rPflegePlan.NaechsteEvaluierung = null;
                rPflegePlan.NaechsteEvaluierungBemerkung = "";
                rPflegePlan.EvalTage = 0;
                rPflegePlan.ParalellJN = false;
               
                rPflegePlan.IDLinkDokument = null;
                rPflegePlan.Warnhinweis = "";

                rPflegePlan.LokalisierungJN = false;
                rPflegePlan.Lokalisierung = "";
                rPflegePlan.LokalisierungSeite = "";

                rPflegePlan.lstIDPDx = "";
                rPflegePlan.lstPDxBezeichnung = "";
                rPflegePlan.IDBefund = IDBefund;
                rPflegePlan.LogInNameFrei = ENV.LoginInNameFrei;

                db.PflegePlan.Add(rPflegePlan);
                return rPflegePlan;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.addPflegeplan: " + ex.ToString());
            }
        }

        public bool addMedizinischeDatenBefund(PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow,
                                                    System.Guid IDPatient, ref string sBeschreibung, Nullable<System.Guid> IDBefund, string sTyp,
                                                    PMDS.Global.MedizinischerTyp MedizinischerTyp, string Absender, string BefundID, string BefundNummer,
                                                    string Hinweis)
        {
            try
            {
                Boolean AddNewRecord = true;

                //sBeschreibung += ", Version " + BefundID.ToString() + "-" + BefundNummer.ToString();
                //Suchen, ob es eine äktere Version gibt
                System.Linq.IQueryable<MedizinischeDaten> tMedDaten = db.MedizinischeDaten.Where(p => p.Modell == BefundID && p.IDPatient == IDPatient).OrderByDescending(p => p.Groesse);
                if (tMedDaten.Count() > 0)
                {
                    int x = tMedDaten.Count();

                    MedizinischeDaten rMedDaten = tMedDaten.First();
                    if (System.Convert.ToDecimal(rMedDaten.Groesse.ToString()) < System.Convert.ToDecimal(BefundNummer))
                    {
                        sBeschreibung += QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rErgänzung / Änderung: Ersetzt Version ") + rMedDaten.Modell.ToString() + "-" + rMedDaten.Groesse.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(", importiert am ") + rMedDaten.Von.ToString();
                    }
                    else
                        AddNewRecord = false; 
                }

                if (AddNewRecord)
                {
                    PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = new db.Entities.MedizinischeDaten();

                    rMedizinischeDaten.ID = System.Guid.NewGuid();
                    rMedizinischeDaten.IDPatient = IDPatient;
                    Benutzer rBenutzer = this.LogggedOnUser();
                    rMedizinischeDaten.IDBenutzergeaendert = rBenutzer.ID;
                    rMedizinischeDaten.MedizinischerTyp = (int)MedizinischerTyp;
                    rMedizinischeDaten.Beschreibung = sBeschreibung.Trim();
                    rMedizinischeDaten.ICDCode = "";
                    rMedizinischeDaten.Von = dNow;
                    rMedizinischeDaten.Bis = null;
                    rMedizinischeDaten.Beendigungsgrund = "";
                    rMedizinischeDaten.AufnahmediagnoseJN = false;
                    rMedizinischeDaten.Bemerkung = Absender.Trim();
                    rMedizinischeDaten.Therapie = "";
                    rMedizinischeDaten.Anzahl = 0;
                    rMedizinischeDaten.NuechternJN = false;
                    rMedizinischeDaten.AntikoaguliertJN = false;
                    rMedizinischeDaten.Handling = Hinweis;
                    rMedizinischeDaten.LetzteVersorgung = null;
                    rMedizinischeDaten.NaechsteVersorgung = null;
                    rMedizinischeDaten.Typ = sTyp.Trim();
                    rMedizinischeDaten.IDBefund = IDBefund;
                    rMedizinischeDaten.Modell = BefundID;
                    rMedizinischeDaten.Groesse = BefundNummer;
                    rMedizinischeDaten.Verordnungen = "";
                    rMedizinischeDaten.lstRezepteinträge = "";

                    db.MedizinischeDaten.Add(rMedizinischeDaten);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.addMedizinischeDaten: " + ex.ToString());
            }
        }

        #region Calc

        #endregion
        public PMDS.db.Entities.BewerberStammblatt GetBewerberStammblatt(Guid IDPatient)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.BewerberStammblatt> tBewerberstammblatt = db.BewerberStammblatt.Where(b => b.ID == IDPatient);
                    if (tBewerberstammblatt.Count() == 1)
                        return tBewerberstammblatt.First();
                    else
                        return new PMDS.db.Entities.BewerberStammblatt();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.GetBewerberStammblatt: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.Benutzer LogggedOnUser()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    return db.Benutzer.Where(b => b.ID == ENV.USERID).First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.LogggedOnUser: " + ex.ToString());
            }
        }

        public string getUserName(Guid IDUsr)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rUsr = (from b in db.Benutzer
                                where b.ID == IDUsr
                                select new
                                {
                                    ID = b.ID,
                                    Benutzer1 = b.Benutzer1
                                }).First();
                    return rUsr.Benutzer1.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getUserName: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.Benutzer LogggedOnUser(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.ID == ENV.USERID);
                return tBenutzer.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.LogggedOnUser: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Benutzer getUser(Guid IDBenutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.ID == IDBenutzer);
                    return tBenutzer.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.LogggedOnUser: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Benutzer LogggedOnUserWithCheck(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.ID == ENV.USERID);
                if (tBenutzer.Count() == 1)
                    return tBenutzer.First();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.LogggedOnUserWithCheck: " + ex.ToString());
            }
        }
        public bool checkIDIsBenutzer(Guid IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.ID == IDBenutzer);
                if (tBenutzer.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkIDIsBenutzer: " + ex.ToString());
            }
        }
        public bool checkIDIsPatient(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(b => b.ID == IDPatient);
                if (tPatient.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkIDIsPatient: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Benutzer getUser(Guid IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.ID == IDBenutzer);
                return tBenutzer.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.LogggedOnUser: " + ex.ToString());
            }
        }
        public bool checkIfUserExists(Guid IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var tBenutzer = (from b in db.Benutzer
                           where b.ID == IDBenutzer
                                 select new
                           {
                                ID = b.ID,
                                b.Nachname
                           });

                if (tBenutzer.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkIfUserExists: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Benutzer getUserByUserName(string UserName, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.Benutzer1 == UserName);
                return tBenutzer.First();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getUserByUserName: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.Benutzer> getUserByUserName2(string UserName, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b => b.Benutzer1 == UserName);
                return tBenutzer;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getUserByUserName: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.Benutzer> getAllUsers(PMDS.db.Entities.ERModellPMDSEntities db, ref System.Collections .Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer;
                tBenutzer = db.Benutzer.OrderBy(p => p.Benutzer1);
                foreach (Benutzer rBenutzer in tBenutzer)
                {
                    lstBenutzerReturn.Add(rBenutzer.ID);
                }
                return tBenutzer;
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllUsers: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.Benutzer> getAllUsers2(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer;
                tBenutzer = db.Benutzer.OrderBy(p => p.Benutzer1);
                return tBenutzer;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllUsers2: " + ex.ToString());
            }
        }
        public bool getAllUsersAbteilungBereiche(Guid IDAbteilung, Guid IDBereich, PMDS.db.Entities.ERModellPMDSEntities db,
                                                    ref System.Collections.Generic.List<Guid> lstBenutzerAll,
                                                    ref System.Collections.Generic.List<Guid> lstBenutzerReturn)
        {
            try
            {
                IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = null;
                if (IDAbteilung != System.Guid.Empty)
                {
                    tBenutzerAbteilung = db.BenutzerAbteilung.Where(o => o.IDAbteilung == IDAbteilung);
                }
                else
                {
                    tBenutzerAbteilung = db.BenutzerAbteilung;
                }

                IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = null;
                if (IDBereich != System.Guid.Empty)
                {
                    tBereichBenutzer = db.BereichBenutzer.Where(o => o.IDBereich == IDBereich);
                }
                else
                {
                    tBereichBenutzer = db.BereichBenutzer;
                }

                foreach (Guid IDBenutzerSearch in lstBenutzerAll)
                {
                    bool HasAbteilung = false;
                    foreach (BenutzerAbteilung rBenutzerAbteilung in tBenutzerAbteilung)
                    {
                        if (IDBenutzerSearch.Equals(rBenutzerAbteilung.IDBenutzer))
                        {
                            HasAbteilung = true;
                            //lstBenutzerReturn.Add(rBenutzerAbteilung.IDBenutzer);
                        }
                    }
                    foreach (BereichBenutzer rBereichBenutzer in tBereichBenutzer)
                    {
                        if (HasAbteilung && IDBenutzerSearch.Equals(rBereichBenutzer.IDBenutzer))
                        {
                            lstBenutzerReturn.Add(rBereichBenutzer.IDBenutzer);
                        }
                    }
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllUsersAbteilungBereiche: " + ex.ToString());
            }
        }


        public PMDS.db.Entities.Aufenthalt getAufenthalt(Guid IDAufenthalt)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.ID == IDAufenthalt);
                    return tAufenthalt.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAufenthalt: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Aufenthalt getAufenthalt(Guid IDAufenthalt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.ID == IDAufenthalt);
                return tAufenthalt.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAufenthalt: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Aufenthalt getLastAufenthaltEntlassen(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.IDPatient == IDPatient).OrderByDescending(o => o.Entlassungszeitpunkt);
                if (tAufenthalt.Count() > 0)
                {
                    return tAufenthalt.First();
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getLastAufenthaltEntlassen: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Aufenthalt getLastAufenthaltEntlassen2(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.IDPatient == IDPatient && o.Entlassungszeitpunkt != null).OrderByDescending(o => o.Entlassungszeitpunkt);
                if (tAufenthalt.Count() > 0)
                {
                    return tAufenthalt.First();
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getLastAufenthaltEntlassen2: " + ex.ToString());
            }
        }
        public bool checkPatientExists(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(b => b.ID == IDPatient);
                if (tPatient.Count() == 1)
                {
                    return true;
                }
                else if (tPatient.Count() == 0)
                {
                    return false;
                }
                else
                {
                    throw new Exception("checkPatientExists: tPatient.Count()>1 not allowed for IDPatient '" + IDPatient.ToString() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkPatientExists: " + ex.ToString());
            }
        }
        public bool checkAufenthaltExists(Guid IDAufenthalt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(b => b.ID == IDAufenthalt);
                if (tAufenthalt.Count() == 1)
                {
                    return true;
                }
                else if (tAufenthalt.Count() == 0)
                {
                    return false;
                }
                else
                {
                    throw new Exception("PMDSBusiness.checkAufenthaltExists: tPatient.Count()>1 not allowed for IDAufenthalt '" + IDAufenthalt.ToString() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkAufenthaltExists: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Patient getPatient(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(b => b.ID == IDPatient);
                return tPatient.First();

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusiness.getPatient"))
                {
                    return this.getPatient(IDPatient, db, IDTime);
                }
                throw new Exception("PMDSBusiness.getPatient: " + ex.ToString());
            }

        }

        public string getPatientsName(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var rPatient = (from p in db.Patient
                                       where p.ID == IDPatient
                                       select new
                                       {
                                           IDPatient = p.ID,
                                           Nachname = p.Nachname,
                                           Vorname = p.Vorname
                                       }).First();

                return rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPatientsName: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Patient getPatientByIDAufenthalt(Guid IDAufenthalt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Patient> tPatient = (from p in db.Patient
                                                     join a in db.Aufenthalt on p.ID equals a.IDPatient
                                                     where a.ID == IDAufenthalt
                                                     select p);
                return tPatient.First();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPatientByIDAufenthalt: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.Patient> getAllPatients(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.OrderBy(p => p.Nachname);
                return tPatient;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllPatients: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.archObject> getDocumentObjects(Guid IDDocu, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.archObject> tArchObject = db.archObject.Where(b => b.IDDoku == IDDocu);
                return tArchObject;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getDocumentObjects: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.Patient getPatient2(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(b => b.ID == IDPatient);
                if (tPatient.Count() == 1)
                {
                    return tPatient.First();
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPatient2: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.UrlaubVerlauf getLetzteAbwesenheit(Guid IDAufenthalt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf = db.UrlaubVerlauf.Where(b => b.IDAufenthalt == IDAufenthalt && b.EndeDatum != null).OrderByDescending(b => b.EndeDatum);
                if (tUrlaubVerlauf.Count() > 0)
                {
                    return tUrlaubVerlauf.First();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getLetzteAbwesenheit: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Klinik getKlinik(Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Klinik> tKlinik = db.Klinik.Where(b => b.ID == IDKlinik);
                return tKlinik.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getKlinik: " + ex.ToString());
            }
        }
        public Klinik getKlinikByAbteilung(Guid IDAbteilung, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Klinik> tKlinik = from k in db.Klinik
                            join a in db.Abteilung on k.ID equals a.IDKlinik
                            where a.ID == IDAbteilung
                            select k;
                if (tKlinik.Count() != 1)
                {
                    throw new Exception("getKlinikByAbteilung: tKlinik.Count() != 1 not allowed for IDAbteilung '" + IDAbteilung.ToString() + "'!");
                }

                return tKlinik.First();
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getKlinikByAbteilung: " + ex.ToString());
            }
        }
        public bool saveAnonymUser(ref Nullable<Guid> IDAnmeldungenReturn, string LogInNameFrei, ref PMDS.db.Entities.Benutzer rBenutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Anmeldungen rNewAnmeldungen = new db.Entities.Anmeldungen();

                    rNewAnmeldungen.ID = System.Guid.NewGuid();
                    rNewAnmeldungen.LogInNameFrei = LogInNameFrei.Trim() + "(" + Environment.MachineName + ")";
                    rNewAnmeldungen.Vorname = rBenutzer.Vorname.Trim();
                    rNewAnmeldungen.Nachname = rBenutzer.Nachname.Trim();
                    rNewAnmeldungen.Benutzer = rBenutzer.Benutzer1.Trim();
                    rNewAnmeldungen.LogInDatum = DateTime.Now;
                    rNewAnmeldungen.LogOutDatum = null;

                    db.Anmeldungen.Add(rNewAnmeldungen);
                    db.SaveChanges();

                    PMDS.BusinessLogic.Benutzer usr = new PMDS.BusinessLogic.Benutzer(ENV.USERID);

                    if (LogInNameFrei.Trim() != "")
                        ENV.LoginInNameFrei = LogInNameFrei.Trim() + " (" + usr.BenutzerName + ")";
                    else
                    {
                        ENV.LoginInNameFrei = usr.Nachname + " " + usr.Vorname + " (" + usr.BenutzerName + ")";
                    }

                    IDAnmeldungenReturn = rNewAnmeldungen.ID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.saveAnonymUser: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.PDX getPDX(System.Guid IDPDx, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.PDX> tPDX = db.PDX.Where(o => o.ID == IDPDx);
                PMDS.db.Entities.PDX rPDX = tPDX.First();
                return rPDX;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPDX: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.Eintrag EndEintragxy(System.Guid IDEintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Eintrag> tEintrag = db.Eintrag.Where(o => o.ID == IDEintrag);
                PMDS.db.Entities.Eintrag rEintrag = tEintrag.First();
                rEintrag.EntferntJN = true;
                return rEintrag;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.EndEintrag: " + ex.ToString());
            }
        }
        public bool checkEndAnonymLogIn()
        {
            try
            {
                if (PMDS.Global.ENV.IDAnmeldungen != null)
                {
                    if (this.endAnonymUser((Guid)PMDS.Global.ENV.IDAnmeldungen))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("PMDSBusiness.endAnonymLogIn: Error endAnonymLogIn!");
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkEndAnonymLogIn: " + ex.ToString());
            }
        }
        public bool endAnonymUser(Guid IDAnmeldungen)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Anmeldungen> tAnmeldungen = db.Anmeldungen.Where(o => o.ID == IDAnmeldungen);
                    PMDS.db.Entities.Anmeldungen rAnmeldungen = tAnmeldungen.First();
                    rAnmeldungen.LogOutDatum = DateTime.Now;
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.endAnonymUser: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.Anmeldungen getAnonymUser(Guid IDAnmeldungen, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Anmeldungen> tAnmeldungen = db.Anmeldungen.Where(o => o.ID == IDAnmeldungen);
                PMDS.db.Entities.Anmeldungen rAnmeldungen = tAnmeldungen.First();
                return rAnmeldungen;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAnonymUser: " + ex.ToString());
            }
        }
        public bool updateNächsteEvaluierung(Guid IDpflegeplan, DateTime NaechsteEvaluierung)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = db.PflegePlan.Where(o => o.ID == IDpflegeplan);
                    PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlan.First();
                    rPflegePlan.NaechsteEvaluierung = NaechsteEvaluierung.Date;
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.updateNächsteEvaluierung: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.PflegeEintrag getPflegeEintrag(Guid IDPflegeEintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(o => o.ID == IDPflegeEintrag);
                PMDS.db.Entities.PflegeEintrag rPflegeEintrag = tPflegeEintrag.First();
                return rPflegeEintrag;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPflegeEintrag: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.PflegeEintragEntwurf getPflegeEintragEntwurf(Guid IDPflegeEintragEntwurf, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.PflegeEintragEntwurf> tPflegeEintragEntwurf = db.PflegeEintragEntwurf.Where(o => o.ID == IDPflegeEintragEntwurf);
                PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurf = tPflegeEintragEntwurf.First();
                return rPflegeEintragEntwurf;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPflegeEintragEntwurf: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.vÜbergabe> getvÜbergabe(DateTime dFrom, PflegeEintragTyp PflegeEintragTyp, PMDS.db.Entities.ERModellPMDSEntities db, Guid IDPatient)
        {
            try
            {
                IQueryable<PMDS.db.Entities.vÜbergabe> tvÜbergabe = db.vÜbergabe.Where(o => o.IDKlient == IDPatient && o.EintragsTyp == (int)PflegeEintragTyp && o.DatumErstellt >= dFrom).OrderByDescending(o => o.DatumErstellt);
                return tvÜbergabe;
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getvÜbergabe: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<PMDS.db.Entities.PflegeEintrag> getPflegeEintraegeByAufenthalt(Guid IDAufenthalt, PflegeEintragTyp PflegeEintragTyp, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Collections.Generic.List<PMDS.db.Entities.PflegeEintrag> lstZeitpunkte = new System.Collections.Generic.List<PMDS.db.Entities.PflegeEintrag>();

                IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(o => o.IDAufenthalt == IDAufenthalt && o.EintragsTyp == (int)PflegeEintragTyp);
                foreach (PMDS.db.Entities.PflegeEintrag rPflegeEintrag in tPflegeEintrag)
                    lstZeitpunkte.Add(rPflegeEintrag);
                return lstZeitpunkte;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPflegeEintraegeByAufenthalt: " + ex.ToString());
            }
        }


        public PMDS.db.Entities.PflegePlan getPflegeplan(Guid IDPflegeplan, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlan = db.PflegePlan.Where(o => o.ID == IDPflegeplan);
                PMDS.db.Entities.PflegePlan rPflegePlan = tPflegePlan.First();
                return rPflegePlan;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPflegeplan: " + ex.ToString());
            }
        }
        public bool checkDateRückmeldung(DateTime DateRückmeldung, PflegeEintragTyp EintragsTyp)
        {
            try
            {
                if (!ENV.adminSecure)       //lthok   WICHTIG!!!!!! muss nsoch in die Touchdoku und  in die Schnellrückmeldung integriert werden!
                {
                    int maxFutureHours = 12;
                    string AddMsg = "";
                    if (EintragsTyp == PflegeEintragTyp.UNEXP_MASSNAHME || EintragsTyp == PflegeEintragTyp.DEKURS)
                    {
                        maxFutureHours = 0;
                        AddMsg = " mehr als " + maxFutureHours.ToString() + " Stunden";
                    }

                    DateTime dAllowed = DateTime.Now.AddHours(maxFutureHours);
                    if (DateRückmeldung > dAllowed || DBNull.Value.Equals(DateRückmeldung))
                    {
                        DateRückmeldung  = DateTime.Now;
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt der Durchführung darf nicht") + AddMsg + QS2.Desktop.ControlManagment.ControlManagment.getRes(" in der Zukunft liegen!"), "", System.Windows.Forms.MessageBoxButtons.OK, true);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkDateRückmeldung: " + ex.ToString());
            }
        }

        public bool PatientIstAbwesend(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db, ref bool PatientHasNoAktAufenthalt, ref PMDS.db.Entities.UrlaubVerlauf rUrlaubVerlaufLast)
        {
            try
            {
                PMDS.db.Entities.Patient rPatient = this.getPatient(IDPatient, db);
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.IDPatient == rPatient.ID && o.Entlassungszeitpunkt == null);
                if (tAufenthalt.Count() > 1)
                {
                    throw new Exception("PMDSBusiness.PatientIstAbwesend: Aufenthalt.Count() > 1  für IDPatient '" + IDPatient.ToString() + "'!");
                }
                else if (tAufenthalt.Count() == 0)
                {
                    PatientHasNoAktAufenthalt = true;
                    return false;
                }
                PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();

                IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf = db.UrlaubVerlauf.Where(o => o.IDAufenthalt == rAufenthalt.ID && o.EndeDatum == null).OrderByDescending(o => o.StartDatum);
                if (tUrlaubVerlauf.Count() > 0)
                {
                    rUrlaubVerlaufLast = tUrlaubVerlauf.First();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.PatientIstAbwesend: " + ex.ToString());
            }
        }


        public PMDS.db.Entities.UrlaubVerlauf rAufenthaltUrlaub(PMDS.db.Entities.Aufenthalt rAufenthalt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {


                IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf = db.UrlaubVerlauf.Where(o => o.IDAufenthalt == rAufenthalt.ID && o.EndeDatum == null).OrderByDescending(o => o.StartDatum);
                if (tUrlaubVerlauf.Count() > 0)
                    
                    return tUrlaubVerlauf.First();
                else
                    return null;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.rPatientIstAbwesend: " + ex.ToString());
            }
        }

        public bool rPatientHasNoAktAufenthalt(PMDS.db.Entities.Patient rPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {

                int icntAufenthalt = db.Aufenthalt.Where(o => o.IDPatient == rPatient.ID && o.Entlassungszeitpunkt == null).Count();
                if (icntAufenthalt > 1)
                    throw new Exception("PMDSBusiness.PatientIstAbwesend: Aufenthalt.Count() > 1  für IDPatient '" + rPatient.ID.ToString() + "'!");
                else if (icntAufenthalt == 0)
                    return true;
                else
                    return false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.rPatientHasNoAktAufenthalt: " + ex.ToString());
            }
        }




        public bool PatientIstAbwesend2(ref DataTable dt, Guid IDPatient, ref bool PatientHasNoAktAufenthalt)
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = " Select Aufenthalt.ID from Patient, Aufenthalt where Aufenthalt.IDPatient=Patient.ID and Aufenthalt.IDPatient='" + IDPatient .ToString()  + "' and Entlassungszeitpunkt is null ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    PatientHasNoAktAufenthalt = false;
                    Guid IDAufenthaltTmp = (Guid)dt.Rows[0][0];

                    dt.Clear();
                    da = new OleDbDataAdapter();
                    cmd = new OleDbCommand();
                    cmd.CommandText = " Select ID from UrlaubVerlauf where IDAufenthalt='" + IDAufenthaltTmp.ToString() + "' and EndeDatum is null ";
                    cmd.CommandTimeout = 0;
                    if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                        RBU.DataBase.CONNECTION.Open();
                    cmd.Connection = RBU.DataBase.CONNECTION;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (dt.Rows.Count == 0)
                {
                    PatientHasNoAktAufenthalt = true;
                    return false;
                }
                else
                {
                    throw new Exception("PMDSBusiness.PatientIstAbwesend2: Aufenthalt.Count() > 1  für IDPatient '" + IDPatient.ToString() + "'!");
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.PatientIstAbwesend2: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.Aufenthalt getAktuellerAufenthaltPatient(Guid IDPatient, bool OKWennKeinAufenthalt, 
                                                                            PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (db == null)
                {
                    db = PMDSBusiness.getDBContext();
                }
                
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.IDPatient == IDPatient && o.Entlassungszeitpunkt == null);
                if (tAufenthalt.Count() > 1)
                {
                    throw new Exception("PMDSBusiness.AktuellerAufenthaltPatient: Aufenthalt.Count() > 1  für IDPatient '" + IDPatient.ToString() + "'!");
                }
                else if (tAufenthalt.Count() == 0)
                {
                    if (!OKWennKeinAufenthalt)
                    {
                        throw new Exception("PMDSBusiness.AktuellerAufenthaltPatient: Aufenthalt.Count() == 0  für IDPatient '" + IDPatient.ToString() + "'!");
                    }
                    return null;
                }
                else if (tAufenthalt.Count() == 1)
                {
                    PMDS.db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                    return rAufenthalt;
                }
                else
                {
                    throw new Exception("PMDSBusiness.AktuellerAufenthaltPatient: Error get Aufenthalt not possible!" + IDPatient.ToString() + "'!");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.AktuellerAufenthaltPatient: " + ex.ToString());
            }
        }

        public IQueryable<PMDS.db.Entities.Aufenthalt> getAufenthalteEntlassen(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.IDPatient == IDPatient && o.Entlassungszeitpunkt != null).OrderByDescending(o => o.Entlassungszeitpunkt);
                return tAufenthalt;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getEntlassungszeitpunktPatient: " + ex.ToString());
            }
        }
        public void getIDAbteilungIDBereichNachAnsichtsmodus(ref Nullable<Guid> IDAbteilungReturn, ref Nullable<Guid> IDBereichReturn, Guid IDPatient,  
                                                                PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.db.Entities.Aufenthalt rAuf = this.getAktuellerAufenthaltPatient(IDPatient, false, db);
                IDAbteilungReturn = rAuf.IDAbteilung.Value;
                IDBereichReturn = rAuf.IDBereich;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getIDAbteilungIDBereichNachAnsichtsmodus: " + ex.ToString());
            }
        }
        public void getIDAbteilungIDBereichNachIDAufenthalt(ref Nullable<Guid> IDAbteilungReturn, ref Nullable<Guid> IDBereichReturn, Guid IDAufenthalt,
                                                            PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.db.Entities.Aufenthalt rAufenthalt = db.Aufenthalt.Where(o => o.ID == IDAufenthalt).First();
                IDAbteilungReturn = rAufenthalt.IDAbteilung.Value;
                IDBereichReturn = rAufenthalt.IDBereich;
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getIDAbteilungIDBereichNachIDAufenthalt: " + ex.ToString());
            }
        }

        public bool DeleteUser(Guid IDBenutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(pp => pp.ID == IDBenutzer);
                    PMDS.db.Entities.Benutzer rBenutzer = tBenutzer.First();

                    IQueryable<PMDS.db.Entities.Adresse> tAdresse = db.Adresse.Where(pp => pp.ID == rBenutzer.IDAdresse);
                    PMDS.db.Entities.Adresse rAdresse = tAdresse.First();

                    IQueryable<PMDS.db.Entities.Kontakt> tKontakt = db.Kontakt.Where(pp => pp.ID == rBenutzer.IDKontakt);
                    PMDS.db.Entities.Kontakt rKontakt = tKontakt.First();

                    IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = db.BereichBenutzer.Where(pp => pp.IDBenutzer == IDBenutzer);
                    foreach (PMDS.db.Entities.BereichBenutzer rBereichBenutzer in tBereichBenutzer)
                    {
                        IQueryable<PMDS.db.Entities.Bereich> tBereich = db.Bereich.Where(pp => pp.ID == rBereichBenutzer.IDBereich);
                        foreach (PMDS.db.Entities.Bereich rBereich in tBereich)
                        {
                            db.Bereich.Remove(rBereich);
                        }
                        db.BereichBenutzer.Remove(rBereichBenutzer);
                        //Die DELETE-Anweisung steht in Konflikt mit der REFERENCE-Einschränkung 'FK_AbteilungBereichBenutzer_Benutzer'. 
                        //Der Konflikt trat in der PMDSDev-Datenbank, Tabelle 'dbo.BereichBenutzer', column 'IDBenutzer' auf.
                    }
                    db.Kontakt.Remove(rKontakt);
                    db.Adresse.Remove(rAdresse);
                    db.Benutzer.Remove(rBenutzer);

                    db.SaveChanges();
                    return true;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeleteUser: " + ex.ToString());
            }
        }
        public void fillNewKontakt(Kontakt newKontakt)
        {
            try
            {
                newKontakt.ID = System.Guid.NewGuid();
                newKontakt.Tel = "";
                newKontakt.Fax = "";
                newKontakt.Mobil = "";
                newKontakt.Andere = "";
                newKontakt.Email = "";
                newKontakt.Ansprechpartner = "";
                newKontakt.Zusatz1 = "";
                newKontakt.Zusatz2 = "";
                newKontakt.Zusatz3 = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.fillNewKontakt: " + ex.ToString());
            }
        }
        public bool UserCanEdit(Guid IDBenutzerToCheck, PflegeEintragTyp EintragsTyp)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    return false;
                }
                else
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Benutzer rUsrLoggedOn = this.LogggedOnUser();
                        System.Linq.IQueryable<Benutzer> tBenutzerToCheck = db.Benutzer.Where(o => o.ID == IDBenutzerToCheck);
                        Benutzer rUsrErstellt = tBenutzerToCheck.First();

                        System.Linq.IQueryable<AuswahlListe> tAuswahlListeUsrLoggedOn = db.AuswahlListe.Where(o => o.ID == rUsrLoggedOn.IDBerufsstand);
                        AuswahlListe rBerufsstandUsrLoggedOn = tAuswahlListeUsrLoggedOn.First();
                        System.Collections.Generic.List<AuswahlListe> lstGruppenUsrLoggedOn = this.getBerufsgruppenFürUser(rBerufsstandUsrLoggedOn.GehörtzuGruppe.Trim());

                        System.Linq.IQueryable<AuswahlListe> tAuswahlListeUsrErstellt = db.AuswahlListe.Where(o => o.ID == rUsrErstellt.IDBerufsstand);
                        AuswahlListe rBerufsstandUsrErstellt = tAuswahlListeUsrErstellt.First();
                        System.Collections.Generic.List<AuswahlListe> lstGruppenUsrErstellt = this.getBerufsgruppenFürUser(rBerufsstandUsrErstellt.GehörtzuGruppe.Trim());

                        bool BeideGleicherBerufsgruppeAngehörig =  (from first in lstGruppenUsrErstellt
                                                    join second in lstGruppenUsrLoggedOn
                                                    on first.ID equals second.ID
                                                    select first).Count() > 0;

                        bool HierarchieUserErstelltGrößerUserLoggedOn = rBerufsstandUsrErstellt.Hierarche > rBerufsstandUsrLoggedOn.Hierarche;
                       
                        bool UserCanEdit = false;
                        if (EintragsTyp == PflegeEintragTyp.Wundtherapie)
                        {
                            //WundTherapie: 1. Benutzer selbst, 
                            //              2. Vorgesetzter innerhalb der gleichen Berufsgruppe und Recht Wundtherapie Ändern darf Wundtherapieeintrag von Untergebenen ändern
                            if (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.WundtherapieÄndern))
                            {
                                UserCanEdit = IDBenutzerToCheck == rUsrLoggedOn.ID ||
                                    (BeideGleicherBerufsgruppeAngehörig && HierarchieUserErstelltGrößerUserLoggedOn && PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.WundtherapieÄndern));
                            }
                        }
                        else if (EintragsTyp == PflegeEintragTyp.Wundverlauf)
                        {
                            //Wunde, WUndverlauf und Bilder: 1. Benutzer selbst, 
                            //              2. Vorgesetzter innerhalb der gleichen Berufsgruppe und Recht Wunde Ändern darf Wundverlauf von Untergebenen ändern
                            if (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.WundeÄndern))
                            {
                                UserCanEdit = IDBenutzerToCheck == rUsrLoggedOn.ID ||
                                    (BeideGleicherBerufsgruppeAngehörig && HierarchieUserErstelltGrößerUserLoggedOn && PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.WundeÄndern));
                            }
                        }
                        else
                        {
                            //Rückmeldungen: 3 Oder Bedingungen
                            //  1. Benutzer darf eigenen Rückmeldungen ändern und die Rückmeldung ist von ihm erstellt
                            //  2. Benutzer darf alles ändern
                            //  3. Vorgesetzter innerhalb der gleichen Berufsgruppe mit Recht eigene Rückmeldungen zu ändern darf Rückmeldungen von Untergebenen ändern
                            UserCanEdit = (
                                            PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.RueckmeldungEigeneAendern) && IDBenutzerToCheck == rUsrLoggedOn.ID) ||
                                            PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.RueckmeldungAendern) ||
                                            (BeideGleicherBerufsgruppeAngehörig && HierarchieUserErstelltGrößerUserLoggedOn && PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.RueckmeldungEigeneAendern)
                                          );

                            UserCanEdit = UserCanEdit && (EintragsTyp != PflegeEintragTyp.MEDIKAMENT) &&
                                                         (EintragsTyp != PflegeEintragTyp.NOTFALL) &&
                                                         (EintragsTyp != PflegeEintragTyp.PLANUNG) &&
                                                         (EintragsTyp != PflegeEintragTyp.EVALUIERUNG) &&
                                                         (EintragsTyp != PflegeEintragTyp.NONE);
                        }



                        return UserCanEdit || ENV.adminSecure;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UserCanEdit: " + ex.ToString());
            }
        }

    

        public void initUserCanSign(PMDS.db.Entities.Benutzer rUsr = null)
        {
            try
            {
                lstBerufsgruppenUserCanSign.Clear();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    if (rUsr == null)
                        rUsr = this.LogggedOnUser();


                    PMDS.db.Entities.AuswahlListe rBerufsstandUsrLoggedOn = db.AuswahlListe.Where(o => o.ID == rUsr.IDBerufsstand).First();
                    System.Collections.Generic.List<AuswahlListe> lstGruppenUsrLoggedOn = this.getBerufsgruppenFürUser(rBerufsstandUsrLoggedOn.GehörtzuGruppe.Trim());

                    IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlListeBER = PMDSBusiness1.GetAuswahlliste(db, "BER", -100000, false);
                    foreach (PMDS.db.Entities.AuswahlListe rAuswahlListe in tAuswahlListeBER)
                    {
                        if (PMDSBusiness1.UserCanSignInit((Guid)rAuswahlListe.ID, rUsr, rBerufsstandUsrLoggedOn, lstGruppenUsrLoggedOn))
                        {
                            lstBerufsgruppenUserCanSign.Add(rAuswahlListe.ID);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.initUserCanSign: " + ex.ToString());
            }
        }
        public bool UserCanSignInit(Guid IDBerufsstand, PMDS.db.Entities.Benutzer rUsr, PMDS.db.Entities.AuswahlListe rBerufsstandUsrLoggedOn, System.Collections.Generic.List<AuswahlListe> lstGruppenUsrLoggedOn)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    return false;
                }
                else
                {
                    if (rUsr == null)
                    {
                        rUsr = this.LogggedOnUser();
                    }

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {

                        if (rBerufsstandUsrLoggedOn == null)
                        {
                            rBerufsstandUsrLoggedOn = db.AuswahlListe.Where(o => o.ID == rUsr.IDBerufsstand).First();
                        }

                        if (lstGruppenUsrLoggedOn == null)
                        {
                            lstGruppenUsrLoggedOn = this.getBerufsgruppenFürUser(rBerufsstandUsrLoggedOn.GehörtzuGruppe.Trim());
                        }

                        PMDS.db.Entities.AuswahlListe rBerufsstandUsrSoll = db.AuswahlListe.Where(o => o.ID == IDBerufsstand).First();
                        System.Collections.Generic.List<AuswahlListe> lstGruppenUsrSoll = this.getBerufsgruppenFürUser(rBerufsstandUsrSoll.GehörtzuGruppe.Trim());

                        bool BeideGleicherBerufsgruppeAngehörig = false;
                        if (lstGruppenUsrSoll.Count == 0)               // wenn der Soll-Berufsstand keiner Berufsgruppe angehört -> keine Prüfung auf Berufsgruppe
                        {
                            BeideGleicherBerufsgruppeAngehörig = true;
                        }
                        else
                        {
                            BeideGleicherBerufsgruppeAngehörig = (from first in lstGruppenUsrSoll
                                                                  join second in lstGruppenUsrLoggedOn
                                                                       on first.ID equals second.ID
                                                                       select first).Count() > 0;
                        }

                        bool HierarchieUserSollGrößerGleichUserLoggedOn = false;
                        if (rBerufsstandUsrSoll.Hierarche >= rBerufsstandUsrLoggedOn.Hierarche || rBerufsstandUsrSoll.IstGruppe)
                        {
                            HierarchieUserSollGrößerGleichUserLoggedOn = true;
                        }

                        bool UserCanSign = BeideGleicherBerufsgruppeAngehörig && HierarchieUserSollGrößerGleichUserLoggedOn && PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.Rueckmelden);
                        return UserCanSign || ENV.adminSecure;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UserCanEdit: " + ex.ToString());
            }
        }
        public bool UserCanSign(Guid IDBerufsstand)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    return false;
                }
                else
                {
                    return PMDSBusiness.lstBerufsgruppenUserCanSign.Contains(IDBerufsstand);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.UserCanEdit: " + ex.ToString());
            }
        }



        public System.Collections.Generic.List<AuswahlListe> getBerufsgruppenFürUser(string GroupsUser)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    return db.AuswahlListe.Where(o => o.IDAuswahlListeGruppe == "BER" && o.IstGruppe == true && GroupsUser.Contains(o.Bezeichnung)).ToList();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBerufsgruppenFürUser: " + ex.ToString());
            }
        }

        public bool CopyQuickfilter(Guid IDQuickfilter, ref Guid IDQuickfilterNew)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.QuickFilter> tQuickFilter = db.QuickFilter.Where(pp => pp.ID == IDQuickfilter);
                    PMDS.db.Entities.QuickFilter rQuickFilter = tQuickFilter.First();

                    PMDS.db.Entities.QuickFilter rNewQuickFilter = new PMDS.db.Entities.QuickFilter();
                    rNewQuickFilter.ID = System.Guid.NewGuid();
                    rNewQuickFilter.Bezeichnung = "Copy of " + rQuickFilter.Bezeichnung.Trim();
                    rNewQuickFilter.MassnahmeJN = rQuickFilter.MassnahmeJN;
                    rNewQuickFilter.IDEintrag = rQuickFilter.IDEintrag;
                    rNewQuickFilter.BezugspersonJN = rQuickFilter.BezugspersonJN;
                    rNewQuickFilter.IDBenutzer = rQuickFilter.IDBenutzer;
                    rNewQuickFilter.ZeitraumJN = rQuickFilter.ZeitraumJN;
                    rNewQuickFilter.Tagevorher = rQuickFilter.Tagevorher;
                    rNewQuickFilter.Tagenachher = rQuickFilter.Tagenachher;
                    rNewQuickFilter.RueckgemeldeteTermineJN = rQuickFilter.RueckgemeldeteTermineJN;
                    rNewQuickFilter.AbwBerufstandJN = rQuickFilter.AbwBerufstandJN;
                    rNewQuickFilter.Massnahmen = rQuickFilter.Massnahmen;
                    rNewQuickFilter.TypJN = rQuickFilter.TypJN;
                    rNewQuickFilter.EintragTyp = rQuickFilter.EintragTyp;
                    rNewQuickFilter.Tooltip = rQuickFilter.Tooltip;
                    rNewQuickFilter.IDAbteilung = rQuickFilter.IDAbteilung;
                    rNewQuickFilter.BenutzenInInterventionJN = rQuickFilter.BenutzenInInterventionJN;
                    rNewQuickFilter.BenutzenInEvaluierungJN = rQuickFilter.BenutzenInEvaluierungJN;
                    rNewQuickFilter.OhneZeitBezug = rQuickFilter.OhneZeitBezug;
                    rNewQuickFilter.Reihenfolge = rQuickFilter.Reihenfolge;
                    rNewQuickFilter.KeyLayout = rQuickFilter.KeyLayout;
                    rNewQuickFilter.KeyQuickFilter = rQuickFilter.KeyQuickFilter;
                    rNewQuickFilter.BereichIntervention = rQuickFilter.BereichIntervention;
                    rNewQuickFilter.BereichÜbergabe = rQuickFilter.BereichÜbergabe;
                    rNewQuickFilter.BenutzenInDekursJN = rQuickFilter.BenutzenInDekursJN;
                    rNewQuickFilter.BereichDekurs = rQuickFilter.BereichDekurs;
                    rNewQuickFilter.LstErstelltVonBerufgruppe = rQuickFilter.LstErstelltVonBerufgruppe;
                    rNewQuickFilter.LstWichtigFürBerufsgruppe = rQuickFilter.LstWichtigFürBerufsgruppe;
                    rNewQuickFilter.ShowCC = rQuickFilter.ShowCC;
                    rNewQuickFilter.LstZusatzwerte = rQuickFilter.LstZusatzwerte;
                    rNewQuickFilter.LstZeitbezug = rQuickFilter.LstZeitbezug;
                    rNewQuickFilter.LstHerkunftPlanungsEintrag = rQuickFilter.LstHerkunftPlanungsEintrag;
                    rNewQuickFilter.LstInterventionsTyp = rQuickFilter.LstInterventionsTyp;
                    rNewQuickFilter.AbzeichnenJN = rQuickFilter.AbzeichnenJN;
                    rNewQuickFilter.IsStandard = rQuickFilter.IsStandard;
                    rNewQuickFilter.LstBerufsstand = rQuickFilter.LstBerufsstand;

                    db.QuickFilter.Add(rNewQuickFilter);
                    db.SaveChanges();

                    IDQuickfilterNew = rNewQuickFilter.ID;
                    return true;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyQuickfilter: " + ex.ToString());
            }
        }

        public void SearchInPMDSList(ref System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cPMDSList> lstPMDSList,
                                    ref PMDS.DB.PMDSBusiness.cPMDSList PMDSEntryBack, ref bool bEntryFound, Guid IDAufenthalt,
                                    ref string sInitText)
        {
            try
            {
                foreach (PMDS.DB.PMDSBusiness.cPMDSList PMDSEntryInListFound in lstPMDSList)
                {
                    if (PMDSEntryInListFound.IDAufenthalt == IDAufenthalt)
                    {
                        PMDSEntryBack = PMDSEntryInListFound;
                        bEntryFound = true;
                        return;
                    }
                }
                if (!bEntryFound)
                {

                    PMDSEntryBack = new PMDS.DB.PMDSBusiness.cPMDSList();
                    PMDSEntryBack.IDAufenthalt = IDAufenthalt;
                    PMDSEntryBack.sText = sInitText + "\r\n";
                    lstPMDSList.Add(PMDSEntryBack);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SearchInPMDSList: " + ex.ToString());
            }
        }



        public bool checkArchivordner(string FolderToCheck, ref string ErrorTextBack, ref Nullable<Guid> IDOrdnerBack)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<tblOrdner> tOrdner = db.tblOrdner.Where(o => o.Bezeichnung == FolderToCheck.Trim());
                    if (tOrdner.Count() == 1)
                    {
                        tblOrdner rOrdner = tOrdner.First();
                        IDOrdnerBack = rOrdner.ID;
                        return true;
                    }
                    else if (tOrdner.Count() > 1)
                    {
                        ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv-Ordner '") + FolderToCheck .Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert mehr als einmal!");   
                        return false;
                    }
                    else 
                    {
                        ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv-Ordner '") + FolderToCheck.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!");          
                        return false;
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkArchivordner: " + ex.ToString());
            }
        }
        public tblOrdner getOrdnerArchiv(Guid IDOrdner)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<tblOrdner> tOrdner = db.tblOrdner.Where(o => o.ID == IDOrdner);
                    tblOrdner rOrdner = tOrdner.First();
                    return rOrdner;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getOrdnerArchiv: " + ex.ToString());
            }
        }
        public bool checkArchivePath(ref string ArchivePathReturn)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<tblPfad> tPfad = db.tblPfad;
                    if (tPfad.Count() == 0)
                    {
                        return false;
                    }
                    else if (tPfad.Count() == 1)
                    {
                        tblPfad rPfad = tPfad.First();
                        ArchivePathReturn = rPfad.Archivpfad.Trim();
                        return true;
                    }
                    else
                    {
                        throw new Exception("checkArchivePath: tPfad.Count() > 1 not allowed!");
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkArchivePath: " + ex.ToString());
            }
        }
        public bool SaveDokumentinArchiv(string DateinameOrig, string VerzeichnisOrig, Guid IDOrdner, string BezeichnungFile,
                                            string DateiType, string ELGADocuType, DateTime dNow, long SizeDoku, 
                                            Guid IDPatient, string PathArchive, ref Guid IDDokumenteintragReturn, string Notiz,
                                            string FileStylesheet = "", string ELGAUniqueId = "", bool IsELGADocu = false, int ELGAÜbertragen = -1, 
                                            Nullable<Guid> IDAufenthalt = null, Nullable<Guid> IDUrlaub = null)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    string FileWithPathOrig = VerzeichnisOrig.Trim() + "\\" + DateinameOrig.Trim();
                    if (!System.IO.File.Exists(FileWithPathOrig))
                    {
                        //return false;
                        throw new Exception("SaveDokumentinArchiv: File '" + FileWithPathOrig + "' nicht vorhanden!");
                    }

                    string SubArchivordner = dNow.Year.ToString() + "_" + dNow.Month.ToString();
                    string Archivordner = System.IO.Path.Combine(PathArchive.Trim(), SubArchivordner);
                    string FileWithPathArchive = System.IO.Path.Combine(Archivordner, BezeichnungFile + "_" + System.Guid.NewGuid().ToString() + DateiType);
                    if (!System.IO.Directory.Exists(Archivordner))
                    {
                        System.IO.Directory.CreateDirectory(Archivordner);
                    }

                    if (System.IO.File.Exists(FileWithPathArchive))
                    {
                        return false;
                    }

                    tblDokumenteintrag NewDokumenteintrag = new db.Entities.tblDokumenteintrag();
                    NewDokumenteintrag.ID = System.Guid.NewGuid();
                    IDDokumenteintragReturn = NewDokumenteintrag.ID;
                    NewDokumenteintrag.IDOrdner = (Guid)IDOrdner;
                    NewDokumenteintrag.Bezeichnung = BezeichnungFile.Trim();
                    NewDokumenteintrag.NotizRTF = null;
                    NewDokumenteintrag.GültigVon = null;
                    NewDokumenteintrag.GültigBis = null;
                    NewDokumenteintrag.Wichtigkeit = "";
                    NewDokumenteintrag.ErstelltAm = dNow;
                    NewDokumenteintrag.ErstelltVon = this.LogggedOnUser().Benutzer1;
                    NewDokumenteintrag.Notiz = Notiz.Trim();
                    NewDokumenteintrag.FileStylesheet = FileStylesheet.Trim();
                    NewDokumenteintrag.ELGAUniqueID = ELGAUniqueId.Trim();
                    NewDokumenteintrag.ELGAUUID = "";
                    NewDokumenteintrag.ELGAÜbertragen = ELGAÜbertragen;
                    NewDokumenteintrag.IsELGADocu = IsELGADocu;
                    NewDokumenteintrag.IDAufenthalt = IDAufenthalt;
                    NewDokumenteintrag.IDUrlaub = IDUrlaub;
                    NewDokumenteintrag.ELGADocuType = ELGADocuType.Trim();
                    NewDokumenteintrag.ELGAStorniert = false;
                    NewDokumenteintrag.ELGAStorniertDatum = null;
                    NewDokumenteintrag.ELGAStorniertUser = "";

                    db.tblDokumenteintrag.Add(NewDokumenteintrag);

                    tblDokumente NewDokument = new db.Entities.tblDokumente();
                    NewDokument.ID = System.Guid.NewGuid();
                    NewDokument.IDDokumenteintrag = NewDokumenteintrag.ID;
                    NewDokument.DateinameOrig = DateinameOrig.Trim();
                    NewDokument.VerzeichnisOrig = VerzeichnisOrig.Trim();
                    NewDokument.DokumentGröße = SizeDoku;
                    NewDokument.DokumentErstellt = dNow;
                    NewDokument.DokumentGeändert = dNow;
                    NewDokument.ErstelltAm = dNow;
                    NewDokument.ErstelltVon = this.LogggedOnUser().Benutzer1;
                    NewDokument.Winzip = false;
                    NewDokument.Archivordner = SubArchivordner;
                    NewDokument.DateinameArchiv = System.IO.Path.GetFileName(FileWithPathArchive.Trim());
                    NewDokument.DateinameTyp = DateiType.Trim();

                    db.tblDokumente.Add(NewDokument);

                    tblObjekt rObjekt = new db.Entities.tblObjekt();
                    rObjekt.ID = System.Guid.NewGuid();
                    rObjekt.IDDokumenteintrag = NewDokumenteintrag.ID ;
                    rObjekt.Datenbankidentität = false;
                    rObjekt.Server = "";
                    rObjekt.Datenbank = "";
                    rObjekt.Benutzer = "";
                    rObjekt.Passwort = "";
                    rObjekt.IDTyp = -1;
                    rObjekt.ID_guid = IDPatient;
                    rObjekt.ID_str = null;
                    rObjekt.ID_int = -1;
                    rObjekt.Bezeichnung = "";

                    db.tblObjekt.Add(rObjekt);

                    //System.GC.Collect(GC.MaxGeneration);
                    System.IO.File.Copy(FileWithPathOrig, FileWithPathArchive);
                    //System.GC.Collect(GC.MaxGeneration);

                    db.SaveChanges();
                    return true;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SaveDokumentinArchiv: " + ex.ToString());
            }
        }

        public void getDocumentFromArchive(Guid IDDokumentenEintrag, ref PMDS.db.Entities.tblDokumenteintrag rDokumenteintragReturn,
                                            ref PMDS.db.Entities.tblDokumente rDokumenteReturn)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.tblDokumenteintrag> tDokumenteintrag = db.tblDokumenteintrag.Where(o => o.ID == IDDokumentenEintrag);
                    if (tDokumenteintrag.Count() > 0 )
                    {
                        rDokumenteintragReturn = tDokumenteintrag.First();
                        Guid IDDokumenteneintragTmp = rDokumenteintragReturn.ID;
                        System.Linq.IQueryable<PMDS.db.Entities.tblDokumente> tDokumente = db.tblDokumente.Where(o => o.IDDokumenteintrag == IDDokumenteneintragTmp);
                        if (tDokumente.Count() > 0)
                        {
                            rDokumenteReturn = tDokumente.First();
                        }
                    }

                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getDocumentFromArchive: " + ex.ToString());
            }
        }
   
        public bool getIDPatientForSozVersNr(ref Nullable<Guid> IDPatientBack, string SozVersNr, DateTime GeburtsdatumPatient, ref string ErrorTextBack, 
                                                string NamePatientAusBefund)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {

                    System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatientNachSozVersNr = db.Patient.Where(o => o.VersicherungsNr.Trim().Replace(" ", "") == SozVersNr.Trim());
                    if (tPatientNachSozVersNr.Count() >= 1)
                    {
                        if (tPatientNachSozVersNr.Count() == 1)
                        {
                            PMDS.db.Entities.Patient rPatient = tPatientNachSozVersNr.First();
                            IDPatientBack = rPatient.ID;

                            //Prüfen, ob SV-Nr mit Name im Befund und im PMDS zusammen passt
                            if (!NamePatientAusBefund.ToLower().Contains(rPatient.Nachname.ToLower()))
                            {
                                ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Kombination aus SozVers.Nr (") + SozVersNr.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(") und Name im Befund (") + NamePatientAusBefund   + QS2.Desktop.ControlManagment.ControlManagment.getRes(") stimmt nicht mit den Daten im PMDS überein (") + rPatient.Nachname + ")\r\n" +
                                                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");    
                                return false;
                            }
                            return true;

                        }
                        else
                        {
                            ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren mehrere Klienten mit der SozVers.Nr '") +  SozVersNr.Trim() +  "'." + "\r\n" +
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");        
                            return false;
                        }
                    }
                    else
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatientnachGeburtsdatum = db.Patient.Where(o => o.Geburtsdatum == GeburtsdatumPatient);
                        if (tPatientnachGeburtsdatum.Count() >= 1)
                        {
                            int iPatientenFound = 0;
                            foreach (PMDS.db.Entities.Patient rPatient in tPatientnachGeburtsdatum)
                            {
                                if (rPatient.VersicherungsNr.Trim().Length == 4)        //Suchen nach SV-Nummer
                                {
                                    if (rPatient.VersicherungsNr.Trim() == SozVersNr.Trim().Substring(0, 4))
                                    {
                                        IDPatientBack = rPatient.ID;
                                        iPatientenFound += 1;
                                    }
                                }
                                else                 //Suchen nach Name
                                {
                                    string[] Namensteile = NamePatientAusBefund.Split(new string[] { ":" }, StringSplitOptions.None);
                                    if (Namensteile.Count() == 2)
                                    {
                                        if (Namensteile[0].Trim() != "" && Namensteile[1].Trim() != "")
                                        {
                                            if (rPatient.Nachname.Trim().Equals(Namensteile[0].Trim(), StringComparison.CurrentCultureIgnoreCase) &&
                                                rPatient.Vorname.Trim().Equals(Namensteile[1].Trim(), StringComparison.CurrentCultureIgnoreCase))
                                            {
                                                IDPatientBack = rPatient.ID;
                                                iPatientenFound += 1;
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                            if (iPatientenFound == 0)           
                            {
                                ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert kein Klient '") + NamePatientAusBefund.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' mit der SozVers.Nr '") + SozVersNr.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' bzw. dem Geburtsdatum '") + GeburtsdatumPatient.ToString("dd.MM.yyyy") + "'." + "\r\n" +
                                                  QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");           
                                return false;
                            }
                            else if (iPatientenFound == 1)
                            {
                                return true;
                            }
                            else
                            {
                                ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert mehr als ein Klient '") + NamePatientAusBefund.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' mit der SozVers.Nr '") + SozVersNr.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' bzw. dem Geburtsdatum '") + GeburtsdatumPatient.ToString("dd.MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes("' in der Datenbank.") + "\r\n" +
                                                             QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");      
                                return false;
                            }
                        }
                        else
                        {
                            ErrorTextBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert kein Klient '") + NamePatientAusBefund.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' mit der SozVers.Nr '") + SozVersNr.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' bzw. dem Geburtsdatum '") + GeburtsdatumPatient.ToString("dd.MM.yyyy") + "'." + "\r\n" +
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");                
                            return false;
                        }
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getIDPatientForSozVersNr: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.AuswahlListe getSelList(string Bezeichnung, string Group, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlListe = db.AuswahlListe.Where(o => o.Bezeichnung == Bezeichnung.Trim() &&
                                                                                                    o.IDAuswahlListeGruppe == Group.Trim());
                if (tAuswahlListe.Count() == 1)
                {
                    return tAuswahlListe.First();
                }
                else if (tAuswahlListe.Count() == 0)
                {
                    return null;  
                }
                else
                {
                    throw new Exception("getSelList: tAuswahlListe.Count() > 1 for Bezeichnung '" + Bezeichnung.Trim()  + "' and Group '" + Group.Trim()  + "'!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelList: " + ex.ToString());
            }
        }

        public PMDS.db.Entities.ZusatzGruppeEintrag getZusatzGruppeEintrag(Guid IDZusatzGruppeEintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.ZusatzGruppeEintrag> tZusatzGruppeEintrag = db.ZusatzGruppeEintrag.Where(o => o.ID == IDZusatzGruppeEintrag);
                PMDS.db.Entities.ZusatzGruppeEintrag rZusatzGruppeEintrag = tZusatzGruppeEintrag.First();
                return rZusatzGruppeEintrag;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getZusatzGruppeEintrag: " + ex.ToString());
            }
        }



        public List<DataFormular> getFormulardatenCountByPatient(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var tFormulardatenCountBypatient = (from fd in db.FormularDaten
                                                    join f in db.Formular on fd.FormularName equals f.Name
                                                  where fd.IDREF == IDPatient
                                                  group f by f.ID into grp
                                                  select
                                                    new {key = grp.Key, cnt = grp.Count()}).ToList();

                List<DataFormular> l = new List<DataFormular>();
                foreach (var r in tFormulardatenCountBypatient)
                    l.Add(new DataFormular() { key = r.key, cnt = r.cnt });

                return l;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getCountFormularByPatient: " + ex.ToString());
            }
        }

        public int getCountFormularByPatient(Guid IDPatient, Guid IDFormular, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Formular> tFormular = db.Formular.Where(o => o.ID == IDFormular);
                if (tFormular.Count() == 1)
                {
                    PMDS.db.Entities.Formular f = tFormular.First();
                    IQueryable<PMDS.db.Entities.FormularDaten> tFormulardaten = db.FormularDaten.Where(o => o.IDREF == IDPatient && o.FormularName == f.Name);
                    return tFormulardaten.Count();
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getCountFormularByPatient: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<FormularDaten> getFormularDatenByName(string Formularname, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<FormularDaten> tFormularDaten = db.FormularDaten.Where(o => o.FormularName == Formularname + ".s2frm");
                return tFormularDaten;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getFormularDatenByName: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<FormularDaten> getAllFormularDaten(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                //System.Linq.IQueryable<FormularDaten> tFormularDaten = db.FormularDaten.AsNoTracking().Where(o => o.FormularName == "Pflegevisite.s2frm" || o.FormularName == "Pflegevisite2.s2frm" || o.FormularName == "Pflegevisite Aktuell.s2frm");
                System.Linq.IQueryable<FormularDaten> tFormularDaten = db.FormularDaten.AsNoTracking();
                return tFormularDaten;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllFormularDaten: " + ex.ToString());
            }
        }


        public System.Linq.IQueryable<FormularDatenFelder> getFormularDatenFelderByIDFormularDaten(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<FormularDatenFelder> tFormularDatenFelder = db.FormularDatenFelder.Where(o => o.IDFormularDaten == ID); 
                return tFormularDatenFelder;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllFormularDaten: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<FormularDatenFelder> getFormularDatenFelderByID(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<FormularDatenFelder> tFormularDatenFelder = db.FormularDatenFelder;
                return tFormularDatenFelder;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllFormularDaten: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<FormularDaten> getFormularDatenByIDPatient(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<FormularDaten> tFormularDaten = db.FormularDaten.Where(o => o.IDREF == ID );
                return tFormularDaten;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getFormularDatenByName: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<FormularDaten> getFormularDatenByID(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<FormularDaten> tFormularDaten = db.FormularDaten.Where(o => o.ID == ID);
                return tFormularDaten;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getFormularDatenByID: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<Formular> getFormularByName(string Name, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Formular> tFormular = db.Formular.Where(o => o.Name == Name + ".s2frm");
                {
                    return tFormular;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getFormularByName: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<Formular> getFormularByID(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Formular> tFormular = db.Formular.Where(o => o.ID == ID);
                {
                    return tFormular;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getFormularByID: " + ex.ToString());
            }
        }

        public IQueryable<PMDS.db.Entities.s2_GetKlientenlisteAbrechnung_Result> getKlientenlisteAbrechnung(ref string KlientenName, ref Nullable<Guid> IDKostenträger,
                                                ref Nullable<DateTime> Von, ref Nullable<DateTime> Bis, 
                                                ref Nullable<int> NurSelbstzahler,
                                                PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string sIDKostenträger = null;
                if (IDKostenträger != null)
                {
                    Guid tmpIDKostenträger = System.Guid.Empty;
                    tmpIDKostenträger = (Guid)IDKostenträger;
                    sIDKostenträger = tmpIDKostenträger.ToString("D");      //IDKostenträger als String ohne {}
                }

                string sIDKlinik = ENV.IDKlinik.ToString("D");

                IQueryable<PMDS.db.Entities.s2_GetKlientenlisteAbrechnung_Result> ts2_GetKlientenlisteAbrechnung_Result = null;
                ts2_GetKlientenlisteAbrechnung_Result = db.s2_GetKlientenlisteAbrechnung(KlientenName, sIDKostenträger, Von, Bis, NurSelbstzahler, sIDKlinik);
                //ts2_GetKlientenlisteAbrechnung_Result = db.s2_GetKlientenlisteAbrechnung(null, null, null, null, null, null);

                int i = ts2_GetKlientenlisteAbrechnung_Result.Count();
                return ts2_GetKlientenlisteAbrechnung_Result;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getKlientenlisteAbrechnung: " + ex.ToString());
            }
        }



        public bool checkDateNull(ref DateTime datToCheck)
        {
            try
            {
                if (datToCheck.Date != null)
                {
                    if (datToCheck.Date != DateTime.MinValue)
                    {
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkDateNull: " + ex.ToString());
            }
        }
        public bool checkGuidEmpty(ref System.Guid guidToCheck)
        {
            try
            {
                if (guidToCheck != null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkGuidEmpty: " + ex.ToString());
            }
        }
        public string getCondition(ref string sWhere)
        {
            try
            {
                if (sWhere.Trim() == "")
                {
                    return " where ";
                }
                else
                {
                    return " and ";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getWhere: " + ex.ToString());
            }
        }

        public DateTime getAnmeldungen(string UserName)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Anmeldungen> tOrdner = db.Anmeldungen.Where(o => o.Benutzer == UserName).OrderByDescending(o => o.LogInDatum);
                    if (tOrdner.Count() > 0)
                    {
                        Anmeldungen rAnmeldungen = tOrdner.First();
                        if (!rAnmeldungen.LogInDatum.Equals(null))
                        {
                            return rAnmeldungen.LogInDatum.Value.Date;
                        }
                        else
                        {
                            return DateTime.Now.Date;
                        }
                    }
                    else
                    {
                        return DateTime.Now.Date;
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAnmeldungen: " + ex.ToString());
            }
        }
        public Anmeldungen getAnmeldung(Guid IDAnmeldung)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Anmeldungen> tAnmeldungen = db.Anmeldungen.Where(o => o.ID == IDAnmeldung);
                    if (tAnmeldungen.Count() > 0)
                    {
                        Anmeldungen rAnmeldungen = tAnmeldungen.First();
                        return rAnmeldungen;
                    }
                    else
                    {
                        throw new Exception("getAnmeldung: tAnmeldungen.Count()=0 fir IDAnmeldung '" + IDAnmeldung.ToString() + "'!");
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAnmeldung: " + ex.ToString());
            }
        }


        public void addRowToDataset(DataSet dsResult, DataRow rToAdd, System.Guid IDToCheck, string ColToCheck, string TableToAdd)
        {
            try
            {
                bool exists = false;
                foreach (DataRow rToCheck in dsResult.Tables[TableToAdd].Rows)
                {
                    if (rToCheck[ColToCheck].Equals(IDToCheck))
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    DataRow rNew = dsResult.Tables[TableToAdd].NewRow();
                    rNew.ItemArray = rToAdd.ItemArray;
                    dsResult.Tables[TableToAdd].Rows.Add(rNew);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("addRowToDataset: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PatientAerzte> getPatientÄrtze(Guid IDArzt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PatientAerzte> tPatientAerzte = db.PatientAerzte.Where(o => o.IDAerzte == IDArzt);
                return tPatientAerzte;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPatientÄrtze: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<RezeptEintrag> getRezeptEintrag(Guid IDArzt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.IDAerzte == IDArzt);
                return tRezeptEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getRezeptEintrag: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<RezeptEintrag> getRezeptEintragByID(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == ID);
                return tRezeptEintrag;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getRezeptEintragByID: " + ex.ToString());
            }
        }

        public Aerzte getArzt(Guid IDArzt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Aerzte> tAerzte = db.Aerzte.Where(o => o.ID == IDArzt);
                if (tAerzte.Count() > 0)
                {
                    return tAerzte.First();
                }
                else
                {
                    return null; 
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getArzt: " + ex.ToString());
            }
        }
        public Adresse getAdresse(Guid IDAdresse, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Adresse> tAdresse = db.Adresse.Where(o => o.ID == IDAdresse);
                return tAdresse.First();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAdresse: " + ex.ToString());
            }
        }
        public Adresse getCheckAdresse(Guid IDAdresse, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Adresse> tAdresse = db.Adresse.Where(o => o.ID == IDAdresse);
                if (tAdresse.Count() > 0)
                    return tAdresse.First();
                else
                    return null;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getCheckAdresse: " + ex.ToString());
            }
        }
        public Adresse getAdresse2(Guid IDAdresse, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Adresse> tAdresse = db.Adresse.Where(o => o.ID == IDAdresse);
                if (tAdresse.Count() == 1)
                {
                    return tAdresse.First();
                }
                else
                {
                    return null;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAdresse2: " + ex.ToString());
            }
        }
        public Kontakt getKontakt(Guid IDKontakt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Kontakt> tKontakt = db.Kontakt.Where(o => o.ID == IDKontakt);
                return tKontakt.First();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getKontakt: " + ex.ToString());
            }
        }
        public Kontakt getCheckKontakt(Guid IDKontakt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Kontakt> tKontakt = db.Kontakt.Where(o => o.ID == IDKontakt);
                if (tKontakt.Count() > 0)
                    return tKontakt.First();
                else
                    return null;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getCheckKontakt: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<Kontaktperson> getKontaktpersonen(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Kontaktperson> tKontaktperson = db.Kontaktperson.Where(o => o.IDPatient == IDPatient);
                return tKontaktperson;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getKontaktpersonen: " + ex.ToString());
            }
        }
        public Kontaktperson getKontaktperson(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Kontaktperson> tKontaktperson = db.Kontaktperson.Where(o => o.ID == ID);
                return tKontaktperson.First();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getKontaktperson: " + ex.ToString());
            }
        }
        public Sachwalter getSachwalter(Guid ID, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Sachwalter> tSachwalter = db.Sachwalter.Where(o => o.ID == ID);
                return tSachwalter.First();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSachwalter: " + ex.ToString());
            }
        }
        public Abteilung getAbteilung(Guid IDAbteilung, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Abteilung> tAbteilung = db.Abteilung.Where(o => o.ID == IDAbteilung);
                return tAbteilung.First();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAbteilung: " + ex.ToString());
            }
        }

        public Bereich getBereich(Guid IDBereich, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Bereich> tBereich = db.Bereich.Where(o => o.ID == IDBereich);
                if (tBereich.Count() > 0)
                    return tBereich.First();
                else
                    return new Bereich();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBereich: " + ex.ToString());
            }
        }


        public dsKlinik.KlinikRow loadComboAllKliniken(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, dsKlinik .KlinikDataTable tKlinik, ref bool lstKlinikenLoaded,
                                                        bool autoSelectKlinik, bool addEmptyItm = false)
        {
            try
            {
                //if (this.lstKlinikenLoaded)
                //    return null;

                cbo.Items.Clear();
                if (addEmptyItm && cbo != null)
                {
                    cbo.Items.Add(System.Guid.Empty, " ");
                }
                tKlinik.Clear();

                dsKlinik dsKlinik1 = new dsKlinik();
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);

                Infragistics.Win.ValueListItem firstKlinik = null;
                dsKlinik.KlinikRow rSelectKlinik = null;
                foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
                {
                    Infragistics.Win.ValueListItem itemKlinik = cbo.Items.Add(rKlinik.ID, rKlinik.Bezeichnung);
                    itemKlinik.Tag = rKlinik;

                    dsKlinik.KlinikRow rKlinikNew = (dsKlinik.KlinikRow)tKlinik.NewRow();
                    rKlinikNew.ItemArray = rKlinik.ItemArray;
                    tKlinik.Rows.Add(rKlinikNew);

                    if (firstKlinik == null)
                    {
                        firstKlinik = itemKlinik;
                        if (autoSelectKlinik)
                        {
                            cbo.SelectedItem = itemKlinik;
                            rSelectKlinik = rKlinik;
                        }
                    }
                }
                lstKlinikenLoaded = true;
                return rSelectKlinik;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadComboAllKliniken: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<Klinik> loadAllKliniken(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Klinik> tKlinik = db.Klinik.OrderBy(p => p.Bezeichnung);
                return tKlinik;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadAllKliniken: " + ex.ToString());
            }
        }

        public void loadCboBereiche(Nullable<Guid> IDAbteilung, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, bool addEmptyItm)
        {
            try
            {
                cbo.Items.Clear();
                if (addEmptyItm)
                {
                    cbo.Items.Add(System.Guid.Empty, " ");
                }
                if (IDAbteilung != null)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Bereich> tBereiche = this.loadBereichForAbteilung((Guid)IDAbteilung, db);
                        System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = this.getBereichBenutzer(ENV.USERID, db);

                        foreach (PMDS.db.Entities.Bereich rBereich in tBereiche)
                        {
                            var tBereichRight = (from bb in tBereichBenutzer
                                                 where bb.IDBereich == rBereich.ID
                                                 select new
                                                 {
                                                     IDBereich = bb.IDBereich
                                                 });
                            if (tBereichRight.Count() > 0)
                            {
                                Infragistics.Win.ValueListItem iotm = cbo.Items.Add(rBereich.ID, rBereich.Bezeichnung.Trim());
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadCboBereiche: " + ex.ToString());
            }
        }
        public bool loadBenutzerEinrichtungForUsers(Guid IDKlinik, Guid IDBenutzerLoggedIn, Guid IDBenutzer2, 
                                                                                            PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<BenutzerEinrichtung> tBenutzerEinrichtung1 = db.BenutzerEinrichtung.Where(p => p.IDEinrichtung == IDKlinik && p.IDBenutzer == IDBenutzerLoggedIn);
                System.Linq.IQueryable<BenutzerEinrichtung> tBenutzerEinrichtung2 = db.BenutzerEinrichtung.Where(p => p.IDEinrichtung == IDKlinik && p.IDBenutzer == IDBenutzer2);
                if (tBenutzerEinrichtung1.Count() > 0 && tBenutzerEinrichtung2.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadBenutzerEinrichtungForUsers: " + ex.ToString());
            }
        }
        public bool loadBenutzerAbteilungForUsers(Guid IDAbteilung, Guid IDBenutzerLoggedIn, Guid IDBenutzer2,
                                                                                    PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<BenutzerAbteilung> tBenutzerAbteilung1 = db.BenutzerAbteilung.Where(p => p.IDAbteilung == IDAbteilung && p.IDBenutzer == IDBenutzerLoggedIn);
                System.Linq.IQueryable<BenutzerAbteilung> tBenutzerAbteilung2 = db.BenutzerAbteilung.Where(p => p.IDAbteilung == IDAbteilung && p.IDBenutzer == IDBenutzer2);
                if (tBenutzerAbteilung1.Count() > 0 && tBenutzerAbteilung2.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadBenutzerAbteilungForUsers: " + ex.ToString());
            }
        }

        public bool checkDocumentKlientExists(Guid ID, string SqlTable, string SqlColumnBytes, string SqlColumnFileType, string KeyField, ref DataTable dtReturn)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = " Select " + KeyField.Trim() + ", " + SqlColumnBytes.Trim() + ", " + SqlColumnFileType.Trim() + " from dbo." + SqlTable.Trim() + " where (not " + SqlColumnBytes.Trim() + " is null) and " + KeyField.Trim() + "='" + ID.ToString()  + "'";
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                da.Fill(dtReturn);
                if (dtReturn.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkDocumentKlientExists: " + ex.ToString());
            }
        }
        public bool saveDocumentForKlient(Guid ID, string SqlTable, string SqlColumnBytes, string SqlColumnFileType, string KeyField, byte[] bytToSave, string FiletType, bool DeleteDocu)
        {
            try
            {
                string colJPG_Einverständniserklärung = "jpg_Einverständniserklärung";
                
                OleDbCommand cmd = new OleDbCommand();
                if (!DeleteDocu)
                {
                    if (FiletType.Trim().ToLower().Equals((".pdf").Trim().ToLower()))
                    {
                        byte[] JPGToSave = null;
                        bool JPGOK = this.pdfToImage(bytToSave, ref JPGToSave);
                        if (!JPGOK)
                        {
                            throw new Exception("pdfToImage: Jpg could not generated!");
                        }
                        cmd.CommandText = " update dbo." + SqlTable.Trim() + " set " + SqlColumnBytes + "=?, " + colJPG_Einverständniserklärung.Trim () + "=?, " + SqlColumnFileType.Trim() + "='" + FiletType.Trim() + "' where " + KeyField.Trim() + "='" + ID.ToString() + "'";
                        cmd.Parameters.Add("@" + SqlColumnBytes.Trim(), System.Data.OleDb.OleDbType.Binary, 0, SqlColumnBytes.Trim()).Value = bytToSave;
                        cmd.Parameters.Add("@" + SqlColumnBytes.Trim(), System.Data.OleDb.OleDbType.Binary, 0, SqlColumnBytes.Trim()).Value = JPGToSave;
                    }
                    else
                    {
                        cmd.CommandText = " update dbo." + SqlTable.Trim() + " set " + SqlColumnBytes + "=?, " + colJPG_Einverständniserklärung.Trim() + "=?, " + SqlColumnFileType.Trim() + "='" + FiletType.Trim() + "' where " + KeyField.Trim() + "='" + ID.ToString() + "'";
                        cmd.Parameters.Add("@" + SqlColumnBytes.Trim(), System.Data.OleDb.OleDbType.Binary, 0, SqlColumnBytes.Trim()).Value = bytToSave;
                        cmd.Parameters.Add("@" + SqlColumnBytes.Trim(), System.Data.OleDb.OleDbType.Binary, 0, SqlColumnBytes.Trim()).Value = null;
                    }
                }
                else
                {
                    cmd.CommandText = " update dbo." + SqlTable.Trim() + " set " + SqlColumnBytes + "=null, " + colJPG_Einverständniserklärung.Trim() + "=null, " + SqlColumnFileType.Trim() + " ='' where " + KeyField.Trim() + "='" + ID.ToString() + "'";
                }
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
               
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.saveDocumentForKlient: " + ex.ToString());
            }
        }

        public bool pdfToImage(byte[] bytesPDF, ref byte[] bytesJPGReturn)
        {
            try
            {
                PdfCommon.Initialize("52433553494d50032923be84e16cd6ae0bce153446af7918d52303038286fd2b0597de34bf5bb65e2a161a268e74107bd7da7c1adb202edff3e8c55a13bff7afa38569c96e45ff0cdef48e36b8df77e907676788cae00126f52c5eaadbb3c424062e8e0e5feb6faf89900306ee469aa40664bdf84b2e4fce7497c19f3f9d2d877dc1be192cb695f4");
                using (var docIn = PdfDocument.Load(bytesPDF))
                {
                    using (var docOut = PdfDocument.CreateNew())
                    {
                        docOut.Pages.ImportPages(docIn, "1", 0);

                        if (docOut.Pages.Count != 1)
                            return false;

                        PdfPage page = docOut.Pages[0];
                        int width = (int)page.Width;                                        //Gets page width and height measured in points. One point is 1/72 inch (around 0.3528 mm)
                        int height = (int)page.Height;

                        using (var bmp = new PdfBitmap((int)page.Width, height, true))      //Create a bitmap 
                        {
                            bmp.FillRect(0, 0, width, height, Color.White);                 //Fill background
                            page.Render(bmp, 0, 0, width, height,
                                Patagames.Pdf.Enums.PageRotate.Normal,
                                Patagames.Pdf.Enums.RenderFlags.FPDF_ANNOT);                //Render contents in a page to a drawing surface specified by a coordinate pair, a width, and a height.

                            using (MemoryStream ms = new MemoryStream())
                            {
                                bmp.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                bytesJPGReturn = ms.ToArray();
                                return true;
                            }
                        }
                    }
                }

                /*
                                GhostscriptVersionInfo _lastInstalledVersion = null;
                                GhostscriptRasterizer _rasterizer = null;

                                int desired_x_dpi = 300;
                                int desired_y_dpi = 300;
                                //string inputPdfPath = @pathFrom;
                                Stream stream = new MemoryStream(bytesPDF);

                                _lastInstalledVersion = GhostscriptVersionInfo.GetLastInstalledVersion(
                                                        GhostscriptLicense.GPL | GhostscriptLicense.AFPL,
                                                        GhostscriptLicense.GPL);
                                _rasterizer = new GhostscriptRasterizer();
                                _rasterizer.Open(stream, _lastInstalledVersion, false);

                                //for (int pageNumber = 1; pageNumber <= _rasterizer.PageCount; pageNumber++)
                                for (int pageNumber = 1; pageNumber <= 1; pageNumber++)
                                {
                                    //Als MemoryStream für Speichern in SQL-Feld
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        Image imgMem = _rasterizer.GetPage(desired_x_dpi, desired_y_dpi, pageNumber);
                                        imgMem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        bytesJPGReturn = this.ToByteArray(ms);
                                        //imgMem.Save("H:\\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                        ms.Close();

                                        return true;
                                    }

                                    //Website: http://ghostscript.com/download/gsdnld.html 
                                    // Installation 32 Bit Version >> C:\Program Files (x86)\gs\gs9.18
                                    // Installation 64 Bit Version >> C:\Program Files\gs\gs9.18


                                    //Speichern als jpg auf der Platte
                                    //string outputPath = @"C:\temp\GhostscriptTest\";
                                    //string pageFilePath = Path.Combine(outputPath, "Page-" + pageNumber.ToString() + ".jpg");

                                    //Image img = _rasterizer.GetPage(desired_x_dpi, desired_y_dpi, pageNumber);
                                    //img.Save(pageFilePath, ImageFormat.Jpeg);
                                    //Console.WriteLine(pageFilePath);

                                }
                                return false;
                */

            }

            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.pdfToImage: " + ex.ToString());
            }
        }
        //public bool checkGhostscriptIsinstalledOnClient()
        //{
        //    try
        //    {
        //        GhostscriptVersionInfo _lastInstalledVersion = null;
        //        GhostscriptRasterizer _rasterizer = null;

        //        _lastInstalledVersion = GhostscriptVersionInfo.GetLastInstalledVersion(
        //                                GhostscriptLicense.GPL | GhostscriptLicense.AFPL,
        //                                GhostscriptLicense.GPL);
        //        _rasterizer = new GhostscriptRasterizer();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        //throw new Exception("PMDSBusiness.checkGhostscriptIsinstalledOnClient: " + ex.ToString());
        //    }
        //}

        public byte[] ToByteArray(Stream stream)
        {
            try
            {
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                    totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
                return buffer;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.ToByteArray: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PMDS.db.Entities.Bereich> loadBereichForAbteilung(Guid IDAbteilung, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Bereich> tBereich = db.Bereich.Where(o => o.IDAbteilung == IDAbteilung);
                return tBereich;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadBereichForAbteilung: " + ex.ToString());
            }
        }




        public System.Linq.IQueryable<tblVeranstalter> loadAllVeranstalter(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<tblVeranstalter> tVeranstalter = db.tblVeranstalter.OrderBy(p => p.Bezeichnung);
                return tVeranstalter;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadAllVeranstalter: " + ex.ToString());
            }
        }

        public void newRowVeranstalter(ref tblVeranstalter rVeranstalter)
        {
            try
            {
                rVeranstalter.ID = System.Guid.NewGuid();
                rVeranstalter.Bezeichnung = "";
                rVeranstalter.Beschreibung = "";
                rVeranstalter.IDKontakt = System.Guid.NewGuid();
                rVeranstalter.IDAdresse = System.Guid.NewGuid();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.newRowVeranstalter: " + ex.ToString());
            }
        }
        public void newRowAdresse(ref Adresse rAdresse)
        {
            try
            {
                rAdresse.ID = System.Guid.NewGuid();
                rAdresse.Strasse = "";
                rAdresse.Plz = "";
                rAdresse.Ort = "";
                rAdresse.Region = "";
                rAdresse.LandKZ = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.newRowAdresse: " + ex.ToString());
            }
        }
        public void newRowKontakt(ref Kontakt rKontakt)
        {
            try
            {
                rKontakt.ID = System.Guid.NewGuid();
                rKontakt.Tel = "";
                rKontakt.Fax = "";
                rKontakt.Mobil = "";
                rKontakt.Andere = "";
                rKontakt.Email = "";
                rKontakt.Ansprechpartner = "";
                rKontakt.Zusatz1 = "";
                rKontakt.Zusatz2 = "";
                rKontakt.Zusatz3 = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.newRowKontakt: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<Unterbringung> checkOpenHAGMeldungenExists(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                Aufenthalt rAufenthaltAct = this.getAktuellerAufenthaltPatient(IDPatient, false, db);
                System.Linq.IQueryable< Unterbringung> tUnterbringung = db.Unterbringung.Where(p => (p.Aktion == "Vornahme" || p.Aktion == "Verlängerung") && 
                                                                                                p.EDI_Benutzer == null && p.IDAufenthalt == rAufenthaltAct.ID);

                return tUnterbringung;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkOpenHAGMeldungenExists: " + ex.ToString());
            }
        }


        public List<tblFortbildungen> loadAllFortbildungen(Nullable<Guid> IDVeranstalter, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (IDVeranstalter != null)
                {
                    List<tblFortbildungen> tFortbildungen = db.tblFortbildungen.Where(p => p.IDVeranstalter == IDVeranstalter).OrderBy(p => p.Bezeichnung).ToList();
                    return tFortbildungen;
                }
                else
                {
                    List<tblFortbildungen> tFortbildungen = db.tblFortbildungen.OrderBy(p => p.Bezeichnung).ToList();
                    return tFortbildungen;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadAllFortbildungen: " + ex.ToString());
            }
        }
        public List<tblFortbildungen> loadAllFortbildungenBenutzer(Nullable<Guid> IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (IDBenutzer == null)
                {
                    List<tblFortbildungen> tFortbildungen = db.tblFortbildungen.OrderBy(p => p.Bezeichnung).ToList();
                    return tFortbildungen;
                }
                else
                {
                    var oFortbildungen = (from fb in db.tblFortbildungen
                                      join fbb in db.tblFortbildungBenutzer on fb.ID equals fbb.IDFortbildung
                                      where fbb.IDBenutzer == IDBenutzer
                                      select new
                                      {
                                          fb = fb
                                      });

                    List<tblFortbildungen> tFortbildungen = new List<tblFortbildungen>();
                    if (oFortbildungen != null)
                    {
                        foreach (var oFortbildung in oFortbildungen)
                        {
                            if (tFortbildungen.Where(o => o.ID == oFortbildung.fb.ID).FirstOrDefault() == null)
                            {
                                List<tblFortbildungen> tFortbildung = db.tblFortbildungen.Where(p => p.ID == oFortbildung.fb.ID).ToList();
                                tFortbildungen.Add((tblFortbildungen)tFortbildung.First());
                            }
                        }
                    }

                    return tFortbildungen;
                }

                //System.Data.Entity.Infrastructure.DbQuery<tblFortbildungen> tFortbildungen2 = oFortbildungen.ToList<tblFortbildungen>();
                //System.Linq.IQueryable<tblFortbildungen> tFortbildungen2 = oFortbildungen.ToList<>();

                //System.Linq.IQueryable<tblFortbildungen> tFortbildungen = db.tblFortbildungen.Join(db.tblFortbildungBenutzer,
                //        c => c.ID, cm => cm.IDBenutzer,(c, cm) => new {IDBenutzer = cm.IDBenutzer});
                //return tFortbildungen;

                //var tFortbildungen = db.tblFortbildungen.Join(db.tblFortbildungBenutzer,
                //            f => db.tblFortbildungen,
                //            b => db.tblFortbildungBenutzer.Where(x => x.IDBenutzer == IDBenutzer),
                //            (post, meta) => new { Post = post, Meta = meta });

                //List<tblFortbildungen> lstFortbildungen = entryPoint.ToArray<tblFortbildungen>();
                //var entryPointxy = (from ep in db.tblFortbildungen
                //                  join e in db.tblFortbildungBenutzer on ep.ID equals e.ID
                //                  join t in db.tblFortbildungBenutzer on e.ID equals t.ID
                //                  where e.ID == IDBenutzer
                //                  select new
                //                  {
                //                      UID = e.ID,
                //                      TID = e.ID,
                //                      Title = t.ID,
                //                      EID = e.ID
                //                  }).Take(10);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadAllFortbildungen: " + ex.ToString());
            }
        }
        public void newRowFortbildungen(ref tblFortbildungen rFortbildungen)
        {
            try
            {
                rFortbildungen.ID = System.Guid.NewGuid();
                rFortbildungen.IDVeranstalter = System.Guid.NewGuid();
                rFortbildungen.Bezeichnung = "";
                rFortbildungen.Beginn = null;
                rFortbildungen.Ende = null;
                rFortbildungen.AnzahlStunden = -1;
                rFortbildungen.AnzahlFreiePlätze = -1;
                rFortbildungen.Zertifikat = "";
                rFortbildungen.Vortragender = "";
                rFortbildungen.Veranstaltungsort = "";
                rFortbildungen.Voraussetzungen = "";
                rFortbildungen.Beschreibung = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.newRowFortbildungen: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<tblFortbildungBenutzer> loadFortbildungBenutzer(Nullable<Guid> IDFortbildung, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (IDFortbildung != null)
                {
                    System.Linq.IQueryable<tblFortbildungBenutzer> tFortbildungBenutzer = db.tblFortbildungBenutzer.Where(p => p.IDFortbildung == IDFortbildung).OrderBy(p => p.Anmeldedatum);
                    return tFortbildungBenutzer;
                }
                else
                {
                    System.Linq.IQueryable<tblFortbildungBenutzer> tFortbildungBenutzer = db.tblFortbildungBenutzer.OrderBy(p => p.Anmeldedatum);
                    return tFortbildungBenutzer;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadFortbildungBenutzer: " + ex.ToString());
            }
        }
        public void newRowFortbildungBenutzer(ref tblFortbildungBenutzer rFortbildungBenutzer)
        {
            try
            {
                rFortbildungBenutzer.ID = System.Guid.NewGuid();
                rFortbildungBenutzer.IDBenutzer = System.Guid.NewGuid();
                rFortbildungBenutzer.IDFortbildung = System.Guid.NewGuid();
                rFortbildungBenutzer.Anmeldedatum = null;
                rFortbildungBenutzer.Erfolg = -1;
                rFortbildungBenutzer.AbgeschlossenAm = null;
                rFortbildungBenutzer.ZuErneuernAm = null;
                rFortbildungBenutzer.Status = "";
                rFortbildungBenutzer.Anmerkung = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.newRowFortbildungBenutzer: " + ex.ToString());
            }
        }


        public System.Linq.IQueryable<Dokumente2> loadFortbildungBenutzerDokumente(Nullable<Guid> IDFortbildungBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<Dokumente2> tDokumente2 = db.Dokumente2.Where(p => p.IDRelation == IDFortbildungBenutzer).OrderByDescending(p => p.ErstelltAm);
                return tDokumente2;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadFortbildungBenutzerDokumente: " + ex.ToString());
            }
        }

        public void newRowDokumente2(ref Dokumente2 rDokumente2)
        {
            try
            {
                rDokumente2.ID = System.Guid.NewGuid();
                rDokumente2.Bezeichnung = "";
                rDokumente2.DokumentenName = "";
                rDokumente2.Abteilungen = "";
                rDokumente2.Benutzergruppen = "";
                rDokumente2.ErstelltAm = DateTime.Now;
                rDokumente2.ErstelltVon = this.LogggedOnUser().Benutzer1;
                rDokumente2.byteDoc = null;
                rDokumente2.byteJpg = null;
                rDokumente2.TypeDocu = "";
                rDokumente2.IDRelation = null;
                rDokumente2.fileType = "";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.newRowDokumente2: " + ex.ToString());
            }
        }

        public void CopyAndAddArztabrechnung(Guid IDArztabrechnung, ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected,
                                            PMDS.db.Entities.ERModellPMDSEntities db, Guid IDKlientOrig)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in lstPatienteSelected)
                {
                    if (!SelectedNodes.IDKlient.Equals(IDKlientOrig))
                    {
                        IQueryable<Arztabrechnung> lstPE = db.Arztabrechnung.Where(pe => pe.ID == IDArztabrechnung);
                        PMDS.db.Entities.Arztabrechnung rArztabrechnungOriginal = lstPE.First();

                        PMDS.db.Entities.Arztabrechnung rNewArztabrechnung = new db.Entities.Arztabrechnung();
                        rNewArztabrechnung.ID = System.Guid.NewGuid();
                        rNewArztabrechnung.Leistung1 = rArztabrechnungOriginal.Leistung1;
                        rNewArztabrechnung.Leistung2 = rArztabrechnungOriginal.Leistung2;
                        rNewArztabrechnung.Leistung3 = rArztabrechnungOriginal.Leistung3;
                        rNewArztabrechnung.Anmerkung = rArztabrechnungOriginal.Anmerkung;
                        rNewArztabrechnung.Datum = rArztabrechnungOriginal.Datum;
                        rNewArztabrechnung.IDBenutzer = rArztabrechnungOriginal.IDBenutzer;

                        rNewArztabrechnung.IDPatient = SelectedNodes.IDKlient.Value;
                        IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(pe => pe.ID == rNewArztabrechnung.IDPatient);
                        PMDS.db.Entities.Patient rPatient = tPatient.First();

                        rNewArztabrechnung.Krankenkasse = rPatient.KrankenKasse.Trim();
                        rNewArztabrechnung.SVNr = rPatient.VersicherungsNr.Trim();
                        
                        db.Arztabrechnung.Add(rNewArztabrechnung);
                        db.SaveChanges();
                    }
                    else
                    {
                        string xy = "";
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddArztabrechnung: " + ex.ToString());
            }
        }
        public void CopyAndAddPflegeplan(Guid IDPflegeplan, ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected,
                                    PMDS.db.Entities.ERModellPMDSEntities db, Guid IDAufenthaltOrig)
        {
            try
            {
                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthaltOrig = db.Aufenthalt.Where(pe => pe.ID == IDAufenthaltOrig);
                PMDS.db.Entities.Aufenthalt rAufenthaltOrig = tAufenthaltOrig.First();

                DateTime dNow = DateTime.Now;
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in lstPatienteSelected)
                {
                    if (!SelectedNodes.IDKlient.Equals(rAufenthaltOrig.IDPatient))
                    {
                        IQueryable<PMDS.db.Entities.PflegePlan> tPflegePlanOrig = db.PflegePlan.Where(pe => pe.ID == IDPflegeplan);
                        PMDS.db.Entities.PflegePlan rPflegePlanOrig = tPflegePlanOrig.First();

                        PMDS.db.Entities.PflegePlan newPflegeplan = PMDS.Global.db.ERSystem.EFEntities.newPflegePlan(db);
                        newPflegeplan.ID = System.Guid.NewGuid();
                        newPflegeplan.IDAufenthalt = SelectedNodes.IDAufenthalt.Value;
                        newPflegeplan.IDEintrag = rPflegePlanOrig.IDEintrag;
                        newPflegeplan.IDBenutzer_Erstellt = rPflegePlanOrig.IDBenutzer_Erstellt;
                        newPflegeplan.IDBenutzer_Geaendert = rPflegePlanOrig.IDBenutzer_Geaendert;
                        newPflegeplan.OriginalJN = rPflegePlanOrig.OriginalJN;
                        newPflegeplan.DatumErstellt = rPflegePlanOrig.DatumErstellt;
                        newPflegeplan.DatumGeaendert = rPflegePlanOrig.DatumGeaendert;
                        newPflegeplan.StartDatum = rPflegePlanOrig.StartDatum;
                        newPflegeplan.EndeDatum = rPflegePlanOrig.EndeDatum;
                        newPflegeplan.LetztesDatum = rPflegePlanOrig.LetztesDatum;
                        newPflegeplan.LetzteEvaluierung = rPflegePlanOrig.LetzteEvaluierung;
                        newPflegeplan.Warnhinweis = rPflegePlanOrig.Warnhinweis;
                        newPflegeplan.Anmerkung = rPflegePlanOrig.Anmerkung;
                        newPflegeplan.ErledigtGrund = rPflegePlanOrig.ErledigtGrund;
                        newPflegeplan.Text = rPflegePlanOrig.Text;
                        newPflegeplan.Intervall = rPflegePlanOrig.Intervall;
                        newPflegeplan.WochenTage = rPflegePlanOrig.WochenTage;
                        newPflegeplan.IntervallTyp = rPflegePlanOrig.IntervallTyp;
                        newPflegeplan.EvalTage = rPflegePlanOrig.EvalTage;
                        newPflegeplan.IDBerufsstand = rPflegePlanOrig.IDBerufsstand;
                        newPflegeplan.ParalellJN = rPflegePlanOrig.ParalellJN;
                        newPflegeplan.Dauer = rPflegePlanOrig.Dauer;
                        newPflegeplan.LokalisierungJN = rPflegePlanOrig.LokalisierungJN;
                        newPflegeplan.EinmaligJN = rPflegePlanOrig.EinmaligJN;
                        newPflegeplan.ErledigtJN = rPflegePlanOrig.ErledigtJN;
                        newPflegeplan.GeloeschtJN = rPflegePlanOrig.GeloeschtJN;
                        newPflegeplan.Lokalisierung = rPflegePlanOrig.Lokalisierung;
                        newPflegeplan.LokalisierungSeite = rPflegePlanOrig.LokalisierungSeite;
                        newPflegeplan.EintragGruppe = rPflegePlanOrig.EintragGruppe;
                        newPflegeplan.PDXJN = rPflegePlanOrig.PDXJN;
                        newPflegeplan.RMOptionalJN = rPflegePlanOrig.RMOptionalJN;
                        newPflegeplan.UntertaegigeJN = rPflegePlanOrig.UntertaegigeJN;
                        newPflegeplan.SpenderAbgabeJN = rPflegePlanOrig.SpenderAbgabeJN;
                        newPflegeplan.IDUntertaegigeGruppe = rPflegePlanOrig.IDUntertaegigeGruppe;
                        newPflegeplan.BarcodeID = rPflegePlanOrig.BarcodeID;
                        newPflegeplan.IDLinkDokument = rPflegePlanOrig.IDLinkDokument;
                        newPflegeplan.NaechsteEvaluierung = rPflegePlanOrig.NaechsteEvaluierung;
                        newPflegeplan.NaechsteEvaluierungBemerkung = rPflegePlanOrig.NaechsteEvaluierungBemerkung;
                        newPflegeplan.OhneZeitBezug = rPflegePlanOrig.OhneZeitBezug;
                        newPflegeplan.IDZeitbereich = rPflegePlanOrig.IDZeitbereich;
                        newPflegeplan.ZuErledigenBis = rPflegePlanOrig.ZuErledigenBis;
                        newPflegeplan.wundejn = rPflegePlanOrig.wundejn;
                        newPflegeplan.EintragFlag = rPflegePlanOrig.EintragFlag;
                        newPflegeplan.NächstesDatum = rPflegePlanOrig.NächstesDatum;
                        newPflegeplan.IDDekurs = rPflegePlanOrig.IDDekurs;
                        newPflegeplan.PrivatJN = rPflegePlanOrig.PrivatJN;
                        newPflegeplan.IDExtern = rPflegePlanOrig.IDExtern;
                        newPflegeplan.Startdatum_Neu = rPflegePlanOrig.Startdatum_Neu;
                        newPflegeplan.lstIDPDx = rPflegePlanOrig.lstIDPDx;
                        newPflegeplan.lstPDxBezeichnung = rPflegePlanOrig.lstPDxBezeichnung;
                        newPflegeplan.AnmerkungRtf = rPflegePlanOrig.AnmerkungRtf;
                        newPflegeplan.IDBefund = rPflegePlanOrig.IDBefund;
                        newPflegeplan.LogInNameFrei = ENV.LoginInNameFrei;

                        db.PflegePlan.Add(newPflegeplan);
                        db.SaveChanges();
                    }
                    else
                    {
                        string xy = "";
                    }
                }
            } 
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddTermine: " + ex.ToString());
            }
        }
        public void CopyAndAddPE(Guid IDPE, ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected,
                                    PMDS.db.Entities.ERModellPMDSEntities db, ref Guid IDGruppe)
        {
            try
            {
                IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintragOrig1 = db.PflegeEintrag.Where(pe => pe.ID == IDPE);
                PMDS.db.Entities.PflegeEintrag rPflegeEintragOrig1 = tPflegeEintragOrig1.First();

                IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthaltOrig = db.Aufenthalt.Where(pe => pe.ID == rPflegeEintragOrig1.IDAufenthalt);
                PMDS.db.Entities.Aufenthalt rAufenthaltOrig = tAufenthaltOrig.First();
                
                DateTime dNow = DateTime.Now;
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in lstPatienteSelected)
                {
                    if (!SelectedNodes.IDKlient.Equals(rAufenthaltOrig.IDPatient))
                    {
                        IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintragOrig = db.PflegeEintrag.Where(pe => pe.ID == IDPE);
                        PMDS.db.Entities.PflegeEintrag rPflegeEintragOrig = tPflegeEintragOrig.First();

                        PMDS.db.Entities.PflegeEintrag newPflegeEintrag = PMDS.Global.db.ERSystem.EFEntities.newPflegeEintrag(db);
                        newPflegeEintrag.ID = System.Guid.NewGuid();
                        this.CopyPflegeEintrag(newPflegeEintrag, rPflegeEintragOrig);
                        newPflegeEintrag.ID = System.Guid.NewGuid();
                        newPflegeEintrag.IDAufenthalt = SelectedNodes.IDAufenthalt.Value;
                        newPflegeEintrag.IDDekurs = rPflegeEintragOrig.ID;

                        PMDS.db.Entities.Patient rPatient = this.getPatient(SelectedNodes.IDKlient.Value, db);
                        newPflegeEintrag.IDAbteilung = rPatient.IDAbteilung;
                        newPflegeEintrag.IDBereich = rPatient.IDBereich;
                        newPflegeEintrag.TextHistorie = "";
                        newPflegeEintrag.TextHistorieRtf = "";
                        newPflegeEintrag.IDGruppe = IDGruppe;

                        db.PflegeEintrag.Add(newPflegeEintrag);
                        db.SaveChanges();
                    }
                    else
                    {
                        string xy = "";
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddPE: " + ex.ToString());
            }
        }

        public void CopyAndAddMedTypDaten(ref System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cMedTypDatenCopy> lstPatienteSelected,
                                            PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                foreach (PMDS.DB.PMDSBusiness.cMedTypDatenCopy MedTypDatenCopy in lstPatienteSelected)
                {
                    if (!MedTypDatenCopy.SelectedNodes.IDKlient.Equals(MedTypDatenCopy.IDPatientOrig2))
                    {
                        IQueryable<MedizinischeDaten> lstMedizinischeDaten = db.MedizinischeDaten.Where(pe => pe.ID == MedTypDatenCopy.IDMedDatenOrig2);
                        PMDS.db.Entities.MedizinischeDaten rMedTypDatenOrig = lstMedizinischeDaten.First();

                        PMDS.db.Entities.MedizinischeDaten rNewMedizinischeDaten = new db.Entities.MedizinischeDaten();
                        rNewMedizinischeDaten.ID = System.Guid.NewGuid();
                        rNewMedizinischeDaten.IDPatient = MedTypDatenCopy.SelectedNodes.IDKlient;
                        rNewMedizinischeDaten.IDBenutzergeaendert = rMedTypDatenOrig.IDBenutzergeaendert;
                        rNewMedizinischeDaten.MedizinischerTyp = rMedTypDatenOrig.MedizinischerTyp;
                        rNewMedizinischeDaten.Beschreibung = rMedTypDatenOrig.Beschreibung;
                        rNewMedizinischeDaten.ICDCode = rMedTypDatenOrig.ICDCode;
                        rNewMedizinischeDaten.Von = rMedTypDatenOrig.Von;
                        rNewMedizinischeDaten.Bis = rMedTypDatenOrig.Bis;
                        rNewMedizinischeDaten.Beendigungsgrund = rMedTypDatenOrig.Beendigungsgrund;
                        rNewMedizinischeDaten.AufnahmediagnoseJN = rMedTypDatenOrig.AufnahmediagnoseJN;
                        rNewMedizinischeDaten.Bemerkung = rMedTypDatenOrig.Bemerkung;
                        rNewMedizinischeDaten.Therapie = rMedTypDatenOrig.Therapie;
                        rNewMedizinischeDaten.Anzahl = rMedTypDatenOrig.Anzahl;
                        rNewMedizinischeDaten.NuechternJN = rMedTypDatenOrig.NuechternJN;
                        rNewMedizinischeDaten.AntikoaguliertJN = rMedTypDatenOrig.AntikoaguliertJN;
                        rNewMedizinischeDaten.Handling = rMedTypDatenOrig.Handling;
                        rNewMedizinischeDaten.LetzteVersorgung = rMedTypDatenOrig.LetzteVersorgung;
                        rNewMedizinischeDaten.NaechsteVersorgung = rMedTypDatenOrig.NaechsteVersorgung;
                        rNewMedizinischeDaten.Modell = rMedTypDatenOrig.Modell;
                        rNewMedizinischeDaten.Groesse = rMedTypDatenOrig.Groesse;
                        rNewMedizinischeDaten.Typ = rMedTypDatenOrig.Typ;
                        rNewMedizinischeDaten.IDBefund = rMedTypDatenOrig.IDBefund;
                        rNewMedizinischeDaten.lstRezepteinträge = "";
                        rNewMedizinischeDaten.NumberRezepteinträge = 0;

                        IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(pe => pe.ID == rNewMedizinischeDaten.IDPatient);
                        PMDS.db.Entities.Patient rPatient = tPatient.First();
                        
                        db.MedizinischeDaten.Add(rNewMedizinischeDaten);
                        db.SaveChanges();
                    }
                    else
                    {
                        string xy = "";
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyAndAddMedTypDaten: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.BenutzerRechte> getBenutzerRechte(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDBenutzer)
        {
            try
            {
                IQueryable<PMDS.db.Entities.BenutzerRechte> tBenutzerRechte = db.BenutzerRechte.Where(o => o.IDBenutzer == IDBenutzer);
                return tBenutzerRechte;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBenutzerRechte: " + ex.ToString());
            }
        }
        public IQueryable<PMDS.db.Entities.BenutzerGruppe> getBenutzergruppen(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                IQueryable<PMDS.db.Entities.BenutzerGruppe> tBenutzerGruppe = db.BenutzerGruppe;
                return tBenutzerGruppe;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBenutzergruppen: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.BenutzerRechte getBenutzerRecht(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDBenutzer, int IDRecht, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                return db.BenutzerRechte.Where(o => o.IDBenutzer == IDBenutzer && o.IDRecht == IDRecht).FirstOrDefault();

                //PMDS.db.Entities.BenutzerRechte rBenutzerRechte = db.BenutzerRechte.Where(o => o.IDBenutzer == IDBenutzer && o.IDRecht == IDRecht).FirstOrDefault();
                //if (tBenutzerRechte.Count() == 1)
                //{
                //    PMDS.db.Entities.BenutzerRechte rBenutzerRechte = tBenutzerRechte.First();
                //    return rBenutzerRechte;
                //}
                //else if (tBenutzerRechte.Count() == 0)
                //{
                //    return null;
                //}
                //else
                //{
                //    throw new Exception("tBenutzerRechte.Count()>1 for IDRecht '" + IDRecht.ToString() + "' and IDBenutzer '" + IDBenutzer.ToString() + "'!");
                //}
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusiness.getBenutzerRecht"))
                {
                    return this.getBenutzerRecht(db, IDBenutzer, IDRecht, IDTime);
                }
                return null;
            }
        }

        public void checkIDUrlaubAufenthalt(Guid IDAufenthalt)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.ID == IDAufenthalt);
                    PMDS.db.Entities.Aufenthalt rActAufenthalt = tAufenthalt.First();
                    if (rActAufenthalt.IDUrlaub == null)
                    {
                        IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf2 = db.UrlaubVerlauf.Where(o => o.IDAufenthalt == rActAufenthalt.ID && o.EndeDatum == null);
                        if (tUrlaubVerlauf2.Count() == 1)
                        {
                            UrlaubVerlauf rUrlaubVerlauf = tUrlaubVerlauf2.First();
                            rActAufenthalt.IDUrlaub = rUrlaubVerlauf.ID;
                            db.SaveChanges();
                        }
                        else if (tUrlaubVerlauf2.Count() > 1)
                        {
                            throw new Exception("checkIDUrlaubAufenthalt: tUrlaubVerlauf.Count>1 and o.EndeDatum == null not allowed for IDAufenthalt '" + IDAufenthalt.ToString() + "'!");
                        }
                    }

                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt2 = db.Aufenthalt.Where(o => o.ID == IDAufenthalt);
                    PMDS.db.Entities.Aufenthalt rActAufenthalt2 = tAufenthalt2.First();
                    if (rActAufenthalt2.IDUrlaub != null)
                    {
                        IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf = db.UrlaubVerlauf.Where(o => o.IDAufenthalt == IDAufenthalt && o.EndeDatum == null);
                        if (tUrlaubVerlauf.Count() == 0)
                        {
                            rActAufenthalt2.IDUrlaub = null;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkIDUrlaubAufenthalt: " + ex.ToString());
            }
        }

        /*
        public void checkIDUrlaubAufenthalt_old(Guid IDAufenthalt)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(o => o.ID == IDAufenthalt);
                    PMDS.db.Entities.Aufenthalt rActAufenthalt = tAufenthalt.First();
                    if (rActAufenthalt.IDUrlaub == null)
                    {
                        IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf2 = db.UrlaubVerlauf.Where(o => o.IDAufenthalt == rActAufenthalt.ID && o.EndeDatum == null);
                        if (tUrlaubVerlauf2.Count() == 1)
                        {
                            UrlaubVerlauf rUrlaubVerlauf = tUrlaubVerlauf2.First();
                            rActAufenthalt.IDUrlaub = rUrlaubVerlauf.ID;
                            db.SaveChanges();
                        }
                        else if (tUrlaubVerlauf2.Count() > 1)
                        {
                            throw new Exception("checkIDUrlaubAufenthalt: tUrlaubVerlauf.Count>1 and o.EndeDatum == null not allowed for IDAufenthalt '" + IDAufenthalt.ToString() + "'!");
                        }
                        else if (tUrlaubVerlauf2.Count() == 0)
                        {
                            bool bPatientIsAnwesend = true;
                        }
                    }

                    IQueryable<PMDS.db.Entities.UrlaubVerlauf> tUrlaubVerlauf = db.UrlaubVerlauf.Where(o => o.IDAufenthalt == IDAufenthalt && o.EndeDatum != null);
                    if (tUrlaubVerlauf.Count() == 1)
                    {
                        IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt2 = db.Aufenthalt.Where(o => o.ID == IDAufenthalt);
                        PMDS.db.Entities.Aufenthalt rActAufenthalt2 = tAufenthalt2.First();
                        if (rActAufenthalt2.IDUrlaub == null || rActAufenthalt2.IDUrlaub == System.Guid.Empty)
                        {
                            UrlaubVerlauf rUrlaubVerlauf = tUrlaubVerlauf.First();
                            rActAufenthalt2.IDUrlaub = rUrlaubVerlauf.ID;
                            db.SaveChanges();
                        }
                    }
                    else if (tUrlaubVerlauf.Count() > 1)
                    {
                        throw new Exception("checkIDUrlaubAufenthalt: tUrlaubVerlauf.Count>1 and o.EndeDatum != null not allowed for IDAufenthalt '" + IDAufenthalt.ToString() + "'!");
                    }
                    else if (tUrlaubVerlauf.Count() == 0)
                    {
                        bool bUrlaubeVerlauf0 = true;
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkIDUrlaubAufenthalt: " + ex.ToString());
            }
        }
        */
            
        public string getPfadArchiv()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.tblPfad> tPfad = db.tblPfad;
                    if (tPfad.Count() == 1)
                    {
                        PMDS.db.Entities.tblPfad rPfad = tPfad.First();
                        return rPfad.Archivpfad;
                    }
                    else if (tPfad.Count() == 0)
                    {
                        return "";
                    }
                    else
                    {
                        throw new Exception("getPfadArchiv: Pfad.Count()>0 not allowed!");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPfadArchiv: " + ex.ToString());
            }
        }

        public bool ÄrzteZusammenführenxyxy(Nullable<Guid> IDPatientÄrzteSelected, Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PatientAerzte> tPatientAerzteSelected = db.PatientAerzte.Where(p => p.ID == IDPatientÄrzteSelected);
                PatientAerzte rPatientAerzteSelected = tPatientAerzteSelected.First();

                System.Linq.IQueryable<PatientAerzte> tPatientAerztePatient = db.PatientAerzte.Where(p => p.IDPatient == IDPatient && p.IDAerzte == rPatientAerzteSelected.IDAerzte && p.ID != rPatientAerzteSelected.ID);
                foreach (PatientAerzte rPatientAerzte in tPatientAerztePatient)
                {
                    System.Linq.IQueryable<RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.IDAerzte == rPatientAerzte.IDAerzte);
                    foreach (PatientAerzte rRezeptEintrag in tPatientAerztePatient)
                    {
      

                    }
                }

                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.ÄrzteZusammenführen: " + ex.ToString());
            }
        }

        public void AddPflegeeintragSimple2(string txt, string title, PflegeEintragTyp PflegeEintragTyp, Guid IDPatient, bool IsBewerber)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    if (!IsBewerber)
                    {
                        PMDS.db.Entities.Aufenthalt rActAufenthalt = this.getAktuellerAufenthaltPatient(IDPatient, false, db);
                        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.AddPflegeeintrag(db, txt, DateTime.Now, null, rActAufenthalt.IDBereich,
                            rActAufenthalt.ID, null, PflegeEintragTyp,
                            null, rActAufenthalt.IDAbteilung, title);
                    }
                    else
                    {
                        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.AddPflegeeintrag(db, txt, DateTime.Now, null, null,
                            null, null, PflegeEintragTyp,
                            null, null, title);
                    }

                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.AddPflegeeintragSimple: " + ex.ToString());
            }
        }

        public void getPatientenEntlassen(Nullable<DateTime> dVon, Nullable<DateTime> dBis, PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste1,
                                            PMDS.db.Entities.ERModellPMDSEntities db, sqlManange sqlManage1)
        {
            try
            {
                if (dVon == null)
                {
                    dVon = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                if (dBis == null)
                {
                    dBis = new DateTime(2300, 1, 1, 0, 0, 0);
                }

                sqlManage1.getPatientenStart(ENV.USERID, 1, ENV.CurrentIDBezugsPfleger, ref dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
                foreach (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenliste1.vKlientenliste)
                {
                    if (!rKlient.IDKlinik.Equals(ENV.IDKlinik))
                        rKlient.Delete();
                }
                dsKlientenliste1.AcceptChanges();

                System.Linq.IQueryable<Einrichtung> tEinrichtung = db.Einrichtung.OrderBy(p => p.Text);
                foreach (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenliste1.vKlientenliste)
                {
                    System.Linq.IQueryable<Aufenthalt> tAufenthalt = db.Aufenthalt.Where(p => p.ID == rKlient.IDAufenthalt);
                    Aufenthalt rAufenthalt = tAufenthalt.First();
                    if (rAufenthalt.Entlassungszeitpunkt == null)
                    {
                        throw new Exception("getPatientenEntlassen: rAufenthalt.Entlassungszeitpunkt=null for IDAufenthalt '" + rAufenthalt.ID.ToString() + "' not allowed!");
                    }

                    if (rAufenthalt.Entlassungszeitpunkt.Value.Date >= dVon.Value.Date && rAufenthalt.Entlassungszeitpunkt.Value <= dBis.Value.Date)
                    {
                        PMDS.Global.db.ERSystem.dsKlientenliste.PatientenEntlassenRow rNewPatientenEntlassen = sqlManage1.getNewPatientEntlassen(ref dsKlientenliste1);
                        rNewPatientenEntlassen.Entlassungszeitpunkt = rAufenthalt.Entlassungszeitpunkt.Value;
                        rNewPatientenEntlassen.IDAufenthalt = rKlient.IDAufenthalt;
                        rNewPatientenEntlassen.IDPatient = rKlient.IDKlient;
                        rNewPatientenEntlassen.Patient = rKlient.PatientName.Trim();

                        if (rAufenthalt.IDEinrichtung_Entlassung == null)
                        {
                            rNewPatientenEntlassen.Wohin = "No information";
                            //throw new Exception("getPatientenEntlassen: rAufenthalt.IDEinrichtung_Entlassung=null for IDAufenthalt '" + rNewPatientenEntlassen.IDAufenthalt.ToString() + "' not allowed!");
                        }
                        else
                        {
                            IEnumerable<Einrichtung> arrEinrichtungForAufenthalt = from rEinrichtungAuf in tEinrichtung.AsEnumerable()
                                                                                   where rEinrichtungAuf.ID == rAufenthalt.IDEinrichtung_Entlassung.Value
                                                                                   select rEinrichtungAuf;
                            //foreach (Einrichtung rEinrichtung in arrEinrichtungForAufenthalt)
                            //{
                            //    string TxtTmp = rEinrichtung.Text.Trim();
                            //}
                            if (arrEinrichtungForAufenthalt.Count() > 1)
                            {
                                throw new Exception("getPatientenEntlassen: arrEinrichtungForAufenthalt.Count() > 0 for rAufenthalt.IDEinrichtung_Entlassung '" + rAufenthalt.IDEinrichtung_Entlassung.ToString() + "' not allowed!");
                            }
                            rNewPatientenEntlassen.Wohin = arrEinrichtungForAufenthalt.First().Text.Trim();
                        }
                    }

                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPatientenEntlassen: " + ex.ToString());
            }
        }


        public System.Collections.Generic.List<QuickMeldung> getQuickbuttonsBasisabteilung(Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Collections.Generic.List<QuickMeldung> lstQuickmeldungenBasisAbteilung = new List<QuickMeldung>();
                System.Linq.IQueryable<Abteilung> tAbteilung = db.Abteilung.Where(p => p.IDKlinik == IDKlinik).OrderBy(p => p.Bezeichnung);
                foreach (Abteilung rAbteilung in tAbteilung)
                {
                    if (rAbteilung.Basisabteilung)
                    {
                        System.Linq.IQueryable<QuickMeldung> tQuickMeldung = db.QuickMeldung.Where(p => p.IDAbteilung == rAbteilung.ID).OrderBy(p => p.Bezeichnung);
                        foreach (QuickMeldung rQuickMeldung in tQuickMeldung)
                        {
                            IEnumerable<QuickMeldung> arrQuickMeldungExistsInList = from rQuickMeldungCheck in lstQuickmeldungenBasisAbteilung.AsEnumerable()
                                                                                        where rQuickMeldungCheck.ID == rQuickMeldung.ID
                                                                                        select rQuickMeldungCheck;
                            if (arrQuickMeldungExistsInList.Count() == 0)
                            {
                                lstQuickmeldungenBasisAbteilung.Add(rQuickMeldung);
                            }
                        }
                    }
                }

                return lstQuickmeldungenBasisAbteilung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getQuickbuttonsBasisabteilung: " + ex.ToString());
            }
        }


        public void sys_UpdateAufenthaltBereichPatient(ref int iCounterUpdatedPatient, ref int iCounterUpdatedPE, bool SaveChanges, bool bNoProt)
        {
            try
            {
                int iCounter = 0;
                StringBuilder sb3 = new StringBuilder();
                int iCounterUpdatedPatient2 = 0;
                iCounterUpdatedPatient = 0;
                bool bAnyChangeAll = false;

                dsKlient dsKlient1 = new dsKlient();
                sqlKlient sqlKlient1 = new sqlKlient();
                sqlKlient1.initControl();

                dsKlient dsKlientDetail = new dsKlient();
                dsPlanungIntervention dsPlanungIntervention1 = new dsPlanungIntervention();
                dsPlanungIntervention dsPlanungInterventionUpdate = new dsPlanungIntervention();
                sqlPlanungIntervention sqlPlanungIntervention1 = new sqlPlanungIntervention();
                sqlPlanungIntervention1.initControl();

                sqlKlient1.getPatient(null, sqlKlient.eSelTypeKlient.All, ref dsKlient1);
                foreach (dsKlient.PatientSmallRow rPatient2 in dsKlient1.PatientSmall)
                {
                    iCounterUpdatedPatient2 += 1;
                    string sInfoPatient = "Patient " + iCounterUpdatedPatient2.ToString() + " / " + dsKlient1.Patient.Rows.Count.ToString() + "";
                    PMDSBusiness.dShowInfo2.Invoke(sInfoPatient);

                    string sInfoAufBereich = "";
                    int iCounterAufenthalt2 = 0;
                    dsKlient1.Aufenthalt.Clear();
                    sqlKlient1.getAufenthalt(rPatient2.ID, sqlKlient.eSelTypeAufenthalt.IDPatient, ref dsKlient1);
                    foreach (dsKlient.AufenthaltRow rAufenthalt2 in dsKlient1.Aufenthalt)
                    {
                        try
                        {
                            bool bAnyChangeDetail = false;
                            if (rAufenthalt2.IsIDAbteilungNull())
                            {
                                throw new Exception("rAufenthalt2.IsIDAbteilungNull()=true for IDAufenthalt '" + rAufenthalt2.ID.ToString() + "'!!");
                            }

                            dsKlient1.Abteilung.Clear();
                            sqlKlient1.getAbteilung(rAufenthalt2.IDAbteilung, sqlKlient.eSelTypeAbteilung.ID, ref dsKlient1);
                            dsKlient.AbteilungRow rAbteilung2 = (dsKlient.AbteilungRow)dsKlient1.Abteilung.Rows[0];
                            if (rAbteilung2.IsIDKlinikNull())
                            {
                                throw new Exception("rAbteilung2.IsIDKlinikNull for rAbteilung2.ID '" + rAbteilung2.ID.ToString() + "'!!");
                            }

                            if (iCounterAufenthalt2 == 0)
                            {
                                if (rPatient2.IsIDAbteilungNull())
                                {
                                    if (!bNoProt)
                                    {
                                        sInfoAufBereich += this.getInfoAbteilung(rAufenthalt2.IDAbteilung, null, ref sqlKlient1, ref dsKlient1);
                                    }
                                    rPatient2.IDAbteilung = rAufenthalt2.IDAbteilung;
                                    bAnyChangeDetail = true;
                                }
                                else
                                {
                                    if (rAufenthalt2.IDAbteilung != rPatient2.IDAbteilung)
                                    {
                                        if (!bNoProt)
                                        {
                                            sInfoAufBereich += this.getInfoAbteilung(rAufenthalt2.IDAbteilung, rPatient2.IDAbteilung, ref sqlKlient1, ref dsKlient1);
                                        }
                                        rPatient2.IDAbteilung = rAufenthalt2.IDAbteilung;
                                        bAnyChangeDetail = true;
                                    }
                                }

                                if (rAufenthalt2.IsIDBereichNull())
                                {
                                    bool IDBereichIsNull = true;
                                }

                                if (rPatient2.IsIDBereichNull())
                                {
                                    Nullable<Guid> IDBereichTmp2 = null;
                                    if (!rAufenthalt2.IsIDBereichNull())
                                    {
                                        IDBereichTmp2 = rAufenthalt2.IDBereich;
                                    }
                                    if (!bNoProt)
                                    {
                                        sInfoAufBereich += this.getInfoBereich(IDBereichTmp2, null, ref sqlKlient1, ref dsKlient1);
                                    }                               
                                    if (IDBereichTmp2 == null)
                                    {
                                        rPatient2.SetIDBereichNull();
                                    }
                                    else
                                    {
                                        rPatient2.IDBereich = rAufenthalt2.IDBereich;
                                    }
                                    bAnyChangeDetail = true;
                                }
                                else
                                {
                                    if (!rAufenthalt2.IsIDBereichNull() && !rPatient2.IsIDBereichNull() && rPatient2.IDBereich != System.Guid.Empty && rAufenthalt2.IDBereich != rPatient2.IDBereich)
                                    {
                                        Nullable<Guid> IDBereichTmp2 = null;
                                        if (!rAufenthalt2.IsIDBereichNull())
                                        {
                                            IDBereichTmp2 = rAufenthalt2.IDBereich;
                                        }
                                        if (!bNoProt)
                                        {
                                            sInfoAufBereich += this.getInfoBereich(IDBereichTmp2, rPatient2.IDBereich, ref sqlKlient1, ref dsKlient1);
                                        }
                                        rPatient2.IDBereich = rAufenthalt2.IDBereich;
                                        bAnyChangeDetail = true;
                                    }
                                }
                            }


                            string PatientNamteTmp = rPatient2.Nachname.Trim() + " " + rPatient2.Vorname.Trim();
                            Nullable<Guid> IDBereichTmp = null;
                            if (rAufenthalt2.IsIDBereichNull())
                            {
                                IDBereichTmp = null;
                            }
                            else
                            {
                                IDBereichTmp = rAufenthalt2.IDBereich;
                            }
                          
                            iCounterAufenthalt2 += 1;
                            if (bAnyChangeDetail)
                            {
                                iCounter += 1;
                                if (!bNoProt)
                                {
                                    sb3.Append(iCounter.ToString() + ". Klient " + PatientNamteTmp.Trim() + "" + "\r\n" + "\r\n");
                                }
                                iCounterUpdatedPatient += 1;
                                bAnyChangeAll = true;

                                if (SaveChanges)
                                {
                                    //sqlKlient1.daPatient.Update(dsKlient1.Patient);
                                }
                            }

                            this.sys_UpdateAufenthaltBereichPatientDetail(rAufenthalt2.ID, ref dsKlientDetail, ref dsPlanungInterventionUpdate, ref sqlKlient1, ref iCounterUpdatedPE, rAufenthalt2.IDAbteilung, ref IDBereichTmp,
                                                                            ref PatientNamteTmp, ref sInfoPatient, ref SaveChanges, ref  bNoProt,  ref sb3, 
                                                                            ref dsPlanungIntervention1, ref sqlPlanungIntervention1);

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("sys_UpdateAufenthaltBereichPatient: Error rAufenthalt.ID='" + rAufenthalt2.ID.ToString() + "' - " + ex.ToString());
                        }
                    }
                }

                System.Windows.Forms.MessageBox.Show("Update für Zuordnungen von PE zu Abteilungen und Bereichen abgeschlossen!");



                //qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                //frmProt.initControl();
                //frmProt.Show();
                //frmProt.ContProtocol1.setText(sb3.ToString());
                //frmProt.Text = "Protokoll Update IDAufenthalt, IDBereicht Patient";

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.sys_UpdateAufenthaltBereichPatient: " + ex.ToString());
            }
        }
        public void sys_UpdateAufenthaltBereichPatientDetail(Guid IDAufenthalt, ref dsKlient dsKlient2, ref dsPlanungIntervention dsPlanungInterventionUpdate, ref sqlKlient sqlKlient1,  ref int iCounterUpdatedPE, 
                                                             Nullable<Guid> IDAbteilung, ref Nullable<Guid> IDBereich, ref string PatientName, ref string sInfoPatient, ref bool SaveChanges,  ref bool bNoProt, 
                                                             ref StringBuilder sb3,  ref dsPlanungIntervention dsPlanungIntervention1, ref sqlPlanungIntervention sqlPlanungIntervention1)
        {
            try
            {
                int iCounterPE = 0;

                dsKlient2.Clear();
                dsPlanungIntervention1.Clear();
                dsPlanungInterventionUpdate.Clear();

                string sInfoAufBereich = "";
                sInfoAufBereich = this.getInfoAufenthalt(IDAufenthalt, ref sqlKlient1, ref dsKlient2) + " - ";
                Nullable<DateTime> prevAufenthaltDatum = null;
                DateTime dFrom = new DateTime(1900, 1, 1, 0, 0, 0);
                DateTime dTo = new DateTime(2300, 1, 1, 0, 0, 0);

                int iCounter = 0;
                sqlKlient1.getAufenthaltVerlauf(IDAufenthalt, sqlKlient.eSelTypeAufenthaltVerlauf.IDAufenthalt, ref dsKlient2);
                foreach (dsKlient.AufenthaltVerlaufRow rAufenthaltVerlauf2 in dsKlient2.AufenthaltVerlauf)
                {
                    try
                    {
                        if (rAufenthaltVerlauf2.IsDatumNull())
                        {
                            throw new Exception("sys_UpdateAufenthaltBereichPatientDetail: rAufenthaltVerlauf2.IsDatumNull()=true for rAufenthaltVerlauf2.ID '" + rAufenthaltVerlauf2.ID.ToString() + "'!!");
                        }


                        if (prevAufenthaltDatum != null)
                        {
                            dTo = prevAufenthaltDatum.Value;
                        }
                        else
                        {
                            dTo = DateTime.Now;
                        }
                        dFrom = rAufenthaltVerlauf2.Datum;

                        int iCounterPETmp = 0;
                        dsPlanungIntervention1.PflegeEintrag.Clear();
                        int iFctCalled = 0;
                        sqlPlanungIntervention1.getPflegeEintrag(rAufenthaltVerlauf2.IDAufenthalt, sqlPlanungIntervention.eSelTypePflegeEintrag.IDAufenthaltAbtBereichZeitpunkt, ref dsPlanungIntervention1, dFrom, dTo, IDAbteilung, IDBereich, ref iFctCalled);
                        //IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(p => p.IDAufenthalt == rAufenthaltVerlauf.IDAufenthalt.Value && p.Zeitpunkt >= dFrom && p.Zeitpunkt <= dTo && (p.IDAbteilung != cAufenthalt.IDAbteilung || p.IDBereich != cAufenthalt.IDBereich)).OrderByDescending(p => p.Zeitpunkt);
                        foreach (dsPlanungIntervention.PflegeEintragRow rPflegeEintragAct in dsPlanungIntervention1.PflegeEintrag)
                        {
                            dsPlanungInterventionUpdate.Clear();
                            iFctCalled = 0;
                            sqlPlanungIntervention1.getPflegeEintrag(rPflegeEintragAct.ID, sqlPlanungIntervention.eSelTypePflegeEintrag.ID, ref dsPlanungInterventionUpdate, DateTime.MinValue, DateTime.MinValue, null, null, ref iFctCalled);
                            dsPlanungIntervention.PflegeEintragRow rPflegeEintragUpdate = (dsPlanungIntervention.PflegeEintragRow)dsPlanungInterventionUpdate.PflegeEintrag.Rows[0];

                            iCounterPE += 1;
                            if (iCounterPETmp >= 200)
                            {
                                iCounterPETmp = 0;
                                System.GC.Collect();
                            }
                            try
                            {
                                bool bAnyChangeDetail = false;

                                if (rPflegeEintragUpdate.IsIDAbteilungNull())
                                {
                                    if (!bNoProt)
                                    {
                                        sInfoAufBereich += this.getInfoAbteilung(IDAbteilung, null, ref sqlKlient1, ref dsKlient2);
                                    }
                                    rPflegeEintragUpdate.IDAbteilung = IDAbteilung.Value;
                                    bAnyChangeDetail = true;
                                }
                                else
                                {
                                    if (rPflegeEintragUpdate.IDAbteilung != IDAbteilung)
                                    {
                                        if (!bNoProt)
                                        {
                                            sInfoAufBereich += this.getInfoAbteilung(IDAbteilung, rPflegeEintragUpdate.IDAbteilung, ref sqlKlient1, ref dsKlient2);
                                        }
                                        rPflegeEintragUpdate.IDAbteilung = IDAbteilung.Value;
                                        bAnyChangeDetail = true;
                                    }
                                }

                                if (rPflegeEintragUpdate.IsIDBereichNull())
                                {
                                    if (IDBereich == System.Guid.Empty)
                                    {
                                        if (!bNoProt)
                                        {
                                            sInfoAufBereich += this.getInfoBereich(null, null, ref sqlKlient1, ref dsKlient2);
                                        }
                                        rPflegeEintragUpdate.SetIDBereichNull();
                                    }
                                    else
                                    {
                                        if (!bNoProt)
                                        {
                                            sInfoAufBereich += this.getInfoBereich(IDBereich, null, ref sqlKlient1, ref dsKlient2);
                                        }
                                        rPflegeEintragUpdate.IDBereich = IDBereich.Value;
                                    }
                                    bAnyChangeDetail = true;
                                }
                                else
                                {
                                    if (rPflegeEintragUpdate.IDBereich != IDBereich)
                                    {
                                        if (IDBereich == System.Guid.Empty)
                                        {
                                            if (!bNoProt)
                                            {
                                                sInfoAufBereich += this.getInfoBereich(null, rPflegeEintragUpdate.IDBereich, ref sqlKlient1, ref dsKlient2);
                                            }
                                            rPflegeEintragUpdate.SetIDBereichNull();
                                        }
                                        else
                                        {
                                            if (!bNoProt)
                                            {
                                                sInfoAufBereich += this.getInfoBereich(IDBereich, rPflegeEintragUpdate.IDBereich, ref sqlKlient1, ref dsKlient2);
                                            }
                                            rPflegeEintragUpdate.IDBereich = IDBereich.Value;
                                        }
                                        bAnyChangeDetail = true;
                                    }
                                }


                                if (bAnyChangeDetail)
                                {
                                    if (SaveChanges)
                                    {
                                        sqlPlanungIntervention1.daPflegeEintrag.Update(dsPlanungInterventionUpdate.PflegeEintrag);
                                    }
                                
                                    iCounterUpdatedPE += 1;
                                    if (!bNoProt)
                                    {
                                        string sInfoDatumPE = "";
                                        if (!rPflegeEintragUpdate.IsDatumErstelltNull())
                                        {
                                            sInfoDatumPE += " (" + rPflegeEintragUpdate.DatumErstellt.ToString() + ")";
                                        }
                                        string sInfoPE = "";
                                        if (rPflegeEintragUpdate.PflegeplanText.Trim().Length >= 11)
                                        {
                                            sInfoPE = rPflegeEintragUpdate.PflegeplanText.Trim().Substring(0, 10) + sInfoDatumPE;
                                        }
                                        else
                                        {
                                            sInfoPE = rPflegeEintragUpdate.PflegeplanText.Trim() + sInfoDatumPE;
                                        }
                                        
                                        string sInfoProt = iCounterUpdatedPE.ToString() + ". PE updated for Klient: " + PatientName + " - " + " Info PE: " + sInfoPE + " - " + sInfoAufBereich + " - Time: " + DateTime.Now.ToString() + "" + "\r\n" + "\r\n";
                                        //sb.Append(sInfoProt);
                                        //this.doLog(sInfoProt);
                                        PMDS.Global.db.ERSystem.PMDSBusinessUI.writeLog(sInfoProt, "PMDS_sysUpdateAufenthaltBereich", false);
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                throw new Exception("sys_UpdateAufenthaltBereichPatientDetail: Error rPflegeEintrag.ID='" + rPflegeEintragAct.ID.ToString() + "' - " + ex.ToString());
                            }

                            PMDSBusiness.dShowInfo2.Invoke(sInfoPatient + " (" + "PE " + iCounterPE.ToString() + " / " + dsPlanungIntervention1.PflegeEintrag.Rows.Count.ToString() + ")");
                        }

                        prevAufenthaltDatum = rAufenthaltVerlauf2.Datum;
                        iCounter += 1;
                    }
                    catch (Exception ex4)
                    {
                        throw new Exception("PMDSBusiness.sys_UpdateAufenthaltBereichPatientDetail: " + ex4.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.sys_UpdateAufenthaltBereichPatientDetail: " + ex.ToString());
            }
        }

        //public void sys_UpdateAufenthaltBereichPatient_orig(bool doLog, ref int iCounterUpdatedPatient, ref int iCounterUpdatedPE, bool SaveChanges)
        //{
        //    try
        //    {
        //        PMDS.db.Entities.ERModellPMDSEntities db2 = DB.PMDSBusiness.getDBContext();
        //        //using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
        //        //{
        //        System.Collections.Generic.List<cSysUpdateData> lstAufenthalte = new List<cSysUpdateData>();

        //        int iCounter = 0;
        //        StringBuilder sb = new StringBuilder();
        //        iCounterUpdatedPatient = 0;
        //        bool bAnyChangeAll = false;

        //        IQueryable<PMDS.db.Entities.Patient> tPatient2 = db2.Patient.OrderBy(p => p.Nachname);
        //        foreach (PMDS.db.Entities.Patient rPatient in tPatient2)
        //        {
        //            string sInfoAufBereich = "";
        //            int iCounterAufenthalt2 = 0;
        //            IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = db2.Aufenthalt.Where(p => p.IDPatient == rPatient.ID).OrderByDescending(p => p.Aufnahmezeitpunkt);
        //            foreach (PMDS.db.Entities.Aufenthalt rAufenthalt in tAufenthalt)
        //            {
        //                try
        //                {
        //                    bool bAnyChangeDetail = false;
        //                    if (rAufenthalt.IDAbteilung == null)
        //                    {
        //                        throw new Exception("rAufenthalt.IDAbteilung=null for IDAufenthalt '" + rAufenthalt.ID.ToString() + "'!!");
        //                    }

        //                    IQueryable<PMDS.db.Entities.Abteilung> tAbteilung = db2.Abteilung.Where(p => p.ID == rAufenthalt.IDAbteilung);
        //                    PMDS.db.Entities.Abteilung rAbteilung = tAbteilung.First();
        //                    if (rAbteilung.IDKlinik != rAufenthalt.IDKlinik)
        //                    {
        //                        throw new Exception("rAbteilung.IDKlinik=rAufenthalt.IDKlinik for rAufenthalt.ID '" + rAufenthalt.ID.ToString() + "'!!");
        //                    }

        //                    if (iCounterAufenthalt2 == 0)
        //                    {
        //                        if (rPatient.IDAbteilung == null)
        //                        {
        //                            sInfoAufBereich += this.getInfoAbteilung(rAufenthalt.IDAbteilung, rPatient.IDAbteilung, db2);
        //                            rPatient.IDAbteilung = rAufenthalt.IDAbteilung;
        //                            bAnyChangeDetail = true;
        //                        }
        //                        else
        //                        {
        //                            if (rAufenthalt.IDAbteilung != rPatient.IDAbteilung)
        //                            {
        //                                sInfoAufBereich += this.getInfoAbteilung(rAufenthalt.IDAbteilung, rPatient.IDAbteilung, db2);
        //                                rPatient.IDAbteilung = rAufenthalt.IDAbteilung;
        //                                bAnyChangeDetail = true;
        //                            }
        //                        }

        //                        if (rAufenthalt.IDBereich == null)
        //                        {
        //                            bool IDBereichIsNull = true;
        //                        }

        //                        if (rPatient.IDBereich == null)
        //                        {
        //                            sInfoAufBereich += this.getInfoBereich(rAufenthalt.IDBereich, rPatient.IDBereich, db2);
        //                            rPatient.IDBereich = rAufenthalt.IDBereich;
        //                            bAnyChangeDetail = true;
        //                        }
        //                        else
        //                        {
        //                            if (rAufenthalt.IDBereich != rPatient.IDBereich)
        //                            {
        //                                sInfoAufBereich += this.getInfoBereich(rAufenthalt.IDBereich, rPatient.IDBereich, db2);
        //                                rPatient.IDBereich = rAufenthalt.IDBereich;
        //                                bAnyChangeDetail = true;
        //                            }
        //                        }
        //                    }


        //                    cSysUpdateData cAufenthalt = new cSysUpdateData();
        //                    cAufenthalt.IDPatient = rPatient.ID;
        //                    cAufenthalt.PatientName = rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim();
        //                    cAufenthalt.IDAufenthalt = rAufenthalt.ID;
        //                    cAufenthalt.IDAbteilung = rAufenthalt.IDAbteilung.Value;
        //                    cAufenthalt.IDBereich = rAufenthalt.IDBereich;
        //                    lstAufenthalte.Add(cAufenthalt);
        //                    iCounterAufenthalt2 += 1;


        //                    if (bAnyChangeDetail)
        //                    {
        //                        iCounter += 1;
        //                        sb.Append(iCounter.ToString() + ". Klient " + cAufenthalt.PatientName + " - " + sInfoAufBereich + "" + "\r\n" + "\r\n");
        //                        iCounterUpdatedPatient += 1;
        //                        bAnyChangeAll = true;
        //                    }

        //                    System.GC.Collect();

        //                }
        //                catch (Exception ex)
        //                {
        //                    throw new Exception("sys_UpdateAufenthaltBereichPatient: Error rAufenthalt.ID='" + rAufenthalt.ID.ToString() + "' - " + ex.ToString());
        //                }
        //            }
        //        }
        //        //if (bAnyChangeAll)
        //        //{
        //        //    if (SaveChanges)
        //        //    {
        //        //        db.SaveChanges();
        //        //    }
        //        //    bAnyChangeAll = false;
        //        //    iCounterUpdatedPatient += 1;
        //        //    if (doLog)
        //        //    {
        //        //        //this.doLog(iCounterUpdatedPatient.ToString() + " Patient updated!" + "\r\n" + sProt + "\r\n");
        //        //    }
        //        //}

        //        //sProt22 = "";
        //        bAnyChangeAll = false;
        //        iCounterUpdatedPE = 0;
        //        foreach (cSysUpdateData cAufenthalt in lstAufenthalte)
        //        {
        //            PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext();

        //            string sInfoAufBereich = "";
        //            sInfoAufBereich = this.getInfoAufenthalt(cAufenthalt.IDAufenthalt, db) + " - ";
        //            int iCounterUpdatedPEDetail = 0;
        //            Nullable<DateTime> prevAufenthaltDatum = null;
        //            DateTime dFrom = new DateTime(1900, 1, 1, 0, 0, 0);
        //            DateTime dTo = new DateTime(2300, 1, 1, 0, 0, 0);
        //            IQueryable<PMDS.db.Entities.AufenthaltVerlauf> tAufenthaltVerlauf = db.AufenthaltVerlauf.Where(p => p.IDAufenthalt == cAufenthalt.IDAufenthalt).OrderByDescending(p => p.Datum);
        //            foreach (PMDS.db.Entities.AufenthaltVerlauf rAufenthaltVerlauf in tAufenthaltVerlauf)
        //            {
        //                if (rAufenthaltVerlauf.Datum == null)
        //                {
        //                    throw new Exception("rAufenthaltVerlauf.Datum=null for rAufenthaltVerlauf.ID '" + rAufenthaltVerlauf.ID.ToString() + "'!!");
        //                }


        //                if (prevAufenthaltDatum != null)
        //                {
        //                    dTo = prevAufenthaltDatum.Value;
        //                }
        //                else
        //                {
        //                    dTo = DateTime.Now;
        //                }
        //                dFrom = rAufenthaltVerlauf.Datum.Value;

        //                IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(p => p.IDAufenthalt == rAufenthaltVerlauf.IDAufenthalt.Value && p.Zeitpunkt >= dFrom && p.Zeitpunkt <= dTo && (p.IDAbteilung != cAufenthalt.IDAbteilung || p.IDBereich != cAufenthalt.IDBereich)).OrderByDescending(p => p.Zeitpunkt);
        //                foreach (PMDS.db.Entities.PflegeEintrag rPflegeEintrag in tPflegeEintrag)
        //                {
        //                    try
        //                    {
        //                        bool bAnyChangeDetail = false;

        //                        if (rPflegeEintrag.IDAufenthalt == null)
        //                        {
        //                            throw new Exception("rPflegeEintrag.IDAufenthalt=null for rPflegeEintrag.ID '" + rPflegeEintrag.IDAufenthalt.ToString() + "'!!");
        //                        }

        //                        if (rPflegeEintrag.IDAbteilung == null)
        //                        {
        //                            sInfoAufBereich += this.getInfoAbteilung(cAufenthalt.IDAbteilung, rPflegeEintrag.IDAbteilung, db);
        //                            rPflegeEintrag.IDAbteilung = cAufenthalt.IDAbteilung;
        //                            bAnyChangeDetail = true;
        //                        }
        //                        else
        //                        {
        //                            if (rPflegeEintrag.IDAbteilung != cAufenthalt.IDAbteilung)
        //                            {
        //                                sInfoAufBereich += this.getInfoAbteilung(cAufenthalt.IDAbteilung, rPflegeEintrag.IDAbteilung, db);
        //                                rPflegeEintrag.IDAbteilung = cAufenthalt.IDAbteilung;
        //                                bAnyChangeDetail = true;
        //                            }
        //                        }

        //                        if (rPflegeEintrag.IDBereich == null)
        //                        {
        //                            if (cAufenthalt.IDBereich == System.Guid.Empty)
        //                            {
        //                                sInfoAufBereich += this.getInfoBereich(null, rPflegeEintrag.IDBereich, db);
        //                                rPflegeEintrag.IDBereich = null;
        //                            }
        //                            else
        //                            {
        //                                sInfoAufBereich += this.getInfoBereich(cAufenthalt.IDBereich, rPflegeEintrag.IDBereich, db);
        //                                rPflegeEintrag.IDBereich = cAufenthalt.IDBereich;
        //                            }
        //                            bAnyChangeDetail = true;
        //                        }
        //                        else
        //                        {
        //                            if (rPflegeEintrag.IDBereich != cAufenthalt.IDBereich)
        //                            {
        //                                if (cAufenthalt.IDBereich == System.Guid.Empty)
        //                                {
        //                                    sInfoAufBereich += this.getInfoBereich(null, rPflegeEintrag.IDBereich, db);
        //                                    rPflegeEintrag.IDBereich = null;
        //                                }
        //                                else
        //                                {
        //                                    sInfoAufBereich += this.getInfoBereich(cAufenthalt.IDBereich, rPflegeEintrag.IDBereich, db);
        //                                    rPflegeEintrag.IDBereich = cAufenthalt.IDBereich;
        //                                }
        //                                bAnyChangeDetail = true;
        //                            }
        //                        }

        //                        if (bAnyChangeDetail)
        //                        {
        //                            iCounter += 1;
        //                            string sInfoDatumPE = "";
        //                            if (rPflegeEintrag.DatumErstellt != null)
        //                            {
        //                                sInfoDatumPE += " (" + rPflegeEintrag.DatumErstellt.ToString() + ")";
        //                            }
        //                            string sInfoPE = rPflegeEintrag.PflegeplanText.Trim() + sInfoDatumPE;
        //                            sb.Append(iCounter.ToString() + ". Klient: " + cAufenthalt.PatientName + " - " + " Text PE: " + sInfoPE + " - " + sInfoAufBereich + "\r\n" + "\r\n" + "\r\n");
        //                            iCounterUpdatedPE += 1;
        //                            iCounterUpdatedPEDetail += 1;
        //                            bAnyChangeAll = true;
        //                        }

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        throw new Exception("sys_UpdateAufenthaltBereichPatient: Error rPflegeEintrag.ID='" + rPflegeEintrag.ID.ToString() + "' - " + ex.ToString());
        //                    }
        //                }

        //                prevAufenthaltDatum = rAufenthaltVerlauf.Datum;
        //            }

        //            if (bAnyChangeAll)
        //            {
        //                if (SaveChanges)
        //                {
        //                    db.SaveChanges();
        //                }
        //                bAnyChangeAll = false;
        //                iCounterUpdatedPE += 1;
        //                if (doLog)
        //                {
        //                    //this.doLog(iCounterUpdatedPEDetail.ToString() + ". PE for Patient: " + cAufenthalt.PatientName.Trim() + "/Aufenthalt '" + cAufenthalt.IDAufenthalt.ToString() +"' upgedated!" + "\r\n" + "\r\n" + sProt + "\r\n" + "\r\n");
        //                }
        //            }

        //        }

        //        qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
        //        frmProt.initControl();
        //        frmProt.Show();
        //        frmProt.ContProtocol1.setText(sb.ToString());
        //        frmProt.Text = "Protokoll Update IDAufenthalt, IDBereicht Patient";
        //        //}

        //    }
        //    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
        //    {
        //        throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("PMDSBusiness.sys_UpdateAufenthaltBereichPatient: " + ex.ToString());
        //    }
        //}

        public string getInfoAufenthalt(Nullable<Guid> IDAufenthalt, ref sqlKlient sqlKlient1, ref dsKlient dsKlient1)
        {
            try
            {
                string sRet = "";
                if (IDAufenthalt == null)
                {
                    sRet += " Für PE kein Aufenthalt";
                }
                else
                {
                    dsKlient1.Aufenthalt.Clear();
                    sqlKlient1.getAufenthalt(IDAufenthalt.Value, sqlKlient.eSelTypeAufenthalt.ID, ref dsKlient1);
                    dsKlient.AufenthaltRow rAuf = (dsKlient.AufenthaltRow)dsKlient1.Aufenthalt.Rows[0];
                    sRet += " Aufenthalt: " + rAuf.Aufnahmezeitpunkt.ToString() + " ";
                }

                return sRet;
            }
            catch (Exception ex)
            {
                throw new Exception("getInfoAufenthalt: " + ex.ToString());
            }
        }

        public string getInfoAbteilung(Nullable<Guid> IDAbteilungNew, Nullable<Guid> IDAbteilungOld, ref sqlKlient sqlKlient1, ref dsKlient dsKlient1)
        {
            try
            {
                string sRet = "";
                if (IDAbteilungNew == null)
                {
                    sRet += " Abteilung new=null ";
                }
                else
                {
                    dsKlient1.Abteilung.Clear();
                    dsKlient.AbteilungRow rAbt = sqlKlient1.getAbteilungRow(IDAbteilungNew.Value, sqlKlient1, ref dsKlient1);
                    sRet += " Abteilung new=" + rAbt.Bezeichnung.Trim() + " ";
                }

                if (IDAbteilungOld == null)
                {
                    sRet += " Abteilung old=null ";
                }
                else
                {
                    dsKlient1.Abteilung.Clear();
                    dsKlient.AbteilungRow rAbt = sqlKlient1.getAbteilungRow(IDAbteilungOld.Value, sqlKlient1, ref dsKlient1);
                    sRet += " Abteilung old=" + rAbt.Bezeichnung.Trim() + " ";
                }

                return sRet;

            }
            catch (Exception ex)
            {
                throw new Exception("getInfoAbteilung: " + ex.ToString());
            }
        }

        public string getInfoBereich(Nullable<Guid> IDBereichNew, Nullable<Guid> IDBereichOld, ref sqlKlient sqlKlient1, ref dsKlient dsKlient1)
        {
            try
            {
                string sRet = "";
                if (IDBereichNew == null)
                {
                    sRet += " Bereich new=null ";
                }
                else
                {
                    dsKlient1.Bereich.Clear();
                    dsKlient.BereichRow rBereich = sqlKlient1.getBereichRow(IDBereichNew.Value, sqlKlient1, ref dsKlient1);
                    sRet += " Bereich new=" + rBereich.Bezeichnung.Trim() + " ";
                }

                if (IDBereichOld == null)
                {
                    sRet += " Bereich old=null ";
                }
                else
                {
                    if (!IDBereichOld.Value.Equals(System.Guid.Empty))
                    {
                        dsKlient1.Bereich.Clear();
                        dsKlient.BereichRow rBereich = sqlKlient1.getBereichRow(IDBereichOld.Value, sqlKlient1, ref dsKlient1);
                        sRet += " Bereich old=" + rBereich.Bezeichnung.Trim() + " ";
                    }
                }

                return sRet;

            }
            catch (Exception ex)
            {
                throw new Exception("getInfoBereich: " + ex.ToString());
            }
        }

        public void doLog(string txt)
        {
            try
            {
                string FileName = PMDS.Global.ENV.LOGPATH + "\\" + "checkPatientAufenthaltBereicht.log";
                using (FileStream fs = new FileStream(FileName, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(txt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doLog: " + ex.ToString());
            }
        }

        public static int GetAgeFromDate(DateTime birthday)
        {
            try
            {
                int years = DateTime.Now.Year - birthday.Year;
                birthday = birthday.AddYears(years);
                if (DateTime.Now.CompareTo(birthday) < 0) { years--; }
                return years;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAgeFromDate: " + ex.ToString());
            }
        }

        public void checkAusawhllisteDescription(Guid IDSelListEntryGuid, string BezeichnungCheck, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlListe = db.AuswahlListe.Where(o => o.ID == IDSelListEntryGuid);
                if (tAuswahlListe.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.checkSelListEntryDescription2: tSelListEntries.Count() != 1 for IDGuidSelListEntry'" + IDSelListEntryGuid.ToString() + "'!");
                }
                PMDS.db.Entities.AuswahlListe rAuswahlListe = tAuswahlListe.First();
                if (rAuswahlListe.Bezeichnung.Trim() != BezeichnungCheck.Trim())
                {
                    rAuswahlListe.Bezeichnung = BezeichnungCheck.Trim();
                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkAusawhllisteDescription: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PflegeEintragEntwurf> getPflegeEintragEntwürf(Guid IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PflegeEintragEntwurf> tPflegeEintragEntwurf = db.PflegeEintragEntwurf.Where(o => o.IDBenutzer == IDBenutzer || (o.FuerUserErstellt != null && o.FuerUserErstellt == IDBenutzer)).OrderBy(p => p.DatumErstellt);
                return tPflegeEintragEntwurf;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPflegeEintragEntwürf: " + ex.ToString());
            }
        }

        public void checkSelListEntryDescription(Guid IDSelListEntryGuid, string IDResCheck, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGuid == IDSelListEntryGuid);
                if (tSelListEntries.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.checkSelListEntryDescription: tSelListEntries.Count() != 1 for IDGuidSelListEntry'" + IDSelListEntryGuid.ToString() + "'!");
                }
                PMDS.db.Entities.tblSelListEntries rSelListEntries = tSelListEntries.First();
                if (rSelListEntries.IDRessource.Trim() != IDResCheck.Trim())
                {
                    rSelListEntries.IDRessource = IDResCheck.Trim();
                    db.SaveChanges();
                }
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkSelListEntryDescription: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<PMDS.db.Entities.tblSelListEntries> getSelListEntries2(String IDGroupStr, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.tblSelListGroup> tSelListGroup = db.tblSelListGroup.Where(o => o.IDGroupStr == IDGroupStr);
                if (tSelListGroup.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.getSelListEntries: rSelListGroup '" + IDGroupStr.Trim() + "' not exists in db!");
                }
                PMDS.db.Entities.tblSelListGroup rSelListGroup = tSelListGroup.First();

                System.Linq.IQueryable<PMDS.db.Entities.tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGroup == rSelListGroup.ID).OrderBy(p => p.IDRessource); 
                return tSelListEntries;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelListEntries2: " + ex.ToString());
            }
        }
        public int getSelListEntriesMaxID(String IDGroupStr, PMDS.db.Entities.ERModellPMDSEntities db, ref int IDOwnIntMax, ref PMDS.db.Entities.tblSelListGroup rSelListGroup)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.tblSelListGroup> tSelListGroup = db.tblSelListGroup.Where(o => o.IDGroupStr == IDGroupStr);
                if (tSelListGroup.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.getSelListEntries: rSelListGroup '" + IDGroupStr.Trim() + "' not exists in db!");
                }
                rSelListGroup = tSelListGroup.First();
                int IDGroupTmp = rSelListGroup.ID;

                int maxID = -999;
                System.Linq.IQueryable<PMDS.db.Entities.tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGroup == IDGroupTmp).OrderBy(p => p.IDRessource);
                foreach (PMDS.db.Entities.tblSelListEntries rSelListEntry in tSelListEntries)
                {
                    if (maxID < rSelListEntry.ID)
                    {
                        maxID = rSelListEntry.ID;
                    }
                    if (rSelListEntry.IDOwnInt != null)
                    {
                        if (IDOwnIntMax < rSelListEntry.IDOwnInt)
                        {
                            IDOwnIntMax = rSelListEntry.IDOwnInt.Value;
                        }
                    }
                }

                return maxID;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelListEntriesMaxID: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<QS2.db.Entities.tblSelListEntries> getSelListEntriesQS2(String IDGroupStr, QS2.db.Entities.ERModellQS2Entities db)
        {
            try
            {
                System.Linq.IQueryable<QS2.db.Entities.tblSelListGroup> tSelListGroup = db.tblSelListGroup.Where(o => o.IDGroupStr == IDGroupStr);
                if (tSelListGroup.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.getSelListEntries: rSelListGroup '" + IDGroupStr.Trim() + "' not exists in db!");
                }
                QS2.db.Entities.tblSelListGroup rSelListGroup = tSelListGroup.First();

                System.Linq.IQueryable<QS2.db.Entities.tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGroup == rSelListGroup.ID).OrderBy(p => p.IDRessource); 
                return tSelListEntries;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelListEntries: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.tblSelListEntries getSelListEntry(Guid IDGuidSelList, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.tblSelListEntries> tSelListEntries = db.tblSelListEntries.Where(o => o.IDGuid == IDGuidSelList);
                PMDS.db.Entities.tblSelListEntries rSelListEntries = tSelListEntries.First();
                return rSelListEntries;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelListEntry: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.tblSelListGroup getSelListEntryGroup(String IDGroupStr, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.tblSelListGroup> tSelListGroup = db.tblSelListGroup.Where(o => o.IDGroupStr == IDGroupStr);
                if (tSelListGroup.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.getSelListEntries: rSelListGroup '" + IDGroupStr.Trim() + "' not exists in db!");
                }
                PMDS.db.Entities.tblSelListGroup rSelListGroup = tSelListGroup.First();
                return rSelListGroup;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelListEntryGroup: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.plan getPlan(Guid IDPlan, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.plan> tPlan = db.plan.Where(o => o.ID == IDPlan);
                if (tPlan.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.getPlan: rPlan.ID '" + IDPlan.ToString().Trim() + "' not exists in db!");
                }
                PMDS.db.Entities.plan rPlan = tPlan.First();
                return rPlan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPlan: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PMDS.db.Entities.plan> getPlansSerientermin(Guid IDSerientermin, DateTime BeginntAm, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.plan> tPlan = db.plan.Where(o => o.IDSerientermin == IDSerientermin && o.BeginntAm > BeginntAm.Date);
                return tPlan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPlansSerientermin: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<PMDS.db.Entities.planObject> getPlanObjects(Guid IDPlan, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.planObject> tplanObject = db.planObject.Where(o => o.IDPlan == IDPlan);
                return tplanObject;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPlanObjects: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<PMDS.db.Entities.plan> getPlansSerientermin4(Guid IDSerientermin, Guid IDPlanOrig, DateTime BeginntAm, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.plan> tPlan = db.plan.Where(o => o.IDSerientermin == IDSerientermin && o.ID != IDPlanOrig && o.BeginntAm >= BeginntAm.Date);
                return tPlan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPlansSerientermin2: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<PMDS.db.Entities.plan> getPlansSerientermin5(Guid IDSerientermin, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.plan> tPlan = db.plan.Where(o => o.IDSerientermin == IDSerientermin);
                return tPlan;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPlansSerientermin5: " + ex.ToString());
            }
        }
        public QS2.db.Entities.tblSelListGroup getSelListEntryGroupQS2(String IDGroupStr, QS2.db.Entities.ERModellQS2Entities db)
        {
            try
            {
                System.Linq.IQueryable<QS2.db.Entities.tblSelListGroup> tSelListGroup = db.tblSelListGroup.Where(o => o.IDGroupStr == IDGroupStr);
                if (tSelListGroup.Count() != 1)
                {
                    throw new Exception("PMDSBusiness.getSelListEntries: rSelListGroup '" + IDGroupStr.Trim() + "' not exists in db!");
                }
                QS2.db.Entities.tblSelListGroup rSelListGroup = tSelListGroup.First();
                return rSelListGroup;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getSelListEntryGroup: " + ex.ToString());
            }
        }

        // 2018
        public PMDS.db.Entities.PflegeEintrag writeDekurs(string TxtDekurs, string TitleDekurs, bool isBewerberJN, Guid IDKlient, PflegeEintragTyp PflegeEintragTyp, 
                                                            Nullable<Guid> IDAufenthalt = null, Nullable<Guid> IDWichtig = null, Nullable<Guid> IDBasis = null, Nullable<DateTime> Zeitpunkt = null, 
                                                            Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = DateTime.Now;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                if (!isBewerberJN)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
                        PMDS.db.Entities.Patient rPatient = b.getPatient2(IDKlient, db);
                        Nullable<Guid> IDAbteilung = null;
                        Nullable<Guid> IDBereich = null;

                        Guid IDAufenthaltTmp;
                        if (!PMDS.Global.historie.HistorieOn)
                        {
                            IDAufenthaltTmp = ENV.IDAUFENTHALT;
                            if (IDAufenthalt != null)
                            {
                                IDAufenthaltTmp = IDAufenthalt.Value;
                            }
                            b.getIDAbteilungIDBereichNachAnsichtsmodus(ref IDAbteilung, ref IDBereich, rPatient.ID, db);
                        }
                        else
                        {
                            IDAufenthaltTmp = ENV.IDAUFENTHALT;
                            b.getIDAbteilungIDBereichNachIDAufenthalt(ref IDAbteilung, ref IDBereich, PMDS.Global.ENV.IDAUFENTHALT, db);
                        }

                        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = b.AddPflegeeintrag(db, TitleDekurs,
                                                                                            DateTime.Now, null, IDBereich,
                                                                                            IDAufenthaltTmp, null, PflegeEintragTyp,
                                                                                            null, IDAbteilung, TxtDekurs);
                        if (IDWichtig != null)
                        {
                            rPflegeEintrag.IDWichtig = IDWichtig;
                            rPflegeEintrag.Wichtig = 1;
                            rPflegeEintrag.Zeitpunkt = Zeitpunkt; 
                        }

                        if (IDBasis != null)
                           rPflegeEintrag.IDDekurs = IDBasis;

                        if (Zeitpunkt != null)
                            rPflegeEintrag.Zeitpunkt = Zeitpunkt;

                        db.SaveChanges();
                        return rPflegeEintrag;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusiness.writeDekurs"))
                {
                    return this.writeDekurs(TxtDekurs, TitleDekurs, isBewerberJN, IDKlient, PflegeEintragTyp, IDAufenthalt, IDWichtig, IDBasis, Zeitpunkt, IDTime);
                }
                throw new Exception("PMDSBusiness.writeDekurs: " + ex.ToString());
                //throw new Exception("PMDSBusiness.writeDekurs: " + ex.ToString());
            }
        }

        public void writeDekursForAssesstment(PMDS.db.Entities.FormularDaten rFormularDaten, PMDS.db.Entities.ERModellPMDSEntities db,
                                            System.Collections.Generic.List<PMDS.db.Entities.FormularDatenFelder> tFormularDatenFelderOrig,
                                            System.Collections.Generic.List<PMDS.db.Entities.AuswahlListe> tAuswahllisteFieldsDekurs, bool IsNew)
        {
            try
            {
                StringBuilder sbDekurs = new StringBuilder();

                List<string> dFelderSort = new List<string>();

                IList<PMDS.db.Entities.AuswahlListe> tSort = tAuswahllisteFieldsDekurs = db.AuswahlListe.Where((a => a.IDAuswahlListeGruppe == "DAS" && a.IstGruppe == false && a.GehörtzuGruppe == rFormularDaten.FormularName)).OrderBy(a => a.Beschreibung).OrderBy(a => a.Reihenfolge).ToList();

                //Formulardatenfelder sortieren nach Reihenfolge in Auswahlliste DAS
                foreach (PMDS.db.Entities.AuswahlListe r in tSort)
                {
                    dFelderSort.Add(r.Bezeichnung);
                }

                foreach (string dFeldSort in dFelderSort)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.FormularDatenFelder> tFormularDatenFelder = db.FormularDatenFelder.Where(o => o.IDFormularDaten == rFormularDaten.ID && o.Feldname == dFeldSort);
                    foreach (PMDS.db.Entities.FormularDatenFelder rFormularDatenFelderSaved in tFormularDatenFelder)
                    {
                        IList<PMDS.db.Entities.AuswahlListe> tDefinitionForField = tAuswahllisteFieldsDekurs = db.AuswahlListe.Where((a => a.IDAuswahlListeGruppe == "DAS" && a.IstGruppe == false && a.GehörtzuGruppe == rFormularDaten.FormularName && a.Bezeichnung == rFormularDatenFelderSaved.Feldname.Trim())).ToList();
                        if (tDefinitionForField.Count() == 1)
                        {
                            PMDS.db.Entities.AuswahlListe rAuswahlisteDefForField = tDefinitionForField[0];
                            PMDS.db.Entities.FormularDatenFelder rFormularDatenFelderOrigWrite = null;
                            foreach (PMDS.db.Entities.FormularDatenFelder rFormularDatenFelderOrig in tFormularDatenFelderOrig)
                            {
                                if (rFormularDatenFelderSaved.Feldname.Trim().Equals(rFormularDatenFelderOrig.Feldname.Trim()))
                                {
                                    if (!rFormularDatenFelderSaved.Feldwert.Trim().Equals(rFormularDatenFelderOrig.Feldwert.Trim()))
                                    {
                                        rFormularDatenFelderOrigWrite = rFormularDatenFelderOrig;
                                    }
                                }
                            }

                            if (!IsNew)
                            {
                                if (rFormularDatenFelderOrigWrite != null)
                                {
                                    string FeldwertTranslationOrig = this.writeDekursForAssesstmentGetTranslationOptionBox(rFormularDatenFelderOrigWrite.Feldwert.Trim(), rFormularDatenFelderOrigWrite.Feldname.Trim(), rFormularDaten.FormularName.Trim(), db);
                                    string FeldwertOrigTmp = "";
                                    if (FeldwertTranslationOrig.Trim() != "")
                                    {
                                        FeldwertOrigTmp = FeldwertTranslationOrig.Trim();
                                    }
                                    else
                                    {
                                        FeldwertOrigTmp = this.checkFormularwertBool(rFormularDatenFelderOrigWrite.Feldwert.Trim());
                                    }

                                    string FeldwertTranslationNew = this.writeDekursForAssesstmentGetTranslationOptionBox(rFormularDatenFelderSaved.Feldwert.Trim(), rFormularDatenFelderSaved.Feldname.Trim(), rFormularDaten.FormularName.Trim(), db);
                                    string FeldwertNewTmp = "";
                                    if (FeldwertTranslationNew.Trim() != "")
                                    {
                                        FeldwertNewTmp = FeldwertTranslationNew.Trim();
                                    }
                                    else
                                    {
                                        FeldwertNewTmp = this.checkFormularwertBool(rFormularDatenFelderSaved.Feldwert.Trim());
                                    }

                                    sbDekurs.Append("\r\n" + rAuswahlisteDefForField.Beschreibung.Trim() + " " + FeldwertOrigTmp.Trim() + " -> " + FeldwertNewTmp.Trim());
                                }
                            }
                            else
                            {
                                if (rFormularDatenFelderSaved.Feldwert.Trim() != "")
                                {
                                    string FeldwertTranslationNew = this.writeDekursForAssesstmentGetTranslationOptionBox(rFormularDatenFelderSaved.Feldwert.Trim(), rFormularDatenFelderSaved.Feldname.Trim(), rFormularDaten.FormularName.Trim(), db);
                                    string FeldwertNewTmp = "";
                                    if (FeldwertTranslationNew.Trim() != "")
                                    {
                                        FeldwertNewTmp = FeldwertTranslationNew.Trim();
                                    }
                                    else
                                    {
                                        FeldwertNewTmp = this.checkFormularwertBool(rFormularDatenFelderSaved.Feldwert.Trim());
                                    }

                                    sbDekurs.Append("\r\n" + rAuswahlisteDefForField.Beschreibung.Trim() + ": " + FeldwertNewTmp.Trim());
                                }
                            }
                        }
                        else if (tDefinitionForField.Count() == 0)
                        {
                            bool NoDekursForField = true;
                        }
                        else
                        {
                            throw new Exception("PMDSBusinesswriteDekursForAssesstment: Definition in Auswahlliste '' > 1 not allowed for FormularName '" + rFormularDaten.FormularName.Trim() + "' and Feldname '" + rFormularDatenFelderSaved.Feldname.Trim() + "'!");
                        }
                    }
                }


                

                if (sbDekurs.ToString().Length > 0)
                {
                    PMDS.db.Entities.Formular rFormular = db.Formular.Where(o => o.Name == rFormularDaten.FormularName).First();
                    PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment wurde editiert") + ": " + rFormular.Bezeichnung.Trim() + "\n\r" + sbDekurs.ToString(),
                                        false, PMDS.Global.ENV.CurrentIDPatient, PflegeEintragTyp.Assessment);
                    
                    //os180809  //Dekurs "NeuesAssessment" mit IDWichtig schreiben
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    //System.Collections.Generic.List<Guid> lst = PMDS.Global.Tools.GetWichtigFuerDefaults(PMDS.Global.eDekursherkunft.none, "NeuesAssessment");

                    System.Collections.Generic.List<Guid> lstGuidBerufsgruppen = new List<Guid>();
                    System.Collections.Generic.List<string> lstBerufsgruppen = qs2.core.generic.readStrVariables(rFormular.lstIDBerufsgruppe.Trim());
                    if (lstBerufsgruppen.Count > 0)
                    {
                        foreach (string IDBerufsgruppe in lstBerufsgruppen)
                        {
                            lstGuidBerufsgruppen.Add (new Guid(IDBerufsgruppe.Trim()));
                        }

                        PMDS.db.Entities.PflegeEintrag rPEUpdate2 = b.getPflegeEintrag(rPflegeEintrag.ID, db);
                        rPEUpdate2.IDGruppe = Guid.NewGuid();

                        foreach (Guid IDWichtig in lstGuidBerufsgruppen)                                     
                        {
                            PMDS.db.Entities.PflegeEintrag rPflegeEintragWichtig = this.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment wurde editiert") + "\n\r" + sbDekurs.ToString(),
                                false, ENV.CurrentIDPatient, PflegeEintragTyp.Assessment);

                            PMDS.db.Entities.PflegeEintrag rPEUpdate = b.getPflegeEintrag(rPflegeEintragWichtig.ID, db);
                            rPEUpdate.IDWichtig = IDWichtig;
                            rPEUpdate.Wichtig = 1;
                            rPEUpdate.CC = true;
                            rPEUpdate.IDGruppe = rPEUpdate2.IDGruppe;
                            rPEUpdate.IDDekurs = rPEUpdate2.ID;
                            rPEUpdate.Zeitpunkt = rPEUpdate2.Zeitpunkt;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusiness.writeDekursForAssesstment"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.writeDekursForAssesstment: " + ex.ToString());
            }
        }
        public string writeDekursForAssesstmentGetTranslationOptionBox(string sWert, string Feldname, string FormularName, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                int iWert;
                if (int.TryParse(sWert.Trim(), out iWert))
                {
                    IList<PMDS.db.Entities.AuswahlListe> tAuswahllisteFieldsDekurs = db.AuswahlListe.Where((a => a.IDAuswahlListeGruppe == "DAS" && a.IstGruppe == true && a.GehörtzuGruppe == FormularName && a.Bezeichnung == Feldname.Trim() && a.Hierarche == iWert)).ToList();
                    if (tAuswahllisteFieldsDekurs.Count() == 1)
                    {
                        PMDS.db.Entities.AuswahlListe rAuswahllisteTranslation = tAuswahllisteFieldsDekurs.First();
                        return rAuswahllisteTranslation.Beschreibung.Trim();
                    }
                    else if (tAuswahllisteFieldsDekurs.Count() > 1)
                    {
                        throw new Exception("writeDekursForAssesstmentGetTranslationOptionBox: tAuswahllisteFieldsDekurs.Count() > 1 for Feldname '" + Feldname.Trim() + "' not allowed!");
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusiness.writeDekursForAssesstmentGetTranslationOptionBox"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.writeDekursForAssesstmentGetTranslationOptionBox: " + ex.ToString());
            }
        }

        public string checkFormularwertBool(string Feldwert)
        {
            try
            {
                if (Feldwert.Trim().ToLower().Equals(("True").Trim().ToLower()))
                {
                    return QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
                }
                else if (Feldwert.Trim().ToLower().Equals(("False").Trim().ToLower()))
                {
                    return QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");
                }
                else
                {
                    return Feldwert;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkFormularwertBool: " + ex.ToString());
            }
        }

        public List<PMDS.db.Entities.FormularDatenFelder> loadFormularDatenFelderForAssesstment(Guid IDFormularData, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.FormularDatenFelder> tFormularDatenFelder = db.FormularDatenFelder.Where(o => o.IDFormularDaten == IDFormularData);
                return tFormularDatenFelder.ToList();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.loadFormularDatenFelderForAssesstment: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PMDS.db.Entities.Layout> getLayout(string Key, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Layout> tLayout = db.Layout.Where(o => o.Key.Contains(Key.Trim()));
                return tLayout;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getLayout: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<PMDS.db.Entities.LayoutGrids> getLayoutGrid(Guid IDLayout, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.LayoutGrids> tLayout = db.LayoutGrids.Where(o => o.IDLayout == IDLayout).OrderBy(o => o.OrderBy);
                return tLayout;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getLayoutGrid: " + ex.ToString());
            }
        }

        public bool DeleteRezeptEintragMedDatenzuordnungen(Guid IDRezepteintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string strSQl = "Delete from RezeptEintragMedDaten where IDRezepteintrag='" + IDRezepteintrag.ToString() + "' and IDVerordnung is null ";
                DbParameter[] pars = new DbParameter[] { };
                db.Database.ExecuteSqlCommand(strSQl, pars);
                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeleteRezeptEintragMedDatenzuordnungen: " + ex.ToString());
            }
        }

        public bool DeleteMedDatenRezeptEintragsZuordnungen(Guid IDMedDaten, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string strSQl = "Delete from RezeptEintragMedDaten where IDMedDaten='" + IDMedDaten.ToString() + "' and IDVerordnung is null "; 
                DbParameter[] pars = new DbParameter[]{};
                db.Database.ExecuteSqlCommand(strSQl, pars);
                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeleteMedDatenRezeptEintragsZuordnungen: " + ex.ToString());
            }
        }
        public bool DeleteMedizinischeDaten(Guid IDMedDaten, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string strSQl = "Delete from MedizinischeDaten where ID='" + IDMedDaten.ToString() + "' ";
                DbParameter[] pars = new DbParameter[] { };
                db.Database.ExecuteSqlCommand(strSQl, pars);
                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.DeleteMedizinischeDaten: " + ex.ToString());
            }
        }
        public void copyRezeptEintragMedDaten(Guid IDRezeptEintragCopyFrom, Guid IDRezeptEintragTo, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == IDRezeptEintragCopyFrom && o.IDVerordnung == null);
                foreach (RezeptEintragMedDaten rRezeptEintragMedDatenExists in tRezeptEintragMedDaten)
                {
                    PMDS.db.Entities.RezeptEintragMedDaten rNewRezeptEintragMedDaten = PMDS.Global.db.ERSystem.EFEntities.newRezeptEintragMedDaten(db);
                    rNewRezeptEintragMedDaten.ID = System.Guid.NewGuid();
                    rNewRezeptEintragMedDaten.IDMedDaten = rRezeptEintragMedDatenExists.IDMedDaten;
                    rNewRezeptEintragMedDaten.IDRezepteintrag = IDRezeptEintragTo;
                    db.RezeptEintragMedDaten.Add(rNewRezeptEintragMedDaten);
                }

                db.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.CopyMedDatenToERRowAndSave()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.copyRezeptEintragMedDaten: " + ex.ToString());
            }
        }

        public DataTable getPatientsByMedikament(string MedikamentToSearch, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string strSQl = "Select (Patient.Nachname + ' ' + Patient.Vorname) as Patient, Patient.ID as IDPatient, Aufenthalt.ID as IDAufenthalt, Medikament.ID as IDMedikament, Medikament.Bezeichnung as Medikament from RezeptEintrag, " +
                                " Medikament, Aufenthalt, Patient where RezeptEintrag.IDMedikament=Medikament.ID and " +
                                " RezeptEintrag.IDAufenthalt=Aufenthalt.ID and Patient.ID= Aufenthalt.IDPatient and " +
                                " Medikament.Bezeichnung like '%" + MedikamentToSearch.Trim() + "%'and Aufenthalt.Entlassungszeitpunkt is null and RezeptEintrag.AbzugebenVon<=? and AbzugebenBis>=? ";

                DataTable dt = new DataTable();
                System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter();
                System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = strSQl;
                da.SelectCommand = cmd;
                DateTime dNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AbzugebenVon", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenVon")).Value = dNow;
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AbzugebenBis", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenBis")).Value = dNow;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dt);

                return dt;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.CopyMedDatenToERRowAndSave()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getPatientsByMedikament: " + ex.ToString());
            }
        }

        public void CopyMedDatenToERRowAndSave(Guid id, int medTyp, DateTime von, DateTime bis, string beschreibung, string bemerkung,
                       string beendigungsgrund, DateTime letzteVersorgung, DateTime naechsteVersorgung, string modell, string handling,
                       string therapie, string ICDCode, bool aufnahmeDiagnose, bool antikoaguliert, string Typ, double anzahl, bool nuechtern, string groesse, Guid IDPatient,
                       PMDS.db.Entities.ERModellPMDSEntities db, bool IsNew)
        {
            try
            {
                PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = null;
                if (IsNew)
                {
                    rMedizinischeDaten = PMDS.Global.db.ERSystem.EFEntities.newMedizinischeDaten(db);
                    rMedizinischeDaten.ID = id;
                    rMedizinischeDaten.MedizinischerTyp = medTyp;
                    rMedizinischeDaten.IDPatient = IDPatient;
                }
                else
                {
                    System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == id);
                    rMedizinischeDaten = tMedizinischeDaten.First();
                }

                rMedizinischeDaten.Von = von;
                if (bis != DateTime.MinValue)
                    rMedizinischeDaten.Bis = bis;
                else
                    rMedizinischeDaten.Bis = null;

                rMedizinischeDaten.Beschreibung = beschreibung;
                rMedizinischeDaten.Bemerkung = bemerkung;
                rMedizinischeDaten.Beendigungsgrund = beendigungsgrund;

                if (letzteVersorgung != DateTime.MinValue)
                    rMedizinischeDaten.LetzteVersorgung = letzteVersorgung;
                else
                    rMedizinischeDaten.LetzteVersorgung = null;

                if (naechsteVersorgung != DateTime.MinValue)
                    rMedizinischeDaten.NaechsteVersorgung = naechsteVersorgung;
                else
                    rMedizinischeDaten.NaechsteVersorgung = null;

                rMedizinischeDaten.Modell = modell;
                rMedizinischeDaten.Handling = handling;
                rMedizinischeDaten.Therapie = therapie;
                rMedizinischeDaten.ICDCode = ICDCode;
                rMedizinischeDaten.AufnahmediagnoseJN = aufnahmeDiagnose;
                rMedizinischeDaten.AntikoaguliertJN = antikoaguliert;
                rMedizinischeDaten.Typ = Typ;
                rMedizinischeDaten.Anzahl = anzahl;
                rMedizinischeDaten.NuechternJN = nuechtern;
                rMedizinischeDaten.Groesse = groesse;
                rMedizinischeDaten.IDBenutzergeaendert = ENV.USERID;
                
                if (IsNew)
                    db.MedizinischeDaten.Add(rMedizinischeDaten);

                db.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.CopyMedDatenToERRowAndSave()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.CopyMedDatenToERRowAndSave: " + ex.ToString());
            }
        }

        public void getColMedikamenteForGrid(PMDS.db.Entities.ERModellPMDSEntities db, Guid IDMedikament, ref string sErstattungscode, ref string sKassenzeichen)
        {
            try
            {
                PMDS.db.Entities.Medikament rMedikament = db.Medikament.Where(a => a.ID == IDMedikament).First();
                sErstattungscode = rMedikament.Erstattungscode;
                sKassenzeichen = rMedikament.Kassenzeichen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.CopyMedDatenToERRowAndSave()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getColMedikamenteForGrid: " + ex.ToString());
            }
        }
        public void saveProtocol(PMDS.db.Entities.ERModellPMDSEntities db, string Info, string Protocol)
        {
            try
            {
                qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
                qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                sqlProtocoll.initControl();
                string CmdReturn = "";
                sqlProtocoll.getProtocol(System.Guid.NewGuid(), ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

                qs2.core.vb.dsProtocol.ProtocolRow rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
                rNewProt.IDGuid = System.Guid.NewGuid();
                rNewProt.Type = "PMDS";
                rNewProt.IDApplication = "PMDS";
                rNewProt.Info = Info;
                rNewProt.Protocol = Protocol;
                rNewProt.Created = DateTime.Now;
                rNewProt.CreatedDay = DateTime.Now.Date;
                rNewProt.User = ENV.LoginInNameFrei.Trim();

                sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.CopyMedDatenToERRowAndSave()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.saveProtocol: " + ex.ToString());
            }
        }
        public PMDS.db.Entities.WundePos getWundePos(Guid IDWundePos, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.WundePos> tWundePos = db.WundePos.Where(a => a.ID == IDWundePos);
                if (tWundePos.Count() == 1)
                {
                    return tWundePos.First();
                }
                else
                {
                    return null;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.CopyMedDatenToERRowAndSave()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getWundePos: " + ex.ToString());
            }
        }
        public bool checkMedikationAbgabeExists(Guid IDRezepteintrag, Guid IDAufenthalt, DateTime Zeitpunkt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.MedikationAbgabe> tMedikationAbgabe = db.MedikationAbgabe.Where(a => a.IDRezeptEintrag == IDRezepteintrag && a.IDAufenthalt == IDAufenthalt && a.Zeitpunkt == Zeitpunkt);
                if (tMedikationAbgabe.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.checkMedikationAbgabeExists()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkMedikationAbgabeExists: " + ex.ToString());
            }
        }

        public string getPatientInfoFromIDAufenthalt(Guid IDAufenthalt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {

                var tPatient = (from a in db.Aufenthalt
                                         join p in db.Patient on a.IDPatient equals p.ID
                                         where a.ID == IDAufenthalt
                                         select new
                                         {
                                             p.ID,
                                             p.Nachname,
                                             p.Vorname
                                         });

                var rPat = tPatient.First();
                return rPat.Nachname.Trim() + " " + rPat.Vorname.Trim();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.getPatientInfoFromIDAufenthalt()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getPatientInfoFromIDAufenthalt: " + ex.ToString());
            }
        }
        public string getMedikemantInfoFromIDRezepteintrag(Guid IDRezepteintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {

                var tMedikamentRE = (from r in db.RezeptEintrag
                                join m in db.Medikament on r.IDMedikament equals m.ID
                                where r.ID == IDRezepteintrag
                                select new
                                {
                                    m.Bezeichnung
                                });

                var rMedRE = tMedikamentRE.First();
                return rMedRE.Bezeichnung.Trim();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.getMedikemantInfoFromIDRezepteintrag()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getMedikemantInfoFromIDRezepteintrag: " + ex.ToString());
            }
        }


        public void copyPdxAnamnese(Nullable<Guid> IDAnamneseKrohwinkel, Nullable<Guid> IDAnamneseOrem, Nullable<Guid> IDAnamnesePOP, Guid IDNew, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                if (IDAnamneseKrohwinkel != null)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PDXAnamnese> tPDXAnamnese = db.PDXAnamnese.Where(a => a.IDAnamneseKrohwinkel == IDAnamneseKrohwinkel);
                    foreach (PMDS.db.Entities.PDXAnamnese rPDXAnamnese in tPDXAnamnese)
                    {
                        PMDS.db.Entities.PDXAnamnese rNewPDXAnamnese = PMDS.Global.db.ERSystem.EFEntities.newPDXAnamnese(db);
                        rNewPDXAnamnese.ID = System.Guid.NewGuid();
                        rNewPDXAnamnese.Modell = rPDXAnamnese.Modell;
                        rNewPDXAnamnese.Modellgruppe = rPDXAnamnese.Modellgruppe;
                        rNewPDXAnamnese.IDAnamneseKrohwinkel = IDNew;
                        rNewPDXAnamnese.IDAnamneseOrem = rPDXAnamnese.IDAnamneseOrem;
                        rNewPDXAnamnese.IDAnamneseNanda = rPDXAnamnese.IDAnamneseNanda;
                        rNewPDXAnamnese.IDAnamneseRT = rPDXAnamnese.IDAnamneseRT;
                        rNewPDXAnamnese.IDAnamneseJuchli = rPDXAnamnese.IDAnamneseJuchli;
                        rNewPDXAnamnese.IDAnamneseRAI = rPDXAnamnese.IDAnamneseRAI;
                        rNewPDXAnamnese.IDPDX = rPDXAnamnese.IDPDX;
                        rNewPDXAnamnese.Resourceklient = rPDXAnamnese.Resourceklient;
                        rNewPDXAnamnese.IDAnamnesePOP = rPDXAnamnese.IDAnamnesePOP;

                        db.PDXAnamnese.Add(rNewPDXAnamnese);
                    }
                    db.SaveChanges();
                }
                else if (IDAnamneseOrem != null)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PDXAnamnese> tPDXAnamnese = db.PDXAnamnese.Where(a => a.IDAnamneseOrem == IDAnamneseOrem);
                    foreach (PMDS.db.Entities.PDXAnamnese rPDXAnamnese in tPDXAnamnese)
                    {
                        PMDS.db.Entities.PDXAnamnese rNewPDXAnamnese = PMDS.Global.db.ERSystem.EFEntities.newPDXAnamnese(db);
                        rNewPDXAnamnese.ID = System.Guid.NewGuid();
                        rNewPDXAnamnese.Modell = rPDXAnamnese.Modell;
                        rNewPDXAnamnese.Modellgruppe = rPDXAnamnese.Modellgruppe;
                        rNewPDXAnamnese.IDAnamneseKrohwinkel = rPDXAnamnese.IDAnamneseKrohwinkel;
                        rNewPDXAnamnese.IDAnamneseOrem = IDNew;
                        rNewPDXAnamnese.IDAnamneseNanda = rPDXAnamnese.IDAnamneseNanda;
                        rNewPDXAnamnese.IDAnamneseRT = rPDXAnamnese.IDAnamneseRT;
                        rNewPDXAnamnese.IDAnamneseJuchli = rPDXAnamnese.IDAnamneseJuchli;
                        rNewPDXAnamnese.IDAnamneseRAI = rPDXAnamnese.IDAnamneseRAI;
                        rNewPDXAnamnese.IDPDX = rPDXAnamnese.IDPDX;
                        rNewPDXAnamnese.Resourceklient = rPDXAnamnese.Resourceklient;
                        rNewPDXAnamnese.IDAnamnesePOP = rPDXAnamnese.IDAnamnesePOP;

                        db.PDXAnamnese.Add(rNewPDXAnamnese);
                    }
                    db.SaveChanges();
                }
                else if (IDAnamnesePOP != null)
                {
                    System.Linq.IQueryable<PMDS.db.Entities.PDXAnamnese> tPDXAnamnese = db.PDXAnamnese.Where(a => a.IDAnamnesePOP == IDAnamnesePOP);
                    foreach (PMDS.db.Entities.PDXAnamnese rPDXAnamnese in tPDXAnamnese)
                    {
                        PMDS.db.Entities.PDXAnamnese rNewPDXAnamnese = PMDS.Global.db.ERSystem.EFEntities.newPDXAnamnese(db);
                        rNewPDXAnamnese.ID = System.Guid.NewGuid();
                        rNewPDXAnamnese.Modell = rPDXAnamnese.Modell;
                        rNewPDXAnamnese.Modellgruppe = rPDXAnamnese.Modellgruppe;
                        rNewPDXAnamnese.IDAnamneseKrohwinkel = rPDXAnamnese.IDAnamneseKrohwinkel;
                        rNewPDXAnamnese.IDAnamneseOrem = rPDXAnamnese.IDAnamneseOrem;
                        rNewPDXAnamnese.IDAnamneseNanda = rPDXAnamnese.IDAnamneseNanda;
                        rNewPDXAnamnese.IDAnamneseRT = rPDXAnamnese.IDAnamneseRT;
                        rNewPDXAnamnese.IDAnamneseJuchli = rPDXAnamnese.IDAnamneseJuchli;
                        rNewPDXAnamnese.IDAnamneseRAI = rPDXAnamnese.IDAnamneseRAI;
                        rNewPDXAnamnese.IDPDX = rPDXAnamnese.IDPDX;
                        rNewPDXAnamnese.Resourceklient = rPDXAnamnese.Resourceklient;
                        rNewPDXAnamnese.IDAnamnesePOP = IDNew;

                        db.PDXAnamnese.Add(rNewPDXAnamnese);
                    }
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("copyPdxAnamnese: IDAnamnese not defined for copy!");
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.getMedikemantInfoFromIDRezepteintrag()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.copyPdxAnamnese: " + ex.ToString());
            }
        }

        public bool checkOffeneTerminePatient(Guid IDPatient, DateTime DeleteAt, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var tPlansOpen = (from p in db.plan
                                    join po in db.planObject on p.ID equals po.IDPlan
                                    where po.IDObject == IDPatient && p.BeginntAm >= DeleteAt 
                                    orderby p.ErstelltAm ascending 
                                    select new
                                    {
                                        p.ID
                                    }).Distinct();

                return tPlansOpen.Count() > 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.getMedikemantInfoFromIDRezepteintrag()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkOffeneTerminePatient: " + ex.ToString());
            }
        }

        public bool updateOpendPlansPatient(Guid IDPatient, DateTime DeleteAt, PMDS.db.Entities.ERModellPMDSEntities db, bool deletePlans)
        {
            try
            {
                string strSQl = "";
                if (deletePlans)
                {
                    strSQl = "delete [planObject] where ID IN " +
                                "(Select po.ID from planObject po, [plan] p " +
                                "where p.ID = po.IDPlan  and " +
                                "p.BeginntAm>=@BeginntAm and po.IDObject = '" + IDPatient.ToString() + "')";
                }
                else
                {
                    strSQl = "UPDATE [planObject] SET planObject.Status = 'Erledigt' " +
                                " FROM [plan] AS p " +
                                " INNER JOIN planObject AS po ON p.ID = po.IDPlan " +
                                " WHERE " +
                                " p.BeginntAm>=@BeginntAm and po.IDObject='" + IDPatient.ToString() + "' ";
                }

                DbParameter[] pars = new DbParameter[]
                {
                    new SqlParameter {ParameterName="BeginntAm", Value=DeleteAt, DbType= DbType.DateTime, SourceColumn= "@BeginntAm"}
                };
                db.Database.ExecuteSqlCommand(strSQl, pars);
                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.getMedikemantInfoFromIDRezepteintrag()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.updateOpendPlansPatient: " + ex.ToString());
            }
        }
        public void checkVOAndUpdate(Nullable<Guid> IDAufenthalt, DateTime EntlassenAm, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var tVO = (from vo in db.VO
                                  where vo.IDAufenthalt == IDAufenthalt && (vo.DatumVerordnetBis >= EntlassenAm.Date || vo.DatumVerordnetBis == null)
                                  select new
                                  {
                                      vo.ID
                                  });

                if (tVO.Count() > 0)
                {
                    foreach (var rVO in tVO)
                    {
                        PMDS.db.Entities.VO rVOUpdateToDB = db.VO.Where(b => b.ID == rVO.ID).First();
                        rVOUpdateToDB.DatumVerordnetBis = EntlassenAm.Date.AddDays(-1);

                        var tVO_Bestelldaten = (from vobe in db.VO_Bestelldaten
                                               where vobe.IDVerordnung == rVO.ID && (vobe.GueltigBis >= EntlassenAm.Date || vobe.GueltigBis == null)
                                               select new
                                               {
                                                   vobe.ID
                                               });

                        if (tVO_Bestelldaten.Count() > 0)
                        {
                            foreach (var rVOBestelldaten in tVO_Bestelldaten)
                            {
                                PMDS.db.Entities.VO_Bestelldaten rVOBestelldatenUpdateToDB = db.VO_Bestelldaten.Where(b => b.ID == rVOBestelldaten.ID).First();
                                rVOBestelldatenUpdateToDB.GueltigBis = EntlassenAm.Date.AddDays(-1);
                            }
                        }
                    }
                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.getMedikemantInfoFromIDRezepteintrag()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkVO: " + ex.ToString());
            }
        }



        public void sys_PEUpdateIDBerusstandWhereNull(DateTime dFrom, DateTime dTo, PMDS.db.Entities.ERModellPMDSEntities db, Infragistics.Win.Misc.UltraLabel lbl,
                                                       ref System.Collections.Generic.List<Guid> lPEOK, ref System.Collections.Generic.List<Guid> lPEError)
        {
            Nullable<Guid> IDPETmp = null;
            try
            {
                var tPE = (from pe in db.PflegeEintrag
                           where pe.Zeitpunkt >= dFrom.Date && pe.Zeitpunkt <= dTo.Date && pe.IDBerufsstand == null
                           select new
                           {
                               pe.ID,
                               pe.IDBenutzer,
                               pe.IDAufenthalt
                           });

                System.Collections.Generic.Dictionary<Guid, PEs> lPe2 = new System.Collections.Generic.Dictionary<Guid, PEs>();
                foreach (var r in tPE)
                {
                    lPe2.Add(System.Guid.NewGuid(), new PEs() { IDPe = r.ID, IDBenutzer = r.IDBenutzer.Value,  IDAufenthalt  = r.IDAufenthalt });
                }

                string iTotal = tPE.Count().ToString();
                int iCounter = 0;
                if (lPe2.Count() > 0)
                {
                    foreach (var valPair2 in lPe2)
                    {
                        try
                        {
                            IDPETmp = valPair2.Key;

                            var rBen = (from b in db.Benutzer where b.ID == valPair2.Value.IDBenutzer
                                                select new
                                                {
                                                    b.ID,
                                                    b.IDBerufsstand
                                                }).First();

                            var rPEUpdate = db.PflegeEintrag.Where(p => p.ID == valPair2.Value.IDPe &&  p.IDAufenthalt == valPair2.Value.IDAufenthalt).First();
                            rPEUpdate.IDBerufsstand = rBen.IDBerufsstand;
                            db.SaveChanges();

                            iCounter += 1;
                            lPEOK.Add(valPair2.Key);
                            lbl.Invoke(new Action(() => lbl.Text = "DS " + iCounter.ToString() + " from " + iTotal));
                            System.Windows.Forms.Application.DoEvents();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                        {
                            lPEError.Add(IDPETmp.Value);
                        }
                        catch (Exception ex)
                        {
                            lPEError.Add(IDPETmp.Value);
                        }
                    }
                }
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.sys_PEUpdateIDBerusstandWhereNull()"));
            }
            catch (Exception ex)
            {
                throw new Exception("sys_PEUpdateIDBerusstandWhereNull.checkVO: " + ex.ToString());
            }
        }
        public void copyUpdateZusatzwertePEIDGruppe2(Guid IDPEOrig2, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var rPEOrig = (from pe in db.PflegeEintrag where pe.ID == IDPEOrig2
                               select new { pe.ID, pe.IDEintrag, pe.IDGruppe }).First();

                if (rPEOrig.IDEintrag != null && rPEOrig.IDGruppe != null)
                {                    
                    var tZusatzWertePEOrig = (from ze in db.ZusatzEintrag
                                        join zge in db.ZusatzGruppeEintrag on ze.ID equals zge.IDZusatzEintrag
                                        join zw in db.ZusatzWert on zge.ID equals zw.IDZusatzGruppeEintrag
                                        where zge.IDFilter == rPEOrig.IDEintrag && zw.IDObjekt == rPEOrig.ID
                                              orderby ze.Bezeichnung ascending
                                        select new{zw.ID, IDZGE = zge.ID, zw.Wert, zw.ZahlenWert, zw.ZahlenWertFloat, zw.RawFormat, zge.IDFilter, zw.IDObjekt, zge.IDZusatzEintrag, zge.IDZusatzGruppe, zge.OptionalJN, zge.DruckenJN, zge.Reihenfolge.HasValue});

                    var tPESameIDGruppe = (from pe in db.PflegeEintrag
                                   where pe.ID != rPEOrig.ID && pe.IDGruppe == rPEOrig.IDGruppe
                                           select new { pe.ID, pe.IDEintrag });

                    if (tPESameIDGruppe.Count() > 0)
                    {
                        foreach (var rPESameIDGruppe in tPESameIDGruppe)
                        {
                            var rPECopied = (from pe in db.PflegeEintrag
                                             where pe.ID == rPESameIDGruppe.ID
                                             select new { pe.ID, pe.IDEintrag }).First();
                            if (rPECopied.IDEintrag != null)
                            {
                                var tZusatzWertePECopied = (from ze in db.ZusatzEintrag
                                                            join zge in db.ZusatzGruppeEintrag on ze.ID equals zge.IDZusatzEintrag
                                                            join zw in db.ZusatzWert on zge.ID equals zw.IDZusatzGruppeEintrag
                                                            where zge.IDFilter == rPECopied.IDEintrag && zge.IDObjekt != rPEOrig.ID && zw.IDObjekt == rPECopied.ID
                                                            orderby ze.Bezeichnung ascending
                                                            select new { zw.ID, IDZGE = zge.ID, zw.Wert, zw.ZahlenWert, zw.ZahlenWertFloat, zw.RawFormat, zge.IDFilter, zw.IDObjekt, zge.IDZusatzEintrag, zge.IDZusatzGruppe, zge.OptionalJN, zge.DruckenJN, zge.Reihenfolge });

                                foreach (var rZWPEOrig in tZusatzWertePEOrig)
                                {
                                    bool bZusatzwertFound = false;
                                    foreach (var rZWPECopied in tZusatzWertePECopied)
                                    {
                                        if (rZWPECopied.IDZusatzEintrag.Equals(rZWPEOrig.IDZusatzEintrag) && rZWPECopied.IDZusatzGruppe.Equals(rZWPEOrig.IDZusatzGruppe))
                                        {
                                            PMDS.db.Entities.ZusatzWert rZusatzWertCopied = db.ZusatzWert.Where(b => b.ID == rZWPECopied.ID).First();
                                            rZusatzWertCopied.Wert = rZWPEOrig.Wert;
                                            rZusatzWertCopied.ZahlenWert = rZWPEOrig.ZahlenWert;
                                            rZusatzWertCopied.RawFormat = rZWPEOrig.RawFormat;
                                            rZusatzWertCopied.ZahlenWertFloat = rZWPEOrig.ZahlenWertFloat;

                                            bZusatzwertFound = true;
                                        }
                                    }
                                    //db.SaveChanges();

                                    if (!bZusatzwertFound)
                                    {
                                        PMDS.db.Entities.ZusatzGruppeEintrag rZusatzGruppeEintragAct = db.ZusatzGruppeEintrag.Where(b => b.ID == rZWPEOrig.IDZGE).First();
                                        PMDS.db.Entities.ZusatzWert rZusatzWertAct = db.ZusatzWert.Where(b => b.ID == rZWPEOrig.ID).First();

                                        //PMDS.db.Entities.ZusatzGruppeEintrag rNewZusatzGruppeEintragForPECopied = EFEntities.newZusatzGruppeEintrag(db);
                                        //rNewZusatzGruppeEintragForPECopied.ID = System.Guid.NewGuid();
                                        //rNewZusatzGruppeEintragForPECopied.IDZusatzGruppe = rZusatzGruppeEintragAct.IDZusatzGruppe;
                                        //rNewZusatzGruppeEintragForPECopied.IDZusatzEintrag = rZusatzGruppeEintragAct.IDZusatzEintrag;
                                        //rNewZusatzGruppeEintragForPECopied.IDObjekt = rZusatzGruppeEintragAct.IDObjekt;
                                        //rNewZusatzGruppeEintragForPECopied.IDFilter = rPESameIDGruppe.IDEintrag;
                                        //rNewZusatzGruppeEintragForPECopied.OptionalJN = rZusatzGruppeEintragAct.OptionalJN;
                                        //rNewZusatzGruppeEintragForPECopied.DruckenJN = rZusatzGruppeEintragAct.DruckenJN;
                                        //rNewZusatzGruppeEintragForPECopied.Reihenfolge = rZusatzGruppeEintragAct.Reihenfolge;

                                        PMDS.db.Entities.ZusatzWert rNewZusatzwertForPECopied = EFEntities.newZusatzWert(db);
                                        rNewZusatzwertForPECopied.ID = System.Guid.NewGuid();
                                        rNewZusatzwertForPECopied.IDZusatzGruppeEintrag = rZWPEOrig.IDZGE;
                                        rNewZusatzwertForPECopied.IDObjekt = rPESameIDGruppe.ID;
                                        rNewZusatzwertForPECopied.Wert = rZusatzWertAct.Wert;
                                        rNewZusatzwertForPECopied.ZahlenWert = rZusatzWertAct.ZahlenWert;
                                        rNewZusatzwertForPECopied.RawFormat = rZusatzWertAct.RawFormat;
                                        rNewZusatzwertForPECopied.ZahlenWertFloat = rZusatzWertAct.ZahlenWertFloat;

                                        db.ZusatzWert.Add(rNewZusatzwertForPECopied);
                                        //db.ZusatzGruppeEintrag.Add(rNewZusatzGruppeEintragForPECopied);
                                        //db.SaveChanges();
                                    }
                                    else
                                    {
                                        bool bZusatzwertFound2 = true;
                                    }
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    //IQueryable<PMDS.db.Entities.ZusatzGruppeEintrag> tZusatzGruppeEintrag = db.ZusatzGruppeEintrag.Where(b => b.IDFilter == rPEOrig.IDEintrag);
                    //foreach (db.Entities.ZusatzGruppeEintrag rZusatzGruppeEintrag in tZusatzGruppeEintrag)
                    //{
                    //    IQueryable<db.Entities.ZusatzEintrag> tZusatzEintrag = db.ZusatzEintrag.Where(b => b.ID == rZusatzGruppeEintrag.IDZusatzEintrag);
                    //    if (tZusatzEintrag.Count() == 1)
                    //    {
                    //        db.Entities.ZusatzEintrag rZusatzEintrag = tZusatzEintrag.First();

                    //        IQueryable<db.Entities.ZusatzWert> tZusatzWert = db.ZusatzWert.Where(b => b.IDZusatzGruppeEintrag == rZusatzGruppeEintrag.ID && b.IDObjekt == IDPE);
                    //        foreach (db.Entities.ZusatzWert rZusatzWert in tZusatzWert)
                    //        {


                    //        }
                    //    }
                    //}
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.copyUpdateZusatzwertePEIDGruppe()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.copyUpdateZusatzwertePEIDGruppe: " + ex.ToString());
            }
        }
        public int checkIDGruppenExistsForIDPER(Guid IDPEOrig, PMDS.db.Entities.ERModellPMDSEntities db, ref string sInfoKopien)
        {
            try
            {
                var rPEOrig = (from pe in db.PflegeEintrag
                               where pe.ID == IDPEOrig
                               select new { pe.ID, pe.IDEintrag, pe.IDGruppe, pe.IDAufenthalt }).First();

                if (rPEOrig.IDGruppe != null)
                {
                    var tPESameIDGruppe = (from pe in db.PflegeEintrag
                                           where pe.ID != rPEOrig.ID && pe.IDGruppe == rPEOrig.IDGruppe && pe.IDAufenthalt == rPEOrig.IDAufenthalt
                                           select new { pe.ID, pe.IDEintrag, pe.IDGruppe, pe.IDBerufsstand, pe.IDWichtig });

                    var tBerufsstandAll = (from a in db.AuswahlListe
                                           where a.IDAuswahlListeGruppe == "BER"
                                           select new { a.ID, a.Bezeichnung });

                    System.Collections.Generic.List<String> lstInfoKopien = new List<string>();
                    int iAnzahlKopien = tPESameIDGruppe.Count();
                    foreach (var rSameGroupPE in tPESameIDGruppe)
                    {
                        if (rSameGroupPE.IDWichtig != null && rSameGroupPE.IDWichtig != System.Guid.Empty)
                        {
                            var rBerufsgruppe = (from pe in tBerufsstandAll
                                                 where pe.ID == rSameGroupPE.IDWichtig
                                                 select new { pe.ID, pe.Bezeichnung }).First(); ;

                            if (!lstInfoKopien.Contains(rBerufsgruppe.Bezeichnung.Trim()))
                            {
                                lstInfoKopien.Add(rBerufsgruppe.Bezeichnung.Trim());
                            }
                        }
                    }

                    foreach (var Berufsstand in lstInfoKopien)
                    {
                        sInfoKopien += "      " + Berufsstand + "\r\n";
                    }
                    if (sInfoKopien.Trim() != "")
                    {
                        sInfoKopien = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste Berufsgruppen aller Kopien:") + "\r\n" + sInfoKopien;
                    }

                    return tPESameIDGruppe.Count();
                }
                else
                    return 0;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.copyUpdateZusatzwertePEIDGruppe()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkIDGruppenExistsForIDPER: " + ex.ToString());
            }
        }

        public bool validateKostenträgerForSave(ref string msgTransReturn, Infragistics.Win.UltraWinGrid.UltraGrid grid, ref PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger ds, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstKostDeleted = new List<Guid>();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rKostGridRow in grid.Rows)
                {
                    DataRowView v = (DataRowView)rKostGridRow.ListObject;
                    PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow rKost = (PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow)v.Row;

                    if (rKost.RowState == DataRowState.Deleted)
                    {
                        lstKostDeleted.Add((Guid)rKost["ID", DataRowVersion.Original]);
                    }
                }

                bool bCheckOK = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rKostGridRow in grid.Rows)
                {
                    DataRowView v = (DataRowView)rKostGridRow.ListObject;
                    PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow rKost2 = (PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow)v.Row;
                    
                    if (rKost2.RowState != DataRowState.Deleted)
                    {
                        if (rKost2.RowState == DataRowState.Added || rKost2.RowState == DataRowState.Modified)
                        {
                            if (rKost2.FIBUKonto.Trim() == "")
                            {
                                msgTransReturn += QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine FIBU-Angabe für Kostenträger {0} vorhanden");
                                msgTransReturn = string.Format(msgTransReturn, rKost2.Name.Trim()) + "\r\n";
                                bCheckOK = false;
                            }
                            else
                            {
                                var tKostDB = (from k in db.Kostentraeger
                                               where k.FIBUKonto == rKost2.FIBUKonto.Trim() && !lstKostDeleted.Contains(k.ID)
                                               select new
                                               {
                                                   IDKost = k.ID,
                                                   NameKost = k.Name
                                               });

                                if (tKostDB.Count() > 0)
                                {
                                    msgTransReturn += QS2.Desktop.ControlManagment.ControlManagment.getRes("FIBU {0} für Kostenträger {1} kommt in Datenbank mehrfach vor");
                                    msgTransReturn = string.Format(msgTransReturn, rKost2.FIBUKonto.Trim(), rKost2.Name.Trim()) + "\r\n";

                                    foreach (var rKostInDB in tKostDB)
                                    {
                                        string msgBoxTransDetailKost = "                    " + QS2.Desktop.ControlManagment.ControlManagment.getRes("FIBU kommt auch vor in Kostenträger {0}");
                                        msgBoxTransDetailKost = string.Format(msgBoxTransDetailKost, rKostInDB.NameKost.Trim()) + "\r\n";
                                        msgTransReturn += msgBoxTransDetailKost + "\r\n";
                                    }
                                    bCheckOK = false;
                                }
                            }
                        }
                    }
                }

                return bCheckOK;

                //IQueryable<PMDS.db.Entities.PflegePlan> tPflegeplan = db.PflegePlan.Where(pp => pp.ID == IDpflegeplan);
                //PMDS.db.Entities.PflegePlan rPflegeplan = tPflegeplan.First();
                //db.PflegePlan.Remove(rPflegeplan);
                //db.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.validateKostenträgerForSave: " + ex.ToString());
            }
        }

        public bool doVidierung(ref PMDS.Data.Global.dsWunde.WundeTherapieRow rWundeTherapie, Guid IDWundeTherapie, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                //WundeTherapie rWundeTherapie = db.WundeTherapie.Where(o => o.ID == IDWundeTherapie).First();
                if (rWundeTherapie.VidiertJN)
                {
                    return false;
                }
                else
                {
                    rWundeTherapie.VidiertJN = true;
                    rWundeTherapie.VidiertVon = ENV.LoginInNameFrei;
                    rWundeTherapie.VidiertAm = DateTime.Now;

                    return true;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.doVidierung: " + ex.ToString());
            }
        }


        public PMDS.db.Entities.tblOrdner getIDOrdnerForArchive(string OrdnerToSearch, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.tblOrdner> tOrdner = db.tblOrdner.Where(a => a.Bezeichnung == OrdnerToSearch.Trim());
                if (tOrdner.Count() == 1)
                {
                    return tOrdner.First();
                }
                else
                {
                    return null;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getIDOrdnerForArchive: " + ex.ToString());
            }
        }


        public PMDS.db.Entities.WundeKopf checkWundeKopfIDAufenthaltPdxExists(Guid IDAufenthaltPDx, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.WundeKopf> tWundeKopf = db.WundeKopf.Where(a => a.IDAufenthaltPDx == IDAufenthaltPDx);
                if (tWundeKopf.Count() == 1)
                {
                    return tWundeKopf.First();
                }
                else
                {
                    return null;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.checkWundeKopfIDAufenthaltPdxExists: " + ex.ToString());
            }
        }

        public void deleteNotUsedMedikamente(ref int iCounterDeletedBack, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string sqlCmd = " Select Bezeichnung as Medikament, ID as IDMedikament from Medikament where Importiert=1 and Aktuell=0 and " + 
                                " (Not ID in (Select IDMedikament from RezeptEintrag)) and " + 
                                " (Not ID in (Select IDMedikament from VO)) and " + 
                                " (Not ID in (Select IDMedikament from VO_Bestelldaten)) and " + 
                                " (Not ID in (Select IDMedikament from VO_Bestellpostitionen))  " + 
                                " order by Bezeichnung asc ";

                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = sqlCmd;
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int iCounterDeletedTmp = 0;
                    foreach(DataRow rMedikament in dt.Rows)
                    {
                        OleDbCommand cmdDelete = new OleDbCommand();
                        cmdDelete.CommandText = " Delete from Medikament where ID='" + rMedikament["IDMedikament"].ToString() + "' ";
                        cmdDelete.CommandTimeout = 0;
                        if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                            RBU.DataBase.CONNECTION.Open();
                        cmdDelete.Connection = RBU.DataBase.CONNECTION;
                        cmdDelete.ExecuteNonQuery();

                        iCounterDeletedTmp += 1;
                    }

                    iCounterDeletedBack = iCounterDeletedTmp;
                }

                //DbParameter[] pars11 = new DbParameter[]
                //{
                //};

                //IEnumerable<cMedikament> tMedikamenteNotUsed = db.Database.SqlQuery<cMedikament>(sqlCmd, pars11);

                //iCounterDeleted = tMedikamenteNotUsed.Count();
                //foreach (var rMedikamentNotUsed in tMedikamenteNotUsed)
                //{
                //    string sMedikament = rMedikamentNotUsed.Medikament.Trim();
                //}

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.deleteNotUsedMedikamente()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.deleteNotUsedMedikamente: " + ex.ToString());
            }
        }

        public bool sys_deletePatient(Guid IDPatient, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeletePatient", RBU.DataBase.CONNECTIONSqlClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPatient", IDPatient.ToString());
                int iReturn = cmd.ExecuteNonQuery();

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessUI.sys_deletePatient()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.sys_deletePatient: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PMDS.db.Entities.BenutzerAbteilung> getBenutzerAbteilung(Guid IDUser, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = db.BenutzerAbteilung.Where(a => a.IDBenutzer == IDUser);
                return tBenutzerAbteilung;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBenutzerAbteilung: " + ex.ToString());
            }
        }
        public System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> getBereichBenutzer(Guid IDUser, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = db.BereichBenutzer.Where(a => a.IDBenutzer == IDUser);
                return tBereichBenutzer;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBereichBenutzer: " + ex.ToString());
            }
        }

        public System.Linq.IQueryable<PMDS.db.Entities.Abteilung> getAllAbteilungen(System.Guid IDKlinik, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Abteilung> tAbteilung = db.Abteilung.Where(o => o.IDKlinik == IDKlinik).OrderBy(o => o.Bezeichnung);
                return tAbteilung;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllAbteilungen: " + ex.ToString());
            }
        }

        public int CopyDekurse(Guid IDAufenthaltQuelle, Guid IDAufenthaltZiel)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                int iDekurse = 0;
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                PMDS.db.Entities.Aufenthalt rQuellAufenthalt = PMDSBusiness1.getAufenthalt(IDAufenthaltQuelle);
                PMDS.db.Entities.Aufenthalt rZielAufenthalt = PMDSBusiness1.getAufenthalt(IDAufenthaltZiel);

                System.Collections.Generic.List<PMDS.db.Entities.PflegeEintrag> lstPflegeEintrage = getPflegeEintraegeByAufenthalt(IDAufenthaltQuelle, PflegeEintragTyp.DEKURS, db);

                foreach (PMDS.db.Entities.PflegeEintrag rPflegeEintrag in lstPflegeEintrage)
                {
                    //In Zielaufenthalt kopieren
                    PMDS.db.Entities.PflegeEintrag rPflegeEintragCopy = InsertPflegeEintrag(db, dNow);
                    rPflegeEintragCopy.AbgezeichnetAm = rPflegeEintrag.AbgezeichnetAm;
                    rPflegeEintragCopy.AbgezeichnetIDBenutzer = rPflegeEintrag.AbgezeichnetIDBenutzer;
                    rPflegeEintragCopy.AbgezeichnetJN = rPflegeEintrag.AbgezeichnetJN;
                    rPflegeEintragCopy.AbzeichnenJN = rPflegeEintrag.AbzeichnenJN;
                    rPflegeEintragCopy.CC = rPflegeEintrag.CC;
                    rPflegeEintragCopy.DatumErstellt = rPflegeEintrag.DatumErstellt;
                    rPflegeEintragCopy.Dekursherkunft = rPflegeEintrag.Dekursherkunft;
                    rPflegeEintragCopy.DurchgefuehrtJN = rPflegeEintrag.DurchgefuehrtJN;
                    rPflegeEintragCopy.EintragsTyp = rPflegeEintrag.EintragsTyp;
                    rPflegeEintragCopy.HAGPflichtigJN = rPflegeEintrag.HAGPflichtigJN;
                    rPflegeEintragCopy.IDAbteilung = rZielAufenthalt.IDAbteilung;
                    rPflegeEintragCopy.IDAufenthalt = rZielAufenthalt.ID;
                    rPflegeEintragCopy.IDBefund = rPflegeEintrag.IDBefund;
                    rPflegeEintragCopy.IDBenutzer = rPflegeEintrag.IDBenutzer;
                    rPflegeEintragCopy.IDBereich = rZielAufenthalt.IDBereich;
                    rPflegeEintragCopy.IDBerufsstand = rPflegeEintrag.IDBerufsstand;
                    rPflegeEintragCopy.IDDekurs = rPflegeEintrag.IDDekurs;
                    rPflegeEintragCopy.IDEintrag = rPflegeEintrag.IDEintrag;
                    rPflegeEintragCopy.IDEvaluierung = rPflegeEintrag.IDEvaluierung;
                    rPflegeEintragCopy.IDExtern = rPflegeEintrag.IDExtern;
                    rPflegeEintragCopy.IDPflegePlan = rPflegeEintrag.IDPflegePlan;
                    rPflegeEintragCopy.IDPflegePlanBerufsstand = rPflegeEintrag.IDPflegePlanBerufsstand;
                    rPflegeEintragCopy.IDPflegeplanH = null;
                    rPflegeEintragCopy.IDSollberufsstand = rPflegeEintrag.IDSollberufsstand;
                    rPflegeEintragCopy.IDWichtig = rPflegeEintrag.IDWichtig;
                    rPflegeEintragCopy.IstDauer = rPflegeEintrag.IstDauer;
                    rPflegeEintragCopy.PflegePlanDauer = rPflegeEintrag.PflegePlanDauer;
                    rPflegeEintragCopy.PflegeplanText = rPflegeEintrag.PflegeplanText;
                    rPflegeEintragCopy.Startdatum_Neu = rPflegeEintrag.Startdatum_Neu;
                    rPflegeEintragCopy.Text = rPflegeEintrag.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\n(Kopie von Aufenthalt mit Aufnahmedatum ") + rQuellAufenthalt.Aufnahmezeitpunkt.ToString() + ")";
                    rPflegeEintragCopy.Wichtig = rPflegeEintrag.Wichtig;
                    rPflegeEintragCopy.Zeitpunkt = rPflegeEintrag.Zeitpunkt;
                    rPflegeEintragCopy.LogInNameFrei = rPflegeEintrag.LogInNameFrei;

                    //Eintrag in Pflegeeintrag schreiben
                    PMDS.db.Entities.PflegeEintrag rPflegeEintragMeldung = InsertPflegeEintrag(db, dNow);
                    rPflegeEintragMeldung.DatumErstellt = dNow;
                    rPflegeEintragMeldung.Dekursherkunft = (int)eDekursherkunft.DekursAusÜbergabe;
                    rPflegeEintragMeldung.DurchgefuehrtJN = true;
                    rPflegeEintragMeldung.EintragsTyp = (int)PflegeEintragTyp.DEKURS;
                    rPflegeEintragMeldung.IDAbteilung = rZielAufenthalt.IDAbteilung;
                    rPflegeEintragMeldung.IDAufenthalt = rZielAufenthalt.ID;
                    rPflegeEintragMeldung.IDBenutzer = ENV.USERID;
                    rPflegeEintragMeldung.IDBereich = rZielAufenthalt.IDBereich;
                    rPflegeEintragMeldung.IDBerufsstand = ENV.BERUFID;
                    rPflegeEintragMeldung.IstDauer = 0;
                    rPflegeEintragMeldung.PflegeplanText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurskopie");
                    rPflegeEintragMeldung.Text = rPflegeEintrag.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\n(Kopie von Aufenthalt mit Aufnahmedatum ") + rQuellAufenthalt.Aufnahmezeitpunkt.ToString() + ")";
                    rPflegeEintragMeldung.Zeitpunkt = dNow;
                    rPflegeEintragMeldung.LogInNameFrei = ENV.LoginInNameFrei;

                    iDekurse++;
                    db.SaveChanges();
                }

                return iDekurse;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string excepDetail = this.getDbEntityValidationException(ex);
                throw new System.Data.Entity.Validation.DbEntityValidationException(excepDetail, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CopyDekurse: " + ex.ToString());
            }
        }



        // 2019
        public static string getResQS2(string IDRes)
        {
            try
            {
                System.Data.EnumerableRowCollection<qs2.core.language.dsLanguage.RessourcenRow> arrRes = (from res in qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen where res.IDRes == IDRes.Trim() && res.Type == "Label" && 
                                                                                                          res.IDApplication == "ALL" && res.IDParticipant == "ALL" select res);
                if (arrRes.Count() > 0)
                {
                    return arrRes.First().German.Trim();
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getResQS2: " + ex.ToString());
            }
        }























        //Connect and Exception-handling
        public static PMDS.db.Entities.ERModellPMDSEntities getDBContext2()
        {
            PMDS.db.Entities.ERModellPMDSEntities DBContext = new PMDS.db.Entities.ERModellPMDSEntities();
            DBContext = PMDSBusiness.getDBContext();
            return DBContext;
        }

        public static PMDS.db.Entities.ERModellPMDSEntities getDBContext()
        {
            string sInfoExcept = "";
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities DBContext = new PMDS.db.Entities.ERModellPMDSEntities();
                //PMDSBusiness.getConnection(ref DBContext);
                PMDSBusiness.setERConnection(ref DBContext);

                return DBContext;
            }
            catch (Exception ex)
            {
                if (PMDSBusiness._iFctCalled <= 5)
                {
                    try
                    {
                        PMDSBusiness._iFctCalled += 1;
                        if (PMDSBusiness._iFctCalled >= 5)
                        {
                            Exception exTmp2 = new Exception("PMDSBusiness.getDBContext: " + PMDSBusiness._iFctCalled.ToString() + "th retry" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        }
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        PMDS.db.Entities.ERModellPMDSEntities dbContext = PMDSBusiness.getDBContext();
                        PMDSBusiness._iFctCalled = 0;
                        return dbContext;
                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("PMDSBusiness.getDBContext: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                    }
                }
                else
                {
                    throw new Exception("PMDSBusiness.getDBContext: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        public static void setERConnection(ref PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                if (ENV.VisualStudioMode)
                    return;

                string providerName = "System.Data.SqlClient";
                string serverName = PMDS.Global.ENV.DB_SERVER;
                string databaseName = PMDS.Global.ENV.DB_DATABASE;
                string User = PMDS.Global.ENV.DB_USER;
                string Pwd = PMDS.Global.ENV.DB_PASSWORD;

                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.ApplicationName = "EntityFramework";
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.IntegratedSecurity = true;
                sqlBuilder.MaxPoolSize = 5000;

                //Für SQL-User
                if (User != null)
                {
                    sqlBuilder.UserID = User;
                    sqlBuilder.Password = Pwd == null ? "" : Pwd;
                    sqlBuilder.IntegratedSecurity = false;
                    sqlBuilder.PersistSecurityInfo = true;
                }
                string providerString = sqlBuilder.ToString();

                //EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                //entityBuilder.Provider = providerName;
                //entityBuilder.ProviderConnectionString = providerString;
                //entityBuilder.Name = "ERModellPMDSEntities";
                //entityBuilder.Metadata = @"res://*/ERModellPMDS.csdl|res://*/ERModellPMDS.ssdl|res://*/ERModellPMDS.msl";

                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //var connection = config.ConnectionStrings.ConnectionStrings[entityBuilder.Name];

                //if (connection == null)
                //{
                //    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                //    {
                //        Name = entityBuilder.Name,
                //        ConnectionString = entityBuilder.ConnectionString.Replace("name=ERModellPMDSEntities;", ""),
                //        ProviderName = "System.Data.EntityClient"
                //    });
                //    config.Save(ConfigurationSaveMode.Modified);
                //    ConfigurationManager.RefreshSection("connectionStrings");

                //    System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Konfigurationsdatei aktualisiert. Bitte starten Sie PMDS noch einmal.");
                //}

                DBContext.Database.Connection.ConnectionString = providerString;
                try
                {
                    DBContext.Database.Connection.Open();
                }
                catch
                {
                    //ev. nocheinmal probieren
                    if (DBContext.Database.Connection.State == ConnectionState.Closed)
                    {
                        qs2.core.generic.WaitMilli(500);
                        DBContext.Database.Connection.Open();
                    }
                }
                return;

            }
            catch (Exception ex)
            {

                throw new Exception("PMDSBusiness.setConnection: " + ex.ToString());
            }
        }
        public static void setERConnectionQS2(ref QS2.db.Entities.ERModellQS2Entities DBContext)
        {
            try
            {
                string providerName = "System.Data.SqlClient";
                string serverName = qs2.core.dbBase.Server.Trim();
                string databaseName = qs2.core.dbBase.Database.Trim();
                string User = qs2.core.dbBase.User.Trim();
                string Pwd = qs2.core.dbBase.PwdDecrypted.Trim();

                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.ApplicationName = "EntityFramework";
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.IntegratedSecurity = true;
                sqlBuilder.MaxPoolSize = 5000;


                //Für SQL-User
                if (User != null)
                {
                    if (User.Trim() != "")
                    {
                        sqlBuilder.UserID = User;
                        sqlBuilder.Password = Pwd == null ? "" : Pwd;
                        sqlBuilder.IntegratedSecurity = false;
                    }

                }

                DBContext.Database.Connection.ConnectionString = sqlBuilder.ConnectionString;
                DBContext.Database.Connection.Open();

                return;

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.setERConnectionQS2: " + ex.ToString());
            }
        }


        public bool CheckDb(PMDS.db.Entities.ERModellPMDSEntities DBContext, ref string prot, ref int iErrorsFound)
        {
            try
            {

                var t = DBContext.Kostentraeger.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t, ref prot, ref iErrorsFound);
                var t2 = DBContext.Abteilung.Where(k2 => k2.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t2, ref prot, ref iErrorsFound);
                var t3 = DBContext.Adresse.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t3, ref prot, ref iErrorsFound);
                var t4 = DBContext.Aerzte.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t4, ref prot, ref iErrorsFound);
                var t5 = DBContext.Anamnese_Krohwinkel.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t5, ref prot, ref iErrorsFound);
                var t6 = DBContext.Anamnese_Orem.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t6, ref prot, ref iErrorsFound);
                var t7 = DBContext.Anamnese_POP.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t7, ref prot, ref iErrorsFound);
                var t8 = DBContext.Aufenthalt.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t8, ref prot, ref iErrorsFound);
                var t9 = DBContext.AufenthaltPDx.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t9, ref prot, ref iErrorsFound);
                var t10 = DBContext.AufenthaltVerlauf.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t10, ref prot, ref iErrorsFound);
                var t11 = DBContext.AufenthaltZusatz.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t11, ref prot, ref iErrorsFound);
                var t12 = DBContext.AuswahlListe.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t12, ref prot, ref iErrorsFound);
                var t13 = DBContext.AuswahlListeGruppe.Where(k => k.ID.Equals("xy")); this.CheckTable(t13, ref prot, ref iErrorsFound);
                var t14 = DBContext.Bank.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t14, ref prot, ref iErrorsFound);
                var t15 = DBContext.BarcodeQ.Where(k => k.ID.Equals(124)); this.CheckTable(t15, ref prot, ref iErrorsFound);
                var t16 = DBContext.Belegung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t16, ref prot, ref iErrorsFound);
                var t17 = DBContext.Benutzer.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t17, ref prot, ref iErrorsFound);
                var t18 = DBContext.BenutzerAbteilung.Where(k => k.IDAbteilung.Equals(System.Guid.NewGuid())); this.CheckTable(t18, ref prot, ref iErrorsFound);
                var t19 = DBContext.BenutzerBezug.Where(k => k.IDBenutzer.Equals(System.Guid.NewGuid())); this.CheckTable(t19, ref prot, ref iErrorsFound);
                var t20 = DBContext.BenutzerEinrichtung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t20, ref prot, ref iErrorsFound);
                var t21 = DBContext.BenutzerGruppe.Where(k => k.IDBenutzer.Equals(System.Guid.NewGuid())); this.CheckTable(t21, ref prot, ref iErrorsFound);
                var t22 = DBContext.Bereich.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t22, ref prot, ref iErrorsFound);
                var t23 = DBContext.billHeader.Where(k => k.ID.Equals("xy")); this.CheckTable(t23, ref prot, ref iErrorsFound);
                var t24 = DBContext.bills.Where(k => k.ID.Equals("xy")); this.CheckTable(t24, ref prot, ref iErrorsFound);
                var t25 = DBContext.bookings.Where(k => k.ID.Equals("xy")); this.CheckTable(t25, ref prot, ref iErrorsFound);
                var t26 = DBContext.DBLizenz.Where(k => k.ID.Equals(1243)); this.CheckTable(t26, ref prot, ref iErrorsFound);
                var t27 = DBContext.DBVersion.Where(k => k.ID.Equals(123)); this.CheckTable(t27, ref prot, ref iErrorsFound);
                var t28 = DBContext.Dienstzeiten.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t28, ref prot, ref iErrorsFound);
                var t29 = DBContext.Dokumente.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t29, ref prot, ref iErrorsFound);
                var t30 = DBContext.Einrichtung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t30, ref prot, ref iErrorsFound);
                var t31 = DBContext.Eintrag.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t31, ref prot, ref iErrorsFound);
                var t33 = DBContext.EintragStandardprozeduren.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t33, ref prot, ref iErrorsFound);
                var t34 = DBContext.EintragZusatz.Where(k => k.IDEintrag.Equals(System.Guid.NewGuid())); this.CheckTable(t34, ref prot, ref iErrorsFound);
                var t35 = DBContext.Essen.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t35, ref prot, ref iErrorsFound);
                var t37 = DBContext.Formular.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t37, ref prot, ref iErrorsFound);
                var t38 = DBContext.FormularDaten.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t38, ref prot, ref iErrorsFound);
                var t39 = DBContext.Gegenstaende.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t39, ref prot, ref iErrorsFound);
                var t40 = DBContext.Gruppe.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t40, ref prot, ref iErrorsFound);
                var t41 = DBContext.GruppenRecht.Where(k => k.IDGruppe.Equals(System.Guid.NewGuid())); this.CheckTable(t41, ref prot, ref iErrorsFound);
                var t42 = DBContext.Info.Where(k => k.ID.Equals("xy")); this.CheckTable(t42, ref prot, ref iErrorsFound);
                var t43 = DBContext.Klinik.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t43, ref prot, ref iErrorsFound);
                var t44 = DBContext.Kontakt.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t44, ref prot, ref iErrorsFound);
                var t45 = DBContext.Kontaktperson.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t45, ref prot, ref iErrorsFound);
                var t46 = DBContext.Kostentraeger.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t46, ref prot, ref iErrorsFound);
                var t47 = DBContext.Leistungskatalog.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t47, ref prot, ref iErrorsFound);
                var t48 = DBContext.LeistungskatalogGueltig.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t48, ref prot, ref iErrorsFound);
                var t49 = DBContext.LinkDokumente.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t49, ref prot, ref iErrorsFound);
                var t50 = DBContext.manBuch.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t50, ref prot, ref iErrorsFound);
                var t51 = DBContext.Massnahmenserien.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t51, ref prot, ref iErrorsFound);
                var t52 = DBContext.Medikament.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t52, ref prot, ref iErrorsFound);
                var t53 = DBContext.MedikationAbgabe.Where(k => k.IDRezeptEintrag.Equals(System.Guid.NewGuid())); this.CheckTable(t53, ref prot, ref iErrorsFound);
                var t54 = DBContext.MedizinischeDaten.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t54, ref prot, ref iErrorsFound);
                var t55 = DBContext.MedizinischeDatenLayout.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t55, ref prot, ref iErrorsFound);
                var t56 = DBContext.MedizinischeTypen.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t56, ref prot, ref iErrorsFound);
                var t61 = DBContext.Patient.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t61, ref prot, ref iErrorsFound);
                var t62 = DBContext.PatientAbwesenheit.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t62, ref prot, ref iErrorsFound);
                var t63 = DBContext.PatientAerzte.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t63, ref prot, ref iErrorsFound);
                var t64 = DBContext.PatientEinkommen.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t64, ref prot, ref iErrorsFound);
                var t65 = DBContext.PatientenBemerkung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t65, ref prot, ref iErrorsFound);
                var t66 = DBContext.PatientKostentraeger.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t66, ref prot, ref iErrorsFound);
                var t67 = DBContext.PatientLeistungsplan.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t67, ref prot, ref iErrorsFound);
                var t68 = DBContext.PatientPflegestufe.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t68, ref prot, ref iErrorsFound);
                var t69 = DBContext.PatientSonderleistung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t69, ref prot, ref iErrorsFound);
                var t70 = DBContext.PatientTaschengeldKostentraeger.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t70, ref prot, ref iErrorsFound);
                var t71 = DBContext.PDX.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t71, ref prot, ref iErrorsFound);
                var t72 = DBContext.PDXAnamnese.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t72, ref prot, ref iErrorsFound);
                var t73 = DBContext.PDXEintrag.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t73, ref prot, ref iErrorsFound);
                var t74 = DBContext.PDXGruppe.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t74, ref prot, ref iErrorsFound);
                var t75 = DBContext.PDXGruppeEintrag.Where(k => k.IDPDX.Equals(System.Guid.NewGuid())); this.CheckTable(t75, ref prot, ref iErrorsFound);
                var t76 = DBContext.PDXPflegemodelle.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t76, ref prot, ref iErrorsFound);
                var t77 = DBContext.PflegeEintrag.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t77, ref prot, ref iErrorsFound);
                var t78 = DBContext.Pflegegeldstufe.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t78, ref prot, ref iErrorsFound);
                var t79 = DBContext.PflegegeldstufeGueltig.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t79, ref prot, ref iErrorsFound);
                var t80 = DBContext.Pflegemodelle.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t80, ref prot, ref iErrorsFound);
                var t81 = DBContext.PflegePlan.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t81, ref prot, ref iErrorsFound);
                var t82 = DBContext.PflegePlanH.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t82, ref prot, ref iErrorsFound);
                var t83 = DBContext.PflegePlanPDx.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t83, ref prot, ref iErrorsFound);
                var t84 = DBContext.QuickFilter.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t84, ref prot, ref iErrorsFound);
                var t85 = DBContext.QuickMeldung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t85, ref prot, ref iErrorsFound);
                var t86 = DBContext.rechNr.Where(k => k.year.Equals(1900)); this.CheckTable(t86, ref prot, ref iErrorsFound);
                var t87 = DBContext.Recht.Where(k => k.ID.Equals(12)); this.CheckTable(t87, ref prot, ref iErrorsFound);
                var t88 = DBContext.Rehabilitation.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t88, ref prot, ref iErrorsFound);
                var t90 = DBContext.RezeptBestellungPos.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t90, ref prot, ref iErrorsFound);
                var t91 = DBContext.RezeptEintrag.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t91, ref prot, ref iErrorsFound);

                var t92 = DBContext.Sachwalter.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t92, ref prot, ref iErrorsFound);
                var t93 = DBContext.SonderleistungsKatalog.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t93, ref prot, ref iErrorsFound);
                var t94 = DBContext.SP.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t94, ref prot, ref iErrorsFound);
                var t95 = DBContext.SPDynRep.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t95, ref prot, ref iErrorsFound);
                var t96 = DBContext.SPPE.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t96, ref prot, ref iErrorsFound);
                var t97 = DBContext.SPPOS.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t97, ref prot, ref iErrorsFound);
                var t98 = DBContext.StandardProzeduren.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t98, ref prot, ref iErrorsFound);
                var t99 = DBContext.Standardzeiten.Where(k => k.ID.Equals(121)); this.CheckTable(t99, ref prot, ref iErrorsFound);
                var t100 = DBContext.Taschengeld.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t100, ref prot, ref iErrorsFound);
                var t101 = DBContext.tbl_Nachricht.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t101, ref prot, ref iErrorsFound);
                var t105 = DBContext.tblDokumente.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t105, ref prot, ref iErrorsFound);
                var t106 = DBContext.tblDokumenteGelesen.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t106, ref prot, ref iErrorsFound);
                var t107 = DBContext.tblDokumenteintrag.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t107, ref prot, ref iErrorsFound);
                var t108 = DBContext.tblDokumenteneintragSchlagwörter.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t108, ref prot, ref iErrorsFound);
                var t109 = DBContext.tblFach.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t109, ref prot, ref iErrorsFound);
                var t110 = DBContext.tblObjekt.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t110, ref prot, ref iErrorsFound);
                var t111 = DBContext.tblOrdner.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t111, ref prot, ref iErrorsFound);
                var t112 = DBContext.tblParameter.Where(k => k.bezeichnung.Equals("xy")); this.CheckTable(t112, ref prot, ref iErrorsFound);
                var t113 = DBContext.tblPfad.Where(k => k.Archivpfad.Equals("xy")); this.CheckTable(t113, ref prot, ref iErrorsFound);
                var t114 = DBContext.tblProvKonfig.Where(k => k.key.Equals("xy")); this.CheckTable(t114, ref prot, ref iErrorsFound);
                var t115 = DBContext.tblRechteOrdner.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t115, ref prot, ref iErrorsFound);
                var t116 = DBContext.tblSchlagwörter.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t116, ref prot, ref iErrorsFound);
                var t117 = DBContext.tblSchrank.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t117, ref prot, ref iErrorsFound);
                var t118 = DBContext.tblSturzprotokoll.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t118, ref prot, ref iErrorsFound);
                var t119 = DBContext.tblThemen.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t119, ref prot, ref iErrorsFound);
                var t120 = DBContext.tblUIDefinitions.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t120, ref prot, ref iErrorsFound);
                var t121 = DBContext.Unterbringung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t121, ref prot, ref iErrorsFound);

                var t122 = DBContext.UrlaubVerlauf.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t122, ref prot, ref iErrorsFound);
                var t124 = DBContext.WundeKopf.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t124, ref prot, ref iErrorsFound);
                var t125 = DBContext.WundePos.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t125, ref prot, ref iErrorsFound);
                var t126 = DBContext.WundePosBilder.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t126, ref prot, ref iErrorsFound);
                var t127 = DBContext.WundeTherapie.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t127, ref prot, ref iErrorsFound);
                var t128 = DBContext.Zeitbereich.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t128, ref prot, ref iErrorsFound);
                var t129 = DBContext.ZeitbereichSerien.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t129, ref prot, ref iErrorsFound);
                var t130 = DBContext.ZusatzEintrag.Where(k => k.ID.Equals("xy")); this.CheckTable(t130, ref prot, ref iErrorsFound);
                var t131 = DBContext.ZusatzGruppe.Where(k => k.ID.Equals("xy")); this.CheckTable(t131, ref prot, ref iErrorsFound);
                var t132 = DBContext.ZusatzGruppeEintrag.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t132, ref prot, ref iErrorsFound);
                var t133 = DBContext.ZusatzWert.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t133, ref prot, ref iErrorsFound);
                

                var t134 = DBContext.getAktDate.Where(k => k.aktDatum == DateTime .Now); this.CheckTable(t134, ref prot, ref iErrorsFound);
                //var t135 = DBContext.vEvaluierungSubreport.Where(k => k.WochentageText.Equals("xy")); this.CheckTable(t135, ref prot, ref iErrorsFound);
                //var t136 = DBContext.vGetPflegestufenAbrechnung.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t136);
                var t137 = DBContext.vInterventionen.Where(k => k.IDPflegeplan.Equals(System.Guid.NewGuid())); this.CheckTable(t137, ref prot, ref iErrorsFound);
                //var t138 = DBContext.vKlientenMitOffenenAufgabenBisJetzt.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t138);
                //var t140 = DBContext.vKostformliste.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t140);
                var t142 = DBContext.vPDxHistorie.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t142, ref prot, ref iErrorsFound);
                var t143 = DBContext.vPflegeberichtDynreportmitZusatz.Where(k => k.BenutzerNachname.Equals("xy")); this.CheckTable(t143, ref prot, ref iErrorsFound);
                var t144 = DBContext.vPflegeEintrag.Where(k => k.IDPflegeEintrag.Equals(System.Guid.NewGuid())); this.CheckTable(t144, ref prot, ref iErrorsFound);
                var t145 = DBContext.vPflegeplanPDX.Where(k => k.WochentageText.Equals("xy")); this.CheckTable(t145, ref prot, ref iErrorsFound);
                var t146 = DBContext.vPflegeStufeQuartal.Where(k => k.PatientpflegestufeID.Equals(System.Guid.NewGuid())); this.CheckTable(t146, ref prot, ref iErrorsFound);
                var t147 = DBContext.vPflegeStufeQuartal2.Where(k => k.PatientpflegestufeID.Equals(System.Guid.NewGuid())); this.CheckTable(t147, ref prot, ref iErrorsFound);
              
                var t149 = DBContext.vÜbergabe.Where(k => k.IDAufenthalt.Equals(System.Guid.NewGuid())); this.CheckTable(t149, ref prot, ref iErrorsFound);
                var t150 = DBContext.vWundaufstellungAktuell.Where(k => k.PatientID.Equals(System.Guid.NewGuid())); this.CheckTable(t150, ref prot, ref iErrorsFound);
                var t151 = DBContext.vZeitbericht.Where(k => k.BenutzerNachname.Equals("xy")); this.CheckTable(t151, ref prot, ref iErrorsFound);
                var t152 = DBContext.vRezeptBestellung2.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t152, ref prot, ref iErrorsFound);
                var t153 = DBContext.vKlientenliste.Where(k => k.IDAufenthalt.Equals(System.Guid.NewGuid())); this.CheckTable(t153, ref prot, ref iErrorsFound);
                var t154 = DBContext.Anmeldungen.Where(k => k.ID.Equals(System.Guid.NewGuid())); this.CheckTable(t154, ref prot, ref iErrorsFound);

                string xy = prot;
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CheckDb: " + ex.ToString());
            }
        }
        public void CheckTable( IQueryable  t, ref string prot, ref int iErrorsFound)
        {
            var o = t.ElementType;
            try
            {
               
                foreach (var r in t)
                {
                    string xy = "";
                }
            }
            catch (Exception ex)
            {
                iErrorsFound += 1;
                string txtTmp = "Error Select from Table '" + o.Name  + "' !" + "\r\n" + ex.ToString();
                //throw new Exception(txtTmp);
                prot += txtTmp + "\r\n" + "\r\n" + "\r\n";
            }
        }


        public string getDbEntityValidationException(System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var failure in ex.EntityValidationErrors)
            {
                sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                foreach (var error in failure.ValidationErrors)
                {
                    sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                    sb.AppendLine();
                }
            }
            return "Entity Validation Failed - errors follow:\n" + sb.ToString();
        }
        public static string getDbEntityValidationException2(System.Data.Entity.Validation.DbEntityValidationException ex, string NameFct)
        {
            PMDS.DB.PMDSBusiness b = new PMDSBusiness();
            string sExcept = b.getDbEntityValidationException(ex);
            sExcept = "Function: " + NameFct + "\r\n" + sExcept;
            return sExcept;
        }

        public static bool handleExceptionsServerNotReachable(ref Nullable<DateTime> IDTime, Exception ExeptOrig, string FctName)
        {
            string sExept2 = ExeptOrig.ToString();
            cClassExeptHandlerServerNotReachable ExeptHandlerServerNotReachable = null;
            try
            {
                if (ExeptOrig.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
                {
                    System.Data.Entity.Validation.DbEntityValidationException ExeptValid = (System.Data.Entity.Validation.DbEntityValidationException)ExeptOrig;
                    System.Data.Entity.Validation.DbEntityValidationException DbEntityValidationException = new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ExeptValid, FctName));
                    sExept2 = DbEntityValidationException.ToString();
                }

                if (IDTime == null)
                {
                    IDTime = DateTime.Now;
                }
                if (!PMDSBusiness.lstExeptHandlerServerNotReachable.ContainsKey(IDTime.Value))
                {
                    cClassExeptHandlerServerNotReachable newExeptHandlerServerNotReachable = new cClassExeptHandlerServerNotReachable();
                    newExeptHandlerServerNotReachable.IDTime = IDTime.Value;
                    newExeptHandlerServerNotReachable.iFctCalled += 1;
                    PMDSBusiness.lstExeptHandlerServerNotReachable.Add(IDTime.Value, newExeptHandlerServerNotReachable);
                }

                bool bFound = PMDSBusiness.lstExeptHandlerServerNotReachable.TryGetValue(IDTime.Value, out ExeptHandlerServerNotReachable);
                if (PMDS.Global.ENV.checkExceptionServerNotReachable(sExept2.Trim()) && ExeptHandlerServerNotReachable.iFctCalled <= 4)
                {
                    try
                    {
                        if (ExeptHandlerServerNotReachable.iFctCalled > 4)
                        {
                            if (PMDSBusiness.lstExeptHandlerServerNotReachable.ContainsKey(ExeptHandlerServerNotReachable.IDTime))
                            {
                                PMDSBusiness.lstExeptHandlerServerNotReachable.Remove(ExeptHandlerServerNotReachable.IDTime);
                            }
                            string exTmp2 = "PMDSBusiness.handleExceptionsServerNotReachable: Too muach repeats (=" + ExeptHandlerServerNotReachable.iFctCalled.ToString() + ") for Fct. " + FctName + "\r\n" + "\r\n" + sExept2.ToString();
                            throw new Exception(exTmp2.ToString());
                            //ENV.HandleException(exTmp2, "PMDSBusiness.handleExceptionsServerNotReachable", false);
                        }
                        else
                        {
                            qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                            ExeptHandlerServerNotReachable.iFctCalled += 1;
                            return true;
                        }
                    }
                    catch (Exception ex2)
                    {
                        if (PMDSBusiness.lstExeptHandlerServerNotReachable.ContainsKey(ExeptHandlerServerNotReachable.IDTime))
                        {
                            PMDSBusiness.lstExeptHandlerServerNotReachable.Remove(ExeptHandlerServerNotReachable.IDTime);
                        }
                        string exTmp2 = "PMDSBusiness.handleExceptionsServerNotReachable: Error repeat Fct. " + FctName + " (" + ExeptHandlerServerNotReachable.iFctCalled.ToString() + "'nd repeat)" + "\r\n" + "\r\n" + ex2.ToString();
                        throw new Exception(exTmp2.ToString());
                    }
                }
                else
                {
                    throw new Exception(FctName + ": " + "\r\n" + "\r\n" + sExept2.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.handleExceptionsServerNotReachable: (Error for Fct: " + FctName + ")" + "\r\n" + "\r\n" + ex.ToString());
            }
        }





















































        //Buisness-Layer Testfunctions
        public static QS2.db.Entities.ERModellQS2Entities getDBContextQS2Test()
        {
            try
            {
                QS2.db.Entities.ERModellQS2Entities DBContext = new QS2.db.Entities.ERModellQS2Entities();
                PMDSBusiness.setERConnectionQS2(ref DBContext);
                return DBContext;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getDBContext: " + ex.ToString());
            }
        }

        public static void getConnectionTest(ref PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                string Server = PMDS.Global.ENV.DB_SERVER;
                string Database = PMDS.Global.ENV.DB_DATABASE;
                string User = PMDS.Global.ENV.DB_USER;
                string Pwd = PMDS.Global.ENV.DB_PASSWORD;

                string ConnStr = "";
                if (User == null)
                {
                    ConnStr = "data source=" + Server + ";initial catalog=" + Database + ";integrated security=True;persist security info=True;MultipleActiveResultSets=True;App=EntityFramework";
                }
                else
                {
                    ConnStr = "data source=" + Server + ";initial catalog=" + Database + ";persist security info=True;user id=" + User + ";password=" + Pwd + ";MultipleActiveResultSets=True;App=EntityFramework";
                }
                DBContext.Database.Connection.ConnectionString = ConnStr;
                DBContext.Database.Connection.Open();

                return;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.setConnection: " + ex.ToString());
            }
            //            // Specify the provider name, server and database.
            //            string providerName = "System.Data.SqlClient";
            //            string serverName = "s2sty010";
            //            string databaseName = "PMDS_Dev";

            //            // Initialize the connection string builder for the
            //            // underlying provider.
            //            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            //            // Set the properties for the data source.
            //            sqlBuilder.DataSource = serverName;
            //            sqlBuilder.InitialCatalog = databaseName;
            //            sqlBuilder.IntegratedSecurity = true;

            //            // Build the SqlConnection connection string.
            //            string providerString = sqlBuilder.ToString();

            //            // Initialize the EntityConnectionStringBuilder.
            //            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            //            //Set the provider name.
            //            entityBuilder.Provider = providerName;

            //            // Set the provider-specific connection string.
            //            entityBuilder.ProviderConnectionString = providerString;

            //            // Set the Metadata location.
            //            entityBuilder.Metadata = @"res://*/EntitySystem.ERModelPMDS.csdl|
            //                                                res://*/EntitySystem.ERModelPMDS.ssdl|
            //                                                res://*/EntitySystem.ERModelPMDS.msl";
            //            Console.WriteLine(entityBuilder.ToString());

            //            using (EntityConnection conn = new EntityConnection(entityBuilder.ToString()))
            //            {
            //                conn.Open();
            //                Console.WriteLine("Just testing the connection.");
            //                //conn.Close();
            //            }
        }
        public bool CheckDbQS2Test(QS2.db.Entities.ERModellQS2Entities DBContextQS2, ref string prot, ref int iErrorsFound)
        {
            try
            {
                var t155 = DBContextQS2.tblSelListEntries.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t155, ref prot, ref iErrorsFound);
                var t156 = DBContextQS2.tblSelListGroup.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t156, ref prot, ref iErrorsFound);
                var t157 = DBContextQS2.tblSelListEntriesObj.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t157, ref prot, ref iErrorsFound);
                var t158 = DBContextQS2.tblObject.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t158, ref prot, ref iErrorsFound);
                var t159 = DBContextQS2.Protocol.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t159, ref prot, ref iErrorsFound);
                var t160 = DBContextQS2.Ressourcen.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t160, ref prot, ref iErrorsFound);
                var t161 = DBContextQS2.tblQueriesDef.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t161, ref prot, ref iErrorsFound);
                var t162 = DBContextQS2.Layout.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t162, ref prot, ref iErrorsFound);
                var t163 = DBContextQS2.LayoutGrids.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t163, ref prot, ref iErrorsFound);
                var t164 = DBContextQS2.tblAdjust.Where(k => k.setting.Equals(System.Guid.NewGuid().ToString())); this.CheckTable(t164, ref prot, ref iErrorsFound);
                var t165 = DBContextQS2.tblAdress.Where(k => k.IDGuid.Equals(System.Guid.NewGuid())); this.CheckTable(t165, ref prot, ref iErrorsFound);

                string xy = prot;
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.CheckDb: " + ex.ToString());
            }
        }
        public string RetAsciiCharTest(int AsciiCode)
        {
            return System.Convert.ToChar(AsciiCode).ToString();
        }

        public retBusiness CodeTmpl_EntTerminexy(Guid IDPatient, Guid IDAufenthalt, DateTime From, DateTime To, System.Guid IDKlinik, string sTextForPE)
        {
            try
            {
                retBusiness retBusiness1 = new retBusiness();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                DateTime dNow = DateTime.Now;
                DateTime actDate = From;
                while (actDate < To)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<vInterventionen> Qry = null;
                        System.Linq.IQueryable<vInterventionen> vInterventionen1 = null;
                        System.Linq.IQueryable<vÜbergabe> vÜbergabe1 = null;
                        Infragistics.Win.UltraWinGrid.UltraGrid grid = null;
                        PMDS.Global.eUITypeTermine UITypeTermine = eUITypeTermine.Interventionen;

                        DBTerminePara dbPar = new DBTerminePara();
                        dbPar.From = actDate;
                        dbPar.To = actDate;
                        dbPar.IDAufenthalt = IDAufenthalt;
                        dbPar.ansicht = TerminlisteAnsichtsmodi.Klientanansicht;

                        //PMDSBusiness1.getInterventionen(db, ref dbPar, ref IDKlinik, ref vInterventionen1, ref UITypeTermine);
                        //System.Linq.Enumerable.ToList(vInterventionen1);
                        foreach (vInterventionen rvInter in vInterventionen1)
                        {
                            PMDS.db.Entities.PflegeEintrag rNewPE = new PMDS.db.Entities.PflegeEintrag();
                            rNewPE.ID = System.Guid.NewGuid();
                            rNewPE.IDPflegePlan = rvInter.IDPflegeplan;
                            rNewPE.IDGruppe = null;
                            rNewPE.IDAufenthalt = rvInter.IDAufenthalt;
                            rNewPE.IDBereich = rvInter.IDBereich;
                            rNewPE.IDEintrag = rvInter.IDEintrag;
                            rNewPE.Zeitpunkt = dNow;
                            rNewPE.IDBenutzer = ENV.USERID;
                            rNewPE.DurchgefuehrtJN = false;
                            rNewPE.Text = sTextForPE;
                            rNewPE.TextRtf = "";
                            rNewPE.Dekursherkunft = -1;
                            rNewPE.AbgezeichnetJN = false;
                            rNewPE.AbgezeichnetIDBenutzer = null;
                            rNewPE.AbgezeichnetAm = null;
                            rNewPE.TextHistorie = "";
                            rNewPE.TextHistorieRtf = "";

                            db.PflegeEintrag.Add(rNewPE);
                            retBusiness1.countTermineFound += 1;

                            this.AddPflegeeintrag(db, sTextForPE, dNow, (Guid)rvInter.IDEintrag, (Guid)rvInter.IDBereich,
                                                rvInter.IDAufenthalt, rvInter.IDPflegeplan, PflegeEintragTyp.PLANUNG,
                                                null, rvInter.IDAbteilung, "Planungsänderung");



                            //PMDS.BusinessLogic.PflegePlan dbPflegePlan = new PMDS.BusinessLogic.PflegePlan(rvInter.IDAufenthalt);
                            //PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow rPflegeplan = dbPflegePlan.GetRowByID(rvInter.IDPflegeplan);

                            //PflegeEintrag peNew = PflegeEintrag.NewByPflegePlan(rvInter.IDAufenthalt, rvInter.IDPflegeplan, rPflegeplan.IDEintrag, dNow, false);
                            //lstToSave.Add(peNew);

                            //PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow rPflegeplan = dbPflegePlan.GetRowByID((System.Guid)rFound["IDPflegeplan"]);
                            ////PMDS.BusinessLogic.PflegeEintrag PflegeEintrag = new PMDS.BusinessLogic.PflegeEintrag((System.Guid)rFound["IDEintrag"]);

                            //agByRow(PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow r, DateTime time,
                            //                                     PMDS.BusinessLogic.PflegeEintrag PflegeEintrag
                            //PflegeEintrag pe = null;  

                            //if (PflegeEintrag != null)
                            //{
                            //    //Sonderbehandlung für Termin/Medikament
                            //    if (PflegeEintrag.EintragsTyp == PflegeEintragTyp.MEDIKAMENT)
                            //        pe = PflegeEintrag.NewMedikament(r.IDAufenthalt, r.ID, time);
                            //    else if (PflegeEintrag.EintragsTyp == PflegeEintragTyp.TERMIN || r.IsIDEintragNull())
                            //        pe = PflegeEintrag.NewByTermin(r.IDAufenthalt, r.ID, time, false);
                            //    else
                            //        pe = PflegeEintrag.NewByPflegePlan(r.IDAufenthalt, r.ID, r.IDEintrag, time, false);
                            //}
                            //else
                            //{
                            //    if (r.IsIDEintragNull())
                            //    {
                            //        pe = PflegeEintrag.NewByTermin(r.IDAufenthalt, r.ID, time, false);
                            //    }
                            //    else
                            //    {
                            //        pe = PflegeEintrag.NewByPflegePlan(r.IDAufenthalt, r.ID, r.IDEintrag, time, false);
                            //    }
                            //}
                        }
                        if (retBusiness1.countTermineFound > 0)
                        {
                            db.SaveChanges();
                        }
                    }
                    actDate = actDate.AddDays(1);
                }
                return retBusiness1;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(this.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.EndTermine: " + ex.ToString());
            }
        }
        public void CodeTemplatesxy(PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                //var res = dbCo.vInterventionen.Where(i => i.Maßnahme.Contains("a"));
                //foreach (var rInt in res)
                //{
                //    string xy = "";
                //}

                //string firstMaßnahme = dbCo.vInterventionen.First<vInterventionen>().Maßnahme;
                //firstMaßnahme = dbCo.vInterventionen.ElementAt(3).Maßnahme;

                ////With OR block, you must use FALSE
                //var wBlockOr1 = PredicateBuilder.False();
                //wBlockOr1 = wBlockOr1.Or(c => c.FirstName.Contains("A"));
                //wBlockOr1 = wBlockOr1.Or(c => c.LastName.Contains("B"));
                //var wBlockOr2 = PredicateBuilder.False();
                //wBlockOr1 = wBlockOr1.Or(
                //    c => c.Birthday == new DateTime(1998, 1, 1));
                //wBlockOr1 = wBlockOr1.Or(
                //    c => c.Birthday == new DateTime(1999, 12, 31));
                ////With AND block, you must use TRUE
                //var wAndBlock = PredicateBuilder.True();
                ////Combine between Or blocks
                //wAndBlock = wAndBlock.And(wBlockOr1.Expand());
                //wAndBlock = wAndBlock.And(wBlockOr2.Expand());
                //var customers = db.Customers.AsExpandable().Where(wAndBlock);


                //DbParameter[] args = new DbParameter[]
                //{
                //    //new SqlParameter {ParameterName="Maßnahme1", Value="xy", DbType= DbType.String, Size= 200, SourceColumn= "@Maßnahme1"},
                //    //new SqlParameter {ParameterName="Maßnahme2", Value="xyxy", DbType= DbType.String, Size= 200, SourceColumn= "@Maßnahme2"},
                //};
                //DbSqlQuery<vInterventionen> QryInterventionen = dbCo.vInterventionen.SqlQuery("Select * from vInterventionen", args);
                //int i = QryInterventionen.Count();
                //foreach (var rInt in QryInterventionen)
                //{
                //    string xyxyxyxy = "";
                //}
                //var predicate2 = PredicateBuilder2.True<vInterventionen>();
                //predicate2 = p => p.Maßnahme.Contains("a");

                //var resQry2 = QryInterventionen.Where(predicate2);
                //foreach (var rInt in resQry2)
                //{
                //    string xy = "";
                //}



                //DbParameter[] args = new DbParameter[]
                //{
                //    new SqlParameter {ParameterName="Maßnahme1", Value="xy", DbType= DbType.String, Size= 200, SourceColumn= "@Maßnahme1"},
                //    new SqlParameter {ParameterName="Maßnahme2", Value="xyxy", DbType= DbType.String, Size= 200, SourceColumn= "@Maßnahme2"},
                //};

                //Qry = dbCo.vInterventionen.SqlQuery(sSql + sWhere, args);
                //int i = Qry.Count();
                //foreach (vInterventionen rInt in Qry)
                //{

                //}

                //var vInterventionen12 = DBContext.ExecuteStoreQuery<vInterventionen>(sql, args);

                //System.Data.EntityClient.EntityCommand cmd = new System.Data.EntityClient.EntityCommand();
                ////cmd.Parameters.Add();
                //EntityDataReader reader = cmd.ExecuteReader();
                ////System.Data.Entity.DbContext db = new System.Data.Entity.DbContext(DBContext.Database.Connection.ConnectionString);
                ///IEnumerable<vInterventionen> Res = DBContext.Database.SqlQuery<vInterventionen>("Select * from vInterventionen", null);         //  db.Database.SqlQuery(

                //tInterventionenBack = Res2.ToList<vInterventionen>;
                //tInterventionenBack = DBContext.vInterventionen;
                //foreach (var rIntervention in tInterventionenBack)
                //{
                //    string xy = rIntervention.Maßnahme;
                //}

                //IQueryable<vInterventionen> I1 = tInterventionenBack.Where(I => I.Maßnahme.StartsWith("A"));
                //foreach (var rIntervention in I1)
                //{
                //    string xy = rIntervention.Maßnahme;
                //}
                //int i = I1.Count();

                //I1 = tInterventionenBack.Where(I => I.Maßnahme.StartsWith("M"));
                //foreach (var rIntervention in I1)
                //{
                //    string xy = rIntervention.Maßnahme;
                //}
                //i = I1.Count();

                //Qry = I1;


                //IQueryable<vInterventionen> I98 = (tInterventionenBack as ObjectQuery).AsQueryable();

                //string xyxyyxy = "";

                //IQueryable<Kostentraeger> Kostenträger3 = from k in DBContext.Kostentraeger
                //                                          where k.Name == "b"
                //                                          select k;

                //Func<int, double, double> f = (m, x) => m * x + 10;
                //System.Linq.Expressions.Expression<Func<int, double, double>> expression = (m, x) => m * x + 10;
                ////System.Linq.Expressions.Expression<Func<int, double, double>> expression2 = k.Name.StartsWith("b");

                //var Kostenträger = DBContext.Kostentraeger.Where(k => k.Name.StartsWith("b"));
                //Kostenträger.Where(k => k.Name.StartsWith("b"));

                //var tKost = DBContext.Kostentraeger;
                //foreach (var Kost in tKost)
                //{
                //    string xy = Kost.Name;
                //}

                //IQueryable<Kostentraeger> Kostenträger2 = DBContext.Kostentraeger.Where("Kostentraeger.Name='Test'");
                //ObjectQuery<Kostentraeger> query =
                //DBContext.Kostentraeger.Where("it.ProductID = @product", new ObjectParameter("Name", "xy"));
                //ObjectQuery<Kostentraeger> Kostenträger24 = productQuery1.Where("it.ProductID = @productID");

                //using (ERModelPMDSEntities data = 
                //new ERModelPMDSEntities()) {
                //ObjectQuery<Kostentraeger> kost6 = data.CreateQuery<Kostentraeger>(
                //"SELECT VALUE c FROM Customer AS c WHERE c.Address.City = @city", 
                //new ObjectParameter("city", "Salt Lake City"));

                //this.getDBContext();
                //using (var DBContext = PMDSBusiness._db)
                //{


                //System.Data.EntityClient.EntityCommand cmd = new System.Data.EntityClient.EntityCommand();
                //cmd.Parameters.Add();
                //EntityDataReader reader = cmd.ExecuteReader();
                //System.Data.Entity.DbContext db = new System.Data.Entity.DbContext(DBContext.Database.Connection.ConnectionString);

                ////IEnumerable<vInterventionen> Res = DBContext.Database.SqlQuery<vInterventionen>("Select * from vInterventionen", null);         //  db.Database.SqlQuery(
                //IEnumerable<vInterventionen> Res = DBContext.vInterventionen.SqlQuery("Select * from vInterventionen").ToList<vInterventionen>();
                //foreach (vInterventionen rInt in Res)
                //{


                //}


                //var tKost = DBContext.Kostentraeger;
                IQueryable<PMDS.db.Entities.Kostentraeger> Kostenträger = DBContext.Kostentraeger.Where(k => k.Name.Equals("b") || k.Name.Contains("xy"));
                //List<string> values = new List<string>();
                //values.Add("Anl");
                //values.Add("Für");
                //context.Customer.Where(c => values.Contains(c.Name)).ToList();
                //var inter = DBContext.vInterventionen.Where(k => values.Contains(k.Maßnahme));

                //string sWhere = "";
                //var inter2 = from d in DBContext.vInterventionen where d.Maßnahme == "C#" && d.Maßnahme != "xy" || (d.Maßnahme.Contains("yxyx"))

                //DBContext.vInterventionen.Where("it.ProductID = @product", new ObjectParameter("Name", "xy"));

                //string xyxyxy = "SELECT Maßnahme FROM vInterventionen as p WHERE p.Maßnahme like 'xy'";
                ////ObjectQuery<DbDataRecord> Inter5 = new ObjectQuery<DbDataRecord>(xyxyxy, DBContext);

                // ObjectContext 
                //var inter2 = DBContext.vInterventionen; 

                //List<vInterventionen> myList = DBContext.CreateQuery<vInterventionen>("SELECT VALUE Kunde FROM Kunde").ToList();
                //DBContext.ExecuteStoreQuery
                ////foreach (var I in inter)
                ////{
                ////    string xy = I.Maßnahme;
                ////}


                //System.Data.EntityClient.EntityCommand ec = new Data.EntityClient.EntityCommand();

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getAllKostenträger: " + ex.ToString());
            }
        }

        public void getInterventionen_Templatesxy(PMDS.db.Entities.ERModellPMDSEntities DBContext, ref DBTerminePara para, ref System.Guid IDKlinik,
                                ref IQueryable<vInterventionen> iInterventionen, ref PMDS.Global.eUITypeTermine UITypeTermine)
        {
            try
            {
                Expression<Func<vInterventionen, bool>> predicate = null;
                this.getPredicateInterventionen_TemplatesTest(para, IDKlinik, ref predicate, false, ref UITypeTermine);

                //var resQry = DBContext.vInterventionen;
                var resQry = DBContext.vInterventionen.Where(predicate);
                foreach (var rInt in resQry)
                {
                    string xy = "";

                }
                iInterventionen = resQry;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getInterventionen: " + ex.ToString());
            }
        }

        public void getPredicateInterventionen_TemplatesTest(DBTerminePara para, System.Guid IDKlinik,
                                        ref Expression<Func<vInterventionen, bool>> predicateRes,
                                        bool IsÜbergabe, ref PMDS.Global.eUITypeTermine UITypeTermine)
        {
            try
            {
                if (para.OnlyIDPflegePlan)
                {
                    predicateRes = p => p.IDPflegeplan == para.IDPflegePlan;
                }
                else
                {
                    Expression<Func<vInterventionen, bool>> predicateAnd1 = PredicateBuilder.True<vInterventionen>();
                    Expression<Func<vInterventionen, bool>> predicateAnd2 = PredicateBuilder.True<vInterventionen>();

                    if (IDKlinik == null)
                    {
                        throw new Exception("getPredicateInterventionen: IDKlinik == null !");
                    }
                    predicateAnd1 = p => p.IDKlinik == IDKlinik;
                    predicateAnd1 = predicateAnd1.And(p => p.UrlaubJN == 0);                            //UrlaubJN nein
                    predicateAnd1 = predicateAnd1.And(p => p.EntlassenJN == 0);                         //EntlassenJN nein
                    predicateAnd1 = predicateAnd1.And(p => p.AbgesetztJN == 0);                         //AbgesetztJN nein
                    predicateAnd1 = predicateAnd1.And(p => p.ErledigtJN == 0);                      //Übergabe 1  ==true
                    predicateAnd1 = predicateAnd1.And(p => p.MitPflegediagnoseAbzeichnenJN == 0);       //AbgesetztJN nein

                    if (para.ShowOhneZeitbezugOhneUI)
                    {
                        if (!this.checkDateNull(ref para.From))
                        {
                            Expression<Func<vInterventionen, bool>> predOr1 = PredicateBuilder.True<vInterventionen>();
                            predOr1 = p => p.Startdatum >= para.From;
                            predOr1 = predOr1.Or(p => p.von == "");
                            predicateAnd1 = predicateAnd1.And(predOr1);
                        }
                        if (!this.checkDateNull(ref para.To))
                        {
                            Expression<Func<vInterventionen, bool>> predOr1 = PredicateBuilder.True<vInterventionen>();
                            predOr1 = p => p.Startdatum <= para.To;
                            predOr1 = predOr1.Or(p => p.von == "");
                            predicateAnd1 = predicateAnd1.And(predOr1);
                        }
                    }
                    else
                    {
                        if (!this.checkDateNull(ref para.From))
                        {
                            predicateAnd1 = p => p.Startdatum >= para.From;
                        }
                        if (!this.checkDateNull(ref para.To))
                        {
                            predicateAnd1 = p => p.Startdatum <= para.To;
                        }
                    }

                    //Expression<Func<vInterventionen, bool>> predicateAndDate = PredicateBuilder.True<vInterventionen>();
                    //if (!this.checkDateNull(ref para.From))
                    //{
                    //    predicateAnd1 = predicateAnd1.And(p => p.Startdatum >= para.From);
                    //}
                    //if (!this.checkDateNull(ref para.To))
                    //{
                    //    predicateAnd1 = predicateAnd1.And(p => p.Startdatum <= para.From);
                    //}

                    //Expression<Func<vInterventionen, bool>> predicateAndDate2 = PredicateBuilder.True<vInterventionen>();
                    //predicateAndDate2 = predicateAndDate2.Or(p => p.Startdatum < para.From);
                    //predicateAndDate2 = predicateAndDate2.Or(p => p.von == "");
                    //predicateAndDate2 = predicateAndDate2.And(predicateAndDate);
                    //predicateAnd1 = predicateAnd1.And(predicateAndDate2);

                    if (para.ansicht == PMDS.Global.TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                        if (!this.checkGuidEmpty(ref para.IDAbteilung))
                        {
                            predicateAnd1 = predicateAnd1.And(p => p.IDAbteilung == para.IDAbteilung);
                        }
                        if (!this.checkGuidEmpty(ref para.IDBereich))
                        {
                            predicateAnd1 = predicateAnd1.And(p => p.IDBereich == para.IDBereich);
                        }
                    }
                    else if (para.ansicht == PMDS.Global.TerminlisteAnsichtsmodi.Klientanansicht)
                    {
                        if (para.IDAufenthalt == null)
                        {
                            throw new Exception("getPredicateInterventionen: para.IDAufenthalt == null !");
                        }
                        if (!this.checkGuidEmpty(ref para.IDAufenthalt))
                        {
                            predicateAnd1 = predicateAnd1.And(p => p.IDAufenthalt == para.IDAufenthalt);
                        }
                    }
                    else
                    {
                        throw new Exception("getPredicateInterventionen: para.ansicht '" + para.ansicht.ToString() + "' not allowed");
                    }

                    //if (para.ShowPflegeEintragTyp)
                    //{
                    //    predicateAnd1 = predicateAnd1.And(p => p.Eintragstyp == (int)para.PflegeEintragTyp);
                    //}
                    if (para.aIDMaßnahme.Length > 0)
                    {
                        Expression<Func<vInterventionen, bool>> predOrMassnahmen = PredicateBuilder.True<vInterventionen>();
                        //List<Guid> lMaßnahmen = new List<Guid>();
                        foreach (Guid IMaßnahme in para.aIDMaßnahme)
                        {
                            predOrMassnahmen = predOrMassnahmen.Or(p => p.IDEintrag == IMaßnahme);
                            //lMaßnahmen.Add(IMaßnahme);
                        }
                        predicateAnd1 = predicateAnd1.And(predOrMassnahmen);
                        //predicateAnd1 = predicateAnd1.And(p => lMaßnahmen.FindAll(p.IDEintrag));
                    }
                    if (para.BerufsstandJN)
                    {
                        //predicateAnd1 = predicateAnd1.And(p => p.IDBerufsstand == para.IDBerufsstand);
                    }
                    if (para.BezugJN)
                    {
                        //predicateAnd1 = predicateAnd1.And(p => p.IDBezug == para.IDBezug);    //lthxy
                        string xy = "";
                    }

                    //predicateAnd2 = predicateAnd2.Or(p => p.von == "");

                    //Expression<Func<vInterventionen, bool>> wAndBlock = PredicateBuilder.True<vInterventionen>();
                    //wAndBlock = wAndBlock.And(predicateAnd1);
                    //wAndBlock = wAndBlock.And(predicateAnd2);
                    //predicateRes = wAndBlock;

                    predicateRes = predicateAnd1;


                    //Expression<Func<vInterventionen, bool>> p1 = PredicateBuilder.True<vInterventionen>();
                    //p1 = p => p.Maßnahme == "X";
                    //p1 = predicateAnd1.And(p => p.Maßnahme == "Y");

                    //Expression<Func<vInterventionen, bool>> p2 = PredicateBuilder.True<vInterventionen>();
                    //p2 = p => p.Maßnahme == "A";
                    //p2 = predicateAnd1.And(p => p.Maßnahme == "B");

                    //Expression<Func<vInterventionen, bool>> pOr = PredicateBuilder.False<vInterventionen>();
                    //pOr = p1;
                    //pOr = pOr.Or(p2);

                    //Expression<Func<vInterventionen, bool>> pWhere = PredicateBuilder.True<vInterventionen>();
                    //pWhere = pOr.And(p1);


                    //Func<vInterventionen, bool> predicate1xy = s => s.Maßnahme == "";
                    //predicate1xy += s => s.IDBezug == "";

                    //Func<vInterventionen, bool> predicate1 = s => s.TerminJN == 0;
                    //Func<vInterventionen, bool> predicate2 = s => (predicate1xy(s) || predicate1(s));
                    //Func<vInterventionen, bool> predicate3 = s => (predicate1(s) && predicate2(s));



                    ////predicateAnd1 = p => p.IDKlinik == IDKlinik;
                    ////predicateAnd2 = p => p.IDKlinik == IDKlinik;

                    ////Expression<Func<vInterventionen, bool>> combinedOr = s => (predicateAnd1(s) || predicateAnd1(s));
                    ////Func<vInterventionen, bool> combinedAnd = s => (predicate1(s) && predicate2(s));


                    //Func<vInterventionen, bool> predicate1 = s => s.Maßnahme;
                    //Func<vInterventionen, bool> predicate2 = s => s.StartsWith("I");
                    //Func<vInterventionen, bool> combinedOr = s => (predicateAnd1(s) || predicateAnd2(s));
                    //Func<vInterventionen, bool> combinedAnd = s => (predicate1(s) && predicate2(s));

                    //predicateRes = predicateAnd2.And(predicateAnd2.
                    //predicateAnd1 = predicateAnd1.Or(p => p.von == "");

                    ////With OR block, you must use FALSE
                    //var wBlockOr1 = PredicateBuilder.False();
                    //wBlockOr1 = wBlockOr1.Or(c => c.FirstName.Contains("A"));
                    //wBlockOr1 = wBlockOr1.Or(c => c.LastName.Contains("B"));
                    //var wBlockOr2 = PredicateBuilder.False();
                    //wBlockOr1 = wBlockOr1.Or(
                    //    c => c.Birthday == new DateTime(1998, 1, 1));
                    //wBlockOr1 = wBlockOr1.Or(
                    //    c => c.Birthday == new DateTime(1999, 12, 31));
                    ////With AND block, you must use TRUE
                    //var wAndBlock = PredicateBuilder.True();
                    ////Combine between Or blocks
                    //wAndBlock = wAndBlock.And(wBlockOr1.Expand());
                    //wAndBlock = wAndBlock.And(wBlockOr2.Expand());
                    //var customers = db.Customers.AsExpandable().Where(wAndBlock);

                    //public	Guid		IDEintrag	= Guid.Empty;
                    //public	Guid		IDBezug		= Guid.Empty;
                    //public  Guid[]		aIDEintrag  = {};
                    //public int			EintragTyp	= -1;
                    //public int          OhneZeitBezug = 2;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPredicateInterventionen_Templates: " + ex.ToString());
            }
        }

        //public void getDbObjectes(PMDS.db.Entities.ERModellPMDSEntities DBContext)
        //{
        //    try
        //    {
        //        var metadata = ((IObjectContextAdapter)DBContext).ObjectContext.MetadataWorkspace;
        //        //var query = from meta in metadata.GetItemCollection(DataSpace.SSpace)
        //        //            where meta.BuiltInTypeKind == BuiltInTypeKind.EntityType
        //        //            select (meta as EntityType).Name;

        //        var queryxyxy = from meta in metadata.GetItems(DataSpace.OSpace)
        //            .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
        //                        let properties = meta is EntityType ? (meta as EntityType).Properties : null
        //                        select new
        //                        {
        //                            TableName = (meta as EntityType).Name,
        //                            Fields = from p in properties
        //                                     select new
        //                                     {
        //                                         FielName = p.Name,
        //                                         DbType = p.TypeUsage.EdmType.Name
        //                                     }
        //                        };


        //        var infoInterventionen = typeof(vInterventionen).GetProperties();
        //        foreach (System.Reflection.PropertyInfo infoCol in infoInterventionen)
        //        {

        //            string ab = infoCol.Name;
        //            string xType = infoCol.Name.GetType().Name;

        //        }


        //        string abxy = "";

        //        //IEnumerable<FieldList> properties = from p in typeof(T).GetProperties()
        //        //                                    where (from a in p.GetCustomAttributes(false)
        //        //                                           where a is EdmScalarPropertyAttribute
        //        //                                           select true).FirstOrDefault()
        //        //                                    select new FieldList
        //        //                                    {
        //        //                                        FieldName = p.Name,
        //        //                                        FieldType = p.PropertyType,
        //        //                                        FieldPK = p.GetCustomAttributes(false).Where(a => a is EdmScalarPropertyAttribute && ((EdmScalarPropertyAttribute)a).EntityKeyProperty).Count() > 0
        //        //                                    }; 

        //        //pmds context = new DataClasses1DataContext();
        //        //var datamodel = context.Mapping;

        //        DbSet<vInterventionen> entities = DBContext.vInterventionen;

        //        //string parmList = "Surname, Firstname, Address.Postcode";
        //        //var customers = entities.Select("Address.Postcode");

        //        //foreach (var r in datamodel.GetTables())
        //        //{

        //        //    if (r.TableName.Equals("dbo.Person", StringComparison.InvariantCultureIgnoreCase))
        //        //    {
        //        //        foreach (var r1 in r.RowType.DataMembers)
        //        //        {
        //        //            string xy = r1.MappedName;
        //        //        }
        //        //    }

        //        //}

        //        var tables = metadata.GetItemCollection(DataSpace.OCSpace)
        //          .GetItems<EntityContainer>()
        //          .Single()
        //          .BaseEntitySets
        //          .OfType<EntitySet>()
        //          .Where(s => !s.MetadataProperties.Contains("Type")
        //            || s.MetadataProperties["Type"].ToString() == "Tables");

        //        foreach (var table in tables)
        //        {
        //            var tableName = table.MetadataProperties.Contains("Table")
        //                && table.MetadataProperties["Table"].Value != null
        //              ? table.MetadataProperties["Table"].Value.ToString()
        //              : table.Name;

        //            var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
        //            string sTableName = tableSchema + "." + tableName;

        //            var result = metadata.GetItems<EntityType>(DataSpace.OSpace);
        //            var obj = result.Single(x => x.Name == tableName);
        //            foreach (object col in obj.Members)
        //            {
        //                string xyxy = "";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("PMDSBusiness.getDbObjectes: " + ex.ToString());
        //    }
        //}

    }

}

