using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;
using System.Linq;



namespace PMDS.DB.Global
{


    public partial class DBAerzte : Component
    {




        public DBAerzte()
        {
            InitializeComponent();
        }

        public DBAerzte(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsAerzte Aerzte
        {
            get { return dsAerzte1; }
        }

        public void Read()
        {
            dsAerzte1.Aerzte.Clear();
            DataBase.Fill(daAerzte, dsAerzte1.Aerzte);
        }

        public dsAerzte.AerzteRow New()
        {
            dsAerzte.AerzteRow r = dsAerzte1.Aerzte.NewAerzteRow();
            r.ID = Guid.NewGuid();
            dsAerzte1.Aerzte.AddAerzteRow(r);
            return r;
        }

        public dsAerzte AerzteByPatient(Guid IDPatient)
        {
            dsAerzte2.Aerzte.Clear();
            daAerzteByPatient.SelectCommand.Parameters[0].Value = IDPatient;
            DataBase.Fill(daAerzteByPatient, dsAerzte2.Aerzte);
            return dsAerzte2;
        }
        public dsAerzte AerzteByID(Guid ID)
        {
            dsAerzte2.Aerzte.Clear();
            PMDS.Global.dbBase.setConnection(this.daAerzteByID, RBU.DataBase.CONNECTION);
            this.daAerzteByID.SelectCommand.Parameters[0].Value = ID;
            daAerzteByID.Fill (dsAerzte2.Aerzte);
            return dsAerzte2;
        }
        public void Write()
        {
            DataBase.Update(daAerzte, dsAerzte1);
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn bereits einmal ein Rezept erstellt wurde
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool IsRezeptErstellt(Guid IDPatient, Guid IDAerzte)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    int iRezepteerstellt = (from re in db.RezeptEintrag 
                                            join a in db.Aufenthalt on re.IDAufenthalt equals a.ID
                                            where a.IDPatient == IDPatient && re.IDAerzte == IDAerzte
                                            select re.ID).Count();
                    return (iRezepteerstellt > 0 ? true : false);                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("IsRezeptErstellt: " + ex.ToString());
            }
        }

        public static dsAerzte.AerzteRow GetArztDetails(Guid IDArzt)
        {
            dsAerzte aerzte = new dsAerzte();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            cmd.CommandText = "SELECT ID, IDAdresse, IDKontakt, Titel, Nachname, Vorname, Fachrichtung FROM Aerzte Where ID=?";
            da.SelectCommand.Parameters.AddWithValue("ID", IDArzt);
            DataBase.Fill(da, aerzte.Aerzte);

            if(aerzte.Aerzte.Count == 0)
                throw new Exception("Kein Arzt wurde gefunden. DBArzte::GetArztDetails");

            return aerzte.Aerzte[0];
        }

        public static string GetArztName(Guid IdArzt)
        {
            PMDS.db.Entities.Aerzte Arzt = PMDS.DB.DBUtil.GetArzt(IdArzt);
            return Arzt.Nachname.Trim() + " " + Arzt.Vorname.Trim();
        }
    }
}
