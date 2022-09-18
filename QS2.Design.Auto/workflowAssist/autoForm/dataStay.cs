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

        public void thLoad(rParam px)
        {
            try
            {
                this.load(px.App, ref px.r, true);
                this.dataLoadedPerThread = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("thLoad: " + ex.ToString());
            }
        }
        public void load(string Application, ref qs2.core.vb.dsObjects.tblStayRow rStayRead, bool loadAll)
        {
            try
            {
                //Load Stay (no thread, wait until loaded)
                if (loadAll)
                {
                    this.coreStaysProducts.loadStays(rStayRead, Application);
                    this.sqlObjects1.getStay(rStayRead.ID, "", System.DateTime.Now, System.DateTime.Now, ref this.dsObject, core.vb.sqlObjects.eTypSelStay.IDIDApplicationIDParticipant, Application, (core.Enums.eStayTyp)rStayRead.StayTyp, rStayRead.IDParticipant, System.Guid.NewGuid(), "", core.Enums.eSearchType.Simple, false, -1, null, -1, false, "", "", -1, -1, -1, "");
                }

                //Load Stay for Protocol and Original-Value as Thread
                rParam px = new rParam();
                px.App = Application;
                px.r = rStayRead;

                Thread threadOrig = new Thread(() => thOrig(px));
                threadOrig.Start();

                Thread threadProtocol = new Thread(() => thProtocol(px));
                threadProtocol.Start();


                rStayRead = this.sqlObjects1.getStaysRow(-999, sqlObjects.eTypSelStay.IDGuidStay, "", Enums.eStayTyp.All, "", rStayRead.IDGuid, false);
                if (loadAll)
                {
                    this.sqlObjects1.getObject(-999, ref this.dsObject, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.IsPatient, "", "", false, rStayRead.PatIDGuid);
                    if (this.dsObject.tblObject.Rows.Count != 1)
                    {
                        throw new Exception("dataStay.load: this.dsObject.tblObject.Rows.Count != 1 for MedRecNr '" + rStayRead.MedRecN + "'!");
                    }
                    else
                    {
                        this.rPatient = (qs2.core.vb.dsObjects.tblObjectRow)this.dsObject.tblObject.Rows[0];
                    }

                    this.sqlObjects1.getAdress(this.rPatient.IDGuid, ref this.dsObject, sqlObjects.eTypSelAdr.idObject);
                    if (this.dsObject.tblAdress.Rows.Count != 1)
                    {
                        throw new Exception("dataStay.load: this.dsObject.tblAdress.Rows.Count != 1 for MedRecNr '" + rStayRead.MedRecN + "'!");
                    }
                    else
                    {
                        this.rPatientMainAdress = (qs2.core.vb.dsObjects.tblAdressRow)this.dsObject.tblAdress.Rows[0];
                    }
                }

             }
            catch (Exception ex)
            {
                throw new Exception("dataStay.load: " + ex.ToString());
            }
        }
        public void thOrig(rParam px)
        {
            try
            {
                this.coreStaysProductsOrig.loadStays(px.r, px.App);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("thOrig: " + ex.ToString());
            }
        }
        public void thProtocol(rParam px)
        {
            try
            {
                this.coreStaysProductsProtocol.loadStays(px.r, px.App);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("thOrig: " + ex.ToString());
            }
        }

    }
}
