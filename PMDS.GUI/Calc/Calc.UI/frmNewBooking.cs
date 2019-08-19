using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace PMDS.Calc.UI
{


    public partial class frmNewBooking : QS2.Desktop.ControlManagment.baseForm 
    {

        public bool apport = true;
        public PMDS.Calc.Logic.booking booking = new PMDS.Calc.Logic.booking();


        private string _IDKost = "";
        private string _IDKlient = "";
        private string _rechNr = "";

        public PMDS.BusinessLogic.Patient pat;





        public frmNewBooking()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void init(string IDKost, string IDKlient, string buchText, decimal betrag, DateTime buchDat, string  rechNr)
        {
            this._IDKost = IDKost;
            this._IDKlient = IDKlient;
            if (this._IDKlient != "")
            {
                this.pat = new PMDS.BusinessLogic.Patient(new System.Guid(this._IDKlient));
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Neue Buchung - ") + pat.FullName;
            }
            
            this.txtBuchText.Text = buchText ;
            this.tbBetrag.Value = betrag;
            this.dtpBuchungsdatum.DateTime = buchDat;
            this._rechNr = rechNr;
        }
        public void saveBooking()
        {
        }

        private void frmBuchNeu_Load(object sender, EventArgs e)
        {
            this.loadRes();
        }
        public void loadRes()
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_Bewerber, 32, 32);

            this.btnSave.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
            this.btnApport.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);

        }
        private void btnApport_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (this.txtBuchText.Text.Trim()  == "")
                {
                        this.txtBuchText.Focus();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungstext: Eingabe erforderlich!", "Buchungen speichern", MessageBoxButtons.OK);
                        return;
                }

                bool noBetrag = false;
                if (this.tbBetrag.Value == System.DBNull.Value)
                        noBetrag = true;
                else
                {
                    if ((double)this.tbBetrag.Value == 0)
                            noBetrag = true;
                }
                if (noBetrag)
                {
                        this.tbBetrag.Focus();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Betrag: Eingabe erforderlich!", "Buchungen speichern", MessageBoxButtons.OK);
                        return;
                }

                if (this.dtpBuchungsdatum.Value == System.DBNull.Value )
                {
                        this.dtpBuchungsdatum.Focus();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungsdatum: Eingabe erforderlich!", "Buchungen speichern", MessageBoxButtons.OK);
                        return;
                }

                PMDS.Calc.Logic.calcData calcData = new PMDS.Calc.Logic.calcData();
                this.booking.saveBooking(PMDS.Calc.Logic.eKonto.Zahlungen, PMDS.Calc.Logic.eKonto.Kundenforderungen, 
                                        this.dtpBuchungsdatum.DateTime, this.txtBuchText.Text.Trim(), 
                                        System.Convert.ToDecimal(this.tbBetrag.Value), -1, this._rechNr, this._IDKlient, this._IDKost,
                                        ref calcData, true, PMDS.Calc.Logic.eCalcRun.month, PMDS.Global.ENV.IDKlinik);

                this.apport = false;
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


    }
}
