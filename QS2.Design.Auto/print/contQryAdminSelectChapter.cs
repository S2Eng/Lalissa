using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.db.Entities;

namespace qs2.design.auto.print
{


    public partial class contQryAdminSelectChapter : UserControl
    {
        public frmQryAdminSelectChapter mainWindow = null;
        public bool abort = true;

        public string _Chapters = "";
        public string _Chapter = "";
        public string _IDApplication = "";

        public string SelChapterKey = "";
        public string SelChapterTransl = "";

        public qs2.core.ui ui1 = new qs2.core.ui();
        





        public contQryAdminSelectChapter()
        {
            InitializeComponent();
        }

        private void contQryAdminSelectChapter_Load(object sender, EventArgs e)
        {

        }


        public void initControl(string Chapters, string Chapter, string IDApplication)
        {
            try
            {
                this.mainWindow.AcceptButton = this.btnOk;
                this.mainWindow.CancelButton = this.btnAbort;

                this._Chapter = Chapter;
                this._Chapters = Chapters;
                this._IDApplication = IDApplication;

                this.gridSelectChapter.Text = qs2.core.language.sqlLanguage.getRes("SelectChapter");
                //this.btnOk.Text = qs2.core.language.sqlLanguage.getRes("OK");
                this.btnAbort.Text = qs2.core.language.sqlLanguage.getRes("Abort");

                this.loadData();
            }
            catch (Exception ex)
            {
                throw new Exception("contQryAdminSelectChapter.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.dsHelper1.Clear();

                System.Collections.Generic.List<string> lstChapters = qs2.core.generic.readStrVariables(this._Chapters);
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    foreach (string chapt in lstChapters)
                    {
                        var rChapterFound = (from sl in db.tblSelListEntries
                                             join slg in db.tblSelListGroup on sl.IDGroup equals slg.ID
                                             where (slg.IDGroupStr == "Chapters0" || slg.IDGroupStr == "Chapters1") && slg.IDApplication == this._IDApplication && sl.IDOwnStr == chapt
                                             select new { sl.IDRessource, sl.ID, sl.IDOwnStr }).FirstOrDefault();

                        core.vb.dsHelper.ChaptersRow rNewRow = (core.vb.dsHelper.ChaptersRow)dsHelper1.Chapters.NewRow();
                        rNewRow.ID = System.Guid.NewGuid();
                        if (rChapterFound != null)
                            rNewRow.Chapter = qs2.core.language.sqlLanguage.getRes(rChapterFound.IDRessource);
                        else
                            rNewRow.Chapter = chapt;
                        rNewRow.ChapterKey = chapt;

                        this.dsHelper1.Chapters.AddChaptersRow(rNewRow);
                    }
                }

                this.gridSelectChapter.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("contQryAdminSelectChapter.loadData: " + ex.ToString());
            }
        }


        public bool SelectChapter(bool WithMsgBox)
        {
            try
            {
                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsHelper.ChaptersRow SelRow = this.getSelectedRow(WithMsgBox, selRowGrid);
                if (SelRow != null)
                {
                    this.SelChapterKey = SelRow.ChapterKey;
                    this.SelChapterTransl = SelRow.Chapter;
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception("contQryAdminSelectChapter.SelectChapter: " + ex.ToString());
            }
        }


        private void gridSelectChapter_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }
        private void gridSelectChapter_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ui1.evClickOK(ref sender, ref e, ref this.gridSelectChapter))
                {

                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void gridSelectChapter_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ui1.evDoubleClickOK(ref sender, ref e, ref this.gridSelectChapter))
                {
                    if (this.SelectChapter(false))
                    {
                        this.abort = false;
                        this.mainWindow.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public qs2.core.vb.dsHelper.ChaptersRow getSelectedRow(bool msgBox, UltraGridRow selRowGrid)
        {
            try
            {
                if (this.gridSelectChapter.ActiveRow != null)
                {
                    if (this.gridSelectChapter.ActiveRow.IsGroupByRow || this.gridSelectChapter.ActiveRow.IsFilterRow)
                    {
                        if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridSelectChapter.ActiveRow.ListObject;
                        qs2.core.vb.dsHelper.ChaptersRow rSelRow = (qs2.core.vb.dsHelper.ChaptersRow)v.Row;
                        selRowGrid = this.gridSelectChapter.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contQryAdminSelectChapter.getSelectedRow: " + ex.ToString());
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.SelectChapter(true))
                {
                    this.abort = false;
                    this.mainWindow.Close();
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}

