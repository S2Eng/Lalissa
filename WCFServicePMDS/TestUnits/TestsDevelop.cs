using TestRep.EfCoreGenericRepository.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;
using TestRep.WCFServicePMDS.DAL.rep2;
using TestRepAsync.WCFServicePMDS.DAL;
using WCFServicePMDS.BAL;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Main;
using Patagames.Pdf.Net;
using System.IO;
using Patagames.Pdf.Enums;
using System.Collections.Concurrent;

namespace WCFServicePMDS.TestUnits
{

    public class TestsDevelop
    {



        public static void runRepository1(Guid IDClient)
        {
            try
            {
                BenutzerBAL benBal = new BenutzerBAL();
                List<BenutzerDTO> lBen = benBal.getBenutzerAll(IDClient);         

                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var owners = _repoWrapper.Benutzer.FindAll();
                    foreach (Benutzer ben in owners)
                    {
                        string txtTmp = ben.Vorname.Trim();
                    }
                    var owners4 = _repoWrapper.Abteilung.FindAll();
                    foreach (Abteilung abt in owners4)
                    {
                        string txtTmp = abt.Bezeichnung.Trim();
                    }
                    
                    var owners2 = _repoWrapper.Benutzer.FindAll().Where(x => x.Benutzer1 == "PMSOwner");
                    foreach (Benutzer ben in owners2)
                    {
                        string txtTmp = ben.Vorname.Trim();
                    }

                    var owners3 = _repoWrapper.Benutzer.FindByCondition(x => x.Benutzer1 == "PMSOwner");
                    foreach (Benutzer ben in owners3)
                    {
                        string txtTmp = ben.Vorname.Trim();
                    }

                    //var vK = _repoWrapper.vKlientenliste.FindByCondition(o => o.IDKlient == new Guid("ac6bd9ed-c711-4acf-aa11-a454dcd3617b"));     //.Select(o => new { o.IDKlient, o.IDAufenthalt})
                    //foreach (var rK in vK)
                    //{
                    //    string sTmp = rK.IDKlient.ToString();
                    //}

                    //var vI = _repoWrapper.vInterventionen.FindByCondition(o => o.IDKlient == new Guid("ac6bd9ed-c711-4acf-aa11-a454dcd3617b") && o.IDLinkDokument == new Guid("d1094a0a-fbbe-4db3-b8f5-9f84f91458ca"));
                    //foreach (var rI in vI)
                    //{
                    //    string sTmp = rI.IDKlient.ToString();
                    //}

                    //var vÜ = _repoWrapper.vÜbergabe.FindByCondition(o => o.IDKlient == new Guid("bc6bd9ed-c711-4acf-aa11-a454dcd3617b"));       //.Select(o => new { o.IDKlient, o.IDAufenthalt})
                    //foreach (var rÜ in vÜ)
                    //{
                    //    string sTmp = rÜ.IDKlient.ToString();
                    //}

                    //_repoWrapper.Benutzer.Save();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.TestUnits.TestsDevelop.runRepository1: " + ex.ToString());
            }
        }

        public static void runRepository2(Guid IDClient)
        {
            try
            { 
                Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient);

                ControllerBenutzer _cont = new ControllerBenutzer(new BenutzerRepository(context));

                //var res  =  _cont.Index().ToAsyncEnumerable();
                Task<IEnumerable<Benutzer>> task = _cont.Index();

                task.Wait();
                var x = task.Result;

                bool bReady = true;


                //TestRep2 TestRep2 = new TestRep2();
                //Task<IEnumerable<Benutzer>> task2 = TestRep2.getBenutzerAsync();

                //task2.Wait();
                //var x2 = task2.Result;

                //bool bReady2 = true;

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.TestUnits.TestsDevelop.runRepository2: " + ex.ToString());
            }
        }

        public async Task<IEnumerable<Benutzer>> getBenutzerAsync(Guid IDClient)
        {
            Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient);
            return await context.Benutzer.ToListAsync();

        }

        public static void runTestRepositoryAsync(Guid IDClient)
        {
            try
            {
                Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient);

                var tTestView1 = context.TestView1.Where(o => o.Vorname == "PMS...1").Select(o => new { o.Vorname, o.Nachname, o.Signatur });
                foreach (var rTestView1 in tTestView1)
                {
                    string sTmp = rTestView1.Vorname;
                }

                
                var x4 = context.Benutzer.Where(o => o.Vorname == "PMS...1").Select(o => new { o.Vorname, o.Idadresse });
                var r = x4.First();
                string sTmp44 = r.Vorname;

                var t5 = (from p in context.Benutzer
                                            where p.Vorname == "Mil..."
                          orderby p.Nachname ascending, p.Vorname ascending
                                            select new
                                            {
                                                p.Vorname,
                                                p.Id
                                            }).ToList();
                foreach (var r2 in t5)
                {
                    string sTmp = r2.Vorname;
                }

                var tAbt = (from p in context.Abteilung
                          where p.Bezeichnung != "Mil..."
                          orderby p.Bezeichnung ascending 
                          select new
                          {
                              p.Bezeichnung,
                              p.Id
                          }).ToList();
                foreach (var rAbt in tAbt)
                {
                    string sTmp = rAbt.Bezeichnung;
                }

                TestsDevelop TestsDevelop1 = new TestsDevelop();






                RepositoryWrapperAsync _repoWrapper = new RepositoryWrapperAsync(context);

                
                Task<IEnumerable<Benutzer>> task2 = TestsDevelop1.GetAllOwnersAsync(IDClient);

                Task<bool> task3 = null;
                Benutzer benUpdate = null;
                task2.Wait();
                IEnumerable<Benutzer> x2 = task2.Result.Where(o => o.Vorname == "PMS...1");
                foreach (Benutzer usr in x2)
                {
                    if (benUpdate == null) { benUpdate = usr; };
                    string NameTmp = usr.Nachname;

                    task3 = TestsDevelop1.SaveOwnerAsync("PMS...1", benUpdate.Id, IDClient);
                }

                bool bReady2 = true;

                task3.Wait();
                bool x3 = task3.Result;

                bool bReady3 = true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.TestUnits.TestsDevelop.runTestRepositoryAsync: " + ex.ToString());
            }
        }

        public async Task<IEnumerable<Benutzer>> GetAllOwnersAsync(Guid IDClient)
        {
            try
            {
                Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient);
                RepositoryWrapperAsync _repoWrapper = new RepositoryWrapperAsync(context);

                var owners = await _repoWrapper.Benutzer.GetAllOwnersAsync();

                return owners;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DAL.rep2.GetAllOwnersAsync: " + ex.ToString());
            }
        }
        public async Task<bool> SaveOwnerAsync(string Vorname, Guid ID, Guid IDClient)
        {
            try
            {
                Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient);
                RepositoryWrapperAsync _repoWrapper = new RepositoryWrapperAsync(context);

                context.Benutzer.Find(ID).Vorname = Vorname;
                await _repoWrapper.Benutzer.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DAL.rep2.SaveOwnerAsync: " + ex.ToString());
            }
        }





















        public void load(Guid IDClient)
        {
            Task t = new TestsDevelop().loadAll(IDClient);
            t.Wait();
        }

        private async Task loadAll(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                IAbteilung _abt = new AbteilungDAL(repoWrapper);
                ConcurrentBag<AbteilungDTO> lst = _abt.getAll();

                //IarchOrdner _ArchOrd = new archOrdnerDAL(repoWrapper);
                //List<archOrdnerDTO> lst2 = _ArchOrd.getAll();

                var taAb = GetAbteilungAsync(repoWrapper);
                var taArchOr = archOrdnerAsync(repoWrapper);

                int i = 12;
                await Task.WhenAll(taAb, taArchOr);
                var rAb = taAb;
                var rArchOr = taArchOr;


                var tasks = new List<Task>();
                tasks.Add(GetAbteilungAsync(repoWrapper));
                tasks.Add(archOrdnerAsync(repoWrapper));
                await Task.WhenAll(tasks).ConfigureAwait(false);


                Task<List<PflegePlanDTO>> taPfleg1 = new PflegePlanDAL(repoWrapper).getAllAsync(IDClient);
                Task<List<PflegePlanDTO>> taPfleg2 = new PflegePlanDAL(repoWrapper).getWhereAsync(o => o.Id == System.Guid.NewGuid(), IDClient);

                var taAb2 = GetAbteilungAsync(repoWrapper);

                IPflegePlan _dalPflegPlan = new PflegePlanDAL(repoWrapper);
                List<PflegePlanDTO> dtoPflegPlan = _dalPflegPlan.getAllSmall();


                //Task taAbt2 = Task.Run(() =>
                //{
                //    IAbteilung _dal = new AbteilungDAL(repoWrapper);
                //    return _dal.getAll();
                //});

                //Task taAbt = (new Task<IList<AbteilungDTO>>(() =>
                //{
                //    IAbteilung _dal = new AbteilungDAL(repoWrapper);
                //    return _dal.getAll();
                //}));
                //taAbt.Start();

                var taarchOrdner = new Task<ConcurrentBag<archOrdnerDTO>>(() =>
                {
                    IarchOrdner _dal = new archOrdnerDAL(repoWrapper);
                    return _dal.getAll();
                });
                taarchOrdner.Start();
                await Task.WhenAll(taarchOrdner);


                Task taAbt = (new Task<ConcurrentBag<AbteilungDTO>>(() =>
                {
                    IAbteilung _dal = new AbteilungDAL(repoWrapper);
                    return _dal.getAll();
                }));
                taAbt.Start();
                await Task.WhenAll(taAbt);

                Task.WaitAll(taPfleg1, taPfleg2);
                var resTaPfleg1 = taPfleg1.Result;
                var resTaPfleg2 = taPfleg2.Result;

                //taAbt2.Wait();
                //taarchOrdner.Wait();

                //new Thread(() => { int i3 = 3; }).Start();
                //Task<IList<AbteilungDTO>> taskAbt = GetAbteilungAsync(repoWrapper);
            }
        }


        public async Task<ConcurrentBag<AbteilungDTO>> GetAbteilungAsync(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            IAbteilung _dto = new AbteilungDAL(repoWrapper);
            return _dto.getAll();
        }
        public async Task<ConcurrentBag<archOrdnerDTO>> archOrdnerAsync(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            IarchOrdner _dto = new archOrdnerDAL(repoWrapper);
            return _dto.getAll();
        }



        public void testPDFIum()
        {
            byte[] pdfDocu = File.ReadAllBytes("F:\\develop\\test.pdf");

            using (MemoryStream ms = new MemoryStream())
            {
                var form = new PdfForms();
                Patagames.Pdf.Net.PdfDocument docPDF = Patagames.Pdf.Net.PdfDocument.Load(pdfDocu, form);
                int i = 0;
                foreach (var field in form.InterForm.Fields)
                {
                    if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                    {
                        field.Value = "";
                    }
                }

                docPDF.Save(ms, SaveFlags.RemoveSecurity);
                pdfDocu = ms.ToArray();
            }


            //byte[] bPdfForPreview = null;
            //PdfLoadedDocument ldoc = null;

            //ldoc = new PdfLoadedDocument(pdfDocu);
            //if (ldoc.Form != null)
            //{
            //    ldoc.Form.Flatten = true;
            //}
            //MemoryStream msPdf = new MemoryStream();
            //ldoc.Save(msPdf);
            //msPdf.Flush();
            //bPdfForPreview = msPdf.ToArray();
        }


    }
}


