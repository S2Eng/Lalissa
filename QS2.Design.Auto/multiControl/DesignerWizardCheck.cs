using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;




namespace qs2.design.auto.multiControl
{


    internal class DesignerWizardCheck : ControlDesigner, ITypeDescriptorContext
    {

        private DesignerVerbCollection m_verbs;



        #region Overrides

        /// <summary>
        /// Wird bei der Initialisierung des Designers aufgerufen, so dass der Designer für Eigenschaften der Komponente Standardwerte festlegen kann.
        /// </summary>
        public override void OnSetComponentDefaults()
        {
            base.OnSetComponentDefaults();

            // Prüfen, ob Assistent aufgerufen werden soll
            //Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\dotnetpro\CaptionBarControl", true);
            //if (regKey != null)
            //{
            //    if ((int)regKey.GetValue("ShowOnStartUp", 1) == 1)
            //    {
            //        FormTestDesigner wizard = new FormTestDesigner();
            //        wizard.ShowDialog();
            //    }
            //}
        }

        /// <summary>
        /// Ruft die Entwurfszeitverben ab, die von der dem Designer zugeordneten Komponente unterstützt werden.
        /// </summary>
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (m_verbs == null)
                {
                    qs2.design.auto.multiControl.ownMultiControl ownMultiControlCHeck = new qs2.design.auto.multiControl.ownMultiControl();
                    qs2.design.auto.multiControl.ownTab ownMultiTabCheck = new qs2.design.auto.multiControl.ownTab();

                    m_verbs = new DesignerVerbCollection();
                    DesignerVerb CheckCriterias = new DesignerVerb("Check Criterias...", new EventHandler(this.OnCheckCriterias));
                    m_verbs.Add(CheckCriterias);

                    if (!this.Component.GetType().Equals(ownMultiTabCheck.GetType()))
                    {
                        DesignerVerb CheckRFessourcen = new DesignerVerb("Check Ressourcen...", new EventHandler(this.OnCheckRessourcen));
                        m_verbs.Add(CheckRFessourcen);

                        DesignerVerb SimulateControl = new DesignerVerb("Simulate Control...", new EventHandler(this.OnSimulateControl));
                        m_verbs.Add(SimulateControl);

                        if (this.Component.GetType().Equals(ownMultiControlCHeck.GetType()))
                        {
                            ownMultiControlCHeck = (qs2.design.auto.multiControl.ownMultiControl)this.Component;
                            if (ownMultiControlCHeck._controlType == core.Enums.eControlType.ComboBox)
                            {
                                DesignerVerb CheckSelList = new DesignerVerb("Check Selection-List...", new EventHandler(this.OnCheckSelList));
                                m_verbs.Add(CheckSelList);
                            }

                            DesignerVerb CheckInfoFielddDB = new DesignerVerb("Info Field Database...", new EventHandler(this.OnCheckInfoFieldDB));
                            m_verbs.Add(CheckInfoFielddDB);
                        }
                    }

                    //DesignerVerb verbPropertyPages = new DesignerVerb(
                    //    "Anpassen...",
                    //    new EventHandler(this.OnPropertyPages));
                    //m_verbs.Add(verbPropertyPages);
                }
                return m_verbs;
            }
        }
        //private void OnPropertyPages(object sender, EventArgs e)
        //{
        //    CaptionBarComponentEditor editor = new CaptionBarComponentEditor();
        //    if (editor.EditComponent(this, this.Component, null))
        //        this.RaiseComponentChanged(null, null, null);
        //}

        #endregion
        private void OnCheckCriterias(object sender, EventArgs e)
        {
            try
            {
               string fldShort = this.logInAssistent(false);

                core.license.doLicense.eApp enumAppFound = qs2.core.generic.searchEnumApplication((String)qs2.core.ENV.developApplication);
                qs2.sitemap.manage.wizardsDevelop.frmCriterias frmCrit = new qs2.sitemap.manage.wizardsDevelop.frmCriterias();
                frmCrit.contCriterias1.IDApplication = qs2.core.ENV.developApplication;
                frmCrit.contCriterias1.IDParticipant = qs2.core.ENV.developParticipant;
                frmCrit.doSearchAuto = true;
                frmCrit.searchAuto = fldShort.Trim();
                frmCrit.defaultApplication = enumAppFound.ToString();
                frmCrit.loadForm(sitemap.manage.wizardsDevelop.contCriterias.eTypeUI.Admin);
                if (frmCrit.ShowDialog() == DialogResult.OK)
                    this.RaiseComponentChanged(null, null, null);

                //frmCrit.Show();
                //frmCrit.contCriterias1.initControl(enumAppFound, ownMultiControl1.OwnFldShort);
            }
            catch (Exception ex)
            {
                throw new Exception("DesignerWizardCheck.OnCheckCriterias:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
            finally
            {
            }
        }
        private void OnCheckRessourcen(object sender, EventArgs e)
        {
            try
            {
                string fldShort = this.logInAssistent(false);

                core.license.doLicense.eApp enumAppFound = qs2.core.generic.searchEnumApplication((String)qs2.core.ENV.developApplication);
                qs2.sitemap.manage.wizardsDevelop.frmRessourcen frmRes = new qs2.sitemap.manage.wizardsDevelop.frmRessourcen();
                frmRes.contRessourcen1.IDApplication = qs2.core.ENV.developApplication;
                frmRes.contRessourcen1.IDParticipant = qs2.core.ENV.developParticipant;
                frmRes.doSearchAuto = true;
                frmRes.searchAuto = fldShort.Trim();
                frmRes.defaultApplication = enumAppFound.ToString();
                if (frmRes.ShowDialog() == DialogResult.OK)
                    this.RaiseComponentChanged(null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception("DesignerWizardCheck.OnCheckRessourcen:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
            finally
            {
            }
        }
        private void OnCheckSelList(object sender, EventArgs e)
        {
            try
            {
                string fldShort = this.logInAssistent(false);
                                
                core.license.doLicense.eApp enumAppFound = qs2.core.generic.searchEnumApplication((String)qs2.core.ENV.developApplication);
                qs2.sitemap.vb.frmSelLists frmSelList = new qs2.sitemap.vb.frmSelLists();
                frmSelList.ContSelList1.Username = "VisualStudio";
                frmSelList.typeUI = sitemap.vb.frmSelLists.eTypeUI.Administration;
                frmSelList.ContSelList1.defaultApplication = enumAppFound.ToString();
                frmSelList.ContSelList1.IDParticipant = qs2.core.ENV.developParticipant;
                frmSelList.doSearchAuto = true;
                frmSelList.searchAuto = fldShort.Trim();
                if (frmSelList.ShowDialog() == DialogResult.OK)
                    this.RaiseComponentChanged(null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception("DesignerWizardCheck.OnCheckSelList:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
            finally
            {
            }
        }
        private void OnCheckInfoFieldDB(object sender, EventArgs e)
        {
            try
            {
                string fldShort = this.logInAssistent(false);

                core.license.doLicense.eApp enumAppFound = qs2.core.generic.searchEnumApplication((String)qs2.core.ENV.developApplication);
                qs2.sitemap.workflowAssist.frmInfoFieldDB frmInfoDB = new qs2.sitemap.workflowAssist.frmInfoFieldDB();
                frmInfoDB.contInfoFieldDB1.searchColumnText = fldShort;
                frmInfoDB.contInfoFieldDB1.IDApplication = qs2.core.ENV.developApplication;
                frmInfoDB.contInfoFieldDB1.IDParticipant = qs2.core.ENV.developParticipant;
                if (frmInfoDB.ShowDialog() == DialogResult.OK)
                    this.RaiseComponentChanged(null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception("DesignerWizardCheck.OnCheckInfoFieldDB:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
            finally
            {
            }
        }
        
        private void OnSimulateControl(object sender, EventArgs e)
        {
            try
            {
                string fldShort = this.logInAssistent(true);

                //qs2.sitemap.manage.wizardsDevelop.frmSimulateControl frmSimulate = new qs2.sitemap.manage.wizardsDevelop.frmSimulateControl();
                //frmSimulate.ownMultiControl1 = ownMultiControl1;

                //frmSimulate.ownMultiControl1.OwnControlType = ownMultiControl1.OwnControlType;
                //frmSimulate.ownMultiControl1.OwnFldShort = ownMultiControl1.OwnFldShort;
                //frmSimulate.ownMultiControl1.OwnLevelLeftOrientationHoriz = ownMultiControl1.OwnLevelLeftOrientationHoriz;
                //frmSimulate.ownMultiControl1.OwnLevelLeftVisible = ownMultiControl1.OwnLevelLeftVisible;
                //frmSimulate.ownMultiControl1.OwnLevelLeftWith = ownMultiControl1.OwnLevelLeftWith;
                //frmSimulate.ownMultiControl1.OwnLevelRightVisible = ownMultiControl1.OwnLevelRightVisible;
                //frmSimulate.ownMultiControl1.OwnLevelRightWith = ownMultiControl1.OwnLevelRightWith;
                //frmSimulate.ownMultiControl1.OwnLevelTopVisible = ownMultiControl1.OwnLevelTopVisible;

                //if (frmSimulate.ShowDialog() == DialogResult.OK)
                //    this.RaiseComponentChanged(null, null, null);
 
            }
            catch (Exception ex)
            {
                throw new Exception("DesignerWizardCheck.OnSimulateControl:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
            finally
            {
            }
        }

        private string logInAssistent(bool simulateControl)
        {
            try
            {
                qs2.core.logIn.connectDesignMode();
                qs2.core.vb.ui.loadStyleInfrag(true, "Light", "VS Designer");
                string FldShort = "";

                if (this.Component.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                {
                    qs2.design.auto.multiControl.ownMultiControl ownMultiControlCHeck = new qs2.design.auto.multiControl.ownMultiControl();
                    ownMultiControlCHeck = (qs2.design.auto.multiControl.ownMultiControl)this.Component;
                    FldShort = ownMultiControlCHeck._FldShort;
                    if (simulateControl) ownMultiControlCHeck.doControl();
                }
                else if (this.Component.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                {
                    qs2.design.auto.multiControl.ownGroupBox groupBoxCheck = new qs2.design.auto.multiControl.ownGroupBox();
                    groupBoxCheck = (qs2.design.auto.multiControl.ownGroupBox)this.Component;
                    FldShort = groupBoxCheck._FldShort;
                    if (simulateControl) groupBoxCheck.doControl();
                }
                else if (this.Component.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                {
                    qs2.design.auto.multiControl.ownMultiGridSelList ownMultiGridSelList1 = new qs2.design.auto.multiControl.ownMultiGridSelList();
                    ownMultiGridSelList1 = (qs2.design.auto.multiControl.ownMultiGridSelList)this.Component;
                    FldShort = ownMultiGridSelList1._FldShortTitle;
                    if (simulateControl) ownMultiGridSelList1.doControl();
                }
                return FldShort;
            }
            catch (Exception ex)
            {
                throw new Exception("DesignerWizardCheck.logInAssistent:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            return this.GetService(serviceType);
        }


        #region ITypeDescriptorContext Member


        /// <summary>
        /// Löst das System.ComponentModel.Design.IComponentChangeService.ComponentChanged-Ereignis aus.
        /// </summary>
        public void OnComponentChanged()
        {
        }

        /// <summary>
        /// Gibt einen Wert zurück, der angibt, ob dieses Objekt geändert werden kann.
        /// </summary>
        /// <returns>true, wenn dieses Objekt geändert werden kann, andernfalls false.</returns>
        public bool OnComponentChanging()
        {
            return false;
        }

        /// <summary>
        /// Ruft den Container ab, der diese System.ComponentModel.TypeDescriptor-Anforderung darstellt.
        /// </summary>
        public IContainer Container
        {
            get { return this.Container; }
        }

        /// <summary>
        /// Ruft die Instanz des Objekts ab, das mit dieser System.ComponentModel.TypeDescriptor-Anforderung verknüpft ist.
        /// </summary>
        public object Instance
        {
            get { return this.Component; }
        }

        /// <summary>
        /// Ruft den System.ComponentModel.PropertyDescriptor ab, der das angegebene Kontextelement beschreibt.
        /// </summary>
        public PropertyDescriptor PropertyDescriptor
        {
            get { return null; }
        }

        #endregion
    }
}
