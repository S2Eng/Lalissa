//----------------------------------------------------------------------------
/// <summary>
///	16.6.2008 RBU: DBZeitbereichSerien DBLayer zeitbereich
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
    public partial class DBZeitbereichSerien : Component
    {
        public DBZeitbereichSerien()
        {
            InitializeComponent();
        }

        public DBZeitbereichSerien(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsZeitbereichSerien.ZeitbereichSerienDataTable Read()
        {
            dsZeitbereichSerien.ZeitbereichSerienDataTable dt = new dsZeitbereichSerien.ZeitbereichSerienDataTable();
            DataBase.Fill(daZeitbereichSerien, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write(dsZeitbereichSerien.ZeitbereichSerienDataTable dt)
        {
            DataBase.Update(daZeitbereichSerien, dt);
        }
    }
}
