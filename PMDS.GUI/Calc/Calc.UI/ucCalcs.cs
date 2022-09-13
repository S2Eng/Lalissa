using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.UI.Sitemap;
using PMDS.GUI.Calc.Calc.UI;
using System.Linq;
using PMDS.Global;
using Infragistics.Win;
//using System.Windows.Input;

namespace PMDS.Calc.UI
{
    public partial class ucCalcs : QS2.Desktop.ControlManagment.BaseControl
    {
        public PMDS.Calc.UI.ucCalcsSitemap uiSiteMapForm;
        public PMDS.Calc.UI.ucSR ucSR;
        private bool editorVis = false;
        private PMDS.Calc.Logic.CalcUIMode ActUIMode = Logic.CalcUIMode.Undefiniert;

        public bool freigegebenOn = false;
        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();
        //public QS2.Ressources.Handle.doRessources doRessources = new QS2.Ressources.Handle.doRessources();


        public ucCalcs()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }



        public void initControl()
        {
            PMDS.Calc.Logic.calculation.delCallFctCalcs += new Calc.Logic.calculation.CallFctCalcs(this.CallFctMainSystem);

            this.butAbrechnen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Abrechnung.ico_Abrechnung, 32, 32);
            this.btnExportAsExcel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Excel, 32, 32);
            this.btnExportAsPdf.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_PDF, 32, 32);
            this.btnRollungSperreLöschen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_historie, 32, 32);

            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Als Excel exportieren");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnExportAsExcel, info);

            info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Als Pdf exportieren");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnExportAsPdf, info);

            info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sperre Storno und Rollung aufheben");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnRollungSperreLöschen, info);


            this.uGridAbrech2.ContextMenuStrip = null;

            this.dtVon.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtBis.Value = this.uiSiteMapForm.calcBase.monatsende(DateTime.Now);
            this.dtVonRechDatum.Value = null;
            this.dtBisRechDatum.Value = null;
            this.dtAbrechMonat.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtRechDatum.DateTime = DateTime.Now;

            this.uOptSetAbrechTyp.Items.Add((int)PMDS.Calc.Logic.eCalcRun.month, QS2.Desktop.ControlManagment.ControlManagment.getRes("Monat"));
            this.uOptSetAbrechTyp.Items.Add((int)PMDS.Calc.Logic.eCalcRun.freeBill, QS2.Desktop.ControlManagment.ControlManagment.getRes("Frei erstellte"));
            this.uOptSetAbrechTyp.ItemSpacingVertical = 3;
            this.uOptSetAbrechTyp.ItemSpacingHorizontal = 3;
            this.uOptSetAbrechTyp.Value = (int)PMDS.Calc.Logic.eCalcRun.month;

            this.cboBillStatus.Value = "a";
            if (this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.buchhaltung)
                this.setUI("F");
            else
                this.setUI("O");

            if (this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.depotgeld)
            {
                //this.dtVon.MaskInput = "{LOC}dd.mm.yyyy";
                //this.dtBis.MaskInput = "{LOC}dd.mm.yyyy";
            }

            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();

            this.uiSiteMapForm.sitemap.fillEnumBillTyp(this.uGridAbrech2.DisplayLayout.ValueLists["eBillTyp"], true);
            this.uiSiteMapForm.sitemap.fillEnumBillTyp(cboRechTyp, true, this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.buchhaltung ? true : false);
            this.cboRechTyp.Value = (int)PMDS.Calc.Logic.eBillTyp.Alle;

            this.uiSiteMapForm.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.butAlleKeine, false, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech2, "", false);
            this.InitTimeContextMenu();

            if (this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.depotgeld)
            {
                this.uGridAbrech2.DisplayLayout.Bands[0].Columns["datum"].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abgerechnet bis"); ;
                this.uGridAbrech2.DisplayLayout.Bands[0].Columns["srJN"].Hidden = true;
            }
            else
            {
                this.uGridAbrech2.DisplayLayout.Bands[0].Columns["datum"].Format = "yyyy-MM";
            }
            if (this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.sr)
            {
                this.uGridAbrech2.DisplayLayout.Bands[0].Columns["KlientName"].Hidden = true;
                this.uGridAbrech2.DisplayLayout.Bands[0].Columns["srJN"].Hidden = true;
            }
            if (this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.buchhaltung || this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.depotgeld ||
                       this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.sr)
            {
                this.panelTopSr.Height = this.grpSuche.Top * 2 + this.grpSuche.Height + panelHistorie2.Height;
                Application.DoEvents();
            }
            this.setColBack(false);
        }
        private void InitTimeContextMenu()
        {
            this.uiSiteMapForm.sitemap.initTimeContextMenu();
            foreach (MenuItem item in this.uiSiteMapForm.sitemap.timemenu.MenuItems)
            {
                item.Click += new EventHandler(Timeitem_Click);
            }
        }

        public bool CallFctMainSystem(PMDS.Calc.Logic.calculation.eTypeCalcsFct TypeCalcsFct, ref PMDS.Calc.Logic.calculation.retMainSystem retMainSystem1)
        {
            try
            {
                this.loadCalcs();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("cuCalcs.CallFctMainSystem: " + ex.ToString());
            }
        }

        public void doSum()
        {
            try
            {
                double BetragSum = 0;
                foreach (PMDS.Calc.Logic.dbPMDS.billsRow rBill in this.dbPMDS1.bills)
                {
                    if (rBill.Typ == (int)Logic.eBillTyp.Rechnung || rBill.Typ == (int)Logic.eBillTyp.Sammelrechnung)
                    {
                        BetragSum += (Double)rBill.betrag;
                    }
                }
                this.numSum.Value = BetragSum;

                if (this.uGridAbrech2.DisplayLayout.Bands[0].Columns.Exists("IDBillsGerollt"))
                {
                    this.uGridAbrech2.DisplayLayout.Bands[0].Columns["IDBillsGerollt"].Hidden = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucCalcs.doSum: " + ex.ToString());
            }
        }

        public void loadCalcs()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.panelGrid.Visible = false;
                this.dbPMDS1.Clear();
                this.numSum.Value = null;
                this.checkUIDate();
                PMDS.Calc.Logic.eBillTyp billTyp;
                if (this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.depotgeld)
                    billTyp = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.sr ? (PMDS.Calc.Logic.eBillTyp)this.cboRechTyp.Value : PMDS.Calc.Logic.eBillTyp.Sammelrechnung;
                else
                    billTyp = PMDS.Calc.Logic.eBillTyp.Depotgeld;


                PMDS.Calc.Logic.eBillStatus BillStatus = this.uiSiteMapForm.getStatus(this.cboBillStatus.Value);
                bool showFreigegebenAndStorniert = false;
                if (BillStatus != Logic.eBillStatus.offen)
                {
                    if (this.getCboBillStatusIsAll())
                    {
                        showFreigegebenAndStorniert = true;
                    }
                }
                PMDS.Calc.Logic.eBillStatus BillStatusFreigegeben = this.uiSiteMapForm.getStatus2(this.cboBillStatus.Value);

                Nullable<DateTime> vonRechDatum = null;
                if (this.dtVonRechDatum.Value != null)
                {
                    vonRechDatum = this.dtVonRechDatum.DateTime.Date;
                }
                Nullable<DateTime> bisRechDatum = null;
                if (this.dtBisRechDatum.Value != null)
                {
                    bisRechDatum = this.dtBisRechDatum.DateTime.Date;
                }

                DateTime dFrom = new DateTime(this.dtVon.DateTime.Year, this.dtVon.DateTime.Month, 1, 0, 0, 0);
                DateTime dTo = new DateTime(this.dtBis.DateTime.Year, this.dtBis.DateTime.Month, DateTime.DaysInMonth(this.dtBis.DateTime.Year, this.dtBis.DateTime.Month), 23, 59, 59);

                if (this.dtVon.DateTime == this.dtBis.MinDate)
                {

                }

                if (this.dtBis.DateTime == this.dtBis.MinDate)
                {
                    dTo = DateTime.Now;
                }

                this.uiSiteMapForm.loadCalcs(ref this.dbPMDS1, dFrom, dTo, vonRechDatum, bisRechDatum,
                                            (UltraGrid)this.uGridAbrech2, (Infragistics.Win.Misc.UltraButton)this.butAlleKeine, ref this.lblCount,
                                            billTyp, BillStatus, showFreigegebenAndStorniert, true, BillStatusFreigegeben, this.txtReNr.Text, this.ActUIMode);

                this.doSum();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.panelGrid.Visible = true;
                this.Cursor = Cursors.Default;
            }
        }
        public void doCalc()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime abrechVon = new DateTime(this.dtAbrechMonat.DateTime.Year, this.dtAbrechMonat.DateTime.Month, 1);
                if (!this.uiSiteMapForm.sitemap.checkUIDateAbrech(this.dtAbrechMonat, this.dtRechDatum)) return;

                if (!this.uiSiteMapForm.sitemap.validAuswahl(true, this.uiSiteMapForm.sitemap.listID)) return;

                PMDS.Global.frmProtokoll frmProtokoll = new PMDS.Global.frmProtokoll();
                frmProtokoll.initControl(abrechVon, this.uiSiteMapForm.calcBase.monatsende(abrechVon),
                            this.dtRechDatum.DateTime, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech2, (Infragistics.Win.Misc.UltraButton)this.butAlleKeine,
                            ref this.lblCount, (PMDS.Calc.Logic.eCalcRun)this.uOptSetAbrechTyp.Value,
                            this.editor, this.editorPrecalc, "M", ref this.uiSiteMapForm.sitemap.listID);
                frmProtokoll.ShowDialog(this);
                this.loadCalcs();
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
        public void doCalcSR(DateTime monat, DateTime rechDate, ref System.Collections.Generic.List<Logic.doSr.cPatients> lstSelPatients)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime abrechVon = new DateTime(monat.Year, monat.Month, 1);

                if (!this.uiSiteMapForm.validSR(true)) return;
                this.uiSiteMapForm.doSR(abrechVon, rechDate, ref lstSelPatients);
                this.ucSR.loadData();
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


        private bool validateUI(bool info)
        {
            if (!this.uiSiteMapForm.sitemap.validAuswahl(info, this.uiSiteMapForm.sitemap.listID)) return false;
            this.checkUIDate();
            return true;
        }
        public void checkUIDate()
        {
            if (this.dtVon.Value == null)
            {
                //this.dtVon.DateTime = this.dtVon.MinDate;
            }

            if (this.dtBis.Value == null)
            {
                //this.dtBis.DateTime = DateTime.Now;
            }

            if (this.dtBis.DateTime < this.dtVon.DateTime)
                this.dtBis.DateTime = this.dtVon.DateTime;
        }

        public void setUI(string aktivButton)
        {            
            using (Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfoF = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.Info, "Hinweis", Infragistics.Win.DefaultableBoolean.True))
            {
                switch (aktivButton)
                {
                    case "F":
                        ActUIMode = PMDS.Calc.Logic.CalcUIMode.Freigegeben;
                        this.btnPrint.Text = "Rechnung(en) öffnen";
                        PMDS.Global.UIGlobal.setUIButton(this.btnVorschau, false);
                        PMDS.Global.UIGlobal.setUIButton(this.btnFreigeben, true);
                        ultraToolTipInfoF.ToolTipText = "\nFür Rechnungsversand = Umschalt-Taste\nFür Rechnungskopie = Strg-Taste";
                        this.btnRollung.Visible = false;
                        break;

                    case "O":
                        ActUIMode = PMDS.Calc.Logic.CalcUIMode.Vorschau;
                        this.btnPrint.Text = "Vorschau(en) öffnen";
                        PMDS.Global.UIGlobal.setUIButton(this.btnFreigeben, false);
                        PMDS.Global.UIGlobal.setUIButton(this.btnVorschau, true);
                        ultraToolTipInfoF.ToolTipText += "\nFür FSW-XLSX-Vorschau = Strg-Taste";
                        this.btnRollung.Visible = true;
                        break;

                    default:
                        ActUIMode = PMDS.Calc.Logic.CalcUIMode.Belege;
                        this.btnPrint.Text = "Beleg(e) öffnen";
                        PMDS.Global.UIGlobal.setUIButton(this.btnVorschau, false);
                        ultraToolTipInfoF.ToolTipText += "";
                        this.btnRollung.Visible = false;
                        break;
                }
                this.ultraToolTipManager1.SetUltraToolTip(this.btnPrint, ultraToolTipInfoF);
            }

            this.freigegebenOn = aktivButton == "F" ? true : false;
            this.uiSiteMapForm._freigeben = this.freigegebenOn;

            this.panelAuswahlRechTyp.Visible = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.sr && this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.depotgeld ? this.freigegebenOn : false;
            if (!this.freigegebenOn)
                this.grpAbrechnen.Visible = this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.calc && this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.buchhaltung ? true : false;
            else
                this.grpAbrechnen.Visible = false;

            this.butRechFreigeb.Visible = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.buchhaltung && this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.depotgeld ? !this.freigegebenOn : false;
            this.paneStorno.Visible = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.buchhaltung && this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.depotgeld ? this.freigegebenOn : false;
            this.panelFSW.Visible = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.buchhaltung && this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.depotgeld ? this.freigegebenOn : false && PMDS.Global.ENV.FSW_IDIntern != Guid.Empty;
            this.panelAuswahlFreigStornoAll.Visible = this.freigegebenOn;
            this.setButtStorno();
            this.panelDelete.Visible = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.buchhaltung ? (!this.freigegebenOn || PMDS.Global.ENV.adminSecure) : false;
            this.uGridAbrech2.DisplayLayout.Bands[0].Columns["Freigegeben"].Hidden = true;
            this.uGridAbrech2.DisplayLayout.Bands[0].Columns["RechNr"].Hidden = !this.freigegebenOn;
            this.uGridAbrech2.DisplayLayout.Bands[0].Columns["RechNrStorno"].Hidden = true;     //!(this.freigegebenOn && this.getCboBillStatusIsStornoOrAll());
            this.uOptSetAbrechTyp.Visible = this.uiSiteMapForm.typ != ucCalcsSitemap.eTyp.depotgeld;

            this.uGridAbrech2.ContextMenuStrip = null;

            Application.DoEvents();
        }



        public bool getCboBillStatusIsStornoOrAll()
        {
            if (this.cboBillStatus.Value != null && (this.cboBillStatus.Value.ToString().Trim().ToLower().Equals(("s").Trim().ToLower()) || this.cboBillStatus.Value.ToString().Trim().ToLower().Equals(("a").Trim().ToLower())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool getCboBillStatusIsStorno()
        {
            if (this.cboBillStatus.Value != null && this.cboBillStatus.Value.ToString().Trim().ToLower().Equals(("s").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool getCboBillStatusIsAll()
        {
            if (this.cboBillStatus.Value != null && this.cboBillStatus.Value.ToString().Trim().ToLower().Equals(("a").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void setUIContMenüRechÖffnen(bool on)
        {
            //this.erlöseVerbuchenToolStripMenuItem.Visible = on;
            //this.toolStripMenuItemLineErlöse.Visible = on;
            this.rechnungÖffnenToolStripMenuItem.Visible = on;
            this.stornierteRechnungÖffnenToolStripMenuItem.Visible = on;
            this.toolStripMenuItemLineRechÖffnen.Visible = on;

        }
        public void setUIContMenüBuchen(bool on)
        {
            this.erlöseVerbuchenToolStripMenuItem.Visible = on;
            this.ausgewählteRechnungenAlsEinzahlungBuchenToolStripMenuItem.Visible = on;
            this.toolStripMenuItemLineErlöse.Visible = on;
        }
        private void setButtStorno()
        {
            if (this.getCboBillStatusIsStorno())
                this.btnStorno.Visible = false;
            else
                this.btnStorno.Visible = true;

            this.uGridAbrech2.DisplayLayout.Bands[0].Columns["RechNrStorno"].Hidden = true;     //!this.getCboBillStatusIsStornoOrAll();
            this.uGridAbrech2.ContextMenuStrip = null;
        }

        public void doAction(PMDS.UI.Sitemap.eAction typ, string txtQuestion, string txtInfo, PMDS.Calc.Logic.eModify typModify,
                                bool msgBox, Nullable<DateTime> datStornodatum, Nullable<DateTime> rechDatum, bool RollungJN)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.uiSiteMapForm.doAction22(typ, txtQuestion, txtInfo, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech2, ref this.lblCount,
                                                typModify, msgBox, datStornodatum, rechDatum, RollungJN);
            
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

        private void dtVon_Enter(object sender, EventArgs e)
        {
            this.dtVon.SelectAll();
        }
        private void dtBis_Enter(object sender, EventArgs e)
        {
            this.dtBis.SelectAll();
        }

        private void butAlleKeine_Click(object sender, EventArgs e)
        {
            this.uiSiteMapForm.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.butAlleKeine, !(bool)this.butAlleKeine.Tag, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech2, "", false);
        }
        private void butAbrechnen_Click(object sender, EventArgs e)
        {
            this.doCalc();
        }
        private void btnFreigeben_Click(object sender, EventArgs e)
        {
            this.setUI("F");
            this.loadCalcs();
        }
        private void btnVorschau_Click(object sender, EventArgs e)
        {
            this.setUI("O");
            this.loadCalcs();
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {

        }
        private void btnTimes_MouseUp(object sender, MouseEventArgs e)
        {
            this.uiSiteMapForm.sitemap.timemenu.Show(this, new Point(this.grpSuche.Left + btnTimes.Left, this.grpSuche.Top + btnTimes.Top + btnTimes.Height));
        }
        private void Timeitem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            PMDS.Global.timehelper h = (PMDS.Global.timehelper)item.Tag;
            this.dtVon.DateTime = h._from;
            this.dtBis.DateTime = h._to;
            this.loadCalcs();
        }

        private void ucCalcs_Resize(object sender, EventArgs e)
        {
            if (this.btnRechEinAus.Tag.ToString() == "1")
                this.setUICalc(this.editorVis);

            //Panels werden nach dem Wiederherstellen nicht korrekt gezeichnet -> neuzeichnen forcieren
            panelPrint.Height -= 1;
            panelDelete.Height -= 1;
            paneStorno.Height -= 1;
            panelFSW.Height -= 1;
            panelAuswahlRechTyp.Height -= 1;
            panelAuswahlFreigStornoAll.Height -= 1;
            panelHistorie2.Height -= 1;
            panelBottom.Height -= 1;

            panelPrint.Height += 1;
            panelDelete.Height += 1;
            paneStorno.Height += 1;
            panelFSW.Height += 1;
            panelAuswahlRechTyp.Height += 1;
            panelAuswahlFreigStornoAll.Height += 1;
            panelHistorie2.Height += 1;
            panelBottom.Height += 1;

            Application.DoEvents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.doAction(eAction.delete, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die markierten Zeilen wirklich löschen?"), "", PMDS.Calc.Logic.eModify.nichts, true, null, null, false);
        }

        private void uOptSetAbrechTyp_ValueChanged(object sender, EventArgs e)
        {

        }



        private void protokollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.getActivRowDS(true) != null)
            {
                PMDS.Calc.Logic.dbPMDS.billsRow rowData = this.getActivRowDS(false);
                this.uiSiteMapForm.sitemap.openProt(ref rowData);
            }
        }

        private PMDS.Calc.Logic.dbPMDS.billsRow getActivRowDS(bool msgBox)
        {
            if (this.uGridAbrech2.ActiveRow != null)
            {
                PMDS.Calc.Logic.dbPMDS.billsRow rowDS = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)this.uGridAbrech2.ActiveRow.ListObject).Row;
                return rowDS;
            }
            else
            {
                if (msgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!", "Aktivität ausführen");
                return null;
            }
        }
        private void butRechFreigeb_Click(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.dtRechDatum, "");

            if (this.dtRechDatum.Value == null)
            {
                this.errorProvider1.SetError(this.dtRechDatum, "Error");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rechnungs-Datum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                this.dtRechDatum.Focus();
                return;
            }

            this.doAction(eAction.freigeben, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Rechnungen wirklich freigeben?"),
                                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnungen wurden freigegeben!"),
            PMDS.Calc.Logic.eModify.nichts, true, null, this.dtRechDatum.DateTime.Date, false);

            this.loadCalcs();
        }
      
        private void dtVon_Leave(object sender, EventArgs e)
        {
            //this.loadCalcs();
        }
        private void dtBis_Leave(object sender, EventArgs e)
        {
            //this.loadCalcs();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (this.freigegebenOn)
            {
                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
                {
                    this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.printRechnungsKopie, true, null, null, false);
                }
                else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift))
                {
                    this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.printRechnungsversand, true, null, null, false);
                }
                else
                {
                    this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.nichts, true, null, null, false);
                }
            }
            else
            {
                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
                {
                    this.doAction(eAction.fswXlsVorschau, "", "", PMDS.Calc.Logic.eModify.printRechnungsKopie, true, null, null, false);
                }
                else
                {
                    this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.nichts, true, null, null, false);
                }
            }

        }

        private void btnRechEinAus_Click(object sender, EventArgs e)
        {
            if (this.btnRechEinAus.Tag.ToString () == "0")
            {
                this.setUICalc(true );
                this.btnRechEinAus.Tag = "1";
            }
            else
            {
                this.setUICalc(false );
                this.btnRechEinAus.Tag = "0";
            }
        }

        private void setUICalc(bool bOn )
        {
            this.editorVis = bOn;

            if (bOn)
            {
                this.editor.Top = this.uGridAbrech2.Top;
                this.editor.Left = this.uGridAbrech2.Left;

                this.editor.Height = this.uGridAbrech2.Height;
                this.editor.Width = this.uGridAbrech2.Width;
            }
            else
            {
                this.editor.Top = -100;
                this.editor.Left = -100;

                this.editor.Height = 80;
                this.editor.Width = 80;
            }
            this.editorPrecalc.Location = this.editor.Location;
            this.editorPrecalc.Size = this.editor.Size;
        }

        private void btnStorno_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<DateTime> dMaxRechDatum = null;
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    List<UltraGridRow> arrSelected = new List<UltraGridRow>();
                    this.uiSiteMapForm.sitemap.doAction22(eAction.stornieren, "", "", "", this.uGridAbrech2, ref lblCount, ref arrSelected, false);
                    List<String> listIDBills = new List<String>();
                    foreach (UltraGridRow rGrid in arrSelected)
                    {
                        PMDS.Calc.Logic.dbPMDS.billsRow r = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)rGrid.ListObject).Row;
                        var rEF = (from b in db.bills
                                   where b.ID == r.ID
                                   select new
                                   {
                                        b.ID,
                                       RechDatum = b.RechDatum.Value
                                   }).First();

                        if (dMaxRechDatum == null)
                            dMaxRechDatum = rEF.RechDatum.Date;
                        else if (rEF.RechDatum.Date > dMaxRechDatum)
                            dMaxRechDatum = rEF.RechDatum.Date;
                    }
                }

                frmInputDate frmInputDate1 = new frmInputDate();
                frmInputDate1.initControl(dMaxRechDatum);
                frmInputDate1.ShowDialog(this);
                if (!frmInputDate1.abort)
                {
                    this.doAction(eAction.stornieren, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Rechnungen wirklich stornieren?"),
                                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnungen wurden storniert!"), PMDS.Calc.Logic.eModify.nichts, 
                                                        true, frmInputDate1.udteStornodatum.DateTime.Date, null, false);
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

        private void textControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true ;
        }

        private void cboRechTyp_ValueChanged(object sender, EventArgs e)
        {
            if (this.cboRechTyp.Focused)
            {
                this.setButtStorno();
                this.loadCalcs();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.loadCalcs();
        }


        public  void setColBack(bool hist)
        {
            if (this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.sr)
            {
                this.BackColor = System.Drawing.Color.Gainsboro;
            }
            else
            {
                if (!hist)
                {
                    this.BackColor = System.Drawing.Color.WhiteSmoke;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }

        private void panelVorFreig3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void erlöseVerbuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.getActivRowDS(true) != null)
                {
                    PMDS.Calc.Logic.dbPMDS.billsRow r = this.getActivRowDS(false);
                    frmNewBooking frm = new frmNewBooking();
                    frm.init(r.IDKost , r.IDKlient, QS2.Desktop.ControlManagment.ControlManagment.getRes("Erlösbuchung"), r.betrag, r.datum, r.RechNr);
                    frm.ShowDialog(this);
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

        private void rechnungÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.openBillRechStor, true, null, null, false);
        }
        private void stornierteRechnungÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.openBillRechStorStorno, true, null, null, false);
        }

        private void ausgewählteRechnungenAlsEinzahlungBuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doAction(eAction.einzahlungBuchen, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die ausgewählten Rechnungen wirklich als Einzahlung buchen?"), 
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzahlungen gebucht"), PMDS.Calc.Logic.eModify.nichts, true, null, null, false);
        }

        private void uGridAbrech2_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "Freigegeben")
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        private void uGridAbrech2_BeforeRowActivate(object sender, RowEventArgs e)
        {
            if (uGridAbrech2.Focused)
            {
                if (e.Row.IsGroupByRow)
                {
                    this.uGridAbrech2.ContextMenuStrip = null;
                    return;
                }

                this.uGridAbrech2.ContextMenuStrip = this.contextMenuStrip1;
                PMDS.Calc.Logic.dbPMDS.billsRow rowDS = (PMDS.Calc.Logic.dbPMDS.billsRow)((System.Data.DataRowView)e.Row.ListObject).Row;
                this.setUIContMenüRechÖffnen((this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.calc ||
                                            this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.sr) &&
                                            this.getCboBillStatusIsStorno() &&
                                            (rowDS.Typ == (int)PMDS.Calc.Logic.eBillTyp.Rechnung ||
                                            rowDS.Typ == (int)PMDS.Calc.Logic.eBillTyp.Sammelrechnung));
                this.setUIContMenüBuchen((this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.calc ||
                                            this.uiSiteMapForm.typ == ucCalcsSitemap.eTyp.sr) &&
                                            this.freigegebenOn);

            }
        }

        private void uGridAbrech2_BeforeRowRegionScroll(object sender, BeforeRowRegionScrollEventArgs e)
        {
            this.uiSiteMapForm.sitemap.evBeforeRowRegionScrollAuto(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech2);
        }

        private void uGridAbrech2_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.Cancel = true;
        }

        private void uGridAbrech2_DoubleClick(object sender, EventArgs e)
        {
            if (this.uiSiteMapForm.sitemap.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbrech2))
                this.doAction(eAction.printBill, "", "", PMDS.Calc.Logic.eModify.nichts, false, null, null, false);
        }

        public void exportGridAsExcel(bool asPdf)
        {
            this.uGridAbrech2.DisplayLayout.Bands[0].Summaries.Clear();
            //this.uGridAbrech2.DisplayLayout.Bands[0].SummaryFooterCaption = "SUM";

            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.External, null, "betrag", 12, true, "bills", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "betrag", 12, true);
            summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.uGridAbrech2.DisplayLayout.Bands[0].Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {summarySettings1});
            //this.uGridAbrech2.Rows.SummaryValues[0].SetExternalSummaryValue(55);
            this.uGridAbrech2.Refresh();

            if (asPdf)
            {
                this.export.exportGrid(this.uGridAbrech2, PMDS.GUI.VB.gridExport.eTyp.pdf, null, "", null, "", "");
            }
            else
            {
                this.export.exportGrid(this.uGridAbrech2, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "", "");
            }
            
            this.uGridAbrech2.DisplayLayout.Bands[0].Summaries.Remove(summarySettings1);
            this.loadCalcs();
        }

        private void btnExportAsExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.exportGridAsExcel(false);

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

        private void ucCalcs_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.uGridAbrech2.ContextMenuStrip = null;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void uGridAbrech2_ExternalSummaryValueRequested(object sender, ExternalSummaryValueEventArgs e)
        {
            try
            {
                e.SummaryValue.SetExternalSummaryValue(this.numSum.Value);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnExportAsPdf_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.exportGridAsExcel(true);

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

        private void cboBillType_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.cboBillStatus.Focused)
                {
                    this.setButtStorno();
                    this.loadCalcs();
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

        private void dtVonErstelltAm_Enter(object sender, EventArgs e)
        {
            this.dtVonRechDatum.SelectAll();
        }
        private void dtBisErstelltAm_Enter(object sender, EventArgs e)
        {
            this.dtBisRechDatum.SelectAll();
        }

        private void btnRollung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;


                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
                {
                    this.doAction(eAction.rollen, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Zeilen wirklich gegen NICHT FREIGEGEBENE Rechnungnen rollen?"),
                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnungen wurden freigegeben!"),
                                    PMDS.Calc.Logic.eModify.nichts, true, null, this.dtRechDatum.DateTime.Date, false);
                }
                else
                {
                    this.doAction(eAction.rollen, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Zeilen wirklich rollen?"),
                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnungen wurden freigegeben!"),
                                    PMDS.Calc.Logic.eModify.nichts, true, null, this.dtRechDatum.DateTime.Date, true);
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

        private void btnRollungSperreLöschen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doAction(eAction.SperreRollungLöschen, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Sperre für Stornorechnungen und Rollung wirklich aufheben?"),
                           "",
                           PMDS.Calc.Logic.eModify.nichts, true, null, this.dtRechDatum.DateTime.Date, true);

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

        private void btnFSW_Click(object sender, EventArgs e)
        {
            try
            {
                eAction action = eAction.fswNoUpload;
                string MsgBoxTite = "Wollen eine FSW-Zahlungsaufforderung erstellen und speichern, aber NICHT senden?";
                string ReturnText = "Zahlungsaufforderung wurde im XML-Format gepeichert, aber nicht gesendet.";
                
                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift))
                {
                    action = eAction.fsw;
                    MsgBoxTite = "Wollen Sie eine FSW-Zahlungsaufforderung erstellen, speichern und senden?";
                    ReturnText = "Zielumgebung = " + ENV.FSW_FTPMode + "\nZahlungsaufforderung wurde erstellt und an den FSW gesendet.";
                }

                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightAlt))
                {
                    action = eAction.fswsFTPOnly;
                    MsgBoxTite = "Wollen Sie eine eZAUFF per sFTP an den FSW senden?";
                    ReturnText = "Zielumgebung = " + ENV.FSW_FTPMode + "\nFSW-Zahlungsaufforderung wurde per sFTP an den FSW gesendet.";
                }

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.doAction(action, MsgBoxTite, ReturnText,
                                PMDS.Calc.Logic.eModify.nichts, true, null, this.dtRechDatum.DateTime.Date, true);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void btnFSWReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doAction(eAction.fswreset, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie den Status der Zahlungsaufforderung für den FSW zurücksetzen?"),
                                QS2.Desktop.ControlManagment.ControlManagment.getRes("Status für FSW-Zahlungsaufforderung wurde zurückgesetzt."),
                                PMDS.Calc.Logic.eModify.nichts, true, null, this.dtRechDatum.DateTime.Date, true);

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
