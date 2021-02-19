using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;
using PMDS.DB;
using System.Linq;
using PMDS.Global.Remote;
using System.Runtime.InteropServices;

namespace PMDS.GUI
{


    public partial class frmPatientRueckmeldungLine : QS2.Desktop.ControlManagment.baseForm
    {
        public List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> _ar = null;
        public static bool IsSchnellr�ckmeldung = false;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();


        [DllImport("user32")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("User32", EntryPoint = "BringWindowToTop")]
        private static extern bool BringWindowToTop(IntPtr wHandle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static int maxLinesSR = 100;     //NMaximale Anzahl der Ma�nahmen in der Liste -- wegen OutOfMemoryExeption








        public frmPatientRueckmeldungLine(List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> ar)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                InitializeComponent();

                if (!DesignMode)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                }

                this._ar = ar;
            }
            catch (Exception ex)
            {
                this.TopMost = false;
                this.Visible = false;
                ENV.HandleException(ex);
            }
        }

        public frmPatientRueckmeldungLine()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                InitializeComponent();
                if (!DesignMode)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                }


            }
            catch (Exception ex)
            {
                this.TopMost = false;
                this.Visible = false;
                ENV.HandleException(ex);
            }
        }

        private void toTop()
        {
            IntPtr hWndActive = FindWindow(null, "PMDS Starter");
            bool b1 = SetForegroundWindow(hWndActive);
            bool b2 = BringWindowToTop(hWndActive);

            this.TopMost = true;
            this.BringToFront();
        }

        public void InitControlsxy(System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> ar)
        {

            try
            {
                pnlMain.SuspendLayout();
                
                int iCount = ar.Count;
                ar.Reverse();
                DateTime Terminzeitpunkt = DateTime.Now;

                //////////////////////////////////////////////////////////////////////////////////////////////
//                pnlMain.Controls.Clear();

                int lastIndex = 1;
                int maxIndex = this.pnlMain.Controls.Count;
                foreach (Control c in pnlMain.Controls)
                    c.Visible = false;

                /////////////////////////////////////////////////////////////////////////////////

                //foreach (dsTermine.PflegePlanRow r in ar)
                //{

                //    if (lastIndex <= maxIndex - 1)
                //    {
                //        ucPflegeEintragExLine uc = (ucPflegeEintragExLine)pnlMain.Controls[lastIndex];

                //        Patient pat = new Patient(r.IDPatient);
                //        bool bOptional = false;                     // Optionaler R�ckmeldetext verarbeiten

                //        if (!r.IsIDNull())
                //            bOptional = PMDS.BusinessLogic.PflegePlan.IsRMOptional(r.ID) || ENV.ABTEILUNG_RMOPTIONAL;
                //        uc.RM_OPTIONAL = bOptional;

                //        if (r.OhneZeitBezug)
                //            Terminzeitpunkt = DateTime.Now;
                //        else
                //            Terminzeitpunkt = r.TerminZeitpunkt;

                //        PflegeEintrag pe = GuiAction.NewPflegeEintragByRow(r, Terminzeitpunkt);

                //        uc.TabIndex = iCount--;
                //        uc.FinishAfterCreate = r.EinmaligJN;    // Einmalige M dann anschlie�end beenden
                //        uc.Eintrag = pe;
                //        uc.EnableEditTime = true;
                //        uc.Dock = DockStyle.Top;
                //        uc.INFOTEXT = pat.FullName;
                //        if (r.EintragsTyp == (int)PflegeEintragTyp.TERMIN)
                //            uc.SetTerminString(r.Text);
                //        uc.ResizeThis();                            // die gr��e anpassen
                //        uc.Visible = true;

                //        lastIndex += 1;

                //    }
                //    else
                //    {

                //        ucPflegeEintragExLine uc = new ucPflegeEintragExLine();

                //        Patient pat = new Patient(r.IDPatient);
                //        bool bOptional = false;                     // Optionaler R�ckmeldetext verarbeiten

                //        if (!r.IsIDNull())
                //            bOptional = PMDS.BusinessLogic.PflegePlan.IsRMOptional(r.ID) || ENV.ABTEILUNG_RMOPTIONAL;
                //        uc.RM_OPTIONAL = bOptional;

                //        if (r.OhneZeitBezug)
                //            Terminzeitpunkt = DateTime.Now;
                //        else
                //            Terminzeitpunkt = r.TerminZeitpunkt;

                //        PflegeEintrag pe = GuiAction.NewPflegeEintragByRow(r, Terminzeitpunkt);

                //        uc.TabIndex = iCount--;
                //        uc.FinishAfterCreate = r.EinmaligJN;    // Einmalige M dann anschlie�end beenden
                //        uc.Eintrag = pe;
                //        uc.EnableEditTime = true;
                //        uc.Dock = DockStyle.Top;
                //        uc.INFOTEXT = pat.FullName;
                //        if (r.EintragsTyp == (int)PflegeEintragTyp.TERMIN)
                //            uc.SetTerminString(r.Text);
                //        uc.ResizeThis();                            // die gr��e anpassen
                //        this.pnlMain.Controls.Add(uc);
                //    }
                //}

                int aktRow = 0;
                PMDS.DB.PMDSBusiness dbBusiness = new DB.PMDSBusiness();

                foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rIntervention in ar)
                {
                    if (aktRow <= maxLinesSR)
                    {
                        //if (rIntervention.Eintragstyp != 1)     //Keine Termine in der Schnellr�ckmeldung
                        //    continue;

                        if (!dbBusiness.UserCanSign(rIntervention.IDBerufsstand))   //Keine nicht abzeichenbaren Ma�nahmen in der Liste
                            continue;

                        ucPflegeEintragExLine uc;

                        if (lastIndex <= maxIndex - 1)
                        {
                            uc = (ucPflegeEintragExLine)pnlMain.Controls[lastIndex];
                            uc.Visible = true;
                            lastIndex += 1;
                        }
                        else
                        {
                            System.Diagnostics.Debug.Print(aktRow.ToString());
                            System.Diagnostics.Debug.Print(DateTime.Now.ToString("hh:mm.ss.ffff"));
                            uc = new ucPflegeEintragExLine();
                            System.Diagnostics.Debug.Print(DateTime.Now.ToString("hh:mm.ss.ffff"));
                            uc.initControl(false, true, false, eDekursherkunft.MassnahmenR�ckmeldungAusIntervention);
                            uc.Dock = DockStyle.Top;
                            uc.setUIPanelBeschreibungSchnellR�ckmeldung();
                            this.pnlMain.Controls.Add(uc);
                            System.Diagnostics.Debug.Print(DateTime.Now.ToString("hh:mm.ss.ffff"));
                        }

                        uc.ResetIgnoreLine();
                        uc.ResetMorgenWieder();

                        uc.auswahlGruppeComboMulti1.clearSelectedNodes();

                        uc.RM_OPTIONAL = PMDS.BusinessLogic.PflegePlan.IsRMOptional(rIntervention.IDPflegeplan) || ENV.ABTEILUNG_RMOPTIONAL;
                        uc._IsBefund = !rIntervention.IsIDBefundNull();
                        Terminzeitpunkt = (rIntervention.OhneZeitbezugJN || !rIntervention.IsIDBefundNull() ? DateTime.Now : rIntervention.Startdatum);

                        if (rIntervention.Eintragstyp == 4)
                        {
                            uc.Eintrag = PflegeEintrag.NewByTermin(rIntervention.IDAufenthalt, rIntervention.IDPflegeplan,  Terminzeitpunkt, false);
                            uc.Eintrag.EintragsTyp = PflegeEintragTyp.TERMIN;
                        }
                        else if (rIntervention.Eintragstyp == 1)
                        {
                            uc.Eintrag = PflegeEintrag.NewByPflegePlan(rIntervention.IDAufenthalt, rIntervention.IDPflegeplan, rIntervention.IDEintrag, Terminzeitpunkt, false);
                            uc.Eintrag.EintragsTyp = PflegeEintragTyp.MASSNAHME;
                        }


                        uc.TabIndex = iCount--;
                        uc.FinishAfterCreate = rIntervention.EinmaligJN;     // Einmalige M dann anschlie�end beenden
                        uc.EnableEditTime = true;
                        uc.INFOTEXT = rIntervention.Klient;
                        uc.SetTerminString(rIntervention.Ma�nahme, true);
                        uc.UpdateGUI();
                        uc.ClearErrorProvider();
                        uc.RequiredFields();
                        uc.ResizeThis(ref aktRow);                            // die Gr��e anpassen                          
                        aktRow++;
                    }
                    else
                    {
                        aktRow++;
                        continue;
                    }
                }

                if (remotingClient.frmLoadingWait1 != null)
                    remotingClient.frmLoadingWait1.Visible = false;

                if (aktRow > maxLinesSR)
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben ") + aktRow.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen ausgew�hlt, es k�nnen aber nur ") + maxLinesSR.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen auf einmal in der Liste anzeigt werden.\r\n") +
                                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte wiederholen Sie die Schnellr�ckmeldung f�r die restlichen Meldungen."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis"), MessageBoxButtons.OK, true);

            }

            catch (Exception ex)
            {
                if (remotingClient.frmLoadingWait1 != null)
                    remotingClient.frmLoadingWait1.Visible = false;
                pnlMain.ResumeLayout();
                this.TopMost = false;
                this.Visible = false;
                ENV.HandleException(ex);
            }

            finally
            {
                pnlMain.ResumeLayout();
                //Scrollbalken wieder nach oben setzen (geht erst nach ResumeLayout)
                using (Control c = new Control() { Parent = pnlMain, Dock = DockStyle.Top })
                {
                    pnlMain.ScrollControlIntoView(c);
                    c.Parent = null;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // F�r alle Controls je nach FinishAfterCreate die PR in die DB speichern
                bool bValid = true;
                foreach (ucPflegeEintragExLine uc in this.pnlMain.Controls)
                {

                    bool b = false;
                    if (uc.Visible && !uc.IgnoreLine )
                    {
                        b = uc.ValidateFields();
                        if (!b)
                            bValid = false;
                    }
                }

                if (!bValid)
                    return;

                System.Collections.Generic.List<Guid> lstPEContainsDienst�bergabe = new List<Guid>();
                foreach (ucPflegeEintragExLine uc in this.pnlMain.Controls)
                {
                    if (!uc.Visible) continue;
                    if (uc.IgnoreLine) continue;

                    uc.UpdateDATA();
                    // Die vermissten Eintr�ge als nicht durchgef�hrt eintragen. Die Funktionalit�t ist �ber die Form schon implementiert und wird benutzt                        
                    uc.Write();
                    //BUtil.UpdatePflegePlan(uc.Eintrag, uc.FinishAfterCreate, false);

                    DateTime N�chstesDatum = DateTime.MinValue;
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();   
                        PMDS.db.Entities.PflegePlan rPflegeplan = null;
                        b.UpdatePflegePlanBeiR�ckmeldung(uc.Eintrag.IDPflegePlan, db, ref  N�chstesDatum, rPflegeplan, uc.MorgenWieder, uc.Eintrag.Zeitpunkt, true);
                        System.Collections.Generic.List<Guid> lstPEToCopy = new System.Collections.Generic.List<Guid>();
                        
                        Guid IDGruppe = System.Guid.NewGuid();
                        IQueryable<PMDS.db.Entities.PflegeEintrag> lstPEorig = db.PflegeEintrag.Where(pe => pe.ID == uc.Eintrag.ID);
                        PMDS.db.Entities.PflegeEintrag rPEeOriginal = lstPEorig.First();
                        rPEeOriginal.IDGruppe = IDGruppe;
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex11)
                        {
                            if (PMDS.Global.ENV.checkExceptionServerNotReachable(ex11.ToString()))
                            {
                                try
                                {
                                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                    db.SaveChanges();
                                }
                                catch (Exception ex12)
                                {
                                    if (PMDS.Global.ENV.checkExceptionServerNotReachable(ex12.ToString()))
                                    {
                                        qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        throw new Exception("frmPatientRueckmeldungLine.btnOK_Click: " + ex12.ToString());
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("frmPatientRueckmeldungLine.btnOK_Click: " + ex11.ToString());
                            }
                        }

                        System.Collections.Generic.List<Guid> lstSelectedCC = uc.auswahlGruppeComboMulti1.AddCC2(uc.Eintrag.ID, true, uc.chkAlsDekursKopieren.Checked, uc.Eintrag.AbzeichnenJN, uc.Eintrag.IDWichtig, ref lstPEToCopy, false, ref IDGruppe);
                        if (lstSelectedCC.Contains(PMDSBusiness.IDSelListDienst�bergabe))
                        {
                            lstPEContainsDienst�bergabe.Add(uc.Eintrag.ID);
                        }

                        if (ENV.HasRight(UserRights.AutomatischeArztabrechungseintr�ge) && rPEeOriginal.EintragsTyp == 4 ) // Nur f�r Termine
                        {
                            int iCounterArtzabrechnungen = 0;
                            PMDS.db.Entities.Aufenthalt rAufenthalt = b.getAufenthalt(rPEeOriginal.IDAufenthalt);
                            if (rAufenthalt != null)
                            {
                                DateTime dNow = DateTime.Now;
                                string ProtocolHeader = "Termin ID (Schnellabzeichnung) " + rPEeOriginal.ID.ToString() + ", Zeitpunkt: " + rPEeOriginal.Zeitpunkt.ToString();
                                if (b.doArztabrechnungen(db, (Guid)rAufenthalt.IDPatient, dNow, ref iCounterArtzabrechnungen, (Guid)rPEeOriginal.IDBenutzer, ProtocolHeader))
                                {
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex14)
                                    {
                                        if (PMDS.Global.ENV.checkExceptionServerNotReachable(ex14.ToString()))
                                        {
                                            try
                                            {
                                                qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                db.SaveChanges();
                                            }
                                            catch (Exception ex15)
                                            {
                                                if (PMDS.Global.ENV.checkExceptionServerNotReachable(ex15.ToString()))
                                                {
                                                    qs2.core.generic.WaitMilli(RBU.DataBase.WaitMSException);
                                                    db.SaveChanges();
                                                }
                                                else
                                                {
                                                    throw new Exception("frmPatientRueckmeldungLine.btnOK_Click: " + ex15.ToString());
                                                }
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("frmPatientRueckmeldungLine.btnOK_Click: " + ex14.ToString());
                                        }
                                    }
                                }
                            }
                        }                    

                        //this.PMDSBusiness1.copyUpdateZusatzwertePEIDGruppe(uc.Eintrag.ID, db);
                    }
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    foreach (Guid IDPE in lstPEContainsDienst�bergabe)
                    {
                        PMDSBusiness1.writeDienst�bergabeForPatient(PMDSBusiness.IDSelListDienst�bergabe, IDPE, db, null);
                    }
                }

                //throw new Exception("TestSR");
                this.DialogResult = DialogResult.OK;

                //if (ENV.Schnellr�ckmeldungAsProcess.Trim() == "1")
                //{
                //    remotingClient remotingClient1 = new remotingClient();
                //    cParComm cParComm1 = new cParComm();
                //    remotingClient.cCallFctReturn CallFctReturn = null;
                //    remotingClient1.callFct(ICommunicationService.eTypeCallTo.MainPMDS, ICommunicationService.eTypeFct.RefreshInterventionen, cParComm1, ref CallFctReturn);
                //}

                remotingSrv.writeClosedSchnellr�ckmeldung(true);
                this.Close();

            }
            catch (Exception ex)
            {
                this.TopMost = false;
                this.Visible = false;
                ENV.HandleException(ex);
            }
        }

        private void frmPatientRueckmeldungLine_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, 32, 32);

            }
            catch (Exception ex)
            {
                this.TopMost = false;
                this.Visible = false;
                ENV.HandleException(ex);
            }
        }

        private void frmPatientRueckmeldungLine_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.InitControlsxy(this._ar);
                    this.toTop();
                }

            }
            catch (Exception ex)
            {
                this.TopMost = false;
                this.Visible = false;
                ENV.HandleException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                remotingSrv.writeClosedSchnellr�ckmeldung(false);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

    }

}
