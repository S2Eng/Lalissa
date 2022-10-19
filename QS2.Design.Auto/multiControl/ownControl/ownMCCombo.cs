using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using qs2.core.vb;
using qs2.core.license;

namespace qs2.design.auto.multiControl
{



    public class ownMCCombo
    {

        public qs2.core.Enums.cVariablesValues TypeComboBox;
        public int minWithDropDown = 300;

        public bool right_QueryReportOthers = false;
        public bool right_QueryReportOwn = false;

        public bool _ComboBoxCheckThreeStateBoxAsDropDown = false;
        public qs2.core.Enums.eControlType PrevControlType;

        public bool SelectionComboBoxCanNotCleared = false;

        public bool ComboBoxIsInitialized = false;
        public bool ComboBoxIsObjectComboBoxForUserAdministration = false;
        
        public bool IsVariableSelListFromRelationForCombObox = false;
        public string IDGroupStrForComboBox = "";

        public System.Collections.Generic.List<eComboBoxObject> lstCombBoxObjectsAdded = new List<eComboBoxObject>();
        public class eComboBoxObject
        {
            public int IDObject = -1;
        }

        







        public void initCombo(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                this.TypeComboBox = qs2.core.Enums.cVariablesValues.none;

                if (ownControl1._controlType == core.Enums.eControlType.ComboBox ||
                    ownControl1._controlType == core.Enums.eControlType.ComboBoxNoDb ||
                    ownControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox ||
                    ownControl1._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    if (ownControl1.IsEvaluation)
                    {
                        this.right_QueryReportOthers = true;
                        this.right_QueryReportOwn = true;
                    }

                    if (ownControl1.ownMCCriteria1.rCriteria != null)
                    {
                        if (ownControl1.ownMCCriteria1.rCriteria.SQLValueListSelect.Trim() == "")
                        {
                            qs2.core.vb.businessFramework b = new core.vb.businessFramework();
                            System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarOwnComboType = new List<qs2.core.Enums.cVariables>();
                            lstClassificationsVarOwnComboType = b.getValueVariableClassification(qs2.core.Enums.cVariablesDefinition.ComboType, ref ownControl1.ownMCCriteria1.lstVariablesClassification);
                            if (lstClassificationsVarOwnComboType.Count > 0)
                            {
                                if (lstClassificationsVarOwnComboType[0].definition.Trim() != "" &&
                                        lstClassificationsVarOwnComboType[0].value.Trim().ToLower() == qs2.core.Enums.cVariablesValues.Roles.ToString().Trim().ToLower())
                                {
                                    this.TypeComboBox = qs2.core.Enums.cVariablesValues.Roles;
                                }
                                else
                                {
                                    this.TypeComboBox = qs2.core.Enums.cVariablesValues.SelList;  
                                }
                            }
                            else
                            {
                                this.TypeComboBox = qs2.core.Enums.cVariablesValues.SelList;
                            }
                        }
                        else
                        {
                            this.TypeComboBox =  qs2.core.Enums.cVariablesValues.Sql;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.initCombo", ownControl1._FldShort, false, true,
                                                        ownControl1.ownMCCriteria1.Application,
                                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool loadCombo(qs2.design.auto.multiControl.ownMultiControl ownControl1, string IDGroupStrOther, string Combination, bool ComboBoxCheckThreeStateBoxAsDropDown)
        {
            try
            {
                string IDGroupStr = "";
                if (IDGroupStrOther.Trim() != "")
                {
                    IDGroupStr = IDGroupStrOther;
                }
                else
                {
                    IDGroupStr = (ownControl1.ownMCCriteria1.rCriteria.AliasFldShort.Trim() == "" ? ownControl1.ownMCCriteria1.rCriteria.FldShort.Trim() : ownControl1.ownMCCriteria1.rCriteria.AliasFldShort.Trim());
                }

                if (ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox == qs2.core.Enums.cVariablesValues.SelList)
                {
                    ownControl1.ownMCCriteria1.ownMCCombo1.loadComboSelList(ownControl1, IDGroupStr, Combination, ComboBoxCheckThreeStateBoxAsDropDown);
                    this.ComboBoxIsInitialized = true;
                    return true;
                }
                else if (ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox == qs2.core.Enums.cVariablesValues.Sql)
                {
                    ownControl1.ownMCCriteria1.ownMCCombo1.loadComboSelListOwnSql(ownControl1, ownControl1.ownMCCriteria1.rCriteria.SQLValueListSelect.Trim());
                    this.ComboBoxIsInitialized = true;
                    return true;
                }
                else if (ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox == qs2.core.Enums.cVariablesValues.Roles)
                {
                    qs2.core.vb.businessFramework b = new core.vb.businessFramework();
                    System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarIDOwnIntAll = new List<qs2.core.Enums.cVariables>();

                    System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarIDOwnIntNoApp = new List<qs2.core.Enums.cVariables>();
                    lstClassificationsVarIDOwnIntNoApp = b.getValueVariableClassification(qs2.core.Enums.cVariablesDefinition.IDOwnInt, ref ownControl1.ownMCCriteria1.lstVariablesClassification);
                    qs2.core.generic.getListVarIDOwnInt(ref lstClassificationsVarIDOwnIntNoApp, ref lstClassificationsVarIDOwnIntAll, false);

                    System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarIDOwnIntApp = new List<qs2.core.Enums.cVariables>();
                    lstClassificationsVarIDOwnIntApp = b.getValueVariableClassificationStr(qs2.core.Enums.cVariablesDefinition.IDOwnInt.ToString() + ownControl1.ownMCCriteria1.Application.Trim(), ref ownControl1.ownMCCriteria1.lstVariablesClassification);
                    qs2.core.generic.getListVarIDOwnInt(ref lstClassificationsVarIDOwnIntApp, ref lstClassificationsVarIDOwnIntAll, true);

                    ownControl1.ownMCCriteria1.ownMCCombo1.loadComboObjects(ownControl1, lstClassificationsVarIDOwnIntAll, Combination);
                    ownControl1.setControlTextBoxForCombo();
                    this.ComboBoxIsInitialized = true;
                    return true;
                }
                else
                {
                    throw new Exception("ownMCCombo.loadCombo: TypeComboBox '" + ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox.ToString() + "' is wrong!");
                    //return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("loadCombo: " + ex.ToString());
            }
        }

 

        public void clearCombo(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "Surgeon", false))
                //{
                //    //string xy = "";
                //}

                if (this.TypeComboBox == qs2.core.Enums.cVariablesValues.SelList || this.TypeComboBox == qs2.core.Enums.cVariablesValues.Sql)
                {
                    this.clearCombo2xy(ownControl1);
                }
                else if (this.TypeComboBox == qs2.core.Enums.cVariablesValues.Roles)
                {
                    this.clearComboForObjects(ownControl1);
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.clearCombo", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        private void loadComboSelList(qs2.design.auto.multiControl.ownMultiControl ownControl1, string IDGruppeToSearch, string Combination, bool ComboBoxCheckThreeStateBoxAsDropDown)
        {
            try
            {
                this.clearCombo2xy(ownControl1);
                qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                // OMC.IDApplication.Check
                qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrp = null;
                if (ownControl1.OwnFieldForALLProducts)
                {
                    arrGrp = ownMCCriteria.sqlAdminWork.getSelListGroup(ref qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGruppeToSearch, ownControl1.ownMCCriteria1.IDParticipant,
                                                               qs2.core.license.doLicense.eApp.ALL.ToString());
                }
                else
                {
                    arrGrp = ownMCCriteria.sqlAdminWork.getSelListGroup(ref qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGruppeToSearch, ownControl1.ownMCCriteria1.IDParticipant,
                                                                                 ownControl1.ownMCCriteria1.Application);
                }

                if (arrGrp.Length == 1)
                {
                    this.loadComboSelList(ownControl1, IDGruppeToSearch, arrGrp[0], false, Combination, ComboBoxCheckThreeStateBoxAsDropDown);
                }
                else
                {
                    arrGrp = ownMCCriteria.sqlAdminWork.getSelListGroup(ref qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGruppeToSearch, ownControl1.ownMCCriteria1.IDParticipant, qs2.core.license.doLicense.eApp.ALL.ToString());
                    if (arrGrp.Length == 1)
                    {
                        this.loadComboSelList(ownControl1, IDGruppeToSearch, arrGrp[0], false, Combination, ComboBoxCheckThreeStateBoxAsDropDown);
                    }
                    else
                    {
                        //this.clearComboSelList(ownControl1);
                    }
                }
            }
            catch (Exception ex)
            { 
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.loadComboSelList", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void loadComboThreeStateCheckBox(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool ControlWasCheckBox, bool ComboBoxCheckThreeStateBoxAsDropDown)
        {
            try
            {
                this.clearCombo2xy(ownControl1);
                string IDGruppeToSearch = "ComboBoxCheckThreeStateBox";
                qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrp = ownMCCriteria.sqlAdminWork.getSelListGroup(ref qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGruppeToSearch, ownControl1.ownMCCriteria1.IDParticipant,
                                                               qs2.core.license.doLicense.eApp.ALL.ToString());
                this.loadComboSelList(ownControl1, IDGruppeToSearch, arrGrp[0], ControlWasCheckBox, "", false);
                if (ControlWasCheckBox)
                {
                    Infragistics.Win.ValueListItem itmCboUndefined = null;
                    foreach (Infragistics.Win.ValueListItem itmCbo in ownControl1.ComboBox.Items)
                    {
                        if ((System.Convert.ToInt32(itmCbo.DataValue, System.Globalization.CultureInfo.InvariantCulture) == -1))
                        {
                            itmCboUndefined = itmCbo;
                        }
                    }
                    if (itmCboUndefined != null)
                    {
                        ownControl1.ComboBox.Items.Remove(itmCboUndefined);
                        //rSelListUndefined.Delete();
                        //ownControl1.ownMCCriteria1.dsAdmin1.tblSelListEntries.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.loadComboSelList", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void loadComboSelListOwnSql(qs2.design.auto.multiControl.ownMultiControl ownControl1, string sqlCommand)
        {
            try
            {
                this.clearCombo2xy(ownControl1);

                core.vb.sqlAdmin sqlAdminFill = new core.vb.sqlAdmin();
                System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
                DataSet dsFilled = new DataSet();
                string ParametersAsTxt = "";
                qs2.core.dbBase.fillDataSet(sqlCommand, parameters, ref dsFilled, "tblCombo", "ds1", ref ParametersAsTxt, false);
                foreach (DataRow rFound in dsFilled.Tables[0].Rows)
                {
                    qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                    core.vb.dsAdmin.tblSelListEntriesRow rNewSelList = sqlAdminFill.getNewRowSelList(qs2.design.auto.ownMCCriteria.dsAdminWork, true);

                    object objKey = (object)rFound[qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.IDOwnIntColumn.ColumnName];
                    if (objKey.GetType().Equals(typeof(int)))
                    {
                        rNewSelList.IDOwnInt = (int)rFound[qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.IDOwnIntColumn.ColumnName];
                        ownControl1.ComboBox.ValueMember = qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.IDOwnIntColumn.ColumnName;
                    }
                    else if (objKey.GetType().Equals(typeof(System.Guid)))
                    {
                        rNewSelList.IDOwnStr = rFound[qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.IDOwnIntColumn.ColumnName].ToString();
                        ownControl1.ComboBox.ValueMember = qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.IDOwnStrColumn.ColumnName;
                    }
                    rNewSelList.IDRessource = (string)rFound[qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.IDRessourceColumn.ColumnName];
                    rNewSelList.Description = rNewSelList.IDRessource;
                    if (rFound[qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.sortColumn.ColumnName] == null)
                        rNewSelList.sort = (int)rFound[qs2.design.auto.ownMCCriteria.dsAdminWork.tblSelListEntries.sortColumn.ColumnName];
                }
                ownControl1.ComboBox.Refresh();
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.loadComboSelListOwnSql", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void loadComboSelList(qs2.design.auto.multiControl.ownMultiControl ownControl1, string IDGruppeToSearch,
                                        qs2.core.vb.dsAdmin.tblSelListGroupRow rGrp, bool ControlWasCheckBox, string Combination, bool ComboBoxCheckThreeStateBoxAsDropDown)
        {
            try
            {
                this.clearCombo2xy(ownControl1);

                qs2.core.vb.dsAdmin dsAdminDropDown = null;
                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    dsAdminDropDown = new core.vb.dsAdmin();
                }

                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();

                // OMC.IDApplication.Check
                qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntries = null;
                if (ownControl1.OwnFieldForALLProducts)
                {
                    arrSelListEntries = ownMCCriteria.sqlAdminWork.getSelListEntrys(ref Parameters, IDGruppeToSearch, ownControl1.ownMCCriteria1.IDParticipant,
                                                                                                                qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                                                                                ref ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", 0, "", rGrp.ID);

                }
                else
                {
                    arrSelListEntries = ownMCCriteria.sqlAdminWork.getSelListEntrys(ref Parameters, IDGruppeToSearch, ownControl1.ownMCCriteria1.IDParticipant,
                                                                                                                    ownControl1.ownMCCriteria1.Application,
                                                                                                                    ref ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", 0, "", rGrp.ID);

                }

                bool KeyIsIDOwnStr = false;
                if (rGrp.Classification.Trim().ToLower().Equals(("Key=IDOwnStr").Trim().ToLower()))
                {
                    KeyIsIDOwnStr = true;
                }

                int iSortNew = 3000;
                string sWhereIDSelList = "";
                System.Collections.Generic.SortedDictionary<int, qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstSelListOrderByParticipant = new SortedDictionary<int, core.vb.dsAdmin.tblSelListEntriesRow>();
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry in arrSelListEntries)
                {
                    if (!rSelListEntry.IDParticipant.Trim().ToLower().Equals(("")) && !rSelListEntry.IDParticipant.Trim().ToLower().Equals(("all")))
                    {
                        lstSelListOrderByParticipant.Add(iSortNew, rSelListEntry);
                        sWhereIDSelList += (sWhereIDSelList.Trim() ==  "" ?  "" : " or ") + "IDSelListEntry='" + rSelListEntry.ID.ToString () + "'";
                        iSortNew += 1;
                    }
                }
                iSortNew = 5000;
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry in arrSelListEntries)
                {
                    if (rSelListEntry.IDParticipant.Trim().ToLower().Equals(("")) || rSelListEntry.IDParticipant.Trim().ToLower().Equals(("all")))
                    {
                        lstSelListOrderByParticipant.Add(iSortNew, rSelListEntry);
                        sWhereIDSelList += (sWhereIDSelList.Trim() == "" ? "" : " or ") + "IDSelListEntry='" + rSelListEntry.ID.ToString() + "'";
                        iSortNew += 1;
                    }
                }
                int iSortCustomer = 0;
                if (sWhereIDSelList.Trim() != "")
                {
                    sWhereIDSelList = " (" + sWhereIDSelList + ") ";
                    qs2.core.vb.dsAdmin.tblSelListEntriesSortRow[] arrSelListEntriesSort = ownMCCriteria.sqlAdminWork.getSelListEntrysSort(-999, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), 
                                                                                                null, sqlAdmin.eTypSelListSort.IDSelListIDParticipantIDRam, sWhereIDSelList);

                    if (arrSelListEntriesSort.Length > 0)
                    {
                        try
                        {
                            //foreach (KeyValuePair<int, qs2.core.vb.dsAdmin.tblSelListEntriesRow> keyPairSelList in lstSelListOrderByParticipant)
                            //{
                            //    keyPairSelList.Value.sort = (keyPairSelList.Value.sort + 10000);
                            //}
                            //dsAdmin.tblSelListEntriesDataTable dtCopySelList = (dsAdmin.tblSelListEntriesDataTable)lstSelListOrderByParticipant.CopyToDataTable();
                            //lstSelListOrderByParticipant.Clear();
                            foreach (dsAdmin.tblSelListEntriesSortRow rSelListEntriesSort in arrSelListEntriesSort)
                            {
                                var keyPairSelLists = lstSelListOrderByParticipant.Where(o => (o.Value.ID == rSelListEntriesSort.IDSelListEntry));
                                if (keyPairSelLists.Count() != 1)
                                {
                                    throw new Exception("loadComboSelList: tSelLists.Count() != 1 for FldShort '" + ownControl1.OwnFldShort.Trim() + "' and IDSelList '" + rSelListEntriesSort.IDSelListEntry.ToString() + "' not allowed!");
                                }
                                KeyValuePair<int, qs2.core.vb.dsAdmin.tblSelListEntriesRow> rKeyPairSelList = keyPairSelLists.First();
                                lstSelListOrderByParticipant.Add(iSortCustomer, rKeyPairSelList.Value);
                                lstSelListOrderByParticipant.Remove(rKeyPairSelList.Key);
                                iSortCustomer += 1;
                                //lstSelListOrderByParticipant = lstSelListOrderByParticipant.Values.OrderBy(o => o.sort);
                            }
                            rGrp.SortColumn = ownMCCriteria.dsAdminWork.tblSelListEntries.sortColumn.ColumnName;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("loadComboSelList: arrSelListEntriesSort.Length>0 for FldShort '" + ownControl1.OwnFldShort.Trim() + "':" + "\r\n" + ex.ToString());
                        }
                    }
                }
                
                //qs2.core.vb.dsAdmin dsAdminTmp = new core.vb.dsAdmin();
                System.Collections.Generic.List<int> lstIDOwnIntExistsInCombo = new List<int>();
                System.Collections.Generic.List<string> lstIDOwnStrExistsInCombo = new List<string>();
                System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstEntriesAdded_ParticipantUserxy = new List<core.vb.dsAdmin.tblSelListEntriesRow>();
                System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstEntriesAdded_ParticipantALLxy = new List<core.vb.dsAdmin.tblSelListEntriesRow>();
                if (arrSelListEntries.Length > 0)
                {
                    System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstToDeleteSelLists = new List<core.vb.dsAdmin.tblSelListEntriesRow>();
                    System.Collections.Generic.List<Infragistics.Win.ValueListItem> lstToDeleteItems = new List<Infragistics.Win.ValueListItem>();
                    foreach (KeyValuePair<int, qs2.core.vb.dsAdmin.tblSelListEntriesRow> keyPairSelList in lstSelListOrderByParticipant)
                    {
                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        string IDRessourceFound = qs2.core.language.sqlLanguage.getRes(keyPairSelList.Value.IDRessource, core.Enums.eResourceType.Label, ownControl1.ownMCCriteria1.IDParticipant,
                                                                                            ownControl1.ownMCCriteria1.Application, ref rLangFoundReturn).Trim() + " ";
                        if (IDRessourceFound.Trim() == "")
                        {
                            keyPairSelList.Value.Description = keyPairSelList.Value.IDRessource;
                        }
                        else
                        {
                            keyPairSelList.Value.Description = IDRessourceFound;
                        }
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow rNew = null;
                        Infragistics.Win.ValueListItem ItemAdded = null;

                        bool bIDOwnIntExists = false;
                        if (KeyIsIDOwnStr)
                        {
                            foreach (string IDOwnStrExists in lstIDOwnStrExistsInCombo)
                            {
                                if (IDOwnStrExists.Equals(keyPairSelList.Value.IDOwnStr))
                                {
                                    bIDOwnIntExists = true;
                                }
                            }
                        }
                        else
                        {
                            foreach (int IDOwnIntExists in lstIDOwnIntExistsInCombo)
                            {
                                if (IDOwnIntExists.Equals(keyPairSelList.Value.IDOwnInt))
                                {
                                    bIDOwnIntExists = true;
                                }
                            }
                        }

                        if (!bIDOwnIntExists)
                        {
                            bool bItemAdded = false;
                            if (keyPairSelList.Value.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower()))
                            {
                                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                                {
                                    qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                                    rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)ownMCCriteria.sqlAdminWork.getNewRowSelList(dsAdminDropDown, true);
                                    rNew.ItemArray = keyPairSelList.Value.ItemArray;
                                    //lstEntriesAdded_ParticipantUser.Add(rNew);
                                }
                                else
                                {
                                    if (KeyIsIDOwnStr)
                                    {
                                        ItemAdded = ownControl1.ComboBox.Items.Add(keyPairSelList.Value.IDOwnStr.Trim(), keyPairSelList.Value.Description.Trim());
                                        bItemAdded = true;
                                    }
                                    else
                                    {
                                        ItemAdded = ownControl1.ComboBox.Items.Add(keyPairSelList.Value.IDOwnInt, keyPairSelList.Value.Description.Trim());
                                        bItemAdded = true;
                                    }
                                }

                            }
                            else if (keyPairSelList.Value.IDParticipant.Trim() == "" || keyPairSelList.Value.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower()))
                            {
                                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                                {
                                    qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                                    rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)ownMCCriteria.sqlAdminWork.getNewRowSelList(dsAdminDropDown, true);
                                    rNew.ItemArray = keyPairSelList.Value.ItemArray;
                                    //lstEntriesAdded_ParticipantALL.Add(rNew);
                                }
                                else
                                {
                                    if (KeyIsIDOwnStr)
                                    {
                                        ItemAdded = ownControl1.ComboBox.Items.Add(keyPairSelList.Value.IDOwnStr.Trim(), keyPairSelList.Value.Description.Trim());
                                        bItemAdded = true;
                                    }
                                    else
                                    {
                                        ItemAdded = ownControl1.ComboBox.Items.Add(keyPairSelList.Value.IDOwnInt, keyPairSelList.Value.Description.Trim());
                                        bItemAdded = true;
                                    }
                                }
                            }

                            if (bItemAdded)
                            {
                                if (KeyIsIDOwnStr)
                                {
                                    lstIDOwnStrExistsInCombo.Add(keyPairSelList.Value.IDOwnStr.Trim());
                                }
                                else
                                {
                                    lstIDOwnIntExistsInCombo.Add(keyPairSelList.Value.IDOwnInt);
                                }
                            }
                            //if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                            //{
                            //    //rNew2 = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)ownMCCriteria.sqlAdminWork.getNewRowSelList(dsAdminDropDown, true);
                            //    //rNew2.ItemArray = rSelListEntry.ItemArray;
                            //}

                            if (ComboBoxCheckThreeStateBoxAsDropDown)
                            {
                                if (keyPairSelList.Value.IDOwnInt == 2)
                                {
                                    lstToDeleteSelLists.Add(rNew);
                                    //ownControl1.ComboBox.Items.Remove(ItemAdded);
                                }
                                if (this.PrevControlType == core.Enums.eControlType.CheckBox || this.PrevControlType == core.Enums.eControlType.CheckBoxNoDb)
                                {
                                    if (keyPairSelList.Value.IDOwnInt == -1)
                                    {
                                        lstToDeleteSelLists.Add(rNew);
                                        //ownControl1.ComboBox.Items.Remove(ItemAdded);
                                    }
                                }
                            }
                        }
                    }

                    if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                    {
                        foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry in lstToDeleteSelLists)
                        {
                            rSelListEntry.Delete();
                        }
                        dsAdminDropDown.AcceptChanges();
                    }
                }
                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    qs2.core.vb.dsObjects dsObjectsTmp = new core.vb.dsObjects();
                    ownControl1.ControlForDropDown.loadData(ref dsAdminDropDown, ref dsObjectsTmp, contOnwMultiControlGrid.eTypeUI.SelList, Combination, KeyIsIDOwnStr);
                }
                else
                {
                    if (rGrp.SortColumn.Trim() == "")
                    {
                        ownControl1.ComboBox.ValueList.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
                    }
                    else
                    {
                        if (rGrp.SortColumn.Trim().ToLower() == (ownMCCriteria .dsAdminWork.tblSelListEntries.IDOwnIntColumn.ColumnName).Trim().ToLower())
                        {
                            ownControl1.ComboBox.ValueList.SortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue;
                        }
                        else if (rGrp.SortColumn.Trim().ToLower() == (ownMCCriteria.dsAdminWork.tblSelListEntries.sortColumn.ColumnName).Trim().ToLower())
                        {
                            ownControl1.ComboBox.ValueList.SortStyle = Infragistics.Win.ValueListSortStyle.None;
                        }
                        else
                        {
                            ownControl1.ComboBox.ValueList.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
                        }
                    }
                    
                    //ownControl1.ComboBox.Refresh();
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.loadComboSelList", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        private void clearCombo2xy(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "Surgeon", false))
                //{
                //    string xy = "";
                //}

                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    ownControl1.ControlForDropDown.clearData();
                }
                else
                {
                    if (!this.SelectionComboBoxCanNotCleared)
                    {
                        ownControl1.ComboBox.Items.Clear();
                    }
                    //ownControl1.ownMCCriteria1.initControl();
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.clearCombo2", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public Infragistics.Win.ValueListItem getSelectedItemCboxy(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                if (ownControl1.ComboBox.SelectedItem != null)
                {
                    return ownControl1.ComboBox.SelectedItem;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.getSelectedItemCbo", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }






        public void loadComboObjects(qs2.design.auto.multiControl.ownMultiControl ownControl1,
                                        System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarIDOwnInt, string Combination)
        {
            try
            {
                if (lstClassificationsVarIDOwnInt.Count == 0)
                {
                    throw new Exception("getObjectsForCombo: No cVariablesIDOwnInt.value defined in rCriteria for Field!");
                }
            
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "surgeon", false))
                //{
                //    string xy = "";
                //}

                //this.right_QueryReportAll = false;
                //this.right_QueryReportOthers = false;
                //this.right_QueryReportOwn = false;

                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                qs2.core.vb.dsAdmin.tblSelListGroupRow rGroupRoles = ownMCCriteria.sqlAdminWork.getSelListGroupRow("Roles", qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.eApp.ALL.ToString());
                qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrRoles = ownMCCriteria.sqlAdminWork.getSelListEntrys(ref Parameters, "", qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                ref ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", -999, "", rGroupRoles.ID);

                this.clearComboForObjects(ownControl1);

                bool bSelectAllNoEditInDropDown = false;
                qs2.core.vb.dsObjects dsObjectsDropDown = new core.vb.dsObjects();
                bool bListAllUsers = false;
                if (ownControl1.IsEvaluation)
                {
                    if (this.right_QueryReportOwn && !this.right_QueryReportOthers)
                    {
                        bListAllUsers = false;
                        this.loadComboObjectsOnlyForUsr(ownControl1, false, ref dsObjectsDropDown);
                        bSelectAllNoEditInDropDown = true;
                    }
                    //else if (this.right_QueryReportAll && !this.right_QueryReportOthers)
                    //{
                    //    bListAllUsers = true;
                    //    //this.loadComboObjectsOnlyForUsr(ownControl1, true, ref dsObjectsDropDown);
                    //    bSelectAllNoEditInDropDown = true;
                    //}
                    else if (this.right_QueryReportOthers)
                    {
                        bListAllUsers = true;
                        bSelectAllNoEditInDropDown = false;
                    }
                    else
                    {
                        bListAllUsers = false;
                        this.loadComboObjectsOnlyForUsr(ownControl1, false, ref dsObjectsDropDown);
                        bSelectAllNoEditInDropDown = true;
                    }
                }
                else
                {
                    bListAllUsers = true;
                }

                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {

                }
                else
                {
                    ownControl1.ComboBox.Items.Add(-1, " ");
                }

                if (bListAllUsers)
                {
                    System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstRoleToLoad = new List<core.vb.dsAdmin.tblSelListEntriesRow>();
                    foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rRole in arrRoles)
                    {
                        foreach (qs2.core.Enums.cVariables cVariablesIDOwnInt in lstClassificationsVarIDOwnInt)
                        {
                            if (rRole.IDOwnInt.Equals(System.Convert.ToInt32(cVariablesIDOwnInt.value.Trim(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)))
                            {
                                lstRoleToLoad.Add(rRole);
                            }
                        }
                    }
                    if (lstRoleToLoad.Count > 0)
                    {
                        foreach (qs2.core.vb.dsObjects.tblObjectRow rUsrFound in qs2.core.vb.sqlObjects.dsAllUsers.tblObject)
                        {
                            bool bAppOK = false;
                            dsObjects.tblObjectApplicationsRow[] arrObjectApplicationsAllApps = (dsObjects.tblObjectApplicationsRow[])qs2.core.vb.sqlObjects.dsAllUsers.tblObjectApplications.Select("IDObjectGuid='" + rUsrFound.IDGuid.ToString() + "'", "");
                            if (arrObjectApplicationsAllApps.Length == 0)
                            {
                                if (ownMCCriteria.dsLicense1.Applications.Rows.Count == 1)
                                {
                                    bAppOK = true;
                                }
                                else if (ownMCCriteria.dsLicense1.Applications.Rows.Count > 1)
                                {
                                    bAppOK = false;
                                }
                                else
                                {
                                    throw new Exception("loadComboObjects: ownMCCriteria.dsLicense1.Applications.Rows.Count=0 not allowed!");
                                }
                            }
                            else
                            {
                                dsObjects.tblObjectApplicationsRow[] arrObjectApplications = (dsObjects.tblObjectApplicationsRow[])qs2.core.vb.sqlObjects.dsAllUsers.tblObjectApplications.Select("IDObjectGuid='" + rUsrFound.IDGuid.ToString() + "' and IDApplication='" + qs2.core.license.doLicense.rApplication.IDApplication.Trim() + "'", "");
                                if (arrObjectApplications.Length > 0)
                                {
                                    bAppOK = true;
                                }
                            }
                            if (bAppOK)
                            {
                                //get Role from User
                                ownMCCriteria.dsAdminWork.tblSelListEntriesObj.Clear();
                                qs2.core.vb.dsAdmin.tblSelListEntriesObjRow[] arrSelListObjs = ownMCCriteria.sqlAdminWork.getSelListEntrysObj(rUsrFound.ID, core.vb.sqlAdmin.eDbTypAuswObj.Roles, "Roles", ownMCCriteria.dsAdminWork, core.vb.sqlAdmin.eTypAuswahlObj.objRAM, qs2.core.license.doLicense.eApp.ALL.ToString());

                                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rObjActUsr in arrSelListObjs)
                                {
                                    foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rRoleToLoad in lstRoleToLoad)
                                    {
                                        if (rObjActUsr.IDSelListEntry.Equals(rRoleToLoad.ID))
                                        {
                                            bool RoleFromUserIsOK = false;
                                            if (ownControl1.IsEvaluation)
                                            {
                                            }
                                            else
                                            {
                                                if (!qs2.core.vb.actUsr.UserHasRoleAdministrator)
                                                {
                                                    if (rObjActUsr.Active)
                                                    {
                                                        RoleFromUserIsOK = true;
                                                    }
                                                }
                                                else
                                                {
                                                    RoleFromUserIsOK = true;
                                                }
                                            }

                                            if (RoleFromUserIsOK)
                                            {
                                                qs2.core.vb.dsObjects.tblObjectRow[] arrObjFound = (qs2.core.vb.dsObjects.tblObjectRow[])dsObjectsDropDown.tblObject.Select("ID=" + rUsrFound.ID.ToString() + "", "");
                                                if (arrObjFound.Length == 0)
                                                {
                                                    if (rUsrFound.IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower()))
                                                    {
                                                        if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                                                        {
                                                            qs2.core.vb.dsObjects.tblObjectRow rNewObj = (qs2.core.vb.dsObjects.tblObjectRow)ownMCCriteria.sqlObjectsWork.getNewRowObject(dsObjectsDropDown);
                                                            rNewObj.ItemArray = rUsrFound.ItemArray;
                                                            rNewObj.Active = rObjActUsr.Active;
                                                        }
                                                        else
                                                        {
                                                            bool bObjExistsInComboBox = false;
                                                            foreach (Infragistics.Win.ValueListItem itmObjExists in ownControl1.ComboBox.Items)
                                                            {
                                                                if (itmObjExists.DataValue.Equals(rUsrFound.ID))
                                                                {
                                                                    bObjExistsInComboBox = true;
                                                                }
                                                            }

                                                            if (!bObjExistsInComboBox)
                                                            {
                                                                if (rUsrFound.NameCombination.Trim() != "")
                                                                {
                                                                    ownControl1.ComboBox.Items.Add(rUsrFound.ID, rUsrFound.NameCombination.Trim());
                                                                }
                                                                else
                                                                {
                                                                    ownControl1.ComboBox.Items.Add(rUsrFound.ID, rUsrFound.LastName.Trim() + " " + rUsrFound.FirstName.Trim());
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //bool bnoApp = true;
                            }
                        }
                    }

                    if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                    {

                    }
                    else
                    {
                        ownControl1.ComboBox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
                        //ownControl1.panelButtons.Controls.Clear();
                        //System.Windows.Forms.Control contMC = ownControl1.ownMCUI1.doButtonControls(design.auto.multiControl.ownMCEvents.eTypButtonControl.Clear, null, "",
                        //                                        qs2.core.language.sqlLanguage.getRes("DeleteSelection"), ownControl1);
                    }
                }

                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    ownMCCriteria.dsObjectsWork.Clear();
                    ownMCCriteria.dsAdminWork.Clear();
                    ownControl1.ControlForDropDown.loadData(ref ownMCCriteria.dsAdminWork, ref dsObjectsDropDown, contOnwMultiControlGrid.eTypeUI.Objects, Combination.Trim(), false);
                    if (bSelectAllNoEditInDropDown && !this.ComboBoxIsObjectComboBoxForUserAdministration)
                    {
                        ownControl1.ControlForDropDown.bLockUserInput = true;
                        ownControl1.ControlForDropDown.AlwaysAllSelected = true;
                        ownControl1.ControlForDropDown.selectAllNone(true, contOnwMultiControlGrid.eTypeUI.Objects);
                    }
                    else
                    {
                        ownControl1.ControlForDropDown.bLockUserInput = false;
                        ownControl1.ControlForDropDown.AlwaysAllSelected = false;
                    }
                }
                else
                {
                    //ownControl1.ComboBox.DisplayLayout.Bands[0].SortedColumns.Clear();
                    //ownControl1.ComboBox.DisplayLayout.Bands[0].SortedColumns.Add(ownMCCriteria.dsObjectsWork.tblObject.ActiveColumn.ColumnName, true);
                    //ownControl1.ComboBox.DisplayLayout.Bands[0].SortedColumns.Add(ownMCCriteria.dsObjectsWork.tblObject.NameCombinationColumn.ColumnName, false);
                    if (ownControl1.ComboBox.Items.Count > 0)
                    {
                        ownControl1.ComboBox.SelectedItem = ownControl1.ComboBox.Items[0];
                    }
                   
                    if (bSelectAllNoEditInDropDown)
                    {
                        ownControl1.ownMCCriteria1.ownMCCombo1.SelectionComboBoxCanNotCleared = true;
                    }
                    else
                    {
                        ownControl1.ownMCCriteria1.ownMCCombo1.SelectionComboBoxCanNotCleared = false;
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.getObjectsForCombo", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
     
        private void loadComboObjectsOnlyForUsr(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool canBeEmpty, ref qs2.core.vb.dsObjects dsObjectsDropDown)
        {
            try
            {
                ownMCCriteria.dsObjectsWork.tblObject.Clear();
                qs2.core.vb.dsObjects.tblObjectRow rNewObj = (qs2.core.vb.dsObjects.tblObjectRow)ownMCCriteria.sqlObjectsWork.getNewRowObject(dsObjectsDropDown);   //ownMCCriteria.dsObjectsWork
                rNewObj.ItemArray = qs2.core.vb.actUsr.rUsr.ItemArray;
                rNewObj.Active = qs2.core.vb.actUsr.rUsr.Active;

                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {

                }
                else
                {
                    ownControl1.ComboBox.Items.Add(qs2.core.vb.actUsr.rUsr.ID, qs2.core.vb.actUsr.rUsr.NameCombination.Trim());
                    ownControl1.ComboBox.Refresh();
                    if (canBeEmpty)
                    {
                        ownControl1.ComboBox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
                    }
                    else
                    {
                        ownControl1.ComboBox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
                    }
                    ownControl1.ComboBox.Value = ownControl1.ComboBox.Items[0].DataValue;
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.loadComboObjectsOnlyForUsr", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

         private void clearComboForObjects(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "Surgeon", false))
                //{
                //    string xy = "";
                //}


                if (ownControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    ownControl1.ControlForDropDown.clearData();
                }
                else
                {

                    ownControl1.ComboBox.Items.Clear();
                    //ownControl1.ownMCCriteria1.initControl();
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.clearComboForObjects", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public Infragistics.Win.ValueListItem getSelectedObjectxy(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                if (ownControl1.ComboBox.SelectedItem != null)
                {
                    return ownControl1.ComboBox.SelectedItem;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.getSelectedObject", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }

        public void addObjectToComboBoxObject(int IDObject, qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "Surgeon", false))
                //{
                //    string xy = "";
                //}

                bool bExistsInCboBox = false;
                foreach (Infragistics.Win.ValueListItem itmCombBox in ownControl1.ComboBox.Items)
                {
                    if (itmCombBox.DataValue.Equals(IDObject))
                    {
                        bExistsInCboBox = true;
                    }
                }

                if (!bExistsInCboBox)
                {
                    dsAdmin.tblSelListGroupRow[] arrSelListEntriesGroupUsers = (dsAdmin.tblSelListGroupRow[])sqlAdmin.dsAllAdmin.tblSelListGroup.Select(sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='Users'", "");
                    dsAdmin.tblSelListGroupRow rSelListEntriesGroupUsers = arrSelListEntriesGroupUsers[0];
                    dsAdmin.tblSelListEntriesRow[] arrSelListsUsers = (dsAdmin.tblSelListEntriesRow[])sqlAdmin.dsAllAdmin.tblSelListEntries.Select("IDGroup=" + rSelListEntriesGroupUsers.ID, sqlAdmin.dsAllAdmin.tblSelListEntries.IDRessourceColumn .ColumnName + " asc");

                    string NameObject = "";
                    var arrSelListUser = from rSelListUser in arrSelListsUsers.AsEnumerable()
                                           where rSelListUser.IDOwnInt == IDObject
                                           orderby rSelListUser.IDRessource ascending
                                           select rSelListUser;
                    if (arrSelListUser.Count() == 1)
                    {
                        NameObject = arrSelListUser.First().IDRessource.Trim();
                    }
                    else if (arrSelListUser.Count() == 0)
                    {
                        qs2.core.vb.sqlObjects sqlObjectsRead = new core.vb.sqlObjects();
                        sqlObjectsRead.initControl();
                        qs2.core.vb.dsObjects.tblObjectRow rObj = sqlObjectsRead.getObjectRow(IDObject, core.vb.sqlObjects.eTypSelObj.ID);
                        NameObject = rObj.NameCombination.Trim();
                    }
                    else if(arrSelListUser.Count() > 1)
                    {
                        throw new Exception("addObjectToComboBoxObject: rrSelListUser.Count() > 1 for IDObject '" +  IDObject.ToString() + " not allowed'");
                    }

                    ownControl1.ComboBox.Items.Add(IDObject, NameObject.Trim());
                    bool bExistsInList = false;
                    foreach (qs2.design.auto.multiControl.ownMCCombo.eComboBoxObject ComboBoxObjectInList in this.lstCombBoxObjectsAdded)
                    {
                        if (ComboBoxObjectInList.IDObject.Equals(IDObject))
                        {
                            bExistsInList = true;
                        }
                    }
                    if (!bExistsInList)
                    {
                        qs2.design.auto.multiControl.ownMCCombo.eComboBoxObject NewComboBoxObject = new ownMCCombo.eComboBoxObject();
                        NewComboBoxObject.IDObject = IDObject;
                        ownControl1.ownMCCriteria1.ownMCCombo1.lstCombBoxObjectsAdded.Add(NewComboBoxObject);
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.addObjectToComboBoxObject", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void resetComboBoxObject(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                //System.Collections.Generic.List<qs2.design.auto.multiControl.ownMCCombo.eComboBoxObject> lstDeleteListAdded = new List<eComboBoxObject>();
                System.Collections.Generic.List<Infragistics.Win.ValueListItem> lstDeleteCboBox = new List<Infragistics.Win.ValueListItem>();
                foreach (qs2.design.auto.multiControl.ownMCCombo.eComboBoxObject ComboBoxObjectInList in this.lstCombBoxObjectsAdded)
                {
                    //bool bExistsInList = false;
                    foreach (Infragistics.Win.ValueListItem itmCombBox in ownControl1.ComboBox.Items)
                    {
                        if (ComboBoxObjectInList.IDObject.Equals(itmCombBox.DataValue))
                        {
                            lstDeleteCboBox.Add(itmCombBox);
                            //bExistsInList = true;
                        }
                    }
                    foreach (Infragistics.Win.ValueListItem itmCombBoxToDelete in lstDeleteCboBox)
                    {
                        ownControl1.ComboBox.Items.Remove(itmCombBoxToDelete);
                    }
                    //if (bExistsInList)
                    //{
                    //    //lstDeleteListAdded.Add(ComboBoxObjectInList);
                    //}
                }

                //foreach (qs2.design.auto.multiControl.ownMCCombo.eComboBoxObject ComboBoxObjectInListToDelete in lstDeleteListAdded)
                //{
                //    this.lstCombBoxObjectsAdded.Remove(ComboBoxObjectInListToDelete);
                //}

                this.lstCombBoxObjectsAdded.Clear();
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCombo.resetComboBoxObject", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

    }
}
