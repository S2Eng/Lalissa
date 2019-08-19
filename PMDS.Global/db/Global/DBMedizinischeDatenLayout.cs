using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Global;
using RBU;

namespace PMDS.DB.Global
{
    public partial class DBMedizinischeDatenLayout : Component
    {


        public DBMedizinischeDatenLayout()
        {
            InitializeComponent();
        }

        public DBMedizinischeDatenLayout(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }





        public PMDS.Global.db.Global.dsMedizinischeDatenLayout ALL
        {
            get { return dsMedizinischeDatenLayout1; }
        }



        public void Read()
        {
            dsMedizinischeDatenLayout1.MedizinischeDatenLayout.Rows.Clear();
            DataBase.Fill(daMedizinischeDatenLayout, dsMedizinischeDatenLayout1.MedizinischeDatenLayout);
        }

        public PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow ReadByType(int iMedizinischerTyp)
        {
            PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutDataTable dt = new PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutDataTable();
            daMedizinischeDatenLayoutByType.SelectCommand.Parameters[0].Value = iMedizinischerTyp;
            DataBase.Fill(daMedizinischeDatenLayoutByType, dt);
            if (dt.Count > 1)
                throw new Exception("DBMedizinischeDatenLayout::ReadByType() - mehr als ein datensatz gefunden für Wert:" + iMedizinischerTyp.ToString());
            if (dt.Count == 0)
                return null;
            return dt[0];
        }

        public void New(int medTyp)
        {
            PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow r = dsMedizinischeDatenLayout1.MedizinischeDatenLayout.NewMedizinischeDatenLayoutRow();
            r.MedizinischerTyp = (int)medTyp;
            dsMedizinischeDatenLayout1.MedizinischeDatenLayout.AddMedizinischeDatenLayoutRow(r);
        }

        public void Write()
        {
            DataBase.Update(daMedizinischeDatenLayout, dsMedizinischeDatenLayout1);
        }

    }

}
