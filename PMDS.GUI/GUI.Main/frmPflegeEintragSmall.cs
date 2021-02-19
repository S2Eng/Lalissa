using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using PMDS.db.Entities;
using System.Linq;
using Infragistics.Win.UltraWinToolTip;


namespace PMDS.GUI
{


    public partial class frmPflegeEintragSmall : QS2.Desktop.ControlManagment.baseForm
    {

        public PMDS.db.Entities.PflegeEintrag rPflegeEintrag = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();

        public bool _bEdit = false;
        public bool abort = true;

        public bool _IsDekurs = false;
        public Global.db.ERSystem.dsTermine.vÜbergabeRow _rvÜbergabe = null;
        public PMDS.db.Entities.PflegePlan _rPflegePlan = null;

        public bool HasChanged = false;
        public bool HistorischerModus = true;
        public bool HistorieFound = false;








        public frmPflegeEintragSmall()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

        }
        private void frmShowText_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void InitControl()
        {
            try
            {
                this.SetEditMode(false);
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnDelete.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.FloatingText, true, false, false, false, PMDS.Global.ENV.SpellCheckerOn, false);
                this.contTXTFieldBeschreibung.delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChanged);
                this.contTXTFieldBeschreibung.bReadOnly = true;

                this.textControlHistorie.Text = "";
                this.textControlHistorie.EditMode = TXTextControl.EditMode.ReadAndSelect;

                this._db = PMDS.DB.PMDSBusiness.getDBContext();

            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegeEintragSmall.InitControl: " + ex.ToString());
            }
        }

        public void valueChanged()
        {
            this.HasChanged = true;
        }

        public void loadData(bool IsDekurs, Global.db.ERSystem.dsTermine.vÜbergabeRow rvÜbergabe)
        {
            try
            {
                this.textControlOriginal.Text = "";
                this.textControChanges.Text = "";

                if (rvÜbergabe.IDPflegeEintrag == null)
                {
                    throw new Exception("frmPflegeEintragSmall.loadData: rvÜbergabe.IDPflegeEintrag == null not allowed!");
                }
                if (rvÜbergabe.IDPflegeEintrag == System.Guid.Empty)
                {
                    throw new Exception("frmPflegeEintragSmall.loadData: rvÜbergabe.IDPflegeEintrag == System.Guid.Empty not allowed!");
                }

                this.rPflegeEintrag = this.PMDSBusiness1.getPflegeEintrag(rvÜbergabe.IDPflegeEintrag, this._db);
                if (this.rPflegeEintrag.IDPflegePlan != null)
                {
                    this._rPflegePlan = this.PMDSBusiness1.getPflegeplan((Guid)this.rPflegeEintrag.IDPflegePlan, this._db);
                }
                if (IsDekurs)
                {
                    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                    //this.Height = 559;
                }
                else
                {
                    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Eintrag");
                }

                this.txtMassnahme.Text = rvÜbergabe.Maßnahme.Trim();
                byte[] b = null;
                if (this.rPflegeEintrag.TextRtf.Trim() == "")
                {
                    this.doEditor1.showText(this.rPflegeEintrag.Text.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                                this.textControChanges, ref b, ref b);

                    this.doEditor1.showText(this.rPflegeEintrag.Text.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                            this.textControlOriginal, ref b, ref b);
                }
                else
                {
                    this.doEditor1.showText(this.rPflegeEintrag.TextRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                                this.textControChanges, ref b, ref b);

                    this.doEditor1.showText(this.rPflegeEintrag.TextRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                            this.textControlOriginal, ref b, ref b);
                }

                bool bAutoHistModus = false;
                if (this.textControChanges.Text.Trim().ToLower().Contains(("<Geändert von>").Trim().ToLower()))
                {
                    int iPosOrig = this.textControChanges.Text.Trim().IndexOf(("<Geändert von>").Trim());
                    string txtRtfToEdit = this.textControChanges.Text.Trim().Substring(0, iPosOrig);
                    this.textControChanges.Text = this.textControChanges.Text.Remove(iPosOrig, this.textControChanges.Text.Length - iPosOrig);

                    byte[] txtOrigIntFormat = null;
                    this.textControChanges.Save(out txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                    this.contTXTFieldBeschreibung.TXTControlField.Load(txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);

                    this.doEditor1.showText(this.rPflegeEintrag.TextRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                                                this.textControlHistorie, ref b, ref b);

                    this.HistorieFound = true;
                    bAutoHistModus = true;
                }
                else
                {
                    byte[] txtOrigIntFormat = null;
                    this.textControChanges.Save(out txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                    this.contTXTFieldBeschreibung.TXTControlField.Load(txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                }

                this.textControChanges.Text = "";
                this.btnEdit.Visible = false;
                //if (this.rPflegeEintrag.EintragsTyp == (int)PMDS.Global.PflegeEintragTyp.DEKURS)
                //{

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                bool UserCanEdit = PMDSBusiness1.UserCanEdit((Guid)this.rPflegeEintrag.IDBenutzer, (PMDS.Global.PflegeEintragTyp)this.rPflegeEintrag.EintragsTyp);
                this.btnEdit.Visible = UserCanEdit;
                if (UserCanEdit)
                {
                    this.HistorischerModus = true;
                    if (bAutoHistModus)
                    {
                        this.HistorischerModus = true;
                    }
                    if (this.HistorischerModus && !PMDS.Global.ENV.adminSecure)
                    {
                        this.btnDelete.Visible = false;
                    }
                    else
                    {
                        this.btnDelete.Visible = true;
                    }
                }
                else
                {
                    this.btnDelete.Visible = false;
                }
                //}

                this.ucZusatzWert1.listControlsEF = new System.Collections.ArrayList();
                if (this.rPflegeEintrag.IDDekurs != null && this.rPflegeEintrag.IDDekurs != System.Guid.Empty)
                {
                    IQueryable<db.Entities.PflegeEintrag> tPflegeEintrag = this._db.PflegeEintrag.Where(o => o.ID == this.rPflegeEintrag.IDDekurs);
                    if (tPflegeEintrag.Count() == 1)
                    {
                        db.Entities.PflegeEintrag rPflegeEintragOrig = tPflegeEintrag.First();
                        if (rPflegeEintragOrig.IDEintrag != null)
                        {
                            this.panelZusatz.Visible = true;
                            this.ucZusatzWert1.showZusatzwerteEF(rPflegeEintragOrig.IDEintrag.Value, rPflegeEintragOrig.ID, this._db, this, rPflegeEintragOrig.IDAufenthalt);
                            this.ucZusatzWert1.setEditOnOff(false);
                        }
                    }
                }
                else
                {
                    if (this.rPflegeEintrag.IDEintrag != null)
                    {
                        this.panelZusatz.Visible = true;
                        this.ucZusatzWert1.showZusatzwerteEF(this.rPflegeEintrag.IDEintrag.Value, this.rPflegeEintrag.ID, this._db, this, this.rPflegeEintrag.IDAufenthalt);
                        this.ucZusatzWert1.setEditOnOff(false);
                    }
                }

                this.HasChanged = false;

                string sInfoKopien = "";
                int iAnzahlKopien = this.PMDSBusiness1.checkIDGruppenExistsForIDPER(this.rPflegeEintrag.ID, this._db, ref sInfoKopien);
                this.chkSaveForAllCC.Visible = iAnzahlKopien > 0;
                if (iAnzahlKopien > 0)
                {
                    UltraToolTipInfo info = new UltraToolTipInfo();
                    info.ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Info Kopien");
                    info.ToolTipText = sInfoKopien;
                    this.ultraToolTipManager1.SetUltraToolTip(this.chkSaveForAllCC, info);
                    this.SetEditMode(true);
                    this.chkSaveForAllCC.Checked = true;
                    this.SetEditMode(false);
                }
                else
                {
                    this.ultraToolTipManager1.SetUltraToolTip(this.chkSaveForAllCC, null);
                }

                //if (!bError && !ucZusatzWert1.ValidateFields() && chkDone.Checked)
                //{
                //    bError = true;
                //}

                //if (ucZusatzWert1.HAS_ADDITIONAL_VALUES)
                //    ucZusatzWert1.UpdateDATA();

                //Eintrag.Write();
                //if (ucZusatzWert1.HAS_ADDITIONAL_VALUES)
                //    ucZusatzWert1.Write();
                //_editinprogress = false;


            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegeEintragSmall.loadData: " + ex.ToString());
            }
        }
        public bool SaveData()
        {
            try
            {
                if (!this.HasChanged)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dekurs wurde nicht geändert!" + "\r\n" + "(Es wurde nichts gespeichert)", "Speichern");
                    return false;
                }

                if (!ucZusatzWert1.ValidateFields())
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zusatzwerte richtig ausfüllen!" + "\r\n" + "(Es wurde nichts gespeichert)", "Speichern");
                    return false;
                }

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                string sChangedFromAt = QS2.Desktop.ControlManagment.ControlManagment.getRes("<Geändert von> ") + rUsr.Benutzer1.Trim() +
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ") + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");

                this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                string txtBreakNewLineBreak2 = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlLineBreak);
                this.textControlLineBreak.Text = "";

                if (this.HistorischerModus)
                {
                    //string sLine = "------------------- Historie --------------------------------------------";
                    this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                    //this.doEditor1.appendText2(sLine, this.textControlLineBreak, TXTextControl.StringStreamType.PlainText);
                    //this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                    string txtBreakNewLineBreak = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlLineBreak);

                    string txtBeschreibungRtfNew = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                    string txtBeschreibungPlainNew = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTFieldBeschreibung.TXTControlField);
                    //string txtBeschreibungRtfOrig = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlOriginal);
                    string txtBeschreibungRtfHistory = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlOriginal);
                    //string txtBeschreibungPlainOrig = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControlOriginal);

                    this.textControSave.Text = "";
                    //if (this.HasChanged)
                    //{
                    this.doEditor1.appendText2(txtBeschreibungRtfNew, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    this.doEditor1.appendText2(sChangedFromAt, this.textControSave, TXTextControl.StringStreamType.PlainText);
                    this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    this.doEditor1.appendText2(txtBeschreibungRtfHistory, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.appendText2(txtBeschreibungRtfOrig, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.appendText2(rtfTextChanged.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);

                }
                else
                {
                    string txtBeschreibungRtfNew = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                    this.doEditor1.appendText2(txtBeschreibungRtfNew, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                }

                //this.doEditor1.appendText2(txtBreakNewLineBreak2.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                //this.doEditor1.appendText2(sChangedFromAt, this.textControSave, TXTextControl.StringStreamType.PlainText);

                string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControSave);
                string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControSave);
                this.rPflegeEintrag.Text = txtBeschreibungPlainTmp;
                this.rPflegeEintrag.TextRtf = txtBeschreibungPlainRtf;

                //}
                //else
                //{
                //    this.doEditor1.appendText2(txtBreakNewLineBreak2.Trim(), this.contTXTFieldBeschreibung.TXTControlField, TXTextControl.StringStreamType.RichTextFormat);
                //    this.doEditor1.appendText2(sChangedFromAt, this.contTXTFieldBeschreibung.TXTControlField, TXTextControl.StringStreamType.PlainText);

                //    string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                //    string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTFieldBeschreibung.TXTControlField);
                //    this.rPflegeEintrag.Text = txtBeschreibungPlainTmp;
                //    this.rPflegeEintrag.TextRtf = txtBeschreibungPlainRtf;
                //}

                this._db.SaveChanges();

                if (this.chkSaveForAllCC.Checked && this.rPflegeEintrag.IDGruppe != null)
                {
                    this.saveDataGroup(this.rPflegeEintrag.IDGruppe.Value, this.rPflegeEintrag.ID, this.rPflegeEintrag.TextRtf, this.rPflegeEintrag.Text, this._db);
                }

                if (this.ucZusatzWert1.Visible && this.ucZusatzWert1.listControlsEF.Count > 0)
                {
                    if (this.rPflegeEintrag.IDDekurs != null && this.rPflegeEintrag.IDDekurs != System.Guid.Empty)
                    {
                        IQueryable<db.Entities.PflegeEintrag> tPflegeEintrag = this._db.PflegeEintrag.Where(o => o.ID == this.rPflegeEintrag.IDDekurs);
                        if (tPflegeEintrag.Count() == 1)
                        {
                            db.Entities.PflegeEintrag rPflegeEintragOrig = tPflegeEintrag.First();
                            this.ucZusatzWert1.saveZusatzwerteEF(rPflegeEintragOrig.ID, this._db);
                        }
                    }
                    else
                    {
                        this.ucZusatzWert1.saveZusatzwerteEF(this.rPflegeEintrag.ID, this._db);
                        //if (this.chkSaveForAllCC.Checked)
                        //{
                        //    PMDSBusiness1.copyUpdateZusatzwertePEIDGruppe(this.rPflegeEintrag.ID, this._db);
                        //}
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegeEintragSmall.SaveData: " + ex.ToString());
            }
        }
        public void saveDataGroup(Guid IDGruppe, Guid IDPENot, string txtRtfxy, string txtPlainxy, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                string sChangedFromAt = QS2.Desktop.ControlManagment.ControlManagment.getRes("<Geändert von> ") + rUsr.Benutzer1.Trim() +
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ") + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");

                this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                string txtBreakNewLineBreak2 = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlLineBreak);
                this.textControlLineBreak.Text = "";

                this.doEditor1.insertLinebreakxy(this.textControlLineBreak);
                string txtBreakNewLineBreak = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlLineBreak);

                string txtBeschreibungRtfNew = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                string txtBeschreibungPlainNew = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTFieldBeschreibung.TXTControlField);
         
                IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintrag = db.PflegeEintrag.Where(b => b.IDGruppe == IDGruppe && b.ID != IDPENot);
                if (tPflegeEintrag.Count() > 0)
                {
                    foreach (PMDS.db.Entities.PflegeEintrag rPE in tPflegeEintrag)
                    {
                        this.contTXTFieldBeschreibung.TXTControlField.Text = "";
                        this.textControlHistorie.Text = "";
                        this.textControlOriginal.Text = "";
                        this.textControChanges.Text = "";
                        this.textControlHistorie.Text = "";
                        this.textControSave.Text = "";

                        byte[] b = null;
                        if (rPE.TextRtf.Trim() == "")
                        {
                            this.doEditor1.showText(rPE.Text.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                                                        this.textControChanges, ref b, ref b);

                            this.doEditor1.showText(rPE.Text.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                                                        this.textControlOriginal, ref b, ref b);
                        }
                        else
                        {
                            this.doEditor1.showText(rPE.TextRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                                                        this.textControChanges, ref b, ref b);

                            this.doEditor1.showText(rPE.TextRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                                                        this.textControlOriginal, ref b, ref b);
                        }

                        if (this.textControChanges.Text.Trim().ToLower().Contains(("<Geändert von>").Trim().ToLower()))
                        {
                            int iPosOrig = this.textControChanges.Text.Trim().IndexOf(("<Geändert von>").Trim());
                            string txtRtfToEdit = this.textControChanges.Text.Trim().Substring(0, iPosOrig);
                            this.textControChanges.Text = this.textControChanges.Text.Remove(iPosOrig, this.textControChanges.Text.Length - iPosOrig);

                            byte[] txtOrigIntFormat = null;
                            this.textControChanges.Save(out txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                            this.contTXTFieldBeschreibung.TXTControlField.Load(txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);

                            this.doEditor1.showText(rPE.TextRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                                                        this.textControlHistorie, ref b, ref b);

                            this.HistorieFound = true;
                        }
                        else
                        {
                            byte[] txtOrigIntFormat = null;
                            this.textControChanges.Save(out txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                            this.contTXTFieldBeschreibung.TXTControlField.Load(txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                        }

                        string txtBeschreibungRtfHistory = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlOriginal);

                        this.textControSave.Text = "";
                        this.doEditor1.appendText2(txtBeschreibungRtfNew, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                        this.doEditor1.appendText2(sChangedFromAt, this.textControSave, TXTextControl.StringStreamType.PlainText);
                        this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                        this.doEditor1.appendText2(txtBreakNewLineBreak.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                        this.doEditor1.appendText2(txtBeschreibungRtfHistory, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);

                        string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControSave);
                        string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControSave);
                        rPE.Text = txtBeschreibungPlainTmp;
                        rPE.TextRtf = txtBeschreibungPlainRtf;
                    }
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegeEintragSmall.saveDataGroup: " + ex.ToString());
            }
        }

        public bool deleteData()
        {
            try
            {
                this._db.PflegeEintrag.Remove(this.rPflegeEintrag);
                this._db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegeEintragSmall.deleteData: " + ex.ToString());
            }
        }
        public void SetEditMode(bool bEdit)
        {
            try
            {
                this._bEdit = bEdit;

                if (bEdit)
                {
                    if (this.HistorischerModus)
                    {
                        if (this.HistorieFound)
                        {
                            //this.contTXTFieldBeschreibung.TXTControlField.Text = "";
                        }
                    }
                    else
                    {

                    }
                    this.contTXTFieldBeschreibung.TXTControlField.EditMode = TXTextControl.EditMode.Edit;
                }
                else
                {
                    this.contTXTFieldBeschreibung.TXTControlField.EditMode = TXTextControl.EditMode.ReadOnly;
                }
                this.contTXTFieldBeschreibung.bReadOnly = !bEdit;
                this.btnSave.Enabled = bEdit;

                if (this.ucZusatzWert1.Visible && this.ucZusatzWert1.listControlsEF.Count > 0)
                {
                    this.ucZusatzWert1.setEditOnOff(bEdit);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPflegeEintragSmall.SetEditMode: " + ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.SetEditMode(true);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.SaveData())
                {
                    this.SetEditMode(false);
                    this.abort = false;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Close();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.deleteData())
                {
                    this.SetEditMode(false);
                    this.abort = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmPflegeEintragSmall_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.loadData(this._IsDekurs, this._rvÜbergabe);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }

        }

        private void btnDekursEntwurfErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string txtDekursActuell = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                GuiAction.PatientVermerk(PMDS.Global.ENV.CurrentIDPatient, null, Global.eDekursherkunft.DekursAusÜbergabe, contTXTFieldBeschreibung.TXTControlField.Text, false, true, null, false, "Fct. btnDekursEntwurfErstellenAs_Click", false, txtDekursActuell);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnDekursEntwurfErstellenAs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string txtDekursActuell = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                GuiAction.PatientVermerk(PMDS.Global.ENV.CurrentIDPatient, null, Global.eDekursherkunft.DekursAusÜbergabe, contTXTFieldBeschreibung.TXTControlField.Text, false, true, null, false, "Fct. btnDekursEntwurfErstellenAs_Click", true, txtDekursActuell);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void chkSaveForAllCC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void chkSaveForAllCC_BeforeCheckStateChanged(object sender, CancelEventArgs e)
        {
            try
            {
                if (!this._bEdit)
                {
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}



