using System;
using System.Windows.Forms;


namespace qs2.design.auto.workflowAssist.assist
{
    public partial class contListElementDropDown : UserControl
    {
        private bool isLoaded;
        private Infragistics.Win.UltraWinToolbars.PopupControlContainerTool containerDropDown;
        private qs2.core.vb.dsAdmin dsAdminSub = new qs2.core.vb.dsAdmin();

        public qs2.sitemap.workflowAssist.contListAssistentElem mainControl = null;
        public qs2.core.vb.sqlAdmin sqlAdminWork = new qs2.core.vb.sqlAdmin();

        public contListElementDropDown()
        {
            InitializeComponent();
        }

        public void InitControl(string Application, string Participant,
                                int IDSelListEntrySublist, string GroupToLoad)
        {
            if (this.isLoaded)
                return;

            this.dsAdminSub.Clear();
            this.sqlAdminWork.initControl();

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
            this.contSelListsObj1.lockUnlock(bEdit);
        }

        public void valueChanged(int IDSelList, bool bOn, ref string ColumnNameClicked)
        {
            this.mainControl?.valueChanged(IDSelList, bOn, ref ColumnNameClicked);
        }

        private void dropDownElementBottom_Click(object sender, EventArgs e)
        {

        }
    }
}
