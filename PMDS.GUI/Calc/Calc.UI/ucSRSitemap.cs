using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using PMDS.GUI.BaseControls;
using Infragistics.Win.Misc;
using PMDS.Global;
using PMDS.UI.Sitemap;
using PMDS.Global.db.Patient;



namespace PMDS.Calc.UI
{
    public class ucSRSitemap : QS2.Desktop.ControlManagment.BaseControl
        {

            public PMDS.UI.Sitemap.UIFct sitemap;
            public PMDS.Calc.UI.ucSR form;

            public PMDS.Calc.Logic.calculation calculation;
            public PMDS.Calc.Logic.Sql sql;
            public PMDS.Calc.Logic.calcBase calcBase;
            public PMDS.Calc.UI.ucCalcsSitemap ucCalcsSitemap;

            public bool searchMode = false;
            public bool isLoaded = false;




            public void initControl(ref PMDS.Calc.UI.ucSR cont )
            {
                try
                {
                    if (this.isLoaded) return;

                    this.form = cont;
                    this.sql = new  PMDS.Calc.Logic.Sql() ;
                    this.calcBase = new PMDS.Calc.Logic.calcBase();
                    this.sitemap = new UIFct();

                    PMDS.Calc.Logic.bill bill = new PMDS.Calc.Logic.bill();
                    this.form .uiSiteMapForm  = this;
                    cont.initControl();
                    
                    this.ucCalcsSitemap = new PMDS.Calc.UI.ucCalcsSitemap();
                    this.ucCalcsSitemap.initControl(this.form.ucCalcs2, false, ucCalcsSitemap.eTyp .sr,false  );
                    PMDS.Global.ENV.evklinikChanged += new PMDS.Global.klinikChanged(this.klinikChanged);

                    this.isLoaded = true;
                }
                catch (Exception ex)
                {
                    PMDS.Global.ENV.HandleException(ex);
                }
            }
            public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
            {
                this.clearData();
                //this.form.loadData((DateTime)this.form.dtMonat.Value);
            }

            public void clearData()
            {
                this.form.dbPMDS1.Clear();
                this.form.dbKostSelect.Clear();
                this.form.cbKostenträger.Items.Clear();
                this.ucCalcsSitemap.IDKost = "";

                DateTime monat = new DateTime();
                this.sql.alleAllgKostSR(this.form.dbPMDS1, ref  monat, "", ENV.IDKlinik);
                this.form.ucCalcs2.uiSiteMapForm.clearCalcs();
            }
            public void loadData(UltraGrid grid, ref QS2.Desktop.ControlManagment.BaseComboEditor cbo, ref PMDS.Calc.Logic.dbPMDS db, ref PMDS.Calc.Logic.dbPMDS dbGrid, DateTime monat)
            {
                db.Clear();
                dbGrid.Clear();
                cbo.Items.Clear();
                this.ucCalcsSitemap.IDKost = "";
                //cbo.Items.Add(Guid.Empty, " ");
                grid.DisplayLayout.Bands[0].Columns["Name"].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger");

                this.sql.alleAllgKostSR(db, ref  monat, "", ENV.IDKlinik);
                foreach (PMDS.Calc.Logic.dbPMDS.KostentraegerRow rKost in db.Kostentraeger)
                {
                    Infragistics.Win.ValueListItem item = cbo.Items.Add(rKost.ID, rKost.Name );
                }
                if (cbo.Items.Count > 0)
                {
                    cbo.SelectedItem = cbo.Items[0];
                    this.fillGrid((Infragistics.Win.UltraWinGrid.UltraGrid)grid, ref dbGrid, monat, cbo.Items[0].DataValue.ToString());
                }
            }
            
            public void fillGrid(UltraGrid grid, ref PMDS.Calc.Logic.dbPMDS dbGrid, DateTime monat, string IDKost)
            {
                dbGrid.Clear();
                this.ucCalcsSitemap.IDKost = "";
                
                DateTime von = new DateTime(monat.Year, monat.Month, 1);
                //DateTime bis = new DateTime(monat.Year, monat.Month, this.tools.monatsende(monat).Day);
                this.sql.alleAllgKostSR_Klienten(ref dbGrid, ref von, IDKost,ENV.IDKlinik);
                grid.Refresh();
                
                this.ucCalcsSitemap.IDKost = IDKost;
                
                grid.DisplayLayout.Bands[0].Columns["Name"].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger   (Anzahl Klienten:") + dbGrid.Patient .Rows .Count.ToString ()  + ")";
                grid.DisplayLayout.Bands[1].Columns["Sollstand"].Hidden = false;
                grid.DisplayLayout.Bands[1].Columns["Sollstand"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
                grid.DisplayLayout.Bands[1].Columns["Sollstand"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grid.DisplayLayout.Bands[1].Columns["Sollstand"].Header.Caption = "Betrag";

                grid.DisplayLayout.Bands[0].SortedColumns.Clear();
                grid.DisplayLayout.Bands[1].SortedColumns.Clear();
                grid.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);
                grid.DisplayLayout.Bands[1].SortedColumns.Add("Nachname", false);
                
                grid.Rows.ExpandAll(true);
            }
        }
}
