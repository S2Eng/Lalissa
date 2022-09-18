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

    public partial class frmCryCrystRepViewer : Form
    {




        public frmCryCrystRepViewer()
        {
            InitializeComponent();
        }

        private void frmCryCrystRepViewer_Load(object sender, EventArgs e)
        {
            try
            {
                this.contQryCrystRepViewer1.doReport();
              
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void initControl()
        {
            try
            {
                this.doRes();
                this.contQryCrystRepViewer1.mainWindow = this;
                this.contQryCrystRepViewer1.initControl();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doRes()
        {
            try
            {
                string IDResFound = qs2.core.language.sqlLanguage.getRes(this.contQryCrystRepViewer1.infoReport.rSelListReport.IDRessource, this.contQryCrystRepViewer1.infoReport.Participant, this.contQryCrystRepViewer1.infoReport.Application);
                this.Text = qs2.core.language.sqlLanguage.getRes("ResultReport") + (IDResFound.Trim().Equals("") ? " " + this.contQryCrystRepViewer1.infoReport.rSelListReport.IDRessource : " " + qs2.core.language.sqlLanguage.getRes(this.contQryCrystRepViewer1.infoReport.rSelListReport.IDRessource));
                
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
