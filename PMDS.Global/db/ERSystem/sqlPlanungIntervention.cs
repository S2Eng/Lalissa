using MARC.Everest.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;



namespace PMDS.Global.db.ERSystem
{

    public partial class sqlPlanungIntervention : Component
    {
        
        public string daSelPflegeplan = "";
        public string daSelPflegeEintrag = "";

        public bool isInitialized = false;

        public enum eSelTypePflegeplan
        {
            ID = 0,
            IDAufenthalt = 1
        }
        public enum eSelTypePflegeEintrag
        {
            ID = 0,
            IDPflegePlan = 1,
            IDAufenthalt = 2,
            IDAufenthaltAbtBereichZeitpunkt = 3
        }
        





        public sqlPlanungIntervention()
        {
            InitializeComponent();
        }

        public sqlPlanungIntervention(IContainer container)
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
                    this.daSelPflegeplan = this.daPflegeplan.SelectCommand.CommandText;
                    this.daSelPflegeEintrag = this.daPflegeEintrag.SelectCommand.CommandText;

                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sqlPlanungIntervention.initControl: " + ex.ToString());
            }
        }





        public bool getPflegeplan(Nullable<System.Guid> ID, eSelTypePflegeplan SelTypePflegeplan, ref dsPlanungIntervention ds)
        {
            try
            {
                this.daPflegeplan.SelectCommand.CommandText = this.daSelPflegeplan;
                this.daPflegeplan.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daPflegeplan, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypePflegeplan == eSelTypePflegeplan.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daPflegeplan.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypePflegeplan == eSelTypePflegeplan.IDAufenthalt)
                {
                    string sqlWhere = " where IDAufenthalt='" + ID.Value.ToString() + "'";
                    this.daPflegeplan.SelectCommand.CommandText += sqlWhere;
                }
                else
                {
                    throw new Exception("sqlPlanungIntervention.getPflegeplan: SelTypePflegeplan '" + SelTypePflegeplan.ToString() + "' not supported!");
                }
                this.daPflegeplan.Fill(ds.PflegePlan);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlPlanungIntervention.getPflegeplan: " + ex.ToString());
            }
        }

        public bool getPflegeEintrag(Nullable<System.Guid> ID, eSelTypePflegeEintrag SelTypePflegeplan, ref dsPlanungIntervention ds, 
                                    DateTime dFrom, DateTime dTo, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, ref int iFctCalled)
        {
            string sInfoExcept = "getPflegeEintrag";
            try
            {
                this.daPflegeEintrag.SelectCommand.CommandText = this.daSelPflegeEintrag;
                this.daPflegeEintrag.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection2(this.daPflegeEintrag, RBU.DataBase.CONNECTIONSqlClient);

                if (SelTypePflegeplan == eSelTypePflegeEintrag.ID)
                {
                    string sqlWhere = " where ID='" + ID.Value.ToString() + "'";
                    this.daPflegeEintrag.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypePflegeplan == eSelTypePflegeEintrag.IDPflegePlan)
                {
                    string sqlWhere = " where IDPflegePlan='" + ID.Value.ToString() + "'";
                    this.daPflegeEintrag.SelectCommand.CommandText += sqlWhere;
                }
                else if (SelTypePflegeplan == eSelTypePflegeEintrag.IDAufenthaltAbtBereichZeitpunkt)
                {
                    string sWhereBereich = "";
                    if (IDBereich != null)
                    {
                        sWhereBereich = " or IDBereich <> '" + IDBereich.ToString() + "' ";
                    }
                    string sqlWhere = " where IDAufenthalt='" + ID.Value.ToString() + "' and Zeitpunkt>=@Zeitpunkt1 and Zeitpunkt<=@Zeitpunkt2 and (IDAbteilung<>'" + IDAbteilung.Value.ToString() + "' " + sWhereBereich + ") ";
                    string sOrderBy = " order by Zeitpunkt desc";
                    this.daPflegeEintrag.SelectCommand.CommandText += sqlWhere + " " + sOrderBy;

                    OleDbParameter pZeitpunkt1 = new OleDbParameter { ParameterName = "@Zeitpunkt1", OleDbType = OleDbType.Date, Value = dFrom };
                    this.daPflegeEintrag.SelectCommand.Parameters.Add(pZeitpunkt1);

                    OleDbParameter pZeitpunkt2 = new OleDbParameter { ParameterName = "@Zeitpunkt2", OleDbType = OleDbType.Date, Value = dTo};
                    this.daPflegeEintrag.SelectCommand.Parameters.Add(pZeitpunkt2);
                }
                else if (SelTypePflegeplan == eSelTypePflegeEintrag.IDAufenthalt)
                {
                    string sqlWhere = " where IDAufenthalt='" + ID.Value.ToString() + "' ";
                    string sOrderBy = " order by Zeitpunkt desc";
                    this.daPflegeEintrag.SelectCommand.CommandText += sqlWhere + " " + sOrderBy;
                }
                else
                {
                    throw new Exception("sqlPlanungIntervention.getPflegeEintrag: SelTypePflegeplan '" + SelTypePflegeplan.ToString() + "' not supported!");
                }
                this.daPflegeEintrag.Fill(ds.PflegeEintrag);

                return true;
            }
            catch (Exception ex)
            {
                if (PMDS.Global.ENV.checkExceptionDBNetLib3(ex.ToString()) && iFctCalled < 4)
                {
                    iFctCalled += 1;
                    if (iFctCalled >= 3)
                    {
                        Exception exTmp2 = new Exception("sqlPlanungIntervention.getPflegeEintrag: " + iFctCalled.ToString() + "th retry" + "\r\n" + sInfoExcept + "\r\n" + ex.ToString());
                        throw new Exception("sqlPlanungIntervention.getPflegeEintrag: " + exTmp2.ToString());
                    }
                    else
                    {
                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                        return this.getPflegeEintrag(ID, SelTypePflegeplan, ref ds, dFrom, dTo, IDAbteilung, IDBereich, ref iFctCalled);
                    }
                }
                else
                {
                    throw new Exception("sqlPlanungIntervention.getPflegeEintrag: " + ex.ToString());
                }
            }
        }


    }
}
