using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucParameterText : ucParameterBase, IBerichtParameterGUI
    {
        private PMDS.Print.CR.BerichtParameter _parameter;
        private bool _hidden;

        public ucParameterText(bool hidden)
        {
            InitializeComponent();
            tbValue.Text = "";
            _hidden = hidden;
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get 
            {
                return tbValue.Text.Trim();
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                return tbValue.Text.Trim();
            }
        }


        public PMDS.Print.CR.BerichtParameter BERICHTPARAMETER
        {
            get
            {
                return _parameter;        
            }
            set
            {
                _parameter = value;
                if (value != null)
                    RefreshControl(_hidden);
            }
        }

        private void RefreshControl(bool hidden)
        {
            lblText.Text = _parameter.Description;
            tbValue.Text = _parameter.Default;
            if (hidden)
            {
                lblText.Visible = false;
                tbValue.Visible = false;
            }
        }

        #endregion

        private void ucParameterText_Load(object sender, EventArgs e)
        {

        }

        private void tbValue_Enter(object sender, EventArgs e)
        {

        }
    }
}
