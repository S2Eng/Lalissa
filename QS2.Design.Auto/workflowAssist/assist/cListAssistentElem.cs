using qs2.core.vb;
using qs2.sitemap.workflowAssist;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;




namespace qs2.design.auto.workflowAssist.assist
{
    

    public class cListAssistentElem
    {
        public bool _isOn = false;
        public bool isOKOn = false;
        public int counterActivated = 0;

        public qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelEntries = null;
        public System.Guid ID = new System.Guid();
        public int IDSelEntry = -999;

        public bool isEditable = false;
        public qs2.sitemap.ui.cButt element = new qs2.sitemap.ui.cButt();
        public string TxtButton = "";

        public bool IsQuerySystem = false;
        public string IDApplication = "";

        public string sqlTable = "";
        public string sqlColumn = "";

        public bool IsVisibleForStayType = false;
        public bool IsVisibleForChapterSelection = false;
        public bool IsVisibleClassificationSelList = true;
        public bool IsVisibleForSystemuser = true;

        public dsAdmin.tblCriteriaRow rCriteria = null;
        public qs2.design.auto.ownMCRelationship ownMCRelationship = null;

        public Image picEnabled = null;
        public Image picDisabled = null;
        public Image picMouseOver = null;

        public string IDGroupStr = "";
        public contListAssistent ListMain = null;
        public qs2.design.auto.multiControl.ownMCInfo ownMCInfo1 = new design.auto.multiControl.ownMCInfo();
        public qs2.core.Enums.eTypList _TypList;
        public contListAssistent assistent = null;

        public bool isReloaded = false;
        public bool AlwaysEditable = false;
    }

}
