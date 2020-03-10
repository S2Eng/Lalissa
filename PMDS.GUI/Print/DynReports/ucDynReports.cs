//----------------------------------------------------------------------------
/// <summary>
/// Erstellt von RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Print;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTree;
using System.Runtime.Remoting;
using PMDS.DB;

namespace PMDS.GUI
{


    public partial class ucDynReports : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool        _UserLoggedOnPending = false;
        private bool        _Init = false;
        private string      _sBasePath = "";






        public ucDynReports()
        {
            InitializeComponent();

            dirTab1.MinTabWidth = 120;

            ENV.ENVPatientIDChanged         += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
            ENV.UserLoggedOn                += new EventHandler(ENV_UserLoggedOn);


            this.ultraPictureBoxTopRigth.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Berichte, 32, 32);
        }


        void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            if (this.Visible)
                RefreshReportList();
            else
                _UserLoggedOnPending = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Initialisiert die Liste nur zum ersten mal
        /// </summary>
        //----------------------------------------------------------------------------
        public void Init(string sPath)
        {
            if (!_Init)
            {
                _sBasePath = sPath;
                RefreshReportList();
                _Init = true;
                dirTab2.BorderStyle = BorderStyle.None;
            }
        }

        void ENV_ENVPatientIDChanged(Guid IDPatiente, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            if(this.Parent != null && this.Parent.Visible)
                RefreshParameters();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klick auf erste Hierachie
        /// </summary>
        //----------------------------------------------------------------------------
        private void dirtab1_TabClicked(DirectoryTabEventArgs args)
        {
            dirTab2.RootDirectory = args.AbsolutePath;
            RefreshClickableImages();
        }

        private void dirTab2_TabClicked(DirectoryTabEventArgs args)
        {
            RefreshClickableImages();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// den Treeview neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshReportList()
        {
            dirTab1.RootDirectory = _sBasePath;            // Tabs als Dir initialisieren
            dirTab2.RootDirectory = dirTab1.CurrentSelectedPath;
            RefreshClickableImages();
            
        }
       
        

        //----------------------------------------------------------------------------
        /// <summary>
        /// Je nach Auswahl Buttonsstate ändern
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideButtons()
        {
            btnPreview.Enabled = ucDynReportParameter1.REPORT_FILE.Length > 0;
        }

             
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die XML Datei zum Report
        /// </summary>
        //----------------------------------------------------------------------------
        public static string GetXMLFileFromReportFile(string sReportFile)
        {
            return Path.Combine(ENV.ReportConfigPath, Path.GetFileNameWithoutExtension(sReportFile) + ".config");     //<120118> Configfile von %ALLUSERSPROFILE% lesen

            return Path.Combine(ENV.ReportConfigPath, Path.GetFileNameWithoutExtension(sReportFile) + ".config");     //<120118> Configfile von %ALLUSERSPROFILE% lesen
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die JPG Datei zum Report
        /// </summary>
        //----------------------------------------------------------------------------
        public static string GetJPGFileFromReportFile(string sReportFile)
        {
            return Path.Combine(ENV.ReportPath, Path.GetFileNameWithoutExtension(sReportFile) + ".JPG");        //<120118>
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Vorschau anstoßen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool abortWindow = false;
                    Nullable<Guid> IDEinrichtungEmpfänger = null;
                    bool bSaveToArchiv = false;
                    Nullable<Guid> IDDokumenteneintrag = null;
                    ucDynReportParameter1.ProcessPreview(true, ucDynReportParameter1.REPORT_FILE, db, ref abortWindow, ref IDEinrichtungEmpfänger, ref bSaveToArchiv, ref IDDokumenteneintrag);
                    dirTab2.BorderStyle = BorderStyle.None;
                }

            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Load
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucDynReports_Load(object sender, EventArgs e)
        {
            if (!ENV.AppRunning)
                return;
        }

        

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die auszuwählenden Parameter aktualisieren / Image aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshParameters()
        {
            ucDynReportParameter1.REPORT_FILE = ucDynReportParameter1.REPORT_FILE;
        }


        private void ucDynReports_VisibleChanged(object sender, EventArgs e)
        {
            if (_UserLoggedOnPending && this.Visible)
            {
                RefreshReportList();
                _UserLoggedOnPending = false;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert bei Links die verlinkte Reportdatei bei .rpt Dateien die gleiche
        /// In der lnk datei steht der Report relativ zum Reportpfad (inkl. Extension)
        /// </summary>
        //----------------------------------------------------------------------------
        public static string GetReportFile(string sFile, ref string sConfigReturn)
        {
            string s = Path.GetExtension(sFile);
            if (s.Equals(".rpt", StringComparison.CurrentCultureIgnoreCase))
                return sFile;
            
            if (s.Equals(".dynreportlink", StringComparison.CurrentCultureIgnoreCase))
            {
                using (StreamReader reader = new StreamReader(sFile, Encoding.Default))
                {
                    string sLine = reader.ReadLine();
                    string sPath = Path.Combine(ENV.ReportPath, sLine);
                    string sConfig = reader.ReadLine();
                    if (sConfig != null)
                    {
                        sConfigReturn = sConfig.Trim();
                    }
                    if (!File.Exists(sPath))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Link Datei {0} mit dem Inhalt <{1}> ist ungültig"), sFile, sLine), true);
                        //throw new Exception(string.Format("Die Link Datei {0} mit dem Inhalt <{1}> ist ungültig", sFile, sLine));
                        return "";
                    }
                    return sPath;
                }
            }
            
            return sFile;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Clickable Images aktualisieren. Es werden alle Reports/links vom Dirtab1
        /// und dirtab2 verarbeitet
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshClickableImages()
        {
            ClickableImages.RemoveAll();
            List<string> al = new List<string>();

            AddReportFilesToList(dirTab1.CurrentSelectedPath, al);
            AddReportFilesToList(dirTab2.CurrentSelectedPath, al);
            al.Sort();

            int iCount = -1;
            foreach (string s in al)
            {
                try
                {
                    string sConfig = "";
                    string sReport = GetReportFile(s, ref sConfig);
                    if (sReport  != "")
                    {
                        iCount++;
                        string sDisplayname = "";
                        DynReportDefinition def = new DynReportDefinition("");
                        if (sConfig.Trim() == "")
                        {
                            sConfig = GetXMLFileFromReportFile(sReport);
                            sDisplayname = Path.GetFileNameWithoutExtension(sReport);

                        }
                        else
                        {
                            sConfig = Path.Combine(ENV.ReportConfigPath, sConfig);
                            sDisplayname = Path.GetFileNameWithoutExtension(sConfig);
                        }
                        
                        def.LoadFromConfig(sConfig);
                        if (def.Displayname.Length > 0)
                            sDisplayname = def.Displayname;

                        if (!def.HasUserRight(ENV.USERID))
                            continue;
                        //PMDS.GUI.Datenerhebung.ValueListItemOwn itemOwn = (PMDS.GUI.Datenerhebung.ValueListItemOwn)item; lthxy
                        ClickableImages.AddFromFile(GetJPGFileFromReportFile(sReport), sDisplayname, "", sReport, iCount, Color.LightGray, null, sConfig);
                    }
                }
                catch (Exception ex)
                {
                    ENV.HandleException(ex);
                }
            }

            lblReportInfo.Text = "";
            ucDynReportParameter1.REPORT_FILE = "";
            ShowHideButtons();
        }


        private void AddReportFilesToList(string sPath, List<string> al)
        {
            if (sPath.Length > 0)
            {
                string[] sa1 = Directory.GetFiles(sPath, "*.rpt");
                al.AddRange(sa1);
                sa1 = Directory.GetFiles(sPath, "*.dynreportlink");
                al.AddRange(sa1);
            }
        }

        private void ClickableImages_DoubleClick(int index, object Tag, string XMLFile)
        {

        }

        private void ClickableImages_Click(int index, object Tag, string XMLFile)
        {
            ucDynReportParameter1.XMLFileAlternate = XMLFile;
            ucDynReportParameter1.REPORT_FILE = "";
            ucDynReportParameter1.REPORT_FILE = Tag.ToString();

            RefreshReportInfo();
            ShowHideButtons();
        }

        private void RefreshReportInfo()
        {
            lblReportInfo.Text = "";
            lblReportInfo.Text = ucDynReportParameter1.REPORTINFO;
        }

        private void ucDynReportParameter1_ParameterChanged(object sender, EventArgs e)
        {
            RefreshReportInfo();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Entfernt das Replacerdelegate aus der Liste
        /// </summary>
        //----------------------------------------------------------------------------
        public void RemoveReplacerDelegate()
        {
            ucDynReportParameter1.RemoveReplacerDelegate();
        }

        private void ClickableImages_Load(object sender, EventArgs e)
        {

        }
        
    }
}
