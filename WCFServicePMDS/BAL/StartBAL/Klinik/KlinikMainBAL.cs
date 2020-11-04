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

    public class KlinikMainBAL : IKlinikMainBAL
    {



        public KlinikMainBAL()
        {

        }

        public void load(ref DateTime dFrom, Guid IDClient)
        {
            Task t = new KlinikMainBAL().loadAll(dFrom, IDClient);
            t.Wait();
        }

        private async Task loadAll(DateTime dFrom, Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                if (KlinikMainDTO.Klinik == null) KlinikMainDTO.Klinik = new KlinikMainDTO();

                if (KlinikMainDTO.Klinik.lKlinik == null) KlinikMainDTO.Klinik.lKlinik = new ConcurrentDictionary<DateTime, ConcurrentBag<KlinikDTO>>();
                if (KlinikMainDTO.Klinik.ltblSuchtgiftschrankSchlüssel == null) KlinikMainDTO.Klinik.ltblSuchtgiftschrankSchlüssel = new ConcurrentDictionary<DateTime, ConcurrentBag<tblSuchtgiftschrankSchlüsselDTO>>();

                Task<ConcurrentBag<KlinikDTO>> taKlinik = new KlinikDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<tblSuchtgiftschrankSchlüsselDTO>> taSuchtgiftschrankSchlüssel = new  tblSuchtgiftschrankSchlüsselDAL(repoWrapper).getAllAsync(IDClient);

                Task.WaitAll(taKlinik, taSuchtgiftschrankSchlüssel);

                KlinikMainDTO.Klinik.lKlinik.TryAdd(dFrom, taKlinik.Result);
                KlinikMainDTO.Klinik.ltblSuchtgiftschrankSchlüssel.TryAdd(dFrom, taSuchtgiftschrankSchlüssel.Result);
            }
        }

        public static async Task loadAllKlinik(DateTime now)
        {
            if (KlinikMainDTO.lAll == null)
                KlinikMainDTO.lAll = new ConcurrentDictionary<DateTime, ConcurrentBag<KlinikMainDTO.KlinikStream>>();

            ConcurrentBag<KlinikMainDTO.KlinikStream> lKlin = new ConcurrentBag<KlinikMainDTO.KlinikStream>();

            var pairKlinik = KlinikMainDTO.Klinik.lKlinik.OrderByDescending(v => v.Key).First();
            foreach (KlinikDTO klin in pairKlinik.Value)
            {
                KlinikMainDTO.KlinikStream klinstream = new KlinikMainDTO.KlinikStream() { IDKlinik = klin.Id, klinik = new KlinikDTO() };
                PropertyCopier<KlinikDTO, KlinikDTO>.Copy(klin, klinstream.klinik);

                var pairAdress = BenutzerMainDTO.Benutzer1.lAdresse.OrderByDescending(v => v.Key).First();
                if (klinstream.klinik.Idadresse != null) klinstream.adresse = pairAdress.Value.Where(pp => pp.Id == klinstream.klinik.Idadresse).First();

                var pairKontakt = BenutzerMainDTO.Benutzer1.lKontakt.OrderByDescending(v => v.Key).First();
                if (klinstream.klinik.Idkontakt != null) klinstream.kontakt = pairKontakt.Value.Where(pp => pp.Id == klinstream.klinik.Idkontakt).First();

                lKlin.Add(klinstream);
            }

            //BenutzerMainBAL.Benutzer.lBenutzer = new List<KeyValuePair<DateTime, List<BenutzerDTO>>>();
            KlinikMainDTO.lAll.TryAdd(now, lKlin);
        }
    }

}
