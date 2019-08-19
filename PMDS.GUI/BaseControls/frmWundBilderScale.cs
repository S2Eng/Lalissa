using PMDS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{

    public partial class frmWundBilderScale : Form
    {

        public bool abort = true;
        public PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new Global.db.ERSystem.PMDSBusinessUI();
        public bool IsInitialized = false;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI bUI2 = new PMDSBusinessUI();

        public enum eActionUI
        {
            Scale = 0,
            ResetToOrig = 1,
            DeleteOrigPictures = 2
        }







        public frmWundBilderScale()
        {
            InitializeComponent();
        }

        private void frmWundBilderScale_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                    this.numWidthHeight.Value = 1200;
                    this.optTypeUI.CheckedIndex = 0;

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        var tWundPosBilder = (from w in db.WundePosBilder
                                            where !(from o in db.WundePos select o.ID).Contains(w.IDWundePos)
                                             select new
                                             {
                                                 ID = w.ID
                                             }).ToList();

                        if (tWundPosBilder.Count() > 0)
                        {
                            this.lblInfo.Visible = true;
                            this.btnSave.Enabled = false;
                        }
                        else
                        {
                            this.lblInfo.Visible = false;
                            this.btnSave.Enabled = true;
                        }
                    }


                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundBilderScale.initControl: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this.optTypeUI.Value.ToString().Trim().ToLower().Equals(eActionUI.Scale.ToString().Trim().ToLower()))
                    {
                        string sProt = "";
                        int iErrorNr = 0;
                        this.bUI.WundBilderScale(db, ref this.ultraProgressBar1, (int)this.numWidthHeight.Value, ref sProt, ref iErrorNr);

                        if (sProt.Trim() != "")
                        {
                            qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                            frmProt.initControl();
                            frmProt.Show();
                            frmProt.ContProtocol1.setText(sProt);
                            frmProt.Text = "Protokoll scale pictures";
                        }
                    }
                    else if (this.optTypeUI.Value.ToString().Trim().ToLower().Equals(eActionUI.ResetToOrig.ToString().Trim().ToLower()))
                    {
   
                        this.bUI.WundBilderResetToOrig(db, ref this.ultraProgressBar1);
                    }
                    else if (this.optTypeUI.Value.ToString().Trim().ToLower().Equals(eActionUI.DeleteOrigPictures.ToString().Trim().ToLower()))
                    {
          
                        this.bUI.WundBilderDeleteOrigPictures(db, ref this.ultraProgressBar1);
                    }
                    else
                    {
                        throw new Exception("saveData: this.optTypeUI.Value '" + this.optTypeUI.Value.ToString() + "' not allowed!");
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("frmWundBilderScale.saveData: " + ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
