using Elga.core.ServiceReferenceELGA;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.BAL2.ELGABAL;

namespace WCFServicePMDS
{

    public class ELGAChache
    {

        private static ConcurrentBag<ELGAPatientUsr> _lEhrPatientClientDto;
        private static ConcurrentBag<ELGADocumentUsr> _lEhrDocumentClientDto;

        public static ConcurrentBag<ELGAPatientUsr> lEhrPatientClientDto
        {
            get => _lEhrPatientClientDto;
            set => _lEhrPatientClientDto = value;
        }
        public static ConcurrentBag<ELGADocumentUsr> lEhrDocumentClientDto
        {
            get => _lEhrDocumentClientDto;
            set => _lEhrDocumentClientDto = value;
        }

        public class ELGAPatientUsr
        {
            public Guid ID { get; set; }
            public Guid IDUser { get; set; }
            public ehrPatientClientDto ehrPatientClient { get; set; }
        }
        public class ELGADocumentUsr
        {
            public Guid IDUser { get; set; }
            public Guid ID { get; set; }
            public documentClientDto documentClient { get; set; }
        }






        public ehrPatientClientDto getEhrPatient(Guid ID)
        {
            try
            {
                var tPat = (from p in ELGAChache.lEhrPatientClientDto
                            where p.ID == ID
                            select new
                            {
                                IDUser = p.IDUser,
                                ehrPatientClient = p.ehrPatientClient
                            }).ToList();

                return tPat.First().ehrPatientClient;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAChache.getEhrPatient: " + ex.ToString());
            }
        }
        public void addPatientToChache(Guid ID, ELGASessionDTO session, ehrPatientClientDto elgaPatient)
        {
            try
            {
                if (ELGAChache.lEhrPatientClientDto == null)
                {
                    ELGAChache.lEhrPatientClientDto = new ConcurrentBag<ELGAPatientUsr>();
                }
                ELGAChache.lEhrPatientClientDto.Add(new ELGAChache.ELGAPatientUsr() { ID = ID, IDUser = session.IDUser, ehrPatientClient = elgaPatient });

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAChache.addPatientToChache: " + ex.ToString());
            }
        }
        public bool clearEhrPatientUsr(ELGASessionDTO session)
        {
            try
            {
                if (ELGAChache.lEhrPatientClientDto != null)
                {
                   Guid IDUsrTmp = session.IDUser;
                   var tPat = (from p in ELGAChache.lEhrPatientClientDto
                                where p.IDUser == IDUsrTmp
                                select new
                                {
                                    IDUser = p.IDUser,
                                    ehrPatientClient = p.ehrPatientClient
                                }).ToList();

                    System.Collections.Generic.List<ehrPatientClientDto> lEhrPatToDelete = new List<ehrPatientClientDto>();
                    foreach (var rPat in tPat)
                    {
                        lEhrPatToDelete.Add(rPat.ehrPatientClient);
                    }
                    foreach (var rPat in lEhrPatToDelete)
                    {
                        ELGAChache.ELGAPatientUsr rPatRet;
                        ELGAChache.lEhrPatientClientDto.TryTake(out rPatRet);
                    }
                }

                return true;



                //Guid IDUsrTmp = session.IDUser;
                //var pairPatientUser = from p in ELGABAL.lEhrPatientClientDto
                //                      where p.Key == IDUsrTmp
                //                        select p;
                //foreach (var r in pairPatientUser)
                //{
                //}

                //ehrPatientClientDto ehrPatientClientDto = null;
                //if (lEhrPatientClientDto.ContainsKey(session.IDUser))
                //{
                //    bool bOk = lEhrPatientClientDto.TryGetValue(session.IDUser, out ehrPatientClientDto);
                //}
                //else
                //{
                //    ehrPatientClientDto = new ehrPatientClientDto();
                //    lEhrPatientClientDto.Add(session.IDUser, ehrPatientClientDto);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAChache.clearEhrPatientUsr: " + ex.ToString());
            }
        }

        public documentClientDto getEhrDocuments(Guid ID)
        {
            try
            {
                throw new Exception("getEhrDocuments: Fct not activated!");

                //var tPat = (from p in ELGAChache.lEhrDocumentClientDto
                //            where p.ID == ID
                //            select new
                //            {
                //                IDUser = p.IDUser,
                //                documentClient = p.documentClient
                //            }).ToList();

                //return tPat.First().documentClient;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAChache.getEhrDocuments: " + ex.ToString());
            }
        }
        public void addDocuToChache(Guid ID, ELGASessionDTO session, documentClientDto elgaDocu)
        {
            try
            {
                throw new Exception("addDocuToChache: Fct not activated!");

                //if (ELGAChache.lEhrDocumentClientDto == null)
                //{
                //    ELGAChache.lEhrDocumentClientDto = new ConcurrentBag<ELGADocumentUsr>();
                //}
                //ELGAChache.lEhrDocumentClientDto.Add(new ELGAChache.ELGADocumentUsr() { ID = ID, IDUser = session.IDUser,  documentClient = elgaDocu });

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAChache.addDocuToChache: " + ex.ToString());
            }
        }
        public bool clearEhrDocuments(ELGASessionDTO session)
        {
            try
            {
                throw new Exception("clearEhrDocuments: Fct not activated!");

                //if (ELGAChache.lEhrDocumentClientDto != null)
                //{
                //    Guid IDUsrTmp = session.IDUser;
                //    var tDocu = (from p in ELGAChache.lEhrDocumentClientDto
                //                 where p.IDUser == IDUsrTmp
                //                 select new
                //                 {
                //                     IDUser = p.IDUser,
                //                     documentClient = p.documentClient
                //                 }).ToList();

                //    System.Collections.Generic.List<documentClientDto> lEhrDocuToDelete = new List<documentClientDto>();
                //    foreach (var rDocu in tDocu)
                //    {
                //        lEhrDocuToDelete.Add(rDocu.documentClient);
                //    }
                //    foreach (var rDocu in lEhrDocuToDelete)
                //    {
                //        ELGAChache.ELGADocumentUsr rDocuRet;
                //        ELGAChache.lEhrDocumentClientDto.TryTake(out rDocuRet);
                //    }
                //}

                //return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ELGAChache.clearEhrDocuments: " + ex.ToString());
            }
        }

    }

}

