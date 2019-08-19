using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;



namespace PMDS.Global.db.ERSystem
{
    
    public partial class sqlKlient : Component
    {

        public string daSelPatient = "";
        public string daSelPatientSmall = "";
        public string daSelAufenthalt = "";
        public string daSelAufenthaltVerlauf = "";
        public string daSelAbteilung= "";
        public string daSelBereich = "";

        public bool isInitialized = false;
        
        public enum eSelTypeKlient
        {
            ID = 0,
            All = 100
        }
        public enum eSelTypeAufenthalt
        {
            ID = 0,
            IDPatient = 1
        }
        public enum eSelTypeAufenthaltVerlauf
        {
            ID = 0,
            IDAufenthalt = 1
        }
        public enum eSelTypeAbteilung
        {
            ID = 0,
            All = 100
        }
        public enum eSelTypeBereich
        {
            ID = 0,
            IDAbteilung = 2,
            All = 100
        }







        public sqlKlient()
        {
            InitializeComponent();
        }

        public sqlKlient(IContainer container)
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
                    this.daSelPatient = this.daPatient.SelectCommand.CommandText;
                    this.daSelPatientSmall = this.daPatientSmall.SelectCommand.CommandText;
                    this.daSelAufenthalt = this.daAufenthalt.SelectCommand.CommandText;
                    this.daSelAufenthaltVerlauf = this.daAufenthaltVerlauf.SelectCommand.CommandText;
                    this.daSelAbteilung = this.daAbteilung.SelectCommand.CommandText;
                    this.daSelBereich = this.daBereich.SelectCommand.CommandText;

                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.initControl: " + ex.ToString());
            }
        }





        public bool getPatient(Nullable<System.Guid> ID, eSelTypeKlient SelTypeKlient, ref dsKlient ds)
        {
            try
            {
                this.daPatientSmall.SelectCommand.CommandText = this.daSelPatientSmall;
                this.daPatientSmall.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daPatientSmall, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypeKlient == eSelTypeKlient.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daPatientSmall.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypeKlient == eSelTypeKlient.All)
                {
                    string sOrderBy = " order by Nachname asc, Vorname asc ";
                    this.daPatientSmall.SelectCommand.CommandText += sOrderBy;
                }
                else
                {
                    throw new Exception("sqlKlient.getPatient: SelTypeKlient '" + SelTypeKlient.ToString() + "' not supported!");
                }
                this.daPatientSmall.Fill(ds.PatientSmall);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getPatient: " + ex.ToString());
            }
        }

        public bool getAufenthalt(Nullable<System.Guid> ID, eSelTypeAufenthalt SelTypeAufenthalt, ref dsKlient ds)
        {
            try
            {
                this.daAufenthalt.SelectCommand.CommandText = this.daSelAufenthalt;
                this.daAufenthalt.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daAufenthalt, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypeAufenthalt == eSelTypeAufenthalt.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daAufenthalt.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypeAufenthalt == eSelTypeAufenthalt.IDPatient)
                {
                    string sqlWhere = " where IDPatient='" + ID.Value.ToString() + "' ";
                    string sqlOrderBy = " order by Aufnahmezeitpunkt desc";
                    this.daAufenthalt.SelectCommand.CommandText += sqlWhere + " " + sqlOrderBy;
                }
                else
                {
                    throw new Exception("sqlKlient.getAufenthalt: SelTypeAufenthalt '" + SelTypeAufenthalt.ToString() + "' not supported!");
                }
                this.daAufenthalt.Fill(ds.Aufenthalt);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getAufenthalt: " + ex.ToString());
            }
        }

        public bool getAufenthaltVerlauf(Nullable<System.Guid> ID, eSelTypeAufenthaltVerlauf SelTypeAufenthaltVerlauf, ref dsKlient ds)
        {
            try
            {
                this.daAufenthaltVerlauf.SelectCommand.CommandText = this.daSelAufenthaltVerlauf;
                this.daAufenthaltVerlauf.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daAufenthaltVerlauf, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypeAufenthaltVerlauf == eSelTypeAufenthaltVerlauf.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daAufenthaltVerlauf.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypeAufenthaltVerlauf == eSelTypeAufenthaltVerlauf.IDAufenthalt)
                {
                    string sqlWhere = " where IDAufenthalt='" + ID.Value.ToString() + "'";
                    string sOrderby = " order by Datum desc";
                    this.daAufenthaltVerlauf.SelectCommand.CommandText += sqlWhere + " " + sOrderby;
                }
                else
                {
                    throw new Exception("sqlKlient.getAufenthaltVerlauf: SelTypeAufenthalt '" + SelTypeAufenthaltVerlauf.ToString() + "' not supported!");
                }
                this.daAufenthaltVerlauf.Fill(ds.AufenthaltVerlauf);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getAufenthaltVerlauf: " + ex.ToString());
            }
        }


        public dsKlient.AbteilungRow getAbteilungRow(Guid IDAbteilung, sqlKlient sqlKlient1, ref dsKlient dsKlient1)
        {
            try
            {
                dsKlient1.Abteilung.Clear();
                this.getAbteilung(IDAbteilung, sqlKlient.eSelTypeAbteilung.ID, ref dsKlient1);
                dsKlient.AbteilungRow rAbteilung = (dsKlient.AbteilungRow)dsKlient1.Abteilung.Rows[0];

                return rAbteilung;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getAbteilungRow: " + ex.ToString());
            }
        }
        public bool getAbteilung(Nullable<System.Guid> ID, eSelTypeAbteilung SelTypeAbteilung, ref dsKlient ds)
        {
            try
            {
                this.daAbteilung.SelectCommand.CommandText = this.daSelAbteilung;
                this.daAbteilung.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daAbteilung, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypeAbteilung == eSelTypeAbteilung.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daAbteilung.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypeAbteilung == eSelTypeAbteilung.All)
                {
                    string sqlOrderBy = " order by Bezeichnung asc ";
                    this.daAbteilung.SelectCommand.CommandText += sqlOrderBy;
                }
                else
                {
                    throw new Exception("sqlKlient.getAbteilung: SelTypeAufenthalt '" + SelTypeAbteilung.ToString() + "' not supported!");
                }
                this.daAbteilung.Fill(ds.Abteilung);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getAbteilung: " + ex.ToString());
            }
        }


        public dsKlient.BereichRow getBereichRow(Guid IDBereich, sqlKlient sqlKlient1, ref dsKlient dsKlient1)
        {
            try
            {
                dsKlient1.Bereich.Clear();
                this.getBereich(IDBereich, sqlKlient.eSelTypeBereich.ID, ref dsKlient1);
                dsKlient.BereichRow rBereich = (dsKlient.BereichRow)dsKlient1.Bereich.Rows[0];

                return rBereich;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getBereichRow: " + ex.ToString());
            }
        }
        public bool getBereich(Nullable<System.Guid> ID, eSelTypeBereich SelTypeBereich, ref dsKlient ds)
        {
            try
            {
                this.daBereich.SelectCommand.CommandText = this.daSelBereich;
                this.daBereich.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daBereich, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypeBereich == eSelTypeBereich.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daBereich.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypeBereich == eSelTypeBereich.IDAbteilung)
                {
                    string sqlWhere = " where IDAbteilung='" + ID.Value.ToString() + "'";
                    this.daBereich.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypeBereich == eSelTypeBereich.All)
                {
                    string sqlOrderBy = " order by Bezeichnung asc ";
                    this.daBereich.SelectCommand.CommandText += sqlOrderBy;
                }
                else
                {
                    throw new Exception("sqlKlient.getBereich: SelTypeAufenthalt '" + SelTypeBereich.ToString() + "' not supported!");
                }
                this.daBereich.Fill(ds.Bereich);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlKlient.getBereich: " + ex.ToString());
            }
        }

    }

}
