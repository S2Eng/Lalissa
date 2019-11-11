using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global;
using System.IO;
using PMDS.Global.db.ERSystem;
using PMDSClient.Sitemap;

namespace PMDS.GUI.ELGA
{

    public partial class contCDAViewer : UserControl
    {
        private string _DocumentName = "";
        private string _ELGADocuUniqueId = "";
        private string _ClinicalDocumentSetID = "";
        private string _Xml = "";
        private string _typeFile = "";
        private string _Stylesheet = "";
        private eTypeUI _TypeUI;
        public frmCDAViewer mainWindow = null;
        public bool saveToElgaClicked = false;
        public bool abort = true;

        public ELGABusiness bELGA = new ELGABusiness();

        public enum eTypeUI
        {
            saveToArchive = 0,
            SaveToElga = 1
        }




        public contCDAViewer()
        {
            InitializeComponent();
        }

        public void initControl(string DocumentName, string ELGADocuUniqueId, string ClinicalDocumentSetID, string Xml, string typeFile, string Stylesheet,
                                eTypeUI TypeUI)
        {
            try
            {
                this._DocumentName = DocumentName;
                this._ELGADocuUniqueId = ELGADocuUniqueId;
                this._ClinicalDocumentSetID = ClinicalDocumentSetID;
                this._Xml = Xml;
                this._typeFile = typeFile;
                this._Stylesheet = Stylesheet;
                this._TypeUI = TypeUI;

                this.btnSaveIntoArchive.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnSaveDocuToELGA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

                if (this._TypeUI == eTypeUI.saveToArchive)
                {
                    this.panelBottom.Visible = true;
                    if (ENV.adminSecure)
                    {
                        this.btnSaveIntoArchive.Visible = true;
                    }
                    else
                    {
                        this.btnSaveIntoArchive.Visible = false;
                    }
                    this.btnSaveDocuToELGA.Visible = false;
                    this.btnClose.Visible = true;
                    this.btnAbort.Visible = false;
                }
                else if (this._TypeUI == eTypeUI.SaveToElga)
                {
                    this.panelBottom.Visible = true;
                    this.btnSaveIntoArchive.Visible = false;
                    this.btnSaveDocuToELGA.Visible = true;
                    this.btnClose.Visible = false;
                    this.btnAbort.Visible = true;

                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rAufenthalt = (from a in db.Aufenthalt
                                           where a.ID == ENV.IDAUFENTHALT
                                           select new
                                           {
                                               a.ID,
                                               a.ELGALocalID,
                                               a.ELGASOOJN
                                           }).First();

                        if (rAufenthalt.ELGASOOJN)
                        {
                            this.btnSaveDocuToELGA.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern");
                        }
                    }
                }
                else
                {
                    throw new Exception("contCDAViewer.initControl: _TypeUI '" + _TypeUI.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contCDAViewer.initControl: " + ex.ToString());
            }
        }
        public void loadFileIntoViewer()
        {
            try
            {
                string pTmp = System.IO.Path.Combine(ENV.path_Temp, "CDA");
                string StyleSheetNameTmp = "";
                if (this._Stylesheet.Trim() == "")
                {
                    throw new Exception("loadFileIntoViewer: this._Stylesheet '" + this._Stylesheet.Trim() + "' not allowed!");
                    //StyleSheetNameTmp = "ELGA_Stylesheet_v1.0.xsl";
                }
                else
                {
                    StyleSheetNameTmp = this._Stylesheet.Trim();
                }

                string fStyle = System.IO.Path.Combine(pTmp, StyleSheetNameTmp);
                if (!System.IO.Directory.Exists(pTmp))
                {
                    Directory.CreateDirectory(pTmp);
                }
                if (!System.IO.File.Exists(fStyle))
                {
                    System.IO.File.Copy(@ENV.pathConfig + "\\" + StyleSheetNameTmp, fStyle);
                }

                string fileXml = Path.Combine(pTmp, this._DocumentName.Trim() + "_" + System.Guid.NewGuid().ToString() + ".xml");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileXml, false))
                {
                    file.Write(_Xml);
                }

                this.webBrowser1.Navigate(@fileXml);
            }
            catch (Exception ex)
            {
                throw new Exception("contCDAViewer.loadFileIntoViewer: " + ex.ToString());
            }
        }

        public bool saveDocuToArchive()
        {
            try
            {
                throw new Exception("contCDAViewer.saveDocuToArchive: Function is not activated!");

                WCFServiceClient WCFServiceClient1 = new WCFServiceClient();
                DateTime dNow = DateTime.Now;
                string ArchivePath = "";
                Nullable<Guid> IDOrdnerArchiv = null;

                if (this._ELGADocuUniqueId.Trim() == "")
                {
                    throw new Exception("contCDAViewer.saveDocuToArchive: _ELGADocuUniqueId='' not allowed!");
                }
                if (this._DocumentName.Trim() == "")
                {
                    throw new Exception("contCDAViewer.saveDocuToArchive: _DocumentName='' not allowed!");
                }
                if (this._Stylesheet.Trim() == "")
                {
                    throw new Exception("contCDAViewer.saveDocuToArchive: _Stylesheet='' not allowed!");
                }

                if (!this.bELGA.checkArchivesystem(ref ArchivePath, ref IDOrdnerArchiv))
                {
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rAufenthalt = (from a in db.Aufenthalt
                                       where a.ID == ENV.IDAUFENTHALT
                                       select new
                                       {
                                           a.ID,
                                           a.ELGALocalID
                                       }).First();

                    if (rAufenthalt.ELGALocalID.Trim().Trim() == "")
                    {
                        throw new Exception("contCDAViewer.saveDocuToArchive: rAufenthalt.ELGALocalID.Trim()='' not allowed!");
                    }

                    Guid IDDocumenteneintrag = System.Guid.NewGuid();
                    return this.bELGA.saveELGADocuToDB(ref ArchivePath, this._typeFile, ref IDOrdnerArchiv, "", db, ref dNow, ref WCFServiceClient1, ENV.IDAUFENTHALT,
                                                    ENV.CurrentIDPatient, null, this._ELGADocuUniqueId.Trim(), rAufenthalt.ELGALocalID.Trim(), this._DocumentName.Trim(), this._Stylesheet.Trim(),
                                                    ref IDDocumenteneintrag, true, "", true, -1);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contCDAViewer.saveDocuToArchive: " + ex.ToString());
            }
        }
        public bool saveDocuToELGA()
        {
            try
            {
                throw new Exception("Function saveDocuToELGA not activated!");
                //return this.bELGA.saveDocuToELGA(ENV.USERID, ENV.IDAUFENTHALT, this._DocumentName.Trim(), this._Xml.Trim(), null, this._Stylesheet.Trim(), this._ClinicalDocumentSetID.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("contCDAViewer.saveDocuToELGA: " + ex.ToString());
            }
        }

        private void ContCDAViewer_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.loadFileIntoViewer();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        private void btnSaveIntoArchive_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.saveDocuToArchive())
                {
                    //this.abort = false;
                    //this.mainWindow.Close();
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
        private void btnSaveDocuToELGA_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //this.saveDocuToELGA();
                this.abort = false;
                this.saveToElgaClicked = true;
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
        private void btnClose_Click(object sender, EventArgs e)
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
        private void btnAbort_Click(object sender, EventArgs e)
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

    }

}
