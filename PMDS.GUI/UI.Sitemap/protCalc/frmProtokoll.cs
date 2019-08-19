using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;
using PMDS.UI.Sitemap;



namespace PMDS.Global
{
    public partial class frmProtokoll : QS2.Desktop.ControlManagment.baseForm 
    {

        private PMDS.UI.Sitemap.runCalc runCalc = new PMDS.UI.Sitemap.runCalc();

        private DateTime _von;
        private DateTime _bis;
        private DateTime _rechDatum;
        private UltraGrid _grid;
        private UltraButton _butAlleKeine;
        private UltraLabel _lblCount;
        private PMDS.Calc.Logic.eCalcRun _calcRun;
        private TXTextControl.TextControl _editor;
        private TXTextControl.TextControl _editorPrecalc;
        private string _typ;
        private System.Collections.ArrayList _listID;

        public bool calc = true;



        public frmProtokoll()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.ucProtokoll1.mainWindow = this;
        }

        public void initControl(DateTime von, DateTime bis, DateTime rechDatum,
                          UltraGrid grid,   UltraButton butAlleKeine,
                          ref QS2.Desktop.ControlManagment.BaseLabel lblCount, PMDS.Calc.Logic.eCalcRun calcRun, TXTextControl.TextControl editor,
                          TXTextControl.TextControl editorPrecalc, string typ, ref System.Collections.ArrayList listID)
        {
            runCalc.mainForm = this;

            this._von = von;
            this._bis = bis;
            this._rechDatum = rechDatum;
            this._grid = grid;
            this._butAlleKeine = butAlleKeine;
            this._lblCount = lblCount;
            this._calcRun = calcRun;
            this._editor = editor;
            this._editorPrecalc = editorPrecalc;
            this._typ = typ;
            this._listID = listID;
        }

        private void frmProtokoll_Load(object sender, EventArgs e)
        {
            if (calc)
            {
                this.Show();
                this.Focus();
                Application.DoEvents();

                runCalc.run(this._von, this._bis, this._rechDatum, ref this._grid, ref this._butAlleKeine,
                    ref this._lblCount, this._calcRun, this._editor, this._editorPrecalc, this._typ, ref this._listID);
            }
        }

    }
}
