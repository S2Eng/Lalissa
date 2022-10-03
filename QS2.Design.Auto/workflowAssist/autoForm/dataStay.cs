using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using qs2.core;
using qs2.core.vb;
using System.Threading;




namespace qs2.design.auto.workflowAssist.autoForm
{


    public class rParam
    {
        public string App;
        public qs2.core.vb.dsObjects.tblStayRow r;
        public bool IsProtocol;
    }


    public class dataStay
    {
        public qs2.core.vb.coreStaysProducts coreStaysProducts;
        public qs2.core.vb.coreStaysProducts coreStaysProductsOrig;
        public qs2.core.vb.coreStaysProducts coreStaysProductsProtocol;

        public qs2.core.vb.sqlObjects sqlObjects1;
        public qs2.core.vb.dsObjects dsObject;
        public qs2.core.vb.dsObjects.tblObjectRow rPatient = null;
        public qs2.core.vb.dsObjects.tblAdressRow rPatientMainAdress = null;
        public qs2.core.vb.Protocol ProtocollManager = null;

        public bool IsNewStay = false;
        public bool isLoaded = false;

        public dsAdmin.tblCriteriaRow[] arrCriteriayLoadImmideatlyxy = null;
        public string sWhereFldShortLoadImmideatlyxy = "";
        public bool ImmediatlyControlsLoadedxy = false;

        public bool dataLoadedPerThread = false;








        public void initDataStay(string Application)
        {
            try
            {
                qs2.design.auto.multiControl.ownMCGeneric.loadRessourceThreeStateButtons();

                this.dsObject = new qs2.core.vb.dsObjects();
                this.sqlObjects1 = new qs2.core.vb.sqlObjects();
                this.sqlObjects1.initControl();
                this.rPatient = null;
                this.rPatientMainAdress = null;

                if (this.isLoaded)
                    return;

                this.coreStaysProducts = new qs2.core.vb.coreStaysProducts();
                this.coreStaysProductsOrig = new qs2.core.vb.coreStaysProducts();
                this.coreStaysProducts.initControl(Application);
                this.coreStaysProductsOrig.initControl(Application);

                this.coreStaysProductsProtocol = new qs2.core.vb.coreStaysProducts();
                this.coreStaysProductsProtocol.initControl(Application);

                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                throw new Exception("dataStay.init: " + ex.ToString());
            }
        }
    }
}
