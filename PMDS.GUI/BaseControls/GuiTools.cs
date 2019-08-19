using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;



namespace PMDS.Calc.UI.Admin
{


    public static class GuiTools
    {


        public static void AddKostentraegerArtValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("KSA"))
                vl = vlc["KSA"];
            else
            {
                vl = vlc.Add("KSA");

                vl.ValueListItems.Add((int)Kostentraegerart.Grundkosten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung"));
                vl.ValueListItems.Add((int)Kostentraegerart.Transferleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung"));
                vl.ValueListItems.Add((int)Kostentraegerart.Periodischeleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistung"));
                vl.ValueListItems.Add((int)Kostentraegerart.Sonderleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonderleistung"));
                vl.ValueListItems.Add((int)Kostentraegerart.Grundkosten_Periodischeleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Periodische Leistungen"));
                vl.ValueListItems.Add((int)Kostentraegerart.Grundkosten_Sonderleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Sonderleistungen"));
                vl.ValueListItems.Add((int)Kostentraegerart.PeriodischeLeistung_Sonderleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistungen und Sonderleistungen"));
                vl.ValueListItems.Add((int)Kostentraegerart.Alles, QS2.Desktop.ControlManagment.ControlManagment.getRes("Alles"));

            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

        public static void AddKostentraegerArtCombo(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, bool transfer )
        {
            if (transfer)
            {
                cbo.Items.Add((int)Kostentraegerart.Grundkosten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung"));
                cbo.Items.Add((int)Kostentraegerart.Transferleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung"));
            }
            cbo.Items.Add((int)Kostentraegerart.Periodischeleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistung"));
            cbo.Items.Add((int)Kostentraegerart.Sonderleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonderleistung"));
            cbo.Items.Add((int)Kostentraegerart.Grundkosten_Periodischeleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Periodische Leistungen"));
            cbo.Items.Add((int)Kostentraegerart.Grundkosten_Sonderleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Sonderleistungen"));
            cbo.Items.Add((int)Kostentraegerart.PeriodischeLeistung_Sonderleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistungen und Sonderleistungen"));
            cbo.Items.Add((int)Kostentraegerart.Alles, QS2.Desktop.ControlManagment.ControlManagment.getRes("Alles"));

        }
    }
}
