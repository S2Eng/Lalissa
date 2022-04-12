//12.04.2007 MDA
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;
using S2Extensions;

namespace PMDS.GUI
{

    public partial class frmEditPDx1 : QS2.Desktop.ControlManagment.baseForm 
    {
        private bool _saveKlicked;
        private bool _bCanclose;
        private bool _bModeNew;		// Flag ob neue oder alte PDx 
        private PDXDef _PDXDef;
        private bool _bCancel;		// signalisiert das Cancel ausgeführt wurde
        private PMDS.BusinessLogic.Pflegemodelle _PflegeModelle;
        private ValueList modellValueList;
        private string _modellErrorText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Eine Pflegedefinition darf pro Modell nur einmal vorkommen. Bitte ändern.");
        private bool _valueChangeEnabled = true;
        
        public frmEditPDx1(bool bNewPDx, ref PDXDef def)
        {
            _valueChangeEnabled = false;
            _bModeNew = bNewPDx;
            _PDXDef = def;
            _PflegeModelle = new PMDS.BusinessLogic.Pflegemodelle();
            _PflegeModelle.Read();

            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            Load += new EventHandler(frmEditPDx1_Load);
            Closing += new System.ComponentModel.CancelEventHandler(this.frmEditPDx1_Closing);

            InitGruppeCombo();

            cbGruppe.SelectedIndex = 0;     // default Pflegediagnose
            
            if (bNewPDx == false)
            {
                tbText.Text = def.Klartext;
                tbDefinition.Text = def.Definition;
                cmbCode.Text = def.Code;
                cmbCode.Text = def.Code;
                chkEntferntJN.Checked = def.EntferntJN;
                cbGruppe.SelectedIndex = (int)def.PDXGruppe;
                osLokalisierung.CheckedIndex = (int)def.PDXLokalisierungsTyp;
                cbWundeJN.Checked = def.WundeJN;
                cmbPDXKuerzel.Text = def.PDXKuerzel; 
            }

            _valueChangeEnabled = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// OK - prüfen der Randbedingungen
        /// </summary> 
        //----------------------------------------------------------------------------
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            _saveKlicked = true;
            _bCanclose = true;

            if (tbText.Text.Length == 0)
            {
                errorProvider1.SetError(tbText, ENV.String("ERROR_BEZEICHNUNG"));
                _bCanclose = false;
            }
            else
                errorProvider1.SetError(tbText, "");

            if (tbDefinition.Text.Length == 0)
            {
                errorProvider1.SetError(tbDefinition, ENV.String("ERROR_PDXDEF"));
                _bCanclose = false;
            }
            else
                errorProvider1.SetError(tbDefinition, "");

            if (cmbCode.Text.Length == 0)
            {
                errorProvider1.SetError(cmbCode, ENV.String("ERROR_PDXCODE"));
                _bCanclose = false;
            }
            else
                errorProvider1.SetError(cmbCode, "");


            if (CheckPDxCode() == true)
                _bCanclose = false;

            if (_bCanclose == false)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), ENV.String("DIALOGTITLE_INPUTERROR"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
            else if(CheckPflgemodelle() == true)
                _bCanclose = false;


        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Cancel
        /// </summary> 
        //----------------------------------------------------------------------------
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _saveKlicked = false;
            _bCanclose = true;
            _bCancel = true;
            this.Close();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüft ob der PDx Code (Neuanlage bereits in der DB vorhanden ist
        /// und setzt den Errorprovider
        /// liefert true wenn ODx schon in DB vorhanden ist
        /// </summary> 
        //----------------------------------------------------------------------------
        private bool CheckPDxCode()
        {
            if (cbGruppe.Text.sEquals("KeineDiagnose") && ( cmbCode.Text.sEquals("$15GuKG") || cmbCode.Text.sEquals("KeineDiagnose")))   //$15GuKG und KeineDiagnose müssen nicht eindeutig sein.
                return false;

            if (!_bModeNew)			// nur bei Neuanlage prüfen
                return false;

            bool bRet = PMDS.DB.DBUtil.PDXCodeExists(cmbCode.Text);
            if (bRet)
            {
                errorProvider1.SetError(cmbCode, ENV.String("ERROR_PDX_CODE_EXISTS"));
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_PDX_CODE_EXISTS"), true);
            }
            return bRet;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüft ob alle Zelle im Grid ausgefüllt sind
        /// liefert true wenn ODx schon in DB vorhanden ist
        /// </summary> 
        //----------------------------------------------------------------------------
        private bool CheckPflgemodelle()
        {
            bool bRet = false;

            //Prüfen ob PDX zu ein andere Modell bereits zugeordnet ist
            string modell;
            for (int i = 0; i < gridPflegemodelle.Rows.Count; i++)
            {
                modell = gridPflegemodelle.Rows[i].Cells["Modell"].Text;

                for (int j = i + 1; j < gridPflegemodelle.Rows.Count; j++)
                {
                    if (gridPflegemodelle.Rows[i].Cells["Modell"].Text == gridPflegemodelle.Rows[j].Cells["Modell"].Text)
                    {
                        DataRow row = ((DataTable)gridPflegemodelle.DataSource).Rows[j];
                        row.SetColumnError(((DataTable)gridPflegemodelle.DataSource).Columns["Modell"], _modellErrorText);
                        bRet = true;

                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(_modellErrorText, true);
                        break;
                    }
                }

                if (bRet) break;
            }

            if (!bRet)
            {
                //Prüfen ob Alle Zellen ausgefüllt sind
                for (int i = 0; i < gridPflegemodelle.Rows.Count; i++)
                {
                    if (gridPflegemodelle.Rows[i].Cells["Modell"].Text == "" ||
                        gridPflegemodelle.Rows[i].Cells["Gruppe"].Text == ""
                      )
                    {
                        bRet = true;
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte Modell oder Gruppe ausfüllen.");
                        break;
                    }
                }
            }

            return bRet;
        }

        private List<PDXPflegemodellDef> GetPflgemodelle()
        {
            List<PDXPflegemodellDef> list = new List<PDXPflegemodellDef>();
            PDXPflegemodellDef pdxPflDef;

            for (int i = 0; i < gridPflegemodelle.Rows.Count; i++)
            {
                foreach (dsPflegemodelle.PflegemodelleRow r in _PflegeModelle.PflegemodelleDataTable)
                {
                    if (r.Modell == gridPflegemodelle.Rows[i].Cells["Modell"].Text &&
                        r.ModellgruppeKlartext == gridPflegemodelle.Rows[i].Cells["Gruppe"].Text 
                       )
                    {
                        pdxPflDef = new PDXPflegemodellDef();
                        pdxPflDef.ID = Guid.NewGuid();
                        pdxPflDef.IDPDX = _PDXDef.ID;
                        pdxPflDef.IDPflegemodelle = r.ID;

                        //Prüfen ob Bereits existiert in _PDXDef.PDXPflegemodelle
                        foreach (PDXPflegemodellDef def in _PDXDef.PDXPflegemodelle)
                        {
                            if (def.IDPDX == pdxPflDef.IDPDX && def.IDPflegemodelle == pdxPflDef.IDPflegemodelle)
                            {
                                pdxPflDef.ID = def.ID;
                                break;
                            }
                        }

                        list.Add(pdxPflDef);
                        break;
                    }
                }
            }

            return list;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Verhindern das ungerechtfertigt geschlossen wird
        /// </summary> 
        //----------------------------------------------------------------------------
        private void frmEditPDx1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = _saveKlicked && !_bCanclose;
            _saveKlicked = false;

            if (_bCanclose && !_bCancel)
            {
                _PDXDef.Code = cmbCode.Text;
                _PDXDef.EntferntJN = chkEntferntJN.Checked;
                _PDXDef.Definition = tbDefinition.Text;
                _PDXDef.Klartext = tbText.Text;
                _PDXDef.PDXGruppe = (ePDXGruppe)cbGruppe.SelectedIndex;
                _PDXDef.PDXLokalisierungsTyp = (PDxLokalisierungsTypen)osLokalisierung.CheckedIndex;

                _PDXDef.PDXPflegemodelle = GetPflgemodelle();

                //Neu nach 15.09.2008 MDa
                _PDXDef.WundeJN = cbWundeJN.Checked;
                _PDXDef.PDXKuerzel = cmbPDXKuerzel.Text; //Gernot%%
            }
        }

        private void frmEditPDx1_Load(object sender, EventArgs e)
        {
            InitializeGridPflegemodelle();
        }

        private void InitializeGridPflegemodelle()
        {
            //TO DO: DataSet des Grids setsen
            DataTable dt = new DataTable();

            dt.Columns.Add("Modell", typeof(string));
            dt.Columns.Add("Gruppe", typeof(string));

            foreach (PDXPflegemodellDef pdxPflDef in _PDXDef.PDXPflegemodelle)
            {
                foreach (dsPflegemodelle.PflegemodelleRow r in _PflegeModelle.PflegemodelleDataTable)
                {
                    if (r.ID == pdxPflDef.IDPflegemodelle)
                    {
                        dt.Rows.Add(new object[] { r.Modell, r.ModellgruppeKlartext });
                        break;
                    }
                }
            }

            gridPflegemodelle.DataSource = dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Gruppenzugehörigkeitscombo intialisieren
        /// </summary> 
        //----------------------------------------------------------------------------
        private void InitGruppeCombo()
        {
            foreach (string s in Enum.GetNames(typeof(ePDXGruppe)))
            {
                cbGruppe.Items.Add(s, s);
            }
        }

        private void AddModell(string modell, string[] modellgruppen)
        {
            ValueListItem modellValueListItem = modellValueList.ValueListItems.Add(modell, modell);

            ValueList modellgruppenValueList = new ValueList();
            modellValueListItem.Tag = modellgruppenValueList;

            // Add the cities to the city value list.
            for (int i = 0; i < modellgruppen.Length; i++)
                modellgruppenValueList.ValueListItems.Add(modellgruppen[i], modellgruppen[i]);
        }

        private ValueList GetModellValueList()
        {
            if (modellValueList != null)
                return modellValueList;

            modellValueList = new ValueList();
            List<string> modellgruppen ;

            foreach (dsPflegemodelle.PflegemodelleRow r in _PflegeModelle.GetAllModelle())
            {
                modellgruppen = new List<string>();
                foreach (dsPflegemodelle.PflegemodelleRow row in _PflegeModelle.GetAllModellegruppenToModel(r.Modell))
                {
                    modellgruppen.Add(row.ModellgruppeKlartext);
                }

                AddModell(r.Modell, modellgruppen.ToArray());
            }

            return modellValueList;
        }

        private ValueList GetGruppeValueListForModell(string modell)
        {
            int index = modellValueList.FindStringExact(modell);

            if (index >= 0)
                return (ValueList)modellValueList.ValueListItems[index].Tag;

            return null;
        }

        private void gridPflegemodelle_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            //Prüfen ob PDX zu ein andere Modell bereits zugeordnet ist
            if (e.Cell.Column.Key == "Modell")
            {
                bool error = false;
                DataRow row = ((DataTable)gridPflegemodelle.DataSource).Rows[e.Cell.Row.Index];

                for (int i = 0; i < gridPflegemodelle.Rows.Count; i++)
                {
                    if (!gridPflegemodelle.Rows[i].Cells["Modell"].Equals(e.Cell) &&
                        gridPflegemodelle.Rows[i].Cells["Modell"].Text == e.Cell.Text
                      )
                    {
                        error = true;
                        row.SetColumnError(((DataTable)gridPflegemodelle.DataSource).Columns["Modell"], _modellErrorText);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(_modellErrorText, true);
                        break;
                    }
                }

                if (!error)
                {
                    row.SetColumnError(((DataTable)gridPflegemodelle.DataSource).Columns["Modell"], "");
                    e.Cell.Row.Cells["Gruppe"].Value = "";
                }
            }
        }

        private void gridPflegemodelle_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // Set the Modell column's ValueList to the Modells value list.
            e.Layout.Bands[0].Columns["Modell"].ValueList = GetModellValueList();

            // Set the Style to DropDownList.
            e.Layout.Bands[0].Columns["Modell"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            e.Layout.Bands[0].Columns["Gruppe"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

        private void gridPflegemodelle_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            // Get the modell.
            string modell = e.Row.Cells["Modell"].Value.ToString();

            e.Row.Cells["Gruppe"].ValueList = GetGruppeValueListForModell(modell);
        }

        private void btnAddAntiko_Click(object sender, EventArgs e)
        {
            ((DataTable)gridPflegemodelle.DataSource).Rows.Add(new object[] { "", "" });
        }

        private void btnDelAntiko_Click(object sender, EventArgs e)
        {
            DataRow row = (DataRow)UltraGridTools.CurrentSelectedRow(gridPflegemodelle);
            row.Delete();
        }

        private void cbWundeJN_CheckedChanged(object sender, EventArgs e)
        {
            osLokalisierung.Enabled = !cbWundeJN.Checked;
            if (!_valueChangeEnabled) return;

            if (cbWundeJN.Checked)
                osLokalisierung.CheckedIndex = (int)PDxLokalisierungsTypen.Muss;
        }

        private void cmbCode_ValueChanged(object sender, EventArgs e)
        {
            if (cmbCode.Text.sEquals("KeineDiagnose"))
            {
                cmbPDXKuerzel.Text = "Keine Diag";
            }
            else
            {
                cmbPDXKuerzel.Text = "";
            }
        }

        private void cbGruppe_ValueChanged(object sender, EventArgs e)
        {
            if (cbGruppe.Text.sEquals("KeineDiagnose") && !cmbCode.Text.sEquals("§15GuKG") && !cmbCode.Text.sEquals("KeineDiagnose"))
            {
                cmbCode.Text = null;
            }
        }

        private void chkEntferntJN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEntferntJN.Checked)
            {
                chkEntferntJN.Appearance.ForeColor = Color.Red;
                chkEntferntJN.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            else
            {
                chkEntferntJN.Appearance.ForeColor = Color.Black;
                chkEntferntJN.Appearance.FontData.Bold = DefaultableBoolean.False;
            }
        }
    }
}