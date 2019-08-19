//----------------------------------------------------------------------------
/// <summary>
///	16.6.2008 RBU: DBEssen DBLayer Essen
/// </summary>
//----------------------------------------------------------------------------
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
    public partial class DBEssen : Component
    {
        public DBEssen()
        {
            InitializeComponent();
        }

        public DBEssen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsEssen.EssenDataTable Read(DateTime von, DateTime bis)
        {
            dsEssen.EssenDataTable dt = new dsEssen.EssenDataTable();
            daEssen.SelectCommand.Parameters[0].Value = von;
            daEssen.SelectCommand.Parameters[1].Value = bis;
            DataBase.Fill(daEssen, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write(dsEssen.EssenDataTable dt)
        {
            DataBase.Update(daEssen, dt);
        }
    }
}
