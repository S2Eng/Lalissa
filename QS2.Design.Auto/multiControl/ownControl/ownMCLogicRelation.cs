using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinTabControl;




namespace qs2.design.auto.multiControl
{



    public class ownMCLogicRelation
    {

        public System.Collections.Generic.List<ClambsRek> lstLogicRelation = null;

        //public qs2.core.vb.dsAdmin dsAdmin1;
        public qs2.core.vb.sqlAdmin sqlAdmin1 = null;
        public bool _isInitialized = false;
        public bool _isInitializedDB = false;

        public qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = null;

        public class cValueInClamp
        {
            public bool bValue = false;
            public string NextCombination = "";
        }







        public void initControl()
        {
            try
            {
                if (this._isInitializedDB)
                    return;

                //this.dsAdmin1 = new qs2.core.vb.dsAdmin();
                //this.dsAdmin1.tblRelationship.Columns.Add(qs2.core.generic.columnNameObject, typeof(object));

                this.lstLogicRelation = new System.Collections.Generic.List<ClambsRek>();

                this.sqlAdmin1 = new qs2.core.vb.sqlAdmin();
                this.sqlAdmin1.initControl();

                this._isInitializedDB = true;
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.initControl", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void buildLogicRelation(ref qs2.design.auto.multiControl.ownMultiControl ownMultiControlPicture,
                                                qs2.core.vb.dsAdmin.tblRelationshipRow[] arrRelationships,
                                                string IDApplication, qs2.core.Enums.eConditionTyp ConditionTyp)
        {
            try
            {
                if (this._isInitialized)
                {
                    return;
                }

                this.ownMultiControl1 = ownMultiControlPicture;
                this.initControl();
                this.lstLogicRelation.Clear();

                int nrCondition = 0;
                if (arrRelationships != null)
                {
                    foreach (qs2.core.vb.dsAdmin.tblRelationshipRow rRelation in arrRelationships)
                    {
                        if (rRelation.TypeSub.Trim() == ConditionTyp.ToString())
                        {
                            if (rRelation.Conditions.Trim() != "")
                            {
                                bool IsFirstClaimb = true;
                                int Sort = 0;
                                int actPos = 0;
                                string StrFoundPrev = "";
                                int containsClipOnTotal = 0;
                                int containsClipCloseTotal = 0;

                                ClambsRek newClamb = new ClambsRek();
                                newClamb.Condition = rRelation.Conditions.Trim();
                                newClamb.firstNode = true;
                                newClamb.IDRes = rRelation.IDKey;
                                this.lstLogicRelation.Add(newClamb);

                                while (actPos <= rRelation.Conditions.Length)
                                {
                                    string sCombination = "";
                                    string sClaimb = "";
                                    int sIndexOfAnd = rRelation.Conditions.Trim().IndexOf(qs2.core.sqlTxt.and.Trim(), actPos);
                                    int sIndexOfOr = rRelation.Conditions.Trim().IndexOf(qs2.core.sqlTxt.or.Trim(), actPos);
                                    if (sIndexOfAnd != -1 && sIndexOfOr == -1)
                                    {
                                        sCombination = qs2.core.sqlTxt.and.Trim();
                                        sClaimb = rRelation.Conditions.Trim().Substring(actPos, sIndexOfAnd - actPos);
                                        actPos += sClaimb.Length + 4;
                                    }
                                    else if (sIndexOfAnd == -1 && sIndexOfOr != -1)
                                    {
                                        sCombination = qs2.core.sqlTxt.or.Trim();
                                        sClaimb = rRelation.Conditions.Trim().Substring(actPos, sIndexOfOr - actPos);
                                        actPos += sClaimb.Length + 3;
                                    }
                                    else if (sIndexOfAnd != -1 && sIndexOfOr != -1)
                                    {
                                        if (sIndexOfAnd < sIndexOfOr)
                                        {
                                            sCombination = qs2.core.sqlTxt.and.Trim();
                                            sClaimb = rRelation.Conditions.Trim().Substring(actPos, sIndexOfAnd - actPos);
                                            actPos += sClaimb.Length + 4;
                                        }
                                        else if (sIndexOfOr < sIndexOfAnd)
                                        {
                                            sCombination = qs2.core.sqlTxt.or.Trim();
                                            sClaimb = rRelation.Conditions.Trim().Substring(actPos, sIndexOfOr - actPos);
                                            actPos += sClaimb.Length + 3;
                                        }
                                    }
                                    if (sIndexOfAnd == -1 && sIndexOfOr == -1)
                                    {
                                        sCombination = "";
                                        sClaimb = rRelation.Conditions.Substring(actPos, rRelation.Conditions.Length - actPos);
                                        actPos += sClaimb.Length + 1000;
                                    }

                                    int containsClipOn = 0;
                                    int containsClipClose = 0;
                                    if (sClaimb.Trim() != "")
                                    {
                                        this.checkClip(ref sClaimb, ref containsClipOn, ref containsClipClose);
                                        containsClipOnTotal += containsClipOn;
                                        containsClipCloseTotal += containsClipClose;
                                    }
                                    if (sClaimb.Trim() != "")
                                    {
                                        string VariableFound = "";
                                        string ValueFound = "";
                                        string StrFoundCondition = "=";
                                        string sClaimbTmp = sClaimb.Trim();
                                        int sIndexOfClampOn = -1;
                                        int sIndexOfClampClose = -1;
                                        if (containsClipOn > 0)
                                        {
                                            sIndexOfClampOn = sClaimbTmp.Trim().IndexOf(qs2.core.sqlTxt.ClampRight.Trim(), 0);
                                            if (sIndexOfClampOn == 0)
                                            {
                                                for (int i = 0; i < containsClipOn; i++)
                                                {
                                                    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQryPicClamp = this.sqlAdmin1.addRowQueriesDef(newClamb.dsValuesInClamb.tblQueriesDef);
                                                    rNewQryPicClamp.Combination = qs2.core.sqlTxt.ClampRight.Trim();
                                                    rNewQryPicClamp.Sort = Sort;
                                                    rNewQryPicClamp.IDSelList = nrCondition;
                                                    Sort += 1;
                                                }
                                            }
                                            sClaimbTmp = sClaimbTmp.Replace(qs2.core.sqlTxt.ClampRight.Trim(), "");
                                        }
                                        if (containsClipClose > 0)
                                        {
                                            sIndexOfClampClose = sClaimbTmp.Trim().IndexOf(qs2.core.sqlTxt.ClampLeft.Trim(), 0);
                                            if (sIndexOfClampClose == 0)
                                            {
                                                throw new Exception("ownMCLogicRelation.buildLogicRelation: Error in formula - position of sIndexOfClampClose == 0!");
                                                //qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQryPicClamp = this.sqlAdmin1.addRowQueriesDef(newClamb.dsValuesInClamb.tblQueriesDef);
                                                //rNewQryPicClamp.Combination = qs2.core.sqlTxt.ClampLeft.Trim();
                                                //rNewQryPicClamp.Sort = Sort;
                                                //rNewQryPicClamp.IDSelList = nrCondition;
                                                //Sort += 1;
                                            }
                                            sClaimbTmp = sClaimbTmp.Replace(qs2.core.sqlTxt.ClampLeft.Trim(), "");
                                        }
                                        qs2.core.generic.readVariableAndValue(sClaimbTmp.Trim(), ref VariableFound, ref ValueFound);
                                        //int actPosMCPrefix = 0;
                                        //actPosMCPrefix = this.searchMulticontrolPrefix(VariableFound, ref actPosMCPrefix);
                                        //if (actPosMCPrefix != -1)
                                        //{
                                        //    VariableFound = this.readStrMulticontrol(VariableFound).Trim();
                                        //}

                                        qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQryPic = this.sqlAdmin1.addRowQueriesDef(newClamb.dsValuesInClamb.tblQueriesDef);
                                        rNewQryPic.CriteriaFldShort = VariableFound.Trim();
                                        rNewQryPic.CriteriaApplication = IDApplication;
                                        rNewQryPic.Condition = StrFoundCondition.Trim();
                                        rNewQryPic.ValueMin = ValueFound.Trim();
                                        if (VariableFound.Trim() == "")
                                        {
                                            throw new Exception("ownMCLogicRelation.buildLogicRelation: VariableFound.Trim() == '' for FldShort '" + ownMultiControlPicture._FldShort.Trim() + "'!");
                                        }
                                        if (ValueFound.Trim() == "")
                                        {
                                            throw new Exception("ownMCLogicRelation.buildLogicRelation: ValueFound.Trim() == '' for FldShort '" + ownMultiControlPicture._FldShort.Trim() + "'!");
                                        }

                                        rNewQryPic.Sort = Sort;
                                        rNewQryPic.IDSelList = nrCondition;

                                        //lth
                                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl1 = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                                        System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                                        System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstOwnGroupBox = new List<multiControl.ownGroupBox>();
                                        qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rNewQryPic.CriteriaFldShort, IDApplication,
                                                                                                ref this.ownMultiControl1.ownMCCriteria1.parentAutoUI, "",
                                                                                                ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstOwnGroupBox);

                                        foreach (qs2.design.auto.multiControl.ownMultiControl ownControlQry in lstOwnMultiControl1)
                                        {
                                            if (ownControlQry.ownMCEvents1.dsEventsRegistered == null)
                                            {
                                                ownControlQry.ownMCEvents1.dsEventsRegistered = new core.vb.dsAdmin();
                                            }
                                            qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrCountPicturesRegistered = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])ownControlQry.ownMCEvents1.dsEventsRegistered.tblQueriesDef.Select(ownControlQry.ownMCEvents1.dsEventsRegistered.tblQueriesDef.CriteriaFldShortColumn.ColumnName + "='" + this.ownMultiControl1._FldShort + "'" + qs2.core.sqlTxt.and + ownControlQry.ownMCEvents1.dsEventsRegistered.tblQueriesDef.TypColumn.ColumnName + "='" + qs2.core.Enums.eConditionTyp.Pictures.ToString() + "'");
                                            if (arrCountPicturesRegistered.Length == 0)
                                            {
                                                qs2.core.vb.dsAdmin.tblQueriesDefRow rQryPicNew = (qs2.core.vb.dsAdmin.tblQueriesDefRow)this.sqlAdmin1.addRowQueriesDef(ownControlQry.ownMCEvents1.dsEventsRegistered.tblQueriesDef);
                                                rQryPicNew.CriteriaFldShort = this.ownMultiControl1._FldShort;
                                                rQryPicNew.Typ = qs2.core.Enums.eConditionTyp.Pictures.ToString();
                                                ownControlQry.ownMCEvents1.evDoPicture += new qs2.design.auto.multiControl.ownMCEvents.doPicture(this.runConditions);
                                            }
                                        }

                                        if (containsClipOn > 0)
                                        {
                                            if (sIndexOfClampOn > 0)
                                            {
                                                throw new Exception("ownMCLogicRelation.buildLogicRelation: Error in formula - position of sIndexOfClampOn > 0!");
                                                //qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQryPicClamp = this.sqlAdmin1.addRowQueriesDef(newClamb.dsValuesInClamb.tblQueriesDef);
                                                //rNewQryPicClamp.Combination = qs2.core.sqlTxt.ClampRight.Trim();
                                                //rNewQryPicClamp.Sort = Sort;
                                                //rNewQryPicClamp.IDSelList = nrCondition;
                                                //Sort += 1;
                                            }
                                        }
                                        if (containsClipClose > 0)
                                        {
                                            if (sIndexOfClampClose > 0)
                                            {
                                                for (int i = 0; i < containsClipClose; i++)
                                                {
                                                    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQryPicClamp = this.sqlAdmin1.addRowQueriesDef(newClamb.dsValuesInClamb.tblQueriesDef);
                                                    rNewQryPicClamp.Combination = qs2.core.sqlTxt.ClampLeft.Trim();
                                                    rNewQryPicClamp.Sort = Sort;
                                                    rNewQryPicClamp.IDSelList = nrCondition;
                                                    Sort += 1;
                                                }
                                            }
                                        }
                                        IsFirstClaimb = false;
                                        StrFoundPrev = sClaimb;
                                        Sort += 1;
                                    }
                                    if (sCombination.Trim() != "" && !IsFirstClaimb)
                                    {
                                        qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQryPicCombination = this.sqlAdmin1.addRowQueriesDef(newClamb.dsValuesInClamb.tblQueriesDef);
                                        rNewQryPicCombination.Combination = sCombination.Trim();
                                        rNewQryPicCombination.Sort = Sort;
                                        rNewQryPicCombination.IDSelList = nrCondition;
                                        Sort += 1;
                                    }
                                }
                                if (containsClipOnTotal != containsClipCloseTotal)
                                {
                                    throw new Exception("ownMCLogicRelation.buildLogicRelation: Error in formula - containsClipOnTotal != containsClipCloseTotal!");
                                }

                                nrCondition += 1;
                            }
                        }
                    }
                }

                //foreach (ClambsRek actuellClamb in this.lstLogicRelation)
                //{
                //    int FinishedToSortNr = -1;
                //    bool ValueOPK = false;
                //    this.doClambsRek(ownMultiControlPicture, ref actuellClamb.dsValuesInClamb, actuellClamb, 0, true, "", ref FinishedToSortNr, ref ValueOPK);
                //}

                this._isInitialized = true;
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.buildLogicRelation", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void checkClip(ref string sClaimb, ref int containsClipOn, ref int containsClipClose)
        {
            try
            {
                if (sClaimb.Trim().ToLower().Contains(qs2.core.sqlTxt.ClampRight.Trim().ToLower()))
                {
                    containsClipOn = this.countCharacterInAString(ref sClaimb, System.Convert.ToChar(qs2.core.sqlTxt.ClampRight.Trim()));
                }
                if (sClaimb.Trim().ToLower().Contains(qs2.core.sqlTxt.ClampLeft.Trim().ToLower()))
                {
                    containsClipClose = this.countCharacterInAString(ref sClaimb, System.Convert.ToChar(qs2.core.sqlTxt.ClampLeft.Trim()));
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMCLogicRelation.checkClip: " + ex.ToString());
            }
        }
        public int countCharacterInAString(ref string sClaimb, char charToFound)
        {
            int count = 0;
            foreach (char c in sClaimb.Trim())
            {
                if (charToFound.Equals(c))
                {
                    count++;
                }
            }
            return count;
        }
        public void doClambsRek(qs2.design.auto.multiControl.ownMultiControl ownMultiControlPicture, ref qs2.core.vb.dsAdmin dsAllConditions,
                                ClambsRek actuellClamb, int fromSort, bool firstClass, string CombinationBeforeClambOpenParent, ref int FinishedToSortNr,
                                ref System.Collections.Generic.List<cValueInClamp> lstValueOKInClamps)
        {
            try
            {
                string lastCombination = "";
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryPicSortedANDs = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])dsAllConditions.tblQueriesDef.Select(actuellClamb.dsValuesInClamb.tblQueriesDef.SortColumn.ColumnName + ">=" + fromSort.ToString(), dsAllConditions.tblQueriesDef.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQryRelation in arrQryPicSortedANDs)
                {
                    if (rQryRelation.Sort > FinishedToSortNr)
                    {
                        if (rQryRelation.Combination.Trim() == qs2.core.sqlTxt.ClampRight.Trim())
                        {
                            ClambsRek ClambsSub = new ClambsRek();
                            //actuellClamb.lstClambsSub.Add(ClambsSub);
                            //actuellClamb.CombinationBeforeClambOpen = lastCombination;
                            FinishedToSortNr = rQryRelation.Sort;
                            bool bValueResultLine = false;
                            System.Collections.Generic.List<cValueInClamp> lstValueOKInClampsRek = new List<cValueInClamp>();
                            this.doClambsRek(ownMultiControlPicture, ref dsAllConditions, ClambsSub, (rQryRelation.Sort + 1), false, lastCombination, ref FinishedToSortNr,
                                                ref lstValueOKInClampsRek);

                            this.getResultLine(ref bValueResultLine, ref lstValueOKInClampsRek);
                            cValueInClamp ValueInClamp = new cValueInClamp();
                            ValueInClamp.bValue = bValueResultLine;
                            ValueInClamp.NextCombination = lastCombination;
                            lstValueOKInClamps.Add(ValueInClamp);
                        }
                        else if (rQryRelation.Combination.Trim() == qs2.core.sqlTxt.ClampLeft.Trim())
                        {
                            //if (!firstClass)
                            FinishedToSortNr = rQryRelation.Sort;
                            return;
                        }
                        else if (rQryRelation.Combination.ToLower().Trim() == qs2.core.sqlTxt.and.ToLower().Trim() ||
                            rQryRelation.Combination.ToLower().Trim() == qs2.core.sqlTxt.or.ToLower().Trim())
                        {
                            lastCombination = rQryRelation.Combination.ToLower().Trim();
                            FinishedToSortNr = rQryRelation.Sort;
                        }
                        else if (!rQryRelation.IsCriteriaFldShortNull())
                        {
                            //if (!firstClass)
                            //{
                            actuellClamb.CombinationBeforeClambOpen = CombinationBeforeClambOpenParent;
                            //actuellClamb.copyToDS(rQryRelation);
                            if (this.getResultMulticontrol_In(ownMultiControl1, rQryRelation))
                            {
                                cValueInClamp ValueInClamp = new cValueInClamp();
                                ValueInClamp.bValue = true;
                                ValueInClamp.NextCombination = lastCombination;
                                lstValueOKInClamps.Add(ValueInClamp);
                            }
                            else
                            {
                                cValueInClamp ValueInClamp = new cValueInClamp();
                                ValueInClamp.bValue = false;
                                ValueInClamp.NextCombination = lastCombination;
                                lstValueOKInClamps.Add(ValueInClamp);
                            }
                            FinishedToSortNr = rQryRelation.Sort;
                            //}
                        }
                        else
                        {
                            throw new Exception("doClambsRek: not allowed!");
                        }
                        //lastCombination = rQryRelation.Combination;
                    }
                    else
                    {
                        //string xy = "";
                    }

                }
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.doClambsRek", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void runConditions(qs2.design.auto.multiControl.ownMultiControl ownMultiControlCalled)
        {
            try
            {
                bool resultIsSet = false;
                foreach (ClambsRek actuellClamb in this.lstLogicRelation)
                {
                    int FinishedToSortNr = -1;
                    System.Collections.Generic.List<cValueInClamp> lstValueOK = new List<cValueInClamp>();
                    this.doClambsRek(ownMultiControlCalled, ref actuellClamb.dsValuesInClamb, actuellClamb, 0, true, "", ref FinishedToSortNr, ref lstValueOK);
                    bool bValueResultLine = false;
                    this.getResultLine(ref bValueResultLine, ref lstValueOK);
                    if (bValueResultLine)    // && !resultIsSet
                    {
                        if (actuellClamb.IDRes != "")
                        {
                            ownMCRelationship.setPictureRessource(this.ownMultiControl1, actuellClamb.IDRes,
                                                        this.ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                        this.ownMultiControl1.ownMCCriteria1.Application);

                            if (qs2.core.ENV.adminSecure)
                            {
                                //System.Windows.Forms.MessageBox.Show(actuellClamb.IDRes, "Picture found");
                            }
                            resultIsSet = true;

                        }
                    }
                }
                if (!resultIsSet)
                {
                    ownMCRelationship.setPictureRessource(this.ownMultiControl1, this.ownMultiControl1._FldShort,
                            this.ownMultiControl1.ownMCCriteria1.IDParticipant,
                            this.ownMultiControl1.ownMCCriteria1.Application);
                    if (qs2.core.ENV.adminSecure)
                    {
                        //System.Windows.Forms.MessageBox.Show(this.ownMultiControl1._FldShort, "Standard-Picture set");
                    }
                }

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.runConditions", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool doResultClambsRekxyxy(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, ClambsRek actuellClamb)
        {
            try
            {
                bool resultLine = true;
                if (!actuellClamb.firstNode)
                {
                    string lastCombination = "";
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQryRelation in actuellClamb.dsValuesInClamb.tblQueriesDef)
                    {
                        if (rQryRelation.Combination.ToLower().Trim() == qs2.core.sqlTxt.and.ToLower().Trim() ||
                            rQryRelation.Combination.ToLower().Trim() == qs2.core.sqlTxt.or.ToLower().Trim())
                        {
                            lastCombination = rQryRelation.Combination.ToLower().Trim();
                        }
                        else if (!rQryRelation.IsCriteriaFldShortNull())
                        {
                            if (rQryRelation.Condition.ToLower().Trim() == "=")
                            {
                                //if (this.getResultMulticontrol_In(ownMultiControl1, rQryRelation))
                                //{
                                //    this.getResultLine(lastCombination, ref resultLine, System.Convert.ToBoolean(true));
                                //}
                                //else
                                //{
                                //    this.getResultLine(lastCombination, ref resultLine, System.Convert.ToBoolean(false));
                                //}
                            }
                            else
                            {
                                //string xyxyx = "";
                            }
                        }
                    }
                }

                bool resultAllSubClambs = resultLine;
                //foreach (ClambsRek ClambsRekActuell in actuellClamb.lstClambsSub)
                //{
                //    resultLine = this.doResultClambsRekxy(ownMultiControl1, ClambsRekActuell);
                //    if (ClambsRekActuell.CombinationBeforeClambOpen != "")
                //    {
                //        string xyxy = "";
                //    }
                //    if (resultLine)
                //    {
                //        string xyxy = "";
                //    }
                //    this.getResultLine(ClambsRekActuell.CombinationBeforeClambOpen, ref resultAllSubClambs, resultLine);
                //    //if (resultLine)
                //    //    return true;
                //}

                return resultAllSubClambs;
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.doResultClambsRek", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }
        public void getResultLine(ref bool resultLine, ref System.Collections.Generic.List<cValueInClamp> lstValueOKInClampsRek)
        {
            try
            {
                bool actuellResult = false;
                foreach (cValueInClamp ValueInClamp in lstValueOKInClampsRek)
                {
                    if (ValueInClamp.NextCombination.ToLower().Trim() == qs2.core.sqlTxt.and.ToLower().Trim())
                    {
                        actuellResult = actuellResult && ValueInClamp.bValue;
                    }
                    else if (ValueInClamp.NextCombination.ToLower().Trim() == qs2.core.sqlTxt.or.ToLower().Trim())
                    {
                        actuellResult = actuellResult || ValueInClamp.bValue;
                    }
                    else
                    {
                        actuellResult = ValueInClamp.bValue;
                    }
                }

                resultLine = actuellResult;

                //if (lastCombination.ToLower().Trim() == qs2.core.sqlTxt.and.ToLower().Trim())
                //{
                //    resultLine = resultLine && actuellResult;
                //}
                //else if (lastCombination.ToLower().Trim() == qs2.core.sqlTxt.or.ToLower().Trim())
                //{
                //    resultLine = resultLine || actuellResult;
                //}
                //else
                //{
                //    resultLine = actuellResult;
                //}

            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.getResultLine", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool getResultMulticontrol_In(qs2.design.auto.multiControl.ownMultiControl ownMultiControlParent,
                                            qs2.core.vb.dsAdmin.tblQueriesDefRow rQryRelation)
        {
            try
            {
                bool valueInList = false;
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstOwnMultiControl1 = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                System.Collections.Generic.List<UltraTab> lstTabePageReturn = new System.Collections.Generic.List<UltraTab>();
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstOwnGroupBox = new List<qs2.design.auto.multiControl.ownGroupBox>();
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                qs2.design.auto.multiControl.ownMCGeneric.getMulticontrol(rQryRelation.CriteriaFldShort, ownMultiControlParent.ownMCCriteria1.Application,
                                                                        ref ownMultiControlParent.ownMCCriteria1.parentAutoUI, "",
                                                                        ref lstOwnMultiControl1, ref lstTabePageReturn, ref lstTab, ref lstOwnGroupBox);
                foreach (qs2.design.auto.multiControl.ownMultiControl ownControlRelation in lstOwnMultiControl1)
                {
                    if (rQryRelation.ValueMin.Trim() != "")
                    {
                        qs2.core.generic.retValue retValue1 = ownControlRelation.ownMCDataBind1.getValueFromRow(ownControlRelation);
                        System.Collections.Generic.List<string> lstCondition = qs2.core.generic.readStrVariables(rQryRelation.ValueMin);
                        foreach (string val in lstCondition)
                        {
                            if (val == retValue1.valueStr)
                                valueInList = true;
                        }
                    }
                }
                return valueInList;
            }
            catch (Exception ex)
            {
                string tempFldShort = "";
                string tempIDApplication = "";
                if (this.ownMultiControl1 != null)
                {
                    tempFldShort = this.ownMultiControl1._FldShort;
                    tempIDApplication = this.ownMultiControl1.ownMCCriteria1.Application;
                }
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCLogicRelation.getResultMulticontrol_In", tempFldShort, false, true, tempIDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

        public int searchMulticontrolPrefix(string strToSearch, ref int actPos)
        {
            actPos = qs2.core.generic.nextPos(strToSearch, qs2.core.ui.prefixMultiControl, actPos);
            return actPos;
        }
        public string readStrMulticontrol(string strToSearch)
        {
            return qs2.core.generic.getSubstring(strToSearch, 3, strToSearch.Length - 3);
        }

        public class ClambsRek
        {

            public qs2.core.vb.dsAdmin dsValuesInClamb = new qs2.core.vb.dsAdmin();
            //public System.Collections.Generic.List<ClambsRek> lstClambsSub = new System.Collections.Generic.List<ClambsRek>();
            public bool firstNode = false;
            public bool result = false;
            public string CombinationBeforeClambOpen = "";
            public string Condition = "";
            public string IDRes = "";


            //public void copyToDS(qs2.core.vb.dsAdmin.tblQueriesDefRow rToCopy)
            //{
            //    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQry = (qs2.core.vb.dsAdmin.tblQueriesDefRow)this.dsValuesInClamb.tblQueriesDef.NewRow();
            //    rNewQry.ItemArray = rToCopy.ItemArray;
            //    rNewQry.IDGuid = System.Guid.NewGuid();
            //    this.dsValuesInClamb.tblQueriesDef.Rows.Add(rNewQry);
            //}

        }

    }

}
