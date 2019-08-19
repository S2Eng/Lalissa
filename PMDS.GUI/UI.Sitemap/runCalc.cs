using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMDS.Global;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;
using PMDS.Global.db.Patient;
using PMDS.Calc.Logic;

namespace PMDS.UI.Sitemap
{


    public class runCalc
    {

        public frmProtokoll mainForm;



        public void run(DateTime von, DateTime bis, DateTime rechDatum,
                  ref UltraGrid grid, ref UltraButton butAlleKeine,
                  ref UltraLabel lblCount, PMDS.Calc.Logic.eCalcRun calcRun, TXTextControl.TextControl editor,
                  TXTextControl.TextControl editorPrecalc, string typ, ref System.Collections.ArrayList listID)
        {
            string Prot = "";
            int iCounterProt = 0;

            PMDS.Calc.Logic.calculation calculation = new PMDS.Calc.Logic.calculation();
            PMDS.Calc.Logic.print print = new PMDS.Calc.Logic.print();
            PMDS.Calc.Logic.doDepotgeld doDepot = new PMDS.Calc.Logic.doDepotgeld();
            PMDS.Calc.Logic.dbBill dbBill = new PMDS.Calc.Logic.dbBill();
            PMDS.Calc.Logic.bill bill = new PMDS.Calc.Logic.bill();

            string protCalculated = "";
            int anzAbg = 0;
            PMDS.BusinessLogic.Patient pat;
            try
            {
                System.Guid IKlinikTest = PMDS.Global.ENV.IDKlinik;
                protCalculated = " <span style=" + (char)34 + "font-size:10pt;" + (char)34 + ">" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Klienten wurde eine Abrechnung durchgeführt:") + "</span>" + "<br/>" + "<br/>";
 
                string txtTit = "";
                if (typ == "M")
                    txtTit = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abrechnung für Monat ") + von.ToString("MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird durchgeführt:");
                else if (typ == "D")
                    txtTit = QS2.Desktop.ControlManagment.ControlManagment.getRes("Depotgeldabrechnung bis ") + von.ToString("dd.MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird durchgeführt:");
                mainForm.ucProtokoll1.start(txtTit, false, "", "", false, false);

                if (listID.Count > 0)
                {
                    //frmProtokoll.Show();
                    //if (PMDS.Global.ENV.mainAbrech != null)
                    //{
                    //    frmProtokoll.Left = PMDS.Global.ENV.mainAbrech.Left + (PMDS.Global.ENV.mainAbrech.Width / 2) / 2;
                    //    frmProtokoll.Top = PMDS.Global.ENV.mainAbrech.Top + (PMDS.Global.ENV.mainAbrech.Height / 2) / 2 + 100;
                    //}

                    print.loadTempStream(PMDS.Calc.Logic.bill.rechnungRTF, (typ == "D" ? true: false));
                    if (typ == "M")
                        PMDS.Calc.Logic.calculation.editorPrecalc = editorPrecalc;

                    foreach (string idklient in listID)
                    {
                        pat = new PMDS.BusinessLogic.Patient(new System.Guid(idklient));
                        try
                        {
                            mainForm.ucProtokoll1.addProtokoll(pat.FullName + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird abgerechnet ...") + "<br/>", true);
                            PMDS.Calc.Logic.calcData calc = null;

                            PMDS.Global.ucProtokoll.eIco ico = new PMDS.Global.ucProtokoll.eIco();
                            string str = pat.FullName;
                            if (typ == "M")
                            {
                                dsKlinik dsKlinik1 = new dsKlinik();
                                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                                dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

                                calc = calculation.run(idklient.ToString(), von, bis, rechDatum, true,
                                                PMDS.Calc.Logic.eCalcTyp.abrechnung, calcRun, editor, PMDS.Global.ENV.IDKlinik, rKlinikActuell.Bereich.Trim(), ref Prot, ref iCounterProt);

                                if (iCounterProt > 0)
                                {
                                    str = str + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde nicht erfolgreich abgerechnet!") + " (" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Details siehe Protokoll.") + ")";
                                    ico = ucProtokoll.eIco.error;
                                }
                                else
                                {
                                    if (calc.dbCalc.Leistungen.Rows.Count > 0)
                                    {
                                        str += QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde erfolgreich abgerechnet!");
                                        string strAdditionalInfo = "";
                                        if (calc.dbCalc.Kostenträger.Rows.Count == 0)
                                        {
                                            strAdditionalInfo += QS2.Desktop.ControlManagment.ControlManagment.getRes("kein Kostenträger zugeordnet") + " ";
                                            ico = ucProtokoll.eIco.error;
                                        }
                                        else
                                        {
                                            ico = ucProtokoll.eIco.ok;
                                        }

                                        int anzKeineLeistung = 0;
                                        string BezeichnungLeistungReturn = "";
                                        if (!this.checkLeistungen(calc.dbCalc, ref BezeichnungLeistungReturn, ref anzKeineLeistung))
                                        {
                                            string infoTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("für {0} Leistung/en wurde kein Zahler gefunden") + " ";
                                            infoTmp = string.Format(infoTmp, anzKeineLeistung.ToString());
                                            strAdditionalInfo += infoTmp;
                                            ico = ucProtokoll.eIco.ok;
                                        }

                                        if (strAdditionalInfo.Trim() != "")
                                        {
                                            str += " (" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Achtung") + ": " + strAdditionalInfo + "!)";
                                        }
                                    }
                                    else
                                    {
                                        str = QS2.Desktop.ControlManagment.ControlManagment.getRes("Für ") + str + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurden keine Leistungen gefunden!");
                                        string strAdditionalInfo = "";
                                        if (calc.dbCalc.Kostenträger.Rows.Count == 0)
                                        {
                                            strAdditionalInfo += QS2.Desktop.ControlManagment.ControlManagment.getRes("kein Kostenträger zugeordnet") + " ";
                                            ico = ucProtokoll.eIco.error;
                                        }
                                        else
                                        {
                                            ico = ucProtokoll.eIco.hinweis;
                                        }

                                        int anzKeineLeistung = 0;
                                        string BezeichnungLeistungReturn = "";
                                        if (!this.checkLeistungen(calc.dbCalc, ref BezeichnungLeistungReturn, ref anzKeineLeistung))
                                        {
                                            string infoTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("für {0} Leistung/en wurde kein Zahler gefunden") + " ";
                                            infoTmp = string.Format(infoTmp, anzKeineLeistung.ToString());
                                            strAdditionalInfo += infoTmp;
                                            ico = ucProtokoll.eIco.error;
                                        }

                                        if (strAdditionalInfo.Trim() != "")
                                        {
                                            str += " (" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Achtung") + ": " + strAdditionalInfo + "!)";
                                        }
                                    }
                                }
                            }
                            else if (typ == "D")
                            {
                                calc = doDepot.run(idklient, bis, rechDatum, editor, PMDS.Global.ENV.IDKlinik);
                                str += QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde erfolgreich abgerechnet! (") + calc.anz.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Positionen verrechnet)"); ico = ucProtokoll.eIco.ok;
                            }

                            PMDS.Global.clTagInfoLog tg = new PMDS.Global.clTagInfoLog();
                            tg.typ = PMDS.Global.clTagInfoLog.eNodeTyp.IDKlient; tg.id = pat.ID; tg.protDetail = calc.protokoll;
                            tg.tabLog = bill.getXMLDbCalc(calc.dbCalc);
                            tg.tabLogFields = dbBill.getXMLDbBill(calc.dbBill);

                            protCalculated += str + "<br/>";
                            mainForm.ucProtokoll1.addTree(tg, str, ico);
                            anzAbg += 1;
                            Application.DoEvents();
                        }
                        catch (Exception ex)
                        {
                            if (PMDS.Calc.Logic.calcBase.errTxt != "") ex = new Exception(PMDS.Calc.Logic.calcBase.errTxt);
                            PMDS.Global.ENV.HandleException(ex);
                        }
                    }
                }

                if (Prot.Trim() != "")
                {
                    PMDS.Calc.UI.Admin.frmProtocoll frmProtocoll1 = new PMDS.Calc.UI.Admin.frmProtocoll();
                    frmProtocoll1.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler bei der Abrechnung");
                    frmProtocoll1.txtProtocoll.Text = Prot.Trim();
                    frmProtocoll1.TopMost = true;
                    frmProtocoll1.Show();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                string txtReg = "Ergebnis Abrechnung";
                if (anzAbg > 0)
                {
                    mainForm.ucProtokoll1.start(txtReg, true, protCalculated, "", false, false);
                    mainForm.ucProtokoll1.showTree();
                }
            }
        }

        public bool checkLeistungen(dbCalc dbCalc, ref string BezeichnungLeistungReturn, ref int anzKeineLeistung)
        {
            try
            {
                dbCalc.LeistungenRow[] arrLeistungenAll = (dbCalc.LeistungenRow[])dbCalc.Leistungen.Select("", "");
                foreach (dbCalc.LeistungenRow rLeist in arrLeistungenAll)
                {
                    dbCalc.ZahlerRow[] arrzahler = (dbCalc.ZahlerRow[])dbCalc.Zahler.Select(dbCalc.Zahler.IDLeistungColumn.ColumnName + "='" + rLeist.ID.Trim() + "'", "");
                    if (arrzahler.Length == 0)
                    {
                        BezeichnungLeistungReturn += rLeist.LeistungBezeichnung.Trim() + ";";
                        anzKeineLeistung += 1;
                    }
                }
                
                return (anzKeineLeistung == 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw new Exception("runCalc.checkLeistungen: " + ex.ToString());
            }
        }


    }
}
