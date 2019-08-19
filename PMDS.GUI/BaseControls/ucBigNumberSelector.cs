//----------------------------------------------------------------------------
/// <summary>
///	ucBigBenutzerAuswahl.cs
/// Erstellt am:	15.5.2008
/// Erstellt von:   RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using VirtualKeyboard;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBigNumberSelector : QS2.Desktop.ControlManagment.BaseControl
    {
        private double                  _selectedValue = -999999;
        private BigNumberSelectorTypes  _type = BigNumberSelectorTypes.Int;
        public event EventHandler       NumberSelected;



        public ucBigNumberSelector()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Initialisierungsroutine
        /// </summary>
        //----------------------------------------------------------------------------
        public void InitControl(BigNumberSelectorTypes type, string InputMask, string Format, double von, double bis, double step, int ItemsPerLine, double? step2, double? step2at)
        {
            _type = type;
            double lstep = step;
            tbNumber.InputMask      = InputMask;
            tbNumber.FormatString   = Format;
            pnlNumbers.Controls.Clear();
            while (von <= bis)
            {
                AddButton(von, Format);

                if (step2 != null)
                {
                    if (step2at.Value <= von)
                        lstep = step2.Value;
                }
                von += lstep;
                von = Math.Round(von, 2, MidpointRounding.AwayFromZero);
            }

            int iLines = pnlNumbers.Controls.Count / ItemsPerLine + 1;            // Für die breite und höhe
            pnlNumbers.Width    = ItemsPerLine * 50      + ((ItemsPerLine+2)* ultraFlowLayoutManager1.HorizontalGap);
            pnlNumbers.Height   = iLines * 50  + ((iLines +2) * ultraFlowLayoutManager1.VerticalGap);
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Der Wert des Elementes
        /// </summary>
        //----------------------------------------------------------------------------
        public object Value
        {
            get { return tbNumber.Value; }
            set { tbNumber.Value = value; }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Auswahlbutton hinzufügen
        /// </summary>
        //----------------------------------------------------------------------------
        private void AddButton(double wert, string Format)
        {
            UltraButton btn             = new UltraButton();
            btn.Width                   = 50;
            btn.Height                  = 50;
            btn.UseOsThemes             = Infragistics.Win.DefaultableBoolean.False;
            btn.ButtonStyle             = Infragistics.Win.UIElementButtonStyle.Flat;
            btn.Appearance.BackColor    = Color.WhiteSmoke;
            btn.Text                    = wert.ToString(Format);
            btn.Tag                     = wert;
            btn.Click                   += new EventHandler(btn_Click);
            pnlNumbers.Controls.Add(btn);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Auswahl wurde getroffen
        /// </summary>
        //----------------------------------------------------------------------------
        void btn_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            _selectedValue = (double)((UltraButton)sender).Tag;
            tbNumber.Value = _type == BigNumberSelectorTypes.Int ? (int) _selectedValue : (double)_selectedValue;
            if (NumberSelected != null)
                NumberSelected(this, EventArgs.Empty);
            pop1.Close();
        }

        
        private void tbNumber_DoubleClick(object sender, EventArgs e)
        {
            pop1.Show(this);
        }

        private void tbNumber_Enter(object sender, EventArgs e)
        {
            
        }

        private void tbNumber_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            tbNumber.SelectAll();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Anzeigezeichen setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public char PromptChar
        {
            get
            {
                return tbNumber.PromptChar;
            }
            set
            {
                tbNumber.PromptChar = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return tbNumber.Appearance.BackColor;
            }
            set
            {
                tbNumber.Appearance.BackColor = value;
            }
        }

        private void tbNumber_MaskChanged(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs e)
        {

        }

        private void tbNumber_ValueChanged(object sender, EventArgs e)
        {
        }
    }

    public enum BigNumberSelectorTypes
    {
        Int,
        Float
    }
}
