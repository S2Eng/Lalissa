using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.ComponentModel;

using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Data;
using System.Reflection;

using FastReport;
using FastReport.MSChart;
using FastReport.Utils;
using FastReport.Design.StandardDesigner;
using System.IO;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;


namespace qs2.design.auto.print
{

    public class HandleStays
    {
        public void OpenStay(bool showMsgBox, int IDStay, string Application, string IDParticipant)
        {
            try
            {
                qs2.core.db.ERSystem.businessFramework b = new core.db.ERSystem.businessFramework();
                PMDS.db.Entities.tblStay rStay = b.checkIsStay(IDStay, Application.Trim(), IDParticipant.Trim());
                if (rStay != null)
                {
                    qs2.core.ENV.cParsCalMainFunction pars = new qs2.core.ENV.cParsCalMainFunction();
                    pars.IDGuidStay = rStay.IDGuid;
                    pars.IDApplication = rStay.IDApplication.Trim();
                    pars.StayTyp = (qs2.core.Enums.eStayTyp)rStay.StayTyp;
                    pars.newStay = false;
                    qs2.core.ENV.CallFunctionMain(core.ENV.eTypeFunction.loadStay, pars);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
            }
        }
    }

    public class QS2Functions
    {
        private static System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InvariantCulture;

        public static string formatPercent(object o, int decimals)
        {
            try
            {
                string ret = "";
                if (o == null)
                    return ret;

                string format = "0";
                if (decimals > 0)
                    format += "." + new String('0', decimals);

                if (o.GetType() == typeof(double))
                {
                    double d = (double)o;
                    ret = Math.Round(d, decimals, MidpointRounding.AwayFromZero).ToString(format, ci) + " %";
                }
                return ret;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return "";
            }
        }

        public static double string2double(string val)
        {
            try
            {
                double ret;
                if (Double.TryParse(val, out ret))
                    return ret;
                else
                    return 0D; ;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return 0;
            }
        }

        public static string decimal2string(object o, int decimals, string prefix, string suffix)
        {
            try
            {
                string ret = "";
                if (o == null)
                    return ret;

                string format = "0";
                if (decimals > 0)
                    format += "." + new String('0', decimals);

                if (o.GetType() == typeof(double))
                {
                    double d = (double)o;
                    ret = prefix + Math.Round(d, decimals, MidpointRounding.AwayFromZero).ToString(format, ci) + suffix;
                }
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return "";
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return "";
            }
        }

        private static double CellToDouble(object o)
        {
            try
            {
                double ret = 0D;
                if (o.GetType() == typeof(FastReport.Table.TableCell))
                {
                    FastReport.Table.TableCell cell = (FastReport.Table.TableCell)o;
                    ret = (cell.Value == null) ? 0D : Convert.ToDouble(cell.Value, ci);
                }
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return 0;
            }
        }

        private static bool LoadStayInProgress { get; set; } = false;   //Doppelklick von report abfangen (Kein DoubleClick-Event in FastReport)

        public static bool setIDClicked(string IDClicked, string IDApplication, string IDParticipant)
        {
            try
            {
                int IDStay;
                try
                {
                    if (!LoadStayInProgress)
                    {
                        LoadStayInProgress = true;
                        IDStay = int.Parse(IDClicked.Replace(",", "").Replace(".", ""));
                        HandleStays hs = new HandleStays();
                        hs.OpenStay(false, IDStay, IDApplication, IDParticipant);
                        LoadStayInProgress = false;
                    }
                }
                catch (FormatException)
                {
                    _ = System.Windows.Forms.MessageBox.Show(IDClicked, "??", System.Windows.Forms.MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return false;
            }
        }

        public static double calcPercent(object o1, object o2)
        {
            try
            {
                double ret = 0D;

                if (o1 == null || o2 == null)
                    return ret;

                double d1 = CellToDouble(o1);
                double d2 = CellToDouble(o2);

                if (d2 != 0)
                    ret = d1 * 100 / d2;

                return ret;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return 0;
            }

        }

        public static bool checkType(object o)
        {
            if (o == null)
                return false;

            if (o.GetType() == typeof(FastReport.Dialog.DialogPage))
            {

            }
            return true;
        }

        public static bool afterSummen(object matrix)
        {
            if (matrix == null)
                return false;

            FastReport.Matrix.MatrixObject m = (FastReport.Matrix.MatrixObject)matrix;

            int[] rowIndices = m.Data.Rows.GetTerminalIndices();
            for (int i = 0; i < rowIndices.Length; i++)
            {
                double Anzahl = GetMatrixCellValue(m, 0, i, 0);
                double Tote = GetMatrixCellValue(m, 0, i, 1);
                double EuroSCORE = GetMatrixCellValue(m, 0, i, 3);
                double ToteProzent = (Tote > 0 ? Tote / Anzahl : 0);
                double Ergebnis = (EuroSCORE > 0 ? ToteProzent * 100 / EuroSCORE : 0);

                int[] columnIndices = m.Data.Columns.GetTerminalIndices();
            }

            //m.BuildTemplate();
            matrix = m;

            return true;
        }

        //public static double getSurvivalFullYears(object MtStat, object MtDate, object SurgDtStart, bool IsReop )
        //{
        //    try
        //    {
        //        int ret = -1;

        //        if (MtStat == null || MtDate == null || SurgDtStart == null || MtStat.GetType() != typeof(int) || 
        //            MtDate.GetType() != typeof(System.DateTime) || SurgDtStart.GetType() != typeof(System.DateTime) ||
        //            IsReop)
        //        {
        //            return ret;
        //        }

        //        int mtStat = (int)MtStat;
        //        DateTime zeroTime = DateTime.MinValue;
        //        DateTime now = DateTime.Now.Date;
        //        DateTime mtDate = (DateTime)MtDate;
        //        DateTime surgDt = (DateTime)SurgDtStart;

        //        if (surgDt == zeroTime || surgDt > now)
        //        {
        //            return ret;
        //        }
                
        //        if (mtStat == 1 && mtDate == zeroTime)    //Alive
        //        {
        //            TimeSpan span = now - surgDt;
        //            ret = (zeroTime + span).Year - 1;
        //        }
        //        else if (mtStat == 2 && mtDate != zeroTime && mtDate <= now && surgDt != zeroTime && surgDt <= mtDate)     //Dead
        //        {
        //            TimeSpan span = mtDate - surgDt;
        //            ret = (zeroTime + span).Year - 1;
        //        }

        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
        //        return 0;
        //    }
        //}

        //public static bool setSurvivalCurve(object SurvivalChart, double p0, double p1, double p2, double p3, double p4, double p5, double p6)
        //{
        //    try
        //    {

        //        if (SurvivalChart.GetType() == typeof(FastReport.MSChart.MSChartObject))
        //        {
        //            FastReport.MSChart.MSChartObject chart = (FastReport.MSChart.MSChartObject)SurvivalChart;

        //            chart.Series[0].AddValue(0, 1);
        //            chart.Series[0].AddValue(1, p0);
        //            chart.Series[0].AddValue(2, p1);
        //            chart.Series[0].AddValue(3, p2);
        //            chart.Series[0].AddValue(4, p3);
        //            chart.Series[0].AddValue(5, p4);
        //            chart.Series[0].AddValue(6, p5);
        //            //chart.Series[0].AddValue(7, p6);

        //            chart.Chart.ChartAreas[0].AxisX.Minimum = 0;
        //            chart.Chart.ChartAreas[0].AxisX.Maximum = 6;
        //            chart.Chart.ChartAreas[0].AxisY.Minimum = 0;
        //            chart.Chart.ChartAreas[0].AxisY.Maximum = 1;
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
        //        return false;
        //    }
        //}

        private static float GetMatrixCellValue(FastReport.Matrix.MatrixObject m, int columnIndex, int rowIndex, int cellIndex)
        {
            object value = m.Data.GetValue(columnIndex, rowIndex, cellIndex);
            return new Variant(value);
        }
    }

    public class FReport : IDisposable
    {
        private qs2.ui.print.infoQry InfoQ { get; set; }
        private qs2.ui.print.infoReport InfoR { get; set; }
        private bool bDes { get; set; } = false;
        public FastReport.Report RepOut = new FastReport.Report();

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

        public void InitAndView(string rpt, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport, bool bDesign)
        {
            RegisterOwnFunctions();
            InfoQ = InfoQuery;
            InfoR = InfoReport;
            bDes = bDesign;
            GenerateAndViewReport(rpt, InfoQuery.dsQryResult);
        }

        public void InitAndView(string rpt, string XMLPath, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport, bool bDesign)
        {
            RegisterOwnFunctions();
            GenerateAndViewReport(rpt, DsFromXML(XMLPath));
        }

        public Report Init(string rpt, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport, bool bDesign)
        {
            RegisterOwnFunctions();
            InfoQ = InfoQuery;
            InfoR = InfoReport;
            bDes = bDesign;
            return GenerateReport(rpt, InfoQuery.dsQryResult);
        }

        public Report Init(string rpt, string XMLPath, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport, bool bDesign)
        {
            RegisterOwnFunctions();
            return GenerateReport(rpt, DsFromXML(XMLPath));
        }

        public static bool FunctionsRegistered { get; set; } = false;

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
        private void RegisterOwnFunctions()
        {
            try
            {
                if (!FunctionsRegistered)
                {
                    List<ObjectInfo> l = new List<ObjectInfo>();
                    RegisteredObjects.Objects.EnumItems(l);

                    RegisteredObjects.AddFunctionCategory("MyFuncs", "QS2 Functions".ToString()); ;
                    Type myType = typeof(QS2Functions);

                    MethodInfo setIDClicked = myType.GetMethod("setIDClicked");
                    MethodInfo calcPercent = myType.GetMethod("calcPercent");
                    MethodInfo formatPercent = myType.GetMethod("formatPercent");
                    MethodInfo decimal2string = myType.GetMethod("decimal2string");
                    MethodInfo string2double = myType.GetMethod("string2double");
                    //MethodInfo getSurvivalFullYears = myType.GetMethod("getSurvivalFullYears");
                    //MethodInfo setSurvivalCurve = myType.GetMethod("setSurvivalCurve");

                    RegisteredObjects.AddFunction(setIDClicked, "MyFuncs");
                    RegisteredObjects.AddFunction(calcPercent, "MyFuncs");
                    RegisteredObjects.AddFunction(formatPercent, "MyFuncs");
                    RegisteredObjects.AddFunction(decimal2string, "MyFuncs");
                    RegisteredObjects.AddFunction(string2double, "MyFuncs");
                    //RegisteredObjects.AddFunction(getSurvivalFullYears, "MyFuncs");
                    //RegisteredObjects.AddFunction(setSurvivalCurve, "MyFuncs");

                    MethodInfo checkType = myType.GetMethod("checkType");
                    RegisteredObjects.AddFunction(checkType, "MyFuncs");

                    MethodInfo afterSummen = myType.GetMethod("afterSummen");
                    RegisteredObjects.AddFunction(afterSummen, "MyFuncs");

                    FunctionsRegistered = true;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
            }
        }

        private static bool IsCustomString(string str)
        {
            try
            {
                if (str.Trim().Length > 1)
                {
                    if (str.Substring(0, 1) == "{" && str.Substring(str.Length - 1, 1) == "}")
                    {

                        if (!qs2.core.ENV.ResWorkaround.Any(x => x.Contains(str)) && qs2.core.ENV.IsDevelopmentMachine)
                        {
                            qs2.core.ENV.ResWorkaround.Add(str);
                            using (StreamWriter sw = File.AppendText(@"C:\temp\fr.txt"))
                            {
                                string ID = str.Substring(1, str.Length - 2);
                                string SQL = "DECLARE @IDRES varchar(200) \n";

                                SQL += "DECLARE @IDRESTmp varchar(200) \n";
                                SQL += "DECLARE @English varchar(200) \n";
                                SQL += "DECLARE @German varchar(200) \n";
                                SQL += "DECLARE @IDApplication varchar(200) \n";
                                SQL += "DECLARE @Date datetime \n";
                                SQL += "DECLARE @IDGuid uniqueidentifier \n";

                                SQL += "SELECT @IDRES = '" + ID + "' \n";
                                SQL += "SELECT @IDRESTmp = '" + str + "' \n";
                                SQL += "SELECT @English = English from qs2.Ressourcen WHERE IDRes = @IDRES AND [Type] = 'Label' \n";
                                SQL += "SELECT @German = German from qs2.Ressourcen WHERE IDRes = @IDRES AND [Type] = 'Label' \n";
                                SQL += "SELECT @IDApplication = '" + qs2.core.license.doLicense.rApplication.IDApplication.ToString() + "' \n";
                                SQL += "SELECT @Date = GETDATE() \n";
                                SQL += "SELECT @IDGuid = NEWID() \n";

                                SQL += "IF NOT EXISTS (SELECT * FROM qs2.Ressourcen WHERE IDRes = @IDRESTmp) AND ISNULL(@English, '!!!')  <> '!!!' \n";
                                SQL += "  BEGIN \n";
                                SQL += "    INSERT INTO qs2.Ressourcen (IDRes, English, German, [User], [Description], IDApplication, IDParticipant, [Type], TypeSub, fileType, Created, CreatedUser, IDGuid, [Image], ImageWidth, ImageHeigth, [Classification], LastChange, ResGroup) \n";
                                SQL += "    SELECT @IDRESTmp, @English, @German, '', '20210713.tmp', @IDApplication, 'ALL', 'Label', '', '', @Date, '', @IDGuid,'',-1,-1,'', @Date,'' \n";
                                SQL += "    print @IDResTmp + ' inserted' \n";
                                SQL += "  END \n";
                                SQL += "ELSE \n";
                                SQL += "  print 'Keine Ressource gefunden oder schon vorhanden für ' + @IDRes \n";
                                SQL += "GO \n";
                                sw.WriteLine(SQL);
                            }
                        }
                        
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return false;
            }
        }

        private static string StripCustomString(string str)
        {
            try
            {
                if (str.Trim().Length >= 2 && str.Substring(0, 1) == "{" && str.Substring(str.Length - 1, 1) == "}")
                    return str.Substring(1, str.Trim().Length - 2);
                else
                    return str;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return str;
            }
        }

        //private string GetRes(string str)
        //{
        //    try
        //    {
        //        return qs2.core.language.sqlLanguage.getRes(str.Substring(1, str.Length - 2), InfoR.Participant, InfoR.Application, false, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return str;
        //    }
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
        private bool ReplaceSQLString(Report rpt)
        {
            try
            {
                //SQL-Query andrucken (statt Übergabe per Parameter)
                TextObject oSQLQuery = (TextObject)rpt.FindObject("SQLQuery");
                if (oSQLQuery != null)
                {
                    oSQLQuery.Text = InfoQ.SqlWhereInfo;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("FastReport.MyFunction.replaceSQLString: " + ex.ToString());
            }
        }

        private bool ReplaceMatrixText(Report rpt, Object o)
        {
            try
            {
                //Texte in {} in Matrix-Zellen ersetzen
                if (o.GetType() == typeof(FastReport.Table.TableCell))
                {
                    FastReport.Table.TableCell cFound = (FastReport.Table.TableCell)o;
                    FastReport.Table.TableCell cReplace = (FastReport.Table.TableCell)rpt.FindObject(cFound.Name);

                    if (IsCustomString(cReplace.Text))
                        cReplace.Text = qs2.core.generic.TranslateEx(StripCustomString(cReplace.Text));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("FastReport.MyFunction.replaceMatrixText: " + ex.ToString());
            }
        }

        private bool ReplaceStringFields(Report rpt, Object o)
        {
            try
            {
                //Texte in geschweiften Klammen {} in Textfeldern ersetzen
                if (o.GetType() == typeof(TextObject))  //Textfelder
                {
                    TextObject oFound = (TextObject)o;
                    TextObject oReplace = (TextObject)rpt.FindObject(oFound.Name);

                    if (IsCustomString(oReplace.Text))
                        oReplace.Text = qs2.core.generic.TranslateEx(StripCustomString(oReplace.Text));
                }
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return false;
            }
        }

        private bool ReplaceChartFields(Report rpt, Object o)
        {
            try
            {
                if (o.GetType() == typeof(MSChartObject))
                {
                    MSChartObject oFound = (MSChartObject)o;
                    MSChartObject oChart = (MSChartObject)rpt.FindObject(oFound.Name);

                    //Legenden in Charts
                    foreach (var serie in oChart.Chart.Series)
                    {
                        if (IsCustomString(serie.Name))
                        {
                            serie.LegendText = qs2.core.generic.TranslateEx(StripCustomString(serie.Name));
                        }
                    }

                    //Reportname
                    foreach (var title in oChart.Chart.Titles)
                    {
                        if (IsCustomString(title.Text))
                        {
                            title.Text = qs2.core.generic.TranslateEx(StripCustomString(title.Text));
                        }
                    }

                    foreach (var area in oChart.Chart.ChartAreas)
                    {
                        //x-Achsenbeschriftung
                        if (IsCustomString(area.AxisX.Title))
                        {
                            area.AxisX.Title = qs2.core.generic.TranslateEx(StripCustomString(area.AxisX.Title)); ;
                        }

                        if (IsCustomString(area.AxisX2.Title))
                        {
                            area.AxisX2.Title = qs2.core.generic.TranslateEx(StripCustomString(area.AxisX2.Title)); ;
                        }

                        //y-Achsenbeschriftung
                        if (IsCustomString(area.AxisY.Title))
                        {
                            area.AxisY.Title = qs2.core.generic.TranslateEx(StripCustomString(area.AxisY.Title)); ;
                        }

                        if (IsCustomString(area.AxisY2.Title))
                        {
                            area.AxisX2.Title = qs2.core.generic.TranslateEx(StripCustomString(area.AxisY2.Title)); ;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return false;
            }
        }

        private bool ReplaceFormFields(Report rpt, Object o)
        {
            try
            {
                if (o.GetType() == typeof(FastReport.Dialog.DialogPage))
                {
                    FastReport.Dialog.DialogPage oFound = (FastReport.Dialog.DialogPage)o;
                    FastReport.Dialog.DialogPage oReplace = (FastReport.Dialog.DialogPage)rpt.FindObject(oFound.Name);

                    if (IsCustomString(oReplace.Text))
                        oReplace.Text = qs2.core.generic.TranslateEx(StripCustomString(oReplace.Text));
                }
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return false;
            }
        }

        private bool ReplaceObjects(Report rpt)
        {
            try
            {
                bool res = ReplaceSQLString(rpt);

                foreach (Object o in rpt.AllObjects)
                {
                    res &= ReplaceFormFields(rpt, o);
                    res &= ReplaceMatrixText(rpt, o);
                    res &= ReplaceStringFields(rpt, o);
                    res &= ReplaceChartFields(rpt, o);

                    if (!res)
                        break;
                }
                return res;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5366:XmlReader zum Lesen von DataSet-XML verwenden", Justification = "<Ausstehend>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA3075:Unsichere DTD-Verarbeitung in XML", Justification = "<Ausstehend>")]
        private DataSet DsFromXML(string data)
        {
            try
            {
                using (Report report = new Report())
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            _ = ds.ReadXml(@data);
                        }
                        catch (System.Security.SecurityException ex)
                        {
                            qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                        }
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FastReport.MyFunction.DsFromXML: " + ex.ToString());
            }
        }

        private void GenerateAndViewReport(string rpt, DataSet ds)
        {
            try
            {
                using (Report report = new Report())
                {
                    report.Load(@rpt);
                    report.RegisterData(ds);

                    if (bDes)
                    {
                        report.Design();
                        report.Dispose();
                    }
                    else
                    {
                        if (ReplaceObjects(report))
                        {
                            report.Show(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
            }
        }
        private Report GenerateReport(string rpt, DataSet ds)
        {
            try
            {                              
                RepOut.Load(@rpt);
                RepOut.RegisterData(ds);
                ReplaceObjects(RepOut);
                return RepOut;                
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                return null;
            }
        }
    }
}