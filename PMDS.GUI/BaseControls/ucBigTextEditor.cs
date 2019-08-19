using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VirtualKeyboard;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBigTextEditor : QS2.Desktop.ControlManagment.BaseControl
    {
        public new event EventHandler TextChanged;

        private bool _preventClickSound = false;

        public ucBigTextEditor()
        {
            InitializeComponent();
        }

        private void txtMain_Enter(object sender, EventArgs e)
        {
            if(!_preventClickSound)
                ucVKey.PlayKlick();

            _preventClickSound = false;
        }

        public bool Mulitline
        {
            set
            {
                txtMain.Multiline = value;
                txtMain.AcceptsReturn = value;
                this.Height = 45;
                txtMain.Appearance.FontData.SizeInPoints   = 24;
                //txtMain.Appearance.BorderColor = System.Drawing.Color.Blue;
                //txtMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                //this.BorderStyle = BorderStyle.None;
            }
        }

        public new string Text
        {
            get { return txtMain.Text; }
            set { txtMain.Text = value;}

        }

        public new void Focus()
        {
            _preventClickSound = true;
            txtMain.Focus();
        }

        public override Color BackColor
        {
            get
            {
                return txtMain.Appearance.BackColor;
            }
            set
            {
                txtMain.Appearance.BackColor = value;
            }
        }

        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }
    }
}
