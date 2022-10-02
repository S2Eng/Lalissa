using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using System.IO;
using PMDS.DB;




namespace PMDS.GUI.GUI.Main
{


    public partial class contDocumentSelect : UserControl
    {

        public bool abort = true;

        public frmDocumentsSelect mainForm = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public Guid _IDAbteilung = System.Guid.Empty;
        public PMDS.GUI.VB.clFolder clFolder = new PMDS.GUI.VB.clFolder();









        public contDocumentSelect()
        {
            InitializeComponent();
        }

        private void contDocumentSelect_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDAbteilung, ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenlisteFromDB)
        {
            try
            {
                this.mainForm.CancelButton = this.btnClose;
                this._IDAbteilung = IDAbteilung;

                this.sqlManange1.initControl();
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

                this.loadData(ref dsKlientenlisteFromDB);
            }
            catch (Exception ex)
            {
                throw new Exception("contDocumentSelect.initControl: " + ex.ToString());
            }
        }

        public void loadData(ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenlisteFromDB)
        {
            try
            {
                //Settings.PathDokumente
                this.dsKlientenliste1.Clear();
                foreach (PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row rDokumentDB in dsKlientenlisteFromDB.Dokumente2)
                {
                    PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row rNewDokument = (PMDS.Global.db.ERSystem.dsKlientenliste.Dokumente2Row)this.dsKlientenliste1.Dokumente2.NewRow();
                    rNewDokument.ItemArray = rDokumentDB.ItemArray;
                    this.dsKlientenliste1.Dokumente2.Rows.Add(rNewDokument);
                }
                this.dsKlientenliste1.AcceptChanges();
                //this.sqlManange1.getDokumente2(System.Guid.Empty, Global.db.ERSystem.sqlManange.eTypeDokumente2.ForAbteilungBenutzergruppe, ref this.dsKlientenliste1, "");
                //this.gridDocuments.Refresh();

                this.gridDocuments.DataSource = this.dsKlientenliste1;
                this.gridDocuments.DataMember = this.dsKlientenliste1.Dokumente2.TableName;
                this.gridDocuments.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception("contDocumentSelect.loadData: " + ex.ToString());
            }
        }

        public Global.db.ERSystem.dsKlientenliste.Dokumente2Row getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridDocuments.ActiveRow != null)
                {
                    if (this.gridDocuments.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridDocuments.ActiveRow.ListObject;
                        Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelRow = (Global.db.ERSystem.dsKlientenliste.Dokumente2Row)v.Row;
                        gridRow = this.gridDocuments.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contDocumentSelect.getSelectedRow: " + ex.ToString());
            }
        }

        private void gridDocuments_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                e.Cancel = true;
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
        private void gridDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridDocuments))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument = this.getSelectedRow(false, ref gridRow);
                    if (rSelDokument != null)
                    {
                        //this.addEditRow(false, rSelDokument);
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
        private void gridDocuments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridDocuments))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument = this.getSelectedRow(false, ref gridRow);
                    if (rSelDokument != null)
                    {
                        bool bFileFoundInDir = false;
                        if (ENV.PathDokumente.Trim() != "" && System.IO.Directory.Exists(ENV.PathDokumente.Trim()))
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(ENV.PathDokumente.Trim());
                            foreach (FileInfo fileInfo in dirInfo.GetFiles())
                            {
                                if (fileInfo.Extension.Trim().ToLower().Equals((".pdf")) &&
                                    fileInfo.Name.Trim().ToLower().Equals(rSelDokument.DokumentenName.Trim().ToLower()))
                                {
                                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                                    {
                                        string AnonymUser = "";
                                        if (PMDS.Global.ENV.IDAnmeldungen != null)
                                        {
                                            PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                                            PMDS.db.Entities.Anmeldungen rAnonymUser = b.getAnonymUser((Guid)PMDS.Global.ENV.IDAnmeldungen, db);
                                            AnonymUser = QS2.Desktop.ControlManagment.ControlManagment.getRes(" (Anonym User:") + rAnonymUser.Benutzer.Trim() + ")";
                                        }
                                        
                                        bFileFoundInDir = true;
                                        this.clFolder.openFile(fileInfo.FullName.Trim(), false);

                                        qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
                                        qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                                        sqlProtocoll.initControl();
                                        string CmdReturn = "";
                                        sqlProtocoll.getProtocol(System.Guid.NewGuid(), ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

                                        qs2.core.vb.dsProtocol.ProtocolRow rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
                                        rNewProt.Type = "DocumentRead";
                                        rNewProt.IDApplication = "PMDS";
                                        PMDS.BusinessLogic.Benutzer ben = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
                                        
                                        rNewProt.Created = DateTime.Now;
                                        rNewProt.User = ENV.LoginInNameFrei.Trim();
                                        rNewProt.Info = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument '") + fileInfo.Name.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' von Benutzer '") + ENV.LoginInNameFrei.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" gelesen!");
                                        rNewProt.Protocol = fileInfo.FullName.Trim();
                                        rNewProt.IDGuid = System.Guid.NewGuid();

                                        sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);
                                    }
                                }
                            } 
                        }
                        if (!bFileFoundInDir)
                        {
                            string sMsgBoxTranslate = "Die Datei '{0}' wurde nicht gefunden!";
                            sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, ENV.PathDokumente.Trim() + @"\" + rSelDokument.DokumentenName.Trim());
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Datei öffnen", MessageBoxButtons.OK);
                        }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainForm.Close();
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
