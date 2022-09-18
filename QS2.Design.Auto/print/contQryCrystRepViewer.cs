using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;





namespace qs2.ui.print
{
    public partial class contQryCrystRepViewer : UserControl
    {

        public System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar;
        public qs2.ui.print.infoReport infoReport;

        public qs2.print.genReport genReport1 = new qs2.print.genReport();
        
        public frmCryCrystRepViewer mainWindow;
        public ReportDocument reportDocument1;
        public string reportFile = "";
        public string reportFileFR = "";

        public string Protocoll = "";
        public string ProtocollTitle = "";
        public string ProtocollText = "";
        public int ProtocollCounter = 0;
        






        public contQryCrystRepViewer()
        {
            InitializeComponent();
        }

        private void contQryCrystRepViewer_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.mainWindow.CancelButton = this.btnClose;

                this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.crystalReportViewer1.DoubleClickPage += new CrystalDecisions.Windows.Forms.PageMouseEventHandler(this.CRReportViewer_PageDoubleClick);

                this.doRes();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doRes()
        {
            try
            {
                this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");
                this.openGeneratedSqlStatementToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("OpenGeneratedSqlStatement");
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        public void doReport()
        {
            try
            {
                this.reportFile = System.IO.Path.Combine(qs2.core.ENV.path_reports, this.infoReport.Application, this.infoReport.rSelListReport.IDRessource + qs2.core.vb.funct.fileTypeCrystReport);
                if (System.IO.File.Exists(this.reportFile))
                {
                    //string fildDB = qs2.core.ENV.path_reports + "\\" + this.IDApplication + "\\" + this.rSelListEntryReport.IDRessource + ".xsd";
                    //this.ds.WriteXmlSchema (fildDB);
                    
                    this.reportDocument1 = new ReportDocument();
                    this.reportDocument1.Load(this.reportFile);
                    this.crystalReportViewer1.ReportSource = this.reportDocument1;
                    this.translateReport(this.reportDocument1, false, "", true, ref this.lstInfoQryRunPar);

                    this.genReport1.LogOnCrystReport(this.reportDocument1, this.lstInfoQryRunPar, false);
                    this.genReport1.doParametersCrystRep(this.lstInfoQryRunPar, this.reportDocument1);
                    this.translateReport(this.reportDocument1, false, "", false, ref this.lstInfoQryRunPar);
                    //this.crystalReportViewer1.RefreshReport();
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ReportFileNotExist") + "!" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + 
                                                            this.reportFile, MessageBoxButtons.OK, "");
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void translateReport(ReportDocument report, bool isSubreport, string nameSubreport, bool setPictures, ref System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar)
        {
            try
            {
                foreach (ReportObject repObj in report.ReportDefinition.ReportObjects)
                {
                    //string nameObj = repObj.Name;
                    //if (nameObj == "pic2")
                    //{
                    //    string xyxyx = "";
                    //}
                    string typeStr = repObj.GetType().ToString();

                    if (!setPictures)
                    {
                        //if (repObj.Name.ToLower().Contains(("Surgeon_XClamp").Trim().ToLower()))
                        //{
                        //    string xy = "";
                        //}

                        if (repObj.GetType().Equals(typeof(TextObject)))
                        {
                            TextObject TextObject1 = (TextObject)repObj;
                            string name = TextObject1.Name;
                            string txt = TextObject1.Text;
                            TextObject1.Text = this.translateTxtObject(txt);
                        }
                        else if (repObj.GetType().Equals(typeof(FieldObject)))
                        {
                            FieldObject FieldObject1 = (FieldObject)repObj;
                            string name = FieldObject1.Name;
                        }
                        else if (repObj.GetType().Equals(typeof(FieldHeadingObject)))
                        {
                            FieldHeadingObject FieldHeadingObject1 = (FieldHeadingObject)repObj;
                            //string name = FieldHeadingObject1.Name;
                            //string txt = FieldHeadingObject1.Text;
                            //System.Collections.Generic.List<string> lstIDResFound = new System.Collections.Generic.List<string>();
                            //FieldHeadingObject1.Text = qs2.core.language.translate.translateText(ref txt, this.infoReport.Application, this.infoReport.Participant, ref lstIDResFound);
                        }
                        //else if (repObj.GetType().Equals(typeof(CrystalDecisions.CrystalReports.Engine.PictureObject)))
                        //{
                        //    CrystalDecisions.CrystalReports.Engine.PictureObject PictureObject1 = (CrystalDecisions.CrystalReports.Engine.PictureObject)repObj;
                        //    this.setPicture(PictureObject1.Name, PictureObject1);
                        //}
                        else if (repObj.GetType().Equals(typeof(ChartObject)))
                        {
                            ChartObject ChartObject1 = (ChartObject)repObj;
                        }
                    }
                    else
                    {
                        if (repObj.GetType().Equals(typeof(TextObject)))
                        {
                            TextObject TextObject1 = (TextObject)repObj;
                            if (TextObject1.Name.Trim() == "pictures")
                            {
                                string txt = TextObject1.Text;
                                System.Collections.Generic.List<string> lstIDResFound = new System.Collections.Generic.List<string>();
                                TextObject1.Text = this.translateTxtObject(txt);

                                qs2.ui.print.infoQry infoQry1 = this.genReport1.getDBForSubreport(lstInfoQryRunPar, nameSubreport);
                                if (infoQry1 != null)
                                {
                                    foreach (string IDResPicture in lstIDResFound)
                                    {
                                        this.setPicture(IDResPicture, infoQry1.dsQryResult);
                                    }
                                }

                            }
                        }
                    }
                }

                if (!isSubreport)
                {
                    foreach (ReportDocument subreport in report.Subreports)
                    {
                        //SubreportObject SubreportObject1 = (SubreportObject)repObj;
                        this.translateReport(subreport, true, subreport.Name, setPictures, ref lstInfoQryRunPar);
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public string translateTxtObject(string txtToTranslate)
        {
            try
            {
                System.Collections.Generic.List<string> lstIDResFound = new System.Collections.Generic.List<string>();
                string TxtTranslated = "";
                if (txtToTranslate.Trim().ToLower().StartsWith(("[lr_").Trim().ToLower()))
                {

                    string IDResToTranslate = "";
                    IDResToTranslate = "[" + txtToTranslate.Trim().Substring(4, txtToTranslate.Trim().Length - 4);
                    TxtTranslated = qs2.core.language.doLanguage.translateText(ref IDResToTranslate, this.infoReport.Application,
                                                                    this.infoReport.Participant, ref lstIDResFound,
                                                                    qs2.core.Enums.eResourceType.LabelRight);
                }
                else
                {
                    TxtTranslated = qs2.core.language.doLanguage.translateText(ref txtToTranslate, this.infoReport.Application,
                                                                    this.infoReport.Participant, ref lstIDResFound,
                                                                    core.Enums.eResourceType.Label);

                }
                //if (TxtTranslated.Trim() == "")
                //{
                //    //TxtTranslated = TextObject1.Name;
                //    string xy = "";
                //}
                return TxtTranslated.Trim();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return "";
            }
        }

        public void setPicture(string IDRes, System.Data.DataSet dsQryAuto1)
        {
            try
            {
                qs2.core.print.dsQryAuto dsQryAutoTemp = new qs2.core.print.dsQryAuto();
                System.Data.DataTable dtPictures = dsQryAuto1.Tables[dsQryAutoTemp.pictures.TableName];
                qs2.core.vb.doDB.addPictureDataToDataset(IDRes, core.Enums.eResourceType.PictureEnabled,
                                                        dtPictures,
                                                        this.infoReport.Application, this.infoReport.Participant);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
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

        private void openGeneratedSqlStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string sqlAll = "";
                foreach (qs2.ui.print.infoQry infoQry1 in this.lstInfoQryRunPar)
                {
                    if (!infoQry1.isSubQuery)
                    {
                        sqlAll += qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + infoQry1.rSelListQry.IDRessource + ": " + qs2.core.generic.lineBreak + infoQry1.Sql;
                        sqlAll += this.genReport1.getParametersStr(infoQry1.parametersSql);
                    }
                }
                this.genReport1.openSQLStatment(sqlAll, "Sql");
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

        private void lblProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                frmProtocol frmProtocol1 = new frmProtocol();
                frmProtocol1.initControl();
                frmProtocol1.Text = this.ProtocollTitle;
                qs2.core.ENV.lstOpendChildForms.Add(frmProtocol1);
                frmProtocol1.Show();
                frmProtocol1.ContProtocol1.setText(this.ProtocollText);

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

        private void CRReportViewer_PageDoubleClick(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.ObjectInfo.ObjectType == CrystalDecisions.Windows.Forms.ObjectType.DatabaseField)
                {
                    if (e.ObjectInfo.Text != null)
                    {
                        if (e.ObjectInfo.Text.Trim() != "")
                        {
                            int IDStay = -999;
                            try
                            {
                                IDStay = System.Convert.ToInt32(e.ObjectInfo.Text.Trim().Replace(".", ""));
                            }
                            catch(Exception ex)
                            {
                                try
                                {
                                    string xy = ex.ToString();
                                    IDStay = System.Convert.ToInt32(e.ObjectInfo.Text.Trim().Replace(",", ""));
                                }
                                catch(Exception ex2)
                                {
                                    string sExcept = ex2.ToString();
                                }
                            }
                            if (IDStay != -999)
                            {
                                this.openStay(false, IDStay, this.infoReport.Application.Trim(), this.infoReport.Participant.Trim());
                            }
                        }
                    }
                }

                //string msg = "Report Object: " + e.ObjectInfo.Name.ToString() + " (" + e.ObjectInfo.ObjectType.ToString() + ")";
                //if (e.ObjectInfo.Text != null)
                //{
                //    msg += "... Text: " + e.ObjectInfo.Text.ToString();
                //}
                //MessageBox.Show(msg);

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
        public bool openStay(bool showMsgBox, int IDStay, string Application, string IDParticipant)
        {
            try
            {
                qs2.core.db.ERSystem.businessFramework b = new core.db.ERSystem.businessFramework();
                QS2.db.Entities.tblStay rStay = b.checkIsStay(IDStay, Application.Trim(), IDParticipant.Trim());
                if (rStay != null)
                {
                    qs2.core.ENV.cParsCalMainFunction pars = new qs2.core.ENV.cParsCalMainFunction();
                    pars.IDGuidStay = rStay.IDGuid;
                    pars.IDApplication = rStay.IDApplication.Trim();
                    pars.StayTyp = (qs2.core.Enums.eStayTyp)rStay.StayTyp;
                    pars.newStay = false;
                    qs2.core.ENV.CallFunctionMain(core.ENV.eTypeFunction.loadStay, pars);
                    return true;
                }

                if (showMsgBox)
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoStayInfoFoundInQuery") + "!", MessageBoxButtons.OK, "");
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("contQryCrystRepViewer.openStay: " + ex.ToString());
            }
        }

    }
}
