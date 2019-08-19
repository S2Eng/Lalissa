using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using PMDS.Data.PflegePlan;
using PMDS.Global;



namespace PMDS.GUI
{


    public partial class frmEditZiel : QS2.Desktop.ControlManagment.baseForm
    {
        public Guid IDPE;
        public PMDS.db.Entities.PflegeEintrag rPflegeEintrag = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public PMDS.db.Entities.ERModellPMDSEntities db = null;
        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();

        public bool _bEdit = false;
        public bool abort = true;

        public bool _IsDekurs = false;
        public dsPflegeEintrag.PflegeEintragRow _rPE = null;
        public PMDS.db.Entities.PflegePlan _rPflegePlan = null;

        public bool HasChanged = false;
        //public bool HistorischerModus = true;
        public bool HistorieFound = false;

        public byte[] _txtOrigIntFormat = null;
        public string _sEvalStatus = "";

        public ucZielEvaluierung mainWindow = null;







        public frmEditZiel()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;

            if (!DesignMode)
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
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                this.contTXTFieldBeschreibung.initControl(TXTextControl.ViewMode.FloatingText, true, false, false, false, PMDS.Global.ENV.SpellCheckerOn, false);
                this.contTXTFieldBeschreibung.delonValueChanged += new QS2.Desktop.Txteditor.contTXTField.onValueChanged(this.valueChanged);
                this.contTXTFieldBeschreibung.bReadOnly = true;

                this.textControlHistorie.Text = "";
                this.textControlHistorie.EditMode = TXTextControl.EditMode.ReadAndSelect;

                this.db = PMDS.DB.PMDSBusiness.getDBContext();
                this.SetEditMode(false);

            }
            catch (Exception ex)
            {
                throw new Exception("frmEditZiel.InitControl: " + ex.ToString());
            }
        }

        public void valueChanged()
        {
            this.HasChanged = true;
        }


        public void loadData(Guid IDPE)
        {
            try
            {
                this.SetEditMode(true);
                this.textControlOriginal.Text = "";
                this.textControChanges.Text = "";

                this.rPflegeEintrag = this.PMDSBusiness1.getPflegeEintrag(IDPE, this.db);
                if (this.rPflegeEintrag.IDPflegePlan == null)
                {
                    throw new Exception("frmEditZiel.loadData: not allowed!");
                }
                this._rPflegePlan = this.PMDSBusiness1.getPflegeplan((Guid)this.rPflegeEintrag.IDPflegePlan, this.db);


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

                this.textControlOriginal.Save(out this._txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                this.contTXTFieldBeschreibung.TXTControlField.Load(this._txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);

                b = null;
                if (this.rPflegeEintrag.TextHistorieRtf.Trim() != "")
                {
                    this.doEditor1.showText(this.rPflegeEintrag.TextHistorieRtf.Trim(), TXTextControl.StreamType.RichTextFormat, false, TXTextControl.ViewMode.Normal,
                        this.textControlHistorie, ref b, ref b);
                }
                else
                {
                    this.doEditor1.showText(this.rPflegeEintrag.TextHistorie.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                                                this.textControlHistorie, ref b, ref b);
                }

                this.textControChanges.Text = "";
                this.STATUS = (ZielEvaluierungsStatus)this.rPflegeEintrag.EvalStatus.Value;

                this._sEvalStatus = QS2.Desktop.ControlManagment.ControlManagment.getRes("Eval.Status: ") + this.optEvaluierungsStatus1.CheckedItem.DisplayText.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" und ") +
                    this.optEvaluierungsStatus2.CheckedItem.DisplayText.Trim();

                if ((ENV.HasRight(UserRights.EvaluierungDurchfuehren) && this.rPflegeEintrag.DatumErstellt.Value.AddHours(24) >= DateTime.Now) || PMDS.Global.ENV.adminSecure) 
                    this.SetEditMode(true);
                else
                    this.SetEditMode(false);                

            }
            catch (Exception ex)
            {
                throw new Exception("frmEditZiel.loadData: " + ex.ToString());
            }
        }
        public ZielEvaluierungsStatus STATUS
        {
            get
            {
                return (ZielEvaluierungsStatus)((optEvaluierungsStatus1.CheckedIndex + 1) * 100 + optEvaluierungsStatus2.CheckedIndex + 1);
            }
            set
            {
                int status = (int)value;
                optEvaluierungsStatus1.CheckedIndex = (status / 100) - 1;
                optEvaluierungsStatus2.CheckedIndex = (status % 100) - 1;
            }
        }


        private bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            bool bfalse = (optEvaluierungsStatus1.CheckedIndex != -1 || optEvaluierungsStatus2.CheckedIndex != -1) && (optEvaluierungsStatus1.CheckedIndex == -1 || optEvaluierungsStatus2.CheckedIndex == -1);
            GuiUtil.ValidateField(optEvaluierungsStatus2, !bfalse, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte ausfüllen"), ref bError, bInfo, errorProvider1);

            return !bError;
        }
        public bool SaveData()
        {
            try
            {
                if (!this.HasChanged)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ziel wurde nicht geändert!" + "\r\n" + "(Es wurde nichts gespeichert)", "Speichern");
                    return false;
                }

                //bool bfalse = false;
                //bool bError = false;
                //bool bInfo = true;
                //GuiUtil.ValidateField(optEvaluierungsStatus2, !bfalse, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte ausfüllen"), ref bError, bInfo, errorProvider1);
                //if (bError)
                //{
                //    return false;
                //}

                if (!this.ValidateFields())
                {
                    return false;
                }

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();

                //string sEvalStatus = QS2.Desktop.ControlManagment.ControlManagment.getRes("Eval.Status: ") + this.optEvaluierungsStatus1.CheckedItem.DisplayText.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" und ") + 
                //                    this.optEvaluierungsStatus2.CheckedItem.DisplayText.Trim();

                string sChangedFromAt = "\r\n" + QS2.Desktop.ControlManagment.ControlManagment.getRes("<Geändert von> ") + ENV.LoginInNameFrei.Trim() +
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ") + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss") + " \r\n" + this._sEvalStatus;   


                string txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);
                //string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.contTXTFieldBeschreibung.TXTControlField);

                this.textControSave.Text = "";
                //string sPrefixTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung für Ziel ") + this._rPflegePlan.Text.Trim() + ": ";
                //this.doEditor1.appendText2(sPrefixTxt, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                this.doEditor1.appendText2(txtBeschreibungPlainRtf, this.textControSave, TXTextControl.StringStreamType.RichTextFormat);

                txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControSave);
                string txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControSave);

                this.rPflegeEintrag.Text = txtBeschreibungPlainTmp;
                this.rPflegeEintrag.TextRtf = txtBeschreibungPlainRtf;
                this.rPflegeEintrag.EvalStatus = (int)STATUS;


                // Save History
                this.textControSave.Text = "";
                string txtBeschreibungPlainRtfHistorie = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlHistorie);

                byte[] b = null;
                //string sLine = "------------------- Historie --------------------------------------------";
                //this.doEditor1.insertLinebreakxy(this.textControSave);
                //this.doEditor1.showText(sLine.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal,
                //                        this.textControSave, ref b, ref b);
                //this.doEditor1.insertLinebreakxy(this.textControSave);
                this.doEditor1.appendText2(sChangedFromAt.Trim(), this.textControSave, TXTextControl.StringStreamType.PlainText);
                this.doEditor1.insertLinebreakxy(this.textControSave);

                //this.doEditor1.showText("", TXTextControl.StreamType.InternalFormat, false, TXTextControl.ViewMode.PageView, this.textControlOriginal, ref this._txtOrigIntFormat, ref b);
                string txtBeschreibungPlainRtfOrig = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControlOriginal);
                this.doEditor1.appendText2(txtBeschreibungPlainRtfOrig.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);

                this.doEditor1.insertLinebreakxy(this.textControSave);
                this.doEditor1.appendText2(txtBeschreibungPlainRtfHistorie.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);
                //this.doEditor1.appendText2(txtBeschreibungPlainTmp.Trim(), this.textControSave, TXTextControl.StringStreamType.RichTextFormat);

                txtBeschreibungPlainRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControSave);
                txtBeschreibungPlainTmp = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControSave);

                this.rPflegeEintrag.TextHistorie = txtBeschreibungPlainTmp;
                this.rPflegeEintrag.TextHistorieRtf = txtBeschreibungPlainRtf;

                this.db.SaveChanges();

                //string PflegeplanTextTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung");
                //string TxtTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung für Ziel ") + this.rPflegeEintrag.Text.Trim();
                //this.mainWindow.speichernPflegeeintrag(PflegeEintragTyp.EVALUIERUNG, PflegeplanTextTmp, TxtTmp, STATUS);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("frmEditZiel.SaveData: " + ex.ToString());
            }
        }

        public bool deleteData()
        {
            try
            {
                this.db.PflegeEintrag.Remove(this.rPflegeEintrag);
                this.db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmEditZiel.deleteData: " + ex.ToString());
            }
        }
        public void SetEditMode(bool bEdit)
        {
            try
            {
                this._bEdit = bEdit;

                this.contTXTFieldBeschreibung.bReadOnly = !bEdit;
                this.btnSave.Enabled = bEdit;

                //if (bEdit)
                //{
                //    if (this.HistorischerModus)
                //    {
                //        if (this.HistorieFound)
                //        {
                //            this.contTXTFieldBeschreibung.TXTControlField.Text = "";
                //        }
                //    }
                //    else
                //    {

                //    }
                //    this.contTXTFieldBeschreibung.TXTControlField.EditMode = TXTextControl.EditMode.Edit;
                //}
                //else
                //{
                //    this.contTXTFieldBeschreibung.TXTControlField.EditMode = TXTextControl.EditMode.ReadOnly;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("frmEditZiel.SetEditMode: " + ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.SaveData())
                {
                    //this.SetEditMode(false);
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

        private void frmPflegeEintragSmall_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.loadData(this.IDPE);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }

        }

        private void optEvaluierungsStatus1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.optEvaluierungsStatus1.Focused)
                {
                    this.valueChanged();
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
        private void optEvaluierungsStatus2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.optEvaluierungsStatus2.Focused)
                {
                    this.valueChanged();
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

    }
}



