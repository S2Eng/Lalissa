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
using PMDS.Global;
using PMDS.Global.db.ERSystem;
using PMDSClient.Sitemap;
using QS2.Desktop.ControlManagment.ServiceReference_01;

namespace PMDS.GUI.ELGA
{

    public partial class contELGASearchPatient : UserControl
    {

        public frmELGASearchPatient mainWindow = null;
        public bool IsInitialized = false;

        public PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow _rSelRow = null;
        public Guid _IDPatient;
        public Guid _IDAufenthalt;
        public bool abort = true;

        public UIGlobal UIGlobal1 = new UIGlobal();
        public WCFServiceClient WCFServiceClient1 = new WCFServiceClient();

    







        public contELGASearchPatient()
        {
            InitializeComponent();
        }

        private void ContELGASearchPatient_Load(object sender, EventArgs e)
        {

        }



        public void initControl(Guid IDPatient, Guid IDAufenthalt, bool SozVersNrEditable)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._IDPatient = IDPatient;
                    this._IDAufenthalt = IDAufenthalt;

                    this.mainWindow.AcceptButton = this.btnSave;
                    this.mainWindow.CancelButton = this.btnAbort;

                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                    

                    this.txtSozVersNr.ReadOnly = SozVersNrEditable;

                    this.clearUI();
                    this.loadData();

                    if (ENV.adminSecure)
                    {
                        this.txtSozVersNr.ReadOnly = false;
                    }

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.contELGASettings: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtSozVersNr.Text = "";
                this.dsManage1.ELGASearchPatients.Clear();
                this.gridFound.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.clearUI: " + ex.ToString());
            }
        }


        public void loadData()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rPatient = (from p in db.Patient
                               where p.ID == this._IDPatient
                               select new
                               {
                                   ID = p.ID,
                                   Nachname = p.Nachname,
                                   Vorname = p.Vorname,
                                   VersicherungsNr = p.VersicherungsNr
                               }).First();

                    this.txtSozVersNr.Text = rPatient.VersicherungsNr.Trim();
                    //this.txtSozVersNr.Text = "SVNR01";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                this.errorProvider1.SetError(this.txtSozVersNr, "");

                if (this.txtSozVersNr.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtSozVersNr, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soz.Vers.Nr: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                if (this.txtSozVersNr.Text.Trim().Length < 2)
                {
                    this.errorProvider1.SetError(this.txtSozVersNr, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soz.Vers.Nr: Mind. 2 Zeichen Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.validateData: " + ex.ToString());
            }
        }
        public bool searchData()
        {
            try
            {
                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return false;
                }

                if (!this.validateData())
                {
                    return false;
                }

                this.dsManage1.ELGASearchPatients.Clear();
                this.gridFound.Refresh();

                ELGAParOutDto parOuot = WCFServiceClient1.ELGAQueryPatients(this.txtSozVersNr.Text.Trim(), ELGABALeTypeQueryPatients.SozVersNr, false);
                if (parOuot.lPatientsk__BackingField.Count() > 0)
                {
                    foreach (ELGAPatientDTO elgaPatient in parOuot.lPatientsk__BackingField)
                    {
                        dsManage.ELGASearchPatientsRow rPatientFound = this.sqlManange1.getNewELGAPatient(ref this.dsManage1);

                        rPatientFound.ID = elgaPatient.IDk__BackingField;
                        rPatientFound.NachnameFirma = elgaPatient.familyNamek__BackingField.Trim();
                        rPatientFound.Vorname = elgaPatient.givenNamek__BackingField.Trim();
                        rPatientFound.PLZ = elgaPatient.zipk__BackingField.Trim();
                        rPatientFound.Ort = elgaPatient.cityk__BackingField.Trim();
                        rPatientFound.Land = elgaPatient.countryk__BackingField.Trim();
                        rPatientFound.Strasse = elgaPatient.streetAddressk__BackingField.Trim();
                        
                        if (!string.IsNullOrEmpty(elgaPatient.businessPhonek__BackingField.Trim()))
                        {
                            rPatientFound.Tel = elgaPatient.businessPhonek__BackingField.Trim();
                        }
                        else
                        {
                            rPatientFound.Tel = elgaPatient.homePhonek__BackingField.Trim();
                        }

                        foreach (ELGAPidsDTO rPid in elgaPatient.ELGAPidsk__BackingField)
                        {
                            if (rPid.patientIDTypek__BackingField.ToLower() == ("HC").ToLower())
                            {
                                rPatientFound.IDElga = rPid.patientIDk__BackingField.Trim();
                                rPatientFound.SozVersNr = rPatientFound.IDElga;
                            }
                        }
                    }
                }
                this.gridFound.Refresh();


                string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientensuche nach Soz.Vers.Nr '{0}' durchgeführt");
                sProt = string.Format(sProt, this.txtSozVersNr.Text.Trim());
                ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientensuche"), null,
                                                ELGABusiness.eTypeProt.QueryPatients, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, this._IDPatient, this._IDAufenthalt, sProt);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.searchData: " + ex.ToString());
            }
        }


        public bool selectData(bool withMsgBox)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                this._rSelRow = this.getSelectedRow(withMsgBox, ref gridRow);
                if (this._rSelRow != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.selectData: " + ex.ToString());
            }
        }

        public PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridFound.ActiveRow != null)
                {
                    if (this.gridFound.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile in der Tabelle ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridFound.ActiveRow.ListObject;
                        PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow rSelRow = (PMDS.Global.db.ERSystem.dsManage.ELGASearchPatientsRow)v.Row;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile in der Tabelle ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchPatient.getSelectedRow: " + ex.ToString());
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchData();

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
        private void BtnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.selectData(true))
                {
                    this.abort = false;
                    this.mainWindow.Close();
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



        private void GridFound_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals(("xy").Trim().ToLower()))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridFound_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridFound_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridFound))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridFound_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridFound))
                {
                    if (this.selectData(false))
                    {
                        this.abort = false;
                        this.mainWindow.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}

