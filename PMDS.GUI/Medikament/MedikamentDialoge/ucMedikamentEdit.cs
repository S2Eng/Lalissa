using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinEditors;
using PMDS.GUI.BaseControls;
using PMDS.Data.Global;
using PMDS.Data.Patient;

using System.Linq;





namespace PMDS.GUI
{



    public partial class ucMedikamentEdit : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _ID = Guid.Empty;
        private PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable _dt;
        private PMDS.BusinessLogic.Medikament _m = new PMDS.BusinessLogic.Medikament();
        private bool _preventValueChanged;

        public event EventHandler ValueChanged;
        PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();


        public ucMedikamentEdit()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {

                    if (generic.sEquals(ENV.MedikamenteImportType, "service"))
                    {
                        this.cbPackungsEinheit.Group = "AEH";
                        this.cmbApplikationsform.Group = "AAF";
                    }
                }
            }

            cbEinheit.Text = "";
            cbGroup.Text = "";
            RequiredFields();
            this.SetUI();

            this.PMDSBusinessUI1.loadCboPackungsanzahl((Infragistics.Win.UltraWinEditors.UltraComboEditor)this.cbPackungsanzahl, null);
        }

        public void SetUI()
        {
            //this.chkAktuell.Enabled = ENV.adminSecure;
            //this.chkImportiert.Enabled = ENV.adminSecure;
            //this.datGültigkeitsdatum.Enabled = ENV.adminSecure;
            //this.datImportiertAm.Enabled = ENV.adminSecure;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Medikament lesen und felder befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Read(Guid IDMedikament)
        {
            this.SetUI();

            _ID = Guid.Empty;
            _dt = _m.ReadMedikament(IDMedikament);
            if (_dt.Count == 0)
                throw new Exception("ucMedikamentEdit::Read() - Datensatz nicht gefunden ID: " + IDMedikament.ToString());

            _ID = IDMedikament;
            _preventValueChanged = true;
            tbBarcode.Text = ROW.BARCODE;
            tbBezeichnung.Text = ROW.Bezeichnung;
            tbExtID.Text = ROW.EXT_ID;
            tbLangText.Text = ROW.LangText;
            tbZulassungsnummer.Text = ROW.Zulassungsnummer;
            cbEinheit.Text = ROW.Einheit;
            cbGroup.Text = ROW.Gruppe;

            if(ROW.IsHerrichtenNull())
                cmbHerrichten.Value = DBNull.Value;
            else
                cmbHerrichten.Value = ROW.Herrichten;

            if(ROW.IsVerabreichungsartNull())
                cmbVerabreichungsart.Value = DBNull.Value;
            else
                cmbVerabreichungsart.Value = ROW.Verabreichungsart;

            cmbApplikationsform.Text = !ROW.IsApplikationsformNull() ? ROW.Applikationsform.Trim() : "";
            cbAerztVorbereitung.Checked = !ROW.IsAerztlichevorbereitungJNNull() ? ROW.AerztlichevorbereitungJN : false;
            cbPackungsanzahl.Value = ROW.Packungsanzahl;
            txtPackGr.Value = ROW.Packungsgroesse;

            cbPackungsEinheit.Text = ROW.Packungseinheit;

            this.chkImportiert.Checked = ROW.Importiert;
            this.chkAktuell.Checked = ROW.Aktuell;
            if (!ROW.IsImportiertAmNull())
            {
                this.datImportiertAm.Value = ROW.ImportiertAm;
            }
            else
            {
                this.datImportiertAm.Value = null;
            }
            if (!ROW.IsGültigkeitsdatumNull())
            {
                this.datGültigkeitsdatum.Value = ROW.Gültigkeitsdatum;
            }
            else
            {
                this.datGültigkeitsdatum.Value = null;
            }

            this.txtLagervorschrift.Text = ROW.Lagervorschrift.Trim();
            this.txtErstattungscode.Text = ROW.Erstattungscode.Trim();
            this.txtLieferant.Text = ROW.Lieferant.Trim();
            this.txtKassenzeichen.Text = ROW.Kassenzeichen.Trim();

            _preventValueChanged = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Werte schreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write()
        {
            if (_ID == Guid.Empty)			// nichts zu speichern
                return;

            ROW.BARCODE = tbBarcode.Text.Trim();
            ROW.Bezeichnung = tbBezeichnung.Text.Trim();
            ROW.EXT_ID = tbExtID.Text.Trim();
            ROW.LangText = tbLangText.Text.Trim();
            ROW.Zulassungsnummer = tbZulassungsnummer.Text.Trim();
            ROW.Einheit = cbEinheit.Text.Trim();
            ROW.Gruppe = cbGroup.Text.Trim();

            //Neu nach 09.07.2007 MDA
            if (cmbHerrichten.Value != null )
                ROW.Herrichten = (int)cmbHerrichten.Value;
            else
                ROW.SetHerrichtenNull();
            if (cmbVerabreichungsart.Value != null)
                ROW.Verabreichungsart = (int)cmbVerabreichungsart.Value;
            else
                ROW.SetVerabreichungsartNull();

            ROW.Applikationsform = cmbApplikationsform.Text.Trim();
            ROW.AerztlichevorbereitungJN = cbAerztVorbereitung.Checked;
            if(cbPackungsanzahl.Value != null)
            ROW.Packungsanzahl = (int)cbPackungsanzahl.Value;
            if (txtPackGr.Value.GetType() == typeof (int))               
            ROW.Packungsgroesse =(int) txtPackGr.Value;
            ROW.Packungseinheit = cbPackungsEinheit.Text.Trim();

            ROW.Importiert = this.chkImportiert.Checked;
            ROW.Aktuell = this.chkAktuell.Checked;
            if (this.datImportiertAm.Value != null)
            {
                ROW.ImportiertAm = this.datImportiertAm.DateTime;
            }
            else
            {
                ROW.SetImportiertAmNull();
            }
            if (this.datGültigkeitsdatum.Value != null)
            {
                ROW.Gültigkeitsdatum = this.datGültigkeitsdatum.DateTime;
            }
            else
            {
                ROW.SetGültigkeitsdatumNull();
            }
            ROW.Lagervorschrift = this.txtLagervorschrift.Text;
            ROW.Kassenzeichen = this.txtKassenzeichen.Text;
            ROW.Erstattungscode = this.txtErstattungscode.Text;
            ROW.Lieferant = this.txtLieferant.Text;

            _m.Write(_dt);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Neuen Satz erzeugen
        /// </summary>
        //----------------------------------------------------------------------------
        public void New()
        {
            ClearFields();
            this.SetUI();
            this._dt = new Global.db.Patient.dsMedikament.MedikamentDataTable();
            _m.New(_dt);
            _ID = ROW.ID;
            this.chkAktuell.Checked = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Entfernt den Datensatz
        /// </summary>
        //----------------------------------------------------------------------------
        public void Delete()
        {
            ROW.Delete();			// markieren
            _m.Write(_dt);			// DB Operation
            ClearFields();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// löschen der Felder
        /// </summary>
        //----------------------------------------------------------------------------
        public void ClearFields()
        {
            this.datImportiertAm.Value = null;
            this.datGültigkeitsdatum.Value = null;

            this.chkImportiert.Checked = false;
            this.chkAktuell.Checked = false;

            _preventValueChanged = true;
            foreach (Control c in this.Controls)
            {
                if (c is UltraTextEditor)
                    ((UltraTextEditor)c).Clear();
                if (c is AuswahlGruppeCombo)
                    ((AuswahlGruppeCombo)c).Text = "";
            }
            _preventValueChanged = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(tbBezeichnung);
            GuiUtil.ValidateRequired(cmbHerrichten);
            GuiUtil.ValidateRequired(cmbVerabreichungsart);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // txtNachname
            GuiUtil.ValidateField(tbBezeichnung, (tbBezeichnung.Text.Trim().Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);           
            GuiUtil.ValidateField(cmbHerrichten, (cmbHerrichten.Text.Trim().Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            GuiUtil.ValidateField(cmbVerabreichungsart, (cmbVerabreichungsart.Text.Trim().Length > 0),
             ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            string MsgTxt2 = "";
            bool cbApplikationsformOK = PMDSBusinessUI.checkCboBox(this.cmbApplikationsform, QS2.Desktop.ControlManagment.ControlManagment.getRes("Applikationsform"), true, ref MsgTxt2, true);
            bool cbPackungseinheitOK = PMDSBusinessUI.checkCboBox(this.cbPackungsEinheit, QS2.Desktop.ControlManagment.ControlManagment.getRes("Packungseinheit"), true, ref MsgTxt2, true);
            bool cbDarreichungsformOK = PMDSBusinessUI.checkCboBox(this.cbEinheit, QS2.Desktop.ControlManagment.ControlManagment.getRes("Einheit"), true, ref MsgTxt2, true);
            if (!cbDarreichungsformOK || !cbPackungseinheitOK || !cbApplikationsformOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }

            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Möglichen Fehler löschen
        /// </summary>
        //----------------------------------------------------------------------------
        public void ClearValidationErrors()
        {
            errorProvider1.SetError(tbBezeichnung, "");
            errorProvider1.SetError(cmbHerrichten, "");
        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle und einzige ROW
        /// </summary>
        //----------------------------------------------------------------------------
        public PMDS.Global.db.Patient.dsMedikament.MedikamentRow ROW
        {
            get
            {
                return _dt[0];
            }
        }

        public Guid ID { get { return ROW.ID; } }
        //public string EXT_ID { get { return tbExtID.Text.Trim(); } set { tbExtID.Text = value; } }
        //public string BARCODE { get { return tbBarcode.Text.Trim(); } set { tbBarcode.Text = value; } }
        //public string ZULASSUNGSNUMMER { get { return tbZulassungsnummer.Text.Trim(); } set { tbZulassungsnummer.Text = value; } }
        public string BEZEICHNUNG { get { return tbBezeichnung.Text.Trim(); } set { tbBezeichnung.Text = value; } }
        //public string LANGTEXT { get { return tbLangText.Text.Trim(); } set { tbLangText.Text = value; } }
        //public string EINHEIT { get { return cbEinheit.Text.Trim(); } set { cbEinheit.Text = value; } }
        //public string GRUPPE { get { return cbGroup.Text.Trim(); } set { cbGroup.Text = value; } }
        //public object HERRICHTEN { get { return cmbHerrichten.Value; } set { cmbHerrichten.Value = value; } }
        //public object VERABREICHUNG { get { return cmbVerabreichungsart.Value; } set { cmbVerabreichungsart.Value = value; } }
        //public string APPLIKATIONSFORM { get { return cmbApplikationsform.Text.Trim(); } set { cmbApplikationsform.Text = value; } }
        //public bool AERZTLICHEVORBEREITUNG { get { return cbAerztVorbereitung.Checked; } set { cbAerztVorbereitung.Checked = value; } }
        //public int PACKUNGSGROESSE { get { return (int)txtPackGr.Value; } set { txtPackGr.Value = value; } }
        //public int PACKKUNGSANZAHL { get { return (int)cbPackungsanzahl.Value; ;} set { cbPackungsanzahl.Value = value; } }

        private void cbEinheit_ValueChanged(object sender, System.EventArgs e)
        {

            if (ValueChanged != null && _preventValueChanged == false)
                ValueChanged(this, null);
        }

        private void lblErstattungscode_Click(object sender, EventArgs e)
        {

        }
    }
}
