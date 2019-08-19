using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RBU;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// Zugriff und speicherung auf die Medizinischen Typen
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class DBMedizinischeTypen : Component
    {
        public DBMedizinischeTypen()
        {
            InitializeComponent();
        }

        public DBMedizinischeTypen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsMedizinischeTypen.MedizinischeTypenDataTable ALL
        {
            get
            {
                dsMedizinischeTypen ds = new dsMedizinischeTypen();
                DataBase.Fill(daMedizinischeTypen, ds);
                return ds.MedizinischeTypen;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Datarow zum Typ
        /// </summary>
        //----------------------------------------------------------------------------
        public dsMedizinischeTypen.MedizinischeTypenRow GetFromTyp(int MedizinischerTyp)
        {
            dsMedizinischeTypen.MedizinischeTypenDataTable dt = new dsMedizinischeTypen.MedizinischeTypenDataTable();
            daMedizinischeTypenByTyp.SelectCommand.Parameters[0].Value = MedizinischerTyp;
            DataBase.Fill(daMedizinischeTypenByTyp, dt);
            
            
            // Für den Spezialtyp kann es sein dass kein Datensatz existiert ==> einen temporären einfügen
            if (MedizinischerTyp == 999 && dt.Rows.Count == 0)
            {
                dsMedizinischeTypen.MedizinischeTypenRow r = dt.AddMedizinischeTypenRow(Guid.NewGuid(), 5, 999, "", new byte[] { }, new byte[] { }, true);
                r.SetIconNull();
                r.SetIconOFFNull();
                dt.AcceptChanges();
            }
            
            return dt[0];
        }

        public void Update(dsMedizinischeTypen.MedizinischeTypenDataTable dt)
        {
            DataBase.Update(daMedizinischeTypen, dt);
        }

    }
}
