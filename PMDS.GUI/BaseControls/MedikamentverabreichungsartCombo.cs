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
    public partial class MedikamentverabreichungsartCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public MedikamentverabreichungsartCombo()
        {
            DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
                RefreshList();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Infragistics.Win.DropDownStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public override void RefreshList()
        {
            this.Items.Clear();

            try
            {
                this.Items.Add(0, QS2.Desktop.ControlManagment.ControlManagment.getRes("wie hergerichtet"));
                this.Items.Add(1, QS2.Desktop.ControlManagment.ControlManagment.getRes("einzeln"));

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }
    }
}
