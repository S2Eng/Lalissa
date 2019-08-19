using Infragistics.Win.UltraWinGrid;
using PMDS.Calc.Logic;
using PMDS.DB;
using PMDS.Global;
using PMDS.Global.db.ERSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Calc.Calc.UI
{

    public partial class frmInputDate : Form
    {

        public bool abort = true;

        public Nullable<DateTime> _MaxRechDatum = null;


        public frmInputDate()
        {
            InitializeComponent();
        }



        public void initControl(Nullable<DateTime> MaxRechDatum)
        {
            try
            {
                this._MaxRechDatum = MaxRechDatum;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

                if (MaxRechDatum == null)
                    this.udteStornodatum.Value = DateTime.Now.Date;
                else
                    this.udteStornodatum.Value = _MaxRechDatum.Value.Date;

            }
            catch (Exception ex)
            {
                throw new Exception("frmInputDate.initControl: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                if (this.udteStornodatum.Value == null)
                {
                    this.errorProvider1.SetError(this.udteStornodatum, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Stornodatum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    this.udteStornodatum.Focus();
                    return false;
                }

                if (_MaxRechDatum != null && this.udteStornodatum.DateTime.Date < _MaxRechDatum.Value.Date)
                {
                    this.errorProvider1.SetError(this.udteStornodatum, "Error");
                    string sMsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Stornodatum darf nicht kleiner als das größte Rechnungsdatum ({0}) sein!");
                    sMsgBox = string.Format(sMsgBox, _MaxRechDatum.Value.Date.ToString("dd.MM.yyyy"));
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBox, true);
                    this.udteStornodatum.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.saveData: " + ex.ToString());
            }
        }


        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
