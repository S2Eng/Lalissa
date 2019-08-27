using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Reflection;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.GUI.BaseControls;

using PMDS.DB.Global;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;
using System.Linq;

namespace PMDS.GUI
{


	public class UltraGridTools
	{
		public UltraGridTools()
		{
			
		}



		public static void SelectFieldInLastRowForEdit(UltraGrid g, string sField)
		{
			g.PerformAction(UltraGridAction.LastRowInBand);
			if (g.ActiveRow == null)
				g.ActiveRow = g.Rows[g.Rows.Count-1];   // scf: wenn man aus einer neuen Zeile noch eine hinzufügt, springt er in die erste neue Zeile
			g.ActiveCell = g.ActiveRow.Cells[sField];
			g.PerformAction(UltraGridAction.EnterEditMode);
		}

        public static void SetGridLayoutToWhiteSmoke(UltraGrid g, Color c)
        {
            g.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            g.DisplayLayout.Override.HeaderAppearance.BackColor = c;
            if (g.DisplayLayout.CaptionAppearance.BackColor.IsEmpty)
                g.DisplayLayout.CaptionAppearance.BackColor = c;
            g.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.WhiteSmoke;
            g.DisplayLayout.Override.RowSelectorAppearance.BackColor = c;
            g.DisplayLayout.ScrollBarLook.Appearance.BackColor = c;
        }

		public static void ShowAllExplorerBarEntries(UltraExplorerBar bar,  bool bShow)
		{
			foreach(UltraExplorerBarGroup g in bar.Groups)
			{
				foreach(UltraExplorerBarItem i in g.Items)
					i.Visible = bShow;
			}
		}

		public static void SetColor(UltraGridRow r, Color c) 
		{
			r.Appearance.BackColor = c;
		}

         public static void SetColors(UltraGridRow r, Color forecolor, Color backcolor)
        {
            r.Appearance.BackColor = backcolor;
            r.Appearance.ForeColor = forecolor;
        }

        public static void ResetColors(UltraGridRow r)
        {
            r.Appearance.ResetBackColor();
            r.Appearance.ResetForeColor();
        }

		public static void SetErrorColor(UltraGridCell cell) 
		{
			cell.Appearance.BackColor = ENVCOLOR.ERROR_BACK_COLOR;
			cell.Appearance.ForeColor = ENVCOLOR.ERROR_FORE_COLOR;
		}

		public static void ResetErrorColor(UltraGridCell cell) 
		{
			cell.Appearance.ResetBackColor();
			cell.Appearance.ResetForeColor();
		}

		public static void NoEditCells(UltraGridRow r) 
		{
			foreach(UltraGridCell c in r.Cells) 
			{
				c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
				c.Activation = Activation.NoEdit;
			}
		}

		public static void SetSpenderZeitpunktHeaderText(Infragistics.Win.UltraWinGrid.ColumnsCollection cc) 
		{
			AuswahlGruppe ag = new AuswahlGruppe("SPZ");
			int i=0;
			foreach(dsAuswahlGruppe.AuswahlListeRow r in ag.AuswahlListe)
			{
				if(i>6)
					break;
				string sKey = string.Format("ZP{0}", i);
				if(cc.Exists(sKey))
					cc[sKey].Header.Caption = r.Bezeichnung;
				i++;
			}
			
		}

        public static void SetSelected(UltraGrid g, bool bSelected)
        {
            SetSelected(g, bSelected, "", "");
        }

		public static void SetSelected(UltraGrid g, bool bSelected, string sColumnCompare, string sNoIfEqueal) 
		{
			UltraGridRow[] ra = GetAllRowsFromGroupedUltraGrid(g, false);
			foreach(UltraGridRow r in ra) 
			{
                if (sColumnCompare.Length > 0)
                {
                    if (r.Cells[sColumnCompare].Value.ToString() == sNoIfEqueal)
                        continue;
                }
				r.Selected = bSelected;
			}
		}

        public static void SetSelectedAndVisible(UltraGrid g, bool bSelected, bool bVisible)
        {
            UltraGridRow[] ra = GetAllRowsFromGroupedUltraGrid(g, false);
            foreach (UltraGridRow r in ra)
            {
                r.Selected = bSelected;
                r.Hidden = !bVisible;
            }
        }

		public static void SetBoolean(UltraGrid g, string sColumn, bool bValue) 
		{
			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sColumn];
			UltraGridRow[] ra = GetAllRowsFromGroupedUltraGrid(g, false);
			foreach(UltraGridRow r in ra) 
			{
				r.Cells[c].Value = bValue;
			}
		}

		public static void SetVisible(UltraGrid g, bool bVisible) 
		{
			UltraGridRow[] ra = GetAllRowsFromGroupedUltraGrid(g, false);
			foreach(UltraGridRow r in ra) 
			{
				r.Hidden = !bVisible;
			}
		}

		public static void EndCurrentEdit(UltraGrid g) 
		{
			UltraGridCell cell =  g.ActiveCell;
			g.UpdateData();
			g.ActiveCell = null;
			g.ActiveCell = cell;
		}

		public static void HandleDeleteSelected(UltraGrid g)
		{
			ArrayList al = new ArrayList();
			foreach(UltraGridRow r in  g.Selected.Rows)
				al.Add(r);

			// UltraGridRow[] ra = GetAllRowsFromGroupedUltraGrid(g, true);
			UltraGridRow[] ra  = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
			if(ra.Length == 0) 
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if(AskRowDelete() != DialogResult.Yes)
				return;
			foreach(UltraGridRow r in ra)
				r.Delete(false);
		}

		public static void HandleBevoreDeleteRowsEvent(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
		{
			if(!e.DisplayPromptMsg)
				return;

			e.DisplayPromptMsg = false;
			if(AskRowDelete() == DialogResult.Yes)
				return;
			e.Cancel = true;
		}

		public static DialogResult AskRowDelete()
		{
			return QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zeile(n) löschen ?", "Löschen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
		}

		public static void SetTag(UltraGrid g, object oTag) 
		{
			UltraGridRow[] ra = GetAllRowsFromGroupedUltraGrid(g, false);
			foreach(UltraGridRow r in ra) 
			{
				r.Tag	= oTag;
			}
		}

        protected static void GetAllRowsFromGroupedUltraGrid(UltraGridRow r, ref ArrayList al, bool bSelectedOnly)
        {
            GetAllRowsFromGroupedUltraGrid(r, ref al, bSelectedOnly, false);
        }

		protected static void GetAllRowsFromGroupedUltraGrid(UltraGridRow r, ref ArrayList al, bool bSelectedOnly, bool bUseChildBands) 
		{
			if(r is UltraGridGroupByRow) 
			{
				UltraGridGroupByRow gr = (UltraGridGroupByRow)r;
				foreach(UltraGridRow rr in gr.Rows)
					GetAllRowsFromGroupedUltraGrid(rr, ref al, bSelectedOnly);
				return;
			}

            if (bUseChildBands && r.ChildBands != null)
            {
                foreach (UltraGridChildBand b in r.ChildBands)
                {
                    foreach (UltraGridRow rchild in b.Rows)
                        GetAllRowsFromGroupedUltraGrid(rchild, ref al, bSelectedOnly, bUseChildBands);
                }
            }

			if (r.IsFilteredOut)
				return;

			if(bSelectedOnly)
			{
				if(r.Selected)
					al.Add(r);
			}
			else
			{
				al.Add(r);
			}

		}

		public static void RemoveValueList(string sGruppe, UltraGrid g)
		{
			if (g.DisplayLayout.ValueLists.Exists(sGruppe))
				g.DisplayLayout.ValueLists.Remove(sGruppe);
		}

		public static void RemoveAbteilungsValueList(UltraGrid g)
		{
			RemoveValueList("ABT", g);
		}

		public static void RemoveBenutzerValueList(UltraGrid g)
		{
			RemoveValueList("BEN", g);
		}
        
        public static void AddGuidTextValuListFromAuswahlGruppe(string sAuswahlGruppe, UltraGrid g, string sBoundGridColumn, int SupressLevelHierarchie, bool AddOnlyHierarchePlus)
        {
            AddGuidTextValuListFromAuswahlGruppe(sAuswahlGruppe, g, sBoundGridColumn, true, SupressLevelHierarchie, AddOnlyHierarchePlus);
        }

		public static void AddGuidTextValuListFromAuswahlGruppe(string sAuswahlGruppe, UltraGrid g, string sBoundGridColumn, bool SetDropDownListStyle, int SupressLevelHierarchie, bool AddOnlyHierarchePlus) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;
			
			ValueList vl = null;

			if(vlc.Exists(sAuswahlGruppe))
				vl = vlc[sAuswahlGruppe];
			else 
			{
				vl = vlc.Add(sAuswahlGruppe);
				AuswahlGruppe	gr = new AuswahlGruppe(sAuswahlGruppe);						// Die jeweilige Auswahlgruppe
				vl.ValueListItems.Add(Guid.Empty, "  ");                                        // Empty immer als leerstring anzeigen und nie als GUID
                foreach (dsAuswahlGruppe.AuswahlListeRow r in gr.AuswahlListe)
                {
                    if (AddOnlyHierarchePlus)
                    {
                        if (r.Hierarche >= SupressLevelHierarchie)
                        {
                            vl.ValueListItems.Add(r.ID, r.Bezeichnung.Trim());
                        }
                    }
                    else
                    {
                        vl.ValueListItems.Add(r.ID, r.Bezeichnung.Trim());
                    }
                }
			}
			
			
			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
            if(SetDropDownListStyle)
                c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
		}

        public static void AddIntTextValuList(string ValueListName, UltraGrid g, string sBoundGridColumn, int from, int to)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;

            if (vlc.Exists(ValueListName))
                vl = vlc[ValueListName];
            else
            {
                vl = vlc.Add(ValueListName);
                vl.ValueListItems.Add(-1, " ");										         // Empty immer als leerstring anzeigen und nie als GUID
                int ii = from;
                for (int i = 0; i < to - from + 1; i++)
                {
                    vl.ValueListItems.Add(ii, ii.ToString());
                    ii++;
                }
            }


            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

		public static void AddTextTextValuListFromAuswahlGruppe(string sAuswahlGruppe, UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;
			
			ValueList vl = null;

			if(vlc.Exists(sAuswahlGruppe))
				vl = vlc[sAuswahlGruppe];
			else 
			{
				vl = vlc.Add(sAuswahlGruppe);
				AuswahlGruppe	gr = new AuswahlGruppe(sAuswahlGruppe);						// Die jeweilige Auswahlgruppe
                
                // Sortieren nach Reihenfolge
                //dsAuswahlGruppe.AuswahlListeGruppeDataTable dtResult = new dsAuswahlGruppe.AuswahlListeGruppeDataTable();
                dsAuswahlGruppe.AuswahlListeDataTable dtResult = (dsAuswahlGruppe.AuswahlListeDataTable) DBGemeinsameFunktionen.Sort((System.Data.DataTable)gr.AuswahlListe, "", "Reihenfolge ASC");

				foreach(dsAuswahlGruppe.AuswahlListeRow r in dtResult)
					vl.ValueListItems.Add(r.Bezeichnung, r.Bezeichnung);
			}
            //Änderung nach 03.03.2008 MDA
            UltraGridColumn c;
            foreach (UltraGridBand b in g.DisplayLayout.Bands)
            {
                if (b.Columns.Exists(sBoundGridColumn))
                {
                    c = b.Columns[sBoundGridColumn];
                    c.ValueList = vl;
                    c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                }
            }
		}

		public static void AddAbteilungsValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("ABT"))
				vl = vlc["ABT"];
			else 
			{
				vl = vlc.Add("ABT");
				// AuswahlCombo Abteilung initialisieren
				Abteilung a = new Abteilung();
				foreach(dsAbteilung.AbteilungRow r in a.ABTEILUNGLISTE)
					vl.ValueListItems.Add(r.ID, r.Bezeichnung);

			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

		}

        public static void AddZeitbereichValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("ZEITBEREICH"))
                vl = vlc["ZEITBEREICH"];
            else
            {
                vl = vlc.Add("ZEITBEREICH");
                // AuswahlCombo Abteilung initialisieren
                Zeitbereich z = new Zeitbereich();
                dsZeitbereich.ZeitbereichDataTable dt = z.Read();
                vl.ValueListItems.Add(Guid.Empty, " ");
                foreach (dsZeitbereich.ZeitbereichRow r in dt)
                    vl.ValueListItems.Add(r.ID, r.Bezeichnung);
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddZeitbereichSerienValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("ZEITBEREICHSERIEN"))
                vl = vlc["ZEITBEREICHSERIEN"];
            else
            {
                vl = vlc.Add("ZEITBEREICHSERIEN");
                // AuswahlCombo Abteilung initialisieren
                ZeitbereichSerien z = new ZeitbereichSerien();
                dsZeitbereichSerien.ZeitbereichSerienDataTable dt = z.Read();
                vl.ValueListItems.Add(Guid.Empty, " ");
                foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)
                    vl.ValueListItems.Add(r.ID, r.Bezeichnung);
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddZeitbereichSerienWithZeitBereichIdsValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("ZEITBEREICHSERIENZBIDS"))
                vl = vlc["ZEITBEREICHSERIENZBIDS"];
            else
            {
                vl = vlc.Add("ZEITBEREICHSERIENZBIDS");
                vl.ValueListItems.Add(new ZeitbereichHelper(Guid.Empty, ZeitbereichTyp.Zeitbereich), " ");

                Zeitbereich zb = new Zeitbereich();                                     // Zeitbereich hinzufügen
                dsZeitbereich.ZeitbereichDataTable dtz = zb.Read();
                foreach (dsZeitbereich.ZeitbereichRow rz in dtz)
                    vl.ValueListItems.Add(new ZeitbereichHelper(rz.ID, ZeitbereichTyp.Zeitbereich), rz.Bezeichnung);
                
                ZeitbereichSerien z = new ZeitbereichSerien();                          // Zeitbereichserien hinzufügen
                dsZeitbereichSerien.ZeitbereichSerienDataTable dt = z.Read();
                
                foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)
                    vl.ValueListItems.Add(new ZeitbereichHelper(r.ID, ZeitbereichTyp.ZeitbereichSerien), r.Bezeichnung);
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddEintragValueList(UltraGrid g, char cGroup, string sBoundGridColumn, int iBand)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            string svl = "EINTRAG" + Convert.ToString(cGroup);
            ValueList vl = null;
            if (vlc.Exists(svl))
                vl = vlc[svl];
            else
                vl = vlc.Add(svl);

            vl.ValueListItems.Clear();

            Katalog k = new PDx().KATALOGE['M'];            // Werte laden
            vl.ValueListItems.Add(Guid.Empty, " ");
            foreach (dsEintrag.EintragRow r in k.EINTRAEGE)
                vl.ValueListItems.Add(r.ID, r.Text);

            UltraGridColumn c = g.DisplayLayout.Bands[iBand].Columns[sBoundGridColumn];
            c.ValueList = vl;
        }
		
		public static void AddSpenderTypValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("SPT"))
				vl = vlc["SPT"];
			else 
			{
				vl = vlc.Add("SPT");
				vl.ValueListItems.Add((int)SpenderTyp.Einzelspender, ENV.SpenderTypText(SpenderTyp.Einzelspender));
				vl.ValueListItems.Add((int)SpenderTyp.Tagesspender, ENV.SpenderTypText(SpenderTyp.Tagesspender));
				vl.ValueListItems.Add((int)SpenderTyp.Wochenspender, ENV.SpenderTypText(SpenderTyp.Wochenspender));
				vl.ValueListItems.Add((int)SpenderTyp.KeinSpender, " ");
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
		}

		public static void AddUntertaegigSerieValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("USE"))
				vl = vlc["USE"];
			else 
			{
				vl = vlc.Add("USE");
				// AuswahlCombo Abteilung initialisieren
				Massnahmenserien a = Massnahmenserien.Default();
				foreach(dsMassnahmenserien.MassnahmenserienRow r in a.Serien)
					vl.ValueListItems.Add(r.ID, r.Bezeichnung);
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

		}

        public static void AddZielEvaluierungsstatusValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("ZEV"))
                vl = vlc["ZEV"];
            else
            {
                vl = vlc.Add("ZEV");
                vl.ValueListItems.Add(101, QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreicht - ASZM ändern"));
                vl.ValueListItems.Add(102, QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreicht - weiter wie bisher"));
                vl.ValueListItems.Add(103, QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreicht - PDX beenden"));

                vl.ValueListItems.Add(201, QS2.Desktop.ControlManagment.ControlManagment.getRes("Teilweise erreicht - ASZM ändern"));
                vl.ValueListItems.Add(202, QS2.Desktop.ControlManagment.ControlManagment.getRes("Teilweise erreicht - weiter wie bisher"));
                vl.ValueListItems.Add(203, QS2.Desktop.ControlManagment.ControlManagment.getRes("Teilweise erreicht - PDX beenden"));

                vl.ValueListItems.Add(301, QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht erreicht - ASZM ändern"));
                vl.ValueListItems.Add(302, QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht erreicht - weiter wie bisher"));
                vl.ValueListItems.Add(303, QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht erreicht - PDX beenden"));
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

		public static void AddPflegerValueListWithEmptyEntry(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("PFL"))
				vl = vlc["PFL"];
			else 
			{
				vl = vlc.Add("PFL");
				// Benutzer lesen
				dsGUIDListe.IDListeDataTable t = Benutzer.AllPfleger();
				foreach(dsGUIDListe.IDListeRow r in t.Rows)
					vl.ValueListItems.Add(r.ID, r.TEXT);
				vl.ValueListItems.Add(Guid.Empty, "****************");
			}
		
			

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

			
		}

		public static void AddBenutzerValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("BEN"))
				vl = vlc["BEN"];
			else 
			{
				vl = vlc.Add("BEN");
				// Benutzer lesen
				dsGUIDListe.IDListeDataTable t = Benutzer.All();
				foreach(dsGUIDListe.IDListeRow r in t.Rows)
					vl.ValueListItems.Add(r.ID, r.TEXT);
			}

            //Änderung nach 06.03.2008 MDA
            UltraGridColumn c;
            foreach (UltraGridBand b in g.DisplayLayout.Bands)
            {
                if (b.Columns.Exists(sBoundGridColumn))
                {
                    c = b.Columns[sBoundGridColumn];
                    c.ValueList = vl;
                    c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                }
            }
		}
 
        public static void AddLinkDokumentValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("LDO"))
                vl = vlc["LDO"];
            else
            {
                vl = vlc.Add("LDO");
                // Linkdokumente lesen
                LinkDokumente d = new LinkDokumente();
                dsGUIDListe.IDListeDataTable t = d.ALL_IDLISTE;
                
                vl.ValueListItems.Add(Guid.Empty, "     ");
                
                foreach (dsGUIDListe.IDListeRow r in t.Rows)
                    vl.ValueListItems.Add(r.ID, r.TEXT);
            }



            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddEintragFlagValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("EFL"))
                vl = vlc["EFL"];
            else
            {
                vl = vlc.Add("EFL");

                string[] sa = Enum.GetNames(typeof(EintragFlag));
                int i = 0;
                foreach (string s in sa)
                {
                    vl.ValueListItems.Add(i, s);
                    i++;
                }
            }


            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddHerrichtenValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            ValueList vl = null;
            if (vlc.Exists("HERRICHTEN"))
                vl = vlc["HERRICHTEN"];
            else
            {
                vl = vlc.Add("HERRICHTEN");

                vl.ValueListItems.Add(medHerrichten.nein, QS2.Desktop.ControlManagment.ControlManagment.getRes("nein (z.B. Salben)"));
                vl.ValueListItems.Add(medHerrichten.kurzfristig, QS2.Desktop.ControlManagment.ControlManagment.getRes("kurzfristig (z.B. Tropfen)"));
                vl.ValueListItems.Add(medHerrichten.langfristig, QS2.Desktop.ControlManagment.ControlManagment.getRes("langfristig (Dispenser)"));
                vl.ValueListItems.Add(medHerrichten.beiBedarf, QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung"));
                vl.ValueListItems.Add(medHerrichten.aerztlich, QS2.Desktop.ControlManagment.ControlManagment.getRes("ärztlich"));
                vl.ValueListItems.Add(medHerrichten.suchtgift, QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchtgift"));
            }
            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
        }

        public static void AddVerabreichungValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            ValueList vl = null;
            if (vlc.Exists("VERABREICHUNG"))
                vl = vlc["VERABREICHUNG"];
            else
            {
                vl = vlc.Add("VERABREICHUNG");
                vl.ValueListItems.Add(medVerabreichung.einzeln, QS2.Desktop.ControlManagment.ControlManagment.getRes("einzeln"));
                vl.ValueListItems.Add(medVerabreichung.wieHergerichtet, QS2.Desktop.ControlManagment.ControlManagment.getRes("wie hergerichtet"));

            }
            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
        }

        public static UltraGridRow[] GetAllRowsFromGroupedUltraGrid(UltraGrid g, bool bSelectedOnly)
        {
            return GetAllRowsFromGroupedUltraGrid(g, bSelectedOnly, false);
        }

		public static UltraGridRow[] GetAllRowsFromGroupedUltraGrid(UltraGrid g, bool bSelectedOnly, bool bUseChildBands)
		{
			ArrayList al = new ArrayList();
			foreach(UltraGridRow r in g.Rows)
				GetAllRowsFromGroupedUltraGrid(r, ref al, bSelectedOnly, bUseChildBands);
			return (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
		}

		public static object ToObject(UltraGridRow row)
		{
			return (((DataRowView)row.ListObject).Row);
		}

		public static void SetAppearanceAndDisplayStyle(UltraGrid ug)
		{
			//			ug.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Down, UltraGridAction.BelowCell, 0,
			//				UltraGridState.InEdit, 0, 0 ));
			//			ug.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Up, UltraGridAction.AboveCell, 0,
			//				UltraGridState.InEdit, 0, 0 ));
			ug.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Return, UltraGridAction.EnterEditMode, 0,
				0, 0, 0 ));
		}

		public static void EnableColumns(ColumnsCollection cc, bool bEnabled)
		{
			foreach(UltraGridColumn c in cc)
				if(bEnabled == false)
					c.CellActivation = Activation.NoEdit;
				else
					c.CellActivation = Activation.AllowEdit;
		}

		public static void EnableColumns(UltraGrid g, bool bEnabled)
		{
			ColumnsCollection cc = g.DisplayLayout.Bands[0].Columns;
			foreach(UltraGridColumn c in cc)
				if(bEnabled == false)
					c.CellActivation = Activation.NoEdit;
				else
					c.CellActivation = Activation.AllowEdit;
		}

		public static void EnableColumn(UltraGrid g, string sColumn, bool bEnabled)
		{
			if(bEnabled == false)
				g.DisplayLayout.Bands[0].Columns[sColumn].CellActivation = Activation.NoEdit;
			else
				g.DisplayLayout.Bands[0].Columns[sColumn].CellActivation = Activation.AllowEdit;
		}

		public static void DeleteCurrentSelectedRow(UltraGrid g, bool AskForSure)
		{
			UltraGridRow r = g.ActiveRow;
			if((r == null) || (r.ListObject == null))
				return;

            DialogResult res = DialogResult.Yes;
            if (AskForSure)
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    Guid IDZGE = new Guid(r.Cells["ID"].Value.ToString().ToUpper());
                    if (db.ZusatzWert.Where(a => a.IDZusatzGruppeEintrag == IDZGE).Count() > 0)
                    {
                        res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wenn Sie diesen Eintrag löschen, werden alle bisher erfassten Zusatzwerte unwiederbringlich gelöscht.\r\nSind Sie Sicher, dass Sie das möchten?", "ACHTUNG!", MessageBoxButtons.YesNo);
                    }
                }
            }

            if (res == DialogResult.Yes)
            {
                int iIndex = Math.Min(g.ActiveRow.VisibleIndex, g.Rows.Count - 2);
                r.Delete(false);
                r = g.Rows.GetRowAtVisibleIndex(iIndex);
                if (r != null)
                    g.ActiveRow = r;
            }
        }

		public static object CurrentSelectedRow(UltraGrid g)
		{
			UltraGridRow r = g.ActiveRow;
			if((r == null) || (r.ListObject == null))
				return null;

			DataRowView v = (DataRowView)r.ListObject;
			return v.Row;
		}

		public static void SetCurrentSelectedRow(UltraGrid g, string col, object val)
        {
			UltraGridRow[] ra = UltraGridTools.GetAllRowsFromGroupedUltraGrid(g, false);
			foreach(UltraGridRow r in ra)
			{
				if((r == null) || (r.ListObject == null))
					continue;

				DataRowView v = (DataRowView)r.ListObject;
				if (v.Row[col].Equals(val))
				{
					g.ActiveRow = r;
					break;
				}
			}
		}

		public static bool DoubleClickOnActiveRow(UltraGrid g, Point p)
		{
			Infragistics.Win.UIElement ui = g.DisplayLayout.UIElement.ElementFromPoint(p);
            UltraGridRow r = null;
            if(ui != null)
			    r = (UltraGridRow)ui.GetContext(typeof(UltraGridRow));
			return (g.ActiveRow == r);
		}

		public static void AddWochentagValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("DAY"))
				vl = vlc["DAY"];
			else 
			{
				vl = vlc.Add("DAY");

				// Wochentage einfügen
				string daysSet = ENV.String("WEEK_DAYS_SET");
				string daysClr = ENV.String("WEEK_DAYS_CLR");
				StringBuilder sb = new StringBuilder();

				for (int i=0;i<=(int)WeekDay.ALL;i++)
				{
					sb.Length = 0;
					for(int day=0;day<7;day++)
						sb.Append(((i & (1<<day)) != 0) ? daysSet[day] : daysClr[day]);

					vl.ValueListItems.Add(i, sb.ToString());
				}
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
			//c.Style		= ColumnStyle.DropDownList;
		}


		public static void AddSpenderZeitpunkteValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("SPZ"))
				vl = vlc["SPZ"];
			else 
			{
				vl = vlc.Add("SPZ");

				// Wochentage einfügen
				StringBuilder sb = new StringBuilder();

				for (int i=0;i<129;i++)
				{
					sb.Length = 0;
					for(int y=0;y<7;y++)
						sb.Append(((i & (1<<y)) != 0) ? "x" : "_");

					vl.ValueListItems.Add(i, sb.ToString());
				}
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
		}

		public static void AddIntervallValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("INTERVALL"))
				vl = vlc["INTERVALL"];
			else 
			{
				vl = vlc.Add("INTERVALL");

				// Intervall einfügen
				int []	factor	= { 7*24,		24,		1 };
				string[]text	= ENV.String("INTERVALL_TYPES").Split(',');
				string[]ext		= ENV.String("INTERVALL_TYPES_EXT").Split(',');

				for (int i=0;i<=365*24;i++)
				{
					for(int f=0;f<factor.Length;f++)
					{
						if((i % factor[f]) == 0)
						{
							int fac = i / factor[f];
							string add = ((fac == 1) ? "" : ext[f]);
							vl.ValueListItems.Add(i, string.Format("{0} {1}{2}",fac, text[f], add));
							break;
						}
					}
				}
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
			c.MaskInput = "";
		}

		public static UltraGridColumn AddValueList(UltraGrid g, string sBound, string sGrp,
			DataTable table, string key, string val) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists(sGrp))
				vl = vlc[sGrp];
			else 
			{
				vl = vlc.Add(sGrp);
				foreach(DataRow r in table.Rows)
					vl.ValueListItems.Add(r[key], (string)r[val]);
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBound];
			c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			return c;
		}

		public static void AddButtonValueList(UltraGrid g, string sBound, string sGrp,
			DataTable table, string key, string val) 
		{
            AddValueList(g, sBound, sGrp, table, key, val).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
		}

		public static void AddNoZeroValueList(UltraGrid g, string sBoundGridColumn) 
		{
			ValueListsCollection vlc = g.DisplayLayout.ValueLists;

			ValueList vl = null;
			if(vlc.Exists("ZERO"))
				vl = vlc["ZERO"];
			else 
			{
				vl = vlc.Add("ZERO");
				vl.ValueListItems.Add(0, " ");
			}

			UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
			c.ValueList = vl;
			//c.Style		= ColumnStyle.DropDownList;
		}

		public static void ValidateDouble(UltraGridCell c) 
		{
			// Im Fehlerfall - Format korrigieren
			string text = c.Text;
			try	{	Double val = Convert.ToDouble(text);	}
			catch{	c.Value = (0.0d).ToString();			}
		}

        public static void AddFilterCondition(UltraGrid grid, string columnKey, FilterComparisionOperator filterOperator, object value)
        {
            ColumnFiltersCollection columnFilters = grid.DisplayLayout.Bands[0].ColumnFilters;
            columnFilters[columnKey].ClearFilterConditions();
            columnFilters[columnKey].FilterConditions.Add(filterOperator, value);
        }

        public static void AddPatientenValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("PAT"))
                vl = vlc["PAT"];
            else
            {
                vl = vlc.Add("PAT");
                // Werte laden
                Patient p = new Patient();

                vl.ValueListItems.Add(DBNull.Value, "");
                foreach (dsGUIDListe.IDListeRow r in (dsGUIDListe.IDListeDataTable)p.AllEntries())
                    vl.ValueListItems.Add(r.ID, r.TEXT);

            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddPatientenValueListFromCurrenUserAbteilungen(UltraGrid g, string sBoundGridColumn, bool bShowEntlassene)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("PAT"))
                vl = vlc["PAT"];
            else
            {
                vl = vlc.Add("PAT");
                // Werte laden
                Patient p = new Patient();

                vl.ValueListItems.Add(DBNull.Value, "");
                dsPatientStation.PatientDataTable dt = Patient.ByFilter("", false, ENV.CurrentUserAbteilungen.ToArray(), Guid.Empty, bShowEntlassene, ENV.IDKlinik);
                foreach (dsPatientStation.PatientRow r in dt)
                    vl.ValueListItems.Add(r.ID, r.Name);

            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

        }

        public static void AddPatientenValueListFromAbteilungenxy(UltraGrid g, string sBoundGridColumn, Guid[] idAbteilung, bool bShowEntlassene)
        {
            try
            {
                ValueListsCollection vlc = g.DisplayLayout.ValueLists;

                ValueList vl = null;
                if (vlc.Exists("PAT"))
                    vl = vlc["PAT"];
                else
                {
                    vl = vlc.Add("PAT");
                    // Werte laden
                    Patient p = new Patient();

                    //<20120202-2>
                    vl.ValueListItems.Add(DBNull.Value, "");
                    dsPatientStation.PatientDataTable dt = Patient.ByFilter("", false, idAbteilung, Guid.Empty, false, ENV.IDKlinik);
                    foreach (dsPatientStation.PatientRow r in dt)
                        vl.ValueListItems.Add(r.ID, r.Name);

                    ArrayList arrIDKlient = new ArrayList();

                    dsPatientStation.PatientDataTable dt2 = Patient.ByFilter("", false, idAbteilung, Guid.Empty, true, ENV.IDKlinik);
                    foreach (dsPatientStation.PatientRow r in dt2)
                    {
                        foreach (ValueListItem itm in  vl.ValueListItems  )
                        {
                            bool bExists = false;
                            if (itm.DataValue != DBNull.Value  )
                            {
                                if (itm.DataValue != DBNull.Value && (Guid)itm.DataValue == r.ID)
                                {
                                    bExists = true;
                                }
                                if (!bExists)
                                {
                                    cFields clFld = new cFields();
                                    clFld.ID = r.ID ;
                                    clFld.UIDNr = r.Name;
                                    arrIDKlient.Add(clFld);
                                }
                            }
                        }
                    }

                    foreach (cFields itm in arrIDKlient)
                    {
                        vl.ValueListItems.Add(itm.ID, itm.UIDNr);
                    }

                }

                UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
                c.ValueList = vl;
                c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        public static void AddMedikationPatientenValueList(dsMedikationVonBis.MedikationDataTable dt, UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("PAT"))
            {
                vl = vlc["PAT"];
                vl.ValueListItems.Clear();
            }
            else
            {
                vl = vlc.Add("PAT");
            }
            // Werte laden
            Patient p;
            List<Guid> lIdPatient = new List<Guid>();
            foreach (dsMedikationVonBis.MedikationRow r in dt)
            {
                if (lIdPatient.IndexOf(r.IDPatient) == -1)
                {
                    p = new Patient(r.IDPatient);
                    vl.ValueListItems.Add(p.ID, p.FullName);
                    lIdPatient.Add(p.ID);
                }
            }
            lIdPatient.Clear();
            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

        public static void AddKostentraegerValueList(Guid IDPatient, UltraGrid g, string sBoundGridColumn, System.Guid  IDKlinik)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("KST"))
            {
                vl = vlc["KST"];
                vl.ValueListItems.Clear();
            }
            else
            {
                vl = vlc.Add("KST");
            }
            // Werte laden

            dsGUIDListe.IDListeDataTable dt = new Depotgeldkonto().GetListKostentraeger(IDPatient, IDKlinik);
            vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Kostenträger wählen."));
            
            foreach (dsGUIDListe.IDListeRow r in dt.Rows)
                vl.ValueListItems.Add(r.ID, r.TEXT);

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            //Neu nach 25.10.2007 MDA
            //Nach aktualisieren von ValueList, wenn die Zelle der entsprechende Spalte selecteirt ist, verliert sie ihr wert.
            //daher muß das alte Wert wieder zurückgesetzt.
            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
                g.ActiveCell.Value = g.ActiveCell.Value;
        }

        public static void AddTaschengeldKostentraegerValueList(UltraGrid g, string sBoundGridColumn, bool refreshList, bool klinik, System.Guid IDKlinik)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            bool refresh = false;
            ValueList vl = null;
            if (vlc.Exists("KST"))
            {
                vl = vlc["KST"];
                if (refreshList)
                    vl.ValueListItems.Clear();
            }
            else
            {
                vl = vlc.Add("KST");
                refresh = true;
            }

            if (refresh || refreshList)
            {
                // Werte laden
                PMDS.DB.Global.DBKostentraeger k = new PMDS.DB.Global.DBKostentraeger();

                //Neu nach 19.10.2007 MDA
                vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Kostenträger wählen."));
               
                foreach (PMDS.Global.db.Global.ds_abrechnung.dsKostentraeger.KostentraegerRow r in k.GetTaschengeldKostentraeger(klinik, IDKlinik))
                {
                    vl.ValueListItems.Add(r.ID, r.Name);
                }
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            //Nach aktualisieren von ValueList, wenn die Zelle der entsprechende Spalte selecteirt ist, verliert sie ihr wert.
            //daher muß das alte Wert wieder zurückgesetzt.
            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
                g.ActiveCell.Value = g.ActiveCell.Value;
        }

        public static void AddZahlartValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;
            ValueList vl = null;
            if (vlc.Exists("ZAHLART"))
                vl = vlc["ZAHLART"];
            else
            {
                vl = vlc.Add("ZAHLART");
                vl.ValueListItems.Add((int)PMDS.Calc.Logic.eZahlart.Bankeinzug, PMDS.Calc.Logic.eZahlart.Bankeinzug.ToString() );
                vl.ValueListItems.Add((int)PMDS.Calc.Logic.eZahlart.Bar, PMDS.Calc.Logic.eZahlart.Bar.ToString());
                vl.ValueListItems.Add((int)PMDS.Calc.Logic.eZahlart.Erlagschein, PMDS.Calc.Logic.eZahlart.Erlagschein.ToString());
                vl.ValueListItems.Add((int)PMDS.Calc.Logic.eZahlart.Überweisung, PMDS.Calc.Logic.eZahlart.Überweisung.ToString());
            }
            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }
	}

    public class cFields
    {
        public System.Guid ID;
        public string UIDNr = "";
    }
}
