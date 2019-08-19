using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.DB;


namespace PMDS.GUI.Datenerhebung
{

    public partial class ucDatenErhebungExtern : UserControl
    {

        public string _lstFormulare = "";
        public bool isInitialized = false;
        public bool DatenerhebungIsInitialized = false;
        
        public frmDatenErhebung mainWindow = null;
        public PMDSBusiness b = new PMDSBusiness();

        public ucDatenErhebung ucDatenErhebung1 = null;







        public ucDatenErhebungExtern()
        {
            InitializeComponent();
        }


        private void ucDatenErhebungExtern_Load(object sender, EventArgs e)
        {

        }


        public void initControl(string lstFormulare)
        {
            try
            {
                if (!this.isInitialized)
                {
                    this._lstFormulare = lstFormulare;

                    this.initDatenerhebung();
                    this.loadData();

                    this.isInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDatenErhebungExtern.initControl: " + ex.ToString());
            }
        }

        public void initDatenerhebung()
        {
            try
            {
                if (!this.DatenerhebungIsInitialized)
                {
                    System.Collections.Generic.List<string> lstSelectedFormulare = qs2.core.generic.readStrVariables(this._lstFormulare.Trim());

                    this.ucDatenErhebung1 = new ucDatenErhebung();
                    this.ucDatenErhebung1.FRAMEWORK = null;
                    this.ucDatenErhebung1.Dock = DockStyle.Fill;
                    this.ucDatenErhebung1.lstFormulare = lstSelectedFormulare;
                    this.panelDatenerhebnung.Controls.Add(this.ucDatenErhebung1);

                    this.ucDatenErhebung1.mainWindowDatenerhebnungExtern = this;
                    this.ucDatenErhebung1.IsExternControl = true;
                    //this.ucDatenErhebung1.loadMainSite();

                    this.DatenerhebungIsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucNotfall.initDatenerhebung: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                //{
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucDatenErhebungExtern.loadData: " + ex.ToString());
            }
        }

    }

}
