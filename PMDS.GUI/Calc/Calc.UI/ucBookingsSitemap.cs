using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using PMDS.GUI.BaseControls;
using Infragistics.Win.Misc;
using PMDS.Global;
using PMDS.UI .Sitemap ;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI
{

    public class ucBookingsSitemap : QS2.Desktop.ControlManagment.BaseControl
    {
        public PMDS.UI.Sitemap.UIFct sitemap;
        private PMDS.Calc.UI.ucBookings form;

        private PMDS.Calc.Logic.Sql  _sql;
        private System.Data.OleDb .OleDbDataAdapter  _da;
        private PMDS.Calc.Logic.booking _booking;

        public bool isLoaded = false;



        public void initControl(ref PMDS.Calc.UI.ucBookings cont )
        {
            try
            {
                if (this.isLoaded) return;

                this.form = cont;

                this.sitemap = new UIFct();
                this._sql = new PMDS.Calc.Logic.Sql();
                this._booking = new PMDS.Calc.Logic.booking();
                this.form.ucprint1.initControl(QS2.Desktop.Txteditor.etyp.calc);

                cont.uiSiteMapForm = this;
                cont.initControl();

                this.setButtons(false);
                this.initSelection();

                this.form.loadBookings(true);

                ENV.evklinikChanged += new klinikChanged(this.klinikChanged);

                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }
        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {
            this.clearBookings();
            this.loadKlienten();
            this.loadKostenträger();
        }

        public void initSelection( )
        {
            this.form.butSearch.Focus();

            this.loadKlienten();
            this.loadKostenträger();
            this.loadEnumBookings();
            //this.sitemap.loadValueListYear(this.form.uGridBookings.DisplayLayout.ValueLists["year"]);
        }

        public void clearBookings()
        {
            try
            {
                this.form.dbPMDS1.Clear();
                this.form.uGridBookings.Refresh();

                this.form.uGridBookings.Selected.Rows.Clear();
                this.UILoadBookings(this.form.dbPMDS1, this.form.uGridBookings, (UltraLabel)this.form.lblCount, true);
                //grid.PerformAction(UltraGridAction.PageUpRow);
                //LastElementEntered
                //    RowSelectorUIElement
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }
        public void loadBookings(ref PMDS.Calc.Logic.dbCalc db, DateTime von, DateTime bis, 
                                UltraGrid grid,   
                                UltraLabel lblCount, string idKlient, string idKost, string konto, string text   )
        { 
              try
              {
                  db.Clear();
                  this._da = this._sql.readBookings(idKlient.ToLower(), false , idKost.ToLower(), konto, PMDS.Calc.Logic.eKontoseite.beide, von, bis, text, db, PMDS.Calc.Logic.eCalcRun .all,ENV.IDKlinik );
                  grid.Refresh();
                  this.loadGridRows(ref grid);
                  this.form.uGridBookings.UpdateData();

                  //foreach (PMDS.Calc.Logic.dbPMDS.arBuchungenRow r in db.arBuchungen)
                  //{
                  //    if (r.Konto == "" && r.Gegenkonto != "")
                  //    {

                  //    }
                  //    else if (r.Konto != "" && r.Gegenkonto == "")
                  //    {

                  //    }
                  //    else
                  //    {
                  //        throw new Exception("loadBookings: Weder Konto noch Gegenkonto angeegben! (ID:" + r.ID + "'");
                  //    }
                  //}

                  grid.Selected.Rows.Clear();
                  this.UILoadBookings(db, grid, lblCount, true );
                  //grid.PerformAction(UltraGridAction.PageUpRow);
                 //LastElementEntered
                    //    RowSelectorUIElement
              }
              catch (Exception ex)
              {
                  PMDS.Global.ENV.HandleException(ex);
              }
              finally
              {
              }
        }

        public void UILoadBookings(PMDS.Calc.Logic.dbCalc db,  
                                    UltraGrid grid, UltraLabel lblCount, bool setAnz )
        {
            try
            {
                this.sitemap.anz = db.bookings.Rows.Count;
                if (setAnz) lblCount.Text = this.sitemap.setUIAnzahl("Keine Buchungen gefunden!");
                if (db.bookings.Rows.Count > 0)
                {
                    grid.DisplayLayout.Rows[0].ExpandAll();
                    grid.ActiveRow = grid.Rows[0];
                    this.form.btnPrint.Enabled = true;
                }
                else
                {
                    this.form.btnPrint.Enabled = false;
                }
                grid.ActiveRow = null;
                this.setButtons(false);
                this.form.btnDelete.Enabled = false;
                this.setUIPrint("S");
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }
        public bool loadGridRows (ref  UltraGrid grid)
        {
            decimal summSoll = 0;
            decimal summHaben = 0;
            foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, false))
            {
                if (r.IsGroupByRow)  continue;
                //if (!this.sitemap.IsInExpandedGroup(r))
                //    continue;

                PMDS.Calc.Logic.dbCalc.bookingsRow rowData = (PMDS.Calc.Logic.dbCalc.bookingsRow)((System.Data.DataRowView)r.ListObject).Row;

                if (rowData.Sollkonto == "" || rowData.Habenkonto  == "")
                {
                    try
                    {
                        throw new Exception("loadBookings: Konto oder Gegenkonto nicht angegeben! (ID:" + r.Cells["ID"].Value.ToString() + "'");
                    }
                    catch (Exception ex2)
                    {
                        PMDS.Global.ENV.HandleException(ex2);
                    }
                }

                if ((string)this.form.cboKonto.Value == rowData.Sollkonto )
                {
                    rowData.Soll = rowData.Betrag ;
                    rowData.Haben  = 0;
                    summSoll += rowData.Soll;
                    string sollKto = (string)rowData.Sollkonto ;
                    rowData.Sollkonto = rowData.Habenkonto ;
                    rowData.Habenkonto  = sollKto;
                }
                else 
                {
                    rowData.Haben = rowData.Betrag ;
                    rowData.Soll  = 0;
                    summHaben += rowData.Haben;
                }
            }

            decimal saldo = summSoll - summHaben;
            if (saldo > 0)
                this.form.lblSaldo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Saldo: Soll ") + saldo.ToString("###,###,##0.00") + " €";
            else if (saldo < 0)
                this.form.lblSaldo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Saldo: Haben ") + (saldo * -1).ToString("###,###,##0.00") + " €";
            else if (saldo == 0)
                this.form.lblSaldo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Saldo: 0 €");

            return true;
        }

        public void doAction22(eAction typ, string txtQuestion, string txtInfo, UltraGrid  grid ,
                                QS2.Desktop.ControlManagment.BaseLabel lblCount, bool msgBox)
        {
            try
            {
                if (grid.ActiveRow == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!");
                    return;
                }
                grid.ActiveRow.Selected = true;
                List<UltraGridRow> arrSelected = new List<UltraGridRow>();
                DialogResult res = this.sitemap.doAction22(typ, txtQuestion, "Buchung/en", txtInfo, (UltraGrid)grid, ref  lblCount, ref arrSelected, msgBox);
                if (res == DialogResult.Yes)
                {
                    int anzDel = 0;
                    foreach (UltraGridRow rToDel in arrSelected)
                    {
                        string IDBuch  = rToDel.Cells["ID"].Value.ToString();
                        if (typ == eAction.delete)
                        {
                            //this._sql.delBooking(IDBuch);
                            rToDel.Delete(false);
                        }
                        anzDel += 1;
                    }
                    this.sitemap.anz -= anzDel;
                    //this.sitemap.setUIAnzahl(ref lblCount, "Keine Buchungen gefunden!");
                    this.setButtons(true);
                    //if (anzDel > 0 & txtInfo != "") QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtInfo, "Buchung/en");
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }

        public void printList(ref PMDS.Calc.Logic.dbCalc db, DateTime von, DateTime bis, string Konto)
        {
            try
            {
                this.setUIPrint((string)this.form.btnPrint.Tag);
                if ((string )this.form.btnPrint.Tag == "S") this._booking.printBookings(db, von, bis,Konto, this.form.ucprint1.editor.textControl1);

                //PMDS.Calc.Logic.dbCalc dbCopy = this.getBookingsFilled(ref db, Konto);
                //dbCopy.WriteXml("F:\\listBookings99.xml");

                //List<PMDS.UI.Sitemap.cParCR> parList = new List<PMDS.UI.Sitemap.cParCR>();
                //PMDS.UI.Sitemap.cParCR par = new PMDS.UI.Sitemap.cParCR();
                //par.id = "Usr";
                //par.value = this.sitemap.usr.FullName;
                //parList.Add(par);

                //par = new PMDS.UI.Sitemap.cParCR();
                //par.id = "Von";
                //par.value = von;
                //parList.Add(par);

                //par = new PMDS.UI.Sitemap.cParCR();
                //par.id = "Bis";
                //par.value = bis;
                //parList.Add(par);

                //par = new PMDS.UI.Sitemap.cParCR();
                //par.id = "Konto";
                //par.value = Konto;
                //parList.Add(par);
                //dbCopy.bookings .TableName = "arBuchungen";
                //this.sitemap.printCR(parList, "listBookings.rpt", (System.Data.DataSet)dbCopy);
             }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }
        public void setUIPrint(string sModus )
        {
            try
            {
                bool modPrint = true;
                if (sModus == "P")
                {
                    modPrint = false;
                    this.form.btnPrint.Tag = "S";
                }
                else
                {
                    modPrint = true;
                    this.form.btnPrint.Tag = "P";
                }
                this.form.panelButtonsAddDel.Visible = modPrint ? true : false;
                this.form.panelBottom.Visible = modPrint ? true : false;
                this.form.ultraTabControl1.SelectedTab = modPrint ? this.form.ultraTabControl1.Tabs[0] : this.form.ultraTabControl1.Tabs[1];
                this.form.btnPrint.Appearance.Image = modPrint ? QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32): null;   //global::PMDS.Calc.UI.Properties.Resources.ICO_navKlein_1leftarrow
                this.form.btnPrint.Text = modPrint ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungen drucken") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Zurück");
                this.form.btnPrint.Width = modPrint ? 134 : 70;

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public bool validate (ref  UltraGrid  grid   )
        {
              foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, false))
              {
                  PMDS.Calc.Logic.dbCalc.bookingsRow rowData = (PMDS.Calc.Logic.dbCalc.bookingsRow)((System.Data.DataRowView)r.ListObject).Row;
                  PMDS.Calc.Logic.dbCalc.bookingsDataTable t = (PMDS.Calc.Logic.dbCalc.bookingsDataTable)rowData.Table;
                  rowData.SetColumnError(r.Cells[t.SollkontoColumn.ColumnName].Column.Index, "");
                  rowData.SetColumnError(r.Cells[t.TextColumn.ColumnName].Column.Index, "");
                  rowData.SetColumnError(r.Cells[t.SollColumn.ColumnName].Column.Index, "");
                  rowData.SetColumnError(r.Cells[t.IDKostenträgerColumn.ColumnName].Column.Index, "");


                  if (!this.sitemap .IsInExpandedGroup(r))
                      continue;

                  if (rowData.Sollkonto  == "")
                  {
                      grid.ActiveRow = r;
                      string txt = "Für die Buchung muß ein Konto erfasst werden!";
                      rowData.SetColumnError(r.Cells[t.SollkontoColumn.ColumnName].Column.Index, txt);
                      QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Buchungen speichern", MessageBoxButtons.OK);
                      return false;
                  }
                  if (rowData.Text == "")
                  {
                      grid.ActiveRow = r;
                      string txt = "Für die Buchung muß ein Buchungstext angegeben werden!";
                      rowData.SetColumnError(r.Cells[t.TextColumn.ColumnName].Column.Index, txt);
                      QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt , "Buchungen speichern", MessageBoxButtons.OK);
                      return false;
                  }
                  if (rowData.IDKostenträger == "")
                  {
                      grid.ActiveRow = r;
                      string txt = "Für die Buchung muß ein Kostenträger angegeben werden!";
                      rowData.SetColumnError(r.Cells[t.IDKostenträgerColumn.ColumnName].Column.Index, txt);
                      QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Buchungen speichern", MessageBoxButtons.OK);
                      return false;
                  }
                  if ((rowData.Soll == 0 && rowData.Haben  ==  0) ||
                     (rowData.Soll !=  0 && rowData.Haben  !=  0))
                  {
                      grid.ActiveRow  = r;
                      string txt = "Für die Buchung muß entweder ein Soll oder Haben-Betrag erfasst werden!";
                      rowData.SetColumnError(r.Cells[t.SollColumn.ColumnName].Column.Index, txt);
                      QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt , "Buchungen speichern", MessageBoxButtons.OK);
                      return false;
                  }

                  if ((string)this.form.cboKonto.Value == rowData.Sollkonto )
                  {
                      string txtKtoGKto = "Konto und Gegenkonto sind gleich!";
                      grid.ActiveRow = r;
                      rowData.SetColumnError(r.Cells[t.SollkontoColumn.ColumnName].Column.Index, txtKtoGKto);
                      QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtKtoGKto, "Buchungen speichern", MessageBoxButtons.OK);
                      return false;
                  }

              }
              return true;
        }
        public void  wirteDS(ref  UltraGrid grid)
        {
            foreach (UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, false))
            {
                PMDS.Calc.Logic.dbCalc.bookingsRow rowData = (PMDS.Calc.Logic.dbCalc.bookingsRow)((System.Data.DataRowView)r.ListObject).Row;
                if (rowData.Soll != 0 || rowData.Haben  == 0)
                {
                    rowData.Betrag = rowData.Soll ;
                    rowData.Habenkonto = rowData.Sollkonto ;
                    rowData.Sollkonto  = (string)this.form.cboKonto.Value;
                }
                else if (rowData.Soll == 0 || rowData.Haben !=  0)
                {
                    rowData.Betrag = rowData.Haben ;
                    rowData.Habenkonto  = (string)this.form.cboKonto.Value;
                }
            }
            grid.UpdateData();
        }
        public bool save(ref  PMDS.Calc.Logic.dbCalc ds, string txtQuestion, string txtHeader,  UltraGrid grid)
      {
          try
          {
                if (!this.validate (ref grid)) return false ;
                this.wirteDS(ref grid);
                DialogResult res = new DialogResult();
                res = DialogResult.Yes;
                    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtQuestion, txtHeader, MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    this._da.Update(ds.bookings );
                    this.form .loadBookings(false );
                    this.form.btnDelete.Enabled = false;

                    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungen wurden gespeichert!", "Buchungen speichern", MessageBoxButtons.OK);
                    this.setButtons(false);
                    return true;
                }
                else return false;
          }
          catch (Exception ex)
          {
              PMDS.Global.ENV.HandleException(ex);
              return false;
          }
      }
        public  void setButtons(bool on )
        {
            this.form .btnSave.Enabled = on;
            this.form.btnReset.Enabled = on;
        }

       public void loadKostenträger()
       {
           this.sitemap.loadKost(this.form.uGridBookings.DisplayLayout.ValueLists[1], (Infragistics.Win.UltraWinEditors.UltraComboEditor)this.form.cboKostenträger, ENV.IDKlinik);
       }

       public void loadKlienten()
       {
           this.sitemap.loadKlienten(this.form.uGridBookings.DisplayLayout.ValueLists[0], (Infragistics.Win.UltraWinEditors.UltraComboEditor)this.form.cboKlienten, PMDS.Global.ENV.IDKlinik, true);
       }
       public void loadEnumBookings()
       {
           this.sitemap.fillEnumKonto(this.form.uGridBookings.DisplayLayout.ValueLists["eKonto"]);
           this.sitemap.fillEnumKonto(this.form.cboKonto);
           this.form.cboKonto.Value = PMDS.Calc.Logic.eKonto.Kundenforderungen.ToString ();
       }
        
       public void add(ref PMDS.Calc.Logic.dbCalc db,  UltraGrid grid)
       {
           PMDS.Calc.Logic.dbCalc.bookingsRow r = (PMDS.Calc.Logic.dbCalc.bookingsRow)db.bookings.NewRow();

           r.ID = System.Guid.NewGuid().ToString();
           r.Betrag = 0;
           r.MWStSatz = 0;
           r.Buchungsdatum = System.DateTime.Now;
           r.Text = "";
           r.RechNr = "";
           r.Sollkonto = "";
           r.Habenkonto  = "";
           r.IDKlient = this.form .cboKlienten .Value.ToString () ;
           r.IDKostenträger = this.form.cboKostenträger.Value.ToString();
           r.ErstellAm = DateTime.Now;
           r.Erstellt = this.sitemap.usr.FullName;
           r.IDKlinik = ENV.IDKlinik;

           db.bookings.Rows.Add(r);
           grid.UpdateData();
           
           this.setButtons(true );

           this.sitemap.activateRow(ref grid, "ID", r.ID);

        }
    }
}
