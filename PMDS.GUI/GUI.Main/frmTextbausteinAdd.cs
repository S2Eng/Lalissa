using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;



namespace PMDS.GUI.GUI.Main
{


    public partial class frmTextbausteinAdd : Form
    {
        public bool isNew = false;
        public Global.db.ERSystem.dsKlientenliste.TextbausteineRow rTextbausteine = null;
        public bool abort = true;
        
        public QS2.Desktop.Txteditor.contTXTField contTXTEditor = null;
        public Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
        public PMDS.Global.db.ERSystem.UISitemaps UISitemaps1 = new Global.db.ERSystem.UISitemaps();







        public frmTextbausteinAdd()
        {
            InitializeComponent();
        }

        private void frmTextbausteinAdd_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }



        public void initControl()
        {
            try
            {
                //this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, 32, 32);

                this.auswahlGruppeComboMulti1.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, eUITypeTermine.None, true, -1, -100000, false);

            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.initControl: " + ex.ToString());
            }
        }
        public void loadTxtEditor()
        {
            try
            {
                this.panelBeschreibungTXTEditor.Controls.Clear();

                this.contTXTEditor = new QS2.Desktop.Txteditor.contTXTField();
                this.contTXTEditor.initControl(TXTextControl.ViewMode.FloatingText, true, true, false, false, ENV.SpellCheckerOn, false);
                this.contTXTEditor.delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChanged);
                this.contTXTEditor.delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChangedBeschreibungTxtControl);

                this.contTXTEditor.Dock = DockStyle.Fill;
                this.panelBeschreibungTXTEditor.Controls.Add(this.contTXTEditor);

            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.loadTxtEditor: " + ex.ToString());
            }
        }
        public void valueChanged()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.valueChanged: " + ex.ToString());
            }
        }
        public void valueChangedBeschreibungTxtControl()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.valueChangedBeschreibungTxtControl: " + ex.ToString());
            }
        }

        public void clearData()
        {
            try
            {
                this.txtKurzbezeichnung.Text = "";
                this.auswahlGruppeComboMulti1.clearSelectedNodes();
                this.contTXTEditor.TXTControlField.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.clearData: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.clearData();

                if (this.isNew)
                {
                    PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                    this.rTextbausteine = this.sqlManange1.newRowTextbaustein(ref this.dsKlientenliste1, rUsr.Benutzer1.Trim());
                }
                else
                {
                    this.txtKurzbezeichnung.Text = this.rTextbausteine.Kurzbezeichnung.Trim();

                    System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                    System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                    System.Collections.Generic.List<Guid> lstGuidsBerufsstand = this.setBerufsstandErstelltFromString(this.rTextbausteine.Berufsgruppen.Trim());
                    this.auswahlGruppeComboMulti1.setSelected(lstGuidsBerufsstand, lstIntSelected, lstStrSelected);

                    this.contTXTEditor.showText(this.rTextbausteine.TextRtf, TXTextControl.StreamType.RichTextFormat);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.loadData: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<Guid> setBerufsstandErstelltFromString(string slstGuid)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.auswahlGruppeComboMulti1.clearSelectedNodes();
                if (slstGuid.Trim() != "")
                {
                    this.UISitemaps1.getListGuidFromString(slstGuid, ref lstGuid);
                    if (lstGuid.Count > 0)
                    {
                    }
                }
                return lstGuid;
            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.setBerufsstandErstelltFromString: " + ex.ToString());
            }
        }

        public void ClearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.txtKurzbezeichnung, "");
                //this.errorProvider1.SetError(this.contTXTEditor, "");
            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.validateData: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                if (this.txtKurzbezeichnung.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtKurzbezeichnung, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kurzbezeichnung: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                    return false;
                }

                //string PlainTxt = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTEditor.TXTControlField);
                //if (PlainTxt.Trim() == "")
                //{
                //    this.errorProvider1.SetError(this.contTXTEditor, "Error");
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Text: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                //    return false;
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                this.ClearErrorProvider();
                if (!this.validateData())
                {
                    return false;
                }

                this.rTextbausteine.Kurzbezeichnung = this.txtKurzbezeichnung.Text.Trim();

                System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstZeitbezug = new System.Collections.Generic.List<int>();
                this.auswahlGruppeComboMulti1.getSelected(ref lstGuid, ref lstZeitbezug, ref lstStrSelected);
                this.rTextbausteine.Berufsgruppen = "";
                foreach (Guid IDBerufsstandSelected in lstGuid)
                {
                    this.rTextbausteine.Berufsgruppen += IDBerufsstandSelected.ToString() + ";";
                }

                this.rTextbausteine.TextRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTEditor.TXTControlField);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAdd.saveData: " + ex.ToString());
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
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

        private void frmTextbausteinAdd_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.loadTxtEditor();
                    this.loadData();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
