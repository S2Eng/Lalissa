 
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

    public class AerzteDAL : IAerzte
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AerzteDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<AerzteDTO> getAerzteAll()
        {
            var t = _repoWrapper.Aerzte.FindAll().ToList();
            List<AerzteDTO> tDto = Mapping.MergeListData<AerzteDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public async Task<ConcurrentBag<AerzteDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Aerzte> t = await repoWrapper.Aerzte.getAllAsync();
                ConcurrentBag<AerzteDTO> tDto = Mapping.MergeListData2<AerzteDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<AerzteDTO> AerzteS1(Guid Idpatient)
        {
           return (from a in this._repoWrapper.dbcontext.Aerzte
                        join pa in this._repoWrapper.dbcontext.PatientAerzte on a.Id equals pa.Idaerzte
                        where pa.Idpatient == Idpatient
                        orderby a.Nachname ascending, a.Vorname ascending
                        select new AerzteDTO { Id = a.Id, Vorname = a.Vorname, Nachname = a.Nachname, Idadresse = a.Idadresse, Idkontakt = a.Idkontakt, Titel = a.Titel, Fachrichtung = a.Fachrichtung,
                            ElgaOid = a.ElgaOid, Elgaabgeglichen = a.Elgaabgeglichen, Elgahausarzt = a.Elgahausarzt, ElgaOrganizationName = a.ElgaOrganizationName, ElgaOrganizationOid = a.ElgaOrganizationOid }).ToList();
        }

        public List<AerzteDTO> AerzteS1ByELGAHausarzt(Guid Idpatient)
        {
            return (from a in this._repoWrapper.dbcontext.Aerzte
                    join pa in this._repoWrapper.dbcontext.PatientAerzte on a.Id equals pa.Idaerzte
                    where pa.Idpatient == Idpatient && pa.ElgaHausarztJn == true
                    orderby a.Nachname ascending, a.Vorname ascending
                    select new AerzteDTO
                    {
                        Id = a.Id,
                        Vorname = a.Vorname,
                        Nachname = a.Nachname,
                        Idadresse = a.Idadresse,
                        Idkontakt = a.Idkontakt,
                        Titel = a.Titel,
                        Fachrichtung = a.Fachrichtung,
                        ElgaOid = a.ElgaOid,
                        Elgaabgeglichen = a.Elgaabgeglichen,
                        Elgahausarzt = a.Elgahausarzt,
                        ElgaOrganizationName = a.ElgaOrganizationName,
                        ElgaOrganizationOid = a.ElgaOrganizationOid
                    }).ToList();
        }

    }

}
