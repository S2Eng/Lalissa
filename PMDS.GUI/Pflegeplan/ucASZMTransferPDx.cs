using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucASZMTransferPDx : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
    {
        private bool _valueChangeEnabled = true;
        private PDxSelectionArgs _pdxArg;
        private dsPDx.PDXRow _pdxRow;
        public event EventHandler PDxValueChanged;
        public event EventHandler PDxZusaetzlicheLokalisierung;
        //Neu nach 08.05.2008 MDA
        private bool _ShowLinkLabel = true;
        //Neu nach 19.09.2008 MDA
        private PflegePlanModus _PflegePlanModus = PflegePlanModus.Normal;

        public ucASZMTransferPDx()
        {
            InitializeComponent();
        }

        //Neu nach 19.09.2008 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return _PflegePlanModus; }
            set { _PflegePlanModus = value; }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs PDX_SARG
        {
            get { return _pdxArg; }
            set
            {
                _pdxArg = value;
                if (_pdxArg != null)
                {
                    _valueChangeEnabled = false;
                    PDx pdx = new PDx();
                    _pdxRow = pdx.ReadOne(_pdxArg.IDPDX);
                    UpdateGUI();
                    ShowHideFields();
                    SetReadOnly();
                    _valueChangeEnabled = true;
                }
            }
        }

        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Link "eine zusätzliche Lokalisierung ermöglichen" anzeigen oder verstecken
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AddlokalisierungEnabled
        {
            get { return _ShowLinkLabel; }
            set
            {
                _ShowLinkLabel = value;
                lblZusätzlicheLokalisierung.Visible = value;
            }
        }

        //Neu nach 01.07.2008 MDA
        /// <summary>
        /// Wenn die PDX erledigt ist, dann darf sie nicht mehr änderbar seien
        /// </summary>
        private void SetReadOnly()
        {
            if(_pdxArg == null) return;
            dtpStart.ReadOnly = _pdxArg.IDAufenthaltPDX != Guid.Empty || _pdxArg.ErledigtJN;

            if (_PflegePlanModus == PflegePlanModus.Wunde)
            {
                cbLokalisierung.Enabled = false;
                this.pnlLokalisierung.Visible = true;
            }
            else
                cbLokalisierung.Enabled = _pdxArg.IDAufenthaltPDX == Guid.Empty && !_pdxArg.ErledigtJN;

            if (lblZusätzlicheLokalisierung.Visible && _pdxArg.ErledigtJN)
                lblZusätzlicheLokalisierung.Visible = false;
            cbArea.ReadOnly = _pdxArg.IDAufenthaltPDX != Guid.Empty || _pdxArg.ErledigtJN;
            cbSide.ReadOnly = _pdxArg.IDAufenthaltPDX != Guid.Empty || _pdxArg.ErledigtJN;
            dtpEvalStart.ReadOnly = _pdxArg.IDAufenthaltPDX != Guid.Empty || _pdxArg.ErledigtJN;

        }

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            InitErrorProvider(); // Neu nach 22.04.2008 MDA
            if (_pdxArg == null) return; //Neu nach 01.10.2008 MDA
            tbText.Text = _pdxArg.Klartext;

            if (_pdxArg.StartDatum != new DateTime(1900, 1, 1))
                dtpStart.Value = _pdxArg.StartDatum;
            else
                dtpStart.Value = DBNull.Value;
            
            //Lokalisierung
            if (_PflegePlanModus == PflegePlanModus.Wunde)
            {
                cbLokalisierung.Checked = true;
            }
            else
            {
                cbLokalisierung.Checked = _pdxArg.LokalisierungJN; 
            }
            //else if (_pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.Kann)
            //{
            //    cbLokalisierung.Checked = _pdxArg.LokalisierungJN;
            //}
            //else if (_pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.Muss)
            //{
            //    cbLokalisierung.Checked = true;
            //}
            //else
            //{
            //    cbLokalisierung.Checked = false;
            //}
            
            if (_pdxArg.Lokalisierung != null)
                cbArea.Value = _pdxArg.Lokalisierung;
            else
                cbArea.Value = null;

            if (_pdxArg.LokalisierungSeite != null)
                cbSide.Value = _pdxArg.LokalisierungSeite;
            else
                cbSide.Value = null;
            if (ENV.EvaluierungsTyp == EvaluierungsTypen.PDX)
            {
                if (_pdxArg.EvalStartDatum.Year != 1900 &&
                    _pdxArg.EvalStartDatum != DateTime.MinValue
                   )
                    dtpEvalStart.Value = _pdxArg.EvalStartDatum;
                else if (_pdxArg.EvalStartDatum == DateTime.MinValue)
                    dtpEvalStart.Text = "";
                else
                    dtpEvalStart.Value = DateTime.Now;
            }
            else
            {
                dtpEvalStart.Text = "";
            }

            if (this.cbLokalisierung.Checked)
            {
                this.pnlLokalisierung.Visible = true;
            }
            else
            {
                this.cbArea.Value = null;
                this.cbSide.Value = null;
                this.pnlLokalisierung.Visible = false;
            }
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {

            if (_pdxArg == null) 
                return; //Neu nach 01.10.2008 MDA
                        
            _pdxArg.Klartext = tbText.Text.Trim();

            if (dtpStart.Text.Trim() == "")
                _pdxArg.StartDatum = new DateTime(1900, 1, 1);
            else
                _pdxArg.StartDatum = Convert.ToDateTime(dtpStart.Value);
            _pdxArg.LokalisierungJN = cbLokalisierung.Checked;

            if (cbArea.Text.Trim().Length > 0)
                _pdxArg.Lokalisierung = cbArea.Text.Trim();
            else
                _pdxArg.Lokalisierung = "";

            if (cbSide.Text.Trim().Length > 0)
                _pdxArg.LokalisierungSeite = cbSide.Text.Trim();
            else
                _pdxArg.LokalisierungSeite = "";

            if (ENV.EvaluierungsTyp == EvaluierungsTypen.PDX && dtpEvalStart.Text.Trim().Length > 0)
                _pdxArg.EvalStartDatum = Convert.ToDateTime(dtpEvalStart.Value);
            else
                _pdxArg.EvalStartDatum = DateTime.MinValue;

            //Neu nach 19.09.2008 MDA
            _pdxArg.WundeJN = _PflegePlanModus == PflegePlanModus.Wunde;

        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // tbText
            GuiUtil.ValidateField(tbText, (tbText.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // dtpStart
            GuiUtil.ValidateField(dtpStart, (dtpStart.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            //Lokalisierung
            bool lokPruefen = false;
            //Änderung nach 19.09.2008 MDA
            //Bei Wunden lokalisierung Prüfen
            if (_PflegePlanModus == PflegePlanModus.Wunde || _pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.Muss)
                lokPruefen = true;
            else if(_pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.Kann && cbLokalisierung.Checked)
                lokPruefen = true;

            if (lokPruefen)
            {
                GuiUtil.ValidateField(cbArea, (cbArea.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

                GuiUtil.ValidateField(cbSide, (cbSide.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }


            // dtpEvalStart
            if (pnlStartEval.Visible)
            {
                GuiUtil.ValidateField(dtpEvalStart, (dtpEvalStart.Text.Length > 0),
                    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }

            return !bError;
        }

        //----------------------------------------------------------------------------
		/// <summary>
		/// Versteckt oder zeigt die entsprechenden Felder
		/// </summary>
		//----------------------------------------------------------------------------
        private void ShowHideFields()
        {
            //Checkbox Lokalisierung
            if (_PflegePlanModus == PflegePlanModus.Wunde)
            {
                cbLokalisierung.Enabled = false;
                this.pnlLokalisierung.Visible = true;
            }
            else
                cbLokalisierung.Enabled = _pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.Kann;
            lblZusätzlicheLokalisierung.Visible = AddlokalisierungEnabled && cbLokalisierung.Checked && _pdxRow.LokalisierungsTyp != (int)PDxLokalisierungsTypen.KannNicht; //Änderung nach 08.05.2008 MDA

            //Panel Lokalisierung
            //if (_pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.KannNicht)
            //{
            //    pnlLokalisierung.Visible = false;
            //}
            //else
            //{
            //    pnlLokalisierung.Visible = _pdxRow.LokalisierungsTyp == (int)PDxLokalisierungsTypen.Muss || _pdxArg.LokalisierungJN;
            //}
          
            //Panel Evaluierungsstartdatum
            pnlStartEval.Visible = ENV.EvaluierungsTyp == EvaluierungsTypen.PDX ? true : false;
        }

        //Neu nach 22.04.2008 MDA
        private void InitErrorProvider()
        {
            errorProvider1.SetError(tbText, "");
            errorProvider1.SetError(dtpStart, "");
            errorProvider1.SetError(cbArea, "");
            errorProvider1.SetError(cbSide, "");
            errorProvider1.SetError(dtpEvalStart, "");
        }

        private void cbLokalisierung_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbLokalisierung.Checked)
            //{
            //    pnlLokalisierung.Visible = true;
            //}
            //else
            //{
            //    pnlLokalisierung.Visible = false;
            //    cbArea.Clear();
            //    cbSide.Clear();
            //}
          
            //Neu nach 03.09.2008 MDA


            if (this.cbLokalisierung.Checked)
            {
                this.pnlLokalisierung .Visible = true;
            }
            else
            {
                this.cbArea.Value = null;
                this.cbSide.Value = null;
                this.pnlLokalisierung.Visible = false;
            }

            lblZusätzlicheLokalisierung.Visible = AddlokalisierungEnabled && cbLokalisierung.Checked && _pdxRow.LokalisierungsTyp != (int)PDxLokalisierungsTypen.KannNicht;
            
            if (_valueChangeEnabled && PDxValueChanged != null)
            {
                UpdateDATA();
                PDxValueChanged(sender, e);
            }
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && PDxValueChanged != null)
            {
                UpdateDATA();
                PDxValueChanged(sender, e);
            }
        }

        private void lnLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_valueChangeEnabled && PDxZusaetzlicheLokalisierung != null)
                PDxZusaetzlicheLokalisierung(sender, e);
        }

        public void setControlsAktivDisable(bool bOn)
        {
             PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);
        }
    
    
    }
}
