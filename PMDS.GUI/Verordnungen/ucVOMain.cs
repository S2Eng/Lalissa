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
        private bool _Einzelansicht;
        public frmVOMain mainWindow { get; set; }

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

                ucVOErfassen1.mainWindowVerwaltung = this.mainWindow;
                ucVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenVerwaltung, this._Einzelansicht, false, null);
                ucVOErfassen1.search2(this.ucVOErfassen1._IDAufenthalt, this.ucVOErfassen1._IDPflegeplan, this.ucVOErfassen1._IDMedDaten, this.ucVOErfassen1._IDWundeKopf);

                ucVOBestellvorschläge1.mainWindowVerwaltung = this.mainWindow;
                ucVOBestellvorschläge1.initControl(ucVOBestellvorschlaegeDetail.eTypeUI.Bestellvorschläge, this._Einzelansicht);

                ucVOLieferung1.mainWindowVerwaltung = this.mainWindow;
                ucVOLieferung1.initControl(ucVOBestellvorschlaegeDetail.eTypeUI.Lieferung, this._Einzelansicht);

                ucLager1.initControl(ucLager.eTypeUI.All);
                
                ultraTabControl1.Tabs["Lager"].Visible = PMDS.Global.ENV.lic_VOLager;
                ucVOErfassen1.panelTop.Controls["grpSearch"].Controls["cboZustand"].Visible = PMDS.Global.ENV.lic_VOLager;
                ucVOErfassen1.panelTop.Controls["grpSearch"].Controls["lblZustandLager"].Visible = PMDS.Global.ENV.lic_VOLager;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOMain.initControl: " + ex.ToString());
            }
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                if (this.ultraTabControl1.Focused)
                {
                    if (PMDS.Global.generic.sEquals(ultraTabControl1.ActiveTab.Key,"Erfassung"))
                    {
                        this.ucVOErfassen1.search2(this.ucVOErfassen1._IDAufenthalt, this.ucVOErfassen1._IDPflegeplan, this.ucVOErfassen1._IDMedDaten, this.ucVOErfassen1._IDWundeKopf);
                    }
                    else if (PMDS.Global.generic.sEquals(ultraTabControl1.ActiveTab.Key, "Bestellvorschläge"))
                    {
                        this.ucVOBestellvorschläge1.search();
                    }
                    else if (PMDS.Global.generic.sEquals(ultraTabControl1.ActiveTab.Key, "Bestellungen"))
                    {
                        this.ucVOLieferung1.search();
                    }
                    else if (PMDS.Global.generic.sEquals(ultraTabControl1.ActiveTab.Key, "Lager"))
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
