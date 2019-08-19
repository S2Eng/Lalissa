using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Specialized;
using CrystalDecisions.Shared;



namespace PMDS.Print.CR
{


    public class frmPrintPreview : QS2.Desktop.ControlManagment.baseForm
    {
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.ComponentModel.Container components = null;



		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintPreview));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(925, 695);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 695);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(328, 352);
            this.Name = "frmPrintPreview";
            this.Text = "Bericht PMDS";
            this.Load += new System.EventHandler(this.frmPrintPreview_Load);
            this.ResumeLayout(false);

		}
		#endregion
        public frmPrintPreview(ReportDocument rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }
        
        private static void ExportToPDF(ReportDocument d, string file)
        {
            CrystalDecisions.Shared.DiskFileDestinationOptions crDiskFileDestinationOptions = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            CrystalDecisions.Shared.ExportOptions crExportOptions = d.ExportOptions;

            crDiskFileDestinationOptions.DiskFileName = file;
            crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
            crExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType =  CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            
            d.Export();
        }
  
        private static TextObject FindTextobjectxy(ReportDocument rInfo, string sKey)
        {
            foreach (Section s in rInfo.ReportDefinition.Sections)
            {
                foreach (ReportObject o in s.ReportObjects)
                {
                    if (o is TextObject)
                    {
                        TextObject t = (TextObject)o;
                        if (t.Name == sKey)
                            return t;
                    }
                }
            }
            return null;
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }
    }
}
