 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.Models.DB;
using Microsoft.EntityFrameworkCore;
 


namespace WCFServicePMDS.DAL
{

    public class PflegePlanDAL : IPflegePlan 
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PflegePlanDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<PflegePlanDTO> getAll()
        {
            var t = _repoWrapper.PflegePlan.FindAll().ToList();
            List<PflegePlanDTO> tDto = Mapping.MergeListData<PflegePlanDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public List<PflegePlanDTO> getAllSmall()
        {
            var tPfPlan = (from pf in _repoWrapper.dbcontext.PflegePlan
                                           join a in _repoWrapper.dbcontext.Aufenthalt on pf.Idaufenthalt equals a.Id
                                           where pf.Id != System.Guid.NewGuid()
                                           select new
                                           {
                                               Id = pf.Id,
                                               DatumErstellt = pf.DatumErstellt,
                                               Text = pf.Text
                                           }).ToList();

            List<PflegePlanDTO> tDto = Mapping.MergeListData<PflegePlanDTO>(tPfPlan.Select(x => x as object).ToList());
            return tDto;

            //List<PflegePlanDTO> tPfPlan = (from pf in _repoWrapper.dbcontext.PflegePlan
            //                               join a in _repoWrapper.dbcontext.Aufenthalt on pf.Idaufenthalt equals a.Id
            //                               where pf.Id != System.Guid.NewGuid()
            //                               select new PflegePlanDTO()
            //                               {
            //                                   Id = pf.Id,
            //                                   DatumErstellt = pf.DatumErstellt,
            //                                   Text = pf.Text
            //                               }).ToList();

            //return tPfPlan;

        }

        public async Task<List<PflegePlanDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PflegePlan> t = await repoWrapper.PflegePlan.getAllAsync();
                //List<PflegePlan> t = await context.PflegePlan.ToListAsync();

                List<PflegePlanDTO> tDto = Mapping.MergeListData<PflegePlanDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
        public async Task<List<PflegePlanDTO>> getWhereAsync(Expression<Func<PflegePlan, bool>> expression, Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PflegePlan> t = await repoWrapper.PflegePlan.getWhereAsync(o => o.Id == System.Guid.NewGuid());
                List<PflegePlanDTO> tDto = Mapping.MergeListData<PflegePlanDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

    }

}
