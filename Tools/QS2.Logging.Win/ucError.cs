using System;
using System.IO;
using System.Windows.Forms;

namespace QS2.Logging
{

    public partial class ucError : System.Windows.Forms.UserControl
    {
        private const string lineBreak = "\r\n";
        private System.Guid _id;
        private QS2.Logging.dsLog.tblLogRow rNewError1;
        private string hostName2 = "";
        private string TxtInfo = "";
        private string fld_title = "";
        private string fld_usr = "";
        private string fld_from = "";
        private string fld_error = "";

        public frmError modalWindow;
        public bool germanTxt;

        public ucError()
        {
            InitializeComponent();
        }
        
        private void frmError_Load(object sender, EventArgs e)
        {
            this.ultraGridBagLayoutPanelExept.Visible = false;
        }

        public void setData(string title, string exep, string usr, bool WriteDataToXML)
        {
            try
            {
                this._id = System.Guid.NewGuid();
                this.lblExept.Value = exep;

                string errFile = "";
                try
                {
                    this.hostName2 = System.Net.Dns.GetHostName();

                    DateTime dNow = System.DateTime.Now;
                    this.fld_title = title;
                    this.fld_usr = usr;
                    this.fld_from = dNow.ToString();
                    this.fld_error = exep;

                    if (WriteDataToXML)
                    {
                        if (!System.IO.Directory.Exists(QS2.Logging.Settings._path_log))
                        {
                            System.IO.Directory.CreateDirectory(QS2.Logging.Settings._path_log);
                        }

                        if (this.hostName2.Trim() == "") hostName2 = System.Guid.NewGuid().ToString();
                        errFile = QS2.Logging.Settings._path_log + "\\log_" + this.hostName2 + ".xml";
                        QS2.Logging.dsLog ds = new QS2.Logging.dsLog();
                        if (!System.IO.File.Exists(errFile))
                        { ds.WriteXml(errFile); }
                        ds.ReadXml(errFile);
                        this.rNewError1 = ds.tblLog.NewtblLogRow();
                        this.rNewError1.id = this._id;
                        this.rNewError1.title = title;
                        this.rNewError1.error = exep;
                        this.rNewError1.usr = usr;
                        this.rNewError1.from = dNow;
                        ds.tblLog.Rows.Add(this.rNewError1);
                        ds.WriteXml(errFile);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("The logfile '" + errFile + "' can not be written!" + lineBreak +
                                    "Please contact your administrator ..." + lineBreak + lineBreak + lineBreak + ex.ToString(), "Write Log-file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              
                }

                this.lblErwOnOff(true);
                if (title != "") this.Text = title;

                if (QS2.Logging.Settings._adminSecure)
                {
                    this.panelExept.Visible = true;
                    this.lblErwOnOff(this.panelExept.Visible);
                }

            }
            catch (Exception ex2)
            {
                MessageBox.Show("Error in the error handling system!" + lineBreak +
                                "Please contact your administrator ..." + lineBreak + lineBreak + lineBreak + ex2.ToString(), "Write Log-file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void lblErwAnsichtEinAus_Click(object sender, EventArgs e)
        {
            this.lblErwOnOff(this.panelExept.Visible);
        }
        private void lblErwOnOff(bool bOn )
        {
            if (!bOn )
            {
                this.panelExept .Visible = true;
                this.ultraGridBagLayoutPanel1execpt.Visible = true;
                if (this.modalWindow != null) this.modalWindow.Height = 650;
            }
            else
            {
                this.panelExept.Visible = false;
                this.ultraGridBagLayoutPanel1execpt.Visible = false;
                if (this.modalWindow != null) this.modalWindow .Height = 237;
            }
        }
        public void setGermanUI()
        {
            this.UFormLinkZurücksetzen.Text = "Meldung kopieren";
            this.lblErwAnsichtEinAus.Text = "Erweiterte Ansicht";
            this.lblSendMessageAsEMail.Text = "Nachricht an S2 senden";
            this.btnClose2.Text = "Schließen";
            this.btnStartMikogo.Text = "Online-Unterstützung 1 (FastViewer)";
            this.btnStartTeamViewer.Text = "Online-Unterstützung 2 (TeamViewer)";
            this.lblMessage1.Visible = false;
            this.lblMessageGerman.Visible = true;

        }
        public void setUIEnglish()
        {
            this.btnStartMikogo.AutoSize = true;
            this.btnStartTeamViewer.AutoSize = true;
        }
        private void UFormLinkZurücksetzen_Click(object sender, EventArgs e) 
        {
            Clipboard.SetDataObject((string )this.lblExept.Value , true);
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            if (this.modalWindow != null )  this.modalWindow .Close();
        }

        private void lblMeldungVersenden_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime dNow = System.DateTime.Now;

                string msgTxt = "";
                if (this.lblMessage1.Visible)
                {
                    msgTxt = "Please a short description of the error" + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Title: " + this.lblMessage1.Text + "\r\n";
                    msgTxt += this.fld_title + "\r\n" + "\r\n";
                    msgTxt += "User: " + this.fld_usr + "\r\n";
                    msgTxt += "Time: " + this.fld_from + "\r\n";
                    msgTxt += "Hostname: " + this.hostName2 + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Message: " + "\r\n" + this.fld_error + "\r\n" + "\r\n";
                }
                else
                {
                    msgTxt = "Please a short description of the error" + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Title: " + this.lblMessageGerman.Text + "\r\n";
                    msgTxt += this.fld_title + "\r\n" + "\r\n";
                    msgTxt += "User: " + this.fld_usr + "\r\n";
                    msgTxt += "Time: " + this.fld_from + "\r\n";
                    msgTxt += "Hostname: " + this.hostName2 + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Message: " + "\r\n" + this.fld_error + "\r\n" + "\r\n";
                }

                QS2.Logging.Win.EMail sendEMail1 = new QS2.Logging.Win.EMail();
                sendEMail1.sendEMail("Message QS2", msgTxt, QS2.Logging.Win.EMail.EMailService);
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


        private void btnStartMikogo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string exe = Application.StartupPath + "\\FastViewer.exe";
                if (File.Exists(exe))
                {
                    System.Diagnostics.Process.Start(exe, "");
                }
                else
                    MessageBox.Show("Remoteunterstützung kann nicht gestartet werden.");

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
        private void btnStartTeamViewer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string exe = Application.StartupPath + "\\TeamViewer-S2-Client.exe";
                if (File.Exists(exe))
                {
                    System.Diagnostics.Process.Start(exe, "");
                }
                else
                    MessageBox.Show("Remoteunterstützung kann nicht gestartet werden.");

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
    }
}
