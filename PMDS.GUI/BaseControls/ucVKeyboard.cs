using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VirtualKeyboard
{
    public partial class ucVKeyboard : QS2.Desktop.ControlManagment.BaseControl
    {
        Font _font = new Font("Arial", 12);
        public ucVKeyboard()
        {
            InitializeComponent();
        }

        public Font KeyFont 
        { 
            get { return _font; } 
            set 
            {
                ;// Do Nothing Fontchange in Designer only _font = value; RefreshFonts(); 
            } 
        }

        private void RefreshFonts()
        {
            foreach (Control c in this.Controls)
            {
                if (c is ucVKey)
                {
                    ucVKey vk = (ucVKey)c;
                    if(vk.SpecialKey == VirtualSpecialKey.None)
                        c.Font = _font;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
        }

        private void vkCaps_KeyToogle(object sender, EventArgs e)
        {
            if (vkCaps.TOOGLE)
            {
                vkAlt.TOOGLE = false;
                vkStrg.TOOGLE = false;
            }
            RefreshVkeys(vkCaps.TOOGLE ? VirtualKeyboardMode.Shift : VirtualKeyboardMode.Normal);
        }

       

        private void vkAlt_KeyToogle(object sender, EventArgs e)
        {
            if (vkAlt.TOOGLE)
            {
                vkCaps.TOOGLE = false;
                vkStrg.TOOGLE = false;
            }
            RefreshVkeys(vkAlt.TOOGLE ? VirtualKeyboardMode.Alt : VirtualKeyboardMode.Normal);
        }

        private void vkStrg_KeyToogle(object sender, EventArgs e)
        {
            if (vkStrg.TOOGLE)
            {
                vkAlt.TOOGLE = false;
                vkCaps.TOOGLE = false;
            }
            RefreshVkeys(vkStrg.TOOGLE ? VirtualKeyboardMode.Control : VirtualKeyboardMode.Normal);
        }


        private void RefreshVkeys(VirtualKeyboardMode vkMode)
        {
            foreach (Control c in this.Controls)
            {
                if (c is ucVKey)
                {
                    ucVKey vk = (ucVKey)c;
                    if(vk.SpecialKey == VirtualSpecialKey.None)
                        vk.MODE = vkMode;
                }
            }
        }

        private void ucVKey51_Load(object sender, EventArgs e)
        {

        }

        private void ucVKey52_Load(object sender, EventArgs e)
        {

        }
            
    }
}
