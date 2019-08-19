using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace PMDS.Global
{


    public partial class ucProtokoll : QS2.Desktop.ControlManagment.BaseControl
    {

        public bool apport = true;
        public bool actionDone = false ;
        private bool _closeWhenJa = true;
        public bool nurProtokoll = false;

        public frmProtokoll mainWindow;


        

        public enum eIco
        {
            ok = 0,
            error = 1,
            hinweis = 2,
            kein = 3
        }

        public ucProtokoll()
        {
            InitializeComponent();
        }

        public void start(string capt, bool buttOn,
                            string txt, string quest, bool jaNein, bool closeWhenJa)
        {
            this.Cursor = Cursors.Default;

            this.ucProtDetail1.modalWindow = this;

            _closeWhenJa = closeWhenJa;
             apport = true;
            actionDone = false;

            this.lblTitel.Text = capt;
            this.txtProtokoll.Value = txt;
            this.panelButtonsJaNein.Visible = jaNein;
            this.panelUnten2 .Visible  = buttOn;
            this.panelButtonsOK.Visible = !jaNein;
            this.txtQuestion.Text = quest;

            this.ucProtDetail1.Visible = false;
            panelAll.Visible = true;
            treeProtokoll.Visible = false;
            txtProtokoll.Visible = true;
            this.nurProtokoll = false;

        }
        public void showTree( )
        {
            treeProtokoll.Visible = true;
            txtProtokoll.Visible = false;
        }
        public void addTree(clTagInfoLog tagInfo, string txt, eIco ico)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode tNod = this.treeProtokoll.Nodes.Add(System.Guid .NewGuid().ToString (), txt );
            tNod.Tag = tagInfo;
            tNod.Override.NodeAppearance.Image = this.imageList1.Images[(int)ico];
        }
        public void showProtokollDetail(clTagInfoLog tagInfo, string txt, eIco ico)
        {

        }

        public void clearTree( )
        {
            this.treeProtokoll.Nodes.Clear();
        }


        private void frmAbrechProt_Load(object sender, EventArgs e)
        {
      
        }

        public void addProtokoll (  string txt, bool addTop )
        {
            if (addTop)
                this.txtProtokoll.Value = txt + this.txtProtokoll.Value;
            else
                this.txtProtokoll.Value += txt;
            
            Application.DoEvents();
        }
        
       private void btnJa_Click(object sender, EventArgs e)
        {
            apport = false;
            if (_closeWhenJa) this.mainWindow.Close();
            actionDone = true;
        }

        private void btnNein_Click(object sender, EventArgs e)
        {
            this.mainWindow.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.mainWindow.Close();
        }

        private void UFormLinkZurücksetzen_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.txtProtokoll.Text, true);
        }

        private void treeProtokoll_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeProtokoll.ActiveNode  != null )
            {
                PMDS.Global.clTagInfoLog tg;
                tg = (clTagInfoLog)this.treeProtokoll.ActiveNode.Tag;
                this.showProtDetail(tg, false );
             }
        }

        public void showProtDetail(clTagInfoLog tg, bool nurProtokoll)
        {

            this.ucProtDetail1.setData("Abrechnungsprotokoll", tg.protDetail, tg );
            this.ucProtDetail1.Visible = true;
            this.nurProtokoll = nurProtokoll;
            if (nurProtokoll) this.ucProtDetail1.btnZurück.Visible = false;
            panelAll.Visible = false;
            this.ucProtDetail1.BorderStyle = BorderStyle.None;
        }

        public void setWithHeight(int w, int h)
        {
            this.Width = w;
            this.Height = Height;

            this.ucProtDetail1.setWithHeight(this.Width, this.Height);
        }
    }
}
