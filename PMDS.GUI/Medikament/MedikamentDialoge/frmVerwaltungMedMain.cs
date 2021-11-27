using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Patient;
using PMDS.DB;

namespace PMDS.GUI
{



    public partial class frmMedikamentenVerwaltung : QS2.Desktop.ControlManagment.baseForm 
    {
        public PMDSBusiness b = new PMDSBusiness();




        public frmMedikamentenVerwaltung()
        {
            InitializeComponent();
            //this.btnImportFromHttp.Text = "Importieren";
            //this.btnImportFromHttp.Appearance .Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Ausschneiden, 32, 32);
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
                this.btnImport.Visible = PMDS.Global.ENV.APVDA;
            }

            cboMonat.SelectedIndex = 0;
            pnlMonat.Visible = PMDS.Global.generic.sEquals(PMDS.Global.ENV.MedikamenteImportType, "service") && PMDS.Global.ENV.ApoZusatzdaten;
            this.btnImport.Appearance.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnImport.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
            this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
            this.btnAbort.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32);
            this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
            this.btnDeleteMedikamenteNotUsed.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table , 32, 32);

            this.cboImportType.SelectedItem = this.cboImportType.Items[1];
        }

        public PMDS.Global.db.Patient.dsMedikament.MedikamentRow GetMedikamentRow()
        {
            return ucVerwaltungMedTabelle1.GetMedikamentRow();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

 


        private void btnImportFromHttp_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmMedikamentenVerwaltung2_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ucVerwaltungMedTabelle1.Write();

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
                this.ucVerwaltungMedTabelle1.ProcessSearch();
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                PMDS.Global.ImportMedDaten ImportMedDaten1 = new PMDS.Global.ImportMedDaten();
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Medikamente wirklich neu importieren?", "Importieren", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    int CountUpdated = 0;
                    int CountDeactivated = 0;
                    string SelFileName = this.cboImportType.SelectedItem.DataValue.ToString();


                    DateTime datStart = DateTime.Now;
                    bool bImportGesamtdaten = (bool)this.cboImportType.SelectedItem.Tag;

                    if (ImportMedDaten1.run(bImportGesamtdaten, this.chkELGATranslate.Checked, ref this.lblStatus, out CountUpdated, out CountDeactivated, SelFileName, 
                        PMDS.Global.ENV.MedikamenteImportType, out string sMsg, PMDS.Global.ENV.MedikamenteImportType == "service" ? (int)cboMonat.SelectedItem.DataValue : 0))
                    {
                        using (DB.DBMedikament DBMedikament1 = new DB.DBMedikament())
                        {
                            DBMedikament1.LoadAllMedikamente(true);
                        }

                        DateTime datEnd = DateTime.Now;
                        //this.ucVerwaltungMedTabelle1.ProcessSearch();

                        string txtInfo = "\r\n" + "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Anzahl Medikamente eingespielt: ") + CountUpdated.ToString();
                        txtInfo += "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Anzahl Medikamente deaktiviert: ") + CountDeactivated.ToString() + "\r\n" + "\r\n";

                        txtInfo += QS2.Desktop.ControlManagment.ControlManagment.getRes("Start: ") + datStart.ToString() + "\r\n";
                        txtInfo += QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende: ") + datEnd.ToString() + "";
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamente wurden importiert!") + txtInfo, "Importieren");
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Laden der Medikamentendaten: " + sMsg, "Importieren");
                    }
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

        private void btnDeleteMedikamenteNotUsed_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie wirklich alle nicht verwendeten Medikamente löschen?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int iCounterDeleted = 0;
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        this.b.deleteNotUsedMedikamente(ref iCounterDeleted, db, ref this.lblStatus);
                        this.ucVerwaltungMedTabelle1.ProcessSearch();
                    }

                    string txtmsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Medikamente wurden gelöscht!");
                    txtmsgBox = string.Format(txtmsgBox, iCounterDeleted.ToString());
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtmsgBox, "PMDS", MessageBoxButtons.OK, true);
                    lblStatus.Text = "";
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

    }
}