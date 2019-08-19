using System;
using System.Collections.Generic;
using System.Text;

namespace PMDS.Global
{
    public class Ansichtinfo
    {
        public TerminlisteAnsichtsmodi  Ansichtsmodus       = TerminlisteAnsichtsmodi.Klientanansicht;
        public Guid                     IDAbteilung         = Guid.Empty;
        public Guid                     IDBereich           = Guid.Empty;
        public Guid                     IDKlinik            = Guid.Empty;


        public void InitFieldsxy()
        {
            IDAbteilung = Guid.Empty;
            IDBereich = Guid.Empty;
            IDKlinik = Guid.Empty;
        }

    }



}
