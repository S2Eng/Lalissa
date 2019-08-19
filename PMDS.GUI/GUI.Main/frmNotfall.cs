//----------------------------------------------------------------------------
/// <summary>
///	frmNotfall.cs
/// Erstellt am:	12.12.2007
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// Fenster mit Notfallfunktionalität:
    /// Neu/melden/bearbeiten/melden
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class frmNotfall : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmNotfall(Guid IDAufenthalt, Guid IDStandardprozeduroderIDSP, BearbeitungsModus mode)
        {
            InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.CancelButton       = btnCancel;
            ucNotfall1.IDAUFENTHALT = IDAufenthalt;
            ucNotfall1.MODE         = mode;
            ucNotfall1.NaechterZeitpunktChanged += new EventHandler(ucNotfall1_NaechterZeitpunktChanged);

            SP sp = new SP();
            if (mode == BearbeitungsModus.neu)
                ucNotfall1.DSSP = sp.NewFromStandardProzedur(IDStandardprozeduroderIDSP, IDAufenthalt, ENV.USERID);
            else
                ucNotfall1.DSSP = sp.Read(IDStandardprozeduroderIDSP);

            

            Aufenthalt a = new Aufenthalt(IDAufenthalt);
            Patient pat = new Patient(a.IDPatient);

            Guid IDStandardProzeduren = ucNotfall1.DSSP.SP[0].IDStandardProzeduren;
            StringBuilder sb = new StringBuilder();
            string sNotfallname = StandardProzeduren.GetBezeichnung(IDStandardProzeduren);
            bool   bNotfall     = StandardProzeduren.GetNotfallFlag(IDStandardProzeduren);
            sb.Append(bNotfall ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall: ") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Standardprozedur: "));
            
            sb.Append(sNotfallname);
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" für "));
            sb.Append(pat.FullInfo);
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" am "));
            sb.Append(DateTime.Now.ToShortDateString());
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" um "));
            sb.Append(DateTime.Now.ToShortTimeString());

            this.Text = sb.ToString();

            cbLetOpen.Checked = mode == BearbeitungsModus.edit || bNotfall;         // neuerliches öffnen oder Notfall bleiben offen
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// wird aufgerufen wenn bei den M der nächste Zeitpunkt verändert wurde
        /// </summary>
        //----------------------------------------------------------------------------
        void ucNotfall1_NaechterZeitpunktChanged(object sender, EventArgs e)
        {
            if (cbLetOpen.Checked)
                return;
            UltraDateTimeEditor ed = (UltraDateTimeEditor)sender;
            if (ed.Value == null) return;

            cbLetOpen.Checked = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle markierten melden und die SP/NF speichern
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ucNotfall1.ValidateFields())
                return;

            if(!ucNotfall1.Write(!cbLetOpen.Checked))
                return;
            CloseWindowOK();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Fenster schließen
        /// </summary>
        //----------------------------------------------------------------------------
        private void CloseWindowOK()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Abbrechen Verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucButton1_Click(object sender, EventArgs e)
        {

            string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Den Dialog wirklich verlassen ?");
            if (ucNotfall1.IsM_checked)
                sText += QS2.Desktop.ControlManagment.ControlManagment.getRes("\r\nEs sind noch Maßnahmen zum Abzeichnen markiert");

            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Verlassen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);
            if (res != DialogResult.Yes)
                return;
            this.Close();
        }

        private void frmNotfall_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmNotfall_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucNotfall1.RemoveReplacerDelegate();            // Delegate entfernen sonst wird die Replacer mehrmals aufgerufen und führt zu einem falschen Ergebnis
        }

        private void frmNotfall_Load(object sender, EventArgs e)
        {

        }
    }
}