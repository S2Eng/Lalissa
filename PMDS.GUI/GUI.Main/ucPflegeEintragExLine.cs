using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI
{
    public partial class ucPflegeEintragExLine : ucPflegeEintragEx
    {
        private bool _FinishAfterCreate = false;
        public int HeigthPflegeEintragControl = -1;
        public int HeigthZusatzwerte = -1;
        public bool ZusatzwerteVisible = false;
        public bool IgnoreLine = false;
        public bool MorgenWieder = false;





        public ucPflegeEintragExLine()
        {
            InitializeComponent();
            dtpZeitpunktPlan.Visible = false;
        }

        public bool FinishAfterCreate
        {
            get { return _FinishAfterCreate; }
            set { _FinishAfterCreate = value; }
        }

        public string INFOTEXT
        {
            set
            {
                lblInfo.Text = value;
            }
        }

        public void ResetIgnoreLine()
        {
            this.chkIgnoreLine.Checked = false;
            this.IgnoreLine = false;
        }

        public void ResetMorgenWieder()
        {
            this.chkMorgenWieder.Checked = false;
            this.MorgenWieder = false;
        }

        public void ResetDauerBackColor()
        {
            this.txtIstDauer.Appearance.ResetBackColor();
        }


        public void SetTerminString(string s, bool TerminStringVisible)
        {
            lblTerminText.Visible = TerminStringVisible;
            if (TerminStringVisible)
                lblTerminText.Text = s;
        }

        public void ResizeThis(ref int aktRow)
        {
            //            lblWichtigFürCC.Text = "CC";
            if (aktRow % 2 != 0)
            {
                this.BackColor = System.Drawing.Color.Gainsboro;
            }
            else
            {
                this.BackColor = System.Drawing.Color.WhiteSmoke;
            }

            ucZusatzWert1.Width = 500;
            if (!ucZusatzWert1.HAS_ADDITIONAL_VALUES)
            {
                this.HeigthPflegeEintragControl = txtBeschreibungLine.Bottom + 5;// auswahlGruppeComboMulti1.Top + auswahlGruppeComboMulti1.Height + 5;
                this.ZusatzwerteVisible = false;
                this.Height = this.HeigthPflegeEintragControl;
            }
            else
            {
                this.HeigthZusatzwerte = 30 * ucZusatzWert1.ADDITIONAL_VALUES_COUNT;
                this.HeigthPflegeEintragControl = this.ucZusatzWert1.Top + this.HeigthZusatzwerte + 3;
                this.ZusatzwerteVisible = true;
                this.Height = this.HeigthPflegeEintragControl;
            }
        }

        private void ucPflegeEintragExLine_Load(object sender, EventArgs e)
        {

        }

        private void ucDateSelect1_Load(object sender, EventArgs e)
        {

        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Refresh Zeitpunkt bei Schnelländerung CboBox
        /// [lth]
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucDateSelect1_delRefresh(DateTime dat)
        {
            if (dat != null)
            {
                this.dtpZeitpunkt.DateTime = dat;
            }
        }

        private void dtpZeitpunkt_ValueChanged(object sender, EventArgs e)
        {
            //this.ucDateSelect1._datAct = this.dtpZeitpunkt.DateTime;
        }

        private void ucDateSelect1_delRefresh(object val)
        {
            this.dtpZeitpunkt.DateTime = (DateTime)val;
        }

        private void ucDateSelect1_Load_1(object sender, EventArgs e)
        {

        }

        private void panelEmpty_Paint(object sender, PaintEventArgs e)
        {

        }

        private void baseLableWin2_Click(object sender, EventArgs e)
        {

        }

        private void chkIgnoreLine_CheckedChanged(object sender, EventArgs e)
        {
            this.IgnoreLine = chkIgnoreLine.Checked;
        }

        private void txtBeschreibungLine_ValueChanged(object sender, EventArgs e)
        {
            //Wenn AlsDekursKopieren verwendet werden darf auf true setzen, wenn Text eingegeben wurde
            if (this.chkAlsDekursKopieren.Visible)
            {
                if (txtBeschreibungLine.Text.Trim() == "")
                    this.chkAlsDekursKopieren.Checked = false;
                else
                    this.chkAlsDekursKopieren.Checked = true;
            }
        }

        private void txtBeschreibungLine_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F12)
            {
                //Text in alle anderen Rückmeldungen kopieren
                foreach (ucPflegeEintragExLine uc1 in this.Parent.Controls)
                {
                    if (uc1.Visible && !uc1.IgnoreLine)
                    {
                        uc1.txtBeschreibungLine.Text = txtBeschreibungLine.Text;
                    }
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F3)
            {
                this.clickLoadTextbausteine(true);
            }

        }

        private void lblAnmerkung_Click(object sender, EventArgs e)
        {

        }

        private void chkMorgenWieder_CheckedChanged(object sender, EventArgs e)
        {
            this.MorgenWieder = chkMorgenWieder.Checked;
        }
    }
}
