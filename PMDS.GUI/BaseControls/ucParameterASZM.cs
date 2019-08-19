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
    public partial class ucParameterASZM : ucParameterBase, IBerichtParameterGUI
    {
        private PMDS.Print.CR.BerichtParameter _parameter;

        public ucParameterASZM()
        {
            InitializeComponent();
            
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get
            {
                return "{" + cbList.ID.ToString() + "}";
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                return cbList.Text;
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
            try
            {
                cbList.GROUP = (EintragGruppe)Enum.Parse(typeof(EintragGruppe), _parameter.Default);
                cbList.RefreshList();
                cbList.Items.Add(Guid.Empty, "              ");
            }
            catch
            {
            }

        }

        #endregion

        private void cbList_SelectionChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }
    }
}
