using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.DB;
using Infragistics.Win.UltraWinToolTip;
using System.Linq;
using System.IO;

namespace PMDS.GUI.BaseControls
{


    public partial class ucMedizinDaten : QS2.Desktop.ControlManagment.BaseControl
    {
        public Guid _IDPatient;
        public Guid _IDPatientLast;

        public PMDS.db.Entities.Aufenthalt _rAufenthalt;
        public PMDS.db.Entities.UrlaubVerlauf _rUrlaubVerlaufLast;
        public PMDS.db.Entities.Patient _rPatient;
        public bool _bPatIsAbwesend = false;
        public bool _PatientHasNoAktAufenthalt = false;

        public eTypeUI _TypeUI;

        public bool _bSignalInProgress = false;

        public ucMedizinData _ucNotfall = null;
        public event NotfallSelectedDelegate NotfallSelected;

        public ucMedizinData _ucDatenschutz = null;
        public ucMedizinData _ucDNR = null;
        public ucMedizinData _ucAbwesenheit = null;
        public ucMedizinData _ucHolocoust = null;
        public ucMedizinData _ucRezeptgebührenbefreit = null;
        public ucMedizinData _ucAbwesenheitBeendet = null;
        public ucMedizinData _ucGeburtstag = null;
        public ucMedizinData _ucWunde = null;
        public ucMedizinData _ucWichtigeInformation = null;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public enum eTypeUI
        {
            //MedIcons = 0,
            MainTop = 1
        }

      
               






        public ucMedizinDaten()
        {
            InitializeComponent();

            ENV.MedizinDatenChanged         += new EventHandler(ENV_MedizinDatenChanged);
            ENV.MedizinischerStateChanged   += new MedizinischeDatenStateChangedDelegate(ENV_MedizinischerStateChanged);
        }

        void ENV_MedizinischerStateChanged(int iMedizinischerTyp)
        {
            if (this._bSignalInProgress)
                return;

            Refresh(_IDPatient, false);
        }
        void ENV_MedizinDatenChanged(object sender, EventArgs e)
        {
            initControls(this._TypeUI);
            Refresh(_IDPatient, false);
        }




        public void initControls(eTypeUI TypeUI)
        {
            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                    return;

                this._TypeUI = TypeUI;
                this.clearControls();

                this.InsertNotfallIcon();
                this.InsertSachwalterIcon();
                this.InsertFreiheitsbeschränktIcon();

                MedizinischeDatenLayout layout = new MedizinischeDatenLayout();
                MedizinischeTypen t = new MedizinischeTypen();
                int widthIco = 32;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tMedizinischeTypen = (from v in db.MedizinischeTypen
                                orderby v.Nummer ascending
                                select new
                                {
                                    ID = v.ID,
                                    Nummer = v.Nummer,
                                    MedizinischerTyp = v.MedizinischerTyp,
                                    Beschreibung = v.Beschreibung,
                                    Icon = v.Icon,
                                    IconOFF = v.IconOFF,
                                    bVisible = v.bVisible
                                });
                    
                    foreach (var rMedType in tMedizinischeTypen)
                    {
                        if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.Datenschutz))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucDatenschutz, MedizinischerTyp.Datenschutz, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.DNR))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucDNR, MedizinischerTyp.DNR, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.Holocoust))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucHolocoust, MedizinischerTyp.Holocoust, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.Rezeptgebührenbefreit))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucRezeptgebührenbefreit, MedizinischerTyp.Rezeptgebührenbefreit, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.AbwesenheitBeendet))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucAbwesenheitBeendet, MedizinischerTyp.AbwesenheitBeendet, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.Geburtstag))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucGeburtstag, MedizinischerTyp.Geburtstag, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.Wunde))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucWunde, MedizinischerTyp.Wunde, rMedType.Icon, rMedType.IconOFF, widthIco);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.Abwesenheit))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucAbwesenheit, MedizinischerTyp.Abwesenheit, rMedType.Icon, rMedType.IconOFF, 200);
                            }
                        }
                        else if (rMedType.MedizinischerTyp.Equals((int)MedizinischerTyp.WichtigeInformation))
                        {
                            if (rMedType.bVisible)
                            {
                                this.insertMedDatenIcon(ref this._ucWichtigeInformation, MedizinischerTyp.WichtigeInformation, rMedType.Icon, rMedType.IconOFF, 16);
                            }
                        }
                        else
                        {
                            if (rMedType.bVisible)
                            {
                                if (rMedType.MedizinischerTyp != 999)          // Spezielnummer: als Speicher für die Icons der offenen Standardprozeduren
                                {
                                    ucMedizinData uc = new ucMedizinData();
                                    uc.StateChanged += new MedizinischeDatenStateChangedDelegate(uc_StateChanged);
                                    uc.Init(rMedType.MedizinischerTyp);
                                    uc.ColumnsToDisplay = layout.GetColumnsToDisplay(rMedType.MedizinischerTyp);
                                    pnlMain.Controls.Add(uc);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.initControls: " + ex.ToString());
            }
        }

        public void clearControls()
        {
            try
            {
                pnlMain.Controls.Clear();

                this._ucNotfall = null;
                //this.NotfallSelected = null;

                this._ucDatenschutz = null;
                this._ucDNR = null;
                this._ucAbwesenheit = null;
                this._ucHolocoust = null;
                this._ucRezeptgebührenbefreit = null;
                this._ucAbwesenheitBeendet = null;
                this._ucGeburtstag = null;
                this._ucWunde = null;

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.clearControls: " + ex.ToString());
            }
        }

        public void Refresh(Guid IDPatient, bool clickGridTermine)
        {
            try
            {
                this._IDPatient = IDPatient;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //_rPatient = this.b.getPatient(this._IDPatient, db);

                    var rPatMedDaten = (from p in db.Patient
                                where p.ID == IDPatient
                                select new
                                {
                                    p.ID,
                                    p.Datenschutz,
                                    p.DNR,
                                    p.Palliativ,
                                    p.DNRAnmerkung,
                                    p.KZUeberlebender,

                                    p.RezeptgebuehrbefreiungJN,
                                    p.RezGebBef_RegoJN,
                                    p.RezGebBef_RegoAb,
                                    p.RezGebBef_RegoBis,
                                    p.RezGebBef_UnbefristetJN,
                                    p.RezGebBef_BefristetJN,
                                    p.RezGebBef_BefristetAb,
                                    p.RezGebBef_BefristetBis,
                                    p.RezGebBef_WiderrufJN,
                                    p.RezGebBef_WiderrufGrund,
                                    p.RezGebBef_SachwalterJN,
                                    p.RezGebBef_Anmerkung,

                                    p.Geburtsdatum
                                }).First();


                    if (ENV.IDAUFENTHALT != null)
                    {
                        _rAufenthalt = this.b.getAufenthalt(ENV.IDAUFENTHALT);
                        if (_rAufenthalt == null)
                        {
                            throw new Exception("ucMedizinDaten.Refresh: No Admission for ID " + ENV.IDAUFENTHALT.ToString());
                        }
                        else
                        {
                            _rUrlaubVerlaufLast = this.b.rAufenthaltUrlaub(_rAufenthalt, db);
                            //_PatientHasNoAktAufenthalt = this.b.rPatientHasNoAktAufenthalt(_rPatient, db);
                        }
                    }
                    else
                        throw new Exception("ucMedizinDaten.Refresh: ENV.IDAufenthalt = null!");
                

                    if ((clickGridTermine && this._IDPatientLast != System.Guid.Empty && this._IDPatientLast == this._IDPatient) || this._IDPatient.Equals(System.Guid.Empty))
                    {
                        return;
                    }

                    SP sp = new SP();
                    if (_rAufenthalt != null && sp.HasOpen(_rAufenthalt.ID))
                    {
                        this.clearMedDatenIcon(this._ucNotfall);
                        this._ucNotfall.Visible = true;                         }
                    else
                    {
                        this.clearMedDatenIcon(this._ucNotfall);
                    }

                    if (this._ucDatenschutz != null)
                    {
                        this.setDatenschutzIcon(this._ucDatenschutz, rPatMedDaten.Datenschutz);
                    }
                    if (this._ucDNR != null)
                    {
                        this.SetDNRIcon(this._ucDNR, rPatMedDaten.DNR, rPatMedDaten.Palliativ, rPatMedDaten.ID, rPatMedDaten.DNRAnmerkung);
                    }
                    if (this._ucAbwesenheit != null)
                    {
                        this.setAbwesenheitIcon(this._ucAbwesenheit, ref _rUrlaubVerlaufLast);
                    }
                    if (this._ucHolocoust != null)
                    {
                        this.setHolocaustIcon(this._ucHolocoust, rPatMedDaten.KZUeberlebender);
                    }
                    if (this._ucRezeptgebührenbefreit != null)
                    {
                        this.setRezeptgebührenbefreitIcon(this._ucRezeptgebührenbefreit, ref _rAufenthalt,

                            rPatMedDaten.RezeptgebuehrbefreiungJN,
                            rPatMedDaten.RezGebBef_RegoJN,
                            rPatMedDaten.RezGebBef_RegoAb,
                            rPatMedDaten.RezGebBef_RegoBis,
                            rPatMedDaten.RezGebBef_UnbefristetJN,
                            rPatMedDaten.RezGebBef_BefristetJN,
                            rPatMedDaten.RezGebBef_BefristetAb,
                            rPatMedDaten.RezGebBef_BefristetBis,
                            rPatMedDaten.RezGebBef_WiderrufJN,
                            rPatMedDaten.RezGebBef_WiderrufGrund,
                            rPatMedDaten.RezGebBef_SachwalterJN,
                            rPatMedDaten.RezGebBef_Anmerkung);
                    }
                    if (this._ucAbwesenheitBeendet != null)
                    {
                        this.setAbwesenheitBeendetIcon(this._ucAbwesenheitBeendet, ref _rAufenthalt, _bPatIsAbwesend);
                    }
                    if (this._ucGeburtstag != null)
                    {
                        this.setGeburtstagIcon(this._ucGeburtstag, (DateTime) rPatMedDaten.Geburtsdatum);
                    }
                    if (this._ucWunde != null)
                    {
                        this.setWundeIcon(this._ucWunde, rPatMedDaten.ID);
                    }
                    if (this._ucWichtigeInformation != null)
                    {
                        this.setWichtigeinformationenIcon(this._ucWichtigeInformation, ref _rAufenthalt);
                    }

                }
                //this.getDataPatientStandardIcons();
                foreach (ucMedizinData uc in pnlMain.Controls)
                {
                    if (!uc.IsExternControl)
                    {
                        uc.IDPATIENT = IDPatient;
                    }
                }

                this.SetToolTip();
                this._IDPatientLast = this._IDPatient;
            }
            catch (Exception ex)
            {
                this.ResumeLayout();
                throw new Exception("ucMedizinDaten.Refresh: " + ex.ToString());
            }
        }

        public void getDataPatientStandardIconsxy()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rS2_GetKlientenliste = (from kl in db.s2_GetKlientenliste(PMDS.Global.ENV.USERID.ToString(), (PMDS.Global.historie.HistorieOn == true ? 1 : 0), System.Guid.Empty.ToString())
                                                where kl.IDKlient == this._IDPatient
                                                select new
                                                {
                                                    kl.IDKlient,
                                                    kl.MT1,
                                                    kl.MT2,
                                                    kl.MT3,
                                                    kl.MT4,
                                                    kl.MT5,
                                                    kl.MT6,
                                                    kl.MT7,
                                                    kl.MT8,
                                                    kl.MT9,
                                                    kl.MT10,
                                                    kl.MT11,
                                                    kl.MT12,
                                                    kl.MT13,
                                                    kl.MT14,
                                                    kl.MT15
                                                }).ToList();

                    bool bDone = true;

                    //if (rS2_GetKlientenliste. == "Nein")
                    //{

                    //}
                    //else if (rS2_GetKlientenliste.Notfall == "Ja, kein Termin offen")
                    //{

                    //}
                    //else
                    //{
                    //    throw new Exception("getDataPatientStandardIcons: rS2_GetKlientenliste.Notfall  '" + rS2_GetKlientenliste.Notfall.Trim() + "' not allowed!");
                    //}
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.getDataPatientStandardIcons: " + ex.ToString());
            }
        }


        private void InsertSachwalterIcon()
        {
            ucMedizinData uc = new ucMedizinData();
            uc.InitAsSachwalter();

            this.pnlMain.Controls.Add(uc);
        }

        private void InsertFreiheitsbeschränktIcon()
        {
            ucMedizinData uc = new ucMedizinData();
            uc.InitAsFreiheitsbeschränkt ();

            this.pnlMain.Controls.Add(uc);
        }

        private void InsertNotfallIcon()
        {
            this._ucNotfall = new ucMedizinData();
            this._ucNotfall.NotfallIcon = true;
            this._ucNotfall.Init(999);
            this._ucNotfall.NotfallSelected += new NotfallSelectedDelegate(this._ucNotfall_NotfallSelected);
            this.pnlMain.Controls.Add(_ucNotfall);
        }
        void _ucNotfall_NotfallSelected(Guid IDSP)
        {
            if (NotfallSelected != null)
                NotfallSelected(IDSP);
        }




    private void setDatenschutzIcon(ucMedizinData ucMedizinDataAct, bool bDatenschutz)
        {
            try
            {
                if (bDatenschutz)
                {
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenschutz für Klient aktiviert!");
                    string ToolTipText = " ";
                    this.setMedDatenIcon(ucMedizinDataAct, "DS", System.Drawing.Color.Salmon, System.Drawing.Color.Black, ToolTipTitle, ToolTipText, System.Drawing.Color.White, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.insertDatenschutzIcon: " + ex.ToString());
            }
        }

        public void SetDNRIcon(ucMedizinData ucMedizinDataAct, bool bDNR, bool bPalliativ, Guid IDPatient, string DNRAnmerkung)
        {
            try
            {
                UltraToolTipInfo info = new UltraToolTipInfo();
                this.clearMedDatenIcon(ucMedizinDataAct);

                if (bDNR && !bPalliativ)
                {
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR");
                    this.setMedDatenIcon(ucMedizinDataAct, "DNR", System.Drawing.Color.Gray, System.Drawing.Color.Black, ToolTipTitle, DNRAnmerkung, System.Drawing.Color.Gray, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else if (!bDNR && bPalliativ)
                {
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Palliativ");
                    this.setMedDatenIcon(ucMedizinDataAct, "P", System.Drawing.Color.LightGray, System.Drawing.Color.Black, ToolTipTitle, DNRAnmerkung, System.Drawing.Color.Gray, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else if (bDNR && bPalliativ)
                {
                    throw new Exception("ucMedizinDaten.SetDNRIcon: bDNR && bPalliativ not allowed for Patient '" + IDPatient.ToString() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.SetToolTipDNR: " + ex.ToString());
            }
        }

        public void setAbwesenheitIcon(ucMedizinData ucMedizinDataAct, ref PMDS.db.Entities.UrlaubVerlauf rUrlaubVerlaufLast)
        {
            try
            {
                if (rUrlaubVerlaufLast != null)
                {
                    string ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient ist abwesend");
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient ist abwesend");
                    ToolTipText = rUrlaubVerlaufLast.Text.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" seit ") + String.Format("{0:dd.MM.yyyy}", rUrlaubVerlaufLast.StartDatum.Value);
                    this.setMedDatenIcon(ucMedizinDataAct, ToolTipText, System.Drawing.Color.Red, System.Drawing.Color.White, ToolTipTitle, ToolTipText, System.Drawing.Color.Red, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setAbwesenheitIcon: " + ex.ToString());
            }
        }

        private void setHolocaustIcon(ucMedizinData ucMedizinDataAct, bool bKZUeberlebender)
        {
            try
            {
                if (bKZUeberlebender)
                {
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Holocaust");
                    string ToolTipText = " ";
                    this.setMedDatenIcon(ucMedizinDataAct, "H", System.Drawing.Color.LightBlue, System.Drawing.Color.Black, ToolTipTitle, ToolTipText, System.Drawing.Color.WhiteSmoke, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setHolocaustIcon: " + ex.ToString());
            }
        }

        private void setRezeptgebührenbefreitIcon(ucMedizinData ucMedizinDataAct, ref PMDS.db.Entities.Aufenthalt rAufenthalt,
                bool RezeptgebuehrbefreiungJN,
                bool RezGebBef_RegoJN,
                DateTime? RezGebBef_RegoAb,
                DateTime? RezGebBef_RegoBis,
                bool RezGebBef_UnbefristetJN,
                bool RezGebBef_BefristetJN,
                DateTime? RezGebBef_BefristetAb,
                DateTime? RezGebBef_BefristetBis,
                bool RezGebBef_WiderrufJN,
                string RezGebBef_WiderrufGrund,
                bool RezGebBef_SachwalterJN,
                string RezGebBef_Anmerkung
            )
        {
            try
            {
                if (rAufenthalt != null)
                {
                    PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
                    string TitleRezeptgebührenbefreit = "";
                    string InfoRezeptgebührenbefreit = "";
                    bool bIsRezeptgebührenbefreit = bUI.showInfoRezeptgebührbefreiungInfo(
                        RezeptgebuehrbefreiungJN,
                        RezGebBef_RegoJN,
                        RezGebBef_RegoAb,
                        RezGebBef_RegoBis,
                        RezGebBef_UnbefristetJN,
                        RezGebBef_BefristetJN,
                        RezGebBef_BefristetAb,
                        RezGebBef_BefristetBis,
                        RezGebBef_WiderrufJN,
                        RezGebBef_WiderrufGrund,
                        RezGebBef_SachwalterJN,
                        RezGebBef_Anmerkung, 
                        ref TitleRezeptgebührenbefreit, ref InfoRezeptgebührenbefreit, false);
                    if (bIsRezeptgebührenbefreit)
                    {
   
                        string ToolTipTitle = TitleRezeptgebührenbefreit;
                        string ToolTipText = InfoRezeptgebührenbefreit;
                        this.setMedDatenIcon(ucMedizinDataAct, "RGB", System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.White, ToolTipTitle, ToolTipText, System.Drawing.Color.WhiteSmoke, Infragistics.Win.UIElementBorderStyle.Solid);
                    }
                    else
                    {
                        this.clearMedDatenIcon(ucMedizinDataAct);
                    }
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setRezeptgebührenbefreitIcon: " + ex.ToString());
            }
        }

        private void setAbwesenheitBeendetIcon(ucMedizinData ucMedizinDataAct, ref PMDS.db.Entities.Aufenthalt rAufenthalt, bool bPatIsAbwesend)
        {
            try
            {
                if (rAufenthalt != null && !bPatIsAbwesend && (rAufenthalt.AbwesenheitBeendet))
                {
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitend beendet");
                    string ToolTipText = " ";
                    this.setMedDatenIcon(ucMedizinDataAct, "Ab", System.Drawing.Color.GreenYellow, System.Drawing.Color.Black, ToolTipTitle, ToolTipText, System.Drawing.Color.LightGreen, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setAbwesenheitBeendetIcon: " + ex.ToString());
            }
        }

        private void setGeburtstagIcon(ucMedizinData ucMedizinDataAct, DateTime GebDat)
        {
            try
            {
                DateTime dNow = DateTime.Now.Date;
                DateTime dGeburtstagHeuer = new DateTime(dNow.Year, GebDat.Month, GebDat.Day, 0, 0, 0);
                if (!DateTime.IsLeapYear(dNow.Year) && dGeburtstagHeuer.Day == 29 && dGeburtstagHeuer.Month == 2)
                {
                    dGeburtstagHeuer = new DateTime(dGeburtstagHeuer.Year, dGeburtstagHeuer.Month, 28, 0, 0, 0);
                }
                if (dGeburtstagHeuer.Date.Equals(DateTime.Now.Date))
                {
                    string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtstag");
                    string ToolTipText = " ";
                    this.setMedDatenIcon(ucMedizinDataAct, "G", System.Drawing.Color.MediumVioletRed, System.Drawing.Color.White, ToolTipTitle, ToolTipText, System.Drawing.Color.LightGreen, Infragistics.Win.UIElementBorderStyle.Solid);
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setGeburtstagIcon: " + ex.ToString());
            }
        }

        private void setWundeIcon(ucMedizinData ucMedizinDataAct, Guid IDPatient)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(this._IDPatient, db);
                    var tvKlientenliste2 = (from wk in db.WundeKopf
                                            join apdx in db.AufenthaltPDx on wk.IDAufenthaltPDx equals apdx.ID
                                            join auf in db.Aufenthalt on apdx.IDAufenthalt equals auf.ID
                                            where auf.IDPatient == IDPatient && apdx.EndeDatum == null
                                            select
                                                auf.IDPatient
                                            ).Count();

                    if (tvKlientenliste2 > 0)
                    {

                        string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde");
                        string ToolTipText = " ";
                        this.setMedDatenIcon(ucMedizinDataAct, "W", System.Drawing.Color.DarkTurquoise, System.Drawing.Color.Black, ToolTipTitle, ToolTipText, System.Drawing.Color.LightGreen, Infragistics.Win.UIElementBorderStyle.Solid);

                    }
                    else 
                    {
                        this.clearMedDatenIcon(ucMedizinDataAct);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setWundeIcon: " + ex.ToString());
            }
        }

        private void setWichtigeinformationenIcon(ucMedizinData ucMedizinDataAct, ref PMDS.db.Entities.Aufenthalt rAufenthalt)
        {
            try
            {
                if (rAufenthalt != null)
                {
                    if (rAufenthalt.SofortMassnahmen.Trim() != "")
                    {
                        string sToolTipTxt = "";
                        if (rAufenthalt.SofortMassnahmen.Trim().Length > 120)
                        {
                            int iPosLZ = rAufenthalt.SofortMassnahmen.Trim().IndexOf(" ", 110);
                            if (iPosLZ != -1)
                            {
                                sToolTipTxt = rAufenthalt.SofortMassnahmen.Trim().Insert(iPosLZ, "\r\n");
                            }
                            else
                            {
                                sToolTipTxt = rAufenthalt.SofortMassnahmen.Trim();
                            }
                        }
                        else
                        {
                            sToolTipTxt = rAufenthalt.SofortMassnahmen.Trim();
                        }

                        string ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wichtige Informationen");
                        string ToolTipText = sToolTipTxt.Trim();
                        this.setMedDatenIcon(ucMedizinDataAct, "", System.Drawing.Color.White, System.Drawing.Color.Black, ToolTipTitle, ToolTipText, System.Drawing.Color.WhiteSmoke, Infragistics.Win.UIElementBorderStyle.Solid);
                    }
                    else
                    {
                        this.clearMedDatenIcon(ucMedizinDataAct);
                    }
                }
                else
                {
                    this.clearMedDatenIcon(ucMedizinDataAct);
                }
            
            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setWichtigeinformationenIcon: " + ex.ToString());
            }
        }










        public void insertMedDatenIcon(ref ucMedizinData ucMedizinData1, MedizinischerTyp MedizinischerTyp, byte[] bIco, byte[] bIcoOFF, int width = 18)
        {
            try
            {
                ucMedizinData1 = new ucMedizinData();
                ucMedizinData1._MedizinischerTyp = (int)MedizinischerTyp;
                ucMedizinData1.IsExternControl = true;

                if (bIco != null)
                {
                    using (var ms = new MemoryStream(bIco))
                    {
                        Image imgTmp = Image.FromStream(ms);
                        ucMedizinData1.imgIco = imgTmp;
                    }
                }
                if (bIcoOFF != null)
                {
                    using (var ms = new MemoryStream(bIcoOFF))
                    {
                        Image imgTmp = Image.FromStream(ms);
                        ucMedizinData1.imgIcoOff = imgTmp;
                    }
                }

                //ucMedizinData1.NotfallSelected += new NotfallSelectedDelegate(this._ucDatenschutz_Selected);
                ucMedizinData1.Width = width;
                this.pnlMain.Controls.Add(ucMedizinData1);
                this.clearMedDatenIcon(ucMedizinData1);

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.insertMedDatenIcon: " + ex.ToString());
            }
        }
        //void _ucDatenschutz_Selected(Guid IDSP)
        //{

        //}

        public void setMedDatenIcon(ucMedizinData ucMedizinData1, string txtMedDatenIcon, System.Drawing.Color BackColorTxt, System.Drawing.Color ForeColorTxt, 
                                    string ToolTipTitle, string ToolTipText, 
                                    System.Drawing.Color BackColor, Infragistics.Win.UIElementBorderStyle BorderStyle)
        {
            try
            {
                this.clearMedDatenIcon(ucMedizinData1);

                ucMedizinData1.Visible = true;
                ucMedizinData1.BackColor = BackColor;
                ucMedizinData1.ultraPictureBox1.Image = ucMedizinData1.imgIco;
                ucMedizinData1.ultraPictureBox1.BackColor = BackColor;

                UltraToolTipInfo info = new UltraToolTipInfo();
                info.ToolTipTitle = ToolTipTitle;
                info.ToolTipText = ToolTipText;

                if (ucMedizinData1.imgIco == null)
                {
                    ucMedizinData1.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    ucMedizinData1.ultraPictureBox1.Visible = false;
                    ucMedizinData1.lblTxt.Visible = true;
                    ucMedizinData1.lblTxt.BringToFront();
                    ucMedizinData1.lblTxt.Text = txtMedDatenIcon.Trim();
                    ucMedizinData1.lblTxt.Appearance.BackColor = BackColorTxt;
                    ucMedizinData1.lblTxt.Appearance.ForeColor = ForeColorTxt;

                    ucMedizinData1.ultraToolTipManager1.SetUltraToolTip(ucMedizinData1.lblTxt, info);
                }
                else
                {
                    ucMedizinData1.lblTxt.Visible = false;
                    ucMedizinData1.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    ucMedizinData1.ultraPictureBox1.BackColor = System.Drawing.Color.White;
                    ucMedizinData1.ultraPictureBox1.Visible = true;
                    ucMedizinData1.ultraPictureBox1.BringToFront();

                    ucMedizinData1.ultraToolTipManager1.SetUltraToolTip(ucMedizinData1.ultraPictureBox1, info);
                    this.BackColor = System.Drawing.Color.White;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.setMedDatenIcon: " + ex.ToString());
            }
        }
        public void clearMedDatenIcon(ucMedizinData ucMedizinData1)
        {
            try
            {
                ucMedizinData1.Visible = true;

                ucMedizinData1.SuspendLayout();
                ucMedizinData1.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
                ucMedizinData1.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                if (ucMedizinData1.imgIcoOff == null)
                {
                    ucMedizinData1.ultraPictureBox1.Image = null;
                    ucMedizinData1.ultraPictureBox1.Visible = true;
                }
                else
                {
                    ucMedizinData1.ultraPictureBox1.Image = ucMedizinData1.imgIcoOff;
                    ucMedizinData1.ultraPictureBox1.Visible = true;
                }                

                ucMedizinData1.lblTxt.Text = "";
                ucMedizinData1.lblTxt.Appearance.BackColor = System.Drawing.Color.White;
                ucMedizinData1.lblTxt.Appearance.ForeColor = System.Drawing.Color.Black;
                
                ucMedizinData1.lblTxt.Visible = false;
                //ucMedizinData1.lblTxt.BringToFront();
                ucMedizinData1.ultraPictureBox1.BringToFront();

                ucMedizinData1.BackColor = System.Drawing.Color.Transparent;
                UltraToolTipInfo info = new UltraToolTipInfo();
                info.ToolTipText = "";
                info.ToolTipTitle = "";
                ucMedizinData1.ultraToolTipManager1.SetUltraToolTip(ucMedizinData1.ultraPictureBox1, info);
                ucMedizinData1.ultraToolTipManager1.SetUltraToolTip(ucMedizinData1.lblTxt, info);
                ucMedizinData1.ResumeLayout();

            }
            catch (Exception ex)
            {
                throw new Exception("ucMedizinDaten.clearMedDatenIcon: " + ex.ToString());
            }
            finally
            {
                ucMedizinData1.ResumeLayout();
            }
        }




        public void uc_StateChanged(int iMedizinischerTyp)
        {
            try
            {
                this._bSignalInProgress = true;

                SetToolTip();
                ENV.SignalMedizinischerStateChanged(iMedizinischerTyp);
                this._bSignalInProgress = false;
            }
            catch (Exception ex)
            {
                this._bSignalInProgress = false;
                throw new Exception("ucMedizinDaten.uc_StateChanged: " + ex.ToString());
            }
        }

        private void SetToolTip()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ucMedizinData uc in pnlMain.Controls)
            {
                if (uc.ON)
                {
                    sb.Append(uc.ToString());
                    sb.Append(Environment.NewLine);
                }
            }

            UltraToolTipInfo info = new UltraToolTipInfo();
            info.ToolTipTitle = "Aktivierte Elemente";
            info.ToolTipText = info.ToString();
            this.ultraToolTipManager1.SetUltraToolTip(pnlMain, info);
        }
    }

}

