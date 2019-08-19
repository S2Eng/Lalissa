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
    public partial class ucParameterZahl : ucParameterBase, IBerichtParameterGUI
    {
        private BerichtParameter        _parameter;

        public ucParameterZahl()
        {
            InitializeComponent();
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get 
            {
                return (int)nupValue.Value;
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                return nupValue.Value.ToString();
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
            nupValue.Value = 0;

            if (_parameter.Default.Length > 0)
            {
                try
                {
                    bool bContainsPlus = _parameter.Default.Contains("+");
                    bool bContainsMinus = _parameter.Default.Contains("-");
                    bool bContainsoperator = bContainsMinus || bContainsPlus;


                    string s = _parameter.Default;
                    if (bContainsoperator)
                    {
                        char sOperator = bContainsPlus ? '+' : '-';
                        string[] sa = s.Split(sOperator);
                        s = sa[0].Trim();
                    }

                    switch (s)
                    {
                        case "JAHR_AKTUELL":
                            nupValue.Value = DateTime.Now.Year;
                            break;
                        case "MONAT_AKTUELL":
                            nupValue.Value = DateTime.Now.Month;
                            break;
                        case "TAG_AKTUELL":
                            nupValue.Value = DateTime.Now.Day;
                            break;
                        default:
                            try
                            {
                                nupValue.Value = Convert.ToInt32(_parameter.Default);
                            }
                            catch
                            {
                            }
                            break;
                    }
                }
                catch
                {
                }
            }
        }
        #endregion

        private void ucParameterZahl_Load(object sender, EventArgs e)
        {

        }

        private void nupValue_Enter(object sender, EventArgs e)
        {
            this.nupValue.SelectAll();
        }
    }
}
