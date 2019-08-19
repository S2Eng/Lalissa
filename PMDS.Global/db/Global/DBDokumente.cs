using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    public partial class DBDokumente : Component
    {
        public DBDokumente()
        {
            InitializeComponent();
        }

        public DBDokumente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        

        public void ReadDokument(string sGruppe, Guid IDObject)
        {
            dsDokumente1.Clear();
            daDokumente.SelectCommand.Parameters[0].Value = IDObject;
            daDokumente.SelectCommand.Parameters[1].Value = sGruppe;
            DataBase.Fill(daDokumente, dsDokumente1.Dokumente);
        }

        public dsDokumente.DokumenteDataTable DOKUMENTE
        {
            get
            {
                return dsDokumente1.Dokumente;
            }
        }

        public void Update()
        {
            DataBase.Update(daDokumente, dsDokumente1.Dokumente);
        }


    }
}
