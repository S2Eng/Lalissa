using System;
using System.Collections.Generic;
using System.Text;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win;

using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.GUI;
using PMDS.Data.Patient;

using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Global.ds_abrechnung.unwichtig;

namespace PMDS.Calc.UI.Admin
{
    
    public static class UltraGridTools
    {

        public static void AddLeistungskatalogValueList(UltraGrid g, string sBoundGridColumn, bool refreshList)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            bool refresh = false;
            ValueList vl = null;
            if (vlc.Exists("LKA"))
            {
                vl = vlc["LKA"];
                if(refreshList)
                    vl.ValueListItems.Clear();
            }
            else
            {
                vl = vlc.Add("LKA");
                refresh = true;
            }
            if (refresh || refreshList)
            {
                // Werte laden
                LeistungsKatalog k = new LeistungsKatalog();

                foreach (dsLeistungskatalog.LeistungskatalogRow r in k.ReadAll())
                    vl.ValueListItems.Add(r.ID, r.Bezeichnung);
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            //Neu nach 25.10.2007 MDA
            //Nach aktualisieren von ValueList, wenn die Zelle der entsprechende Spalte selecteirt ist, verliert sie ihr wert.
            //daher muß das alte Wert wieder zurückgesetzt.
            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
                g.ActiveCell.Value = g.ActiveCell.Value;
        }

        public static void AddSonderleistungsKatalogValueList(UltraGrid g, string sBoundGridColumn, System.Guid IDKlinik)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("KSA"))
                vl = vlc["KSA"];
            else
            {
                vl = vlc.Add("KSA");

                SonderleistungsKatalog k = new SonderleistungsKatalog();
                vl.ValueListItems.Clear();
                vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Sonderleistung auswählen."));
                
                foreach (dsSonderleistungsKatalog.SonderleistungsKatalogRow r in k.Read())
                {
                    if (r.IsIDKlinikNull())
                    {
                        vl.ValueListItems.Add(r.ID, r.Bezeichnung);
                    }
                    else if (r.IDKlinik.Equals(IDKlinik))
                    {
                        vl.ValueListItems.Add(r.ID, r.Bezeichnung);
                    }
                }

            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            //Neu nach 25.10.2007 MDA
            //Nach aktualisieren von ValueList, wenn die Zelle der entsprechende Spalte selecteirt ist, verliert sie ihr wert.
            //daher muß das alte Wert wieder zurückgesetzt.
            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
                g.ActiveCell.Value = g.ActiveCell.Value;
        }

        public static void AddKostentraegerPatientenValueList(UltraGrid g, UltraGridRow r, string datumsColumn, string sBoundGridColumn, bool refreshList)
        {
            r.Cells[sBoundGridColumn].ValueList = null;
            r.Cells[sBoundGridColumn].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

            DateTime gueltigAb, gueltigBis;
            Guid IDKostentraeger = Guid.Empty;

            try
            {
                gueltigAb = r.Cells[datumsColumn].EditorResolved.IsInEditMode ? (DateTime)r.Cells[datumsColumn].EditorResolved.Value : (DateTime)r.Cells[datumsColumn].Value;
                gueltigBis = new DateTime(gueltigAb.Year, gueltigAb.Month, DateTime.DaysInMonth(gueltigAb.Year, gueltigAb.Month));
                IDKostentraeger = (Guid)r.Cells["IDKostentraeger"].Value;
            }
            catch
            {
                return;
            }

            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            bool refresh = false;
            ValueList vl = null;
            if (vlc.Exists("PAT_" + IDKostentraeger.ToString() + "_" + gueltigAb.ToString("dd.MM.yyyy")))
            {
                vl = vlc["PAT_" + IDKostentraeger.ToString() + "_" + gueltigAb.ToString("dd.MM.yyyy")];

                if(refreshList)
                    vl.ValueListItems.Clear();
            }
            else
            {
                vl = vlc.Add("PAT_" + IDKostentraeger.ToString() + "_" + gueltigAb.ToString("dd.MM.yyyy"));
                refresh = true;
            }

            if (refresh || refreshList)
            {
                // Werte laden
                Patient p;
                dsKlientenKostentraeger ds = new dsKlientenKostentraeger();
                PMDS.Calc.Admin.DB.DBPatientKostentraeger pk = new PMDS.Calc.Admin.DB.DBPatientKostentraeger();
                pk.GetKlientenKostentraeger(ds, IDKostentraeger, gueltigAb, gueltigBis);

                vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Klient auswählen."));
                
                foreach (dsKlientenKostentraeger.PatientKostentraegerRow row in ds.PatientKostentraeger)
                {
                    p = new Patient(row.IDPatient);
                    vl.ValueListItems.Add(p.ID, p.FullName);
                }

                //Neu nach 16.06.2008 MDA
                //Wenn nur ein Klient in der Liste ist, dann Klient selektieren
                if (vl.ValueListItems.Count == 2 && (Guid)r.Cells[sBoundGridColumn].Value == Guid.Empty)
                {
                    vl.SelectedItem = vl.ValueListItems[1];
                    r.Cells[sBoundGridColumn].Value = (Guid)vl.ValueListItems[1].DataValue;
                }
            }

            r.Cells[sBoundGridColumn].ValueList = vl;
            r.Cells[sBoundGridColumn].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            //Nach aktualisieren von ValueList, wenn die Zelle der entsprechende Spalte selecteirt ist, verliert sie ihr wert.
            //daher muß das alte Wert wieder zurückgesetzt.
            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
            {
                g.ActiveCell.Value = g.ActiveCell.Value;

            }

            if (g.ActiveRow == null || g.ActiveRow != r) return;
            bool gefunden = false;
            foreach (ValueListItem item in vl.ValueListItems)
            {
                if (g.ActiveRow.Cells[sBoundGridColumn].Value != DBNull.Value &&
                    (Guid)g.ActiveRow.Cells[sBoundGridColumn].Value == (Guid)item.DataValue)
                {
                    gefunden = true;
                    break;
                }
            }

            if (!gefunden)
            {
                if (vl.ValueListItems.Count == 2)
                    g.ActiveRow.Cells[sBoundGridColumn].Value = (Guid)vl.ValueListItems[1].DataValue;
                else
                    g.ActiveRow.Cells[sBoundGridColumn].Value = Guid.Empty;
            }
        }

        public static void RefreshPatientKostentraegerList(UltraGrid g, UltraGridRow r, string sBoundGridColumn, bool refreshList, bool klinik, System.Guid IDKlinik)
        {
            r.Cells[sBoundGridColumn].ValueList = null;
            r.Cells[sBoundGridColumn].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

            bool TransferleistungJN = r.Cells["TransferleistungJN"].EditorResolved.IsInEditMode ? (bool)r.Cells["TransferleistungJN"].EditorResolved.Value : (bool)r.Cells["TransferleistungJN"].Value;
            bool SelbstzahlerJN = r.Cells["SelbstzahlerJN"].EditorResolved.IsInEditMode ? (bool)r.Cells["SelbstzahlerJN"].EditorResolved.Value : (bool)r.Cells["SelbstzahlerJN"].Value;

            if (TransferleistungJN == false && SelbstzahlerJN == true)
                return;

            DateTime gueltigAb, gueltigBis = DateTime.Now;

            try
            {
                gueltigAb = r.Cells["GueltigAb"].IsInEditMode ? (DateTime)r.Cells["GueltigAb"].EditorResolved.Value : (DateTime)r.Cells["GueltigAb"].Value;
            }
            catch
            {
                return;
            }

            if (!TransferleistungJN)
            {
                try
                {
                    if (r.Cells["GueltigBis"].IsInEditMode)
                    {
                        gueltigBis = (r.Cells["GueltigBis"].EditorResolved.IsValid && r.Cells["GueltigBis"].EditorResolved.Value != DBNull.Value) ? (DateTime)r.Cells["GueltigBis"].EditorResolved.Value : abrech.GueltigBis;
                    }
                    else
                    {
                        gueltigBis = (r.Cells["GueltigBis"].Value != null && r.Cells["GueltigBis"].Value != DBNull.Value) ? (DateTime)r.Cells["GueltigBis"].Value : abrech.GueltigBis;
                    }
                }
                catch
                {
                    return;
                }
            }

            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            bool refresh = false;
            ValueList vl = null;
            if (vlc.Exists("KST_" + r.Cells["ID"].Value.ToString()))
            {
                vl = vlc["KST_" + r.Cells["ID"].Value.ToString()];

                if(refreshList)
                    vl.ValueListItems.Clear();
            }
            else
            {
                vl = vlc.Add("KST_" + r.Cells["ID"].Value.ToString());
            }

            if (refresh || refreshList)
            {
                vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Transfer Kostenträger wählen."));
                
                Guid idPatient = (Guid)r.Cells["IDPatient"].Value;
                dsKostentraeger.KostentraegerDataTable dt;
                PMDS.DB.Global.DBKostentraeger k = new PMDS.DB.Global.DBKostentraeger();
                if (TransferleistungJN)
                    dt = k.GetTransferPatientkostentraeger(idPatient, gueltigAb.Date, klinik , IDKlinik).Kostentraeger;
                else
                    dt = k.GetTransferPatientkostentraeger(idPatient, gueltigAb.Date, gueltigBis.Date, klinik, IDKlinik).Kostentraeger;
                
                foreach (dsKostentraeger.KostentraegerRow row in dt)
                    vl.ValueListItems.Add(row.ID, row.Name);

            }

            r.Cells[sBoundGridColumn].ValueList = vl;
            r.Cells[sBoundGridColumn].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;


            //Nach aktualisieren von ValueList, wenn die Zelle der entsprechende Spalte selecteirt ist, verliert sie ihr wert.
            //daher muß das alte Wert wieder zurückgesetzt.
            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
            {
                g.ActiveCell.Value = g.ActiveCell.Value;

            }

            if (g.ActiveRow == null || g.ActiveRow != r) return;
            bool gefunden = false;
            foreach (ValueListItem item in vl.ValueListItems)
            {
                if (g.ActiveRow.Cells[sBoundGridColumn].Value != DBNull.Value &&
                    (Guid)g.ActiveRow.Cells[sBoundGridColumn].Value == (Guid)item.DataValue)
                {
                    gefunden = true;
                    break;
                }
            }

            if (!gefunden)
            {
                if (vl.ValueListItems.Count == 2)
                    g.ActiveRow.Cells[sBoundGridColumn].Value = (Guid)vl.ValueListItems[1].DataValue;
                else
                    g.ActiveRow.Cells[sBoundGridColumn].Value = Guid.Empty;
            }
        }    

    }
}
