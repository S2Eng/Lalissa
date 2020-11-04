using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;
using WCFServicePMDS;


namespace WCFServicePMDS.TestUnits
{

    public class TestRepository
    {

 

        public static void run(Guid IDClient)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
                {
                    //WCFServicePMDS.TestUnits.TestUnits t = new WCFServicePMDS.TestUnits.TestUnits(context);
                    WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    int i = _repoWrapper.Abteilung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Adresse.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Aerzte.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    var t1 = context.AnamneseKrohwinkel.Where(o => o.Id == System.Guid.NewGuid()).Select(o => new { o.Id, o.AngstVon, o.Beruf });
                    var t2 = context.AnamneseOrem.Where(o => o.Id == System.Guid.NewGuid()).Select(o => new { o.Id, o.IdbenutzerErstellt, o.Bezugsperson });
                    var t3 = context.AnamnesePop.Where(o => o.Id == System.Guid.NewGuid()).Select(o => new { o.Id, o.IdbenutzerErstellt, o.Decubitus });
                    //i = _repoWrapper.Anamnese_Krohwinkel.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.Anamnese_Orem.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.Anamnese_POP.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.Anmeldungen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    //i = _repoWrapper.archDoku.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();            // tables not in DB
                    //i = _repoWrapper.archDokuSchlag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.archObject.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.archOrdner.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.Arztabrechnung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Aufenthalt.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AufenthaltPDx.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AufenthaltVerlauf.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AufenthaltZusatz.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AuswahlListe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AuswahlListeGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.Bank.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BarcodeQ.FindByCondition(o => o.Id != 12).Count();
                    i = _repoWrapper.Belegung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Benutzer.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerAbteilung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerBezug.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerEinrichtung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerRechte.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Bereich.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BereichBenutzer.FindByCondition(o => o.Idbenutzer == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BillHeader.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.Bills.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.Bookings.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.Dokumente.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Dokumente2.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Einrichtung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Eintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.EintragStandardprozeduren.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.EintragZusatz.FindByCondition(o => o.Idabteilung == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Essen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Formular.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.FormularDaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.FormularDatenFelder.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Gegenstaende.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Gruppe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.GruppenRecht.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Info.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.Klinik.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Kontakt.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Kontaktperson.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.KontaktpersonStammdaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Kostentraeger.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Leistungskatalog.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.LeistungskatalogGueltig.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.LinkDokumente.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.ManBuch.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Massnahmenserien.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Medikament.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.MedikationAbgabe.FindByCondition(o => o.Idaufenthalt == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.MedizinischeDaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.MedizinischeDatenLayout.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.MedizinischeTypen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Patient.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientAbwesenheit.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientAerzte.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientEinkommen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientenBemerkung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientKostentraeger.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientLeistungsplan.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientPflegestufe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientSonderleistung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientTaschengeldKostentraeger.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDX.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXAnamnese.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXGruppeEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXPflegemodelle.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    var t4 = context.PflegeEintrag.Where(o => o.Id == System.Guid.NewGuid()).Select(o => new { o.Id});
                    //i = _repoWrapper.PflegeEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.PflegeEintragEntwurf.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Pflegegeldstufe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PflegegeldstufeGueltig.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Pflegemodelle.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PflegePlan.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PflegePlanH.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PflegePlanPDx.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Plan.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PlanAnhang.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PlanObject.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PlanStatus.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.QuickFilter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.QuickMeldung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.RechNr.FindByCondition(o => o.Nr == 1234).Count();
                    i = _repoWrapper.Recht.FindByCondition(o => o.Id == 1234).Count();
                    i = _repoWrapper.Rehabilitation.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.RezeptBestellungPos.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.RezeptEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.RezeptEintragMedDaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Sachwalter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.SonderleistungsKatalog.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.SP.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.SPDynRep.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.SPPE.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.SPPOS.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.StandardProzeduren.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Standardzeiten.FindByCondition(o => o.Id == 1234).Count();
                    i = _repoWrapper.Taschengeld.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.tbl_Nachricht.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.TblAutoDoku.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.TblDokumente.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.TblDokumenteGelesen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblDokumenteintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblDokumenteneintragSchlagwörter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblFortbildungBenutzer.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblFortbildungen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblInterop.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblObjekt.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblParameter.FindByCondition(o => o.Bezeichnung == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblPfad.FindByCondition(o => o.Archivpfad == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblProvKonfig.FindByCondition(o => o.Value == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblRechteOrdner.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSchlagwörter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSchrank.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSturzprotokoll.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSuchtgiftschrankSchlüssel.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblTextTemplates.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblTextTemplatesFiles.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblThemen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblUIDefinitions.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblUserAccounts.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblVeranstalter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Textbausteine.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Unterbringung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.UrlaubVerlauf.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO_Bestelldaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO_Bestellpostitionen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO_Lager.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO_MedizinischeDaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO_PflegeplanPDX.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.VO_Wunde.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.WundeKopf.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.WundePos.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.WundePosBilder.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.WundeTherapie.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Zeitbereich.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.ZeitbereichSerien.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.ZusatzEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.ZusatzGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.ZusatzGruppeEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.ZusatzWert.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AddIns.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Layout.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.LayoutGrids.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Protocol.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Ressourcen.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblAdjust.FindByCondition(o => o.Setting == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblAdress.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblCriteria.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblCriteriaOpt.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblDBVersion.FindByCondition(o => o.Description == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblMedArchiv.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblObject.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblObjectApplications.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblObjectRel.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblParticipants.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblQueriesDef.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblQueryJoinsTemp.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblRelationship.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListEntries.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListEntriesObj.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListEntriesSort.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListGroup.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSideLogic.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblStatistics.FindByCondition(o => o.Id == 1234).Count();
                    i = _repoWrapper.TblStay.FindByCondition(o => o.Id == 1234).Count();
                    i = _repoWrapper.TblStayAdditions.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblVersions.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();

                    i = _repoWrapper.DBLizenz.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Dienstzeiten.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Elgaactivities.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Elgaprotocoll.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblRedist.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();


                    i = _repoWrapper.vKlientenliste2.FindByCondition(o => o.IDKlient == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.vInterventionen2.FindByCondition(o => o.IDKlient == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.vÜbergabe2.FindByCondition(o => o.IDKlient == System.Guid.NewGuid()).Count();

                    var tK = context.vKlientenliste2.Where(o => o.IDKlient == System.Guid.NewGuid()).Select(o => new { o.IDKlient });
                    var tI = context.vInterventionen2.Where(o => o.IDKlient == System.Guid.NewGuid()).Select(o => new { o.IDKlient });
                    var tÜ = context.vÜbergabe2.Where(o => o.IDKlient == System.Guid.NewGuid()).Select(o => new { o.IDKlient });
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.TestUnits.TestRepository.run: " + ex.ToString());
            }
        }

        public static void runSmall(Guid IDClient)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
                {
                    //WCFServicePMDS.TestUnits.TestUnits t = new WCFServicePMDS.TestUnits.TestUnits(context);
                    WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    int i = _repoWrapper.Abteilung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.AuswahlListe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.AuswahlListeGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid().ToString()).Count();
                  
                    i = _repoWrapper.Benutzer.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerAbteilung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerBezug.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerEinrichtung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BenutzerRechte.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Bereich.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.BereichBenutzer.FindByCondition(o => o.Idbenutzer == System.Guid.NewGuid()).Count();
                   
                    i = _repoWrapper.Dokumente.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Dokumente2.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Einrichtung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                  
                    i = _repoWrapper.Gruppe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.GruppenRecht.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                  
                    i = _repoWrapper.Klinik.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                  
                    i = _repoWrapper.Kontaktperson.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.KontaktpersonStammdaten.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                   
                    i = _repoWrapper.Leistungskatalog.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.LeistungskatalogGueltig.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    
                    i = _repoWrapper.Massnahmenserien.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                   
                    i = _repoWrapper.MedizinischeDatenLayout.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Patient.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PatientAbwesenheit.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                   
                    i = _repoWrapper.PDX.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXAnamnese.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXGruppe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXGruppeEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PDXPflegemodelle.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    var t4 = context.PflegeEintrag.Where(o => o.Id == System.Guid.NewGuid()).Select(o => new { o.Id });
                    //i = _repoWrapper.PflegeEintrag.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.PflegeEintragEntwurf.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Pflegegeldstufe.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.PflegegeldstufeGueltig.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Pflegemodelle.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.QuickFilter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.RechNr.FindByCondition(o => o.Nr == 1234).Count();
                    i = _repoWrapper.Recht.FindByCondition(o => o.Id == 1234).Count();
                   
                    i = _repoWrapper.Sachwalter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                  
                    i = _repoWrapper.Standardzeiten.FindByCondition(o => o.Id == 1234).Count();
                    i = _repoWrapper.Taschengeld.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.TblFortbildungen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblInterop.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.TblParameter.FindByCondition(o => o.Bezeichnung == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblPfad.FindByCondition(o => o.Archivpfad == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblProvKonfig.FindByCondition(o => o.Value == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblRechteOrdner.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSchlagwörter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSchrank.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSturzprotokoll.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
              
                    i = _repoWrapper.TblTextTemplates.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblTextTemplatesFiles.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblThemen.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblUIDefinitions.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblUserAccounts.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblVeranstalter.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Textbausteine.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Unterbringung.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                  
                    i = _repoWrapper.AddIns.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Layout.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.LayoutGrids.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();

                    i = _repoWrapper.Ressourcen.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblAdjust.FindByCondition(o => o.Setting == System.Guid.NewGuid().ToString()).Count();

                    i = _repoWrapper.TblCriteria.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblCriteriaOpt.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblDBVersion.FindByCondition(o => o.Description == System.Guid.NewGuid().ToString()).Count();
                    i = _repoWrapper.TblMedArchiv.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();
         
                    i = _repoWrapper.TblParticipants.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblQueriesDef.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblQueryJoinsTemp.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblRelationship.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListEntries.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListEntriesObj.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListEntriesSort.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSelListGroup.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblSideLogic.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblStatistics.FindByCondition(o => o.Id == 1234).Count();
            
                    i = _repoWrapper.TblVersions.FindByCondition(o => o.Idapplication == System.Guid.NewGuid().ToString()).Count();

                    i = _repoWrapper.DBLizenz.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Dienstzeiten.FindByCondition(o => o.Idguid == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Elgaactivities.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.Elgaprotocoll.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();
                    i = _repoWrapper.TblRedist.FindByCondition(o => o.Id == System.Guid.NewGuid()).Count();


                    //i = _repoWrapper.vKlientenliste2.FindByCondition(o => o.IDKlient == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.vInterventionen2.FindByCondition(o => o.IDKlient == System.Guid.NewGuid()).Count();
                    //i = _repoWrapper.vÜbergabe2.FindByCondition(o => o.IDKlient == System.Guid.NewGuid()).Count();

                    //var tK = context.vKlientenliste2.Where(o => o.IDKlient == System.Guid.NewGuid()).Select(o => new { o.IDKlient });
                    //var tI = context.vInterventionen2.Where(o => o.IDKlient == System.Guid.NewGuid()).Select(o => new { o.IDKlient });
                    //var tÜ = context.vÜbergabe2.Where(o => o.IDKlient == System.Guid.NewGuid()).Select(o => new { o.IDKlient });
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.TestUnits.TestRepository.run: " + ex.ToString());
            }
        }

    }

}
