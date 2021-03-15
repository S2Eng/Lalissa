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
using static PMDSClient.Sitemap.WCFServiceClient;
using System.Text.RegularExpressions;
using WCFServicePMDS.BAL2.ELGABAL;

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
        public bool bSearchEinrichtung { get; set; }

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


        //private static List<KeyValuePair<string, string>> lShortCountries = new List<KeyValuePair<string, string>>() {new KeyValuePair<string, string>("AT", "Österreich"),
        //                                                                                                new KeyValuePair<string, string>("DE", "Deutschland"),
        //                                                                                                new KeyValuePair<string, string>("HU", "ungarn")};



        public void initControl(Nullable<Guid> IDPatient, Nullable<Guid> IDAufenthalt, cSearchGdaFlds FieldsSearch, eTypeUI TypeUI, bool bSearchEinrichtung)
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

                    this.bSearchEinrichtung = bSearchEinrichtung;
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
                        StrasseNr = "",
                        bSearchEinrichtung = this.bSearchEinrichtung
                    };

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

                    if (parOuot.MessageException != null && !String.IsNullOrWhiteSpace(parOuot.MessageException))
                    {
                        string msgText = parOuot.MessageException.Trim() + "\r\n" + "\r\n";
                        if (parOuot.MessageExceptionNr > 0)
                            msgText += QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldungs-Nr") + ": " + parOuot.MessageExceptionNr.ToString();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msgText, "ELGA", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (parOuot.lGDAs.Count > 0)
                        {
                            foreach (ObjectDTO elgaPatient in parOuot.lGDAs)
                            {                                
                                dsManage.ELGASearchGDAsRow rGda = this.sqlManange1.getNewELGAGDA(ref this.dsManage1);

                                rGda.ID = System.Guid.NewGuid();
                                rGda.IDElga = elgaPatient.IDELgaGda.Trim();
                                rGda.NachnameFirma = elgaPatient.NachNameFirma.Trim();
                                rGda.Vorname = elgaPatient.Vorname.Trim();
                                rGda.Title = elgaPatient.Title.Trim();
                                rGda.IsOrganisation = elgaPatient.isOrganisation;
                                var Fachrichtung = (from al in db.AuswahlListe
                                                    where al.IDAuswahlListeGruppe == "FAR" && al.ELGA_Code == elgaPatient.Fachrichtung
                                                    select al.Bezeichnung).FirstOrDefault();
                                if (Fachrichtung != null)
                                    rGda.Fachrichtung = Fachrichtung.ToString();

                                if (elgaPatient.lAdresses != null)
                                {
                                    foreach (AdressDto elgaAdressGda in elgaPatient.lAdresses)
                                    {
                                        rGda.PLZ = elgaAdressGda.Zip.Trim();
                                        rGda.Ort = elgaAdressGda.City.Trim();
                                        rGda.State = elgaAdressGda.State.Trim();
                                        rGda.Strasse = elgaAdressGda.Street.Trim();
                                        rGda.StrasseNr = elgaAdressGda.StreetNr.Trim();
                                        rGda.Land = (from al in db.AuswahlListe
                                                     where al.IDAuswahlListeGruppe == "ISO" && al.Beschreibung == elgaAdressGda.Country
                                                     select al.Bezeichnung).FirstOrDefault().ToString();
                                        rGda.Status = elgaAdressGda.Status.Trim();
                                    }
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

