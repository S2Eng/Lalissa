 
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

    public class LinkDokumenteDAL : ILinkDokumente
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public LinkDokumenteDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public ConcurrentBag<LinkDokumenteDTO> getAll()
        {
            var t = _repoWrapper.LinkDokumente.FindAll().ToList();
            ConcurrentBag<LinkDokumenteDTO> tDto = Mapping.MergeListData2<LinkDokumenteDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }


    }

}
