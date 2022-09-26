using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;





namespace QS2.Logging
{

    public partial class ucError2 : System.Windows.Forms.UserControl
    {
        private const string lineBreak = "\r\n";
        public System.Guid _id;
        public frmError2 modalWindow;
        public QS2.Logging.dsLog.tblLogRow rNewError = null;
        public string hostName = "";
        public string TxtInfo = "";
        public bool germanTxt = false;

        public ucError2()
        {
            InitializeComponent();
        }
        
        private void frmError_Load(object sender, EventArgs e)
        {
            this.ultraGridBagLayoutPanelExept.Visible = false;
            //this.pictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.ePicture.ico_log, 32, 32);
        }

        public void setData(string title, string exep, string usr)
        {
            try
            {
                this._id = System.Guid.NewGuid();
                //sErr += "<span style=" + (char)34 + "font-size:8pt;" + (char)34 + ">" + exep + "</span>" + "";
                this.lblExept.Value = exep;

                string errFile = "";
                try
                {
                    if (!System.IO.Directory.Exists(QS2.Logging.ENV._path_log))
                    {
                        System.IO.Directory.CreateDirectory(QS2.Logging.ENV._path_log);
                    }

                    this.hostName= System.Net.Dns.GetHostName();
                    if (this.hostName == "") hostName = System.Guid.NewGuid().ToString();
                    errFile = QS2.Logging.ENV._path_log + "\\log_" + this.hostName + ".xml";
                    QS2.Logging.dsLog ds = new QS2.Logging.dsLog();
                    if (!System.IO.File.Exists(errFile))
                        { ds.WriteXml(errFile); }
                    ds.ReadXml(errFile);
                    this.rNewError = ds.tblLog.NewtblLogRow();
                    this.rNewError.id = this._id;
                    this.rNewError.title = title;
                    this.rNewError.error = exep;
                    this.rNewError.usr = usr;
                    this.rNewError.from = System.DateTime.Now;
                    ds.tblLog.Rows.Add(this.rNewError);
                    ds.WriteXml(errFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The logfile '" + errFile + "' can not be written!" + lineBreak +
                                    "Please contact your administrator ..." + lineBreak + lineBreak + lineBreak + ex.ToString(), "Write Log-file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              
                }

                this.lblErwOnOff(true);
                if (title != "") this.Text = title;

                if (QS2.Logging.ENV._adminSecure)
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
            this.btnSend.Text = "Senden";
            this.btnStartMikogo.Text = "Online-Unterstützung 1 (FastViewer)";
            this.btnStartTeamViewer.Text = "Online-Unterstützung 2 (TeamViewer)";



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

                string msgTxt = "";
                if (!this.germanTxt)
                {
                    msgTxt = "Please a short description of the error" + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Title: " + this.txtDescritpionOfProblem.Text + "\r\n";
                    msgTxt += this.rNewError.title + "\r\n" + "\r\n";
                    msgTxt += "User: " + this.rNewError.usr + "\r\n";
                    msgTxt += "Time: " + this.rNewError.from.ToString() + "\r\n";
                    msgTxt += "Hostname: " + this.hostName.ToString() + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Message: " + "\r\n" + this.rNewError.error.ToString() + "\r\n" + "\r\n";
                }
                else
                {
                    msgTxt = "Please a short description of the error" + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Title: " + this.txtDescritpionOfProblem.Text + "\r\n";
                    msgTxt += this.rNewError.title + "\r\n" + "\r\n";
                    msgTxt += "User: " + this.rNewError.usr + "\r\n";
                    msgTxt += "Time: " + this.rNewError.from.ToString() + "\r\n";
                    msgTxt += "Hostname: " + this.hostName.ToString() + "\r\n" + "\r\n" + "\r\n";
                    msgTxt += "Message: " + "\r\n" + this.rNewError.error.ToString() + "\r\n" + "\r\n";
                }


                QS2.functions.cs.EMail sendEMail1 = new QS2.functions.cs.EMail();
                sendEMail1.sendEMail("Message QS2", msgTxt, QS2.functions.cs.EMail.EMailService);

                //if (this.modalWindow != null) this.modalWindow.Close();
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
