using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.DB;

namespace PMDS.GUI.Verordnungen
{

    public partial class ucVOMain : UserControl
    {
        public bool _Einzelansicht = false;
        public frmVOMain mainWindow = null;

        public ucVOMain()
        {
            InitializeComponent();
        }

        private void ucVOMain_Load(object sender, EventArgs e)
        {

        }



        public void initControl(bool Einzelansicht)
        {
            try
            {
                this._Einzelansicht = Einzelansicht;

                //PMDSBusinessComm.checkMessageForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll);

                this.ucVOErfassen1.mainWindowVerwaltung = this.mainWindow;
                this.ucVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung, this._Einzelansicht, false, null);

                this.ucVOBestellvorschläge1.mainWindowVerwaltung = this.mainWindow;
                this.ucVOBestellvorschläge1.initControl(ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge, this._Einzelansicht);

                this.ucVOLieferung1.mainWindowVerwaltung = this.mainWindow;
                this.ucVOLieferung1.initControl(ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung, this._Einzelansicht);

                this.ucVOErfassen1.search2(this.ucVOErfassen1._IDAufenthalt, this.ucVOErfassen1._IDPflegeplan, this.ucVOErfassen1._IDMedDaten, this.ucVOErfassen1._IDWundeKopf);

                this.ucLager1.initControl(ucLager.eTypeUI.All);

                this.ultraTabControl1.Tabs["Lager"].Visible = PMDS.Global.ENV.lic_VOLager;
                this.ucVOErfassen1.panelTop.Controls["grpSearch"].Controls["cboZustand"].Visible = PMDS.Global.ENV.lic_VOLager;
                this.ucVOErfassen1.panelTop.Controls["grpSearch"].Controls["lblZustandLager"].Visible = PMDS.Global.ENV.lic_VOLager;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOMain.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw new Exception("ucVOMain.loadData: " + ex.ToString());
            }
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                if (this.ultraTabControl1.Focused)
                {
                    if (this.ultraTabControl1.ActiveTab.Key.Trim().ToLower().Equals(("Erfassung").Trim().ToLower()))
                    {
                        this.ucVOErfassen1.search2(this.ucVOErfassen1._IDAufenthalt, this.ucVOErfassen1._IDPflegeplan, this.ucVOErfassen1._IDMedDaten, this.ucVOErfassen1._IDWundeKopf);
                    }
                    else if (this.ultraTabControl1.ActiveTab.Key.Trim().ToLower().Equals(("Bestellvorschläge").Trim().ToLower()))
                    {
                        this.ucVOBestellvorschläge1.search();
                    }
                    else if (this.ultraTabControl1.ActiveTab.Key.Trim().ToLower().Equals(("Bestellungen").Trim().ToLower()))
                    {
                        this.ucVOLieferung1.search();
                    }
                    else if (this.ultraTabControl1.ActiveTab.Key.Trim().ToLower().Equals(("Lager").Trim().ToLower()))
                    {
                        this.ucLager1.loadData(null, "");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOMain.loadData: " + ex.ToString());
            }
        }

    }
}
