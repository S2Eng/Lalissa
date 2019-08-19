//----------------------------------------------------------------------------
/// <summary>
///	MedikamentHerrichtenCombo.cs
/// Erstellt am:	11.07.2007
/// Erstellt von:	MDA
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class MedikamentHerrichtenCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public MedikamentHerrichtenCombo()
        {
            DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            if (!DesignMode && ENV.AppRunning)
                RefreshList();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Infragistics.Win.DropDownStyle DropDownStyle
        {
            get {return base.DropDownStyle;}
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public override void RefreshList()
        {
            try
            {
                PMDS.GUI.PMDSBusinessUI.getListHerrichtenMedikamente(this);

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

    }
}
