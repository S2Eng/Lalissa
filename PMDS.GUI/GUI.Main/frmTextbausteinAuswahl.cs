using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;



namespace PMDS.GUI.GUI.Main
{


    public partial class frmTextbausteinAuswahl : Form
    {

        public Global.db.ERSystem.dsKlientenliste.TextbausteineRow rTextbausteinSelected = null;
        public bool abort = true;
        public string TextbausteinAsPlainText = "";

        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();






        public frmTextbausteinAuswahl()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }

        private void frmTextbausteinAuswahl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void initControl()
        {
            try
            {
                this.CancelButton = this.btnAbort;
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.loadTextbausteine();
            }
            catch (Exception ex)
            {
                throw new Exception("frmTextbausteinAuswahl.initControl: " + ex.ToString());
            }
        }
        public void loadTextbausteine()
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                this.cboTextbausteine.Items.Clear();
                Global.db.ERSystem.dsKlientenliste dsKlientenliste1 = new Global.db.ERSystem.dsKlientenliste();
                Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
                sqlManange1.initControl();
                sqlManange1.getTextbausteine(System.Guid.Empty, Global.db.ERSystem.sqlManange.eTypeTextbausteine.All, ref dsKlientenliste1);
                
                PMDS.Global.db.ERSystem.UISitemaps UISitemaps1 = new Global.db.ERSystem.UISitemaps();
                foreach (Global.db.ERSystem.dsKlientenliste.TextbausteineRow rTextbausteinFound in dsKlientenliste1.Textbausteine)
                {
                    bool TextbausteinIsInCombo = false;
                    System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                    UISitemaps1.getListGuidFromString(rTextbausteinFound.Berufsgruppen.Trim () , ref lstGuid);
                    foreach(Guid IDBerufsgruppeStand in lstGuid)
                    {
                        if (PMDSBusiness1.UserCanSign(IDBerufsgruppeStand))
                        {
                            if (!TextbausteinIsInCombo)
                            {
                                ValueListItem itmCbo = this.cboTextbausteine.Items.Add(rTextbausteinFound.ID, rTextbausteinFound.Kurzbezeichnung.Trim());
                                itmCbo.Tag = rTextbausteinFound;
                                TextbausteinIsInCombo = true; 
                            }
                        }
                    }
                    //if (rTextbausteinFound.Berufsgruppen.Trim().ToLower().Contains(rUsr.IDBerufsstand.ToString().Trim().ToLower()))
                    //{
                    //    ValueListItem itmCbo = this.cboTextbausteine.Items.Add(rTextbausteinFound.ID, rTextbausteinFound.Kurzbezeichnung.Trim());
                    //    itmCbo.Tag = rTextbausteinFound;
                    //}
                }
                this.cboTextbausteine.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                this.cboTextbausteine.DropDownStyle = DropDownStyle.DropDown;
                this.cboTextbausteine.Refresh();

            }
            catch (Exception e)
            {
                throw new Exception("frmTextbausteinAuswahl.loadTextbausteine: " + e.ToString());
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.abort = true;
                this.Close();
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cboTextbausteine_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    if (this.cboTextbausteine.SelectedItem != null)
                    {
                        ValueListItem itmCbo = this.cboTextbausteine.SelectedItem;
                        this.rTextbausteinSelected = (Global.db.ERSystem.dsKlientenliste.TextbausteineRow)itmCbo.Tag;

                        byte[] b = null;
                        this.doEditor1.showText(this.rTextbausteinSelected.TextRtf, TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.PageView, this.textControlConvert,ref b, ref b);
                        this.TextbausteinAsPlainText = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControlConvert);

                        this.abort = false;
                        this.Close();
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
