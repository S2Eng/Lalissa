using qs2.core.vb;
using qs2.sitemap.workflowAssist;
using System.Drawing;

namespace qs2.design.auto.workflowAssist.assist
{
    public class cListAssistentElem
    {
        public bool _isOn = false;
        public qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelEntries = null;
        public System.Guid ID = new System.Guid();
        public int IDSelEntry = -999;
        public bool isEditable = false;
        public qs2.sitemap.ui.cButt element = new qs2.sitemap.ui.cButt();
        public bool IsQuerySystem = false;
        public string IDApplication = "";
        public dsAdmin.tblCriteriaRow rCriteria = null;
        public Image picEnabled = null;
        public Image picDisabled = null;
        public contListAssistent ListMain = null;
        public qs2.design.auto.multiControl.ownMCInfo ownMCInfo1 = new design.auto.multiControl.ownMCInfo();
        public qs2.core.Enums.eTypList _TypList;
        public contListAssistent assistent;
    }
}
