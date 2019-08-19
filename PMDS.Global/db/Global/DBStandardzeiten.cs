using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    public partial class DBStandardzeiten : Component
    {
        public DBStandardzeiten()
        {
            InitializeComponent();
        }

        public DBStandardzeiten(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsStandardZeiten STANDARDZEITEN
        {
            get { return dsStandardZeiten1; }
        }

        public void Read()
        {
            dsStandardZeiten1.Standardzeiten.Clear();
            DataBase.Fill(daStandardzeiten, dsStandardZeiten1);
        }

        public void Write()
        {
            DataBase.Update(daStandardzeiten, dsStandardZeiten1);
        }
    }
}
