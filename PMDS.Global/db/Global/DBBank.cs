using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.OleDb;
using RBU;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    public partial class DBBank : DBBase,  IDBBase
    {
        public DBBank()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Adapter zur Ermittlung bestimmter Eintrags.
        /// </summary>
        //----------------------------------------------------------------------------
        protected override OleDbDataAdapter daFilterEntry
        {
            get { return daBankByID; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Neuen ZusatzEintrag erzeugen.
        /// </summary>
        //----------------------------------------------------------------------------
        public override void New()
        {
            ITEM.Clear();
            ITEM.AddBankRow(Guid.NewGuid(), "", 0, 0, "", "", System.Guid.Empty);
        }
        public dsBank.BankRow loadBankKlinik(System.Guid IDAdresse, bool doExceptionNoKlinikFound)
        {
            dsBank.BankDataTable dtBankKlinik = new dsBank.BankDataTable();
            this.daBankIDKlinik.SelectCommand.Parameters[0].Value = IDAdresse;
            RBU.DataBase.Fill(this.daBankIDKlinik, dtBankKlinik);
            if (dtBankKlinik.Rows.Count != 1)
            {
                if (doExceptionNoKlinikFound)
                    throw new Exception("loadBankKlinik: dtBankKlinik.Rows.Count != 1 for IDKlinik '" + IDAdresse.ToString() + "'!");
                else
                    return null;
            }
            return (dsBank.BankRow)dtBankKlinik.Rows[0];
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenTabelle liefern
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual dsBank.BankDataTable ITEM
        {
            get { return dsBank1.Bank; }
        }

        #region IDBBase Members

        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenTabelle liefern
        /// </summary>
        //----------------------------------------------------------------------------
        DataTable IDBBase.ITEM
        {
            get { return this.ITEM; }
        }

        #endregion
    }
}
