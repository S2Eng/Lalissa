using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Shared;
using System.Diagnostics; 

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using System.IO;
using PMDS.Print;
using PMDS.GUI.BaseControls;
using System.Collections;
using PMDS.DB;
using System.Linq;
using Infragistics.Win.UltraWinToolTip;


namespace PMDS.GUI
{

    public partial class ucMed1VerschreibenDetail : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool _valueChangeEnabled = true;
        public event EventHandler ValueChanged;
        public event EventHandler MedikamentChanged;

        public enum eTypActionGrid
        {
            GetRowsBestellung = 0,
            ResetFlags =1
        }

        public ucMed1Verschreiben mainWindow = null;
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();

        public string colNameKlient = "NameKlient";










        public ucMed1VerschreibenDetail()
        {
            InitializeComponent();

            if (!DesignMode && ENV.AppRunning)
            {
                RequiredFields();
                InitGUI();
                dgEintraege.DisplayLayout.Bands[0].Columns["AbzugebenBis"].SortComparer = new datumComparer();
            }
        }

        private void InitGUI()
        {
            this.btnRefreshMedikamenteInGrid2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamente aktualisieren!");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnRefreshMedikamenteInGrid2, info);

            this.btnMedDaten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Medizinische_Daten, QS2.Resources.getRes.ePicTyp.ico);
            this.btnWunden.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Wunden_02, QS2.Resources.getRes.ePicTyp.ico);

            UltraToolTipInfo info2 = new UltraToolTipInfo();
            info2.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinische Daten");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnMedDaten, info2);

            info2 = new UltraToolTipInfo();
            info2.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnWunden, info2);

            RefreshMedikamentValueList(true);

            // Einheit-Combo initialisieren
            UltraGridTools.AddTextTextValuListFromAuswahlGruppe("MEH", dgEintraege, "Einheit");
            dgEintraege.DisplayLayout.Bands[0].Columns["Einheit"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            
            UltraGridTools.AddHerrichtenValueList(dgEintraege, "Herrichten"); 
            UltraGridTools.AddVerabreichungValueList(dgEintraege, "Verabreichungsart");

            // ZP0 bis ZP6 Wert 0 unterdrücken
            for (int i = 0; i < 7; i++)
                UltraGridTools.AddNoZeroValueList(dgEintraege, string.Format("ZP{0}", i));

            // Beschriftung anpassen
            UltraGridTools.SetSpenderZeitpunktHeaderText(dgEintraege.DisplayLayout.Bands[0].Columns);
            UltraGridTools.AddBenutzerValueList(dgEintraege, "IDBenutzer_Geaendert");
            UltraGridTools.AddBenutzerValueList(dgEintraege, "IDBenutzer_Erstellt");
            UltraGridTools.AddBenutzerValueList(dgEintraege, "ZuletztBestelltVon");

            this.dgEintraege.Name = "gridMedikamenteVerschreiben";
            string defaultLayoutName = "Medikamente verschreiben";
            QS2.Desktop.ControlManagment.BaseGrid baseGrid = (QS2.Desktop.ControlManagment.BaseGrid)this.dgEintraege;
            baseGrid.doBaseElements1.runControlManagmentBaseGridManual(baseGrid, defaultLayoutName);

        }

        private void RefreshAbzugebenBisValueList()
        {
            ValueListsCollection vlc = dgEintraege.DisplayLayout.ValueLists;

            ValueList vl = null;
            string sGrp = "DATUM";
            if (vlc.Exists(sGrp))
            {
                vl = vlc[sGrp];
            }
            else                                                    
            {
                vl = vlc.Add(sGrp);
                vl.ValueListItems.Add(new DateTime(3000, 1, 1, 23, 59, 59), " ");
                vl.ValueListItems.Add(new DateTime(3000, 1, 1, 0, 0, 0), " ");

                UltraGridColumn c = dgEintraege.DisplayLayout.Bands[0].Columns["AbzugebenBis"];
                c.ValueList = vl;
            }

            foreach (UltraGridRow r in dgEintraege.Rows)
            {
                if (!r.IsGroupByRow)
                {
                    DateTime dtbis = (DateTime)r.Cells["AbzugebenBis"].Value;
                    if (dtbis.Year >= 3000)
                        continue;
                    //os191220
                    //if (!vl.ValueListItems.Contains(dtbis))
                    //    vl.ValueListItems.Add(dtbis, dtbis.ToShortDateString());
                }

            }

        }

        private void RefreshAerzteValueList(string colName, string NameValueList)
        {
            ValueListsCollection vlc = dgEintraege.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists(NameValueList))
            {
                vl = vlc[NameValueList];
            }
            else                                                       
            {
                vl = vlc.Add(NameValueList);
                UltraGridColumn c = dgEintraege.DisplayLayout.Bands[0].Columns[colName];
                c.ValueList = vl;
            }

            foreach (UltraGridRow r in dgEintraege.Rows)
            {
                if (!r.IsGroupByRow)
                {
                    if (r.Cells[colName].Value !=  System .DBNull.Value)
                    {
                        Guid IDArzt = (Guid)r.Cells[colName].Value;
                        if (!vl.ValueListItems.Contains(IDArzt))
                            vl.ValueListItems.Add(IDArzt, Aerzte.GetArztName(IDArzt));
                    }
                }
            }

        }

        private void RefreshMedikamentValueList(bool removeValueList)
        {
            ValueListsCollection vlc = dgEintraege.DisplayLayout.ValueLists;

            if (removeValueList)
            {
                if (vlc.Exists("MED"))
                    vlc.Remove("MED");
            }
        
            PMDS.DB.DBMedikament medik = new PMDS.DB.DBMedikament();
            medik.LoadAllMedikamente(false);
            UltraGridTools.AddValueList(dgEintraege, "IDMedikament", "MED", PMDS.DB.DBMedikament._dsMedikament.MedikamentSmall, "ID", "Bezeichnung");
        }

        private void InitRezeptEintraege(bool bSetFirstRow)
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                foreach (UltraGridRow r in dgEintraege.Rows)
                {
                    InitDosierung(r);
                    InitAnmerkung(r);
                    HideRezepteintraege(r);      

                    DataRowView v = (DataRowView)r.ListObject;
                    dsRezeptEintrag.RezeptEintragRow rRezeptEintrag = (dsRezeptEintrag.RezeptEintragRow)v.Row;

                    string sErstattungscode = "";
                    string sKassenzeichen = "";
                    this.b.getColMedikamenteForGrid(db, rRezeptEintrag.IDMedikament, ref sErstattungscode, ref sKassenzeichen);
                    r.Cells["Erstattungscode"].Value = sErstattungscode;
                    r.Cells["Kassenzeichen"].Value = sKassenzeichen;

                    r.Cells[PMDS.DynReportsForms.MedikamentenBlattDataSource.colHerrichtenSortierung.Trim()].Value = PMDS.DynReportsForms.MedikamentenBlattDataSource.orderByHerrichten(rRezeptEintrag.Herrichten);
                }

                if (bSetFirstRow)
                    SetFirstRow();
                db.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        private void InitDosierung(UltraGridRow r)
        {
            DataRowView v = (DataRowView)r.ListObject;
            if (v != null)
            {
                if (!r.IsGroupByRow)
                {
                    r.Cells["Dosierung"].Value = PMDS.BusinessLogic.Tools.ToStringFromRezepteintragRow((dsRezeptEintrag.RezeptEintragRow)v.Row);
                }
            }
        }

        private void InitAnmerkung(UltraGridRow r)
        {
            Image img = imageList1.Images[0];

            if (!r.IsGroupByRow)
            {
                if (r.Cells["Bemerkung"].Value.ToString().Trim() != "")
                {
                    r.Cells["Anmerkung"].Value = img;
                    r.Cells["Anmerkung"].ToolTipText = r.Cells["Bemerkung"].Value.ToString();
                }
                else
                {
                    r.Cells["Anmerkung"].Value = null;
                    r.Cells["Anmerkung"].ToolTipText = "";
                }
            }
        }

        private dsRezeptEintrag.RezeptEintragRow GetCurrentRezeptEintragRow()
        {
            dsRezeptEintrag.RezeptEintragRow r = (dsRezeptEintrag.RezeptEintragRow)UltraGridTools.CurrentSelectedRow(dgEintraege);
            if (r == null)
                return null;
            return r;

        }

        private dsRezeptEintrag.RezeptEintragDataTable CURRENT_DT
        {
            get
            {
                return (dsRezeptEintrag.RezeptEintragDataTable)dgEintraege.DataSource;
            }
        }
        private void UpdateCurrentRow(object sender)
        {
            dsRezeptEintrag.RezeptEintragRow r = (dsRezeptEintrag.RezeptEintragRow)UltraGridTools.CurrentSelectedRow(dgEintraege);
            if (r == null)
                return;

            frmRezeptEintrag frm = new frmRezeptEintrag(GetCurrentRezeptEintragRow(), BearbeitungsModus.edit);
            frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung einer Medikation!");

            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                bool copyRezeptEintragMedDatenGesplittet = false;
                if (frm.NewRezeptEintrag != null)                               // Sollte ein Rezepteintrag gesplittet (abgestzt) worden sein dann den neuen Eintrag verapeichern
                {
                    CURRENT_DT.Rows.Add(frm.NewRezeptEintrag.ItemArray);        // Kopieren
                    copyRezeptEintragMedDatenGesplittet = true;
                }

                InitRezeptEintraege(false);

                if (frm.NewRezeptEintrag != null)
                    SetActiveRow(frm.NewRezeptEintrag.ID);

                //r = (dsRezeptEintrag.RezeptEintragRow)UltraGridTools.CurrentSelectedRow(dgEintraege);

                OnValueChanged(sender, EventArgs.Empty);
                RefreshMedikamentValueList(true);
                RefreshAerzteValueList("IDAerzte", "AERZTE");
                RefreshAerzteValueList("IDArztAbgesetzt", "IDArztAbgesetzt");
                UpdateButtons();
                
                this.mainWindow.Save();

                string sAktion = "";
                if (frm.ucRezeptEintrag1._bIsStorno)
                {
                    sAktion = QS2.Desktop.ControlManagment.ControlManagment.getRes("STORNIERT") + " (" + r.Bemerkung.Trim() + ")";
                }
                else
                {
                    sAktion = QS2.Desktop.ControlManagment.ControlManagment.getRes("geändert");
                }

                sAktion += " ";
                sAktion += QS2.Desktop.ControlManagment.ControlManagment.getRes("ab") + " " + r.AbzugebenVon.ToString() + " ";    
                if (r.AbzugebenBis.Year != 3000)
                    sAktion += QS2.Desktop.ControlManagment.ControlManagment.getRes("bis") + " " + r.AbzugebenBis.ToString() + " ";
                sAktion +=  r.DosierungASString ;

                PflegeEintrag.NewRezeptAenderungEinfuegen(IDAufenthalt, DateTime.Now, r.IDMedikament, sAktion, frm.ucRezeptEintrag1.chkGegenzeichnen.Checked,
                                                            frm.ucRezeptEintrag1.cbImportant.ID, frm.ucRezeptEintrag1.chkHAGPflichtigJN.Checked);

                if (r.AbzugebenBis.Year != 3000)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        b2.checkRezeptEintragAbgesetzt(r.ID, db);
                    }
                }

                if (copyRezeptEintragMedDatenGesplittet) 
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        this.b.copyRezeptEintragMedDaten(r.ID, frm.NewRezeptEintrag.ID, db);
                    }
                }

                //this.InfoAbgesetzt(r);
            }
        }

        public void InfoAbgesetztxy(dsRezeptEintrag.RezeptEintragRow r)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (r.AbzugebenBis.Year != 3000)
                    {
                        var tRezeptEintrag = (from r2 in db.RezeptEintrag
                                    join rb in db.RezeptBestellungPos on r2.ID equals rb.IDRezeptEintrag
                                    join m in db.Medikament on r2.IDMedikament equals m.ID
                                    where r2.ID == r.ID
                                    select new
                                    {
                                        ID = r2.ID,
                                        r2.AbzugebenBis,
                                        Bezeichnung = m.Bezeichnung
                                    });

                        if (tRezeptEintrag.Count() > 0)
                        {
                            var rRezeptEintrag = tRezeptEintrag.First();

                            string protTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament absetzen");
                            string protTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament {0} wurde abgesetzt und scheint daher ab {1} nicht mehr in der Medikamentenbestellung auf!");
                            protTxt = string.Format(protTxt, rRezeptEintrag.Bezeichnung.Trim().Trim(), rRezeptEintrag.AbzugebenBis.ToString("dd.MM.yyyy"));
                            this.b.saveProtocol(db, protTitle, protTxt);

                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(protTxt, QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS Info"), MessageBoxButtons.OK, true);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("InfoAbgesetzt: " + ex.ToString());
            }
        }

        private void SetActiveRow(Guid id)
        {
            foreach (UltraGridRow r in dgEintraege.Rows)
            {
                if (!r.IsGroupByRow)
                {
                    r.Selected = false;
                    if (r.Cells["ID"].Value.ToString() == id.ToString())
                    {
                        r.Selected = true;
                        dgEintraege.ActiveRow = r;
                    }
                }
            }
        }
        protected void OnValueChanged(object sender, EventArgs args)
        {
            SignalChange(sender, args);
            UpdateButtons();
        }

        private void SignalChange(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

        private void dgEintraege_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                
                if ((e.Cell.Column.Key.ToLower() == "bestellenjn" || e.Cell.Column.Key.ToLower() == "dringend") && !ENV.HasRight(UserRights.RezepteBestellen))
                {
                    e.Cell.Value = false;
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben für diese Aktion nicht die erforderlichen Rechte!", "Hinweis", MessageBoxButtons.OK);
                    return;
                }

                if (PMDS.Global.historie.HistorieOn) return;
                OnValueChanged(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private dsRezeptEintrag.RezeptEintragDataTable REZEPTEINTRAEGE
        {
            get
            {
                return (dsRezeptEintrag.RezeptEintragDataTable)dgEintraege.DataSource;
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                dsRezeptEintrag.RezeptEintragRow row = REZEPTEINTRAEGE.NewRezeptEintragRow();
                Rezept.InitRezeptEintrag(row, _aufenthalt);

                frmRezeptEintrag frm = new frmRezeptEintrag(row, BearbeitungsModus.neu);
                DialogResult res = frm.ShowDialog();

                if (res == DialogResult.OK)
                {
                    if (row.Packungsanzahl == 0)
                        row.Packungsanzahl = 1;
                    REZEPTEINTRAEGE.Rows.Add(row);
                    SetActiveRow(row.ID);
                    InitDosierung(dgEintraege.ActiveRow);
                    InitAnmerkung(dgEintraege.ActiveRow);
                    OnValueChanged(sender, EventArgs.Empty);
                    RefreshMedikamentValueList(true);
                    RefreshAerzteValueList("IDAerzte", "AERZTE");
                    RefreshAerzteValueList("IDArztAbgesetzt", "IDArztAbgesetzt");
                    UpdateButtons();
                    
                    this.mainWindow.Save();

                    string sAktion = QS2.Desktop.ControlManagment.ControlManagment.getRes("angeordnet") + " ";
                    sAktion = QS2.Desktop.ControlManagment.ControlManagment.getRes("ab") + " " + row.AbzugebenVon.ToString() + " ";
                    if (row.AbzugebenBis.Date.Year != 3000)
                        sAktion += QS2.Desktop.ControlManagment.ControlManagment.getRes("bis") + " " + row.AbzugebenBis.ToString() + " ";
                    sAktion += row.DosierungASString;

                    PflegeEintrag.NewRezeptAenderungEinfuegen(IDAufenthalt, DateTime.Now, row.IDMedikament, sAktion, false, System.Guid.Empty,
                                                                frm.ucRezeptEintrag1.RezeptEintrag.HAGPflichtigJN);
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

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            try
            {

                dsRezeptEintrag.RezeptEintragRow r = (dsRezeptEintrag.RezeptEintragRow)(UltraGridTools.CurrentSelectedRow(dgEintraege));
                if (!this.b2.checkDeleteRezepteinträgeMedDatenExists(r.ID))
                {
                    return;
                }

                //Löschen nur möglich wenn
                //  AdminSecure oder Recht RezepteintragLöschen
                //  Eintrag nicht älter als eine Stunde
                //  Nicht auf Blisterliste
                //  Nicht auf Bestelliste
                //  Keine Medikamentenabgaben

                bool bRecht = false;
                TimeSpan tsZeitraum = new TimeSpan(0);
                Nullable<DateTime> dtBlisterliste = null;
                Nullable<DateTime> dtBestellung = null;
                int iMedAbgabe = 0;

                bRecht = ENV.adminSecure || PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.RezepteintragLöschen);
                tsZeitraum = DateTime.Now - r.DatumErstellt;
                if (!r.IsZeitpunktBlisterlisteNull())
                    dtBlisterliste = r.ZeitpunktBlisterliste;
                if (!r.IsZuletztBestelltAmNull())
                    dtBestellung = r.ZuletztBestelltAm;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    iMedAbgabe = db.MedikationAbgabe.Where(ma => ma.IDRezeptEintrag == r.ID).Count();
                }

                if (bRecht && (tsZeitraum.Days <= 0 && tsZeitraum.Hours == 0) && dtBlisterliste == null && dtBestellung == null && iMedAbgabe == 0) 
                {
                    this.Cursor = Cursors.WaitCursor;

                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                        return;

                    PflegeEintrag.NewRezeptAenderungEinfuegen(IDAufenthalt, DateTime.Now, r.IDMedikament, QS2.Desktop.ControlManagment.ControlManagment.getRes("gelöscht"), false, System.Guid.Empty,
                                                                r.HAGPflichtigJN);

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        this.b.DeleteRezeptEintragMedDatenzuordnungen(r.ID, db);
                    }

                    r.Delete();

                    OnValueChanged(sender, EventArgs.Empty);
                    UpdateButtons();
                    this.mainWindow.Save();
                }

                else
                {


                    string sMsg = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dieser Rezepteintrag darf nicht gelöscht werden.") + "\n\r";
                    string sMsgRecht = "";
                    string sMsgZeitpunkt = "";
                    string sMsgBlisterliste = "";
                    string sMsgBestellung = "";
                    string sMsgAbgabe = "";

                    if (!bRecht)
                    {
                        sMsgRecht = "\n\r" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben kein Recht für das Löschen des Rezepteintags.");
                    }

                    if (tsZeitraum.Days > 0 || tsZeitraum.Hours > 0)
                    {      
                        sMsgZeitpunkt = "\n\r" + string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Eintrag wurde vor mehr als eine Stunde angelegt: {0}."), r.DatumErstellt.ToShortDateString() + " " + r.DatumErstellt.ToShortTimeString() );
                    }

                    if (dtBlisterliste != null)
                    {
                        sMsgBlisterliste += "\n\r" + string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Eintrag wurde bereits auf einer Blisterliste angedruckt: Zuletzt am {0}."), r.ZeitpunktBlisterliste.ToShortDateString() + " " + r.ZeitpunktBlisterliste.ToShortTimeString());
                    }

                    if (dtBestellung != null)
                    {
                        sMsgBestellung += "\n\r" + string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Medikament wurde bereits bestellt. Zuletzt am {0}."), r.ZuletztBestelltAm.ToShortDateString() + " " + r.ZuletztBestelltAm.ToShortTimeString());
                    }

                    if (iMedAbgabe > 0)
                    {
                        sMsgAbgabe += "\n\r" + string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Medikament wurde schon {0} mal als Einzelabgabe gemeldet."), iMedAbgabe.ToString()) ;
                    }

                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsg + sMsgRecht + sMsgZeitpunkt + sMsgBlisterliste + sMsgBestellung + sMsgAbgabe);


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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UpdateCurrentRow(sender);
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

        private void UpdateButtons()
        {
            UpdateButtons(false);
        }

        private void UpdateButtons(bool bSetGridIndex)
        {

            if (bSetGridIndex)
                SetFirstRow();

            btnDel.Enabled = (dgEintraege.Rows.VisibleRowCount > 0);
            btnUpdate.Enabled = (dgEintraege.Rows.VisibleRowCount > 0);

        }

        protected void RequiredFields()
        {

        }

        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // Grid nur validieren, wenn Kopf passt
            if (!bError)
                ValidateGrid(ref bError, bInfo);

            return !bError;
        }
        public static string msgBoxText = "";

        private bool ValidateGrid(ref bool bError, bool bInfo)
        {
            try
            {
                ucMed1VerschreibenDetail.msgBoxText = "";
                dgEintraege.PerformAction(UltraGridAction.ExitEditMode);
                dgEintraege.BeginUpdate();

                foreach (UltraGridRow r in dgEintraege.Rows)
                {
                    if (!r.IsGroupByRow)
                    {
                        UltraGridCell cVon = r.Cells["AbzugebenVon"];
                        UltraGridCell cBis = r.Cells["AbzugebenBis"];
                        UltraGridCell cMed = r.Cells["IDMedikament"];
                        UltraGridCell c;

                        GuiUtil.ValidateField(dgEintraege, r, cBis,
                            (((DateTime)cBis.Value).Date >= ((DateTime)cVon.Value).Date),
                            ENV.String("GUI.E_REZEPTE_ABG_BIS"), ref bError, bInfo, true);

                        GuiUtil.ValidateField(dgEintraege, r, cMed,
                            ((cMed.Value != DBNull.Value) && ((Guid)cMed.Value != Guid.Empty)),
                            ENV.String("GUI.E_REZEPTE_MED"), ref bError, bInfo);

                        // mindestens 1 ZP0 ... ZP6 muss einen Wert haben
                        bool bZOK = false;
                        for (int i = 0; i < 7; i++)
                        {
                            c = r.Cells[string.Format("ZP{0}", i)];
                            if ((double)c.Value > 0 || ((medHerrichten)r.Cells["Herrichten"].Value != medHerrichten.beiBedarf))
                            {
                                bZOK = true;
                                break;
                            }
                        }

                        // für ZP0 ... ZP6 eventuell Fehler setzten - sofern es keine Bedarfsmed ist 
                        for (int i = 0; i < 7; i++)
                        {
                            c = r.Cells[string.Format("ZP{0}", i)];
                            if ((medHerrichten)r.Cells["Herrichten"].Value != medHerrichten.beiBedarf)
                                GuiUtil.ValidateField(dgEintraege, r, c, bZOK,
                                    ENV.String("GUI.E_REZEPTE_ZP"), ref bError, bInfo);
                        }
                    }
                }

            }
            finally
            {
                dgEintraege.EndUpdate();
            }

            if (ucMed1VerschreibenDetail.msgBoxText.Trim() != "")
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ucMed1VerschreibenDetail.msgBoxText, true);
            return !bError;
        }

        private void dgEintraege_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (!e.Cell.Row.IsGroupByRow)
                {
                    if (PMDS.Global.historie.HistorieOn) return;
                    if ((e.Cell.Column.Key == "IDMedikament") && (PMDS.DB.DBMedikament._dsMedikament != null))
                    {
                        frmMedikamentenVerwaltung frm = new frmMedikamentenVerwaltung();
                        DialogResult res = frm.ShowDialog();
                        PMDS.Global.db.Patient.dsMedikament.MedikamentRow row = frm.GetMedikamentRow();
                        if (res == DialogResult.OK && row != null)
                        {
                            e.Cell.Value = row.ID;
                            e.Cell.Row.Cells["Einheit"].Value = row.Einheit.Trim();
                            OnValueChanged(sender, EventArgs.Empty);
                            RefreshMedikamentValueList(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void dgEintraege_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) return;
                UltraGridCell c = dgEintraege.ActiveCell;

                if ((c.Column.Key.Length == 3) &&
                    (c.Column.Key.Substring(0, 2) == "ZP"))
                {
                    UltraGridTools.ValidateDouble(c);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void dgEintraege_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            try
            {
                e.RaiseErrorEvent = false;
                e.StayInEditMode = false;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private Guid _aufenthalt = Guid.Empty;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthalt
        {
            get { return _aufenthalt; }
            set
            {
                _aufenthalt = value;
                LoadRezeptEintraege();

                bool LayoutFound = false;
                qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                compLayout1.initControl();
                compLayout1.doLayoutGrid(this.dgEintraege, this.dgEintraege.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgEintraege);
            }
        }

        public void Write()
        {
            Rezept rez = new Rezept();
            foreach (dsRezeptEintrag.RezeptEintragRow r in REZEPTEINTRAEGE.Rows)
                if (r.RowState == DataRowState.Added)
                    r.DosierungASString = PMDS.BusinessLogic.Tools.ToStringFromRezepteintragRow(r);

            rez.Update(REZEPTEINTRAEGE);
        }

        private void LoadRezeptEintraege()
        {
            Rezept rez = new Rezept();
            dgEintraege.DataSource = rez.Read(_aufenthalt);         
            InitRezeptEintraege(true);
            UpdateButtons();
            RefreshAbzugebenBisValueList();
        
            RefreshAerzteValueList("IDAerzte", "AERZTE");
            RefreshAerzteValueList("IDArztAbgesetzt", "IDArztAbgesetzt");
            
            this.setBezeichnungStandardzeiten();

            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;

                foreach (UltraGridRow rowRezepteintrag in this.dgEintraege.Rows)
                {
                    if (rowRezepteintrag.IsGroupByRow)
                    {
                        this.showGrid_rek(rowRezepteintrag, db);
                    }
                    else
                    {
                        this.showGridRow(rowRezepteintrag, db);
                    }
                }
            }
        }

        public void showGrid_rek(UltraGridRow rowRezepteintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rowRezepteintrag.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.showGrid_rek(rFoundInGrid, db);
                        }
                        else
                        {
                            this.showGridRow(rFoundInGrid, db);

                            if (rFoundInGrid.ChildBands != null && rFoundInGrid.ChildBands.Count > 0)
                            {
                                foreach (UltraGridChildBand bnd in rFoundInGrid.ChildBands)
                                {
                                    foreach (UltraGridRow rGridRowChild in bnd.Rows)
                                    {
                                        if (rFoundInGrid.IsGroupByRow)
                                        {
                                            this.showGrid_rek(rFoundInGrid, db);
                                        }
                                        else
                                        {
                                            this.showGridRow(rGridRowChild, db);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMed1VerschreibenDetail.showGrid_rek: " + ex.ToString());
            }
        }
        public void showGridRow(UltraGridRow rowRezeptEintrag, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                DataRowView v = (DataRowView)rowRezeptEintrag.ListObject;
                dsRezeptEintrag.RezeptEintragRow rRezeptEintrag = (dsRezeptEintrag.RezeptEintragRow)v.Row;

                var rPatient = (from p in db.Patient
                           join a in db.Aufenthalt on p.ID equals a.IDPatient
                           where a.ID == rRezeptEintrag.IDAufenthalt
                                select new
                            {
                                IDPatient = p.ID,
                                IDAufenthalt = a.ID,
                                Nachname = p.Nachname,
                                Vorname = p.Vorname
                            }).First();

                rowRezeptEintrag.Cells[this.colNameKlient.Trim()].Value = rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim();

            }
            catch (Exception ex)
            {
                throw new Exception("ucMed1VerschreibenDetail.showGridRow: " + ex.ToString());
            }
        }

        private void setBezeichnungStandardzeiten()
        {
            this.dgEintraege.DisplayLayout.Bands[0].Columns["ZP0"].Header.Caption = "nüchtern";
            this.dgEintraege.DisplayLayout.Bands[0].Columns["ZP1"].Header.Caption = "morgens";
            this.dgEintraege.DisplayLayout.Bands[0].Columns["ZP2"].Header.Caption = "mittags";
            this.dgEintraege.DisplayLayout.Bands[0].Columns["ZP3"].Header.Caption = "abends";
            this.dgEintraege.DisplayLayout.Bands[0].Columns["ZP4"].Header.Caption = "nachts";
            this.dgEintraege.DisplayLayout.Bands[0].Columns["ZP5"].Hidden = true;
        }

        private void dtpZeitpunkt_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }

        private void dgEintraege_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {

                if (PMDS.Global.historie.HistorieOn) return;
                if (btnUpdate.Enabled && ENV.HasRight(UserRights.RezepteVerwalten))
                    UpdateCurrentRow(sender);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void dgEintraege_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) return;
                if (e.KeyCode == Keys.Delete && btnUpdate.Enabled)
                {
                    e.Handled = true;
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {

                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void enableRezeptEintragchange(bool enable)
        {
            UpdateButtons();
        }

        public void dgEintraegeDelRows()
        {
            dgEintraege.UpdateMode = UpdateMode.OnCellChangeOrLostFocus;
            foreach (UltraGridRow r in dgEintraege.Rows)
            {
                if (!r.IsGroupByRow)
                {
                    r.Delete(false);
                }
            }
        }
        private void HideShowRezepteintraege()
        {
            foreach (UltraGridRow r in dgEintraege.Rows)
            {
                if (!r.IsGroupByRow)
                {
                    r.Selected = false;
                    HideRezepteintraege(r); 
                }
            }
            UpdateButtons();
            SetFirstRow();
        }

        private void SetFirstRow()
        {
            dgEintraege.ActiveRow = dgEintraege.Rows.GetRowAtVisibleIndex(0);
        }

        private void cbBeendetezeigenJN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                HideShowRezepteintraege();
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

        private void HideRezepteintraege(UltraGridRow r)
        {
            if (!r.IsGroupByRow)
            {
                r.Hidden = (HidebeendeteRezeptEintraege(r)); 
            }
        }


        private bool HidebeendeteRezeptEintraege(UltraGridRow r)
        {
            bool hide = false;
            if (!cbBeendetezeigenJN.Checked)
            {
                if (!r.IsGroupByRow)
                {
                    //if ((DateTime)r.Cells["AbzugebenBis"].Value < DateTime.Now.Date.AddDays(1))
                    if ((DateTime)r.Cells["AbzugebenBis"].Value < DateTime.Now || (DateTime)r.Cells["AbzugebenBis"].Value  < (DateTime)r.Cells["AbzugebenVon"].Value)
                        hide = true;
                }

            }
            else
                hide = false;
            return hide;
        }

        public void PrintMedikamentenBlatt()
        {
            dsRezeptEintrag.RezeptEintragDataTable dt = new dsRezeptEintrag.RezeptEintragDataTable();

            foreach (UltraGridRow ugrow in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgEintraege, false))
            {
                if (!ugrow.Hidden)
                {
                    if (!ugrow.IsGroupByRow)
                    {
                        dt.ImportRow((dsRezeptEintrag.RezeptEintragRow)((DataRowView)ugrow.ListObject).Row);  
                    }
                }
            }
        
            PMDS.Print.frmPrintPreview.PreviewMedikamentenBlatt(dt, IDAufenthalt);
        }

        private void dgEintraege_AfterGroupPosChanged(object sender, AfterGroupPosChangedEventArgs e)
        {
            cbBeendetezeigenJN.Enabled = (dgEintraege.Rows.VisibleRowCount == 0);

        }

        private void dgEintraege_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) return;
                UpdateButtons(false);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void dgEintraege_Click(object sender, EventArgs e)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) return;
                if (dgEintraege.ActiveCell == null)
                    return;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            this.panelButtons.Visible = !bOn && ENV.HasRight(UserRights.RezepteVerwalten);    
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.GUI.VB.gridExport exp = new PMDS.GUI.VB.gridExport();
                exp.printPreviewGrid(this.dgEintraege);
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

        public void doActionGrid(ref List<PMDS.DB.PMDSBusiness.cField> lstData, eTypActionGrid TypActionGrid)
        {
            try
            {
                foreach (UltraGridRow rFoundInGrid in this.dgEintraege.Rows)
                {
                    if (rFoundInGrid.IsGroupByRow)
                    {
                        this.doActionGrid_rek(ref lstData, rFoundInGrid, TypActionGrid);
                    }
                    else
                    {
                        this.doActionGridGetRow(ref lstData, TypActionGrid, rFoundInGrid);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucRezept2.doActionGrid: " + ex.ToString());
            }
        }
        public void doActionGrid_rek(ref List<PMDS.DB.PMDSBusiness.cField> lstData, UltraGridRow rFoundInGridParent,
                                            eTypActionGrid TypActionGrid)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow)
                        {
                            this.doActionGrid_rek(ref lstData, rFoundInGrid, TypActionGrid);
                        }
                        else
                        {
                            this.doActionGridGetRow(ref lstData, TypActionGrid, rFoundInGrid);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezept2.doActionGrid_rek: " + ex.ToString());
            }
        }
        public void doActionGridGetRow(ref List<PMDS.DB.PMDSBusiness.cField> lstData, eTypActionGrid TypActionGrid,
                                        UltraGridRow rFoundInGrid)
        {
            try
            {
                if (TypActionGrid == eTypActionGrid.GetRowsBestellung)
                {
                    if (((bool)rFoundInGrid.Cells["bestellenjn"].Value) == true ||
                        ((bool)rFoundInGrid.Cells["dringend"].Value) == true)
                    {
                        DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                        dsRezeptEintrag.RezeptEintragRow rSelected = (dsRezeptEintrag.RezeptEintragRow)v.Row;

                        PMDS.DB.PMDSBusiness.cField NewField = new DB.PMDSBusiness.cField();
                        NewField.ID = rSelected.ID;
                        NewField.BestellenJN = (bool)rFoundInGrid.Cells["bestellenjn"].Value;
                        NewField.Dringend = (bool)rFoundInGrid.Cells["dringend"].Value;
                        NewField.rGrid = rFoundInGrid;
                        NewField.Packungsanzahl = (int)rFoundInGrid.Cells["Packungsanzahl"].Value;   
                        lstData.Add(NewField);

                        //dsRezeptEintrag.RezeptEintragRow NewRow = (dsRezeptEintrag.RezeptEintragRow)tRezeptEinträgeFound.NewRow();
                        //NewRow.ItemArray = rSelected.ItemArray;
                        //NewRow["Dringend"] = rFoundInGrid.Cells["dringend"].Value;
                        //tRezeptEinträgeFound.Rows.Add(NewRow);
                    }

                }
                else if (TypActionGrid == eTypActionGrid.ResetFlags)
                {
                    rFoundInGrid.Cells["bestellenjn"].Value = false;
                    rFoundInGrid.Cells["dringend"].Value = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucRezept2.doActionGridGetRow: " + ex.ToString());
            }
        }

        public class datumComparer : IComparer
        {
            public datumComparer()
            {
            }

            public int Compare(object x, object y)
            {
                UltraGridCell xCell = (UltraGridCell)x;
                UltraGridCell yCell = (UltraGridCell)y;

                return DateTime.Compare((DateTime)xCell.Row.Cells["Abzugebenbis"].Value, (DateTime)yCell.Row.Cells["AbzugebenBis"].Value);
            }
        }

        private void dgEintraege_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Row.IsGroupByRow || e.Cell.IsFilterRowCell)
                    return;

                if (e.Cell.Column.ToString().Trim().Equals("dringend", StringComparison.CurrentCultureIgnoreCase) ||
                    e.Cell.Column.ToString().Trim().Equals("bestellenjn", StringComparison.CurrentCultureIgnoreCase))
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
                ENV.HandleException(ex);
            }
        }

        public dsRezeptEintrag.RezeptEintragRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.dgEintraege.ActiveRow != null)
                {
                    if (this.dgEintraege.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.dgEintraege.ActiveRow.ListObject;
                        dsRezeptEintrag.RezeptEintragRow rSelRow = (dsRezeptEintrag.RezeptEintragRow)v.Row;
                        gridRow = this.dgEintraege.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMed1VerschreibenDetail.getSelectedRow: " + ex.ToString());
            }
        }


        private void btnRefreshMedikamenteInGrid2_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshMedikamentValueList(true);
                this.mainWindow.RefreshControl();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnMedDaten_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.btnMedDaten_Click();

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
        private void btnWunden_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.btnWunden_Click();

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

        private void ucRezept2_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}