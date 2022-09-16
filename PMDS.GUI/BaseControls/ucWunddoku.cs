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
using System.IO;
using Infragistics.Win.UltraWinGrid;
using PMDS.DB;
using System.Linq;



namespace PMDS.GUI.BaseControls
{
    public partial class ucWunddoku : QS2.Desktop.ControlManagment.BaseControl, ISave
    {
        public event EventHandler WundDokuChanged;

        public Wunde _wunde = new Wunde();
        private bool _InitInProgress = false;
        private Guid _IDAufenthaltPDx;
        private bool _Bilderchanged = false;

        public PMDS.UI.Sitemap.UIFct UIFct1 = new UI.Sitemap.UIFct();
        public bool RigthWundverlaufÄndern = false;
        public bool RigthWundtherapieÄndern = false;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public frmWundeBilder frmWundeBilder1 = null;

        public UltraGridCell CellLastClicked = null;

        public System.Collections.Generic.Dictionary<Guid, cVidiert> lstVidiert = new Dictionary<Guid, cVidiert>();
        public class cVidiert
        {
            public Nullable<Guid> IDWundTherapie = null;
            public string TxtDekurs = "";

        }

        public string colWundtherapieVidierenButton = "WundtherapieVidieren";

        public Nullable<Guid> IDPatientCurrentTmp = null;
        public Nullable<Guid> IDAufenthaltTmp = null;

        public bool IsInitialized = false;







        public ucWunddoku()
        {
            InitializeComponent();
            if (!ENV.AppRunning)
                return;

            FillCombo();

            ucWundSelector1.PointChanged += new EventHandler(ucWundSelector1_PointChanged);

            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("INZ", dgWundverlauf, "Infektionszeichen");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("ERR", dgWundverlauf, "Erreger");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("SCH", dgWundverlauf, "Schmerzqualitaet");

            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WFT", dgWundverlauf, "FistelnTaschen");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WBL", dgWundverlauf, "Wundbelag");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WFS", dgWundverlauf, "WundeFreiliegendeStrukturen");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WSK", dgWundverlauf, "Wundsekretion");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WSM", dgWundverlauf, "Sekretionsmenge");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WUZ", dgWundverlauf, "WundrandUnterminiertZerklueftet");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WOM", dgWundverlauf, "WundrandOedemoesWulstig");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WTP", dgWundverlauf, "WundumgebungTrockenPergamentartig");
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("WEO", dgWundverlauf, "WundumgebungEkzemOedemRoetung");

            UltraGridTools.AddIntTextValuList("v1to4", dgWundverlauf, "Stadium", 1, 4);
            UltraGridTools.AddIntTextValuList("v1to10", dgWundverlauf, "Schmerzintensitaet", 1, 10);

            UltraGridTools.AddBenutzerValueList(dgWundverlauf, "IDBenutzer_Erstellt");
            UltraGridTools.AddBenutzerValueList(dgTherapie, "IDBenutzer_Erstellt");

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                this.dgWundverlauf.DisplayLayout.ValueLists["Wundheilungsphase"].ValueListItems.Clear();
                IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlListe = this.b.GetAuswahlliste(db, "WHP", -100000, false);
                foreach (PMDS.db.Entities.AuswahlListe rSelList in tAuswahlListe)
                {
                    this.dgWundverlauf.DisplayLayout.ValueLists["Wundheilungsphase"].ValueListItems.Add(rSelList.Bezeichnung.Trim(), rSelList.Bezeichnung.Trim());
                }

                this.dgWundverlauf.DisplayLayout.ValueLists["Wundgrund"].ValueListItems.Clear();
                tAuswahlListe = this.b.GetAuswahlliste(db, "WGD", -100000, false);
                foreach (PMDS.db.Entities.AuswahlListe rSelList in tAuswahlListe)
                {
                    this.dgWundverlauf.DisplayLayout.ValueLists["Wundgrund"].ValueListItems.Add(rSelList.Bezeichnung.Trim(), rSelList.Bezeichnung.Trim());
                }

                this.cboWundeEntstanden.Items.Clear();
                tAuswahlListe = this.b.GetAuswahlliste(db, "WEN", -100000, false);
                foreach (PMDS.db.Entities.AuswahlListe rSelList in tAuswahlListe)
                {
                    this.cboWundeEntstanden.Items.Add(rSelList.Bezeichnung.Trim(), rSelList.Bezeichnung.Trim());
                }

                this.dgWundverlauf.DisplayLayout.ValueLists["Wundgeruch"].ValueListItems.Clear();
                tAuswahlListe = this.b.GetAuswahlliste(db, "WGR", -100000, false);
                foreach (PMDS.db.Entities.AuswahlListe rSelList in tAuswahlListe)
                {
                    this.dgWundverlauf.DisplayLayout.ValueLists["Wundgeruch"].ValueListItems.Add(rSelList.Bezeichnung.Trim(), rSelList.Bezeichnung.Trim());
                }
            }

            this.setUIGrids();

        }

        void ucWundSelector1_PointChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Combos mit Werte füllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillCombo()
        {
            cbWundart.ShowAddButton = true;
            cbWundart.AddEmptyEntry = true;
            cbWundart.MaxDropDownItems = 30;
            cbWundart.Group = "WAT";

            cbDekuskala.ShowAddButton = true;
            cbDekuskala.AddEmptyEntry = true;
            cbDekuskala.MaxDropDownItems = 30;
            cbDekuskala.Group = "DES";
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// IDAufenthaltPDx
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthaltPDx
        {
            get { return _IDAufenthaltPDx; }
            set
            {
                this.initControl();

                this.btnDel.Visible = ENV.adminSecure;
                this.btnDelTherapie.Visible = ENV.adminSecure;

                _InitInProgress = true;
                _IDAufenthaltPDx = value;

                bool bEnabled = _IDAufenthaltPDx != Guid.Empty;
                btnAdd.Enabled = bEnabled;
                btnDel.Enabled = bEnabled;
                cbDekuskala.Enabled = bEnabled;
                cbWundart.Enabled = bEnabled;

                txtBisherigeBehandlung.Enabled = bEnabled;
                dtBekanntSeit.Enabled = bEnabled;
                this.cboWundeEntstanden.Enabled = bEnabled;

                RefreshControl();
                _InitInProgress = false;
            }
        }
        public void initControl()
        {
            if (!this.IsInitialized)
            {
                this.btnDel.Click += new System.EventHandler(this.btnDelWundePos_Click);
                this.btnDelTherapie.Click += new System.EventHandler(this.btnDelWundTherapie_Click);

                this.IsInitialized = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderung nach außen signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void SignalValueChanged()
        {
            if (WundDokuChanged != null && !_InitInProgress)
                WundDokuChanged(this, null);
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein neuer Wundverlauf wird hinzugefügt
        /// </summary>
        //----------------------------------------------------------------------------
        private void dgWundverlauf_InitializeTemplateAddRow(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            e.TemplateAddRow.Cells["ID"].Value = Guid.NewGuid();
            e.TemplateAddRow.Cells["Erhebungszeitpunkt"].Value = DateTime.Now;

            if (dsWunde1.WundeKopf.Count > 0)
                e.TemplateAddRow.Cells["IDWundeKopf"].Value = dsWunde1.WundeKopf[0].ID;

        }

        public void setUIGrids()
        {
            this.dgThumbnails.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgThumbnails.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.White;
            this.dgThumbnails.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

            this.dgWundverlauf.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgWundverlauf.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.White;
            this.dgWundverlauf.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

            this.dgTherapie.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgTherapie.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.White;
            this.dgTherapie.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

            this.dgTherapie.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            this.dgThumbnails.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.White;
            this.dgWundverlauf.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;

            this.dgWundverlauf.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.dgTherapie.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.dgThumbnails.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            
            if (ENV.WundtherapieVidieren)
            {
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.dsWunde1.WundeTherapie.VidiertAmColumn.ColumnName].Hidden = false;
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.dsWunde1.WundeTherapie.VidiertJNColumn.ColumnName].Hidden = false;
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.dsWunde1.WundeTherapie.VidiertVonColumn.ColumnName].Hidden = false;
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.colWundtherapieVidierenButton.Trim()].Hidden = false;
            }
            else
            {
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.dsWunde1.WundeTherapie.VidiertAmColumn.ColumnName].Hidden = true;
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.dsWunde1.WundeTherapie.VidiertJNColumn.ColumnName].Hidden = true;
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.dsWunde1.WundeTherapie.VidiertVonColumn.ColumnName].Hidden = true;
                this.dgTherapie.DisplayLayout.Bands[0].Columns[this.colWundtherapieVidierenButton.Trim()].Hidden = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen speichern
        /// </summary>
        //----------------------------------------------------------------------------
        public bool Save()
        {
            if (this.IDPatientCurrentTmp == null)
            {
                throw new Exception("ucWunddoku.Save: this.IDPatientCurrentTmp == null not allowed!");
            }
            if (this.IDAufenthaltTmp == null)
            {
                throw new Exception("ucWunddoku.Save: this.IDAufenthaltTmp == null not allowed!");
            }

            if (_IDAufenthaltPDx == Guid.Empty)
                return true;

            if ( !ValidateFields())
            {
                return false;
            }

            //Prüfen,ob ein anderer Benutzer in der Zwischenzeit eine Wundtherapie eingefügt hat
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                dsWunde.WundeKopfRow rWundeKopfUpdate = (dsWunde.WundeKopfRow)dsWunde1.WundeKopf.Rows[0];
                if (rWundeKopfUpdate.RowState == DataRowState.Added)
                {
                    db.Entities.WundeKopf rWundeKopf = this.b.checkWundeKopfIDAufenthaltPdxExists(_IDAufenthaltPDx, db);
                    if (rWundeKopf != null)
                    {
                        string txtMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis: Die Wundbeschreibung wurde in der Zwischenzeit durch einen anderen Benutzer geändert:\n\r\n\r{0}");
                        string FieldsExistsInDB = "";
                        if (!string.IsNullOrWhiteSpace(rWundeKopf.Wundart))
                            FieldsExistsInDB += "Wundart: " + rWundeKopf.Wundart.Trim() + Environment.NewLine;
                        if (!string.IsNullOrWhiteSpace(rWundeKopf.Dekuskala))
                            FieldsExistsInDB += QS2.Desktop.ControlManagment.ControlManagment.getRes("Skala: ") + rWundeKopf.Dekuskala.Trim() + Environment.NewLine;
                        if (rWundeKopf.Dekuwert.HasValue)
                            FieldsExistsInDB += QS2.Desktop.ControlManagment.ControlManagment.getRes("Wert: ") + rWundeKopf.Dekuwert.ToString() + Environment.NewLine;
                        if (rWundeKopf.BekanntSeit.HasValue)
                            FieldsExistsInDB += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bekannt seit: ") + rWundeKopf.BekanntSeit.Value.ToString("dd.MM.yyyy") + Environment.NewLine;
                        if (!string.IsNullOrWhiteSpace(rWundeKopf.WundeEntstanden)) 
                            FieldsExistsInDB += QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde entstanden: ") + rWundeKopf.WundeEntstanden.Trim() + Environment.NewLine;
                        if (!string.IsNullOrWhiteSpace(rWundeKopf.BisherigeBehandlung))
                            FieldsExistsInDB += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bisherige Behandlung: ") + (rWundeKopf.BisherigeBehandlung.Length < 30 ? rWundeKopf.BisherigeBehandlung.Trim() : rWundeKopf.BisherigeBehandlung.Trim().Substring(0,30) + "...") + Environment.NewLine;

                        txtMsgBox = string.Format(txtMsgBox, FieldsExistsInDB);

                        rWundeKopfUpdate.ID = rWundeKopf.ID;
                        rWundeKopfUpdate.IDBenutzer_Erstellt = rWundeKopf.IDBenutzer_Erstellt.Value;
                        rWundeKopfUpdate.IDBenutzer_Geaendert = ENV.USERID;
                        rWundeKopfUpdate.DatumGeaendert = DateTime.Now;
                        rWundeKopfUpdate.AcceptChanges();
                        rWundeKopfUpdate.SetModified();

                        foreach (dsWunde.WundePosRow rWundePos in dsWunde1.WundePos)
                            rWundePos.IDWundeKopf = rWundeKopfUpdate.ID;
                        foreach (dsWunde.WundeTherapieRow rWundeTherapie in dsWunde1.WundeTherapie)
                            rWundeTherapie.IDWundeKopf = rWundeKopfUpdate.ID;

                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtMsgBox, "", MessageBoxButtons.OK, true);
                    }
                }
            }

            UpdateWundeKopfData();

            if (ENV.WundtherapieVidieren)
            {
                foreach (dsWunde.WundeTherapieRow rTherapie in dsWunde1.WundeTherapie)
                {
                    if (rTherapie.RowState != DataRowState.Deleted && rTherapie.RowState == DataRowState.Modified)
                    {

                        Guid IDBenutzer = Guid.Empty;
                        if (!rTherapie.IsIDBenutzer_ErstelltNull())
                            IDBenutzer = rTherapie.IDBenutzer_Erstellt;
                        else if (rTherapie.IsIDBenutzer_ErstelltNull() && !rTherapie.IsIDBenutzer_GeaendertNull())
                        {
                            rTherapie.IDBenutzer_Erstellt = rTherapie.IDBenutzer_Geaendert;
                            IDBenutzer = rTherapie.IDBenutzer_Geaendert;
                        }

                        if (this.check24HoursAndRightEditWundeTherapie(rTherapie.DatumErstellt, IDBenutzer))
                        {
                            if (!this.lstVidiert.Keys.Contains(rTherapie.ID))
                            {
                                rTherapie.VidiertJN = false;
                                rTherapie.SetVidiertAmNull();
                                rTherapie.VidiertVon = "";
                            }
                        }
                    }
                }

                foreach (cVidiert VidiertAct in this.lstVidiert.Values)
                {
                    this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidierung"), VidiertAct.TxtDekurs,
                                            false, this.IDPatientCurrentTmp.Value, PflegeEintragTyp.WUNDEN, this.IDAufenthaltTmp.Value);
                }

                this.lstVidiert.Clear();
            }

            if (_Bilderchanged)
                RefreshThumbs();
            _Bilderchanged = false;

            List<string> lstDekursWundeTherapie = this.getTxtDekursWundeTherapie(ENV.lic_WundtherapieOffenWarnung);
            if (lstDekursWundeTherapie.Count > 0)
            {
                foreach (string txtDekursWundeTherapie in lstDekursWundeTherapie)
                {
                    if (txtDekursWundeTherapie.Trim() != "")
                    {
                        PMDS.db.Entities.PflegeEintrag peNew = this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde wurde editiert.") + "\n\r" + txtDekursWundeTherapie, false, this.IDPatientCurrentTmp.Value, PflegeEintragTyp.WUNDEN, this.IDAufenthaltTmp.Value);
                        System.Collections.Generic.List<Guid> lst = PMDS.Global.Tools.GetWichtigFuerDefaults(eDekursDefaults.NeueWundtherapie.ToString());
                        foreach (Guid IDWichtig in lst)
                        {
                            this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde wurde editiert.") + "\n\r" + txtDekursWundeTherapie, false, this.IDPatientCurrentTmp.Value, PflegeEintragTyp.WUNDEN, peNew.IDAufenthalt, IDWichtig, peNew.ID, peNew.Zeitpunkt);
                        }
                    }
                }
            }

            List<string> lstDekursWundePos = this.getTxtDekursWundePos();
            if (lstDekursWundePos.Count > 0)
            {
                foreach (string txtDekursWundePos in lstDekursWundePos)
                {
                    if (txtDekursWundePos.Trim() != "")
                    {
                        PMDS.db.Entities.PflegeEintrag peNew = this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde wurde editiert.") + "\n\r" + txtDekursWundePos, false, this.IDPatientCurrentTmp.Value, PflegeEintragTyp.WUNDEN, this.IDAufenthaltTmp.Value);
                        System.Collections.Generic.List<Guid> lst = PMDS.Global.Tools.GetWichtigFuerDefaults(eDekursDefaults.NeuerWundeintrag.ToString());
                        foreach (Guid IDWichtig in lst)
                        {
                            this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde wurde editiert.") + "\n\r" + txtDekursWundePos, false, this.IDPatientCurrentTmp.Value, PflegeEintragTyp.WUNDEN, peNew.IDAufenthalt, IDWichtig, peNew.ID, peNew.Zeitpunkt);
                        }
                    }

                }
            }

            //Neuen Eintrag erst speichern, nachdem die Unterschiede protokolliert wurden
            _wunde.Write(dsWunde1);     // Pos, Therapie und Bilddaten sind einfache datatables die entsprechend manipuliert wurden

            return true;
        }

        public List<string> getTxtDekursWundeTherapie(bool bCheckOpen)
        {
            try
            {
                List<string> lstDekursWundeTherapie = new List<string>();
                //this.dgTherapie.UpdateData();

                string sMsgTherapieNichtAbgesetzt = "";
                int iTherapieNichtAbgesetzt = 0;
                foreach (dsWunde.WundeTherapieRow rWundeTherapieAct in this.dsWunde1.WundeTherapie)
                {
                    if (rWundeTherapieAct.RowState != DataRowState.Deleted)
                    {
                        string txtDekursWundeTherapie = "";

                        if (rWundeTherapieAct.RowState == DataRowState.Added)
                        {
                            this.setRowTxtDekursWundeTherapie(rWundeTherapieAct, null, true, ref txtDekursWundeTherapie);
                        }
                        else
                        {
                            PMDS.DB.Global.DBWunde DBWundeTmp = new DB.Global.DBWunde();
                            dsWunde dsWunde1 = DBWundeTmp.readWundeTherapieByID(rWundeTherapieAct.ID);
                            if (dsWunde1.WundeTherapie.Rows.Count != 1)
                            {
                                throw new Exception("getTxtDekursWundeTherapie: sWunde1.WundeTherapie.Rows.Count != 1 for IDWundeTherapie '" + rWundeTherapieAct.ID.ToString() + "'!");
                            }
                            dsWunde.WundeTherapieRow rWundeOrig = (dsWunde.WundeTherapieRow)dsWunde1.WundeTherapie.Rows[0];

                            this.setRowTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, false, ref txtDekursWundeTherapie);
                        }

                        if (bCheckOpen && rWundeTherapieAct.RowState == DataRowState.Unchanged && rWundeTherapieAct.IsAbgesetztAmNull())
                        {
                            iTherapieNichtAbgesetzt++;
                            sMsgTherapieNichtAbgesetzt += rWundeTherapieAct.DatumErstellt.ToString();
                            if (!rWundeTherapieAct.IsTherapieNull() && rWundeTherapieAct.Therapie.Trim() != "")
                            {
                                sMsgTherapieNichtAbgesetzt += ", ";
                                string sTherapietext = rWundeTherapieAct.Therapie.Trim();
                                if (sTherapietext.Length > 30)
                                    sTherapietext = sTherapietext.Substring(0, 30) + " ...";
                                sMsgTherapieNichtAbgesetzt += sTherapietext;
                            }
                            sMsgTherapieNichtAbgesetzt += "\n\r";
                        }

                        if (txtDekursWundeTherapie.Trim() != "")
                        {
                            txtDekursWundeTherapie = getTxtWunde(rWundeTherapieAct.IDWundeKopf) + txtDekursWundeTherapie;                            
                            string sTranslatedHeader = "";
                            if (!rWundeTherapieAct.IsDatumErstelltNull())
                            {
                                if (rWundeTherapieAct.RowState == DataRowState.Added)
                                {
                                    sTranslatedHeader = QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom {0} hinzugefügt");
                                    sTranslatedHeader = string.Format(sTranslatedHeader, rWundeTherapieAct.DatumErstellt.ToString("dd.MM.yyyy HH:mm"));
                                }
                                else
                                {
                                    if (rWundeTherapieAct.VidiertJN == true)
                                    {
                                        sTranslatedHeader = QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom {0} vidiert");
                                    }
                                    else
                                    {
                                        sTranslatedHeader = QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom {0} geändert");

                                    }
                                    sTranslatedHeader = string.Format(sTranslatedHeader, rWundeTherapieAct.DatumErstellt.ToString("dd.MM.yyyy HH:mm"));
                                }
                            }

                            lstDekursWundeTherapie.Add(sTranslatedHeader + "\r\n" + txtDekursWundeTherapie);
                        }
                    }
                }

                if (iTherapieNichtAbgesetzt > 0)
                {
                    sMsgTherapieNichtAbgesetzt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis: Nicht abgesetzte Therapie") + (iTherapieNichtAbgesetzt == 1 ? "" : "n") + "\n\r" + sMsgTherapieNichtAbgesetzt;
                    System.Windows.Forms.MessageBox.Show(sMsgTherapieNichtAbgesetzt);
                }

                return lstDekursWundeTherapie;
            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.getTxtDekursWundeTherapie: " + ex.ToString());
            }
        }

        public List<string> getTxtDekursWundePos()
        {
            try
            {
                List<string> lstDekursWundePos = new List<string>();
                
                foreach (dsWunde.WundePosRow rWundePosAct in this.dsWunde1.WundePos)
                {
                    if (rWundePosAct.RowState != DataRowState.Deleted)
                    {
                        string txtDekursWundePos = "";

                        if (rWundePosAct.RowState == DataRowState.Added)
                        {
                            this.setRowTxtDekursWundePos(rWundePosAct, null, true, ref txtDekursWundePos);
                        }
                        else
                        {
                            PMDS.DB.Global.DBWunde DBWundeTmp = new DB.Global.DBWunde();
                            dsWunde dsWunde1 = DBWundeTmp.readWundePosByID(rWundePosAct.ID);
                            if (dsWunde1.WundePos.Rows.Count != 1)
                            {
                                throw new Exception("getTxtDekursWundePos: sWunde1.WundePos.Rows.Count != 1 for IDWundePos '" + rWundePosAct.ID.ToString() + "'!");
                            }
                            dsWunde.WundePosRow rWundeOrig = (dsWunde.WundePosRow)dsWunde1.WundePos.Rows[0];

                            this.setRowTxtDekursWundePos(rWundePosAct, rWundeOrig, false, ref txtDekursWundePos);
                        }

                        if (txtDekursWundePos.Trim() != "")
                        {

                            txtDekursWundePos = getTxtWunde(rWundePosAct.IDWundeKopf) + txtDekursWundePos;

                            string sTranslatedHeader = "";
                            if (!rWundePosAct.IsDatumErstelltNull())
                            {
                                if (rWundePosAct.RowState == DataRowState.Added)
                                {
                                    sTranslatedHeader = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundverlauf vom {0} hinzugefügt");
                                    sTranslatedHeader = string.Format(sTranslatedHeader, rWundePosAct.DatumErstellt.ToString("dd.MM.yyyy HH:mm"));
                                }
                                else
                                {
                                    sTranslatedHeader = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundverlauf vom {0} geändert");
                                    sTranslatedHeader = string.Format(sTranslatedHeader, rWundePosAct.DatumErstellt.ToString("dd.MM.yyyy HH:mm"));
                                }
                            }

                            lstDekursWundePos.Add(sTranslatedHeader + "\r\n" + txtDekursWundePos);
                        }
                    }
                }

                return lstDekursWundePos;
            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.getTxtDekursWundePos: " + ex.ToString());
            }
        }

        private string getTxtWunde(Guid IDWundeKopf)
        {
            try
            {
                string txtWunde = "";
                dsWunde.WundeKopfRow WundeKopf = dsWunde1.WundeKopf.FindByID(IDWundeKopf);
                System.Linq.IQueryable<PMDS.db.Entities.AufenthaltPDx> tAufenthaltPDx = null;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    tAufenthaltPDx = db.AufenthaltPDx.Where(o => o.ID == WundeKopf.IDAufenthaltPDx);
                    PMDS.db.Entities.AufenthaltPDx rAufenthaltPDx = null;
                    if (tAufenthaltPDx.Count() == 1)
                    {
                        rAufenthaltPDx = tAufenthaltPDx.First();
                        string strWundart = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundart: nicht definiert");
                        string strLokalisierung = QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokalisierung: nicht definiert");
                        string strLokalisierungSeite = QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokalisierungsseite: nicht definiert");
                        string strDatumErstellt = "";

                        if (WundeKopf.Wundart.Trim() != "")
                            strWundart = WundeKopf.Wundart.Trim();
                        if (strLokalisierung.Trim() != "")
                            strLokalisierung = rAufenthaltPDx.Lokalisierung.Trim();
                        if (strLokalisierungSeite.Trim() != "")
                            strLokalisierungSeite = rAufenthaltPDx.LokalisierungSeite.Trim();
                        if (!WundeKopf.IsDatumErstelltNull())
                            strDatumErstellt = WundeKopf.DatumErstellt.ToString();

                        txtWunde += strWundart + " " + strLokalisierung + " / " + strLokalisierungSeite + " - " + strDatumErstellt + " \n\r";
                    }
                }
                return txtWunde;
            }

            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.getTxtWunde: " + ex.ToString());
            }
        }


        public void setRowTxtDekursWundeTherapie(dsWunde.WundeTherapieRow rWundeTherapieAct, dsWunde.WundeTherapieRow rWundeOrig, bool rowAdded, ref string txtDekursWundeTherapie)
        {
            try
            {
                string sColname = "VorgeschlagenVon";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorgeschlagen von: "), false, ref txtDekursWundeTherapie);

                sColname = "VerordnetAm";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Angeordnet am: "), true, ref txtDekursWundeTherapie);

                sColname = "AngeordnetVon";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Angeordnet von: "), false, ref txtDekursWundeTherapie);

                sColname = "Debridement";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Debridement: "), false, ref txtDekursWundeTherapie);

                sColname = "Reinigung";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Reinigung: "), false, ref txtDekursWundeTherapie);

                sColname = "Wundauflage";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundauflage: "), false, ref txtDekursWundeTherapie);

                sColname = "Wundrandschutz";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrandschutz: "), false, ref txtDekursWundeTherapie);

                sColname = "Sekundaerverband";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Sekundärverband: "), false, ref txtDekursWundeTherapie);

                sColname = "Fixierung";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Fixierung: "), false, ref txtDekursWundeTherapie);

                sColname = "VWIntervall";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("VW-Interval: "), false, ref txtDekursWundeTherapie);

                sColname = "Hyperkeratoseentfernung";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hyperkeratoseentfernung: "), false, ref txtDekursWundeTherapie);

                sColname = "Hautpflege";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hautpflege: "), false, ref txtDekursWundeTherapie);

                sColname = "Zusatzernährung";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzernährung: "), false, ref txtDekursWundeTherapie);

                sColname = "Kompression";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Kompression: "), false, ref txtDekursWundeTherapie);

                sColname = "Freillagerung";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Freillagerung: "), false, ref txtDekursWundeTherapie);

                sColname = "Wundabstrich";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundabstrich: "), false, ref txtDekursWundeTherapie);

                sColname = "Therapie";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie: "), false, ref txtDekursWundeTherapie);

                sColname = "AbgesetztAm";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("AbgesetztAm: "), true, ref txtDekursWundeTherapie);

                sColname = "AbgesetztVon";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("AbgesetztVon: "), false, ref txtDekursWundeTherapie);

                sColname = "VidiertJN";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidiert: "), false, ref txtDekursWundeTherapie);

                sColname = "VidiertAm";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidiert am: "), false, ref txtDekursWundeTherapie);

                sColname = "VidiertVon";
                this.setColTxtDekursWundeTherapie(rWundeTherapieAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidiert von: "), false, ref txtDekursWundeTherapie);
            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.setRowTxtDekursWundeTherapie: " + ex.ToString());
            }
        }

        public void setRowTxtDekursWundePos(dsWunde.WundePosRow rWundePosAct, dsWunde.WundePosRow rWundeOrig, bool rowAdded, ref string txtDekursWundePos)
        {
            try
            {
                string sColname = "Erhebungszeitpunkt";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Erhebungszeitpunkt: "), true, ref txtDekursWundePos);

                sColname = "Stadium";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Stadium: "), false, ref txtDekursWundePos);

                sColname = "Schmerzqualitaet";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Schmerzqualität: "), false, ref txtDekursWundePos);

                sColname = "Schmerzintensitaet";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Schmerzintensität: "), false, ref txtDekursWundePos);

                sColname = "NekroseJN";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("nekrotisch?: "), false, ref txtDekursWundePos);

                sColname = "Wundzustand";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundzustand: "), false, ref txtDekursWundePos);

                sColname = "Wundheilungsphase";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundheilungsphase: "), false, ref txtDekursWundePos);

                sColname = "Wundgrund";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundgrund: "), false, ref txtDekursWundePos);

                sColname = "L";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Länge (cm): "), false, ref txtDekursWundePos);

                sColname = "B";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Breite (cm): "), false, ref txtDekursWundePos);

                sColname = "H";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Tiefe (cm): "), false, ref txtDekursWundePos);

                sColname = "Erreger";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreger: "), false, ref txtDekursWundePos);

                sColname = "Infektionszeichen";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Infektionszeichen: "), false, ref txtDekursWundePos);

                sColname = "FistelnTaschen";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Fisteln / Taschen: "), false, ref txtDekursWundePos);

                sColname = "Wundbelag";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundbelag: "), false, ref txtDekursWundePos);

                sColname = "WundeFreiliegendeStrukturen";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Freiliegende Strukturen: "), false, ref txtDekursWundePos);

                sColname = "Wundsekretion";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundexudat Farbe: "), false, ref txtDekursWundePos);

                sColname = "Sekretionsmenge";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundexudat Menge: "), false, ref txtDekursWundePos);

                sColname = "Wundgeruch";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundgeruch: "), false, ref txtDekursWundePos);

                sColname = "WundrandIntakt";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand intakt?: "), false, ref txtDekursWundePos);

                sColname = "WundrandMazeriert";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand mazeriert: "), false, ref txtDekursWundePos);

                sColname = "WundrandUnterminiertZerklueftet";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand unterminiert / zerklüftet / glatt: "), false, ref txtDekursWundePos);

                sColname = "WundrandGeroetet";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand gerötet: "), false, ref txtDekursWundePos);

                sColname = "WundrandHyperkeratose";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand Hyperkeratose: "), false, ref txtDekursWundePos);

                sColname = "WundrandOedemoesWulstig";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand ödemös / wulstig: "), false, ref txtDekursWundePos);

                sColname = "WundumgebungIntakt";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung intakt?: "), false, ref txtDekursWundePos);

                sColname = "WundumgebungTrockenPergamentartig";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung trocken / pergamentartig: "), false, ref txtDekursWundePos);

                sColname = "WundumgebungEkzemOedemRoetung";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung Ekzem / Ödem / Rötung: "), false, ref txtDekursWundePos);

                sColname = "WundumgebungSpannungsblase";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung Spannungsblase: "), false, ref txtDekursWundePos);

                sColname = "Wundumgebung";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung sonstiges: "), false, ref txtDekursWundePos);

                sColname = "GranulationProz";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Granulation %: "), false, ref txtDekursWundePos);

                sColname = "EpithelisierungProz";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Epithelisierung %: "), false, ref txtDekursWundePos);

                sColname = "Heilungsverlauf";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Heilungsverlauf: "), false, ref txtDekursWundePos);

                sColname = "Heilungstext";
                this.setColTxtDekursWundePos(rWundePosAct, rWundeOrig, rowAdded, sColname.Trim(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonstiges: "), false, ref txtDekursWundePos);


            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.setRowTxtDekursWundePos: " + ex.ToString());
            }
        }

        public void setColTxtDekursWundeTherapie(dsWunde.WundeTherapieRow rWundeTherapieAct, dsWunde.WundeTherapieRow rWundeOrig, bool rowAdded, string sColname, string colTranslated, bool isDateCol, ref string txtDekursWundeTherapie)
        {
            try
            {
                if (rWundeOrig == null || this.ValueGridChanged(rWundeTherapieAct[sColname], rWundeOrig[sColname], false))
                {
                    if (rWundeOrig == null && rWundeTherapieAct[sColname] != System.DBNull.Value && rWundeTherapieAct[sColname].ToString().Trim() != "")
                    {
                        if (isDateCol)
                        {
                            txtDekursWundeTherapie += "\r\n" + colTranslated + "" + " -> " + this.getDateTimeAsStringRowValue(rWundeTherapieAct[sColname]);
                        }
                        else
                        {
                            txtDekursWundeTherapie += "\r\n" + colTranslated + "" + " -> " + this.getStringFromRowValue(rWundeTherapieAct[sColname]);
                        }
                    }
                    else if (rWundeOrig != null)
                    {
                        if (isDateCol)
                        {
                            txtDekursWundeTherapie += "\r\n" + colTranslated + this.getDateTimeAsStringRowValue(rWundeOrig[sColname]) + " -> " + this.getDateTimeAsStringRowValue(rWundeTherapieAct[sColname]);
                        }
                        else
                        {
                            txtDekursWundeTherapie += "\r\n" + colTranslated + this.getStringFromRowValue(rWundeOrig[sColname]) + " -> " + this.getStringFromRowValue(rWundeTherapieAct[sColname]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.setColTxtDekursWundeTherapie: " + ex.ToString());
            }
        }


        public void setColTxtDekursWundePos(dsWunde.WundePosRow rWundePosAct, dsWunde.WundePosRow rWundeOrig, bool rowAdded, string sColname, string colTranslated, bool isDateCol, ref string txtDekursWundePos)
        {
            try
            {
                if (rWundeOrig == null || this.ValueGridChanged(rWundePosAct[sColname], rWundeOrig[sColname], false))
                {
                    if (rWundeOrig == null && rWundePosAct[sColname] != System.DBNull.Value && rWundePosAct[sColname].ToString().Trim() != "")
                    {
                        if (isDateCol)
                        {
                            txtDekursWundePos += "\r\n" + colTranslated + "" + " -> " + this.getDateTimeAsStringRowValue(rWundePosAct[sColname]);
                        }
                        else
                        {
                            txtDekursWundePos += "\r\n" + colTranslated + "" + " -> " + this.getStringFromRowValue(rWundePosAct[sColname]);
                        }
                    }
                    else if (rWundeOrig != null)
                    {
                        if (isDateCol)
                        {
                            txtDekursWundePos += "\r\n" + colTranslated + this.getDateTimeAsStringRowValue(rWundeOrig[sColname]) + " -> " + this.getDateTimeAsStringRowValue(rWundePosAct[sColname]);
                        }
                        else
                        {
                            txtDekursWundePos += "\r\n" + colTranslated + this.getStringFromRowValue(rWundeOrig[sColname]) + " -> " + this.getStringFromRowValue(rWundePosAct[sColname]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.setColTxtDekursWundePos: " + ex.ToString());
            }
        }

        public bool ValueGridChanged(object colValueOrig, object colValueNew, bool rowAdded)
        {
            try
            {
                if (rowAdded)
                {
                    return true;
                }
                else
                {
                    if (!colValueOrig.GetType().Equals(colValueNew.GetType()))
                    {
                        return true;
                    }

                    Type type = colValueOrig.GetType();
                    if (type.IsPrimitive || typeof(string).Equals(type))
                    {
                        return !colValueOrig.Equals(colValueNew);
                    }

                    if (typeof(DateTime).Equals(type))
                    {
                        DateTime t1 = Convert.ToDateTime(colValueOrig);
                        DateTime t2 = Convert.ToDateTime(colValueNew);
                        //Milliisekunden entfernen, sonst gibt der Vergleich immer falsch!!!
                        t1 = t1.AddTicks(-(t1.Ticks % 10000000));
                        t2 = t2.AddTicks(-(t2.Ticks % 10000000));
                        //TimeSpan x = t1 - t2;
                        return t1 != t2;
                    }


                    if (!colValueOrig.Equals(colValueNew))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.ValueGridChanged: " + ex.ToString());
            }
        }
        public string getDateTimeAsStringRowValue(object colValue)
        {
            try
            {
                if (colValue == System.DBNull.Value)
                {
                    return "";
                }
                else
                {
                    DateTime datValue = (DateTime)colValue;
                    return datValue.ToString("dd.MM.yyyy HH:mm");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.getDateTimeAsStringRowValue: " + ex.ToString());
            }
        }
        public string getStringFromRowValue(object colValue)
        {
            try
            {
                if (colValue == System.DBNull.Value)
                {
                    return "";
                }
                else
                {
                    string strValue = System.Convert.ToString(colValue);
                    return strValue.Trim();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWundedoku.getStringFromRowValue: " + ex.ToString());
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Kopfdaten ändern
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateWundeKopfData()
        {
            dsWunde.WundeKopfRow r = dsWunde1.WundeKopf[0];
            r.Dekuskala = cbDekuskala.Text.Trim();
            r.Dekuwert = RBU.RBUSF.ConvertStringToInt(tbDekuwert.Text);
            r.Wundart = cbWundart.Text;

            if (dtBekanntSeit.Value == null)
            {
                r.SetBekanntSeitNull();
            }
            else
            {
                r.BekanntSeit = dtBekanntSeit.DateTime;
            }

            if (this.cboWundeEntstanden.Value == null)
            {
                r.WundeEntstanden = "";
            }
            else
            {
                r.WundeEntstanden = this.cboWundeEntstanden.Value.ToString();
            }

            if (txtBisherigeBehandlung.Value == null)
            {
                r.BisherigeBehandlung = "";
            }
            else
            {
                r.BisherigeBehandlung = txtBisherigeBehandlung.Value.ToString();
            }

            r.ClickedValueX = -1;
            r.ClickedValueY = -1;
            r.ClickedImage = ucWundSelector1.IMAGEPOINTED.GetBuffer();
            if (ucWundSelector1.POINTS.Count > 0)
            {
                r.ClickedValueX = ucWundSelector1.POINTS[0].X;
                r.ClickedValueY = ucWundSelector1.POINTS[0].Y;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Rückgängig mit gleicher ID
        /// </summary>
        //----------------------------------------------------------------------------
        public void Undo()
        {
            RefreshControl();
        }

        private void RefreshControl()
        {
            if (_wunde == null)
                _wunde = new Wunde();

            this.IDPatientCurrentTmp = ENV.CurrentIDPatient;
            this.IDAufenthaltTmp = ENV.IDAUFENTHALT;

            dsWunde1.Clear();
            cbDekuskala.Text = "";
            cbWundart.Text = "";
            tbDekuwert.Text = "";
            ucWundSelector1.Clear();
            txtBisherigeBehandlung.Text = "";
            dtBekanntSeit.Value = null;
            this.cboWundeEntstanden.Value = null;

            if (_IDAufenthaltPDx == Guid.Empty)
                return;

            dsWunde1 = _wunde.ReadKopfPos(IDAufenthaltPDx);      // lesen (Ein leerer ds wird angelegt wenn noch nicht vorhanden

            dgWundverlauf.DataSource = dsWunde1;
            dgTherapie.DataSource = dsWunde1;
            RefreshThumbs();
            UpdateGUI();
            this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

            this.dgWundverlauf.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgWundverlauf.DisplayLayout.Bands[0].SortedColumns.Add("Erhebungszeitpunkt", true);

            this.dgTherapie.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgTherapie.DisplayLayout.Bands[0].SortedColumns.Add("DatumErstellt", true);

            this.dgWundverlauf.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgTherapie.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            this.lstVidiert.Clear();
            //cbWundart.Text  = "AA";
        }

        private void RefreshThumbs()
        {
            dgThumbnails.DataSource = _wunde.GetAllThumbs(dsWunde1.WundeKopf[0].ID);
        }

        private void UpdateGUI()
        {
            dsWunde.WundeKopfRow rk = dsWunde1.WundeKopf[0];
            ucWundSelector1.SetPoint(new Point(rk.ClickedValueX, rk.ClickedValueY));
            cbDekuskala.Text = rk.Dekuskala;
            tbDekuwert.Text = rk.Dekuwert.ToString();
            cbWundart.Text = rk.Wundart;
            txtBisherigeBehandlung.Text = rk.BisherigeBehandlung.ToString();

            if (rk.IsBekanntSeitNull()) {
                dtBekanntSeit.Value = null;
            }
            else {
                dtBekanntSeit.Value = rk.BekanntSeit.Date;
            }

            if (rk.WundeEntstanden.Trim() == "")
            {
                this.cboWundeEntstanden.Value = null;
            }
            else
            {
                this.cboWundeEntstanden.Value = rk.WundeEntstanden.Trim();
            }
        }

        public bool IsChanged
        {
            get { return false; }
        }

        public bool ValidateFields()
        {
            //return true;

            string MsgTxt2 = "";
            bool cbWundartOK = PMDSBusinessUI.checkCboBox(this.cbWundart, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundart"), true, ref MsgTxt2, true);

            if (!cbWundartOK)
            {
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["Ausmaß und Lokalisierung der Gewebeschädigung"];
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }
            else
            {
                this.cbWundart.Appearance.BackColor = Color.White;
                this.cbWundart.UseAppStyling = false;
            }
            return cbWundartOK;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einen neuen Wundverlauf hinzufügen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {

            PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                dsWunde.WundePosRow r = dsWunde1.WundePos.NewWundePosRow();
                r.ID = Guid.NewGuid();
                r.IDWundeKopf = dsWunde1.WundeKopf[0].ID;
                r.Erhebungszeitpunkt = DateTime.Now;
                r.DatumErstellt = r.Erhebungszeitpunkt; //os 190417: hinzugefügt
                r.IDBenutzer_Erstellt = ENV.USERID;     //os 190417: hinzugefügt
                r.NekroseJN = false;
                r.EpithelisierungProz = 0;
                r.FistelnTaschen = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WFT", 0).Bezeichnung;            
                r.GranulationProz = 0;
                r.B = 0;
                r.H = 0;
                r.Heilungstext = "";
                r.Infektionszeichen = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "INZ", 0).Bezeichnung;
                r.L = 0;
                r.Schmerzintensitaet = 0;
                r.Schmerzqualitaet = "";
                r.Sekretionsmenge = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WSM", 1).Bezeichnung;
                r.Wundbelag = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WBL", 1).Bezeichnung;
                r.WundeFreiliegendeStrukturen = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WFS", 0).Bezeichnung;
                r.Wundgeruch = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WGR", 1).Bezeichnung;
                r.WundrandGeroetet = false;
                r.WundrandHyperkeratose = false;
                r.WundrandIntakt = true;
                r.WundrandMazeriert = false;
                r.WundrandOedemoesWulstig = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WOM", 0).Bezeichnung;
                r.WundrandUnterminiertZerklueftet = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WUZ", 0).Bezeichnung;
                r.Wundsekretion = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WSK", 0).Bezeichnung;
                r.Wundumgebung = "";
                r.WundumgebungEkzemOedemRoetung = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WEO", 0).Bezeichnung;
                r.WundumgebungIntakt = true;
                r.WundumgebungSpannungsblase = false;
                r.WundumgebungTrockenPergamentartig = PMDSBusiness1.GetAuswahllisteByReihenfolge(db, "WTP", 0).Bezeichnung;
                r.Wundzustand = "";
                r.Wundheilungsphase = "";
                r.Wundgrund = "";
                dsWunde1.WundePos.AddWundePosRow(r);
            }
            SignalValueChanged();

            this.dgWundverlauf.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToLastItem;
            this.dgWundverlauf.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgWundverlauf.DisplayLayout.Bands[0].SortedColumns.Add("Erhebungszeitpunkt", true);
        }

        private void cbWundart_ValueChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }

        private void dgWundverlauf_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            SignalValueChanged();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eine neue Therapie hinzufügen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnAddTherapie_Click(object sender, EventArgs e)
        {
            DateTime dNow = DateTime.Now;
            dsWunde.WundeTherapieRow r = dsWunde1.WundeTherapie.NewWundeTherapieRow();
            r.ID = Guid.NewGuid();
            r.IDWundeKopf = dsWunde1.WundeKopf[0].ID;
            r.VerordnetAm = dNow;
            r.Therapie = "";
            r.AngeordnetVon = "";
            r.AbgesetztVon = "";

            r.Debridement = "";
            r.Reinigung = "";
            r.Wundauflage = "";
            r.Fixierung = "";
            r.Hyperkeratoseentfernung = "";
            r.Hautpflege = "";
            r.Zusatzernährung = "";
            r.Kompression = "";
            r.Freillagerung = "";
            r.Wundabstrich = "";
            r.Sekundaerverband = "";
            r.Wundrandschutz = "";
            r.VWIntervall = "";
            r.VidiertJN = false;
            r.VidiertVon = "";
            r.SetVidiertAmNull();
            r.VorgeschlagenVon = "";
            r.DatumErstellt = dNow;
            r.IDBenutzer_Erstellt = ENV.USERID;
                
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Benutzer rUser = this.b.getUser(ENV.USERID, db);
                if (rUser.IDArzt == null )
                    //r.VorgeschlagenVon = rUser.Vorname + ' ' +rUser.Nachname + " (" + ENV.LoginInNameFrei + ")";
                    r.VorgeschlagenVon = ENV.LoginInNameFrei;
                else
                    r.AngeordnetVon = ENV.LoginInNameFrei;
            }

            dsWunde1.WundeTherapie.AddWundeTherapieRow(r);
            SignalValueChanged();

            this.dgTherapie.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToLastItem;

            this.dgTherapie.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgTherapie.DisplayLayout.Bands[0].SortedColumns.Add("DatumErstellt", true);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bilder verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        private void dgWundverlauf_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.Cell.Column.Key != "Bilder")
                return;

            try
            {
                Guid IDWundePos = (Guid)e.Cell.Row.Cells["ID"].Value;

                DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                dsWunde.WundePosRow rSelRow = (dsWunde.WundePosRow)v.Row;
                this.loadFrmWundeBilder(IDWundePos);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public void loadFrmWundeBilder(Guid IDWundePos)
        {
            try
            {
                this._wunde.FillBilder(IDWundePos, dsWunde1);

                if (this.frmWundeBilder1 == null)
                {
                    this.frmWundeBilder1 = new frmWundeBilder();
                    this.frmWundeBilder1.initControl();
                }
                this.frmWundeBilder1.loadData2(IDWundePos, this._wunde, this.dsWunde1);
                this.frmWundeBilder1.ShowDialog();
                if (!this.frmWundeBilder1.abort)
                {
                    this.RefreshThumbs();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWunddoku.loadFrmWundeBilder: " + ex.ToString());
            }
        }

        private void dgWundverlauf_ClickCellButtonOld(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.Cell.Column.Key != "Bilder")
                return;

            try
            {
                Guid IDWundePos = (Guid)e.Cell.Row.Cells["ID"].Value;

                DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                dsWunde.WundePosRow rSelRow = (dsWunde.WundePosRow)v.Row;
                this.loadFrmWundeBilder(IDWundePos);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        void frm_ContentChanged(object sender, EventArgs e)
        {
            _Bilderchanged = true;
            SignalValueChanged();
        }



        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            this.setUIGrids();
        }

        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(panelBild, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(this.panelWundeEingabe, bOn);

            panelButtons2.Visible = !bOn && ENV.HasRight(UserRights.WundtherapieÄndern);    //os: 180627, neues eigenes Recht für Therapei
            panelButtons.Visible = !bOn && ENV.HasRight(UserRights.WundeÄndern);
            this.RigthWundverlaufÄndern = ENV.HasRight(UserRights.WundeÄndern);
            this.RigthWundtherapieÄndern = ENV.HasRight(UserRights.WundtherapieÄndern);

        }

        private void dgTherapie_BeforeRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {

        }

        private void dgTherapie_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
            {
                e.Cancel = true;
            }

        }

        private void dgWundverlauf_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) e.Cancel = true;
        }

        private void dgTherapie_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            SignalValueChanged();
        }

        private void dgWundVerlaufCardview_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) e.Cancel = true;

                //if (RigthWunddokuÄndern)
                //{
                DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                dsWunde.WundePosRow rWundPos = (dsWunde.WundePosRow)v.Row;
                if (rWundPos.RowState == DataRowState.Added)
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    if ((rWundPos.Erhebungszeitpunkt.AddHours(ENV.WundverlaufModifyTime) > DateTime.Now && RigthWundverlaufÄndern) || ENV.adminSecure)
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                }
                //}
                //else
                //{
                //    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                //}

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void dgWundVerlaufCardview_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            SignalValueChanged();


        }

        private void dgWundVerlaufCardview_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.Cell.Column.Key != "Bilder")
                return;

            try
            {
                Guid IDWundePos = (Guid)e.Cell.Row.Cells["ID"].Value;

                DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                dsWunde.WundePosRow rSelRow = (dsWunde.WundePosRow)v.Row;
                if (rSelRow.RowState == DataRowState.Added)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bilder können erst nach dem Speichern des Wundverlaufs hinzugefügt werden.", "PMDS", MessageBoxButtons.OK);
                }
                else
                {
                    this.loadFrmWundeBilder(IDWundePos);
                }
         

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void ultraGrid1_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    e.Cancel = true;
                }

                this.CellLastClicked = e.Cell;

                DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                dsWunde.WundeTherapieRow rWundeTherapie = (dsWunde.WundeTherapieRow)v.Row;
                if (rWundeTherapie.RowState == DataRowState.Added)
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if(ENV.HasRight(UserRights.WundtherapieÄndern))
                    {
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsWunde1.WundeTherapie.AbgesetztVonColumn.ColumnName.Trim().ToLower()) ||
                            e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsWunde1.WundeTherapie.AbgesetztAmColumn.ColumnName.Trim().ToLower()) ||
                            this.check24HoursAndRightEditWundeTherapie(rWundeTherapie.DatumErstellt, rWundeTherapie.IDBenutzer_Erstellt))
                        {
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        }
                    }
                }

                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsWunde1.WundeTherapie.VidiertJNColumn.ColumnName.Trim().ToLower()) ||
                    e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsWunde1.WundeTherapie.VidiertAmColumn.ColumnName.Trim().ToLower()) ||
                    e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsWunde1.WundeTherapie.VidiertVonColumn.ColumnName.Trim().ToLower()))
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }

        }

        public bool check24HoursAndRightEditWundeTherapie(DateTime DatumErstellt, Guid IDBenutzer_Erstellt)
        {
            try
            {
                if ((DatumErstellt.AddHours(ENV.WundtherapieModifyTime) > DateTime.Now && ENV.HasRight(UserRights.WundtherapieÄndern) && this.b.UserCanEdit(IDBenutzer_Erstellt, PflegeEintragTyp.Wundtherapie)) || ENV.adminSecure)
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
                throw new Exception("check24HoursEditWundeTherapie: " + ex.ToString());
            }
        }
        private void ultraGrid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            SignalValueChanged();

        }

        private void dtBekanntSeit_ValueChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }

        private void txtBisherigeBehandlung_ValueChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }

        private void dgThumbnails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIFct1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgThumbnails))
                {
                    dsWunde.WundePosBilderRow rSelWundPosBilder = this.getSelectedRow(false);
                    if (rSelWundPosBilder != null)
                    {
                        //this.ByteArrayToFile("F:\\test.jpg", rSelWundPosBilder.Thumbnail);
                        //qs2.core.vb.funct f = new qs2.core.vb.funct();
                        //f.openFile("F:\\test.jpg", "", true);

                        PMDS.Global.UI.frmPictureViewer frm = new PMDS.Global.UI.frmPictureViewer();
                        frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bild zur Wunddokumentation vom ") + rSelWundPosBilder.ZeitpunktBild.ToString("dd.MM.yyyy");
                        Image returnImage;
                        using (MemoryStream ms = new MemoryStream(rSelWundPosBilder.Bild))
                        {
                            returnImage = Image.FromStream(ms);
                            frm.pictureBox1.Image = returnImage;
                        }                                                    
                        frm.Show(this);
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }
        public dsWunde.WundePosBilderRow getSelectedRow(bool msgBox)
        {
            try
            {
                if (this.dgThumbnails.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.dgThumbnails.ActiveRow.ListObject;
                    dsWunde.WundePosBilderRow rSelWundPosBilder = (dsWunde.WundePosBilderRow)v.Row;
                    return rSelWundPosBilder;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Bild ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
        }

        private void dgTherapie_KeyUp(object sender, KeyEventArgs e)
        {
            StringComparison sc = StringComparison.CurrentCultureIgnoreCase;
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F3)
            {
                if (this.CellLastClicked != null &&
                        this.CellLastClicked.IsActiveCell &&
                        this.CellLastClicked.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                {
                    if (this.CellLastClicked.Column.Key.Equals("Therapie", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Debridement", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Reinigung", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Wundauflage", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Sekundaerverband", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Fixierung", sc) ||
                        this.CellLastClicked.Column.Key.Equals("VWIntervall", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Hyperkeratoseentfernung", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Hautpflege", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Zusatzernährung", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Kompression", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Freillagerung", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Wundabstrich", sc) ||
                        this.CellLastClicked.Column.Key.Equals("Wundrandschutz", sc))
                        clickLoadTextbausteine();
                }
            }
        }
        public void clickLoadTextbausteine()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmTextbausteinAuswahl frmTextbausteinAuswahl1 = new GUI.Main.frmTextbausteinAuswahl();
                frmTextbausteinAuswahl1.initControl();
                frmTextbausteinAuswahl1.ShowDialog(this);
                if (!frmTextbausteinAuswahl1.abort)
                {
                    CellLastClicked.Value = frmTextbausteinAuswahl1.TextbausteinAsPlainText;
                    SignalValueChanged();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucWunddoku.clickloadTextbausteine: " + ex.ToString());
            }
        }

        private void dgTherapie_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) return;
                
                if (e.Cell.Column.Key == this.colWundtherapieVidierenButton.Trim())
                {
                    if (!ENV.WundtherapieVidieren)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Vidierung ist nicht aktiviert!");
                        return;
                    }
                    if (!ENV.HasRight(UserRights.WundtherapieVidieren))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Recht für Vidierung!");
                        return;
                    }

                    DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                    dsWunde.WundeTherapieRow rRowWundeTherapieAct = (dsWunde.WundeTherapieRow)v.Row;

                    if (e.Cell.Activation == Activation.AllowEdit)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            bool doVidierung = this.b.doVidierung(ref rRowWundeTherapieAct, rRowWundeTherapieAct.ID, db);
                            if (!doVidierung)
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wundtherapie ist bereits vidiert!");
                                return;
                            }
                            else
                            {
                                e.Cell.Row.Cells["VidiertJN"].Value = rRowWundeTherapieAct.VidiertJN;
                                e.Cell.Row.Cells["VidiertAm"].Value = rRowWundeTherapieAct.VidiertAm;
                                e.Cell.Row.Cells["VidiertVon"].Value = rRowWundeTherapieAct.VidiertVon.Trim();

                                if (!this.lstVidiert.Keys.Contains(rRowWundeTherapieAct.ID))
                                {
                                    cVidiert newVidiert = new cVidiert();
                                    newVidiert.IDWundTherapie = rRowWundeTherapieAct.ID;
                                    string txtDekurs = QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidierung durchgeführt für Therapie {0} vom {1}");

                                    txtDekurs = string.Format(txtDekurs, rRowWundeTherapieAct.IsTherapieNull() ? "" : rRowWundeTherapieAct.Therapie.Trim(), rRowWundeTherapieAct.DatumErstellt.ToString("dd.MM.yyyy HH:mm:ss"));
                                    newVidiert.TxtDekurs = txtDekurs;
                                    this.lstVidiert.Add(newVidiert.IDWundTherapie.Value, newVidiert);
                                }
                                SignalValueChanged();
                            }
                        }
                    }
                    else
                    {
                        bool bVidierungNotEditable = true;
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        private void btnDelWundePos_Click(object sender, EventArgs e)
        {
            try
            {
                dsWunde.WundePosRow rSelWundePos = this.getSelectedRowWundePos(true);
                if (rSelWundePos != null)
                {
                    rSelWundePos.Delete();
                    SignalValueChanged();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void btnDelWundTherapie_Click(object sender, EventArgs e)
        {
            try
            {
                dsWunde.WundeTherapieRow rSelWundeTherapie = this.getSelectedRowWundTherapie(true);
                if (rSelWundeTherapie != null)
                {
                    rSelWundeTherapie.Delete();
                    SignalValueChanged();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public dsWunde.WundePosRow getSelectedRowWundePos(bool msgBox)
        {
            try
            {
                if (this.dgWundverlauf.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.dgWundverlauf.ActiveRow.ListObject;
                    dsWunde.WundePosRow rSelWundePos = (dsWunde.WundePosRow)v.Row;
                    return rSelWundePos;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
        }
        public dsWunde.WundeTherapieRow getSelectedRowWundTherapie(bool msgBox)
        {
            try
            {
                if (this.dgTherapie.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.dgTherapie.ActiveRow.ListObject;
                    dsWunde.WundeTherapieRow rSelWundeTherapie = (dsWunde.WundeTherapieRow)v.Row;
                    return rSelWundeTherapie;
                }
                else
                {
                    if (msgBox)
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
        }



    }

}
