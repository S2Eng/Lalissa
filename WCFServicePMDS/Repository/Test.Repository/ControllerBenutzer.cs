using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;
using static TestRep.WCFServicePMDS.Interface2;


namespace TestRep.WCFServicePMDS.DAL.rep2
{
    public class ControllerBenutzer
    {

        private readonly Interface2.IBenutzerRepository _BenutzerRepository;


        public ControllerBenutzer(IBenutzerRepository BenutzerRepository)
        {
            _BenutzerRepository = BenutzerRepository;

        }

        public async Task<IEnumerable<Benutzer>> Index()
        {
            return await _BenutzerRepository.GetAllAsyn();
        }

        public async Task<Benutzer> AddBlog(Benutzer Benutzer)
        {
            await _BenutzerRepository.AddAsyn(Benutzer);
            await _BenutzerRepository.SaveAsync();
            return Benutzer;
        }

        public async Task<Benutzer> UpdateBlog(Benutzer Benutzer)
        {
            var updated = await _BenutzerRepository.UpdateAsyn(Benutzer, Benutzer.Id);
            return updated;
        }

        public string Delete(int id)
        {
            _BenutzerRepository.Delete(_BenutzerRepository.Get(id));
            return "Employee deleted successfully!";
        }


    }
}
