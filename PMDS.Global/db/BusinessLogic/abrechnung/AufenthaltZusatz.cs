using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Calc.Admin.DB;
using PMDS.Abrechnung.Global;

namespace PMDS.BusinessLogic.Abrechnung
{
    public  class AufenthaltZusatz
    {
        private DBAufenthaltZusatz _db = new DBAufenthaltZusatz();

        public AufenthaltZusatz()
        {

        }

        /// <summary>
        /// Aufenthalszusatzinformationen für ein Aufenthal zurückgeben
        /// </summary>
        /// <param name="IDAufenthalt"></param>
        /// <returns></returns>
        public dsAufenthaltZusatz ReadByAufenthalt(Guid IDAufenthalt)
        {
            return _db.ReadByAufenthalt(IDAufenthalt);
        }

        /// <summary>
        /// Daten in Datenbank speichern
        /// </summary>
        /// <param name="ds"></param>
        public void Update(dsAufenthaltZusatz dsalt, AufenthaltZusatzMode mode)
        {
            //Änderung nach 04.09.2008 MDA
            if (dsalt.AufenthaltZusatz.Count == 0) return;
            Guid IDAufenthalt       = dsalt.AufenthaltZusatz[0].IDAufenthalt;
            AufenthaltZusatz z      = new AufenthaltZusatz();
            dsAufenthaltZusatz ds   = z.ReadByAufenthalt(IDAufenthalt);
            dsAufenthaltZusatz.AufenthaltZusatzRow ralt = dsalt.AufenthaltZusatz[0];
            dsAufenthaltZusatz.AufenthaltZusatzRow r;

            if (ds.AufenthaltZusatz.Count == 0)
                r = New(ds, IDAufenthalt);
            else
                r = ds.AufenthaltZusatz[0];
            
            switch (mode)
            {
                case AufenthaltZusatzMode.Taschengeld:
                    r.MinSaldo = ralt.MinSaldo;
                    r.OffeneRechnungJN = ralt.OffeneRechnungJN; //OffeneRechnungJN übernehmen
                    break;
                case AufenthaltZusatzMode.Klient:
                    r.SozialhilfeBescheidJN = ralt.SozialhilfeBescheidJN;
                    if (!ralt.IsSozialhilfeAntragDatumNull())
                        r.SozialhilfeAntragDatum = ralt.SozialhilfeAntragDatum;
                    else
                        r.SetSozialhilfeAntragDatumNull();
                    r.SozialhilfeBescheidGZ = ralt.SozialhilfeBescheidGZ;
                    r.Zimmernummer = ralt.Zimmernummer;
                    r.OffeneRechnungJN = ralt.OffeneRechnungJN;
                    r.SozialhilfeBescheidGZ = ralt.SozialhilfeBescheidGZ;
                    break;
                default:
                    break;
            }
            _db.Update(ds);
        }

        public dsAufenthaltZusatz.AufenthaltZusatzRow New(dsAufenthaltZusatz ds, Guid IDAufenthalt)
        {
            dsAufenthaltZusatz.AufenthaltZusatzRow r = ds.AufenthaltZusatz.AddAufenthaltZusatzRow(Guid.NewGuid(), IDAufenthalt, "", DateTime.Now, false, 0.0, false, "");
            r.SetSozialhilfeAntragDatumNull();
            return r;
        }
    }

    public enum AufenthaltZusatzMode
    {
        Taschengeld,
        Klient
    }
}
