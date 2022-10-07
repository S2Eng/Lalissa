using Infragistics.Win.UltraWinGrid;
using qs2.core.vb;
using qs2.design.auto.print;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static qs2.core.vb.businessFramework;

namespace qs2.design.auto
{
    
    public class ui
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool repaint);
        
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPlacement(IntPtr hWnd,
           [In] ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll")]
        public static extern Boolean ShowWindowAsync(IntPtr hWnd, Int32 nCmdShow);
        [DllImport("user32.dll")]
        public static extern Boolean SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        [DllImport("user32.dll")]
        public static extern Boolean AnimateWindow(IntPtr hWnd, uint dwTime, uint dwFlags);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, IntPtr lol);
        //Definitions For Different Window Placement Constants
        public const UInt32 SW_HIDE = 0;
        public const UInt32 SW_SHOWNORMAL = 1;
        public const UInt32 SW_NORMAL = 1;
        public const UInt32 SW_SHOWMINIMIZED = 2;
        public const UInt32 SW_SHOWMAXIMIZED = 3;
        public const UInt32 SW_MAXIMIZE = 3;
        public const UInt32 SW_SHOWNOACTIVATE = 4;
        public const UInt32 SW_SHOW = 5;
        public const UInt32 SW_MINIMIZE = 6;
        public const UInt32 SW_SHOWMINNOACTIVE = 7;
        public const UInt32 SW_SHOWNA = 8;
        public const UInt32 SW_RESTORE = 9;

        public sealed class AnimateWindowFlags
        {
            public const int AW_HOR_POSITIVE = 0x00000001;
            public const int AW_HOR_NEGATIVE = 0x00000002;
            public const int AW_VER_POSITIVE = 0x00000004;
            public const int AW_VER_NEGATIVE = 0x00000008;
            public const int AW_CENTER = 0x00000010;
            public const int AW_HIDE = 0x00010000;
            public const int AW_ACTIVATE = 0x00020000;
            public const int AW_SLIDE = 0x00040000;
            public const int AW_BLEND = 0x00080000;
        }

        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }









        public static void openTableViewer(System.Data.DataSet ds, string IDRessourceTitle, string TitleAdditionalText,
                                    string IDParticipant, string IDApplication,
                                    string defaultTableNameDataMember, qs2.ui.print.contTable.eTypeUI TypeOfViewer, bool FilterOnOff)
        {
            qs2.ui.print.frmTable frmTable1 = new qs2.ui.print.frmTable();
            frmTable1.IDRessourceTitle = IDRessourceTitle;
            frmTable1.TitleAdditionalText = TitleAdditionalText;
            frmTable1.defaultDs = ds;
            frmTable1.IDParticipant = IDParticipant;
            frmTable1.IDApplication = IDApplication;
            frmTable1.defaultTableNameDataMember = defaultTableNameDataMember;
            frmTable1.contTable1.Sql = "";
            frmTable1.contTable1.doUnvisibleGuid = true;
            //frmTable1.contTable1.parameters = infoQryRunPar.parametersSql;
            if (TypeOfViewer == qs2.ui.print.contTable.eTypeUI.History)
            {
                qs2.core.vb.dsProtocol dsProtocolTemp = new qs2.core.vb.dsProtocol();
                frmTable1.selectDatasets = false;
                frmTable1.contTable1.translateQuery1.lstUnvisibleCols.Add(dsProtocolTemp.Protocol.IDGuidObjectColumn.ColumnName);
                frmTable1.contTable1.translateQuery1.lstUnvisibleCols.Add(dsProtocolTemp.Protocol.IDStayColumn.ColumnName);
                frmTable1.contTable1.translateQuery1.lstUnvisibleCols.Add(dsProtocolTemp.Protocol.sKeyColumn.ColumnName);
            }
            string protocol = "";
            frmTable1.initControl(TypeOfViewer, ref protocol, FilterOnOff);
            qs2.core.ENV.lstOpendChildForms.Add(frmTable1);
            frmTable1.Show();

            if (protocol.Trim() != "")
            {
                qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                frmProt.initControl();
                frmProt.Text = "Info: Problems with Query";
                qs2.core.ENV.lstOpendChildForms.Add(frmProt);
                frmProt.Show();
                frmProt.ContProtocol1.setText(protocol.Trim());
            }
        }


        public System.Collections.Generic.List<qs2.core.generic.retValue> getControlValues(System.Windows.Forms.Control mainCont)
        {
            string prefixTag = "Field=";

            System.Collections.Generic.List<qs2.core.generic.retValue> lstUserInput = new System.Collections.Generic.List<qs2.core.generic.retValue>();
            foreach (System.Windows.Forms.Control cont in mainCont.Controls)
            {
                cont.Refresh();

                if (cont.Tag != null)
                {
                    if (cont.Tag.GetType().Name.ToLower() == ("string").ToLower())
                    {
                        if (cont.GetType().Name.ToLower() == ("ultracomboeditor").ToLower())
                        {
                            Infragistics.Win.UltraWinEditors.UltraComboEditor cboControl = (Infragistics.Win.UltraWinEditors.UltraComboEditor)cont;
                            string fieldInfo = this.getTagInfoControl(cont, ref prefixTag);
                            if (fieldInfo.Trim() != "")
                            {
                                qs2.core.generic.retValue retValue = new qs2.core.generic.retValue();
                                retValue.fieldInfo = fieldInfo.Trim();
                                retValue.valueStr = cboControl.SelectedItem.DataValue.ToString();
                                lstUserInput.Add(retValue);
                            }
                        }
                        else if (cont.GetType().Name.ToLower() == ("ultranumericeditor").ToLower())
                        {
                            Infragistics.Win.UltraWinEditors.UltraNumericEditor numControl = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)cont;
                            string fieldInfo = this.getTagInfoControl(cont, ref prefixTag);
                            if (fieldInfo.Trim() != "")
                            {
                                double dbl = Convert.ToDouble(numControl.Value.ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                                qs2.core.generic.retValue retValue = new qs2.core.generic.retValue();
                                retValue.fieldInfo = fieldInfo.Trim();
                                retValue.valueStr = dbl.ToString().Replace(",", ".");
                                lstUserInput.Add(retValue);
                            }
                        }
                        else if (cont.GetType().Name.ToLower() == ("ultracheckeditor").ToLower())
                        {
                            Infragistics.Win.UltraWinEditors.UltraCheckEditor chkControl = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)cont;
                            string fieldInfo = this.getTagInfoControl(cont, ref prefixTag);
                            if (fieldInfo.Trim() != "")
                            {
                                qs2.core.generic.retValue retValue = new qs2.core.generic.retValue();
                                retValue.fieldInfo = fieldInfo.Trim();
                                if (chkControl.Checked)
                                    retValue.valueStr = "1";
                                else
                                    retValue.valueStr = "0";
                                lstUserInput.Add(retValue);
                            }
                        }
                        else if (cont.GetType().Name.ToLower() == ("UltraTextEditor").ToLower())
                        {
                            Infragistics.Win.UltraWinEditors.UltraTextEditor txtControl = (Infragistics.Win.UltraWinEditors.UltraTextEditor)cont;
                            string fieldInfo = this.getTagInfoControl(cont, ref prefixTag);
                            if (fieldInfo.Trim() != "")
                            {
                                qs2.core.generic.retValue retValue = new qs2.core.generic.retValue();
                                retValue.fieldInfo = fieldInfo.Trim();
                                retValue.valueStr = txtControl.Text.Trim();
                                lstUserInput.Add(retValue);
                            }
                        }
                        else if (cont.GetType().Name.ToLower() == ("UltraDateTimeEditor").ToLower())
                        {
                            Infragistics.Win.UltraWinEditors.UltraDateTimeEditor datControl = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cont;
                            string fieldInfo = this.getTagInfoControl(cont, ref prefixTag);
                            if (fieldInfo.Trim() != "")
                            {
                                qs2.core.generic.retValue retValue = new qs2.core.generic.retValue();
                                retValue.fieldInfo = fieldInfo.Trim();
                                retValue.valueStr = "1";
                                DateTime dat = datControl.DateTime.Date;
                                retValue.valueStr = dat.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                                lstUserInput.Add(retValue);
                            }
                        }
                    }
                }

            }

            return lstUserInput;
        }
        public string getTagInfoControl(System.Windows.Forms.Control cont, ref string prefixTag)
        {
            if (cont.Tag != null)
            {
                if (cont.Tag.GetType().Name.ToLower() == ("string").ToLower())
                {
                    if (cont.Tag.ToString().Length > 8)
                    {
                        if (cont.Tag.ToString().StartsWith(prefixTag.ToLower(), StringComparison.OrdinalIgnoreCase))
                        {
                            string fieldInfo = cont.Tag.ToString().Substring(6, cont.Tag.ToString().Length - 6);
                            return fieldInfo;
                        }
                    }
                }
            }
            return "";
        }

        public static void RestartAs(string sTypeToStart, int IDUser, string URIGuidClient, string URIGuidSrv, string DbConnStr, string ExeName, int SrvNr, string IDApplication)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessStartInfo = new System.Diagnostics.ProcessStartInfo();
                ProcessStartInfo.Arguments = " ?typ=" + sTypeToStart.Trim() + "";

                string sConfigPath = qs2.core.ENV.path_config.Trim();
                string sConfigFile = qs2.core.ENV.configFile.Trim();
                string sIDUser = IDUser.ToString().Trim();

                if (sConfigPath.Contains(" "))
                    sConfigPath = "\"" + sConfigPath.TrimEnd(Path.DirectorySeparatorChar) + "\"";

                if (sConfigFile.Contains(" "))
                    sConfigFile = "\"" + sConfigFile + "\"";

                if (sIDUser.Contains(" "))
                    sIDUser = "\"" + sIDUser + "\"";

                ProcessStartInfo.Arguments += @" ?ConfigPath=" + sConfigPath + " ";
                ProcessStartInfo.Arguments += @" ?ConfigFile=" + sConfigFile + " ";

                if (IDUser > 0)
                {
                    ProcessStartInfo.Arguments += " ?IDUser=" +sIDUser + " ";
                }

                if (URIGuidClient.Trim() != "")
                {
                    ProcessStartInfo.Arguments += " ?URIGuid=" + URIGuidClient.Trim() + " ";
                }
                if (URIGuidSrv.Trim() != "")
                {
                    ProcessStartInfo.Arguments += " ?URIGuidSrv=" + URIGuidSrv.Trim() + " ";
                }

                if (SrvNr != -1)
                {
                    ProcessStartInfo.Arguments += " ?SrvNr=" + SrvNr.ToString() + " ";
                }

                if (IDApplication.Trim() != "")
                {
                    ProcessStartInfo.Arguments += " ?IDApplication=" + IDApplication.ToString() + " ";
                }

                ProcessStartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "" + ExeName.Trim() + ".exe");
                System.Diagnostics.Process.Start(ProcessStartInfo);

            }
            catch (Exception ex)
            {
                throw new Exception("ui.RestartAs: " + ex.ToString());
            }
        }

        public void loadButtons(dsAdmin.tblSelListEntriesRow rSelListGroup1, Panel newPnlGroup1,
                                qs2.core.Enums.eTypRunQuery typRunQuery, ref sqlAdmin sqlAdmin1, ref dsAdmin dsAdmin1, string IDApplication, string IDParticipant,
                                ref qs2.core.db.ERSystem.businessFramework b2, ref qs2.core.vb.businessFramework b,
                                ref SortedDictionary<string, qs2.ui.pint.contQryRun.cButton> dictButtons, bool IsStayUI,
                                ref System.Collections.Generic.List<cSelListAndObj> lstRolesForUserActive)
        {
            try
            {
                dsAdmin dsAdminTmp3 = new dsAdmin();
                sqlAdmin sqlAdminTmp3 = new sqlAdmin();
                sqlAdminTmp3.initControl();

                if (newPnlGroup1 != null)
                    newPnlGroup1.Controls.Clear();
                
                dsAdmin1.tblSelListEntriesObj.Rows.Clear();
                dsAdmin dsAdminForButtons = new dsAdmin();

                string IDGroupToLoad = "";
                if (typRunQuery == qs2.core.Enums.eTypRunQuery.ReportGroups)
                    IDGroupToLoad = "Reports";
                else if (typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                    IDGroupToLoad = "Queries";
                else if (typRunQuery == qs2.core.Enums.eTypRunQuery.DocumentGroups)
                    IDGroupToLoad = "Documents";

                if (rSelListGroup1 != null)
                {
                    sqlAdmin1.getSelListEntrysObj(rSelListGroup1.ID, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, IDGroupToLoad, dsAdminForButtons, core.vb.sqlAdmin.eTypAuswahlObj.sellist, IDApplication);
                }
                else
                {
                    qs2.core.db.ERSystem.businessFramework businessFramework1 = new qs2.core.db.ERSystem.businessFramework();
                    foreach (Guid IDSelListDocu in businessFramework1.GetSelListDocuments(IDApplication, IDParticipant))
                    {
                        sqlAdmin1.getSelListEntrysObj(-999, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "", dsAdminForButtons, core.vb.sqlAdmin.eTypAuswahlObj.IDGuid, "", -999, "", -999, "", -999, "", "", false, IDSelListDocu);
                    }
                }

                foreach (dsAdmin.tblSelListEntriesObjRow rObj in dsAdminForButtons.tblSelListEntriesObj)
                {
                    //if (rObj.IDParticipant.Trim() == "ALL" || rObj.IDParticipant.Trim() == "")
                    //{
                    dsAdmin.tblSelListEntriesRow rSelListEntryFound = sqlAdmin1.getSelListEntrysRow("", sqlAdmin.eTypAuswahlList.id, qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplication, "", 0, "", rObj.IDSelListEntry);
                    if (rSelListEntryFound != null)
                    {
                        bool bHasLicenseKey = false;
                        if (rSelListEntryFound.LicenseKey.Trim() == "")
                        {
                            bHasLicenseKey = true;
                        }
                        else
                        {
                            System.Collections.Generic.List<string> lstLicenseKeys = new List<string>();
                            lstLicenseKeys = b.getVariablesLicenseKeys(rSelListEntryFound.LicenseKey.Trim());
                            bHasLicenseKey = b2.checkLicenseKey(lstLicenseKeys, rSelListEntryFound.FldShortColumn.Trim(), IDApplication);
                        }
                        if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                        {
                            bHasLicenseKey = true;
                        }

                        if (bHasLicenseKey)
                        {
                            dsAdmin.tblSelListEntriesRow rSelListEntryFound2 = sqlAdmin1.getSelListEntrysRow("", sqlAdmin.eTypAuswahlList.id, qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplication, "", 0, "", rObj.IDSelListEntrySublist);
                            dsAdmin.tblSelListGroupRow rSelListGroupRow2 = sqlAdmin1.getSelListGroupRowID(rSelListEntryFound2.IDGroup);
                            dsAdmin.tblSelListGroupRow rSelListGroupRow = sqlAdmin1.getSelListGroupRowID(rSelListEntryFound.IDGroup);

                            qs2.ui.pint.contQryRun.cButton NewButton = new qs2.ui.pint.contQryRun.cButton();
                            NewButton.rObj = rObj;
                            NewButton.rSelListEntrySubListFound = rSelListEntryFound2;
                            NewButton.rSelListEntryFound = rSelListEntryFound;

                            bool bExistsInGroup = false;
                            foreach (KeyValuePair<string, qs2.ui.pint.contQryRun.cButton> KeyValuePairButton in dictButtons)
                            {
                                if (KeyValuePairButton.Value.rObj.IDSelListEntry.Equals(rSelListEntryFound.ID))
                                {
                                    bExistsInGroup = true;
                                }
                            }
                            if (!bExistsInGroup || IsStayUI)
                            {
                                string TranslatedText = "";
                                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                                string idResFound = qs2.core.language.sqlLanguage.getRes(rSelListEntryFound.IDRessource, core.Enums.eResourceType.Label, IDParticipant, IDApplication, ref rLangFoundReturn);
                                if (idResFound.Trim() == "")
                                    TranslatedText = NewButton.rSelListEntryFound.IDRessource;
                                else
                                    TranslatedText = idResFound;

                                NewButton.TranslatedTxt = TranslatedText.Trim();

                                bool bRightIsOk = true;
                                if (rSelListEntryFound.Classification.Trim().ToLower().Contains(("Right=").Trim().ToLower()) && !qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                                {
                                    bRightIsOk = false;
                                    System.Collections.Generic.List<string> lstVarClassification = qs2.core.generic.readStrVariables(rSelListEntryFound.Classification.Trim());
                                    foreach (string defVarClassification in lstVarClassification)
                                    {
                                        string VariableFound = "";
                                        string ValueFound = "";
                                        qs2.core.generic.readVariableAndValue(defVarClassification, ref VariableFound, ref ValueFound);
                                        if (ValueFound.Trim() != "")
                                        {
                                            System.Collections.Generic.List<string> lstVariables = new List<string>();
                                            qs2.core.generic.getValues(ValueFound, "|", ref lstVariables);
                                            foreach (string varUser in lstVariables)
                                            {
                                                if (varUser.Trim().ToLower().Equals((qs2.core.vb.actUsr.rUsr.UserName.Trim()).Trim().ToLower()))
                                                {
                                                    bRightIsOk = true;
                                                }
                                            }
                                        }
                                    }
                                }

                                bool HasUserHasRight = true;
                                if (typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                                {
                                    if (!rSelListEntryFound.CreatedUser.Trim().ToLower().Equals(actUsr.rUsr.UserName.Trim().ToLower()))
                                    {
                                        if (rSelListEntryFound.TypeStr.Trim().ToLower().Equals(("User").Trim().ToLower()) && !rSelListEntryFound.Published)
                                        {
                                            HasUserHasRight = false;
                                            dsAdminTmp3.Clear();
                                            sqlAdminTmp3.getSelListEntrysObj(actUsr.rUsr.ID, core.vb.sqlAdmin.eDbTypAuswObj.UserQueries, core.vb.sqlAdmin.eDbTypAuswObj.UserQueries.ToString(), dsAdminTmp3, core.vb.sqlAdmin.eTypAuswahlObj.IDSelListEntryIDObject, "", rSelListEntryFound.ID);
                                            if (dsAdminTmp3.tblSelListEntriesObj.Rows.Count > 0)
                                            {
                                                HasUserHasRight = true;
                                            }
                                        }
                                    }
                                }

                                bool bIDParticipant = true;
                                if (typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                                {
                                    bIDParticipant = false;
                                    if (rSelListEntryFound.IDParticipant.Trim() == "" || rSelListEntryFound.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower()) ||
                                        rSelListEntryFound.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower()))
                                    {
                                        bIDParticipant = true;
                                    }
                                }

                                if (bRightIsOk && HasUserHasRight && bIDParticipant && 
                                    (typRunQuery != qs2.core.Enums.eTypRunQuery.DocumentGroups || b.checkUserRightsReportDocu(rSelListEntryFound.ID)) &&
                                    (typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups || b.checkRolesReportDocu(rSelListEntryFound.ID, ref lstRolesForUserActive)))
                                {
                                    if (rSelListEntryFound._Private && !qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                                    {
                                        if (rSelListEntryFound.CreatedUser.Trim().ToLower().Equals((qs2.core.vb.actUsr.rUsr.UserName.Trim()).Trim().ToLower()))
                                        {
                                            dictButtons.Add(TranslatedText + System.Guid.NewGuid().ToString(), NewButton);
                                        }
                                    }
                                    else
                                    {
                                        dictButtons.Add(TranslatedText + System.Guid.NewGuid().ToString(), NewButton);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ui.loadButtons: " + ex.ToString());
            }
        }
    }
}
