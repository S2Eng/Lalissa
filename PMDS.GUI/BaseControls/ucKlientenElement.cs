using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.BaseControls
{

    public partial class ucKlientenElement : QS2.Desktop.ControlManagment.BaseControl
    {

        public System.Guid id;
        public bool isOn = false;
        public bool isVisible = false;
        public bool isOnSingle = false;
        public bool activiertForSearch = false;

        public bool singleIsActivated = false;

        public ucKlienten mainContr;
                



        public ucKlientenElement()
        {
            InitializeComponent();
        }
        
        private void btnClick_Click(object sender, EventArgs e)
        {
            if (this.isOn)
                this.isOn = false;
            else
                this.isOn = true;

            this.mainContr.elementClicked(this);
        }
        private void picButtSingle_Click(object sender, EventArgs e)
        {
            singleCLick();
        }
        private void singleCLick()
        {
            if (!PMDS.Global.ENV.selKlientenChanged(PMDS.Global.eSendMain.checkEdited, new List<string>(), true, false)) return;

            if (this.isOnSingle)
            {
                this.isOnSingle = false;
                if (this.mainContr.typ == PMDS.Global.eSendMain.abrechnung)
                    this.picButtSingle.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);
            }
            else
            {
                this.isOnSingle = true;
                if (this.mainContr.typ == PMDS.Global.eSendMain.abrechnung)
                    this.picButtSingle.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            }

            this.mainContr.elementClickedSingle(this, this.isOnSingle);
        }

        private void uGridLayKlient_MouseEnter(object sender, EventArgs e)
        {
            if (this.mainContr.typ == PMDS.Global.eSendMain.abrechnung)
            {
                this.picButtSingle.Visible = true;
                this.picButtSingle.Tag = this.picButtSingle.Image;
                if (this.isOnSingle == false)
                    this.picButtSingle.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Info, 32, 32);

                if (this.mainContr.lastElMousOver != null)
                {
                    if (this.mainContr.lastElMousOver.id != this.id)
                    {
                        if (!this.mainContr.lastElMousOver.isOnSingle)
                        {
                            this.mainContr.lastElMousOver.picButtSingle.Visible = false;
                            //this.picButtSingle.Image = null;
                        }
                        else
                        {
                            //this.picButtSingle.Image = null;
                        }
                    }
                    this.mainContr.lastElMousOver = this;
                }
                else
                {
                    this.mainContr.lastElMousOver = this;
                }
            }
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            if (this.mainContr.typ == PMDS.Global.eSendMain.abrechnung)
            {
                if (!this.isOnSingle) this.picButtSingle.Visible = false;
            }
        }

        private void ucKlientenElement_MouseEnter(object sender, EventArgs e)
        {

        }

        private void ucKlientenElement_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnClick_MouseEnter(object sender, EventArgs e)
        {
            uGridLayKlient_MouseEnter(sender, e);
         }

        private void historischeDatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatientHistorie auf = new frmPatientHistorie(this.id, true);
            auf.ShowDialog();
        }
    }
}
