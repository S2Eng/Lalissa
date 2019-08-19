using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinToolbars ;




namespace PMDS.GUI
{
    public partial class ucDateSelect : QS2.Desktop.ControlManagment.BaseControl
    {

        //----------------------------------------------------------------------------
        /// <summary>
        /// Neues Control zur Schnelländerung Rückmeldung
        /// [lth]
        /// </summary>
        //----------------------------------------------------------------------------


        public event PMDS.Global.refreshUI delRefresh ;
        //public event Infragistics.Win.UltraWinToolbars.ToolClickEventHandler  evToolClick;

        private DateTime _datAct;
        


        public ucDateSelect()
        {
            InitializeComponent();
        }

        private void uButtAuswahlZeit_Click(object sender, EventArgs e)
        {

        }

        private void ucDateSelect_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            DateTime dat = new DateTime() ;
            //DateTime actDat;
            //actDat = this._datAct;

            if (e.Tool.Key == "buttJetzt")
            {
                dat = DateTime.Now;
            }
            else if (e.Tool.Key == "buttVorEinerStunde")
            {
                dat = DateTime.Now.AddHours(-1);
            }

            if (this.Visible &&  delRefresh != null)
                delRefresh(dat );
        }

        private void ucDateSelect_Load(object sender, EventArgs e)
        {
            this.uButtAuswahlZeit.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Clock, 32, 32);

            PopupMenuTool popup = (PopupMenuTool)this.ultraToolbarsManager1.Tools["popUpAUswahlZeit"];
            this.uButtAuswahlZeit.PopupItem = popup;

        }

        public  void initToolbar(Boolean bBig )
        {
            if (bBig )
            {
                this.ultraToolbarsManager1.UseLargeImagesOnMenu = true;
                this.ultraToolbarsManager1.UseLargeImagesOnToolbar = true;
            }
            else
            {
                this.ultraToolbarsManager1.UseLargeImagesOnMenu = false;
                this.ultraToolbarsManager1.UseLargeImagesOnToolbar = false;
            }


        }

    }
}
