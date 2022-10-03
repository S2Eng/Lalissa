using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinTabControl;



namespace qs2.design.auto.workflowAssist.autoForm
{



    public class doSideLogic
    {

        public qs2.core.vb.sqlAdmin sqlAdminWork = null;
        public qs2.core.vb.dsAdmin dsAdminWork = null;

        public bool isLoaded = false;

        

        public void initControl()
        {
            try
            {
                if (this.isLoaded)
                    return;

                this.dsAdminWork = new qs2.core.vb.dsAdmin();
                this.sqlAdminWork = new qs2.core.vb.sqlAdmin();
                this.sqlAdminWork.initControl();

                this.isLoaded = true;

            }
            catch (Exception ex)
            {
                throw new Exception("doSideLogic.doSideLogic: " + ex.ToString());
            }
        }
    }
}
