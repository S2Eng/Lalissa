using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;

namespace PMDS.GUI.BaseControls
{
    public partial class ucParameterBenutzer : ucParameterBase, IBerichtParameterGUI
    {
        private PMDS.Print.CR.BerichtParameter _parameter;

        public ucParameterBenutzer()
        {
            InitializeComponent();
            cbUser.Items.Add(Guid.Empty, "             ");           // Leer Eintrag hinzufügen
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get 
            {
                if (cbUser.SelectedItem != null)
                    return "{" + cbUser.SelectedItem.DataValue.ToString() + "}";
                else
                    return "{" + Guid.Empty.ToString() + "}";
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                return cbUser.Text;
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
                    RefreshControl();
            }
        }

        private void RefreshControl()
        {
            lblText.Text = _parameter.Description;
        }

        #endregion

        private void cbUser_SelectionChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }
    }
}
