using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.UltraChart.Shared.Styles;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Resources;
using System.IO;
using System.Collections;
using Infragistics.UltraChart.Core;
using Infragistics.UltraChart.Core.Primitives;
using QS2.Resources;



namespace qs2.Queries.KaplanMeier
{
     

    
    public partial class contChartKaplanMeier : UserControl
    {
        public qs2.core.license.doLicense.eApp Application;
        public string IDParticipant = "ALL";

        // Input for Chart-Calculating
        //public System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunningxy = new System.Collections.Generic.List<qs2.ui.print.infoQry>();
        // Result Chart
        public DataSet dsResult = new DataSet();

        public qs2.sitemap.queries.dbKaplanMeier dbKaplanMeier1 = new qs2.sitemap.queries.dbKaplanMeier();
        public qs2.sitemap.queries.KaplanMeier KaplanMeier1 = new qs2.sitemap.queries.KaplanMeier();
        //public qs2.Queries.KaplanMeier.ucInputKaplanMeier _ucInputKaplanMeier1 = null;
        public DataTable _t = null;
        public qs2.ui.print.infoQry infoQryRunPar = null;

        public bool _LostToFUP = false;

        public bool isLoaded = false;






        public contChartKaplanMeier()
        {
            InitializeComponent();
        }

        private void contChart_Load(object sender, EventArgs e)
        {
        }

        public  void initControl()
        {
            try
            {
                if (this.isLoaded)
                    return;

                this.btnPrintChart.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken , 32, 32);
                this.btnPrintChart.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("Print");

                this.neuLadenToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
                this.neuLadenToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Reload");

                //this.showDataToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ShowChartData");
                //lth Translations für Chart-Anzeige einbauen (Übersetzte Ressourcen einfügen!)

                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        

        public void drawKaplanMeier(DataTable t)
        {
            try
            {
                this._t = t;
                //this._ucInputKaplanMeier1 = ucInputKaplanMeier1;

                int Ereignis = 0;
                int Beobachtungszeitraum = 0;       //System.Convert.ToInt32(this._ucInputKaplanMeier1.fldKM_Beobachtungszeitraum.Value);
                int Konfidenzband = 0;              // System.Convert.ToInt32(this._ucInputKaplanMeier1.fldKM_Konfidenzband.Value);
                double KM_Alpha = 0;                //System.Convert.ToInt32(this._ucInputKaplanMeier1.fldKM_Alpha.Value);
                //bool LostToFUP = false;             // this._ucInputKaplanMeier1.fldKM_LostToFUP.Checked;

                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rParFound in this.infoQryRunPar.dsParFctForQuery.tblQueriesDef.Rows)
                {
                    //  "KM_EventGroup_Vascular"  keine Verwendung
                    if (rParFound.QryColumn.Trim().ToLower() == ("KM_Period").Trim().ToLower())
                    {
                        if (rParFound.ValueMin.Trim()!= "")
                        {
                            Beobachtungszeitraum = System.Convert.ToInt32(rParFound.ValueMin.Trim());
                        }
                    }
                    else if (rParFound.QryColumn.Trim().ToLower() == ("KM_ConfidenceBand").Trim().ToLower())
                    {
                        if (rParFound.ValueMin.Trim() != "")
                        {
                            Konfidenzband = System.Convert.ToInt32(rParFound.ValueMin.Trim());
                        }
                    }
                    else if (rParFound.QryColumn.Trim().ToLower() == ("KM_Alpha").Trim().ToLower())
                    {
                        if (rParFound.ValueMin.Trim() != "")
                        {
                            KM_Alpha = System.Convert.ToDouble(rParFound.ValueMin.Trim(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                    }
                    else if (rParFound.QryColumn.Trim().ToLower() == ("KM_ShowLostToFollowUp").Trim().ToLower())
                    {
                        if (rParFound.ValueMin.Trim().ToLower().Equals(("1").Trim().ToLower()))
                        {
                            this._LostToFUP = true;
                        }
                    }
                    else if (rParFound.QryColumn.Trim().ToLower() == ("KM_EventGroup_Vascular").Trim().ToLower())
                    {
                        Ereignis = System.Convert.ToInt32(rParFound.ValueMin.Trim());
                    }
                }

                this.dsKaplanMeier1.Clear();
                DataRow[] arrRows = this.dbKaplanMeier1.getInputListe(qs2.core.license.doLicense.rParticipant.IDParticipant, ref t);
                foreach (DataRow r in arrRows)
                {
                    qs2.core.vb.dsKaplanMeier.KMInputRow rowKM = KaplanMeier1.newRowKMInput(this.dsKaplanMeier1);

                    rowKM.PatExtID = System.Convert.ToString(r["PatExtID"]); 
                    rowKM.FUPEreignis = Ereignis;   // Event nach Sql oder InputPar
                    rowKM.PatFirstname = System.Convert.ToString(r["FirstName"]).Trim();
                    rowKM.PatLastname = System.Convert.ToString(r["LastName"]).Trim(); 

                    if (r["DOB"] != System.DBNull.Value)
                    {
                        rowKM.PatDOB = (DateTime)r["DOB"];  
                    }
                    if (r["SurgDtStart"] != System.DBNull.Value)
                    {
                        rowKM.SurgDtStart = (DateTime)r["SurgDtStart"];
                    }
                    if (r["FUPDt"] != System.DBNull.Value)
                    {
                        rowKM.FUPDt = (DateTime)r["FUPDt"];
                    }

                }

                if (this.dsKaplanMeier1.KMInput.Rows.Count > 0)
                {
                    this.lblNoRowsFound.Visible = false;
                    this.gridBagLayoutPanelChart.Visible = true;
                    this.ultraChart1.Visible = true;

                    this.KaplanMeier1.calc(ref this.dsKaplanMeier1, Beobachtungszeitraum, Konfidenzband, KM_Alpha / 100.0);
                    this.runChart(ref ultraChart1, ref this.dsKaplanMeier1, Konfidenzband, Beobachtungszeitraum, this._LostToFUP);
                }
                else
                {
                    this.gridBagLayoutPanelChart.Visible = false;
                    this.lblNoRowsFound.Visible = true;
                    this.ultraChart1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void runChart(ref Infragistics.Win.UltraWinChart.UltraChart chart, ref qs2.core.vb.dsKaplanMeier dsKM, 
                                int Konfidenzband, int Beobachtungszeitraum, bool ShowLostToFUP)
        {

            chart.Series.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("value1", typeof(double));
            dt.Columns.Add("date2", typeof(DateTime));
            dt.Columns.Add("value2", typeof(double));
            dt.Columns.Add("date3", typeof(DateTime));
            dt.Columns.Add("value3", typeof(double));

            int cntRow = 0;
            double cHallWellnerMin = 0;
            double cHallWellnerMax = 0;
            double cKolmogoroffMin = 0;
            double cKolmogoroffMax = 0;
            int ctk = 0;
            double S = 0.0;

            foreach (qs2.core.vb.dsKaplanMeier.KMResultRow rowR in dsKM.KMResult.Rows)
            {
                cntRow += 1;

                if (cntRow < dsKM.KMResult.Rows.Count)
                {
                    cHallWellnerMin = rowR.HallWellnerMin;
                    cHallWellnerMax = rowR.HallWellnerMax;
                    cKolmogoroffMin = rowR.KolmogoroffMin;
                    cKolmogoroffMax = rowR.KolmogoroffMax;
                    ctk = rowR.tk;
                }
                else
                {
                    ctk += 4;
                }

                S = rowR.S;

                if (Konfidenzband == 1)
                {
                    dt.Rows.Add(new object[] { DateTime.Now.AddDays(rowR.tk), rowR.S, DateTime.Now.AddDays(ctk), cKolmogoroffMin, DateTime.Now.AddDays(ctk), cKolmogoroffMax });
                }
                else
                {
                    dt.Rows.Add(new object[] { DateTime.Now.AddDays(rowR.tk), rowR.S, DateTime.Now.AddDays(ctk), cHallWellnerMin, DateTime.Now.AddDays(ctk), cHallWellnerMax });
                }
            }

            // Kurve abschließen
            if (ShowLostToFUP)
            {
                if (Konfidenzband == 1)
                {
                    dt.Rows.Add(new object[] { DateTime.Now.AddDays(this.KaplanMeier1.MaxDifferenz), S, DateTime.Now.AddDays(ctk), cKolmogoroffMin, DateTime.Now.AddDays(ctk), cKolmogoroffMax });
                }
                else
                {
                    dt.Rows.Add(new object[] { DateTime.Now.AddDays(this.KaplanMeier1.MaxDifferenz), S, DateTime.Now.AddDays(ctk), cHallWellnerMin, DateTime.Now.AddDays(ctk), cHallWellnerMax });
                }
            }

            chart.ChartType = ChartType.StepLineChart;
            chart.LineChart.Thickness = 2;
            chart.LineChart.MidPointAnchors = false;
            chart.Data.ZeroAligned = true;

            chart.Axis.Y.RangeType = AxisRangeType.Custom;
            chart.Axis.Y.RangeMax = 1;
            chart.Axis.Y.RangeMin = 0;
            chart.Axis.Y.Labels.ItemFormat = AxisItemLabelFormat.Custom;
            chart.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:0.0>";

            Color[] colors = new Color[] { Color.Blue, Color.Gray, Color.Gray };
            chart.ColorModel.ModelStyle = ColorModels.CustomLinear;
            chart.ColorModel.CustomPalette = colors;

            chart.Axis.X.RangeMin = System.DateTime.Now.Ticks;
            chart.Axis.X.RangeMax = System.DateTime.Now.AddYears(Beobachtungszeitraum).Ticks;
            chart.Axis.X.RangeType = AxisRangeType.Custom;

            chart.Axis.X.TickmarkStyle = AxisTickStyle.DataInterval;
            chart.Axis.X.TimeAxisStyle.TimeAxisStyle = RulerGenre.Continuous;
            chart.Axis.X.Labels.ItemFormat = AxisItemLabelFormat.Custom;
            chart.LineChart.TreatDateTimeAsString = true;
            chart.Axis.X.TickmarkIntervalType = AxisIntervalType.Years;
            chart.Axis.X.TickmarkStyle = AxisTickStyle.DataInterval;
            chart.Axis.X.TickmarkInterval = (double)1;
            chart.LineChart.EndStyle = LineCapStyle.Flat;
            chart.Axis.X.Labels.Orientation = TextOrientation.Horizontal;

            chart.Tooltips.FormatString = "<DATA_VALUE:0.###>";

            Hashtable labelHash = new Hashtable();
            labelHash.Add("CUSTOM", new MyLabelRenderer());
            chart.LabelHash = labelHash;
            chart.Axis.X.Labels.ItemFormatString = "<CUSTOM>";

            NumericTimeSeries series1 = new NumericTimeSeries();
            series1.Data.DataSource = dt;
            series1.Data.TimeValueColumn = "date";
            series1.Data.ValueColumn = "value1";
            series1.Label = "KM 1";
            ultraChart1.Series.Add(series1);

            NumericTimeSeries series2 = new NumericTimeSeries();
            series2.Data.DataSource = dt;
            series2.Data.TimeValueColumn = "date2";
            series2.Data.ValueColumn = "value2";
            series2.Label = "KB 1";
            ultraChart1.Series.Add(series2);

            NumericTimeSeries series3 = new NumericTimeSeries();
            series3.Data.DataSource = dt;
            series3.Data.TimeValueColumn = "date3";
            series3.Data.ValueColumn = "value3";
            series3.Label = "KB 2";
            ultraChart1.Series.Add(series3);

            series1.DataBind();
            series2.DataBind();
            series3.DataBind();

            chart.TitleTop.Text = "Kaplan-Meier Kurve (n=" + dsKM.KMRangListe.Count.ToString() + ") - " + ((Konfidenzband == 1) ? "Kolmogoroff Konfidenzband" : "Hall-Wellner Konfidenzband");
            chart.TitleTop.HorizontalAlign = StringAlignment.Center;
            chart.TitleTop.FontSizeBestFit = true;

            chart.TitleLeft.Text = "Wahrscheinlichkeit S(t)";
            chart.TitleLeft.Visible = true;
            chart.TitleLeft.HorizontalAlign = StringAlignment.Center;
            chart.TitleLeft.Margins.Left = 5;

            chart.TitleBottom.Text = "Zeit in Jahren";
            chart.TitleBottom.Visible = true;
            chart.TitleBottom.Margins.Bottom = 5;
            chart.TitleBottom.HorizontalAlign = StringAlignment.Center;

            chart.Axis.X.Extent = 10;
            chart.Axis.Y.Extent = 15;

        }

        private void ultraChart1_FillSceneGraph(object sender, Infragistics.UltraChart.Shared.Events.FillSceneGraphEventArgs e)
        {
            int x, y;
            Line l;

            if (e.Grid.Count == 0) return;

            IAdvanceAxis xAxis = (IAdvanceAxis)e.Grid["X"];
            IAdvanceAxis yAxis = (IAdvanceAxis)e.Grid["Y"];

            if (this._LostToFUP)
            {
                foreach (qs2.core.vb.dsKaplanMeier.KMChartZensiertRow row in this.dsKaplanMeier1.KMChartZensiert.Rows)
                {
                    x = (int)xAxis.Map(DateTime.Now.AddDays(row.Differenz));
                    y = (int)yAxis.Map(row.S);

                    l = new Line();
                    l.p1 = new Point(x, y - 3);
                    l.p2 = new Point(x, y + 3);
                    l.PE.Stroke = Color.Red;

                    e.SceneGraph.Add(l);

                }
            }
            MyLabelRenderer.counter = -1;
        }

        public void printChart()
        {
            System.Drawing.Printing.PrinterSettings print = new System.Drawing.Printing.PrinterSettings();
            System.Drawing.Printing.PageSettings page = new System.Drawing.Printing.PageSettings();

            page.Landscape = true;
            print.DefaultPageSettings.Landscape = true;
            ultraChart1.PrintChart(print, page);

        }

        private void neuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.drawKaplanMeier(this._t);
                //this.drawKaplanMeier(this._ucInputKaplanMeier1, this._t);

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPrintChart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.printChart();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.ui.print.frmTable frmTable1 = new qs2.ui.print.frmTable();
                frmTable1.contTable1.infoQryRunPar = this.infoQryRunPar;
                frmTable1.contTable1.noChart = true;
                frmTable1.selectDatasets = true;
                System.Collections.ArrayList lstDatasets = new System.Collections.ArrayList();
                lstDatasets.Add(this.dsKaplanMeier1);
                frmTable1.lstDatasets = lstDatasets;
                frmTable1.IDParticipant = this.infoQryRunPar.Participant;
                frmTable1.IDApplication = this.infoQryRunPar.Application;
                string protocol = "";
                frmTable1.initControl(ui.print.contTable.eTypeUI.History, ref protocol, false);
                frmTable1.contTable1.tabMain.SelectedTab = frmTable1.contTable1.tabMain.Tabs[0];
                frmTable1.contTable1.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                qs2.core.ENV.lstOpendChildForms.Add(frmTable1);
                frmTable1.Show();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }


    public class MyLabelRenderer : IRenderLabel
    {
        public static int counter = -1;
        public string ToString(Hashtable context)
        {
            counter++;
            return counter.ToString();
        }
    }

}
