using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using VirtualKeyboard;
using System.Threading;

namespace PMDS.GUI.BaseControls
{
    public partial class frmBigMessageBox : QS2.Desktop.ControlManagment.baseForm 
    {
        private static string               _sText;
        private static string               _sCaption;
        private static MessageBoxButtons    _buttons;
        private static IWin32Window         _owner;

        public static void Show(string sText, string sCaption, MessageBoxButtons buttons, IWin32Window owner, bool StartThread)
        {
            _sText      = sText;
            _sCaption   = sCaption;
            _buttons    = buttons;
            _owner      = owner;

            if (StartThread)
            {
                Thread t = new Thread(new ThreadStart(t_start));            // Workaround weil Combobox nicht automatisch schließt
                t.Start();
            }
            else
            {
                t_start();
            }
        }

        private static void t_start()
        {
            frmBigMessageBox frm = new frmBigMessageBox(_sText, _sCaption, _buttons);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public frmBigMessageBox(string sText, string sCaption, MessageBoxButtons buttons)
        {
            InitializeComponent();
            lblText.Text        = sText;
            lblHeader.Text    = sCaption;
            this.DialogResult   = DialogResult.Cancel;

            btnJa.Top   = btnCancel.Top;                    // Es gibt immer nur 2 Buttons ==> aud gleiche höhe bringen
            btnNein.Top = btnCancel.Top;

            bool bYes = false;
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                case MessageBoxButtons.OK:
                case MessageBoxButtons.OKCancel:
                case MessageBoxButtons.RetryCancel:
                    bYes = false;
                    break;
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
                    bYes = true;
                    break;
                default:
                    break;
            }

            btnCancel.Visible   = !bYes;
            btnOK.Visible       = !bYes;
            btnNein.Visible     = bYes;
            btnJa.Visible       = bYes;

            if (buttons == MessageBoxButtons.OK)
                btnCancel.Visible = false;

            QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
            ControlManagment1.autoTranslateForm(this);
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
                    DialogResult = DialogResult.Cancel;
                    break;
                case "OK":
                    DialogResult = DialogResult.OK;
                    break;
                case "Ja":
                    DialogResult = DialogResult.Yes;
                    break;
                case "Nein":
                    DialogResult = DialogResult.No;
                    break;
                default:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}