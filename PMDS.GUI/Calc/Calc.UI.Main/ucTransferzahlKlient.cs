using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Global;
using PMDS.GUI;




namespace PMDS.Calc.UI.Admin
{

    public partial class ucTransferzahlKlient : QS2.Desktop.ControlManagment.BaseControl
    {

        private Guid _IDPatient = Guid.Empty;
        public event EventHandler ValueChanged;
        private bool _DataChenged = false;
        private string _Error = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte ein gültiges Datum(mm.yyyy) eingeben.");




        public ucTransferzahlKlient()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            this.ucPatientenEinkommen1.initControl();
            this.ucPatientenEinkommen2.initControl();
        }

        public bool Save()
        {
            bool ret1;
            ret1 = ucPatientenEinkommen1.Save();
            if (ret1)
                ret1 = ucPatientenEinkommen2.Save();
            
            if (ret1)
                _DataChenged = false;

            return ret1;
        }

        public bool IsChanged { get { return _DataChenged; } }

        public bool ValidateFields()
        {
            bool validate;
            validate = ucPatientenEinkommen1.ValidateFields();

            if (!validate)
                return false;

            return ucPatientenEinkommen2.ValidateFields();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                _DataChenged = false;
                ucPatientenEinkommen1.IDPatient = _IDPatient;
                ucPatientenEinkommen2.IDPatient = _IDPatient;
            }
        }

         
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void uc_ValueChanged(object sender, EventArgs e)
        {
            _DataChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

    }
}
