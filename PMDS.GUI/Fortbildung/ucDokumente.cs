using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;

using System.IO;





namespace PMDS.GUI.Fortbildung
{


    public partial class ucDokumente : UserControl
    {

        public Nullable<Guid> _IDFortbildungBenutzer;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public bool Isinitialized = false;








        public ucDokumente()
        {
            InitializeComponent();
        }

        private void ucDokumente_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.lvDokumente.Items.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.clearUI: " + ex.ToString());
            }
        }
        public void loadDokumente2(Nullable<Guid> IDFortbildungBenutzer)
        {
            try
            {
                this._IDFortbildungBenutzer = IDFortbildungBenutzer;
                this.clearUI();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Dokumente2> tDokumente2 = this.b.loadFortbildungBenutzerDokumente(IDFortbildungBenutzer, db);
                    foreach (Dokumente2 rDokumente2 in tDokumente2)
                    {
                        string sErstelltAm = QS2.Desktop.ControlManagment.ControlManagment.getRes(" vom ") + rDokumente2.ErstelltAm.ToString("dd.MM.yyyy") + "";
                        UltraListViewItem listItem = new UltraListViewItem(rDokumente2.Bezeichnung.Trim() + "" + sErstelltAm, null, null);
                        listItem.Key = rDokumente2.ID.ToString();
                        listItem.Tag = rDokumente2.ID;
                        listItem.CheckState = CheckState.Unchecked;
                        this.lvDokumente.Items.Add(listItem);
                    }

                    this.lvDokumente.Refresh();

                    this.lvDokumente.SelectedItems.Clear();
                    this.lvDokumente.ActiveItem = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.loadDokumente: " + ex.ToString());
            }
        }
        public void add()
        {
            try
            {
                frmInputBezeichnung frmInputBezeichnung1 = new frmInputBezeichnung();
                frmInputBezeichnung1.initControl();
                frmInputBezeichnung1.ShowDialog(this);
                if (!frmInputBezeichnung1.abort)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "pdf-files (*.pdf)|*.pdf|word-files (*.docx)|*.docx|All files (*.*)|*.*";
                        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        dialog.Title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wählen Sie bitte eine Datei aus:");

                        DialogResult DialogRes = dialog.ShowDialog();
                        if (DialogRes == DialogResult.OK)
                        {
                            if (System.IO.File.Exists(dialog.FileName))
                            {
                                string FileType = Path.GetExtension(dialog.FileName).Trim();
                                System.IO.FileStream fs = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
                                byte[] bytDocument = r.ReadBytes(System.Convert.ToInt32(fs.Length));
                                fs.Close();
                                r.Close();

                                byte[] JPGToSave = null;
                                bool JPGOK = this.b.pdfToImage(bytDocument, ref JPGToSave);
                                if (!JPGOK)
                                {
                                    throw new Exception("pdfToImage: Jpg could not generated!");
                                }

                                Dokumente2 NewDokumente2 = new Dokumente2();
                                this.b.newRowDokumente2(ref NewDokumente2);
                                NewDokumente2.Bezeichnung = frmInputBezeichnung1.txtBezeichnung.Text.Trim();
                                NewDokumente2.TypeDocu = "Fortbildung";
                                NewDokumente2.fileType = FileType.Trim();
                                NewDokumente2.byteDoc = bytDocument;
                                NewDokumente2.byteJpg = JPGToSave;
                                NewDokumente2.IDRelation = this._IDFortbildungBenutzer;

                                db.Dokumente2.Add(NewDokumente2);
                                db.SaveChanges();
                                this.loadDokumente2(this._IDFortbildungBenutzer);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.add: " + ex.ToString());
            }
        }
        public void delete(Guid IDDokument2)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Dokument wirklich löschen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<Dokumente2> tDokumente2 = db.Dokumente2.Where(p => p.ID == IDDokument2);
                        Dokumente2 rDokumente2 = tDokumente2.First();
                        db.Dokumente2.Remove(rDokumente2);
                        db.SaveChanges();

                        this.loadDokumente2(this._IDFortbildungBenutzer);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.delete: " + ex.ToString());
            }
        }

        public bool openDocument(Guid IDDokument2)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<Dokumente2> tDokumente2 = db.Dokumente2.Where(p => p.ID == IDDokument2);
                    Dokumente2 rDokumente2 = tDokumente2.First();

                    MemoryStream ms = new MemoryStream(rDokumente2.byteDoc);
                    string sGuid = Guid.NewGuid().ToString();
                    string FileTmp = System.IO.Path.Combine(PMDS.Global.ENV.path_Temp.Trim(), sGuid.Trim() + rDokumente2.fileType.Trim());
                    using (FileStream file = new FileStream(FileTmp.Trim(), FileMode.Create, System.IO.FileAccess.Write))
                    {
                        byte[] bytes = new byte[ms.Length];
                        ms.Read(bytes, 0, (int)ms.Length);
                        file.Write(bytes, 0, bytes.Length);
                        ms.Close();
                    }
                    PMDS.GUI.VB.clFolder clFolder1 = new PMDS.GUI.VB.clFolder();
                    clFolder1.openFile(FileTmp.Trim(), false);

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.openDocument: " + ex.ToString());
            }
        }

        public Nullable<Guid> getSelectedItem(bool WithMsgBox)
        {
            try
            {
                if (this.lvDokumente.ActiveItem != null)
                {
                    Guid IDDokument2 = new Guid(this.lvDokumente.ActiveItem.Tag.ToString().Trim());
                    return IDDokument2;
                }
                else
                {
                    if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Dokument ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDokumente.getSelectedItem: " + ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.add();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDDokument2 = this.getSelectedItem(true);
                if (IDDokument2 != null)
                {
                    this.delete((Guid)IDDokument2);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lvDokumente_Click(object sender, EventArgs e)
        {
            try
            {
                Nullable<Guid> IDDokument2 = this.getSelectedItem(true);
                if (IDDokument2 != null)
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void lvDokumente_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Nullable<Guid> IDDokument2 = this.getSelectedItem(true);
                if (IDDokument2 != null)
                {
                    this.openDocument((Guid)IDDokument2);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
