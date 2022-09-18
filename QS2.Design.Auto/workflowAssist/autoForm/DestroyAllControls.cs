using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;




namespace qs2.design.auto.workflowAssist.autoForm
{


    public class DestroyAllControls
    {


        public void DisposeAllControls(Control.ControlCollection Controls, qs2.sitemap.workflowAssist.form.frmAutoUI frmAutoUIToDestroy)
        {
            try
            {
                frmAutoUIToDestroy.contAutoUI.dsAdmin1.Clear();
                frmAutoUIToDestroy.rStay = null;
                frmAutoUIToDestroy.rPatient = null;

                frmAutoUIToDestroy.contAutoUI.parentFormAutoUI = null;
                frmAutoUIToDestroy.contAutoUI._license = null;
                frmAutoUIToDestroy.contAutoUI.autoLoadControls = null;
                frmAutoUIToDestroy.contAutoUI.doAutoControls = null;
                frmAutoUIToDestroy.contAutoUI.rStayRead = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.coreStaysProducts = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.coreStaysProductsProtocol = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.sqlObjects1 = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.dsObject = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.rPatient = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.rPatientMainAdress = null;
                frmAutoUIToDestroy.contAutoUI.dataStay.ProtocollManager = null;
                frmAutoUIToDestroy.contAutoUI.dataStay = null;
                frmAutoUIToDestroy.contAutoUI.autoUI1 = null;
                frmAutoUIToDestroy.contAutoUI.rStayRead = null;
                frmAutoUIToDestroy.contAutoUI.doSideLogic1 = null;
                frmAutoUIToDestroy.contAutoUI.buisLogAdminWork = null;
                frmAutoUIToDestroy.contAutoUI.contAutoProtokoll1.dsAdminFields = null;
                frmAutoUIToDestroy.contAutoUI.contAutoProtokoll1.sqlAdminWork = null;
                frmAutoUIToDestroy.contAutoUI.contAutoProtokoll1.dsAdminSys = null;
                frmAutoUIToDestroy.contAutoUI.contAutoProtokoll1.dsAdminFunctions = null;                             

                int iDestroyed = 0;
                bool onlyMC = true;
                this.DestroyControl_rek(null, ref iDestroyed, ref onlyMC, Controls, true);

                //System.Windows.Forms.Application.DoEvents();
                //System.GC.Collect(0, GCCollectionMode.Forced);
                //System.GC.Collect(0, GCCollectionMode.Optimized);
                //System.GC.Collect();
                //System.Windows.Forms.Application.DoEvents();

                frmAutoUIToDestroy.contAutoUI.dsAdmin1 = null;
                frmAutoUIToDestroy.contAutoUI.contAutoProtokoll1.Dispose();
                frmAutoUIToDestroy.contAutoUI = null;

                frmAutoUIToDestroy.Dispose();
                System.Windows.Forms.Application.DoEvents();
                System.GC.Collect(0, GCCollectionMode.Forced);
                System.GC.Collect(0, GCCollectionMode.Optimized);
                System.GC.Collect();
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }

        }

        public void DestroyControl_rek(Control contParentxy, ref int iDestroyed, ref bool onlyOwnMC, Control.ControlCollection Controls, bool IsFirst)
        {
            string sEceptCVontrolName = "";
            try
            {
                Control.ControlCollection ControlsTmp = null;
                if (IsFirst)
                {
                    ControlsTmp = Controls;
                }
                else
                {
                    ControlsTmp = contParentxy.Controls;
                }
                foreach (Control contFound in ControlsTmp)
                {
                    if (contFound != null)
                    {
                        try
                        {
                            sEceptCVontrolName = contFound.Name;
                            if (contFound.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                            {
                                qs2.design.auto.multiControl.ownTab ownTab1 = (qs2.design.auto.multiControl.ownTab)contFound;
                                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tabCont in ownTab1.Tabs)
                                {
                                    this.DestroyControl_rek((Control)tabCont.TabPage, ref iDestroyed, ref  onlyOwnMC, ControlsTmp, false);
                                    if (!onlyOwnMC)
                                    {
                                        ControlsTmp.Remove(tabCont.TabPage);
                                        tabCont.TabPage.Dispose();
                                        tabCont.Dispose();
                                        ownTab1 = null;
                                        iDestroyed += 1;
                                    }
                                }
                                if (!onlyOwnMC)
                                {
                                    ControlsTmp.Remove(ownTab1);
                                    System.Windows.Forms.Application.DoEvents();
                                    ownTab1.Dispose();
                                    iDestroyed += 1;

                                    System.GC.Collect();
                                }
                            }
                            else if (contFound.GetType().Equals(typeof(Infragistics.Win.UltraWinTabControl.UltraTabControl)))
                            {
                                Infragistics.Win.UltraWinTabControl.UltraTabControl ownTab1 = (Infragistics.Win.UltraWinTabControl.UltraTabControl)contFound;
                                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tabCont in ownTab1.Tabs)
                                {
                                    this.DestroyControl_rek((Control)tabCont.TabPage, ref iDestroyed, ref  onlyOwnMC, ControlsTmp, false);
                                    if (!onlyOwnMC)
                                    {
                                        ControlsTmp.Remove(tabCont.TabPage);
                                        tabCont.TabPage.Dispose();
                                        tabCont.Dispose();
                                        iDestroyed += 1;
                                    }
                                }
                                if (!onlyOwnMC)
                                {
                                    ControlsTmp.Remove(ownTab1);
                                    System.Windows.Forms.Application.DoEvents();
                                    ownTab1.Dispose();
                                    ownTab1 = null;
                                    iDestroyed += 1;

                                    System.GC.Collect();
                                }
                            }
                            else
                            {
                                this.DestroyControl_rek(contFound, ref iDestroyed, ref onlyOwnMC, ControlsTmp, false);
                            }
                        }
                        catch (Exception ex3)
                        {
                            string xy = ex3.ToString();
                        }
                    }
                }

                if (contParentxy != null)
                {
                    if (!onlyOwnMC)
                    {
                        try
                        {
                            ControlsTmp.Remove(contParentxy);
                            System.Windows.Forms.Application.DoEvents();
                        }
                        catch (Exception ex2)
                        {
                            string xy = ex2.ToString();
                        }
                        try
                        {
                            contParentxy.Dispose();
                            contParentxy = null;

                            System.GC.Collect(0, GCCollectionMode.Forced);
                            System.GC.Collect(0, GCCollectionMode.Optimized);
                            System.GC.Collect();

                            iDestroyed += 1;
                        }
                        catch (Exception ex2)
                        {
                            string xy = ex2.ToString();
                        }
                    }
                    else
                    {
                        if (contParentxy.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                        {
                            qs2.design.auto.multiControl.ownMultiControl MC = (qs2.design.auto.multiControl.ownMultiControl)contParentxy;
                            MC.unloadControl();
                            iDestroyed += 1;
                        }
                        else if (contParentxy.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                        {
                            qs2.design.auto.multiControl.ownMultiGridSelList MG = (qs2.design.auto.multiControl.ownMultiGridSelList)contParentxy;
                            MG.unloadControl();
                            iDestroyed += 1;
                        }
                        else if (contParentxy.GetType().Equals(typeof(qs2.sitemap.workflowAssist.contListAssistent)))
                        {
                            qs2.sitemap.workflowAssist.contListAssistent LA = (qs2.sitemap.workflowAssist.contListAssistent)contParentxy;
                            LA.unloadControl();
                            iDestroyed += 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string xy = ex.ToString();
            }
        }

        public void DestroyControl_Comprek(object components, ref int iDestroyed, Control.ControlCollection Controls)
        {
            try
            {
                System.ComponentModel.Container Container1 = new System.ComponentModel.Container();
                Container1 = (System.ComponentModel.Container)components;

                foreach (Object componentFound in Container1.Components)
                {
                    if (componentFound.GetType().Equals(typeof(UltraToolbarsManager)))
                    {
                        UltraToolbarsManager tm = (UltraToolbarsManager)componentFound;
                        tm.Dispose();
                        tm = null;
                        iDestroyed += 1;
                    }
                    else if (componentFound.GetType().Equals(typeof(ContextMenuStrip)))
                    {
                        ContextMenuStrip cms = (ContextMenuStrip)componentFound;
                        cms.Dispose();
                        cms = null;
                        iDestroyed += 1;
                    }
                    else if (componentFound.GetType().Equals(typeof(MenuStrip)))
                    {
                        MenuStrip ms = (MenuStrip)componentFound;
                        ms.Dispose();
                        ms = null;
                        iDestroyed += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DestroyControl: " + ex.ToString());
            }
        }

    }
}
