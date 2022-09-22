using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;



namespace qs2.print
{


    public class doParameterForQuery
    {

        public class cSurgeon
        {
            public dsAdmin.tblQueriesDefRow rQryConditionSurgeonPerfusionistOrig = null;
            public dsAdmin.tblQueriesDefRow[] arrQueriesConditions = null;
            public bool SurgeonAddParametersAuto = false;
            public bool CheckBoxIsOn = false;
            public bool PerfusionistAddParametersAuto = false;

        }

        public class cSelListPar
        {
            public Nullable<Guid> IDOwnMCControl = null;
            public string FieldName = "";
            public string TableName = "";
            public string Combination = "";
            public string CombinationEnd = "";
            public Guid IDGuidMainForNewSort = System.Guid.Empty;
            public System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstQryDefPar = new List<dsAdmin.tblQueriesDefRow>();
            public System.Collections.Generic.List<dsAdmin.tblSelListEntriesRow> lstObjectFields = new List<dsAdmin.tblSelListEntriesRow>();
        }
        public class cFixObjectsGenerated
        {
            public string FieldName = "";
            public string TableName = "";
            public string sValue = "";
        }




        




        

        public void getParValues(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids,
                            qs2.ui.print.infoQry infoQryRunPar,
                            dsAdmin.tblQueriesDefDataTable tQryDefToSetValues,
                            bool IsFctCRParameter, ref bool IsHeadquarter, string IDParticipant,
                            bool noParticipant, bool checkBrackets, ref bool BracketOK)
        {
            try
            {
                System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstParToAdd = new List<dsAdmin.tblQueriesDefRow>();

                System.Collections.Generic.List<core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive = new List<core.vb.businessFramework.cSelListAndObj>();
                qs2.core.vb.businessFramework b = new core.vb.businessFramework();
                b.getAllRolesForUser(qs2.core.vb.actUsr.rUsr.ID, ref lstRolesForUserActive, false);

                string sExceptInfo = "1.check";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                int iCounter = 0;
                dsAdmin.tblQueriesDefRow rQryConditionPrev = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsUI = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                {
                    bool IsSurgeon = false;
                    bool checkBoxUIIsOn = false;
                    qs2.design.auto.multiControl.ownMultiControl ownControlVisibleOnUI = null;

                    if ((rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.ComboBox.ToString().Trim().ToLower() ||
                        rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.ComboBoxNoDb.ToString().Trim().ToLower() ||
                        rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.ComboBoxAsDropDown.ToString().Trim().ToLower()) &&
                        rQryCondition.QryColumn.Trim().ToLower().Equals(("Surgeon").Trim().ToLower()) && !IsFctCRParameter)
                    {
                        IsSurgeon = true;
                    }
                    int iMultiControlsFound = 0;
                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControl in lstMultiControl)
                    {
                        //if (!ownControl.IsInUseInparameterList)
                        //{
                        //    string xy = "";
                        //}
                        if (!ownControl.IsBetweenControlSecondValue)
                        {
                            this.getValueFromMultiControlUI(ownControl, ref infoQryRunPar, rQryCondition, ref IsSurgeon,
                                                            ref checkBoxUIIsOn, ref ownControlVisibleOnUI, ref tQryDefToSetValues,
                                                            ref IsFctCRParameter);
                            iMultiControlsFound += 1;
                        }
                    }

                    if (rQryCondition.ValueMin.Trim() != "")
                    {
                        //Min und Max prüfen. Nur bei Between und Not Between-Conditions
                        if ((rQryCondition.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.between.Trim().ToString().Trim().ToLower()) ||
                            rQryCondition.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.notBetween.Trim().ToString().Trim().ToLower())) && !IsFctCRParameter)
                        {
                            if (ownControlVisibleOnUI != null)
                            {
                                qs2.core.generic.retValue retValueChild = new qs2.core.generic.retValue();
                                retValueChild = ownControlVisibleOnUI.ownMultiControlChild.ownMCValue1.getValue(ownControlVisibleOnUI.ownMultiControlChild, false);
                                rQryCondition.Max = retValueChild.valueStr.Trim();
                            }
                            if (rQryCondition.Max.Trim() == "")
                            {
                                rQryCondition[qs2.core.generic.columnRemoved] = true;
                            }
                        }
                    }
                    //Null und Not Null-Conditions
                    else if (rQryCondition.Condition.Trim().ToLower() == (qs2.core.sqlTxt.isNull).Trim().ToLower() ||
                                rQryCondition.Condition.Trim().ToLower() == (qs2.core.sqlTxt.isNotNull).Trim().ToLower())
                    {
                        rQryCondition[qs2.core.generic.columnRemoved] = false;
                    }
                    else
                    {
                        if (!IsFctCRParameter)
                        {
                            rQryCondition[qs2.core.generic.columnRemoved] = true;
                        }
                    }

                    rQryConditionPrev = rQryCondition;
                    iCounter += 1;
                }

                if (!IsFctCRParameter)
                {
                    this.checkAndCorrectAutoObjectComboBoxes(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues);
                }

                sExceptInfo = "after foreach lstMultiControl";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                this.checkComboBoxAsDropDown(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                sExceptInfo = "after function checkComboBoxAsDropDown";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                this.checkComboBoxCheckThreeStateBox(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                sExceptInfo = "after function checkComboBoxCheckThreeStateBox";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                if (!IsFctCRParameter && checkBrackets)
                {
                    if (!this.checkBrackets(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, IDParticipant,
                                        ref lstRolesForUserActive, ref BracketOK))
                    {
                        throw new Exception("doParameterForQuery.getParValues: checkBrackets() not OK! (" + sExceptInfo.Trim() + "', this.checkBrackets=false)");
                    }
                }

                if (!infoQryRunPar.Application.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    if (!IsHeadquarter && !IsFctCRParameter && !noParticipant)
                    {
                        this.checkIsHeadquarter(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, IDParticipant);
                    }
                    if (!IsFctCRParameter)
                    {
                        this.genObjectsFixInWhere(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, IDParticipant, ref lstRolesForUserActive);
                    }
                }

                if (!IsFctCRParameter)
                {
                    this.checkForContainsParMultiGridSelList(lstMultiControl, lstReturnMultiGrids, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                    sExceptInfo = "after function checkForContainsParMultiGridSelList";
                    if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                    {
                        throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                    }
                }

                System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstDefConditionAdded = new List<dsAdmin.tblQueriesDefRow>();
                if (!infoQryRunPar.Application.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    if (!IsFctCRParameter)
                    {
                        string INKlauselObjectFields = "";
                        string INKlauselSheriffs = "";
                        this.addAutoParameterIDObject(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter,
                                                        ref INKlauselObjectFields, ref INKlauselSheriffs, false, ref lstDefConditionAdded);
                    }
                }

                if (infoQryRunPar.isStayReport)
                {
                    this.addFreeSqlForStayReport(infoQryRunPar.isStayReport, infoQryRunPar.IDGuid, tQryDefToSetValues, infoQryRunPar);                
                }

                sExceptInfo = "last check";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                //if (!infoQryRunPar.isSubQuery && lstDefConditionAdded.Count > 0)
                //{
                //    this.addClaimbs(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                //}

                sExceptInfo = "last check";
                this.buildInfoSql(tQryDefToSetValues, ref IsFctCRParameter, ref infoQryRunPar, ref lstDefConditionAdded);
                //System.Windows.Forms.MessageBox.Show(infoQryRunPar.SqlWhereInfo);

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.getParValues:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void addFreeSqlForStayReport(bool isStayReport, Nullable<Guid> IDGuid, dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, 
                                            qs2.ui.print.infoQry infoQryRunPar)
        {
            try
            {
                if (isStayReport)
                {
                    System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lQueryDefsDel = new List<dsAdmin.tblQueriesDefRow>();
                    foreach (var rQueryDef in tQryDefToSetValues)
                    {
                        if (string.Equals(rQueryDef.Typ, "WhereConditions", StringComparison.InvariantCultureIgnoreCase) ||
                            string.Equals(rQueryDef.Typ, "InputParameters", StringComparison.InvariantCultureIgnoreCase))
                        {
                            lQueryDefsDel.Add(rQueryDef);
                        }
                    }
                    foreach (var rQueryDef in lQueryDefsDel)
                    {
                        rQueryDef.Delete();
                    }
                    tQryDefToSetValues.AcceptChanges();

                    dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), "",
                                                       "", "", "", infoQryRunPar.rSelListQry.ID, core.Enums.eControlType.Integer);
                    rNewQryDefCondition.Combination = "";
                    rNewQryDefCondition.CombinationEnd = "";
                    rNewQryDefCondition.Sort = 0;
                    rNewQryDefCondition.QryTable = infoQryRunPar.rSelListQry._Table;
                    rNewQryDefCondition.freeSql = " IDGuid='" + IDGuid.Value.ToString() + "' ";
                    rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = true;
                    rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addFreeSqlForStayReport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void getParValuesOrig2(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids,
                    qs2.ui.print.infoQry infoQryRunPar,
                    dsAdmin.tblQueriesDefDataTable tQryDefToSetValues,
                    bool IsFctCRParameter, ref bool IsHeadquarter, string IDParticipant, bool bExtern,
                    bool noParticipant)
        {
            try
            {
                System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstParToAdd = new List<dsAdmin.tblQueriesDefRow>();

                System.Collections.Generic.List<core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive = new List<core.vb.businessFramework.cSelListAndObj>();
                qs2.core.vb.businessFramework b = new core.vb.businessFramework();
                b.getAllRolesForUser(qs2.core.vb.actUsr.rUsr.ID, ref lstRolesForUserActive, false);

                string sExceptInfo = "1.check";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                int iCounter = 0;
                int iCounterBracketsCorrected = 0;
                System.Collections.Generic.SortedList<int, dsAdmin.tblQueriesDefRow> lstColsPrev = new SortedList<int, dsAdmin.tblQueriesDefRow>();
                dsAdmin.tblQueriesDefRow rQryConditionPrev = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsUI = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                {
                    bool IsSurgeon = false;
                    bool checkBoxUIIsOn = false;
                    qs2.design.auto.multiControl.ownMultiControl ownControlVisibleOnUI = null;

                    if ((rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.ComboBox.ToString().Trim().ToLower() ||
                        rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.ComboBoxNoDb.ToString().Trim().ToLower() ||
                        rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.ComboBoxAsDropDown.ToString().Trim().ToLower()) &&
                        rQryCondition.QryColumn.Trim().ToLower().Equals(("Surgeon").Trim().ToLower()) && !IsFctCRParameter)
                    {
                        IsSurgeon = true;
                    }
                    int iMultiControlsFound = 0;
                    foreach (qs2.design.auto.multiControl.ownMultiControl ownControl in lstMultiControl)
                    {
                        //if (!ownControl.IsInUseInparameterList)
                        //{
                        //    string xy = "";
                        //}
                        if (!ownControl.IsBetweenControlSecondValue)
                        {
                            this.getValueFromMultiControlUI(ownControl, ref infoQryRunPar, rQryCondition, ref IsSurgeon,
                                                            ref checkBoxUIIsOn, ref ownControlVisibleOnUI, ref tQryDefToSetValues,
                                                            ref IsFctCRParameter);
                            iMultiControlsFound += 1;
                        }
                    }
                    //if (iMultiControlsFound > 1)
                    //{
                    //    throw new Exception("getParValues: iMultiControlsFound > 1 not possible for Field '" + rQryCondition.CriteriaFldShort.Trim()  + "'!!");
                    //}
                    if (rQryCondition.ValueMin.Trim() != "")
                    {
                        if ((rQryCondition.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.between.Trim().ToString().Trim().ToLower()) ||
                            rQryCondition.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.notBetween.Trim().ToString().Trim().ToLower())) && !IsFctCRParameter)
                        {
                            if (ownControlVisibleOnUI != null)
                            {
                                qs2.core.generic.retValue retValueChild = new qs2.core.generic.retValue();
                                retValueChild = ownControlVisibleOnUI.ownMultiControlChild.ownMCValue1.getValue(ownControlVisibleOnUI.ownMultiControlChild, false);
                                if (retValueChild.valueObj != null)
                                {
                                    //retValueChild.valueStr = retValueChild.valueObj.ToString().Trim();
                                }
                                rQryCondition.Max = retValueChild.valueStr.Trim();
                            }
                            if (rQryCondition.Max.Trim() == "")
                            {
                                rQryCondition[qs2.core.generic.columnRemoved] = true;
                            }
                        }
                        //if (IsSurgeon && !checkBoxUIIsOn)
                        //{
                        //    //cSurgeon Surgeon = new cSurgeon();
                        //    //this.checkparContainsParSurgeonPerfusionist(lstMultiControl, infoQryRunPar, ref Surgeon, ref checkBoxUIIsOn, ref tQryDefToSetValues, ref IsFctCRParameter);
                        //    //sExceptInfo = "after function checkparContainsParSurgeon";
                        //    //if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                        //    //{
                        //    //    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                        //    //}
                        //}
                    }
                    else if (rQryCondition.Condition.Trim().ToLower() == (qs2.core.sqlTxt.isNull).Trim().ToLower() ||
                                rQryCondition.Condition.Trim().ToLower() == (qs2.core.sqlTxt.isNotNull).Trim().ToLower())
                    {
                        rQryCondition[qs2.core.generic.columnRemoved] = false;
                    }
                    else
                    {
                        if (!IsFctCRParameter)
                        {
                            rQryCondition[qs2.core.generic.columnRemoved] = true;
                            if (rQryCondition.CombinationEnd.Contains((")")))
                            {
                                //rQryConditionPrev.CombinationEnd += rQryCondition.CombinationEnd;
                                var arrColsPrev = from rColsPrev in lstColsPrev.AsEnumerable()
                                                  where rColsPrev.Value.Sort > iCounterBracketsCorrected
                                                  orderby rColsPrev.Key descending
                                                  select rColsPrev;
                                bool bDone = false;
                                bool BracketOpendeWasRemovedBefore = false;
                                foreach (KeyValuePair<int, dsAdmin.tblQueriesDefRow> keyPairPrev in arrColsPrev)
                                {
                                    if (!bDone && (bool)keyPairPrev.Value[qs2.core.generic.columnRemoved] == true &&
                                        keyPairPrev.Value.Combination.Contains(("(")))
                                    {
                                        BracketOpendeWasRemovedBefore = true;
                                    }

                                    if (!bDone && (bool)keyPairPrev.Value[qs2.core.generic.columnRemoved] == false && !BracketOpendeWasRemovedBefore)
                                    {
                                        keyPairPrev.Value.CombinationEnd += rQryCondition.CombinationEnd;
                                        bDone = true;
                                    }
                                }
                            }
                        }
                        iCounterBracketsCorrected = iCounter;
                    }

                    rQryConditionPrev = rQryCondition;
                    lstColsPrev.Add(iCounter, rQryConditionPrev);
                    iCounter += 1;
                }

                if (!IsFctCRParameter)
                {
                    this.checkAndCorrectAutoObjectComboBoxes(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues);
                }

                sExceptInfo = "after foreach lstMultiControl";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                if (!infoQryRunPar.Application.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    if (!IsHeadquarter && !IsFctCRParameter && !noParticipant)
                    {
                        this.checkIsHeadquarter(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, IDParticipant);
                    }
                    if (!IsFctCRParameter)
                    {
                        this.genObjectsFixInWhere(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, IDParticipant, ref lstRolesForUserActive);
                    }
                }

                this.checkComboBoxAsDropDown(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                sExceptInfo = "after function checkComboBoxAsDropDown";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                this.checkComboBoxCheckThreeStateBox(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                sExceptInfo = "after function checkComboBoxCheckThreeStateBox";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                if (!IsFctCRParameter)
                {
                    this.checkForContainsParMultiGridSelList(lstMultiControl, lstReturnMultiGrids, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                    sExceptInfo = "after function checkForContainsParMultiGridSelList";
                    if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                    {
                        throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                    }
                }

                System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstDefConditionAdded = new List<dsAdmin.tblQueriesDefRow>();
                if (!infoQryRunPar.Application.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    if (!IsFctCRParameter)
                    {
                        string INKlauselObjectFields = "";
                        string INKlauselSheriffs = "";
                        this.addAutoParameterIDObject(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter,
                                                        ref INKlauselObjectFields, ref INKlauselSheriffs, false, ref lstDefConditionAdded);
                    }
                }

                sExceptInfo = "last check";
                if (!this.checkSorts(tQryDefToSetValues, sExceptInfo))
                {
                    throw new Exception("doParameterForQuery.getParValues: Sort-Order in for query not OK! (" + sExceptInfo.Trim() + "', this.checkSorts=false)");
                }

                //if (!infoQryRunPar.isSubQuery && lstDefConditionAdded.Count > 0)
                //{
                //    this.addClaimbs(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter);
                //}

                sExceptInfo = "last check";
                this.buildInfoSql(tQryDefToSetValues, ref IsFctCRParameter, ref infoQryRunPar, ref lstDefConditionAdded);
                //System.Windows.Forms.MessageBox.Show(infoQryRunPar.SqlWhereInfo);

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.getParValues:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public bool checkBrackets(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                    qs2.ui.print.infoQry infoQryRunPar,
                                    ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter,
                                    ref bool IsHeadquarter, string IDParticipant,
                                    ref System.Collections.Generic.List<core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive,
                                    ref bool bBracketsOK)
        {
            try
            {
                dsHelper dsHelperTmp = new dsHelper();
                sqlHelper sqlHelperTmp = new sqlHelper();
                sqlHelperTmp.initControl();
                
                int iBracketEbene = 0;
                int iBracketKey = 0;
                dsHelper.QueriesClampsRow rNewBracketHlpPrev = null;
                dsAdmin.tblQueriesDefRow[] arrQryDef = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select(qs2.core.generic.columnNoCheckClamps + "=0", "Sort asc");
                foreach (dsAdmin.tblQueriesDefRow rQry in arrQryDef)
                {
                    if (rQry.Combination.Trim().Contains("("))
                    {
                        int iBracketOpenCounter = rQry.Combination.Count(c => c == '(');
                        iBracketEbene += iBracketOpenCounter;
                        iBracketKey += 1;
                        rQry[qs2.core.generic.columnClampEbene] = iBracketEbene;
                        rQry[qs2.core.generic.columnClampKey] = iBracketKey;

                        dsHelper.QueriesClampsRow rNewBracketHlp = sqlHelperTmp.getNewRowBrackets(ref dsHelperTmp);
                        rNewBracketHlp.ClampEbene = iBracketEbene;
                        rNewBracketHlp.ClampKey = iBracketKey;
                        rNewBracketHlp.Sort = rQry.Sort;
                        rNewBracketHlp.rQry = rQry;
                        rNewBracketHlpPrev = rNewBracketHlp;
                    }

                    if (rQry.CombinationEnd.Trim().Contains(")"))
                    {
                        int iBracketCloseCounter = rQry.CombinationEnd.Count(c => c == ')');
                        rQry[qs2.core.generic.columnClampEbene] = iBracketEbene;
                        rQry[qs2.core.generic.columnClampKey] = iBracketKey;

                        dsHelper.QueriesClampsRow rNewClampHlp = sqlHelperTmp.getNewRowBrackets(ref dsHelperTmp);
                        rNewClampHlp.ClampEbene = iBracketEbene;
                        rNewClampHlp.ClampKey = iBracketKey;
                        rNewClampHlp.Sort = rQry.Sort;
                        rNewClampHlp.rQry = rQry;
                        rNewBracketHlpPrev = rNewClampHlp;

                        iBracketEbene -= iBracketCloseCounter;
                    }

                    if (iBracketEbene > 0)
                    {
                        if (rQry.Combination.Trim().StartsWith(")"))
                        {
                            dsAdmin.tblQueriesDefRow rQryLastPar = (dsAdmin.tblQueriesDefRow)rNewBracketHlpPrev.rQry;
                            if (rQryLastPar.CombinationEnd.Contains(")"))
                            {
                                throw new Exception("doParameterForQuery.checkBrackets: rQryLastPar.CombinationEnd.Contains((')') in Query '" + infoQryRunPar.rSelListQry.IDRessource.Trim() + "' not possible!");
                            }
                            List<char> lChrClamp = (from c in rQry.Combination where c == ')' select c).ToList();
                            for (int i = 0; i < lChrClamp.Count; i++)
                            {
                                rQryLastPar.CombinationEnd += ") ";
                            }
                            rQry.Combination = rQry.Combination.Replace(")", "");
                            iBracketEbene -= 1;
                        }

                        if (iBracketEbene > 0)
                        {
                            rQry[qs2.core.generic.columnClampEbene] = iBracketEbene;
                            rQry[qs2.core.generic.columnClampKey] = iBracketKey;

                            dsHelper.QueriesClampsRow rNewClampHlp = sqlHelperTmp.getNewRowBrackets(ref dsHelperTmp);
                            rNewClampHlp.ClampEbene = iBracketEbene;
                            rNewClampHlp.ClampKey = iBracketKey;
                            rNewClampHlp.Sort = rQry.Sort;
                            rNewClampHlp.rQry = rQry;
                            rNewBracketHlpPrev = rNewClampHlp;
                        }
                    }
                    else
                    {
                        rQry[qs2.core.generic.columnClampEbene] = -1;
                        rQry[qs2.core.generic.columnClampKey] = -1;
                        rNewBracketHlpPrev = null;
                    }
                }

                bBracketsOK = (iBracketEbene == 0);

                int iBracketKeyTmp = iBracketKey;
                while (iBracketKeyTmp > 0)
                {
                    int iCounter = 0;
                    bool bBracketOK = false;
                    string CombinationFirst = "";
                    dsHelper.QueriesClampsRow[] arrQryBrackets = (dsHelper.QueriesClampsRow[])dsHelperTmp.QueriesClamps.Select(dsHelperTmp.QueriesClamps.ClampKeyColumn.ColumnName + "=" + iBracketKeyTmp.ToString () + "", "Sort asc");
                    //Geöffnete Klammern von gelöschten Rows zu nächst gefundenen nicht gelöschten Rows verschieben
                    foreach (dsHelper.QueriesClampsRow rQryClamp in arrQryBrackets)     
                    {
                        dsAdmin.tblQueriesDefRow rQry = (dsAdmin.tblQueriesDefRow)rQryClamp.rQry;
                        bool bQryRemoved = (bool)rQry[qs2.core.generic.columnRemoved];
                        if (iCounter == 0)
                        {
                            CombinationFirst = rQry.Combination;
                            bBracketOK = (bQryRemoved) ? false : true;
                        }

                        if (!bQryRemoved)
                        {
                            if (!bBracketOK)
                            {
                                rQry.Combination = CombinationFirst;
                                bBracketOK = true;
                            }
                        }
                        iCounter += 1;
                    }

                    iCounter = 0;
                    bBracketOK = false;
                    CombinationFirst = "";
                    System.Collections.Generic.List<String> lCombEnd = new List<string>();
                    arrQryBrackets = (dsHelper.QueriesClampsRow[])dsHelperTmp.QueriesClamps.Select(dsHelperTmp.QueriesClamps.ClampKeyColumn.ColumnName + "=" + iBracketKeyTmp.ToString() + "", "Sort desc");
                    foreach (dsHelper.QueriesClampsRow rQryClamp in arrQryBrackets)         // If CombinationEnd deleted => nach vorne schieben
                    {
                        dsAdmin.tblQueriesDefRow rQry = (dsAdmin.tblQueriesDefRow)rQryClamp.rQry;
                        bool bQryRemoved = (bool)rQry[qs2.core.generic.columnRemoved];
                        if (bQryRemoved && !string.IsNullOrEmpty(rQry.CombinationEnd))
                            lCombEnd.Add(rQry.CombinationEnd);

                        if (!bQryRemoved)
                        {
                            foreach (var comEnd in lCombEnd)
                                rQry.CombinationEnd += comEnd;
                            lCombEnd.Clear();
                        }
                        iCounter += 1;
                    }

                    iCounter = 0;
                    bBracketOK = false;
                    arrQryBrackets = (dsHelper.QueriesClampsRow[])dsHelperTmp.QueriesClamps.Select(dsHelperTmp.QueriesClamps.ClampKeyColumn.ColumnName + "=" + iBracketKeyTmp.ToString() + "", "Sort desc");
                    //Schließende Klammern von gelöschten Rows zu nächst gefundenen nicht gelöschten Rows verschieben (desc)
                    foreach (dsHelper.QueriesClampsRow rQryClamp in arrQryBrackets)
                    {
                        dsAdmin.tblQueriesDefRow rQry = (dsAdmin.tblQueriesDefRow)rQryClamp.rQry;
                        bool bQryRemoved = (bool)rQry[qs2.core.generic.columnRemoved];
                        if (iCounter == 0)
                        {
                            bBracketOK = (bQryRemoved) ? false : true;
                        }

                        if (!bQryRemoved)
                        {
                            if (!bBracketOK)
                            {
                                rQry.CombinationEnd = rQry.CombinationEnd + ") ";
                                bBracketOK = true;
                            }
                        }
                        iCounter += 1;
                    }
                    iBracketKeyTmp--;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkBrackets: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        //public void checkAndAutoCorrectClamps_old(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
        //                    qs2.ui.print.infoQry infoQryRunPar,
        //                    ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues)
        //{
        //    try
        //    {
        //        System.Collections.Generic.SortedList<int, dsAdmin.tblQueriesDefRow> lstColsPrev = new SortedList<int, dsAdmin.tblQueriesDefRow>();
        //        int iCounter = 0;
        //        int iCounterClampCorrected = 0;
        //        //bool IsFirstAndHasAndCombination = false;
        //        dsAdmin.tblQueriesDefRow rQryConditionPrev = null;
        //        string sWhere = "";         //qs2.core.generic.columnIsObjectComboBox + "=1";
        //        qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsCheckObjects = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select(sWhere, tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
        //        foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsCheckObjects)
        //        {
        //            if ((bool)rQryCondition[qs2.core.generic.columnRemoved] == true)
        //            {
        //                if (rQryCondition.CombinationEnd.Contains((")")))
        //                {
        //                    //rQryConditionPrev.CombinationEnd += rQryCondition.CombinationEnd;
        //                    var arrColsPrev = from rColsPrev in lstColsPrev.AsEnumerable()
        //                                      where rColsPrev.Value.Sort > iCounterClampCorrected
        //                                      orderby rColsPrev.Key descending
        //                                      select rColsPrev;
        //                    bool bDone = false;
        //                    bool ClampOpendeWasRemovedBefore = false;
        //                    foreach (KeyValuePair<int, dsAdmin.tblQueriesDefRow> keyPairPrev in arrColsPrev)
        //                    {
        //                        if (!bDone && (bool)keyPairPrev.Value[qs2.core.generic.columnRemoved] == true &&
        //                            keyPairPrev.Value.Combination.Contains(("(")))
        //                        {
        //                            ClampOpendeWasRemovedBefore = true;
        //                        }

        //                        if (!bDone && (bool)keyPairPrev.Value[qs2.core.generic.columnRemoved] == false && !ClampOpendeWasRemovedBefore)
        //                        {
        //                            keyPairPrev.Value.CombinationEnd += rQryCondition.CombinationEnd;
        //                            bDone = true;
        //                        }
        //                    }
        //                }
        //                iCounterClampCorrected = iCounter;
        //            }

        //            rQryConditionPrev = rQryCondition;
        //            lstColsPrev.Add(iCounter, rQryConditionPrev);
        //            iCounter += 1;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("doParameterForQuery.checkAndAutoCorrectClamps:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
        //    }
        //}


        public void getValueFromMultiControlUI(qs2.design.auto.multiControl.ownMultiControl ownControl,
                                                ref qs2.ui.print.infoQry infoQryRunPar, dsAdmin.tblQueriesDefRow rQryCondition,
                                                ref bool IsSurgeon,
                                                ref bool checkBoxUIIsOn, ref qs2.design.auto.multiControl.ownMultiControl ownControlVisibleOnUI,
                                                ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValuesref, ref bool IsFctCRParameter)
        {
            try
            {
                if (ownControl.Visible)
                {
                    if (infoQryRunPar.IDQueryGroup.Equals(ownControl.IDGroupReport))
                    {
                        if (rQryCondition.IDGuid.Equals(ownControl.rQry.IDGuid))
                        {
                            qs2.core.generic.retValue retValue1 = new qs2.core.generic.retValue();
                            retValue1 = ownControl.ownMCValue1.getValue(ownControl, false);
                            if (retValue1.valueObj != null)
                            {
                                //retValue1.valueStr = retValue1.valueObj.ToString().Trim();
                            }
                            rQryCondition.ValueMin = retValue1.valueStr;
                            if (ownControl.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown)
                            {
                                rQryCondition.ComboAsDropDownCondition = ownControl.ControlForDropDown.optTypeCombination.Value.ToString();
                                if (ownControl.ownMCCriteria1.ownMCCombo1.TypeComboBox == qs2.core.Enums.cVariablesValues.Roles)
                                {
                                    bool CheckBoxExists = false;
                                    checkBoxUIIsOn = ownControl.ownMCUI1.getValueCheckBox(ref CheckBoxExists);
                                    rQryCondition[qs2.core.generic.columnCheckOn] = checkBoxUIIsOn;
                                    rQryCondition[qs2.core.generic.columnIsObjectComboBox] = true;
                                }
                            }
                            else if (ownControl.OwnControlType == core.Enums.eControlType.ComboBox)
                            {
                                if (ownControl.ownMCCriteria1.ownMCCombo1.TypeComboBox == qs2.core.Enums.cVariablesValues.Roles)
                                {
                                    bool CheckBoxExists = false;
                                    checkBoxUIIsOn = ownControl.ownMCUI1.getValueCheckBox(ref CheckBoxExists);
                                    rQryCondition[qs2.core.generic.columnCheckOn] = checkBoxUIIsOn;
                                    rQryCondition[qs2.core.generic.columnIsObjectComboBox] = true;
                                }
                            }
                            else
                            {
                                rQryCondition.ComboAsDropDownCondition = "";
                            }
                            if (IsSurgeon)
                            {
                                if (ownControl.ownMCUI1.checkIsSurgeonControl(ownControl) && !IsFctCRParameter)
                                {
                                    bool CheckBoxExists = false;
                                    checkBoxUIIsOn = ownControl.ownMCUI1.getValueCheckBox(ref CheckBoxExists);
                                    //string xy = "";
                                }
                            }
                            rQryCondition[qs2.core.generic.columnMultiControl] = ownControl;
                            ownControlVisibleOnUI = ownControl;
                            ownControl.valueTaken = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.getValueFromMultiControlUI:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public bool ColumnExistsInTable(string TableName, string ColumnName)
        {
            try
            {
                qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(TableName.Trim(), ColumnName.Trim(), qs2.core.SysDB.sqlSysDB.dsSysDBAll, false);
                if (rColSys == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ColumnExistsinTable: " + ex.ToString());
            }
        }

        public void checkAndCorrectAutoObjectComboBoxes(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                                    qs2.ui.print.infoQry infoQryRunPar,
                                                    ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues)
        {
            try
            {
                bool IsFirstAndHasAndCombination = false;
                dsAdmin.tblQueriesDefRow rQryConditionObjPrev = null;
                string sWhere = "";         //qs2.core.generic.columnIsObjectComboBox + "=1";
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsCheckObjects = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select(sWhere, tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryConditionObj in arrQryConditionsCheckObjects)
                {
                    if ((bool)rQryConditionObj[qs2.core.generic.columnIsObjectComboBox] == true)
                    {
                        if (rQryConditionObj.Combination.Contains("("))
                        {
                            IsFirstAndHasAndCombination = false;
                            rQryConditionObjPrev = null;
                        }
                        if ((rQryConditionObjPrev == null) && ((bool)rQryConditionObj[qs2.core.generic.columnRemoved] == false) &&
                                rQryConditionObj.Combination.Trim().ToLower().Contains("and".Trim().ToLower()))
                        {
                            IsFirstAndHasAndCombination = true;
                        }
                        if ((rQryConditionObjPrev != null) && !IsFirstAndHasAndCombination &&
                            rQryConditionObj.Combination.Trim().ToLower().Contains("or".Trim().ToLower()))
                        {
                            rQryConditionObj.Combination = rQryConditionObj.Combination.Replace("or", "and");
                        }
                        rQryConditionObjPrev = rQryConditionObj;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkAndCorrectAutoObjectComboBoxes:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void checkForContainsParMultiGridSelList(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids,
                                                            qs2.ui.print.infoQry infoQryRunPar,
                                                            ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter)
        {
            try
            {
                //bool IsMultiGrid = false;
                dsAdmin.tblQueriesDefRow[] arrQueriesConditions = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQueriesConditions)
                {
                    if (rQryCondition.ControlType.Trim().ToLower() == core.Enums.eControlType.GridMultiSelect.ToString().Trim().ToLower() &&
                        rQryCondition.QryColumn.Trim().ToLower().Equals(("gridConFactors").Trim().ToLower()) && !IsFctCRParameter)
                    {
                        //IsMultiGrid = true;

                        sqlAdmin sqlAdminTmp = new sqlAdmin();
                        sqlAdminTmp.initControl();

                        qs2.design.auto.multiControl.ownMultiGridSelList ElementMultiGridSelListForQueryFound = null;
                        System.Collections.Generic.List<qs2.core.generic.retValue> lstUserInput = new List<core.generic.retValue>();
                        foreach (qs2.design.auto.multiControl.ownMultiGridSelList ownControlSelListGrid in lstReturnMultiGrids)
                        {
                            if (infoQryRunPar.IDQueryGroup.Equals(ownControlSelListGrid.IDGroupReport))
                            {
                                if (ownControlSelListGrid.rQry.IDGuid.Equals(rQryCondition.IDGuid))
                                {
                                    ElementMultiGridSelListForQueryFound = ownControlSelListGrid;
                                    ElementMultiGridSelListForQueryFound.getSelListsAdded(lstUserInput);
                                }
                            }
                        }

                        //qs2.design.auto.ui ui = new qs2.design.auto.ui();
                        //System.Collections.Generic.List<qs2.core.generic.retValue> lstUserInput = ui.getControlValues(infoQryRunPar.ownMultiGridSelList1);
                        if (lstUserInput.Count > 0)
                        {
                            string sqlWhereMultiGrid = "";
                            foreach (qs2.core.generic.retValue vParToSet in lstUserInput)
                            {
                                if (sqlWhereMultiGrid.Trim() != "")
                                {
                                    sqlWhereMultiGrid += qs2.core.sqlTxt.and;
                                }
                                sqlWhereMultiGrid += " CongenitalData like '%" + vParToSet.valueStr.Trim() + "%' ";
                                //this.genSql1.setParametersListSqlFix(ref lstSqlFix, ref  infoQryRunPar.Sql, vParToSet.fieldInfo, vParToSet.valueStr);

                                dsAdmin.tblQueriesDefRow rNewQryDefCondition = sqlAdminTmp.addRowQueriesDef(tQryDefToSetValues);
                                doParameterForQuery.setRowToDefault(rNewQryDefCondition);

                                rNewQryDefCondition.ApplicationOwn = infoQryRunPar.Application;
                                rNewQryDefCondition.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                                rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                                rNewQryDefCondition.Typ = core.Enums.eTypQueryDef.WhereConditions.ToString();
                                rNewQryDefCondition.Combination = qs2.core.sqlTxt.and;
                                rNewQryDefCondition.Condition = qs2.core.sqlTxt.like;
                                rNewQryDefCondition.QryColumn = "CongenitalData";
                                rNewQryDefCondition.QryTable = infoQryRunPar.rSelListQry._Table;
                                rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                                rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                                rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = false;
                                rNewQryDefCondition.IsSQLServerField = true;
                                rNewQryDefCondition.IDSelList = infoQryRunPar.rSelListQry.ID;
                                rNewQryDefCondition.UserInput = true;

                                if (vParToSet.sType.Trim().ToLower().Equals(core.vb.sqlAdmin.eTypStayAdditions.multiSelListsRoles.ToString().Trim().ToLower()))
                                {
                                    rNewQryDefCondition.ValueMin = "%IDObject=" + vParToSet.valueStr.Trim() + "%";
                                    //%IDObject=
                                }
                                else
                                {
                                    rNewQryDefCondition.ValueMin = vParToSet.valueStr.Trim();
                                }
                                //rNewQryDefCondition.freeSql = sqlWhereMultiGrid;
                                rNewQryDefCondition.ControlType = core.Enums.eControlType.Textfield.ToString();

                            }

                            sqlWhereMultiGrid = " ( " + sqlWhereMultiGrid + " ) ";
                            //infoQryRunPar.Sql += (!infoQryRunPar.Sql.Contains(qs2.core.sqlTxt.where.Trim()) ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and) + " " + sqlWhereMultiGrid;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkForContainsParMultiGridSelList:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void checkComboBoxCheckThreeStateBox(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                        qs2.ui.print.infoQry infoQryRunPar,
                                        ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsUI = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                {
                    if (!(bool)rQryCondition[qs2.core.generic.columnRemoved] && !(bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox])
                    {
                        if (rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ComboBoxCheckThreeStateBox.ToString().Trim().ToLower()) ||
                             rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.CheckBox.ToString().Trim().ToLower()) ||
                             rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.CheckBoxNoDb.ToString().Trim().ToLower()) ||
                             rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ThreeStateCheckBox.ToString().Trim().ToLower()) ||
                             rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ThreeStateCheckBoxNoDb.ToString().Trim().ToLower()))
                        {
                            if (!rQryCondition.ComboAsDropDown && rQryCondition.ValueMin.Trim() == "2")
                            {
                                rQryCondition[qs2.core.generic.columnRemoved] = true;
                            }
                        }
                    }
                    else
                    {
                        //string str = "";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkComboBoxCheckThreeStateBox:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void checkIsHeadquarter(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                                qs2.ui.print.infoQry infoQryRunPar,
                                                ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter,
                                                ref bool IsHeadquarter, string IDParticipant)
        {
            try
            {
                string TableNameSys = this.getTableNameForSysCatalog(infoQryRunPar.rSelListQry._Table.Trim());
                if (this.ColumnExistsInTable(TableNameSys.Trim(), "IDParticipant"))
                {
                    sqlAdmin sqlAdminTmp = new sqlAdmin();
                    sqlAdminTmp.initControl();

                    dsAdmin.tblQueriesDefRow rNewQryDefCondition = sqlAdminTmp.addRowQueriesDef(tQryDefToSetValues);
                    doParameterForQuery.setRowToDefault(rNewQryDefCondition);

                    rNewQryDefCondition.ApplicationOwn = infoQryRunPar.Application;
                    rNewQryDefCondition.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                    rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                    rNewQryDefCondition.Typ = core.Enums.eTypQueryDef.WhereConditions.ToString();
                    rNewQryDefCondition.Combination = qs2.core.sqlTxt.and;
                    rNewQryDefCondition.Condition = qs2.core.sqlTxt.equals;
                    rNewQryDefCondition.QryColumn = "IDParticipant";
                    rNewQryDefCondition.QryTable = infoQryRunPar.rSelListQry._Table;
                    rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                    rNewQryDefCondition.IsSQLServerField = true;
                    rNewQryDefCondition.IDSelList = infoQryRunPar.rSelListQry.ID;
                    rNewQryDefCondition.FunctionPar = false;
                    rNewQryDefCondition.UserInput = false;
                    rNewQryDefCondition.ValueMin = IDParticipant.Trim();
                    rNewQryDefCondition.ControlType = core.Enums.eControlType.Textfield.ToString();
                    rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                    rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkIsHeadquarter: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


        public void genObjectsFixInWhere(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                        qs2.ui.print.infoQry infoQryRunPar,
                                        ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter,
                                        ref bool IsHeadquarter, string IDParticipant, ref System.Collections.Generic.List<core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive)
        {
            try
            {
                System.Collections.Generic.List<cFixObjectsGenerated> lstFixObjectsGenerated = new List<cFixObjectsGenerated>();
                this.genObjectsFixInWhere(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, 
                                            IDParticipant, ref lstRolesForUserActive, "IsSurgical", 1, ref lstFixObjectsGenerated);
                this.genObjectsFixInWhere(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, 
                                            IDParticipant, ref lstRolesForUserActive, "IsCardiological", 9, ref lstFixObjectsGenerated);
                this.genObjectsFixInWhere(lstMultiControl, infoQryRunPar, ref tQryDefToSetValues, ref IsFctCRParameter, ref IsHeadquarter, 
                                            IDParticipant, ref lstRolesForUserActive, "IsPerfusionist", 4, ref lstFixObjectsGenerated);

                string sWhereFix1 = "";
                string sWhereFix2 = "";
                int iCounter = 0;
                foreach (cFixObjectsGenerated FixObjectsGenerated in lstFixObjectsGenerated)
                {
                    string sComnbination1 = "";
                    string sComnbination2 = "";
                    string sComnbinationEnd = "";
                    if (lstFixObjectsGenerated.Count == 1)
                    {
                        if (iCounter == 0) sComnbination1 = " ";
                    }
                    else
                    {
                        if (iCounter == 0) sComnbination1 = " ("; else sComnbination1 = " or ";
                        if (iCounter == 0) sComnbination2 = " ("; else sComnbination2 = " and ";
                    }
                    if (iCounter == lstFixObjectsGenerated.Count - 1 && iCounter > 0) sComnbinationEnd = " ) ";

                    sWhereFix1 += sComnbination1 + "" + FixObjectsGenerated.TableName.Trim() + "." + FixObjectsGenerated.FieldName.Trim() + "=1" + sComnbinationEnd + "";
                    sWhereFix2 += sComnbination2 + "" + FixObjectsGenerated.TableName.Trim() + "." + FixObjectsGenerated.FieldName.Trim() + "<0" + sComnbinationEnd + "";

                    //dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), sComnbination,
                    //            FixObjectsGenerated.FieldName.Trim(), FixObjectsGenerated.TableName.Trim(), FixObjectsGenerated.sValue.Trim(), infoQryRunPar.rSelListQry.ID,
                    //            core.Enums.eControlType.Integer);
                    //rNewQryDefCondition.CombinationEnd = sComnbinationEnd;
                    iCounter += 1;
                }

                if (sWhereFix1.Trim() != "")
                {
                    dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), "",
                                                                        "", "", "", infoQryRunPar.rSelListQry.ID, core.Enums.eControlType.Integer);
                    rNewQryDefCondition.Combination = qs2.core.sqlTxt.and;
                    rNewQryDefCondition.CombinationEnd = "";
                    rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                    rNewQryDefCondition[qs2.core.generic.columnRemoved] = true;
                    rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = true;
                    rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                    rNewQryDefCondition.QryTable = infoQryRunPar.rSelListQry._Table.Trim();
                    //rNewQryDefCondition[qs2.core.generic.columnIDGuidMainForNewSort] = pair2.Value.IDGuidMainForNewSort;
                    rNewQryDefCondition.freeSql = " (" + sWhereFix1 + " or " + sWhereFix2 + ")";
                    rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = true;
                    rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                }


                //int iCounter = 0;
                //foreach (cFixObjectsGenerated FixObjectsGenerated in lstFixObjectsGenerated)
                //{
                //    string sComnbination = "";
                //    string sComnbinationEnd = "";
                //    if (lstFixObjectsGenerated.Count == 1)
                //    {
                //        if (iCounter == 0) sComnbination = " and ";
                //    }
                //    else
                //    {
                //        if (iCounter == 0) sComnbination = " and ("; else sComnbination = " or ";
                //    }
                //    if (iCounter == lstFixObjectsGenerated.Count - 1 && iCounter > 0) sComnbinationEnd = " ) ";

                //    dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), sComnbination,
                //                FixObjectsGenerated.FieldName.Trim(), FixObjectsGenerated.TableName.Trim(), FixObjectsGenerated.sValue.Trim(), infoQryRunPar.rSelListQry.ID,
                //                core.Enums.eControlType.Integer);
                //    rNewQryDefCondition.CombinationEnd = sComnbinationEnd;
                //    iCounter += 1;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.genObjectsFixInWhere: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void genObjectsFixInWhere(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                qs2.ui.print.infoQry infoQryRunPar,
                                ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter,
                                ref bool IsHeadquarter, string IDParticipant, ref System.Collections.Generic.List<core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive,
                                string CheckFldShort, int CheckRoleNr, ref System.Collections.Generic.List<cFixObjectsGenerated> lstFixObjectsGenerated)
        {
            try
            {
                string TableNameSys = this.getTableNameForSysCatalog(infoQryRunPar.rSelListQry._Table.Trim());
                if (this.ColumnExistsInTable(TableNameSys.Trim(), CheckFldShort))
                {
                    bool RoleFoundForLoggedInUser = false;
                    int sValue = 0;
                    foreach (core.vb.businessFramework.cSelListAndObj cRoleLoggedInUser in lstRolesForUserActive)
                    {
                        if (cRoleLoggedInUser.rSelList.IDOwnInt.Equals(CheckRoleNr))
                        {
                            RoleFoundForLoggedInUser = true;
                            sValue = 1;
                        }
                    }
                    //infoQryRunPar.rSelListQry._Table
                    if (RoleFoundForLoggedInUser)
                    {
                        cFixObjectsGenerated NewFixObjectsGenerated = new cFixObjectsGenerated();
                        NewFixObjectsGenerated.FieldName = CheckFldShort.Trim();
                        NewFixObjectsGenerated.TableName = infoQryRunPar.rSelListQry._Table.Trim();
                        NewFixObjectsGenerated.sValue = sValue.ToString();

                        lstFixObjectsGenerated.Add(NewFixObjectsGenerated);
                        //dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter2(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), " and ",
                        //                                                CheckFldShort.Trim(), infoQryRunPar.rSelListQry._Table.Trim(), sValue.ToString(), infoQryRunPar.rSelListQry.ID,
                        //                                                core.Enums.eControlType.Integer);
                    }

                    //sqlAdmin sqlAdminTmp = new sqlAdmin();
                    //sqlAdminTmp.initControl();

                    //dsAdmin.tblQueriesDefRow rNewQryDefCondition = sqlAdminTmp.addRowQueriesDef(tQryDefToSetValues);
                    //doParameterForQuery.setRowToDefault(rNewQryDefCondition);

                    //rNewQryDefCondition.ApplicationOwn = infoQryRunPar.Application;
                    //rNewQryDefCondition.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                    //rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                    //rNewQryDefCondition.Typ = core.Enums.eTypQueryDef.WhereConditions.ToString();
                    //rNewQryDefCondition.Combination = qs2.core.sqlTxt.and;
                    //rNewQryDefCondition.Condition = qs2.core.sqlTxt.equals;
                    //rNewQryDefCondition.QryColumn = "IDParticipant";
                    //rNewQryDefCondition.QryTable = infoQryRunPar.rSelListQry._Table;
                    //rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                    //rNewQryDefCondition.IsSQLServerField = true;
                    //rNewQryDefCondition.IDSelList = infoQryRunPar.rSelListQry.ID;
                    //rNewQryDefCondition.FunctionPar = false;
                    //rNewQryDefCondition.UserInput = false;
                    //rNewQryDefCondition.ValueMin = IDParticipant.Trim();
                    //rNewQryDefCondition.ControlType = core.Enums.eControlType.Textfield.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.genObjectsFixInWhere: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void addAutoParameterIDObject(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControlxy,
                                                qs2.ui.print.infoQry infoQryRunPar,
                                                ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter,
                                                ref bool IsHeadquarter,
                                                ref string INKlauselObjectFields, ref string INKlauselCombBox, bool onlytblStay,
                                                ref System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstDefConditionAdded)
        {
            try
            {
                INKlauselObjectFields = "";
                INKlauselCombBox = "";

                sqlAdmin sqlAdminTmp = new sqlAdmin();
                sqlAdminTmp.initControl();
                System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstQryToDelete = new List<dsAdmin.tblQueriesDefRow>();

                qs2.core.vb.businessFramework b = new businessFramework();
                qs2.core.vb.dsAdmin dsAdminTmp = new qs2.core.vb.dsAdmin();
                dsAdmin.tblSelListEntriesRow[] arrSelListObjFieldInDB = null;
                b.getAllObjectFieldsInProductStay(ref arrSelListObjFieldInDB, false, infoQryRunPar.Application);
                dsAdmin.tblSelListEntriesRow[] arrSelListObjFieldInDBSheriff = null;
                b.getAllObjectFieldsInProductStay(ref arrSelListObjFieldInDBSheriff, true, infoQryRunPar.Application);

                var rQueriesDefUICbo = from rQueriesDef in tQryDefToSetValues.AsEnumerable()
                                       where (rQueriesDef.ControlType == core.Enums.eControlType.ComboBox.ToString().Trim() ||
                                               rQueriesDef.ControlType == core.Enums.eControlType.ComboBoxNoDb.ToString().Trim())
                                       orderby rQueriesDef.Sort ascending
                                       select rQueriesDef;

                int Counter = 0;
                System.Collections.Generic.SortedList<int, cSelListPar> lstObjectComboBoxIN = new SortedList<int, cSelListPar>();
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in rQueriesDefUICbo)
                {
                    if (!(bool)rQryCondition[qs2.core.generic.columnRemoved])
                    {
                        bool IsObjectComboBox = System.Convert.ToBoolean(rQryCondition[qs2.core.generic.columnIsObjectComboBox]);
                        if (IsObjectComboBox)
                        {
                            qs2.design.auto.multiControl.ownMultiControl ownControl = (qs2.design.auto.multiControl.ownMultiControl)rQryCondition[qs2.core.generic.columnMultiControl];
                            var varObjectFieldsFomrUI = from rSelListComboBox in arrSelListObjFieldInDB.AsEnumerable()
                                                        where rSelListComboBox.FldShortColumn == rQryCondition.QryColumn.Trim()
                                                        select rSelListComboBox;

                            lstQryToDelete.Add(rQryCondition);
                            if (varObjectFieldsFomrUI.Count() > 0)
                            {
                                if (varObjectFieldsFomrUI.Count() > 1)
                                {
                                    throw new Exception("addAutoParameterIDObject: varSheriffs.Count() > 1!");
                                }
                                dsAdmin.tblSelListEntriesRow rSelListComboBox = varObjectFieldsFomrUI.First();
                                cSelListPar SelListPar = this.addToDictionary(ref lstObjectComboBoxIN, ref ownControl.ID, rQryCondition, rQryCondition.QryColumn.Trim(), rQryCondition.QryTable.Trim(), ref Counter);
                                SelListPar.Combination = rQryCondition.Combination;
                                SelListPar.CombinationEnd = rQryCondition.CombinationEnd;
                                SelListPar.IDGuidMainForNewSort = (Guid)rQryCondition[qs2.core.generic.columnIDGuidMainForNewSort];
                                bool columnCheckOn = System.Convert.ToBoolean(rQryCondition[qs2.core.generic.columnCheckOn]);
                                if (columnCheckOn)
                                {
                                    foreach (dsAdmin.tblSelListEntriesRow rSelListObj in arrSelListObjFieldInDB)
                                    {
                                        SelListPar.lstObjectFields.Add(rSelListObj);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //string xy = "";
                    }
                }

                this.genINKlausel2(ref lstObjectComboBoxIN, ref tQryDefToSetValues, ref infoQryRunPar, ref lstQryToDelete,
                                    ref INKlauselObjectFields, ref INKlauselCombBox, onlytblStay, ref lstDefConditionAdded);

                foreach (dsAdmin.tblQueriesDefRow rQryConditionDelete in lstQryToDelete)
                {
                    rQryConditionDelete.Delete();
                }
                tQryDefToSetValues.AcceptChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addAutoParameterIDObject: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void genINKlausel2(ref System.Collections.Generic.SortedList<int, cSelListPar> lstObjectComboBox, ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues,
                                    ref qs2.ui.print.infoQry infoQryRunPar, ref System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstQryToDelete,
                                    ref string INKlauselCheckBoxInComboBox, ref string INKlauselCombBox, bool onlytblStay,
                                    ref System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstDefConditionAdded)
        {
            try
            {
                bool sClaimbOn = false;
                bool sClaimbOff = false;

                foreach (System.Collections.Generic.KeyValuePair<int, cSelListPar> pair2 in lstObjectComboBox)
                {
                    INKlauselCheckBoxInComboBox = "";         // Felder, die durch das Häkchen in der Oberfläche eingebeldnet werden (Surg_Assist1,....)
                    INKlauselCombBox = "";             // Alle Object-Felder (heißen Sheriff, weil es ein Irrtum war)

                    dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), "",
                                                                                        "", "", "", infoQryRunPar.rSelListQry.ID, core.Enums.eControlType.Integer);
                    rNewQryDefCondition.Combination = pair2.Value.Combination;
                    rNewQryDefCondition.CombinationEnd = pair2.Value.CombinationEnd;
                    rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                    rNewQryDefCondition[qs2.core.generic.columnRemoved] = true;
                    rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = true;

                    if (rNewQryDefCondition.Combination.Trim() == "")
                    {
                        rNewQryDefCondition.Combination = " and ";
                    }

                    if (rNewQryDefCondition.Combination.Trim().Contains(("(")))
                    {
                        sClaimbOn = true;
                    }
                    if (rNewQryDefCondition.CombinationEnd.Trim().Contains((")")))
                    {
                        sClaimbOff = true;
                    }

                    rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                    rNewQryDefCondition.QryTable = pair2.Value.TableName.Trim();
                    rNewQryDefCondition[qs2.core.generic.columnIDGuidMainForNewSort] = pair2.Value.IDGuidMainForNewSort;

                    string INKlausel2 = "";
                    foreach (dsAdmin.tblQueriesDefRow rQueriesDef in pair2.Value.lstQryDefPar)
                    {
                        bool bAddToList = true;
                        System.Collections.Generic.List<string> lstValuesCboBox = qs2.core.generic.readStrVariables(rQueriesDef.ValueMin.Trim());
                        foreach (string sIDObject in lstValuesCboBox)
                        {
                            if (onlytblStay)
                            {
                                if (rQueriesDef.QryTable.Trim().ToLower().Equals(("tblStay").Trim().ToLower()))
                                {
                                    INKlausel2 += (INKlausel2.Trim() == "" ? "" : ",") + sIDObject.Trim();
                                }
                                else
                                {
                                    //bool isNotTblStay = true;
                                }
                            }
                            else
                            {
                                if (!sIDObject.Trim().ToLower().Equals(("-1").Trim().ToLower()))
                                {
                                    INKlausel2 += (INKlausel2.Trim() == "" ? "" : ",") + sIDObject.Trim();
                                }
                                else
                                {
                                    bAddToList = false;
                                }
                            }
                        }
                        if (bAddToList)
                        {
                            //lstQryToDelete.Add(rQueriesDef);
                        }
                    }

                    string sProt = "";
                    foreach (dsAdmin.tblSelListEntriesRow rSelListObjects in pair2.Value.lstObjectFields)
                    {
                        string TableNameSysSub = this.getTableNameForSysCatalog(pair2.Value.TableName.Trim());
                        if (this.ColumnExistsInTable(TableNameSysSub.Trim(), rSelListObjects.FldShortColumn.Trim()))
                        {
                            if (onlytblStay)
                            {
                                if (TableNameSysSub.Trim().ToLower().Equals(("tblStay").Trim().ToLower()))
                                {
                                    string INKlauselObjectFieldTmp = "";                    //qs2.core.dbBase.dbSchema + 
                                    INKlauselObjectFieldTmp = pair2.Value.TableName.Trim() + "." + rSelListObjects.FldShortColumn.Trim() + " IN (" + INKlausel2.Trim() + ") ";
                                    INKlauselCheckBoxInComboBox += (INKlauselCheckBoxInComboBox.Trim() == "" ? " and (" : " or ") + INKlauselObjectFieldTmp;
                                }
                                else
                                {
                                    //bool isNotTblStay = true;
                                }
                            }
                            else
                            {
                                string INKlauselObjectFieldTmp = "";                    //qs2.core.dbBase.dbSchema + 
                                INKlauselObjectFieldTmp = pair2.Value.TableName.Trim() + "." + rSelListObjects.FldShortColumn.Trim() + " IN (" + INKlausel2.Trim() + ") ";
                                INKlauselCheckBoxInComboBox += (INKlauselCheckBoxInComboBox.Trim() == "" ? " and (" : " or ") + INKlauselObjectFieldTmp;
                            }
                        }
                        else
                        {
                            //bool NotInTabel = true;
                        }
                        sProt += rSelListObjects.FldShortColumn.Trim() + "\r\n";
                    }
                    bool doWhereCboBox = true;
                    if (INKlauselCheckBoxInComboBox.Trim() != "")
                    {
                        //INKlauselCheckBoxInComboBox += " or " + pair2.Value.TableName.Trim() + "." + pair2.Value.FieldName.Trim() + " IN (" + INKlausel2 + ") ";
                        INKlauselCheckBoxInComboBox = INKlauselCheckBoxInComboBox.Replace("and", "");
                        INKlauselCheckBoxInComboBox += ")";
                        doWhereCboBox = false;
                    }

                    bool doWhere = true;
                    if (doWhere)
                    {
                        if (INKlausel2.Trim() != "")
                        {
                            INKlauselCombBox = "" + pair2.Value.TableName.Trim() + "." + pair2.Value.FieldName.Trim() + " IN (" + INKlausel2 + ") ";      //qs2.core.dbBase.dbSchema +
                        }
                        if (!doWhereCboBox)
                        {
                            rNewQryDefCondition.freeSql =  INKlauselCheckBoxInComboBox;
                        }
                        else
                        {
                            rNewQryDefCondition.freeSql = INKlauselCombBox + INKlauselCheckBoxInComboBox;
                        }
                        lstDefConditionAdded.Add(rNewQryDefCondition);
                        rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = true;
                        rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                    }
                }

                if ((sClaimbOn && !sClaimbOff) || (!sClaimbOn && sClaimbOff))
                {
                    foreach (dsAdmin.tblQueriesDefRow rQueriesDef in lstDefConditionAdded)
                    {
                        rQueriesDef.Combination = rQueriesDef.Combination.Replace("(", "");
                        rQueriesDef.CombinationEnd = rQueriesDef.CombinationEnd.Replace(")", "");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("genINKlausel: " + ex.ToString());
            }
        }
        public cSelListPar addToDictionary(ref System.Collections.Generic.SortedList<int, cSelListPar> lstObjectComboBox, ref Guid IDOwnMCControl, dsAdmin.tblQueriesDefRow rQryCondition,
                                    string FieldName, string TableName, ref int Counter)
        {
            try
            {
                cSelListPar SelListPar = null;
                //if (lstObjectComboBox.ContainsKey(IDOwnMCControl))
                //{
                //    SelListPar = lstObjectComboBox[IDOwnMCControl];
                //}
                //else
                //{
                //    SelListPar = new cSelListPar();
                //}
                SelListPar = new cSelListPar();
                SelListPar.IDOwnMCControl = IDOwnMCControl;
                SelListPar.FieldName = FieldName.Trim();
                SelListPar.TableName = TableName.Trim();

                SelListPar.lstQryDefPar.Add(rQryCondition);
                lstObjectComboBox.Add(Counter, SelListPar);
                Counter += 1;

                return SelListPar;
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addToDictionary: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public string getTableNameForSysCatalog(string TableNameToCheck)
        {
            try
            {
                string TableNameReturn = TableNameToCheck.Trim();
                if (TableNameReturn.Trim().ToLower().StartsWith(("qs2.fnc").Trim().ToLower()))
                {
                    TableNameReturn = TableNameReturn.Trim().Insert(4, "v");
                }
                if (TableNameReturn.Trim().ToLower().StartsWith(("qs2.").Trim().ToLower()))
                {
                    TableNameReturn = TableNameReturn.Trim().Substring(4, TableNameReturn.Trim().Length - 4);
                }
                return TableNameReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("getTableNameForSysCatalog: " + ex.ToString());
            }
        }

        public void checkComboBoxAsDropDown(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                        qs2.ui.print.infoQry infoQryRunPar,
                                        ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter)
        {
            try
            {
                int iCounterNewParTotalAdded = 0;
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsUI = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                {
                    if (rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ComboBox.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ComboBoxNoDb.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ThreeStateCheckBox.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ThreeStateCheckBoxNoDb.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.CheckBox.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.CheckBoxNoDb.ToString().Trim().ToLower()))
                    {
                        if (rQryCondition.ComboAsDropDown && (bool)rQryCondition[qs2.core.generic.columnRemoved] && (bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox])
                        {
                            if (rQryCondition.CombinationEnd.Trim() != "")
                            {
                                dsAdmin.tblQueriesDefRow rQryConditionBeforeNotRemoved = this.getLastBeforeNotRemoved(tQryDefToSetValues, rQryCondition.Sort);
                                //rQryConditionBeforeNotRemoved.CombinationEnd += " " + rQryCondition.CombinationEnd;
                            }
                        }
                        else if (rQryCondition.ComboAsDropDown && !(bool)rQryCondition[qs2.core.generic.columnRemoved] && !(bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox])
                        {
                            bool IsLastConditionInControl = false;
                            int iCounterParInControl = 0;
                            System.Collections.Generic.List<string> lstValues = qs2.core.generic.readStrVariables(rQryCondition.ValueMin.Trim().ToString().Trim());
                            if (lstValues.Count > 0)
                            {
                                int InsertAfterPosition = -1;
                                rQryCondition[qs2.core.generic.columnRemoved] = true;
                                rQryCondition[qs2.core.generic.columnNoCheckClamps] = true;

                                dsAdmin.tblQueriesDefRow rNewQryDefCondition = this.addNewParameter(ref tQryDefToSetValues, infoQryRunPar.Application.Trim(), "",
                                                                                    "", "", "", infoQryRunPar.rSelListQry.ID, core.Enums.eControlType.Integer);
                                //rNewQryDefCondition.Combination = qs2.core.sqlTxt.and;
                                rNewQryDefCondition.CombinationEnd = "";
                                rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                                rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                                rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = false;
                                rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                                rNewQryDefCondition.QryTable = infoQryRunPar.rSelListQry._Table.Trim();
                                rNewQryDefCondition.CriteriaFldShort = "";
                                rNewQryDefCondition.freeSql = "";
                                rNewQryDefCondition.Sort = rQryCondition.Sort ;
                                int ParsAdded = 0;

                                if (iCounterParInControl == 0)
                                {
                                    InsertAfterPosition = rQryCondition.Sort;
                                }
                                if (InsertAfterPosition <= 0)
                                {
                                    throw new Exception("doParameterForQuery.checkComboBoxAsDropDown: InsertAfterPosition <= 0 not allowed!");
                                }
                                this.doNewSort(tQryDefToSetValues, ref InsertAfterPosition, ref ParsAdded, rNewQryDefCondition);

                                string sqlToAdd = "";
                                foreach (string sValue in lstValues)
                                {
                                    if ((lstValues.Count - 1) == iCounterParInControl)
                                        IsLastConditionInControl = true;

                                    //int iValue = System.Convert.ToInt32(sValue.Trim());
                                    string CombinationTmp = "";
                                    if (rQryCondition.ComboAsDropDownCondition.Trim() == "")
                                    {
                                        CombinationTmp = qs2.core.sqlTxt.and.ToString().Trim();
                                    }
                                    else
                                    {
                                        CombinationTmp = rQryCondition.ComboAsDropDownCondition.Trim();
                                    }

                                    if (iCounterParInControl == 0)
                                    {
                                        sqlToAdd += rQryCondition.QryTable.Trim() + "." + rQryCondition.QryColumn.Trim() + rQryCondition.Condition + sValue.Trim() + " ";
                                    }
                                    else
                                    {
                                        sqlToAdd += " " + CombinationTmp.Trim() + " " + rQryCondition.QryTable.Trim() + "." + rQryCondition.QryColumn.Trim() + rQryCondition.Condition + sValue.Trim() + " ";
                                    }

                                    //this.addNewParameter(lstMultiControl, infoQryRunPar, rQryCondition, sValue,
                                    //                        ref iCounterParInControl, ref IsLastConditionInControl, rQryCondition.IDGuid, ref InsertAfterPosition,
                                    //                        ref tQryDefToSetValues, rQryCondition.ComboAsDropDownCondition.Trim());

                                    iCounterParInControl += 1;
                                    iCounterNewParTotalAdded += 1;
                                }

                                rNewQryDefCondition.freeSql = " (" + sqlToAdd + ") ";
                                rNewQryDefCondition.Combination = rQryCondition.Combination.Trim();
                                rNewQryDefCondition.CombinationEnd = rQryCondition.CombinationEnd.Trim();
                                //rNewQryDefCondition.freeSql = " " + rQryCondition.Combination.Trim() +  " (" + sqlToAdd + ") " + rQryCondition.CombinationEnd.Trim() + " ";
                            }
                            else
                            {
                                rQryCondition[qs2.core.generic.columnRemoved] = true;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkComboBoxAsDropDown: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void checkComboBoxAsDropDown_old(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                                qs2.ui.print.infoQry infoQryRunPar,
                                                ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter)
        {
            try
            {
                int iCounterNewParTotalAdded = 0;
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsUI = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                {
                    if (rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ComboBox.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ComboBoxNoDb.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ThreeStateCheckBox.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ThreeStateCheckBoxNoDb.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.CheckBox.ToString().Trim().ToLower()) ||
                        rQryCondition.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.CheckBoxNoDb.ToString().Trim().ToLower()))
                    {
                        if (rQryCondition.ComboAsDropDown && (bool)rQryCondition[qs2.core.generic.columnRemoved] && (bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox])
                        {
                            if (rQryCondition.CombinationEnd.Trim() != "")
                            {
                                dsAdmin.tblQueriesDefRow rQryConditionBeforeNotRemoved = this.getLastBeforeNotRemoved(tQryDefToSetValues, rQryCondition.Sort);
                                //rQryConditionBeforeNotRemoved.CombinationEnd += " " + rQryCondition.CombinationEnd;
                            }
                        }
                        else if (rQryCondition.ComboAsDropDown && !(bool)rQryCondition[qs2.core.generic.columnRemoved] && !(bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox])
                        {
                            bool IsLastConditionInControl = false;
                            int iCounterParInControl = 0;
                            System.Collections.Generic.List<string> lstValues = qs2.core.generic.readStrVariables(rQryCondition.ValueMin.Trim().ToString().Trim());
                            if (lstValues.Count > 0)
                            {
                                int InsertAfterPosition = -1;
                                foreach (string sValue in lstValues)
                                {
                                    if ((lstValues.Count - 1) == iCounterParInControl)
                                        IsLastConditionInControl = true;

                                    //int iValue = System.Convert.ToInt32(sValue.Trim());
                                    
                                    rQryCondition[qs2.core.generic.columnRemoved] = true;
                                    rQryCondition[qs2.core.generic.columnNoCheckClamps] = true;
                                    if (iCounterParInControl == 0)
                                    {
                                        InsertAfterPosition = rQryCondition.Sort;
                                    }
                                    if (InsertAfterPosition <= 0)
                                    {
                                        throw new Exception("doParameterForQuery.checkComboBoxAsDropDown: InsertAfterPosition <= 0 not allowed!");
                                    }
                                    this.addNewParameter(lstMultiControl, infoQryRunPar, rQryCondition, sValue,
                                                            ref iCounterParInControl, ref IsLastConditionInControl, rQryCondition.IDGuid, ref InsertAfterPosition,
                                                            ref tQryDefToSetValues, rQryCondition.ComboAsDropDownCondition.Trim());
                                    iCounterParInControl += 1;
                                    iCounterNewParTotalAdded += 1;
                                }
                            }
                            else
                            {
                                rQryCondition[qs2.core.generic.columnRemoved] = true;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkComboBoxAsDropDown: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void addClaimbsxy(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                           qs2.ui.print.infoQry infoQryRunPar,
                                           ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, ref bool IsFctCRParameter)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryConditionsUI = (dsAdmin.tblQueriesDefRow[])tQryDefToSetValues.Select("", tQryDefToSetValues.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                bool addClaimbs = true;
                foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                {
                    if ((bool)rQryCondition[qs2.core.generic.columnRemoved] == false && (bool)rQryCondition[qs2.core.generic.columnAutoAddedCol] == false &&
                        (bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox] == false)
                    {
                        if (rQryCondition.Combination.Contains("("))
                        {
                            addClaimbs = true;
                        }
                    }
                }

                if (addClaimbs)
                {
                    int iCounter = 0;
                    dsAdmin.tblQueriesDefRow rQryConditionFirst = null;
                    dsAdmin.tblQueriesDefRow rQryConditionLast = null;
                    foreach (dsAdmin.tblQueriesDefRow rQryCondition in arrQryConditionsUI)
                    {
                        if ((bool)rQryCondition[qs2.core.generic.columnRemoved] == false && (bool)rQryCondition[qs2.core.generic.columnAutoAddedCol] == false &&
                            (bool)rQryCondition[qs2.core.generic.columnIsObjectComboBox] == false)
                        {
                            if (rQryConditionFirst == null)
                            {
                                rQryConditionFirst = rQryCondition;
                            }
                            rQryConditionLast = rQryCondition;
                            iCounter += 1;
                        }
                    }
                    if (iCounter > 1)
                    {
                        rQryConditionFirst.Combination += "( ";
                        rQryConditionLast.CombinationEnd += " ) ";
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addClaimbs: " + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public dsAdmin.tblQueriesDefRow addNewParameter(ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues, string Application, string Combination,
                                                        string FldShortColumn, string Table, string ValueMin, int IDSelList, core.Enums.eControlType ControlType)
        {
            try
            {
                sqlAdmin sqlAdminTmp = new sqlAdmin();
                sqlAdminTmp.initControl();

                dsAdmin.tblQueriesDefRow rNewQryDefCondition = sqlAdminTmp.addRowQueriesDef(tQryDefToSetValues);
                doParameterForQuery.setRowToDefault(rNewQryDefCondition);

                rNewQryDefCondition.ApplicationOwn = Application.Trim();
                rNewQryDefCondition.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                rNewQryDefCondition.Sort = this.getNextSort(tQryDefToSetValues);
                rNewQryDefCondition.Typ = core.Enums.eTypQueryDef.WhereConditions.ToString();
                rNewQryDefCondition.Combination = Combination;
                rNewQryDefCondition.Condition = qs2.core.sqlTxt.equals;
                rNewQryDefCondition.QryColumn = FldShortColumn.Trim();
                rNewQryDefCondition.QryTable = Table.Trim();
                rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                rNewQryDefCondition.IsSQLServerField = true;
                rNewQryDefCondition.IDSelList = IDSelList;
                rNewQryDefCondition.FunctionPar = false;
                rNewQryDefCondition.UserInput = false;
                rNewQryDefCondition.ValueMin = ValueMin.ToString();
                rNewQryDefCondition.ControlType = ControlType.ToString();
                rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = false;

                return rNewQryDefCondition;

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addNewParameter:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void addNewParameter(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                        qs2.ui.print.infoQry infoQryRunPar,
                                        dsAdmin.tblQueriesDefRow rQryConditionOrig, string valueToSet,
                                        ref int iCounterParInControl, ref bool IsLastConditionInControl, Guid IDGuidSortAfterMain,
                                        ref int InsertAfterPosition, ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues,
                                        string ComboBoxAdDropDownCombination)
        {
            try
            {
                sqlAdmin sqlAdminTmp = new sqlAdmin();
                sqlAdminTmp.initControl();

                dsAdmin.tblQueriesDefRow rNewQryDefCondition = (dsAdmin.tblQueriesDefRow)tQryDefToSetValues.NewRow();
                doParameterForQuery.setRowToDefault(rNewQryDefCondition);

                rNewQryDefCondition.ItemArray = rQryConditionOrig.ItemArray;
                rNewQryDefCondition.IDGuid = System.Guid.NewGuid();
                rNewQryDefCondition.Sort = -999;
                rNewQryDefCondition[qs2.core.generic.columnIDGuidMainForNewSort] = IDGuidSortAfterMain;
                rNewQryDefCondition[qs2.core.generic.columnNewSort] = rNewQryDefCondition.Sort;
                rNewQryDefCondition.ValueMin = valueToSet;
                rNewQryDefCondition[qs2.core.generic.columnAutoAddedCol] = false;
                rNewQryDefCondition[qs2.core.generic.columnIsObjectComboBox] = false;

                string CombinationTmp = "";
                if (ComboBoxAdDropDownCombination.Trim() == "")
                {
                    CombinationTmp = qs2.core.sqlTxt.and.ToString().Trim();
                }
                else
                {
                    CombinationTmp = ComboBoxAdDropDownCombination.Trim();
                }
                if (iCounterParInControl == 0 && !IsLastConditionInControl)
                {
                    rNewQryDefCondition.Combination = rQryConditionOrig.Combination + " ( ";
                    rNewQryDefCondition.CombinationEnd = "";
                }
                else if (iCounterParInControl != 0 && !IsLastConditionInControl)
                {
                    rNewQryDefCondition.Combination = " " + CombinationTmp.Trim() + " ";
                    rNewQryDefCondition.CombinationEnd = "";
                }
                else if (iCounterParInControl != 0 && IsLastConditionInControl)
                {
                    rNewQryDefCondition.Combination = " " + CombinationTmp.Trim() + " ";
                    rNewQryDefCondition.CombinationEnd = rQryConditionOrig.CombinationEnd + " ) ";
                }

                rNewQryDefCondition[qs2.core.generic.columnNoCheckClamps] = false;
                rNewQryDefCondition[qs2.core.generic.columnRemoved] = false;
                tQryDefToSetValues.Rows.Add(rNewQryDefCondition);

                int ParsAdded = 0;
                this.doNewSort(tQryDefToSetValues, ref InsertAfterPosition, ref ParsAdded, rNewQryDefCondition);

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addNewParameter:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void doNewSort(dsAdmin.tblQueriesDefDataTable tConditionsForQuery, ref int InsertAfterPosition, ref int ParsAdded,
                                   dsAdmin.tblQueriesDefRow rQryConditionToInsert)
        {
            try
            {
                string sWhereNewSort = tConditionsForQuery.SortColumn.ColumnName + ">0";
                dsAdmin.tblQueriesDefRow[] arrQueriesContitionsAll = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereNewSort, tConditionsForQuery.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryContitionAll in arrQueriesContitionsAll)
                {
                    if (rQryContitionAll.Sort <= 0)
                    {
                        throw new Exception("doParameterForQuery.doNewSort: rQryContitionAll.Sort <= 0 not allowed!");
                    }
                    int resortAfterPosition = -1;
                    if (rQryContitionAll.Sort == InsertAfterPosition)
                    {
                        resortAfterPosition = rQryContitionAll.Sort;
                        rQryConditionToInsert.Sort = rQryContitionAll.Sort + 1;
                        InsertAfterPosition = rQryConditionToInsert.Sort;
                        ParsAdded += 1;
                        this.resortConditions(tConditionsForQuery, ref resortAfterPosition, ref ParsAdded, rQryConditionToInsert);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.doNewSort:" + ex.ToString());
            }
        }
        public dsAdmin.tblQueriesDefRow getLastBeforeNotRemoved(dsAdmin.tblQueriesDefDataTable tConditionsForQuery, int SortSearchBefore)
        {
            try
            {
                //dsAdmin.tblQueriesDefRow rQueriesDefBefore = null;
                string sWhereNewSort = tConditionsForQuery.SortColumn.ColumnName + "<" + SortSearchBefore.ToString() + "";
                dsAdmin.tblQueriesDefRow[] arrQueriesContitionsAll = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereNewSort, tConditionsForQuery.SortColumn.ColumnName + " desc");
                foreach (dsAdmin.tblQueriesDefRow rQryContitionAll in arrQueriesContitionsAll)
                {
                    if (!(bool)rQryContitionAll[qs2.core.generic.columnRemoved])
                    {
                        return rQryContitionAll;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.getLastBeforeNotRemoved:" + ex.ToString());
            }
        }
        public void resortConditions(dsAdmin.tblQueriesDefDataTable tConditionsForQuery, ref int InsertAfterPosition, ref int ParsAdded,
                                        dsAdmin.tblQueriesDefRow rQryConditionNotDo)
        {
            try
            {
                string sWhereNewSort = tConditionsForQuery.SortColumn.ColumnName + ">0";
                dsAdmin.tblQueriesDefRow[] arrQueriesContitionsResort = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereNewSort, tConditionsForQuery.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryContitionResort in arrQueriesContitionsResort)
                {
                    if (rQryContitionResort.Sort > InsertAfterPosition && rQryContitionResort.IDGuid != rQryConditionNotDo.IDGuid)
                    {
                        rQryContitionResort.Sort = rQryContitionResort.Sort + 2;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.resortConditions:" + ex.ToString());
            }
        }
        public bool checkSorts(dsAdmin.tblQueriesDefDataTable tConditionsForQuery, string sExceptInfo)
        {
            try
            {
                //System.Collections.Generic.List<int> lstPositionsChecked = new List<int>();
                string sWhereNewSort = "";
                dsAdmin.tblQueriesDefRow rQryContitionAllPrev = null;
                dsAdmin.tblQueriesDefRow[] arrQueriesContitionsAll = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereNewSort, tConditionsForQuery.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryContitionFound in arrQueriesContitionsAll)
                {
                    if (rQryContitionFound.Sort < 0)
                    {
                        throw new Exception("checkSorts: rQryContitionAll.Sort < 0 (" + sExceptInfo.Trim() + ") not allowed!");
                    }
                    if (rQryContitionAllPrev != null)
                    {
                        if (rQryContitionFound.Sort <= rQryContitionAllPrev.Sort)
                        {
                            throw new Exception("checkSorts: arrQueriesContitionsAll.Sort <= 0 rQryContitionAllPrev.Sort (" + sExceptInfo.Trim() + ") not allowed!");
                        }
                        //if (rQryContitionFound.Sort != (rQryContitionAllPrev.Sort + 1))
                        //{
                        //    throw new Exception("checkSorts: rQryContitionFound.Sort != (rQryContitionAllPrev.Sort + 1) (" + sExceptInfo.Trim() + ") not allowed!");
                        //}   

                    }

                    rQryContitionAllPrev = rQryContitionFound;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.checkSorts:" + ex.ToString());
            }
        }
        public void buildInfoSql(dsAdmin.tblQueriesDefDataTable tConditionsForQuery, ref bool IsFctCRParameter, ref qs2.ui.print.infoQry infoQryRunPar,
                                    ref System.Collections.Generic.List<dsAdmin.tblQueriesDefRow> lstDefConditionAdded)
        {
            try
            {
                qs2.sitemap.print.genSql genSql1 = new sitemap.print.genSql();
                qs2.core.vb.businessFramework b = new businessFramework();
                dsAdmin.tblSelListEntriesRow[] arrSelListObjFieldInDB = null;
                if (!infoQryRunPar.Application.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    b.getAllObjectFieldsInProductStay(ref arrSelListObjFieldInDB, false, infoQryRunPar.Application);
                }

                int iCounter = 0;
                //string sEnter = "\r\n";
                string sWhereNewSort = "";
                dsAdmin.tblQueriesDefRow[] arrQueriesContitionsAll = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereNewSort, tConditionsForQuery.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryContitionFound in arrQueriesContitionsAll)
                {
                    if (!(bool)rQryContitionFound[qs2.core.generic.columnRemoved])
                    {
                        string SqlWhereTmp = "Info Input:";

                        string ColumnTranslated = qs2.core.language.sqlLanguage.getRes(rQryContitionFound.QryColumn.Trim());
                        if (ColumnTranslated.Trim() == "")
                        {
                            ColumnTranslated = rQryContitionFound.QryColumn.Trim();
                        }

                        string AndTranslated = this.translateTxt("and");
                        string WhereTranslated = this.translateTxt("where");

                        if ((rQryContitionFound.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.between.Trim().ToString().Trim().ToLower()) ||
                            rQryContitionFound.Condition.Trim().ToLower().Equals(qs2.core.sqlTxt.notBetween.Trim().ToString().Trim().ToLower())) && !IsFctCRParameter)
                        {
                            string ValueMinTmp = this.translateParameterForinfoSql(rQryContitionFound.ValueMin.Trim(), rQryContitionFound.QryColumn.Trim(), infoQryRunPar.Application.Trim(), ref arrSelListObjFieldInDB);
                            string MaxTmp = this.translateParameterForinfoSql(rQryContitionFound.Max.Trim(), rQryContitionFound.QryColumn.Trim(), infoQryRunPar.Application.Trim(), ref arrSelListObjFieldInDB);
                            string ConditionTmp = this.translateTxt(rQryContitionFound.Condition.Trim());
                            string CombinationTmp = this.translateTxt(rQryContitionFound.Combination.Trim());
                            string CombinationEndTmp = this.translateTxt(rQryContitionFound.CombinationEnd.Trim());
                            if (iCounter == 0 && infoQryRunPar.SqlWhereInfo.Trim() == "")
                            {
                                string sBracket = "";
                                if (CombinationTmp.Trim().Contains("("))
                                {
                                    sBracket = " " + " (";
                                }
                                CombinationTmp = WhereTranslated.Trim() + sBracket;
                            }
                            string EuroscoreTranslated = "";
                            if (b.checkFieldsForTranslateSelList(ValueMinTmp.Trim(), rQryContitionFound.QryColumn.Trim(), infoQryRunPar.Application.Trim(), ref EuroscoreTranslated))
                            {
                                ValueMinTmp = EuroscoreTranslated.Trim();
                            }
                            if (rQryContitionFound.QryColumn.Trim() != "")
                            {
                                SqlWhereTmp = CombinationTmp.Trim() + " " + ColumnTranslated + " " + ConditionTmp.Trim() + " " + ValueMinTmp.Trim() + " " + AndTranslated.Trim() + " " + MaxTmp.Trim() + " " + CombinationEndTmp.Trim() + "";
                            }
                            if (rQryContitionFound.freeSql.Trim() != "")
                            {
                                SqlWhereTmp = CombinationTmp.Trim() + " " + rQryContitionFound.freeSql.Trim();
                            }
                        }
                        else
                        {
                            string ValueMinTmp = this.translateParameterForinfoSql(rQryContitionFound.ValueMin.Trim(), rQryContitionFound.QryColumn.Trim(), infoQryRunPar.Application.Trim(), ref arrSelListObjFieldInDB);
                            string ConditionTmp = this.translateTxt(rQryContitionFound.Condition.Trim());
                            string CombinationTmp = this.translateTxt(rQryContitionFound.Combination.Trim());
                            string CombinationEndTmp = this.translateTxt(rQryContitionFound.CombinationEnd.Trim());
                            if (iCounter == 0 && infoQryRunPar.SqlWhereInfo.Trim() == "")
                            {
                                string sBracket = "";
                                if (CombinationTmp.Trim().Contains("("))
                                {
                                    sBracket = " " + " (";
                                }
                                CombinationTmp = WhereTranslated.Trim() + sBracket;
                            }
                            string EuroscoreTranslated = "";
                            if (b.checkFieldsForTranslateSelList(ValueMinTmp.Trim(), rQryContitionFound.QryColumn.Trim(), infoQryRunPar.Application.Trim(), ref EuroscoreTranslated))
                            {
                                ValueMinTmp = EuroscoreTranslated.Trim();
                            }
                            if (rQryContitionFound.QryColumn.Trim() != "")
                            {
                                SqlWhereTmp = CombinationTmp.Trim() + " " + ColumnTranslated + " " + ConditionTmp.Trim() + " " + ValueMinTmp.Trim() + " " + CombinationEndTmp.Trim() + "";
                            }
                            if (rQryContitionFound.freeSql.Trim() != "")
                            {
                                SqlWhereTmp = CombinationTmp.Trim() + " " + rQryContitionFound.freeSql.Trim();
                            }
                        }
                        infoQryRunPar.SqlWhereInfo += SqlWhereTmp.Trim() + " "; // + sEnter;
                        iCounter += 1;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.buildInfoSql:" + ex.ToString());
            }
        }

        public string translateParameterForinfoSql(string ValueToParse, string FldShort, string Application,
                                                    ref dsAdmin.tblSelListEntriesRow[] arrSelListObjFieldInDB)
        {
            try
            {
                if (Application.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    return ValueToParse.Trim();
                }

                string ValueReturn = ValueToParse.Trim();
                if (ValueReturn.Trim() != "")
                {
                    qs2.core.vb.sqlObjects sqlObjectsWork = new sqlObjects();
                    sqlObjectsWork.initControl();
                    qs2.core.vb.dsObjects dsObjectsWork = new dsObjects();

                    int IDObject = -999;
                    bool isInt = int.TryParse(ValueToParse.Trim(), out IDObject);
                    if (isInt)
                    {
                        foreach (dsAdmin.tblSelListEntriesRow rSelListObjFieldInDB in arrSelListObjFieldInDB)
                        {
                            if (FldShort.Trim().ToLower().Equals(rSelListObjFieldInDB.FldShortColumn.Trim().ToLower()))
                            {
                                dsObjects.tblObjectRow rObj = sqlObjectsWork.getObjectRow(IDObject, sqlObjects.eTypSelObj.ID);
                                if (rObj != null)
                                {
                                    ValueReturn = rObj.NameCombination.Trim();
                                    return ValueReturn;
                                }
                            }
                        }
                    }

                    //if (DateTime.TryParse(ValueToParse.Trim(), out datTmp))
                    DateTime datTmp;
                    string format = "MM/dd/yyyy HH:mm:ss";
                    if (DateTime.TryParseExact(ValueToParse.Trim(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out datTmp))
                    {
                        ValueReturn = datTmp.ToString("d");
                        return ValueReturn;
                    }

                }

                return ValueReturn.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("translateParameterForinfoSql:" + ex.ToString());
            }
        }
        public string translateTxt(string TxtToTranslate)
        {
            try
            {
                if (TxtToTranslate.Trim() != "")
                {
                    string TxtTranslated = qs2.core.language.sqlLanguage.getRes(TxtToTranslate.Trim());
                    if (TxtTranslated.Trim() == "")
                    {
                        return TxtToTranslate.Trim();
                    }
                    else
                    {
                        return TxtTranslated.Trim();
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("translateTxt:" + ex.ToString());
            }
        }
        public int getNextSort(dsAdmin.tblQueriesDefDataTable tQryDef)
        {
            try
            {
                int lastSort = 0;
                foreach (dsAdmin.tblQueriesDefRow rQry in tQryDef)
                {
                    if (rQry.Sort > lastSort)
                    {
                        lastSort = rQry.Sort;
                    }
                }

                return (lastSort + 1);
            }
            catch (Exception ex)
            {
                throw new Exception("getNextSort:" + ex.ToString());
            }
        }

        public dsAdmin.tblQueriesDefRow getNextPar(dsAdmin.tblQueriesDefDataTable tQryDef, int SortToSearch)
        {
            try
            {
                dsAdmin.tblQueriesDefRow[] arrQryDef = (dsAdmin.tblQueriesDefRow[])tQryDef.Select("", "Sort asc");
                foreach (dsAdmin.tblQueriesDefRow rQry in arrQryDef)
                {
                    if (rQry.Sort > SortToSearch && !(bool)rQry[qs2.core.generic.columnRemoved])
                    {
                        return rQry;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("getNextPar:" + ex.ToString());
            }
        }
        public dsAdmin.tblQueriesDefRow getPrevPar(dsAdmin.tblQueriesDefDataTable tQryDef, int SortToSearch)
        {
            try
            {
                dsAdmin.tblQueriesDefRow[] arrQryDef = (dsAdmin.tblQueriesDefRow[])tQryDef.Select("", "Sort desc");
                foreach (dsAdmin.tblQueriesDefRow rQry in arrQryDef)
                {
                    if (rQry.Sort < SortToSearch && !(bool)rQry[qs2.core.generic.columnRemoved])
                    {
                        return rQry;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("getPrevPar:" + ex.ToString());
            }
        }

        public void doNewSortxyxy(dsAdmin.tblQueriesDefDataTable tConditionsForQuery)
        {
            try
            {
                int iCountNewFieldsAddedTotal = 0;
                string sWhereNewSort = tConditionsForQuery.SortColumn.ColumnName + ">100000";
                dsAdmin.tblQueriesDefRow[] arrQueriesContitionsNewSort = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereNewSort, tConditionsForQuery.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (dsAdmin.tblQueriesDefRow rQryContitionNewSort in arrQueriesContitionsNewSort)
                {
                    iCountNewFieldsAddedTotal += 1;
                    string sWhereAll = tConditionsForQuery.SortColumn.ColumnName + "<100000";
                    int lastSortFoundBevorNewPar = -1;
                    dsAdmin.tblQueriesDefRow[] arrQueriesContitionsAll = (dsAdmin.tblQueriesDefRow[])tConditionsForQuery.Select(sWhereAll, tConditionsForQuery.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                    foreach (dsAdmin.tblQueriesDefRow rQryContitionAll in arrQueriesContitionsAll)
                    {
                        if (rQryContitionAll.IDGuid.Equals((Guid)rQryContitionNewSort[qs2.core.generic.columnIDGuidMainForNewSort]))
                        {
                            rQryContitionNewSort.Sort += lastSortFoundBevorNewPar + 1;
                        }
                        lastSortFoundBevorNewPar = rQryContitionAll.Sort;
                        rQryContitionAll.Sort += iCountNewFieldsAddedTotal + 1;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.doNewSort:" + ex.ToString());
            }
        }
        public dsAdmin.tblQueriesDefRow getConditionFromParxyxy(dsAdmin.tblQueriesDefDataTable tQryDef, System.Guid IDKey, ref dsAdmin.tblQueriesDefDataTable tQryDefToSetValues)
        {
            try
            {
                dsAdmin.tblQueriesDefRow[] arrQueriesCondition = (dsAdmin.tblQueriesDefRow[])tQryDef.Select(tQryDef.IDGuidColumn.ColumnName + "='" + IDKey.ToString() + "'", tQryDef.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueriesCondition.Length != 1)
                {
                    throw new Exception("doParameterForQuery.getConditionFromPar: arrQueriesCondition.Length != 1");
                }
                return arrQueriesCondition[0];
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.getConditionFromPar:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }

        }
        public dsAdmin.tblQueriesDefRow getConditionFromCopyUIxyxy(dsAdmin.tblQueriesDefDataTable tQryDef, System.Guid IDGuidOrigDataSetUI)
        {
            try
            {
                dsAdmin.tblQueriesDefRow[] arrQueriesCondition = (dsAdmin.tblQueriesDefRow[])tQryDef.Select(tQryDef.IDGuidColumn.ColumnName + "='" + IDGuidOrigDataSetUI.ToString() + "'", tQryDef.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueriesCondition.Length != 1)
                {
                    throw new Exception("doParameterForQuery.getConditionFromCopyUI: arrQueriesCondition.Length != 1");
                }
                return arrQueriesCondition[0];
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.getConditionFromPar:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }

        }



        public static void addColumnsToTableQueryDefxyxy(ref qs2.core.vb.dsAdmin.tblQueriesDefDataTable tQueryDef)
        {
            try
            {
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnOrderBy))
                    tQueryDef.Columns.Add(qs2.core.generic.columnOrderBy, typeof(int));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnParameterLabelTranslated))
                    tQueryDef.Columns.Add(qs2.core.generic.columnParameterLabelTranslated, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnParameterForReport))
                    tQueryDef.Columns.Add(qs2.core.generic.columnParameterForReport, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnParameterCombinationTranslated))
                    tQueryDef.Columns.Add(qs2.core.generic.columnParameterCombinationTranslated, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnParameterCombinationEndTranslated))
                    tQueryDef.Columns.Add(qs2.core.generic.columnParameterCombinationEndTranslated, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnValueTranslated))
                    tQueryDef.Columns.Add(qs2.core.generic.columnValueTranslated, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnStatus))
                    tQueryDef.Columns.Add(qs2.core.generic.columnStatus, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnParameterSqlWhereUI))
                    tQueryDef.Columns.Add(qs2.core.generic.columnParameterSqlWhereUI, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameVal))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameVal, typeof(object));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameValTxt))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameValTxt, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameVal + "_2"))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameVal + "_2", typeof(object));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameValTxt + "_2"))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameValTxt + "_2", typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameType))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameType, typeof(string));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameIDGroup))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameIDGroup, typeof(System.Guid));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNameIDKey))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNameIDKey, typeof(System.Guid));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnMultiControl))
                    tQueryDef.Columns.Add(qs2.core.generic.columnMultiControl, typeof(object));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnRemoved))
                    tQueryDef.Columns.Add(qs2.core.generic.columnRemoved, typeof(bool));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNewSort))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNewSort, typeof(int));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNewSort))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNewSort, typeof(int));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnIDGuidMainForNewSort))
                    tQueryDef.Columns.Add(qs2.core.generic.columnIDGuidMainForNewSort, typeof(Guid));

                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in tQueryDef)
                {
                    rQry[qs2.core.generic.columnRemoved] = false;
                    rQry[qs2.core.generic.columnNewSort] = -1;
                    rQry[qs2.core.generic.columnIDGuidMainForNewSort] = System.Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addColumnsToTableQueryDef:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public static void addColumnsToTableConditions(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tQueryDef)
        {
            try
            {
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnRemoved))
                    tQueryDef.Columns.Add(qs2.core.generic.columnRemoved, typeof(bool));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNewSort))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNewSort, typeof(int));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnIDGuidMainForNewSort))
                    tQueryDef.Columns.Add(qs2.core.generic.columnIDGuidMainForNewSort, typeof(Guid));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnMultiControl))
                    tQueryDef.Columns.Add(qs2.core.generic.columnMultiControl, typeof(object));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnCheckOn))
                    tQueryDef.Columns.Add(qs2.core.generic.columnCheckOn, typeof(bool));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnIsObjectComboBox))
                    tQueryDef.Columns.Add(qs2.core.generic.columnIsObjectComboBox, typeof(bool));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnAutoAddedCol))
                    tQueryDef.Columns.Add(qs2.core.generic.columnAutoAddedCol, typeof(bool));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnClampEbene))
                    tQueryDef.Columns.Add(qs2.core.generic.columnClampEbene, typeof(int));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnClampKey))
                    tQueryDef.Columns.Add(qs2.core.generic.columnClampKey, typeof(int));
                if (!tQueryDef.Columns.Contains(qs2.core.generic.columnNoCheckClamps))
                    tQueryDef.Columns.Add(qs2.core.generic.columnNoCheckClamps, typeof(bool));

                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in tQueryDef)
                {
                    doParameterForQuery.setRowToDefault(rQry);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.addColumnsToTableQueryDef2:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public static void setRowToDefault(qs2.core.vb.dsAdmin.tblQueriesDefRow rQry)
        {
            try
            {
                rQry[qs2.core.generic.columnRemoved] = false;
                rQry[qs2.core.generic.columnNewSort] = -1;
                rQry[qs2.core.generic.columnIDGuidMainForNewSort] = System.Guid.Empty;
                rQry[qs2.core.generic.columnMultiControl] = null;
                rQry[qs2.core.generic.columnCheckOn] = false;
                rQry[qs2.core.generic.columnIsObjectComboBox] = false;
                rQry[qs2.core.generic.columnAutoAddedCol] = false;
                rQry[qs2.core.generic.columnClampEbene] = -1;
                rQry[qs2.core.generic.columnClampKey] = -1;
                rQry[qs2.core.generic.columnNoCheckClamps] = false;

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.setRowToDefault:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void deleteFieldsForExternQuery(System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                                qs2.ui.print.infoQry infoQryRunPar)
        {
            try
            {
                System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblQueriesDefRow> lstFieldsQueryDelete = new List<dsAdmin.tblQueriesDefRow>();

                dsAdmin dsAmin1 = new dsAdmin();
                qs2.core.vb.sqlAdmin.getSelList(null, null, "ColumnsNotAllowedInExternQueries", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnInt, dsAmin1, sqlAdmin.eTypAuswahlList.groupParticipantOwnOrAll);
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rFieldsNotAllowed in dsAmin1.tblSelListEntries)
                {
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rFieldsQuery in infoQryRunPar.dsFieldsForQuery.tblQueriesDef)
                    {
                        if (rFieldsQuery.QryColumn.Trim().ToLower().Equals(rFieldsNotAllowed.FldShortColumn.Trim().ToLower()))
                        {
                            lstFieldsQueryDelete.Add(rFieldsQuery);
                        }
                    }
                }

                if (lstFieldsQueryDelete.Count > 0)
                {
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rFieldsQueryToDelete in lstFieldsQueryDelete)
                    {
                        rFieldsQueryToDelete.Delete();
                    }
                    infoQryRunPar.dsFieldsForQuery.tblQueriesDef.AcceptChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("doParameterForQuery.deleteFieldsForExternQuery:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


    }
}
