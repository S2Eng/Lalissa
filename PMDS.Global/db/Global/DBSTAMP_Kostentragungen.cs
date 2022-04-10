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
using PMDS.Global;

namespace PMDS.DB.Global
{
    public partial class DBSTAMP_Kostentragungen : Component
    {
        public DBSTAMP_Kostentragungen()
        {
            InitializeComponent();
        }

        public DBSTAMP_Kostentragungen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsSTAMP_Kostentragungen.STAMP_KostentragungenDataTable Read(Guid IDAufenthalt)
        {
            dsSTAMP_Kostentragungen.STAMP_KostentragungenDataTable dt = new dsSTAMP_Kostentragungen.STAMP_KostentragungenDataTable();
            daSTAMP_Kostentragungen.SelectCommand.Parameters[0].Value = IDAufenthalt;
            DataBase.Fill(daSTAMP_Kostentragungen, dt);
            return dt;
        }

        public void Write(dsSTAMP_Kostentragungen.STAMP_KostentragungenDataTable dt)
        {            
            DataBase.Update(daSTAMP_Kostentragungen, dt);
        }
    }
}
