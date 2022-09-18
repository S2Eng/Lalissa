using Infragistics.Documents.Excel;
using qs2.core.db.ERSystem;
using PMDS.db.Entities;
using S2Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qs2.ui.ManageDeathStatus
{

    public partial class contManageDeathStatusExcel : UserControl
    {
        public frmManageDeathStatusExcel ContMain { get; set; }

        private string ImportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string ImportFile = "StatistikAustria.xlsx";

        private StringBuilder sbLog = new StringBuilder();
        private StringBuilder sbErr = new StringBuilder();

        Workbook wb = new Workbook();
        Worksheet ws;

        int rowMax;
        int cellMax;

        private string StrOpenFile = "";
        private string StrFileNotFound = "";
        private readonly List<KeyValuePair<int, string>> ListColumns = new List<System.Collections.Generic.KeyValuePair<int, string>>();

        private bool bRunning;

        public contManageDeathStatusExcel()
        {
            InitializeComponent();
        }

        public bool InitControl()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                btnStart.Text = qs2.core.language.sqlLanguage.getRes("Run");
                StrFileNotFound = qs2.core.language.sqlLanguage.getRes("FileDoesNotExist");
                StrOpenFile = qs2.core.language.sqlLanguage.getRes("OpenDeathStatusXLSX");
                
                lblLastName.Text = qs2.core.language.sqlLanguage.getRes("LastName");
                lblFirstName.Text = qs2.core.language.sqlLanguage.getRes("FirstName");
                lblDOB.Text = qs2.core.language.sqlLanguage.getRes("DOB");
                lblDayDOB.Text = qs2.core.language.sqlLanguage.getRes("Day");
                lblMonthDOB.Text = qs2.core.language.sqlLanguage.getRes("Month");
                lblYearDOB.Text = qs2.core.language.sqlLanguage.getRes("Year");     
                lblGender.Text = qs2.core.language.sqlLanguage.getRes("Gender");

                lblDOD.Text = qs2.core.language.sqlLanguage.getRes("MtDate");
                lblDayDOD.Text = qs2.core.language.sqlLanguage.getRes("Day");
                lblMonthDOD.Text = qs2.core.language.sqlLanguage.getRes("Month");
                lblYearDOD.Text = qs2.core.language.sqlLanguage.getRes("Year");
                lblICD9.Text = qs2.core.language.sqlLanguage.getRes("ICD9");

                lblAdvice.Text = qs2.core.language.sqlLanguage.getRes("DeathStatusImport.Advice", false);
                lblDatabase.Text = qs2.core.language.sqlLanguage.getRes("DatabaseFields"); 
                lblExcel.Text = qs2.core.language.sqlLanguage.getRes("ExcelFields");  
            }

            if (ReadHeader())
            {
                pnlAssignment.Enabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadHeader()
        {
            try
            {
                FileDialog fdOpen = new OpenFileDialog();
                fdOpen.Filter = "xlsx|" + "*.xlsx";
                fdOpen.InitialDirectory = ImportPath;
                fdOpen.FileName = ImportFile;
                fdOpen.Title = StrOpenFile;
                DialogResult res = fdOpen.ShowDialog();

                if (res == DialogResult.OK)
                {
                    ImportPath = Path.GetDirectoryName(fdOpen.FileName);
                    ImportFile = Path.GetFileName(fdOpen.FileName);
                    if (!File.Exists(fdOpen.FileName))
                    {
                        MessageBox.Show(StrFileNotFound, fdOpen.FileName, MessageBoxButtons.OK);
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                //Datei öffnen, erste Zeile einlesen und Felder für Zuordnung bereitstellen
                wb = Workbook.Load(Path.Combine(ImportPath, ImportFile));
                ws = wb.Worksheets[0];

                //Heder einlesen und in Liste speichern
                int row = 0;
                rowMax = ws.Rows.Count() - 1;
                cellMax = ws.Rows[0].Cells.Count();

                for (int cell = 0; cell < cellMax; cell++)
                {
                    ListColumns.Add(new KeyValuePair<int, string>(cell, ws.Rows[row].Cells[cell].Value.ToString()));
                }

                FillCbo(cboLastName, 0);
                FillCbo(cboFirstName, 1);
                FillCbo(cboDayDOB, 2);
                FillCbo(cboMonthDOB, 3);
                FillCbo(cboYearDOB, 4);
                FillCbo(cboGender, 5);
                FillCbo(cboDayDOD, 9);
                FillCbo(cboMonthDOD, 8);
                FillCbo(cboYearDOD, 7);
                FillCbo(cboICD9, 11);

                return true;
            }

            catch (Exception ex) 
            {
                sbErr.Append("Error in ReadHeader: " + ex.Message + "\n");
                CleanUp();
                return false;
            }
        }

        private void FillCbo(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, int iDefault)
        {
            try
            {
                cbo.Clear();
                foreach (KeyValuePair<int, string> cellheader in ListColumns)
                {
                    cbo.Items.Add(cellheader.Key, cellheader.Value);
                }
                cbo.SelectedIndex = iDefault;
            }
            catch (Exception ex)
            {
                sbErr.Append("Error in FillCbo: " + ex.Message + "\n");
                CleanUp();
            }
        }

        private void contManageDeathStatusExcel_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                bRunning = qs2.core.generic.FrmProgressInit(0, rowMax, "Init ...");

                sbLog.Clear();
                sbErr.Clear();

                for (int row = 1; row <= rowMax; row++)
                {
                    string LastName = ws.Rows[row].Cells[cboLastName.SelectedIndex].Value.ToString();
                    string FirstName = ws.Rows[row].Cells[cboFirstName.SelectedIndex].Value.ToString();
                    string YearDOB = ws.Rows[row].Cells[cboYearDOB.SelectedIndex].Value.ToString();
                    string MonthDOB = ws.Rows[row].Cells[cboMonthDOB.SelectedIndex].Value.ToString();
                    string DayDOB = ws.Rows[row].Cells[cboDayDOB.SelectedIndex].Value.ToString();
                    string sGender = ws.Rows[row].Cells[cboGender.SelectedIndex].Value.ToString();
                    string YearDOD = ws.Rows[row].Cells[cboYearDOD.SelectedIndex].Value.ToString();
                    string MonthDOD = ws.Rows[row].Cells[cboMonthDOD.SelectedIndex].Value.ToString();
                    string DayDOD = ws.Rows[row].Cells[cboDayDOD.SelectedIndex].Value.ToString();
                    string ICD9 = ws.Rows[row].Cells[cboICD9.SelectedIndex].Value.ToString();

                    if (!String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(FirstName) &&
                        !String.IsNullOrWhiteSpace(YearDOB) && !String.IsNullOrWhiteSpace(MonthDOB) && !String.IsNullOrWhiteSpace(DayDOB) &&
                        !String.IsNullOrWhiteSpace(sGender) &&
                        !String.IsNullOrWhiteSpace(YearDOD) && !String.IsNullOrWhiteSpace(MonthDOD) && !String.IsNullOrWhiteSpace(DayDOD) &&
                        !String.IsNullOrWhiteSpace(ICD9))
                    {
                        DateTime DOB = new DateTime(Convert.ToInt32(ws.Rows[row].Cells[cboYearDOB.SelectedIndex].Value), Convert.ToInt32(ws.Rows[row].Cells[cboMonthDOB.SelectedIndex].Value), Convert.ToInt32(ws.Rows[row].Cells[cboDayDOB.SelectedIndex].Value)).Date;
                        DateTime DOD = new DateTime(Convert.ToInt32(ws.Rows[row].Cells[cboYearDOD.SelectedIndex].Value), Convert.ToInt32(ws.Rows[row].Cells[cboMonthDOD.SelectedIndex].Value), Convert.ToInt32(ws.Rows[row].Cells[cboDayDOD.SelectedIndex].Value)).Date;
                        

                        Update(LastName, FirstName, DOB, sGender, DOD, ICD9, out string ProtocolOK, out string ProtocolErr, row + 1);
                        sbLog.Append(ProtocolOK);
                        sbErr.Append(ProtocolErr);
                        qs2.core.generic.FrmProgressUpdate(rowMax - row, qs2.core.language.sqlLanguage.getRes("remainingRecords", "ALL", "ALL", true, true) + " " + (rowMax - row).ToString());   //********
                    }
                    else
                    {
                        string msg = LastName + " " + FirstName;
                        sbErr.Append (row.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.Incomplete", false) + ": " + msg + "\n");    
                    }
                }
                CleanUp();
            }
            catch (Exception ex)
            {
                sbErr.Append("Error in btnStart: " + ex.Message + "\n");
                CleanUp();
            }
        }

        private void CleanUp()
        {
            try
            {
                if (bRunning)
                {
                    qs2.core.generic.FrmProgressUpdate(0, " ");
                    qs2.core.generic.FrmProgressClose();
                }

                qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                frmProt.initControl();
                frmProt.Text = qs2.core.language.sqlLanguage.getRes("DeathStatusImport.RecordsModified", false);  
                qs2.core.ENV.lstOpendChildForms.Add(frmProt);
                frmProt.Show();
                frmProt.ContProtocol1.setText(sbLog.ToString());

                if (!sbErr.ToString().sEquals(""))
                {
                    qs2.core.vb.frmProtocol frmProtErr = new qs2.core.vb.frmProtocol();
                    frmProtErr.initControl();
                    frmProtErr.Text = qs2.core.language.sqlLanguage.getRes("DeathStatusImport.RecordsFault", false);  
                    qs2.core.ENV.lstOpendChildForms.Add(frmProtErr);
                    frmProtErr.Show();
                    frmProtErr.ContProtocol1.setText(sbErr.ToString());

                    int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                    frmProt.Left = (screenWidth - frmProt.Width - frmProtErr.Width) / 2;
                    frmProtErr.Left = frmProt.Left + frmProt.Width + 5;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in contManageDeathStateExcel.CleanUp: " + ex.ToString());
            }
        }

        private bool Update(string LastName, string FirstName, DateTime DOB, string Gender, DateTime DOD, string ICD9, out string ProtocolOK, out string ProtocolErr, int counter)
        {
            //Call Update-Function
            //Suche Patient nach Nachname, Vorname, Geburtsdatum, Geschlecht
            //Wenn eindeutig -> Update MtStat, MtDate und ICD9 -> Update-Protokoll
            //      wenn alle Stay (Aufnahme-Datum, Op-Datum, Entlassungsdatum) < DOD -> OK-Liste
            //      wenn mindestens ein Stay > DOD -> Hinweis-Liste
            //Wenn nicht eindeutig -> Hinweis-Liste
            //Wenn nicht gefunden -> Hinweisliste
            try
            {
                ProtocolOK = "";
                ProtocolErr = "";

                string msg = LastName + " " + FirstName + ", " + DOB.ToString("d") + " Geschlecht = " + Gender;
                using (ERModellPMDSEntities db = businessFramework.getDBContext())
                {
                    int iGender;
                    switch (Gender.ToUpper())
                    {
                        case "M":
                            iGender = 1;
                            break;
                        case "W":
                        case "F":
                            iGender = 2;
                            break;
                        case "U":
                            iGender = 3;
                            break;
                        case "X":
                        case "D":
                            iGender = 4;
                            break;
                        default:
                            iGender = -1;
                            break;
                    }

                    List<tblObject> patList = (from o in db.tblObject
                                               where o.LastName == LastName && o.FirstName == FirstName && o.DOB == DOB && o.Gender == iGender
                                               select o).ToList();

                    if (!patList.Any())
                    {
                        ProtocolErr = counter.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.PatientNotFound", false) + ": " + msg + "\n"; 
                    }

                    else if (patList.Count == 1)
                    {
                        //Update
                        string sqlUpdate = "UPDATE qs2.tblObject SET MtStat = 2, ICD9 = '" + ICD9 + "', MtDate = CONVERT(DateTime, '" + DOD.ToString("yyyyMMdd") + "', 112) WHERE IDGuid = '" + patList[0].IDGuid + "'";
                        db.Database.ExecuteSqlCommand(sqlUpdate);

                        ProtocolOK = counter.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.ProtocolMsg", false) + "! " + msg + "\n";

                        //Protocol-Insert
                        using (qs2.core.vb.Protocol Protocol1 = new qs2.core.vb.Protocol())
                        {
                            Protocol1.save2(qs2.core.vb.Protocol.eTypeProtocoll.ManageDeathStatus, patList[0].IDGuid, -999, qs2.core.license.doLicense.rParticipant.IDParticipant, "ALL", "",
                                        "", qs2.core.vb.Protocol.eActionProtocol.None, LastName + " " + FirstName, "",
                                        "Update MtStat, MtDate, ICD9 from XLS, Row = " + counter.ToString(), sqlUpdate, Path.Combine(ImportPath, ImportFile));
                        }


                        //Stays checken
                        Guid IDGuid = patList.First().IDGuid;

                        bool errAdmitDate = (from s in db.tblStay
                                             where s.PatIDGuid == IDGuid && s.AdmitDt > DOD
                                             select s).Count() > 0;

                        bool errSurgDatStart = (from s1 in
                                                    (from s in db.tblStay where s.PatIDGuid == IDGuid && s.SurgDtStart != null select s)
                                                where s1.SurgDtStart > DOD
                                                select s1).Count() > 0;

                        bool errDischDate = (from s1 in
                                                 (from s in db.tblStay where s.PatIDGuid == IDGuid && s.DischDt != null select s)
                                             where s1.DischDt > DOD
                                             select s1).Count() > 0;

                        if (errAdmitDate)
                        {
                            ProtocolErr = counter.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.AdmitAfterDOD", false) + "! " + msg + "\n";     //********
                        }
                        else if (errSurgDatStart)
                        {
                            ProtocolErr = counter.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.SurgDtAfterDOD", false) + "! " + msg + "\n";      //********
                        }
                        else if (errDischDate)
                        {
                            ProtocolErr = counter.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.DischDtAfterDOD", false) + "! " + msg + "\n";      //********
                        }
                    }
                    else
                    {
                        ProtocolErr = counter.ToString() + ": " + qs2.core.language.sqlLanguage.getRes("DeathStatusImport.PatientNotUnique", false) + "! " + msg + "\n";     //********
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ProtocolOK = "";
                ProtocolErr = "";
                sbErr.Append("Error in Update: " + ex.Message + "\n");
                CleanUp();
                return false;
            }
        }
    }
}
