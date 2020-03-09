using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using System.Linq;

using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using PMDS.DB;
using PMDS.Global.db.ERSystem;
using System.IO;
using QS2.Desktop.ControlManagment.ServiceReference_01;
using PMDSClient.Sitemap;

namespace PMDS.GUI.Messenger
{  

    public partial class contMessenger : UserControl
    {
        public frmMessenger mainWindow = null;
        public bool IsInitialized = false;

        public PMDS.GUI.VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;

        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public eTypeUI _TypeUI;
        public enum eTypeUI
        {
            ShowMessage = 0,
            AnswerAll = 1,
            AnswerSender = 2,
            NewMessage = 3
        }

        public class eTgTree
        {          
            public dsAsyncCommData dsAsyncCommData1 = new dsAsyncCommData();
            public dsAsyncCommData.DataGenericRow rDataGeneric = null;
            public dsAsyncCommData.ToUsersRow[] tToUsers = null;
        }

        public string newLine = "\r\n";
        public string newLineOrig = "----------------- {0} -------------------------------";

        public QS2.Desktop.Txteditor.doEditor doEditor = new QS2.Desktop.Txteditor.doEditor();

        public contMessenger()
        {
            InitializeComponent();
        }



        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
                    this.btnAnswerAll.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32);
                    this.btnAnswerSender.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32);
                    this.btnSend.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_send, 32, 32);
                    this.btnDelete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                    this.btnNewMessage.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);

                    this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1.LabelPickerAlternate = QS2.Desktop.ControlManagment.ControlManagment.getRes("Empfänger");
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Users, false, isTxtTemplate, this.dropDownPatienten);
                    this.uPopUpContPatienten.PopupControl = this.contSelectPatientenBenutzer1;
                    this.contSelectPatientenBenutzer1.popupContMainSearch = this.uPopUpContPatienten;
                    this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItemsAndHeader;
                    this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = false;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                    this.optPostEinAusgang.Value = "E";
                    this.setUIOptionBox(this.optPostEinAusgang.Value.ToString().Trim());
                    this.optReaded.Value = "A";

                    this.gridMessages.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.tMessages.ReadedColumn.ColumnName].Hidden = false;

                    this.gridMessages.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.tMessages.MessageTxtColumn.ColumnName].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
                    this.gridMessages.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.tMessages.MessageTxtColumn.ColumnName].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                    this.gridMessages.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.tMessages.MessageTxtColumn.ColumnName].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
                    this.gridMessages.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.tMessages.MessageTxtColumn.ColumnName].PerformAutoResize();
                    //this.gridMessages.DisplayLayout.Bands[0].GroupHeaderLines = 5;

                    this.clearUITree(true);

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.initControl: " + ex.ToString());
            }
        }

        public void clearUITree(bool WithDetail)
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.gridMessages.Refresh();

                if (WithDetail)
                {
                    this.clearUIDetail();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.clearUITree: " + ex.ToString());
            }
        }
        public void clearUIDetail()
        {
            try
            {
                this.lblSender.Text = "";
                this.txtTitle.Text = "";
                this.textControlMessage.Text = "";
                //this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                this.lblInfoMessageBottom.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.clearUIDetail: " + ex.ToString());
            }
        }



        public void refreshTree()
        {
            try
            {
                this.optPostEinAusgang.Value = "E";
                this.setUIOptionBox(this.optPostEinAusgang.Value.ToString().Trim());

                this.optReaded.Value = "U";
                this.udteFrom.Value = null;
                this.udteTo.Value = null;
                this.loadTreeMessages();
            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.refreshTree: " + ex.ToString());
            }
        }

        //[Serializable()]
        //public class MessagesDTO
        //{
        //    public Guid Id { get; set; }
        //    public Guid? Idpatient { get; set; }
        //    public Guid? Idadresse { get; set; }
        //    public Guid? Idkontakt { get; set; }
        //    public string Titel { get; set; }
        //    public string Nachname { get; set; }
        //    public string Vorname { get; set; }
        //}

        public void loadTreeMessages()
        {
            try
            {
                this.setUI(eTypeUI.ShowMessage);
                this.clearErrorProvider();
                this.clearUITree(true);

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool UIAusgang = this.optPostEinAusgang.Value.ToString().Equals("A");

                    DateTime dFromTmp = new DateTime(1900, 1, 1, 0, 0, 0);
                    DateTime dToTmp = new DateTime(3000, 1, 1, 0, 0, 0);
                    if (this.udteTo.Value != null)
                    {
                        dToTmp = this.udteTo.DateTime.Date;
                    }

                    string ClientsMessage = PMDSBusinessComm.eClientsMessage.MessageToAllClients.ToString();
                    string TypeMessage = PMDSBusinessComm.eTypeMessage.Message.ToString();
                    //IQueryable<PMDS.db.Entities.Messages> tProtMessages = null;
                    //string sMarkerReadedForUser = "readed_" + ENV.USERID.ToString() + ";";
                    MessagesDto lM;

                    if (UIAusgang)
                    {
                        if (this.udteFrom.Value != null)
                        {
                            dFromTmp = this.udteFrom.DateTime.Date;
                        }

                        WCFServiceClient wcf = new WCFServiceClient();
                        lM = wcf.messagesSent(ClientsMessage, TypeMessage, ENV.USERID, dFromTmp.Date, dToTmp.Date);

                        //tProtMessages = db.Messages.Where(o => o.ClientsMessage == ClientsMessage && o.TypeMessage == TypeMessage && o.IDGuidObject == ENV.USERID && o.CreatedDay >= dFromTmp.Date && o.CreatedDay <= dToTmp.Date).OrderByDescending(o => o.Created);
                        
                        //var tM = (from m in db.Messages
                        //          join mu in db.MessagesToUsers on m.ID equals mu.IDMessages
                        //          where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IDGuidObject == ENV.USERID &&
                        //                   m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                        //          orderby m.Created ascending
                        //          select new
                        //          {
                        //              m.ID,
                        //              m.IDGuidObject,
                        //              m.MessagesToUsers,
                        //              m.Progress,
                        //              m.sKey,
                        //              m.Text,
                        //              m.Title,
                        //              m.UserFrom,
                        //              m.UserFromID,
                        //              m.ClientsMessage,
                        //              m.Db,
                        //              m.CreatedDay,
                        //              m.Created,
                        //              m.Classification
                        //          });

                        //public List<SachwalterS1DTO> SachwalterS1(Guid idpatient, DateTime d)
                        //{
                        //    return (from o in this._repoWrapper.dbcontext.Patient
                        //            join s in this._repoWrapper.dbcontext.Sachwalter on o.Id equals s.Idpatient
                        //            where o.Id == idpatient && s.Von <= d.Date && (s.Bis >= d.Date || s.Bis == null) && s.SachwalterJn == true
                        //            select new SachwalterS1DTO { Id = s.Id, Idpatient = s.Idpatient, Nachname = s.Nachname, Vorname = s.Vorname, Titel = s.Titel, Idadresse = s.Idadresse, Idkontakt = s.Idkontakt }).ToList();
                        //}

                        this.btnDelete.Visible = true;
                    }
                    else 
                    {
                        this.btnDelete.Visible = false;

                        if (this.optReaded.Value.ToString().Equals("U"))
                        {                   
                            this.udteFrom.Value = null;
                            dFromTmp = new DateTime(1900, 1, 1, 0, 0, 0);
                            //tProtMessages = db.Messages.Where(o => o.TypeMessage == ClientsMessage && o.TypeMessage == TypeMessage && o.Classification.Contains(ENV.USERID.ToString()) && 
                            //                                    !o.Progress.Contains(sMarkerReadedForUser) && o.CreatedDay >= dFromTmp.Date && o.CreatedDay <= dToTmp.Date).OrderByDescending(o => o.Created);

                            WCFServiceClient wcf = new WCFServiceClient();
                            lM = wcf.messagesUnreadedUsr(ClientsMessage, TypeMessage, ENV.USERID, dFromTmp.Date, dToTmp.Date);
                        }
                        else if (this.optReaded.Value.ToString().Equals("G") || this.optReaded.Value.ToString().Equals("A"))
                        {
                            if (this.udteFrom.Value != null)
                            {
                                dFromTmp = this.udteFrom.DateTime.Date;
                            }
                            else
                            {
                                this.udteFrom.DateTime = DateTime.Now.AddMonths(-1);
                                dFromTmp = this.udteFrom.DateTime.Date;
                            }
                            //tProtMessages = db.Messages.Where(o => o.TypeMessage == ClientsMessage && o.TypeMessage == TypeMessage && o.Classification.Contains(ENV.USERID.ToString()) && 
                            //                                    o.CreatedDay >= dFromTmp.Date && o.CreatedDay <= dToTmp.Date).OrderByDescending(o => o.Created);

                            WCFServiceClient wcf = new WCFServiceClient();
                            lM = wcf.messagesAllUsr(ClientsMessage, TypeMessage, ENV.USERID, dFromTmp.Date, dToTmp.Date);
                        }
                        else
                        {
                            throw new Exception("loadTreeMessages: this.optReaded.Value. '" + this.optReaded.Value.ToString().Trim() + "' not allowed!");
                        }
                    }

                    if (lM.lMessages.Count() >= 1)
                    {
                        foreach (var rM in lM.lMessages)
                        {
                            PMDS.Global.db.ERSystem.dsKlientenliste.tMessagesRow  rNewtMessage = this.sqlManange1.getNewttMessages(ref this.dsKlientenliste1);

                            var rUserFrom = (from b in db.Benutzer
                                             where b.ID == rM.IdguidObject
                                             select new
                                             {
                                                 IDBenutzer = b.ID,
                                                 Benutzer = b.Benutzer1,
                                                 Nachname = b.Nachname,
                                                 Vorname = b.Vorname
                                             }).First();

                            rNewtMessage.IDProtocoll = rM.Id;
                            rNewtMessage.Absender = rUserFrom.Nachname.Trim() + " " + rUserFrom.Vorname.Trim() + " (" + rUserFrom.Benutzer.Trim() + ")";
                            rNewtMessage.UserIDFrom = rUserFrom.IDBenutzer;
                            rNewtMessage.UserFrom = rNewtMessage.Absender.Trim();
                            rNewtMessage.Title = rM.Title.Trim();
                            rNewtMessage.MessageTxt = rM.Text.Trim();

                            //byte[] byt = null;
                            //this.textControl1.Text = "";
                            //this.doEditor.showText(rProtMessage.Protocol1.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControl1, ref byt, ref byt);
                            //string sHTMLMessage = this.doEditor.getText(TXTextControl.StringStreamType.HTMLFormat, this.textControl1);
                            //rNewtMessage.MessageTxt = sHTMLMessage.Trim();

                            //string sNewLine = "\n";
                            //rNewtMessage.MessageTxt = "aaaaa" + sNewLine + "bbbbb" + sNewLine + "ccccc";

                            rNewtMessage.Created = rM.Created;

                            string sTitleTmp = "";
                            if (rNewtMessage.Title.Trim() != "")
                            {
                                sTitleTmp = rNewtMessage.Title.Trim();
                            }
                            else
                            {
                                if (rNewtMessage.MessageTxt.Trim().Length >= 120)
                                {
                                    sTitleTmp = rNewtMessage.MessageTxt.Trim().Substring(0, 120);
                                }
                                else
                                {
                                    sTitleTmp = rNewtMessage.MessageTxt.Trim();
                                }
                            }
                        }
                    }
                    this.gridMessages.Refresh();

                    foreach (UltraGridRow rSelGridRow in this.gridMessages.Rows)
                    {
                        DataRowView v = (DataRowView)rSelGridRow.ListObject;
                        dsKlientenliste.tMessagesRow rtMessageAct = (dsKlientenliste.tMessagesRow)v.Row;

                        var lMu = (from mu in lM.lMessagesToUsers
                                where mu.Idmessages == rtMessageAct.IDProtocoll && mu.Iduser == ENV.USERID
                                select new
                                {
                                    ID = mu.Id, mu.Idmessages, mu.Iduser, mu.Readed, mu.ReadedAt
                                });

                        if (!UIAusgang)
                        {
                            if (lMu.Count() > 0 && !lMu.First().Readed)
                            {
                                rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                rtMessageAct.Readed = false;
                            }
                            else
                            {
                                rtMessageAct.Readed = true;
                            }
                        }
                        else
                        {
                            if (lMu.Count() > 0 && !lMu.First().Readed)
                            {
                                rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                rtMessageAct.Readed = false;
                            }
                            else
                            {
                                rtMessageAct.Readed = true;
                            }
                        }

                        //var rProtocol = (from p in db.Messages
                        //                 where p.ID == rtMessageAct.IDProtocoll
                        //                 select new
                        //                 {
                        //                     IDProtocol = p.ID,
                        //                     progress = p.Progress,
                        //                     db = p.Db
                        //                 }).First();

                        //if (!UIAusgang)
                        //{
                        //    //string sMarkReadedForUser = this.getMarkerForReadedUserLoggedIn();
                        //    if (!rMu.Readed)
                        //    {
                        //        rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        //        rtMessageAct.Readed = false;
                        //    }
                        //    else
                        //    {
                        //        rtMessageAct.Readed = true;
                        //    }
                        //}
                        //else
                        //{
                        //    //eTgTree tgTree2 = this.getXMLDatabaseForMessage(rProtocol.IDProtocol, db);
                        //    //dsAsyncCommData.ToUsersRow[] tToUsersNotReaded = (dsAsyncCommData.ToUsersRow[])tgTree2.dsAsyncCommData1.ToUsers.Select("Readed=0", "");
                        //    if (!rMu.Readed)
                        //    {
                        //        rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        //        rtMessageAct.Readed = false;
                        //    }
                        //    else
                        //    {
                        //        rtMessageAct.Readed = true;
                        //    }
                        //}
                    }

                    this.gridMessages.Refresh();
                    //this.lblMessages.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachrichten") + " (" + this.treeMessages.Nodes.Count.ToString() + ")";
                }

                if (this.gridMessages.Rows.Count > 0)
                {
                    UltraGridRow rFirstGridRow = this.gridMessages.Rows[0];
                    DataRowView v = (DataRowView)this.gridMessages.Rows[0].ListObject;
                    dsKlientenliste.tMessagesRow rFirstRow = (dsKlientenliste.tMessagesRow)v.Row;

                    this.loadMessageDetail(rFirstRow, rFirstGridRow, false);
                    this.gridMessages.ActiveRow = this.gridMessages.Rows[0];
                }

                this.lblNewMessages.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.loadTreeMessages: " + ex.ToString());
            }
        }
        public void loadTreeMessagesOrig()
        {
            try
            {
                this.setUI(eTypeUI.ShowMessage);
                this.clearErrorProvider();
                this.clearUITree(true);

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool UIAusgang = this.optPostEinAusgang.Value.ToString().Equals("A");

                    DateTime dFromTmp = new DateTime(1900, 1, 1, 0, 0, 0);
                    DateTime dToTmp = new DateTime(3000, 1, 1, 0, 0, 0);
                    if (this.udteTo.Value != null)
                    {
                        dToTmp = this.udteTo.DateTime.Date;
                    }

                    string ClientsMessage = PMDSBusinessComm.eClientsMessage.MessageToAllClients.ToString();
                    string TypeMessage = PMDSBusinessComm.eTypeMessage.Message.ToString();
                    IQueryable<PMDS.db.Entities.Messages> tProtMessages = null;
                    string sMarkerReadedForUser = "readed_" + ENV.USERID.ToString() + ";";

                    if (UIAusgang)
                    {
                        if (this.udteFrom.Value != null)
                        {
                            dFromTmp = this.udteFrom.DateTime.Date;
                        }
                        tProtMessages = db.Messages.Where(o => o.ClientsMessage == ClientsMessage && o.TypeMessage == TypeMessage && o.IDGuidObject == ENV.USERID && o.CreatedDay >= dFromTmp.Date && o.CreatedDay <= dToTmp.Date).OrderByDescending(o => o.Created);

                        WCFServiceClient wcf = new WCFServiceClient();
                        MessagesDto lM = wcf.messagesSent(ClientsMessage, TypeMessage, ENV.USERID, dFromTmp.Date, dToTmp.Date);


                        //var tM = (from m in db.Messages
                        //          join mu in db.MessagesToUsers on m.ID equals mu.IDMessages
                        //          where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IDGuidObject == ENV.USERID &&
                        //                   m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                        //          orderby m.Created ascending
                        //          select new
                        //          {
                        //              m.ID,
                        //              m.IDGuidObject,
                        //              m.MessagesToUsers,
                        //              m.Progress,
                        //              m.sKey,
                        //              m.Text,
                        //              m.Title,
                        //              m.UserFrom,
                        //              m.UserFromID,
                        //              m.ClientsMessage,
                        //              m.Db,
                        //              m.CreatedDay,
                        //              m.Created,
                        //              m.Classification
                        //          });

                        //public List<SachwalterS1DTO> SachwalterS1(Guid idpatient, DateTime d)
                        //{
                        //    return (from o in this._repoWrapper.dbcontext.Patient
                        //            join s in this._repoWrapper.dbcontext.Sachwalter on o.Id equals s.Idpatient
                        //            where o.Id == idpatient && s.Von <= d.Date && (s.Bis >= d.Date || s.Bis == null) && s.SachwalterJn == true
                        //            select new SachwalterS1DTO { Id = s.Id, Idpatient = s.Idpatient, Nachname = s.Nachname, Vorname = s.Vorname, Titel = s.Titel, Idadresse = s.Idadresse, Idkontakt = s.Idkontakt }).ToList();
                        //}

                        this.btnDelete.Visible = true;
                    }
                    else
                    {
                        this.btnDelete.Visible = false;

                        if (this.optReaded.Value.ToString().Equals("U"))
                        {
                            this.udteFrom.Value = null;
                            dFromTmp = new DateTime(1900, 1, 1, 0, 0, 0);
                            tProtMessages = db.Messages.Where(o => o.TypeMessage == ClientsMessage && o.TypeMessage == TypeMessage && o.Classification.Contains(ENV.USERID.ToString()) &&
                                                                !o.Progress.Contains(sMarkerReadedForUser) && o.CreatedDay >= dFromTmp.Date && o.CreatedDay <= dToTmp.Date).OrderByDescending(o => o.Created);
                        }
                        else if (this.optReaded.Value.ToString().Equals("G") || this.optReaded.Value.ToString().Equals("A"))
                        {
                            if (this.udteFrom.Value != null)
                            {
                                dFromTmp = this.udteFrom.DateTime.Date;
                            }
                            else
                            {
                                this.udteFrom.DateTime = DateTime.Now.AddMonths(-1);
                                dFromTmp = this.udteFrom.DateTime.Date;
                            }
                            tProtMessages = db.Messages.Where(o => o.TypeMessage == ClientsMessage && o.TypeMessage == TypeMessage && o.Classification.Contains(ENV.USERID.ToString()) &&
                                                                o.CreatedDay >= dFromTmp.Date && o.CreatedDay <= dToTmp.Date).OrderByDescending(o => o.Created);
                        }
                        else
                        {
                            throw new Exception("loadTreeMessages: this.optReaded.Value. '" + this.optReaded.Value.ToString().Trim() + "' not allowed!");
                        }
                    }

                    if (tProtMessages.Count() >= 1)
                    {
                        foreach (PMDS.db.Entities.Messages rProtMessage in tProtMessages)
                        {
                            PMDS.Global.db.ERSystem.dsKlientenliste.tMessagesRow rNewtMessage = this.sqlManange1.getNewttMessages(ref this.dsKlientenliste1);

                            var rUserFrom = (from b in db.Benutzer
                                             where b.ID == rProtMessage.IDGuidObject
                                             select new
                                             {
                                                 IDBenutzer = b.ID,
                                                 Benutzer = b.Benutzer1,
                                                 Nachname = b.Nachname,
                                                 Vorname = b.Vorname
                                             }).First();

                            rNewtMessage.IDProtocoll = rProtMessage.ID;
                            rNewtMessage.Absender = rUserFrom.Nachname.Trim() + " " + rUserFrom.Vorname.Trim() + " (" + rUserFrom.Benutzer.Trim() + ")";
                            rNewtMessage.UserIDFrom = rUserFrom.IDBenutzer;
                            rNewtMessage.UserFrom = rNewtMessage.Absender.Trim();
                            rNewtMessage.Title = rProtMessage.Title.Trim();
                            rNewtMessage.MessageTxt = rProtMessage.Text.Trim();

                            //byte[] byt = null;
                            //this.textControl1.Text = "";
                            //this.doEditor.showText(rProtMessage.Protocol1.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControl1, ref byt, ref byt);
                            //string sHTMLMessage = this.doEditor.getText(TXTextControl.StringStreamType.HTMLFormat, this.textControl1);
                            //rNewtMessage.MessageTxt = sHTMLMessage.Trim();

                            //string sNewLine = "\n";
                            //rNewtMessage.MessageTxt = "aaaaa" + sNewLine + "bbbbb" + sNewLine + "ccccc";

                            rNewtMessage.Created = rProtMessage.Created;

                            string sTitleTmp = "";
                            if (rNewtMessage.Title.Trim() != "")
                            {
                                sTitleTmp = rNewtMessage.Title.Trim();
                            }
                            else
                            {
                                if (rNewtMessage.MessageTxt.Trim().Length >= 120)
                                {
                                    sTitleTmp = rNewtMessage.MessageTxt.Trim().Substring(0, 120);
                                }
                                else
                                {
                                    sTitleTmp = rNewtMessage.MessageTxt.Trim();
                                }
                            }
                        }
                    }
                    this.gridMessages.Refresh();

                    foreach (UltraGridRow rSelGridRow in this.gridMessages.Rows)
                    {
                        DataRowView v = (DataRowView)rSelGridRow.ListObject;
                        dsKlientenliste.tMessagesRow rtMessageAct = (dsKlientenliste.tMessagesRow)v.Row;

                        var rProtocol = (from p in db.Messages
                                         where p.ID == rtMessageAct.IDProtocoll
                                         select new
                                         {
                                             IDProtocol = p.ID,
                                             progress = p.Progress,
                                             db = p.Db
                                         }).First();

                        if (!UIAusgang)
                        {
                            string sMarkReadedForUser = this.getMarkerForReadedUserLoggedIn();
                            if (!rProtocol.progress.Trim().ToLower().Contains(sMarkReadedForUser.Trim().ToLower()))
                            {
                                rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                rtMessageAct.Readed = false;
                            }
                            else
                            {
                                rtMessageAct.Readed = true;
                            }
                        }
                        else
                        {
                            //eTgTree tgTree2 = this.getXMLDatabaseForMessage(rProtocol.IDProtocol, db);
                            //dsAsyncCommData.ToUsersRow[] tToUsersNotReaded = (dsAsyncCommData.ToUsersRow[])tgTree2.dsAsyncCommData1.ToUsers.Select("Readed=0", "");
                            //if (tToUsersNotReaded.Length > 0)
                            //{
                            //    rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            //    rtMessageAct.Readed = false;
                            //}
                            //else
                            //{
                            //    rtMessageAct.Readed = true;
                            //}
                        }

                    }

                    this.gridMessages.Refresh();
                    //this.lblMessages.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachrichten") + " (" + this.treeMessages.Nodes.Count.ToString() + ")";
                }

                if (this.gridMessages.Rows.Count > 0)
                {
                    UltraGridRow rFirstGridRow = this.gridMessages.Rows[0];
                    DataRowView v = (DataRowView)this.gridMessages.Rows[0].ListObject;
                    dsKlientenliste.tMessagesRow rFirstRow = (dsKlientenliste.tMessagesRow)v.Row;

                    this.loadMessageDetail(rFirstRow, rFirstGridRow, false);
                    this.gridMessages.ActiveRow = this.gridMessages.Rows[0];
                }

                this.lblNewMessages.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.loadTreeMessages: " + ex.ToString());
            }
        }


        public void loadMessageDetail(dsKlientenliste.tMessagesRow rSelMessage, UltraGridRow rSelGridRow, bool updateMessageReaded)
        {
            try
            {
                this.setUI(eTypeUI.ShowMessage);
                this.clearUIDetail();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    List<PMDS.db.Entities.Messages> tProtMessage = db.Messages.Where(o => o.ID == rSelMessage.IDProtocoll).ToList();
                    List<PMDS.db.Entities.MessagesToUsers> tMessagesToUsers = db.MessagesToUsers.Where(o => o.IDMessages == rSelMessage.IDProtocoll).ToList();
                    if (tProtMessage.Count() == 1)
                    {
                        PMDS.db.Entities.Messages rProtMessage = tProtMessage.First();

                        //eTgTree tgTree2 = this.getXMLDatabaseForMessage(rProtMessage.ID, db);

                        this.setUIUserFrom(rProtMessage.UserFromID, db);
                        var rUserFrom = (from b in db.Benutzer
                                         where b.ID == rProtMessage.UserFromID
                                         select new
                                         {
                                             IDBenutzer = b.ID,
                                             Benutzer = b.Benutzer1,
                                             Nachname = b.Nachname,
                                             Vorname = b.Vorname
                                         }).First();
                        
                        this.lblSender.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Absender") + ": " + rUserFrom.Nachname.Trim() + " " + rUserFrom.Vorname.Trim() + " (" + rProtMessage.UserFrom.Trim() + ")";
                        this.txtTitle.Text = rProtMessage.Title.Trim();
                        this.textControlMessage.Text = rProtMessage.Text.Trim();

                        this.setAllUsersMessageToUserPicker(tMessagesToUsers, rProtMessage, true, db);

                        bool UIAusgang = false;
                        if (this.optPostEinAusgang.Value.ToString().Trim().ToLower().Equals(("A").Trim().ToLower()))
                        {
                            var tMUNotReaded = (from mu in tMessagesToUsers
                                                where !mu.Readed
                                                select new { mu.ID, mu.Readed, mu.ReadedAt});
                            if (tMUNotReaded.Count() > 0)
                            {
                                rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                rSelMessage.Readed = false;
                            }
                            else
                            {
                                rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                rSelMessage.Readed = true;
                            }

                            var tMUReaded = (from mu in tMessagesToUsers
                                             where mu.Readed
                                             select new { mu.ID, mu.Readed, mu.ReadedAt });

                            string sTransTxtInfomessageBottom = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} von {1} Empfängern haben die Nachricht gelesen") + "";
                            sTransTxtInfomessageBottom = string.Format(sTransTxtInfomessageBottom, tMUReaded.Count().ToString(), tMessagesToUsers.Count.ToString());
                            this.lblInfoMessageBottom.Text = sTransTxtInfomessageBottom.Trim();

                            //lthxy
                            //dsAsyncCommData.ToUsersRow[] tToUsersNotReaded = (dsAsyncCommData.ToUsersRow[])tgTree2.dsAsyncCommData1.ToUsers.Select("Readed=0", "");
                            //if (tToUsersNotReaded.Length > 0)
                            //{
                            //    rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            //    rSelMessage.Readed = false;
                            //}
                            //else
                            //{
                            //    rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            //    rSelMessage.Readed = true;
                            //}
                            //dsAsyncCommData.ToUsersRow[] tToUsersReaded = (dsAsyncCommData.ToUsersRow[])tgTree2.dsAsyncCommData1.ToUsers.Select("Readed=1", "");
                            //string sTransTxtInfomessageBottom = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} von {1} Empfängern haben die Nachricht gelesen") + "";
                            //sTransTxtInfomessageBottom = string.Format(sTransTxtInfomessageBottom, tToUsersReaded.Length.ToString(), tgTree2.dsAsyncCommData1.ToUsers.Count.ToString());
                            //this.lblInfoMessageBottom.Text = sTransTxtInfomessageBottom.Trim();
                        }
                        else if (this.optPostEinAusgang.Value.ToString().Trim().ToLower().Equals(("E").Trim().ToLower()))
                        {
                            if (updateMessageReaded)
                            {
                                IQueryable<PMDS.db.Entities.MessagesToUsers> tMUUpdate = db.MessagesToUsers.Where(a => a.IDMessages == rProtMessage.ID);
                                if (tMUUpdate.Count() > 0)
                                {
                                    foreach (var rMU in tMUUpdate)
                                    {
                                        rMU.Readed = true;
                                        rMU.ReadedAt = DateTime.Now;
                                    }
                                    db.SaveChanges();
                                }

                                //this.checkTreeItemReaded(ENV.USERID, tgTree2, rProtMessage, db);
                                rSelGridRow.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                rSelMessage.Readed = true;
                            }
                        }
                        else
                        {
                            throw new Exception("loadMessageDetail: this.optPostEinAusgang.Value. '" + this.optPostEinAusgang.Value.ToString().Trim() + "' not allowed!");
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nachricht existiert nicht mehr!", "", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.loadMessageDetail: " + ex.ToString());
            }
        }

      
        public void setUIUserFrom(Guid IDUser, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                var rUserFrom = (from b in db.Benutzer
                                    where b.ID == IDUser
                                 select new
                                    {
                                        IDBenutzer = b.ID,
                                        Benutzer = b.Benutzer1,
                                        Nachname = b.Nachname,
                                        Vorname = b.Vorname
                                    }).First();

                this.lblSender.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Absender") + ": " + rUserFrom.Nachname.Trim() + " " + rUserFrom.Vorname.Trim() + " (" + rUserFrom.Benutzer.Trim() + ")";

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.setUIUserFrom: " + ex.ToString());
            }
        }

        public void setAllUsersMessageToUserPicker(List<PMDS.db.Entities.MessagesToUsers> tMessagesToUsers, PMDS.db.Entities.Messages rProtMessage, bool setIconIfUserReaded, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                string lstIDUsers = "";
                foreach (PMDS.db.Entities.MessagesToUsers rToUsers in tMessagesToUsers)
                {
                    bool IDFoundInTree2 = false;
                    lstIDUsers += rToUsers.IDUser.ToString() + ";";
                    this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(rToUsers.IDUser, ref IDFoundInTree2);
                    if (!IDFoundInTree2)
                    {
                        this.contSelectPatientenBenutzer1.addObjectToSelected2(rToUsers.IDUser, true);
                    }
                }
                this.contSelectPatientenBenutzer1.loadDataColl(ref lstIDUsers);
                this.contSelectPatientenBenutzer1.setLabelCount2();

                this.contSelectPatientenBenutzer1.setIconToSelectedObjects(null, true, false);
                if (setIconIfUserReaded)
                {
                    foreach (PMDS.db.Entities.MessagesToUsers rToUsers in tMessagesToUsers)
                    {
                        if (rToUsers.Readed)
                        {
                            this.contSelectPatientenBenutzer1.setIconToSelectedObjects(rToUsers.IDUser, false, false);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.setAllUsersMessageToUserPicker: " + ex.ToString());
            }
        }

        public void checkTreeItemReadedxy(Guid IDUser, List<PMDS.db.Entities.MessagesToUsers> tMessagesToUsers, PMDS.db.Entities.Messages rProtMessage, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                //    string sMarkReadedForUser = this.getMarkerForReadedUserLoggedIn();
                //    if (!rProtMessage.Progress.Trim().ToLower().Contains(sMarkReadedForUser.Trim().ToLower()))
                //    {
                //        dsAsyncCommData.ToUsersRow[] tToUsers = (dsAsyncCommData.ToUsersRow[])tgTree.dsAsyncCommData1.ToUsers.Select("IDUser='" + IDUser.ToString() + "'", "");
                //        if (tToUsers.Length != 1)
                //        {
                //            throw new Exception("contMessenger.loadMessageDetail: tToUsers.Length != 1 not allowed for IDUser '" + IDUser.ToString() + "'!");
                //        }
                //        dsAsyncCommData.ToUsersRow rToUsers = tToUsers[0];
                //        rToUsers.Readed = true;
                //        rToUsers.ReadedAt = DateTime.Now;

                //        string xml = "";
                //        System.IO.StringWriter xmlStrWriter = new System.IO.StringWriter();
                //        System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(xmlStrWriter);
                //        xmlWriter.WriteStartDocument(true);
                //        tgTree.dsAsyncCommData1.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
                //        xml = xmlStrWriter.ToString();
                //        xmlWriter.Close();
                //        rProtMessage.Db = xml;

                //        rProtMessage.Progress += sMarkReadedForUser;
                //        db.SaveChanges();
                //    }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.checkTreeItemReaded: " + ex.ToString());
            }
        }

        public string getMarkerForReadedUserLoggedIn()
        {
            try
            {
                return "readed_" + ENV.USERID.ToString() + ";";

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.getMarkerForReadedUserLoggedIn: " + ex.ToString());
            }
        }


        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.textControlMessage, "");

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.clearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                if (this.txtTitle.Text.Trim() == "" && this.textControlMessage.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.textControlMessage, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Nachricht eingegeben!", "", MessageBoxButtons.OK);
                    return false;
                }

                List<Guid> lstUsers = this.contSelectPatientenBenutzer1.getList();
                if (lstUsers.Count == 0)
                {
                    this.errorProvider1.SetError(this.textControlMessage, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Benutzer ausgewählt!", "", MessageBoxButtons.OK);
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.validateData: " + ex.ToString());
            }
        }
        public bool sendMessage()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this._TypeUI == eTypeUI.AnswerSender)
                    {

                    }
                    else if (this._TypeUI == eTypeUI.AnswerAll)
                    {

                    }
                    else if (this._TypeUI == eTypeUI.NewMessage)
                    {

                    }
                    else
                    {
                        throw new Exception("sendMessage: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                    }

                    List<Guid> lstToUsers = this.contSelectPatientenBenutzer1.getList();
                    //string sToUsers = "";
                    //foreach (Guid IDUser in lstUsers)
                    //{
                    //    PMDS.db.Entities.Benutzer rUser = this.b.getUser(IDUser, db);
                    //    if (rUser.Benutzer1.Trim() == "")
                    //    {
                    //        throw new Exception("contMessenger.sendMessage: rUser.Benutzer1='' for IDUser '" + rUser.ID.ToString() + "' not allowed!");
                    //    }
                    //    sToUsers += rUser.Benutzer1.Trim() + ";";
                    //}

                    PMDS.DB.PMDSBusinessComm.newMessageToClients(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.Message, db,
                                                                    ENV.USERID, lstToUsers, this.txtTitle.Text.Trim(), this.textControlMessage.Text.Trim());
                }

                this.loadTreeMessages();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.sendMessage: " + ex.ToString());
            }
        }

        public void setUI(eTypeUI TypeUI)
        {
            try
            {
                this._TypeUI = TypeUI;

                if (this._TypeUI == eTypeUI.ShowMessage)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        this.panelButtonsTop.Visible = true;
                        this.panelButtonsBottomRight.Visible = false;
                    
                        this.txtTitle.Enabled = false;
                        this.textControlMessage.EditMode = TXTextControl.EditMode.ReadOnly;
                        this.contSelectPatientenBenutzer1._UserCanChangeBenutzerPatients = false;
                        this.contSelectPatientenBenutzer1.setUIEditable(false);

                        //if (!this.optReaded.Value.ToString().Trim().ToLower().Equals(("U").Trim().ToLower()))
                        //{
                        //    this.udteFrom.DateTime = DateTime.Now.AddMonths(-2);
                        //}
                        //else
                        //{
                        //    this.udteFrom.Value = null;
                        //}
                    }
                }
                else if (this._TypeUI == eTypeUI.NewMessage)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        this.clearUIDetail();

                        this.panelButtonsTop.Visible = false;
                        this.panelButtonsBottomRight.Visible = true;
                        this.txtTitle.Enabled = true;
                        this.textControlMessage.EditMode = TXTextControl.EditMode.Edit;
                        this.contSelectPatientenBenutzer1._UserCanChangeBenutzerPatients = true;
                        this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                        this.contSelectPatientenBenutzer1.setUIEditable(true);

                        this.txtTitle.Focus();

                    }
                }
                else if (this._TypeUI == eTypeUI.AnswerSender)
                {
                    UltraGridRow rSelGridRow = null;
                    dsKlientenliste.tMessagesRow rSelMessage = this.getSelectedRow(ref rSelGridRow, true);
                    if (rSelMessage != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.clearUIDetail();
                            PMDS.db.Entities.Messages rProtMessage = db.Messages.Where(o => o.ID == rSelMessage.IDProtocoll).First();

                            this.setTextAnswerAllSender(rProtMessage, db);

                            this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                            string lstIDUsers = "";
                            lstIDUsers += rProtMessage.IDGuidObject.ToString() + ";";
                            bool IDFoundInTree2 = false;
                            this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(rProtMessage.IDGuidObject.Value, ref IDFoundInTree2);
                            if (!IDFoundInTree2)
                            {
                                this.contSelectPatientenBenutzer1.addObjectToSelected2(rProtMessage.IDGuidObject.Value, true);
                            }

                            this.contSelectPatientenBenutzer1.loadDataColl(ref lstIDUsers);
                            this.contSelectPatientenBenutzer1.setLabelCount2();

                            this.panelButtonsTop.Visible = false;
                            this.panelButtonsBottomRight.Visible = true;
                            this.txtTitle.Enabled = true;
                            this.textControlMessage.EditMode = TXTextControl.EditMode.Edit;
                            this.contSelectPatientenBenutzer1._UserCanChangeBenutzerPatients = true;
                            this.contSelectPatientenBenutzer1.setUIEditable(true);

                            this.txtTitle.Focus();
                        }
                    }
                }   
                else if (this._TypeUI == eTypeUI.AnswerAll)
                {
                    UltraGridRow rSelGridRow = null;
                    dsKlientenliste.tMessagesRow rSelMessage = this.getSelectedRow(ref rSelGridRow, true);
                    if (rSelMessage != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            this.clearUIDetail();
                            PMDS.db.Entities.Messages rProtMessage = db.Messages.Where(o => o.ID == rSelMessage.IDProtocoll).First();
                            List<PMDS.db.Entities.MessagesToUsers> tMessagesToUsers = db.MessagesToUsers.Where(o => o.IDMessages == rSelMessage.IDProtocoll).ToList();

                            this.setTextAnswerAllSender(rProtMessage, db);

                            this.panelButtonsTop.Visible = false;
                            this.panelButtonsBottomRight.Visible = true;
                            this.txtTitle.Enabled = true;
                            this.textControlMessage.EditMode = TXTextControl.EditMode.Edit;

                            this.setAllUsersMessageToUserPicker(tMessagesToUsers, rProtMessage, false, db);        //lthxy
                            this.contSelectPatientenBenutzer1._UserCanChangeBenutzerPatients = true;

                            //this.textControl1.SelectionViewMode = TXTextControl.SelectionViewMode.Classic;
                            //this.textControl1.SelectAll();
                            //this.textControl1.Focus();
                            //System.Windows.Forms.Application.DoEvents();
                            //this.textControl1.Selection.Start = 0;
                            //this.textControl1.Selection.Length = 1;
                            this.txtTitle.Focus();
                        }
                    }
                }
                else
                {
                    throw new Exception("setUI: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.setUI: " + ex.ToString());
            }
        }

        public void setTextAnswerAllSender(PMDS.db.Entities.Messages rProtMessage, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                this.setUIUserFrom(ENV.USERID, db);
                this.txtTitle.Text = "AW: " + rProtMessage.Title.Trim();

                var rUserFrom = (from b in db.Benutzer
                                 where b.ID == rProtMessage.IDGuidObject
                                 select new
                                 {
                                     IDBenutzer = b.ID,
                                     Benutzer = b.Benutzer1,
                                     Nachname = b.Nachname,
                                     Vorname = b.Vorname
                                 }).First();

                string newLineOrigTmp = string.Format(this.newLineOrig.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Von") + ": " + rUserFrom.Nachname.Trim() + " " + rUserFrom.Vorname.Trim() + " (" + rUserFrom.Benutzer.Trim() + ")");
                this.textControlMessage.Text = this.newLine + this.newLine + this.newLine + this.newLine + this.newLine + this.newLine + newLineOrigTmp + this.newLine + rProtMessage.Text.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.setTextAnswerAllSender: " + ex.ToString());
            }
        }

        public void deleteMessage(dsKlientenliste.tMessagesRow rSelMessage, UltraGridRow rSelGridRow)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Nachricht wirklich löschen?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Messages rM = db.Messages.Where(o => o.ID == rSelMessage.IDProtocoll).First();
                        db.Messages.Remove(rM);
                        db.SaveChanges();

                        this.clearUIDetail();
                        this.setUI(eTypeUI.NewMessage);
                    }

                    this.loadTreeMessages();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.deleteMessage: " + ex.ToString());
            }
        }

        public void printMessage(dsKlientenliste.tMessagesRow rSelMessage, UltraGridRow rSelGridRow, TXTextControl.TextControl editor)
        {
            try
            {
                editor.Text = "";
                string sNewLine = "\r\n";

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    List<PMDS.db.Entities.MessagesToUsers> tMessagesToUsers = db.MessagesToUsers.Where(o => o.IDMessages == rSelMessage.IDProtocoll).ToList();

                    string sTxtMessageForPrint = "";
                    sTxtMessageForPrint += QS2.Desktop.ControlManagment.ControlManagment.getRes("Absender") + ": " + rSelMessage.Absender + newLine +
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Erstellt am") + ": " + rSelMessage.Created.ToString("dd.MM.yyyy HH:mm:ss") + newLine +
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Betreff") + ": " + rSelMessage.Title.Trim() + sNewLine;

                    string UserSended = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gesendet an:") + newLine;
                    foreach (var rUserSended in tMessagesToUsers)
                    {
                        var rUserFrom = (from b in db.Benutzer
                                            where b.ID == rUserSended.IDUser
                                            select new
                                            {
                                                IDBenutzer = b.ID,
                                                Benutzer = b.Benutzer1,
                                                Nachname = b.Nachname,
                                                Vorname = b.Vorname
                                            }).First();

                        UserSended += rUserFrom.Nachname.Trim() + " " + rUserFrom.Vorname.Trim() + " (" + rUserFrom.Benutzer.Trim() + ")" + "; ";
                    }

                    sTxtMessageForPrint += newLine + UserSended.Trim() + newLine + newLine + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachricht") + ": " + sNewLine + rSelMessage.MessageTxt.Trim();
                    editor.Text = sTxtMessageForPrint.Trim();

                    byte[] bPDF = this.doEditor.getTextInByte(TXTextControl.BinaryStreamType.AdobePDF, editor);
                    Stream stream = new MemoryStream(bPDF);
             
                    PMDS.GUI.VB.frmPdfViewer frmPdfViewer1 = new PMDS.GUI.VB.frmPdfViewer();
                    frmPdfViewer1.initControl("", stream);
                    frmPdfViewer1.Show();
                    frmPdfViewer1.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Druck Nachricht");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.printMessage: " + ex.ToString());
            }
        }


        public dsKlientenliste.tMessagesRow getSelectedRow(ref UltraGridRow gridRow, bool WithMsgBox)
        {
            try
            {
                if (this.gridMessages.ActiveRow != null)
                {
                    if (this.gridMessages.ActiveRow.IsGroupByRow)
                    {
                        if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Meldung ausgewählt!", "", MessageBoxButtons.OK);
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridMessages.ActiveRow.ListObject;
                        dsKlientenliste.tMessagesRow rSelRow = (dsKlientenliste.tMessagesRow)v.Row;
                        gridRow = this.gridMessages.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Meldung ausgewählt!", "", MessageBoxButtons.OK);
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.getSelectedRow: " + ex.ToString());
            }
        }

        public void setUIOptionBox(string ValueOptBoxEinAusgang)
        {
            try
            {
                if (ValueOptBoxEinAusgang.Trim().Equals(("E")))
                {
                    this.optReaded.Visible = true;
                }
                else
                {
                    this.optReaded.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contMessenger.setUIOptionBox: " + ex.ToString());
            }
        }



        private void optPostEinAusgang_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.optPostEinAusgang.Focused)
                {
                    this.setUIOptionBox(this.optPostEinAusgang.Value.ToString().Trim());
                    this.loadTreeMessages();
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

        private void optReaded_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.optReaded.Focused)
                {
                    this.loadTreeMessages();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.refreshTree();
                //this.loadTreeMessages();

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

        private void btnAnswerSender_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setUI(eTypeUI.AnswerSender);

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
        private void btnAnswerAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setUI(eTypeUI.AnswerAll);

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

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.sendMessage();

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
        private void btnAbortSend_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadTreeMessages();

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

        private void btnNewMessage_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setUI(eTypeUI.NewMessage);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rSelGridRow = null;
                dsKlientenliste.tMessagesRow rSelMessage = this.getSelectedRow(ref rSelGridRow, true);
                if (rSelMessage != null)
                {
                    this.deleteMessage(rSelMessage, rSelGridRow);
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

        private void gridMessages_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMessages_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
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
        private void gridMessages_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, this.gridMessages))
                {
                    UltraGridRow rSelGridRow = null;
                    dsKlientenliste.tMessagesRow rSelMessage = this.getSelectedRow(ref rSelGridRow, false);
                    if (rSelMessage != null)
                    {
                        this.loadMessageDetail(rSelMessage, rSelGridRow, true);
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
        private void gridMessages_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;


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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rSelGridRow = null;
                dsKlientenliste.tMessagesRow rSelMessage = this.getSelectedRow(ref rSelGridRow, true);
                if (rSelMessage != null)
                {
                    this.printMessage(rSelMessage, rSelGridRow, this.textControl1);
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


        private void udteFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.udteFrom.Focused)
                {
                    this.loadTreeMessages();
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
        private void udteTo_Leave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.udteTo.Focused)
                {
                    this.loadTreeMessages();
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
