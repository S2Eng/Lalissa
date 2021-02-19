using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualKeyboard;
using Infragistics.Win.Misc;

namespace PMDS.GUI.BaseControls
{
    public partial class frmBigPicker : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmBigPicker(string sCaption, DataTable dt, string sDisplayMember, string sValueMember)
        {
            InitializeComponent();
            tbSearch.TextChanged += new EventHandler(tbSearch_TextChanged);

            DataSource          = dt;
            DisplayMember       = sDisplayMember;
            ValueMember         = sValueMember;
            lblHeader.Text    = sCaption;

            tbSearch.Mulitline = false;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten filter aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void tbSearch_TextChanged(object sender, System.EventArgs e)
        {
            FilterItems(tbSearch.Text);
            btnOK.Enabled = lbSearch.Items.Count > 0;

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten filtern
        /// </summary>
        //----------------------------------------------------------------------------
        private void FilterItems(string filter)
        {
            string f = "";
            if (filter != "")
                f = string.Format("{0} like '%{1}%'", DisplayMember, GuiUtil.LikeFilter(filter));

            try { dv.RowFilter = f; }
            catch { dv.RowFilter = "1 = 0"; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            UltraButton b = (UltraButton)sender;
            string s = b.Tag.ToString();
            switch (s)
            {
                case "Abbrechen":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "OK":
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
            Close();
        }

        //----------------------------------------------------------------------------
		/// <summary>
		/// DataSource
		/// </summary>
		//----------------------------------------------------------------------------
		public DataTable DataSource
		{
			get	{	return dv.Table;	}
			set	{	dv.Table = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DisplayMember
		/// </summary>
		//----------------------------------------------------------------------------
		public string DisplayMember
		{
			get	{	return lbSearch.DisplayMember;	}
			set	{	lbSearch.DisplayMember = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ValueMember
		/// </summary>
		//----------------------------------------------------------------------------
		public string ValueMember
		{
			get	{	return lbSearch.ValueMember;	}
			set	{	lbSearch.ValueMember = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Value
		/// </summary>
		//----------------------------------------------------------------------------
		public object Value
		{
			get	{	return lbSearch.SelectedValue;	}
			set
			{
				if (value == null)
				{
					if (lbSearch.Items.Count > 0)
						lbSearch.SelectedIndex = 0;
				}
				else
					lbSearch.SelectedValue = value;
			}
		}



        private void frmBigPicker_Load(object sender, EventArgs e)
        {
            tbSearch.Focus();
        }

        private void lbSearch_DoubleClick(object sender, EventArgs e)
        {
            if (lbSearch.SelectedValue == null)
                return;

            DialogResult = DialogResult.OK;
            ucVKey.PlayKlick();
            Close();
        }
    }
}