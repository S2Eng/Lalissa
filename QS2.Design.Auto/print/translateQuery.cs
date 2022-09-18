using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using qs2.core.vb;
using S2Extensions;




namespace qs2.design.auto.print
{


    public class translateQuery
    {
        public qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
        public qs2.core.vb.dsAdmin dsAdmin1 = new qs2.core.vb.dsAdmin();

        public qs2.core.vb.sqlObjects sqlObjects1 = new qs2.core.vb.sqlObjects();
        public qs2.core.vb.dsObjects dsObjects1 = new qs2.core.vb.dsObjects();

        public System.Collections.Generic.List<UltraGridRow> lstUnvisibleRows = new System.Collections.Generic.List<UltraGridRow>();
        public System.Collections.Generic.List<string> lstUnvisibleCols = new System.Collections.Generic.List<string>();
        public System.Collections.Generic.List<string> lstColsNoRigth = new System.Collections.Generic.List<string>();

        public class cVariables
        {
            public string definition = "";
            public string value = "";
        }

        public TableToArray TableToArray = null;











        public DataTable translateSelList(DataTable dtFromQuery, UltraGrid grid, string IDApplication, ref string protocol, bool translateForReport)
        {
            string ErrField = "";
            string ErrFieldSub = "";
            try
            {
                qs2.core.vb.businessFramework b = new businessFramework();
                ownMCCriteria ownMCCriteria1 = new ownMCCriteria();
                System.Collections.Specialized.ListDictionary lstYesNo = this.getRessourceThreeStateButtons();

                this.TableToArray = new TableToArray();
                Object[,] objTranslated = this.TableToArray.copyTableToArrayForTranslation(ref dtFromQuery);

                //System.Collections.Generic.List<System.Data.DataColumn> lstCols = new System.Collections.Generic.List<System.Data.DataColumn>();
                //foreach (DataColumn col in dtToTranslate.Columns)
                //{
                //    lstCols.Add(col);
                //}

                string colPrev = "";
                string colPrevPrev = "";
                int colCount = 0;
                foreach (DataColumn col in dtFromQuery.Columns)
                {
                    bool SubSelListCboDone = false;
                    List<dsAdmin.tblRelationshipRow> arrRelationsParentEqualsValue = null;
                    colCount += 1;
                    ErrField = col.ColumnName;
                    bool rigthOK = false;
                    if (!translateForReport)
                    {
                        string protocollForAdmin = "";
                        bool ProtocolWindow = false;
                        System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();

                        qs2.core.vb.dsAdmin dsAdminWork = new core.vb.dsAdmin();
                        qs2.core.vb.sqlAdmin sqlAdminWork = new core.vb.sqlAdmin();
                        sqlAdminWork.initControl();
                        ownMCCriteria1.Application = IDApplication;
                        ownMCCriteria1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();

                        string FldShortTmp = "";
                        if (col.ColumnName.sEquals(qs2.core.generic.prefixColAutoTranslate, S2Extensions.Enums.eCompareMode.StartsWith))
                        {
                            FldShortTmp = col.ColumnName.Substring(qs2.core.generic.prefixColAutoTranslate.Length, col.ColumnName.Length - qs2.core.generic.prefixColAutoTranslate.Length);
                        }
                        else if (col.ColumnName.sEquals(qs2.core.generic.TransEmpty,S2Extensions.Enums.eCompareMode.StartsWith))
                        {
                            FldShortTmp = col.ColumnName.Substring(qs2.core.generic.TransEmpty.Length, col.ColumnName.Length - qs2.core.generic.TransEmpty.Length);
                        }
                        else if (col.ColumnName.sEquals(qs2.core.generic.prefixColAutoTranslateFunctions, S2Extensions.Enums.eCompareMode.StartsWith))
                        {
                            FldShortTmp = col.ColumnName.Substring(qs2.core.generic.prefixColAutoTranslateFunctions.Length, col.ColumnName.Length - qs2.core.generic.prefixColAutoTranslateFunctions.Length);
                        }
                        else
                        {
                            FldShortTmp = col.ColumnName.Trim();
                        }
                        bool HasCriteria = false;
                        rigthOK = ownMCCriteria1.checkAssignments(null, ownMCRelationship.eTypAssignments.Roles, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive,
                                                                        FldShortTmp, true, sqlAdminWork, ref HasCriteria, false, -999);

                        if (!rigthOK && HasCriteria)
                        {
                            if (!col.ColumnName.sEquals(qs2.core.generic.TransEmpty, S2Extensions.Enums.eCompareMode.StartsWith))
                            {
                                this.lstColsNoRigth.Add(col.ColumnName);
                            }
                        }
                        if (!HasCriteria)
                        {
                            rigthOK = true;
                        }
                        else
                        {
                            //string xy = "";
                        }
                    }
                    else
                    {
                        rigthOK = true;
                    }

                    //if (!rigthOK)
                    //{
                    //    string xy = "";
                    //}
                    if (rigthOK)
                    {
                        if (!col.ColumnName.sEquals(qs2.core.generic.TransEmpty, S2Extensions.Enums.eCompareMode.StartsWith) &&
                            !col.ColumnName.sEquals(qs2.core.generic.prefixColAutoTranslate, S2Extensions.Enums.eCompareMode.StartsWith))
                        {

                            string IDApplicationTmp = "";
                            IDApplicationTmp = IDApplication;
                            string IDGroupToLoad = "";
                            qs2.core.vb.dsAdmin dsSelListFound = new qs2.core.vb.dsAdmin();

                            bool colIsCriteriaComboBox = false;
                            bool colIsCriteriaComboBoxAndIsInRelation = false;
                            dsAdmin.tblRelationshipRow[] arrRelationship = null;
                            bool colIsDbComboBox = false;
                            string SQLValueListSelect = "";

                            bool colIsCheckBox = false;
                            bool colIsThreeStateCheckBox = false;
                            bool colIsObjectID = false;

                            qs2.core.vb.dsAdmin.tblCriteriaRow rCriteriaFound = null;
                            this.dsAdmin1.Clear();
                            qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteriaFound = this.sqlAdmin1.getCriterias(this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, col.ColumnName, IDApplication,
                                                                                                                false, false, false, "", "", false);
                            if (arrCriteriaFound.Length == 0)
                            {
                                arrCriteriaFound = this.sqlAdmin1.getCriterias(this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, col.ColumnName, "ALL",
                                                                                false, false, false, "", "", false);
                            }
                            if (arrCriteriaFound.Length == 0)
                            {
                                colIsDbComboBox = true;
                                IDGroupToLoad = col.ColumnName;
                            }
                            else if (arrCriteriaFound.Length == 1)
                            {
                                rCriteriaFound = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriteriaFound[0];

                                if (rCriteriaFound.Classification.sEquals("Type=IDObject", S2Extensions.Enums.eCompareMode.Contains))
                                {
                                    colIsObjectID = true;
                                }
                                else if (rCriteriaFound.ControlType.Equals(core.Enums.eControlType.ComboBox.ToString(), StringComparison.OrdinalIgnoreCase) || 
                                         rCriteriaFound.ControlType.Equals(core.Enums.eControlType.ComboBoxNoDb.ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    if (!String.IsNullOrWhiteSpace(rCriteriaFound.AliasFldShort.Trim()))
                                    {
                                        IDGroupToLoad = rCriteriaFound.AliasFldShort;
                                    }
                                    else
                                    {
                                        IDGroupToLoad = rCriteriaFound.FldShort;
                                    }
                                    SQLValueListSelect = rCriteriaFound.SQLValueListSelect;
                                    colIsCriteriaComboBox = true;
                                    string FldShortParentReturn = "";
                                    colIsCriteriaComboBoxAndIsInRelation = b.checkColumnComboBoxExistsSelListRelation(IDGroupToLoad.Trim(), IDApplication.Trim(), ref arrRelationship, ref FldShortParentReturn);

                                    //Prüfen, ob die vorherige column FldShortParentReturn ist
                                    if (!String.IsNullOrWhiteSpace(FldShortParentReturn))
                                    {
                                        if (!colPrevPrev.Equals(FldShortParentReturn, StringComparison.OrdinalIgnoreCase))
                                        {
                                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("InconsistentOrderInQuery") + ": "  + qs2.core.language.sqlLanguage.getRes(FldShortParentReturn) + " / " +
                                              qs2.core.language.sqlLanguage.getRes(col.ColumnName), System.Windows.Forms.MessageBoxButtons.OK, "");
                                            return null;                               
                                        }
                                    }
                                }
                                else if (rCriteriaFound.ControlType.Equals(core.Enums.eControlType.CheckBox.ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    colIsCheckBox = true;
                                }
                                else if (rCriteriaFound.ControlType.Equals(core.Enums.eControlType.ThreeStateCheckBox.ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    colIsThreeStateCheckBox = true;
                                }
                            }
                            else
                            {
                                throw new Exception("translateQuery.translateSelList: arrCriteria.Length > 1 !");
                            }

                            if ((colIsCriteriaComboBox || colIsDbComboBox) && !colIsCheckBox && !colIsThreeStateCheckBox)
                            {
                                //colTxt.SetOrdinal(col.Ordinal);
                                bool KeyIsIDOwnStr = false;
                                string TranslationFound = "";

                                qs2.core.vb.dsAdmin.tblSelListGroupRow rGroup = null;
                                qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries = null;
                                this.getSelListGroupForTranslateSelListComboBox(ref ErrField, ref ErrFieldSub, ref IDApplication,
                                                                                ref IDApplicationTmp, ref protocol, ref IDGroupToLoad, col, ref rGroup,
                                                                                ref dtFromQuery, ref arrSelListEntries, true);

                                if (rGroup != null)
                                {
                                    KeyIsIDOwnStr = rGroup.Classification.Equals("Key=IDOwnStr", StringComparison.OrdinalIgnoreCase);

                                    System.Collections.Specialized.ListDictionary lstTranslationsFounded = new System.Collections.Specialized.ListDictionary();
                                    //System.Data.DataRow[] arrOrderCmb = (System.Data.DataRow[])dtFromQuery.Select("", col.ColumnName + " asc");
                                    if (KeyIsIDOwnStr)
                                    {
                                        this.translateSelListComboBoxObj(ref dtFromQuery, ref ErrField, ref ErrFieldSub, col,
                                                                        ref lstTranslationsFounded,
                                                                        ref colCount, ref objTranslated, arrSelListEntries, ref protocol,
                                                                        ref TranslationFound, ref IDGroupToLoad);
                                    }
                                    else
                                    {
                                        List<dsAdmin.tblRelationshipRow> arrRelationsParentEqualsValueTmp = null;
                                        this.translateSelListComboBox(ref dtFromQuery, ref ErrField, ref ErrFieldSub, col,
                                                                        ref lstTranslationsFounded,
                                                                        ref colCount, ref objTranslated, arrSelListEntries, ref protocol,
                                                                        ref TranslationFound, ref IDGroupToLoad, false, null, "", IDApplication, ref SubSelListCboDone, ref arrRelationsParentEqualsValueTmp);
                                    }
                                }
                                //if (colIsCriteriaComboBoxAndIsInRelation)
                                //{
                                //    this.getGroupfromSelectedParentFldShort2xy(IDApplication, ref colPrev, ref arrRelationship, ref iColPrevValueSelList, ref KeyIsIDOwnStr, ref TranslationFound, ref rGroup,
                                //                        ref arrSelListEntries, ref ErrField, ref ErrFieldSub, ref protocol, ref colCount, ref IDGroupToLoad,
                                //                        ref dtFromQuery, col, ref objTranslated);

                                //}
                                if (colIsCriteriaComboBoxAndIsInRelation)
                                {
                                    string colPrevNotTrans = "";
                                    if (colPrev.sEquals(qs2.core.generic.prefixColAutoTranslate, S2Extensions.Enums.eCompareMode.StartsWith))
                                    {
                                        colPrevNotTrans = colPrevPrev;
                                    }
                                    else
                                    {
                                        colPrevNotTrans = colPrev.Trim();
                                    }

                                    System.Collections.Specialized.ListDictionary lstTranslationsFounded = new System.Collections.Specialized.ListDictionary();
                                    this.translateSelListComboBox(ref dtFromQuery, ref ErrField, ref ErrFieldSub, col,
                                                                    ref lstTranslationsFounded,
                                                                   ref colCount, ref objTranslated, arrSelListEntries, ref protocol,
                                                                   ref TranslationFound, ref IDGroupToLoad, true, arrRelationship, colPrevNotTrans, IDApplication,
                                                                   ref SubSelListCboDone, ref arrRelationsParentEqualsValue);
                                }
                            }
                            else if (colIsCheckBox || colIsThreeStateCheckBox)
                            {
                                this.translateCheckThreeStateBoxes(ref dtFromQuery, ref ErrField, ref ErrFieldSub, col,
                                                                    ref colCount, ref objTranslated, ref protocol,
                                                                    ref lstYesNo);
                            }
                            else if (colIsObjectID)
                            {
                                this.translateObjectID(ref dtFromQuery, ref ErrField, ref ErrFieldSub, col,
                                                        ref colCount, ref objTranslated, ref protocol);
                            }
                            else
                            {
                                //string xy = "";
                            }
                        }
                        colPrevPrev = colPrev;
                        colPrev = col.ColumnName;
                    }
                }
                ErrField = "";

                DataTable dtResult = this.TableToArray.copyTranslatedArrayToNewTable(ref objTranslated, ref dtFromQuery);
                this.TableToArray.clearColumnsNotUsedForTranslation(ref dtResult);

                foreach (string columnName in this.lstColsNoRigth)              //lthxy
                {
                    if (dtResult.Columns.Contains(columnName.Trim()))
                    {
                        dtResult.Columns.Remove(columnName.Trim());
                    }
                    else
                    {
                        //string xy = "";
                    }
                }

                dtResult.AcceptChanges();
                return dtResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Column '" + ErrField.Trim() + "' or Error ColumnSub '" + ErrFieldSub.Trim() + "' translateQuery.translateSelList: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public bool getGroupfromSelectedParentFldShort(string IDApplication, string FldShort, ref dsAdmin.tblRelationshipRow[] arrRelationship, ref int iValueSelListEntry,
                                    ref string iGroupStrSelListReturn)
        {
            try
            {
                var RelationsParentEqualsValue = from rRel in arrRelationship.AsEnumerable()
                                                 where rRel.FldShortParent == FldShort.Trim() && rRel.FldShortParent != "" &&
                                                         (rRel.IDApplicationParent == IDApplication.Trim() ||
                                                         rRel.IDApplicationParent == qs2.core.license.doLicense.eApp.ALL.ToString().Trim())
                                                 select rRel;
                bool TransRelationColumnDone = false;
                foreach (dsAdmin.tblRelationshipRow rSelFoundSameValue in RelationsParentEqualsValue)
                {
                    System.Collections.Generic.List<string> lstValuesParent = qs2.core.generic.readStrVariables(rSelFoundSameValue.Conditions.Trim());
                    foreach (string sValParent in lstValuesParent)
                    {
                        if (!TransRelationColumnDone)
                        {
                            int iValParent = System.Convert.ToInt32(sValParent.Trim());
                            if (iValueSelListEntry != -1 && iValueSelListEntry.Equals(iValParent))
                            {

                                iGroupStrSelListReturn = rSelFoundSameValue.IDKey.Trim();
                                return true;
                            }
                        }
                    }
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("getGroupfromSelectedParentFldShort: " + ex.ToString());
            }
        }
        public void getSelListGroupForTranslateSelListComboBox(ref string ErrField, ref string ErrFieldSub, ref string IDApplication, ref string IDApplicationTmp,
                                                            ref string protocol, ref string IDGroupToLoad, DataColumn col,
                                                            ref qs2.core.vb.dsAdmin.tblSelListGroupRow rGroup, ref DataTable dtFromQuery,
                                                            ref qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries, bool doColumn)
        {
            try
            {
                //colTxt.SetOrdinal(col.Ordinal);
                qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrp = this.sqlAdmin1.getSelListGroup(ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGroupToLoad, "ALL", IDApplication);
                if (arrGrp.Length != 1)
                {
                    arrGrp = this.sqlAdmin1.getSelListGroup(ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGroupToLoad, "ALL", qs2.core.license.doLicense.eApp.ALL.ToString());
                    if (arrGrp.Length != 1)
                    {
                        //throw new Exception("translateSelList: No rGroup found for IDGroup '" + col.ColumnName + "'!");
                        //string xy = "";
                    }
                    else
                    {
                        IDApplicationTmp = qs2.core.license.doLicense.eApp.ALL.ToString();
                    }
                }
                if (arrGrp.Length > 1)
                {
                    throw new Exception("translateQuery.translateSelList: arrGrp.Length > 1 for FldShort '" + IDGroupToLoad + "'!");
                }

                if (arrGrp.Length == 1)
                {
                    rGroup = arrGrp[0];
                    string colNameToSearch = qs2.core.generic.TransEmpty + "" + col.ColumnName;

                    if (!this.lstUnvisibleCols.Contains(col.ColumnName))
                    {
                        this.lstUnvisibleCols.Add(col.ColumnName);
                    }
                    string colNameNew = qs2.core.generic.prefixColAutoTranslate + "" + col.ColumnName;
                    if (dtFromQuery.Columns.Contains(colNameToSearch))
                    {
                        dtFromQuery.Columns[colNameToSearch].ColumnName = colNameNew;
                    }

                    qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    arrSelListEntries = this.sqlAdmin1.getSelListEntrys(ref Parameters, "", qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplicationTmp, ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", -1, "", rGroup.ID);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Column '" + ErrField.Trim() + "' or Error ColumnSub '" + ErrFieldSub.Trim() + "' translateQuery.getSelListGroupForTranslateSelListComboBox: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateSelListComboBox(ref DataTable dtFromQuery, ref string ErrField, ref string ErrFieldSub, DataColumn col,
                                        ref System.Collections.Specialized.ListDictionary lstTranslationsFounded, ref int colCount,
                                        ref Object[,] objTranslated, qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries,
                                        ref string protocol, ref string TranslationFound, ref string IDGroupToLoad, bool colIsCriteriaComboBoxAndIsInRelation,
                                        dsAdmin.tblRelationshipRow[] arrRelationship, string colPrevNotTrans, string IDApplication, ref bool SubSelListCboDone,
                                        ref List<dsAdmin.tblRelationshipRow> arrRelationsParentEqualsValue)
        {
            try
            {
                int rowCount = 0;
                int oldValue = -999;
                foreach (DataRow r in dtFromQuery.Rows)
                {
                    try
                    {
                        ErrFieldSub = r[col.ColumnName] + "" + "\r\n";
                        //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ErrFieldSub, "undefined", false))
                        //{
                        //    string xy = "";
                        //}

                        if (r[col.ColumnName] != System.DBNull.Value)
                        {
                            int objColValueToTranlate = -999;
                            try
                            {
                                objColValueToTranlate = Convert.ToInt32(r[col.ColumnName]);
                            }
                            catch (Exception ex)
                            {
                                objColValueToTranlate = -999;
                                //string xy = ex.ToString();
                                //throw new Exception("Error - cannot translate Combobox because field '" + ErrField + "' is not an integer in database!");
                            }
                            //iColPrevValueSelList = objColValueToTranlate;
                            if (!colIsCriteriaComboBoxAndIsInRelation && lstTranslationsFounded.Contains(objColValueToTranlate))
                            {
                                objTranslated[rowCount, colCount] = lstTranslationsFounded[objColValueToTranlate];
                            }
                            else
                            {
                                if (colIsCriteriaComboBoxAndIsInRelation)
                                {
                                    bool FirstTransCol = true;
                                    //if (!SubSelListCboDone)
                                    //{
                                        arrSelListEntries = null;
                                        var RelationsParentEqualsValue = from rRel in arrRelationship.AsEnumerable()
                                                                         where rRel.FldShortParent.Equals(colPrevNotTrans.Trim(), StringComparison.OrdinalIgnoreCase) && rRel.FldShortParent != "" &&
                                                                                 (rRel.IDApplicationParent == IDApplication.Trim() ||
                                                                                 rRel.IDApplicationParent == qs2.core.license.doLicense.eApp.ALL.ToString().Trim())
                                                                         select rRel;
                                        arrRelationsParentEqualsValue = RelationsParentEqualsValue.ToList();
                                        SubSelListCboDone = true;
                                    //}
                                    //else
                                    //{
                                    //    FirstTransCol = false;
                                    //}

                                    foreach (dsAdmin.tblRelationshipRow rSelFoundSameValue in arrRelationsParentEqualsValue)
                                    {
                                        System.Collections.Generic.List<string> lstValuesParent = qs2.core.generic.readStrVariables(rSelFoundSameValue.Conditions.Trim());
                                        foreach (string sValParent in lstValuesParent)
                                        {
                                            //if (!TransRelationColumnDone)
                                            //{
                                            int iValParent = System.Convert.ToInt32(sValParent.Trim());
                                            if (r[colPrevNotTrans.Trim()].Equals(iValParent))
                                            {
                                                string iGroupStrSelList = rSelFoundSameValue.IDKey.Trim();
                                                TranslationFound = "";
                                                dsAdmin.tblSelListGroupRow rGroup = null;
                                                arrSelListEntries = null;
                                                string IDApplicationTmp = IDApplication.Trim();
                                                this.getSelListGroupForTranslateSelListComboBox(ref ErrField, ref ErrFieldSub, ref IDApplication,
                                                                                                ref IDApplicationTmp, ref protocol, ref iGroupStrSelList, col,
                                                                                                ref rGroup, ref dtFromQuery, ref arrSelListEntries, FirstTransCol);
                                                //if (rGroup != null)
                                                //{
                                                //}

                                                break;
                                            }
                                            //}
                                        }
                                    }
                                }

                                //if (objColValueToTranlateoldValue == -999 || (objColValueToTranlate != objColValueToTranlateoldValue))
                                //{
                                int countSelList = 0;
                                bool bTranslationFound = false;
                                if (arrSelListEntries != null)
                                {
                                    do
                                    {
                                        qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntryFound = arrSelListEntries[countSelList];
                                        //if (objColValueToTranlate.GetType().Equals(typeof(int)))
                                        //{
                                        if (rSelListEntryFound.IDOwnInt.Equals(System.Convert.ToInt32(objColValueToTranlate)))
                                        {
                                            TranslationFound = qs2.core.language.sqlLanguage.getRes(rSelListEntryFound.IDRessource, true, true).Trim();
                                            if (TranslationFound.Equals(""))
                                            {
                                                TranslationFound = rSelListEntryFound.IDRessource;
                                            }
                                            if (!SubSelListCboDone)
                                            {
                                                lstTranslationsFounded.Add(objColValueToTranlate, TranslationFound);
                                            }
                                            bTranslationFound = true;
                                        }
                                        //}
                                        countSelList += 1;
                                    } while (!bTranslationFound && (countSelList < arrSelListEntries.Length));
                                }

                                if (bTranslationFound)
                                {
                                    objTranslated[rowCount, colCount] = TranslationFound;
                                }
                                else
                                {
                                    if (colIsCriteriaComboBoxAndIsInRelation && (int)r[colPrevNotTrans.Trim()] == -1)
                                    {
                                        objTranslated[rowCount, colCount] = "";
                                    }
                                    else
                                    {
                                        if (colIsCriteriaComboBoxAndIsInRelation)
                                        {
                                            objTranslated[rowCount, colCount] = objColValueToTranlate.ToString();
                                        }
                                        else
                                        {
                                            objTranslated[rowCount, colCount] = objColValueToTranlate.ToString() + " (" + qs2.core.language.sqlLanguage.getRes("InvalidValue", true, true) + ")";
                                            protocol += "Warning: Field: '" + col.ColumnName + "' - Value '" + objColValueToTranlate.ToString() + "' not found in SelList-Group '" + IDGroupToLoad + ".\r\n\r\n";
                                        }
                                    }
                                }

                            }
                            oldValue = objColValueToTranlate;
                        }
                        else
                        {
                            objTranslated[rowCount, colCount] = "null";
                            oldValue = -999;
                        }
                        rowCount += 1;

                    }
                    catch (Exception ex)
                    {
                        string errTmp = "Error Cell-Value " + ErrFieldSub + " - " + ex.ToString() + "\r\n";
                        protocol += errTmp;
                        throw new Exception(errTmp);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Column '" + ErrField.Trim() + "' or Error ColumnSub '" + ErrFieldSub.Trim() + "' translateQuery.translateSelListComboBox: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateSelListComboBoxObj(ref DataTable dtFromQuery, ref string ErrField, ref string ErrFieldSub, DataColumn col,
                                                ref System.Collections.Specialized.ListDictionary lstTranslationsFounded, ref int colCount,
                                                ref Object[,] objTranslated, qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries,
                                                ref string protocol, ref string TranslationFound, ref string IDGroupToLoad)
        {
            try
            {
                int rowCount = 0;
                foreach (DataRow r in dtFromQuery.Rows)
                {
                    try
                    {
                        ErrFieldSub = r[col.ColumnName] + "" + "\r\n";
                        if (r[col.ColumnName] != System.DBNull.Value)
                        {
                            string sValueToSearch = "";
                            string objColValueToTranlate = "";
                            int countSelList = 0;
                            bool bTranslationFound = false;
                                
                            objColValueToTranlate = r[col.ColumnName].ToString().Trim();
                            List<dsAdmin.tblSelListEntriesRow> arr = arrSelListEntries.Where(s => s.IDOwnStr.Equals(objColValueToTranlate, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (arr.Count > 0)
                                sValueToSearch = arrSelListEntries.Where(s => s.IDOwnStr.Equals(objColValueToTranlate, StringComparison.OrdinalIgnoreCase)).ToList().FirstOrDefault().IDRessource;

                            do
                            {
                                TranslationFound = qs2.core.language.sqlLanguage.getRes(sValueToSearch, true, true).Trim();
                                if (String.IsNullOrWhiteSpace(TranslationFound))
                                {
                                    TranslationFound = objColValueToTranlate.Trim();
                                }
                                bTranslationFound = true;
                                countSelList += 1;
                            } while (!bTranslationFound && (countSelList < arrSelListEntries.Length));

                            if (bTranslationFound)
                            {
                                objTranslated[rowCount, colCount] = TranslationFound;
                            }
                            else
                            {
                                string err = col.ColumnName + "'-'" + objColValueToTranlate.ToString();
                                objTranslated[rowCount, colCount] = err;
                                //protocol += err + "\r\n\r\n";
                            }
                        }
                        else
                        {
                            objTranslated[rowCount, colCount] = col.ColumnName + "?";
                        }
                        rowCount += 1;
                    }
                    catch (Exception ex)
                    {
                        string errTmp = "Error Cell-Value " + ErrFieldSub + " - " + ex.ToString() + "\r\n";
                        protocol += errTmp;
                        throw new Exception(errTmp);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Column '" + ErrField.Trim() + "' or Error ColumnSub '" + ErrFieldSub.Trim() + "' translateQuery.translateSelListComboBoxObj: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateCheckThreeStateBoxes(ref DataTable dtFromQuery, ref string ErrField, ref string ErrFieldSub, DataColumn col,
                                                    ref int colCount, ref Object[,] objTranslated,
                                                    ref string protocol,
                                                    ref System.Collections.Specialized.ListDictionary lstYesNo)
        {
            try
            {
                //bool containsTransCol = false;
                string colNameToSearch = qs2.core.generic.TransEmpty + "" + col.ColumnName;
                //if (dtFromQuery.Columns.Contains(colNameToSearch))
                //{
                string colNameNew = qs2.core.generic.prefixColAutoTranslate + "" + col.ColumnName;
                dtFromQuery.Columns[colNameToSearch].ColumnName = colNameNew;
                //containsTransCol = true;
                //}
                this.lstUnvisibleCols.Add(col.ColumnName);

                string TranslationFound = "";
                int oldValue = -999;
                int rowCount = 0;
                //System.Data.DataRow[] arrOrderCmb = (System.Data.DataRow[])dtFromQuery.Select("", col.ColumnName + " asc");
                foreach (DataRow r in dtFromQuery.Rows)
                {
                    try
                    {
                        ErrFieldSub = r[col.ColumnName] + " (colIsCheckBox or  colIsThreeStateCheckBox) " + "\r\n";
                        int objColValueToTranlate = -999;
                        bool isNumeric = true;
                        if (r[col.ColumnName] != System.DBNull.Value)
                        {
                            //if (colIsCheckBox)
                            //{
                            //}
                            if (r[col.ColumnName].GetType().Equals(typeof(int)) || r[col.ColumnName].GetType().Equals(typeof(double)))  //double für OLAP-Excel-Import
                            {
                                objColValueToTranlate = Convert.ToInt32(r[col.ColumnName]);
                            }
                            else if (r[col.ColumnName].GetType().Equals(typeof(bool)))
                            {
                                if ((bool)r[col.ColumnName] == true)
                                {
                                    objColValueToTranlate = 1;
                                }
                                else
                                {
                                    objColValueToTranlate = 0;
                                }
                            }
                            else if (r[col.ColumnName].GetType().Equals(typeof(string)))    //Bei Import von Excel kann der Value auch Typ string sein
                            {
                                isNumeric = false;
                                objTranslated[rowCount, colCount] = TranslationFound; 
                            }
                            else
                            {
                                throw new Exception("Error - cannot translate Check-Box or ThreeState-Box because field '" + ErrField + "' is not a bit, integer, double or string!");
                            }

                            if (isNumeric)
                            {
                                if (objColValueToTranlate == 1)
                                {
                                    TranslationFound = lstYesNo[1].ToString();
                                }
                                else if (objColValueToTranlate == 0)
                                {
                                    TranslationFound = lstYesNo[0].ToString();
                                }
                                else if (objColValueToTranlate == -1)
                                {
                                    TranslationFound = lstYesNo[-1].ToString();
                                }
                                else
                                {
                                    TranslationFound = objColValueToTranlate.ToString() + "(" + qs2.core.language.sqlLanguage.getRes("InvalidValue") + ")";
                                    string err = "Value for Threestate Checkbox not allowed. Value = " + objColValueToTranlate.ToString() + "";
                                    protocol += err + "\r\n\r\n";
                                }

                                objTranslated[rowCount, colCount] = TranslationFound;
                            }
                        }
                        else
                        {
                            objTranslated[rowCount, colCount] = "null";
                        }
                        oldValue = objColValueToTranlate;
                        rowCount += 1;
                    }
                    catch (Exception ex)
                    {
                        string errTmp = "Error Cell-Value " + ErrFieldSub + " - " + ex.ToString() + "\r\n";
                        protocol += errTmp;
                        throw new Exception(errTmp);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Column '" + ErrField.Trim() + "' or Error ColumnSub '" + ErrFieldSub.Trim() + "' translateQuery.translateCheckThreeStateBoxes: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateObjectID(ref DataTable dtFromQuery, ref string ErrField, ref string ErrFieldSub, DataColumn col,
                                            ref int colCount, ref Object[,] objTranslated,
                                            ref string protocol)
        {
            try
            {
                string colNameToSearch = qs2.core.generic.TransEmpty + "" + col.ColumnName;

                string colNameNew = qs2.core.generic.prefixColAutoTranslate + "" + col.ColumnName;
                dtFromQuery.Columns[colNameToSearch].ColumnName = colNameNew;
                this.lstUnvisibleCols.Add(col.ColumnName);

                int rowCount = 0;
                foreach (DataRow r in dtFromQuery.Rows)
                {
                    try
                    {
                        ErrFieldSub = r[col.ColumnName] + " (colIsObjectID)" + "\r\n";
                        if (r[col.ColumnName] != System.DBNull.Value)
                        {
                            object objColValueToTranlate = (int)r[col.ColumnName];
                            this.dsObjects1.tblObject.Clear();
                            this.sqlObjects1.initControl();
                            if (objColValueToTranlate.GetType().Equals(typeof(int)))
                            {
                                if ((int)objColValueToTranlate != -1)
                                {
                                    this.sqlObjects1.getObject((int)objColValueToTranlate, ref this.dsObjects1, core.vb.sqlObjects.eTypSelObj.ID);
                                    if (this.dsObjects1.tblObject.Rows.Count == 1)
                                    {
                                        qs2.core.vb.dsObjects.tblObjectRow rObj = (qs2.core.vb.dsObjects.tblObjectRow)this.dsObjects1.tblObject.Rows[0];
                                        objTranslated[rowCount, colCount] = qs2.core.vb.sqlObjects.getNameCombination(ref rObj);
                                    }
                                    else
                                    {
                                        string err = "rObject.ID '" + objColValueToTranlate.ToString() + "' not found in Db!";
                                        //throw new Exception(err);
                                        protocol += err + "\r\n\r\n";
                                    }
                                }
                                else
                                {
                                    //string xy = "";
                                }
                            }
                            else if (objColValueToTranlate.GetType().Equals(typeof(System.Guid)))
                            {
                                if (objColValueToTranlate != System.DBNull.Value)
                                {
                                    if ((System.Guid)objColValueToTranlate != System.Guid.Empty)
                                    {
                                        this.sqlObjects1.getObject(-99, ref this.dsObjects1, core.vb.sqlObjects.eTypSelObj.IDGuid, core.vb.sqlObjects.eTypObj.none, "", "", false, (System.Guid)objColValueToTranlate);
                                        if (this.dsObjects1.tblObject.Rows.Count == 1)
                                        {
                                            qs2.core.vb.dsObjects.tblObjectRow rObj = (qs2.core.vb.dsObjects.tblObjectRow)this.dsObjects1.tblObject.Rows[0];
                                            objTranslated[rowCount, colCount] = qs2.core.vb.sqlObjects.getNameCombination(ref rObj);
                                        }
                                        else
                                        {
                                            string err = "rObject.IDGuid '" + objColValueToTranlate.ToString() + "' not found in Db!";
                                            //throw new Exception(err);
                                            protocol += err + "\r\n\r\n";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Field: '" + col.ColumnName + "' - Value-Type '" + objColValueToTranlate.GetType().Name + "' is wrong for Translate tblObject.Name!");
                            }
                        }
                        else
                        {
                            objTranslated[rowCount, colCount] = "";
                        }
                        rowCount += 1;
                    }
                    catch (Exception ex)
                    {
                        string errTmp = "Error Cell-Value " + ErrFieldSub + " - " + ex.ToString() + "\r\n";
                        protocol += errTmp;
                        throw new Exception(errTmp);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Column '" + ErrField.Trim() + "' or Error ColumnSub '" + ErrFieldSub.Trim() + "' translateQuery.translateObjectID: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }




        public void translateColumnsTRANSxy(DataTable dtToTranslate, UltraGrid grid, string IDApplication)
        {
            try
            {
                System.Collections.Generic.List<System.Data.DataColumn> lstCols = new System.Collections.Generic.List<System.Data.DataColumn>();
                foreach (DataColumn col in dtToTranslate.Columns)
                {
                    lstCols.Add(col);
                }
                System.Collections.Generic.List<string> lstSelListWasPrinted = new List<string>();

                //System.Collections.Generic.List<UltraGridColumn> lstColsHidden= new System.Collections.Generic.List<UltraGridColumn>();
                foreach (DataColumn col in lstCols)
                {
                    //string IDGroupToLoad = "";
                    //core.Enums.eControlType typeRet = new core.Enums.eControlType();
                    //typeRet = core.Enums.eControlType.Textfield;
                    qs2.core.vb.dsAdmin dsSelListFound = new qs2.core.vb.dsAdmin();

                    if (col.ColumnName.sEquals(qs2.core.generic.prefixColAutoTranslateFunctions, S2Extensions.Enums.eCompareMode.StartsWith))
                    {
                        foreach (DataRow r in dtToTranslate.Rows)
                        {
                            if (r[col.ColumnName] != System.DBNull.Value)
                            {
                                if (r[col.ColumnName].GetType().Equals(typeof(string)))
                                {
                                    //int startIndex = -1;
                                    //string var = qs2.core.generic.readStrBetween(defTrans, ref startIndex, "(", ")", true, true, true);
                                    System.Collections.Generic.List<string> lstDefTrans = qs2.core.generic.readStrVariables(r[col.ColumnName].ToString());
                                    System.Collections.Generic.List<cVariables> lstVariables = new System.Collections.Generic.List<cVariables>();
                                    foreach (string defTrans in lstDefTrans)
                                    {
                                        cVariables cVariableNew = new cVariables();
                                        qs2.core.vb.funct.getVariablesLefRightOfPoint(defTrans, ref cVariableNew.definition, ref cVariableNew.value, "=");
                                        lstVariables.Add(cVariableNew);
                                        // Type = IDOwnStr; IDGroupStr = ProcGrp0; IDApplication = VASCULAR;
                                        // Type=IDOwnInt;FldShort=Mt30Stat;IDApplication=ALL;
                                    }
                                    if (lstVariables.Count != 3)
                                    {
                                        throw new Exception("translateQuery.translateColumnsTRANS: lstVariables.Count != 3 !");
                                    }

                                    //tblObject.ID AS IDObjectNameCombination, 
                                    //'Type=ID;Table=tblObject;TransColumn=NameCombination;' AS TRANS_IDObjectNameCombination, 
                                    string colValueNameValue = col.ColumnName.Substring(qs2.core.generic.prefixColAutoTranslateFunctions.Length, col.ColumnName.Length - qs2.core.generic.prefixColAutoTranslateFunctions.Length);
                                    if (r[colValueNameValue] != System.DBNull.Value)
                                    {
                                        object ValueToTranslate = r[colValueNameValue];
                                        cVariables cVariableKeySelList = lstVariables[0];
                                        cVariables cVariableDef = lstVariables[1];
                                        cVariables cVariableApplication = lstVariables[2];
                                        if (cVariableDef.definition.sEquals("FldShort"))
                                        {
                                            this.dsAdmin1.Clear();
                                            qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteriaTrans = this.sqlAdmin1.getCriterias(this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, cVariableDef.value, cVariableApplication.value, false, false, false, "", "", false);
                                            if (arrCriteriaTrans.Length != 1)
                                            {
                                                throw new Exception("translateQuery.translateColumnsTRANS: No rCriteria found for IDGroup '" + col.ColumnName + "'!");
                                            }
                                            else
                                            {
                                                string Translation = "";
                                                bool GroupNotFound = false;
                                                bool IDSelListNotFound = false;
                                                string lstTxtAllSelListEntries = "";
                                                this.translateValue(cVariableKeySelList.value, cVariableApplication.value, arrCriteriaTrans[0].FldShort,
                                                                    ref Translation, ref ValueToTranslate, true,
                                                                    ref GroupNotFound, ref IDSelListNotFound, ref lstTxtAllSelListEntries, 
                                                                    false, ref lstSelListWasPrinted, false, false);
                                                r[col.ColumnName] = Translation.Trim();
                                            }
                                        }
                                        else if (cVariableDef.definition.sEquals("IDGroupStr"))
                                        {
                                            string Translation = "";
                                            bool GroupNotFound = false;
                                            bool IDSelListNotFound = false;
                                            string lstTxtAllSelListEntries = "";
                                            this.translateValue(cVariableKeySelList.value, cVariableApplication.value, cVariableDef.value,
                                                                ref Translation, ref ValueToTranslate, true,
                                                                ref GroupNotFound, ref IDSelListNotFound, ref lstTxtAllSelListEntries, false, 
                                                                ref lstSelListWasPrinted, false, false);
                                            r[col.ColumnName] = Translation.Trim();
                                        }
                                        else
                                        {
                                            throw new Exception("translateQuery.translateColumnsTRANS: Definition for lstVariables[1].definition is wrong! definition='" + lstVariables[1].definition.Trim() + "'!");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("translateQuery.translateColumnsTRANS: colValueNameValue is wrong! colValueNameValue='" + colValueNameValue.Trim() + "'!");
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (string columnName in this.lstUnvisibleCols)
                {
                    if (grid != null)
                    {
                        grid.DisplayLayout.Bands[0].Columns[columnName].Hidden = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("translateQuery.translateColumnsTRANS: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void translateValue(string KeySelList, string Application, string IDGroupStr,
                                    ref string Translation, ref object ValueToTranslate,
                                    bool DoExceptionNotFound, ref bool GroupNotFound, ref bool IDSelListNotFound, ref string lstTxtAllSelListEntries,
                                    bool doListTxt, ref System.Collections.Generic.List<string> lstSelListWasPrinted,
                                    bool printEntrySheet, bool bPrintDbTypes)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrpTransTrans = this.sqlAdmin1.getSelListGroup(ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGroupStr, "ALL", Application);
                if (arrGrpTransTrans.Length != 1)
                {
                    arrGrpTransTrans = this.sqlAdmin1.getSelListGroup(ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGroupStr, "ALL", qs2.core.license.doLicense.eApp.ALL.ToString());
                    if (arrGrpTransTrans.Length != 1)
                    {
                        GroupNotFound = true;
                        if (DoExceptionNotFound)
                        {
                            throw new Exception("translateColumnsTRANSSelList.arrGrpTransTrans: No rGroup found for IDGroup '" + Application + "'!");
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Application = qs2.core.license.doLicense.eApp.ALL.ToString();
                    }
                }
                if (arrGrpTransTrans.Length == 1)
                {
                    qs2.core.vb.dsAdmin.tblSelListGroupRow rGroup = arrGrpTransTrans[0];
                    if (printEntrySheet)
                    {
                        bool WasPrinted = false;
                        foreach (string IDGroupStrWasPrinted in lstSelListWasPrinted)
                        {
                            if (IDGroupStrWasPrinted.sEquals(IDGroupStr))
                            {
                                WasPrinted = true;
                            }
                        }
                        if (WasPrinted)
                        {
                            //return;
                        }

                        lstSelListWasPrinted.Add(IDGroupStr.Trim());
                    }

                    qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntriesTrans = null;
                    qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    arrSelListEntriesTrans = this.sqlAdmin1.getSelListEntrys(ref Parameters, "", qs2.core.license.doLicense.eApp.ALL.ToString(), Application, ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", -1, "", rGroup.ID);
                    //if (arrSelListEntriesTrans.Length == 0)
                    //{
                    //    arrSelListEntriesTrans = this.sqlAdmin1.getSelListEntrys(ref Parameters, "", qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.eApp.ALL.ToString() , ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", -1, "", rGroup.ID);
                    //}

                    System.Collections.Generic.List<string> lstSelLists = new List<string>();
                    if (arrSelListEntriesTrans.Length > 0)
                    {
                        int iCounterAdded = 0;
                        foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntryFound in arrSelListEntriesTrans)
                        {
                            if (KeySelList.sEquals("IDOwnInt"))
                            {
                                if (rSelListEntryFound.IDOwnInt.Equals(System.Convert.ToInt32(ValueToTranslate)) || doListTxt)
                                {
                                    Translation = qs2.core.language.sqlLanguage.getRes(rSelListEntryFound.IDRessource, true, true);
                                    if (String.IsNullOrWhiteSpace(Translation))
                                    {
                                        Translation = rSelListEntryFound.IDRessource.Trim();
                                    }
                                    
                                    if (bPrintDbTypes)
                                    {
                                        Translation = "[" + rSelListEntryFound.IDOwnInt.ToString() + "] " + Translation;
                                    }
                                    lstSelLists.Add(Translation.Trim());
                                    iCounterAdded += 1;
                                    if (!doListTxt)
                                        return;
                                }
                            }
                            else if (KeySelList.sEquals("IDOwnStr"))
                            {
                                if (rSelListEntryFound.IDOwnStr.Equals(System.Convert.ToString(ValueToTranslate)) || doListTxt)
                                {
                                    Translation = qs2.core.language.sqlLanguage.getRes(rSelListEntryFound.IDRessource, true, true);
                                    if (String.IsNullOrWhiteSpace(Translation))
                                    {
                                        Translation = rSelListEntryFound.IDRessource.Trim();
                                    }
                                    
                                    lstSelLists.Add(Translation.Trim());
                                    iCounterAdded += 1;
                                    if (!doListTxt)
                                        return;
                                }
                            }
                            else
                            {
                                if (DoExceptionNotFound)
                                {
                                    throw new Exception("translateQuery.translateValue: Definition for cVariableKeySelList.value is wrong! value='" + KeySelList.Trim() + "'!");
                                }
                                else
                                {
                                    throw new Exception("translateQuery.translateValue: Definition for cVariableKeySelList.value is wrong! value='" + KeySelList.Trim() + "'!");
                                }
                            }
                        }
                        IDSelListNotFound = true;
                        //string noEntrySelListFound = "";
                    }
                    else
                    {
                        Translation = "[Error: No SelList-Entries found in Group]";
                        //string noSelListsFound = "";
                    }

                    int nBiggestSelList = 0;
                    foreach (string SelListEntry in lstSelLists)
                    {
                        if (SelListEntry.Trim().Length > nBiggestSelList)
                        {
                            nBiggestSelList = SelListEntry.Trim().Length;
                        }
                    }
                    if (nBiggestSelList < 7)
                    {
                        this.formatSelList(nBiggestSelList, ref lstTxtAllSelListEntries, ref lstSelLists, 4);
                    }
                    else if (nBiggestSelList < 10)
                    {
                        this.formatSelList(nBiggestSelList, ref lstTxtAllSelListEntries, ref lstSelLists, 3);
                    }
                    else if (nBiggestSelList < 20)
                    {
                        this.formatSelList(nBiggestSelList, ref lstTxtAllSelListEntries, ref lstSelLists, 2);
                    }
                    else
                    {
                        this.formatSelList(nBiggestSelList, ref lstTxtAllSelListEntries, ref lstSelLists, 1);
                    }

                    if (IDGroupStr.sEquals("CountryID") ||
                        IDGroupStr.sEquals(new List<object> { "PatOrigin", "DisLoctn", "RefCardDept", "DisLoctnDesc" }, S2Extensions.Enums.eCompareMode.Contains))
                    {
                        lstTxtAllSelListEntries = "";
                    }

                    if (rGroup.Classification.sEquals("DoNotPrint", S2Extensions.Enums.eCompareMode.Contains))
                    {
                        lstTxtAllSelListEntries = "";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("translateQuery.translateValue: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nBiggestSelList"></param>
        /// <param name="lstTxtAllSelListEntries"></param>
        /// <param name="lstSelLists"></param>
        /// <param name="MaxCols"></param>
        public void formatSelList(int nBiggestSelList, ref string lstTxtAllSelListEntries, ref System.Collections.Generic.List<string> lstSelLists,
                                    int MaxCols)
        {
            try
            {
                string sCheckBox = "O ";
                int actCol = 0;
                int iCounter = 0;
                foreach (string txtSelListEntry in lstSelLists)
                {
                    string emptyStrings = "";
                    string newLine = "";
                    if (actCol >= MaxCols)
                    {
                        newLine = "\r\n";
                        emptyStrings = "   ";
                        actCol = 0;
                    }
                    if (iCounter == 0)
                    {
                        emptyStrings = "   ";
                    }
                    string newSelList = sCheckBox + txtSelListEntry.Trim();
                    newSelList = qs2.core.generic.getLineForEntrySheet(newSelList.Trim(), nBiggestSelList + 2, " ", false);
                    lstTxtAllSelListEntries += newLine + emptyStrings + newSelList;

                    actCol += 1;
                    iCounter += 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("formatSelList: " + ex.ToString());
            }
        }

        public System.Collections.Specialized.ListDictionary getRessourceThreeStateButtons()
        {
            System.Collections.Specialized.ListDictionary lstYesNo = new System.Collections.Specialized.ListDictionary();           
            lstYesNo.Add(1, String.IsNullOrWhiteSpace(qs2.core.language.sqlLanguage.getRes("True")) ? "Yes" : qs2.core.language.sqlLanguage.getRes("True"));
            lstYesNo.Add(0, String.IsNullOrWhiteSpace(qs2.core.language.sqlLanguage.getRes("False")) ? "No" : qs2.core.language.sqlLanguage.getRes("False"));
            lstYesNo.Add(-1, String.IsNullOrWhiteSpace(qs2.core.language.sqlLanguage.getRes("Indeterminate")) ? "Indeterminate" : qs2.core.language.sqlLanguage.getRes("Indeterminate"));
            return lstYesNo;
        }

        public void translateSelList_old(DataTable dtToTranslate, UltraGrid grid, string IDApplication)
        {
            try
            {
                System.Collections.Generic.List<System.Data.DataColumn> lstCols = new System.Collections.Generic.List<System.Data.DataColumn>();
                foreach (DataColumn col in dtToTranslate.Columns)
                {
                    lstCols.Add(col);
                }
                Console.Write("Start: " + DateTime.Now.ToString());

                int iGesamt = 0;
                int iakt = 0;
                int iSelLists = 0;
                int iCheckBox = 0;
                int iNone = 0;
                System.Collections.ArrayList ar = new System.Collections.ArrayList();

                //System.Collections.Generic.List<UltraGridColumn> lstColsHidden= new System.Collections.Generic.List<UltraGridColumn>();
                foreach (DataColumn col in lstCols)
                {

                    iakt += 1;
                    string IDApplicationTmp = "";
                    IDApplicationTmp = IDApplication;
                    string IDGroupToLoad = "";
                    //core.Enums.eControlType typeRet = new core.Enums.eControlType();
                    //typeRet = core.Enums.eControlType.Textfield;
                    qs2.core.vb.dsAdmin dsSelListFound = new qs2.core.vb.dsAdmin();

                    bool colIsCriteriaComboBox = false;
                    bool colIsDbComboBox = false;
                    string SQLValueListSelect = "";

                    bool colIsCheckBox = false;
                    bool colIsThreeStateCheckBox = false;

                    qs2.core.vb.dsAdmin.tblCriteriaRow rCriteriaFound = null;
                    this.dsAdmin1.Clear();
                    qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteriaFound = this.sqlAdmin1.getCriterias(this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam,
                                                                                                        col.ColumnName, IDApplication, false, false, false, "", "", false);
                    if (arrCriteriaFound.Length == 0)
                    {
                        arrCriteriaFound = this.sqlAdmin1.getCriterias(this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, col.ColumnName, "ALL", false, false,
                                                                        false, "", "", false);
                        if (arrCriteriaFound.Length == 0)
                        {
                        }
                    }
                    if (arrCriteriaFound.Length == 0)
                    {
                        colIsDbComboBox = true;
                        IDGroupToLoad = col.ColumnName;
                    }
                    else if (arrCriteriaFound.Length == 1)
                    {
                        rCriteriaFound = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriteriaFound[0];
                        if (rCriteriaFound.ControlType.Equals(core.Enums.eControlType.ComboBox.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            if (!string.IsNullOrWhiteSpace(rCriteriaFound.AliasFldShort))
                            {
                                IDGroupToLoad = rCriteriaFound.AliasFldShort;
                            }
                            else
                            {
                                IDGroupToLoad = rCriteriaFound.FldShort;
                            }
                            SQLValueListSelect = rCriteriaFound.SQLValueListSelect;
                            colIsCriteriaComboBox = true;
                        }
                        else if (rCriteriaFound.ControlType.Equals(core.Enums.eControlType.CheckBox.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            colIsCheckBox = true;
                        }
                        else if (rCriteriaFound.ControlType.Equals(core.Enums.eControlType.ThreeStateCheckBox.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            colIsThreeStateCheckBox = true;
                        }
                    }
                    else
                    {
                        throw new Exception("translateQuery.translateSelList: arrCriteria.Length > 1 !");
                    }


                    if ((colIsCriteriaComboBox || colIsDbComboBox) && !colIsCheckBox && !colIsThreeStateCheckBox)
                    {

                        iSelLists += 1;
                        Console.Write("Number: " + iakt.ToString() + " ComboBox: " + IDGroupToLoad + " " + DateTime.Now.ToString() + " Gesamt: " + iGesamt.ToString() + "\r\n");

                        //colTxt.SetOrdinal(col.Ordinal);
                        qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrp = this.sqlAdmin1.getSelListGroup(ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGroupToLoad, "ALL", IDApplication);
                        if (arrGrp.Length != 1)
                        {
                            arrGrp = this.sqlAdmin1.getSelListGroup(ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGroupToLoad, "ALL", qs2.core.license.doLicense.eApp.ALL.ToString());
                            if (arrGrp.Length == 1)
                            {
                                IDApplicationTmp = qs2.core.license.doLicense.eApp.ALL.ToString();
                            }
                        }

                        if (arrGrp.Length > 1)
                        {
                            throw new Exception("translateQuery.translateSelList: arrGrp.Length > 1 for FldShort '" + IDGroupToLoad + "'!");
                        }

                        if (arrGrp.Length == 1)
                        {
                            qs2.core.vb.dsAdmin.tblSelListGroupRow rGroup = arrGrp[0];

                            string colNameNew = qs2.core.generic.prefixColAutoTranslate + "" + col.ColumnName;
                            System.Data.DataColumn colTxt = dtToTranslate.Columns.Add(colNameNew, typeof(string));
                            dtToTranslate.Columns[colNameNew].SetOrdinal(dtToTranslate.Columns[col.ColumnName].Ordinal + 1);

                            this.lstUnvisibleCols.Add(col.ColumnName);

                            DataSet dsFilledSqlSelList = new DataSet();
                            qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries = null;
                            if (!String.IsNullOrWhiteSpace(SQLValueListSelect))
                            {
                                core.vb.sqlAdmin sqlAdminFill = new core.vb.sqlAdmin();
                                string ParametersAsTxt = "";
                                System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
                                qs2.core.dbBase.fillDataSet(SQLValueListSelect.Trim(), parameters, ref dsFilledSqlSelList, "tblCombo", "ds1", ref ParametersAsTxt, false);
                            }
                            else
                            {
                                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                                arrSelListEntries = this.sqlAdmin1.getSelListEntrys(ref Parameters, "", qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplicationTmp, ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", -1, "", rGroup.ID);
                            }

                            object objColValueToTranlateoldValue = null;
                            System.Data.DataRow[] arrOrderCmb = (System.Data.DataRow[])dtToTranslate.Select("", col.ColumnName + " asc");
                            foreach (DataRow r in arrOrderCmb)
                            {


                                object objColValueToTranlate = (object)r[col.ColumnName];
                                if (objColValueToTranlateoldValue != null && objColValueToTranlate != objColValueToTranlateoldValue)
                                {
                                    if (objColValueToTranlate != System.DBNull.Value)
                                    {
                                        //    if (SQLValueListSelect.Trim() != "")
                                        //    {
                                        //        //foreach (DataRow rFound in dsFilledSqlSelList.Tables[0].Rows)
                                        //        //{
                                        //        //    object objKey = (object)rFound[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName];
                                        //        //    if (objKey.GetType().Equals(typeof(int)))
                                        //        //    {
                                        //        //        int IDOwnInt = System.Convert.ToInt32(objColValueToTranlate);
                                        //        //        if (objKey.Equals(System.Convert.ToInt32(IDOwnInt)))
                                        //        //        {
                                        //        //            r[colTxt.ColumnName] = rFound[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName];
                                        //        //        }
                                        //        //    }
                                        //        //    else if (objKey.GetType().Equals(typeof(System.Guid)))
                                        //        //    {
                                        //        //        System.Guid IDGuid = new System.Guid(objColValueToTranlate.ToString());
                                        //        //        if (objKey.Equals(IDGuid))
                                        //        //        {
                                        //        //            r[colTxt.ColumnName] = rFound[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName];
                                        //        //        }
                                        //        //    }
                                        //        //}
                                        //    }
                                        //    else
                                        //    {
                                        int countSelList = 0;
                                        bool bTranslationFound = false;
                                        do
                                        {
                                            qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntryFound = arrSelListEntries[countSelList];
                                            if (objColValueToTranlate.GetType().Equals(typeof(int)))
                                            {
                                                if (rSelListEntryFound.IDOwnInt.Equals(System.Convert.ToInt32(objColValueToTranlate)))
                                                {
                                                    string TranslationFound = qs2.core.language.sqlLanguage.getRes(rSelListEntryFound.IDRessource, true, true).Trim();
                                                    //string TranslationFound = "xy";
                                                    r[colTxt.ColumnName] = TranslationFound.Equals("") ? TranslationFound : rSelListEntryFound.IDRessource;
                                                    //ar.Add(  TranslationFound.Equals("") ? TranslationFound : rSelListEntryFound.IDRessource);
                                                    bTranslationFound = true;
                                                }
                                            }
                                            countSelList += 1;
                                        } while (!bTranslationFound && (countSelList < arrSelListEntries.Length - 1));
                                        iGesamt += 1;
                                        //}
                                    }
                                }
                                objColValueToTranlateoldValue = objColValueToTranlate;
                            }
                        }
                    }
                    else if (colIsCheckBox || colIsThreeStateCheckBox)
                    {
                        iCheckBox += 1;
                        // Console.Write("Number: " + iakt.ToString() + " Checkbox: " + col.ColumnName + " " + DateTime.Now.ToString() + " Gesamt: " + iGesamt.ToString() + "\r\n");

                        string colNameNew = qs2.core.generic.prefixColAutoTranslate + "" + col.ColumnName;
                        System.Data.DataColumn colTxt = dtToTranslate.Columns.Add(colNameNew, typeof(string));
                        dtToTranslate.Columns[colNameNew].SetOrdinal(dtToTranslate.Columns[col.ColumnName].Ordinal + 1);

                        if (grid != null)
                        {
                            grid.DisplayLayout.Bands[0].Columns[colTxt.ColumnName].Header.VisiblePosition = grid.DisplayLayout.Bands[0].Columns[col.ColumnName].Header.VisiblePosition;
                        }
                        this.lstUnvisibleCols.Add(col.ColumnName);

                        //foreach (DataRow r in dtToTranslate.Rows)
                        //{
                        //    r[colTxt.ColumnName] = "";
                        //    if (grid != null)
                        //    {
                        //        UltraGridRow gridRow = grid.Rows.GetRowWithListIndex(dtToTranslate.Rows.IndexOf(r));
                        //        if (gridRow == null)
                        //        {
                        //            throw new Exception("translateSelList: gridRow is null!");
                        //        }
                        //    }

                        //    string strColValueToTranlate = "";
                        //    object objColValueToTranlate = (object)r[col.ColumnName];
                        //    if (objColValueToTranlate != System.DBNull.Value)
                        //    {
                        //        if (objColValueToTranlate.GetType().Equals(typeof(int)))
                        //        {
                        //            int iObjColValueToTranlate = System.Convert.ToInt32(objColValueToTranlate);
                        //            if (iObjColValueToTranlate == 1)
                        //            {
                        //                string TranslationFound = qs2.core.language.sqlLanguage.getRes("Yes");
                        //                if (TranslationFound.Trim() == "")
                        //                {
                        //                    r[colTxt.ColumnName] = "Yes";
                        //                }
                        //                else
                        //                {
                        //                    r[colTxt.ColumnName] = TranslationFound;
                        //                }
                        //            }
                        //            else if (iObjColValueToTranlate == 0)
                        //            {
                        //                string TranslationFound = qs2.core.language.sqlLanguage.getRes("No");
                        //                if (TranslationFound.Trim() == "")
                        //                {
                        //                    r[colTxt.ColumnName] = "No";
                        //                }
                        //                else
                        //                {
                        //                    r[colTxt.ColumnName] = TranslationFound;
                        //                }
                        //            }
                        //            else if (iObjColValueToTranlate == -1)
                        //            {
                        //                string TranslationFound = qs2.core.language.sqlLanguage.getRes("No Selection");
                        //                if (TranslationFound.Trim() == "")
                        //                {
                        //                    r[colTxt.ColumnName] = "No Selection";
                        //                }
                        //                else
                        //                {
                        //                    r[colTxt.ColumnName] = TranslationFound;
                        //                }
                        //            }
                        //        }
                        //        else if (objColValueToTranlate.GetType().Equals(typeof(bool)))
                        //        {
                        //            bool bObjColValueToTranlate = System.Convert.ToBoolean(objColValueToTranlate);
                        //            if (bObjColValueToTranlate)
                        //            {
                        //                string TranslationFound = qs2.core.language.sqlLanguage.getRes("Yes");
                        //                if (TranslationFound.Trim() == "")
                        //                {
                        //                    r[colTxt.ColumnName] = "Yes";
                        //                }
                        //                else
                        //                {
                        //                    r[colTxt.ColumnName] = TranslationFound;
                        //                }
                        //            }
                        //            else
                        //            {
                        //                string TranslationFound = qs2.core.language.sqlLanguage.getRes("No");
                        //                if (TranslationFound.Trim() == "")
                        //                {
                        //                    r[colTxt.ColumnName] = "No";
                        //                }
                        //                else
                        //                {
                        //                    r[colTxt.ColumnName] = TranslationFound;
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        iNone += 1;
                        // Console.Write("Number: " + iakt.ToString() + " None: " + col.ColumnName + " " + DateTime.Now.ToString() + " Gesamt: " + iGesamt.ToString() + "\r\n");
                    }
                }

                foreach (string columnName in this.lstUnvisibleCols)
                {
                    if (grid != null)
                    {
                        grid.DisplayLayout.Bands[0].Columns[columnName].Hidden = true;
                    }
                }








                ////Zweidimensionales Array (mit doppelter Anzahl Spalten für Übersetzungen)
                //Object[,] myObjArray = new object[dtToTranslate.Rows.Count, dtToTranslate.Columns.Count * 2];

                //int rowCount = 0;
                //int colCount = 0;

                ////DataTable in zweidimensionales Array schreiben
                //foreach (DataRow row in dtToTranslate.Rows)
                //{
                //    object[] itemArray = row.ItemArray;

                //    colCount = 0;
                //    foreach (object o in itemArray)
                //    {
                //        myObjArray[rowCount, colCount] = o;
                //        colCount += 1;
                //    }

                //    rowCount += 1;
                //}

                //// Alle neuen Zellen mit Text auffüllen (
                //for (int i = 0; i < dtToTranslate.Rows.Count; i++)
                //{
                //    for (int j = dtToTranslate.Columns.Count + 1; j < dtToTranslate.Columns.Count * 2; j++)
                //    {
                //        myObjArray[i, j] = "---------------TEST-------------------";    // Hier die Übersetzung rein
                //    }
                //}

                ////Neu Spalte einfügen (Verschieben aller Spalten nach rechts, äußerste fällt raus)
                //for (int i = 0; i < dtToTranslate.Rows.Count; i++)
                //{
                //    for (int j = dtToTranslate.Columns.Count * 2; j < dtToTranslate.Columns.Count + 1; j--)
                //    {
                //        myObjArray[i, j] = myObjArray[i, j - 1];    // Hier die Übersetzung rein
                //    }
                //}

                ////Array in dataTable 
                //DataTable dtTranslated = new DataTable();
                //dtTranslated = dtToTranslate.Clone();

                //int AnzahlSpaltenInklUeberstzung = dtToTranslate.Columns.Count * 2;        //Hier muss die Anzahl der ursprünglichen Spalten + Anzahl der übersetzten Spalten rein

                //for (int i = 0; i < dtToTranslate.Rows.Count; i++)
                //{

                //    Object[] oRow = new object[300];    //AnzahlSpaltenInklUeberstzung
                //    for (int j = 0; j < 300; j++)
                //    {
                //        oRow[j] = myObjArray[i, j];
                //    }
                //    dtTranslated.LoadDataRow(oRow, true);
                //}
















            }
            catch (Exception ex)
            {
                throw new Exception("translateQuery.translateSelList: " + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

    }
}
