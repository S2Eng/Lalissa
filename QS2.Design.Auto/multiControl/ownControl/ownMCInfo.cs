using System;

namespace qs2.design.auto.multiControl
{
    public class ownMCInfo
    {
        private static qs2.core.vb.contProtocol contTotalProtocol2 = null;

        public void showInfoCriterias(System.Windows.Forms.Control ctl, string fldShort, string IDApplication, string IDParticipant, bool OwnFieldForALLProducts)
        {
            try
            {
                qs2.sitemap.manage.wizardsDevelop.frmCriterias frmCriterias1 = new qs2.sitemap.manage.wizardsDevelop.frmCriterias();
                if (OwnFieldForALLProducts)
                {
                    frmCriterias1.contCriterias1.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString();
                    frmCriterias1.defaultApplication = qs2.core.license.doLicense.eApp.ALL.ToString();
                }
                else
                {
                    frmCriterias1.contCriterias1.IDApplication = IDApplication;
                    frmCriterias1.defaultApplication = IDApplication;
                }
                frmCriterias1.contCriterias1.IDParticipant = IDParticipant;
                frmCriterias1.searchAuto = fldShort;
                frmCriterias1.doSearchAuto = true;
                frmCriterias1.loadForm(sitemap.manage.wizardsDevelop.contCriterias.eTypeUI.Admin);
                frmCriterias1.ShowDialog(ctl);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCInfo.showInfoCriterias", fldShort, true, false, IDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void showInfoRessourcen(System.Windows.Forms.Control ctl, string fldShort, string IDApplication, string IDParticipant, bool OwnFieldForALLProducts)
        {
            try
            {
                qs2.sitemap.manage.wizardsDevelop.frmRessourcen frmRes = new qs2.sitemap.manage.wizardsDevelop.frmRessourcen();
                if (OwnFieldForALLProducts)
                {
                    frmRes.contRessourcen1.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString();
                    frmRes.defaultApplication = qs2.core.license.doLicense.eApp.ALL.ToString();
                }
                else
                {
                    frmRes.contRessourcen1.IDApplication = IDApplication.ToString();
                    frmRes.defaultApplication = IDApplication;
                }

                frmRes.contRessourcen1.IDParticipant = IDParticipant;
                frmRes.doSearchAuto = true;
                frmRes.searchAuto = fldShort.Trim();
                frmRes.ShowDialog(ctl);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCInfo.showInfoRessourcen", fldShort, true, false, IDApplication,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void showInfoFldShorts(System.Windows.Forms.Control ctl, string[] fldShorts, string title, string IDApplicationxy, bool OwnFieldForALLProductsxy)
        {
            try
            {
                string info = "";
                if (fldShorts != null)
                {
                    int nr = 0;
                    foreach (string fldShort in fldShorts)
                    {
                        nr += 1;
                        info += nr.ToString() + ". " + fldShort + qs2.core.generic.lineBreak;
                    }
                }

                System.Windows.Forms.MessageBox.Show(info, title);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCInfo.showInfoFldShorts", "", true, false, IDApplicationxy,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void infoClassification(qs2.design.auto.multiControl.ownMultiControl ownControl1, string IDApplicationxy)
        {
            try
            {
                string info = "";
                foreach (qs2.core.Enums.cVariables VariableFromLst in ownControl1.ownMCCriteria1.lstVariablesClassification)
                {
                    info += "Definition: " + VariableFromLst.definition.Trim() + qs2.core.generic.lineBreak;
                    info += "Value: " + VariableFromLst.value.Trim() + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak;
                }
                if (info.Trim() == "")
                {
                    info = "No Classification exists for this Criteria!";
                }
                System.Windows.Forms.MessageBox.Show(info, qs2.core.language.sqlLanguage.getRes("Info") + " " + qs2.core.language.sqlLanguage.getRes("Classification"));
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCInfo.showInfoFldShorts", "", true, false, IDApplicationxy,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool showInfoSelList(System.Windows.Forms.Control ctl, string fldShort, string Application,
                                        string IDParticipant, bool addSelList, qs2.design.auto.multiControl.ownMultiControl ownMultiControl1,
                                        bool OwnFieldForALLProducts, bool sysMode, bool OnlyOwnSelListsEditable)
        {
            try
            {
                qs2.sitemap.vb.frmSelLists frmSelList = new qs2.sitemap.vb.frmSelLists();
                frmSelList.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName;
                frmSelList._OnlyOwnSelListsEditable = OnlyOwnSelListsEditable;
                frmSelList.ContSelList1._ShowOnlyUserSelLists = true;
                frmSelList.ContSelList1.IDParticipantToAdd = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim();
                frmSelList.ContSelList1.IDApplicationCalled = Application.Trim();
                qs2.core.generic.retValue selectedValue = new qs2.core.generic.retValue();
                if (ownMultiControl1 != null && (ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBox ||
                                                 ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBoxNoDb))
                {
                    selectedValue = ownMultiControl1.ownMCValue1.getValue(ownMultiControl1, false);
                }

                if (!sysMode)
                {
                    frmSelList.typeUI = sitemap.vb.frmSelLists.eTypeUI.manageQueryGroups;
                    frmSelList.ContSelList1.doAutoRessource = true;
                    frmSelList.ContSelList1.IDGruppeStr = fldShort;
                    frmSelList.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName;
                    frmSelList._Private = false;
                }
                else
                {
                    frmSelList.typeUI = sitemap.vb.frmSelLists.eTypeUI.Administration;
                    frmSelList.searchAuto = fldShort;
                    frmSelList.doSearchAuto = true;
                }
                if (OwnFieldForALLProducts)
                {
                    frmSelList.ContSelList1.defaultApplication = qs2.core.license.doLicense.eApp.ALL.ToString();
                }
                else
                {
                    frmSelList.ContSelList1.defaultApplication = Application;
                }
                frmSelList.ContSelList1.IDParticipant = IDParticipant;
                frmSelList.ShowDialog(ctl);
                if (addSelList && frmSelList.ContSelList1.savedClicked && ownMultiControl1 != null)
                {
                    ownMultiControl1.ownMCCriteria1.ownMCCombo1.loadCombo(ownMultiControl1, "", ownMultiControl1.ownMCCriteria1.CombinationComboBoxAsDropDown, ownMultiControl1.ownMCCriteria1.ownMCCombo1._ComboBoxCheckThreeStateBoxAsDropDown);
                }

                if (ownMultiControl1 != null)
                {
                    if ((ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBox ||
                         ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBoxNoDb) && selectedValue.valueStr.Trim() != "")
                    {
                        ownMultiControl1.ownMCValue1.setValue(ownMultiControl1, selectedValue.valueStr);
                    }
                }

                return frmSelList.ContSelList1.savedClicked;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCInfo.showInfoSelList", fldShort, true, false, Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

        public void infoFieldDB(System.Windows.Forms.Control ctl, string fldShort, string IDApplication, string IDParticipant, bool OwnFieldForALLProducts)
        {
            try
            {
                qs2.sitemap.workflowAssist.frmInfoFieldDB frmInfoDB = new qs2.sitemap.workflowAssist.frmInfoFieldDB();
                frmInfoDB.contInfoFieldDB1.searchColumnText = fldShort;
                frmInfoDB.contInfoFieldDB1.IDApplication = IDApplication;
                frmInfoDB.contInfoFieldDB1.IDParticipant = IDParticipant;
                frmInfoDB.contInfoFieldDB1.txtSearchTextColumn.Text = fldShort;
                frmInfoDB.ShowDialog(ctl);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCInfo.infoFieldDB", fldShort, true, false, IDApplication,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public static void openProtocoll(ref string protocollForAdmin)
        {
            qs2.core.vb.frmProtocol frmProtokoll1 = new qs2.core.vb.frmProtocol();
            frmProtokoll1.initControl();
            frmProtokoll1.Text = "Stay - Info Customizing";
            qs2.core.ENV.lstOpendChildForms.Add(frmProtokoll1);
            frmProtokoll1.Show();
            frmProtokoll1.ContProtocol1.setText(protocollForAdmin.Trim());
        }

        public static void checkForProtocol(bool openAlways)
        {
            if ((qs2.core.Protocol.totalProtocol.Trim() != "" || openAlways) && !openAlways)
            {
                ownMCInfo.contTotalProtocol2.setText(qs2.core.generic.lineBreak + qs2.core.Protocol.totalProtocol.Trim() + ownMCInfo.contTotalProtocol2.getTxt());
                qs2.core.Protocol.totalProtocol = "";
            }
        }
    }
}
