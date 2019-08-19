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
    public partial class ucParameterDate : ucParameterBase, IBerichtParameterGUI
    {
        private PMDS.Print.CR.BerichtParameter _parameter;
        private typ                     _typ = typ.Date;
        private bool                    _bNoChangeEvent = true;

        public ucParameterDate()
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Now;
        }

        public enum typ
        {
            Date,
            DateTime,
            Time
        }

        public typ TYP
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
                SetFromTyp();
            }
        }

        private void SetFromTyp()
        {
            switch (_typ)
            {
                case typ.Date:
                    dtpDate.FormatString = "dd.MM.yyyy";
                    dtpDate.MaskInput = "{date}";
                    break;
                case typ.DateTime:
                    dtpDate.FormatString = "dd.MM.yyyy HH:mm";
                    dtpDate.MaskInput = "{date} {time}";
                    break;
                case typ.Time:
                    dtpDate.FormatString = "HH:mm";
                    dtpDate.MaskInput = "{time}";
                    break;
                default:
                    break;
            }
        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get 
            {
                return dtpDate.Value;
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                return dtpDate.Value.ToString();
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
            _bNoChangeEvent = true;
            lblText.Text = _parameter.Description;
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
                    case "DATUM_AKTUELL":                       // Datum und Zeit wurde bereits aktuell gesetzt
                    case "ZEIT_AKTUELL":
                        break;
                    case "1QB":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                        break;
                    case "2QB":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 4, 1);
                        break;
                    case "3QB":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 7, 1);
                        break;
                    case "4QB":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 10, 1);
                        break;
                    case "1QE":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3), 23, 59, 59);
                        break;
                    case "2QE":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6), 23, 59, 59);
                        break;
                    case "3QE":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9), 23, 59, 59);
                        break;
                    case "4QE":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
                        break;
                    case "JB":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                        break;
                    case "JE":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
                        break;
                    case "TAG_BEGINN":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                        break;
                    case "TAG_ENDE":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                        break;
                    case "MB":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        break;
                    case "ME":
                        dtpDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
                        break;
                    case "LEER":
                        dtpDate.Value = null;
                        break;
                    default:
                        try
                        {
                            dtpDate.Value = Convert.ToDateTime(_parameter.Default);
                        }
                        catch
                        {
                        }
                        break;
                }

                if (bContainsoperator)
                {
                    ProcessOffset(_parameter.Default);
                    return;
                }

            }
            catch
            {
            }
            finally
            {
                _bNoChangeEvent = false ;
            }
        }

        private void ProcessOffset(string p)
        {
            bool bplus = p.Contains("+");
            int iFactor = bplus ? 1 : -1;
            char sOperator = bplus ? '+' : '-';
            string[] sa = p.Split(sOperator);
            if (sa.Length == 2)
            {
                string s = sa[1].Trim();                   // in sa[1] steht Zahl[Einheit]
                if(s.Length == 0)
                    return;
                char[] ca = s.ToCharArray();
                char   c = ca[ca.Length-1];         // Das lezte Zeichen ist die Einheit
                switch (c)
                {
                    case 'S':
                        s = s.Replace("S", "");
                        dtpDate.Value = dtpDate.DateTime.AddHours(iFactor * Convert.ToInt32(s));
                        return;
                    case 'J':
                        s = s.Replace("J", "");
                        dtpDate.Value = dtpDate.DateTime.AddYears(iFactor * Convert.ToInt32(s));
                        return;
                    case 'M':
                        s = s.Replace("M", "");
                        dtpDate.Value = dtpDate.DateTime.AddMonths(iFactor * Convert.ToInt32(s));
                        return;
                    case 'T':
                        s = s.Replace("T", "");
                        dtpDate.Value = dtpDate.DateTime.AddDays(iFactor * Convert.ToInt32(s));
                        return;
                    case 'W':
                        s = s.Replace("W", "");
                        dtpDate.Value = dtpDate.DateTime.AddDays(iFactor * Convert.ToInt32(s) * 7);
                        return;
                    default:
                        dtpDate.Value = dtpDate.DateTime.AddDays(iFactor * Convert.ToInt32(s));
                        break;
                }
            }
        }

        #endregion



        private void dtpDate2_Enter(object sender, EventArgs e)
        {
            dtpDate.SelectAll();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            if (!_bNoChangeEvent)
                SignalValueChanged();
        }
    }
}
