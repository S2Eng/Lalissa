using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualKeyboard;
using PMDS.Data.PflegePlan;
using PMDS.GUI.BaseControls;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucBigRMMain : QS2.Desktop.ControlManagment.BaseControl
    {
        private BigRMModes                  _mode;
        private dsPflegePlan.PflegePlanRow  _row;
        private QMEintrag                   _QMe;
        public bool bOK = false;


        public ucBigRMMain()
        {
            InitializeComponent();
        }

        public void InitControl(dsPflegePlan.PflegePlanRow row, BigRMModes mode, QMEintrag QMe)
        {
            ucBigRM1.InitControl(row, mode, QMe);
            _mode = mode;
            _row = row;
            _QMe = QMe;

            btnMorgen.Visible = _mode == BigRMModes.Normal;
        }
        public void clearContrl()
        {
            this.ucBigRM1.clearContrl();

        }

        public void InitControl(BigRMModes mode, Guid IDEintrag)
        {
            _mode = mode;
            ucBigRM1.InitControl(mode, IDEintrag);
        }

        public void InitControlBedarfsMediaktion()
        {
            _mode = BigRMModes.Bedarfsmedikation;
            ucBigRM1.InitControl(BigRMModes.Bedarfsmedikation, Guid.Empty);
        }

        public void InitControlFreierBericht()
        {
            _mode = BigRMModes.FreierBericht;
            ucBigRM1.InitControl(BigRMModes.FreierBericht, Guid.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            this.Visible = false;
        }

        private void btnAbzeichnen_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            Abzeichnen(false);
        }

        private void btnMorgen_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            Abzeichnen(true);

        }

        private void Abzeichnen(bool bMorgenWieder)
        {
            Cursor.Current = Cursors.WaitCursor;
            


            if (!ucBigRM1.ValidateFields())
                return;

            ucBigRM1.Abzeichnen();          // pflegeeintrag schreiben je nach Modus
            // Zusatzwerte
            dsZusatzWert.ZusatzWertDataTable dt = ucBigRM1.GetZusatzWerteForDB(ucBigRM1.Eintrag.ID);
            QM.WriteZusatzWerte(dt);
                
            if (_mode == BigRMModes.Normal)
            {
                //PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                //PMDS.db.Entities.PflegePlan rPflegeplan = null;
                //b.UpdatePflegePlanBeiRÜckmeldung(this._IDPflegePlan, db, ref  NächstesDatum, ref rPflegeplan, bMorgenWieder);

                //BUtil.UpdatePflegePlan(ucBigRM1.Eintrag, _row.EinmaligJN, bMorgenWieder);
                DateTime NächstesDatum = DateTime.MinValue;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();    //lthok
                    PMDS.db.Entities.PflegePlan rPflegeplan = null;
                    b.UpdatePflegePlanBeiRückmeldung(ucBigRM1.Eintrag.IDPflegePlan, db, ref  NächstesDatum, rPflegeplan, false, ucBigRM1.Eintrag.Zeitpunkt, true);
                    //uc.auswahlGruppeComboMulti1.AddCC(pe.ID, true);
                }
            }
            this.bOK = true;
            this.Visible = false;
        }

        private void ucBigRM1_Load(object sender, EventArgs e)
        {

        }

        private void frmBigRM_Load(object sender, EventArgs e)
        {
            this.btnCancel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
        }

       
    }
}