using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinGrid;

using Infragistics.Win.UltraWinToolTip;




namespace QS2.Logging.Win
{

    public partial class contLogManager2 : UserControl
    {

        public frmLogManager2 mainWindow = null;
        private QS2.functions.vb.FileFunctions clString = new QS2.functions.vb.FileFunctions();

        public dsLog2.tblLog2Row rLogSel2Last = null;

        public contLogManager2()
        {
            InitializeComponent();
        }


        private void contLogManager2_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw new Exception("contLogManager2.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                if (QS2.Logging.ENV._path_log.Trim() == "")
                {
                    throw new Exception("contLogManager2.loadData: QS2.Logging.ENV._path_log.Trim()='' not allowed!");
                }

                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.SelectedPath = QS2.Logging.ENV._path_log.Trim();
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        this.lblInfo.Text = "";
                        this.dsLog21.Clear();
                        this.gridLogs.Refresh();

                        int iFileCounter = 0;
                        string[] files = Directory.GetFiles(fbd.SelectedPath);
                        foreach (string sFile in files)
                        {
                            FileInfo info = new FileInfo(sFile.Trim());
                            if (info.Extension.Trim().ToLower().Equals((".logQS2").Trim().ToLower()))
                            {
                                iFileCounter += 1;
                                this.setLblInfo("Reading file " + info.Name.Trim() + " (" + iFileCounter.ToString() + ")");
                                dsLog2.tblLog2Row rNewLog = null;
                                bool bIsText = false;
                                string sLine = "";
                                System.IO.StreamReader srFile = new System.IO.StreamReader(sFile.Trim());
                                while ((sLine = srFile.ReadLine()) != null)
                                {
                                    bool bLineAdded = false;
                                    if (bIsText && !sLine.Trim().ToLower().Trim().StartsWith(("<Type>").Trim().ToLower()))
                                    {
                                        rNewLog.Text += sLine.Trim() + "\r\n";
                                        bLineAdded = true;
                                    }
                                    else if (bIsText && sLine.Trim().ToLower().Trim().StartsWith(("<Type>").Trim().ToLower()))
                                    {
                                        bIsText = false;
                                    }
                                    if (sLine.Trim() != "" && !bLineAdded)
                                    {
                                        Nullable<DateTime> dValueDat = null;
                                        if (sLine.Trim().ToLower().Trim().StartsWith(("<Entry>").Trim().ToLower()))
                                        {
                                            rNewLog = this.getNewRowLog(this.dsLog21);
                                            rNewLog.FileName = info.Name;
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<EndEntry>").Trim().ToLower()))
                                        {
                                            bool bRowEnd = true;
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<Time>").Trim().ToLower()))
                                        {
                                            string sValueRet = this.loadFieldFromFile("<Time>", ref sLine, true, ref dValueDat);
                                            rNewLog.Time = dValueDat.Value;
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<Machine>").Trim().ToLower()))
                                        {
                                            string sValueRet = this.loadFieldFromFile("<Machine>", ref sLine, false, ref dValueDat);
                                            rNewLog.MachineName = sValueRet.Trim();
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<IPAdress>").Trim().ToLower()))
                                        {
                                            string sValueRet = this.loadFieldFromFile("<IPAdress>", ref sLine, false, ref dValueDat);
                                            rNewLog.IDAdress = sValueRet.Trim();
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<User>").Trim().ToLower()))
                                        {
                                            string sValueRet = this.loadFieldFromFile("<User>", ref sLine, false, ref dValueDat);
                                            rNewLog.User = sValueRet.Trim();
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<Text>").Trim().ToLower()))
                                        {
                                            bIsText = true;
                                            string sValueRet = this.loadFieldFromFile("<Text>", ref sLine, false, ref dValueDat);
                                            rNewLog.Text = sValueRet.Trim();
                                        }
                                        else if (sLine.Trim().ToLower().Trim().StartsWith(("<Type>").Trim().ToLower()))
                                        {
                                            string sValueRet = this.loadFieldFromFile("<Type>", ref sLine, false, ref dValueDat);
                                            rNewLog.Type = sValueRet.Trim();
                                        }
                                        else
                                        {
                                            throw new Exception("loadData: Line '" + sLine.Trim() + "' not allowed!");
                                        }
                                    }
                                }

                                srFile.Close();
                            }
                        }

                        this.gridLogs.Refresh();
                        this.setLblInfo(iFileCounter.ToString() + " Log-files imported");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contLogManager2.loadLog: " + ex.ToString());
            }
        }
        public void setLblInfo(string Txt)
        {
            try
            {
                this.lblInfo.Text = Txt;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                throw new Exception("contLogManager2.setLblInfo: " + ex.ToString());
            }
        }
        public string loadFieldFromFile(string TypeVar, ref string sLine, bool isDate, ref Nullable<DateTime> dValueDat)
        {
            try
            {
                int iPosStart = sLine.Trim().IndexOf(TypeVar.Trim());
                if (iPosStart == -1)
                {
                    throw new Exception("loadFieldFromFile: iPosStart=-1 not allod for sLine '" + sLine.Trim() + "' and TypeVar '" + TypeVar.Trim() + "'!");
                }

                string sValue = sLine.Trim().Substring(iPosStart + TypeVar.Trim().Length, sLine.Trim().Length - TypeVar.Trim().Length);
                if (isDate)
                {
                    DateTime datTmp;
                    if (DateTime.TryParse(sValue.Trim(), out datTmp))
                    {
                        dValueDat = datTmp;
                    }
                    else
                    {
                        throw new Exception("contLogManager2.loadFieldFromFile: Error DateTime.TryParse(sValue.Trim(), out datTmp) for sLine '" + sLine.Trim() + "'!");
                    }
                    //sValueDat = Convert.ToDateTime(sValue.Trim());
                }

                return sValue.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("contLogManager2.loadFieldFromFile: " + ex.ToString());
            }
        }

        public dsLog2.tblLog2Row getNewRowLog(dsLog2 ds)
        {
            try
            {
                dsLog2.tblLog2Row rNew = (dsLog2.tblLog2Row)ds.tblLog2.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.SetTimeNull();
                rNew.MachineName = "";
                rNew.IDAdress = "";
                rNew.User = "";
                rNew.Text = "";
                rNew.Type = "";
                rNew.FileName = "";

                ds.tblLog2.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("contLogManager2.getNewRowLog: " + ex.ToString());
            }
        }



        public dsLog2.tblLog2Row getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridLogs.ActiveRow != null)
                {
                    if (this.gridLogs.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) System.Windows.Forms.MessageBox.Show("No row selected!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridLogs.ActiveRow.ListObject;
                        dsLog2.tblLog2Row rSelRow = (dsLog2.tblLog2Row)v.Row;
                        gridRow = this.gridLogs.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) System.Windows.Forms.MessageBox.Show("No row selected!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contLogManager2.getSelectedRow: " + ex.ToString());
            }
        }

        

        private void gridLogs_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public bool evClickOK(ref object sender, ref EventArgs e, UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }
        public bool evDoubleClickOK(ref object sender, ref EventArgs e, UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }



        private void gridLogs_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridLogs))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    dsLog2.tblLog2Row rLogSel = this.getSelectedRow(false, ref gridRow);
                    if (rLogSel != null)
                    {

                    }

                    if (this.gridLogs.ActiveRow.IsGroupByRow)
                    {
                        if (this.gridLogs.ActiveRow.ChildBands.HasChildRows)
                        {
                            UltraGridRow FirstChildRow = this.gridLogs.ActiveRow.GetChild(ChildRow.First);
                            DataRowView v = (DataRowView)FirstChildRow.ListObject;
                            dsLog2.tblLog2Row rLogSel2 = (dsLog2.tblLog2Row)v.Row;

                            if (this.rLogSel2Last == null || (this.rLogSel2Last != null && !this.rLogSel2Last.ID.Equals(rLogSel2.ID)))
                            {
                                //FirstChildRow.ToolTipText = rLogSel2.Text.Trim();

                                if (this.chkTooltip.Checked)
                                {
                                    UltraToolTipInfo info = new UltraToolTipInfo();
                                    info.ToolTipText = rLogSel2.Text;
                                    this.ultraToolTipManager1.SetUltraToolTip(this.gridLogs, info);
                                    this.ultraToolTipManager1.ShowToolTip(this.gridLogs);

                                    this.rLogSel2Last = rLogSel2;
                                }
                            }
                            else
                            {
                                this.rLogSel2Last = null;
                                this.ultraToolTipManager1.HideToolTip();
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }
        private void gridLogs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridLogs))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    dsLog2.tblLog2Row rLogSel = this.getSelectedRow(false, ref gridRow);
                    if (rLogSel != null)
                    {
                        frmErrorDetail frmErrorDetail1 = new frmErrorDetail();
                        frmErrorDetail1.initControl();

                        frmErrorDetail1.txtTime.Text = rLogSel.Time.ToString();
                        frmErrorDetail1.txtMachineName.Text = rLogSel.MachineName.Trim();
                        frmErrorDetail1.txtUser.Text = rLogSel.User.Trim();
                        frmErrorDetail1.txtText.Text = rLogSel.Text.Trim();
                        frmErrorDetail1.txtType.Text = rLogSel.Type.Trim();

                        frmErrorDetail1.Show();
                    }

                    if (this.gridLogs.ActiveRow.IsGroupByRow)
                    {
                        if (this.gridLogs.ActiveRow.ChildBands.HasChildRows)
                        {
                            UltraGridRow FirstChildRow = this.gridLogs.ActiveRow.GetChild(ChildRow.First);
                            DataRowView v = (DataRowView)FirstChildRow.ListObject;
                            dsLog2.tblLog2Row rLogSel2 = (dsLog2.tblLog2Row)v.Row;

                            //FirstChildRow.ToolTipText = rLogSel2.Text.Trim();

                            //frmErrorDetail frmErrorDetail1 = new frmErrorDetail();
                            //frmErrorDetail1.initControl();

                            //frmErrorDetail1.txtTime.Text = rLogSel2.Time.ToString();
                            //frmErrorDetail1.txtMachineName.Text = rLogSel2.MachineName.Trim();
                            //frmErrorDetail1.txtUser.Text = rLogSel2.User.Trim();
                            //frmErrorDetail1.txtText.Text = rLogSel2.Text.Trim();
                            //frmErrorDetail1.txtType.Text = rLogSel2.Type.Trim();

                            //frmErrorDetail1.Show();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }
        private void gridLogs_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.Cancel = false;
                e.DisplayPromptMsg = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }


        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSaveAsXML2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string sPathTmpDefault = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fil = this.clString.saveFile(false, QS2.functions.vb.FileFunctions.typLogFile, "", sPathTmpDefault);
                if (fil != null)
                {
                    this.dsLog21.WriteXml(fil);
                    MessageBox.Show("Data saved!", "Export to XML");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
