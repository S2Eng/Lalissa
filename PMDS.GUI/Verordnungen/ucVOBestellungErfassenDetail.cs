using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Global.db.ERSystem;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.GUI.Verordnungen
{

    public partial class ucVOBestellungErfassenDetail : UserControl
    {
        public Nullable<Guid> _IDVOBestelldaten = null;
        public Nullable<Guid> _IDVO = null;
        public bool _EinmaligeAnfoderung = false;
        public bool _IsNew = false;

        public PMDS.db.Entities.VO_Bestelldaten _rVO_Bestelldaten = null;

        public bool abort = true;
        public frmVOBestellungErfassenDetail mainWindow = null;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.GUI.VB.PMDSBusinessVB bVB = new PMDS.GUI.VB.PMDSBusinessVB();

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;

        public bool rightAddVOBestelldaten = false;
        public bool rightAddVOBestelldatenEinmaligeAnforderung = false;







        public ucVOBestellungErfassenDetail()
        {
            InitializeComponent();
        }

        private void ucVOBestellungErfassen_Load(object sender, EventArgs e)
        {

        }


        public void initControl(bool IsNew, Nullable<Guid> IDVOBestelldaten, Nullable<Guid> IDVO, bool EinmaligeAnfoderung)
        {
            try
            {
                this._IsNew = IsNew;
                this._IDVO = IDVO;
                this._IDVOBestelldaten = IDVOBestelldaten;
                this._EinmaligeAnfoderung = EinmaligeAnfoderung;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnSearchMedikmanete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;

                this.SelListChanged("", null, null);

                this.optSerienterminType.CheckedIndex = 0;
                this.opTagWochenMonat.CheckedIndex = 0;
                this.SerienterminTypeOrTagWochenMonat_ValueChanged();

                this.udteDatumNaechsterAnspruch.ReadOnly = false;
                this.chkEinmaligeAnforderung.Enabled = false;

                this.rightAddVOBestelldaten = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.VOBestellung);
                this.rightAddVOBestelldatenEinmaligeAnforderung = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.VOBestellungEinmalig);

                this._db = PMDSBusiness.getDBContext();
                this.clearUI();

                //PMDSBusinessUI.dSelListChanged += new PMDSBusinessUI.SelListChanged(this.SelListChanged);

                this.loadData();
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.initControl: " + ex.ToString());
            }
        }

        public void SelListChanged(string Grp, UltraComboEditor cbo, Infragistics.Win.ValueList val)
        {
            try
            {
                List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                this.PMDSBusinessUI2.loadSelList("VOT", this.cboTyp, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheit, null, null, ref lstEmpty);
                this.PMDSBusinessUI2.loadSelList("LFT", this.cboLieferant, null, null, ref lstEmpty);

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.SelListChanged: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.txtMedikament.Text = "";
                this.txtMedikament.Tag = null;
                this.udteGueltigAb.Value = null;
                this.udteGueltigBis.Value = null;
                this.cboTyp.Value = null;

                this.clearSerientermineUI();
                this.udteDatumNaechsterAnspruch.Value = null;
                this.chkEigentumKlient.Checked = false;
                this.numMenge.Value = 0;
                this.cboEinheit.Value = null;
                this.cboLieferant.Value = null;
                this.txtHinweisLieferant.Text = "";
                this.txtAnmerkung.Text = "";
                this.chkEinmaligeAnforderung.Checked = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.clearUI: " + ex.ToString());
            }
        }
        public void clearSerientermineUI()
        {
            try
            {
                this.chkDauerbestellung.Checked = false;
                this.dteSerienterminEndetAm.Value = null;

                this.optSerienterminType.CheckedIndex = 0;
                this.iWiedWertJeden.Value = null;
                this.opTagWochenMonat.CheckedIndex = 0;
                this.opTagWochenMonat.Enabled = true;
                this.iNTenMonat.Value = null;

                this.cbMo.Checked = false;
                this.cbDi.Checked = false;
                this.cbMi.Checked = false;
                this.cbDo.Checked = false;
                this.cbFr.Checked = false;
                this.cbSa.Checked = false;
                this.cbSo.Checked = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.clearSerientermineUI: " + ex.ToString());
            }
        }
        public void setWochentageOnOff(bool bOn)
        {
            try
            {
                this.cbMo.Checked = bOn;
                this.cbDi.Checked = bOn;
                this.cbMi.Checked = bOn;
                this.cbDo.Checked = bOn;
                this.cbFr.Checked = bOn;
                this.cbSa.Checked = bOn;
                this.cbSo.Checked = bOn;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.setWochentageOnOff: " + ex.ToString());
            }
        }
        public void setSerientterminUIReadOnlyOnOff(bool bOn)
        {
            try
            {
                this.optSerienterminType.Enabled = !bOn;
                this.iWiedWertJeden.ReadOnly = bOn;
                this.iNTenMonat.ReadOnly = bOn;
                this.opTagWochenMonat.Enabled = !bOn;
                this.grpWochentage.Enabled = !bOn;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.setSerientterminUIReadOnlyOnOff: " + ex.ToString());
            }
        }
        public void loadData()
        {
            try
            {
                this.clearUI();
                DateTime dNow = DateTime.Now;

                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(this._db);

                this.cboLieferant.ReadOnly = this._EinmaligeAnfoderung;
                this.txtHinweisLieferant.ReadOnly = this._EinmaligeAnfoderung;
                this.txtAnmerkung.ReadOnly = this._EinmaligeAnfoderung;

                if (this._IsNew)
                {
                    this._rVO_Bestelldaten = PMDS.Global.db.ERSystem.EFEntities.newVO_Bestelldaten(this._db);
                    this._rVO_Bestelldaten.ID = System.Guid.NewGuid();
                    this._rVO_Bestelldaten.IDVerordnung = this._IDVO.Value;
                    this._rVO_Bestelldaten.GueltigAb = dNow.Date;
                    this._rVO_Bestelldaten.GueltigAb = dNow.Date;
                    this._rVO_Bestelldaten.GueltigBis = null;

                    this._rVO_Bestelldaten.DatumNaechsterAnspruch = dNow;

                    IQueryable<PMDS.db.Entities.VO> tVO = this._db.VO.Where(o => o.ID == this._IDVO);
                    PMDS.db.Entities.VO rVO = tVO.First();
                    this._rVO_Bestelldaten.Typ = rVO.Typ;

                    IQueryable <PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == rVO.IDMedikament);
                    PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                    this.txtMedikament.Tag = rMedikament.ID;
                    this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();
                    this._rVO_Bestelldaten.EinmaligeAnforderung = this._EinmaligeAnfoderung;
                    if (this._rVO_Bestelldaten.EinmaligeAnforderung)
                    {
                        this._rVO_Bestelldaten.GueltigBis = dNow.Date;
                        this.optSerienterminType.CheckedIndex = 0;
                        this.setWochentageOnOff(true);
                    }
                    this._rVO_Bestelldaten.Menge = rVO.Menge;
                    this._rVO_Bestelldaten.Einheit = rVO.Einheit;
                    this._rVO_Bestelldaten.DatumErstellt = dNow;
                    this._rVO_Bestelldaten.DatumGeaendert = dNow;
                    this._rVO_Bestelldaten.IDBenutzerErstellt = rBenutzer.ID;
                    this._rVO_Bestelldaten.IDBenutzergeaendert = rBenutzer.ID;
                    this._rVO_Bestelldaten.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                    this._rVO_Bestelldaten.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                    this._rVO_Bestelldaten.Lieferant = rVO.Lieferant;
                    this._rVO_Bestelldaten.HinweisLieferant = rVO.HinweisLieferant;
                    this._rVO_Bestelldaten.Anmerkung = rVO.Anmerkung;

                    this.lblDatumNächsterAnspruch.Visible = false;
                    this.udteDatumNaechsterAnspruch.Visible = false;
                    this._db.VO_Bestelldaten.Add(this._rVO_Bestelldaten);
                }
                else
                {
                    IQueryable<PMDS.db.Entities.VO_Bestelldaten> tVO_Bestelldaten = this._db.VO_Bestelldaten.Where(o => o.ID == this._IDVOBestelldaten);
                    this._rVO_Bestelldaten = tVO_Bestelldaten.First();
                    IQueryable<PMDS.db.Entities.Medikament> tMedikament = this._db.Medikament.Where(o => o.ID == this._rVO_Bestelldaten.IDMedikament);
                    PMDS.db.Entities.Medikament rMedikament = tMedikament.First();
                    this.txtMedikament.Tag = rMedikament.ID;
                    this.txtMedikament.Text = rMedikament.Bezeichnung.Trim();

                    this._rVO_Bestelldaten.DatumGeaendert = dNow;
                    this._rVO_Bestelldaten.IDBenutzergeaendert = rBenutzer.ID;
                    this._rVO_Bestelldaten.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                    this.lblDatumNächsterAnspruch.Visible = true;
                    this.udteDatumNaechsterAnspruch.Visible = true;
                }

                this.udteGueltigAb.Value = this._rVO_Bestelldaten.GueltigAb;
                if (this._rVO_Bestelldaten.GueltigBis != null)
                {
                    this.udteGueltigBis.DateTime = this._rVO_Bestelldaten.GueltigBis.Value;
                }
                else
                {
                    this.udteGueltigBis.Value = null;
                }

                this.cboTyp.Value = this._rVO_Bestelldaten.Typ;

                this.chkDauerbestellung.Checked = this._rVO_Bestelldaten.Dauerbestellung;
                this.udteDatumNaechsterAnspruch.Value = this._rVO_Bestelldaten.DatumNaechsterAnspruch;
                if (this._rVO_Bestelldaten.SerienterminEndetAm != null)
                {
                    this.dteSerienterminEndetAm.DateTime = this._rVO_Bestelldaten.SerienterminEndetAm.Value;
                }
                else
                {
                    this.dteSerienterminEndetAm.Value = null;
                }

                if (this._rVO_Bestelldaten.SerienterminType.Trim() != "")
                {
                    this.optSerienterminType.Value = this._rVO_Bestelldaten.SerienterminType;
                }
                else
                {
                    this.optSerienterminType.CheckedIndex = 0;
                }
               
                if (this._rVO_Bestelldaten.WiedWertJeden != null)
                {
                    this.iWiedWertJeden.Value = this._rVO_Bestelldaten.WiedWertJeden.Value;
                }
                else
                {
                    this.iWiedWertJeden.Value = null;
                }

                if (this._rVO_Bestelldaten.TagWochenMonat.Trim() != "")
                {
                    this.opTagWochenMonat.Value = this._rVO_Bestelldaten.TagWochenMonat;
                }
                else
                {
                    this.opTagWochenMonat.CheckedIndex = 0;
                }

                if (this._rVO_Bestelldaten.nTenMonat != null)
                {
                    this.iNTenMonat.Value = this._rVO_Bestelldaten.nTenMonat.Value;
                }
                else
                {
                    this.iNTenMonat.Value = null;
                }
                this.setWochentage(this._rVO_Bestelldaten.Wochentage.Trim());

                this.chkEigentumKlient.Checked = this._rVO_Bestelldaten.EigentumKlient;
                this.numMenge.Value = this._rVO_Bestelldaten.Menge;
                this.cboEinheit.Text = this._rVO_Bestelldaten.Einheit.Trim();
                if (this._rVO_Bestelldaten.Lieferant != null)
                {
                    this.cboLieferant.Value = this._rVO_Bestelldaten.Lieferant.Value;
                }
                else
                {
                    this.cboLieferant.Value = null;
                }
                this.txtHinweisLieferant.Text = this._rVO_Bestelldaten.HinweisLieferant.Trim();
                this.txtAnmerkung.Text = this._rVO_Bestelldaten.Anmerkung.Trim();
                this.chkEinmaligeAnforderung.Checked = this._rVO_Bestelldaten.EinmaligeAnforderung;

                this.SerienterminTypeOrTagWochenMonat_ValueChanged();

                if (this._IsNew)
                {
                    this.setWochentageOnOff(true);
                }
                else
                {
                    this.setSerientterminUIReadOnlyOnOff(true);
                }


                this.PanelSerientermineUISub.Enabled = !this._rVO_Bestelldaten.EinmaligeAnforderung;
                this.cboTyp.ReadOnly = this._rVO_Bestelldaten.EinmaligeAnforderung;
                if (this._rVO_Bestelldaten.EinmaligeAnforderung)
                {
                    this.cboLieferant.Enabled = this.rightAddVOBestelldaten;
                    this.txtHinweisLieferant.Enabled = this.rightAddVOBestelldaten;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.txtMedikament, "");
                this.errorProvider1.SetError(this.udteGueltigAb, "");
                this.errorProvider1.SetError(this.cboTyp, "");
                this.errorProvider1.SetError(this.dteSerienterminEndetAm, "");
                this.errorProvider1.SetError(this.cboTyp, "");
                this.errorProvider1.SetError(this.iWiedWertJeden, "");
                this.errorProvider1.SetError(this.iNTenMonat, "");
                this.errorProvider1.SetError(this.cboLieferant, "");

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.clearErrorProvider: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                if (this.txtMedikament.Tag == null)
                {
                    this.errorProvider1.SetError(this.txtMedikament, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Verordnung ausgewählt!", "", MessageBoxButtons.OK);
                    return false;
                }

                if (this.udteGueltigAb.Value == null)
                {
                    this.errorProvider1.SetError(this.udteGueltigAb, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab: Eingabe erforderlich", "", MessageBoxButtons.OK);
                    return false;
                }

                if (this.cboTyp.Value == null)
                {
                    this.errorProvider1.SetError(this.cboTyp, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                if (this.cboLieferant.Value == null)
                {
                    //this.errorProvider1.SetError(this.cboLieferant, "Error");
                    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lieferant: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    //return false;
                }
                else
                {
                    if (this.cboLieferant.Value.GetType() != typeof(Guid))
                    {
                        this.errorProvider1.SetError(this.cboLieferant, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lieferant: Falsche Eingabe!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                if (this.chkEinmaligeAnforderung.Checked)
                {
                    if (this.udteGueltigAb.Value == null)
                    {
                        this.errorProvider1.SetError(this.udteGueltigAb, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab: Eingabe erforderlich", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (this.udteGueltigBis.Value == null)
                    {
                        this.errorProvider1.SetError(this.udteGueltigBis, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig bis: Eingabe erforderlich", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (!this.udteGueltigAb.DateTime.Equals(this.udteGueltigBis.DateTime))
                    {
                        this.errorProvider1.SetError(this.udteGueltigAb, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab muss gleich Gültig bis sein!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }

                //if (this.chkDauerbestellung.Checked)
                //{
                //if (this.dteSerienterminEndetAm.Value == null)
                //{
                //    this.errorProvider1.SetError(this.dteSerienterminEndetAm, "Error");
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dauerbestellung endet am: Eingabe erforderlich", "", MessageBoxButtons.OK);
                //    return false;
                //}
                //else
                //{
                //    if (this.dteSerienterminEndetAm.DateTime.Date <= this.udteGueltigAb.DateTime.Date)
                //    {
                //        this.errorProvider1.SetError(this.dteSerienterminEndetAm, "Error");
                //        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Serientermin endet am muss grösser sein als Gültig ab!", "", MessageBoxButtons.OK);
                //        return false;
                //    }
                //}

                int iSerientermintype = System.Convert.ToInt32(this.optSerienterminType.Value.ToString().Trim());
                    if (iSerientermintype == 1)
                    {
                        string sWochentage = this.getWochentage();
                        if (sWochentage.Trim() == "")
                        {
                            this.errorProvider1.SetError(this.grpWochentage, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wochentage: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    else if (iSerientermintype == 2)
                    {
                        if (this.iWiedWertJeden.Value == System.DBNull.Value)
                        {
                            this.errorProvider1.SetError(this.iWiedWertJeden, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wert wiederholen alle n Tage/Wochen/Monate: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }

                        int iTagWochenMonat = System.Convert.ToInt32(this.opTagWochenMonat.Value.ToString().Trim());
                        if (iTagWochenMonat == 1)
                        {
                            string sWochentage = this.getWochentage();
                            if (sWochentage.Trim() == "")
                            {
                                this.errorProvider1.SetError(this.grpWochentage, "Error");
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wochentage: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                                return false;
                            }
                        }

                    }
                    else if (iSerientermintype == 3)
                    {
                        if (this.iNTenMonat.Value == System.DBNull.Value)
                        {
                            this.errorProvider1.SetError(this.iNTenMonat, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("n-ten des Monats: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                //}
                

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.validateData: " + ex.ToString());
            }
        }

        public bool saveData(ref bool UserAborted)
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }

                this._rVO_Bestelldaten.IDMedikament = (Guid)this.txtMedikament.Tag;
                this._rVO_Bestelldaten.GueltigAb = this.udteGueltigAb.DateTime.Date;
                if (this.udteGueltigBis.Value != null)
                {
                    this._rVO_Bestelldaten.GueltigBis = this.udteGueltigBis.DateTime.Date;
                }
                else
                {
                    this._rVO_Bestelldaten.GueltigBis = null;
                }
                this._rVO_Bestelldaten.Typ = (Guid)this.cboTyp.Value;
                
                this._rVO_Bestelldaten.Dauerbestellung = this.chkDauerbestellung.Checked;
                this._rVO_Bestelldaten.DatumNaechsterAnspruch = this.udteDatumNaechsterAnspruch.DateTime;

                //if (this.chkDauerbestellung.Checked)
                //{
                    if (this.dteSerienterminEndetAm.Value != null)
                    {
                        this._rVO_Bestelldaten.SerienterminEndetAm = this.dteSerienterminEndetAm.DateTime.Date;
                    }
                    else
                    {
                        this._rVO_Bestelldaten.SerienterminEndetAm = null;
                    }
                    this._rVO_Bestelldaten.SerienterminType = this.optSerienterminType.Value.ToString();
                    if (this.iWiedWertJeden.Value != System.DBNull.Value)
                    {
                        this._rVO_Bestelldaten.WiedWertJeden = (int)this.iWiedWertJeden.Value;
                    }
                    else
                    {
                        this._rVO_Bestelldaten.WiedWertJeden = null;
                    }
                    if (this.opTagWochenMonat.Value != null)
                    {
                        this._rVO_Bestelldaten.TagWochenMonat = this.opTagWochenMonat.Value.ToString();
                    }
                    else
                    {
                        this._rVO_Bestelldaten.TagWochenMonat = "";
                    }
                    if (this.iNTenMonat.Value != System.DBNull.Value)
                    {
                        this._rVO_Bestelldaten.nTenMonat = (int)this.iNTenMonat.Value;
                    }
                    else
                    {
                        this._rVO_Bestelldaten.nTenMonat = null;
                    }
                    this._rVO_Bestelldaten.Wochentage = this.getWochentage();
                    this._rVO_Bestelldaten.Dauer = -1;
                //}
                //else
                //{
                //    this._rVO_Bestelldaten.SerienterminEndetAm = null;
                //    this._rVO_Bestelldaten.SerienterminType = "";
                //    this._rVO_Bestelldaten.WiedWertJeden = null;
                //    this._rVO_Bestelldaten.TagWochenMonat = "";
                //    this._rVO_Bestelldaten.nTenMonat = null;
                //    this._rVO_Bestelldaten.Wochentage = "";
                //    this._rVO_Bestelldaten.Dauer = -1;
                //}
                

                this._rVO_Bestelldaten.EigentumKlient = this.chkEigentumKlient.Checked;
                if (this.numMenge.Value != null)
                {
                    this._rVO_Bestelldaten.Menge = (double)this.numMenge.Value;
                }
                else
                {
                    this._rVO_Bestelldaten.Menge = 0;
                }
                this._rVO_Bestelldaten.Einheit = this.cboEinheit.Text.Trim();
                if (this.cboLieferant.Value != null)
                {
                    this._rVO_Bestelldaten.Lieferant = (Guid)this.cboLieferant.Value;
                }
                else
                {
                    this._rVO_Bestelldaten.Lieferant = null;
                }
                this._rVO_Bestelldaten.HinweisLieferant = this.txtHinweisLieferant.Text.Trim();
                this._rVO_Bestelldaten.Anmerkung = this.txtAnmerkung.Text.Trim();
                this._rVO_Bestelldaten.EinmaligeAnforderung = this.chkEinmaligeAnforderung.Checked;

                bool calcNächsterAnspruch = false;
                bool dDatumNächsterAbspruchBerechnet = false;
                Nullable<DateTime> calcNächsterAnspruchAb = null;
                if (this._IsNew)
                {
                    if (this._rVO_Bestelldaten.GueltigAb.Date >= DateTime.Now.Date)
                    {
                        calcNächsterAnspruchAb = this._rVO_Bestelldaten.GueltigAb.Date;
                    }
                    else
                    {
                        //calcNächsterAnspruchAb = DateTime.Now.Date;
                        calcNächsterAnspruchAb = this._rVO_Bestelldaten.GueltigAb.Date; // new DateTime(this._rVO_Bestelldaten.GueltigAb.Date.Year, this._rVO_Bestelldaten.GueltigAb.Date.Month, this._rVO_Bestelldaten.GueltigAb.Date.Day, 0, 0, 0);
                        if (calcNächsterAnspruchAb.Value.Date < DateTime.Now.Date)
                        {
                            calcNächsterAnspruchAb = calcNächsterAnspruchAb.Value;
                        }
                    }
                    calcNächsterAnspruch = true;
                }
                else
                {
                    //calcNächsterAnspruchAb = this._rVO_Bestelldaten.DatumNaechsterAnspruch.Date;
                }

                if (this._IsNew)
                {
                    if (!this.b2.checkBestellvorschlag(this._rVO_Bestelldaten, null))
                    {
                        UserAborted = true;
                        return false;
                    }
                }
                else
                {
                    if (!this.b2.checkBestellvorschlag(this._rVO_Bestelldaten, this._rVO_Bestelldaten.ID))
                    {
                        UserAborted = true;
                        return false;
                    }
                }

                if (calcNächsterAnspruch)
                {
                    List<PMDS.GUI.VB.General.cSerientermine> lstDatumNächsterAnspruch = new List<VB.General.cSerientermine>();
                    DateTime dSerienterminEndetAm = new DateTime(3000, 1, 1, 0, 0, 0);
                    this.bVB.genVODatumNaechsterAnspruch(calcNächsterAnspruchAb.Value, calcNächsterAnspruchAb.Value, this._rVO_Bestelldaten.GueltigAb .Date, this._rVO_Bestelldaten.SerienterminType, this._rVO_Bestelldaten.WiedWertJeden, this._rVO_Bestelldaten.TagWochenMonat,
                                                            this._rVO_Bestelldaten.nTenMonat, this._rVO_Bestelldaten.Wochentage, ref lstDatumNächsterAnspruch, dSerienterminEndetAm);

                    if (lstDatumNächsterAnspruch.Count == 0)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es konnte kein Datum für den nächsten Anspruch berechnet werden!" + "\r\n" +
                                                                                   "Bitte korrigieren Sie entspr. die Eingaben.", "", MessageBoxButtons.OK);
                        return false;
                        //throw new Exception("ucVOBestellungErfassen.saveData: lstDatumNächsterAnspruch.Count != 1 not allowed for IDVOBestelldaten '" + this._rVO_Bestelldaten.ID.ToString() + "'!");
                    }
                    else if (lstDatumNächsterAnspruch.Count > 1)
                    {
                        throw new Exception("ucVOBestellungErfassen.saveData: lstDatumNächsterAnspruch.Count>1 not allowed for IDVOBestelldaten '" + this._rVO_Bestelldaten.ID.ToString() + "'!");
                    }

                    this._rVO_Bestelldaten.DatumNaechsterAnspruch = lstDatumNächsterAnspruch[0].dFrom.Date;
                    dDatumNächsterAbspruchBerechnet = true;
                }


                this._db.SaveChanges();

                if (dDatumNächsterAbspruchBerechnet && ENV.adminSecure)
                {
                    string sTxtmsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestelldaten wurden gespeichert!") + "\r\n" + "\r\n";
                    sTxtmsgBox += QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächster Anspruch");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sTxtmsgBox + ": " + this._rVO_Bestelldaten.DatumNaechsterAnspruch.Value.ToString("dd.MM.yyyy"), "", MessageBoxButtons.OK, true);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.saveData: " + ex.ToString());
            }
        }

        public string getWochentage()
        {
            try
            {
                string sWochentage = "";

                if (this.cbMo.Checked)
                {
                    sWochentage += "Mo;";
                }
                if (this.cbDi.Checked)
                {
                    sWochentage += "Di;";
                }
                if (this.cbMi.Checked)
                {
                    sWochentage += "Mi;";
                }
                if (this.cbDo.Checked)
                {
                    sWochentage += "Do;";
                }
                if (this.cbFr.Checked)
                {
                    sWochentage += "Fr;";
                }
                if (this.cbSa.Checked)
                {
                    sWochentage += "Sa;";
                }
                if (this.cbSo.Checked)
                {
                    sWochentage += "So;";
                }

                return sWochentage.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.getWochentage: " + ex.ToString());
            }
        }
        public void setWochentage(string sWochentage)
        {
            try
            {
                if (sWochentage.Trim().Contains(("Mo;")))
                {
                    this.cbMo.Checked = true;
                }
                else
                {
                    this.cbMo.Checked = false;
                }
                if (sWochentage.Trim().Contains(("Di;")))
                {
                    this.cbDi.Checked = true;
                }
                else
                {
                    this.cbDi.Checked = false;
                }
                if (sWochentage.Trim().Contains(("Mi;")))
                {
                    this.cbMi.Checked = true;
                }
                else
                {
                    this.cbMi.Checked = false;
                }
                if (sWochentage.Trim().Contains(("Do;")))
                {
                    this.cbDo.Checked = true;
                }
                else
                {
                    this.cbDo.Checked = false;
                }
                if (sWochentage.Trim().Contains(("Fr;")))
                {
                    this.cbFr.Checked = true;
                }
                else
                {
                    this.cbFr.Checked = false;
                }
                if (sWochentage.Trim().Contains(("Sa;")))
                {
                    this.cbSa.Checked = true;
                }
                else
                {
                    this.cbSa.Checked = false;
                }
                if (sWochentage.Trim().Contains(("So;")))
                {
                    this.cbSo.Checked = true;
                }
                else
                {
                    this.cbSo.Checked = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.setWochentage: " + ex.ToString());
            }
        }

        public void SerienterminTypeOrTagWochenMonat_ValueChanged()
        {
            try
            {
                string sSerienterminType = "";
                if (this.optSerienterminType.Value != null)
                {
                    sSerienterminType = this.optSerienterminType.Value.ToString().Trim();
                }

                string sTagWochenMonat = "";
                if (this.opTagWochenMonat.Value != null)
                {
                    sTagWochenMonat = this.opTagWochenMonat.Value.ToString().Trim();
                }

                this.setUISerientermine(sSerienterminType, sTagWochenMonat);
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.SerienterminTypeOrTagWochenMonat_ValueChanged: " + ex.ToString());
            }
        }
        public void setUISerientermine(string SerienterminType, string TagWochenMonat)
        {
            try
            {
                if (SerienterminType.Trim() != "")
                {
                    int iSerienterminType = System.Convert.ToInt32(SerienterminType.Trim());
                    if (iSerienterminType == 1)
                    {
                        this.iWiedWertJeden.Enabled = false;
                        this.opTagWochenMonat.Enabled = false;
                        this.iNTenMonat.Enabled = false;
                        this.grpWochentage.Enabled = true;
                    }
                    else if (iSerienterminType == 2)
                    {
                        this.iWiedWertJeden.Enabled = true;
                        this.opTagWochenMonat.Enabled = true;
                        this.iNTenMonat.Enabled = false;
                        this.grpWochentage.Enabled = false;

                        if (TagWochenMonat.Trim() != "")
                        {
                            int iTagWochenMonat = System.Convert.ToInt32(TagWochenMonat.Trim());
                            if (iTagWochenMonat == 1)
                            {
                                this.grpWochentage.Enabled = true;
                            }
                            else
                            {
                                this.grpWochentage.Enabled = false;
                            }
                        }
                        else
                        {
                            this.grpWochentage.Enabled = false;
                        }
                    }
                    else if (iSerienterminType == 3)
                    {
                        this.iWiedWertJeden.Enabled = false;
                        this.opTagWochenMonat.Enabled = false;
                        this.iNTenMonat.Enabled = true;
                        this.grpWochentage.Enabled = false;
                    }
                }
                else
                {
                    this.iWiedWertJeden.Enabled = false;
                    this.opTagWochenMonat.Enabled = false;
                    this.iNTenMonat.Enabled = false;
                    this.grpWochentage.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.setUISerientermine: " + ex.ToString());
            }
        }

        public void searchMedikament()
        {
            try
            {
                PMDS.GUI.Medikament.frmSearchMedikamente frm = new Medikament.frmSearchMedikamente();
                frm.initControl();
                frm.ShowDialog(this);
                if (!frm.contSearchMedikamente1.abort)
                {
                    this._rVO_Bestelldaten.IDMedikament = frm.contSearchMedikamente1.rSelMedikament.ID;
                    this.txtMedikament.Tag = frm.contSearchMedikamente1.rSelMedikament.ID;
                    this.txtMedikament.Text = frm.contSearchMedikamente1.rSelMedikament.Bezeichnung.Trim();
                    this.cboEinheit.Text = frm.contSearchMedikamente1.rSelMedikament.Packungseinheit;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVOBestellungErfassenDetail.searchMedikament: " + ex.ToString());
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool UserAborted = false;
                if (this.saveData(ref UserAborted))
                {
                    this.abort = false;
                    if (this.mainWindow != null)
                    {
                        this.mainWindow.Close();
                    }
                }
                else
                {
                    if (UserAborted)
                    {
                        //this.abort = true;
                        //this.mainWindow.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chkDauerbestellung_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.chkDauerbestellung.Checked)
                //{
                //    this.grpSerientermin.Visible = true;
                //    this.SerienterminTypeOrTagWochenMonat_ValueChanged();
                //}
                //else
                //{
                //    this.clearSerientermineUI();
                //    this.grpSerientermin.Visible = false;
                //}

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void optSerienterminType_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SerienterminTypeOrTagWochenMonat_ValueChanged();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void opTagWochenMonat_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SerienterminTypeOrTagWochenMonat_ValueChanged();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cboTyp_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("VOT");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("VOT", this.cboTyp, null, this.cboTyp.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("VOT", this.cboTyp, null);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void cboEinheit_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("MEH");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("MEH", this.cboEinheit, null, this.cboEinheit.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("MEH", this.cboEinheit, null);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void cboLieferant_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Button.Key.Trim().ToLower().Equals(("Add").Trim().ToLower()))
                {
                    frmAuswahl frm = new frmAuswahl("LFT");
                    frm.ShowDialog();
                    List<PMDS.db.Entities.AuswahlListe> lstEmpty = null;
                    this.PMDSBusinessUI2.loadSelList("LFT", this.cboLieferant, null, this.cboLieferant.Value, ref lstEmpty);
                    PMDSBusinessUI.doSelListChanged("LFT", this.cboLieferant, null);
                }
               
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void udteGueltigAb_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.udteGueltigAb.Focused)
                {
                    if (this._rVO_Bestelldaten.EinmaligeAnforderung)
                    {
                        this.udteGueltigBis.Value = this.udteGueltigAb.Value;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void udteGueltigAb_AfterCloseUp(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this._rVO_Bestelldaten.EinmaligeAnforderung)
                {
                    this.udteGueltigBis.Value = this.udteGueltigAb.Value;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void udteGueltigBis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.udteGueltigBis.Focused)
                {
                    if (this._rVO_Bestelldaten.EinmaligeAnforderung)
                    {
                        this.udteGueltigAb.Value = this.udteGueltigBis.Value;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void udteGueltigBis_AfterCloseUp(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this._rVO_Bestelldaten.EinmaligeAnforderung)
                {
                    this.udteGueltigAb.Value = this.udteGueltigBis.Value;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSearchMedikmanete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchMedikament();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }

}
