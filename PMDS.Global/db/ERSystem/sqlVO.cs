using PMDS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace PMDS.Global.db.ERSystem
{

    public partial class sqlVO : Component
    {

        public string selVO = "";
        public string selVO_Bestelldaten = "";
        public string selVO_Bestellpostitionen = "";
        public string selVOLager= "";

        public bool isInitialized = false;

        public enum eSelVO
        {
            ID = 0,
            Search = 1
        }
        public enum eSelVO_Bestelldaten
        {
            ID = 0,
            AllsWhereIDVOVerordnung = 1,
            Bestellvorschläge = 2,
            search = 3,
            IDVO = 4
        }
        public enum eSelVO_Bestellpostitionen
        {
            ID = 0,
            Search = 1
        }
        public enum eSelVOLager
        {
            IDVO = 0,
            All = 1
        }

        public PMDSBusiness b = new PMDSBusiness();







        public sqlVO()
        {
            InitializeComponent();
        }

        public sqlVO(IContainer container)
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
                    this.selVO = this.daVO.SelectCommand.CommandText;
                    this.selVO_Bestelldaten = this.daVO_Bestelldaten.SelectCommand.CommandText;
                    this.selVO_Bestellpostitionen = this.daVO_Bestellpostitionen.SelectCommand.CommandText;
                    this.selVOLager = this.da_VOLager.SelectCommand.CommandText;

                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.initControl: " + ex.ToString());
            }
        }




        public bool getVO(Nullable<System.Guid> ID, eSelVO selType, ref dsVO ds, Nullable<DateTime> dFrom, Nullable<DateTime> dTo, Nullable<Guid> gTyp, string lstPatients,
                            Nullable<Guid> IDAufenthalt, Nullable<Guid> IDPflegeplan, Nullable<Guid> IDMedDaten, Nullable<Guid> IDWundeKopf, bool NurAktuelle, PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI TypeUI, bool SearchForForVerknüpfungen, ref System.Collections.Generic.List<Guid> lstTyp,
                            ref List<Guid> lstIDVONotShow, string sLagerZustand)
        {
            try
            {
                this.daVO.SelectCommand.CommandText = this.selVO;
                this.daVO.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daVO, RBU.DataBase.CONNECTION);

                if (selType == eSelVO.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daVO.SelectCommand.CommandText += sqlWhere;
                }
                else if (selType == eSelVO.Search)
                {
                    string sqlWhere = "";
                    if (NurAktuelle)
                    {
                        dFrom = DateTime.Now.Date;
                        dTo = DateTime.Now.Date;
                    }
                    if (dFrom != null)
                    {
                        if (NurAktuelle)
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumVerordnetAb<=? ";
                        }
                        else
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumVerordnetAb>=? ";
                        }
                    }
                    if (dTo != null)
                    {
                        if (NurAktuelle)
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " (DatumVerordnetBis>=? or DatumVerordnetBis is null)";
                        }
                        else
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " (DatumVerordnetBis<=? or DatumVerordnetBis is null) ";
                        }
                    }
                    if (gTyp != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Typ='" + gTyp.ToString() + "' ";
                    }
                    if (sLagerZustand.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " VO.ID IN (Select IDVO from VO_Lager where Zustand='" + sLagerZustand.Trim() + "') ";
                    }
                    if (lstTyp != null && lstTyp.Count > 0)
                    {
                        string sWhereTmp = "";
                        foreach (Guid gGuidTmp in lstTyp)
                        {
                            sWhereTmp += (sWhereTmp.Trim() == "" ? "" : " or ") + " Typ='" + gGuidTmp.ToString() + "' ";
                        }
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " (" + sWhereTmp + ") ";
                    }
                    if (lstIDVONotShow != null && lstIDVONotShow.Count > 0)
                    {
                        string sWhereTmp = "";
                        foreach (Guid gGuidTmp in lstIDVONotShow)
                        {
                            sWhereTmp += (sWhereTmp.Trim() == "" ? "" : " and ") + " ID<>'" + gGuidTmp.ToString() + "' ";
                        }
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " (" + sWhereTmp + ") ";
                    }
                    if (lstPatients.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + lstPatients + " ";
                    }

                    if (SearchForForVerknüpfungen)
                    {
                        string sqlWhereIDsTmp = "";
                        sqlWhereIDsTmp += (sqlWhereIDsTmp.Trim() == "" ? "" : " or ") + " IDAufenthalt='" + IDAufenthalt.ToString() + "' ";
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + sqlWhereIDsTmp + " ";
                    }
                    else
                    {
                        string sqlWhereIDsTmp = "";
                        if (IDAufenthalt != null && IDPflegeplan == null && IDMedDaten == null && IDWundeKopf == null)
                        {
                            sqlWhereIDsTmp += (sqlWhereIDsTmp.Trim() == "" ? "" : " or ") + " IDAufenthalt='" + IDAufenthalt.ToString() + "' ";
                            //sqlWhereIDsTmp += (sqlWhereIDsTmp.Trim() == "" ? "" : " or ") + " (IDAufenthalt='" + IDAufenthalt.ToString() + "' and VO.ID not IN (Select IDVerordnung from VO_PflegeplanPDX)  and VO.ID not IN (Select IDVerordnung from VO_MedizinischeDaten)) ";
                        }
                        if (IDPflegeplan != null)
                        {
                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                            {
                                PMDS.db.Entities.PflegePlan rPflegeplan = this.b.getPflegeplan(IDPflegeplan.Value, db);
                                //IQueryable<PMDS.db.Entities.PflegePlanPDx> tPflegePlanPDx = db.PflegePlanPDx.Where(o => o.IDPflegePlan == IDPflegeplan.Value);
                                //PMDS.db.Entities.PflegePlanPDx rPflegePlanPDx = tPflegePlanPDx.First();
                                if (rPflegeplan.EintragGruppe.Equals("T"))      //Keine VO zu Terminen möglich
                                    return true;
                                
                                
                                string sqlWhereTmp = " (VO.ID IN (Select IDVerordnung from VO_PflegeplanPDX where IDUntertaegigeGruppe='" + rPflegeplan.IDUntertaegigeGruppe.ToString() + "') ";
                                if (IDAufenthalt != null)
                                {
                                    sqlWhereTmp += " and VO.IDAufenthalt='" + IDAufenthalt.ToString() + "' ";
                                }
                                sqlWhereTmp += ") ";
                                sqlWhereIDsTmp += (sqlWhereIDsTmp.Trim() == "" ? "" : " or ") + sqlWhereTmp + " ";
                            }
                        }
                        if (IDMedDaten != null)
                        {
                            string sqlWhereTmp = " (VO.ID IN (Select IDVerordnung from VO_MedizinischeDaten where IDMedizinischeDaten='" + IDMedDaten.ToString() + "') ";
                            if (IDAufenthalt != null)
                            {
                                sqlWhereTmp += " and VO.IDAufenthalt='" + IDAufenthalt.ToString() + "' ";
                            }
                            sqlWhereTmp += ") ";
                            sqlWhereIDsTmp += (sqlWhereIDsTmp.Trim() == "" ? "" : " or ") + sqlWhereTmp + " ";
                        }
                        if (IDWundeKopf != null)
                        {
                            string sqlWhereTmp = " (VO.ID IN (Select IDVerordnung from VO_Wunde where IDWundeKopf='" + IDWundeKopf.ToString() + "') ";
                            if (IDAufenthalt != null)
                            {
                                sqlWhereTmp += " and VO.IDAufenthalt='" + IDAufenthalt.ToString() + "' ";
                            }
                            sqlWhereTmp += ") ";
                            sqlWhereIDsTmp += (sqlWhereIDsTmp.Trim() == "" ? "" : " or ") + sqlWhereTmp + " ";
                        }
                        if (sqlWhereIDsTmp.Trim() != "")
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + sqlWhereIDsTmp + " ";
                        }
                    }

                    this.daVO.SelectCommand.CommandText += sqlWhere;
                    if (dFrom != null)
                    {
                        this.daVO.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumVerordnetAb", System.Data.OleDb.OleDbType.Date, 16, "DatumVerordnetAb")).Value = dFrom.Value.Date;
                    }
                    if (dTo != null)
                    {
                        this.daVO.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumVerordnetBis", System.Data.OleDb.OleDbType.Date, 16, "DatumVerordnetBis")).Value = dTo.Value.Date;
                    }
                }
                else
                {
                    throw new Exception("sqlVO.getVO: selType '" + selType.ToString() + "' not supported!");
                }

                this.daVO.Fill(ds.VO);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getVO: " + ex.ToString());
            }
        }

        public dsVO.VORow getNewRowVO(ref dsVO ds)
        {
            try
            {
                dsVO.VORow rNew = (dsVO.VORow)ds.VO.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDAufenthalt = System.Guid.NewGuid();
                rNew.IDMedikament = System.Guid.NewGuid();
                rNew.Typ = System.Guid.NewGuid();
                rNew.Menge = 0;
                rNew.Einheit = "";
                rNew.Hinweis = "";
                rNew.DatumVerordnetAb = DateTime.Now;
                rNew.SetDatumVerordnetBisNull();
                rNew.BestaetigtVon = "";
                rNew.DatumErstellt = DateTime.Now;
                rNew.IDBenutzerErstellt = System.Guid.NewGuid();
                rNew.LoginNameFreiErstellt = "";
                rNew.DatumGeaendert = DateTime.Now;
                rNew.IDBenutzerGeaendert = System.Guid.NewGuid();
                rNew.LoginNameFreiGeaendert = "";
                rNew.SetLieferantNull();
                rNew.HinweisLieferant = "";
                rNew.Anmerkung = "";

                ds.VO.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getNewRowVO: " + ex.ToString());
            }
        }

        public bool delete_VO(Guid IDVO)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO where ID='" + IDVO.ToString()  + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_VO: " + ex.ToString());
            }
        }
        public bool delete_VOMedDaten(Guid IDVO, Guid IDMedizinischeDaten)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO_MedizinischeDaten where IDVerordnung='" + IDVO.ToString() + "' and IDMedizinischeDaten='" + IDMedizinischeDaten.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_VOMedDaten: " + ex.ToString());
            }
        }
        public bool delete_VOPflegeplanPDx(Guid IDVO, Guid IDUntertaegigeGruppe)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO_PflegeplanPDX where IDVerordnung='" + IDVO .ToString() + "' and IDUntertaegigeGruppe='" + IDUntertaegigeGruppe.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_VOPflegeplanPDx: " + ex.ToString());
            }
        }
        public bool delete_VOWundeKopf(Guid IDVO, Guid IDWundeKopf)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO_Wunde where IDVerordnung='" + IDVO.ToString() + "' and IDWundeKopf='" + IDWundeKopf.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_VOWundeKopf: " + ex.ToString());
            }
        }

        public bool getVO_Bestelldaten(Nullable<System.Guid> ID, eSelVO_Bestelldaten selType, ref dsVO ds, string sWhereIDVO, Nullable<DateTime> dFrom, Nullable<DateTime> dTo, Nullable<Guid> gTyp,
                                        string lstPatients, bool NurAktuelle, Nullable<Guid> IDAufenthalt, ref System.Collections.Generic.List<Guid> lstTyp)
        {
            try
            {
                this.daVO_Bestelldaten.SelectCommand.CommandText = this.selVO_Bestelldaten;
                this.daVO_Bestelldaten.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daVO_Bestelldaten, RBU.DataBase.CONNECTION);

                if (selType == eSelVO_Bestelldaten.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daVO_Bestelldaten.SelectCommand.CommandText += sqlWhere;
                }
                else if (selType == eSelVO_Bestelldaten.IDVO)
                {
                    string sqlWhere = " where IDVerordnung='" + ID.Value.ToString() + "'";
                    this.daVO_Bestelldaten.SelectCommand.CommandText += sqlWhere;
                }
                else if (selType == eSelVO_Bestelldaten.AllsWhereIDVOVerordnung)
                {
                    string sqlWhere = "";
                    if (sWhereIDVO.Trim() != "")
                    {
                        sqlWhere = " where (" + sWhereIDVO + ") ";
                    }
                    else
                    {
                        sqlWhere = " where ID='" + System.Guid.NewGuid().ToString() + "' ";
                    }
                    this.daVO_Bestelldaten.SelectCommand.CommandText += sqlWhere;
                }
                else if (selType == eSelVO_Bestelldaten.search)
                {
                    string sqlWhere = "";
                    if (NurAktuelle)
                    {
                        dFrom = null;
                        dTo = DateTime.Now.Date; ;
                    }
                    if (dFrom != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " GueltigAb>=? ";
                    }
                    if (dTo != null)
                    {
                        if (NurAktuelle)
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " GueltigBis>? ";
                        }
                        else
                        {
                            sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " GueltigBis<=? ";
                        }
                    }
                    if (gTyp != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Typ='" + gTyp.ToString() + "' ";
                    }
                    if (lstTyp.Count > 0)
                    {
                        string sWhereTmp = "";
                        foreach (Guid gGuidTmp in lstTyp)
                        {
                            sWhereTmp += (sWhereTmp.Trim() == "" ? "" : " or ") + " Typ='" + gGuidTmp.ToString() + "' ";
                        }
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " VO_Bestellpostitionen.IDBestelldaten_VO IN (Select ID from VO_Bestelldaten where (" + sWhereTmp + ")) ";
                    }
                    if (lstPatients.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + lstPatients + " ";
                    }
                    if (IDAufenthalt != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + "  VO_Bestelldaten.IDVerordnung IN (Select VO.ID from VO where VO.IDAufenthalt='" + IDAufenthalt.ToString() + "') ";
                    }

                    this.daVO_Bestelldaten.SelectCommand.CommandText += sqlWhere;
                    if (dFrom != null)
                    {
                        this.daVO_Bestelldaten.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb")).Value = dFrom.Value.Date;
                    }
                    if (dTo != null)
                    {
                        this.daVO_Bestelldaten.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis")).Value = dTo.Value.Date;
                    }
                }
                else if (selType == eSelVO_Bestelldaten.Bestellvorschläge)
                {
                    string sqlWhere = "";

                    //string sWhereTmp6 = " (Select Count(*) as anz from VO_Bestellpostitionen where VO_Bestellpostitionen.IDBestelldaten_VO=VO_Bestelldaten.ID and VO_Bestellpostitionen.DatumBestellung <> ?) = 0 ";
                    //sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " " + sWhereTmp6 + " ";

                    //sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Status='" + PMDSBusiness.IDVOStatusBestellt.ToString() + "' ";
                    if (dFrom != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumNaechsterAnspruch>=? ";
                    }
                    if (dTo != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumNaechsterAnspruch<=? ";
                    }
                    if (sWhereIDVO.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " " + sWhereIDVO + " ";
                    }
                  
                    if (gTyp != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Typ='" + gTyp.ToString() + "' ";
                    }
                    if (lstTyp.Count > 0)
                    {
                        string sWhereTmp = "";
                        foreach (Guid gGuidTmp in lstTyp)
                        {
                            sWhereTmp += (sWhereTmp.Trim() == "" ? "" : " or ") + " VO_Bestelldaten.Typ='" + gGuidTmp.ToString() + "' ";
                        }
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " (" + sWhereTmp + ") ";
                    }

                    this.daVO_Bestelldaten.SelectCommand.CommandText += sqlWhere;

                    //this.daVO_Bestelldaten.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("VO_Bestellpostitionen.DatumBestellung", System.Data.OleDb.OleDbType.Date, 16, "VO_Bestellpostitionen.DatumBestellung")).Value = dTo.Value.Date;
                    if (dFrom != null)
                    {
                        this.daVO_Bestelldaten.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumNaechsterAnspruch", System.Data.OleDb.OleDbType.Date, 16, "DatumNaechsterAnspruch")).Value = dFrom.Value.Date;
                    }
                    if (dTo != null)
                    {
                        this.daVO_Bestelldaten.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumNaechsterAnspruch", System.Data.OleDb.OleDbType.Date, 16, "DatumNaechsterAnspruch")).Value = dTo.Value.Date;
                    }
                  
                }
                else
                {
                    throw new Exception("sqlVO.getVO_Bestelldaten: selType '" + selType.ToString() + "' not supported!");
                }

                this.daVO_Bestelldaten.Fill(ds.VO_Bestelldaten);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getVO_Bestelldaten: " + ex.ToString());
            }
        }

        public bool delete_VOBestelldaten(Guid IDVO)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO_Bestelldaten where ID='" + IDVO.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_VOBestelldaten: " + ex.ToString());
            }
        }

        public dsVO.VO_BestelldatenRow getNewRowVO_Bestelldaten(ref dsVO ds)
        {
            try
            {
                dsVO.VO_BestelldatenRow rNew = (dsVO.VO_BestelldatenRow)ds.VO_Bestelldaten.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDVerordnung = System.Guid.NewGuid();
                rNew.GueltigAb = DateTime.Now;
                rNew.GueltigBis = DateTime.Now;
                rNew.Typ = System.Guid.NewGuid();
                rNew.IDMedikament = System.Guid.NewGuid();
                
                rNew.EigentumKlient = false;
                rNew.Menge = 0;
                rNew.Einheit = "";
                rNew.Lieferant = System.Guid.NewGuid();
                rNew.HinweisLieferant = "";
                rNew.Anmerkung = "";
                rNew.IDBenutzerErstellt = System.Guid.NewGuid();
                rNew.LoginNameFreiErstellt = "";
                rNew.DatumErstellt = DateTime.Now;
                rNew.IDBenutzergeaendert = System.Guid.NewGuid();
                rNew.LoginNameFreiGeaendert = "";
                rNew.DatumGeaendert = DateTime.Now;

                rNew.Dauerbestellung = false;
                rNew.DatumNaechsterAnspruch = DateTime.Now;
                rNew.SetSerienterminEndetAmNull();
                rNew.SerienterminType = "";
                rNew.SetWiedWertJedenNull();
                rNew.TagWochenMonat = "";
                rNew.SetnTenMonatNull();
                rNew.Wochentage = "";
                rNew.Dauer = -1;
                rNew.EinmaligeAnforderung = false;

                ds.VO_Bestelldaten.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getNewRowVO_Bestelldaten: " + ex.ToString());
            }
        }

        public bool getVO_Bestellpostitionen(Nullable<System.Guid> ID, eSelVO_Bestellpostitionen selType, ref dsVO ds, string sWhereIDVO, Nullable<DateTime> dFrom, Nullable<DateTime> dTo, Nullable<Guid> gTyp, Nullable<Guid> gStatus, 
                                            ref System.Collections.Generic.List<Guid> lstTyp)
        {
            try
            {
                this.daVO_Bestellpostitionen.SelectCommand.CommandText = this.selVO_Bestellpostitionen;
                this.daVO_Bestellpostitionen.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daVO_Bestellpostitionen, RBU.DataBase.CONNECTION);
                
                if (selType == eSelVO_Bestellpostitionen.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daVO_Bestellpostitionen.SelectCommand.CommandText += sqlWhere;
                }
                else if (selType == eSelVO_Bestellpostitionen.Search)
                {
                    string sqlWhere = "";
                    if (dFrom != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumBestellung>=? ";
                    }
                    if (dTo != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumBestellung<=? ";
                    }
                    if (sWhereIDVO.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " " + sWhereIDVO + " ";
                    }

                    if (gTyp != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " VO_Bestellpostitionen.IDBestelldaten_VO IN (Select ID from VO_Bestelldaten where Typ='" + gTyp.ToString() + "') ";
                    }
                    if (lstTyp != null && lstTyp.Count > 0)
                    {
                        string sWhereTmp = "";
                        foreach (Guid gGuidTmp in lstTyp)
                        {
                            sWhereTmp += (sWhereTmp.Trim() == "" ? "" : " or ") + " Typ='" + gGuidTmp.ToString() + "' ";
                        }
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " VO_Bestellpostitionen.IDBestelldaten_VO IN (Select ID from VO_Bestelldaten where (" + sWhereTmp + ")) ";
                    }
                    if (gStatus != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Status='" + gStatus.ToString() + "' ";
                    }

                    this.daVO_Bestellpostitionen.SelectCommand.CommandText += sqlWhere;
                    if (dFrom != null)
                    {
                        this.daVO_Bestellpostitionen.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumBestellung", System.Data.OleDb.OleDbType.Date, 16, "DatumBestellung")).Value = dFrom.Value.Date;
                    }
                    if (dTo != null)
                    {
                        this.daVO_Bestellpostitionen.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumBestellung", System.Data.OleDb.OleDbType.Date, 16, "DatumBestellung")).Value = dTo.Value.Date;
                    }
                }
                else
                {
                    throw new Exception("sqlVO.getVO_Bestellpostitionen: selType '" + selType.ToString() + "' not supported!");
                }
                this.daVO_Bestellpostitionen.Fill(ds.VO_Bestellpostitionen);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getVO_Bestellpostitionen: " + ex.ToString());
            }
        }

        public bool delete_IDVO_Bestellposition(Guid IDVOBestellposition)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO_Bestellpostitionen where ID='" + IDVOBestellposition.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_IDVO_Bestellposition: " + ex.ToString());
            }
        }

        public dsVO.VO_BestellpostitionenRow getNewRowVO_Bestellpostitionen(ref dsVO ds)
        {
            try
            {
                dsVO.VO_BestellpostitionenRow rNew = (dsVO.VO_BestellpostitionenRow)ds.VO_Bestellpostitionen.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDBestelldaten_VO = System.Guid.NewGuid();
                rNew.IDMedikament = System.Guid.NewGuid();
                rNew.IDMedikamentGeliefert = System.Guid.NewGuid();
                rNew.DatumBestellung = DateTime.Now;
                rNew.MengeBestellung = 0;
                rNew.EinheitBestellung = "";
                rNew.Anmerkung = "";
                rNew.Status = System.Guid.NewGuid();
                rNew.SetLieferantNull();
                rNew.HinweisLieferant = "";
                rNew.SetDatumLieferungNull();
                //rNew.DatumLieferung = DateTime.Now;
                rNew.MengeLieferung = 0;
                rNew.EinheitLieferung = "";
                rNew.BemerkungLieferung = "";
                rNew.IDBenutzerErstellt = System.Guid.NewGuid();
                rNew.LoginNameFreiErstellt = "";
                rNew.DatumErstellt = DateTime.Now;
                rNew.IDBenutzerGeaendert = System.Guid.NewGuid();
                rNew.LoginNameFreiGeaendert = "";
                rNew.DatumGeaendert = DateTime.Now;
                rNew.UserChanged = false;
                rNew.SetDatumBestellungPlanNull();

                ds.VO_Bestellpostitionen.Rows.Add(rNew);
                return rNew;

            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getNewRowVO_Bestellpostitionen: " + ex.ToString());
            }
        }


        public bool getVOLager(Nullable<System.Guid> IDVO, eSelVOLager selType, dsVO ds, Nullable<DateTime> dFrom, Nullable<DateTime> dTo, string sZustand, string sSeriennummer)
        {
            try
            {
                this.da_VOLager.SelectCommand.CommandText = this.selVOLager;
                this.da_VOLager.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.da_VOLager, RBU.DataBase.CONNECTION);

                if (selType == eSelVOLager.IDVO)
                {
                    string sqlWhere = " where IDVO='" + IDVO.Value.ToString() + "'";
                    if (sZustand.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Zustand='" + sZustand.Trim() + "' ";
                    }

                    this.da_VOLager.SelectCommand.CommandText += sqlWhere;
                }
                else if (selType == eSelVOLager.All)
                {
                    string sqlWhere = "";
                    if (sSeriennummer.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Seriennummer like '%" + sSeriennummer.Trim() + "%' ";
                    }
                    if (sZustand.Trim() != "")
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " Zustand='" + sZustand.Trim() + "' ";
                    }
                    if (dFrom != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumErstellt>=? ";
                    }
                    if (dTo != null)
                    {
                        sqlWhere += (sqlWhere.Trim() == "" ? " where " : " and ") + " DatumErstellt<=? ";
                    }
                    this.da_VOLager.SelectCommand.CommandText += sqlWhere;
                    if (dFrom != null)
                    {
                        this.da_VOLager.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt")).Value = dFrom.Value.Date;
                    }
                    if (dTo != null)
                    {
                        DateTime dToTmp = new DateTime(dTo.Value.Date.Year, dTo.Value.Date.Month, dTo.Value.Date.Day, 23, 59, 59);
                        this.da_VOLager.SelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt")).Value = dToTmp;
                    }
                }
                else
                {
                    throw new Exception("sqlVO.getVOLager: selType '" + selType.ToString() + "' not supported!");
                }
                this.da_VOLager.Fill(ds.VO_Lager);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getVOLager: " + ex.ToString());
            }
        }

        public bool delete_VOLager(Guid IDVOLager)
        {
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = " Delete from VO_Lager where ID='" + IDVOLager.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.delete_VOLager: " + ex.ToString());
            }
        }

        public dsVO.VO_LagerRow getNewRowVOLager(ref dsVO ds)
        {
            try
            {
                dsVO.VO_LagerRow rNew = (dsVO.VO_LagerRow)ds.VO_Lager.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDVO = System.Guid.NewGuid();
                rNew.Seriennummer = "";
                rNew.Zustand = "";
                rNew.IDBenutzerErstellt = System.Guid.NewGuid();
                rNew.LoginNameFreiErstellt = "";
                rNew.DatumErstellt = DateTime.Now;
                rNew.IDBenutzerGeaendert = System.Guid.NewGuid();
                rNew.LoginNameFreiGeaendert = "";
                rNew.DatumGeaendert = DateTime.Now;

                ds.VO_Lager.Rows.Add(rNew);
                return rNew;

            }
            catch (Exception ex)
            {
                throw new Exception("sqlVO.getNewRowVOLager: " + ex.ToString());
            }
        }

    }


}
