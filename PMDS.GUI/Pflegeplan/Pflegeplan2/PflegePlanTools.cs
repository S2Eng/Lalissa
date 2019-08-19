using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public class PflegePlanTools
    {
        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle ASZM 's einer Pflegedefinition zu ein Array von ASZMSelectionArgs hinzufügen
        /// Die lokalisierung wird berücksichtigt
        /// </summary>
        //----------------------------------------------------------------------------
        private static void AddArgs(List<ASZMSelectionArgs> ListARGS, Guid IDAufenthaltPDx, Guid IDPDX, PMDS.BusinessLogic.PflegePlan pflegePlan, Guid IDPflegePlan, string sLokalisierung, string sLokalisierungSeite, bool ErledigteAnzeigen)
        {
            string erledigteAnzeigen = ErledigteAnzeigen ? "" : " and ErledigtJN = 0 ";
            dsPflegePlan.PflegePlanRow[] rows = (dsPflegePlan.PflegePlanRow[])pflegePlan.PFLEGEPLAN_EINTRAEGE.Select("ID = '" + IDPflegePlan.ToString() + "' AND (EintragGruppe = 'A' or EintragGruppe = 'S' or EintragGruppe = 'Z' or EintragGruppe = 'M' or EintragGruppe = 'R')" + erledigteAnzeigen, "EintragGruppe, Text, StartDatum, Lokalisierung, LokalisierungSeite");
            ASZMSelectionArgs arg;
            DateTime start = new DateTime(1900, 1, 1);
            string text = "";

            foreach (dsPflegePlan.PflegePlanRow r in rows)
            {
                if (sLokalisierung.Trim() == r.Lokalisierung.Trim() && sLokalisierungSeite.Trim() == r.LokalisierungSeite.Trim() && r.PDXJN)
                {
                    start = r.StartDatum.Date;
                    text = r.Text;
                    arg = new ASZMSelectionArgs();

                    arg.IsEditedFromuser = false;
                    //arg.IsNew = true;
                    arg.IDAufenthaltPDX = IDAufenthaltPDx;
                    arg.IDPflegePlan = IDPflegePlan;
                    if (r.IsAnmerkungNull())
                    {
                        arg.Anmerkung = "";
                    }
                    else
                    {
                         arg.Anmerkung = r.Anmerkung.Trim();
                    }

                    arg.Dauer = r.Dauer;
                    arg.EinmaligJN = r.EinmaligJN;
                    arg.EvalTage = r.EvalTage;
                    arg.IDBerufsstand = r.IDBerufsstand;
                    arg.SpenderAbgabgeJN = r.SpenderAbgabeJN;
                    arg.IDEintrag = !r.IsIDEintragNull() ? r.IDEintrag : Guid.Empty;
                    arg.Intervall = r.Intervall;
                    arg.IntervallTyp = r.IntervallTyp;
                    arg.LokalisierungJN = r.LokalisierungJN;
                    arg.Lokalisierung = r.Lokalisierung.Trim();
                    arg.LokalisierungSeite = r.LokalisierungSeite.Trim();
                    arg.ParalellJN = r.ParalellJN;
                    arg.StartDatum = r.StartDatum;
                    arg.Text = r.Text.Trim();
                    arg.Warnhinweis = r.Warnhinweis.Trim();
                    arg.WochenTage = r.WochenTage;
                    arg.EintragGruppe = PDx.GetEintragGruppeFromChar(r.EintragGruppe[0]);
                    arg.ISPDX = r.PDXJN;
                    arg.WundeJN = r.WundeJN;//Neu nach 01.10.2008 MDA
                    if (arg.ISPDX)
                        arg.IDPDX = IDPDX;
                    arg.RMOptionalJN = r.RMOptionalJN;
                    arg.ErledigtJN = r.ErledigtJN;

                    if (ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
                    {
                        arg.EvalBemerkung = r.NaechsteEvaluierungBemerkung.Trim();

                        if (!r.IsNaechsteEvaluierungNull() && r.EintragGruppe == EintragGruppe.Z.ToString())        // nächste Evaluierung nur für Ziele
                            arg.EvalStartDatum = r.NaechsteEvaluierung;
                        else
                            arg.EvalStartDatum = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        arg.EvalBemerkung = "";
                        arg.EvalStartDatum = new DateTime(1900, 1, 1);
                    }

                    if (r.IsIDUntertaegigeGruppeNull())				// UNtertägigkeitsz zusammengehörigkeit von Maßnahmen
                        arg.IDUntertaegigGruppe = Guid.Empty;
                    else
                        arg.IDUntertaegigGruppe = r.IDUntertaegigeGruppe;
                    
                    if (r.IsIDLinkDokumentNull())
                        arg.IDLinkDokument = Guid.Empty;
                    else
                        arg.IDLinkDokument = r.IDLinkDokument;

                    dsAufenthaltPDx.AufenthaltPDxRow[] aufRows = (dsAufenthaltPDx.AufenthaltPDxRow[])pflegePlan.AUFENTHALTPDX.Select("ID='" + IDAufenthaltPDx + "'");
                    if (aufRows.Length > 0)
                        arg.Resourceklient = aufRows[0].IsresourceklientNull() ? "" : aufRows[0].resourceklient.Trim();


                    if(!r.IsIDUntertaegigeGruppeNull())
                    {
                        dsPflegePlan.PflegePlanRow[] rows2 = (dsPflegePlan.PflegePlanRow[])pflegePlan.PFLEGEPLAN_EINTRAEGE.Select("IDUntertaegigeGruppe = '" + r.IDUntertaegigeGruppe.ToString() + "' " + erledigteAnzeigen, "EintragGruppe, Text, StartDatum, Lokalisierung, LokalisierungSeite");

                        List<string> lUnt = new List<string>();
                        if (r.IsIDZeitbereichNull())
                        {
                            List<DateTime> lU = new List<DateTime>();
                            
                            foreach (dsPflegePlan.PflegePlanRow r2 in rows2)
                            {
                                if (!r2.PDXJN) continue;
                                if (arg.ErledigtJN != r2.ErledigtJN) continue;
                                lU.Add(r2.StartDatum);
                                lUnt.Add(r2.IsAnmerkungNull() ? "" : r2.Anmerkung);
                            }

                            if (r.UntertaegigeJN)
                            {
                                arg.StartDatum = arg.StartDatum.Date;
                                arg.UNTERTAEGIG = lU.ToArray();
                                arg.ANMERKUNG = lUnt.ToArray();
                                arg.ZEITBEREICH = null;
                            }
                        }
                        else
                        {
                            List<Guid> lZb = new List<Guid>();

                            foreach (dsPflegePlan.PflegePlanRow r2 in rows2)
                            {
                                if (!r2.PDXJN) continue;
                                if (arg.ErledigtJN != r2.ErledigtJN) continue;

                                if (!r2.IsIDZeitbereichNull())
                                {
                                    lZb.Add(r2.IDZeitbereich);
                                    lUnt.Add(r2.IsAnmerkungNull() ? "" : r2.Anmerkung);
                                }
                            }

                            if (r.UntertaegigeJN)
                            {
                                arg.StartDatum = arg.StartDatum.Date;
                                arg.ZEITBEREICH = lZb.ToArray();
                                arg.ANMERKUNG = lUnt.ToArray();
                                arg.UNTERTAEGIG = null;
                            }
                        }
                    }

                    arg.OhneZeitBezug = r.OhneZeitBezug;
                    arg.IDZeitbereich = r.IsIDZeitbereichNull() ? Guid.Empty : r.IDZeitbereich;
                    arg.EintragFlag   = r.EintragFlag;

                    if (!r.IsIDZeitbereichNull())
                    {
                        arg.StartDatum = r.StartDatum;
                        arg.ZuErledigenBis = r.ZuErledigenBis;
                    }
                    else
                        arg.ZuErledigenBis = r.StartDatum;

                    ListARGS.Add(arg);
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array aus ein PflegePlan bilden und zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public static PDxSelectionArgs[] GetPDXSelArgsFromPflegePlan(PMDS.BusinessLogic.PflegePlan pflegePlan, bool ErledigteAnzeigen)
        {
            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
            if (pflegePlan == null || pflegePlan.AUFENTHALTPDX == null)
                return list.ToArray();

            //Alle Pflegedefinitionen aus der Tabelle AufenthaltPDx im Array list speichern
            dsAufenthaltPDx.AufenthaltPDxRow[] aufPDxRows = (dsAufenthaltPDx.AufenthaltPDxRow[])pflegePlan.AUFENTHALTPDX.Select("", "Klartext");
            PDxSelectionArgs pdxArg;
            PDx pdx;
            dsPDx.PDXRow pdxRow;
            Guid IDAufenthaltPDx = Guid.Empty;
            //ASZMSelectionArgs[] args;
            string sLokalisierung = "";
            string sLokalisierungSeite = "";
            List<ASZMSelectionArgs> listARGS = new List<ASZMSelectionArgs>();

            foreach (dsAufenthaltPDx.AufenthaltPDxRow ar in aufPDxRows)
            {
                if (!ErledigteAnzeigen && ar.ErledigtJN) continue;
                pdx = new PDx();
                pdxRow = pdx.ReadOne(ar.IDPDX);

                pdxArg = new PDxSelectionArgs();
                pdxArg.IDPDX = ar.IDPDX;
                pdxArg.IDAufenthaltPDX = ar.ID;
                pdxArg.ErledigtJN = ar.ErledigtJN;
                pdxArg.Klartext = pdxRow.Klartext.Trim();
                pdxArg.Text = pdxRow.Klartext.Trim();
                pdxArg.StartDatum = ar.StartDatum;
                pdxArg.Lokalisierung = ar.Lokalisierung.Trim();
                pdxArg.LokalisierungJN = ar.LokalisierungJN;
                pdxArg.LokalisierungSeite = ar.LokalisierungSeite.Trim();
                pdxArg.LokalisierungsTyp = (PDxLokalisierungsTypen)pdxRow.LokalisierungsTyp;
                pdxArg.Resourceklient = ar.IsresourceklientNull() ? "" : ar.resourceklient.Trim();
                pdxArg.WundeJN = ar.WundeJN; //Neu nach 01.10.2008 MDA
                listARGS.Clear(); 
                IDAufenthaltPDx = ar.ID;
                //Alle ASZM's die zu eiene Pflegedefinition aus der Tabelle AufenthaltPDx gehören im pdxArg.ARGS speichern.
                foreach (dsPflegePlanPDx.PflegePlanPDxRow rp in pflegePlan.PFLEGEPLANPDX.Rows)
                {
                    if (!ErledigteAnzeigen && rp.ErledigtJN) continue;

                    if (rp.IDPDX == ar.IDPDX && rp.IDAufenthaltPDx == IDAufenthaltPDx)
                    {
                        sLokalisierung = ar.Lokalisierung.Trim();
                        sLokalisierungSeite = ar.LokalisierungSeite.Trim();

                        AddArgs(listARGS, IDAufenthaltPDx, ar.IDPDX, pflegePlan, rp.IDPflegePlan, sLokalisierung, sLokalisierungSeite, ErledigteAnzeigen);
                        //Liste nach Text sortieren
                        ASZMSelectionArgs.Sort(listARGS);
                        pdxArg.ARGS = listARGS.ToArray();
                    }
                }

                list.Add(pdxArg);
            }

            return list.ToArray();
        }
 
        public static void AfterPflegePlanNodeSelected(ITreeview uc, ucASZMTransfer2 ucASZMTr, IWizardPage ucTrPDx, 
                                                    ref PDxSelectionArgs currentPDXSARG, Control ressourceControl, 
                                                    bool RessourceChanged, Control errorControl, Control defControl,
                                                    bool SuchmodusJN, PflegePlanModus PflegePlanModus, ucPflegeplan2 ucPflegeplan)
        {
            if (uc.ARG != null || uc.PDX_SARG != null)   //lthxy  Farben sind noch nicht perfekt für Planungssystem  blau und grau - schiefe kasterl
            {
              
                bool FirstControl = true;
                //panelMain
                if (SuchmodusJN && PflegePlanModus == Global.PflegePlanModus.Normal)
                {
                    ucPflegeplan.panelMain.Visible = true;
                    FirstControl = false;
                }
                else if (!SuchmodusJN && PflegePlanModus == Global.PflegePlanModus.Normal)
                {
                    ucPflegeplan.panelMain.Visible = true;
                    FirstControl = true;
                }
                if (SuchmodusJN && PflegePlanModus == Global.PflegePlanModus.Wunde)
                {
                    if (uc.IsPDx)
                    {
                        ucPflegeplan.panelMain.Visible = true;
                        FirstControl = true;
                    }
                    else
                    {
                        ucPflegeplan.panelMain.Visible = true;
                        FirstControl = false;
                    }
                }
                else if (!SuchmodusJN && PflegePlanModus == Global.PflegePlanModus.Wunde)
                {
                    ucPflegeplan.panelMain.Visible = true;
                    FirstControl = true;
                }

                errorControl.Visible = false;
                //PDx pdx = new PDx();
                //dsPDx.PDXRow r;
                if (uc.IsPDx)
                {
                    // PDX Node

                    //Wenn ein PDx ausgewählt wurde dann das Headertext angeben ,das Control ucASZMTransferPDx einblenden
                    //und das Control ucASZMTransfer ausblenden
                    ucASZMTr.Visible = false;
                    ((Control)ucTrPDx).Visible = FirstControl;
                    ((Control)ucTrPDx).Left = 0;
                    ((Control)ucTrPDx).Top = 0;

                    if (ucTrPDx is ucASZMTransferPDx)
                        ((ucASZMTransferPDx)ucTrPDx).PDX_SARG = uc.PDX_SARG;
                    if (ucTrPDx is ucWunde)
                        ((ucWunde)ucTrPDx).IDAufenthaltPDx = uc.PDX_SARG.IDAufenthaltPDX;

                    //Neu nach 14.05.2007 MDA: Ressourcen des PDX anzeigen
                    currentPDXSARG = uc.PDX_SARG;

                    //r = pdx.ReadOne(uc.PDX_SARG.IDPDX);
                    //defControl.Text = r.IsDefinitionNull() ? "" : r.Definition;
                    ressourceControl.Enabled = (SuchmodusJN ? false: true);
                    ressourceControl.Text = currentPDXSARG.Resourceklient;
                    RessourceChanged = false;
                }
                else
                {
                    // ASZM Node

                    //Wenn ein PDx ausgewählt wurde dann das Headertext angeben ,das Control ucASZMTransferPDx ausblenden
                    //und das Control ucASZMTransfer einblenden
                    ((Control)ucTrPDx).Visible = false;
                    ucASZMTr.Visible = (SuchmodusJN ? false : true);
                    ucASZMTr.Left = 0;
                    ucASZMTr.Top = 0;
                    ucASZMTr.ARG = uc.ARG;
                    //ressourceControl.Text = "";
                    ressourceControl.Enabled = false;
                    RessourceChanged = false;

                }
            }
            else
            {
                // Mittlere Node

                //Falls kein PDX oder ASZM selektiert wurde, Fehlermeldung anzeigen
 //               errorControl.Visible = true;
                ((Control)ucTrPDx).Visible = false;
                ucASZMTr.Visible = false;
                //ressourceControl.Text = "";
                ressourceControl.Enabled = false;
                RessourceChanged = false;
            }

            if (uc.CurrentPDX != null)
            {
                PDx pdx = new PDx();
                dsPDx.PDXRow r;
                r = pdx.ReadOne(uc.CurrentPDX.IDPDX);
                defControl.Text = r.IsDefinitionNull() ? "" : r.Definition;
            }
        }

        /// <summary>
        /// Vor dem Selektionsänderung im TreeView des Pflegeplans werden die Änderungen übernommen
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="ucASZMTr"></param>
        /// <param name="ucTrPDx"></param>
        /// <param name="ressourceControl"></param>
        /// <param name="errorControl"></param>
        public static bool BeforePflegePlanNodeSelected(ITreeview uc, ucASZMTransfer2 ucASZMTr, IWizardPage ucTrPDx, Control ressourceControl, Control errorControl, bool validateFields)
        {
            if (validateFields && ucTrPDx is ucWunde)
            {
                ucWunde ucw = (ucWunde)ucTrPDx;
                if (ucw.IsChanged)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte Änderungen speichern");
                    return false;
                }
            }

            if (uc.ARG != null || uc.PDX_SARG != null)
            {
                errorControl.Visible = false;

                //Änderungen übernehmen
                if (uc.IsPDx)
                {
                    if (validateFields && !ucTrPDx.ValidateFields())
                        return false;
                    ucTrPDx.UpdateDATA();
                    if (uc.PDX_SARG != null)
                        uc.PDX_SARG.Resourceklient = ressourceControl.Text.Trim();
                }
                else if (ucASZMTr.ISCHANGED)
                {
                    //bool bResValid = ucASZMTr.ValidateFields();
                    if (validateFields && !ucASZMTr.ValidateFields())
                        return false;
                    ucASZMTr.UpdateDATA();
                }
            }

            return true;
        }

        /// <summary>
        /// Datenprüfung
        /// </summary>
        /// <param name="pdxSA"></param>
        /// <returns></returns>
        public static bool ValidatePDxArg(PDxSelectionArgs pdxSA)
        {
            bool bError = false;
            
            // Bezeichnung
            bError = pdxSA.Klartext.Trim() == "";
            if (bError) return !bError;

            // StartDatum
            bError = pdxSA.StartDatum == new DateTime(1900, 1, 1);
            if (bError) return !bError;

            //Lokalisierung
            bool lokPruefen = false;
            if (pdxSA.LokalisierungsTyp == PDxLokalisierungsTypen.Muss)
                lokPruefen = true;
            else if (pdxSA.LokalisierungsTyp == PDxLokalisierungsTypen.Kann && pdxSA.LokalisierungJN)
                lokPruefen = true;

            if (lokPruefen)
            {
                bError = pdxSA.Lokalisierung.Trim() == "";
                if (bError) return !bError;

                bError = pdxSA.LokalisierungSeite.Trim() == "";
                if (bError) return !bError;
            }


            if (ENV.EvaluierungsTyp == EvaluierungsTypen.PDX)
            {
                bError = pdxSA.EvalStartDatum == new DateTime(1900, 1, 1);
                if (bError) return !bError;
            }

            return !bError;
        }

        /// <summary>
        /// Datenprüfung
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool ValidateASZMARGS(ASZMSelectionArgs arg)
        {
            bool bError = false;
            if(arg.OhneZeitBezug)
                return !bError;

            if (ASZMTransfer.IsUntertaegig(arg))
            {
                if ((arg.ZEITBEREICH == null || arg.ZEITBEREICH.Length == 0) && (arg.UNTERTAEGIG == null || arg.UNTERTAEGIG.Length == 0))
                    bError = true;
            }
            else if (arg.StartDatum == new DateTime(1900, 1, 1) && (arg.EintragGruppe == EintragGruppe.M || arg.EintragGruppe == EintragGruppe.T))
                bError = true;
            
            return !bError;
        }

        public static bool ValidateASZMARGS(ASZMSelectionArgs arg, ZusatzGruppe zusatzgruppe)
        {
            bool bError = false;
            if (arg.OhneZeitBezug)
                return !bError;

            if (ASZMTransfer.IsUntertaegig(arg))
            {
                if ((arg.ZEITBEREICH == null || arg.ZEITBEREICH.Length == 0) && (arg.UNTERTAEGIG == null || arg.UNTERTAEGIG.Length == 0))
                    bError = true;
            }
            else if (arg.StartDatum == new DateTime(1900, 1, 1) && (arg.EintragGruppe == EintragGruppe.M || arg.EintragGruppe == EintragGruppe.T))
                bError = true;

            if (!bError && zusatzgruppe != null)
            {
                if (arg.EintragGruppe == EintragGruppe.M)
                {
                    if ((arg.ZEITBEREICH == null || arg.ZEITBEREICH.Length == 0) && (arg.UNTERTAEGIG == null || arg.UNTERTAEGIG.Length == 0))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte prüfen Sie die Zeitpunkte der Interventionen"),
                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Feher bei der Planung"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                        bError = true;
                        return false;
                    }
                }

                dsZusatzGruppeEintrag.ZusatzGruppeEintragRow[] eintraege = (dsZusatzGruppeEintrag.ZusatzGruppeEintragRow[])zusatzgruppe.ZusatzEintraege.Select("IDFilter = '" + arg.IDEintrag.ToString() + "'");
                StringBuilder sb = new StringBuilder();
                dsZusatzGruppeEintrag.ZusatzGruppeEintragRow[] rows;
                foreach (dsZusatzGruppeEintrag.ZusatzGruppeEintragRow r in eintraege)
                {
                    //Eintra prüfen
                    if (r.IsIDZusatzEintragNull() || r.IDZusatzEintrag.Trim() == ""
                        )
                        bError = true;
                    else
                    {
                        sb = new StringBuilder();
                        sb.Append("ID <>'" + r.ID.ToString() + "'");
                        sb.Append(" and IDFilter = '" + r.IDFilter.ToString() + "'");
                        sb.Append(" and IDObjekt = '" + r.IDObjekt.ToString() + "'");
                        sb.Append(" and IDZusatzEintrag = '" + r.IDZusatzEintrag.ToString() + "'");

                        rows = (dsZusatzGruppeEintrag.ZusatzGruppeEintragRow[])zusatzgruppe.ZusatzEintraege.Select(sb.ToString());
                        
                        if (rows.Length > 0)
                            bError = true;
                    }
                    if (bError) break;
                }
            }

            return !bError;
        }


        public static bool EndSelectedASZM(PMDS.BusinessLogic.PflegePlan pflegePlan, ASZMLokalisiert[] raszm, string sReason, DateTime dtEnd)
        {
            pflegePlan.EndASZM(raszm, sReason, dtEnd);
            // Alle PflegeEinträge für Abfrage auf nicht Rückgemeldete holen
            PflegeEintrag[] ape = pflegePlan.GetPflegeEintraegeFromASZML(raszm, dtEnd);

            foreach (PflegeEintrag pe in ape)   //lthok  --> warum iteration mittels pe    wo ist pp
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                string sTextForPE = "";
                DateTime dNow = DateTime.Now;
                PMDSBusiness1.EndPflegePlan(pe.IDPflegePlan, sTextForPE, dNow, false, true, true);      //lthok 

            }
            return true;
        }

        public static void GetPdxASZML(ref ASZMLokalisiert[] raszm, ref PDxLokalisiert[] rpdx, PMDS.BusinessLogic.PflegePlan pflegePlan, ucPflegeplanTreeView uc)
        {
            PDxSelectionArgs[] pdxArgs = uc.GetSelectedPDX();
            if (pdxArgs == null || pdxArgs.Length == 0)
            {
                return; 
            } 

            ArrayList al = new ArrayList();
            PDxLokalisiert l;

            foreach (PDxSelectionArgs pdxArg in pdxArgs)
            {
                l = new PDxLokalisiert();
                l._IDAufenthaltPDx = pdxArg.IDAufenthaltPDX;
                l._IDPDx = pdxArg.IDPDX;
                l._Lokalisierung = pdxArg.Lokalisierung;
                l._LokalisierungSeite = pdxArg.LokalisierungSeite;
                al.Add(l);
            }

            rpdx = (PDxLokalisiert[])al.ToArray(typeof(PDxLokalisiert));

            if (rpdx.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("DIALOGTITLE_MISSINGPDXSELECTION"), ENV.String("DIALOGTITLE_MISSINGPDXSELECTION"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                return;
            }

            raszm = pflegePlan.GetAllIDPflegePlanFromPDxArray(rpdx);				// Liste mit allen beteiligten Elementen holen
        }

        private static void GetASZML(ref ASZMLokalisiert[] raszm, ref PDxLokalisiert[] rpdx, PMDS.BusinessLogic.PflegePlan pflegePlan, ucPflegeplanTreeView uc)
        {
            ASZMSelectionArgs[] args = uc.GetSelectedASZM();
            if (args == null || args.Length == 0) return;

            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();
            List<Guid> list = new List<Guid>();
            PDxLokalisiert l;

            foreach (ASZMSelectionArgs arg in args)
            {
                if (arg.ErledigtJN) continue;
                if (list.IndexOf(arg.IDAufenthaltPDX) == -1)
                {
                    list.Add(arg.IDAufenthaltPDX);
                    l = new PDxLokalisiert();

                    l._IDAufenthaltPDx = arg.IDAufenthaltPDX;
                    l._IDPDx = arg.IDPDX;
                    l._Lokalisierung = arg.Lokalisierung;
                    l._LokalisierungSeite = arg.LokalisierungSeite;
                    al2.Add(l);
                }

                foreach (dsPflegePlan.PflegePlanRow r in pflegePlan.PFLEGEPLAN_EINTRAEGE)
                {

                    if (r.IsIDEintragNull())
                        continue;

                    // Ein Datensatz gilt als gefunden wenn es sich 
                    // 1) Es sich um einen Eintrag handelt der auf der mit derselben lokalisierung bereits vorhanden ist
                    // Ein Eintrag darf immer stattfinden wenn es sich um einen Eintrag ohne PDXZuordnung handelt
                    // Ein Eintrag darf auch dann Stattfinden wenn es sich um einen Eintrag derselben UntertägigkeitsGruppe handelt
                    if (r.IDEintrag == arg.IDEintrag &&
                        r.Lokalisierung.Trim().ToUpper() == arg.Lokalisierung.Trim().ToUpper() &&
                        r.LokalisierungSeite.Trim().ToUpper() == arg.LokalisierungSeite.Trim().ToUpper()
                        && r.ErledigtJN == false && arg.ISPDX)
                    {
                        if (r.UntertaegigeJN)	// Bei Untertägigen darf nur dieselbe Gruppe vorkommen aber sonst keine andere
                        {
                            if (r.IDUntertaegigeGruppe == arg.IDUntertaegigGruppe)
                            {
                                al.Add(r);
                                break;
                            }
                        }
                        else
                        {
                            al.Add(r);
                            break;
                        }
                    }
                }
            }

            if (al.Count == 0)											// keine Einträge in der Liste ==> nix zu tun
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_NO_SELECTION"), ENV.String("MESSAGE_NO_SELECTION"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                return;
            }

            // für alle markierten ASZM sämtliche PflegeplanPDx lesen soferne PDx und in die Liste eintragen
            raszm = pflegePlan.GetAllIDPflegePlanFromPflegePlanRows((dsPflegePlan.PflegePlanRow[])al.ToArray(typeof(dsPflegePlan.PflegePlanRow)));

            rpdx = (PDxLokalisiert[])al2.ToArray(typeof(PDxLokalisiert));
        }


        public static bool EndPflegePlanUIxy(PMDS.BusinessLogic.PflegePlan pflegePlan, ucPflegeplanTreeView uc)
        {
            ASZMLokalisiert[] PDXraszm = null;
            PDxLokalisiert[] PDX_rpdx = null;
            GetPdxASZML(ref PDXraszm, ref PDX_rpdx, pflegePlan, uc);

            //TO DO: ASZM Beenden
            ASZMLokalisiert[] ASZMraszm = null;
            PDxLokalisiert[] ASZM_rpdx = null;
            GetASZML(ref ASZMraszm, ref ASZM_rpdx, pflegePlan, uc);

            if (PDXraszm == null && ASZMraszm == null)
                return false;
            
            frmAskEndPDxASZM frm = new frmAskEndPDxASZM();

            if (PDXraszm != null)
                frm.EndPDX(PDXraszm);

            if (ASZMraszm != null && ASZM_rpdx != null)
                frm.EndASZM(ASZMraszm, ASZM_rpdx);

            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return false;
            PflegeEintrag[] ape;

            if (PDXraszm != null)
            {
                // Alle PflegeEinträge für Abfrage auf nicht Rückgemeldete holen
                ape = pflegePlan.GetPflegeEintraegeFromASZML(PDXraszm, frm.END_DATE);

                foreach (PflegeEintrag pe in ape)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    string sTextForPE = "";
                    DateTime dNow = DateTime.Now;
                    PMDSBusiness1.EndPflegePlan(pe.IDPflegePlan, sTextForPE, dNow, true, true, false);      //lthok

                    //// Termin am selben Tag ist auch OKAY !
                    //PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    //string sTextForPE = "Automatisierte Rückmeldung";
                    //PMDS.DB.PMDSBusiness.retBusiness ret = PMDSBusiness1.EndTermine(pe.IDAufenthalt, pe.IDAufenthalt, pe.Zeitpunkt.Date, pe.Zeitpunkt.Date, ENV.IDKlinik, sTextForPE);

                    ////foreach (PMDS.db.Entities.vInterventionen rIntervention in ret.lstFound )
                    ////{
                    ////    PMDS.BusinessLogic.PflegePlan dbPflegePlan = new PflegePlan(rIntervention.IDAufenthalt);
                    ////    PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow r = dbPflegePlan.GetRowByID(rIntervention.IDPflegeplan);
                    ////    PMDS.BusinessLogic.PflegeEintrag PflegeEintrag = new PflegeEintrag((System.Guid)rIntervention.IDEintrag);

                    ////    pe1 = GuiAction.NewPflegeEintragByRow(r, (DateTime)r.StartDatum, PflegeEintrag);
                    ////    pe1.Text = "Nicht durchgeführt.";
                    ////    pe1.DurchgefuehrtJN = false;
                    ////    pe1.Write();
                    ////}
                }
                pflegePlan.EndPDx(PDX_rpdx, PDXraszm, frm.PDX_REASON, frm.END_DATE);
            }


            if (ASZMraszm != null && ASZM_rpdx != null)
            {
                // in Raszm stehen nun alle Einträge welche beendet werden sollen. Untertägige müssen speziell berücksichtigt werden
                ASZMraszm = frm.SELECTED_ASZM;
                if (!EndSelectedASZM(pflegePlan, ASZMraszm, frm.ASZM_REASON, frm.END_DATE))
                    return false;
            }
            return true;
        }
    }
}
