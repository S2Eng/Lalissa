using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using PMDS.Global.db.Patient;
using System.Drawing;

using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using PMDS.Global.db.ERSystem;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.DB;
using PMDS.Data.Global;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace PMDS.Global.db.ERSystem
{
        
    public class PMDSBusinessUI
    {

        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();

        public enum eTypeUI
        {
            VOErfassenKlientStammdaten = 0,
            VOErfassenPlanung2 = 1,
            VOErfassenPlanungOnlyShow = 2,
            VOErfassungMedDaten = 3,
            VOErfassenVerwaltung = 4,
            VOErfassenWunde = 5,
        }

        public class cItmTg
        {
            public bool IsDatabase = false;

            public string fileNameOnly = "";
            public string fileNameFull = "";
            public string Dir = "";

            public string Database = "";
            public string ConnStringInConfig = "";
        }









        public static void initPDFViewer()
        {
            Patagames.Pdf.Net.PdfCommon.Initialize("52433553494d50032923be84e16cd6ae0bce153446af7918d52303038286fd2b0597de34bf5bb65e2a161a268e74107bd7da7c1adb202edff3e8c55a13bff7afa38569c96e45ff0cdef48e36b8df77e907676788cae00126f52c5eaadbb3c424062e8e0e5feb6faf89900306ee469aa40664bdf84b2e4fce7497c19f3f9d2d877dc1be192cb695f4");
        }


        public void initFormDekurse(ref QS2.Desktop.Txteditor.frmTxtEditorField frmEditor, ref TXTextControl.TextControl textControl1, 
                                    ref string sLine, ref string LineRtf, ref string LinePlain)
        {
            try
            {
                sLine = "____________________________________________________________________________________";
                LineRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, textControl1);
                LinePlain = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, textControl1);

                frmEditor = new QS2.Desktop.Txteditor.frmTxtEditorField();
                frmEditor.ContTXTField1.initControl(TXTextControl.ViewMode.FloatingText, true, true, false, true, false, false);
                //frmEditor.ContTXTField1delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChanged);

                //QS2.Desktop.Txteditor.frmTxtEditor frmEditorxy = new QS2.Desktop.Txteditor.frmTxtEditor();
                //frmEditor.fFelderEinAus = false;
                //frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                //frmEditor.ContTxtEditor1.LinealeOnOff(false);
                //frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.ReadAndSelect;
                //frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                frmEditor.Show();
                frmEditor.ContTXTField1.TXTControlField.ViewMode = TXTextControl.ViewMode.PageView;
                frmEditor.ContTXTField1.TXTControlField.EditMode = TXTextControl.EditMode.ReadOnly;
                frmEditor.ContTXTField1.doSmallVersion();
                Application.DoEvents();

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.initFormDekurse: " + ex.ToString());
            }
        }

        public void printDekurse(ref QS2.Desktop.Txteditor.frmTxtEditorField frmEditor, ref TXTextControl.TextControl textControl1, 
                                string DekursRtf, string Dekurs, string Benutzer, string Zusatzwerte, string Maßnahme, string Zeitpunkt,
                                ref string infoRow, ref string sLine, ref string LineRtf, ref string LinePlain)
        {
            try
            {
                int Position1 = frmEditor.ContTXTField1.TXTControlField.InputPosition.TextPosition;
                this.doEditor1.appendText2(infoRow.Trim(), frmEditor.ContTXTField1.TXTControlField, TXTextControl.StringStreamType.PlainText);
                this.doEditor1.insertLinebreakxy(frmEditor.ContTXTField1.TXTControlField);
                frmEditor.ContTXTField1.TXTControlField.Select(Position1, frmEditor.ContTXTField1.TXTControlField.Text.Length - Position1);
                frmEditor.ContTXTField1.TXTControlField.Selection.FontSize = 10 * 20;
                frmEditor.ContTXTField1.TXTControlField.Selection.FontName = "Arial";
                frmEditor.ContTXTField1.TXTControlField.Selection.ForeColor = System.Drawing.Color.RoyalBlue;
                frmEditor.ContTXTField1.TXTControlField.Selection.Bold = true;

                infoRow = Zeitpunkt.Trim() + "\r\n";        //.ToString("dd.mm.yyyy")
                                                                        //infoRow += "\r\n";
                infoRow += QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme: ") + Maßnahme.Trim() + "\r\n";        //.ToString("dd.mm.yyyy")
                if (Zusatzwerte.Trim() != "")
                {
                    infoRow += QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzwerte: ") + Zusatzwerte.Trim() + "\r\n";        //.ToString("dd.mm.yyyy")
                }
                infoRow += QS2.Desktop.ControlManagment.ControlManagment.getRes("Erstellt von: ") + Benutzer.Trim() + "\r\n";        //.ToString("dd.mm.yyyy")

                int Position2 = frmEditor.ContTXTField1.TXTControlField.InputPosition.TextPosition;
                this.doEditor1.appendText2(infoRow.Trim(), frmEditor.ContTXTField1.TXTControlField, TXTextControl.StringStreamType.PlainText);
                this.doEditor1.insertLinebreakxy(frmEditor.ContTXTField1.TXTControlField);
                this.doEditor1.insertLinebreakxy(frmEditor.ContTXTField1.TXTControlField);
                frmEditor.ContTXTField1.TXTControlField.Select(Position2, frmEditor.ContTXTField1.TXTControlField.Text.Length - Position2);
                frmEditor.ContTXTField1.TXTControlField.Selection.FontSize = 9 * 20;
                frmEditor.ContTXTField1.TXTControlField.Selection.FontName = "Arial";
                frmEditor.ContTXTField1.TXTControlField.Selection.ForeColor = System.Drawing.Color.Black;
                frmEditor.ContTXTField1.TXTControlField.Selection.Bold = false;

                textControl1.Text = "";
                ReadInEditorDoLine(DekursRtf.Trim(), Dekurs.Trim(), ref infoRow, ref sLine, frmEditor.ContTXTField1.TXTControlField,
                                        ref LineRtf, ref LinePlain);
                this.doEditor1.insertLinebreakxy(frmEditor.ContTXTField1.TXTControlField);
                this.doEditor1.insertLinebreakxy(frmEditor.ContTXTField1.TXTControlField);

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.printDekurse: " + ex.ToString());
            }
        }

        public void ReadInEditorDoLine(string txtRtf, string txtPlain,
                        ref string InfoRow, ref string sLine, TXTextControl.TextControl textControl1,
                        ref string LineRtf, ref string LinePlain)
        {
            try
            {

                //this.textControl1.Text = "";
                //this.doEditor1.showText(infoRow.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControl1, ref b, ref b);
                //string InfoRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControl1);
                //string InfoPlain = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControl1);

                if (txtRtf.Trim() == "")
                {
                    if (txtPlain.Trim() != "")
                    {
                        //this.doEditor1.appendText2(InfoPlain.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                        this.doEditor1.appendText2(txtPlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        //this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                        //this.doEditor1.appendText2(LinePlain.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                        //this.doEditor1.insertPagebreak(frmEditor.ContTxtEditor1.textControl1);
                    }
                }
                else
                {
                    //this.doEditor1.appendText2(InfoRtf.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    try
                    {
                        this.doEditor1.appendText2(txtRtf.Trim(), textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    }
                    catch (Exception ex)
                    {
                        if (txtPlain.Trim() != "")
                        {
                            this.doEditor1.appendText2(txtPlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        }
                        else
                        {
                            this.doEditor1.appendText2(txtRtf.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        }
                    }
                    //this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                    //this.doEditor1.appendText2(LineRtf.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.insertPagebreak(frmEditor.ContTxtEditor1.textControl1);
                }

                int Position2 = textControl1.InputPosition.TextPosition;
                this.doEditor1.appendText2(LinePlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                textControl1.Select(Position2, textControl1.Text.Length - Position2);
                textControl1.Selection.FontSize = 9 * 20;
                textControl1.Selection.FontName = "Arial";
                textControl1.Selection.ForeColor = System.Drawing.Color.Black;
                textControl1.Selection.Bold = false;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.doLineReadEditor: " + ex.ToString());
            }
        }

        public void loadCboPackungsanzahl(Infragistics.Win.UltraWinEditors.UltraComboEditor cbo, Infragistics.Win.ValueListItemsCollection valList)
        {
            try
            {
                if (cbo != null)
                {
                    cbo.Items.Clear();

                    Infragistics.Win.ValueListItem itm = cbo.Items.Add(0, "OP 0");
                    itm = cbo.Items.Add(1, "OP 1");
                    itm = cbo.Items.Add(2, "OP 2");
                    itm = cbo.Items.Add(3, "OP 3");
                    itm = cbo.Items.Add(4, "OP 4");
                    itm = cbo.Items.Add(5, "OP 5");
                    itm = cbo.Items.Add(6, "OP 6");
                }

                if (valList != null)
                {
                    valList.ValueList.ValueListItems.Clear();

                    Infragistics.Win.ValueListItem itm = valList.ValueList.ValueListItems.Add(0, "OP 0");
                    itm = valList.ValueList.ValueListItems.Add(1, "OP 1");
                    itm = valList.ValueList.ValueListItems.Add(2, "OP 2");
                    itm = valList.ValueList.ValueListItems.Add(3, "OP 3");
                    itm = valList.ValueList.ValueListItems.Add(4, "OP 4");
                    itm = valList.ValueList.ValueListItems.Add(5, "OP 5");
                    itm = valList.ValueList.ValueListItems.Add(6, "OP 6");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.loadCboPackungsanzahl: " + ex.ToString());
            }
        }

        public void initGridRowsRezeptEintragMedDaten2(UltraGrid grid, string colSelect, dsKlientenliste dsKlientenliste1, bool UIFromRezept, bool UIWunde)
        {
            try
            {
                foreach (UltraGridColumn col in grid.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }

                if (UIFromRezept && !UIWunde)
                {
                    if (colSelect.Trim() != "")
                    {
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl");
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Hidden = false;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Width = 100;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.VisiblePosition = 0;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.Appearance.TextHAlign = HAlign.Center;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].CellAppearance.TextHAlign = HAlign.Center;
                    }

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medizinischer Typ");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName].Width = 130;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName].Header.VisiblePosition = 2;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beschreibung");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Width = 250;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeschreibungColumn.ColumnName].Header.VisiblePosition = 3;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Width = 95;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Header.VisiblePosition = 4;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Center;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Width = 95;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Header.VisiblePosition = 5;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Center;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BemerkungColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BemerkungColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BemerkungColumn.ColumnName].Width = 250;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BemerkungColumn.ColumnName].Header.VisiblePosition = 6;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.TherapieColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.TherapieColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.TherapieColumn.ColumnName].Width = 200;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.TherapieColumn.ColumnName].Header.VisiblePosition = 7;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeendigungsgrundColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beendigungsgrund");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeendigungsgrundColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeendigungsgrundColumn.ColumnName].Width = 200;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BeendigungsgrundColumn.ColumnName].Header.VisiblePosition = 8;


                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                }
                else if (!UIFromRezept && !UIWunde)
                {
                    if (colSelect.Trim() != "")
                    {
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl");
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Hidden = false;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Width = 100;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.VisiblePosition = 0;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.Appearance.TextHAlign = HAlign.Center;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].CellAppearance.TextHAlign = HAlign.Center;
                    }

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.RezepteintragColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.RezepteintragColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.RezepteintragColumn.ColumnName].Width = 420;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.RezepteintragColumn.ColumnName].Header.VisiblePosition = 1;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Width = 110;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Header.VisiblePosition = 2;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Center;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.VonColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Width = 110;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Header.VisiblePosition = 3;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Center;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BisColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.DosierungColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Signatur");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.DosierungColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.DosierungColumn.ColumnName].Width = 400;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.DosierungColumn.ColumnName].Header.VisiblePosition = 4;


                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                }
                else if (!UIFromRezept && UIWunde)
                {
                    if (colSelect.Trim() != "")
                    {
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl");
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Hidden = false;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Width = 100;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.VisiblePosition = 0;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].Header.Appearance.TextHAlign = HAlign.Center;
                        grid.DisplayLayout.Bands[0].Columns[colSelect.Trim()].CellAppearance.TextHAlign = HAlign.Center;
                    }

                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Header.Caption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde");
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Hidden = false;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Width = 500;
                    grid.DisplayLayout.Bands[0].Columns[dsKlientenliste1.UI.BezeichnungColumn.ColumnName].Header.VisiblePosition = 1;

                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.initGridRowsRezeptEintragMedDaten: " + ex.ToString());
            }
        }





        public void getBestellpostitionenVO_IDs(ref DataTable dt, Guid IDBestellposition, ref Nullable<Guid> IDAufenthaltTmp,  ref Nullable<Guid> Typ, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select VO.IDAufenthalt, VO_Bestelldaten.Typ from VO_Bestellpostitionen, VO_Bestelldaten, VO where VO_Bestelldaten.ID=VO_Bestellpostitionen.IDBestelldaten_VO and VO_Bestelldaten.IDVerordnung=VO.ID and VO_Bestellpostitionen.ID='" + IDBestellposition.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                IDAufenthaltTmp = (Guid)dt.Rows[0][0];
                Typ = (Guid)dt.Rows[0][1];

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getBestellpostitionenVO_IDs"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBestellpostitionenVO_IDs: " + ex.ToString());
            }
        }
        public void getBestelldatenVO_IDs(ref DataTable dt, Guid IDBestelldaten, ref Nullable<Guid> IDAufenthaltTmp, ref Nullable<Guid> IDMedikamentTmp, ref Nullable<Guid> Typ, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select VO.IDAufenthalt, VO_Bestelldaten.IDMedikament, VO_Bestelldaten.Typ from VO_Bestelldaten, VO where VO_Bestelldaten.IDVerordnung=VO.ID and VO_Bestelldaten.ID='" + IDBestelldaten.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                IDAufenthaltTmp = (Guid)dt.Rows[0][0];
                IDMedikamentTmp = (Guid)dt.Rows[0][1];
                Typ = (Guid)dt.Rows[0][2];

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getBestelldatenVO_IDs"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getIDPatientForAufenthalt: " + ex.ToString());
            }
        }
        public Guid getIDPatientForAufenthalt(ref DataTable dt, Guid IDAufenthalt, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select Aufenthalt.IDPatient from Aufenthalt where Aufenthalt.ID='" + IDAufenthalt.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                Guid IDPatientTmp = (Guid)dt.Rows[0][0];
                return IDPatientTmp;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getIDPatientForAufenthalt"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getIDPatientForAufenthalt: " + ex.ToString());
            }
        }
        public string getPatientenData(ref DataTable dt, Guid IDPatient, ref OleDbDataAdapter da, ref OleDbCommand cmd, ref string KrankenKasse, ref string VersicherungsNr)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select (Nachname + ' ' + Vorname) as Name, KrankenKasse, VersicherungsNr from Patient where ID='" + IDPatient.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                string Name = (string)dt.Rows[0][0];
                KrankenKasse = (string)dt.Rows[0][1];
                VersicherungsNr = (string)dt.Rows[0][2];
                return Name.Trim();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getPatientName"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getPatientName: " + ex.ToString());
            }
        }
        public string getBenutzerData(ref DataTable dt, Guid IDUser, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select (Nachname + ' ' + Vorname) as Name from Benutzer where ID='" + IDUser.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                string Name = (string)dt.Rows[0][0];
                return Name.Trim();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getPatientName"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getBenutzerData: " + ex.ToString());
            }
        }
        public string getMedikamentName(ref DataTable dt, Guid IDMedikament, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select Bezeichnung from Medikament where ID='" + IDMedikament.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                string Medikament = (string)dt.Rows[0][0];
                return Medikament.Trim();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getMedikamentName"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getMedikamentName: " + ex.ToString());
            }
        }
        public string getVOInfoMedDaten(ref DataTable dt, Guid IDVO, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select MedizinischeDaten.Beschreibung, MedizinischeDaten.Von, MedizinischeDaten.Bis from VO, VO_MedizinischeDaten, MedizinischeDaten where VO.ID='" + IDVO.ToString() + "' and VO_MedizinischeDaten.IDVerordnung=VO.ID and MedizinischeDaten.ID=VO_MedizinischeDaten.IDMedizinischeDaten ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);

                string Info = "";
                if (dt.Rows.Count > 0)
                {
                    //Info += QS2.Desktop.ControlManagment.ControlManagment.getRes("Med.Daten") + ": ";
                    foreach (DataRow r in dt.Rows)
                    {
                        Info += ((String)dt.Rows[0][0]).ToString();
                        if (dt.Rows[0][1] != System.DBNull.Value)
                        {
                            Info += ", " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Von") + ": " + ((DateTime)dt.Rows[0][1]).ToString("dd.MM.yyyy");
                        }
                        if (dt.Rows[0][2] != System.DBNull.Value)
                        {
                            Info += ", " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis") + ": " + ((DateTime)dt.Rows[0][2]).ToString("dd.MM.yyyy");
                        }
                        Info += "\r\n";
                    }
                }
                
                return Info;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getIDPatientForAufenthalt"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getVOInfoMedDaten: " + ex.ToString());
            }
        }
        public string getVOInfoIDPflegeplanPDx(ref DataTable dt, Guid IDVO, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select distinct Eintrag.Text from VO, VO_PflegeplanPDX, PflegePlanPDx, Eintrag where VO.ID='" + IDVO.ToString() + "' and VO_PflegeplanPDX.IDVerordnung=VO.ID and PflegePlanPDx.IDUntertaegigeGruppe=VO_PflegeplanPDX.IDUntertaegigeGruppe and PflegePlanPDx.IDEintrag=Eintrag.ID ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);

                string Info = "";
                if (dt.Rows.Count > 0)
                {
                    //Info += QS2.Desktop.ControlManagment.ControlManagment.getRes("Massnahmen") + ": ";
                    foreach (DataRow r in dt.Rows)
                    {
                        Info += ((String)r[0]).ToString() + "\r\n";
                    }
                }
                
                return Info;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getIDPatientForAufenthalt"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getVOInfoIDPflegeplanPDx: " + ex.ToString());
            }
        }
        public string getVOInfoIDWundeKopf(ref DataTable dt, Guid IDVO, ref OleDbDataAdapter da, ref OleDbCommand cmd)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select distinct (PDX.Klartext + ' (' + AufenthaltPDx.Lokalisierung + ' ' + AufenthaltPDx.LokalisierungSeite + ')') as Text from VO, VO_Wunde, WundeKopf, AufenthaltPDx, PDX, Eintrag where VO.ID='" + IDVO.ToString() + "' and VO_Wunde.IDVerordnung=VO.ID and WundeKopf.ID=VO_Wunde.IDWundeKopf and WundeKopf.IDAufenthaltPDx=AufenthaltPDx.ID and AufenthaltPDx.IDPDX=PDX.ID ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);

                string Info = "";
                if (dt.Rows.Count > 0)
                {
                    //Info += QS2.Desktop.ControlManagment.ControlManagment.getRes("Massnahmen") + ": ";
                    foreach (DataRow r in dt.Rows)
                    {
                        Info += ((String)r[0]).ToString() + "\r\n";
                    }
                }

                return Info;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getIDPatientForAufenthalt"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.getVOInfoIDPflegeplanPDx: " + ex.ToString());
            }
        }

        public void get_BestelldatenFields(ref DataTable dt, Guid IDVO_Bestelldaten, ref OleDbDataAdapter da, ref OleDbCommand cmd, ref bool Dauerbestellung)
        {
            try
            {
                dt.Clear();
                dt.Columns.Clear();
                cmd.Parameters.Clear();
                cmd.CommandText = " Select VO_Bestelldaten.Dauerbestellung from VO_Bestelldaten where VO_Bestelldaten.ID='" + IDVO_Bestelldaten.ToString() + "' ";
                cmd.CommandTimeout = 0;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                da.SelectCommand = cmd;
                da.Fill(dt);
                Dauerbestellung = (bool)dt.Rows[0][0];

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "getIDPatientForAufenthalt"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.get_BestelldatenFields: " + ex.ToString());
            }
        }

        public string getInfoVO(Guid IDMedDaten, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string sInfo = "";
                var tVO = (from v in db.VO
                            join vm in db.VO_MedizinischeDaten on v.ID equals vm.IDVerordnung
                            join m in db.Medikament on v.IDMedikament equals m.ID
                            where vm.IDMedizinischeDaten == IDMedDaten
                            select new
                            {
                                ID = v.ID,
                                IDMedikament = v.IDMedikament,
                                Medikament = m.Bezeichnung,
                                DatumVerordnetAb = v.DatumVerordnetAb,
                                DatumVerordnetBis = v.DatumVerordnetBis,
                                Einheit = v.Einheit,
                            });

                foreach (var r in tVO)
                {
                    sInfo += "Verordnung:" + r.Medikament.Trim() + " Verordnet ab:" + r.DatumVerordnetAb.ToString("dd.MM.yyyy") + "" + "\r\n";
                }

                return sInfo;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDSBusiness.getDbEntityValidationException2(ex, "checkBestellvorschlag"), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.getInfoVO: " + ex.ToString());
            }
        }


        public static bool checkTxtRegex(string txt, bool WithMsgBox)
        {
            try
            {
                if (PMDS.Global.ENV.DekursRegex.Trim() != "")
                {
                    string RegexPattern = PMDS.Global.ENV.DekursRegex.Trim();
                    string txtDekurs = txt;
                    Regex regex = new Regex(@RegexPattern.Trim());
                    Match match = regex.Match(txtDekurs.Trim());
                    if (!match.Success)
                    {
                        if (WithMsgBox)
                        {
                            string sMsgBoxTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Eingabekriterien wurden für den Dekurstext nicht erfüllt:");
                            string sMsgBoxTxtCriterias = PMDS.Global.ENV.DekursRegexBeschreibung.Trim();
                            if (sMsgBoxTxtCriterias.Trim() == "")
                            {
                                sMsgBoxTxtCriterias = PMDS.Global.ENV.DekursRegex.Trim();
                            }
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTxt + "\r\n" + "\r\n" + sMsgBoxTxtCriterias, "", MessageBoxButtons.OK);
                        }
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.checkTxtRegex: " + ex.ToString());
            }
        }

        public static void writeLog(string txt, string prefixFile, bool isException)
        {
            try
            {
                if (!System.IO.Directory.Exists(ENV.LOGPATH))
                {
                    System.IO.Directory.CreateDirectory(ENV.LOGPATH);
                }

                string logFile = ENV.LOGPATH + "\\" + System.Environment.MachineName + "_" + prefixFile + ".log";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
                {
                    if (isException)
                    {
                        file.WriteLine(DateTime.Now.ToString() + " - " + "Exception: " + txt + "\r\n" + "\r\n");
                    }
                    else
                    {
                        file.WriteLine(DateTime.Now.ToString() + " - " + "Info: " + txt + "\r\n" + "\r\n");
                    }
                }

                //System.GC.Collect();

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.writeLog: " + ex.ToString());
            }
        }

        public bool showInfoRezeptgebührbefreiungByAufenthalt(Guid IDAufenthalt, ref string TitleBack, ref string TxtBack, bool newLineWithBR)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Patient rPatient = b.getPatientByIDAufenthalt(IDAufenthalt, db);
                    return showInfoRezeptgebührbefreiungByPat(ref rPatient, ref TitleBack, ref TxtBack, newLineWithBR);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.showInfoRezeptgebührbefreiung: " + ex.ToString());
            }
        }


        public bool showInfoRezeptgebührbefreiungByPat(ref PMDS.db.Entities.Patient rPatient, ref string TitleBack, ref string TxtBack, bool newLineWithBR)
        {
            try
            {

                string sZU = "";
                if (newLineWithBR)
                {
                    sZU = "<br/>";
                }
                else
                {
                    sZU = "\r\n";
                }

                string sInfoTxt = "";

                if (rPatient.RezeptgebuehrbefreiungJN)
                {
                    sInfoTxt += QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient ist rezeptgebührenbefreit");

                    if (rPatient.RezGebBef_RegoJN)
                    {
                        sInfoTxt += sZU + QS2.Desktop.ControlManagment.ControlManagment.getRes("Rego");
                        if (rPatient.RezGebBef_RegoAb != null)
                        {
                            sInfoTxt += " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("ab") + " " + rPatient.RezGebBef_RegoAb.Value.ToString("dd.MM.yyyy");
                        }
                        if (rPatient.RezGebBef_RegoBis != null)
                        {
                            sInfoTxt += " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("bis") + " " + rPatient.RezGebBef_RegoBis.Value.ToString("dd.MM.yyyy");
                        }
                    }

                    if (rPatient.RezGebBef_UnbefristetJN)
                    {
                        sInfoTxt += sZU + QS2.Desktop.ControlManagment.ControlManagment.getRes("Unbefristet");
                    }

                    if (rPatient.RezGebBef_BefristetJN)
                    {
                        sInfoTxt += sZU + QS2.Desktop.ControlManagment.ControlManagment.getRes("Befristet");
                        if (rPatient.RezGebBef_BefristetAb != null)
                        {
                            sInfoTxt += " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("von") + " " + rPatient.RezGebBef_BefristetAb.Value.ToString("dd.MM.yyyy");
                        }
                        if (rPatient.RezGebBef_BefristetBis != null)
                        {
                            sInfoTxt += " " + QS2.Desktop.ControlManagment.ControlManagment.getRes("bis") + " " + rPatient.RezGebBef_BefristetBis.Value.ToString("dd.MM.yyyy");
                        }
                    }

                    if (rPatient.RezGebBef_WiderrufJN && rPatient.RezGebBef_WiderrufGrund.Trim() != "")
                    {
                        sInfoTxt += sZU + QS2.Desktop.ControlManagment.ControlManagment.getRes("Wegen") + ": " + rPatient.RezGebBef_WiderrufGrund.Trim();
                    }

                    if (rPatient.RezGebBef_SachwalterJN)
                    {
                        sInfoTxt += sZU + QS2.Desktop.ControlManagment.ControlManagment.getRes("Sachwalter");
                    }
                }

                if (rPatient.RezGebBef_Anmerkung.Trim() != "")
                {
                    sInfoTxt += (sInfoTxt == "" ? "" : sZU) + rPatient.RezGebBef_Anmerkung.Trim().Replace("\r\n", sZU);
                }

                if (sInfoTxt == "")
                {
                    return false;
                }
                else
                {
                    TitleBack = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rezeptgebührenbefreiung");
                    TxtBack = sInfoTxt;
                    return true;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.showInfoRezeptgebührbefreiungByPat: " + ex.ToString());
            }
        }



        public string selectFilePicture()
        {
            try
            {
                System.Windows.Forms.OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.Filter = this.getSelectFilterPictures();
                DialogResult res = OpenFileDialog1.ShowDialog();
                if (res != DialogResult.OK)
                {
                    return "";
                }
                
                string sFile = OpenFileDialog1.FileName;
                if (!File.Exists(sFile))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + sFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert nicht"), true);
                    return "";
                }

                return sFile;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.selectFilePicture: " + ex.ToString());
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.imageToByteArray: " + ex.ToString());
            }
        }

        public string getSelectFilterPictures()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("JPEG (*.jpg*)|*.jpg*");
            sb.Append("|PNG (*.png)|*.png");
            sb.Append("|BMP (*.bmp)|*.bmp");
            sb.Append("|ICO (*.ico)|*.ico");

            return sb.ToString();
        }


        public void searchConfigDirForConfigs(bool FirstLoad, string ConfigPath, Infragistics.Win.UltraWinEditors.UltraComboEditor cboConfigFiles, string ConfigFileDefault, 
                                                ref bool runWithDefaultConfigFile, ref string lastSelectedFile, ref int iCounterConfigsFound, ref Infragistics.Win.ValueListItem itmSel)
        {
            try
            {
                if (!System.IO.Directory.Exists(ConfigPath.Trim()))
                {
                    throw new Exception("PMDSBusinessUI.searchConfigDirForConfigs: this._ConfigPath '" + ConfigPath.Trim() + "' not exists!");
                }

                string[] FilesFoundInDirectory = System.IO.Directory.GetFiles(ConfigPath, "*.config", System.IO.SearchOption.TopDirectoryOnly);
                foreach (string fil in FilesFoundInDirectory)
                {
                    string onlyFileName = System.IO.Path.GetFileName(fil.Trim());
                    string OrigDirName = System.IO.Path.GetDirectoryName(fil.Trim());
                    string sExtension = System.IO.Path.GetExtension(fil.Trim());

                    if (sExtension.Trim().ToLower().Equals((".config").Trim().ToLower()) && onlyFileName.Trim().ToLower().Contains(("PMDS").Trim().ToLower()) &&
                        !onlyFileName.Trim().ToLower().Contains(("qs2").Trim().ToLower()) && !onlyFileName.Trim().ToLower().Contains(("Abrechnung").Trim().ToLower()) &&
                        !onlyFileName.Trim().ToLower().Equals(("PMDS.Main.exe.config").Trim().ToLower()) && !onlyFileName.Trim().ToLower().Equals(("QS2.exe.config").Trim().ToLower()))
                    {
                        if (cboConfigFiles != null)
                        {
                            Infragistics.Win.ValueListItem itm = cboConfigFiles.Items.Add(onlyFileName.Trim(), onlyFileName.Trim());
                            cItmTg ctmTg = new cItmTg();
                            ctmTg.fileNameOnly = onlyFileName.Trim();
                            ctmTg.Dir = OrigDirName.Trim();
                            ctmTg.fileNameFull = fil.Trim();
                            itm.Tag = ctmTg;
                            if (ConfigFileDefault.Trim() != "" && ConfigFileDefault.Trim().ToLower().Equals(ctmTg.fileNameOnly.Trim().ToLower()))
                            {
                                itm.Appearance.ForeColor = System.Drawing.Color.White;
                                itm.Appearance.BackColor = System.Drawing.Color.DarkGreen;
                            }

                            if (itmSel == null)
                            {
                                itmSel = itm;
                            }
                            if (lastSelectedFile.Trim() != "" && lastSelectedFile.Trim().ToLower().Equals(ctmTg.fileNameOnly.Trim().ToLower()))
                            {
                                itmSel = itm;
                            }
                            if (lastSelectedFile.Trim() == "" && ConfigFileDefault.Trim() != "" && ConfigFileDefault.Trim().ToLower().Equals(ctmTg.fileNameOnly.Trim().ToLower()))
                            {
                                itmSel = itm;
                            }
                        }

                        iCounterConfigsFound += 1;
                    }
                }

                if (FirstLoad && iCounterConfigsFound == 1)
                {
                    runWithDefaultConfigFile = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.searchConfigDirForConfigs:" + ex.ToString());
            }
        }


        public Bitmap ResizePicByWidth(Image sourceImage, double newWidthHeight, bool doWidth)
        {
            try
            {
                if (doWidth)
                {
                    double sizeFactor = newWidthHeight / sourceImage.Width;
                    double newHeigth = sizeFactor * sourceImage.Height;
                    Bitmap newImage = new Bitmap((int)newWidthHeight, (int)newHeigth);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(sourceImage, new Rectangle(0, 0, (int)newWidthHeight, (int)newHeigth));
                    }
                    return newImage;
                }
                else
                {
                    double sizeFactor = newWidthHeight / sourceImage.Height;
                    double newWidth = sizeFactor * sourceImage.Width;
                    Bitmap newImage = new Bitmap((int)newWidth, (int)newWidthHeight);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(sourceImage, new Rectangle(0, 0, (int)newWidth, (int)newWidthHeight));
                    }
                    return newImage;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessUI.ResizePicByWidth: " + ex.ToString());
            }
        }



        public bool WundBilderScale(PMDS.db.Entities.ERModellPMDSEntities db, ref Infragistics.Win.UltraWinProgressBar.UltraProgressBar progBar, int WidthHeightPicture,
                                        ref string sProt, ref int iErrorNr)
        {
            try
            {
                dsManage dsManageUpdate = new dsManage();
                sqlManange sqlManangeUpdate = new sqlManange();
                sqlManangeUpdate.initControl();

                progBar.Value = 0;
                db.Configuration.LazyLoadingEnabled = false;
                var tWundePosBilder = (from v in db.WundePosBilder
                                       orderby v.DatumErstellt
                                       select new
                                       {
                                           ID = v.ID
                                       }).ToList();
                progBar.Maximum = tWundePosBilder.Count();
                int iCounter = 0;
                Image img = null;
                MemoryStream ms = new MemoryStream();
                MemoryStream msOut = new MemoryStream();

                foreach (var rWundePosBild in tWundePosBilder)
                {
                    try
                    {
                        dsManageUpdate.Clear();
                        sqlManangeUpdate.getWundeBilder(dsManageUpdate, rWundePosBild.ID, sqlManange.eTypeWundBilder.ID);
                        dsManage.WundePosBilderRow rWundePosBilderUpdate = (dsManage.WundePosBilderRow)dsManageUpdate.WundePosBilder.Rows[0];

                        if (!rWundePosBilderUpdate.IsBildNull())
                        {

                            //using (var ms = new MemoryStream(rWundePosBilderUpdate.Bild))
                            //{
                            ms.SetLength(0);
                            ms.Write (rWundePosBilderUpdate.Bild, 0, rWundePosBilderUpdate.Bild.Length -1);
                            img = Image.FromStream(ms);
                            //}
                        
                            //Image imgOrigLoaded = img;
                            double dWidth = System.Convert.ToDouble(WidthHeightPicture);
                            bool bScale = true;

                            Bitmap bmpScaled = null;

                            if (img.Height > img.Width) //Hochformat
                            {
                                if (img.Height <= dWidth)
                                {
                                    bScale = false;
                                }
                                else
                                {
                                    bmpScaled = this.ResizePicByWidth(img, dWidth, false);
                                }
                            }
                            else     //Querformat
                            {
                                if (img.Width <= dWidth)
                                {
                                    bScale = false;
                                }
                                else
                                {
                                    bmpScaled = this.ResizePicByWidth(img, dWidth, true);
                                }
                            }

                            if (bScale)
                            {
                                msOut.SetLength(0);
                                bmpScaled.Save(msOut, System.Drawing.Imaging.ImageFormat.Jpeg);
                                rWundePosBilderUpdate.BildOrig = rWundePosBilderUpdate.Bild;
                                rWundePosBilderUpdate.Bild = msOut.ToArray();
                                sqlManangeUpdate.daWundePosBilder.Update(dsManageUpdate.WundePosBilder);
                            }

                            iCounter += 1;
                            if (iCounter > 10)
                            {
                                iCounter = 0;
                                System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                                //System.GC.Collect(2, GCCollectionMode.Forced);
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                GC.WaitForFullGCComplete();
                                GC.Collect();
                            }
                        }
                        progBar.Value += 1;
                        Application.DoEvents();

                    }
                    catch (Exception ex)
                    {
                        iErrorNr += 1;
                        string sExcept = iErrorNr.ToString() + ". Exception: rWundePosBild.ID=" + rWundePosBild.ID.ToString() + "\r\n" + ex.ToString() + "\r\n" + "\r\n";
                        sProt += sExcept;
                    }
                }

                ms.Dispose();
                msOut.Dispose();
                img.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.WundbilderScale: " + ex.ToString());
            }
        }
        public bool WundBilderResetToOrig(PMDS.db.Entities.ERModellPMDSEntities db, ref Infragistics.Win.UltraWinProgressBar.UltraProgressBar progBar)
        {
            try
            {
                dsManage dsManageUpdate = new dsManage();
                sqlManange sqlManangeUpdate = new sqlManange();
                sqlManangeUpdate.initControl();

                progBar.Value = 0;
                db.Configuration.LazyLoadingEnabled = false;
                var tWundePosBilder = (from v in db.WundePosBilder
                                       orderby v.DatumErstellt
                                       select new
                                       {
                                           ID = v.ID
                                       }).ToList();
                progBar.Maximum = tWundePosBilder.Count();
                int iCounter = 0;
                foreach (var rWundePosBild in tWundePosBilder)
                {
                    dsManageUpdate.Clear();
                    sqlManangeUpdate.getWundeBilder(dsManageUpdate, rWundePosBild.ID, sqlManange.eTypeWundBilder.ID);
                    dsManage.WundePosBilderRow rWundePosBilderUpdate = (dsManage.WundePosBilderRow)dsManageUpdate.WundePosBilder.Rows[0];

                    if (!rWundePosBilderUpdate.IsBildOrigNull())
                    {
                        rWundePosBilderUpdate.Bild = rWundePosBilderUpdate.BildOrig;
                        sqlManangeUpdate.daWundePosBilder.Update(dsManageUpdate.WundePosBilder);
                        progBar.Value += 1;
                        Application.DoEvents();
                    }

                    iCounter += 1;
                    if (iCounter > 100)
                    {
                        iCounter = 0;
                        System.GC.Collect();
                    }
                }
              
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.WundBilderResetToOrig: " + ex.ToString());
            }
        }
        public bool SaveWundPictures(PMDS.db.Entities.ERModellPMDSEntities db, ref Infragistics.Win.UltraWinProgressBar.UltraProgressBar progBar)
        {
            try
            {
                dsManage dsManageUpdate = new dsManage();
                sqlManange sqlManangeUpdate = new sqlManange();
                sqlManangeUpdate.initControl();

                progBar.Value = 0;
                db.Configuration.LazyLoadingEnabled = false;
                var tWundePosBilder = (from v in db.WundePosBilder
                                       orderby v.DatumErstellt
                                       select new
                                       {
                                           ID = v.ID
                                       }).ToList();
                progBar.Maximum = tWundePosBilder.Count();
                int iCounter = 0;
                foreach (var rWundePosBild in tWundePosBilder)
                {
                    dsManageUpdate.Clear();
                    sqlManangeUpdate.getWundeBilder(dsManageUpdate, rWundePosBild.ID, sqlManange.eTypeWundBilder.ID);
                    dsManage.WundePosBilderRow rWundePosBilderUpdate = (dsManage.WundePosBilderRow)dsManageUpdate.WundePosBilder.Rows[0];

                    if (!rWundePosBilderUpdate.IsBildNull())
                    {
                        rWundePosBilderUpdate.BildOrig = rWundePosBilderUpdate.Bild;
                    }
                    else
                    {
                        rWundePosBilderUpdate.SetBildOrigNull();
                    }
                
                    sqlManangeUpdate.daWundePosBilder.Update(dsManageUpdate.WundePosBilder);
                    progBar.Value += 1;
                    Application.DoEvents();

                    iCounter += 1;
                    if (iCounter > 100)
                    {
                        iCounter = 0;
                        System.GC.Collect();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.SaveWundPictures: " + ex.ToString());
            }
        }
        public bool WundBilderDeleteOrigPictures(PMDS.db.Entities.ERModellPMDSEntities db, ref Infragistics.Win.UltraWinProgressBar.UltraProgressBar progBar)
        {
            try
            {
                dsManage dsManageUpdate = new dsManage();
                sqlManange sqlManangeUpdate = new sqlManange();
                sqlManangeUpdate.initControl();

                progBar.Value = 0;
                db.Configuration.LazyLoadingEnabled = false;
                var tWundePosBilder = (from v in db.WundePosBilder
                                   orderby v.DatumErstellt 
                                   select new
                                   {
                                       ID = v.ID
                                   }).ToList();
                progBar.Maximum = tWundePosBilder.Count();
                int iCounter = 0;
                foreach (var rWundePosBild in tWundePosBilder)
                {
                    dsManageUpdate.Clear();
                    sqlManangeUpdate.getWundeBilder(dsManageUpdate, rWundePosBild.ID, sqlManange.eTypeWundBilder.ID);
                    dsManage.WundePosBilderRow rWundePosBilderUpdate = (dsManage.WundePosBilderRow)dsManageUpdate.WundePosBilder.Rows[0];

                    rWundePosBilderUpdate.SetBildOrigNull();
                    sqlManangeUpdate.daWundePosBilder.Update(dsManageUpdate.WundePosBilder);
                    progBar.Value += 1;
                    Application.DoEvents();

                    iCounter += 1;
                    if (iCounter > 100)
                    {
                        iCounter = 0;
                        System.GC.Collect();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.WundBilderDeleteOrigPictures: " + ex.ToString());
            }
        }


        public static bool checkClientsS2()
        {
            if (Environment.MachineName.Trim().ToLower().Equals(("styhl2").Trim().ToLower()) || Environment.MachineName.Trim().ToLower().Equals(("sty041").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}

