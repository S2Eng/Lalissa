using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using Infragistics.Win.UltraWinGrid;




namespace PMDS.GUI
{


    public partial class ucVerwaltungMedTabelle : QS2.Desktop.ControlManagment.BaseControl 
    {
        private PMDS.BusinessLogic.Medikament _Medikament = new PMDS.BusinessLogic.Medikament();
        public event EventHandler ValueChanged;







        public ucVerwaltungMedTabelle()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            cbEinheit.Text = "";
            cbGroup.Text = "";
            this.setUI();
            this.btnSearch2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
        }



        public void Write()
        {
            ProcessSave();
        }

        public void SetSearchText (string txt)
        {
            this.tbBezeichnung.Text = txt;     //Löst eine Neusuche aus
        }

        public void ProcessSearch()
        {
            if (tbBezeichnung.TextLength != 0 || tbLangText.TextLength != 0 || cbEinheit.TextLength != 0 || cbGroup.TextLength != 0)
            {
                dgMain.DataSource = _Medikament.ReadMedikament(tbBezeichnung.Text.Trim(), tbLangText.Text.Trim(), cbEinheit.Text.Trim(),
                                                    cbGroup.Text.Trim(), true, false, (int)this.optAktuellYN.Value);
            }
            else
            {
                _Medikament.ClearMedikamente();
                //dgMain.DataSource = _Medikament.AllMedikamenteBig((int)this.optAktuellYN.Value, true);
            }

            this.SetLabelCount();

            this.setUI();
        }

        public void setUI()
        {
            //this.dgMain.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.EXT_IDColumn.ColumnName].Hidden = false;
            //this.dgMain.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.EXT_IDColumn.ColumnName].Header.VisiblePosition = 2;
            //this.dgMain.DisplayLayout.Bands[0].Columns[this.dsMedikament1.Medikament.EXT_IDColumn.ColumnName].Width = 120;

            //this.dgMain.Refresh();
        }

        private bool ProcessSave()
        {
            UltraGridTools.EndCurrentEdit(dgMain);

            if ((PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable)dgMain.DataSource != null)
                _Medikament.Write((PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable)dgMain.DataSource);
            return true;
        }

        private void AddMedikament()
        {
            frmMedikamentEdit frm = new frmMedikamentEdit();
            frm.New();

            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                tbBezeichnung.Text = frm.BEZEICHNUNG;
                ProcessSearch();
            }
    
        }

        public PMDS.Global.db.Patient.dsMedikament.MedikamentRow GetMedikamentRow()
        {
            return (PMDS.Global.db.Patient.dsMedikament.MedikamentRow)UltraGridTools.CurrentSelectedRow(dgMain);
        }

        public void UpdateMedikament()
        {
            PMDS.Global.db.Patient.dsMedikament.MedikamentRow row = GetMedikamentRow();
            if(row == null)
                return;

            frmMedikamentEdit frm = new frmMedikamentEdit();
            frm.Read(row.ID);

            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                tbBezeichnung.Text = frm.BEZEICHNUNG;
                ProcessSearch();
            }

        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
    
        }
        public void setControlsAktivDisable(bool bOn)
        {

        }

        public void ClearMask()
        {
            tbBezeichnung.Clear();
            tbLangText.Clear();
            cbGroup.Text = "";
            cbEinheit.Text = "";
            //ProcessSearch();
            //this.lblFound.Text = "";
            this.optAktuellYN.Value = 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AddMedikament();
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

                PMDS.Global.db.Patient.dsMedikament.MedikamentRow row = GetMedikamentRow();

                if (row == null)
                    return;

                if (Rezept.IsMedikamentInUse(row.ID))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament ") + row.Bezeichnung + QS2.Desktop.ControlManagment.ControlManagment.getRes(" kann nicht gelöscht werden weil es in Rezepten vorhanden ist."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                    return;
                }

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Medikament wirklich löschen ?", "Medikament löschen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                row.Delete();
                
                if (ValueChanged != null)
                    ValueChanged(sender, e);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                UpdateMedikament();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProcessSave();
        }

        private void ucMedikamentTabelle_Load(object sender, EventArgs e)
        {
            if (!ENV.AppRunning)
                return;
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("MGR", dgMain, "Gruppe");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("MEH", dgMain, "Einheit");

            dgMain.DataSource = _Medikament.AllMedikamenteBig((int)this.optAktuellYN.Value, false);
            this.SetLabelCount();
        }
        public void SetLabelCount()
        {
            Global.db.Patient.dsMedikament.MedikamentDataTable dt = (Global.db.Patient.dsMedikament.MedikamentDataTable)dgMain.DataSource;
            this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + dt.Rows.Count.ToString();
        }
        
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ProcessSearch();
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

        private void lblReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ClearMask();
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

        private void dgMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                QS2.Desktop.ControlManagment.UI ui1 = new QS2.Desktop.ControlManagment.UI();
                if (ui1.evDoubleClickOK(sender, e, this.dgMain))
                {
                    this.UpdateMedikament();
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

        private void tbBezeichnung_KeyUp(object sender, KeyEventArgs e)
        {
            if (System.Windows.Input.Keyboard.IsKeyUp(System.Windows.Input.Key.Return))
            {
                //this.Cursor = Cursors.WaitCursor;
                //ProcessSearch();
            }
        }

        private void tbBezeichnung_ValueChanged(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Interval = 500;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (!String.IsNullOrWhiteSpace(this.tbBezeichnung.Text))
            {
                ProcessSearch();
            }
        }
    }
}
