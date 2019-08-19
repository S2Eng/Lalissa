using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Calc.UI.Admin;
using PMDS.Global;
using PMDS.GUI;




namespace PMDS.Calc.UI.Admin
{



    public partial class ucLeistungenKlient : QS2.Desktop.ControlManagment.BaseControl
    {

        private Guid _IDPatient = Guid.Empty;
        public event EventHandler ValueChanged;
        private bool _LeistungChenged = false;




        public ucLeistungenKlient()
        {
            InitializeComponent();
        }
        

        public bool Save()
        {
            bool ret1;
            ret1 = ucLeistungszuordKlient1.Save();

            if (ret1)
                ret1 = ucSonderleistungenKlient1.Save();

            if (ret1)
            {
                _LeistungChenged = false;
               }
            return ret1;
        }
        public bool IsChanged { get { return _LeistungChenged; } }
        public bool ValidateFields()
        {
            bool validate = ucLeistungszuordKlient1.ValidateFields();

            if (!validate)
                return false;

            return ucSonderleistungenKlient1.ValidateFields();
        }
        private void loadData()
        {
            _LeistungChenged = false;
            ucLeistungszuordKlient1.RefreshControl();
            ucSonderleistungenKlient1.RefreshControl();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _LeistungChenged = false;
                _IDPatient = value;
                ucLeistungszuordKlient1.IDPatient = _IDPatient;
                ucSonderleistungenKlient1.IDPatient = _IDPatient;
            }
        }

        private void uc_ValueChanged(object sender, EventArgs e)
        {
            _LeistungChenged = true;
             if (ValueChanged != null)
                ValueChanged(this, e);
        }



    }
}
