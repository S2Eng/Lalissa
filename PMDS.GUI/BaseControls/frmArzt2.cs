using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class frmArzt : QS2.Desktop.ControlManagment.baseForm 
    {
        private bool _bCanclose = false;

        public frmArzt()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AdresseKontaktBasis setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Arzt Arzt
        {
            get { return ucArzt1.Arzt; }
            set {ucArzt1.Arzt = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AerzteRow setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsAerzte.AerzteRow AerzteRow
        {
            get { return ucArzt1.AerzteRow; }
            set {ucArzt1.AerzteRow = value;}
        }

        public void AllowEdit(bool bSwitch)
        {
            this.btnOK.Enabled = bSwitch;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _bCanclose = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Felder vorher überprüfen
            if (!this.ucArzt1.ValidateFields())
                return;

            ucArzt1.UpdateDATA();
            
            _bCanclose = true;
        }

        private void frmArzt_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_bCanclose;
        }

        private void frmArzt_Load(object sender, EventArgs e)
        {
            try
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

                if (PMDS.Global.historie.HistorieOn)
                {
                    this.btnOK.Visible = false;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }
}