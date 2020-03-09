using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;



namespace PMDS.Global.db.ERSystem
{




    public partial class sqlManange : Component
    {

        public string daSelAnmeldungen = "";
        public string daSeldaGetAktAufenhaltByPatient = "";
        public string daSelTextbausteine = "";
        public string daSelÄrzte = "";
        public string daSelDokumenten2 = "";
        public string daSelArztabrechnung = "";
        public string daSelSuchtgiftschrankSchlüssel = "";
        public string daSelRechNr = "";
        public string daSelMedizinischeTypen = "";
        public string daSelEintrag = "";
        public string daSelMedizinischeDaten = "";
        public string daSelWundBilder = "";
        public string daSelRecht = "";
        public string daSelELGAProtocoll = "";
        public string daSelMessage = "";
        public string daSelMessageToClient = "";


        public enum eTypeAnmeldungen
        {
            ID = 0,
            Usr = 1
        }
        public enum eTypeTextbausteine
        {
            ID = 0,
            All = 1
        }
        public enum eTypeÄrzte
        {
            ID = 0,
            All = 1
        }
        public enum eTypeDokumente2
        {
            All = 0,
            ForAbteilungBenutzergruppe = 1
        }
        public enum eTypeRechNr
        {
            All = 0
        }
        public enum eTypeMedizinischeDatenLayout
        {
            all = 0,
            ID = 1
        }
        public enum eTypeEintrag
        {
            all = 0,
            ID = 1,
            Gruppe = 2
        }
        public enum eTypeMedDaten
        {
            MedDaten = 0
        }
        public enum eTypeWundBilder
        {
            ID = 0
        }
        public enum eTypeRecht
        {
            AllForUser = 0
        }
        public enum eTypeELGAProtocoll
        {
            AllForUser = 0
        }
        public enum eTypeMessages
        {
            ID = 0,
            All = 1,
            MessagesUnreaded = 2
        }



        public bool isInitialized = false;









        public sqlManange()
        {
            InitializeComponent();
        }


        public sqlManange(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void initControl()
        {
            try
            {
                if (!this.isInitialized)
                {
                    this.daSelAnmeldungen = this.daAnmeldungen.SelectCommand.CommandText;
                    this.daSeldaGetAktAufenhaltByPatient = this.daGetAktAufenhaltByPatient.SelectCommand.CommandText;
                    this.daSelTextbausteine = this.daTextbausteine.SelectCommand.CommandText;
                    this.daSelÄrzte = this.daÄrzte.SelectCommand.CommandText;
                    this.daSelDokumenten2 = this.daDokumente2.SelectCommand.CommandText;
                    this.daSelArztabrechnung = this.daArztabrechnung.SelectCommand.CommandText;
                    this.daSelSuchtgiftschrankSchlüssel = this.daSuchtgiftschrankSchlüssel.SelectCommand.CommandText;
                    this.daSelRechNr = this.daRechNr.SelectCommand.CommandText;
                    this.daSelMedizinischeTypen = this.daMedizinischeTypen.SelectCommand.CommandText;
                    this.daSelEintrag = this.daEintrag.SelectCommand.CommandText;
                    this.daSelMedizinischeDaten = this.daMedizinischeDaten.SelectCommand.CommandText;
                    this.daSelWundBilder = this.daWundePosBilder.SelectCommand.CommandText;
                    this.daSelRecht = this.daRecht.SelectCommand.CommandText;
                    this.daSelELGAProtocoll = this.daELGAProtocoll.SelectCommand.CommandText;
                    this.daSelMessage = this.daMessages.SelectCommand.CommandText;
                    this.daSelMessageToClient = this.daMessagesToUsers.SelectCommand.CommandText;

                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.initControl: " + ex.ToString());
            }
        }


        public bool getPatientenStart(System.Guid IDBenutzer, int hist, System.Guid IDBezugsperson,
                                        ref  dsKlientenliste ds, System.Guid IDAbteilung, System.Guid IDBereich, System.Guid IDKlient, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                string sqlTxt = "";
                string sqlPar = "";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();

                sqlTxt = this.davGetKlientenliste.SelectCommand.CommandText;
                da.SelectCommand = cmd;
                da.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(da, RBU.DataBase.CONNECTION);

                sqlTxt += "('" + IDBenutzer.ToString() + "'," + hist.ToString() + ",'" + IDBezugsperson.ToString() + "')";

                if (IDAbteilung != null)
                {
                    if (!IDAbteilung.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDAbteilung='" + IDAbteilung.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }
                if (IDBereich != null)
                {
                    if (!IDBereich.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDBereich='" + IDBereich.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }
                if (IDKlient != null)
                {
                    if (!IDKlient.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDKlient='" + IDKlient.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }

                sqlTxt = sqlTxt.Replace("vKlientenliste", "dbo.s2_GetKlientenliste");
                cmd.CommandText = sqlTxt + " " + sqlPar;
                da.Fill(ds.vKlientenliste);

                return true;
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "sqlManage.getPatientenStart"))
                {
                    return this.getPatientenStart(IDBenutzer, hist, IDBezugsperson, ref ds, IDAbteilung, IDBereich, IDKlient, IDTime);
                }
                throw new Exception("sqlManage.getPatientenStart: " + ex.ToString());
            }
        }
        public bool getPatientActAufenthalt(System.Guid IDKlient, int hist, ref  dsKlientenliste ds, int iFctCalled = 0)
        {
            string sInfoExcept = "";
            try
            {
                this.daGetAktAufenhaltByPatient.SelectCommand.Parameters.Clear();
                this.daGetAktAufenhaltByPatient.SelectCommand.CommandText = this.daSeldaGetAktAufenhaltByPatient;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                this.daGetAktAufenhaltByPatient.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                this.daGetAktAufenhaltByPatient.SelectCommand.CommandText += " and " + ds.AktAufenthaltPatient.IDPatientColumn.ColumnName + "='" + IDKlient.ToString() + "'";
                sInfoExcept = this.daGetAktAufenhaltByPatient.SelectCommand.CommandText;
                this.daGetAktAufenhaltByPatient.Fill(ds.AktAufenthaltPatient);

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
                            Exception exTmp2 = new Exception("sqlManange.getPatientActAufenthalt: " + iFctCalled.ToString() + "'nd try" + "\r\n" + sInfoExcept + "\r\n");
                            ENV.HandleException(exTmp2, "ExceptionDBNetLibNextCall", false);
                        }
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        iFctCalled += 1;
                        return this.getPatientActAufenthalt(IDKlient, hist, ref ds , iFctCalled);
                    }
                    catch (Exception ex3)
                    {
                        PMDS.Global.ENV.checkExceptionDBNetLib(ex3.ToString());
                        throw new Exception("sqlManange.getPatientActAufenthalt: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                    }
                }
                else
                {
                    throw new Exception("sqlManange.getPatientActAufenthalt: " + "\r\n" + sInfoExcept + "\r\n" + "\r\n" + ex.ToString());
                }
            }
        }

        public void getAllPatients(ref ERSystem.dsKlientenliste dsKlientenlisteAll, bool IncludeHistory)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                ERSystem.dsKlientenliste dsKlientenliste1 = new db.ERSystem.dsKlientenliste();
                PMDS.Global.db.ERSystem.sqlManange sqlManangeWork = new ERSystem.sqlManange();
                sqlManangeWork.initControl();
                sqlManangeWork.getPatientenStart(ENV.USERID, 0, System.Guid.Empty, ref dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
                foreach (ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenliste1.vKlientenliste)
                {
                    b.addRowToDataset((DataSet)dsKlientenlisteAll, rKlient, rKlient.IDAufenthalt, dsKlientenliste1.vKlientenliste.IDAufenthaltColumn.ColumnName, dsKlientenliste1.vKlientenliste.TableName.Trim());
                }

                if (IncludeHistory)
                {
                    dsKlientenliste1.Clear();
                    sqlManangeWork.getPatientenStart(ENV.USERID, 1, System.Guid.Empty, ref dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
                    foreach (ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenliste1.vKlientenliste)
                    {
                        b.addRowToDataset((DataSet)dsKlientenlisteAll, rKlient, rKlient.IDAufenthalt, dsKlientenliste1.vKlientenliste.IDAufenthaltColumn.ColumnName, dsKlientenliste1.vKlientenliste.TableName.Trim());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getAllPatients: " + ex.ToString());
            }
        }

        public bool getAnmeldungen(System.Guid ID, eTypeAnmeldungen TypeAnmeldungen, ref  dsKlientenliste ds,
                                    ref string Usr)
        {
            try
            {
                this.daAnmeldungen.SelectCommand.CommandText = this.daSelAnmeldungen;
                this.daAnmeldungen.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daAnmeldungen, RBU.DataBase.CONNECTION);

                if (TypeAnmeldungen == eTypeAnmeldungen.ID)
                {
                    string sqlWhere = "";

                }
                else if (TypeAnmeldungen == eTypeAnmeldungen.Usr)
                {
                    string sqlWhere = "";

                }
                else
                {
                    throw new Exception("getAnmeldungen: TypeAnmeldungen '" + TypeAnmeldungen.ToString() + "' not supported!");
                }
                this.daAnmeldungen.Fill(ds.Anmeldungen);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getAnmeldungen: " + ex.ToString());
            }
        }

        public bool getTextbausteine(System.Guid ID, eTypeTextbausteine TypeSel, ref  dsKlientenliste ds)
        {
            try
            {
                this.daTextbausteine.SelectCommand.CommandText = this.daSelTextbausteine;
                this.daTextbausteine.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daTextbausteine, RBU.DataBase.CONNECTION);

                if (TypeSel == eTypeTextbausteine.ID)
                {
                    string sqlWhere = " where ID='" + ID.ToString() + "'";
                    this.daTextbausteine.SelectCommand.CommandText += sqlWhere + " order by Kurzbezeichnung asc";

                }
                else if (TypeSel == eTypeTextbausteine.All)
                {
                    this.daTextbausteine.SelectCommand.CommandText += " order by Kurzbezeichnung asc";
                }
                else
                {
                    throw new Exception("getTextbausteine: TypeSel '" + TypeSel.ToString() + "' not supported!");
                }

                this.daTextbausteine.Fill(ds.Textbausteine);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getTextbausteine: " + ex.ToString());
            }
        }
        public dsKlientenliste.TextbausteineRow newRowTextbaustein(ref dsKlientenliste ds, string usr)
        {
            try
            {
                dsKlientenliste.TextbausteineRow rNew = (dsKlientenliste.TextbausteineRow)ds.Textbausteine.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Kurzbezeichnung = "";
                rNew.TextRtf = "";
                rNew.Berufsgruppen = "";
                rNew.ErstelltAm = DateTime.Now;
                rNew.ErstelltVon = usr.Trim();

                ds.Textbausteine.Rows.Add(rNew);
                return rNew;

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.newRowTextbaustein: " + ex.ToString());
            }
        }

        public bool getÄrzte(System.Guid ID, eTypeÄrzte TypeSel, ref  dsKlientenliste ds, string txtSearch)
        {
            try
            {
                this.daÄrzte.SelectCommand.CommandText = this.daSelÄrzte;
                this.daÄrzte.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daÄrzte, RBU.DataBase.CONNECTION);

                if (TypeSel == eTypeÄrzte.ID)
                {
                    string sqlWhere = " where ID='" + ID.ToString() + "'";
                    this.daÄrzte.SelectCommand.CommandText += sqlWhere;

                }
                else if (TypeSel == eTypeÄrzte.All)
                {
                    string sqlWhere = "";
                    if (txtSearch.Trim() != "")
                    {
                        sqlWhere = " where (Nachname like '%" + txtSearch.Trim() + "%' or Vorname like '%" + txtSearch.Trim() + "%') ";
                    }

                    this.daÄrzte.SelectCommand.CommandText += sqlWhere + " order by Nachname asc, Vorname asc";
                }
                else
                {
                    throw new Exception("getÄrzte: TypeSel '" + TypeSel.ToString() + "' not supported!");
                }

                this.daÄrzte.Fill(ds.Aerzte);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getÄrzte: " + ex.ToString());
            }
        }

        public bool getDokumente2(System.Guid ID, eTypeDokumente2 TypeSel, ref  dsKlientenliste ds, string txtSearch)
        {
            try
            {
                this.daDokumente2.SelectCommand.CommandText = this.daSelDokumenten2;
                this.daDokumente2.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daDokumente2, RBU.DataBase.CONNECTION);

                if (TypeSel == eTypeDokumente2.All)
                {
                    this.daDokumente2.SelectCommand.CommandText += " order by Bezeichnung asc";

                }
                else if (TypeSel == eTypeDokumente2.ForAbteilungBenutzergruppe)
                {
                    string sqlWhere = "";
                    //if (txtSearch.Trim() != "")
                    //{
                    //    sqlWhere = " where (Nachname like '%" + txtSearch.Trim() + "%' or Vorname like '%" + txtSearch.Trim() + "%') ";
                    //}

                    this.daDokumente2.SelectCommand.CommandText += sqlWhere + " order by Bezeichnung asc";
                }
                else
                {
                    throw new Exception("getDokumente2: TypeSel '" + TypeSel.ToString() + "' not supported!");
                }

                this.daDokumente2.Fill(ds.Dokumente2);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getDokumente2: " + ex.ToString());
            }
        }


        public void loadDokumenteBenutzer(ref PMDS.Global.db.ERSystem.dsKlientenliste dsReturn, Guid IDAbteilungSelectByUser)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsDokumente2Abteilungen dsDokumente2Abteilungen1 = new dsDokumente2Abteilungen();
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                PMDS.Global.db.ERSystem.dsKlientenliste dsDB = new dsKlientenliste();
                this.getDokumente2(System.Guid.Empty, eTypeDokumente2.All, ref dsDB, "");
                foreach (PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row rDokumentDB in dsDB.Dokumente2)
                {
                    dsDokumente2Abteilungen1.Clear();
                    if (rDokumentDB.Abteilungen.Trim() != "")
                    {
                        dsDokumente2Abteilungen1.ReadXml(new StringReader(rDokumentDB.Abteilungen.Trim()));
                        foreach (PMDS.Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilung in dsDokumente2Abteilungen1.Abteilungen)
                        {
                            if (rAbteilung.IDAbteilung.Equals(IDAbteilungSelectByUser))
                            {
                                PMDS.Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow[] arrBenutzergruppen = (PMDS.Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow[])dsDokumente2Abteilungen1.Benutzergruppen.Select("IDAbteilung='" + rAbteilung.IDAbteilung.ToString() + "'", "");
                                foreach (PMDS.Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow rBenutzergruppen in arrBenutzergruppen)
                                {
                                    if (PMDSBusiness1.UserCanSign(rBenutzergruppen.IDBenutzergruppe))
                                    {
                                        PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row[] arrDokumente = (PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row[])dsReturn.Dokumente2.Select("ID='" + rDokumentDB.ID.ToString() + "'", "");
                                        if (arrDokumente.Length == 0)
                                        {
                                            PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row rNewDokument = (PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row)dsReturn.Dokumente2.NewRow();
                                            rNewDokument.ItemArray = rDokumentDB.ItemArray;
                                            dsReturn.Dokumente2.Rows.Add(rNewDokument);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.loadDokumenteBenutzer: " + ex.ToString());
            }
        }
        public dsKlientenliste.Dokumente2Row addNewRowDokumente2(ref dsKlientenliste ds, string User)
        {
            try
            {
                dsKlientenliste.Dokumente2Row rNew = (dsKlientenliste.Dokumente2Row)ds.Dokumente2.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Bezeichnung = "";
                rNew.DokumentenName = "";
                rNew.Abteilungen = "";
                rNew.Benutzergruppen = "";
                rNew.ErstelltAm = DateTime.Now;
                rNew.ErstelltVon = User.Trim();

                ds.Dokumente2.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.addNewRowDokumente2: " + ex.ToString());
            }
        }

        public string getS2_GetZusatzswerteAsString(System.Guid IDPflegeeintrag)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                System.Data.DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandText = "SELECT A = dbo.s2_GetZusatzswerteAsString('" + IDPflegeeintrag.ToString() + "')";

                da.Fill(dt);
                string retValue = "";
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    if (r[0] != null)
                    {
                        retValue = r[0].ToString().Trim();
                    }
                }

                return retValue;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getS2_GetZusatzswerteAsString: " + ex.ToString());
            }
        }

        public bool getFormularData(PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref PMDS.Global.db.ERSystem.dsKlientenliste ds, int histKlienten)
        {
            try
            {
                string sqlPar = "";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                string SelectCommandTxt = this.daFormularData.SelectCommand.CommandText;
                da.SelectCommand = cmd;
                da.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(da, RBU.DataBase.CONNECTION);

                //SelectCommandTxt = "('" + System.Guid.Empty.ToString() + "'," + "0" + ",'" + System.Guid.Empty.ToString() + "')";
                SelectCommandTxt = SelectCommandTxt.Replace("[p1]", "" + System.Guid.Empty.ToString() + "");
                SelectCommandTxt = SelectCommandTxt.Replace("222", histKlienten.ToString() + "");
                SelectCommandTxt = SelectCommandTxt.Replace("[p3]", "" + System.Guid.Empty.ToString() + "");

                if (cParFormular.lstFormularNames.Count > 0)
                {
                    string sTmp2 = "";
                    foreach (string Formularname in cParFormular.lstFormularNames)
                    {
                        string sTmp = " FormularName='" + Formularname.Trim() + "' ";
                        sTmp2 += (sTmp2.Trim() == "" ? " ": " or ") + sTmp;
                    }
                    sTmp2 = " (" + sTmp2 + ") ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp2;
                }
                if (cParFormular.IDAbteilung_current != null)
                {
                    if (!cParFormular.IDAbteilung_current.Value.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDAbteilung='" + cParFormular.IDAbteilung_current.Value.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }
                if (cParFormular.IDBereich_current != null)
                {
                    if (!cParFormular.IDBereich_current.Value.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDBereich='" + cParFormular.IDBereich_current.Value.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }
                if (cParFormular.IDKlient_current != null)
                {
                    if (!cParFormular.IDKlient_current.Value.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDKlient='" + cParFormular.IDKlient_current.Value.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }
                if (cParFormular.IDKlinik_current != null)
                {
                    if (!cParFormular.IDKlinik_current.Value.Equals(System.Guid.Empty))
                    {
                        string sTmp = "";
                        sTmp = " IDKlinik='" + cParFormular.IDKlinik_current.Value.ToString() + "' ";
                        sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                    }
                }
                if (cParFormular.f_DatumErstelltVon != null)
                {
                    string sTmp = "";
                    sTmp = " Datumerstellt>=?";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }
                if (cParFormular.f_DatumErstelltBis != null)
                {
                    string sTmp = "";
                    sTmp = " Datumerstellt<=?";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }
                cmd.CommandText = SelectCommandTxt + " " + sqlPar;

                if (cParFormular.f_DatumErstelltVon != null)
                    cmd.Parameters.Add("Datumerstellt", System.Data.OleDb.OleDbType.Date, 16, "Datumerstellt").Value = cParFormular.f_DatumErstelltVon.Value.Date;

                if (cParFormular.f_DatumErstelltBis != null)
                    cmd.Parameters.Add("Datumerstellt", System.Data.OleDb.OleDbType.Date, 16, "Datumerstellt").Value = cParFormular.f_DatumErstelltBis.Value.Date;

                da.Fill(ds.FormularData);
                int iCounter = ds.FormularData.Count;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getFormularData: " + ex.ToString());
            }
        }

        public bool getArztabrechnung2(PMDS.Global.db.ERSystem.dsKlientenliste ds, Nullable<Guid> IDBenutzer, string Anmerkung, 
                                        string sLeistungenLike, 
                                        Nullable<DateTime> Von, Nullable<DateTime> Bis, 
                                        Nullable<Guid> IDPatient, Nullable<Guid> IDArztabrechnung, string sLeistung, 
                                        Nullable<Guid> notIDArztabrechnung)
        {
            try
            {               //lthArztabrechnung 
                this.daArztabrechnung.SelectCommand.CommandText = this.daSelArztabrechnung;
                this.daArztabrechnung.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daArztabrechnung, RBU.DataBase.CONNECTION);

                string sqlPar = "";
                if (sLeistungenLike.Trim() != "")
                {
                    string sTmp = " (Leistung1 like '%" + sLeistungenLike.Trim() + "%' or Leistung2 like '%" + sLeistungenLike.Trim() + "%' or Leistung3 like '%" + sLeistungenLike.Trim() + "%') ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;

                    //string sTmp2 = "";
                    //foreach (string Leistung in lstLeistungen)
                    //{
                    //    string sTmp = " (Leistung1='" + Leistung.Trim() + "' or Leistung2='" + Leistung.Trim() + "' or Leistung3='" + Leistung.Trim() + "') ";
                    //    sTmp2 += (sTmp2.Trim() == "" ? " " : " or ") + sTmp;
                    //}
                    //sTmp2 = " (" + sTmp2 + ") ";
                    //sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp2;
                }
                if (sLeistung.Trim() != "")
                {
                    string sTmp = " (Leistung1='" + sLeistung.Trim() + "' or Leistung2='" + sLeistung.Trim() + "' or Leistung3='" + sLeistung.Trim() + "') ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }

                if (IDBenutzer != null)
                {
                    string sTmp = "";
                    sTmp = " IDBenutzer='" + IDBenutzer.ToString() + "' ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }
                if (IDPatient != null)
                {
                    string sTmp = "";
                    sTmp = " IDPatient='" + IDPatient.ToString() + "' ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }
                if (IDArztabrechnung != null)
                {
                    string sTmp = "";
                    sTmp = " ID='" + IDArztabrechnung.ToString() + "' ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }
                if (notIDArztabrechnung != null)
                {
                    string sTmp = "";
                    sTmp = " ID<>'" + notIDArztabrechnung.ToString() + "' ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }

                if (Anmerkung.Trim() != "")
                {
                    string sTmp = "";
                    sTmp = " Anmerkung like '%" + Anmerkung.Trim() + "%' ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }

                if (Von != null)
                {
                    string sTmp = "";
                    sTmp = " Datum>=? ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }
                if (Bis != null)
                {
                    string sTmp = "";
                    sTmp = " Datum<=? ";
                    sqlPar += (sqlPar.Trim() == "" ? " where " : " and ") + sTmp;
                }

                this.daArztabrechnung.SelectCommand.CommandText += " " + sqlPar + " order by Datum desc, Leistung1 asc, Leistung2 asc, Leistung3 asc ";
                if (Von != null)
                {
                    DateTime datTmpVon = new DateTime(Von.Value.Year, Von.Value.Month, Von.Value.Day, 0, 0, 0);
                    this.daArztabrechnung.SelectCommand.Parameters.Add("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum").Value = datTmpVon;
                }
                if (Bis != null)
                {
                    DateTime datTmpBis = new DateTime(Bis.Value.Year, Bis.Value.Month, Bis.Value.Day, 23, 59, 59);
                    this.daArztabrechnung.SelectCommand.Parameters.Add("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum").Value = datTmpBis;
                }

                this.daArztabrechnung.Fill(ds.Arztabrechnung);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getFormularData: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsKlientenliste.ArztabrechnungRow getNewArztabrechnung(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            {           //lthArztabrechnung 
                PMDS.Global.db.ERSystem.dsKlientenliste.ArztabrechnungRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.ArztabrechnungRow)ds.Arztabrechnung.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDPatient = System.Guid.NewGuid();
                rNew.IDBenutzer = System.Guid.NewGuid();
                rNew.Leistung1 = "";
                rNew.Leistung2 = "";
                rNew.Leistung3 = "";
                rNew.Anmerkung = "";
                rNew.Datum = DateTime.Now;
                rNew.Krankenkasse = "";
                rNew.SVNr = "";

                ds.Arztabrechnung.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewArztabrechnung: " + ex.ToString());
            }
        }
        public void deleteArztabrechnung(Guid IDArztabrechnung)
        {
            try
            {                 
                OleDbCommand cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 0;
                cmd.CommandText = " Delete from Arztabrechnung where ID='" + IDArztabrechnung.ToString() + "' ";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.deleteArztabrechnung: " + ex.ToString());
            }
        }

        
        public bool getSuchtgiftschrankSchlüssel(PMDS.Global.db.ERSystem.dsKlientenliste ds, string UserÜbergeber, string UserÜbernehmer)
        {
            try
            {          
                this.daSuchtgiftschrankSchlüssel.SelectCommand.CommandText = this.daSelSuchtgiftschrankSchlüssel;
                this.daSuchtgiftschrankSchlüssel.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daSuchtgiftschrankSchlüssel, RBU.DataBase.CONNECTION);

                string sqlWhere = "";
                if (UserÜbergeber.Trim() != "")
                {
                    string sTmp = "";
                    sTmp = " UserÜbergeber='" + UserÜbergeber.Trim() + "' ";
                    sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + sTmp;
                }

                if (UserÜbernehmer.Trim() != "")
                {
                    string sTmp = "";
                    sTmp = " UserÜbernehmer='" + UserÜbernehmer.Trim() + "' ";
                    sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + sTmp;
                }

                this.daSuchtgiftschrankSchlüssel.SelectCommand.CommandText += sqlWhere;
                this.daSuchtgiftschrankSchlüssel.Fill(ds.tblSuchtgiftschrankSchlüssel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getSuchtgiftschrankSchlüssel: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsKlientenliste.tblSuchtgiftschrankSchlüsselRow getNewSuchtgiftschrankSchlüssel(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            { 
                PMDS.Global.db.ERSystem.dsKlientenliste.tblSuchtgiftschrankSchlüsselRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.tblSuchtgiftschrankSchlüsselRow)ds.tblSuchtgiftschrankSchlüssel.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.UserÜbergeber = "";
                rNew.UserÜbergeberPool = "";
                rNew.UserÜbernehmer = "";
                rNew.UserÜbernehmerPool = "";
                rNew.Am = DateTime.Now;
                rNew.Anmerkung = "";
                rNew.IDAbteilung = System.Guid.NewGuid();

                ds.tblSuchtgiftschrankSchlüssel.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewSuchtgiftschrankSchlüssel: " + ex.ToString());
            }
        }

        public PMDS.Global.db.ERSystem.dsKlientenliste.PatientenEntlassenRow getNewPatientEntlassen(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsKlientenliste.PatientenEntlassenRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.PatientenEntlassenRow)ds.PatientenEntlassen.NewRow();
                rNew.IDAufenthalt = System.Guid.NewGuid();
                rNew.IDPatient = System.Guid.NewGuid();
                rNew.Patient = "";
                rNew.Wohin = "";
                rNew.Entlassungszeitpunkt = new DateTime(1900, 1, 1, 0, 0, 0);

                ds.PatientenEntlassen.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewPatientEntlassen: " + ex.ToString());
            }
        }



        public PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow getNewDekursEntwürfe(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            { 
                PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow)ds.DekurseEntwürfe.NewRow();
                rNew.IDPEEntwurf = System.Guid.NewGuid();
                rNew.IDAufenthalt = System.Guid.NewGuid();
                rNew.SetIDPflegePlanNull();
                rNew.Patient = "";
                rNew.DatumErstellt = DateTime.Now;
                rNew.ErstelltVon = "";
                rNew.SetIDPflegePlanNull();
                rNew.Zeitpunkt = DateTime.Now;
                rNew.Dekurs = "";
                rNew.Klinik = "";
                rNew.Abteilung = "";
                rNew.FuerUserErstellt = "";
                rNew.SetIDFuerUserErstelltNull();

                ds.DekurseEntwürfe.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewDekursEntwürfe: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsKlientenliste.UIRow getNewUI(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            {        
                PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow)ds.UI.NewRow();
                rNew.Bezeichnung = "";
                rNew.Rezepteintrag = "";
                rNew.SetVonNull();
                rNew.SetBisNull();
                rNew.Dosierung = "";
                rNew.ID2 = System.Guid.NewGuid();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDRezeptEintrag = System.Guid.NewGuid();
                rNew.SetIDVerordnungNull();
                rNew.IDMedDatenWundeKopf = System.Guid.NewGuid();
                rNew.Herrichten = -1;

                rNew.Beschreibung = "";
                rNew.Bemerkung = "";
                rNew.Therapie = "";
                rNew.MedizinischerTyp = "";
                rNew.Beendigungsgrund = "";
                rNew.obj = "";

                ds.UI.Rows.Add(rNew);
                return rNew;

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewUI: " + ex.ToString());
            }
        }

        public void deleteRezeptEintragMedDaten(Guid IDRezeptEintragMedDaten)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 0;
                cmd.CommandText = " Delete from RezeptEintragMedDaten where ID='" + IDRezeptEintragMedDaten.ToString() + "' ";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.deleteRezeptEintragMedDaten: " + ex.ToString());
            }
        }

        public void deleteVO_MedizinischeDaten(Guid IDVO_MedizinischeDaten)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 0;
                cmd.CommandText = " Delete from VO_MedizinischeDaten where ID='" + IDVO_MedizinischeDaten.ToString() + "' ";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.deleteVO_MedizinischeDaten: " + ex.ToString());
            }
        }
        public void deleteVO_Wunde(Guid IDVO_Wunde)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 0;
                cmd.CommandText = " Delete from VO_Wunde where ID='" + IDVO_Wunde.ToString() + "' ";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.deleteVO_Wunde: " + ex.ToString());
            }
        }


        public bool getRechNr(PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                this.daRechNr.SelectCommand.CommandText = this.daSelRechNr;
                this.daRechNr.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daRechNr, RBU.DataBase.CONNECTION);

                string sqlWhere = "";
                string sqlOrderby = " order by typ asc, year asc";
                this.daRechNr.SelectCommand.CommandText += sqlWhere + " " + sqlOrderby;

                this.daRechNr.Fill(ds.rechNr);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getRechNr: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsManage.rechNrRow getNewRechNr(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.rechNrRow rNew = (PMDS.Global.db.ERSystem.dsManage.rechNrRow)ds.rechNr.NewRow();
                rNew.typ = "";
                rNew.nr = -1;
                rNew.year = DateTime.Now.Year;


                ds.rechNr.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewRechNr: " + ex.ToString());
            }
        }


        public PMDS.Global.db.ERSystem.dsKlientenliste.tSelectSimpleRow getNewtSelectSimpleSelect(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsKlientenliste.tSelectSimpleRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.tSelectSimpleRow)ds.tSelectSimple.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Select = false;
                rNew.Text = "";
                rNew.SetID2Null();
                rNew.SetID3Null();
                rNew.IDTxt = "";

                ds.tSelectSimple.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewtSelectSimpleSelect: " + ex.ToString());
            }
        }

        public PMDS.Global.db.ERSystem.dsKlientenliste.tMessagesRow getNewttMessages(ref PMDS.Global.db.ERSystem.dsKlientenliste ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsKlientenliste.tMessagesRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.tMessagesRow)ds.tMessages.NewRow();
                rNew.IDProtocoll = System.Guid.NewGuid();
                rNew.Title = "";
                rNew.Absender = "";
                rNew.MessageTxt = "";
                rNew.Created = DateTime.Now;
                rNew.Readed = false;
                rNew.UserFrom = "";
                rNew.UserIDFrom = System.Guid.NewGuid();

                ds.tMessages.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewttMessages: " + ex.ToString());
            }
        }


        public bool getMedizinischeTypen(PMDS.Global.db.ERSystem.dsManage ds, Nullable<Guid> ID, eTypeMedizinischeDatenLayout eTypeSel)
        {
            try
            {
                this.daMedizinischeTypen.SelectCommand.CommandText = this.daSelMedizinischeTypen;
                this.daMedizinischeTypen.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daMedizinischeTypen, RBU.DataBase.CONNECTION);

            
                if (eTypeSel == eTypeMedizinischeDatenLayout.all)
                {
                    string sqlWhere = "";
                    string sqlOrderBy = " order by Nummer asc";
                    this.daMedizinischeTypen.SelectCommand.CommandText += sqlWhere + " " + sqlOrderBy;
                }
                else if (eTypeSel == eTypeMedizinischeDatenLayout.ID)
                {
                    string sqlWhere = "";
                    sqlWhere += " ID='" + ID.Value.ToString() + "' ";
                    this.daMedizinischeTypen.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("getMedizinischeTypen: eTypeSel '" + eTypeSel.ToString() + "' not allowed!");
                }

                this.daMedizinischeTypen.Fill(ds.MedizinischeTypen);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getMedizinischeTypen: " + ex.ToString());
            }
        }

        public void deleteMedizinischeTypen(Guid ID)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 0;
                cmd.CommandText = " Delete from MedizinischeTypen where ID='" + ID.ToString() + "' ";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.deleteMedizinischeTypen: " + ex.ToString());
            }
        }

        public PMDS.Global.db.ERSystem.dsManage.MedizinischeTypenRow getNewMedizinischeTypen(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.MedizinischeTypenRow rNew = (PMDS.Global.db.ERSystem.dsManage.MedizinischeTypenRow)ds.MedizinischeTypen.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Nummer = -1;
                rNew.MedizinischerTyp = -1;
                rNew.Beschreibung = "";
                rNew.SetIconNull();
                rNew.SetIconOFFNull();
                rNew.bVisible = true;

                ds.MedizinischeTypen.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewMedizinischeTypen: " + ex.ToString());
            }
        }


        public bool getEintrag(PMDS.Global.db.ERSystem.dsKlientenliste ds, string EintragText, Nullable<Guid> ID, String EintragGruppe2, int iEntferntJN, eTypeEintrag eTypeSel)
        {
            try
            {
                this.daEintrag.SelectCommand.CommandText = this.daSelEintrag;
                this.daEintrag.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daEintrag, RBU.DataBase.CONNECTION);

                if (eTypeSel == eTypeEintrag.all)
                {
                    string sqlWhere = "";
                    string sqlOrderBy = " order by Text asc";
                    this.daEintrag.SelectCommand.CommandText += sqlWhere + " " + sqlOrderBy;
                }
                else if (eTypeSel == eTypeEintrag.Gruppe)
                {
                    string sqlWhere = " where EintragGruppe='" + EintragGruppe2.Trim() + "' ";
                    if (EintragText.Trim() != "")
                    {
                        sqlWhere += " and (Text like '%" + EintragText.Trim() + "%' or Warnhinweis like '%" + EintragText.Trim() + "%') ";
                    }
                    if (iEntferntJN == 1)
                    {
                        sqlWhere += " and EntferntJN=1 ";
                    }
                    else if (iEntferntJN == 0)
                    {
                        sqlWhere += " and EntferntJN=0 ";
                    }
                    string sqlOrderBy = " order by Text asc";
                    this.daEintrag.SelectCommand.CommandText += sqlWhere + " " + sqlOrderBy;
                }
                else if (eTypeSel == eTypeEintrag.ID)
                {
                    string sqlWhere = "";
                    sqlWhere += " where ID='" + ID.Value.ToString() + "' ";
                    this.daEintrag.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("getEintrag: eTypeSel '" + eTypeSel.ToString() + "' not allowed!");
                }

                this.daEintrag.Fill(ds.Eintrag);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getEintrag: " + ex.ToString());
            }
        }

        public bool getMedizinischeDaten(PMDS.Global.db.ERSystem.dsKlientenliste ds, Guid IDPatient, System.Collections.Generic.List<int> lstMedDaten, eTypeMedDaten eTypeSel)
        {
            try
            {
                this.daMedizinischeDaten.SelectCommand.CommandText = this.daSelMedizinischeDaten;
                this.daMedizinischeDaten.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daMedizinischeDaten, RBU.DataBase.CONNECTION);
                
                if (eTypeSel == eTypeMedDaten.MedDaten)
                {
                    string sqlWhere = " where IDPatient='" + IDPatient.ToString() + "' ";
                    string sqlWhereMedDaten = "";
                    foreach (int MedDatenTyp in lstMedDaten)
                    {
                        sqlWhereMedDaten += (sqlWhereMedDaten.Trim() == "" ? " and (" : " or ") + " MedizinischerTyp=" + MedDatenTyp.ToString() + " ";
                    }
                    sqlWhereMedDaten += ") ";
                    sqlWhere += sqlWhereMedDaten;
                    string sqlOrderBy = " order by Beschreibung asc";
                    this.daMedizinischeDaten.SelectCommand.CommandText += sqlWhere + " " + sqlOrderBy;
                }
                else
                {
                    throw new Exception("getMedizinischeDaten: eTypeSel '" + eTypeSel.ToString() + "' not allowed!");
                }

                this.daMedizinischeDaten.Fill(ds.MedizinischeDaten);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getMedizinischeDaten: " + ex.ToString());
            }
        }

        public bool getWundeBilder(PMDS.Global.db.ERSystem.dsManage ds, Guid ID, eTypeWundBilder eTypeSel)
        {
            try
            {
                this.daWundePosBilder.SelectCommand.CommandText = this.daSelWundBilder;
                this.daWundePosBilder.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daWundePosBilder, RBU.DataBase.CONNECTION);

                if (eTypeSel == eTypeWundBilder.ID)
                {
                    string sqlWhere = " where ID='" + ID.ToString() + "' ";
                    this.daWundePosBilder.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("getWundeBilder: eTypeSel '" + eTypeSel.ToString() + "' not allowed!");
                }

                this.daWundePosBilder.Fill(ds.WundePosBilder);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getWundeBilder: " + ex.ToString());
            }
        }

        public bool getRecht(PMDS.Global.db.ERSystem.dsKlientenliste ds, Guid IDUser, eTypeRecht eTypeSel)
        {
            try
            {
                this.daRecht.SelectCommand.CommandText = this.daSelRecht;
                this.daRecht.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daRecht, RBU.DataBase.CONNECTION);

                if (eTypeSel == eTypeRecht.AllForUser)
                {
                    string sqlWhere = " where ELGA=1 " + " order by Bezeichnung asc";
                    this.daRecht.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("getRecht: eTypeSel '" + eTypeSel.ToString() + "' not allowed!");
                }

                this.daRecht.Fill(ds.Recht);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getRecht: " + ex.ToString());
            }
        }
        public bool getELGAProtocoll(PMDS.Global.db.ERSystem.dsKlientenliste ds, Guid IDUser, Nullable<DateTime> dCreatedFrom, Nullable<DateTime> dCreatedTo, eTypeELGAProtocoll eTypeSel)
        {
            try
            {
                this.daELGAProtocoll.SelectCommand.CommandText = this.daSelELGAProtocoll;
                this.daELGAProtocoll.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daELGAProtocoll, RBU.DataBase.CONNECTION);

                if (eTypeSel == eTypeELGAProtocoll.AllForUser)
                {
                    string sqlWhere = " where IDBenutzer='" + IDUser.ToString() + "' ";
                    if (dCreatedFrom != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " CreatedAt>=? ";
                    }
                    if (dCreatedTo != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " CreatedAt<=? ";
                    }

                    string sqlOrderBy = " order by CreatedAt desc";
                    this.daELGAProtocoll.SelectCommand.CommandText += sqlWhere + " " + sqlOrderBy;
                    if (dCreatedFrom != null)
                    {
                        this.daELGAProtocoll.SelectCommand.Parameters.Add("CreatedAt", System.Data.OleDb.OleDbType.Date, 16, "CreatedAt").Value = dCreatedFrom.Value;
                    }
                    if (dCreatedTo != null)
                    {
                        DateTime dToTmp = new DateTime(dCreatedTo.Value.Year, dCreatedTo.Value.Month, dCreatedTo.Value.Day, 23, 59, 59, 59);
                        this.daELGAProtocoll.SelectCommand.Parameters.Add("CreatedAt", System.Data.OleDb.OleDbType.Date, 16, "CreatedAt").Value = dToTmp;
                    }
                }
                else
                {
                    throw new Exception("getELGAProtocoll: eTypeSel '" + eTypeSel.ToString() + "' not allowed!");
                }

                this.daELGAProtocoll.Fill(ds.ELGAProtocoll);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getELGAProtocoll: " + ex.ToString());
            }
        }


        public PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow getNewELGAPatient(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow rNew = (PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow)ds.ELGASearchPatients.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.NachnameFirma = "";
                rNew.Vorname = "";
                rNew.Strasse = "";
                rNew.PLZ = "";
                rNew.Ort = "";
                rNew.Land = "";
                rNew.Tel = "";
                rNew.SozVersNr = "";
                rNew.PatientLocalID = "";

                ds.ELGASearchPatients.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewELGAPatient: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow getNewELGAGDA(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow rNew = (PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow)ds.ELGASearchGDAs.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.NachnameFirma = "";
                rNew.Vorname = "";
                rNew.Title = "";
                rNew.PLZ = "";
                rNew.Ort = "";
                rNew.Land = "";
                rNew.Strasse = "";
                rNew.StrasseNr = "";
                rNew.IsOrganisation = false;
                rNew.Status = "";
                rNew.State = "";
                rNew.IDElga = "";

                ds.ELGASearchGDAs.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewELGAGDA: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow getNewELGADocument(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow rNew = (PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow)ds.ELGASearchDocuments.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Dokument = "";
                rNew.SetErstelltAmNull();
                rNew.UUID = "";
                rNew.UniqueID = "";
                rNew.LocigalID = "";
                rNew.Author = "";
                rNew.Description = "";
                rNew.DocStatus = "";
                rNew.Version = "";
                rNew.CreationTime = "";
                rNew.Size = 0;
                rNew.Stylesheet = "";
                rNew.ELGAPatientLocalID = "";
                rNew.TypeFile = "";

                ds.ELGASearchDocuments.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getNewELGADocument: " + ex.ToString());
            }
        }

        public bool getMessage2(PMDS.Global.db.ERSystem.dsManage ds, Nullable<Guid> ID, eTypeMessages TypeSel, string ClientsMessage, string TypeMessage)
        {
            try
            {
                this.daMessages.SelectCommand.CommandText = this.daSelMessage;
                this.daMessages.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daMessages, RBU.DataBase.CONNECTION);

                if (TypeSel == eTypeMessages.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "' order by Title asc";
                    this.daMessages.SelectCommand.CommandText += sqlWhere;
                }
                else if (TypeSel == eTypeMessages.All)
                {
                    string sqlWhere = " order by Title asc";
                    this.daMessages.SelectCommand.CommandText += sqlWhere;
                }
                else if (TypeSel == eTypeMessages.MessagesUnreaded)
                {
                    string sqlWhere = " where ClientsMessage='" + ClientsMessage.ToString() + "' and TypeMessage='" + TypeMessage.ToString() + "' and " +
                                      " Classification like '%" + ENV.USERID.ToString() + "%' and(not Progress like '%readed_" + ENV.USERID.ToString() + "%') order by Title asc";
                    this.daMessages.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("getMessage2: TypeSel '" + TypeSel.ToString() + "' not allowed!");
                }

                this.daMessages.Fill(ds.Messages2);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getMessage2: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsManage.Messages2Row addNewMessages2(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.Messages2Row rNew = (PMDS.Global.db.ERSystem.dsManage.Messages2Row)ds.Messages2.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Title = "";
                rNew.Text = "";
                rNew.UserFrom = "";
                rNew.Created = DateTime.Now;
                rNew.UserFromID = System.Guid.NewGuid();
                rNew.ClientsMessage = "";
                rNew.TypeMessage = "";
                rNew.Progress = "";
                rNew.Db = "";
                rNew.SetIDGuidObjectNull();
                rNew.Classification = "";
                rNew.sKey = "";

                ds.Messages2.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.addNewMessages2: " + ex.ToString());
            }
        }
        public bool getMessages2ToUser(PMDS.Global.db.ERSystem.dsManage ds, Nullable<Guid> ID, eTypeMessages TypeSel)
        {
            try
            {
                this.daMessagesToUsers.SelectCommand.CommandText = this.daSelMessageToClient;
                this.daMessagesToUsers.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daMessagesToUsers, RBU.DataBase.CONNECTION);
                
                if (TypeSel == eTypeMessages.ID)
                {
                    string sqlWhere = " where ID='" + ID.ToString() + "' order by Title asc";
                    this.daMessagesToUsers.SelectCommand.CommandText += sqlWhere;
                }
                else if (TypeSel == eTypeMessages.All)
                {
                    string sqlWhere = " order by Title asc";
                    this.daMessagesToUsers.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("getMessage2: TypeSel '" + TypeSel.ToString() + "' not allowed!");
                }

                this.daMessagesToUsers.Fill(ds.Messages2ToUsers);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.getMessage2: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsManage.Messages2ToUsersRow addNewMessages2ToUser(ref PMDS.Global.db.ERSystem.dsManage ds)
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.Messages2ToUsersRow rNew = (PMDS.Global.db.ERSystem.dsManage.Messages2ToUsersRow)ds.Messages2ToUsers.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDMessages = System.Guid.NewGuid();
                rNew.Readed = false;
                rNew.ReadedAt = DateTime.Now;
                rNew.IDUser = System.Guid.NewGuid();
                rNew.Username = "";

                ds.Messages2ToUsers.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlManange.addNewMessages2ToUser: " + ex.ToString());
            }
        }


    }

}
