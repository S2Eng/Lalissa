using System;
using System.Collections.Generic;
using System.Text;



namespace PMDS.GUI.BaseControls
{
    public class historie
    {


        public static void OnOffControls(System.Windows.Forms.Control cont, bool bOn)
        {
            foreach (System.Windows.Forms.Control cto in cont.Controls)
            {
                OnOffControlsInObj((object)cto, bOn);
                PMDS.GUI.BaseControls.historie .OnOffControls(cto, bOn);        
            }

        }
        private  static void OnOffControlsInObj(object cto, bool bOn)
        {

                if (cto.GetType().Name.ToString() == "UltraTextEditor")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraTextEditor)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraTextEditor)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraTextEditor)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraOptionSet")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraOptionSet)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraOptionSet)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraOptionSet)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UserCombo")
                {
                    ((PMDS.GUI.BaseControls.UserCombo)cto).Enabled  = !bOn;
                    ((PMDS.GUI.BaseControls.UserCombo)cto).BackColor = System.Drawing.Color.White;
                    ((PMDS.GUI.BaseControls.UserCombo)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((PMDS.GUI.BaseControls.UserCombo)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;

                }
                else if (cto.GetType().Name.ToString() == "ZeitbereicheZeitbereichSerienCombo")
                {
                    ((PMDS.GUI.BaseControls.ZeitbereicheZeitbereichSerienCombo)cto).Enabled = !bOn;
                    ((PMDS.GUI.BaseControls.ZeitbereicheZeitbereichSerienCombo)cto).BackColor = System.Drawing.Color.White;
                    ((PMDS.GUI.BaseControls.ZeitbereicheZeitbereichSerienCombo)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((PMDS.GUI.BaseControls.ZeitbereicheZeitbereichSerienCombo)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "LinkDokumenteCombo")
                {
                    ((PMDS.GUI.BaseControls.LinkDokumenteCombo)cto).Enabled = !bOn;
                    ((PMDS.GUI.BaseControls.LinkDokumenteCombo)cto).BackColor = System.Drawing.Color.White;
                    ((PMDS.GUI.BaseControls.LinkDokumenteCombo)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((PMDS.GUI.BaseControls.LinkDokumenteCombo)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "CheckBox")
                {
                    ((System.Windows.Forms.CheckBox )cto).Enabled = !bOn;
                    ((System.Windows.Forms.CheckBox)cto).BackColor  = System.Drawing.Color.White;
                }
                else if (cto.GetType().Name.ToString() == "UltraMaskedEdit")
                {
                    ((Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraButton")
                {
                    ((Infragistics.Win.Misc.UltraButton)cto).Visible = bOn;
                    //((Infragistics.Win.Misc.UltraButton)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    //((Infragistics.Win.Misc.UltraButton)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraCheckEditor")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraComboEditor")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraComboEditor)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraComboEditor)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraComboEditor)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraGrid")
                {
                    //((Infragistics.Win.UltraWinGrid.UltraGrid )cto).Enabled = bOn;
                    //((Infragistics.Win.UltraWinGrid.UltraGrid)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    //((Infragistics.Win.UltraWinGrid.UltraGrid)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraDateTimeEditor")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraDateTimeEditor")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "UltraNumericEditor")
                {
                    ((Infragistics.Win.UltraWinEditors.UltraNumericEditor)cto).Enabled = !bOn;
                    ((Infragistics.Win.UltraWinEditors.UltraNumericEditor)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((Infragistics.Win.UltraWinEditors.UltraNumericEditor)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                }
                else if (cto.GetType().Name.ToString() == "ListBox")
                {
                    ((System.Windows.Forms.ListBox)cto).Enabled = !bOn;

                }
                else if (cto.GetType().Name.ToString() == "UltraGroupBox")
                {
                }
                else if (cto.GetType().Name.ToString() == "UltraTabPageControl")
                {
                }
                else if (cto.GetType().Name.ToString() == "Panel")
                {
                    //((System.Windows.Forms.Panel)cto).Enabled = bOn;
                }
                else if (cto.GetType().Name.ToString() == "UltraLabel")
                {
                }
                else if (cto.GetType().Name.ToString() == "ucMedTypDaten")
                {
                }
                else if (cto.GetType().Name.ToString() == "UltraExpandableGroupBox")
                {
                }
                else if (cto.GetType().Name.ToString() == "UltraExpandableGroupBoxPanel")
                {
                }
                else if (cto.GetType().Name.ToString() == "UltraTabControl")
                {
                }
                else if (cto.GetType().Name.ToString() == "UltraTabSharedControlsPage")
                {
                }
                else if (cto.GetType().Name.ToString() == "UltraDropDownButton")
                {
                    if (cto.GetType().Name != "ultraDropDownButtonHeimvertragDrucken")
                    {

                    }
                }
                else if (cto.GetType().Name.ToString() == "UltraGridBagLayoutPanel")
                {
                }
                else if (cto.GetType().Name.ToString() == "dtCombo")
                {
                    ((dtCombo)cto).Enabled = !bOn;
                    ((dtCombo)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((dtCombo)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;

                }
                else if (cto.GetType().Name.ToString() == "ucButton")
                {
                    ((ucButton)cto).Visible = !bOn;
                    ((ucButton)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((ucButton)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;

                }
                else if (cto.GetType().Name.ToString() == "AuswahlGruppeCombo")
                {
                    ((AuswahlGruppeCombo)cto).Enabled = !bOn;
                    ((AuswahlGruppeCombo)cto).Appearance.BackColorDisabled = System.Drawing.Color.White;
                    ((AuswahlGruppeCombo)cto).Appearance.ForeColorDisabled = System.Drawing.Color.Black;

                }
                else
                {
                    string yxyxyx = cto.GetType().Name.ToString();
                }


        }
    }
    }

