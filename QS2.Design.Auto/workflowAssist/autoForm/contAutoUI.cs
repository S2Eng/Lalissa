using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTabs;
using qs2.core.vb;
using qs2.design.auto.workflowAssist.autoForm;
using System.Threading;
using S2Extensions;

namespace qs2.sitemap.workflowAssist.form
{

    public partial class contAutoUI : UserControl
    {
        public license _license;

        public qs2.design.auto.workflowAssist.autoForm.autoLoadControls autoLoadControls = null;
        public qs2.design.auto.workflowAssist.autoForm.doAutoControls doAutoControls = null;

        public qs2.core.vb.dsObjects.tblStayRow rStayRead;
        public qs2.design.auto.workflowAssist.autoForm.dataStay dataStay;
        public static bool LoadingStayData = false;
        public bool _PatientVisible = false;
      
        
        public static string tabNameProtokoll = "protokoll";
        public qs2.core.Enums.eStayTyp loadedStayTyp;
        public qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1 = null;
        public qs2.design.auto.workflowAssist.autoForm.doSideLogic doSideLogic1 = null;
        public bool AllControlsDone = false;
        public bool GenAutoPrintDllDone = false;
        public string protocolldoActionAllControls = "";
        public bool _ShowAllStayTypes = false;
        public bool IsInitialized = false;

        public businessFramework buisLogAdminWork = new businessFramework();
        public bool _runAsSystemuser = false;
        public int _runAsUser = -999;
        public bool IsFirstLoad = true;

        public bool resetOpenModeOnClose = true;

        public System.Collections.Generic.SortedDictionary<int, qs2.design.auto.workflowAssist.assist.cListAssistentElem> lstAllChapters = new SortedDictionary<int, design.auto.workflowAssist.assist.cListAssistentElem>();
        public System.Collections.Generic.SortedDictionary<int, string> lstAllChaptersActive = new SortedDictionary<int, string>();

        public System.Collections.Generic.List<string> lstChaptersClickedFromUser = new List<string>();

        public static bool _isNew2 = false;
        public bool _OpendFromEvaluation = false;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

        public qs2.ui.print.frmQryRunReport frmQryRunReport1 = null;
    }
}
