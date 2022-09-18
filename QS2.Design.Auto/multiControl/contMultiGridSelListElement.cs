using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace qs2.design.auto.multiControl
{


    public partial class contMultiGridSelListElement : UserControl
    {

        public ownMultiGridSelList mainControl;
        public bool isLoaded = false;
        public int groupNrToLoad = -1;
  




        public contMultiGridSelListElement()
        {
            InitializeComponent();
        }


        private void MultiGridSelListElement_Load(object sender, EventArgs e)
        {
        }
        public void initControl()
        {
            try
            {
                if (this.isLoaded) return;

                this.sqlAdmin1.initControl();
                this.loadRes();

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }
                this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Hidden = false;
                this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Hidden = false;
                
                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.initControl", "", false, true,
                                                                this.mainControl.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void loadRes()
        {
            try
            {
                this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection");
                this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.loadRes", "", false, true,
                                                                this.mainControl.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
  
        public void loadDataFirstxy(string GroupToLoad, qs2.core.license.doLicense.eApp Application, string IDParticipant)
        {
            try
            {
                //this.dsAdmin1.Clear();
                //this.translateLabel(GroupToLoad, Application, IDParticipant);
                //this.sqlAdmin1.getSelListEntrys(GroupToLoad, IDParticipant, Application.ToString(), ref this.dsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group);
                //this.translateCombo(Application, IDParticipant);

                //this.cboSelListEntrySelection.Refresh();
                ////this.cboSelListEntrySelection.Focus();

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.loadDataFirstxy", "", false, true,
                                                                this.mainControl.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void loadData(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry, string GroupToLoad, string Application, string IDParticipant)
        {
            try
            {
                this.dsAdmin1.Clear();
                this.translateLabel(rSelListEntry.IDRessource, Application, IDParticipant);
                this.sqlAdmin1.getSelListEntrysObj(rSelListEntry.ID, qs2.core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, GroupToLoad, this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlObj.sellist, Application.ToString());

                int iCounter = 0;
                qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntryFirst = null;
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rObj in this.dsAdmin1.tblSelListEntriesObj)
                {
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntryFound = this.sqlAdmin1.getSelListEntrysRow("", qs2.core.vb.sqlAdmin.eTypAuswahlList.id, IDParticipant, Application.ToString(), "", rObj.IDSelListEntry, "", rObj.IDSelListEntry);
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)this.sqlAdmin1.getNewRowSelList(this.dsAdmin1, true);
                    rNew.ItemArray = rSelListEntryFound.ItemArray;
                    iCounter += 1;
                    if (rSelListEntryFirst == null)
                    {
                        rSelListEntryFirst = rNew;
                    }
                }
                
                this.translateCombo(Application, IDParticipant);

                this.cboSelListEntrySelection.Refresh();
                //this.cboSelListEntrySelection.Focus();

                this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Width = this.cboSelListEntrySelection.Width - 80;

                if (iCounter == 1)
                {
                    this.cboSelListEntrySelection.ActiveRow = this.cboSelListEntrySelection.Rows[0];
                    this.cboSelListEntrySelectionValueChanged(this.cboSelListEntrySelection);
                    //this.Visible = false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.loadData", "", false, true,
                                                                    this.mainControl.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void loadDataUsersForRole(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry, string GroupToLoad, string Application, string IDParticipant,
                                        bool LoadRoles)
        {
            try
            {
                this.dsAdmin1.Clear();
                this.translateLabel(rSelListEntry.IDRessource, Application, IDParticipant);
                if (LoadRoles)
                {
                    qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrSelListEntrieiesGroupUsers = (qs2.core.vb.dsAdmin.tblSelListGroupRow[])qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(this.dsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName + "='Roles'", "");
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntriesUsers = (qs2.core.vb.dsAdmin.tblSelListEntriesRow[])qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(this.dsAdmin1.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntrieiesGroupUsers[0].ID.ToString() + "", "");
                    foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rRolesUser in arrSelListEntriesUsers)
                    {
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)this.sqlAdmin1.getNewRowSelList(this.dsAdmin1, true);
                        rNew.ItemArray = rRolesUser.ItemArray;
                    }
                    this.cboSelListEntrySelection.Refresh();
                    this.translateCombo(Application, IDParticipant);

                }
                else
                {
                    this.mainControl.rSelListSelectedRole = rSelListEntry;
                    qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrSelListEntrieiesGroupUsers = (qs2.core.vb.dsAdmin.tblSelListGroupRow[])qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(this.dsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName + "='Users'", "");
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntriesUsers = (qs2.core.vb.dsAdmin.tblSelListEntriesRow[])qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(this.dsAdmin1.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntrieiesGroupUsers[0].ID.ToString() + "", "");
                    this.sqlAdmin1.getSelListEntrysObj(rSelListEntry.ID, qs2.core.vb.sqlAdmin.eDbTypAuswObj.Roles, "Roles", this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlObj.IDSelListEntry, Application.ToString(), rSelListEntry.ID);
                    foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rUser in arrSelListEntriesUsers)
                    {
                        bool bRolwOKForUser = false;
                        foreach (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rRolesUser in this.dsAdmin1.tblSelListEntriesObj)
                        {
                            if (rRolesUser.IDObject.Equals(rUser.ID))
                            {
                                bRolwOKForUser = true;
                            }
                        }
                        if (bRolwOKForUser)
                        {
                            qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrUserInComboFound = (qs2.core.vb.dsAdmin.tblSelListEntriesRow[])this.dsAdmin1.tblSelListEntries.Select(this.dsAdmin1.tblSelListEntries.IDColumn.ColumnName + "=" + rUser.ID.ToString() + "", "");
                            if (arrUserInComboFound.Length == 0)
                            {
                                qs2.core.vb.dsAdmin.tblSelListEntriesRow rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)this.sqlAdmin1.getNewRowSelList(this.dsAdmin1, true);
                                rNew.ItemArray = rUser.ItemArray;
                            }
                            else
                            {
                                //string xy = "";
                            }
                        }
                    }
                    this.cboSelListEntrySelection.Refresh();
                }
                this.cboSelListEntrySelection.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Width = this.cboSelListEntrySelection.Width - 80;
       
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.loadData", "", false, true,
                                                                    this.mainControl.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void translateLabel(string IDRessource, string Application, string IDParticipant)
        {
            try
            {
                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                string IDResLabelFound = qs2.core.language.sqlLanguage.getRes(IDRessource, core.Enums.eResourceType.Label, IDParticipant, Application, ref rLangFoundReturn);
                if (IDResLabelFound.Trim() != "")
                    this.lblSelListEntryToSelect.Text = IDResLabelFound;
                else
                    this.lblSelListEntryToSelect.Text = IDRessource;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.translateLabel", "", false, true,
                                                                this.mainControl.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void translateCombo(string Application, string IDParticipant)
        {
            try
            {
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry in this.dsAdmin1.tblSelListEntries)
                {
                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                    string IDResFound = qs2.core.language.sqlLanguage.getRes(rSelListEntry.IDRessource, core.Enums.eResourceType.Label, IDParticipant, Application, ref rLangFoundReturn);
                    if (IDResFound.Trim() != "")
                        rSelListEntry.IDRessource = IDResFound;
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.translateCombo", "", false, true,
                                                            this.mainControl.ownMCCriteria1.Application,
                                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        private void cboSelListEntrySelection_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboSelListEntrySelection.Focused)
                {
                    if (this.cboSelListEntrySelection.ActiveRow != null)
                    {
                        this.cboSelListEntrySelectionValueChanged(this.cboSelListEntrySelection);
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.cboSelListEntrySelection_ValueChanged", "", false, true,
                                                                this.mainControl.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void cboSelListEntrySelectionValueChanged(Infragistics.Win.UltraWinGrid.UltraCombo cbo)
        {
            try
            {
                if (cbo.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)cbo.ActiveRow.ListObject;
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelSelListEntry = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                    this.mainControl.unvisibleAllElementsHigher(this.groupNrToLoad);
                    int NextListNr = this.mainControl.getNextListNrToAdd();

                    if (this.mainControl.CheckIfDoRolesAndUsers())
                    {
                        if (NextListNr == 3)
                        {
                            this.mainControl.addNewRowToMainGroup(rSelSelListEntry);
                        }
                        else
                        {
                            this.mainControl.addNewSelListElement(rSelSelListEntry, NextListNr);
                        }
                    }
                    else
                    {
                        if (this.mainControl.ListNrIsLast(NextListNr))
                        {
                            this.mainControl.addNewRowToMainGroup(rSelSelListEntry);
                        }
                        else
                        {
                            this.mainControl.addNewSelListElement(rSelSelListEntry, NextListNr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "contMultiGridSelListElement.cboSelListEntrySelectionValueChanged", "", false, true,
                                                                this.mainControl.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
    }
}
