namespace qs2.ui.OLAP
{
    partial class contOLAP
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            FastReport.Olap.Cube.CubeDataColumns cubeDataColumns1 = new FastReport.Olap.Cube.CubeDataColumns();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contOLAP));
            this.cube1 = new FastReport.Olap.Cube.Cube(this.components);
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.cubeGridToolbar1 = new FastReport.Olap.Controls.CubeGridToolbar();
            this.cubeGrid1 = new FastReport.Olap.Controls.CubeGrid();
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.sliceGridToolbar1 = new FastReport.Olap.Controls.SliceGridToolbar();
            this.sliceGrid1 = new FastReport.Olap.Controls.SliceGrid();
            this.slice1 = new FastReport.Olap.Slice.Slice(this.components);
            this.ultraPanel5 = new Infragistics.Win.Misc.UltraPanel();
            this.chartToolbar1 = new FastReport.Olap.Chart.ChartToolbar();
            this.chart1 = new FastReport.Olap.Chart.Chart();
            this.dtDataSet1 = new FastReport.Olap.Cube.DTDataSet();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cubeGridToolbar1)).BeginInit();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliceGridToolbar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliceGrid1.StatusZone)).BeginInit();
            this.ultraPanel5.ClientArea.SuspendLayout();
            this.ultraPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartToolbar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 416);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(839, 41);
            this.ultraPanel1.TabIndex = 0;
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraTabControl1);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(839, 416);
            this.ultraPanel2.TabIndex = 1;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(839, 416);
            this.ultraTabControl1.TabIndex = 0;
            ultraTab1.Key = "Data";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Tag = "Data";
            ultraTab1.Text = "Data";
            ultraTab2.Key = "Slice";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Tag = "Slice";
            ultraTab2.Text = "Slice";
            ultraTab3.Key = "Chart";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Tag = "Chart";
            ultraTab3.Text = "Chart";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(835, 390);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraPanel3);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(835, 390);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraPanel4);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(835, 390);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ultraPanel5);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(835, 390);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.cubeGrid1);
            this.ultraPanel3.ClientArea.Controls.Add(this.cubeGridToolbar1);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(835, 390);
            this.ultraPanel3.TabIndex = 0;
            // 
            // cubeGridToolbar1
            // 
            this.cubeGridToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cubeGridToolbar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cubeGridToolbar1.Grid = this.cubeGrid1;
            this.cubeGridToolbar1.Location = new System.Drawing.Point(0, 0);
            this.cubeGridToolbar1.Name = "cubeGridToolbar1";
            this.cubeGridToolbar1.Size = new System.Drawing.Size(835, 25);
            this.cubeGridToolbar1.Stretch = true;
            this.cubeGridToolbar1.Style = FastReport.DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cubeGridToolbar1.TabIndex = 0;
            this.cubeGridToolbar1.TabStop = false;
            this.cubeGridToolbar1.Text = "cubeGridToolbar1";
            // 
            // cubeGrid1
            // 
            // 
            // 
            // 
            this.cubeGrid1.CaptionZone.AllowDrop = true;
            this.cubeGrid1.CaptionZone.Dock = System.Windows.Forms.DockStyle.Top;
            this.cubeGrid1.CaptionZone.Location = new System.Drawing.Point(0, 0);
            this.cubeGrid1.CaptionZone.Name = "";
            this.cubeGrid1.CaptionZone.Size = new System.Drawing.Size(835, 21);
            this.cubeGrid1.CaptionZone.TabIndex = 2;
            this.cubeGrid1.Cube = this.cube1;
            // 
            // 
            // 
            this.cubeGrid1.DataZone.AllowDrop = true;
            this.cubeGrid1.DataZone.Columns = cubeDataColumns1;
            this.cubeGrid1.DataZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeGrid1.DataZone.FirstVisibleCol = 0;
            this.cubeGrid1.DataZone.FirstVisibleRow = 0;
            this.cubeGrid1.DataZone.Location = new System.Drawing.Point(0, 21);
            this.cubeGrid1.DataZone.Name = "";
            this.cubeGrid1.DataZone.Size = new System.Drawing.Size(835, 324);
            this.cubeGrid1.DataZone.TabIndex = 0;
            this.cubeGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeGrid1.FilterManager = null;
            this.cubeGrid1.Location = new System.Drawing.Point(0, 25);
            this.cubeGrid1.Name = "cubeGrid1";
            this.cubeGrid1.Size = new System.Drawing.Size(835, 365);
            this.cubeGrid1.TabIndex = 1;
            this.cubeGrid1.Text = "cubeGrid1";
            // 
            // ultraPanel4
            // 
            // 
            // ultraPanel4.ClientArea
            // 
            this.ultraPanel4.ClientArea.Controls.Add(this.sliceGrid1);
            this.ultraPanel4.ClientArea.Controls.Add(this.sliceGridToolbar1);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel4.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(835, 390);
            this.ultraPanel4.TabIndex = 0;
            // 
            // sliceGridToolbar1
            // 
            this.sliceGridToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sliceGridToolbar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sliceGridToolbar1.Grid = this.sliceGrid1;
            this.sliceGridToolbar1.Location = new System.Drawing.Point(0, 0);
            this.sliceGridToolbar1.Name = "sliceGridToolbar1";
            this.sliceGridToolbar1.Size = new System.Drawing.Size(835, 25);
            this.sliceGridToolbar1.Stretch = true;
            this.sliceGridToolbar1.Style = FastReport.DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.sliceGridToolbar1.TabIndex = 0;
            this.sliceGridToolbar1.TabStop = false;
            this.sliceGridToolbar1.Text = "sliceGridToolbar1";
            // 
            // sliceGrid1
            // 
            // 
            // 
            // 
            this.sliceGrid1.CaptionZone.AllowDrop = true;
            this.sliceGrid1.CaptionZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.CaptionZone.Location = new System.Drawing.Point(0, 0);
            this.sliceGrid1.CaptionZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.CaptionZone.Name = "";
            this.sliceGrid1.CaptionZone.Size = new System.Drawing.Size(835, 21);
            this.sliceGrid1.CaptionZone.TabIndex = 0;
            // 
            // 
            // 
            this.sliceGrid1.DataZone.AllowDrop = true;
            this.sliceGrid1.DataZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.DataZone.FirstVisibleCol = 0;
            this.sliceGrid1.DataZone.FirstVisibleRow = 0;
            this.sliceGrid1.DataZone.Images = null;
            this.sliceGrid1.DataZone.Location = new System.Drawing.Point(102, 99);
            this.sliceGrid1.DataZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.DataZone.Name = "";
            this.sliceGrid1.DataZone.Size = new System.Drawing.Size(733, 240);
            this.sliceGrid1.DataZone.TabIndex = 7;
            this.sliceGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.sliceGrid1.FieldsZone.AllowDrop = true;
            this.sliceGrid1.FieldsZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.FieldsZone.FirstVisibleItem = 0;
            this.sliceGrid1.FieldsZone.Images = null;
            this.sliceGrid1.FieldsZone.Location = new System.Drawing.Point(0, 47);
            this.sliceGrid1.FieldsZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.FieldsZone.Name = "";
            this.sliceGrid1.FieldsZone.Size = new System.Drawing.Size(102, 26);
            this.sliceGrid1.FieldsZone.TabIndex = 2;
            // 
            // 
            // 
            this.sliceGrid1.FilterFieldsZone.AllowDrop = true;
            this.sliceGrid1.FilterFieldsZone.ContainerType = FastReport.Olap.Slice.SliceContainerType.Filters;
            this.sliceGrid1.FilterFieldsZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.FilterFieldsZone.FirstVisibleItem = 0;
            this.sliceGrid1.FilterFieldsZone.Images = null;
            this.sliceGrid1.FilterFieldsZone.Location = new System.Drawing.Point(0, 21);
            this.sliceGrid1.FilterFieldsZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.FilterFieldsZone.Name = "";
            this.sliceGrid1.FilterFieldsZone.Size = new System.Drawing.Size(835, 26);
            this.sliceGrid1.FilterFieldsZone.TabIndex = 1;
            this.sliceGrid1.Location = new System.Drawing.Point(0, 25);
            this.sliceGrid1.Name = "sliceGrid1";
            this.sliceGrid1.Size = new System.Drawing.Size(835, 365);
            this.sliceGrid1.Slice = this.slice1;
            // 
            // 
            // 
            this.sliceGrid1.StatusZone.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.sliceGrid1.StatusZone.AggregateFunctions = ((System.Collections.Generic.List<FastReport.Olap.Types.AggregateFunction>)(resources.GetObject("sliceGrid1.StatusZone.AggregateFunctions")));
            this.sliceGrid1.StatusZone.BarType = FastReport.DevComponents.DotNetBar.eBarType.StatusBar;
            this.sliceGrid1.StatusZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.StatusZone.DockSide = FastReport.DevComponents.DotNetBar.eDockSide.Document;
            // 
            // 
            // 
            this.sliceGrid1.StatusZone.FloatFormat.Format = "#0.##";
            this.sliceGrid1.StatusZone.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // 
            // 
            this.sliceGrid1.StatusZone.IntegerFormat.Format = "#0.##";
            this.sliceGrid1.StatusZone.Location = new System.Drawing.Point(0, 339);
            this.sliceGrid1.StatusZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.StatusZone.MinimumSize = new System.Drawing.Size(0, 16);
            this.sliceGrid1.StatusZone.Name = "";
            this.sliceGrid1.StatusZone.Size = new System.Drawing.Size(835, 26);
            this.sliceGrid1.StatusZone.Stretch = true;
            this.sliceGrid1.StatusZone.Style = FastReport.DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.sliceGrid1.StatusZone.TabIndex = 8;
            this.sliceGrid1.StatusZone.TabStop = false;
            this.sliceGrid1.TabIndex = 1;
            this.sliceGrid1.Text = "sliceGrid1";
            // 
            // 
            // 
            this.sliceGrid1.XAxisZone.AllowDrop = true;
            this.sliceGrid1.XAxisZone.AxisAutoSize = true;
            this.sliceGrid1.XAxisZone.AxisAutoSizeConstraint = 0;
            this.sliceGrid1.XAxisZone.BottomFrame = 0;
            this.sliceGrid1.XAxisZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.XAxisZone.FirstVisibleItem = 0;
            this.sliceGrid1.XAxisZone.FirstVisibleLevel = 0;
            this.sliceGrid1.XAxisZone.Images = null;
            this.sliceGrid1.XAxisZone.Location = new System.Drawing.Point(102, 73);
            this.sliceGrid1.XAxisZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.XAxisZone.Name = "";
            this.sliceGrid1.XAxisZone.RightFrame = 17;
            this.sliceGrid1.XAxisZone.Size = new System.Drawing.Size(733, 26);
            this.sliceGrid1.XAxisZone.TabIndex = 5;
            // 
            // 
            // 
            this.sliceGrid1.XFieldsZone.AllowDrop = true;
            this.sliceGrid1.XFieldsZone.ContainerType = FastReport.Olap.Slice.SliceContainerType.XAxis;
            this.sliceGrid1.XFieldsZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.XFieldsZone.FirstVisibleItem = 0;
            this.sliceGrid1.XFieldsZone.Images = null;
            this.sliceGrid1.XFieldsZone.Location = new System.Drawing.Point(102, 47);
            this.sliceGrid1.XFieldsZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.XFieldsZone.Name = "";
            this.sliceGrid1.XFieldsZone.Size = new System.Drawing.Size(733, 26);
            this.sliceGrid1.XFieldsZone.TabIndex = 3;
            // 
            // 
            // 
            this.sliceGrid1.YAxisZone.AllowDrop = true;
            this.sliceGrid1.YAxisZone.AxisAutoSize = true;
            this.sliceGrid1.YAxisZone.AxisAutoSizeConstraint = 0;
            this.sliceGrid1.YAxisZone.BottomFrame = 17;
            this.sliceGrid1.YAxisZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.YAxisZone.FirstVisibleItem = 0;
            this.sliceGrid1.YAxisZone.FirstVisibleLevel = 0;
            this.sliceGrid1.YAxisZone.Images = null;
            this.sliceGrid1.YAxisZone.Location = new System.Drawing.Point(0, 99);
            this.sliceGrid1.YAxisZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.YAxisZone.Name = "";
            this.sliceGrid1.YAxisZone.RightFrame = 0;
            this.sliceGrid1.YAxisZone.Size = new System.Drawing.Size(102, 240);
            this.sliceGrid1.YAxisZone.TabIndex = 6;
            // 
            // 
            // 
            this.sliceGrid1.YFieldsZone.AllowDrop = true;
            this.sliceGrid1.YFieldsZone.ContainerType = FastReport.Olap.Slice.SliceContainerType.YAxis;
            this.sliceGrid1.YFieldsZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceGrid1.YFieldsZone.FirstVisibleItem = 0;
            this.sliceGrid1.YFieldsZone.Images = null;
            this.sliceGrid1.YFieldsZone.Location = new System.Drawing.Point(0, 73);
            this.sliceGrid1.YFieldsZone.Margin = new System.Windows.Forms.Padding(0);
            this.sliceGrid1.YFieldsZone.Name = "";
            this.sliceGrid1.YFieldsZone.Size = new System.Drawing.Size(102, 26);
            this.sliceGrid1.YFieldsZone.TabIndex = 4;
            // 
            // slice1
            // 
            this.slice1.Cube = this.cube1;
            // 
            // ultraPanel5
            // 
            // 
            // ultraPanel5.ClientArea
            // 
            this.ultraPanel5.ClientArea.Controls.Add(this.chart1);
            this.ultraPanel5.ClientArea.Controls.Add(this.chartToolbar1);
            this.ultraPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel5.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel5.Name = "ultraPanel5";
            this.ultraPanel5.Size = new System.Drawing.Size(835, 390);
            this.ultraPanel5.TabIndex = 0;
            // 
            // chartToolbar1
            // 
            this.chartToolbar1.Chart = null;
            this.chartToolbar1.DialogsDefaultPath = "";
            this.chartToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartToolbar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chartToolbar1.Location = new System.Drawing.Point(0, 0);
            this.chartToolbar1.Name = "chartToolbar1";
            this.chartToolbar1.Size = new System.Drawing.Size(835, 25);
            this.chartToolbar1.Stretch = true;
            this.chartToolbar1.Style = FastReport.DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.chartToolbar1.TabIndex = 0;
            this.chartToolbar1.TabStop = false;
            this.chartToolbar1.Text = "chartToolbar1";
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 25);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(835, 365);
            this.chart1.Slice = null;
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // dtDataSet1
            // 
            this.dtDataSet1.DataTable = null;
            // 
            // contOLAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ultraPanel1);
            this.Name = "contOLAP";
            this.Size = new System.Drawing.Size(839, 457);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cubeGridToolbar1)).EndInit();
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sliceGridToolbar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliceGrid1.StatusZone)).EndInit();
            this.ultraPanel5.ClientArea.ResumeLayout(false);
            this.ultraPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartToolbar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Olap.Cube.Cube cube1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private FastReport.Olap.Controls.CubeGrid cubeGrid1;
        private FastReport.Olap.Controls.CubeGridToolbar cubeGridToolbar1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        private FastReport.Olap.Controls.SliceGrid sliceGrid1;
        private FastReport.Olap.Slice.Slice slice1;
        private FastReport.Olap.Controls.SliceGridToolbar sliceGridToolbar1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Infragistics.Win.Misc.UltraPanel ultraPanel5;
        private FastReport.Olap.Chart.Chart chart1;
        private FastReport.Olap.Chart.ChartToolbar chartToolbar1;
        private FastReport.Olap.Cube.DTDataSet dtDataSet1;
    }
}
