 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL
{

    public class PatientDAL : IPatient
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PatientDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<PatientDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Patient> tDto = (from o in this._repoWrapper.dbcontext.Patient
                                                 select o).ToList();
                //List<Patient> tDto = await repoWrapper.Patient.getAllAsync();
                ConcurrentBag<PatientDTO> t = Mapping.MergeListData2<PatientDTO>(tDto.Select(x => x as object).ToList());
                return t;
            }
        }
        public List<PatientDTO> getPatientAll()
        {
            var t = _repoWrapper.Patient.FindAll().ToList();
            List<PatientDTO> tDto = Mapping.MergeListData<PatientDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }
        public PatientDTO getPatientByID(Guid Id)
        {
            var t = _repoWrapper.Patient.FindByCondition(o => o.Id == Id).ToList();
            List<PatientDTO> tDto = Mapping.MergeListData<PatientDTO>(t.Select(x => x as object).ToList());
            return tDto.First();
        }
        public PatientS1DTO PatientS1(Guid ID)
        {
            List<PatientS1DTO> tPatient = (from o in this._repoWrapper.dbcontext.Patient
                                         where o.Id == ID
                                         select new PatientS1DTO { Id = o.Id, Idadresse = o.Idadresse, Idkontakt = o.Idkontakt, Vorname = o.Vorname, Nachname = o.Nachname, VersicherungsNr = o.VersicherungsNr, Sexus = o.Sexus,
                                             Geburtsdatum = o.Geburtsdatum, Familienstand = o.Familienstand, WohnungAbgemeldetJn = o.WohnungAbgemeldetJn, KrankenKasse = o.KrankenKasse, 
                                             BPk = o.BPk, Konfision = o.Konfision, LstSprachen = o.LstSprachen, SozVersLeerGrund = o.SozVersLeerGrund, SozVersMitversichertBei = o.SozVersMitversichertBei, SozVersStatus = o.SozVersStatus, Titel = o.Titel}).ToList();
           return tPatient.First();
        }

    }

}
