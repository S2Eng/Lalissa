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
    public partial class ucParameterAbteilung : ucParameterBase, IBerichtParameterGUI
    {
        private PMDS.Print.CR.BerichtParameter _parameter;

        public ucParameterAbteilung()
        {
            InitializeComponent();
//            cbAbteilung.Items.Add(Guid.Empty, "             ");           // Leer Eintrag hinzufügen   // nicht bei AbteilungCombo
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get 
            {
                if (cbAbteilung.SelectedItem != null)
                    return "{" + cbAbteilung.SelectedItem.DataValue.ToString() + "}";
                else
                    return "{" + Guid.Empty.ToString() + "}";
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                if (cbAbteilung.SelectedItem != null)
                    return cbAbteilung.SelectedItem.DisplayText;
                else
                    return "";
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

        private void cbAbteilung_SelectionChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }
    }
}
