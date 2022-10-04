using System;
using System.Windows.Forms;
using S2Extensions;

namespace qs2.sitemap.workflowAssist
{
    public partial class contListAssistent : UserControl
    {
        public bool ButtonOKVisible = true;
        
        public ImageList ImgListEnabled = new ImageList();
        public ImageList ImgListDisabled = new ImageList();
        public ImageList ImgListMouseOver = new ImageList();

        public qs2.core.vb.businessFramework b = new qs2.core.vb.businessFramework();
        public bool RightChaptersIsDone = false;
        
        public bool IsInitialized = false;
        public bool IsInitialized2 = false;

        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

        public contListAssistent()
        {
            InitializeComponent();
        }

        public void doAssignments(ref string protocollForAdmin, ref bool ProtocolWindow, int IDSelListCkicked, bool bOn)
        {
            try
            {
                System.Collections.Generic.List<string> lstProcGroupsActive = new System.Collections.Generic.List<string>();
                this.getActiveElements(this, ref lstProcGroupsActive);

                design.auto.ownMCRelationship.eTypAssignments TypAssignments = new design.auto.ownMCRelationship.eTypAssignments();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doAssignmentsDropDown(ref string protocollForAdmin, ref bool ProtocolWindow, int IDSelListCkicked, bool bOn)
        {
            try
            {
                System.Collections.Generic.List<string> lstProcGroupsActive = new System.Collections.Generic.List<string>();
                this.getActiveElements(this, ref lstProcGroupsActive);

                design.auto.ownMCRelationship.eTypAssignments TypAssignments = new design.auto.ownMCRelationship.eTypAssignments();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        public void getActiveElements(contListAssistent assistent, ref System.Collections.Generic.List<string> lstProcGroupsActive)
        {
            foreach (contListAssistentElem ProcGroup in assistent.panelButtons.ClientArea.Controls)
            {
                if (ProcGroup.isOn)
                {
                    lstProcGroupsActive.Add(ProcGroup.cListAssistentElem.element.selListEntryIDOwnStr);
                }
            }
        }
    }
}
