using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace PMDS.Calc.UI.Admin.generic.Calc
{


    public class genericCalc
    {




        public void openBill(bool withMsgBox, string TypBill, string IDKostIntern, ref TXTextControl.TextControl editor,
                                string IDBillHeader, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                PMDS.Calc.Logic.print print = new PMDS.Calc.Logic.print();
                List<PMDS.Calc.Logic.dbPMDS.billsRow> arrBillRows = new List<PMDS.Calc.Logic.dbPMDS.billsRow>();
                PMDS.Calc.Logic.Sql sqlCalc = new PMDS.Calc.Logic.Sql();
                PMDS.Calc.Logic.dbPMDS dbPMDSRead = new PMDS.Calc.Logic.dbPMDS();

                if (TypBill == PMDS.Calc.Logic.eBillTyp.Rechnung.ToString() || TypBill == PMDS.Calc.Logic.eBillTyp.Sammelrechnung.ToString() ||
                    TypBill == PMDS.Calc.Logic.eBillTyp.FreieRechnung.ToString())
                {
                    PMDS.Calc.Logic.dbPMDS.billsRow rBill = sqlCalc.readBillsIDKostIntern(IDKostIntern.ToString(), true, PMDS.Global.ENV.IDKlinik, new Guid(IDBillHeader));
                    if (rBill == null)
                    {
                        throw new Exception("openBill: No Bill found for IDKostIntern '" + IDKostIntern.ToString() + "' found!");
                    }
                    arrBillRows.Add(rBill);
                    print.printBills(arrBillRows, editor, "PMDS - Rechnung", arrBillRows.Count == 1 ? this : null, (object)gridRow, PMDS.Calc.Logic.eModify.openBillRechStor, "");
                }
                //else if (rExportBMD.TypBill == PMDS.Calc.Logic.eBillTyp.Sammelrechnung.ToString())
                //{
                //    sqlCalc.readBills(rExportBMD.IDBillHeader.ToString(), ref dbPMDSRead);
                //    if (dbPMDSRead.bills .Rows .Count != 1 )
                //    {
                //        throw new Exception("openBill: dbPMDSRead.bills .Rows .Count != 1 IDBillHeader '" + rExportBMD .IDBillHeader .ToString () + "'!");
                //    }
                //    PMDS.Calc.Logic.dbPMDS.billsRow rBill = ( PMDS.Calc.Logic.dbPMDS.billsRow )dbPMDSRead.bills.Rows[0];
                //    arrBillRows.Add(rBill);
                //    this.print.printSites(arrBillRows, this.editor, "PMDS - Rechnung", arrBillRows.Count == 1 ? this : null, (object)gridRow, PMDS.Calc.Logic.eModify.openBillRechStor);
                //}
                else
                    throw new Exception("genericCalc.openBill: TypeBill '" + TypBill.ToString() + "' not exist for IDBillHeader '" + IDBillHeader.ToString() + "'!");

                //List<Infragistics.Win.UltraWinGrid.UltraGridRow> arrSelected = new List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
                //List<PMDS.Calc.Logic.dbPMDS.billsRow> arrBillRows = new List<PMDS.Calc.Logic.dbPMDS.billsRow>();
                //Infragistics.Win.UltraWinGrid.UltraGridRow rSelRow = null;
                //DialogResult res = this.sitemap.doAction(PMDS.UI.Sitemap.eAction.printBill, txtQuestion, "Rechnung/en", txtInfo, ref grid, ref  lblCount, ref arrSelected, msgBox);
                //if (res == DialogResult.Yes)
                //{
                //    int anzDel = 0;
                //    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rToDel in arrSelected)
                //    {
                //        PMDS.Calc.Logic.dsExport.ExportBMDRow rExport = (PMDS.Calc.Logic.dsExport.ExportBMDRow)((System.Data.DataRowView)rToDel.ListObject).Row;

                //        if (typ == eAction.printBill)
                //        {
                //            PMDS.Calc.Logic.dbPMDS dbPMDSReadBill = new PMDS.Calc.Logic.dbPMDS();
                //            PMDS.Calc.Logic.Sql sqlCalc = new PMDS.Calc.Logic.Sql();
                //            PMDS.Calc.Logic.dbPMDS.billsRow rBill = sqlCalc.readBill(rExport.IDBill.ToString());
                //            arrBillRows.Add(rBill);
                //            if (rSelRow == null) rSelRow = rToDel;
                //        }

                //        anzDel += 1;
                //    }
                //    if (typ == eAction.printBill)
                //    {
                //        this.print.printSites(arrBillRows, this.editor, "PMDS - Rechnung/en", arrBillRows.Count == 1 ? this : null, (object)rSelRow, typModify);
                //    }
                //}
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void openDbCalc(string IDBillHeader)
        {
            try
            {
                PMDS.Calc.Logic.dbCalc dbCalcTemp = new PMDS.Calc.Logic.dbCalc();
                PMDS.Calc.Logic.dbPMDS dbPMDS1 = new PMDS.Calc.Logic.dbPMDS();
                PMDS.Calc.Logic.Sql sqlCalc = new PMDS.Calc.Logic.Sql();
                sqlCalc.readBillHeader(IDBillHeader.ToString(), ref dbPMDS1, PMDS.Global.ENV.IDKlinik);
                if (dbPMDS1.billHeader.Rows.Count == 0)
                {
                    throw new Exception("genericCalc.openDbCalc: dbPMDS1.billHeader.Rows.Count == 0 for IDBillHeader '" + IDBillHeader.ToString() + "'!");
                }
                else
                {
                    PMDS.Calc.Logic.dbPMDS.billHeaderRow rBillHeader = (PMDS.Calc.Logic.dbPMDS.billHeaderRow)dbPMDS1.billHeader.Rows[0];

                    PMDS.Global.frmProtDS frmDS = new PMDS.Global.frmProtDS();

                    System.IO.StringReader xmlStringReader = new System.IO.StringReader(rBillHeader.dbCalc);
                    System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(xmlStringReader);
                    frmDS._db.ReadXml(xmlReader);
                    xmlReader.Close();
                    frmDS.addLogDS(false);
                    frmDS.loadTable(dbCalcTemp.KostenKostenträger.TableName);
                    frmDS.Show();

                    if (dbPMDS1.billHeader.Rows.Count > 1)
                    {
                        throw new Exception("genericCalc.openDbCalc: dbPMDS1.billHeader.Rows.Count > 1 for IDBillHeader '" + IDBillHeader.ToString() + "'!");
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
