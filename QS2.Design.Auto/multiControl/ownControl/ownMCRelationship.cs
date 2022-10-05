using System;
using System.Collections.Generic;
using Infragistics.Win.UltraWinTabControl;

namespace qs2.design.auto
{
    public class ownMCRelationship
    {
        public qs2.core.vb.sqlAdmin sqlAdmin1;

        public enum eTypAssignments
        {
            AutoSaveToChapter = 45700,
            ProcGroup = 45701,
            ChapterDropDownList = 45702,
            ProcGroupDropDownList = 45703,
            Roles = 45704,
            MCParent = 45705,
            none = 45799
        }
    }
}
