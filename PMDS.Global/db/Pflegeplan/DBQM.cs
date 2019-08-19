//----------------------------------------------------------------------------------------------
//	DBQM.cs
//  Klasse zum lesen der Informationen für die QuickMeldungsButtons
//  Erstellt am:	18.4.2008
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using RBU;
using PMDS.Data.Global;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
    public partial class DBQM : Component
    {
        public DBQM()
        {
            InitializeComponent();
        }

        public DBQM(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert die aktuellen einträge zur jeweiligen Gruppe gruppiert nach 
        /// IDUntertägigeGruppe, IDEintrag,  Startdatum
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPflegePlan.PflegePlanDataTable Read(Guid IDAufenhalt, EintragGruppe gruppe)
        {
            dsPflegePlan.PflegePlanDataTable dt = new dsPflegePlan.PflegePlanDataTable();
            daPflegePlanByAufenthalt_Gruppe.SelectCommand.Parameters[0].Value = IDAufenhalt;
            daPflegePlanByAufenthalt_Gruppe.SelectCommand.Parameters[1].Value = gruppe.ToString();
            DataBase.Fill(daPflegePlanByAufenthalt_Gruppe, dt);  //lth -> Anpassen wie PMDS-Interventionen  --> vionterventionen aus PMDSBusisness
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert alle Zusatzwerte zu einem Eintrag (M)
        /// Die verscheidenen Typen sind in ZusatzEintragTyp geregelt
        /// Gefiltert werden nicht der Abteilung zugehörigen Swoie die Images und Labels
        /// </summary>
        //----------------------------------------------------------------------------
        public dsZusatzwerteForEintrag.ZusatzEintragDataTable GetZusatzwerte(Guid IDEintrag, Guid IDAbteilung)
        {
            dsZusatzwerteForEintrag.ZusatzEintragDataTable dt = new dsZusatzwerteForEintrag.ZusatzEintragDataTable();
            daZusatzwerteForEintrag.SelectCommand.Parameters[0].Value = IDEintrag;
            DataBase.Fill(daZusatzwerteForEintrag, dt);
            List<dsZusatzwerteForEintrag.ZusatzEintragRow> al = new List<dsZusatzwerteForEintrag.ZusatzEintragRow>();
            foreach (dsZusatzwerteForEintrag.ZusatzEintragRow r in dt)
            {
                if (r.IDAbteilung == Guid.Empty)                            // Generelle Abteilung immer drinnen lassen
                    continue;
                if (r.IDAbteilung != IDAbteilung)                           // Die nicht zur Abteilung gehörenden FIltern
                {
                    al.Add(r);
                    continue;
                }

                if (r.Typ == (int)ZusatzEintragTyp.IMAGE || r.Typ == (int)ZusatzEintragTyp.LABEL)       // Image und label nicht bei Zusatzwerte in der BigRM
                    al.Add(r);

            }

            foreach (dsZusatzwerteForEintrag.ZusatzEintragRow rdel in al)
                rdel.Delete();
            dt.AcceptChanges();

            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Schreibt den Datatable gegen die DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void WriteZusatzWerte(dsZusatzWert.ZusatzWertDataTable dt)
        {
            DataBase.Update(daZusatzWert, dt);
        }
    }
}
