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

    public class PatientMainBAL : IPatientMainBAL
    {

        public PatientMainBAL()
        {

        }



        public PatientMainDTO newInstanz()
        {
            PatientMainDTO pat = new PatientMainDTO();

            pat.lPatient = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<PatientDTO>>();
            pat.lAufenthalt = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AufenthaltDTO>>();
            pat.lKontaktperson = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<KontaktpersonDTO>>();
            pat.lPatientAbwesenheit = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<PatientAbwesenheitDTO>>();
            pat.lPatientAerzte = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<PatientAerzteDTO>>();
            pat.lPatientEinkommen = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<PatientEinkommenDTO>>();
            pat.lPatientenBemerkung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<PatientenBemerkungDTO>>();
            pat.lPatientPflegestufe = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<PatientPflegestufeDTO>>();
            pat.lRehabilitation = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<RehabilitationDTO>>();
            pat.lSachwalter = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<SachwalterDTO>>();

            return pat;
        }

        public List<PatientMainDTO.PatientDt> load(ref DateTime dFrom, Guid IDClient)
        {
            Task t = new PatientMainBAL().loadAll(dFrom, IDClient);
            t.Wait();

            Task tKlient = this.loadAllPatient(dFrom);
            tKlient.Wait();

            var valPair = PatientMainDTO.lAllAct.OrderByDescending(v => v.Key).First();
            return valPair.Value;
        }

        public async Task loadAll(DateTime dFrom, Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                if (PatientMainDTO.Patient == null) PatientMainDTO.Patient = newInstanz();


                Task<ConcurrentBag<PatientDTO>> taPatient = new PatientDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<AufenthaltDTO>> taAufenthalt = new AufenthaltDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<KontaktpersonDTO>> taKontaktperson = new KontaktpersonDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<PatientAbwesenheitDTO>> taPatientAbwesenheit = new PatientAbwesenheitDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<PatientAerzteDTO>> taPatientAerzte = new PatientAerzteDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<PatientEinkommenDTO>> taPatientEinkommen = new PatientEinkommenDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<PatientenBemerkungDTO>> taPatientenBemerkung = new PatientenBemerkungDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<PatientPflegestufeDTO>> taPatientPflegestufe = new PatientPflegestufeDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<RehabilitationDTO>> taRehabilitation = new RehabilitationDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<SachwalterDTO>> taSachwalter = new SachwalterDAL(repoWrapper).getAllAsync(IDClient);
                //Dokumente ?

                Task.WaitAll(taPatient, taAufenthalt, taKontaktperson, taPatientAbwesenheit, taPatientAerzte, taPatientEinkommen, taPatientenBemerkung,
                                taPatientPflegestufe, taRehabilitation, taSachwalter);

                PatientMainDTO.Patient.lPatient.TryAdd(dFrom, taPatient.Result);
                PatientMainDTO.Patient.lAufenthalt.TryAdd(dFrom, taAufenthalt.Result);
                PatientMainDTO.Patient.lKontaktperson.TryAdd(dFrom, taKontaktperson.Result);
                PatientMainDTO.Patient.lPatientAbwesenheit.TryAdd(dFrom, taPatientAbwesenheit.Result);
                PatientMainDTO.Patient.lPatientAerzte.TryAdd(dFrom, taPatientAerzte.Result);
                PatientMainDTO.Patient.lPatientEinkommen.TryAdd(dFrom, taPatientEinkommen.Result);
                PatientMainDTO.Patient.lPatientenBemerkung.TryAdd(dFrom, taPatientenBemerkung.Result);
                PatientMainDTO.Patient.lPatientPflegestufe.TryAdd(dFrom, taPatientPflegestufe.Result);
                PatientMainDTO.Patient.lRehabilitation.TryAdd(dFrom, taRehabilitation.Result);
                PatientMainDTO.Patient.lSachwalter.TryAdd(dFrom, taSachwalter.Result);
            }
        }

        public async Task loadAllPatient(DateTime now)
        {
            ConcurrentBag<AdresseDTO> lAdresse = Lists.getFirstFromDictConcBag<AdresseDTO>(BenutzerMainDTO.Benutzer1.lAdresse);
            ConcurrentBag<KontaktDTO> lKontakt = Lists.getFirstFromDictConcBag<KontaktDTO>(BenutzerMainDTO.Benutzer1.lKontakt);

            if (PatientMainDTO.lAllAct == null)
                PatientMainDTO.lAllAct = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, List<PatientMainDTO.PatientDt>>();
            if (PatientMainDTO.lAllEntl == null)
                PatientMainDTO.lAllEntl = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, List<PatientMainDTO.PatientDt>>();

            List<PatientMainDTO.PatientDt> lPatAct = new List<PatientMainDTO.PatientDt>();
            List<PatientMainDTO.PatientDt> lPatEntl = new List<PatientMainDTO.PatientDt>();

            var pairPat = PatientMainDTO.Patient.lPatient.OrderByDescending(v => v.Key).First();
            foreach (PatientDTO pat in pairPat.Value)
            {
                PatientMainDTO.PatientDt patstream = new PatientMainDTO.PatientDt() { IDPatient = pat.Id, patient = new PatientDTO(), DtoFrom = pairPat.Key };
                PropertyCopier<PatientDTO, PatientDTO>.Copy(pat, patstream.patient);

                if (patstream.patient.Idadresse != null) patstream.adresse = lAdresse.Where(o => o.Id == patstream.patient.Idadresse).First();
                if (patstream.patient.Idkontakt != null) patstream.kontakt = lKontakt.Where(o => o.Id == patstream.patient.Idkontakt).First();

                AufenthaltDTO aufAct = AufenthaltBAL.aufenthaltActForPatient(patstream.IDPatient);
                if (aufAct != null)
                {
                    patstream.aufenthaltAct = new PatientMainDTO.AufenthaltDt() { aufenthalt = aufAct, DtoFrom = pairPat.Key };

                    ConcurrentBag<AbteilungDTO> lAbteilung = Lists.getFirstFromDictConcBag<AbteilungDTO>(BenutzerMainDTO.Benutzer1.lAbteilung);
                    patstream.abteilung = lAbteilung.Where(o => o.Id == patstream.aufenthaltAct.aufenthalt.Idabteilung).First();


                    lPatAct.Add(patstream);
                }
                else
                {
                    lPatEntl.Add(patstream);
                }
            }

            PatientMainDTO.lAllAct.TryAdd(now, lPatAct);
            PatientMainDTO.lAllEntl.TryAdd(now, lPatEntl);

            var dPat = PatientMainDTO.lAllAct.OrderByDescending(v => v.Key).First();
            List<PatientMainDTO.PatientDt> patSer = dPat.Value;

            PatientMainDTO.lastPatListSerB = WCFServicePMDS.Repository.serialize.BinarySerialize<List<PatientMainDTO.PatientDt>>(patSer);
            List<PatientMainDTO.PatientDt> sdDes2 = (List<PatientMainDTO.PatientDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(PatientMainDTO.lastPatListSerB);

            PatientMainDTO.PatientB = WCFServicePMDS.Repository.serialize.BinarySerialize<PatientMainDTO>(PatientMainDTO.Patient);
            PatientMainDTO patDes = (PatientMainDTO)WCFServicePMDS.Repository.serialize.BinaryDeserialize(PatientMainDTO.PatientB);

            PatientMainDTO.lastPatienten tLastPat = this.loadLastPatienten();

        }

        public PatientMainDTO.lastPatienten loadLastPatienten()
        {
            //if (PatientMainDTO.LastPatient != null)
            //{
            //    DateTime lastDateTime = Lists.getFirstFromDictKey<PatientAerzteDTO>(PatientMainDTO.Patient.lPatientAerzte);
            //    DateTime dDateTime = Lists.getFirstFromDictKey<PatientAerzteDTO>(PatientMainDTO.LastPatient.lPatientAerzte);
            //    if (dDateTime <= lastDateTime)
            //    {
            //        return PatientMainDTO.LastPatient;
            //    }
            //}

            PatientMainDTO pat = newInstanz();
            pat.lPatient.TryAdd(Lists.getFirstFromDictKey<PatientDTO>(PatientMainDTO.Patient.lPatient), Lists.getFirstFromDictConcBag<PatientDTO>(PatientMainDTO.Patient.lPatient));
            pat.lAufenthalt.TryAdd(Lists.getFirstFromDictKey<AufenthaltDTO>(PatientMainDTO.Patient.lAufenthalt), Lists.getFirstFromDictConcBag<AufenthaltDTO>(PatientMainDTO.Patient.lAufenthalt));
            pat.lKontaktperson.TryAdd(Lists.getFirstFromDictKey<KontaktpersonDTO>(PatientMainDTO.Patient.lKontaktperson), Lists.getFirstFromDictConcBag<KontaktpersonDTO>(PatientMainDTO.Patient.lKontaktperson));
            pat.lPatientAbwesenheit.TryAdd(Lists.getFirstFromDictKey<PatientAbwesenheitDTO>(PatientMainDTO.Patient.lPatientAbwesenheit), Lists.getFirstFromDictConcBag<PatientAbwesenheitDTO>(PatientMainDTO.Patient.lPatientAbwesenheit));
            pat.lPatientAerzte.TryAdd(Lists.getFirstFromDictKey<PatientAerzteDTO>(PatientMainDTO.Patient.lPatientAerzte), Lists.getFirstFromDictConcBag<PatientAerzteDTO>(PatientMainDTO.Patient.lPatientAerzte));
            pat.lPatientEinkommen.TryAdd(Lists.getFirstFromDictKey<PatientEinkommenDTO>(PatientMainDTO.Patient.lPatientEinkommen), Lists.getFirstFromDictConcBag<PatientEinkommenDTO>(PatientMainDTO.Patient.lPatientEinkommen));
            pat.lPatientenBemerkung.TryAdd(Lists.getFirstFromDictKey<PatientenBemerkungDTO>(PatientMainDTO.Patient.lPatientenBemerkung), Lists.getFirstFromDictConcBag<PatientenBemerkungDTO>(PatientMainDTO.Patient.lPatientenBemerkung));
            pat.lPatientPflegestufe.TryAdd(Lists.getFirstFromDictKey<PatientPflegestufeDTO>(PatientMainDTO.Patient.lPatientPflegestufe), Lists.getFirstFromDictConcBag<PatientPflegestufeDTO>(PatientMainDTO.Patient.lPatientPflegestufe));
            pat.lRehabilitation.TryAdd(Lists.getFirstFromDictKey<RehabilitationDTO>(PatientMainDTO.Patient.lRehabilitation), Lists.getFirstFromDictConcBag<RehabilitationDTO>(PatientMainDTO.Patient.lRehabilitation));
            pat.lSachwalter.TryAdd(Lists.getFirstFromDictKey<SachwalterDTO>(PatientMainDTO.Patient.lSachwalter), Lists.getFirstFromDictConcBag<SachwalterDTO>(PatientMainDTO.Patient.lSachwalter));


            PatientMainDTO.lastPatienten lPat = new PatientMainDTO.lastPatienten();
            lPat.lPatient = Lists.getFirstFromDictConcBag<PatientDTO>(pat.lPatient).ToList();
            lPat.lAufenthalt = Lists.getFirstFromDictConcBag<AufenthaltDTO>(pat.lAufenthalt).ToList();
            lPat.lKontaktperson = Lists.getFirstFromDictConcBag<KontaktpersonDTO>(pat.lKontaktperson).ToList();
            lPat.lPatientAbwesenheit = Lists.getFirstFromDictConcBag<PatientAbwesenheitDTO>(pat.lPatientAbwesenheit).ToList();
            lPat.lPatientAerzte = Lists.getFirstFromDictConcBag<PatientAerzteDTO>(pat.lPatientAerzte).ToList();
            lPat.lPatientEinkommen = Lists.getFirstFromDictConcBag<PatientEinkommenDTO>(pat.lPatientEinkommen).ToList();
            lPat.lPatientenBemerkung = Lists.getFirstFromDictConcBag<PatientenBemerkungDTO>(pat.lPatientenBemerkung).ToList();
            lPat.lPatientPflegestufe = Lists.getFirstFromDictConcBag<PatientPflegestufeDTO>(pat.lPatientPflegestufe).ToList();
            lPat.lRehabilitation = Lists.getFirstFromDictConcBag<RehabilitationDTO>(pat.lRehabilitation).ToList();
            lPat.lSachwalter = Lists.getFirstFromDictConcBag<SachwalterDTO>(pat.lSachwalter).ToList();


            PatientMainDTO.LastPatient = lPat;

            PatientMainDTO.lastPatTablesSerB = WCFServicePMDS.Repository.serialize.BinarySerialize<PatientMainDTO.lastPatienten>(PatientMainDTO.LastPatient);
            //PatientMainDTO.lastPatienten patDes2 = (PatientMainDTO.lastPatienten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(PatientMainDTO.lastPatTablesSerB);

            return PatientMainDTO.LastPatient;
        }

        public async Task<ConcurrentBag<vKlientenlisteDTO>> getvKlientenliste(Guid IDClient)
        {
            try
            {
                if (PatientMainDTO.vKlientenliste == null)
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            PatientMainDTO.vKlientenliste = new ConcurrentBag<vKlientenlisteDTO>();
                            using (WCFServicePMDS.Repository.RepositoryWrapper repo = new Repository.RepositoryWrapper(IDClient))
                            {
                                PatientMainDTO.vKlientenliste = new vKlientenlisteDAL(repo).getvKlientenlisteAll2();
                                PatientMainDTO.vKlientenlisteB = WCFServicePMDS.Repository.serialize.BinarySerialize<ConcurrentBag<vKlientenlisteDTO>>(PatientMainDTO.vKlientenliste);
                            }

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("getvKlientenliste: Task => " + ex.ToString());
                        }

                    }).ContinueWith((t) =>
                    {
                        if (t.IsFaulted) throw t.Exception;
                        if (t.IsCompleted) { }
                    });
                }

                return PatientMainDTO.vKlientenliste;
            }
            catch (Exception ex)
            {
                throw new Exception("getvKlientenliste: " + ex.ToString());
            }
        }

        public static PatientMainDTO.PatientDt getPatientByID(Guid id)
        {
            var valPair = PatientMainDTO.lAllAct.OrderByDescending(v => v.Key).First();
            var t = valPair.Value.Where(o => o.IDPatient == id);
            if (t.Count() == 0)
            {
                var valPair2 = PatientMainDTO.lAllEntl.OrderByDescending(v => v.Key).First();
                var r = valPair2.Value.Where(o => o.IDPatient == id).First();
                return r;
            }
            else
            {
                return t.First();
            }

        }


    }

}
