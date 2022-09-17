using Infragistics.Documents.Excel;
using Microsoft.Win32.SafeHandles;
using qs2.core.db.ERSystem;
using QS2.db.Entities;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace qs2.core.BAL
{
    public class ImportHelpFromExcel : IDisposable
    {
        private bool Disposed { get; set; } = false;
        private SafeHandle Handle { get; set; } = new SafeFileHandle(IntPtr.Zero, true);



        public void run(string app, ref string prot)
        {
            string f = this.getExcelFile();
            if (string.IsNullOrEmpty(f))
                return;

            Workbook wb = Workbook.Load(f);
            using (ERModellQS2Entities db = businessFramework.getDBContext())
            {
                string sqlDel = string.Concat("Delete from qs2.Ressourcen where Type='Help' and IDApplication='", app, "' and IDParticipant='ALL' and IDLanguageUser='ALL'");
                db.Database.ExecuteSqlCommand(sqlDel);

                int nr = 1;
                int iSaved = 0;
                bool bSearch = true;
                while (wb.Worksheets[0].Rows[nr] != null && bSearch)
                {
                    WorksheetRow r = wb.Worksheets[0].Rows[nr];
                    string fldtmp = hasValue<object>(r.Cells[1].Value);
                    try
                    {
                        string fldtmpNext = hasValue<object>(wb.Worksheets[0].Rows[nr + 1].Cells[1].Value);
                        if (string.IsNullOrEmpty(fldtmp) && string.IsNullOrEmpty(fldtmpNext))
                            bSearch = false;
                        else
                        {
                            if (!string.IsNullOrEmpty(fldtmp) || (string.IsNullOrEmpty(fldtmp) && !string.IsNullOrEmpty(fldtmpNext)))
                            {
                                if (!string.IsNullOrEmpty(fldtmp) && checkCriteria(fldtmp, app, db))
                                {
                                    var rCheckRes = (from rRes in db.Ressourcen where rRes.IDRes == fldtmp && rRes.Type == "Help" && rRes.IDApplication == app && rRes.IDParticipant == "ALL" && rRes.IDLanguageUser == "ALL" select new { rRes.IDRes}).FirstOrDefault();
                                    if (rCheckRes == null)
                                    {
                                        Ressourcen rRes = this.newRes(app, hasValue<object>(r.Cells[1].Value), hasValue<object>(r.Cells[0].Value), hasValue<object>(r.Cells[3].Value));
                                        db.Ressourcen.Add(rRes);
                                        db.SaveChanges();
                                        iSaved += 1;
                                    }
                                    else
                                        prot += string.Concat(hasValue<object>(r.Cells[1].Value), ": Field cannot be imported because it is already imported", "\r\n");
                                }
                                nr += 1;
                            }
                        }
                    }
                    catch (DbEntityValidationException ex)
                    {
                        throw new System.Data.Entity.Validation.DbEntityValidationException("Error Excel-Field: " + fldtmp + "\r\n" + qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ImportHelpFromExcel.run: Error Excel-Field: " + fldtmp + "\r\n" + ex.ToString());
                    }
                }
                //db.SaveChanges();
                prot = string.Concat(Convert.ToString(iSaved), " fields imported!", "\r\n", prot);
            }
        }

        public string getExcelFile()
        {
            OpenFileDialog fd = new OpenFileDialog() { RestoreDirectory = true, Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx|Microsoft Excel Files (*.xls)|*.xls", FilterIndex = 0, InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)};
            if (fd.ShowDialog() == DialogResult.OK)
                return fd.FileName;
            else
                return "";
        }

        public bool checkCriteria(string fldshort, string app, ERModellQS2Entities db)
        {
            var r = (from c in db.tblCriteria where c.FldShort == fldshort && c.IDApplication == app select new { c.FldShort, c.IDApplication, c.AliasFldShort }).FirstOrDefault();
            if (r is null)
            {
                r = (from c in db.tblCriteria where c.FldShort == fldshort && c.IDApplication == "All" select new { c.FldShort, c.IDApplication, c.AliasFldShort }).FirstOrDefault();
                if (r is null) return false;
            }
            return true;
        }

        public Ressourcen newRes(string app, string IDRes, string fieldN, string German)
        {
           return new Ressourcen() {
                    IDRes = IDRes, German = German, English = German, IDApplication = app, IDParticipant = "ALL",
                    Type = "Help", fileType = "", TypeSub = "", CreatedUser = "", User = "", IDLanguageUser = "ALL",
                    Description = fieldN, Classification = "", ResGroup = "", Created = DateTime.Now, LastChange = DateTime.Now,
                    IDGuid = System.Guid.NewGuid(), fileBytes = null, Image = "", ImageHeigth = -1, ImageWidth = -1};
        }

        public string hasValue<T>(T v)
        {
            if (v == null)
                return "";
            else
                return v.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                Handle.Dispose();
            }
            Disposed = true;
        }
    }

}
