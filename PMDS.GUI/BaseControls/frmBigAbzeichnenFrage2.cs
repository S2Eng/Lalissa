using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using VirtualKeyboard;

namespace PMDS.GUI.BaseControls
{
    public partial class frmBigAbzeichnenFrage2 : QS2.Desktop.ControlManagment.baseForm 
    {
        private BigAbzeichnenActions _action = BigAbzeichnenActions.Abbrechen;

        public frmBigAbzeichnenFrage2(string sText)
        {
            InitializeComponent();
            lblText.Text = sText;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Dialogresult
        /// </summary>
        //----------------------------------------------------------------------------
        public new BigAbzeichnenActions DialogResult
        {
            get
            {
                return _action;
            }
        }
        public void HideMorgenwieder()
        {
            btnMorgen.Visible = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Im Tag der Butons steckt die Action
        /// </summary>
        //----------------------------------------------------------------------------
        private void btn_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            UltraButton b = (UltraButton)sender;
            string s = b.Tag.ToString();
            switch (s)
            {
                case "Abbrechen":
                    _action = BigAbzeichnenActions.Abbrechen;
                    break;
                case "Dialog":
                    _action = BigAbzeichnenActions.Dialog;
                    break;
                case "Morgen":
                    _action = BigAbzeichnenActions.Morgen;
                    break;
                case "Abzeichnen":
                    _action = BigAbzeichnenActions.Abzeichnen;
                    break;
                default:
                    _action = BigAbzeichnenActions.Abbrechen;
                    break;
            }
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            _action = BigAbzeichnenActions.Abbrechen;
            Close();
        }
    }

    //----------------------------------------------------------------------------
    /// <summary>
    /// Die verschiedenen Dialogresults
    /// </summary>
    //----------------------------------------------------------------------------
    public enum BigAbzeichnenActions
    {
        Abzeichnen,
        Morgen,
        Dialog,
        Abbrechen
    }
}