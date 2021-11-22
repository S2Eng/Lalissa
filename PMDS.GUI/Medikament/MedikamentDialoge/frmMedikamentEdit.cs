//----------------------------------------------------------------------------------------------
//  Erstellt am:	21.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI
{
    public partial class frmMedikamentEdit : QS2.Desktop.ControlManagment.baseForm 
    {



        private bool _CanClose = false;

        public frmMedikamentEdit()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            Closing += new CancelEventHandler(this.frm_Closing);
        }

        public string BEZEICHNUNG { get { return ucMedikamentEdit1.BEZEICHNUNG; }}
        //----------------------------------------------------------------------------
        /// <summary>
        /// Neuen Satz erzeugen
        /// </summary>
        //----------------------------------------------------------------------------
        public void New()
        {
            ucMedikamentEdit1.New();
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Medikament lesen und felder befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Read(Guid IDMedikament)
        {
            ucMedikamentEdit1.Read(IDMedikament);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Value
        /// </summary>
        //----------------------------------------------------------------------------
        public object Value
        {
            get { return ucMedikamentEdit1.ID; }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Dialog schließen überwachen
        /// </summary>
        //----------------------------------------------------------------------------
        private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_CanClose;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ucMedikamentEdit1.ValidateFields())
            {
                ucMedikamentEdit1.Write();
                using (DB.DBMedikament DBMedikament1 = new DB.DBMedikament())
                {
                    DBMedikament1.LoadAllMedikamente(true);
                }
                _CanClose = true;
            }
        }

        private void ucMedikamentEdit1_ValueChanged(object sender, EventArgs e)
        {
            _CanClose = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CanClose = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _CanClose = true;
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void frmMedikamentEdit_Load(object sender, EventArgs e)
        {

        }
    }
}