using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using QS2.Resources;

using System.Runtime.InteropServices;





namespace qs2.sitemap.workflowAssist.form
{
    public partial class frmAutoUI : Form
    {
        private string _IDResTitleForm = "Stay";
        public qs2.core.license.doLicense.eApp Application;
        public int numberForm = 0;
        public qs2.core.vb.dsObjects.tblStayRow rStay;
        public qs2.core.vb.dsObjects.tblObjectRow rPatient;
        public bool SaveWasClicked = false;
        public bool isInEditMode = false;
        public contAutoUI contAutoUI = null;
        private qs2.design.auto.workflowAssist.autoForm.tgWindowHandler tgWindowHandlerWindow = null;
        public bool evDoRefreshStayListIsInitialized = false;
        public event doRefreshStayList evDoRefreshStayList;
        public delegate void doRefreshStayList();
        private bool closeFormAuto = false;
        public bool WasVisibleFirst = false;
        private Timer TimerAppClosesbyuser = null;
        private bool FormSucessfulClosed = false;
        public bool IsInitialized = false;
        public qs2.design.auto.workflowAssist.autoForm.dataStay dataStay = new design.auto.workflowAssist.autoForm.dataStay();
        private FormWindowState prevState;
        private bool doFctSetUI = true;
        private bool DoNotLoadData = false;
    }
}
