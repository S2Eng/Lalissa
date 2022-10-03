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





namespace qs2.design.auto.workflowAssist.autoForm
{

    public class doAutoControls
    {

        public dsAdmin dsAdminWork = new dsAdmin();
        public sqlAdmin sqlAdminWork = null;

        public enum eTypActivityControl
        {
            fillData = 0,
            edit = 1,
            validate = 3,
            save = 4,
            doRelationsship = 6,
            doPicturesInit = 7,
            runPictures = 8,
            checkAssignments = 9,
            initControl = 10,
            doAutoPrintDll = 11,
            LoadDataAutoUI = 12,
            ClearFocus = 13,
            getTableAdditions = 14,
            doVisible = 15,
            ResetToDefaultValues = 16,
            ResetToDefaultValuesParentGuid = 17,
            CheckValuesInDeactivatedChapters = 18,
            ClearMC = 19,
            checkTabs = 20
        }

        public class eRetDoControls
        {

        }
        
        public static string _prototocollCheck = "";

        public void initClass()
        {
            if (this.sqlAdminWork == null)
            {
                this.sqlAdminWork = new sqlAdmin();
                this.sqlAdminWork.initControl();
            }
            this.dsAdminWork.Clear();
        }
    }
}
