﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using QS2.Resources;




namespace qs2.ui.print
{

    
    public partial class contQryAdmin : UserControl 
    {
        
        public bool isInEditMode = false;
        public frmQryAdmin mainWindow;
        public qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();
        public string IDParticipant = "";

        public qs2.core.Enums.eTypeQuery typeQuery = new qs2.core.Enums.eTypeQuery();
        public string DefaultApplication = "";
        public qs2.ui.drawMulticontrol drawMulticontrol1 = new qs2.ui.drawMulticontrol();

        public bool abort = true;
        public bool saveIsClicked = false;
        
        public qs2.ui.print.frmQryRunReport frmQryRunReport1 = null;
        public static bool dataChanged = false;






        public contQryAdmin()
        {
            InitializeComponent();
        }

        public void initControl(string defaultApplication)
        {
            try
            {
                this.loadRes();

                this.contSelListQueries.mainWindowQueryManage = this;

                //this.dropDownReportCriterias.initControl(true);
                this.contSelListQueries.Participant = this.IDParticipant;
                this.contSelListQueries.typeQuery = this.typeQuery;

                if (this.typeQuery == core.Enums.eTypeQuery.Admin)
                {
                    this.contSelListQueries.initControl(defaultApplication, false, false, false, true, true, false);
                }
                else if (this.typeQuery == core.Enums.eTypeQuery.User)
                {
                    this.contSelListQueries.initControl(defaultApplication, false, false, true, true, false, false);
                }
                
                this.ultraTabControlFields.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                this.loadApplicationList(defaultApplication);

                this.btnSave.initControl();
                this.btnCancel.initControl();

                this.contFields.mainWindow = this;
                this.contInputParemeters.mainWindow = this;
                this.contJoins.mainWindow = this;
                this.contConditions.mainWindow = this;

                this.contFields.initControl(core.Enums.eTypQueryDef.SelectFields);
                this.contConditions.initControl(core.Enums.eTypQueryDef.WhereConditions);
                this.contJoins.initControl(core.Enums.eTypQueryDef.Joins);
                this.contInputParemeters.initControl(core.Enums.eTypQueryDef.InputParameters);

                if (this.typeQuery == core.Enums.eTypeQuery.Admin)
                {
                    extendedViewToolStripMenuItem.Checked = true;
                    this.btnDoAutoJoin.Visible = true;
                    this.btnEditQuery.Visible = false;
                }
                else if (this.typeQuery == core.Enums.eTypeQuery.User)
                {
                    this.btnDoAutoJoin.Visible = false;
                    this.panelButtonsUnten.Visible = false;

                    if (!qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        this.ExtendedView(false);
                    }
                    else
                    {
                        this.ExtendedView(false);
                    }
                }

                if (this.contSelListQueries.rSelListEntryToLoad != null)
                {
                    this.panelButtClose.Visible = true;
                }


            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRes()
        {
            try
            {
                this.sqlAdmin1.initControl();

                this.btnCancel.initControl();
                this.btnSave.initControl();
                this.btnEdit.initControl();
                this.btnClose.initControl();
                this.btnTestQuery.initControl();
                this.btnDoAutoJoin.initControl();
                this.btnManageQuery.initControl();
                this.btnEditQuery.initControl();
                this.btnDeleteQuery.initControl();
                this.btnUserRights .initControl();

                this.btnEdit.Text = qs2.core.language.sqlLanguage.getRes("Edit");
                this.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel");
                this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");
                this.ultraTabControlMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;

                this.grpSql.Text = qs2.core.language.sqlLanguage.getRes("Sql");

                this.lblListQueries.Text = qs2.core.language.sqlLanguage.getRes("ListQueries");

                if (this.typeQuery == core.Enums.eTypeQuery.Admin)
                {
                    this.btnManageQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("ManageQuery");
                }
                else if (this.typeQuery == core.Enums.eTypeQuery.User)
                {
                    this.btnManageQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("AddQuery");
                }
                this.btnEditQuery .OwnTooltipText = qs2.core.language.sqlLanguage.getRes("EditQuery");

                this.btnDeleteQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("DeleteQuery");
                this.btnUserRights.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("UserRights");

                this.setNumberForSelectedControlDefault();

                //this.btnAddQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("AddQuery");

                this.extendedViewToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ExtendedView");

                this.btnTestQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("TestQuery");
                this.btnDoAutoJoin.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("DoAutoJoin");
                
                //this.btnTestQuery.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("AddQuery");
                this.btnTestQuery.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_sys, 32, 32);
                this.btnDoAutoJoin.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_modifyQuery, 32, 32);
                //this.btnManageQuery.Appearance.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_selListsObj  , 32, 32 );

                this.exportToTSqlToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_sys, 32, 32);
                this.exportAllQueriesToTSqlToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_sys, 32, 32);
                this.btnUserRights.Appearance.Image = getRes.getImage(getRes.Allgemein.ico_OK, 32, 32);

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void setNumberForSelectedControlDefault()
        {
            try
            {
                this.setNumberForSelectedControl(core.Enums.eTypQueryDef.SelectFields, 0);
                this.setNumberForSelectedControl(core.Enums.eTypQueryDef.WhereConditions, 0);
                this.setNumberForSelectedControl(core.Enums.eTypQueryDef.Joins, 0);
                this.setNumberForSelectedControl(core.Enums.eTypQueryDef.InputParameters, 0);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadApplicationList(string defaultApplication)
        {
            try
            {
                this.dropDownApplications1.initControl(false);
                this.dropDownApplications1.loadData();

                bool onlyLicensedProducts = true;
                if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    onlyLicensedProducts = false;
                }

                if (this.typeQuery == core.Enums.eTypeQuery.Admin)
                {
                    this.comboApplication1.initControlxy(true, onlyLicensedProducts, true);
                }
                else if (this.typeQuery == core.Enums.eTypeQuery.User)
                {
                    this.comboApplication1.initControlxy(false, onlyLicensedProducts, true);
                }
                this.comboApplication1.setApplication(defaultApplication);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadQueries(dsAdmin.tblSelListEntriesRow rSelListAdded, bool loadCboListQueries, bool noEditMode)
        {
            try
            {
                this.contFields.clear();
                this.contInputParemeters.clear();
                this.contConditions.clear();
                this.contJoins.clear();

                this.contFields.rSelList = null;
                this.contInputParemeters.rSelList = null;
                this.contConditions.rSelList = null;
                this.contJoins.rSelList = null;

                this.setNumberForSelectedControlDefault();

                bool toEditMode = false;
                
                if (loadCboListQueries)
                    this.contSelListQueries.loadQueries(rSelListAdded, this.getSelectedApplication(), this.IDParticipant, null, this.getTypeSelListForPrivate(), -999, false);

                if (noEditMode)
                    this.edit(toEditMode);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public bool getTypeSelListForPrivate()
        {
            try
            {
                if (this.typeQuery == core.Enums.eTypeQuery.Admin)
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
                throw new Exception("getTypeSelListForPrivate: " + ex.ToString());
            }
        }
        public void refreshControl()
        {
            try
            {


            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public string getSelectedApplication()
        {
            try
            {
                //core.license.doLicense.eApp enumAppFound = core.license.doLicense.eApp.ALL;
                //if (this.cboApplications.Value != null)
                return this.comboApplication1.getSelectedApplication().ToString();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return "";
            }
        }
        public void loadQueryDefValueChange(string typ, ref string protocollForAdmin, ref bool ProtocolWindow)
        {
            try
            {
                dsAdmin.tblSelListEntriesRow rSelectedSelList = this.contSelListQueries.getSelectedQuery(false);
                if (rSelectedSelList != null)
                {
                    if (typ == "loadQuery")
                        this.loadQueriesDef(rSelectedSelList);
                    else if (typ == "runQuery")
                        this.loadRunQuery(rSelectedSelList, ref protocollForAdmin, ref ProtocolWindow);
                }
                else
                    this.edit(false);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadQueriesDef(dsAdmin.tblSelListEntriesRow rSelList)
        {
            try
            {
                this.contFields.clear();
                this.contInputParemeters.clear();
                this.contConditions.clear();
                this.contJoins.clear();

                this.contFields.loadData(rSelList);
                this.contConditions.loadData(rSelList);
                this.contJoins.loadData(rSelList);
                this.contInputParemeters.loadData(rSelList);

                this.loadSQL(rSelList);

                this.edit(false);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadSQL(dsAdmin.tblSelListEntriesRow rSelList)
        {
            try
            {
                //this.txtSQL.Text  = rSelList.Sql;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void edit(bool bEdit)
        {
           try
           {
               this.isInEditMode = bEdit;

               this.btnSave.Enabled = bEdit;
               this.btnCancel.Enabled = bEdit;
               this.btnEdit.Enabled = !bEdit;

               this.btnTestQuery.Enabled = !bEdit;

               this.contFields.edit(bEdit);
               this.contJoins.edit(bEdit);
               this.contConditions.edit(bEdit);
               this.contInputParemeters.edit(bEdit);
               
               this.btnDoAutoJoin.Enabled = bEdit;
               this.exportToTSqlToolStripMenuItem.Visible = !bEdit;
               this.exportAllQueriesToTSqlToolStripMenuItem.Visible = !bEdit;
           }
           catch (Exception ex)
           {
               qs2.core.generic.getExep(ex.ToString(), ex.Message);
           }
        }

        public bool save()
        {
            try
            {
                qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListQuery = this.contSelListQueries.getSelectedQuery(false);
                if (rSelListQuery != null)
                {
                    if (this.contFields.save(rSelListQuery) && this.contConditions.save(rSelListQuery) &&
                            this.contJoins.save(rSelListQuery) && this.contInputParemeters.save(rSelListQuery))
                    {
                        //string protokoll = "";
                        //dsAdmin.tblQueriesDefDataTable tQryPar = this.getParValues();

                        //System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
                        //string sql = this.genSql1.doSql(this.contFields.dsAdmin1.tblQueriesDef, this.contConditions.dsAdmin1.tblQueriesDef, this.contInputParemeters.dsAdmin1.tblQueriesDef, ref protokoll, null, false, parameters);
                        //this.contFields.rSelList.Sql = sql.Trim();
                        //this.txtSQL.Text = sql.Trim();
                        //dsAdmin.tblSelListEntriesRow[] arrSelListEntry = new  dsAdmin.tblSelListEntriesRow[1];
                        //arrSelListEntry.SetValue(this.contFields.rSelList, 0);
                        //this.sqlAdmin1.daSelListEntrys.Update(arrSelListEntry);

                        //if (!protokoll.Trim().Equals(""))
                        //{
                        //    qs2.core.vb.frmProtokoll frmProtokoll1 = new qs2.core.vb.frmProtokoll();
                        //    frmProtokoll1.doTitle(qs2.core.language.sqlLanguage.getRes("SqlForQuery"));
                        //    frmProtokoll1.txtProtokoll.Text  = protokoll;
                        //    frmProtokoll1.Show();
                        //}

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoQuerySelected") + "!", MessageBoxButtons.OK, "");
                    return false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SaveClicked();
                 
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void SaveClicked()
        {
            try
            {
                //if (this.typeQuery == qs2.core.Enums.eTypeQuery.User)
                //{
                //    this.doAutoJoin();   
                //}

                dsAdmin.tblSelListEntriesRow rSelectedSelList = this.contSelListQueries.getSelectedQuery(false);
                if (rSelectedSelList != null)
                {
                    if (this.typeQuery == qs2.core.Enums.eTypeQuery.Admin)
                    {
                        if (rSelectedSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.FullMode.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            DialogResult doAutoJoins = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("doAutoJoins") + "?", MessageBoxButtons.YesNo, "");
                            if (doAutoJoins == DialogResult.Yes)
                            {
                                this.doAutoJoin(true);
                            }
                        }
                        else
                        {
                            this.contJoins.clear();
                        }
                    }
                    else if (this.typeQuery == qs2.core.Enums.eTypeQuery.User)
                    {
                        if (rSelectedSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.FullMode.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            this.doAutoJoin(false);
                        }
                        else
                        {
                            this.contJoins.clear();
                        }
                    }

                    //this.checkIDGuidStayAuto();
                    if (this.save())
                    {
                        this.edit(false);
                        this.saveIsClicked = true;
                        this.abort = false;
                        contQryAdmin.dataChanged = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQryAdmin.SaveClicked: " + ex.ToString());
            }
        }

        public void checkIDGuidStayAutoxy()
        {
            try
            {
                throw new Exception("checkIDGuidStayAutoxy: Fct deactivated!");

                dsAdmin.tblSelListEntriesRow rSelectedQuery = this.contSelListQueries.getSelectedQuery(false);
                if (rSelectedQuery != null)
                {
                    qs2.core.SysDB.dsSysDB ds = new core.SysDB.dsSysDB();
                    qs2.core.SysDB.dsSysDB.COLUMNSRow[] arrColSys = qs2.core.SysDB.sqlSysDB.getAllSysColumnsForTable("", ds);
                    foreach (qs2.core.SysDB.dsSysDB.COLUMNSRow rSysDB in arrColSys)
                    {
                        string ColumnTranslated = qs2.core.language.sqlLanguage.getRes(rSysDB.COLUMN_NAME, true, true);
                        if (ColumnTranslated.Trim() == "")
                            ColumnTranslated = rSysDB.COLUMN_NAME;

                        string protocoll = "";
                        string SchemaSysDB = "";
                        if (!rSysDB.IsTABLE_SCHEMANull())
                        {
                            SchemaSysDB = rSysDB.TABLE_SCHEMA.Trim();
                        }

                        UltraGridRow selRowGrid = null;
                        qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQuery = this.contFields.add(true, rSysDB.COLUMN_NAME, rSysDB.TABLE_NAME, "", ColumnTranslated,
                                         false, true, rSysDB.DATA_TYPE, ref selRowGrid,
                                         null, ref protocoll,
                                         SchemaSysDB, null, core.Enums.eStayTyp.All, false);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("addIDGuidStayAuto: " + ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               this.edit(true);
           }
           catch (Exception ex)
           {
               qs2.core.generic.getExep(ex.ToString(), ex.Message);
           }
           finally
           {
               this.Cursor = Cursors.Default;
           }
       }

       private void btnCancel_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;

               string protocollForAdmin = "";
               bool ProtocolWindow = false;

               this.loadQueryDefValueChange("loadQuery", ref protocollForAdmin, ref ProtocolWindow);

               if (protocollForAdmin.Trim() != "")
               {
                   qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
               }
           }
           catch (Exception ex)
           {
               qs2.core.generic.getExep(ex.ToString(), ex.Message);
           }
           finally
           {
               this.Cursor = Cursors.Default;
           }
       }

       private void btnClose_Click(object sender, EventArgs e)
       {
           this.mainWindow.Close();
       }

        
      private void btnTestQuery_Click(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;

              string protocollForAdmin = "";
              bool ProtocolWindow = false;

              this.loadQueryDefValueChange("runQuery", ref protocollForAdmin, ref ProtocolWindow);

              if (protocollForAdmin.Trim() != "")
              {
                  qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
              }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }
      public void loadRunQuery(dsAdmin.tblSelListEntriesRow rSelectedSelList,ref string protocollForAdmin, ref bool ProtocolWindow)
      {
          try
          {
              if (this.frmQryRunReport1 == null)
              {
                  this.frmQryRunReport1 = new qs2.ui.print.frmQryRunReport();
                  qs2.core.ENV.lstOpendChildForms.Add(this.frmQryRunReport1);
              }

              this.frmQryRunReport1.Visible = true;
              this.frmQryRunReport1.contQryRunReport1.typRunQuery = qs2.core.Enums.eTypRunQuery.QueryGroups;
              this.frmQryRunReport1.contQryRunReport1.rowGridSelList = this.contSelListQueries.cboQuerySelect.ActiveRow;
              this.frmQryRunReport1.initControl(this.getSelectedApplication(), this.IDParticipant);
              this.frmQryRunReport1.loadRes();
              this.frmQryRunReport1.loadTitleWindow(rSelectedSelList.IDRessource);
              this.frmQryRunReport1.run(null, rSelectedSelList, this.getSelectedApplication(), this.IDParticipant, ref protocollForAdmin, ref ProtocolWindow);
              this.frmQryRunReport1.Show();
              this.frmQryRunReport1.Visible = true;

              //if (this.contFields.rSelList.Sql != "")
              //{
              //    System.Data.DataSet dsResultQuery = qs2.core.dbBase.fillDataSet(this.contFields.rSelList.Sql);
              //    //dsResultQuery.Tables[0].TableName = "ExportTable1";
              //    frmTable frmTable1 = new frmTable();
              //    frmTable1.rSelListEntry = this.contFields.rSelList;
              //    frmTable1.contTable1.ds = dsResultQuery;
              //    frmTable1.IDParticipant = this.IDParticipant;
              //    frmTable1.IDApplication = this.getSelectedApplication();
              //    frmTable1.initControl(qs2.ui.print.contTable.eTypeUI.Query);
              //    frmTable1.Show();
              //}
              //else
              //    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoSqlExists") + "!", MessageBoxButtons.OK, "");

          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }

      private void txtSQL_ValueChanged(object sender, EventArgs e)
      {
          try
          {
              if (this.txtSQL.Focused)
              {
                  this.contFields.rSelList.Sql = (string)this.txtSQL.Text;
                  //if (this.txtSQL.Text  != null)
                  //    this.contFields.rSelList.Sql = (string)this.txtSQL.Text;
                  //else
                  //    this.contFields.rSelList.Sql = "";
              }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }

      private void txtSQL_KeyPress(object sender, KeyPressEventArgs e)
      {
          try
          {
              e.Handled = !this.isInEditMode;
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }

      private void btnClose_Click_1(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;
              this.mainWindow.Close();

          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }

      private void toolbarsManagerControlSelection_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;

              if (e.Tool.Key.Equals(core.Enums.eTypQueryDef.WhereConditions.ToString()) || e.Tool.Key.Equals(core.Enums.eTypQueryDef.Joins.ToString()) || e.Tool.Key.Equals(core.Enums.eTypQueryDef.InputParameters.ToString()))
              {
                  this.ultraTabControlFields.ActiveTab = this.ultraTabControlFields.Tabs[e.Tool.Key];
                  this.ultraTabControlFields.SelectedTab = this.ultraTabControlFields.Tabs[e.Tool.Key];
              }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }
      public void setNumberForSelectedControl(core.Enums.eTypQueryDef typQueryDef, int count)
      {
          try
          {
              string countStr = (count > 0 ? " (" + count.ToString() + ")" : "");
              
              if (typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                    this.toolbarsManagerControlSelection.Tools[qs2.core.Enums.eTypQueryDef.SelectFields.ToString()].SharedProps.Caption = " " + qs2.core.language.sqlLanguage.getRes("Fields") + countStr;
              else if (typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                    this.toolbarsManagerControlSelection.Tools[qs2.core.Enums.eTypQueryDef.InputParameters.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("InputParameters") + countStr;
              else if (typQueryDef == core.Enums.eTypQueryDef.Joins)
                    this.toolbarsManagerControlSelection.Tools[qs2.core.Enums.eTypQueryDef.Joins.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Joins") + countStr;
              else if (typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                    this.toolbarsManagerControlSelection.Tools[qs2.core.Enums.eTypQueryDef.WhereConditions.ToString()].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("Conditions") + countStr;
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }
      private void btnDoAutoJoin_Click(object sender, EventArgs e)
      {
          try
          {
                this.Cursor = Cursors.WaitCursor;
                this.doAutoJoin(true);                
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }
      public void doAutoJoin(bool changeToJoins)
      {
          try
          {
              System.Collections.Generic.List<string> tables = new System.Collections.Generic.List<string>();
              //string sqlTables = "";
              string prot = "";
              
              qs2.sitemap.print.genSql genSql1 = new qs2.sitemap.print.genSql();
              dsAdmin dsAutoJoinsFounded = new dsAdmin();

              if (qs2.core.ENV.autoJoin == 1 || qs2.core.ENV.autoJoin == 3)
              {
                  genSql1.calcJoinStandard(this.contFields.dsAdmin1.tblQueriesDef, this.contConditions.dsAdmin1.tblQueriesDef, ref dsAutoJoinsFounded,
                          ref prot, ref this.contJoins.rSelList);
              }
              if (qs2.core.ENV.autoJoin == 2 || qs2.core.ENV.autoJoin == 3)
              {
                  genSql1.calcJoinTable(this.contFields.dsAdmin1.tblQueriesDef, this.contConditions.dsAdmin1.tblQueriesDef, ref dsAutoJoinsFounded,
                                              ref prot, ref this.contJoins.rSelList);
              }

              DialogResult deleteOldJoins = DialogResult.Yes;
              if (this.typeQuery == qs2.core.Enums.eTypeQuery.User)
              {
                  deleteOldJoins = DialogResult.Yes;
              }
              else if (this.typeQuery == qs2.core.Enums.eTypeQuery.Admin)
              {
                  deleteOldJoins = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DeleteOldJoins") + "?", MessageBoxButtons.YesNo, "");
              }

              if (dsAutoJoinsFounded.tblQueriesDef.Rows.Count > 0)
              {
                  if (changeToJoins)
                  {
                      //if (this.typeQuery == qs2.core.Enums.eTypeQuery.Admin)
                      //{
                          this.ultraTabControlFields.ActiveTab = this.ultraTabControlFields.Tabs[core.Enums.eTypQueryDef.Joins.ToString()];
                          this.ultraTabControlFields.SelectedTab = this.ultraTabControlFields.Tabs[core.Enums.eTypQueryDef.Joins.ToString()];
                          Infragistics.Win.UltraWinToolbars.StateButtonTool statButt = (Infragistics.Win.UltraWinToolbars.StateButtonTool)this.toolbarsManagerControlSelection.Tools[core.Enums.eTypQueryDef.Joins.ToString()];
                          statButt.Checked = true;
                      //}
                  }
                  this.contJoins.doAutoJoins(dsAutoJoinsFounded, deleteOldJoins);
                  //this.edit(true);

                  //this.contFields.rSelList._Table = sqlTables;
              }
              else
              {
                  this.contJoins.doAutoJoins(dsAutoJoinsFounded, deleteOldJoins);
                  if (this.typeQuery == qs2.core.Enums.eTypeQuery.Admin)
                  {
                      qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoJoinsFound") + "!", MessageBoxButtons.OK, "");
                  }
              }

          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }
        
      private void btnManageQuery_Click(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;
              this.addEditQuery(false, null);

          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }
      public void addEditQuery(bool edit, dsAdmin.tblSelListEntriesRow rSelectedQuery)
      {
          try
          {
                if (this.typeQuery == qs2.core.Enums.eTypeQuery.Admin)
                {
                    qs2.sitemap.vb.frmSelLists frmSelListAdd = new qs2.sitemap.vb.frmSelLists();
                    frmSelListAdd.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName;
                    frmSelListAdd.ContSelList1.doAutoRessource = (this.typeQuery == core.Enums.eTypeQuery.Admin ? false : false);
                    frmSelListAdd.ContSelList1.defaultApplication = this.getSelectedApplication();
                    frmSelListAdd.ContSelList1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                    frmSelListAdd.ContSelList1.IDGruppeStr = "Queries";
                    frmSelListAdd.TypeStr = this.typeQuery.ToString();
                    frmSelListAdd.typeUI = (this.typeQuery == core.Enums.eTypeQuery.Admin ? sitemap.vb.frmSelLists.eTypeUI.manageQueriesAdmin : sitemap.vb.frmSelLists.eTypeUI.manageQueriesUser);
                    frmSelListAdd._Private = (this.typeQuery == core.Enums.eTypeQuery.Admin ? false : true);
                    frmSelListAdd.ShowDialog(this);

                    if (frmSelListAdd.ContSelList1.savedClicked)
                    {
                        if (frmSelListAdd.ContSelList1.rSelListLastAdded != null)
                        {
                            this.loadQueries(null, false, false);
                            this.contSelListQueries.loadQueries(frmSelListAdd.ContSelList1.rSelListLastAdded, this.getSelectedApplication(), this.IDParticipant, null, this.getTypeSelListForPrivate(), -999, false);
                            this.contFields.addAutoFields();
                            this.edit(true);
                        }
                        else
                        {
                            this.loadQueries(null, false, false);
                            this.contSelListQueries.loadQueries(null, this.getSelectedApplication(), this.IDParticipant, null, this.getTypeSelListForPrivate(), -999, false);
                        }
                        contQryAdmin.dataChanged = true;
                    }
                }
                else if (this.typeQuery == qs2.core.Enums.eTypeQuery.User)
                {
                    qs2.sitemap.vb.frmAddSelList frmAddSelList1 = new qs2.sitemap.vb.frmAddSelList();
                    frmAddSelList1.ContAddSelList1.typUI = sitemap.vb.contAddSelList.eTypUI.newQueryUser;
                    frmAddSelList1.ContAddSelList1.isNew = !edit;
                    if (edit)
                    {
                        frmAddSelList1.ContAddSelList1.IDSelListToEdit = rSelectedQuery.ID; 
                    }
                    frmAddSelList1.ContAddSelList1.IDApplication = this.getSelectedApplication();
                    frmAddSelList1.ContAddSelList1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                    frmAddSelList1.ContAddSelList1.IDGroupStr = "Queries";
                    frmAddSelList1.ShowDialog(this);

                    if (!frmAddSelList1.ContAddSelList1.abort)
                    {
                        this.loadQueries(null, false, false);
                        this.contSelListQueries.loadQueries(frmAddSelList1.ContAddSelList1.rSelListActuell, this.getSelectedApplication(), this.IDParticipant, null, this.getTypeSelListForPrivate(), -999, false);
                        this.contFields.addAutoFields();
                        this.edit(true);
                        contQryAdmin.dataChanged = true;
                    }
                    else if (frmAddSelList1.ContAddSelList1.bCopy)
                    {
                        this.loadQueries(null, false, false);
                        this.contSelListQueries.loadQueries(frmAddSelList1.ContAddSelList1.rSelListActuell, this.getSelectedApplication(), this.IDParticipant, null, this.getTypeSelListForPrivate(), -999, false);
                        this.contFields.addAutoFields();
                        this.edit(true);
                        contQryAdmin.dataChanged = true;
                    }

                }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }
      private void comboApplication1_evOnChange(string selectedApplication)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;
              this.loadQueries(null, true, true);
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }

      public void ExtendedView(bool bOn)
      {
          this.toolbarsManagerControlSelection.Tools[core.Enums.eTypQueryDef.Joins.ToString()].SharedProps.Visible = bOn;
          this.toolbarsManagerControlSelection.Tools[core.Enums.eTypQueryDef.InputParameters.ToString()].SharedProps.Visible = bOn;
      }

      private void extendedViewToolStripMenuItem_Click(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;
              this.ExtendedView(extendedViewToolStripMenuItem.Checked);
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }

      private void btnDeleteQuery_Click(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;

              dsAdmin.tblSelListEntriesRow rSelectedQuery = this.contSelListQueries.getSelectedQuery(true);
              if (rSelectedQuery != null)
              {
                  this.deleteQuery(rSelectedQuery);
              }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }
      public void deleteQuery(dsAdmin.tblSelListEntriesRow rSelectedQuery)
      {
          try
          {
            if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DeleteRecord"), MessageBoxButtons.YesNo, "")  == DialogResult.Yes)
            {
                this.sqlAdmin1.deleteSelListEntryObj(rSelectedQuery.ID);
                this.sqlAdmin1.deleteSelListEntrySublistObj(rSelectedQuery.ID);
                this.sqlAdmin1.deleteSelListEntry(rSelectedQuery.ID);
           
                this.contFields.clear();
                this.contInputParemeters.clear();
                this.contConditions.clear();
                this.contJoins.clear();

                this.contFields.rSelList = null;
                this.contInputParemeters.rSelList = null;
                this.contConditions.rSelList = null;
                this.contJoins.rSelList = null;

                this.contSelListQueries.loadQueries(null, this.getSelectedApplication(), this.IDParticipant, null, this.getTypeSelListForPrivate(), -999, false);
                contQryAdmin.dataChanged = true;
            }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
      }

      private void btnEditQuery_Click(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;
              dsAdmin.tblSelListEntriesRow rSelectedQuery = this.contSelListQueries.getSelectedQuery(true);
              if (rSelectedQuery != null)
              {
                  this.addEditQuery(true, rSelectedQuery);
              }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }

      private void exportToTSqlToolStripMenuItem_Click(object sender, EventArgs e)
      {
          try
          {
                this.Cursor = Cursors.WaitCursor;
                
                dsAdmin.tblSelListEntriesRow rQueryToExport = this.contSelListQueries.getSelectedQuery(true);
                if (rQueryToExport != null)
                {
                    qs2.print.exportTSQL exportTSql1 = new qs2.print.exportTSQL();
                    StringBuilder sbResultSkript = new StringBuilder();
                    exportTSql1.AppendTitle(sbResultSkript);
                    int counter = 1;
                    exportTSql1.ExportQuery(rQueryToExport, this.getSelectedApplication(), ref sbResultSkript, true, ref counter);
                }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
      }

      private void exportAllQueriesToTSqlToolStripMenuItem_Click(object sender, EventArgs e)
      {
          try
          {
              this.Cursor = Cursors.WaitCursor;

              System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstSelLists = this.contSelListQueries.getAllQueries();
              if (lstSelLists.Count > 0)
              {
                  qs2.print.exportTSQL exportTSql1 = new qs2.print.exportTSQL();
                  StringBuilder sbResultSkript = new StringBuilder();
                  exportTSql1.ExportQueries(ref lstSelLists, this.getSelectedApplication());
              }
              else
              {
                  qs2.core.generic.showMessageBox("No Queries found" + "!", MessageBoxButtons.OK, "");
              }
          }
          catch (Exception ex)
          {
              qs2.core.generic.getExep(ex.ToString(), ex.Message);
          }
          finally
          {
              this.Cursor = Cursors.Default;
          }
        }
           
        private void btnUserRights_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                  
                dsAdmin.tblSelListEntriesRow rSelectedQuery = this.contSelListQueries.getSelectedQuery(true);
                if (rSelectedQuery != null)
                {
                    qs2.sitemap.vb.frmUserSelList frmUserSelList1 = new qs2.sitemap.vb.frmUserSelList();
                    string sTransNameQuery = qs2.core.language.sqlLanguage.getRes(rSelectedQuery.IDRessource.Trim());
                    string TitleWindow = qs2.core.language.sqlLanguage.getRes("RightsQueries") + " - " + sTransNameQuery;
                    frmUserSelList1.initControl(rSelectedQuery.ID, this.getSelectedApplication().Trim (), sTransNameQuery.Trim(), TitleWindow);
                    frmUserSelList1.ShowDialog(this);
                    if (!frmUserSelList1.ContUserSelList1.abort)
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }

}