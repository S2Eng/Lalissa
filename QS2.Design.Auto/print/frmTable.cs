using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using QS2.Resources;



namespace qs2.ui.print
{



    public partial class frmTable : Form
    {

        public string IDRessourceTitle = "";
        public string IDParticipant = "";
        public string TitleAdditionalText  = "";

        public string IDApplication = "";
        public bool selectDatasets = false;
        
        public string defaultTableNameDataMember = "";
        public System.Data.DataSet defaultDs = null;
        public System.Collections.ArrayList lstDatasets;





        public frmTable()
        {
            InitializeComponent();
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            //this.initControl();
        }

        public void initControl( contTable.eTypeUI typeUI, ref string protocol, bool FilterOnOff)
        {
            try
            {
                this.doRes(typeUI);
                this.contTable1.mainWindow = this;
                this.contTable1.initControl(this.selectDatasets, typeUI, FilterOnOff);

                if (this.lstDatasets != null)
                    this.contTable1.fillComboDatasets(lstDatasets);

                if (this.defaultDs != null && this.defaultTableNameDataMember.Trim() != "")
                {
                    bool bTranslateTable = false;
                    if (this.defaultTableNameDataMember.Trim().ToLower().StartsWith(("Qry").Trim().ToLower()))
                    {
                        bTranslateTable = true;
                    }
                    this.contTable1.doTable(this.defaultTableNameDataMember, this.defaultDs, ref protocol, bTranslateTable);
                }

             }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doRes(contTable.eTypeUI typeUI)
        {
            try
            {
                this.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Reports, 32, 32);

                string IDResFound = qs2.core.language.sqlLanguage.getRes(IDRessourceTitle, this.IDParticipant, this.IDApplication);

                if (typeUI == contTable.eTypeUI.Query)
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("ResultQuery") + (IDResFound.Trim().Equals("") ? " " + IDRessourceTitle : " " + qs2.core.language.sqlLanguage.getRes(IDRessourceTitle));
                }
                else if (typeUI == contTable.eTypeUI.History)
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("History") + " " +  (IDResFound.Trim().Equals("") ? "" + IDRessourceTitle : "" + qs2.core.language.sqlLanguage.getRes(IDRessourceTitle)) + " " + this.TitleAdditionalText;
                }
               
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

    }
}
