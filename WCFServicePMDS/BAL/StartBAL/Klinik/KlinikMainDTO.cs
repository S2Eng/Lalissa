using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.BAL.Main.Interfaces;
using System.Collections.Concurrent;

namespace WCFServicePMDS.BAL.Main
{

    public class KlinikMainDTO
    {
        private static KlinikMainDTO _Klinik;

        public static KlinikMainDTO Klinik
        {
            get => _Klinik;
            set => _Klinik = value;
        }



        private static ConcurrentDictionary<DateTime, ConcurrentBag<KlinikStream>> _lAll;
        public static ConcurrentDictionary<DateTime, ConcurrentBag<KlinikStream>> lAll
        {
            get => _lAll;
            set => _lAll = value;
        }


        public class KlinikStream
        {
            public Guid IDKlinik;
            public KlinikDTO klinik;
            public AdresseDTO adresse;
            public KontaktDTO kontakt;
        }


        private ConcurrentDictionary<DateTime, ConcurrentBag<KlinikDTO>> _lKlinik;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblSuchtgiftschrankSchlüsselDTO>> _ltblSuchtgiftschrankSchlüssel;


        public ConcurrentDictionary<DateTime, ConcurrentBag<KlinikDTO>> lKlinik
        {
            get => _lKlinik;
            set => _lKlinik = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblSuchtgiftschrankSchlüsselDTO>> ltblSuchtgiftschrankSchlüssel
        {
            get => _ltblSuchtgiftschrankSchlüssel;
            set => _ltblSuchtgiftschrankSchlüssel = value;
        }

    }

}
