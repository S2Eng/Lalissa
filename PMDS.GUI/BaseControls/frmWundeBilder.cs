using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Global;
using PMDS.Global;
using System.IO;
using System.Drawing.Imaging;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using PMDS.DB;


namespace PMDS.GUI.BaseControls
{
    
    public partial class frmWundeBilder : QS2.Desktop.ControlManagment.baseForm 
    {
        public Guid _IDWundePos;
        public bool _editable = false;

        public bool abort = true;
        public bool IsInitialized = false;
        
        public UIGlobal UIGlobal1 = new UIGlobal();
        public Wunde _wundeMain = null;
        public dsWunde _dsWundeMain = null;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();








        public frmWundeBilder()
        {
            InitializeComponent();

            if (!ENV.AppRunning)
                return;

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }
        

        private void frmWundeBilder_Load(object sender, EventArgs e)
        {
        }
        private void frmWundeBilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }




        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.initControl: " + ex.ToString());
            }
        }
        public void loadData2(Guid IDWundePos, Wunde wundeMain, dsWunde dsWundeMain)
        {
            try
            {
                this._IDWundePos = IDWundePos;
                this._wundeMain = wundeMain;
                this._dsWundeMain = dsWundeMain;

                this.abort = true;
                dgMain.Rows.ColumnFilters.ClearAllFilters();
                this.dsWunde2.Clear();

                this.dbWunde1.FillBilder(IDWundePos, this.dsWunde2);
                this.dgMain.Refresh();

                this.checkEditable(IDWundePos);
                //dgMain.Rows.ColumnFilters["IDWundePos"].FilterConditions.Add(FilterComparisionOperator.Equals, IDWundePos);
            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.loadData: " + ex.ToString());
            }
        }
        public void checkEditable(Guid IDWundePos)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.WundePos rWundePos = this.b.getWundePos(IDWundePos, db);
                    //if (rWundePos != null && rWundePos.DatumErstellt.Value.AddHours(ENV.WundbildModifyTime) < DateTime.Now)
                    //{
                    //    this.setEditableOnOff(false);
                    //}
                    //else
                    //{
                    //    this.setEditableOnOff(true);
                    //}

                    //System.Windows.Forms.MessageBox.Show("Wundbildzeit: " + (rWundePos.Erhebungszeitpunkt.Value.AddHours(ENV.WundbildModifyTime) > DateTime.Now).ToString());
                    //System.Windows.Forms.MessageBox.Show("Recht: " + ENV.HasRight(UserRights.WundeÄndern).ToString());
                    //System.Windows.Forms.MessageBox.Show("Benutzer_erstellt: " + rWundePos.IDBenutzer_Erstellt.Value.ToString());

                    
                    //System.Windows.Forms.MessageBox.Show("Rolle: " + this.b.UserCanEdit(rWundePos.IDBenutzer_Erstellt.Value, PflegeEintragTyp.Wundverlauf).ToString());


                    //rWundePos == null -> Neuer Eintrag, Editable auf jeden Fall false
                    if (rWundePos == null)
                    {                       ;
                        //System.Windows.Forms.MessageBox.Show("Keine Wundinfo gefunden.");
                        this.setEditableOnOff(false);
                    }
                    else if (ENV.adminSecure)
                    {
                        this.setEditableOnOff(true);
                    }
                    else if (rWundePos.Erhebungszeitpunkt.Value.AddHours(ENV.WundbildModifyTime) > DateTime.Now && 
                        ENV.HasRight(UserRights.WundeÄndern) &&
                        rWundePos.IDBenutzer_Erstellt != null &&
                        this.b.UserCanEdit(rWundePos.IDBenutzer_Erstellt.Value, PflegeEintragTyp.Wundverlauf))
                    {
                        this.setEditableOnOff(true);
                    }
                    else
                    {
                        this.setEditableOnOff(false);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.checkEditable: " + ex.ToString());
            }
        }
        public void setEditableOnOff(bool bOn)
        {
            try
            {
                this.btnAdd.Visible = bOn;
                this.btnDel.Visible = bOn;
                this.btnSave.Enabled = bOn;
                this._editable = bOn;

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.checkEditable: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                this._wundeMain.Write(this._dsWundeMain);
                this.dbWunde1.daWundePosBilder.Update(this.dsWunde2.WundePosBilder);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.saveData: " + ex.ToString());
            }
        }


        private string selectFile()
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res != DialogResult.OK)
                    return "";
                string sFile = openFileDialog1.FileName;
                if (!File.Exists(sFile))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datei " + sFile + " existiert nicht");
                    return "";
                }

                return sFile;

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.selectFile: " + ex.ToString());
            }
        }

        public void addRow()
        {
            try
            {
                string sNewImage = this.selectFile();
                if (sNewImage == "")
                    return;

                //frmPictureViewer frmPictureViewer1 = new frmPictureViewer();
                //frmPictureViewer1.initControl(sNewImage);
                //frmPictureViewer1.ShowDialog(this);
                //if (frmPictureViewer1.abort)
                //{
                //    return;
                //}


                dsWunde.WundePosBilderRow r = this.dsWunde2.WundePosBilder.NewWundePosBilderRow();
                r.ID = Guid.NewGuid();
                r.IDWundePos = _IDWundePos;
                r.Bild = File.ReadAllBytes(sNewImage);
                FileInfo info = new FileInfo(sNewImage);
                r.ZeitpunktBild = info.LastWriteTime;
                r.Reihenfolge = 0;
                r.druckenJN = true;
                r.Beschreibung = "";

                using (Image i = Image.FromFile(sNewImage))
                {
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(this.GetThumbnailImageAbort);
                    Image it = i.GetThumbnailImage(100, 80, myCallback, IntPtr.Zero);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        it.Save(ms, ImageFormat.Jpeg);
                        r.Thumbnail = ms.GetBuffer();
                    }
                    this.dsWunde2.WundePosBilder.AddWundePosBilderRow(r);
                }

                r = null;

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundeBilder.addRow: " + ex.ToString());
            }
        }
        public bool GetThumbnailImageAbort()
        {
            return false;
        }


        private void dgMain_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (this._editable)
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void dgMain_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgMain))
                    {
                    }

                }
                catch (Exception ex)
                {
                    PMDS.Global.ENV.HandleException(ex);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void dgMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgMain))
                    {
                    }

                }
                catch (Exception ex)
                {
                    PMDS.Global.ENV.HandleException(ex);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addRow();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
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

                if (dgMain.ActiveRow == null)
                    return;

                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Bild wirklich löschen ?", "Bild löschen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    return;

                dgMain.ActiveRow.Delete(false);

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.saveData())
                {
                    this.abort = false;
                    this.Close();
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
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.abort = true;
                this.Close();
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
        
    }

}
