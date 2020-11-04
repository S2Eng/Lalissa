using System;
using System.Linq;
using System.Threading.Tasks;
using TestRep.EfCoreGenericRepository;
using TestRep.EfCoreGenericRepository.DataAccess;
using WCFServicePMDS.Models.DB;


namespace TestRep.EfCoreGenericRepository.DataAccess
{
    public class BenutzerRepository : GenericRepository<Benutzer>, WCFServicePMDS.Interface2.IBenutzerRepository
    {

        public BenutzerRepository(PMDSDevContext context) : base(context)
        {
        }

        public Benutzer Get(Guid ID)
        {
            var query = GetAll().FirstOrDefault(b => b.Id == ID);
            return query;
        }
        public void Save2()
        {
            
        }
        public async Task<Benutzer> GetSingleAsyn(int blogId)
        {
            return await _context.Set<Benutzer>().FindAsync(blogId);
        }

        public override Benutzer Update(Benutzer t, object key)
        {
            Benutzer exist = _context.Set<Benutzer>().Find(key);
            if (exist != null)
            {
                //t.CreatedBy = exist.CreatedBy;
                //t.CreatedOn = exist.CreatedOn;
            }
            return base.Update(t, key);
        }

        public async override Task<Benutzer> UpdateAsyn(Benutzer t, object key)
        {
            Benutzer exist = await _context.Set<Benutzer>().FindAsync(key);
            if (exist != null)
            {
                //t.CreatedBy = exist.CreatedBy;
                //t.CreatedOn = exist.CreatedOn;
            }
            return await base.UpdateAsyn(t, key);
        }
    }
}