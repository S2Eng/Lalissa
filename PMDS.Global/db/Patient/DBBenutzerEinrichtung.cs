using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PMDS.Global.db.Patient;
using RBU;



namespace PMDS.DB.Patient
{


    public partial class DBBenutzerEinrichtung : Component
    {

        public static string seldaBenutzerEinrichtung = "";

        public enum eTypSelBenEinrichtung
        {
            IDBenutzer = 0,
            IDEinrichtung = 1
        }

        public DBBenutzerEinrichtung()
        {
            InitializeComponent();
        }

        public DBBenutzerEinrichtung(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        public void initControl()
        {
            DBBenutzerEinrichtung.seldaBenutzerEinrichtung = this.daBenutzerEinrichtung.SelectCommand.CommandText;
        }


        public void getBenutzerEinrichtung(System.Guid ID, dsBenutzerEinrichtung ds, eTypSelBenEinrichtung typSel)
        {
            this.daBenutzerEinrichtung.SelectCommand.CommandText = DBBenutzerEinrichtung.seldaBenutzerEinrichtung;
            this.daBenutzerEinrichtung.SelectCommand.Parameters.Clear();
            PMDS.Global.dbBase.setConnection(this.daBenutzerEinrichtung, DataBase.CONNECTION);

            if (typSel == eTypSelBenEinrichtung.IDBenutzer)
            {
                string sWhere = " where IDBenutzer = ? ";
                this.daBenutzerEinrichtung.SelectCommand.CommandText += sWhere;
                this.daBenutzerEinrichtung.SelectCommand.Parameters.AddWithValue("IDBenutzer", ID);
            }
            else if (typSel == eTypSelBenEinrichtung.IDEinrichtung)
            {
                string sWhere = " where IDEinrichtung = ? ";
                this.daBenutzerEinrichtung.SelectCommand.CommandText += sWhere;
                this.daBenutzerEinrichtung.SelectCommand.Parameters.AddWithValue("IDEinrichtung", ID);
            }
            else
                throw new Exception("getBenutzerEinrichtung: typSel '" + typSel.ToString() + "' not exists!");

            this.daBenutzerEinrichtung.Fill(ds.BenutzerEinrichtung);
        }

        public dsBenutzerEinrichtung.BenutzerEinrichtungRow newRowBenutzerEinrichtung(dsBenutzerEinrichtung ds)
        {
            dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinrichtung = (dsBenutzerEinrichtung.BenutzerEinrichtungRow)ds.BenutzerEinrichtung.NewRow();
            rBenEinrichtung.ID = System.Guid.NewGuid();
            rBenEinrichtung.IDEinrichtung = System.Guid.Empty;
            rBenEinrichtung.IDBenutzer = System.Guid.Empty;
            rBenEinrichtung.Default = false;

            ds.BenutzerEinrichtung.Rows.Add(rBenEinrichtung);
            return rBenEinrichtung;
        }
    }
}
