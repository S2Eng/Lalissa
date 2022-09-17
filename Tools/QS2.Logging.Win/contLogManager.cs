using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QS2.Resources;





namespace QS2.Logging
{
    public partial class contLogViewer : System.Windows.Forms.UserControl
    {

        private string _db = "";
        private QS2.functions.vb.funct clString = new QS2.functions.vb.funct();

        public QS2.Logging.frmLogManager mainWindow = null;




       

        public contLogViewer()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            try
            {
                this.previewOnOff(chkVorschau.Checked);

                this.btnSuche.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche , 32, 32 );
                this.btnLogOpen.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Ordner, 32, 32);
                this.btnSaveAs.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32 );
                this.btnRefresh.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren , 32, 32 );

                this.loadRes();

                this.loadDB();
                this.openDefaultErrFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        public void loadRes()
        {
            try
            {
                this.btnClose2.Text =  "Close";
                this.lblLogOrdnerÖffnen.Text =  "Open log-folder";
                this.lblGesamteDatenbankVersenden.Text =  "Send database";
                this.lblMeldungVersenden.Text =  "SendMessage";
                this.lblAlleMeldungenKopieren.Text =  "Copy all messages";
                this.lblCopyMessage.Text =  "Copy message";
                this.lblDatabases.Text =  "Databases";

                this.chkVorschau.Text =  "Preview-mode";
                this.lblSearch.Text =  "Search";

                Infragistics .Win.UltraWinToolTip .UltraToolTipInfo infoTooltip = new Infragistics .Win.UltraWinToolTip .UltraToolTipInfo ();
                infoTooltip.ToolTipText = "";
                infoTooltip.ToolTipTitle  =  "Refresh";
                this.ultraToolTipManager1.SetUltraToolTip(this.btnRefresh, infoTooltip);

                infoTooltip = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                infoTooltip.ToolTipText = "Open";
                infoTooltip.ToolTipTitle = "";
                this.ultraToolTipManager1.SetUltraToolTip(this.btnLogOpen, infoTooltip);

                infoTooltip = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                infoTooltip.ToolTipText =  "Save as";
                infoTooltip.ToolTipTitle = "";
                this.ultraToolTipManager1.SetUltraToolTip(this.btnSaveAs , infoTooltip);

                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.titleColumn .ColumnName].Header.Caption =  "Message";
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.errorColumn.ColumnName].Header.Caption =  "Message-detail";
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.typColumn.ColumnName].Header.Caption =  "Type";
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.usrColumn .ColumnName].Header.Caption =  "User";
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.fromColumn.ColumnName].Header.Caption =  "Date";

                this.ultraGrid1.DisplayLayout.GroupByBox.Prompt = "Drag a columne to group by ...";
                
            }
            catch (Exception ex)
            {
                QS2.functions.vb.funct.getExcept(ex.ToString(), "");
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.mainWindow.Close();
        }

        private void btnLogOpen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!System.IO.Directory.Exists(QS2.Logging.ENV._path_log))
                { System.IO.Directory.CreateDirectory(QS2.Logging.ENV._path_log); }
                string fil = clString.selectFile(false, QS2.functions.vb.funct.typLogFile, QS2.Logging.ENV._path_log);
                if (fil != "")
                {
                    this.dsLog1.tblLog.Rows.Clear();
                    this.dsLog1.ReadXml(fil);
                    this.ultraGrid1.Refresh();
                    this.ultraGrid1.Selected.Rows.Clear();
                    this.ultraGrid1.ActiveRow = null;
                    this.Text = "Log-manager" + " [" + "Log-file" + ": " + fil + "]";

                    this._db = fil;
                    this.loadDB();

                    this.cboDB.Value = null ;
                    string aktDat = clString.getFileName(fil, false);
                    foreach ( Infragistics.Win.ValueListItem  itm  in this.cboDB.Items  )
                    {
                        if (itm.DisplayText == aktDat)
                        {
                            this.cboDB.Text  = itm.DisplayText;
                        }
                    }

                    this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(this.dsLog1.tblLog.fromColumn.ColumnName, true);
                    this.setLableFounded();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default ;
            }
        }

        private void openDefaultErrFile( )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!System.IO.Directory.Exists(QS2.Logging.ENV._path_log))
                {
                    System.IO.Directory.CreateDirectory(QS2.Logging.ENV._path_log);
                }

                string hostName = System.Net.Dns.GetHostName();
                if (hostName == "") hostName = System.Guid.NewGuid().ToString();
                string errFile = QS2.Logging.ENV._path_log + "\\log_" + System.Net.Dns.GetHostName() + ".xml";

                if (System.IO.File.Exists(errFile))
                {
                    this.dsLog1.ReadXml(errFile);
                    this.ultraGrid1.Refresh();
                    this.ultraGrid1.Selected.Rows.Clear();
                    this.ultraGrid1.ActiveRow = null;
                    this.Text = "Log-manager" + " [" + "Logfile" + ": " + errFile + "]";
                    this.cboDB.Text = clString.getFileName(errFile, false);
                    this._db = errFile;

                    this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(this.dsLog1.tblLog.fromColumn.ColumnName , true);
                    this.setLableFounded();
                }
                else
                {
                    this.Text = "Log-manager" + " [" + "Log-path" + ": " + QS2.Logging.ENV._path_log + "]";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.txtSuche.Focus();
                this.Cursor = Cursors.Default;
            }
        }
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string fil = clString.saveFile(false, QS2.functions.vb.funct.typLogFile, QS2.Logging.ENV._path_log);
                if (fil != null )
                {
                    dsLog1.WriteXml(fil);
                    MessageBox.Show("Logfile saved!", "Save log-file");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chkVorschau_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.previewOnOff(chkVorschau.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void previewOnOff(bool bOn)
        {
            if (bOn)
            {
                this.ultraGrid1.DisplayLayout.Bands[0].AutoPreviewEnabled = true;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.errorColumn.ColumnName].Hidden = true;
                this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.ultraGrid1.DisplayLayout.Bands[0].AutoPreviewEnabled = false;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[this.dsLog1.tblLog.errorColumn.ColumnName].Hidden = false;
                this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
        }

        private void txtSuche_Leave(object sender, EventArgs e)
        {
  
        }

        private void txtSuche_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSuche_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //dsLog.tblLogRow[] prows;
                //prows = (dsLog.tblLogRow[])this.dsLog1.tblLog.Select("error = '" + txtSuche.Text + "' or title ='" + txtSuche.Text + "'");
                
                this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters[dsLog1.tblLog .errorColumn .ColumnName ].ClearFilterConditions();
                this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters[dsLog1.tblLog.titleColumn .ColumnName].ClearFilterConditions();
                if (this.txtSuche.Text != "")
                {
                    this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters[dsLog1.tblLog.errorColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Contains , this.txtSuche.Text);
                    //this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters[dsLog1.tblLog.titleColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, this.txtSuche.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UFormLinkZurücksetzen_Click(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveRow != null)
            {
                Clipboard.SetDataObject((string)this.ultraGrid1.ActiveRow.Cells[dsLog1.tblLog.errorColumn.ColumnName].Value, true);
            }
            else
            {
                MessageBox.Show("No record", "QS2");
            }
            
        }

        private void lblAlleMeldungenKopieren_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string prot = "";
            foreach (QS2.Logging.dsLog.tblLogRow r in this.dsLog1.tblLog)
            {
                prot += r.error + QS2.functions.cs.funct.lineBreak;
            }
            Clipboard.SetDataObject(prot, true);

            this.Cursor = Cursors.Default;
        }

        private void cboDatenbanken_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void cboDatenbanken_ValueChanged(object sender, EventArgs e)
        {
            if (this.cboDB.Focused)
            {
                this.loadDB();
            }
        }
        
        private void loadDB()
        {
                this.Cursor = Cursors.WaitCursor;
                
                this.cboDB.Items.Clear  ();

                foreach (string db in System.IO.Directory.GetFiles(QS2.Logging.ENV._path_log))
                {
                    if (clString.getFiletyp(db) == ".xml")
                        this.cboDB.Items.Add(db, clString.getFileName(db, false));
                }
                this.Cursor = Cursors.Default;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.btnRefresh.Focused)
            {
                this.loadDB();
             }
        }

        private void cboDB_ValueChanged(object sender, EventArgs e)
        {
            if (this.cboDB.Focused)
            {
                this.Cursor = Cursors.WaitCursor;

                this.dsLog1.tblLog.Rows.Clear();
                this.dsLog1.ReadXml((string )cboDB.Value);
                this.ultraGrid1.Refresh();  
                this.ultraGrid1.Selected.Rows.Clear();
                this.ultraGrid1.ActiveRow = null;
                this.Text = "Log-manager" + " [" + "Log-file" + ": " + (string)cboDB.Value + "]";
                this._db = (string)cboDB.Value;

                this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(this.dsLog1.tblLog.fromColumn.ColumnName, true);
                this.setLableFounded();

                this.Cursor = Cursors.Default;
            }
        }

        private void setLableFounded()
        {
            this.lblFound.Text = "Found: " + this.ultraGrid1.Rows.Count.ToString();
        }
        private void lblLogOrdnerÖffnen_Click(object sender, EventArgs e)
        {
            QS2.functions.cs.funct.openWindowsExplorer(QS2.Logging.ENV._path_log);
        }

        private void testExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Test-exception from QS2.Logging.Win.dll");
            }
            catch (Exception ex)
            {
                frmError frmErr = new frmError();
                frmErr.setData("Test-exception", ex.ToString(), "QS2.Logging.Win.dll", true);
                frmErr.ShowDialog();
            }
        }


    }
}
