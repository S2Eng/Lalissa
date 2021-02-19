using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Global;


namespace PMDS.GUI
{

    public partial class frmEditDynReports : QS2.Desktop.ControlManagment.baseForm 
    {
        private ucBerichtParameterDefinition    _lastselected = null;
        private string                          _ReportFile = "";
        private bool                            _InitInProgress = true;




        public frmEditDynReports(string sReportFullName)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
            }
            _ReportFile = sReportFullName;
            SetHeaderText();
        }

        private void frmEditDynReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ENV.delPatientenUersPickerValueChanged -= new dPatientenUersPickerValueChanged(this.ucBenutzerCheckList1.PatientenUersPickerValueChanged);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }





        private void SetHeaderText()
        {
            this.Text += " - " + Path.GetFileNameWithoutExtension(_ReportFile);
        }

        private void RefreshImage()
        {
            pbImage.Image = null;

            string sFile = JPGFILE;

            if (!File.Exists(sFile))
                return;

            using (FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.Read))
            {
                pbImage.Image = Image.FromStream(fs);
                fs.Close();
            }

        }

        private string JPGFILE
        {
            get
            {
                return Path.Combine(ENV.ReportPath, Path.GetFileNameWithoutExtension(_ReportFile) + ".JPG");       
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                InsertNewParameter();
                SignalChange();

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

        private ucBerichtParameterDefinition InsertNewParameter()
        {
            ucBerichtParameterDefinition uc = new ucBerichtParameterDefinition();
            uc.Dock         = DockStyle.Top;
            uc.HEADER_ONLY  = false;
            uc.Enter        += new EventHandler(uc_Enter);
            uc.Changed      += new EventHandler(uc_Changed);
            this.pnlParameters.Controls.Add(uc);
            uc.BringToFront();
            return uc;
        }

        void uc_Changed(object sender, EventArgs e)
        {
            SignalChange();
        }

        private void SignalChange()
        {
            if (_InitInProgress)
                return;
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
        }

        private void SignalUndo()
        {
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
        }

        void uc_Enter(object sender, EventArgs e)
        {
            _lastselected = (ucBerichtParameterDefinition)sender;
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_lastselected == null)
                    return;
                pnlParameters.Controls.Remove(_lastselected);
                _lastselected = null;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                dataGridView1.EndEdit();
                WriteConfigFile();

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


        private string XMLFILE
        {
            get
            {
                return Path.Combine(ENV.ReportConfigPath, Path.GetFileNameWithoutExtension(_ReportFile) + ".config");  
            }
        }

        private void WriteConfigFile()
        {
            DynReportDefinition def = new DynReportDefinition(tbUeberschrift.Text);
            def.BenutzerListe       = ucBenutzerCheckList1.SELECTED;
            def.FormToLoad          = tbForm.Text.Trim();
            def.FormAssembly        = tbAssembly.Text.Trim();
            def.DatasetAssemly      = tbDatasetAssembly.Text.Trim();
            def.DataSources         = GetDataSources();
            def.Displayname         = tbAnzeigename.Text.Trim();
            for (int i = pnlParameters.Controls.Count - 1; i > -1; i--)      
            {
                ucBerichtParameterDefinition uc = (ucBerichtParameterDefinition)pnlParameters.Controls[i];
                def.AddParameter(uc.BEZEICHNUNG, uc.TYPE, uc.NAME, uc.DEFAULT);
            }

            def.WriteToConfigFile(XMLFILE);
            SignalUndo();
        }

        private List<PMDS.Print.CR.BerichtDatenquelle> GetDataSources()
        {
            List<PMDS.Print.CR.BerichtDatenquelle> l = new List<PMDS.Print.CR.BerichtDatenquelle>();
            dsDatenQuellen1.AcceptChanges();
            foreach (dsDatenQuellen.DatenQuellenRow r in dsDatenQuellen1.DatenQuellen)
                l.Add(new PMDS.Print.CR.BerichtDatenquelle(r.Bereich.Trim(), r.Klasse.Trim()));
            return l;
        }

        private void frmEditDynReports_Load(object sender, EventArgs e)
        {

            InsertHeaderLine();    
            LoadParameters();
            RefreshImage();
            _InitInProgress = false;
        }

        private void LoadParameters()
        {
            pnlParameters.Controls.Clear();
            if (!File.Exists(XMLFILE))
                return;

            DynReportDefinition def = new DynReportDefinition("");
            def.LoadFromConfig(XMLFILE);
            tbUeberschrift.Text             = def.Reportinfo;
            tbAnzeigename.Text              = def.Displayname;
            ucBenutzerCheckList1.SELECTED   = def.BenutzerListe;
            tbForm.Text                     = def.FormToLoad;
            tbAssembly.Text                 = def.FormAssembly;
            tbDatasetAssembly.Text          = def.DatasetAssemly;
            FillDataSourcesFromList(def.DataSources);

            foreach (PMDS.Print.CR.BerichtParameter p in def.PARAMTERS)
            {
                ucBerichtParameterDefinition uc = InsertNewParameter();
                uc.NAME         = p.Name;
                uc.DEFAULT      = p.Default;
                uc.BEZEICHNUNG  = p.Description;
                uc.TYPE         = p.Typ;
            }
        }

        private void FillDataSourcesFromList(List<PMDS.Print.CR.BerichtDatenquelle> list)
        {
            dsDatenQuellen1.Clear();
            foreach (PMDS.Print.CR.BerichtDatenquelle q in list)
                dsDatenQuellen1.DatenQuellen.AddDatenQuellenRow(q.Bereich, q.Klasse);
            dsDatenQuellen1.AcceptChanges();
        }

        private void InsertHeaderLine()
        {
            ucBerichtParameterDefinition uc = new ucBerichtParameterDefinition();
            uc.HEADER_ONLY  = true; 
            uc.Dock         = DockStyle.Top;
            uc.BringToFront();
            pnlHeader.Controls.Add(uc);
        }

        private void frmEditDynReports_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            frmDynReportInfo frm = new frmDynReportInfo();
            frm.ShowDialog();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                LoadParameters();
                SignalUndo();

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

        private void ucBenutzerCheckList1_CheckedChanged(object sender, EventArgs e)
        {
            SignalChange();
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            ucBenutzerCheckList1.Visible = cbAll.Checked;
            SignalChange();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SignalChange();
        }

    }

}
