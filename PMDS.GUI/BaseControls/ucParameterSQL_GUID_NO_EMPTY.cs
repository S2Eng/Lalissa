using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Print.CR;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucParameterSQL_GUID_NO_EMPTY : ucParameterBase, IBerichtParameterGUI
    {
        private BerichtParameter _parameter;

        public ucParameterSQL_GUID_NO_EMPTY()
        {
            InitializeComponent();

        }

        #region IBerichtParameterGUI Member

        public object VALUE
        {
            get
            {
                if (cbMain.SelectedItem == null)
                    return "{" + Guid.Empty.ToString() + "}";
                return "{" + cbMain.SelectedItem.DataValue.ToString() + "}";
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                if (cbMain.SelectedItem == null)
                    return "";
                return cbMain.SelectedItem.DisplayText;
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
                bool bOk = true;
                cbMain.Items.Clear();
//                cbMain.Items.Add(Guid.Empty, " ");      // Leer als erster
                // Die SQL Anweisung steht im Default. Die Ersetzungen des Typs {{{Feldname.Value}}} oder {{{Feldname.Text}}} über externen Aufruf ersetzen lassen
                string sSQL = ParameterHelper.ReplacePlaceHolder(BERICHTPARAMETER.Default, out bOk);
                if (bOk)
                {
                    dsGuidListeNoKey.IDListeDataTable dt = DatabaseHelper.IDListeFromSQL(sSQL);
                    foreach (dsGuidListeNoKey.IDListeRow r in dt.Rows)
                        cbMain.Items.Add(r.ID, r.TEXT);
                    if (cbMain.Items.Count > 0)
                        cbMain.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public override void AnotherValueChanged(BerichtParameter p)
        {
            if (IsDependedParameter(p, BERICHTPARAMETER.Default))
                RefreshControl();
        }

        #endregion

        private void cbMain_ValueChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }
    }
}
