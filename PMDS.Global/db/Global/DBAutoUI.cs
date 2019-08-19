using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{


    public partial class DBAutoUI : Component
    {

        public DBAutoUI()
        {
            InitializeComponent();
        }

        public DBAutoUI(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }





        public bool getAutoUI(dsVerwaltung ds, string DbTable)
        {
            this.daUIDefinitionsByDBTable.SelectCommand.Parameters[0].Value = DbTable.Trim();
            DataBase.Fill(daUIDefinitionsByDBTable, ds.tblUIDefinitions);
            return true;
        }

    }
}
