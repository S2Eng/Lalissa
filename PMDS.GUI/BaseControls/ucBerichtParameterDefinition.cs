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
    public partial class ucBerichtParameterDefinition : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool _selected = false;

        public event EventHandler Changed;
        
        public ucBerichtParameterDefinition()
        {
            InitializeComponent();
            FillCombo();
        }

        public string NAME
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string BEZEICHNUNG
        {
            get
            {
                return tbBezeichnung.Text;
            }
            set
            {
                tbBezeichnung.Text = value;
            }
        }


        public string DEFAULT
        {
            get
            {
                return cbDefault.Text;
            }
            set
            {
                cbDefault.Text = value;
            }
        }

        public BerichtParameter.BerichtParameterTyp TYPE
        {
            get
            {
                return (BerichtParameter.BerichtParameterTyp)Enum.Parse(typeof(BerichtParameter.BerichtParameterTyp), cbTyp.Text);
            }
            set
            {
                cbTyp.SelectedIndex = (int)value;
            }
        }


        public bool HEADER_ONLY
        {
            get
            {
                return pnlHeader.Visible;
            }
            set
            {
                pnlHeader.Visible = value;
            }
        }

        public bool SELECTED
        {
            get
            {
                return _selected;
            }
        }

        private void FillCombo()
        {
            foreach (string s in Enum.GetNames(typeof(BerichtParameter.BerichtParameterTyp)))
                cbTyp.Items.Add(s);
        }

        private void ucBerichtParameterDefinition_Enter(object sender, EventArgs e)
        {
            _selected = true;
        }

        private void ucBerichtParameterDefinition_Leave(object sender, EventArgs e)
        {
            _selected = false;
        }

        private void pnlHeader_VisibleChanged(object sender, EventArgs e)
        {
            this.Height = pnlHeader.Visible ? pnlHeader.Height : pnlFields.Height;
            pnlFields.Visible = !HEADER_ONLY;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
