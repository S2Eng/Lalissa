using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.Engines;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using Infragistics.Win.UltraWinListView;
using PMDS.Print;
using PMDS.DB;
using System.Linq;
using PMDS.Global.db.Global;
using PMDS.GUI.Medikament;

namespace PMDS.GUI
{


    public partial class ucMed1Verschreiben : QS2.Desktop.ControlManagment.BaseControl, IAufenthalt, ISave
    {

        public event EventHandler ValueChanged;

        private Guid                _aufenthalt = Guid.Empty;
        private bool                _dataChanged = false;
        private Guid                _IDPatient = Guid.Empty;

        public ucMedikamenteMain ucMedikamenteStammdatenMain = null;

        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        

               


        public ucMed1Verschreiben()
        {
            InitializeComponent();
        }


        


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthalt
        {
            get { return _aufenthalt; }
            set
            {
                if (value == _aufenthalt)
                    return;

                _aufenthalt = value;
                RefreshControl();
            }
        }
        public void RefreshControl()
        {
            if (this.Visible)
            {
                if (_aufenthalt != Guid.Empty)
                {
                    Aufenthalt a = new Aufenthalt(_aufenthalt);
                    _IDPatient = a.IDPatient;
                    //ReadRezeptList();
                }
                ucMed1VerschreibenDetailAll.IDAufenthalt = _aufenthalt;
                
                this.showInfoRezeptgebührbefreiung();
            }
        }

        public void showInfoRezeptgebührbefreiung()
        {
            try
            {
                this.txtInfoRezeptgebührbefreiung2.Value = "";
                this.panelInfoRezeptgebührenbefreiungJN.Visible = false;

                PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
                string TitleRezeptgebührenbefreit = "";
                string InfoRezeptgebührenbefreit = "";
                bool bIsRezeptgebührenbefreit = bUI.showInfoRezeptgebührbefreiungByAufenthalt(IDAufenthalt, ref TitleRezeptgebührenbefreit, ref InfoRezeptgebührenbefreit, true);
                if (bIsRezeptgebührenbefreit)
                {
                    this.txtInfoRezeptgebührbefreiung2.Value = InfoRezeptgebührenbefreit;
                    this.panelInfoRezeptgebührenbefreiungJN.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("showInfoRezeptgebührbefreiung: " + ex.ToString());
            }
        }

        private void ucRezeptEdit2_VisibleChanged(object sender, EventArgs e)
        {
            //this._RefreshNeeded = true;
            RefreshControl();
        }

        public void Write()
        {
            ucMed1VerschreibenDetailAll.Write();
        }
        
        private bool SaveDetails()
        {
            try
            {
                //if (!ValidateFields())
                //    return false;
                 Write();

                List<PMDS.DB.PMDSBusiness.cField> lstData = new List<DB.PMDSBusiness.cField>();
                //tRezeptEinträgeFound.Columns.Add("Dringend", typeof(string));

                this.ucMed1VerschreibenDetailAll.doActionGrid(ref lstData, ucMed1VerschreibenDetail.eTypActionGrid.GetRowsBestellung);

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDSBusiness1.AddBestellungen(ref lstData);
                if (lstData.Count > 0)
                {
                    foreach (PMDS.DB.PMDSBusiness.cField Field in lstData)
                    {
                        Field.rGrid.Cells["ZuletztBestelltAm"].Value = Field.ZuletztBestelltAm;
                        Field.rGrid.Cells["ZuletztBestelltVon"].Value = Field.ZuletztBestelltVon;
                    }
                }

                this.ucMed1VerschreibenDetailAll.doActionGrid(ref lstData, ucMed1VerschreibenDetail.eTypActionGrid.ResetFlags);

                DataChanged = false;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucRezepteEdit2.SaveDetails: " + ex.ToString());
            }
        }

        public bool ValidateFields()
        {
            bool bError = false;
           
            
            if (!bError)
                bError = !ucMed1VerschreibenDetailAll.ValidateFields();

            return !bError;
        }

        public bool CanClose
        {
            get
            {
                bool bClose = true;
                if (DataChanged)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                                ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                                MessageBoxButtons.YesNoCancel,
                                                                                                MessageBoxIcon.Question, true);
                    switch (res)
                    {
                        case DialogResult.Yes:
                            if (!SaveDetails())
                                bClose = false;
                            break;

                        case DialogResult.No:
                            undo();
                            break;

                        case DialogResult.Cancel:
                            bClose = false;
                            break;
                    }
                }

                return bClose;
            }
        }

        public bool ShowButtons
        {
            get { return btnUndo.Visible; }
            set
            {
                btnUndo.Visible = value;
                btnSave.Visible = value;
            }
        }
        
        public bool DataChanged
        {
            get { return _dataChanged; }

            set
            {

                _dataChanged = value; 

                btnSave.Enabled = value;
                btnUndo.Enabled = value;

                             
                bool bButtons = false;
                bButtons |= (btnSave.Visible);
                bButtons |= (btnUndo.Visible);
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            this.ucMed1VerschreibenDetailAll.setControlsAktivDisable(bOn);
            panelButtons.Visible = !bOn;

        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                undo();

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

        private void undo()
        {
            this.RefreshControl();            
            DataChanged = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (SaveDetails())
                {
                    //PflegeEintrag.NewRezeptAenderungEinfuegen(IDAufenthalt, DateTime.Now);
                }
                DataChanged = false;

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
                     
        protected void OnValueChanged(object sender, EventArgs args)
        {
            //if (_initinProgressxy)
            //    return;
           
            DataChanged = true;
            if (ValueChanged != null)
                ValueChanged(sender, args);
           
        }


        public bool Save()
        {
            return SaveDetails();
        }

        public bool IsChanged
        {
            get
            {
                return DataChanged;
            }
        }

        public void Undo()
        {
            this.RefreshControl();      
        }


        private void btnPrintMedBlatt_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ucMed1VerschreibenDetailAll.PrintMedikamentenBlatt();
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

        private void btnTerminErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GuiAction.InsertTermin(this.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, null, null, null);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void btnMedDaten_Click()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsRezeptEintrag.RezeptEintragRow rSelRow = this.ucMed1VerschreibenDetailAll.getSelectedRow(true, ref gridRow);
                if (rSelRow != null)
                {
                    PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                    frmRezeptEintragMedDaten1.initControl(rSelRow.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2);
                    frmRezeptEintragMedDaten1.ShowDialog(this);
                    if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                    {
                        string lstMedDaten = "";
                        int NumberMedDaten = 0;
                        string lstWunden = "";
                        int NumberWunden = 0;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.b2.saveAnzeigeGridRezeptEintrag(rSelRow.ID, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                            db.SaveChanges();

                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == rSelRow.ID && o.IDMedDaten != null && o.IDVerordnung == null);
                            if (tRezeptEintragMedDaten.Count() > 0)
                            {
                                foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                                {
                                    if (rRezeptEintragMedDaten2.IDMedDaten != null)
                                    {
                                        int NumberRezepteinträge = 0;
                                        string lstRezepteinträge = "";
                                        this.b2.saveAnzeigeGridMedDaten(rRezeptEintragMedDaten2.IDMedDaten.Value, db, ref lstRezepteinträge, ref NumberRezepteinträge);
                                    }
                                }
                                db.SaveChanges();
                            }
                        }

                        rSelRow.NumberMedDaten = NumberMedDaten;
                        rSelRow.lstMedDaten = lstMedDaten;
                        rSelRow.NumberWunden = NumberWunden;
                        rSelRow.lstWunden = lstWunden;
                        this.ucMed1VerschreibenDetailAll.dgEintraege.Refresh();
                        
                        //if (rSelRow.AbzugebenBis.Year != 3000)
                        //{
                        //    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        //    {
                        //        b2.checkRezeptEintragAbgesetzt(rSelRow.ID, db);
                        //    }
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public void btnWunden_Click()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsRezeptEintrag.RezeptEintragRow rSelRow = this.ucMed1VerschreibenDetailAll.getSelectedRow(true, ref gridRow);
                if (rSelRow != null)
                {
                    PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                    frmRezeptEintragMedDaten1.initControl(rSelRow.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.RezeptEintragShowWundKopf);
                    frmRezeptEintragMedDaten1.ShowDialog(this);
                    if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                    {
                        string lstMedDaten = "";
                        int NumberMedDaten = 0;
                        string lstWunden = "";
                        int NumberWunden = 0;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.b2.saveAnzeigeGridRezeptEintrag(rSelRow.ID, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                            db.SaveChanges();
                        }

                        rSelRow.NumberMedDaten = NumberMedDaten;
                        rSelRow.lstMedDaten = lstMedDaten;
                        rSelRow.NumberWunden = NumberWunden;
                        rSelRow.lstWunden = lstWunden;
                        this.ucMed1VerschreibenDetailAll.dgEintraege.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnMedDaten_Click(object sender, EventArgs e)
        {

        }

        private void ucMed1VerschreibenDetailAll_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnKlientenMitGleichemMedikament_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsRezeptEintrag.RezeptEintragRow rSelRow = this.ucMed1VerschreibenDetailAll.getSelectedRow(false, ref gridRow);
                if (rSelRow != null)
                {
                    frmPatientenGleichesMedikament frm = new frmPatientenGleichesMedikament();
                    frm.initControl(rSelRow.IDMedikament, rSelRow.IDAufenthalt);
                    frm.ShowDialog(this);
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Medikament ausgewählt!", "", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    
    }

}

