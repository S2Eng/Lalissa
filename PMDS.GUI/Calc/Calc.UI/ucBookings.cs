using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.UI.Sitemap;
using Infragistics.Win.Misc;



namespace PMDS.Calc.UI
{
    public partial class ucBookings : QS2.Desktop.ControlManagment.BaseControl
    {
        public PMDS.Calc.UI.ucBookingsSitemap uiSiteMapForm;
        public PMDS.Calc.Logic.calcBase calcBase;
        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();



        public ucBookings()
        {
            InitializeComponent();
        }

        public void  initControl( )
        {
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.setUITimeActMonth();
            this.setUI();
            this.InitTimeContextMenu();

            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();
        }
        public void setUITimeActMonth()
        {
            this.dtVon.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.calcBase = new PMDS.Calc.Logic.calcBase();
            this.dtBis.Value = calcBase.monatsende(DateTime.Now);
        }
         private void InitTimeContextMenu()
        {
            this.uiSiteMapForm.sitemap.initTimeContextMenu();
            foreach (MenuItem item in this.uiSiteMapForm.sitemap.timemenu.MenuItems)
            {
                item.Click += new EventHandler(Timeitem_Click);
            }
        }

        public void loadBookings (  bool init )
        { 
              try
              {
                  this.Cursor = Cursors.WaitCursor;

                  this.dbPMDS1.Clear();
                  this.checkUIDate();
                  if (!this.checkConboSel()) return;
                  string idKlientLoad = "";
                  if (init )
                      idKlientLoad = System.Guid .NewGuid ().ToString ();
                  else
                        idKlientLoad = (string )this.cboKlienten.Value == "" ? "": this.cboKlienten .Value.ToString ();

                  this.uiSiteMapForm.sitemap.refreshAuswahlGrp(this.cboBezeichnungstexte, "BUT");
                  //this.uiSiteMapForm.initSelection();

                  this.uiSiteMapForm.loadBookings(ref this.dbPMDS1, this.dtVon.DateTime, this.dtBis.DateTime,  this.uGridBookings,
                                                    (UltraLabel)this.lblCount,
                                                    idKlientLoad,
                                                     (string )this.cboKostenträger .Value == "" ? "": this.cboKostenträger .Value.ToString (),
                                                      (string )this.cboKonto.Value == "" ? "" : this.cboKonto.Value.ToString(), this.txtText .Text ); 
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
         public bool checkConboSel()
         {
            if (this.cboKlienten.Value.ToString().Trim() != "")
            {
                string sValue = this.cboKlienten.Value.ToString();
                Guid gValue;
                if (!Guid.TryParse(sValue, out gValue))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klienten: Auswahl erforderlich!", "");
                    this.cboKlienten.Focus();
                    return false;
                }
            }
            if (!this.uiSiteMapForm.sitemap.checkCombo(this.cboKlienten, true, true)) return false;

            if (this.cboKostenträger.Value.ToString().Trim() != "")
            {
                string sValue = this.cboKostenträger.Value.ToString();
                Guid gValue;
                if (!Guid.TryParse(sValue, out gValue))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kostenträger: Auswahl erforderlich!", "");
                    this.cboKostenträger.Focus();
                    return false;
                }
            }
             if (!this.uiSiteMapForm.sitemap.checkCombo(this.cboKostenträger, true, true)) return false;

             if (!this.uiSiteMapForm.sitemap.checkCombo(this.cboKonto, true, true)) return false;

             return true;
         }
        private bool validateUI(bool info)
        {
            this.checkUIDate();
            return true;
        }
        public void checkUIDate()
        {
            if (this.dtVon.Value == null || this.dtBis.Value == null)
            {
                this.dtVon.DateTime = DateTime.Now;
                this.dtBis.DateTime = DateTime.Now;
            }
            if (this.dtBis.DateTime < this.dtVon.DateTime)
                this.dtBis.DateTime = this.dtVon.DateTime;
        }

        public void setUI( )
        {

        }
        public void doAction22(PMDS.UI.Sitemap.eAction typ, string txtQuestion, string txtInfo, bool msgBox)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.uiSiteMapForm.doAction22(typ, txtQuestion, txtInfo, (UltraGrid)this.uGridBookings, this.lblCount, msgBox);
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
        
        private void uGridAbrech_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if ( e.Cell .Row .IsAddRow)  return;

            if (e.Cell.Column.ToString() == "Erstellt" || e.Cell.Column.ToString() == "ErstellAm")
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit  ;
            else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
        }
        
        private void dtVon_Enter(object sender, EventArgs e)
        {
            this.dtVon.SelectAll();
        }
        private void dtBis_Enter(object sender, EventArgs e)
        {
            this.dtBis.SelectAll();
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
            this.loadBookings(false);
        }

        private void ucCalcs_Resize(object sender, EventArgs e)
        {
            this.resizeControl();
        }
        private void resizeControl()
        {
            if (this.ucprint1 != null ) this.ucprint1.ResizeControl(this.panelBookings.Width, this.panelBookings.Height);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.doAction22(eAction.delete, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Buchungen wirklich löschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungen wurden gelöscht!"), true);
                this.btnDelete.Enabled = false;
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

        private void dtVon_Leave(object sender, EventArgs e)
        {
        }
        private void dtBis_Leave(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.print();
        }

        private void print()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!this.checkConboSel()) return;
                this.uiSiteMapForm.printList(ref this.dbPMDS1, this.dtVon.DateTime, this.dtBis.DateTime, (string)this.cboKonto.Value);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.add();     
        }

        private void add()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!this.checkConboSel()) return;
                this.uiSiteMapForm.add(ref this.dbPMDS1, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridBookings);
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

        private void ucSave_Click(object sender, EventArgs e)
        {
            this.uiSiteMapForm.save(ref this.dbPMDS1, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Buchungen wirklich speichern?"), 
                                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungen speichern"), 
                                    (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridBookings);
        }

        private void auswahlNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.uiSiteMapForm.initSelection();
            this.Cursor = Cursors.Default;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.loadBookings(false);
        }

        private void uGridBookings_CellChange(object sender, CellEventArgs e)
        {
            this.uiSiteMapForm.setButtons(true);
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            this.loadBookings(false);
        }

        private void uGridBookings_AfterRowActivate(object sender, EventArgs e)
        {
            this.btnDelete.Enabled = true;
        }

        private void uGridBookings_BeforeRowActivate(object sender, RowEventArgs e)
        {
            //e.Row.Selected = true;
            if (this.uGridBookings.DisplayLayout.UIElement.LastElementEntered != null)
            {
                if (uGridBookings.DisplayLayout.UIElement.LastElementEntered.GetType() == typeof(Infragistics.Win.UltraWinGrid.RowSelectorUIElement))
                {
                    //this.btnDelete.Enabled = true;
                }
            }
        }

        private void uGridBookings_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {

        }

        private void uGridBookings_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            
        }

        private void uGridBookings_AfterRowInsert(object sender, RowEventArgs e)
        {
            //e.Row.Cells["Soll"].Value = (decimal)0;
            //e.Row.Cells["Haben"].Value = (decimal)0;
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            this.resizeControl();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.loadBookings(false);
        }


        private void uGridBookings_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (uGridBookings.Focused )
                e.Cancel = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!this.checkConboSel()) return;
                this.export.exportGrid(this.uGridBookings, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "", "");
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


        private void cboKonto_Leave(object sender, EventArgs e)
        {
            //if (this.cboKonto.Focused) this.loadBookings(false);
        }
        private void cboKostenträger_Leave(object sender, EventArgs e)
        {
            //if (this.cboKostenträger.Focused) this.loadBookings(false);
        }
        private void cboKlienten_Leave(object sender, EventArgs e)
        {
            //if (this.cboKlienten.Focused) this.loadBookings(false);
        }

        private void cboBezeichnung_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            this.uiSiteMapForm.sitemap.openFormAuswahlGrp(this.cboBezeichnungstexte, "BUT");
        }


        private void uGridBookings_DoubleClick(object sender, EventArgs e)
        {

        }
        private void uGridBookings_BeforeRowRegionScroll(object sender, BeforeRowRegionScrollEventArgs e)
        {
            this.uiSiteMapForm.sitemap.evBeforeRowRegionScrollAuto(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridBookings);
        }

        private void lblZurücksetzen_Click(object sender, EventArgs e)
        {
           try
            {
                this.Cursor = Cursors.WaitCursor;

                this.uiSiteMapForm.initSelection();
                this.txtText.Text = "";
                this.cboKostenträger.Value  = "";
                this.cboKlienten.Value = "";
                this.setUITimeActMonth();
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

        private void cboKostenträger_Enter(object sender, EventArgs e)
        {
            this.cboKostenträger.SelectAll();
        }
        private void cboKonto_Enter(object sender, EventArgs e)
        {
            this.cboKonto.SelectAll();
        }

        private void cboKlienten_Enter(object sender, EventArgs e)
        {
            this.cboKlienten.SelectAll();
        }



    }
}
