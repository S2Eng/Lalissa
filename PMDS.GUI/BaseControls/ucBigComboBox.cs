using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using VirtualKeyboard;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBigComboBox : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler       SelectionChanged;
        public new event EventHandler   TextChanged;
        public event EventHandler       AfterDropDown;
        public event EventHandler       AfterCloseUp;
        public event EventHandler       SearchClicked;

        private bool _PlayClickSound = true;

        public bool PlayClickSound
        {
            get { return _PlayClickSound; }
            set { _PlayClickSound = value; }
        }

        public ucBigComboBox()
        {
            InitializeComponent();
            cbMain.ButtonsRight[1].Visible = false;     // Default kein Suchenbutton sichtbar
        }

        public ValueListItemsCollection Items
        {
            get
            {
                return cbMain.Items;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Suchenbutton aktivieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ShowSearchButton
        {
            set
            {
                cbMain.ButtonsRight[1].Visible = value;
                cbMain.ButtonsRight[0].Visible = !value;
            }
        }


        public DropDownStyle DropDownStyle { get { return cbMain.DropDownStyle; } set { cbMain.DropDownStyle = value; } }

        private void cbMain_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if(e.Button.Key == "v")
                cbMain.DropDown();
            if (e.Button.Key == "s")
            {
                PlayClick();
                if (SearchClicked != null)
                    SearchClicked(this, EventArgs.Empty);
            }

        }

        public ValueListItem SelectedItem { get { return cbMain.SelectedItem; } set { cbMain.SelectedItem = value; } }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ID ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        public Guid ID
        {
            get
            {
                if (cbMain.Value == null)
                    return Guid.Empty;
                else
                    return (Guid)cbMain.Value;
            }
            set
            {
                PlayClickSound = false;
                if (value == Guid.Empty)
                    cbMain.Value = null;
                else
                    cbMain.Value = value;
                PlayClickSound = true ;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktueller Text der Combo
        /// </summary>
        //----------------------------------------------------------------------------
        public new string Text
        {
            get
            {
                return cbMain.Text;
            }
            set
            {
                cbMain.Text = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return cbMain.Appearance.BackColor;
            }
            set
            {
                cbMain.Appearance.BackColor = value;
            }
        }

        private void cbMain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PlayClick()
        {
            if (_PlayClickSound)
                ucVKey.PlayKlick();
        }

        private void cbMain_SelectionChanged(object sender, EventArgs e)
        {
            if (cbMain.Focused)
            {
                PlayClick();
                if (SelectionChanged != null)
                    SelectionChanged(this, EventArgs.Empty);
            }
        }

        private void cbMain_BeforeDropDown(object sender, CancelEventArgs e)
        {
            PlayClick();
        }

        private void cbMain_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(this, EventArgs.Empty);
        }

        private void cbMain_AfterDropDown(object sender, EventArgs e)
        {
            if (AfterDropDown != null)
                AfterDropDown(this, EventArgs.Empty);
        }

        private void cbMain_AfterCloseUp(object sender, EventArgs e)
        {
            if (AfterCloseUp != null)
                AfterCloseUp(this, EventArgs.Empty);
        }

        private void cbMain_AfterEditorButtonCloseUp(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
           
           
        }

    }
}
