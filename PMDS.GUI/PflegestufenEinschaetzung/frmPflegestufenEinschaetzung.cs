using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI.PflegestufenEinschaetzung
{
    public partial class frmPflegestufenEinschaetzung : QS2.Desktop.ControlManagment.baseForm
    {
        private PMDS.Global.db.cPflegestufenEinschaetzung.PSEParams p { get; set; }

        public frmPflegestufenEinschaetzung()
        {
            InitializeComponent();
            Init(ENV.IDAUFENTHALT);
        }

        private void Init(Guid IDAufenthalt)
        {
            try
            {
                btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                btnCancel2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);
                btnOK2.Enabled = false;
                if (p == null)
                {
                    p = new Global.db.cPflegestufenEinschaetzung.PSEParams();
                }
                p.IDAufenthalt = IDAufenthalt;
                p = PMDS.Global.db.cPflegestufenEinschaetzung.Init(p);
                if (p.LastResult)
                {
                    this.lblKlientName.Text = p.KlientNachname + " " + p.KlientVorname;

                    DateTime dtFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                    this.dtpVon.DateTime = dtFirst.AddMonths(-1);
                    this.dtpBis.DateTime = dtFirst.AddSeconds(-1);
                    btnOK2.Enabled = true;
                }
                else
                {
                    btnOK2.Enabled = false;
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(p.ErrorText, "Fehlermeldung");
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("frmPflegestufenEinschaetzung.Init: " + ex.ToString());
            }
        }

        private void LoadData()
        {
            try
            {
                p = PMDS.Global.db.cPflegestufenEinschaetzung.LoadData(p);
                if (p.LastResult)
                {
                    if (p.HasData)
                    {
                        MakeExcel();
                        if (!p.LastResult)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(p.ErrorText, "Fehlermeldung");
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Daten im angegebenen Zeitraum gefunden.", "Hinweis");
                    }
                }
                else
                {
                    btnOK2.Enabled = false;
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(p.ErrorText, "Fehlermeldung");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegestufenEinschaetzung.LoadData: " + ex.ToString());
            }
        }

        private void MakeExcel()
        {
            try
            {
                p = PMDS.Global.db.cPflegestufenEinschaetzung.MakeExcel(p);
            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegestufenEinschaetzung.LoadData: " + ex.ToString());
            }
        }
        private void btnCancel2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Close();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {

                if (ENV.lic_PflegestufenEinschätzung)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string msg = "";

                    if (dtpVon.DateTime != null && dtpVon.DateTime > dtpVon.MinDate)
                    {
                        p.dtVon = dtpVon.DateTime;
                    }
                    else
                    {
                        msg += "Sie müssen ein Von-Datum angeben.\n";
                    }

                    if (dtpBis.DateTime != null && dtpBis.DateTime > dtpBis.MinDate)
                    {
                        p.dtBis = dtpBis.DateTime;
                    }
                    else
                    {
                        msg += "Sie müssen ein Bis-Datum angeben.";
                    }

                    if (msg.Length == 0)
                    {
                        this.LoadData();
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msg, "Hinweis");
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben für diese Funktion keine Lizenz erworben.", "Hinweis");
                    btnOK2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
