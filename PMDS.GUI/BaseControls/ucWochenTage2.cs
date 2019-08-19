//----------------------------------------------------------------------------------------------
//  Erstellt am:	29.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI
{
    public partial class ucWochenTage2 : QS2.Desktop.ControlManagment.BaseControl
    {
        private int _wochentage = 0;
        public event EventHandler ValueChanged;
        private bool _preventValueChanged = false;

        public ucWochenTage2()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktualisieren der Checkboxen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshCheckboxes()
        {
            _preventValueChanged = true;
            cbMo.Checked = (_wochentage & 1) == 0 ? false : true;
            cbDi.Checked = (_wochentage & 2) == 0 ? false : true;
            cbMi.Checked = (_wochentage & 4) == 0 ? false : true;
            cbDo.Checked = (_wochentage & 8) == 0 ? false : true;
            cbFr.Checked = (_wochentage & 16) == 0 ? false : true;
            cbSa.Checked = (_wochentage & 32) == 0 ? false : true;
            cbSo.Checked = (_wochentage & 64) == 0 ? false : true;
            _preventValueChanged = false;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Bitcodierte Wochentage - Bit 0 = Montag
        /// </summary>
        //----------------------------------------------------------------------------
        [Description("Bitcodierter Wert für die Wochentage Bit 0 = Montag")]
        public int WOCHENTAGE
        {
            get
            {
                _wochentage = 0;
                if (cbMo.Checked) _wochentage += 1;
                if (cbDi.Checked) _wochentage += 2;
                if (cbMi.Checked) _wochentage += 4;
                if (cbDo.Checked) _wochentage += 8;
                if (cbFr.Checked) _wochentage += 16;
                if (cbSa.Checked) _wochentage += 32;
                if (cbSo.Checked) _wochentage += 64;
                return _wochentage;
            }
            set
            {
                _wochentage = value;
                RefreshCheckboxes();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eigene ToString Funktion
        /// </summary>
        //----------------------------------------------------------------------------
        public override string ToString()
        {
            string sRet = "";           //-IntVers=NoTranslation
            if (cbMo.Checked)
                sRet += "Mo ";
            if (cbDi.Checked)
                sRet += "Di ";
            if (cbMi.Checked)
                sRet += "Mi ";
            if (cbDo.Checked)
                sRet += "Do ";
            if (cbFr.Checked)
                sRet += "Fr ";
            if (cbSa.Checked)
                sRet += "Sa ";
            if (cbSo.Checked)
                sRet += "So ";
            if (sRet.Length == 0)
                sRet = "*****";
            return sRet;
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null && _preventValueChanged == false)
                ValueChanged(this, null);
        }

    }
}
