using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qs2.ui
{
    public partial class frmExchangeIDStayGuid : Form
    {
        public frmExchangeIDStayGuid()
        {
            InitializeComponent();          
        }

        public void Init(bool ExchangeModeExportIn, string RecordInfoIn, qs2.core.vb.dsObjects.tblStayRow rIn)
        {
            try
            {
                if (rIn == null) throw new ArgumentNullException(nameof(rIn));

                this.Text = qs2.core.generic.TranslateEx("frmExchangeIDGuidStay");
                contExchangeIDGuidStay1.Init(ExchangeModeExportIn, RecordInfoIn, rIn);

            }
            catch (Exception ex)
            {
                throw new Exception("cntExchangeIDGuidStay.Init: " + ex.ToString());
            }
        }
    }
}
