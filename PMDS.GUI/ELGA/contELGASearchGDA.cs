using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global.db.ERSystem;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using PMDSClient.Sitemap;
using QS2.Desktop.ControlManagment.ServiceReference_01;
using static PMDSClient.Sitemap.WCFServiceClient;
using System.Text.RegularExpressions;

namespace PMDS.GUI.ELGA
{

    public partial class contELGASearchGDA : UserControl
    {

        public PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow _rSelRow = null;
        public Nullable<Guid> _IDPatient;
        public Nullable<Guid> _IDAufenthalt;
        public cSearchGdaFlds _FieldsSearch = null;

        public frmELGASearchGDA mainWindow = null;
        public bool IsInitialized = false;

        public bool abort = true;
        public UIGlobal UIGlobal1 = new UIGlobal();
        public WCFServiceClient WCFServiceClient1 = new WCFServiceClient();

        public eTypeUI _TypeUI;
        public enum eTypeUI
        {
            Ärzte = 0,
            Kliniken = 1,
            ExtEinrichtungen = 2
        }

        public ELGABusiness bELGA = new ELGABusiness();








        public contELGASearchGDA()
        {
            InitializeComponent();
        }

        private void ContELGASearchGDA_Load(object sender, EventArgs e)
        {

        }



        public void initControl(Nullable<Guid> IDPatient, Nullable<Guid> IDAufenthalt, cSearchGdaFlds FieldsSearch, eTypeUI TypeUI)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.mainWindow.AcceptButton = this.btnSearch;
                    this.mainWindow.CancelButton = this.btnAbort;

                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                    this._IDPatient = IDPatient;
                    this._IDAufenthalt = IDAufenthalt;
                    this._FieldsSearch = FieldsSearch;
                    this._TypeUI = TypeUI;

                    this.clearUI(true);

                    this.txtNachname.Text = this._FieldsSearch.NachnameFirma.Trim();
                    this.txtVorname.Text = this._FieldsSearch.Vorname.Trim();
                    this.txtPLZ.Text = this._FieldsSearch.PLZ.Trim();
                    this.txtOrt.Text = this._FieldsSearch.Ort.Trim();
                    this.txtStrasse.Text = this._FieldsSearch.Strasse.Trim();
                    this.txtStrasseNr.Text = this._FieldsSearch.StrasseNr.Trim();

                    if (this._TypeUI == eTypeUI.Kliniken || this._TypeUI == eTypeUI.ExtEinrichtungen)
                    {
                        this.lblVorname.Visible = false;
                        this.txtVorname.Visible = false;
                    }

                    this.loadData();

                    if (ENV.adminSecure)
                    {
                    }

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchGDA.contELGASettings: " + ex.ToString());
            }
        }

        public void clearUI(bool clearGrid)
        {
            try
            {
                this.txtNachname.Text = "";
                this.txtVorname.Text = "";
                this.txtPLZ.Text = "";
                this.txtOrt.Text = "";
                this.txtStrasse.Text = "";
                this.txtStrasseNr.Text = "";

                if (clearGrid)
                {
                    this.dsManage1.Clear();
                    this.gridFound.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchGDA.clearUI: " + ex.ToString());
            }
        }


        public void loadData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchGDA.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                this.errorProvider1.SetError(this.txtNachname, "");
                this.errorProvider1.SetError(this.txtVorname, "");
                this.errorProvider1.SetError(this.txtPLZ, "");
                this.errorProvider1.SetError(this.txtOrt, "");
                this.errorProvider1.SetError(this.txtStrasse, "");
                this.errorProvider1.SetError(this.txtStrasseNr, "");

                if (this.txtNachname.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtNachname, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nachname/Firma: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                if (this.txtNachname.Text.Trim().Length < 3)
                {
                    this.errorProvider1.SetError(this.txtNachname, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nachname/Firma: Mind. 3 Zeichen Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                PMDSBusinessUI bUI = new PMDSBusinessUI();
                bool bNachnameOk = bUI.checkTexteditorForStern(this.txtNachname, this.errorProvider1, QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname/Firma"));
                if (!bNachnameOk)
                {
                    return false;
                }
                bool bVornameOK = bUI.checkTexteditorForStern(this.txtVorname, this.errorProvider1, QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname"));
                if (!bVornameOK)
                {
                    return false;
                }

                if (this.txtPLZ.Text.Trim() != "")
                {
                    try
                    {
                        int iPLZ = Convert.ToInt32(this.txtPLZ.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        this.errorProvider1.SetError(this.txtNachname, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("PLZ darf nur Ziffern enthalten!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchGDA.validateData: " + ex.ToString());
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
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //var rAufenthalt = (from p in db.Aufenthalt
                    //                where p.ID == ENV.IDAUFENTHALT
                    //                   select new
                    //                {
                    //                    p.ID,
                    //                    p.IDPatient
                    //                }).First();
                    
                    //if (!this.bELGA.ELGAIsActive(rAufenthalt.IDPatient.Value, ENV.IDAUFENTHALT, true))
                    //{
                    //    return false;
                    //}

                    if (!this.validateData())
                    {
                        return false;
                    }

                    cSearchGdaFlds FieldsSearchingWcf = new cSearchGdaFlds()
                    {
                        NachnameFirma = this.txtNachname.Text.Trim(),
                        Vorname = this.txtVorname.Text.Trim(),
                        PLZ = this.txtPLZ.Text.Trim(),
                        Ort = "",
                        Strasse = "",
                        StrasseNr = ""
                    };

                    //cSearchGdaFlds FieldsSearchingWcf = new cSearchGdaFlds() { 
                    //    NachnameFirma = this.txtNachname.Text.Trim(),
                    //    Vorname = this.txtVorname.Text.Trim(), 
                    //    Ort = this.txtOrt.Text.Trim(),
                    //    PLZ = this.txtPLZ.Text.Trim(), 
                    //    Strasse = this.txtStrasse.Text.Trim(),
                    //    StrasseNr = this.txtStrasseNr.Text.Trim()
                    //};

                    this.dsManage1.Clear();
                    this.gridFound.Refresh();

                    ELGAParOutDto parOuot = WCFServiceClient1.ELGAQueryGDAs(FieldsSearchingWcf);

                    string sFieldsSearchingGda = "Felder:" + "\r\n";
                    sFieldsSearchingGda += "Nachname/Firma: " + FieldsSearchingWcf.NachnameFirma.Trim() + "\r\n";
                    sFieldsSearchingGda += "Vorname: " + FieldsSearchingWcf.Vorname.Trim() + "\r\n";
                    sFieldsSearchingGda += "PLZ: " + FieldsSearchingWcf.PLZ.Trim() + "\r\n";
                    //sFieldsSearchingGda += "Ort: " + FieldsSearchingWcf.Ort.Trim() + "\r\n";
                    //sFieldsSearchingGda += "Strasse: " + FieldsSearchingWcf.Strasse.Trim() + "\r\n";
                    //sFieldsSearchingGda += "StrasseNr: " + FieldsSearchingWcf.StrasseNr.Trim() + "\r\n";

                    string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gda-Suche wurde durchgeführt") + "\r\n" + sFieldsSearchingGda;
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("GDA-Suche") + " " + this._TypeUI.ToString(), null,
                                                    ELGABusiness.eTypeProt.ELGAQueryGDAs, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, this._IDPatient, this._IDAufenthalt, sProt);

                    if (parOuot.MessageExceptionk__BackingField != null && parOuot.MessageExceptionk__BackingField.Trim() != "")
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(parOuot.MessageExceptionk__BackingField.Trim() + "\r\n" + "\r\n" + 
                                                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldungs-Nr") + ": " + parOuot.MessageExceptionNrk__BackingField.ToString(), "ELGA", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (parOuot.lGDAsk__BackingField.Count() > 0)
                        {
                            foreach (ObjectDTO elgaPatient in parOuot.lGDAsk__BackingField)
                            {
                                foreach (AdressDto elgaAdressGda in elgaPatient.lAdressesk__BackingField)
                                {
                                    dsManage.ELGASearchGDAsRow rGda = this.sqlManange1.getNewELGAGDA(ref this.dsManage1);

                                    rGda.ID = System.Guid.NewGuid();
                                    rGda.IDElga = elgaPatient.IDELgaGdak__BackingField.Trim();
                                    rGda.NachnameFirma = elgaPatient.NachNameFirmak__BackingField.Trim();
                                    rGda.Vorname = elgaPatient.Vornamek__BackingField.Trim();
                                    rGda.Title = elgaPatient.Titlek__BackingField.Trim();
                                    rGda.IsOrganisation = elgaPatient.isOrganisationk__BackingField;

                                    rGda.PLZ = elgaAdressGda.Zipk__BackingField.Trim();
                                    rGda.Ort = elgaAdressGda.Cityk__BackingField.Trim();
                                    rGda.Land = elgaAdressGda.Countryk__BackingField.Trim();
                                    rGda.Strasse = elgaAdressGda.Streetk__BackingField.Trim();
                                    rGda.StrasseNr = elgaAdressGda.StreetNrk__BackingField.Trim();

                                    rGda.Status = elgaAdressGda.Statusk__BackingField.Trim();
                                    rGda.State = elgaAdressGda.Statek__BackingField.Trim();
                                }
                            }
                        }
                    }

                    this.gridFound.Refresh();
                    this.gridFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("GDA's gefunden") + " (" + this.gridFound.Rows.Count.ToString() + ")";
                    return true;


                    //List<ELGABusiness.ProtVar> lProt = new List<ELGABusiness.ProtVar>()
                    //        {
                    //            new ELGABusiness.ProtVar(){ Fld= "xy", oValOrig = "", oValNew = "", Table = "Patienxyt"  },
                    //        };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchGDA.searchData: " + ex.ToString());
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
                throw new Exception("contELGASearchGDA.selectData: " + ex.ToString());
            }
        }

        public PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
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
                        PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow rSelRow = (PMDS.Global.db.ERSystem.dsManage.ELGASearchGDAsRow)v.Row;
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
                throw new Exception("contELGASearchGDA.getSelectedRow: " + ex.ToString());
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

