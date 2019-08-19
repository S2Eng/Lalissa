using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using Infragistics.Win.UltraWinListView;





namespace PMDS.GUI.GUI.Main
{



    public partial class ucPatientenmehrfachauswahl : UserControl
    {

        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected = null;

        public bool abort = true;
        public PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl mainWindow = null;

        
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1 = new Global.db.ERSystem.dsKlientenliste();
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
        public PMDS.Global.db.ERSystem.sqlManange sqlManangeWork = new Global.db.ERSystem.sqlManange();
        private PMDS.Global.historie hist = new PMDS.Global.historie();

        public System.Guid lastSelectedAbteilung = System.Guid.Empty;
        public System.Guid lastSelectedBereich = System.Guid.Empty;










        public ucPatientenmehrfachauswahl()
        {
            InitializeComponent();
        }

        private void ucPatientenmehrfachauswahl_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, 32, 32);
                this.ucPatientGroup1.SetCurrentToRoot();
                this.ucPatientGroup1.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenmehrfachauswahl.initControl: " + ex.ToString());
            }
        }

        public void loadData(bool Historie,System.Guid Abteilung, System.Guid Bereich)
        {
            try
            {
                this.lblFound.Text = "";
                this.lvPatients.Items.Clear();
                this.lvPatients.Refresh();

                PMDS.Global.UIGlobal UIGlobal1 = new UIGlobal();
                UIGlobal1.removeDoubledPatients(ref this.lstPatienteSelected);

                Global.db.Patient.dsKlinik.KlinikRow rKlinik = this.ucPatientGroup1.getSelKlinik(true);
                if (rKlinik != null)
                {
                    this.dsKlientenliste1.vKlientenliste.Clear();
                    this.sqlManangeWork.getPatientenStart(ENV.USERID, (this.chkHistorie.Checked == true ? 1 : 0), ENV.CurrentIDBezugsPfleger, ref this.dsKlientenliste1, Abteilung, Bereich, System.Guid.Empty);

                    Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow[] arrKlienten = (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow[])this.dsKlientenliste1.vKlientenliste.Select("", this.dsKlientenliste1.vKlientenliste.PatientNameColumn.ColumnName + " asc");
                    foreach (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlienten in arrKlienten)
                    {
                        UltraListViewItem listItem = new UltraListViewItem(rKlienten.PatientName.Trim(), null, null);
                        listItem.Key = System.Guid.NewGuid().ToString();
                        listItem.Tag = rKlienten;
                        listItem.CheckState = CheckState.Unchecked;
                        this.lvPatients.Items.Add(listItem);
                    }
                    foreach (UltraListViewItem listItem in this.lvPatients.Items)
                    {
                        Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlientenTree = (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow)listItem.Tag;
                        foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in this.lstPatienteSelected)
                        {
                            if (SelectedNodes.IDAufenthalt.Equals(rKlientenTree.IDAufenthalt))
                            {
                                listItem.CheckState = CheckState.Checked;
                            }
                        }
                    }

                    this.lvPatients.Refresh();
                    this.lblFound.Text = "Gefunden: " + this.lvPatients.Items.Count.ToString();
                }
                else
                {
                    throw new Exception("ucPatientenmehrfachauswahl.loadData: rKlinik=null!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenmehrfachauswahl.loadData: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {


                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenmehrfachauswahl.saveData: " + ex.ToString());
            }
        }


        public void lvPatientsItemCheckStateChanged(UltraListViewItem ListItem)
        {
            try
            {
                //if (this.treePatients.ActiveNode != null)
                //{
                System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteToDelete = new List<PMDS.Global.UIGlobal.eSelectedNodes>();
                Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlienten = (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow)ListItem.Tag;
                bool bPatientExists = false;
                PMDS.Global.UIGlobal.eSelectedNodes NodeExists = null;
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in this.lstPatienteSelected)
                {
                    if (SelectedNodes.IDAufenthalt.Equals(rKlienten.IDAufenthalt))
                    {
                        NodeExists = SelectedNodes;
                        bPatientExists = true;
                    }
                }

                if (ListItem.CheckState == CheckState.Checked && !bPatientExists)
                {
                    PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes = new PMDS.Global.UIGlobal.eSelectedNodes();
                    SelectedNodes.IDKlient = rKlienten.IDKlient;
                    SelectedNodes.IDAufenthalt = rKlienten.IDAufenthalt;
                    this.lstPatienteSelected.Add(SelectedNodes);
                }
                else if (ListItem.CheckState == CheckState.Unchecked && bPatientExists)
                {
                    this.lstPatienteSelected.Remove(NodeExists);
                }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenmehrfachauswahl.lvPatientsItemCheckStateChanged: " + ex.ToString());
            }
        }

        public void selectAllnone(bool bOn)
        {
            try
            {
                this.lstPatienteSelected.Clear();
                foreach (UltraListViewItem listItem in this.lvPatients.Items)
                {
                    if (bOn)
                    {
                        listItem.CheckState = CheckState.Checked;
                        this.lvPatientsItemCheckStateChanged(listItem);
                    }
                    else
                    {
                        listItem.CheckState = CheckState.Unchecked;
                        this.lvPatientsItemCheckStateChanged(listItem);
                    }
                }
            
            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenmehrfachauswahl.selectAllnone: " + ex.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.mainWindow.Close();
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
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.mainWindow.Close();

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

        private void ucPatientGroup1_klinikHasChanged(Global.db.Patient.dsKlinik.KlinikRow rKlinik)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //if (rKlinik == null)
                //    this.ucPatientPicker1.clearData();
                //else
                //    this.setTitleForm(rKlinik);

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

        private void ucPatientGroup1_SelectionChanged(object sender, PatientGroupSelection args)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.lastSelectedAbteilung = args.Abteilung;
                this.lastSelectedBereich = args.Bereich;
                this.loadData(this.chkHistorie.Checked, this.lastSelectedAbteilung, this.lastSelectedBereich);
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
        private void chkHistorie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.chkHistorie.Focused)
                {
                    this.loadData(this.chkHistorie.Checked, this.lastSelectedAbteilung, this.lastSelectedBereich);
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

        private void lvPatients_ItemCheckStateChanged(object sender, Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (lvPatients.Focused)
                {
                    this.lvPatientsItemCheckStateChanged(e.Item);
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

        private void lblAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllnone(true);

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
        private void lblNone_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllnone(false);

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
