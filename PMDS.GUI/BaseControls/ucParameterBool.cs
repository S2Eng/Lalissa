using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Print.CR;

namespace PMDS.GUI.BaseControls
{
    public partial class ucParameterBool : ucParameterBase, IBerichtParameterGUI
    {
        private BerichtParameter        _parameter;
        private bool _threestate;

        public ucParameterBool(bool threestate)
        {
            InitializeComponent();
            _threestate = threestate;
            cbValue.ThreeState = _threestate;
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get 
            {
                if (!_threestate)
                    return cbValue.Checked;
                else
                    return cbValue.CheckState;
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                if (!_threestate)
                    return cbValue.Checked.ToString();
                else
                    return cbValue.CheckState.ToString();
            }
        }

        public BerichtParameter BERICHTPARAMETER
        {
            get
            {
                return _parameter;        
            }
            set
            {
                _parameter = value;
                if (value != null)
                    RefreshControl();
            }
        }

        private void RefreshControl()
        {
            lblText.Text = _parameter.Description;
            try
            {
                if (_threestate == false)
                {
                    string s = _parameter.Default;
                    if (s.StartsWith("WAHR"))
                        cbValue.Checked = true;
                    else if (s.StartsWith("FALSCH"))
                        cbValue.Checked = false;
                }
                else
                {
                    string s = _parameter.Default;
                    if (s.StartsWith("WAHR"))
                        cbValue.CheckState = CheckState.Checked;
                    else if (s.StartsWith("FALSCH"))
                        cbValue.CheckState = CheckState.Unchecked;
                    else if (s.StartsWith("UNDEFINIERT"))
                        cbValue.CheckState = CheckState.Indeterminate;
                }
            }
            catch
            {
            }
        }

        #endregion

        private void ucParameterBool_Load(object sender, EventArgs e)
        {

        }
    }
}
