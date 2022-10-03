using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QS2.Resources;



namespace qs2.design.auto.workflowAssist.assist
{


    public partial class contListElementDropDown : UserControl
    {

        public bool isLoaded = false;
        public bool isEditable = false;

        public Infragistics.Win.UltraWinToolbars.PopupControlContainerTool containerDropDown = null;
        public string _Application = "";
        public string _Participant = "";
        public qs2.sitemap.workflowAssist.contListAssistentElem mainControl = null;

        public qs2.core.vb.sqlAdmin sqlAdminWork = new qs2.core.vb.sqlAdmin();
        public qs2.core.vb.dsAdmin dsAdminSub = new qs2.core.vb.dsAdmin();







        public contListElementDropDown()
        {
            InitializeComponent();
        }

        public void InitControl(qs2.core.Enums.eTypList TypList, string Application, string Participant,
                                int IDSelListEntrySublist, string GroupToLoad)
        {
            if (this.isLoaded)
                return;

            this._Application = Application;
            this._Participant = Participant;

            this.dsAdminSub.Clear();
            this.sqlAdminWork.initControl();

            //this.dropDownElementBottom.Appearance.Image = qs2.Resources.getRes.getImage(getRes.ePicture.ico_OK , getRes.ePicTyp.ico);

            this.containerDropDown = (Infragistics.Win.UltraWinToolbars.PopupControlContainerTool)this.toolBarDropDown.Tools["PopupControlContainerToolElement"];
            this.dropDownElementBottom.PopupItem = this.containerDropDown;

            this.contSelListsObj1.delonValueChanged += new sitemap.vb.contSelListsObj.onValueChanged(this.valueChanged);

            this.doRes();

            System.Collections.ArrayList lstClassification = new System.Collections.ArrayList();
            this.contSelListsObj1.TypeStr = "";
            this.contSelListsObj1._idObject_IDSelListEntrySublist_IDStay = -999;
            this.contSelListsObj1.grpToLoad = GroupToLoad;
            this.contSelListsObj1.typDB = core.vb.sqlAdmin.eDbTypAuswObj.ProceduresToStay;
            this.contSelListsObj1.typ = sitemap.vb.contSelListsObj.eTyp.saveForStay;
            this.contSelListsObj1.initControl(Infragistics.Win.DefaultableBoolean.True, "Procedures", false, false, lstClassification, 
                                                Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns, sitemap.vb.contSelListsObj.eTypUI.Procedures,
                                                 false, Application, Participant);
            //this.contSelListsObj1.loadData(IDSelListEntrySublist);
            this.lockUnlock(false);

            this.isLoaded = true;
        }

        public void doRes()
        {
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            toolTipInfo.ToolTipText = qs2.core.language.sqlLanguage.getRes("AssignProceduresToTheProcedureGroup");
            toolTipInfo.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("Procedures");
            ultraToolTipManager1.SetUltraToolTip(this.dropDownElementBottom, toolTipInfo);
        }

        private void dropDownElementBottom_MouseUp(object sender, MouseEventArgs e)
        {

        }

        public void resetDropDownProcGroupsMain(System.Guid IDElementClicked, int IDSelListEntrySubList,ref string ColumnNameClicked)
        {
            this.contSelListsObj1.resetDropDownProcGroupsMain(true, -999, ref ColumnNameClicked );
        }

        public void lockUnlock(bool bEdit)
        {
            this.isEditable = bEdit;
            this.contSelListsObj1.lockUnlock(bEdit);
        }

        public void valueChanged(int IDSelList, bool bOn, ref string ColumnNameClicked)
        {
            if (this.mainControl != null)
            {
                this.mainControl.valueChanged(IDSelList, bOn, ref ColumnNameClicked);
            }   
        }

        private void dropDownElementBottom_Click(object sender, EventArgs e)
        {

        }
    }
}
