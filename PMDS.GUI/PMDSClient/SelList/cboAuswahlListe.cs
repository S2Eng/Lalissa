using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.GUI.PMDSClient.UIBackgroundWorker;

namespace PMDS.GUI.PMDSClient.SelList
{

    public partial class cboAuswahlListe : UserControl
    {

        private AuswahlListeBW _AuswahllisteUI;
        public AuswahlListeBW AuswahllisteUI
        {
            get => _AuswahllisteUI;
            set => _AuswahllisteUI = value;
        }





        public cboAuswahlListe()
        {
            InitializeComponent();
        }


        public void initControl(WCFServicePMDS.BAL.AuswahlListeBAL.TypeSelList TypeSelList)
        {
            this.AuswahllisteUI = new AuswahlListeBW(TypeSelList, this.cbo);
        }








        private void CboAuswahlListe_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Cbo_Click(object sender, EventArgs e)
        {

        }
        private void Cbo_DoubleClick(object sender, EventArgs e)
        {

        }

    }

}

