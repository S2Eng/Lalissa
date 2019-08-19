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
    //----------------------------------------------------------------------------
    /// <summary>
    /// DB Zugriff auf die LinkDokumente
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class DBLinkDokumente : Component
    {
        public DBLinkDokumente()
        {
            InitializeComponent();
        }

        public DBLinkDokumente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle in der DB vorhandenen Linkdokumente sortiert nach LinkName
        /// </summary>
        //----------------------------------------------------------------------------
        public dsLinkDokumente.LinkDokumenteDataTable ALL
        {
            get
            {
                dsLinkDokumente.LinkDokumenteDataTable dt = new dsLinkDokumente.LinkDokumenteDataTable();
                DataBase.Fill(daLinkDokumente, dt);
                return dt;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle in der DB vorhandenen Linkdokumente sortiert nach Beschreibung
        /// als ID Liste
        /// </summary>
        //----------------------------------------------------------------------------
        public dsGUIDListe.IDListeDataTable ALL_IDLISTE
        {
            get
            {
                dsGUIDListe.IDListeDataTable dt = new dsGUIDListe.IDListeDataTable();
                DataBase.Fill(daLinkDokumenteIDListeAll, dt);
                return dt;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen Datatable mit ID als Filter. Bei Vorhandenem Datensatz
        /// ist im Datatable ein Eintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public dsLinkDokumente.LinkDokumenteDataTable GetByID(Guid ID)
        {
            dsLinkDokumente.LinkDokumenteDataTable dt = new dsLinkDokumente.LinkDokumenteDataTable();
            daLinkDokumanteByID.SelectCommand.Parameters[0].Value = ID;
            DataBase.Fill(daLinkDokumanteByID, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen in die DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void Update(dsLinkDokumente.LinkDokumenteDataTable dt)
        {
            DataBase.Update(daLinkDokumente, dt);
        }

    }
}
