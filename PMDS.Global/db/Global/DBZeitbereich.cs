//----------------------------------------------------------------------------
/// <summary>
///	16.6.2008 RBU: DBZeitbereich DBLayer zeitbereich
/// </summary>
//----------------------------------------------------------------------------
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
    public partial class DBZeitbereich : Component
    {
        public DBZeitbereich()
        {
            InitializeComponent();
        }

        public DBZeitbereich(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsZeitbereich.ZeitbereichDataTable Read()
        {
            dsZeitbereich.ZeitbereichDataTable dt = new dsZeitbereich.ZeitbereichDataTable();
            DataBase.Fill(daZeitbereich, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write(dsZeitbereich.ZeitbereichDataTable dt)
        {
            DataBase.Update(daZeitbereich, dt);
        }
    }
}
