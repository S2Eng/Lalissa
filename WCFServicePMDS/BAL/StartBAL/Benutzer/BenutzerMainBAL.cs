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
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Net.Sockets;

namespace WCFServicePMDS.BAL.Main
{

    public class BenutzerMainBAL : IBenutzerMainBAL
    {
        public static bool ready { get; set; }



        public BenutzerMainBAL()
        {

        }


        public BenutzerMainDTO newInstanz()
        {
            BenutzerMainDTO ben = new BenutzerMainDTO();

            ben.lBenutzer = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerDTO>>();
            ben.lAdresse = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AdresseDTO>>();
            ben.lKontakt = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<KontaktDTO>>();
            ben.lBenutzerEinrichtung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerEinrichtungDTO>>();
            ben.lBenutzerRechte = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerRechteDTO>>();
            ben.lBenutzerAbteilung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerAbteilungDTO>>();
            ben.lBenutzerBezug = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerBezugDTO>>();
            ben.lBenutzerGruppe = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerGruppeDTO>>();
            ben.lBereichBenutzer = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BereichBenutzerDTO>>();
            ben.lGruppe = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<GruppeDTO>>();
            ben.lGruppenRecht = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<GruppenRechtDTO>>();
            ben.lRecht = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<RechtDTO>>();
            ben.lBereich = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BereichDTO>>();
            ben.lDienstzeiten = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<DienstzeitenDTO>>();
            ben.lAbteilung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>>();
            ben.lStandardzeiten = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<StandardzeitenDTO>>();
            ben.lBank = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BankDTO>>();
            ben.lBelegung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BelegungDTO>>();
            ben.lKlinik = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<KlinikDTO>>();
            ben.lAerzte = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AerzteDTO>>();


            return ben;
        }

        public List<BenutzerMainDTO.BenutzerDt> load(ref DateTime dFrom, Guid IDClient)
        {
            Task t = new BenutzerMainBAL().loadAll(dFrom, IDClient);
            t.Wait();

            Task tKlin = KlinikMainBAL.loadAllKlinik(dFrom);
            Task tBen = this.loadBen(dFrom);
            tKlin.Wait();
            tBen.Wait();

            var valPair = BenutzerMainDTO.lAll.OrderByDescending(v => v.Key).First();
            return valPair.Value;
        }

        public async Task loadAll(DateTime dFrom, Guid IDClient)
        {
            new BAL.Main.KlinikMainBAL().load(ref dFrom, IDClient);

            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                if (BenutzerMainDTO.Benutzer1 == null) BenutzerMainDTO.Benutzer1 = newInstanz();


                Task<ConcurrentBag<BenutzerDTO>> taBenutzer = new BenutzerDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<AdresseDTO>> taAdresses = new AdresseDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<KontaktDTO>> taKontakte = new KontaktDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BenutzerEinrichtungDTO>> taBenutzerEinrichtung = new BenutzerEinrichtungDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BenutzerRechteDTO>> taBenutzerRechte = new BenutzerRechteDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BenutzerAbteilungDTO>> taBenutzerAbteilung = new BenutzerAbteilungDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BenutzerBezugDTO>> taBenutzerBezug = new BenutzerBezugDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BenutzerGruppeDTO>> taBenutzerGruppe = new BenutzerGruppeDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BereichBenutzerDTO>> taBereichBenutzer = new BereichBenutzerDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<GruppeDTO>> taGruppe = new GruppeDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<GruppenRechtDTO>> taGruppenRecht = new GruppenRechtDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<RechtDTO>> taRecht = new RechtDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BereichDTO>> taBereich = new BereichDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<DienstzeitenDTO>> taDienstzeiten = new DienstzeitenDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<AbteilungDTO>> taAbteilung = new AbteilungDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<StandardzeitenDTO>> taStandardzeiten = new StandardzeitenDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BankDTO>> taBank = new BankDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<BelegungDTO>> taBelegung = new BelegungDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<KlinikDTO>> taKlinik = new KlinikDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<AerzteDTO>> taAerzte = new AerzteDAL(repoWrapper).getAllAsync(IDClient);
                //Dokumente ?


                Task.WaitAll(taBenutzer, taAdresses, taKontakte, taBenutzerEinrichtung, taBenutzerRechte, taBenutzerAbteilung, taBenutzerBezug, taBenutzerGruppe, taBereichBenutzer, 
                                taGruppe, taGruppenRecht, taRecht, taBereich, taDienstzeiten, taAbteilung, taStandardzeiten, taBank, taBelegung, taKlinik, taAerzte);

                BenutzerMainDTO.Benutzer1.lBenutzer.TryAdd(dFrom, taBenutzer.Result);
                BenutzerMainDTO.Benutzer1.lAdresse.TryAdd(dFrom, taAdresses.Result);
                BenutzerMainDTO.Benutzer1.lKontakt.TryAdd(dFrom, taKontakte.Result);
                BenutzerMainDTO.Benutzer1.lBenutzerEinrichtung.TryAdd(dFrom, taBenutzerEinrichtung.Result);
                BenutzerMainDTO.Benutzer1.lBenutzerRechte.TryAdd(dFrom, taBenutzerRechte.Result);
                BenutzerMainDTO.Benutzer1.lBenutzerAbteilung.TryAdd(dFrom, taBenutzerAbteilung.Result);
                BenutzerMainDTO.Benutzer1.lBenutzerBezug.TryAdd(dFrom, taBenutzerBezug.Result);
                BenutzerMainDTO.Benutzer1.lBenutzerGruppe.TryAdd(dFrom, taBenutzerGruppe.Result);
                BenutzerMainDTO.Benutzer1.lBereichBenutzer.TryAdd(dFrom, taBereichBenutzer.Result);
                BenutzerMainDTO.Benutzer1.lGruppe.TryAdd(dFrom, taGruppe.Result);
                BenutzerMainDTO.Benutzer1.lGruppenRecht.TryAdd(dFrom, taGruppenRecht.Result);
                BenutzerMainDTO.Benutzer1.lRecht.TryAdd(dFrom, taRecht.Result);
                BenutzerMainDTO.Benutzer1.lBereich.TryAdd(dFrom, taBereich.Result);
                BenutzerMainDTO.Benutzer1.lDienstzeiten.TryAdd(dFrom, taDienstzeiten.Result);
                BenutzerMainDTO.Benutzer1.lAbteilung.TryAdd(dFrom, taAbteilung.Result);
                BenutzerMainDTO.Benutzer1.lStandardzeiten.TryAdd(dFrom, taStandardzeiten.Result);
                BenutzerMainDTO.Benutzer1.lBank.TryAdd(dFrom, taBank.Result);
                BenutzerMainDTO.Benutzer1.lBelegung.TryAdd(dFrom, taBelegung.Result);
                BenutzerMainDTO.Benutzer1.lKlinik.TryAdd(dFrom, taKlinik.Result);
                BenutzerMainDTO.Benutzer1.lAerzte.TryAdd(dFrom, taAerzte.Result);
            }
        }

        public async Task loadBen(DateTime now)
        {
            ConcurrentBag<AbteilungDTO> lAbteilungen = Lists.getFirstFromDictConcBag<AbteilungDTO>(BenutzerMainDTO.Benutzer1.lAbteilung);
            ConcurrentBag<AdresseDTO> lAdresse = Lists.getFirstFromDictConcBag<AdresseDTO>(BenutzerMainDTO.Benutzer1.lAdresse);
            ConcurrentBag<KontaktDTO> lKontakt = Lists.getFirstFromDictConcBag<KontaktDTO>(BenutzerMainDTO.Benutzer1.lKontakt);
            ConcurrentBag<AerzteDTO> lAerzte = Lists.getFirstFromDictConcBag<AerzteDTO>(BenutzerMainDTO.Benutzer1.lAerzte);
            ConcurrentBag<BenutzerRechteDTO> lBenRechte = Lists.getFirstFromDictConcBag<BenutzerRechteDTO>(BenutzerMainDTO.Benutzer1.lBenutzerRechte);
            ConcurrentBag<RechtDTO> lRechte = Lists.getFirstFromDictConcBag<RechtDTO>(BenutzerMainDTO.Benutzer1.lRecht);
            ConcurrentBag<BereichDTO> lBereiche = Lists.getFirstFromDictConcBag<BereichDTO>(BenutzerMainDTO.Benutzer1.lBereich);
            ConcurrentBag<BereichBenutzerDTO> lBereichBen = Lists.getFirstFromDictConcBag<BereichBenutzerDTO>(BenutzerMainDTO.Benutzer1.lBereichBenutzer);
            ConcurrentBag<BenutzerAbteilungDTO> lBenAbteilung = Lists.getFirstFromDictConcBag<BenutzerAbteilungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerAbteilung);
            ConcurrentBag<KlinikDTO> lKlinik = Lists.getFirstFromDictConcBag<KlinikDTO>(BenutzerMainDTO.Benutzer1.lKlinik);
            ConcurrentBag<BenutzerEinrichtungDTO> lBenEinrichtung = Lists.getFirstFromDictConcBag<BenutzerEinrichtungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerEinrichtung);

            if (BenutzerMainDTO.lAll == null)
                BenutzerMainDTO.lAll = new ConcurrentDictionary<DateTime, List<BenutzerMainDTO.BenutzerDt>>();

            //List<Task> tasks = new List<Task>();
            List<BenutzerMainDTO.BenutzerDt> lBen = new List<BenutzerMainDTO.BenutzerDt>();
            var pairBen = BenutzerMainDTO.Benutzer1.lBenutzer.OrderByDescending(v => v.Key).First();
            foreach (BenutzerDTO ben in pairBen.Value)
            {
                string name = ben.Nachname.Trim();
                if (ben.Nachname.Trim() == "Neu...")
                {
                    bool bStop = true;
                }
                try
                {
                    BenutzerMainDTO.BenutzerDt benstream = new BenutzerMainDTO.BenutzerDt() { IDBenutzer = ben.Id, ben = new BenutzerDTO(), DtoFrom = pairBen.Key };
                    PropertyCopier<BenutzerDTO, BenutzerDTO>.Copy(ben, benstream.ben);
                    //benstream.ben = ben;

                    var taBenAdrKont = new Task(() =>
                    {
                        //Kontakt, Adresse

                        if (benstream.ben.Idkontakt != null) benstream.kontakt = lKontakt.Where(o => o.Id == benstream.ben.Idkontakt).First();
                        if (benstream.ben.Idberufsstand != null) AuswahlListeBAL.auswahlliste("BER", benstream.ben.Idberufsstand.Value);

                        if (benstream.ben.Idarzt != null)       //Arzt
                        {
                            benstream.aerzt = new BenutzerMainDTO.AerztDt() { DtoFrom = pairBen.Key };

                            List<AerzteDTO> lAerzte2 = lAerzte.Where(o => o.Id == benstream.ben.Idarzt).ToList();
                            if (lAerzte2.Count() > 0)
                            {
                                benstream.aerzt.aerzt = lAerzte.First();
                                if (benstream.aerzt.aerzt.Idadresse != null) benstream.aerzt.adresse = lAdresse.Where(o => o.Id == benstream.aerzt.aerzt.Idadresse.Value).First();
                                if (benstream.aerzt.aerzt.Idkontakt != null) benstream.aerzt.kontakt = lKontakt.Where(o => o.Id == benstream.aerzt.aerzt.Idkontakt.Value).First();
                            }
                        }
                    });
                    taBenAdrKont.Start();

                    var taRechte = new Task(() =>
                    {
                        //Recht Benutzer
                        benstream.recht = new BenutzerMainDTO.RechtDt() { DtoFrom = pairBen.Key };
                        benstream.recht.benutzerRechte = lBenRechte.Where(pp => pp.Idbenutzer == benstream.ben.Id).ToList();
                        benstream.recht.recht = (from r in lRechte
                                                 join br in lBenRechte
                                                 on r.Id equals br.Idrecht
                                                 where br.Idbenutzer == benstream.ben.Id
                                                 select new RechtDTO { Id = r.Id, Bezeichnung = r.Bezeichnung, Elga = r.Elga }).ToList();

                        //Recht Bereiche
                        benstream.lBereich = new List<BenutzerMainDTO.BereichDt>();
                        var lBereich = (from bb in lBereichBen
                                        join b in lBereiche
                                        on bb.Idbereich equals b.Id
                                        where bb.Idbenutzer == benstream.ben.Id
                                        orderby b.Reihenfolge ascending
                                        select b).ToList();
                        foreach (BereichDTO ber in lBereich)
                        {
                            BenutzerMainDTO.BereichDt berStr = new BenutzerMainDTO.BereichDt() { bereich2 = ber, DtoFrom = pairBen.Key };
                            if (benstream.lBereich.Count() < 50000)
                            {
                                benstream.lBereich.Add(berStr);
                                if (ber.Idabteilung != null)
                                {
                                    AbteilungDTO abt = lAbteilungen.Where(o => o.Id == ber.Idabteilung).First();
                                    berStr.abteilung2 = abt;
                                }
                            }
                        }
                    });
                    taRechte.Start();

                    var taAbt = new Task(() =>
                    {
                        //Recht Abteilungen
                        benstream.lAbteilung = new List<BenutzerMainDTO.AbteilungDt>();
                        var lAbteilung = (from ba in lBenAbteilung
                                          join a in lAbteilungen
                                          on ba.Idabteilung equals a.Id
                                          where ba.Idbenutzer == benstream.ben.Id
                                          orderby a.Reihenfolge ascending
                                          select a).ToList();
                        foreach (AbteilungDTO abt in lAbteilung)
                            benstream.lAbteilung.Add(new BenutzerMainDTO.AbteilungDt() { abteilung = abt, DtoFrom = pairBen.Key });
                    });
                    taAbt.Start();

                    var taEinr = new Task(() =>
                    {
                        //Klinik Benutzer
                        benstream.lKlinik = new List<BenutzerMainDTO.KlinikDt>();
                        var benEinrichtung = lBenEinrichtung.Where(o => o.Idbenutzer == benstream.ben.Id);
                        foreach (var rBenEinricht in benEinrichtung)
                        {
                            benstream.lKlinik.Add(new BenutzerMainDTO.KlinikDt() { klinik = lKlinik.Where(o => o.Id == rBenEinricht.Ideinrichtung).First(), DtoFrom = pairBen.Key }); ;
                        }
                    });
                    taEinr.Start();

                    //tasks.Add(taBenAdrKont); tasks.Add(taAbt); tasks.Add(taEinr);
                    await Task.WhenAll(taBenAdrKont, taAbt, taRechte, taEinr);
                    Exceptions.checkFault(new List<Task>() { taBenAdrKont, taRechte, taRechte });

                    lBen.Add(benstream);
                }
                catch (Exception ex)
                {
                    throw new Exception("loadBen foreach: Error user '" + ben.Nachname.Trim() + "'\r\n" + ex.ToString()); ;
                }
            }

            //Task.WaitAll(tasks.ToArray());
            BenutzerMainDTO.lAll.TryAdd(now, lBen);

            var dBen = BenutzerMainDTO.lAll.OrderByDescending(v => v.Key).First();
            List<BenutzerMainDTO.BenutzerDt> benSer = dBen.Value;

            //BenutzerMainDTO.lastBenListSer = WCFServicePMDS.Repository.serialize.Serialize<List<BenutzerMainDTO.BenutzerDt>>(benSer);
            //List<BenutzerMainDTO.BenutzerDt> benDes = WCFServicePMDS.Repository.serialize.Deserialize<List<BenutzerMainDTO.BenutzerDt>>(BenutzerMainDTO.lastBenListSer);
            //int iSize = System.Text.ASCIIEncoding.Unicode.GetByteCount(BenutzerMainDTO.lastBenListSer);

            BenutzerMainDTO.lastBenListSerB = WCFServicePMDS.Repository.serialize.BinarySerialize<List<BenutzerMainDTO.BenutzerDt>>(benSer);
            List<BenutzerMainDTO.BenutzerDt> sBenDes = (List<BenutzerMainDTO.BenutzerDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(BenutzerMainDTO.lastBenListSerB);

            BenutzerMainDTO.lastBenutzer tLastBen = this.loadLastBenutzer();
            BenutzerMainBAL.ready = true;

            //BenutzerMainDTO.lastBenListSer = SerializeToXml(benSer);
            //List<BenutzerMainDTO.BenutzerDt> benDeser = DeserializeFromXML(BenutzerMainDTO.lastBenListSer);

            //serialize
            //var aSerializer = new XmlSerializer(typeof(List<BenutzerMainDTO.BenutzerDt>));
            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);
            //aSerializer.Serialize(sw, benSer);
            //BenutzerMainDTO.lastBenListSer = sw.GetStringBuilder().ToString();
            //int sizeOfVariable = System.Text.ASCIIEncoding.Unicode.GetByteCount(BenutzerMainDTO.lastBenListSer);
        }
        public async Task loadBen2(DateTime now)
        {
            ConcurrentBag<AbteilungDTO> lAbteilungen = Lists.getFirstFromDictConcBag<AbteilungDTO>(BenutzerMainDTO.Benutzer1.lAbteilung);
            ConcurrentBag<AdresseDTO> lAdresse = Lists.getFirstFromDictConcBag<AdresseDTO>(BenutzerMainDTO.Benutzer1.lAdresse);
            ConcurrentBag<KontaktDTO> lKontakt = Lists.getFirstFromDictConcBag<KontaktDTO>(BenutzerMainDTO.Benutzer1.lKontakt);
            ConcurrentBag<AerzteDTO> lAerzte = Lists.getFirstFromDictConcBag<AerzteDTO>(BenutzerMainDTO.Benutzer1.lAerzte);
            ConcurrentBag<BenutzerRechteDTO> lBenRechte = Lists.getFirstFromDictConcBag<BenutzerRechteDTO>(BenutzerMainDTO.Benutzer1.lBenutzerRechte);
            ConcurrentBag<RechtDTO> lRechte = Lists.getFirstFromDictConcBag<RechtDTO>(BenutzerMainDTO.Benutzer1.lRecht);
            ConcurrentBag<BereichDTO> lBereiche = Lists.getFirstFromDictConcBag<BereichDTO>(BenutzerMainDTO.Benutzer1.lBereich);
            ConcurrentBag<BereichBenutzerDTO> lBereichBen = Lists.getFirstFromDictConcBag<BereichBenutzerDTO>(BenutzerMainDTO.Benutzer1.lBereichBenutzer);
            ConcurrentBag<BenutzerAbteilungDTO> lBenAbteilung = Lists.getFirstFromDictConcBag<BenutzerAbteilungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerAbteilung);
            ConcurrentBag<KlinikDTO> lKlinik = Lists.getFirstFromDictConcBag<KlinikDTO>(BenutzerMainDTO.Benutzer1.lKlinik);
            ConcurrentBag<BenutzerEinrichtungDTO> lBenEinrichtung = Lists.getFirstFromDictConcBag<BenutzerEinrichtungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerEinrichtung);

            if (BenutzerMainDTO.lAll == null)
                BenutzerMainDTO.lAll = new ConcurrentDictionary<DateTime, List<BenutzerMainDTO.BenutzerDt>>();

            //List<Task> tasks = new List<Task>();
            List<BenutzerMainDTO.BenutzerDt> lBen = new List<BenutzerMainDTO.BenutzerDt>();
            var pairBen = BenutzerMainDTO.Benutzer1.lBenutzer.OrderByDescending(v => v.Key).First();
            foreach (BenutzerDTO ben in pairBen.Value)
            {
                string name = ben.Nachname.Trim();
                if (ben.Nachname.Trim() == "Neu...")
                {
                    bool bStop = true;
                }
                try
                {
                    BenutzerMainDTO.BenutzerDt benstream = new BenutzerMainDTO.BenutzerDt() { IDBenutzer = ben.Id, ben = new BenutzerDTO(), DtoFrom = pairBen.Key };
                    PropertyCopier<BenutzerDTO, BenutzerDTO>.Copy(ben, benstream.ben);
                    //benstream.ben = ben;

                    //Kontakt, Adresse
                    if (benstream.ben.Idkontakt != null) benstream.kontakt = lKontakt.Where(o => o.Id == benstream.ben.Idkontakt).First();
                    if (benstream.ben.Idberufsstand != null) AuswahlListeBAL.auswahlliste("BER", benstream.ben.Idberufsstand.Value);

                    if (benstream.ben.Idarzt != null)       //Arzt
                    {
                        benstream.aerzt = new BenutzerMainDTO.AerztDt() { DtoFrom = pairBen.Key };

                        List<AerzteDTO> lAerzte2 = lAerzte.Where(o => o.Id == benstream.ben.Idarzt).ToList();
                        if (lAerzte2.Count() > 0)
                        {
                            benstream.aerzt.aerzt = lAerzte.First();
                            if (benstream.aerzt.aerzt.Idadresse != null) benstream.aerzt.adresse = lAdresse.Where(o => o.Id == benstream.aerzt.aerzt.Idadresse.Value).First();
                            if (benstream.aerzt.aerzt.Idkontakt != null) benstream.aerzt.kontakt = lKontakt.Where(o => o.Id == benstream.aerzt.aerzt.Idkontakt.Value).First();
                        }
                    }

                    //Recht Benutzer
                    benstream.recht = new BenutzerMainDTO.RechtDt() { DtoFrom = pairBen.Key };
                    benstream.recht.benutzerRechte = lBenRechte.Where(pp => pp.Idbenutzer == benstream.ben.Id).ToList();
                    benstream.recht.recht = (from r in lRechte
                                             join br in lBenRechte
                                             on r.Id equals br.Idrecht
                                             where br.Idbenutzer == benstream.ben.Id
                                             select new RechtDTO { Id = r.Id, Bezeichnung = r.Bezeichnung, Elga = r.Elga }).ToList();

                    //Recht Bereiche
                    benstream.lBereich = new List<BenutzerMainDTO.BereichDt>();
                    var lBereich = (from bb in lBereichBen
                                    join b in lBereiche
                                    on bb.Idbereich equals b.Id
                                    where bb.Idbenutzer == benstream.ben.Id
                                    orderby b.Reihenfolge ascending
                                    select b).ToList();
                    foreach (BereichDTO ber in lBereich)
                    {
                        BenutzerMainDTO.BereichDt berStr = new BenutzerMainDTO.BereichDt() { bereich2 = ber, DtoFrom = pairBen.Key };
                        if (benstream.lBereich.Count() < 50000)
                        {
                            benstream.lBereich.Add(berStr);
                            if (ber.Idabteilung != null)
                            {
                                AbteilungDTO abt = lAbteilungen.Where(o => o.Id == ber.Idabteilung).First();
                                berStr.abteilung2 = abt;
                            }
                        }
                    }

                    //Recht Abteilungen
                    benstream.lAbteilung = new List<BenutzerMainDTO.AbteilungDt>();
                    var lAbteilung = (from ba in lBenAbteilung
                                      join a in lAbteilungen
                                      on ba.Idabteilung equals a.Id
                                      where ba.Idbenutzer == benstream.ben.Id
                                      orderby a.Reihenfolge ascending
                                      select a).ToList();
                    foreach (AbteilungDTO abt in lAbteilung)
                        benstream.lAbteilung.Add(new BenutzerMainDTO.AbteilungDt() { abteilung = abt, DtoFrom = pairBen.Key });

                    //Klinik Benutzer
                    benstream.lKlinik = new List<BenutzerMainDTO.KlinikDt>();
                    var benEinrichtung = lBenEinrichtung.Where(o => o.Idbenutzer == benstream.ben.Id);
                    foreach (var rBenEinricht in benEinrichtung)
                    {
                        benstream.lKlinik.Add(new BenutzerMainDTO.KlinikDt() { klinik = lKlinik.Where(o => o.Id == rBenEinricht.Ideinrichtung).First(), DtoFrom = pairBen.Key }); ;
                    }


                    lBen.Add(benstream);
                }
                catch (Exception ex)
                {
                    throw new Exception("loadBen foreach: Error user '" + ben.Nachname.Trim() + "'\r\n" + ex.ToString()); ;
                }
            }

            //Task.WaitAll(tasks.ToArray());
            BenutzerMainDTO.lAll.TryAdd(now, lBen);

            var dBen = BenutzerMainDTO.lAll.OrderByDescending(v => v.Key).First();
            List<BenutzerMainDTO.BenutzerDt> benSer = dBen.Value;

            //BenutzerMainDTO.lastBenListSer = WCFServicePMDS.Repository.serialize.Serialize<List<BenutzerMainDTO.BenutzerDt>>(benSer);
            //List<BenutzerMainDTO.BenutzerDt> benDes = WCFServicePMDS.Repository.serialize.Deserialize<List<BenutzerMainDTO.BenutzerDt>>(BenutzerMainDTO.lastBenListSer);
            //int iSize = System.Text.ASCIIEncoding.Unicode.GetByteCount(BenutzerMainDTO.lastBenListSer);

            BenutzerMainDTO.lastBenListSerB = WCFServicePMDS.Repository.serialize.BinarySerialize<List<BenutzerMainDTO.BenutzerDt>>(benSer);
            List<BenutzerMainDTO.BenutzerDt> sBenDes = (List<BenutzerMainDTO.BenutzerDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(BenutzerMainDTO.lastBenListSerB);

            BenutzerMainDTO.lastBenutzer tLastBen = this.loadLastBenutzer();
            BenutzerMainBAL.ready = true;

            //BenutzerMainDTO.lastBenListSer = SerializeToXml(benSer);
            //List<BenutzerMainDTO.BenutzerDt> benDeser = DeserializeFromXML(BenutzerMainDTO.lastBenListSer);

            //serialize
            //var aSerializer = new XmlSerializer(typeof(List<BenutzerMainDTO.BenutzerDt>));
            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);
            //aSerializer.Serialize(sw, benSer);
            //BenutzerMainDTO.lastBenListSer = sw.GetStringBuilder().ToString();
            //int sizeOfVariable = System.Text.ASCIIEncoding.Unicode.GetByteCount(BenutzerMainDTO.lastBenListSer);
        }

        public BenutzerMainDTO.lastBenutzer loadLastBenutzer()
        {
            BenutzerMainDTO ben = newInstanz();
            ben.lBenutzer.TryAdd(Lists.getFirstFromDictKey<BenutzerDTO>(BenutzerMainDTO.Benutzer1.lBenutzer), Lists.getFirstFromDictConcBag<BenutzerDTO>(BenutzerMainDTO.Benutzer1.lBenutzer));
            ben.lAdresse.TryAdd(Lists.getFirstFromDictKey<AdresseDTO>(BenutzerMainDTO.Benutzer1.lAdresse), Lists.getFirstFromDictConcBag<AdresseDTO>(BenutzerMainDTO.Benutzer1.lAdresse));
            ben.lBenutzerEinrichtung.TryAdd(Lists.getFirstFromDictKey<BenutzerEinrichtungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerEinrichtung), Lists.getFirstFromDictConcBag<BenutzerEinrichtungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerEinrichtung));
            ben.lBenutzerRechte.TryAdd(Lists.getFirstFromDictKey<BenutzerRechteDTO>(BenutzerMainDTO.Benutzer1.lBenutzerRechte), Lists.getFirstFromDictConcBag<BenutzerRechteDTO>(BenutzerMainDTO.Benutzer1.lBenutzerRechte));
            ben.lBenutzerAbteilung.TryAdd(Lists.getFirstFromDictKey<BenutzerAbteilungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerAbteilung), Lists.getFirstFromDictConcBag<BenutzerAbteilungDTO>(BenutzerMainDTO.Benutzer1.lBenutzerAbteilung));
            ben.lBenutzerBezug.TryAdd(Lists.getFirstFromDictKey<BenutzerBezugDTO>(BenutzerMainDTO.Benutzer1.lBenutzerBezug), Lists.getFirstFromDictConcBag<BenutzerBezugDTO>(BenutzerMainDTO.Benutzer1.lBenutzerBezug));
            ben.lBenutzerGruppe.TryAdd(Lists.getFirstFromDictKey<BenutzerGruppeDTO>(BenutzerMainDTO.Benutzer1.lBenutzerGruppe), Lists.getFirstFromDictConcBag<BenutzerGruppeDTO>(BenutzerMainDTO.Benutzer1.lBenutzerGruppe));
            ben.lBereichBenutzer.TryAdd(Lists.getFirstFromDictKey<BereichBenutzerDTO>(BenutzerMainDTO.Benutzer1.lBereichBenutzer), Lists.getFirstFromDictConcBag<BereichBenutzerDTO>(BenutzerMainDTO.Benutzer1.lBereichBenutzer));
            ben.lGruppe.TryAdd(Lists.getFirstFromDictKey<GruppeDTO>(BenutzerMainDTO.Benutzer1.lGruppe), Lists.getFirstFromDictConcBag<GruppeDTO>(BenutzerMainDTO.Benutzer1.lGruppe));
            ben.lGruppenRecht.TryAdd(Lists.getFirstFromDictKey<GruppenRechtDTO>(BenutzerMainDTO.Benutzer1.lGruppenRecht), Lists.getFirstFromDictConcBag<GruppenRechtDTO>(BenutzerMainDTO.Benutzer1.lGruppenRecht));
            ben.lRecht.TryAdd(Lists.getFirstFromDictKey<RechtDTO>(BenutzerMainDTO.Benutzer1.lRecht), Lists.getFirstFromDictConcBag<RechtDTO>(BenutzerMainDTO.Benutzer1.lRecht));
            ben.lBereich.TryAdd(Lists.getFirstFromDictKey<BereichDTO>(BenutzerMainDTO.Benutzer1.lBereich), Lists.getFirstFromDictConcBag<BereichDTO>(BenutzerMainDTO.Benutzer1.lBereich));
            ben.lDienstzeiten.TryAdd(Lists.getFirstFromDictKey<DienstzeitenDTO>(BenutzerMainDTO.Benutzer1.lDienstzeiten), Lists.getFirstFromDictConcBag<DienstzeitenDTO>(BenutzerMainDTO.Benutzer1.lDienstzeiten));
            ben.lAbteilung.TryAdd(Lists.getFirstFromDictKey<AbteilungDTO>(BenutzerMainDTO.Benutzer1.lAbteilung), Lists.getFirstFromDictConcBag<AbteilungDTO>(BenutzerMainDTO.Benutzer1.lAbteilung));
            ben.lStandardzeiten.TryAdd(Lists.getFirstFromDictKey<StandardzeitenDTO>(BenutzerMainDTO.Benutzer1.lStandardzeiten), Lists.getFirstFromDictConcBag<StandardzeitenDTO>(BenutzerMainDTO.Benutzer1.lStandardzeiten));
            ben.lDienstzeiten.TryAdd(Lists.getFirstFromDictKey<DienstzeitenDTO>(BenutzerMainDTO.Benutzer1.lDienstzeiten), Lists.getFirstFromDictConcBag<DienstzeitenDTO>(BenutzerMainDTO.Benutzer1.lDienstzeiten));
            ben.lBank.TryAdd(Lists.getFirstFromDictKey<BankDTO>(BenutzerMainDTO.Benutzer1.lBank), Lists.getFirstFromDictConcBag<BankDTO>(BenutzerMainDTO.Benutzer1.lBank));
            ben.lBelegung.TryAdd(Lists.getFirstFromDictKey<BelegungDTO>(BenutzerMainDTO.Benutzer1.lBelegung), Lists.getFirstFromDictConcBag<BelegungDTO>(BenutzerMainDTO.Benutzer1.lBelegung));
            ben.lKlinik.TryAdd(Lists.getFirstFromDictKey<KlinikDTO>(BenutzerMainDTO.Benutzer1.lKlinik), Lists.getFirstFromDictConcBag<KlinikDTO>(BenutzerMainDTO.Benutzer1.lKlinik));
            ben.lAerzte.TryAdd(Lists.getFirstFromDictKey<AerzteDTO>(BenutzerMainDTO.Benutzer1.lAerzte), Lists.getFirstFromDictConcBag<AerzteDTO>(BenutzerMainDTO.Benutzer1.lAerzte));


            BenutzerMainDTO.lastBenutzer lBen = new BenutzerMainDTO.lastBenutzer();
            lBen.lBenutzer = Lists.getFirstFromDictConcBag<BenutzerDTO>(ben.lBenutzer).ToList();
            lBen.lAdresse = Lists.getFirstFromDictConcBag<AdresseDTO>(ben.lAdresse).ToList();
            lBen.lBenutzerEinrichtung = Lists.getFirstFromDictConcBag<BenutzerEinrichtungDTO>(ben.lBenutzerEinrichtung).ToList();
            lBen.lBenutzerRechte = Lists.getFirstFromDictConcBag<BenutzerRechteDTO>(ben.lBenutzerRechte).ToList();
            lBen.lBenutzerAbteilung = Lists.getFirstFromDictConcBag<BenutzerAbteilungDTO>(ben.lBenutzerAbteilung).ToList();
            lBen.lBenutzerBezug = Lists.getFirstFromDictConcBag<BenutzerBezugDTO>(ben.lBenutzerBezug).ToList();
            lBen.lBenutzerGruppe = Lists.getFirstFromDictConcBag<BenutzerGruppeDTO>(ben.lBenutzerGruppe).ToList();
            lBen.lBereichBenutzer = Lists.getFirstFromDictConcBag<BereichBenutzerDTO>(ben.lBereichBenutzer).ToList();
            lBen.lGruppenRecht = Lists.getFirstFromDictConcBag<GruppenRechtDTO>(ben.lGruppenRecht).ToList();
            lBen.lRecht = Lists.getFirstFromDictConcBag<RechtDTO>(ben.lRecht).ToList();
            lBen.lBereich = Lists.getFirstFromDictConcBag<BereichDTO>(ben.lBereich).ToList();
            lBen.lDienstzeiten = Lists.getFirstFromDictConcBag<DienstzeitenDTO>(ben.lDienstzeiten).ToList();
            lBen.lAbteilung = Lists.getFirstFromDictConcBag<AbteilungDTO>(ben.lAbteilung).ToList();
            lBen.lStandardzeiten = Lists.getFirstFromDictConcBag<StandardzeitenDTO>(ben.lStandardzeiten).ToList();
            lBen.lDienstzeiten = Lists.getFirstFromDictConcBag<DienstzeitenDTO>(ben.lDienstzeiten).ToList();
            lBen.lBank = Lists.getFirstFromDictConcBag<BankDTO>(ben.lBank).ToList();
            lBen.lBelegung = Lists.getFirstFromDictConcBag<BelegungDTO>(ben.lBelegung).ToList();
            lBen.lKlinik = Lists.getFirstFromDictConcBag<KlinikDTO>(ben.lKlinik).ToList();
            lBen.lAerzte = Lists.getFirstFromDictConcBag<AerzteDTO>(ben.lAerzte).ToList();
            lBen.lGruppe = Lists.getFirstFromDictConcBag<GruppeDTO>(ben.lGruppe).ToList();

            BenutzerMainDTO.LastBenutzer = lBen;

            BenutzerMainDTO.lastBenTablesSerB = WCFServicePMDS.Repository.serialize.BinarySerialize<BenutzerMainDTO.lastBenutzer>(BenutzerMainDTO.LastBenutzer);
            //BenutzerMainDTO.lastBenutzer benDes2 = (BenutzerMainDTO.lastBenutzer)WCFServicePMDS.Repository.serialize.BinaryDeserialize(BenutzerMainDTO.lastBenTablesSerB);

            return BenutzerMainDTO.LastBenutzer;
        }


        public static string SerializeToXml(List<BenutzerMainDTO.BenutzerDt> DataObject)
        {
            var xsSubmit = new XmlSerializer(typeof(List<BenutzerMainDTO.BenutzerDt>));
            using (var sw = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sw))
                {
                    xsSubmit.Serialize(writer, DataObject);
                    var data = sw.ToString();
                    writer.Flush();
                    writer.Close();
                    sw.Flush();
                    sw.Close();
                    return data;
                }
            }

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(DataObject.GetType());
            //    xmlSerializer.Serialize(ms, DataObject);
            //    ms.Flush();
            //    Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //    soc.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
            //}
            //return "";
        }
        public static List<BenutzerMainDTO.BenutzerDt> DeserializeFromXML(string xml)
        {
            var xsExpirations = new XmlSerializer(typeof(List<BenutzerMainDTO.BenutzerDt>));
            List<BenutzerMainDTO.BenutzerDt> rootDataObj = null;
            using (TextReader reader = new StringReader(xml))
            {
                rootDataObj = (List<BenutzerMainDTO.BenutzerDt>)xsExpirations.Deserialize(reader);
                reader.Close();
            }
            return rootDataObj;
        }


    }

}
