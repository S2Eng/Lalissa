using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Abrechnung.Global;
using RBU;



namespace PMDS.Calc.Admin.DB
{
    public partial class DBAufenthaltZusatz : Component
    {
        public DBAufenthaltZusatz()
        {
            InitializeComponent();
        }

        public DBAufenthaltZusatz(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Aufenthalszusatzinformationen für ein Aufenthal zurückgeben
        /// </summary>
        /// <param name="IDAufenthalt"></param>
        /// <returns></returns>
        public dsAufenthaltZusatz ReadByAufenthalt(Guid IDAufenthalt)
        {
            dsAufenthaltZusatz ds = new dsAufenthaltZusatz();
            daByAufenthalt.SelectCommand.Parameters[0].Value = IDAufenthalt;
            DataBase.Fill(daByAufenthalt, ds.AufenthaltZusatz);
            return ds;
        }

        /// <summary>
        /// Daten in Datenbank speichern
        /// </summary>
        /// <param name="ds"></param>
        public void Update(dsAufenthaltZusatz ds)
        {
            DataBase.Update(daAufenthaltZusatz, ds.AufenthaltZusatz);
        }
    }
}
