using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WCFServicePMDS.Models.DB
{
    public partial class PMDSDevContext : DbContext
    {
        public PMDSDevContext()
        {
        }

        public PMDSDevContext(DbContextOptions<PMDSDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestView1> TestView1 { get; set; }
        public virtual DbSet<vInterventionen2> vInterventionen2 { get; set; }
        public virtual DbSet<vKlientenliste2> vKlientenliste2 { get; set; }
        public virtual DbSet<vÜbergabe2> vÜbergabe2 { get; set; }


        public virtual DbSet<Abteilung> Abteilung { get; set; }
        public virtual DbSet<AddIns> AddIns { get; set; }
        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Aerzte> Aerzte { get; set; }
        public virtual DbSet<AnamneseKrohwinkel> AnamneseKrohwinkel { get; set; }
        public virtual DbSet<AnamneseOrem> AnamneseOrem { get; set; }
        public virtual DbSet<AnamnesePop> AnamnesePop { get; set; }
        public virtual DbSet<Anmeldungen> Anmeldungen { get; set; }
        public virtual DbSet<ArchDoku> ArchDoku { get; set; }
        public virtual DbSet<ArchDokuSchlag> ArchDokuSchlag { get; set; }
        public virtual DbSet<ArchObject> ArchObject { get; set; }
        public virtual DbSet<ArchOrdner> ArchOrdner { get; set; }
        public virtual DbSet<Arztabrechnung> Arztabrechnung { get; set; }
        public virtual DbSet<Aufenthalt> Aufenthalt { get; set; }
        public virtual DbSet<AufenthaltPdx> AufenthaltPdx { get; set; }
        public virtual DbSet<AufenthaltVerlauf> AufenthaltVerlauf { get; set; }
        public virtual DbSet<AufenthaltZusatz> AufenthaltZusatz { get; set; }
        public virtual DbSet<AuswahlListe> AuswahlListe { get; set; }
        public virtual DbSet<AuswahlListeGruppe> AuswahlListeGruppe { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BarcodeQ> BarcodeQ { get; set; }
        public virtual DbSet<Belegung> Belegung { get; set; }
        public virtual DbSet<Benutzer> Benutzer { get; set; }
        public virtual DbSet<BenutzerAbteilung> BenutzerAbteilung { get; set; }
        public virtual DbSet<BenutzerBezug> BenutzerBezug { get; set; }
        public virtual DbSet<BenutzerEinrichtung> BenutzerEinrichtung { get; set; }
        public virtual DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        public virtual DbSet<BenutzerRechte> BenutzerRechte { get; set; }
        public virtual DbSet<Bereich> Bereich { get; set; }
        public virtual DbSet<BereichBenutzer> BereichBenutzer { get; set; }
        public virtual DbSet<BillHeader> BillHeader { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Dblizenz> Dblizenz { get; set; }
        public virtual DbSet<Dbversion> Dbversion { get; set; }
        public virtual DbSet<Dienstzeiten> Dienstzeiten { get; set; }
        public virtual DbSet<Dokumente> Dokumente { get; set; }
        public virtual DbSet<Dokumente2> Dokumente2 { get; set; }
        public virtual DbSet<Einrichtung> Einrichtung { get; set; }
        public virtual DbSet<Eintrag> Eintrag { get; set; }
        public virtual DbSet<EintragStandardprozeduren> EintragStandardprozeduren { get; set; }
        public virtual DbSet<EintragZusatz> EintragZusatz { get; set; }
        public virtual DbSet<Elgaactivities> Elgaactivities { get; set; }
        public virtual DbSet<Elgacontacts> Elgacontacts { get; set; }
        public virtual DbSet<Elgadocuments> Elgadocuments { get; set; }
        public virtual DbSet<Elgaprotocoll> Elgaprotocoll { get; set; }
        public virtual DbSet<Essen> Essen { get; set; }
        public virtual DbSet<Formular> Formular { get; set; }
        public virtual DbSet<FormularDaten> FormularDaten { get; set; }
        public virtual DbSet<FormularDatenFelder> FormularDatenFelder { get; set; }
        public virtual DbSet<Gegenstaende> Gegenstaende { get; set; }
        public virtual DbSet<Gruppe> Gruppe { get; set; }
        public virtual DbSet<GruppenRecht> GruppenRecht { get; set; }
        public virtual DbSet<Info> Info { get; set; }
        public virtual DbSet<Klinik> Klinik { get; set; }
        public virtual DbSet<Kontakt> Kontakt { get; set; }
        public virtual DbSet<Kontaktperson> Kontaktperson { get; set; }
        public virtual DbSet<KontaktpersonStammdaten> KontaktpersonStammdaten { get; set; }
        public virtual DbSet<Kostentraeger> Kostentraeger { get; set; }
        public virtual DbSet<Layout> Layout { get; set; }
        public virtual DbSet<LayoutGrids> LayoutGrids { get; set; }
        public virtual DbSet<Leistungskatalog> Leistungskatalog { get; set; }
        public virtual DbSet<LeistungskatalogGueltig> LeistungskatalogGueltig { get; set; }
        public virtual DbSet<LinkDokumente> LinkDokumente { get; set; }
        public virtual DbSet<ManBuch> ManBuch { get; set; }
        public virtual DbSet<Massnahmenserien> Massnahmenserien { get; set; }
        public virtual DbSet<Medikament> Medikament { get; set; }
        public virtual DbSet<MedikationAbgabe> MedikationAbgabe { get; set; }
        public virtual DbSet<MedizinischeDaten> MedizinischeDaten { get; set; }
        public virtual DbSet<MedizinischeDatenLayout> MedizinischeDatenLayout { get; set; }
        public virtual DbSet<MedizinischeTypen> MedizinischeTypen { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAbwesenheit> PatientAbwesenheit { get; set; }
        public virtual DbSet<PatientAerzte> PatientAerzte { get; set; }
        public virtual DbSet<PatientEinkommen> PatientEinkommen { get; set; }
        public virtual DbSet<PatientKostentraeger> PatientKostentraeger { get; set; }
        public virtual DbSet<PatientLeistungsplan> PatientLeistungsplan { get; set; }
        public virtual DbSet<PatientPflegestufe> PatientPflegestufe { get; set; }
        public virtual DbSet<PatientSonderleistung> PatientSonderleistung { get; set; }
        public virtual DbSet<PatientTaschengeldKostentraeger> PatientTaschengeldKostentraeger { get; set; }
        public virtual DbSet<PatientenBemerkung> PatientenBemerkung { get; set; }
        public virtual DbSet<Pdx> Pdx { get; set; }
        public virtual DbSet<Pdxanamnese> Pdxanamnese { get; set; }
        public virtual DbSet<Pdxeintrag> Pdxeintrag { get; set; }
        public virtual DbSet<Pdxgruppe> Pdxgruppe { get; set; }
        public virtual DbSet<PdxgruppeEintrag> PdxgruppeEintrag { get; set; }
        public virtual DbSet<Pdxpflegemodelle> Pdxpflegemodelle { get; set; }
        public virtual DbSet<PflegeEintrag> PflegeEintrag { get; set; }
        public virtual DbSet<PflegeEintragEntwurf> PflegeEintragEntwurf { get; set; }
        public virtual DbSet<PflegePlan> PflegePlan { get; set; }
        public virtual DbSet<PflegePlanH> PflegePlanH { get; set; }
        public virtual DbSet<PflegePlanPdx> PflegePlanPdx { get; set; }
        public virtual DbSet<Pflegegeldstufe> Pflegegeldstufe { get; set; }
        public virtual DbSet<PflegegeldstufeGueltig> PflegegeldstufeGueltig { get; set; }
        public virtual DbSet<Pflegemodelle> Pflegemodelle { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<PlanAnhang> PlanAnhang { get; set; }
        public virtual DbSet<PlanObject> PlanObject { get; set; }
        public virtual DbSet<PlanStatus> PlanStatus { get; set; }
        public virtual DbSet<Protocol> Protocol { get; set; }
        public virtual DbSet<QuickFilter> QuickFilter { get; set; }
        public virtual DbSet<QuickMeldung> QuickMeldung { get; set; }
        public virtual DbSet<RechNr> RechNr { get; set; }
        public virtual DbSet<Recht> Recht { get; set; }
        public virtual DbSet<Rehabilitation> Rehabilitation { get; set; }
        public virtual DbSet<Ressourcen> Ressourcen { get; set; }
        public virtual DbSet<RezeptBestellungPos> RezeptBestellungPos { get; set; }
        public virtual DbSet<RezeptEintrag> RezeptEintrag { get; set; }
        public virtual DbSet<RezeptEintragMedDaten> RezeptEintragMedDaten { get; set; }
        public virtual DbSet<Sachwalter> Sachwalter { get; set; }
        public virtual DbSet<SonderleistungsKatalog> SonderleistungsKatalog { get; set; }
        public virtual DbSet<Sp> Sp { get; set; }
        public virtual DbSet<SpdynRep> SpdynRep { get; set; }
        public virtual DbSet<Sppe> Sppe { get; set; }
        public virtual DbSet<Sppos> Sppos { get; set; }
        public virtual DbSet<StandardProzeduren> StandardProzeduren { get; set; }
        public virtual DbSet<Standardzeiten> Standardzeiten { get; set; }
        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<Taschengeld> Taschengeld { get; set; }
        public virtual DbSet<TblAdjust> TblAdjust { get; set; }
        public virtual DbSet<TblAdress> TblAdress { get; set; }
        public virtual DbSet<TblAutoDoku> TblAutoDoku { get; set; }
        public virtual DbSet<TblCriteria> TblCriteria { get; set; }
        public virtual DbSet<TblCriteriaOpt> TblCriteriaOpt { get; set; }
        public virtual DbSet<TblDbversion> TblDbversion { get; set; }
        public virtual DbSet<TblDokumente> TblDokumente { get; set; }
        public virtual DbSet<TblDokumenteGelesen> TblDokumenteGelesen { get; set; }
        public virtual DbSet<TblDokumenteintrag> TblDokumenteintrag { get; set; }
        public virtual DbSet<TblDokumenteneintragSchlagwörter> TblDokumenteneintragSchlagwörter { get; set; }
        public virtual DbSet<TblFach> TblFach { get; set; }
        public virtual DbSet<TblFortbildungBenutzer> TblFortbildungBenutzer { get; set; }
        public virtual DbSet<TblFortbildungen> TblFortbildungen { get; set; }
        public virtual DbSet<TblInterop> TblInterop { get; set; }
        public virtual DbSet<TblMedArchiv> TblMedArchiv { get; set; }
        public virtual DbSet<TblNachricht> TblNachricht { get; set; }
        public virtual DbSet<TblObject> TblObject { get; set; }
        public virtual DbSet<TblObjectApplications> TblObjectApplications { get; set; }
        public virtual DbSet<TblObjectRel> TblObjectRel { get; set; }
        public virtual DbSet<TblObjekt> TblObjekt { get; set; }
        public virtual DbSet<TblOrdner> TblOrdner { get; set; }
        public virtual DbSet<TblParameter> TblParameter { get; set; }
        public virtual DbSet<TblParticipants> TblParticipants { get; set; }
        public virtual DbSet<TblPfad> TblPfad { get; set; }
        public virtual DbSet<TblProvKonfig> TblProvKonfig { get; set; }
        public virtual DbSet<TblQueriesDef> TblQueriesDef { get; set; }
        public virtual DbSet<TblQueryJoinsTemp> TblQueryJoinsTemp { get; set; }
        public virtual DbSet<TblRechteOrdner> TblRechteOrdner { get; set; }
        public virtual DbSet<TblRedist> TblRedist { get; set; }
        public virtual DbSet<TblRelationship> TblRelationship { get; set; }
        public virtual DbSet<TblSchlagwörter> TblSchlagwörter { get; set; }
        public virtual DbSet<TblSchrank> TblSchrank { get; set; }
        public virtual DbSet<TblSelListEntries> TblSelListEntries { get; set; }
        public virtual DbSet<TblSelListEntriesObj> TblSelListEntriesObj { get; set; }
        public virtual DbSet<TblSelListEntriesSort> TblSelListEntriesSort { get; set; }
        public virtual DbSet<TblSelListGroup> TblSelListGroup { get; set; }
        public virtual DbSet<TblSideLogic> TblSideLogic { get; set; }
        public virtual DbSet<TblStatistics> TblStatistics { get; set; }
        public virtual DbSet<TblStay> TblStay { get; set; }
        public virtual DbSet<TblStayAdditions> TblStayAdditions { get; set; }
        public virtual DbSet<TblSturzprotokoll> TblSturzprotokoll { get; set; }
        public virtual DbSet<TblSuchtgiftschrankSchlüssel> TblSuchtgiftschrankSchlüssel { get; set; }
        public virtual DbSet<TblTextTemplates> TblTextTemplates { get; set; }
        public virtual DbSet<TblTextTemplatesFiles> TblTextTemplatesFiles { get; set; }
        public virtual DbSet<TblThemen> TblThemen { get; set; }
        public virtual DbSet<TblUidefinitions> TblUidefinitions { get; set; }
        public virtual DbSet<TblUserAccounts> TblUserAccounts { get; set; }
        public virtual DbSet<TblVeranstalter> TblVeranstalter { get; set; }
        public virtual DbSet<TblVersions> TblVersions { get; set; }
        public virtual DbSet<Textbausteine> Textbausteine { get; set; }
        public virtual DbSet<Unterbringung> Unterbringung { get; set; }
        public virtual DbSet<UrlaubVerlauf> UrlaubVerlauf { get; set; }
        public virtual DbSet<Vo> Vo { get; set; }
        public virtual DbSet<VoBestelldaten> VoBestelldaten { get; set; }
        public virtual DbSet<VoBestellpostitionen> VoBestellpostitionen { get; set; }
        public virtual DbSet<VoLager> VoLager { get; set; }
        public virtual DbSet<VoMedizinischeDaten> VoMedizinischeDaten { get; set; }
        public virtual DbSet<VoPflegeplanPdx> VoPflegeplanPdx { get; set; }
        public virtual DbSet<VoWunde> VoWunde { get; set; }
        public virtual DbSet<WundeKopf> WundeKopf { get; set; }
        public virtual DbSet<WundePos> WundePos { get; set; }
        public virtual DbSet<WundePosBilder> WundePosBilder { get; set; }
        public virtual DbSet<WundeTherapie> WundeTherapie { get; set; }
        public virtual DbSet<Zeitbereich> Zeitbereich { get; set; }
        public virtual DbSet<ZeitbereichSerien> ZeitbereichSerien { get; set; }
        public virtual DbSet<ZusatzEintrag> ZusatzEintrag { get; set; }
        public virtual DbSet<ZusatzGruppe> ZusatzGruppe { get; set; }
        public virtual DbSet<ZusatzGruppeEintrag> ZusatzGruppeEintrag { get; set; }
        public virtual DbSet<ZusatzWert> ZusatzWert { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=STYSRV10V;Initial Catalog=PMDSDev;Persist Security Info=True;User ID=hl;Password=NiwQs21+!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Abteilung>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piAbteilung")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.RmoptionalJn).HasColumnName("RMOptionalJN");

                entity.HasOne(d => d.IdklinikNavigation)
                    .WithMany(p => p.Abteilung)
                    .HasForeignKey(d => d.Idklinik)
                    .HasConstraintName("FK_Abteilung_Klinik");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Abteilung)
                    .HasForeignKey(d => d.Idkontakt)
                    .HasConstraintName("FK_Abteilung_Kontakt");
            });

            modelBuilder.Entity<AddIns>(entity =>
            {
                entity.ToTable("AddIns", "qs2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivatedAt).HasColumnType("datetime");

                entity.Property(e => e.ActivatedFrom)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddInName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dll)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piAdresse")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LandKz)
                    .IsRequired()
                    .HasColumnName("LandKZ")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plz)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aerzte>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ElgaOid)
                    .IsRequired()
                    .HasColumnName("ELGA_OID")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaOrganizationName)
                    .IsRequired()
                    .HasColumnName("ELGA_OrganizationName")
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaOrganizationOid)
                    .IsRequired()
                    .HasColumnName("ELGA_OrganizationOID")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgaabgeglichen).HasColumnName("ELGAAbgeglichen");

                entity.Property(e => e.Elgahausarzt).HasColumnName("ELGAHausarzt");

                entity.Property(e => e.Fachrichtung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Aerzte)
                    .HasForeignKey(d => d.Idadresse)
                    .HasConstraintName("FK_Aerzte_Adresse");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Aerzte)
                    .HasForeignKey(d => d.Idkontakt)
                    .HasConstraintName("FK_Aerzte_Kontakt");
            });

            modelBuilder.Entity<AnamneseKrohwinkel>(entity =>
            {
                entity.ToTable("Anamnese_Krohwinkel");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AktivitaetenBeschreibung).HasColumnType("text");

                entity.Property(e => e.AndereKontakte).HasColumnType("text");

                entity.Property(e => e.AngstVon).HasColumnType("text");

                entity.Property(e => e.AusscheidenPflegeplanungJn).HasColumnName("AusscheidenPflegeplanungJN");

                entity.Property(e => e.AusscheidenTagesstrukturJn).HasColumnName("AusscheidenTagesstrukturJN");

                entity.Property(e => e.Beruf).HasColumnType("text");

                entity.Property(e => e.BettgitterJn).HasColumnName("BettgitterJN");

                entity.Property(e => e.BewegenTagesstrukturJn).HasColumnName("BewegenTagesstrukturJN");

                entity.Property(e => e.Biographie).HasColumnType("text");

                entity.Property(e => e.BiographiePflegeplanungJn).HasColumnName("BiographiePflegeplanungJN");

                entity.Property(e => e.BiographieTagesstrukturJn).HasColumnName("BiographieTagesstrukturJN");

                entity.Property(e => e.BlutdruckZuckerRegelmaessigGemessenJn).HasColumnName("BlutdruckZuckerRegelmaessigGemessenJN");

                entity.Property(e => e.BrilleJn).HasColumnName("BrilleJN");

                entity.Property(e => e.DekubitusBeschreibung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DekubitusVorhandenJn).HasColumnName("DekubitusVorhandenJN");

                entity.Property(e => e.DiatSchonkostSondenernaehrung).HasColumnType("text");

                entity.Property(e => e.ErfahrungenPflegeplanungJn).HasColumnName("ErfahrungenPflegeplanungJN");

                entity.Property(e => e.ErfahrungenTagesstrukturJn).HasColumnName("ErfahrungenTagesstrukturJN");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.EssenTrinkenPflegeplanungJn).HasColumnName("EssenTrinkenPflegeplanungJN");

                entity.Property(e => e.EssenTrinkenTagesstrukturJn).HasColumnName("EssenTrinkenTagesstrukturJN");

                entity.Property(e => e.FruehstueckSpaetFruehEinnehmen)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GefausteteHandJn).HasColumnName("GefausteteHandJN");

                entity.Property(e => e.GehentJn).HasColumnName("GehentJN");

                entity.Property(e => e.GerneBeschaeftigtMit).HasColumnType("text");

                entity.Property(e => e.HaarBarttracht).HasColumnType("text");

                entity.Property(e => e.Haarpflege).HasColumnType("text");

                entity.Property(e => e.HilfeHerbeirufenJn).HasColumnName("HilfeHerbeirufenJN");

                entity.Property(e => e.HilfsmittelBenutzenJn).HasColumnName("HilfsmittelBenutzenJN");

                entity.Property(e => e.HilfsmittelZurMobilitaetJn).HasColumnName("HilfsmittelZurMobilitaetJN");

                entity.Property(e => e.HinlegenJn).HasColumnName("HinlegenJN");

                entity.Property(e => e.HinsetzenJn).HasColumnName("HinsetzenJN");

                entity.Property(e => e.HoergeraetJn).HasColumnName("HoergeraetJN");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.IstMisstraurischGegen).HasColumnType("text");

                entity.Property(e => e.KannBlaseDarmKontrollierenJn).HasColumnName("KannBlaseDarmKontrollierenJN");

                entity.Property(e => e.KannMitteilenJn).HasColumnName("KannMitteilenJN");

                entity.Property(e => e.KannSelbstBewegenJn).HasColumnName("KannSelbstBewegenJN");

                entity.Property(e => e.Keinekontakte).HasColumnType("text");

                entity.Property(e => e.Kleidung).HasColumnType("text");

                entity.Property(e => e.KniegelenkJn).HasColumnName("KniegelenkJN");

                entity.Property(e => e.KoerperlicheaktivitaetenJn).HasColumnName("KoerperlicheaktivitaetenJN");

                entity.Property(e => e.Koerperpflegemittel).HasColumnType("text");

                entity.Property(e => e.KoerperpflegemittelVersorger)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KompressionsstruempfeJn).HasColumnName("KompressionsstruempfeJN");

                entity.Property(e => e.Kontakte).HasColumnType("text");

                entity.Property(e => e.KontakteSelbsstaendigHerstellenJn).HasColumnName("KontakteSelbsstaendigHerstellenJN");

                entity.Property(e => e.KontrakturenBeschreibung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KontrakturenvorhandenJn).HasColumnName("KontrakturenvorhandenJN");

                entity.Property(e => e.LaufenJn).HasColumnName("LaufenJN");

                entity.Property(e => e.LeidetAnVerlustVon).HasColumnType("text");

                entity.Property(e => e.MaennlicheWeiblichePflegeperson).HasColumnType("text");

                entity.Property(e => e.MahlzeitInDerGemeinschaftJn).HasColumnName("MahlzeitInDerGemeinschaftJN");

                entity.Property(e => e.MakeUpSchmuck).HasColumnType("text");

                entity.Property(e => e.MaxGebEllenbogenJn).HasColumnName("MaxGebEllenbogenJN");

                entity.Property(e => e.Medikamente).HasColumnType("text");

                entity.Property(e => e.MedikamenteBlasenDarmfunktion).HasColumnType("text");

                entity.Property(e => e.MedikamenteRegelmaessigJn).HasColumnName("MedikamenteRegelmaessigJN");

                entity.Property(e => e.MittagsschlafJn).HasColumnName("MittagsschlafJN");

                entity.Property(e => e.NachtsNachschauenJn).HasColumnName("NachtsNachschauenJN");

                entity.Property(e => e.OhneHilfeZurechtJn).HasColumnName("OhneHilfeZurechtJN");

                entity.Property(e => e.Rasieren).HasColumnType("text");

                entity.Property(e => e.SchlafBesonderheiten).HasColumnType("text");

                entity.Property(e => e.SchlafGewohnheiten).HasColumnType("text");

                entity.Property(e => e.SchlafMedikamente).HasColumnType("text");

                entity.Property(e => e.SchlafPflegeplanungJn).HasColumnName("SchlafPflegeplanungJN");

                entity.Property(e => e.SchlafTagesstrukturJn).HasColumnName("SchlafTagesstrukturJN");

                entity.Property(e => e.SchlafenVonBis).HasColumnType("text");

                entity.Property(e => e.Schmerzen).HasColumnType("text");

                entity.Property(e => e.SchminkenJn).HasColumnName("SchminkenJN");

                entity.Property(e => e.SichBeschaeftigenPflegeplanungJn).HasColumnName("SichBeschaeftigenPflegeplanungJN");

                entity.Property(e => e.SichBeschaeftigenTagesstrukturJn).HasColumnName("SichBeschaeftigenTagesstrukturJN");

                entity.Property(e => e.SichFuehlenTagesstrukturJn).HasColumnName("SichFuehlenTagesstrukturJN");

                entity.Property(e => e.SichFuehlenpflegeplanungJn).HasColumnName("SichFuehlenpflegeplanungJN");

                entity.Property(e => e.SichKleidenPflegeplanungJn).HasColumnName("SichKleidenPflegeplanungJN");

                entity.Property(e => e.SichKleidenTagesstrukturJn).HasColumnName("SichKleidenTagesstrukturJN");

                entity.Property(e => e.SichPflegenPflegeplanungJn).HasColumnName("SichPflegenPflegeplanungJN");

                entity.Property(e => e.SichPflegenTagesstrukturJn).HasColumnName("SichPflegenTagesstrukturJN");

                entity.Property(e => e.SitzenJn).HasColumnName("SitzenJN");

                entity.Property(e => e.SondePegkomplett).HasColumnName("SondePEGKomplett");

                entity.Property(e => e.SorgeUm).HasColumnType("text");

                entity.Property(e => e.SozialePflegeplanungJn).HasColumnName("SozialePflegeplanungJN");

                entity.Property(e => e.SozialeTagesstrukturJn).HasColumnName("SozialeTagesstrukturJN");

                entity.Property(e => e.SpatzierenGehenJn).HasColumnName("SpatzierenGehenJN");

                entity.Property(e => e.SpeisenGetraenke).HasColumnType("text");

                entity.Property(e => e.SpeisenGetraenkeAblehnen).HasColumnType("text");

                entity.Property(e => e.SpitzfussstellungJn).HasColumnName("SpitzfussstellungJN");

                entity.Property(e => e.StehenJn).HasColumnName("StehenJN");

                entity.Property(e => e.SterbephaseBetreuung).HasColumnType("text");

                entity.Property(e => e.SturtzgefahrJn).HasColumnName("SturtzgefahrJN");

                entity.Property(e => e.TagesablaufsgestaltungHilfe).HasColumnType("text");

                entity.Property(e => e.TagesablaufsgestaltungHilfeJn).HasColumnName("TagesablaufsgestaltungHilfeJN");

                entity.Property(e => e.Tagsablauf).HasColumnType("text");

                entity.Property(e => e.ToilettenHilfsmittel).HasColumnType("text");

                entity.Property(e => e.ToilettengangHilfeJn).HasColumnName("ToilettengangHilfeJN");

                entity.Property(e => e.TreppenSteigenJn).HasColumnName("TreppenSteigenJN");

                entity.Property(e => e.UmgebungPflegeplanungJn).HasColumnName("UmgebungPflegeplanungJN");

                entity.Property(e => e.UmgebungTagesstrukturJn).HasColumnName("UmgebungTagesstrukturJN");

                entity.Property(e => e.VermisstBeschreibung).HasColumnType("text");

                entity.Property(e => e.Versorger).HasColumnType("text");

                entity.Property(e => e.VitaleFunkPflegeplanungJn).HasColumnName("VitaleFunkPflegeplanungJN");

                entity.Property(e => e.VitaleFunkTagesstrukturJn).HasColumnName("VitaleFunkTagesstrukturJN");

                entity.Property(e => e.Waeschewechsel).HasColumnType("text");

                entity.Property(e => e.WannWieOftSpatzieren).HasColumnType("text");

                entity.Property(e => e.WieHandhabenMitDuschenBaden).HasColumnType("text");

                entity.Property(e => e.Wuensche).HasColumnType("text");

                entity.Property(e => e.ZahnFusspflegeHilfeJn).HasColumnName("ZahnFusspflegeHilfeJN");

                entity.Property(e => e.ZeitKeineBesuche)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZeitenToiletteAufsuchen).HasColumnType("text");

                entity.Property(e => e.ZimmerVerschlossen).HasColumnType("text");
            });

            modelBuilder.Entity<AnamneseOrem>(entity =>
            {
                entity.ToTable("Anamnese_Orem");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abfuehrhilfen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AbhaengigePersonen).HasColumnType("text");

                entity.Property(e => e.AbhaengigePersonenJn).HasColumnName("AbhaengigePersonenJN");

                entity.Property(e => e.AeusserungenVonVerzweiflungVeraenderteLebensenergien).HasColumnType("text");

                entity.Property(e => e.Allergie).HasColumnType("text");

                entity.Property(e => e.AnderWundenHautlaesionen).HasColumnType("text");

                entity.Property(e => e.AnderWundenHautlaesionenIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnderWundenHautlaesionenJn).HasColumnName("AnderWundenHautlaesionenJN");

                entity.Property(e => e.AngehoerigeBetreuungskonzeptMiteinbeziehenJn).HasColumnName("AngehoerigeBetreuungskonzeptMiteinbeziehenJN");

                entity.Property(e => e.Angstzustaende).HasColumnType("text");

                entity.Property(e => e.AngstzustaendeJn).HasColumnName("AngstzustaendeJN");

                entity.Property(e => e.AtemProbleme).HasColumnType("text");

                entity.Property(e => e.AtemProblemeHilfeMassnahmenHilfsMittel).HasColumnType("text");

                entity.Property(e => e.AtemProblemeJn).HasColumnName("AtemProblemeJN");

                entity.Property(e => e.AtemProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.AussclagartigeHautveraend).HasColumnType("text");

                entity.Property(e => e.AussclagartigeHautveraendIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AussclagartigeHautveraendJn).HasColumnName("AussclagartigeHautveraendJN");

                entity.Property(e => e.BemerkbareTrauerreaktion).HasColumnType("text");

                entity.Property(e => e.BemerkbareTrauerreaktionJn).HasColumnName("BemerkbareTrauerreaktionJN");

                entity.Property(e => e.BeobachtungErnaehrungProbleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungFluessigkeitsprobleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungSichBewegen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenAspirationsrisiko).HasColumnType("text");

                entity.Property(e => e.BeobachtungenAtemProbleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungenAusscheidung).HasColumnType("text");

                entity.Property(e => e.BeobachtungenBehandlungsprogramm).HasColumnType("text");

                entity.Property(e => e.BeobachtungenBlutzirkulation).HasColumnType("text");

                entity.Property(e => e.BeobachtungenEigenPersonFaehigkeitenWertschaetzungen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenErsticken).HasColumnType("text");

                entity.Property(e => e.BeobachtungenFaehigkeitGesundheitszustand).HasColumnType("text");

                entity.Property(e => e.BeobachtungenFaehigkeitVorhandeneRessourcen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenGedankenRichtigZuVerarbeiten).HasColumnType("text");

                entity.Property(e => e.BeobachtungenGesungheitsfoerdendeMassnahmen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenGewalteinwirkungen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenInfoZurSituationUmsetzen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenKoerperTemp).HasColumnType("text");

                entity.Property(e => e.BeobachtungenKommunikationProbleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungenLebensanforderungen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenSchlafprobleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungenSchmerzen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenSelbstpflagedefizit).HasColumnType("text");

                entity.Property(e => e.BeobachtungenSexualitaet).HasColumnType("text");

                entity.Property(e => e.BeobachtungenSichBewegen).HasColumnType("text");

                entity.Property(e => e.BeobachtungenSozialesituation).HasColumnType("text");

                entity.Property(e => e.BeobachtungenStuhlgangProbleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungenUmgebungsveraenderung).HasColumnType("text");

                entity.Property(e => e.BeobachtungenUrinausscheidungProbleme).HasColumnType("text");

                entity.Property(e => e.BeobachtungenVeraenderteLebensenergien).HasColumnType("text");

                entity.Property(e => e.BeobachtungenVorVerletzugen).HasColumnType("text");

                entity.Property(e => e.Besuchswuensche)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BetreuungskonseptAngaben).HasColumnType("text");

                entity.Property(e => e.BewegungImBettBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bezugsperson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlutzirkulationStoerungen).HasColumnType("text");

                entity.Property(e => e.BlutzirkulationStoerungenJn).HasColumnName("BlutzirkulationStoerungenJN");

                entity.Property(e => e.Decubitus).HasColumnType("text");

                entity.Property(e => e.DepositenJn).HasColumnName("DepositenJN");

                entity.Property(e => e.Diaet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiaetSeit).HasColumnType("datetime");

                entity.Property(e => e.DurchgefuehrtMit).HasColumnType("text");

                entity.Property(e => e.EigeneKoerperAkzeptanzAngaben).HasColumnType("text");

                entity.Property(e => e.EigeneKoerperAkzeptanzJn).HasColumnName("EigeneKoerperAkzeptanzJN");

                entity.Property(e => e.EinschneidendeLebenssituationsveraenderungen).HasColumnType("text");

                entity.Property(e => e.ErkenntGesungheitsfoerdendeMassnahmenJn).HasColumnName("ErkenntGesungheitsfoerdendeMassnahmenJN");

                entity.Property(e => e.ErnaehrungArt)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ErnaehrungProbleme).HasColumnType("text");

                entity.Property(e => e.ErnaehrungProblemeJn).HasColumnName("ErnaehrungProblemeJN");

                entity.Property(e => e.ErnaehrungProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.ErstickenErhoehtesRisikoJn).HasColumnName("ErstickenErhoehtesRisikoJN");

                entity.Property(e => e.EssenTrinkenBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Essgewohnheiten)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaehigkeitEntscheidungenZuTreffenAngaben).HasColumnType("text");

                entity.Property(e => e.FaehigkeitEntscheidungenZuTreffenJn).HasColumnName("FaehigkeitEntscheidungenZuTreffenJN");

                entity.Property(e => e.FaehigkeitGedankenRichtigZuVerarbeitenJn).HasColumnName("FaehigkeitGedankenRichtigZuVerarbeitenJN");

                entity.Property(e => e.FaehigkeitGesundheitszustandAngaben).HasColumnType("text");

                entity.Property(e => e.FaehigkeitGesundheitszustandUmzugehenJn).HasColumnName("FaehigkeitGesundheitszustandUmzugehenJN");

                entity.Property(e => e.FaehigkeitLebensanforderungenBegegnenZuKoennenJn).HasColumnName("FaehigkeitLebensanforderungenBegegnenZuKoennenJN");

                entity.Property(e => e.FaehigkeitVorhandeneRessourcenZuErkennenJn).HasColumnName("FaehigkeitVorhandeneRessourcenZuErkennenJN");

                entity.Property(e => e.FamBeziehSozialeProbleme).HasColumnType("text");

                entity.Property(e => e.FamBeziehSozialeProblemeJn).HasColumnName("FamBeziehSozialeProblemeJN");

                entity.Property(e => e.FamBeziehSozialeSituation).HasColumnType("text");

                entity.Property(e => e.FluessigkeitenNahrungAspirationsrisikoJn).HasColumnName("FluessigkeitenNahrungAspirationsrisikoJN");

                entity.Property(e => e.Fluessigkeitsprobleme).HasColumnType("text");

                entity.Property(e => e.FluessigkeitsproblemeJn).HasColumnName("FluessigkeitsproblemeJN");

                entity.Property(e => e.FluessigkeitsproblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.FortbewegungZuFussBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FreizeitBerschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GelegtAm).HasColumnType("datetime");

                entity.Property(e => e.GesungheitsfoerdendeMassnahmen).HasColumnType("text");

                entity.Property(e => e.HaematomaPetechienBlutungen).HasColumnType("text");

                entity.Property(e => e.HaematomaPetechienBlutungenIn)
                    .HasColumnName("HaematomaPetechienBlutungenIN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HaematomaPetechienBlutungenJn).HasColumnName("HaematomaPetechienBlutungenJN");

                entity.Property(e => e.HarnableitungssystemArt)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HarnableitungssystemGelegtAm).HasColumnType("datetime");

                entity.Property(e => e.HaushaltBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HautProbleme).HasColumnType("text");

                entity.Property(e => e.HautProblemeJn).HasColumnName("HautProblemeJN");

                entity.Property(e => e.Hautturgor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HinweiseKoerpPsychGewalteinwirkungen).HasColumnType("text");

                entity.Property(e => e.HinweiseKoerpPsychGewalteinwirkungenJn).HasColumnName("HinweiseKoerpPsychGewalteinwirkungenJN");

                entity.Property(e => e.HinweiseVermehrteBeschaeftigung).HasColumnType("text");

                entity.Property(e => e.HinweiseVermehrteBeschaeftigungMitSeelischeTraumaJn).HasColumnName("HinweiseVermehrteBeschaeftigungMitSeelischeTraumaJN");

                entity.Property(e => e.HoergeraetLinksJn).HasColumnName("HoergeraetLinksJN");

                entity.Property(e => e.HoergeraetRechtsJn).HasColumnName("HoergeraetRechtsJN");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Infektionsgefahr).HasColumnType("text");

                entity.Property(e => e.InfektionsgefahrJn).HasColumnName("InfektionsgefahrJN");

                entity.Property(e => e.Intertrigo).HasColumnType("text");

                entity.Property(e => e.IntertrigoIn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IntertrigoJn).HasColumnName("IntertrigoJN");

                entity.Property(e => e.KannBehandlungsprogrammAkzeptierenJn).HasColumnName("KannBehandlungsprogrammAkzeptierenJN");

                entity.Property(e => e.KannInfoZurSituationUmsetzenJn).HasColumnName("KannInfoZurSituationUmsetzenJN");

                entity.Property(e => e.KleidenBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KoerperTempGefaehrdungJn).HasColumnName("KoerperTempGefaehrdungJN");

                entity.Property(e => e.KoerperTempVeraendertJn).HasColumnName("KoerperTempVeraendertJN");

                entity.Property(e => e.KoerperTempVeraenderungSeit).HasColumnType("datetime");

                entity.Property(e => e.KoerperpflageBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KommunikationProbleme).HasColumnType("text");

                entity.Property(e => e.KommunikationProblemeJn).HasColumnName("KommunikationProblemeJN");

                entity.Property(e => e.KommunikationSelbsthilfe).HasColumnType("text");

                entity.Property(e => e.Konfision)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KuenstlicheAusgang)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KuenstlicheAusgangSeit).HasColumnType("datetime");

                entity.Property(e => e.LetzterStuhlAm).HasColumnType("datetime");

                entity.Property(e => e.MobilImRollstuhlBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileKrankenpflage).HasColumnType("text");

                entity.Property(e => e.MoeglichkeitUmgebungsveraenderungAnzupassenJn).HasColumnName("MoeglichkeitUmgebungsveraenderungAnzupassenJN");

                entity.Property(e => e.MundschleimhautZustand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oedeme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PflegendenAngehoerigeProbleme).HasColumnType("text");

                entity.Property(e => e.RaucherJn).HasColumnName("RaucherJN");

                entity.Property(e => e.RueckenmarklaesionProbleme).HasColumnType("text");

                entity.Property(e => e.Schlafprobleme).HasColumnType("text");

                entity.Property(e => e.SchlafproblemeJn).HasColumnName("SchlafproblemeJN");

                entity.Property(e => e.SchlafproblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.SchmerzausloesendeFaktoren)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchmerzenArt)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SchmerzenAustrahlung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchmerzenHaeufigkeit)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SchmerzenJn).HasColumnName("SchmerzenJN");

                entity.Property(e => e.SchmerzenLokalisation).HasColumnType("text");

                entity.Property(e => e.SchmerzenSeit).HasColumnType("datetime");

                entity.Property(e => e.SchmerzlinderndeFaktoren)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchmerzverstaerkendeFaktoren)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchweissBesonderheiten)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SehhilfeBrilleJn).HasColumnName("SehhilfeBrilleJN");

                entity.Property(e => e.SehhilfeKontaktlinsenJn).HasColumnName("SehhilfeKontaktlinsenJN");

                entity.Property(e => e.SelbstpflagedefizitBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SelbstpflagedefizitGewohnheiten)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexualitaet).HasColumnType("text");

                entity.Property(e => e.SichBewegenProbleme).HasColumnType("text");

                entity.Property(e => e.SichBewegenProblemeJn).HasColumnName("SichBewegenProblemeJN");

                entity.Property(e => e.SichBewegenProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.Sinneswahrnehmung).HasColumnType("text");

                entity.Property(e => e.SinneswahrnehmungSonstigeAngaben).HasColumnType("text");

                entity.Property(e => e.SinneswahrnehmungUngestoertJn).HasColumnName("SinneswahrnehmungUngestoertJN");

                entity.Property(e => e.SituationVorDerSichFuerchten).HasColumnType("text");

                entity.Property(e => e.SituationVorDerSichFuerchtenJn).HasColumnName("SituationVorDerSichFuerchtenJN");

                entity.Property(e => e.Situationsauswirkung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SonstigeAtemProblemeAuftretung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sonstiges).HasColumnType("text");

                entity.Property(e => e.SozialeDienste).HasColumnType("text");

                entity.Property(e => e.Stillgewohnheiten)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezFarbe)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezGeruch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezHaeufigkeit)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezKonsistenz)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezMenge)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StuhlgangBesondereGewohnheiten).HasColumnType("text");

                entity.Property(e => e.StuhlgangProbleme).HasColumnType("text");

                entity.Property(e => e.StuhlgangProblemeJn).HasColumnName("StuhlgangProblemeJN");

                entity.Property(e => e.StuhlgangProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.Suizidversuche).HasColumnType("text");

                entity.Property(e => e.TracheostomaBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransferBettAussehalbBeschreibung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Trinkhilfen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UmfeldRealitaetsbezug).HasColumnType("text");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezFarbe)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezGeruch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezMenge)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UrinausscheidungProbleme).HasColumnType("text");

                entity.Property(e => e.UrinausscheidungProblemeJn).HasColumnName("UrinausscheidungProblemeJN");

                entity.Property(e => e.UrinausscheidungProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.VerstaendigungAn).HasColumnType("text");

                entity.Property(e => e.VorVerletzSturzKrankheitVergiftungSelbstSchuetzenJn).HasColumnName("VorVerletzSturzKrankheitVergiftungSelbstSchuetzenJN");

                entity.Property(e => e.ZahnKieferzustand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZahnersatzOkjn).HasColumnName("ZahnersatzOKJN");

                entity.Property(e => e.ZahnersatzUkjn).HasColumnName("ZahnersatzUKJN");

                entity.Property(e => e.ZuHauseAllesRegelnKoennenJn).HasColumnName("ZuHauseAllesRegelnKoennenJN");

                entity.Property(e => e.ZuHauseNichtRegelnKoennen).HasColumnType("text");

                entity.Property(e => e.ZungeAussehen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.AnamneseOrem)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anamnese_Orem_Benutzer");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.AnamneseOrem)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anamnese_Orem_Patient");
            });

            modelBuilder.Entity<AnamnesePop>(entity =>
            {
                entity.ToTable("Anamnese_POP");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abfuehrhilfen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AbhaengigePersonen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AbhaengigePersonenJn)
                    .IsRequired()
                    .HasColumnName("AbhaengigePersonenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AeusserungenVonVerzweiflungVeraenderteLebensenergien)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AeusserungenVonVerzweiflungVeraenderteLebensenergienJn)
                    .IsRequired()
                    .HasColumnName("AeusserungenVonVerzweiflungVeraenderteLebensenergienJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Allergie)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnderWundenHautlaesionen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnderWundenHautlaesionenIn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnderWundenHautlaesionenJn)
                    .IsRequired()
                    .HasColumnName("AnderWundenHautlaesionenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Angstzustaende)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AngstzustaendeJn)
                    .IsRequired()
                    .HasColumnName("AngstzustaendeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AtemProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AtemProblemeAuftretung).HasDefaultValueSql("('0')");

                entity.Property(e => e.AtemProblemeHilfeMassnahmenHilfsMittel)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AtemProblemeJn)
                    .IsRequired()
                    .HasColumnName("AtemProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AtemProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.AusschlagartigeHautveraend)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AusschlagartigeHautveraendIn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AusschlagartigeHautveraendJn)
                    .IsRequired()
                    .HasColumnName("AusschlagartigeHautveraendJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BelastendeFaktoren)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BemerkbareTrauerreaktion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BemerkbareTrauerreaktionJn)
                    .IsRequired()
                    .HasColumnName("BemerkbareTrauerreaktionJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BemerkbareTrauerreaktionSeit).HasColumnType("datetime");

                entity.Property(e => e.BeobachtungErnaehrungProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungFluessigkeitsprobleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungSichBewegen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BeobachtungenAngehoerige)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenAspirationsrisiko)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenAtemProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenAusscheidung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenBehandlungsprogramm)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenBlutzirkulation)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenEigenPersonFaehigkeitenWertschaetzungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenErsticken)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenFaehigkeitGesundheitszustand)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenFaehigkeitVorhandeneRessourcen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenFamilieBeeintraechtigungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenFamilieBereitschaft)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenGedankenRichtigZuVerarbeiten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenGesungheitsfoerdendeMassnahmen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenGewalteinwirkungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenInfoZurSituationUmsetzen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenKoerperTemp)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenKommunikationProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenLebensanforderungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenMobilitaetBeeintraechtigt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSchlafprobleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSchmerzen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSelbstpflegedefizit)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSexualitaet)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSichBewegen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSozialesituation)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenStuhlgangProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenSubjektivesSinneerleben)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenUmgebungsveraenderung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenUrinausscheidungProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenVeraenderteLebensenergien)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeobachtungenVorVerletzugen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Beschaeftigung).HasDefaultValueSql("('0')");

                entity.Property(e => e.BeschaeftigungBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Besuchswuensche)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BewegungImBett).HasDefaultValueSql("('0')");

                entity.Property(e => e.BewegungImBettBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezugsperson)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlutzirkulationStoerungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlutzirkulationStoerungenJn)
                    .IsRequired()
                    .HasColumnName("BlutzirkulationStoerungenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Bmi)
                    .HasColumnName("BMI")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Decubitus)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DecubitusSkala)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepositenJn)
                    .IsRequired()
                    .HasColumnName("DepositenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Diaet)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiaetSeit).HasColumnType("datetime");

                entity.Property(e => e.DurchgefuehrtMit)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Durstgefuehl).HasDefaultValueSql("('0')");

                entity.Property(e => e.EigenPersonFaehigkeitenWertschaetzungen).HasDefaultValueSql("('0')");

                entity.Property(e => e.EigeneKoerperAkzeptanzAngaben)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EigeneKoerperAkzeptanzJn)
                    .IsRequired()
                    .HasColumnName("EigeneKoerperAkzeptanzJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EinschneidendeLebenssituationsveraenderungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErkenntGesungheitsfoerdendeMassnahmenJn)
                    .IsRequired()
                    .HasColumnName("ErkenntGesungheitsfoerdendeMassnahmenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ErnaehrungArt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErnaehrungParenteralEnteral).HasDefaultValueSql("((2))");

                entity.Property(e => e.ErnaehrungProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErnaehrungProblemeJn)
                    .IsRequired()
                    .HasColumnName("ErnaehrungProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ErnaehrungProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EssenTrinken).HasDefaultValueSql("('0')");

                entity.Property(e => e.EssenTrinkenBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Essgewohnheiten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FaehigkeitEntscheidungenZuTreffenAngaben)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FaehigkeitEntscheidungenZuTreffenJn)
                    .IsRequired()
                    .HasColumnName("FaehigkeitEntscheidungenZuTreffenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FaehigkeitGedankenRichtigZuVerarbeitenJn)
                    .IsRequired()
                    .HasColumnName("FaehigkeitGedankenRichtigZuVerarbeitenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FaehigkeitGesundheitszustandAngaben)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FaehigkeitGesundheitszustandUmzugehenJn)
                    .IsRequired()
                    .HasColumnName("FaehigkeitGesundheitszustandUmzugehenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FaehigkeitLebensanforderungenBegegnenZuKoennenJn)
                    .IsRequired()
                    .HasColumnName("FaehigkeitLebensanforderungenBegegnenZuKoennenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FaehigkeitVorhandeneRessourcenZuErkennenJn)
                    .IsRequired()
                    .HasColumnName("FaehigkeitVorhandeneRessourcenZuErkennenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FamBeziehSozialeProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FamBeziehSozialeProblemeJn)
                    .IsRequired()
                    .HasColumnName("FamBeziehSozialeProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FamBeziehSozialeSituation)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FamilieBeeintraechtigungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FamilieBereitschaft)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FamilieZusammensetzung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FluessigkeitenNahrungAspirationsrisikoJn)
                    .IsRequired()
                    .HasColumnName("FluessigkeitenNahrungAspirationsrisikoJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Fluessigkeitsprobleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FluessigkeitsproblemeJn)
                    .IsRequired()
                    .HasColumnName("FluessigkeitsproblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FluessigkeitsproblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.FortbewegungZuFuss).HasDefaultValueSql("('0')");

                entity.Property(e => e.FortbewegungZuFussBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Freizeit).HasDefaultValueSql("('0')");

                entity.Property(e => e.FreizeitBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GelegtAm).HasColumnType("datetime");

                entity.Property(e => e.GesungheitsfoerdendeMassnahmen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Gewicht).HasDefaultValueSql("('0')");

                entity.Property(e => e.Groesse).HasDefaultValueSql("('0')");

                entity.Property(e => e.HaematomaPetechienBlutungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HaematomaPetechienBlutungenIn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HaematomaPetechienBlutungenJn)
                    .IsRequired()
                    .HasColumnName("HaematomaPetechienBlutungenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HarnableitungssystemArt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HarnableitungssystemGelegtAm).HasColumnType("datetime");

                entity.Property(e => e.HarnableitungssystemGrosse).HasDefaultValueSql("('0')");

                entity.Property(e => e.Haushalt).HasDefaultValueSql("('0')");

                entity.Property(e => e.HaushaltBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HautProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HautProblemeJn)
                    .IsRequired()
                    .HasColumnName("HautProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Hautturgor)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HinweiseKoerpPsychGewalteinwirkungen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HinweiseKoerpPsychGewalteinwirkungenJn)
                    .IsRequired()
                    .HasColumnName("HinweiseKoerpPsychGewalteinwirkungenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HinweiseVermehrteBeschaeftigung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HinweiseVermehrteBeschaeftigungMitSeelischeTraumaJn)
                    .IsRequired()
                    .HasColumnName("HinweiseVermehrteBeschaeftigungMitSeelischeTraumaJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HoergeraetLinksJn)
                    .IsRequired()
                    .HasColumnName("HoergeraetLinksJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HoergeraetRechtsJn)
                    .IsRequired()
                    .HasColumnName("HoergeraetRechtsJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Infektionsgefahr)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InfektionsgefahrJn)
                    .IsRequired()
                    .HasColumnName("InfektionsgefahrJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Intertrigo)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntertrigoIn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntertrigoJn)
                    .IsRequired()
                    .HasColumnName("IntertrigoJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KannBehandlungsprogrammAkzeptierenJn)
                    .IsRequired()
                    .HasColumnName("KannBehandlungsprogrammAkzeptierenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KannInfoZurSituationUmsetzenJn)
                    .IsRequired()
                    .HasColumnName("KannInfoZurSituationUmsetzenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KauSchluckVerhalten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Kleiden).HasDefaultValueSql("('0')");

                entity.Property(e => e.KleidenBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KoerperTemp).HasDefaultValueSql("('0')");

                entity.Property(e => e.KoerperTempGefaehrdungJn)
                    .IsRequired()
                    .HasColumnName("KoerperTempGefaehrdungJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KoerperTempVeraendertJn)
                    .IsRequired()
                    .HasColumnName("KoerperTempVeraendertJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KoerperTempVeraenderung).HasDefaultValueSql("('0')");

                entity.Property(e => e.KoerperTempVeraenderungSeit).HasColumnType("datetime");

                entity.Property(e => e.Koerperpflege).HasDefaultValueSql("('0')");

                entity.Property(e => e.KoerperpflegeBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KommunikationProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KommunikationProblemeJn)
                    .IsRequired()
                    .HasColumnName("KommunikationProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KommunikationSelbsthilfe)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KuenstlicheAusgang)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KuenstlicheAusgangSeit).HasColumnType("datetime");

                entity.Property(e => e.LetzterStuhlAm).HasColumnType("datetime");

                entity.Property(e => e.MobilImRollstuhl).HasDefaultValueSql("('0')");

                entity.Property(e => e.MobilImRollstuhlBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MobileKrankenpflege)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MobilitaetBeeintraechtigt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MobilitaetBeeintraechtigtJn)
                    .IsRequired()
                    .HasColumnName("MobilitaetBeeintraechtigtJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MobilitaetBeeintraechtigtSeit).HasColumnType("datetime");

                entity.Property(e => e.MoeglichkeitUmgebungsveraenderungAnzupassenJn)
                    .IsRequired()
                    .HasColumnName("MoeglichkeitUmgebungsveraenderungAnzupassenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MundschleimhautZustand)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Oedeme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RaucherJn)
                    .IsRequired()
                    .HasColumnName("RaucherJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReligioeseBeduerfnisse)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Schlafprobleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchlafproblemeJn)
                    .IsRequired()
                    .HasColumnName("SchlafproblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SchlafproblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.SchmerzausloesendeFaktoren)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchmerzenArt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchmerzenAustrahlung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchmerzenHaeufigkeit)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchmerzenIntensitaet).HasDefaultValueSql("('0')");

                entity.Property(e => e.SchmerzenJn)
                    .IsRequired()
                    .HasColumnName("SchmerzenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SchmerzenLokalisation)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchmerzenSeit).HasColumnType("datetime");

                entity.Property(e => e.SchmerzlinderndeFaktoren)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchmerzverstaerkendeFaktoren)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SchweissBesonderheiten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Schweisssekretion).HasDefaultValueSql("('0')");

                entity.Property(e => e.SehhilfeBrilleJn)
                    .IsRequired()
                    .HasColumnName("SehhilfeBrilleJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SehhilfeKontaktlinsenJn)
                    .IsRequired()
                    .HasColumnName("SehhilfeKontaktlinsenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Selbstorganisation).HasDefaultValueSql("('0')");

                entity.Property(e => e.SelbstorganisationJn)
                    .IsRequired()
                    .HasColumnName("SelbstorganisationJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SelbstorganisationtBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SelbstpflegeHarnNacht).HasDefaultValueSql("('0')");

                entity.Property(e => e.SelbstpflegeHarnTag).HasDefaultValueSql("('0')");

                entity.Property(e => e.SelbstpflegeStuhlNacht).HasDefaultValueSql("('0')");

                entity.Property(e => e.SelbstpflegeStuhlTag).HasDefaultValueSql("('0')");

                entity.Property(e => e.SelbstpflegedefizitBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SelbstpflegedefizitGewohnheiten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SelbstpflegedefizitJn)
                    .IsRequired()
                    .HasColumnName("SelbstpflegedefizitJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Sexualitaet)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SichBewegenProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SichBewegenProblemeJn)
                    .IsRequired()
                    .HasColumnName("SichBewegenProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SichBewegenProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.Sinneswahrnehmung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SinneswahrnehmungSonstigeAngaben)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SinneswahrnehmungUngestoertJn)
                    .IsRequired()
                    .HasColumnName("SinneswahrnehmungUngestoertJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SituationVorDerSichFuerchten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SituationVorDerSichFuerchtenJn)
                    .IsRequired()
                    .HasColumnName("SituationVorDerSichFuerchtenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Situationsauswirkung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SonstigeAtemProblemeAuftretung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SonstigeHilfen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sonstiges)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SozialeDienste)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Stillgewohnheiten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezFarbe)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezGeruch)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezHaeufigkeit)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezKonsistenz)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangAuffaelligkeitenVeraenderungBezMenge)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangBesondereGewohnheiten)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StuhlgangProblemeJn)
                    .IsRequired()
                    .HasColumnName("StuhlgangProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StuhlgangProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.SubjektivesSinneerlebenAngaben)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Suizidversuche)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tracheostoma).HasDefaultValueSql("('0')");

                entity.Property(e => e.TracheostomaBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TransferBettAussehalb).HasDefaultValueSql("('0')");

                entity.Property(e => e.TransferBettAussehalbBeschreibung)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trinkhilfen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trinkmenge).HasDefaultValueSql("('0')");

                entity.Property(e => e.UmfeldRealitaetsbezug)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezFarbe)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezGeruch)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezHaeufigkeitNachts).HasDefaultValueSql("('0')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezHaeufigkeitNachtsZeitabstand).HasDefaultValueSql("('0')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezHaeufigkeitTagsueber).HasDefaultValueSql("('0')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezHaeufigkeitTagsueberZeitabstand).HasDefaultValueSql("('0')");

                entity.Property(e => e.UrinAuffaelligkeitenVeraenderungBezMenge)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UrinausscheidungProbleme)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UrinausscheidungProblemeJn)
                    .IsRequired()
                    .HasColumnName("UrinausscheidungProblemeJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UrinausscheidungProblemeSeit).HasColumnType("datetime");

                entity.Property(e => e.VerstaendigungAn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Verwandschaftsverhältnis)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VorVerletzSturzKrankheitVergiftungSelbstSchuetzenJn)
                    .IsRequired()
                    .HasColumnName("VorVerletzSturzKrankheitVergiftungSelbstSchuetzenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WeitereBeteiligte)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZahnKieferzustand)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZahnersatzOkjn)
                    .IsRequired()
                    .HasColumnName("ZahnersatzOKJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ZahnersatzUkjn)
                    .IsRequired()
                    .HasColumnName("ZahnersatzUKJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ZuHauseAllesRegelnKoennenJn)
                    .IsRequired()
                    .HasColumnName("ZuHauseAllesRegelnKoennenJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ZuHauseNichtRegelnKoennen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZungeAussehen)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Anmeldungen>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Benutzer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogInDatum).HasColumnType("datetime");

                entity.Property(e => e.LogInNameFrei)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogOutDatum).HasColumnType("datetime");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ArchDoku>(entity =>
            {
                entity.ToTable("archDoku");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AbgelegtAm).HasColumnType("datetime");

                entity.Property(e => e.AbgelegtVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Archivordner)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BinIntern).HasColumnName("binIntern");

                entity.Property(e => e.DateinameArchiv)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateinameTyp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Db).HasColumnName("db");

                entity.Property(e => e.Doku).HasColumnName("doku");

                entity.Property(e => e.DokuOrig)
                    .IsRequired()
                    .HasColumnName("dokuOrig")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GültigBis).HasColumnType("datetime");

                entity.Property(e => e.GültigVon).HasColumnType("datetime");

                entity.Property(e => e.Idactivity).HasColumnName("IDActivity");

                entity.Property(e => e.Idordner).HasColumnName("IDOrdner");

                entity.Property(e => e.Idstatus)
                    .HasColumnName("IDStatus")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Idtyp)
                    .HasColumnName("IDTyp")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IntReleased)
                    .IsRequired()
                    .HasColumnName("intReleased")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Notiz)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RechNr)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wichtigkeit)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdordnerNavigation)
                    .WithMany(p => p.ArchDoku)
                    .HasForeignKey(d => d.Idordner)
                    .HasConstraintName("FK_archDoku_archOrdner2");
            });

            modelBuilder.Entity<ArchDokuSchlag>(entity =>
            {
                entity.ToTable("archDokuSchlag");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iddoku).HasColumnName("IDDoku");

                entity.Property(e => e.Schlagwort)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddokuNavigation)
                    .WithMany(p => p.ArchDokuSchlag)
                    .HasForeignKey(d => d.Iddoku)
                    .HasConstraintName("FK_tblDokumenteneintragSchlagwörter_tblDokumenteintrag2");
            });

            modelBuilder.Entity<ArchObject>(entity =>
            {
                entity.ToTable("archObject");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Iddoku).HasColumnName("IDDoku");

                entity.Property(e => e.Idobject).HasColumnName("IDObject");

                entity.Property(e => e.IdselList).HasColumnName("IDSelList");

                entity.HasOne(d => d.IddokuNavigation)
                    .WithMany(p => p.ArchObject)
                    .HasForeignKey(d => d.Iddoku)
                    .HasConstraintName("FK_arrObject_archDokuDetail");
            });

            modelBuilder.Entity<ArchOrdner>(entity =>
            {
                entity.ToTable("archOrdner");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Icon).HasColumnType("image");

                entity.Property(e => e.IdordnerMain).HasColumnName("IDOrdnerMain");

                entity.Property(e => e.Idsystemordner)
                    .HasColumnName("IDSystemordner")
                    .HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<Arztabrechnung>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Krankenkasse)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Leistung1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Leistung2)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Leistung3)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Svnr)
                    .IsRequired()
                    .HasColumnName("SVNr")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.Arztabrechnung)
                    .HasForeignKey(d => d.Idbenutzer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Arztabrechnung_Benutzer");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Arztabrechnung)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Arztabrechnung_Arztabrechnung");
            });

            modelBuilder.Entity<Aufenthalt>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piAufenthalt")
                    .IsUnique();

                entity.HasIndex(e => new { e.Idklinik, e.Id, e.Idpatient })
                    .HasName("_dta_index_Aufenthalt_6_373576369__K1_K2_46");

                entity.HasIndex(e => new { e.Idbereich, e.Idklinik, e.Idabteilung, e.Id, e.Idpatient })
                    .HasName("_dta_index_Aufenthalt_6_373576369__K47_K46_K3_K1_K2");

                entity.HasIndex(e => new { e.Entlassungszeitpunkt, e.Idbereich, e.Idklinik, e.Idabteilung, e.Id, e.Idpatient })
                    .HasName("_dta_index_Aufenthalt_6_373576369__K47_K46_K3_K1_K2_10");

                entity.HasIndex(e => new { e.Id, e.Idabteilung, e.Idbereich, e.Idklinik, e.Entlassungszeitpunkt, e.Idpatient })
                    .HasName("_dta_index_Aufenthalt_6_736825787__K37_K10_K2_1_3_38");

                entity.HasIndex(e => new { e.Idabteilung, e.IdaufenthaltVerlauf, e.IdbenutzerAufnahme, e.IdbenutzerEntlassung, e.IdeinrichtungAufnahme, e.IdeinrichtungEntlassung, e.Aufnahmezeitpunkt, e.AufnahmeArt, e.BegleitungVon, e.SomatischeAuff, e.PsychischeAuff, e.VerhaltenAufnahme, e.SonstigeBesonderheiten, e.SofortMassnahmen, e.Idurlaub, e.BarcodeId, e.Fallnummer, e.Gruppenkennzahl, e.Verfuegungsdatum, e.Bermerkung, e.Besuchsregelung, e.Postregelung, e.SonstigeRegelung, e.Erwartungen, e.Iderstkontakt, e.Gewicht, e.NaechsteEvaluierung, e.NaechsteEvaluierungBemerkung, e.TaschengeldSollstand, e.TaschegeldVortragDatum, e.TaschengeldVortragBetrag, e.Ausgleichszahlung, e.Idklinik, e.Idbereich, e.Idpatient, e.Entlassungszeitpunkt, e.Id })
                    .HasName("_dta_index_Aufenthalt_6_736825787__K2_K10_K1_3_4_5_6_7_8_9_11_12_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32_33_");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aufnahmezeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.BarcodeId)
                    .HasColumnName("BarcodeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BegleitungVon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bermerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Besuchsregelung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ElgacontactId)
                    .IsRequired()
                    .HasColumnName("ELGAContactID")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgasoogrund)
                    .IsRequired()
                    .HasColumnName("ELGASOOGrund")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgasooiduser)
                    .IsRequired()
                    .HasColumnName("ELGASOOIDUser")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgasoojn).HasColumnName("ELGASOOJN");

                entity.Property(e => e.Elgassoodatum)
                    .HasColumnName("ELGASSOODatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Entlassungsbemerkung).HasColumnType("text");

                entity.Property(e => e.Entlassungszeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.Erwartungen)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gruppenkennzahl)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.IdaufenthaltVerlauf).HasColumnName("IDAufenthaltVerlauf");

                entity.Property(e => e.IdbenutzerAufnahme).HasColumnName("IDBenutzer_Aufnahme");

                entity.Property(e => e.IdbenutzerEntlassung).HasColumnName("IDBenutzer_Entlassung");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.IdeinrichtungAufnahme).HasColumnName("IDEinrichtung_Aufnahme");

                entity.Property(e => e.IdeinrichtungEntlassung).HasColumnName("IDEinrichtung_Entlassung");

                entity.Property(e => e.Iderstkontakt).HasColumnName("IDErstkontakt");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idurlaub).HasColumnName("IDUrlaub");

                entity.Property(e => e.InfoDienstuebergabe)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaechsteEvaluierung).HasColumnType("datetime");

                entity.Property(e => e.NaechsteEvaluierungBemerkung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Postregelung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PsychischeAuff)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SofortMassnahmen)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SomatischeAuff)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SonstigeBesonderheiten)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SonstigeRegelung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Soozeitpunkt)
                    .HasColumnName("SOOZeitpunkt")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaschegeldVortragDatum).HasColumnType("datetime");

                entity.Property(e => e.Verfuegungsdatum).HasColumnType("datetime");

                entity.Property(e => e.VerhaltenAufnahme)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZeitpunktBlisterlisteAufnahme).HasColumnType("datetime");

                entity.Property(e => e.ZeitpunktBlisterlisteEntlassung).HasColumnType("datetime");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.Aufenthalt)
                    .HasForeignKey(d => d.Idabteilung)
                    .HasConstraintName("FK_Aufenthalt_Abteilung");

                entity.HasOne(d => d.IdbenutzerAufnahmeNavigation)
                    .WithMany(p => p.AufenthaltIdbenutzerAufnahmeNavigation)
                    .HasForeignKey(d => d.IdbenutzerAufnahme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aufenthalt_Benutzer2");

                entity.HasOne(d => d.IdbenutzerEntlassungNavigation)
                    .WithMany(p => p.AufenthaltIdbenutzerEntlassungNavigation)
                    .HasForeignKey(d => d.IdbenutzerEntlassung)
                    .HasConstraintName("FK_Aufenthalt_Benutzer3");

                entity.HasOne(d => d.IdeinrichtungAufnahmeNavigation)
                    .WithMany(p => p.AufenthaltIdeinrichtungAufnahmeNavigation)
                    .HasForeignKey(d => d.IdeinrichtungAufnahme)
                    .HasConstraintName("FK_Aufenthalt_Einrichtung1");

                entity.HasOne(d => d.IdeinrichtungEntlassungNavigation)
                    .WithMany(p => p.AufenthaltIdeinrichtungEntlassungNavigation)
                    .HasForeignKey(d => d.IdeinrichtungEntlassung)
                    .HasConstraintName("FK_Aufenthalt_Einrichtung2");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Aufenthalt)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Aufenthalt_Patient");
            });

            modelBuilder.Entity<AufenthaltPdx>(entity =>
            {
                entity.ToTable("AufenthaltPDx");

                entity.HasIndex(e => e.Id)
                    .HasName("piAufenthaltPDx")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.StartDatum, e.Idevaluierung, e.LokalisierungJn, e.Lokalisierung, e.LokalisierungSeite, e.Resourceklient, e.NaechsteEvaluierung, e.NaechsteEvaluierungBemerkung, e.EndeDatum, e.ErledigtGrund, e.IdbenutzerErstellt, e.IdbenutzerBeendet, e.DatumErstellt, e.DatumGeaendert, e.Idaufenthalt, e.Wundejn, e.ErledigtJn, e.Idpdx })
                    .HasName("_dta_index_AufenthaltPDx_5_501576825__K2_K19_K7_K3_1_4_5_6_8_9_10_11_12_13_14_15_16_17_18");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.EndeDatum).HasColumnType("datetime");

                entity.Property(e => e.ErledigtGrund)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ErledigtJn).HasColumnName("ErledigtJN");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.IdbenutzerBeendet).HasColumnName("IDBenutzer_Beendet");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.Idevaluierung).HasColumnName("IDEvaluierung");

                entity.Property(e => e.Idpdx).HasColumnName("IDPDX");

                entity.Property(e => e.Lokalisierung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LokalisierungJn).HasColumnName("LokalisierungJN");

                entity.Property(e => e.LokalisierungSeite)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaechsteEvaluierung).HasColumnType("datetime");

                entity.Property(e => e.NaechsteEvaluierungBemerkung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Resourceklient)
                    .HasColumnName("resourceklient")
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.Wundejn).HasColumnName("wundejn");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.AufenthaltPdx)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AufenthaltPDx_Aufenthalt");

                entity.HasOne(d => d.IdpdxNavigation)
                    .WithMany(p => p.AufenthaltPdx)
                    .HasForeignKey(d => d.Idpdx)
                    .HasConstraintName("FK_AufenthaltPDx_PDX");
            });

            modelBuilder.Entity<AufenthaltVerlauf>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piAufenthaltVerlauf")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.Idbenutzer, e.IdabteilungVon, e.IdabteilungNach, e.Idbereich, e.ZuweisenderArzt, e.AufnahmeArzt, e.Idaufenthalt, e.Datum })
                    .HasName("_dta_index_AufenthaltVerlauf_5_517576882__K2_K8_1_3_4_5_6_9_10");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abschlussbemerkung).HasColumnType("text");

                entity.Property(e => e.AufnahmeArzt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AufnahmeStatus).HasColumnType("text");

                entity.Property(e => e.Aufnahmegespraech).HasColumnType("text");

                entity.Property(e => e.Bemerkung).HasColumnType("text");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.IdabteilungNach).HasColumnName("IDAbteilung_Nach");

                entity.Property(e => e.IdabteilungVon).HasColumnName("IDAbteilung_Von");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.ZuweisenderArzt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdabteilungNachNavigation)
                    .WithMany(p => p.AufenthaltVerlaufIdabteilungNachNavigation)
                    .HasForeignKey(d => d.IdabteilungNach)
                    .HasConstraintName("FK_AufenthaltVerlauf_Abteilung1");

                entity.HasOne(d => d.IdabteilungVonNavigation)
                    .WithMany(p => p.AufenthaltVerlaufIdabteilungVonNavigation)
                    .HasForeignKey(d => d.IdabteilungVon)
                    .HasConstraintName("FK_AufenthaltVerlauf_Abteilung");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.AufenthaltVerlauf)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AufenthaltVerlauf_Aufenthalt");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.AufenthaltVerlauf)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_AufenthaltVerlauf_Benutzer");

                entity.HasOne(d => d.IdbereichNavigation)
                    .WithMany(p => p.AufenthaltVerlauf)
                    .HasForeignKey(d => d.Idbereich)
                    .HasConstraintName("FK_AufenthaltVerlauf_Bereich");
            });

            modelBuilder.Entity<AufenthaltZusatz>(entity =>
            {
                entity.HasIndex(e => e.Idaufenthalt)
                    .HasName("IX_AufenthaltZusatz")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.OffeneRechnungJn).HasColumnName("OffeneRechnungJN");

                entity.Property(e => e.SozialhilfeAntragDatum).HasColumnType("datetime");

                entity.Property(e => e.SozialhilfeBescheidGz)
                    .IsRequired()
                    .HasColumnName("SozialhilfeBescheidGZ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SozialhilfeBescheidJn).HasColumnName("SozialhilfeBescheidJN");

                entity.Property(e => e.Zimmernummer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithOne(p => p.AufenthaltZusatz)
                    .HasForeignKey<AufenthaltZusatz>(d => d.Idaufenthalt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AufenthaltZusatz_Aufenthalt");
            });

            modelBuilder.Entity<AuswahlListe>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piAuswahlListe")
                    .IsUnique();

                entity.HasIndex(e => new { e.Bezeichnung, e.GehörtzuGruppe, e.Hierarche, e.IdauswahlListeGruppe, e.Id })
                    .HasName("_dta_index_AuswahlListe_6_181575685__K2_K1_4_6_7");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ElgaCode)
                    .IsRequired()
                    .HasColumnName("ELGA_Code")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaCodeSystem)
                    .IsRequired()
                    .HasColumnName("ELGA_CodeSystem")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaDisplayName)
                    .IsRequired()
                    .HasColumnName("ELGA_DisplayName")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaId).HasColumnName("ELGA_ID");

                entity.Property(e => e.GehörtzuGruppe)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hierarche).HasDefaultValueSql("((-1))");

                entity.Property(e => e.IdauswahlListeGruppe)
                    .HasColumnName("IDAuswahlListeGruppe")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdauswahlListeGruppeNavigation)
                    .WithMany(p => p.AuswahlListe)
                    .HasForeignKey(d => d.IdauswahlListeGruppe)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AuswahlListe_AuswahlListeGruppe");
            });

            modelBuilder.Entity<AuswahlListeGruppe>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piAuswahlListeGruppe")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PflichtJn).HasColumnName("PflichtJN");

                entity.Property(e => e.Sys).HasColumnName("sys");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bic)
                    .HasColumnName("BIC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Blz).HasColumnName("BLZ");

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");
            });

            modelBuilder.Entity<BarcodeQ>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVerarbeitet).HasColumnType("datetime");

                entity.Property(e => e.FertigJn).HasColumnName("FertigJN");

                entity.Property(e => e.Idpflegeplan).HasColumnName("IDPflegeplan");

                entity.Property(e => e.IduserIdskipped).HasColumnName("IDUserIDSkipped");

                entity.Property(e => e.IduserVerarbeitet).HasColumnName("IDUserVerarbeitet");

                entity.Property(e => e.ScanZeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.ScannerId)
                    .IsRequired()
                    .HasColumnName("ScannerID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScannerZeitpunktChar)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Belegung>(entity =>
            {
                entity.HasIndex(e => new { e.Idabteilung, e.Tag })
                    .HasName("IX_Belegung")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Belegung1).HasColumnName("Belegung");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Tag).HasColumnType("datetime");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.Belegung)
                    .HasForeignKey(d => d.Idabteilung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Belegung_Abteilung");
            });

            modelBuilder.Entity<Benutzer>(entity =>
            {
                entity.HasIndex(e => e.Benutzer1)
                    .HasName("uiBenutzer")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("piBenutzer")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vorname, e.Nachname, e.Benutzer1, e.Id })
                    .HasName("_dta_index_Benutzer_6_325576198__K1_4_5_6");

                entity.HasIndex(e => new { e.Id, e.Idadresse, e.Idkontakt, e.Vorname, e.Benutzer1, e.Passwort, e.AktivJn, e.PflegerJn, e.Idberufsstand, e.BarcodeId, e.Eintrittsdatum, e.Austrittsdatum, e.SmtpSrv, e.SmtpPort, e.SmtpAbsender, e.SmtpPwd, e.SmtpAuthentStandard, e.IsGeneric, e.Idarzt, e.ArztabrechnungJn, e.Signatur, e.Nachname })
                    .HasName("_dta_index_Benutzer_6_325576198__K5_1_2_3_4_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AktivJn).HasColumnName("AktivJN");

                entity.Property(e => e.ArztabrechnungJn).HasColumnName("ArztabrechnungJN");

                entity.Property(e => e.Austrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.BarcodeId)
                    .HasColumnName("BarcodeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Benutzer1)
                    .HasColumnName("Benutzer")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Eintrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.ElgaAuthorSpeciality)
                    .IsRequired()
                    .HasColumnName("ELGA_AuthorSpeciality")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgaactive).HasColumnName("ELGAActive");

                entity.Property(e => e.ElgaautoLogin).HasColumnName("ELGAAutoLogin");

                entity.Property(e => e.ElgaautostartSession).HasColumnName("ELGAAutostartSession");

                entity.Property(e => e.ElgapatId)
                    .IsRequired()
                    .HasColumnName("ELGAPatID")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgauser)
                    .IsRequired()
                    .HasColumnName("ELGAUser")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgavalidTrough)
                    .HasColumnName("ELGAValidTrough")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idarzt).HasColumnName("IDArzt");

                entity.Property(e => e.Idberufsstand).HasColumnName("IDBerufsstand");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Passwort)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PflegerJn).HasColumnName("PflegerJN");

                entity.Property(e => e.Signatur)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SmtpAbsender)
                    .IsRequired()
                    .HasColumnName("smtpAbsender")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SmtpAuthentStandard).HasColumnName("smtpAuthentStandard");

                entity.Property(e => e.SmtpPort).HasColumnName("smtpPort");

                entity.Property(e => e.SmtpPwd)
                    .IsRequired()
                    .HasColumnName("smtpPwd")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SmtpSrv)
                    .IsRequired()
                    .HasColumnName("smtpSrv")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Benutzer)
                    .HasForeignKey(d => d.Idadresse)
                    .HasConstraintName("FK_Benutzer_Adresse");

                entity.HasOne(d => d.IdberufsstandNavigation)
                    .WithMany(p => p.Benutzer)
                    .HasForeignKey(d => d.Idberufsstand)
                    .HasConstraintName("FK_Benutzer_AuswahlListe");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Benutzer)
                    .HasForeignKey(d => d.Idkontakt)
                    .HasConstraintName("FK_Benutzer_Kontakt");
            });

            modelBuilder.Entity<BenutzerAbteilung>(entity =>
            {
                entity.HasIndex(e => new { e.Idabteilung, e.Idbenutzer })
                    .HasName("IDX_BenutzerAbteilung")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");
            });

            modelBuilder.Entity<BenutzerBezug>(entity =>
            {
                entity.HasIndex(e => new { e.IdaufenthaltVerlauf, e.Idbenutzer })
                    .HasName("IDX_BenutzerBezug")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdaufenthaltVerlauf).HasColumnName("IDAufenthaltVerlauf");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");
            });

            modelBuilder.Entity<BenutzerEinrichtung>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Ideinrichtung).HasColumnName("IDEinrichtung");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.BenutzerEinrichtung)
                    .HasForeignKey(d => d.Idbenutzer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BenutzerEinrichtung_Benutzer");

                entity.HasOne(d => d.IdeinrichtungNavigation)
                    .WithMany(p => p.BenutzerEinrichtung)
                    .HasForeignKey(d => d.Ideinrichtung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BenutzerEinrichtung_Einrichtung");
            });

            modelBuilder.Entity<BenutzerGruppe>(entity =>
            {
                entity.HasIndex(e => new { e.Idgruppe, e.Idbenutzer })
                    .HasName("IDX_BenutzerGruppe")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idgruppe).HasColumnName("IDGruppe");
            });

            modelBuilder.Entity<BenutzerRechte>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idrecht).HasColumnName("IDRecht");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.BenutzerRechte)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_BenutzerRechte_Benutzer");
            });

            modelBuilder.Entity<Bereich>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piBereich")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bereichstyp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.UnterAerztlicheFuehrungJn).HasColumnName("UnterAerztlicheFuehrungJN");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.Bereich)
                    .HasForeignKey(d => d.Idabteilung)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Bereich_Abteilung");

                entity.HasOne(d => d.IdbereichNavigation)
                    .WithMany(p => p.InverseIdbereichNavigation)
                    .HasForeignKey(d => d.Idbereich)
                    .HasConstraintName("FK_Bereich_Bereich");
            });

            modelBuilder.Entity<BereichBenutzer>(entity =>
            {
                entity.HasKey(e => new { e.Idbereich, e.Idbenutzer })
                    .HasName("PK_AbteilungBereichBenutzer");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.BereichBenutzer)
                    .HasForeignKey(d => d.Idbenutzer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbteilungBereichBenutzer_Benutzer");

                entity.HasOne(d => d.IdbereichNavigation)
                    .WithMany(p => p.BereichBenutzer)
                    .HasForeignKey(d => d.Idbereich)
                    .HasConstraintName("FK_AbteilungBereichBenutzer_Bereich");
            });

            modelBuilder.Entity<BillHeader>(entity =>
            {
                entity.ToTable("billHeader");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DbCalc)
                    .IsRequired()
                    .HasColumnName("dbCalc")
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Protokoll)
                    .IsRequired()
                    .HasColumnName("protokoll")
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Betrag)
                    .HasColumnName("betrag")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbBill)
                    .IsRequired()
                    .HasColumnName("dbBill")
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstellAm).HasColumnType("datetime");

                entity.Property(e => e.Erstellt)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExportiertJn).HasColumnName("ExportiertJN");

                entity.Property(e => e.Idabrechnung)
                    .IsRequired()
                    .HasColumnName("IDAbrechnung")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdbillStorno)
                    .IsRequired()
                    .HasColumnName("IDBillStorno")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdbillsGerollt)
                    .IsRequired()
                    .HasColumnName("IDBillsGerollt")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklient)
                    .IsRequired()
                    .HasColumnName("IDKlient")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idkost)
                    .IsRequired()
                    .HasColumnName("IDKost")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdkostIntern)
                    .IsRequired()
                    .HasColumnName("IDKostIntern")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idsr)
                    .IsRequired()
                    .HasColumnName("IDSR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KlientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KostenträgerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RechDatum).HasColumnType("datetime");

                entity.Property(e => e.RechNr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rechnung)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.ToTable("bookings");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Betrag).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Buchungsdatum).HasColumnType("datetime");

                entity.Property(e => e.ErstellAm).HasColumnType("datetime");

                entity.Property(e => e.Erstellt)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Habenkonto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklient)
                    .IsRequired()
                    .HasColumnName("IDKlient")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idkostenträger)
                    .IsRequired()
                    .HasColumnName("IDKostenträger")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MwstSatz).HasColumnName("MWStSatz");

                entity.Property(e => e.RechNr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sollkonto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Dblizenz>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK__DBLizenz__DF3675D3B65F9CC1");

                entity.ToTable("DBLizenz");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lizenz)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Dbversion>(entity =>
            {
                entity.ToTable("DBVersion");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ScriptVersion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Dienstzeiten>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK__Dienstze__DF3675D3DE503E36");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.VerwendenIn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Von).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dokumente>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aenderungsdatum).HasColumnType("datetime");

                entity.Property(e => e.Erstellungsdatum).HasColumnType("datetime");

                entity.Property(e => e.Gruppe)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Idobject).HasColumnName("IDObject");

                entity.Property(e => e.Inhalt).HasColumnType("image");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.DokumenteIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dokumente_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.DokumenteIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dokumente_Benutzer1");
            });

            modelBuilder.Entity<Dokumente2>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abteilungen)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Benutzergruppen)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ByteDoc).HasColumnName("byteDoc");

                entity.Property(e => e.ByteJpg).HasColumnName("byteJpg");

                entity.Property(e => e.DokumentenName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasColumnName("fileType")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idrelation).HasColumnName("IDRelation");

                entity.Property(e => e.TypeDocu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Einrichtung>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piEinrichtung")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ElgaOid)
                    .IsRequired()
                    .HasColumnName("ELGA_OID")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgaabgeglichen).HasColumnName("ELGAAbgeglichen");

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.IstKrankenkasse)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Einrichtung)
                    .HasForeignKey(d => d.Idadresse)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Einrichtung_Adresse");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Einrichtung)
                    .HasForeignKey(d => d.Idkontakt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Einrichtung_Kontakt");
            });

            modelBuilder.Entity<Eintrag>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piEintrag")
                    .IsUnique();

                entity.HasIndex(e => new { e.Sicht, e.Text, e.Id, e.EintragGruppe })
                    .HasName("_dta_index_Eintrag_6_2073058421__K1_K2_4_6");

                entity.HasIndex(e => new { e.Id, e.Sicht, e.Warnhinweis, e.Flag, e.IdlinkDokument, e.BedarfsMedikationJn, e.OhneZeitBezug, e.EintragGruppe, e.EntferntJn, e.Text })
                    .HasName("_dta_index_Eintrag_5_2073058421__K2_K3_K6_1_4_5_7_8_9_10");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BedarfsMedikationJn).HasColumnName("BedarfsMedikationJN");

                entity.Property(e => e.EintragGruppe)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EntferntJn).HasColumnName("EntferntJN");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdlinkDokument).HasColumnName("IDLinkDokument");

                entity.Property(e => e.LstFormulare)
                    .IsRequired()
                    .HasColumnName("lstFormulare")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sicht)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Warnhinweis)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EintragStandardprozeduren>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.IdstandardProzeduren).HasColumnName("IDStandardProzeduren");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.EintragStandardprozeduren)
                    .HasForeignKey(d => d.Ideintrag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EintragStandardprozeduren_Eintrag");

                entity.HasOne(d => d.IdstandardProzedurenNavigation)
                    .WithMany(p => p.EintragStandardprozeduren)
                    .HasForeignKey(d => d.IdstandardProzeduren)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EintragStandardprozeduren_StandardProzeduren");
            });

            modelBuilder.Entity<EintragZusatz>(entity =>
            {
                entity.HasKey(e => new { e.Ideintrag, e.Idabteilung })
                    .HasName("pkEintragZusatz");

                entity.HasIndex(e => new { e.Ideintrag, e.Idabteilung })
                    .HasName("piEintragZusatz")
                    .IsUnique();

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.EinmaligJn).HasColumnName("EinmaligJN");

                entity.Property(e => e.Idberufsstand).HasColumnName("IDBerufsstand");

                entity.Property(e => e.Idmassnahmenserien).HasColumnName("IDMassnahmenserien");

                entity.Property(e => e.Idzeitbereich).HasColumnName("IDZeitbereich");

                entity.Property(e => e.IdzeitbereichSerien).HasColumnName("IDZeitbereichSerien");

                entity.Property(e => e.LokalisierungJn).HasColumnName("LokalisierungJN");

                entity.Property(e => e.ParalellJn).HasColumnName("ParalellJN");

                entity.Property(e => e.RmoptionalJn).HasColumnName("RMOptionalJN");

                entity.Property(e => e.UntertaegigJn).HasColumnName("UntertaegigJN");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.EintragZusatz)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_EintragZusatz_Eintrag");

                entity.HasOne(d => d.IdmassnahmenserienNavigation)
                    .WithMany(p => p.EintragZusatz)
                    .HasForeignKey(d => d.Idmassnahmenserien)
                    .HasConstraintName("FK_EintragZusatz_Massnahmenserie");

                entity.HasOne(d => d.IdzeitbereichNavigation)
                    .WithMany(p => p.EintragZusatz)
                    .HasForeignKey(d => d.Idzeitbereich)
                    .HasConstraintName("FK_EintragZusatz_Zeitbereich");

                entity.HasOne(d => d.IdzeitbereichSerienNavigation)
                    .WithMany(p => p.EintragZusatz)
                    .HasForeignKey(d => d.IdzeitbereichSerien)
                    .HasConstraintName("FK_EintragZusatz_ZeitbereichSerien");
            });

            modelBuilder.Entity<Elgaactivities>(entity =>
            {
                entity.ToTable("ELGAActivities");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaactivityAt)
                    .HasColumnName("ELGAActivityAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ElgaactivityFrom)
                    .IsRequired()
                    .HasColumnName("ELGAActivityFrom")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Entalssungsgrund)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EntlassenAm).HasColumnType("datetime");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.Elgaactivities)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_ELGAActivities_Aufenthalt");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Elgaactivities)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_ELGAActivities_Patient");
            });

            modelBuilder.Entity<Elgacontacts>(entity =>
            {
                entity.ToTable("ELGAContacts");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedFrom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgacontactId)
                    .IsRequired()
                    .HasColumnName("ELGAContactID")
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idarzt).HasColumnName("IDArzt");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.HasOne(d => d.IdarztNavigation)
                    .WithMany(p => p.Elgacontacts)
                    .HasForeignKey(d => d.Idarzt)
                    .HasConstraintName("FK_ELGAContacts_Aerzte");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Elgacontacts)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_ELGAContacts_Patient");
            });

            modelBuilder.Entity<Elgadocuments>(entity =>
            {
                entity.ToTable("ELGADocuments");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedFrom)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Docu).HasColumnName("docu");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idelga)
                    .IsRequired()
                    .HasColumnName("IDElga")
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendetAt).HasColumnType("datetime");

                entity.Property(e => e.SendetFrom)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetId).HasColumnName("SetID");

                entity.Property(e => e.VersionsNr)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VidiertAt).HasColumnType("datetime");

                entity.Property(e => e.VidiertFrom)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.Elgadocuments)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_ELGADocuments_Aufenthalt");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Elgadocuments)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_ELGADocuments_Patient");
            });

            modelBuilder.Entity<Elgaprotocoll>(entity =>
            {
                entity.ToTable("ELGAProtocoll");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Characteristics)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgaerrors)
                    .IsRequired()
                    .HasColumnName("ELGAErrors")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Elgafunctions)
                    .IsRequired()
                    .HasColumnName("ELGAFunctions")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Protocoll)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Essen>(entity =>
            {
                entity.HasIndex(e => e.Tag)
                    .HasName("IX_Essen")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tag).HasColumnType("datetime");
            });

            modelBuilder.Entity<Formular>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.Name, e.Id, e.Bezeichnung })
                    .HasName("_dta_index_Formular_c_5_2089058478__K2_K1_K3")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Blop)
                    .IsRequired()
                    .HasColumnName("BLOP")
                    .HasColumnType("text");

                entity.Property(e => e.Gui).HasColumnName("GUI");

                entity.Property(e => e.InNotfallAnzeigenJn).HasColumnName("InNotfallAnzeigenJN");

                entity.Property(e => e.LstIdberufsgruppe)
                    .IsRequired()
                    .HasColumnName("lstIDBerufsgruppe")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PdfBlop).HasColumnName("PDF_BLOP");
            });

            modelBuilder.Entity<FormularDaten>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Datumerstellt)
                    .HasName("_dta_index_FormularDaten_c_5_2105058535__K5D")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Blop)
                    .IsRequired()
                    .HasColumnName("BLOP")
                    .HasColumnType("text");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.Datumerstellt).HasColumnType("datetime");

                entity.Property(e => e.FormularName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Idref).HasColumnName("IDREF");

                entity.Property(e => e.PdfBlop).HasColumnName("PDF_BLOP");
            });

            modelBuilder.Entity<FormularDatenFelder>(entity =>
            {
                entity.HasIndex(e => new { e.IdformularDaten, e.Feldname })
                    .HasName("IX_FormularDatenFelderByFormular");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Feldname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Feldtyp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Feldwert)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdformularDaten).HasColumnName("IDFormularDaten");

                entity.HasOne(d => d.IdformularDatenNavigation)
                    .WithMany(p => p.FormularDatenFelder)
                    .HasForeignKey(d => d.IdformularDaten)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormularDatenFelder_FormularDaten");
            });

            modelBuilder.Entity<Gegenstaende>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Beschreibung).IsUnicode(false);

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.Eigentuemer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EigentumKlientJn)
                    .HasColumnName("EigentumKlientJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EigentumKlinikJn)
                    .HasColumnName("EigentumKlinikJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HilfesmittelJn).HasColumnName("HilfesmittelJN");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idbenutzerausgegeben).HasColumnName("IDBenutzerausgegeben");

                entity.Property(e => e.Idbenutzerzurueck).HasColumnName("IDBenutzerzurueck");

                entity.Property(e => e.LetzteUeberpruefungAm).HasColumnType("datetime");

                entity.Property(e => e.MieteJn)
                    .HasColumnName("MieteJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NaechsteUeberpruefungAm).HasColumnType("datetime");

                entity.Property(e => e.Nr)
                    .HasMaxLength(155)
                    .IsUnicode(false);

                entity.Property(e => e.Von).HasColumnType("datetime");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.Gegenstaende)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_Gegenstaende_Aufenthalt");

                entity.HasOne(d => d.IdbenutzerausgegebenNavigation)
                    .WithMany(p => p.GegenstaendeIdbenutzerausgegebenNavigation)
                    .HasForeignKey(d => d.Idbenutzerausgegeben)
                    .HasConstraintName("FK_Gegenstaende_Benutzer");

                entity.HasOne(d => d.IdbenutzerzurueckNavigation)
                    .WithMany(p => p.GegenstaendeIdbenutzerzurueckNavigation)
                    .HasForeignKey(d => d.Idbenutzerzurueck)
                    .HasConstraintName("FK_Gegenstaende_Benutzer1");
            });

            modelBuilder.Entity<Gruppe>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piGruppe")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GruppenRecht>(entity =>
            {
                entity.HasIndex(e => new { e.Idgruppe, e.Idrecht })
                    .HasName("IDX_GruppenRecht")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idgruppe).HasColumnName("IDGruppe");

                entity.Property(e => e.Idrecht).HasColumnName("IDRecht");
            });

            modelBuilder.Entity<Info>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Kurz)
                    .IsRequired()
                    .HasColumnName("kurz")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasColumnName("lang")
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasColumnName("typ")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klinik>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piKlinik")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bereich)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Einrichtungsleiter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EinrichtungsleiterTitel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EinrichtungsleiterVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaAuthorSpeciality)
                    .IsRequired()
                    .HasColumnName("ELGA_AuthorSpeciality")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaOid)
                    .IsRequired()
                    .HasColumnName("ELGA_OID")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FormatRechNr)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FormatStornoNr)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FormatZahlungsbestätigung)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idbank).HasColumnName("IDBank");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.MitAerztlicheAufsichtJn).HasColumnName("MitAerztlicheAufsichtJN");

                entity.Property(e => e.MitAerztlicheLeitungJn).HasColumnName("MitAerztlicheLeitungJN");

                entity.Property(e => e.MitPaedagischeLeitungJn).HasColumnName("MitPaedagischeLeitungJN");

                entity.Property(e => e.MitPflegedienstleitungJn).HasColumnName("MitPflegedienstleitungJN");

                entity.Property(e => e.Rechnungsformular)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RechnungsformularDepot)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zvr)
                    .HasColumnName("ZVR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Klinik)
                    .HasForeignKey(d => d.Idadresse)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Klinik_Adresse");

                entity.HasOne(d => d.IdbankNavigation)
                    .WithMany(p => p.Klinik)
                    .HasForeignKey(d => d.Idbank)
                    .HasConstraintName("FK_Klnik_Bank");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Klinik)
                    .HasForeignKey(d => d.Idkontakt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Klinik_Kontakt");
            });

            modelBuilder.Entity<Kontakt>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piKontakt")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Andere)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Ansprechpartner)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Mobil)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz1)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz2)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz3)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kontaktperson>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExternerDienstleisterJn).HasColumnName("ExternerDienstleisterJN");

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.IdkontaktStammdaten).HasColumnName("IDKontaktStammdaten");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Kontaktart)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nachname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.VerstaendigenJn).HasColumnName("VerstaendigenJN");

                entity.Property(e => e.Verwandtschaft)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Kontaktperson)
                    .HasForeignKey(d => d.Idadresse)
                    .HasConstraintName("FK_Kontaktperson_Adresse");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Kontaktperson)
                    .HasForeignKey(d => d.Idkontakt)
                    .HasConstraintName("FK_Kontaktperson_Kontakt");

                entity.HasOne(d => d.IdkontaktStammdatenNavigation)
                    .WithMany(p => p.Kontaktperson)
                    .HasForeignKey(d => d.IdkontaktStammdaten)
                    .HasConstraintName("FK_Kontaktperson_KontaktpersonStammdaten");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Kontaktperson)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kontaktperson_Patient");
            });

            modelBuilder.Entity<KontaktpersonStammdaten>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Kostentraeger>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anrede)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bank)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Blz)
                    .IsRequired()
                    .HasColumnName("BLZ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErlagscheingebuehrJn).HasColumnName("ErlagscheingebuehrJN");

                entity.Property(e => e.Fibukonto)
                    .IsRequired()
                    .HasColumnName("FIBUKonto")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gsbg)
                    .HasColumnName("GSBG")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.IdkostentraegerSub).HasColumnName("IDKostentraegerSub");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.IdpatientIstZahler).HasColumnName("IDPatientIstZahler");

                entity.Property(e => e.Kontonr)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientbezogenJn).HasColumnName("PatientbezogenJN");

                entity.Property(e => e.Plz)
                    .IsRequired()
                    .HasColumnName("PLZ")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Rechnungsanschrift)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rechnungsempfaenger)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SammelabrechnungJn).HasColumnName("SammelabrechnungJN");

                entity.Property(e => e.Strasse)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaschengeldJn).HasColumnName("TaschengeldJN");

                entity.Property(e => e.TransferleistungJn).HasColumnName("TransferleistungJN");

                entity.Property(e => e.Uidnr)
                    .IsRequired()
                    .HasColumnName("UIDNr")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZahlartOld)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Layout>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("Layout", "qs2");

                entity.HasIndex(e => e.LayoutName)
                    .HasName("IX_Layout")
                    .IsUnique();

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutoFitStyleGrid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateFrom)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GridRowMaxHeigth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.GridRowMinHeigth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LayoutName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<LayoutGrids>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("LayoutGrids", "qs2");

                entity.HasIndex(e => new { e.ColMaxHeigth, e.ColumnCaption, e.Desc, e.GroupBy, e.GridAutoNewline, e.TypeCol, e.AutoSizeHeigthColumn, e.ColMinHeigth, e.Idguid, e.GridName, e.ColumnName, e.ColumnWith, e.Visible, e.OrderBy, e.Idlayout, e.Band, e.Sort })
                    .HasName("_dta_index_LayoutGrids_5_1806837699__K11_K3_K10_1_2_4_5_6_7_8_9_12_13_14_15_16_17");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColMaxHeigth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ColMinHeigth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ColumnCaption)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColumnWith).HasDefaultValueSql("((-1))");

                entity.Property(e => e.GridName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Idlayout).HasColumnName("IDLayout");

                entity.Property(e => e.Sort).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TypeCol)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeUi).HasColumnName("TypeUI");

                entity.HasOne(d => d.IdlayoutNavigation)
                    .WithMany(p => p.LayoutGrids)
                    .HasForeignKey(d => d.Idlayout)
                    .HasConstraintName("FK_LayoutGrids_Layout");
            });

            modelBuilder.Entity<Leistungskatalog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnumLeistungsgruppe).HasColumnName("enumLeistungsgruppe");

                entity.Property(e => e.Fibukonto)
                    .HasColumnName("FIBUKonto")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.MonatsleistungJn).HasColumnName("MonatsleistungJN");

                entity.Property(e => e.TaeglichJn).HasColumnName("TaeglichJN");

                entity.Property(e => e.VerrechnungImVorrausJn).HasColumnName("VerrechnungImVorrausJN");
            });

            modelBuilder.Entity<LeistungskatalogGueltig>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Betrag).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.GutschriftProTagAbwesend).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.Idleistungskatalog).HasColumnName("IDLeistungskatalog");

                entity.Property(e => e.Mwst)
                    .HasColumnName("MWST")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TagsatzberechnungJn).HasColumnName("TagsatzberechnungJN");

                entity.HasOne(d => d.IdleistungskatalogNavigation)
                    .WithMany(p => p.LeistungskatalogGueltig)
                    .HasForeignKey(d => d.Idleistungskatalog)
                    .HasConstraintName("FK_LeistungskatalogGueltig_Leistungskatalog");
            });

            modelBuilder.Entity<LinkDokumente>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aenderungsdatum).HasColumnType("datetime");

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dokument).HasColumnType("image");

                entity.Property(e => e.Erstellungsdatum).HasColumnType("datetime");

                entity.Property(e => e.Gruppe)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManBuch>(entity =>
            {
                entity.ToTable("manBuch");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechAm)
                    .HasColumnName("abgerechAm")
                    .HasColumnType("datetime");

                entity.Property(e => e.AbgerechJn).HasColumnName("abgerechJN");

                entity.Property(e => e.AbrechGruppe)
                    .HasColumnName("abrechGruppe")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Am)
                    .HasColumnName("am")
                    .HasColumnType("datetime");

                entity.Property(e => e.Betrag)
                    .HasColumnName("betrag")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Brutto)
                    .HasColumnName("brutto")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BuchText)
                    .IsRequired()
                    .HasColumnName("buchText")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Erfasst)
                    .IsRequired()
                    .HasColumnName("erfasst")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Fibukonto)
                    .IsRequired()
                    .HasColumnName("FIBUKonto")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GruppeTxt)
                    .IsRequired()
                    .HasColumnName("gruppeTxt")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklient).HasColumnName("IDKlient");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idref).HasColumnName("IDRef");

                entity.Property(e => e.MwSt).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ReNr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RechnungTyp).HasDefaultValueSql("((1))");

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Zeitraumdetail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Massnahmenserien>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Z0).HasColumnType("datetime");

                entity.Property(e => e.Z1).HasColumnType("datetime");

                entity.Property(e => e.Z2).HasColumnType("datetime");

                entity.Property(e => e.Z3).HasColumnType("datetime");

                entity.Property(e => e.Z4).HasColumnType("datetime");

                entity.Property(e => e.Z5).HasColumnType("datetime");

                entity.Property(e => e.Z6).HasColumnType("datetime");

                entity.Property(e => e.Z7).HasColumnType("datetime");
            });

            modelBuilder.Entity<Medikament>(entity =>
            {
                entity.HasIndex(e => e.Aktuell)
                    .HasName("Aktuell");

                entity.HasIndex(e => e.Bezeichnung)
                    .HasName("Bezeichnung");

                entity.HasIndex(e => e.Id)
                    .HasName("_dta_index_Medikament_5_21575115__K1");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AerztlichevorbereitungJn).HasColumnName("AerztlichevorbereitungJN");

                entity.Property(e => e.Applikationsform)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Barcode)
                    .HasColumnName("BARCODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Einheit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Erstattungscode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('n')");

                entity.Property(e => e.ExtId)
                    .HasColumnName("EXT_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gruppe)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gültigkeitsdatum).HasColumnType("datetime");

                entity.Property(e => e.HerrichtenTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImportiertAm).HasColumnType("datetime");

                entity.Property(e => e.Kassenzeichen)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lagervorschrift)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LangText).HasColumnType("text");

                entity.Property(e => e.Lieferant)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packungsanzahl).HasDefaultValueSql("((1))");

                entity.Property(e => e.Packungseinheit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zulassungsnummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedikationAbgabe>(entity =>
            {
                entity.HasKey(e => new { e.IdrezeptEintrag, e.Zeitpunkt });

                entity.Property(e => e.IdrezeptEintrag).HasColumnName("IDRezeptEintrag");

                entity.Property(e => e.Zeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.MedikamentText)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.TagesspenderJn).HasColumnName("TagesspenderJN");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.MedikationAbgabe)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_MedikationAbgabe_Aufenthalt");
            });

            modelBuilder.Entity<MedizinischeDaten>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.Idbenutzergeaendert, e.Beschreibung, e.Icdcode, e.Beendigungsgrund, e.AufnahmediagnoseJn, e.Bemerkung, e.Therapie, e.Anzahl, e.NuechternJn, e.AntikoaguliertJn, e.Handling, e.LetzteVersorgung, e.NaechsteVersorgung, e.Modell, e.Groesse, e.Typ, e.Idbefund, e.Verordnungen, e.LstRezepteinträge, e.Idpatient, e.MedizinischerTyp, e.Von, e.Bis })
                    .HasName("_dta_index_MedizinischeDaten_6_998294616__K2_K4_K7_K8_1_3_5_6_9_10_11_12_13_14_15_17_18_19_20_21_22_23_24_25");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AntikoaguliertJn).HasColumnName("AntikoaguliertJN");

                entity.Property(e => e.AufnahmediagnoseJn).HasColumnName("AufnahmediagnoseJN");

                entity.Property(e => e.Beendigungsgrund)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.Groesse)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Handling)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Icdcode)
                    .HasColumnName("ICDCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idbefund).HasColumnName("IDBefund");

                entity.Property(e => e.Idbenutzergeaendert).HasColumnName("IDBenutzergeaendert");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.LetzteVersorgung).HasColumnType("datetime");

                entity.Property(e => e.LstRezepteinträge)
                    .IsRequired()
                    .HasColumnName("lstRezepteinträge")
                    .HasColumnType("varchar(max)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Modell)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NaechsteVersorgung).HasColumnType("datetime");

                entity.Property(e => e.NuechternJn).HasColumnName("NuechternJN");

                entity.Property(e => e.Therapie)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Verordnungen).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Von).HasColumnType("datetime");

                entity.HasOne(d => d.IdbenutzergeaendertNavigation)
                    .WithMany(p => p.MedizinischeDaten)
                    .HasForeignKey(d => d.Idbenutzergeaendert)
                    .HasConstraintName("FK_MedizinischeDaten_Benutzer");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.MedizinischeDaten)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_MedizinischeDaten_Patient");
            });

            modelBuilder.Entity<MedizinischeDatenLayout>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BVisible)
                    .IsRequired()
                    .HasColumnName("bVisible")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedizinischeTypen>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BVisible)
                    .IsRequired()
                    .HasColumnName("bVisible")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Icon).HasColumnType("image");

                entity.Property(e => e.IconOff)
                    .HasColumnName("IconOFF")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piPatient")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vorname, e.Nachname, e.Id })
                    .HasName("_dta_index_Patient_6_1511116574__K1_4_5");

                entity.HasIndex(e => new { e.Vorname, e.Nachname, e.Geburtsdatum, e.Id })
                    .HasName("_dta_index_Patient_6_86291367__K1_4_5_6");

                entity.HasIndex(e => new { e.Vorname, e.Nachname, e.Geburtsdatum, e.Titel, e.Id })
                    .HasName("_dta_index_Patient_6_86291367__K1_4_5_6_7");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbwesenheitenHändBerech).HasColumnName("abwesenheitenHändBerech");

                entity.Property(e => e.Adelstitel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AktuellerDienstgeber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AmputationProzent).HasColumnName("Amputation_Prozent");

                entity.Property(e => e.Angehörige).HasColumnType("text");

                entity.Property(e => e.Anrede)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ArbeitslosBezSeit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Augenfarbe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AuszugswunschDatum).HasColumnType("datetime");

                entity.Property(e => e.BesondereAeusserlicheKennzeichen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Besonderheit).HasColumnType("text");

                entity.Property(e => e.Betreuer).HasColumnType("text");

                entity.Property(e => e.Betreuungsstufe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BetreuungsstufeAb).HasColumnType("datetime");

                entity.Property(e => e.BetreuungsstufeBis).HasColumnType("datetime");

                entity.Property(e => e.BewerberBemerkung)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.BewerberJn).HasColumnName("BewerberJN");

                entity.Property(e => e.BewerbungDatum).HasColumnType("datetime");

                entity.Property(e => e.BewerbungaktivJn).HasColumnName("BewerbungaktivJN");

                entity.Property(e => e.BewerbungsGrund)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.BlobEinverständniserklärung).HasColumnName("blob_Einverständniserklärung");

                entity.Property(e => e.BlutGruppe)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DatumPensionsteilungsantrag).HasColumnType("datetime");

                entity.Property(e => e.DatumPflegegeldantrag).HasColumnType("datetime");

                entity.Property(e => e.Depotinjektion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DerzeitigerBeruf)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dnr).HasColumnName("DNR");

                entity.Property(e => e.EinverständniserklärungFileType)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EinzugswunschDatum).HasColumnType("datetime");

                entity.Property(e => e.ErlernterBeruf)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Familienstand)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FernsehgebuehrbefreiungJn).HasColumnName("FernsehgebuehrbefreiungJN");

                entity.Property(e => e.Fibukonto)
                    .HasColumnName("FIBUKonto")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.Geburtsort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Haarfarbe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hauptversicherung).HasColumnType("text");

                entity.Property(e => e.Hausarzt).HasColumnType("text");

                entity.Property(e => e.Haustier)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.IdadresseSub).HasColumnName("IDAdresseSub");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.IdkontaktSub).HasColumnName("IDKontaktSub");

                entity.Property(e => e.Initialberuehrung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JpgEinverständniserklärung).HasColumnName("jpg_Einverständniserklärung");

                entity.Property(e => e.Kennwort)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Klasse)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Klientennummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Klingeln)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KommunionJn).HasColumnName("KommunionJN");

                entity.Property(e => e.Konfision)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kosename)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KrankenKasse)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.KrankengeldSeit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KrankensalbungJn).HasColumnName("KrankensalbungJN");

                entity.Property(e => e.Kzueberlebender).HasColumnName("KZUeberlebender");

                entity.Property(e => e.LedigerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LiftJn).HasColumnName("LiftJN");

                entity.Property(e => e.LstSprachen)
                    .IsRequired()
                    .HasColumnName("lstSprachen")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinSaldo)
                    .HasColumnName("minSaldo")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Namenstag).HasColumnType("datetime");

                entity.Property(e => e.PatientenverfuegungBeachtlichJn).HasColumnName("PatientenverfuegungBeachtlichJN");

                entity.Property(e => e.PatientenverfuegungJn).HasColumnName("PatientenverfuegungJN");

                entity.Property(e => e.PatientverfuegungAnmerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PatientverfuegungDatum).HasColumnType("datetime");

                entity.Property(e => e.PensionsteilungsantragJn).HasColumnName("PensionsteilungsantragJN");

                entity.Property(e => e.PflegeArt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PflegegeldantragJn).HasColumnName("PflegegeldantragJN");

                entity.Property(e => e.Prioritaet)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrivPolNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Privatversicherung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReligionWunsch)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Resusfaktor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RezGebBefAnmerkung)
                    .IsRequired()
                    .HasColumnName("RezGebBef_Anmerkung")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RezGebBefBefristetAb)
                    .HasColumnName("RezGebBef_BefristetAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.RezGebBefBefristetBis)
                    .HasColumnName("RezGebBef_BefristetBis")
                    .HasColumnType("datetime");

                entity.Property(e => e.RezGebBefBefristetJn).HasColumnName("RezGebBef_BefristetJN");

                entity.Property(e => e.RezGebBefRegoAb)
                    .HasColumnName("RezGebBef_RegoAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.RezGebBefRegoBis)
                    .HasColumnName("RezGebBef_RegoBis")
                    .HasColumnType("datetime");

                entity.Property(e => e.RezGebBefRegoJn).HasColumnName("RezGebBef_RegoJN");

                entity.Property(e => e.RezGebBefSachwalterJn).HasColumnName("RezGebBef_SachwalterJN");

                entity.Property(e => e.RezGebBefUnbefristetJn).HasColumnName("RezGebBef_UnbefristetJN");

                entity.Property(e => e.RezGebBefWiderrufGrund)
                    .IsRequired()
                    .HasColumnName("RezGebBef_WiderrufGrund")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RezGebBefWiderrufJn).HasColumnName("RezGebBef_WiderrufJN");

                entity.Property(e => e.RezeptgebuehrbefreiungJn).HasColumnName("RezeptgebuehrbefreiungJN");

                entity.Property(e => e.RollungBis).HasColumnType("datetime");

                entity.Property(e => e.RollungVon).HasColumnType("datetime");

                entity.Property(e => e.SachWalterBelange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SachWalterBis).HasColumnType("datetime");

                entity.Property(e => e.SachWalterVon).HasColumnType("datetime");

                entity.Property(e => e.Sachwalter).HasColumnType("text");

                entity.Property(e => e.Sexus)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sollstand).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SonstigeWuensche)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SozVersLeerGrund)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SozVersMitversichertBei)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SozVersStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Staatsb)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Stationswunsch)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Statur)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SterbeDatum).HasColumnType("datetime");

                entity.Property(e => e.SterbeRegel).HasColumnType("text");

                entity.Property(e => e.TageAbweseneheitOhneKuerzung).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TelefongebuehrbefreiungJn).HasColumnName("TelefongebuehrbefreiungJN");

                entity.Property(e => e.Titel)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Todeszeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.Vermerk).HasColumnType("text");

                entity.Property(e => e.VersicherungsNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Voraufenthalt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WaescheMarkiert)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WaescheWaschen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wohnsituation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WohnungAbgemeldetJn).HasColumnName("WohnungAbgemeldetJN");

                entity.Property(e => e.Zimmerwunsch)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZustaendigeStelle)
                    .HasColumnName("Zustaendige_Stelle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Idadresse)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Patient_Adresse");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_Patien_Benutzer");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Idkontakt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Patient_Kontakt");
            });

            modelBuilder.Entity<PatientAbwesenheit>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbTagN).HasColumnName("abTagN");

                entity.Property(e => e.AbgerechnetBis).HasColumnType("datetime");

                entity.Property(e => e.BetrifftPflegegeldJn).HasColumnName("BetrifftPflegegeldJN");

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.ErfasstAm).HasColumnType("datetime");

                entity.Property(e => e.Grund)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idüber)
                    .IsRequired()
                    .HasColumnName("IDÜber")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Von).HasColumnType("datetime");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientAbwesenheit)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientAbwesenheit_Patient");
            });

            modelBuilder.Entity<PatientAerzte>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AufnahmearztJn).HasColumnName("AufnahmearztJN");

                entity.Property(e => e.BehandelnderFajn).HasColumnName("BehandelnderFAJN");

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.HausarztJn).HasColumnName("HausarztJN");

                entity.Property(e => e.Idaerzte).HasColumnName("IDAerzte");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Von).HasColumnType("datetime");

                entity.Property(e => e.ZuweiserJn).HasColumnName("ZuweiserJN");

                entity.HasOne(d => d.IdaerzteNavigation)
                    .WithMany(p => p.PatientAerzte)
                    .HasForeignKey(d => d.Idaerzte)
                    .HasConstraintName("FK_PatientAerzte_Aerzte");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientAerzte)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_PatientAerzte_Patient");
            });

            modelBuilder.Entity<PatientEinkommen>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetBis).HasColumnType("datetime");

                entity.Property(e => e.BetragVerwendbar).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErfasstAm).HasColumnType("datetime");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.Idbankliste).HasColumnName("IDBankliste");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idkostentraeger).HasColumnName("IDKostentraeger");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.RechnungJn).HasColumnName("RechnungJN");

                entity.Property(e => e.SelbstzahlerJn).HasColumnName("SelbstzahlerJN");

                entity.Property(e => e.TransferleistungJn).HasColumnName("TransferleistungJN");

                entity.HasOne(d => d.IdkostentraegerNavigation)
                    .WithMany(p => p.PatientEinkommen)
                    .HasForeignKey(d => d.Idkostentraeger)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Kostentraeger_PatientEinkommen");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientEinkommen)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientEinkommen_Patient");
            });

            modelBuilder.Entity<PatientKostentraeger>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetBis).HasColumnType("datetime");

                entity.Property(e => e.Betrag).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BetragErrechnetJn).HasColumnName("BetragErrechnetJN");

                entity.Property(e => e.EnumKostentraegerart).HasColumnName("enumKostentraegerart");

                entity.Property(e => e.ErfasstAm).HasColumnType("datetime");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idkostentraeger).HasColumnName("IDKostentraeger");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.IdpatientIstZahler).HasColumnName("IDPatientIstZahler");

                entity.Property(e => e.RechnungJn)
                    .IsRequired()
                    .HasColumnName("RechnungJN")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RechnungTyp).HasDefaultValueSql("((1))");

                entity.Property(e => e.VorauszahlungJn).HasColumnName("VorauszahlungJN");

                entity.HasOne(d => d.IdkostentraegerNavigation)
                    .WithMany(p => p.PatientKostentraeger)
                    .HasForeignKey(d => d.Idkostentraeger)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientKostentraeger_Kostentraeger");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientKostentraeger)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientKostentraeger_Patient");
            });

            modelBuilder.Entity<PatientLeistungsplan>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetBis).HasColumnType("datetime");

                entity.Property(e => e.ErfasstAm).HasColumnType("datetime");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idleistungskatalog).HasColumnName("IDLeistungskatalog");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.ImVorausJn).HasColumnName("ImVorausJN");

                entity.Property(e => e.StornoJn).HasColumnName("StornoJN");

                entity.HasOne(d => d.IdleistungskatalogNavigation)
                    .WithMany(p => p.PatientLeistungsplan)
                    .HasForeignKey(d => d.Idleistungskatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientLeistungsplan_Leistungskatalog");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientLeistungsplan)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientLeistungsplan_Patient");
            });

            modelBuilder.Entity<PatientPflegestufe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetBis).HasColumnType("datetime");

                entity.Property(e => e.AenderungsantragDatum).HasColumnType("datetime");

                entity.Property(e => e.BetragVerwendbar).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ErfasstAm).HasColumnType("datetime");

                entity.Property(e => e.GenehmigungDatum).HasColumnType("datetime");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.GutschriftProTagAbwesend).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idkostentraeger).HasColumnName("IDKostentraeger");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idpflegegeldstufe).HasColumnName("IDPflegegeldstufe");

                entity.Property(e => e.IdpflegegeldstufeAntrag).HasColumnName("IDPflegegeldstufeAntrag");

                entity.Property(e => e.IdpflegegeldstufeGenehmigt).HasColumnName("IDPflegegeldstufeGenehmigt");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientPflegestufe)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientPflegestufe_Patient");

                entity.HasOne(d => d.IdpflegegeldstufeNavigation)
                    .WithMany(p => p.PatientPflegestufe)
                    .HasForeignKey(d => d.Idpflegegeldstufe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientPflegestufe_Pflegegeldstufe");
            });

            modelBuilder.Entity<PatientSonderleistung>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetJn).HasColumnName("AbgerechnetJN");

                entity.Property(e => e.Belegnummer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Betrag).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DatumVerrech)
                    .HasColumnName("datumVerrech")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idsonderleistungskatalog).HasColumnName("IDSonderleistungskatalog");

                entity.Property(e => e.Mwst)
                    .HasColumnName("MWST")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientSonderleistung)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientSonderleistung_Patient");

                entity.HasOne(d => d.IdsonderleistungskatalogNavigation)
                    .WithMany(p => p.PatientSonderleistung)
                    .HasForeignKey(d => d.Idsonderleistungskatalog)
                    .HasConstraintName("FK_PatientSonderleistung_SonderleistungsKatalog");
            });

            modelBuilder.Entity<PatientTaschengeldKostentraeger>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetBis).HasColumnType("datetime");

                entity.Property(e => e.Betrag).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ErfasstAm).HasColumnType("datetime");

                entity.Property(e => e.GueltigAb)
                    .HasColumnName("GueltigAB")
                    .HasColumnType("datetime");

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idkostentraeger).HasColumnName("IDKostentraeger");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.HasOne(d => d.IdkostentraegerNavigation)
                    .WithMany(p => p.PatientTaschengeldKostentraeger)
                    .HasForeignKey(d => d.Idkostentraeger)
                    .HasConstraintName("FK_PatientTaschengeldKostentraeger_Kostentraeger");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientTaschengeldKostentraeger)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_PatientTaschengeldKostentraeger_Patient");
            });

            modelBuilder.Entity<PatientenBemerkung>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piPatientenBemerkung")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bemerkung)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.PatientenBemerkung)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_PatientenBemerkung_Benutzer");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientenBemerkung)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientenBemerkung_Patient");
            });

            modelBuilder.Entity<Pdx>(entity =>
            {
                entity.ToTable("PDX");

                entity.HasIndex(e => e.Id)
                    .HasName("piPDX")
                    .IsUnique();

                entity.HasIndex(e => new { e.Klartext, e.Code, e.LokalisierungsTyp, e.Id })
                    .HasName("_dta_index_PDX_5_69575286__K1_2_3_8");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Definition)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.EntferntJn).HasColumnName("EntferntJN");

                entity.Property(e => e.Gruppe).HasDefaultValueSql("((0))");

                entity.Property(e => e.Klartext)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pdxkuerzel)
                    .IsRequired()
                    .HasColumnName("PDXKuerzel")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ThematischeId).HasColumnName("ThematischeID");

                entity.Property(e => e.Wundejn).HasColumnName("wundejn");
            });

            modelBuilder.Entity<Pdxanamnese>(entity =>
            {
                entity.ToTable("PDXAnamnese");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdanamneseJuchli).HasColumnName("IDAnamneseJuchli");

                entity.Property(e => e.IdanamneseKrohwinkel).HasColumnName("IDAnamneseKrohwinkel");

                entity.Property(e => e.IdanamneseNanda).HasColumnName("IDAnamneseNanda");

                entity.Property(e => e.IdanamneseOrem).HasColumnName("IDAnamneseOrem");

                entity.Property(e => e.IdanamnesePop).HasColumnName("IDAnamnesePOP");

                entity.Property(e => e.IdanamneseRai).HasColumnName("IDAnamneseRAI");

                entity.Property(e => e.IdanamneseRt).HasColumnName("IDAnamneseRT");

                entity.Property(e => e.Idpdx).HasColumnName("IDPDX");

                entity.Property(e => e.Modell)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resourceklient)
                    .HasMaxLength(2028)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdanamneseKrohwinkelNavigation)
                    .WithMany(p => p.Pdxanamnese)
                    .HasForeignKey(d => d.IdanamneseKrohwinkel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PDXAnamnese_Anamnese_Krohwinkel");

                entity.HasOne(d => d.IdanamneseOremNavigation)
                    .WithMany(p => p.Pdxanamnese)
                    .HasForeignKey(d => d.IdanamneseOrem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PDXAnamnese_Anamnese_Orem");

                entity.HasOne(d => d.IdpdxNavigation)
                    .WithMany(p => p.Pdxanamnese)
                    .HasForeignKey(d => d.Idpdx)
                    .HasConstraintName("FK_PDXAnamnese_PDX");
            });

            modelBuilder.Entity<Pdxeintrag>(entity =>
            {
                entity.ToTable("PDXEintrag");

                entity.HasIndex(e => e.Id)
                    .HasName("piPDXEintrag")
                    .IsUnique();

                entity.HasIndex(e => new { e.Idpdx, e.Ideintrag, e.Idabteilung })
                    .HasName("uiPDXEintrag")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idpdx).HasColumnName("IDPDX");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.Pdxeintrag)
                    .HasForeignKey(d => d.Idabteilung)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PDXEintrag_Abteilung");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.Pdxeintrag)
                    .HasForeignKey(d => d.Ideintrag)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PDXEintrag_Eintrag");

                entity.HasOne(d => d.IdpdxNavigation)
                    .WithMany(p => p.Pdxeintrag)
                    .HasForeignKey(d => d.Idpdx)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PDXEintrag_PDX");
            });

            modelBuilder.Entity<Pdxgruppe>(entity =>
            {
                entity.ToTable("PDXGruppe");

                entity.HasIndex(e => e.Id)
                    .HasName("piPDXGruppe")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.Pdxgruppe)
                    .HasForeignKey(d => d.Idabteilung)
                    .HasConstraintName("FK_PDXGruppe_Abteilung");
            });

            modelBuilder.Entity<PdxgruppeEintrag>(entity =>
            {
                entity.ToTable("PDXGruppeEintrag");

                entity.HasIndex(e => new { e.Idpdxgruppe, e.Idpdx })
                    .HasName("IDX_PDXGruppeEintrag")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idpdx).HasColumnName("IDPDX");

                entity.Property(e => e.Idpdxgruppe).HasColumnName("IDPDXGruppe");

                entity.HasOne(d => d.IdpdxgruppeNavigation)
                    .WithMany(p => p.PdxgruppeEintrag)
                    .HasForeignKey(d => d.Idpdxgruppe)
                    .HasConstraintName("FK_PDXGruppeEintrag_PDXGruppe");
            });

            modelBuilder.Entity<Pdxpflegemodelle>(entity =>
            {
                entity.ToTable("PDXPflegemodelle");

                entity.HasIndex(e => new { e.Idpdx, e.Idpflegemodelle })
                    .HasName("IX_PDXPflegemodelle")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idpdx).HasColumnName("IDPDX");

                entity.Property(e => e.Idpflegemodelle).HasColumnName("IDPflegemodelle");

                entity.HasOne(d => d.IdpdxNavigation)
                    .WithMany(p => p.Pdxpflegemodelle)
                    .HasForeignKey(d => d.Idpdx)
                    .HasConstraintName("FK_PDXPflegemodelle_PDX");

                entity.HasOne(d => d.IdpflegemodelleNavigation)
                    .WithMany(p => p.Pdxpflegemodelle)
                    .HasForeignKey(d => d.Idpflegemodelle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PDXPflegemodelle_Pflegemodelle");
            });

            modelBuilder.Entity<PflegeEintrag>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Idaufenthalt })
                    .HasName("pkPflegeEintrag")
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdpflegePlan)
                    .HasName("IDX_IDPflegeplan33");

                entity.HasIndex(e => e.Zeitpunkt)
                    .HasName("Zeitpunkt")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.Idgruppe, e.Idaufenthalt })
                    .HasName("IX_IDGruppe");

                entity.HasIndex(e => new { e.Idaufenthalt, e.Zeitpunkt, e.Id, e.Idabteilung })
                    .HasName("_dta_index_PflegeEintrag_6_693577509__K2_K8D_K1_K23");

                entity.HasIndex(e => new { e.Idaufenthalt, e.Zeitpunkt, e.IdpflegePlan, e.Id })
                    .HasName("idx_Zeitpunkt");

                entity.HasIndex(e => new { e.EintragsTyp, e.PflegeplanText, e.DatumErstellt, e.Zeitpunkt, e.Text, e.DurchgefuehrtJn, e.Cc, e.Idaufenthalt, e.Ideintrag, e.Idabteilung, e.Idbereich, e.Idwichtig, e.Id, e.Idbenutzer })
                    .HasName("_dta_index_PflegeEintrag_6_693577509__K26_K2_K5_K23_K22_K14_K1_K4_7_8_9_11_12_17");

                entity.HasIndex(e => new { e.Text, e.DurchgefuehrtJn, e.EintragsTyp, e.PflegeplanText, e.Idbereich, e.Idabteilung, e.Id, e.Zeitpunkt, e.Idaufenthalt, e.Idwichtig, e.Idsollberufsstand, e.Idberufsstand, e.Idbenutzer, e.IdpflegePlan, e.Ideintrag })
                    .HasName("_dta_index_PflegeEintrag_6_693577509__K2_K14_K18_K6_K4_K3_K5_1_8_9_11_12_17_22_23");

                entity.HasIndex(e => new { e.Id, e.Ideintrag, e.DatumErstellt, e.Text, e.DurchgefuehrtJn, e.PflegeplanText, e.Idbereich, e.Idabteilung, e.Cc, e.TextRtf, e.AbgezeichnetJn, e.AbgezeichnetAm, e.Dekursherkunft, e.AbzeichnenJn, e.HagpflichtigJn, e.LogInNameFrei, e.EintragsTyp, e.Idaufenthalt, e.Zeitpunkt, e.IdpflegePlan, e.Idbenutzer, e.AbgezeichnetIdbenutzer, e.Idberufsstand, e.Idsollberufsstand, e.Idwichtig })
                    .HasName("_dta_index_PflegeEintrag_6_693577509__K12_K2_K8_K3_K4_K31_K6_K18_K14_1_5_7_9_11_17_22_23_26_29_30_32_33_34_35_37");

                entity.HasIndex(e => new { e.Id, e.Idaufenthalt, e.Idbenutzer, e.Ideintrag, e.IstDauer, e.DurchgefuehrtJn, e.EintragsTyp, e.EvalStatus, e.PflegeplanText, e.Idsollberufsstand, e.Idberufsstand, e.DatumErstellt, e.Text, e.Idbereich, e.Idabteilung, e.PflegePlanDauer, e.Wichtig, e.Idwichtig, e.Idevaluierung, e.Iddekurs, e.Cc, e.Idextern, e.IdpflegePlanBerufsstand, e.IdpflegeplanH, e.Solldauer, e.IdpflegePlan, e.Zeitpunkt })
                    .HasName("_dta_index_PflegeEintrag_5_693577509__K3_K8_1_2_4_5_6_7_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.AbgezeichnetAm).HasColumnType("datetime");

                entity.Property(e => e.AbgezeichnetIdbenutzer).HasColumnName("AbgezeichnetIDBenutzer");

                entity.Property(e => e.AbgezeichnetJn).HasColumnName("AbgezeichnetJN");

                entity.Property(e => e.AbzeichnenJn).HasColumnName("AbzeichnenJN");

                entity.Property(e => e.Cc).HasColumnName("CC");

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DurchgefuehrtJn).HasColumnName("DurchgefuehrtJN");

                entity.Property(e => e.HagpflichtigJn).HasColumnName("HAGPflichtigJN");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Idbefund).HasColumnName("IDBefund");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.Idberufsstand).HasColumnName("IDBerufsstand");

                entity.Property(e => e.Iddekurs).HasColumnName("IDDekurs");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idevaluierung).HasColumnName("IDEvaluierung");

                entity.Property(e => e.Idextern).HasColumnName("IDExtern");

                entity.Property(e => e.Idgruppe).HasColumnName("IDGruppe");

                entity.Property(e => e.IdpflegePlan).HasColumnName("IDPflegePlan");

                entity.Property(e => e.IdpflegePlanBerufsstand).HasColumnName("IDPflegePlanBerufsstand");

                entity.Property(e => e.IdpflegeplanH).HasColumnName("IDPflegeplanH");

                entity.Property(e => e.Idsollberufsstand).HasColumnName("IDSollberufsstand");

                entity.Property(e => e.Idwichtig).HasColumnName("IDWichtig");

                entity.Property(e => e.LogInNameFrei)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PflegeplanText)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartdatumNeu)
                    .HasColumnName("Startdatum_Neu")
                    .HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.TextHistorie)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TextHistorieRtf)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TextRtf)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Zeitpunkt).HasColumnType("datetime");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.PflegeEintrag)
                    .HasForeignKey(d => d.Idabteilung)
                    .HasConstraintName("FK_PflegeEintrag_AbteilungEntwurf");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.PflegeEintrag)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_PflegeEintrag_Aufenthalt");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.PflegeEintrag)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_PflegeEintrag_BenutzerEntwurf");

                entity.HasOne(d => d.IdbereichNavigation)
                    .WithMany(p => p.PflegeEintrag)
                    .HasForeignKey(d => d.Idbereich)
                    .HasConstraintName("FK_PflegeEintrag_BereichEntwurf");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.PflegeEintrag)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_PflegeEintrag_EintragEntwurf");

                entity.HasOne(d => d.IdpflegePlanNavigation)
                    .WithMany(p => p.PflegeEintrag)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.IdpflegePlan)
                    .HasConstraintName("FK_PflegeEintrag_PflegePlanEntwurf");
            });

            modelBuilder.Entity<PflegeEintragEntwurf>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Idaufenthalt })
                    .HasName("pkPflegeEintragEntwurf")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.AbgezeichnetAm).HasColumnType("datetime");

                entity.Property(e => e.AbgezeichnetIdbenutzer).HasColumnName("AbgezeichnetIDBenutzer");

                entity.Property(e => e.AbgezeichnetJn).HasColumnName("AbgezeichnetJN");

                entity.Property(e => e.AbzeichnenJn).HasColumnName("AbzeichnenJN");

                entity.Property(e => e.Cc).HasColumnName("CC");

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DurchgefuehrtJn).HasColumnName("DurchgefuehrtJN");

                entity.Property(e => e.HagpflichtigJn).HasColumnName("HAGPflichtigJN");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.Idbefund).HasColumnName("IDBefund");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idbereich).HasColumnName("IDBereich");

                entity.Property(e => e.Idberufsstand).HasColumnName("IDBerufsstand");

                entity.Property(e => e.Iddekurs).HasColumnName("IDDekurs");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idevaluierung).HasColumnName("IDEvaluierung");

                entity.Property(e => e.Idextern).HasColumnName("IDExtern");

                entity.Property(e => e.IdpflegePlan).HasColumnName("IDPflegePlan");

                entity.Property(e => e.IdpflegePlanBerufsstand).HasColumnName("IDPflegePlanBerufsstand");

                entity.Property(e => e.IdpflegeplanH).HasColumnName("IDPflegeplanH");

                entity.Property(e => e.Idsollberufsstand).HasColumnName("IDSollberufsstand");

                entity.Property(e => e.Idwichtig).HasColumnName("IDWichtig");

                entity.Property(e => e.LogInNameFrei)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LstSelectedCc)
                    .IsRequired()
                    .HasColumnName("lstSelectedCC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstSelectedPatient)
                    .IsRequired()
                    .HasColumnName("lstSelectedPatient")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PflegeplanText)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartdatumNeu)
                    .HasColumnName("Startdatum_Neu")
                    .HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.TextRtf)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Zeitpunkt).HasColumnType("datetime");

                entity.HasOne(d => d.IdabteilungNavigation)
                    .WithMany(p => p.PflegeEintragEntwurf)
                    .HasForeignKey(d => d.Idabteilung)
                    .HasConstraintName("FK_PflegeEintragEntwurf_Abteilung");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.PflegeEintragEntwurf)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PflegeEintragEntwurf_Aufenthalt");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.PflegeEintragEntwurf)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_PflegeEintragEntwurf_Benutzer");

                entity.HasOne(d => d.IdbereichNavigation)
                    .WithMany(p => p.PflegeEintragEntwurf)
                    .HasForeignKey(d => d.Idbereich)
                    .HasConstraintName("FK_PflegeEintragEntwurf_Bereich");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.PflegeEintragEntwurf)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_PflegeEintragEntwurf_Eintrag");

                entity.HasOne(d => d.IdpflegePlanNavigation)
                    .WithMany(p => p.PflegeEintragEntwurf)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.IdpflegePlan)
                    .HasConstraintName("FK_PflegeEintragEntwurf_PflegePlan");
            });

            modelBuilder.Entity<PflegePlan>(entity =>
            {
                entity.HasKey(e => new { e.Idaufenthalt, e.Id })
                    .HasName("pkPflegePlan");

                entity.HasIndex(e => e.Id)
                    .HasName("piPflegePlan")
                    .IsUnique();

                entity.HasIndex(e => new { e.Idaufenthalt, e.Ideintrag, e.ErledigtJn })
                    .HasName("IDAufenthalt");

                entity.HasIndex(e => new { e.Ideintrag, e.EndeDatum, e.ErledigtJn, e.Idaufenthalt, e.NaechsteEvaluierung, e.EintragGruppe })
                    .HasName("_dta_index_PflegePlan_5_597577167__K26_K2_K38_K30_3_10");

                entity.HasIndex(e => new { e.Warnhinweis, e.Anmerkung, e.Idberufsstand, e.Lokalisierung, e.LokalisierungSeite, e.RmoptionalJn, e.Idbefund, e.Id, e.Idaufenthalt })
                    .HasName("_dta_index_PflegePlan_6_1248827611__K1_K2_13_14_21_28_29_32_53");

                entity.HasIndex(e => new { e.Id, e.Ideintrag, e.IdbenutzerErstellt, e.IdbenutzerGeaendert, e.StartDatum, e.EndeDatum, e.Warnhinweis, e.Anmerkung, e.Text, e.Idberufsstand, e.EinmaligJn, e.ErledigtJn, e.GeloeschtJn, e.Lokalisierung, e.LokalisierungSeite, e.Pdxjn, e.IdlinkDokument, e.OhneZeitBezug, e.ZuErledigenBis, e.EintragFlag, e.NächstesDatum, e.PrivatJn, e.Idaufenthalt, e.EintragGruppe })
                    .HasName("IDAufenthalt_Eintraggruppe");

                entity.HasIndex(e => new { e.Id, e.Idaufenthalt, e.Ideintrag, e.IdbenutzerErstellt, e.IdbenutzerGeaendert, e.LetztesDatum, e.Intervall, e.OriginalJn, e.DatumErstellt, e.DatumGeaendert, e.StartDatum, e.EndeDatum, e.Dauer, e.LetzteEvaluierung, e.Warnhinweis, e.Anmerkung, e.ErledigtGrund, e.Text, e.LokalisierungSeite, e.WochenTage, e.IntervallTyp, e.EvalTage, e.Idberufsstand, e.ParalellJn, e.BarcodeId, e.LokalisierungJn, e.EinmaligJn, e.ErledigtJn, e.GeloeschtJn, e.Lokalisierung, e.ZuErledigenBis, e.Pdxjn, e.RmoptionalJn, e.UntertaegigeJn, e.SpenderAbgabeJn, e.IduntertaegigeGruppe, e.PrivatJn, e.IdlinkDokument, e.NaechsteEvaluierung, e.NaechsteEvaluierungBemerkung, e.OhneZeitBezug, e.Idzeitbereich, e.Idextern, e.Wundejn, e.EintragFlag, e.StartdatumNeu, e.NächstesDatum, e.Iddekurs, e.EintragGruppe })
                    .HasName("Eintraggruppe");

                entity.HasIndex(e => new { e.Id, e.Ideintrag, e.IdbenutzerErstellt, e.IdbenutzerGeaendert, e.LetztesDatum, e.Intervall, e.OriginalJn, e.DatumErstellt, e.DatumGeaendert, e.StartDatum, e.EndeDatum, e.Dauer, e.LetzteEvaluierung, e.Warnhinweis, e.Anmerkung, e.ErledigtGrund, e.Text, e.LokalisierungSeite, e.WochenTage, e.IntervallTyp, e.EvalTage, e.Idberufsstand, e.ParalellJn, e.IduntertaegigeGruppe, e.LokalisierungJn, e.EinmaligJn, e.ErledigtJn, e.GeloeschtJn, e.Lokalisierung, e.ZuErledigenBis, e.EintragGruppe, e.Pdxjn, e.RmoptionalJn, e.UntertaegigeJn, e.SpenderAbgabeJn, e.Idextern, e.BarcodeId, e.IdlinkDokument, e.NaechsteEvaluierung, e.NaechsteEvaluierungBemerkung, e.Idzeitbereich, e.StartdatumNeu, e.Wundejn, e.EintragFlag, e.NächstesDatum, e.Iddekurs, e.PrivatJn, e.Idaufenthalt, e.OhneZeitBezug })
                    .HasName("_dta_index_PflegePlan_5_597577167__K2_K40_1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32_");

                entity.HasIndex(e => new { e.Ideintrag, e.StartDatum, e.ErledigtGrund, e.IdbenutzerErstellt, e.IdbenutzerGeaendert, e.OriginalJn, e.DatumErstellt, e.DatumGeaendert, e.Idberufsstand, e.EndeDatum, e.LetztesDatum, e.LetzteEvaluierung, e.Warnhinweis, e.Anmerkung, e.Lokalisierung, e.Text, e.Intervall, e.WochenTage, e.IntervallTyp, e.EvalTage, e.IduntertaegigeGruppe, e.ParalellJn, e.Dauer, e.LokalisierungJn, e.EinmaligJn, e.GeloeschtJn, e.Idzeitbereich, e.LokalisierungSeite, e.Pdxjn, e.RmoptionalJn, e.UntertaegigeJn, e.SpenderAbgabeJn, e.Idextern, e.BarcodeId, e.IdlinkDokument, e.NaechsteEvaluierung, e.NaechsteEvaluierungBemerkung, e.OhneZeitBezug, e.StartdatumNeu, e.ZuErledigenBis, e.EintragFlag, e.NächstesDatum, e.Iddekurs, e.PrivatJn, e.Idaufenthalt, e.Wundejn, e.ErledigtJn, e.EintragGruppe, e.Id })
                    .HasName("_dta_index_PflegePlan_5_597577167__K2_K43_K26_K30_K1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_27_28_29_31_");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AnmerkungRtf)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeId)
                    .HasColumnName("BarcodeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.EinmaligJn).HasColumnName("EinmaligJN");

                entity.Property(e => e.EintragFlag).HasDefaultValueSql("((3))");

                entity.Property(e => e.EintragGruppe)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EndeDatum).HasColumnType("datetime");

                entity.Property(e => e.ErledigtGrund)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ErledigtJn).HasColumnName("ErledigtJN");

                entity.Property(e => e.GeloeschtJn).HasColumnName("GeloeschtJN");

                entity.Property(e => e.Idbefund).HasColumnName("IDBefund");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Idberufsstand).HasColumnName("IDBerufsstand");

                entity.Property(e => e.Iddekurs).HasColumnName("IDDekurs");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idextern).HasColumnName("IDExtern");

                entity.Property(e => e.IdlinkDokument).HasColumnName("IDLinkDokument");

                entity.Property(e => e.IduntertaegigeGruppe).HasColumnName("IDUntertaegigeGruppe");

                entity.Property(e => e.Idzeitbereich).HasColumnName("IDZeitbereich");

                entity.Property(e => e.LetzteEvaluierung).HasColumnType("datetime");

                entity.Property(e => e.LetztesDatum).HasColumnType("datetime");

                entity.Property(e => e.LogInNameFrei)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lokalisierung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LokalisierungJn).HasColumnName("LokalisierungJN");

                entity.Property(e => e.LokalisierungSeite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LstIdpdx)
                    .IsRequired()
                    .HasColumnName("lstIDPDx")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstPdxBezeichnung)
                    .IsRequired()
                    .HasColumnName("lstPDxBezeichnung")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaechsteEvaluierung).HasColumnType("datetime");

                entity.Property(e => e.NaechsteEvaluierungBemerkung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NächstesDatum).HasColumnType("datetime");

                entity.Property(e => e.OriginalJn).HasColumnName("OriginalJN");

                entity.Property(e => e.ParalellJn).HasColumnName("ParalellJN");

                entity.Property(e => e.Pdxjn).HasColumnName("PDXJN");

                entity.Property(e => e.PrivatJn).HasColumnName("PrivatJN");

                entity.Property(e => e.RmoptionalJn).HasColumnName("RMOptionalJN");

                entity.Property(e => e.SpenderAbgabeJn).HasColumnName("SpenderAbgabeJN");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.StartdatumNeu)
                    .HasColumnName("Startdatum_Neu")
                    .HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UntertaegigeJn).HasColumnName("UntertaegigeJN");

                entity.Property(e => e.Warnhinweis)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Wundejn).HasColumnName("wundejn");

                entity.Property(e => e.ZuErledigenBis).HasColumnType("datetime");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.PflegePlan)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_PflegePlan_Aufenthalt");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.PflegePlanIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_PflegePlan_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.PflegePlanIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .HasConstraintName("FK_PflegePlan_Benutzer1");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.PflegePlan)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_PflegePlan_Eintrag");

                entity.HasOne(d => d.IdzeitbereichNavigation)
                    .WithMany(p => p.PflegePlan)
                    .HasForeignKey(d => d.Idzeitbereich)
                    .HasConstraintName("FK_PflegePlan_Zeitbereich");
            });

            modelBuilder.Entity<PflegePlanH>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piPflegePlanH")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.IdpflegePlan, e.DatumGeaendert })
                    .HasName("_dta_index_PflegePlanH_5_709577566__K3_K10_1");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aktion)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Anmerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.EinmaligJn).HasColumnName("EinmaligJN");

                entity.Property(e => e.EintragFlag).HasDefaultValueSql("((3))");

                entity.Property(e => e.EintragGruppe)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EndeDatum).HasColumnType("datetime");

                entity.Property(e => e.ErledigtGrund)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ErledigtJn).HasColumnName("ErledigtJN");

                entity.Property(e => e.GeloeschtJn).HasColumnName("GeloeschtJN");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idbefund).HasColumnName("IDBefund");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Idberufsstand).HasColumnName("IDBerufsstand");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idevaluierung).HasColumnName("IDEvaluierung");

                entity.Property(e => e.IdpflegePlan).HasColumnName("IDPflegePlan");

                entity.Property(e => e.Idzeitbereich).HasColumnName("IDZeitbereich");

                entity.Property(e => e.LetzteEvaluierung).HasColumnType("datetime");

                entity.Property(e => e.LetztesDatum).HasColumnType("datetime");

                entity.Property(e => e.Lokalisierung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LokalisierungJn).HasColumnName("LokalisierungJN");

                entity.Property(e => e.LokalisierungSeite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NaechsteEvaluierung).HasColumnType("datetime");

                entity.Property(e => e.NaechsteEvaluierungBemerkung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OriginalJn).HasColumnName("OriginalJN");

                entity.Property(e => e.ParalellJn).HasColumnName("ParalellJN");

                entity.Property(e => e.Pdxjn).HasColumnName("PDXJN");

                entity.Property(e => e.RmoptionalJn).HasColumnName("RMOptionalJN");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Warnhinweis)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZuErledigenBis).HasColumnType("datetime");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.PflegePlanHIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_PflegePlanH_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.PflegePlanHIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .HasConstraintName("FK_PflegePlanH_Benutzer1");
            });

            modelBuilder.Entity<PflegePlanPdx>(entity =>
            {
                entity.ToTable("PflegePlanPDx");

                entity.HasIndex(e => e.Id)
                    .HasName("piPflegePlanPDx")
                    .IsUnique();

                entity.HasIndex(e => e.IduntertaegigeGruppe)
                    .HasName("IDUntertaegigeGruppe");

                entity.HasIndex(e => new { e.Id, e.Ideintrag, e.Idpdx, e.IdbenutzerErstellt, e.IdbenutzerBeendet, e.DatumErstellt, e.DatumBeendet, e.ErledigtJn, e.ErledigtGrund, e.IdaufenthaltPdx, e.IdpflegePlan })
                    .HasName("_dta_index_PflegePlanPDx_5_725577623__K2_1_3_4_5_6_7_8_9_10_11");

                entity.HasIndex(e => new { e.Id, e.IdpflegePlan, e.Ideintrag, e.Idpdx, e.IdbenutzerErstellt, e.IdbenutzerBeendet, e.DatumErstellt, e.DatumBeendet, e.ErledigtJn, e.ErledigtGrund, e.IdaufenthaltPdx })
                    .HasName("_dta_index_PflegePlanPDx_5_725577623__K11_1_2_3_4_5_6_7_8_9_10");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumBeendet).HasColumnType("datetime");

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.ErledigtGrund)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ErledigtJn).HasColumnName("ErledigtJN");

                entity.Property(e => e.IdaufenthaltPdx).HasColumnName("IDAufenthaltPDx");

                entity.Property(e => e.IdbenutzerBeendet).HasColumnName("IDBenutzer_Beendet");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idpdx).HasColumnName("IDPDX");

                entity.Property(e => e.IdpflegePlan).HasColumnName("IDPflegePlan");

                entity.Property(e => e.IduntertaegigeGruppe).HasColumnName("IDUntertaegigeGruppe");

                entity.HasOne(d => d.IdaufenthaltPdxNavigation)
                    .WithMany(p => p.PflegePlanPdx)
                    .HasForeignKey(d => d.IdaufenthaltPdx)
                    .HasConstraintName("FK_PflegePlanPDx_AufenthaltPDx");

                entity.HasOne(d => d.IdbenutzerBeendetNavigation)
                    .WithMany(p => p.PflegePlanPdxIdbenutzerBeendetNavigation)
                    .HasForeignKey(d => d.IdbenutzerBeendet)
                    .HasConstraintName("FK_PflegePlanPDx_Benutzer1");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.PflegePlanPdxIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_PflegePlanPDx_Benutzer");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.PflegePlanPdx)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_PflegePlanPDx_Eintrag");

                entity.HasOne(d => d.IdpdxNavigation)
                    .WithMany(p => p.PflegePlanPdx)
                    .HasForeignKey(d => d.Idpdx)
                    .HasConstraintName("FK_PflegePlanPDx_PDX");

                entity.HasOne(d => d.IdpflegePlanNavigation)
                    .WithMany(p => p.PflegePlanPdx)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.IdpflegePlan)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PflegePlanPDx_PflegePlan");
            });

            modelBuilder.Entity<Pflegegeldstufe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PflegegeldstufeGueltig>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Betrag).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.Idpflegegeldstufe).HasColumnName("IDPflegegeldstufe");

                entity.HasOne(d => d.IdpflegegeldstufeNavigation)
                    .WithMany(p => p.PflegegeldstufeGueltig)
                    .HasForeignKey(d => d.Idpflegegeldstufe)
                    .HasConstraintName("FK_PflegegeldstufeGueltig_Pflegegeldstufe");
            });

            modelBuilder.Entity<Pflegemodelle>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodeSystem)
                    .IsRequired()
                    .HasColumnName("codeSystem")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodeSystemName)
                    .IsRequired()
                    .HasColumnName("codeSystemName")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("displayName")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Modell)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModellgruppeKlartext)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateId)
                    .IsRequired()
                    .HasColumnName("templateId")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TemplateId2)
                    .IsRequired()
                    .HasColumnName("templateId2")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_tblAufgaben2")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("plan");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AwaitingResponse)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeginntAm).HasColumnType("datetime");

                entity.Property(e => e.Betreff)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConversationId)
                    .HasColumnName("ConversationID")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dauer).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Db).HasColumnName("db");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Design).HasColumnName("design");

                entity.Property(e => e.DetailsMime)
                    .HasColumnName("DetailsMIME")
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmpfangenAm)
                    .HasColumnName("empfangenAm")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndetAm).HasColumnType("datetime");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FälligAm).HasColumnType("datetime");

                entity.Property(e => e.Für)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesendetAm)
                    .HasColumnName("gesendetAm")
                    .HasColumnType("datetime");

                entity.Property(e => e.Html).HasColumnName("html");

                entity.Property(e => e.Id1tmp).HasColumnName("ID1Tmp");

                entity.Property(e => e.Id2tmp).HasColumnName("ID2Tmp");

                entity.Property(e => e.Id3tmp).HasColumnName("ID3Tmp");

                entity.Property(e => e.Idactivity).HasColumnName("IDActivity");

                entity.Property(e => e.Idart).HasColumnName("IDArt");

                entity.Property(e => e.Idfolder).HasColumnName("IDFolder");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idoutlook)
                    .IsRequired()
                    .HasColumnName("IDoutlook")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdoutlookTicks)
                    .IsRequired()
                    .HasColumnName("IDoutlookTicks")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdplanMain).HasColumnName("IDPlanMain");

                entity.Property(e => e.Idserientermin).HasColumnName("IDSerientermin");

                entity.Property(e => e.Idstatus)
                    .HasColumnName("IDStatus")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Idtyp)
                    .HasColumnName("IDTyp")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IduserAccount).HasColumnName("IDUserAccount");

                entity.Property(e => e.KommStatus)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastChangeItscont)
                    .HasColumnName("LastChangeITSCont")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastSyncToExchange).HasColumnType("datetime");

                entity.Property(e => e.MailAn)
                    .IsRequired()
                    .HasMaxLength(6000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailBcc)
                    .IsRequired()
                    .HasMaxLength(6000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailCc)
                    .IsRequired()
                    .HasColumnName("MailCC")
                    .HasMaxLength(6000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailFrom)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MessageId)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NTenMonat).HasColumnName("nTenMonat");

                entity.Property(e => e.OutlookApi).HasColumnName("OutlookAPI");

                entity.Property(e => e.Priorität)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Readed)
                    .IsRequired()
                    .HasColumnName("readed")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RemembJn).HasColumnName("remembJN");

                entity.Property(e => e.RemembMinut).HasColumnName("remembMinut");

                entity.Property(e => e.ReplyTxt)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerienterminEndetAm).HasColumnType("datetime");

                entity.Property(e => e.SerienterminType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TagWochenMonat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Teilnehmer)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wichtig).HasColumnName("wichtig");

                entity.Property(e => e.Wochentage)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zusatz)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IduserAccountNavigation)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.IduserAccount)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_plan_tblUserAccounts2");
            });

            modelBuilder.Entity<PlanAnhang>(entity =>
            {
                entity.ToTable("planAnhang");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateiTyp)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Doku).HasColumnName("doku");

                entity.Property(e => e.Idplan).HasColumnName("IDPlan");

                entity.HasOne(d => d.IdplanNavigation)
                    .WithMany(p => p.PlanAnhang)
                    .HasForeignKey(d => d.Idplan)
                    .HasConstraintName("FK_tblAufgabenAnhang_tblAufgaben2");
            });

            modelBuilder.Entity<PlanObject>(entity =>
            {
                entity.ToTable("planObject");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idobject).HasColumnName("IDObject");

                entity.Property(e => e.Idplan).HasColumnName("IDPlan");

                entity.Property(e => e.IdselList).HasColumnName("IDSelList");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdplanNavigation)
                    .WithMany(p => p.PlanObject)
                    .HasForeignKey(d => d.Idplan)
                    .HasConstraintName("FK_tblAufgabeZuordnung_tblAufgaben2");
            });

            modelBuilder.Entity<PlanStatus>(entity =>
            {
                entity.ToTable("planStatus");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Am).HasColumnType("datetime");

                entity.Property(e => e.Betreff)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idplan).HasColumnName("IDPlan");

                entity.Property(e => e.MessageId)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Usr)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Protocol>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK_Protocoll");

                entity.ToTable("Protocol", "qs2");

                entity.HasIndex(e => new { e.Idguid, e.Info, e.Created, e.CreatedDay, e.Progress, e.Type, e.SKey })
                    .HasName("_dta_index_Protocol_6_393104491__K4_K9_1_3_13_17_18");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Db)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idapplication)
                    .IsRequired()
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdguidObject).HasColumnName("IDGuidObject");

                entity.Property(e => e.Idparticipant)
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(150);

                entity.Property(e => e.Idstay).HasColumnName("IDStay");

                entity.Property(e => e.IdstayApplication)
                    .HasColumnName("IDStayApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InfoFile)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MedRecNr)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Patient)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progress)
                    .IsRequired()
                    .HasColumnName("progress")
                    .HasColumnType("nvarchar(max)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Protocol1)
                    .IsRequired()
                    .HasColumnName("Protocol")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SKey)
                    .HasColumnName("sKey")
                    .HasMaxLength(300);

                entity.Property(e => e.Sql)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<QuickFilter>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbwBerufstandJn)
                    .HasColumnName("AbwBerufstandJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AbzeichnenJn)
                    .HasColumnName("AbzeichnenJN")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.BenutzenInDekursJn).HasColumnName("BenutzenInDekursJN");

                entity.Property(e => e.BenutzenInEvaluierungJn)
                    .HasColumnName("BenutzenInEvaluierungJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BenutzenInInterventionJn)
                    .HasColumnName("BenutzenInInterventionJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BereichIntervention).HasDefaultValueSql("((0))");

                entity.Property(e => e.BereichÜbergabe).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BezugspersonJn)
                    .HasColumnName("BezugspersonJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EintragTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.Idabteilung)
                    .HasColumnName("IDAbteilung")
                    .HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.IdbereichBereich)
                    .IsRequired()
                    .HasColumnName("IDBereichBereich")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdbereichEinzel)
                    .IsRequired()
                    .HasColumnName("IDBereichEinzel")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IddekursBereich)
                    .IsRequired()
                    .HasColumnName("IDDekursBereich")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IddekursEinzel)
                    .IsRequired()
                    .HasColumnName("IDDekursEinzel")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.IdinterventionBereich)
                    .IsRequired()
                    .HasColumnName("IDInterventionBereich")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdinterventionEinzel)
                    .IsRequired()
                    .HasColumnName("IDInterventionEinzel")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KeyLayout)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KeyQuickFilter)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstBerufsstand)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstBsquickfilter)
                    .IsRequired()
                    .HasColumnName("LstBSQuickfilter")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstErstelltVonBerufgruppe)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstHerkunftPlanungsEintrag)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstInterventionsTyp)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstWichtigFürBerufsgruppe)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstZeitbezug)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstZusatzwerte)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MassnahmeJn)
                    .HasColumnName("MassnahmeJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Massnahmen)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OhneZeitBezug).HasDefaultValueSql("((2))");

                entity.Property(e => e.Reihenfolge).HasDefaultValueSql("((0))");

                entity.Property(e => e.RueckgemeldeteTermineJn)
                    .HasColumnName("RueckgemeldeteTermineJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShowCc).HasColumnName("ShowCC");

                entity.Property(e => e.Tagenachher).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tagevorher).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tooltip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypJn)
                    .HasColumnName("TypJN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ZeitraumJn)
                    .HasColumnName("ZeitraumJN")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.QuickFilter)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_QuickFilter_Eintrag2");
            });

            modelBuilder.Entity<QuickMeldung>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idabteilung)
                    .HasColumnName("IDAbteilung")
                    .HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.QuickMeldung)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_QuickMeldung_Eintrag");
            });

            modelBuilder.Entity<RechNr>(entity =>
            {
                entity.HasKey(e => new { e.Typ, e.Year });

                entity.ToTable("rechNr");

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.Nr)
                    .HasColumnName("nr")
                    .HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<Recht>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piRecht")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Elga).HasColumnName("ELGA");
            });

            modelBuilder.Entity<Rehabilitation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.EndeGrund)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Institution)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MassnahmeJn).HasColumnName("MassnahmeJN");

                entity.Property(e => e.Von).HasColumnType("datetime");

                entity.Property(e => e.Ziel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Rehabilitation)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_Rehabilitation_Patient");
            });

            modelBuilder.Entity<Ressourcen>(entity =>
            {
                entity.HasKey(e => new { e.Idres, e.IdlanguageUser, e.Idapplication, e.Idparticipant, e.Type })
                    .HasName("PK_tblLanguage_1");

                entity.ToTable("Ressourcen", "qs2");

                entity.HasIndex(e => e.Idapplication)
                    .HasName("IX_Ressourcen_2");

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_Ressourcen_3")
                    .IsUnique();

                entity.HasIndex(e => e.Idres)
                    .HasName("IX_Ressourcen");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_tblLanguage");

                entity.Property(e => e.Idres)
                    .HasColumnName("IDRes")
                    .HasMaxLength(255);

                entity.Property(e => e.IdlanguageUser)
                    .HasColumnName("IDLanguageUser")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('ALL')");

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('ALL')");

                entity.Property(e => e.Idparticipant)
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('ALL')");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Label')");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.English).IsRequired();

                entity.Property(e => e.FileBytes).HasColumnName("fileBytes");

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasColumnName("fileType")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.German)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImageHeigth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ImageWidth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ResGroup)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeSub)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<RezeptBestellungPos>(entity =>
            {
                entity.HasIndex(e => new { e.RezeptAngefordertDatum, e.RezeptAnforderungDatum, e.Id, e.DatumBestellt, e.GedrucktJn, e.Dringend, e.DatumGedruckt, e.RezeptAngefordertJn, e.IdrezeptEintrag, e.BestelltJn })
                    .HasName("_dta_index_RezeptBestellungPos_5_1442820202__K9_K3_K4_1_5_6_7_8_10_11");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BestelltJn).HasColumnName("BestelltJN");

                entity.Property(e => e.DatumBestellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGedruckt).HasColumnType("datetime");

                entity.Property(e => e.GedrucktJn).HasColumnName("GedrucktJN");

                entity.Property(e => e.IdrezeptEintrag).HasColumnName("IDRezeptEintrag");

                entity.Property(e => e.Packungsanzahl).HasDefaultValueSql("((-1))");

                entity.Property(e => e.RezeptAnforderungDatum).HasColumnType("datetime");

                entity.Property(e => e.RezeptAngefordertDatum).HasColumnType("datetime");

                entity.Property(e => e.RezeptAngefordertJn).HasColumnName("RezeptAngefordertJN");
            });

            modelBuilder.Entity<RezeptEintrag>(entity =>
            {
                entity.HasIndex(e => new { e.Idaufenthalt, e.Idmedikament, e.AbzugebenBis, e.AbzugebenVon, e.Packunggroesse })
                    .HasName("_dta_index_RezeptEintrag_5_741577680__K42_K3_K5_K4_K36");

                entity.HasIndex(e => new { e.Packunggroesse, e.Packungeinheit, e.Packungsanzahl, e.ZuletztBestelltAm, e.Idaufenthalt, e.Id, e.Idaerzte, e.Idmedikament })
                    .HasName("_dta_index_RezeptEintrag_5_741577680__K42_K1_K41_K3_36_39_45_46");

                entity.HasIndex(e => new { e.Id, e.Idmedikament, e.Zp3, e.Zp4, e.Zp5, e.Wochentage, e.BedarfsMedikationJn, e.Bemerkung, e.Zp0, e.Zp1, e.Zp2, e.DatumGeaendert, e.Herrichten, e.AerztlichevorbereitungJn, e.Zp6, e.Einheit, e.Intervall, e.Wiederholungseinheit, e.Wiederholungswert, e.StandardzeitenJn, e.IdbenutzerErstellt, e.IdbenutzerGeaendert, e.DatumErstellt, e.Zeitpunkt3, e.Zeitpunkt4, e.Packunggroesse, e.Verabreichungsart, e.Applikationsform, e.Wiederholungstyp, e.Idaerzte, e.AusstellungsDatum, e.DosierungAsstring, e.Zeitpunkt0, e.Zeitpunkt1, e.Zeitpunkt2, e.BeaufsichtigungJn, e.Packungsanzahl, e.ZuletztBestelltAm, e.Rezeptdaten, e.Packungeinheit, e.BestellenJn, e.Idaufenthalt, e.AbzugebenVon, e.AbzugebenBis })
                    .HasName("_dta_index_RezeptEintrag_5_741577680__K42_K4_K5_1_3_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbzugebenBis).HasColumnType("datetime");

                entity.Property(e => e.AbzugebenVon).HasColumnType("datetime");

                entity.Property(e => e.AerztlichevorbereitungJn).HasColumnName("AerztlichevorbereitungJN");

                entity.Property(e => e.Applikationsform)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('' collate Latin1_General_CI_AS)");

                entity.Property(e => e.AusstellungsDatum).HasColumnType("datetime");

                entity.Property(e => e.BeaufsichtigungJn).HasColumnName("BeaufsichtigungJN");

                entity.Property(e => e.BedarfsMedikationJn).HasColumnName("BedarfsMedikationJN");

                entity.Property(e => e.Bemerkung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BestellenJn).HasColumnName("BestellenJN");

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.DosierungAsstring)
                    .IsRequired()
                    .HasColumnName("DosierungASString")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Einheit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HagpflichtigJn).HasColumnName("HAGPflichtigJN");

                entity.Property(e => e.Idaerzte).HasColumnName("IDAerzte");

                entity.Property(e => e.IdaerzteGeaendert).HasColumnName("IDAerzteGeaendert");

                entity.Property(e => e.IdarztAbgesetzt).HasColumnName("IDArztAbgesetzt");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Idmedikament).HasColumnName("IDMedikament");

                entity.Property(e => e.LstMedDaten)
                    .IsRequired()
                    .HasColumnName("lstMedDaten")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstWunden)
                    .IsRequired()
                    .HasColumnName("lstWunden")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packungeinheit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packungsanzahl).HasDefaultValueSql("((1))");

                entity.Property(e => e.Rezeptdaten)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('' collate Latin1_General_CI_AS)");

                entity.Property(e => e.StandardzeitenJn).HasColumnName("StandardzeitenJN");

                entity.Property(e => e.Zeitpunkt0).HasColumnType("datetime");

                entity.Property(e => e.Zeitpunkt1).HasColumnType("datetime");

                entity.Property(e => e.Zeitpunkt2).HasColumnType("datetime");

                entity.Property(e => e.Zeitpunkt3).HasColumnType("datetime");

                entity.Property(e => e.Zeitpunkt4).HasColumnType("datetime");

                entity.Property(e => e.ZeitpunktBlisterliste).HasColumnType("datetime");

                entity.Property(e => e.Zp0).HasColumnName("ZP0");

                entity.Property(e => e.Zp1).HasColumnName("ZP1");

                entity.Property(e => e.Zp2).HasColumnName("ZP2");

                entity.Property(e => e.Zp3).HasColumnName("ZP3");

                entity.Property(e => e.Zp4).HasColumnName("ZP4");

                entity.Property(e => e.Zp5).HasColumnName("ZP5");

                entity.Property(e => e.Zp6).HasColumnName("ZP6");

                entity.Property(e => e.ZuletztBestelltAm).HasColumnType("datetime");

                entity.HasOne(d => d.IdaerzteNavigation)
                    .WithMany(p => p.RezeptEintrag)
                    .HasForeignKey(d => d.Idaerzte)
                    .HasConstraintName("FK_RezeptEintrag_Aerzte");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.RezeptEintrag)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_RezeptEintrag_Aufenthalt");

                entity.HasOne(d => d.IdmedikamentNavigation)
                    .WithMany(p => p.RezeptEintrag)
                    .HasForeignKey(d => d.Idmedikament)
                    .HasConstraintName("FK_RezeptEintrag_Medikament");
            });

            modelBuilder.Entity<RezeptEintragMedDaten>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdmedDaten).HasColumnName("IDMedDaten");

                entity.Property(e => e.Idrezepteintrag).HasColumnName("IDRezepteintrag");

                entity.Property(e => e.Idverordnung).HasColumnName("IDVerordnung");

                entity.Property(e => e.IdwundeKopf).HasColumnName("IDWundeKopf");

                entity.HasOne(d => d.IdmedDatenNavigation)
                    .WithMany(p => p.RezeptEintragMedDaten)
                    .HasForeignKey(d => d.IdmedDaten)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RezeptEintragMedDaten_MedizinischeDaten");

                entity.HasOne(d => d.IdrezepteintragNavigation)
                    .WithMany(p => p.RezeptEintragMedDaten)
                    .HasForeignKey(d => d.Idrezepteintrag)
                    .HasConstraintName("FK_RezeptEintragMedDaten_RezeptEintrag");
            });

            modelBuilder.Entity<Sachwalter>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Belange)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BestimmtAm).HasColumnType("datetime");

                entity.Property(e => e.Bis).HasColumnType("datetime");

                entity.Property(e => e.Gericht)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.Property(e => e.IdkontaktStammdaten).HasColumnName("IDKontaktStammdaten");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SachwalterJn).HasColumnName("SachwalterJN");

                entity.Property(e => e.Titel)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Von).HasColumnType("datetime");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.Sachwalter)
                    .HasForeignKey(d => d.Idadresse)
                    .HasConstraintName("FK_Sachwalter_Adresse");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.Sachwalter)
                    .HasForeignKey(d => d.Idkontakt)
                    .HasConstraintName("FK_Sachwalter_Kontakt");

                entity.HasOne(d => d.IdkontaktStammdatenNavigation)
                    .WithMany(p => p.Sachwalter)
                    .HasForeignKey(d => d.IdkontaktStammdaten)
                    .HasConstraintName("FK_Sachwalter_KontaktpersonStammdaten");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.SachwalterNavigation)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_Sachwalter_Patient");
            });

            modelBuilder.Entity<SonderleistungsKatalog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Betrag).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fibu)
                    .IsRequired()
                    .HasColumnName("FIBU")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Mwst).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Sp>(entity =>
            {
                entity.ToTable("SP");

                entity.HasIndex(e => new { e.Id, e.Zeitpunkt, e.IdstandardProzeduren, e.Anmerkung, e.IdbenutzerErstellt, e.IdbenutzerGeaendert, e.DatumGeaendert, e.DatumErstellt, e.EreignisZeitpunkt, e.OffenJn, e.Idaufenthalt })
                    .HasName("_dta_index_SP_5_1714821171__K6_K5_1_2_3_4_7_8_9_10_11");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.EreignisZeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.IdstandardProzeduren).HasColumnName("IDStandardProzeduren");

                entity.Property(e => e.OffenJn).HasColumnName("offenJN");

                entity.Property(e => e.Zeitpunkt).HasColumnType("datetime");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.Sp)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_SP_Aufenthalt");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.SpIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_SP_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.SpIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .HasConstraintName("FK_SP_Benutzer1");

                entity.HasOne(d => d.IdstandardProzedurenNavigation)
                    .WithMany(p => p.Sp)
                    .HasForeignKey(d => d.IdstandardProzeduren)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_StandardProzeduren");
            });

            modelBuilder.Entity<SpdynRep>(entity =>
            {
                entity.ToTable("SPDynRep");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DynRep)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdstandardProzeduren).HasColumnName("IDStandardProzeduren");

                entity.HasOne(d => d.IdstandardProzedurenNavigation)
                    .WithMany(p => p.SpdynRep)
                    .HasForeignKey(d => d.IdstandardProzeduren)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPDynRep_StandardProzeduren");
            });

            modelBuilder.Entity<Sppe>(entity =>
            {
                entity.ToTable("SPPE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdpflegeEintrag).HasColumnName("IDPflegeEintrag");

                entity.Property(e => e.Idsp).HasColumnName("IDSP");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.Sppe)
                    .HasForeignKey(d => d.Idsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPPE_SP");
            });

            modelBuilder.Entity<Sppos>(entity =>
            {
                entity.ToTable("SPPOS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AktivJn).HasColumnName("aktivJN");

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.Idsp).HasColumnName("IDSP");

                entity.Property(e => e.OefterJn).HasColumnName("oefterJN");

                entity.Property(e => e.Wiederumam)
                    .HasColumnName("wiederumam")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.SpposIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_SPPOS_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.SpposIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .HasConstraintName("FK_SPPOS_Benutzer1");

                entity.HasOne(d => d.IdeintragNavigation)
                    .WithMany(p => p.Sppos)
                    .HasForeignKey(d => d.Ideintrag)
                    .HasConstraintName("FK_SPPOS_EINTRAG");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.Sppos)
                    .HasForeignKey(d => d.Idsp)
                    .HasConstraintName("FK_SPPOS_SP");
            });

            modelBuilder.Entity<StandardProzeduren>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NotfallJn).HasColumnName("NotfallJN");
            });

            modelBuilder.Entity<Standardzeiten>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zeitpunkt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PK__sysdiagr__C2B05B61120DA62C");

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Taschengeld>(entity =>
            {
                entity.HasIndex(e => new { e.Einzahlung, e.Auszahlung, e.AbgerechnetJn, e.Idpatient })
                    .HasName("_dta_index_Taschengeld_5_1769773362__K20_K2_14_15");

                entity.HasIndex(e => new { e.Einzahlung, e.Auszahlung, e.Saldo, e.AbgerechnetJn, e.Idpatient, e.Datum })
                    .HasName("_dta_index_Taschengeld_5_1769773362__K2_K12_14_15_16_20");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgerechnetJn).HasColumnName("AbgerechnetJN");

                entity.Property(e => e.Auszahlung).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BelegNr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Einzahlung).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Grund)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idbenutzerdurchgefuehrt).HasColumnName("IDBenutzerdurchgefuehrt");

                entity.Property(e => e.Idklinik).HasColumnName("IDKlinik");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Lieferant)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdbenutzerdurchgefuehrtNavigation)
                    .WithMany(p => p.Taschengeld)
                    .HasForeignKey(d => d.Idbenutzerdurchgefuehrt)
                    .HasConstraintName("FK_Taschengeld_Benutzer");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.Taschengeld)
                    .HasForeignKey(d => d.Idpatient)
                    .HasConstraintName("FK_Taschengeld_Patient");
            });

            modelBuilder.Entity<TblAdjust>(entity =>
            {
                entity.HasKey(e => new { e.Setting, e.Client })
                    .HasName("PK_tblAdjust2");

                entity.ToTable("tblAdjust", "qs2");

                entity.HasIndex(e => new { e.Type, e.UsrSetting })
                    .HasName("IX_tblAdjust");

                entity.Property(e => e.Setting)
                    .HasColumnName("setting")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Client)
                    .HasColumnName("client")
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bool).HasColumnName("bool");

                entity.Property(e => e.Byt).HasColumnName("byt");

                entity.Property(e => e.Dat)
                    .HasColumnName("dat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbl).HasColumnName("dbl");

                entity.Property(e => e.Str)
                    .IsRequired()
                    .HasColumnName("str")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsrSetting).HasColumnName("usrSetting");
            });

            modelBuilder.Entity<TblAdress>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK_tblAdress_1");

                entity.ToTable("tblAdress", "qs2");

                entity.HasIndex(e => e.City)
                    .HasName("IX_tblAdress_2");

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_tblAdress_5")
                    .IsUnique();

                entity.HasIndex(e => e.IdguidObject)
                    .HasName("ix_IDGuidObject")
                    .IsUnique();

                entity.HasIndex(e => e.Zip)
                    .HasName("IX_tblAdress_3");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdguidObject).HasColumnName("IDGuidObject");

                entity.Property(e => e.PhoneBusiness)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneMobil)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhonePrivat)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Web)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("ZIP")
                    .HasMaxLength(70)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdguidObjectNavigation)
                    .WithOne(p => p.TblAdress)
                    .HasPrincipalKey<TblObject>(p => p.Idguid)
                    .HasForeignKey<TblAdress>(d => d.IdguidObject)
                    .HasConstraintName("FK_tblAdress_tblObject");
            });

            modelBuilder.Entity<TblAutoDoku>(entity =>
            {
                entity.ToTable("tblAutoDoku");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DocuRtf)
                    .IsRequired()
                    .HasColumnName("docuRtf")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Html)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdresTitle)
                    .IsRequired()
                    .HasColumnName("IDResTitle")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Txt)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasColumnName("typ")
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblCriteria>(entity =>
            {
                entity.HasKey(e => new { e.FldShort, e.Idapplication });

                entity.ToTable("tblCriteria", "qs2");

                entity.HasIndex(e => e.AliasFldShort)
                    .HasName("IX_tblCriteria_1");

                entity.HasIndex(e => e.ControlType)
                    .HasName("IX_tblCriteria_2");

                entity.HasIndex(e => e.Editable)
                    .HasName("IX_tblCriteria_5");

                entity.HasIndex(e => e.FldShort)
                    .HasName("IX_tblCriteria_6")
                    .IsUnique();

                entity.HasIndex(e => e.SourceTable)
                    .HasName("IX_tblCriteria_4");

                entity.HasIndex(e => e.UseInQueries)
                    .HasName("IX_tblCriteria_3");

                entity.HasIndex(e => new { e.FldShort, e.Idapplication })
                    .HasName("IX_tblCriteria");

                entity.Property(e => e.FldShort).HasMaxLength(60);

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.AliasFldShort)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ControlMaxLength).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ControlMaxVal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ControlMinLength).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ControlMinVal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ControlPattern)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ControlType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Editable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LicenseKey)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaskInput)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prefered)
                    .IsRequired()
                    .HasColumnName("prefered")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowAt)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SourceTable)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SqlvalueListSelect)
                    .IsRequired()
                    .HasColumnName("SQLValueListSelect")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseInQueries)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblCriteriaOpt>(entity =>
            {
                entity.HasKey(e => new { e.FldShort, e.Idapplication, e.Parameter });

                entity.ToTable("tblCriteriaOpt", "qs2");

                entity.HasIndex(e => e.Parameter)
                    .HasName("IX_tblCriteriaOpt");

                entity.Property(e => e.FldShort).HasMaxLength(60);

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.Parameter).HasMaxLength(100);

                entity.Property(e => e.Referenze)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VersionNrFrom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VersionNrTo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.TblCriteria)
                    .WithMany(p => p.TblCriteriaOpt)
                    .HasForeignKey(d => new { d.FldShort, d.Idapplication })
                    .HasConstraintName("FK_tblCriteriaOpt_tblCriteria");
            });

            modelBuilder.Entity<TblDbversion>(entity =>
            {
                entity.HasKey(e => e.VersionDate);

                entity.ToTable("tblDBVersion", "qs2");

                entity.Property(e => e.VersionDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblDokumente>(entity =>
            {
                entity.ToTable("tblDokumente");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Archivordner)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateinameArchiv)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateinameOrig)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateinameTyp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DokumentErstellt).HasColumnType("datetime");

                entity.Property(e => e.DokumentGeändert).HasColumnType("datetime");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iddokumenteintrag).HasColumnName("IDDokumenteintrag");

                entity.Property(e => e.VerzeichnisOrig)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddokumenteintragNavigation)
                    .WithMany(p => p.TblDokumente)
                    .HasForeignKey(d => d.Iddokumenteintrag)
                    .HasConstraintName("FK_tblDokumente_tblDokumenteintrag");
            });

            modelBuilder.Entity<TblDokumenteGelesen>(entity =>
            {
                entity.ToTable("tblDokumenteGelesen");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnzahlBenachrichtigt).HasColumnName("anzahlBenachrichtigt");

                entity.Property(e => e.Gelesen).HasColumnName("gelesen");

                entity.Property(e => e.Iddokumenteneintrag).HasColumnName("IDDokumenteneintrag");

                entity.HasOne(d => d.IddokumenteneintragNavigation)
                    .WithMany(p => p.TblDokumenteGelesen)
                    .HasForeignKey(d => d.Iddokumenteneintrag)
                    .HasConstraintName("FK_tblDokumentGelesen_tblDokumenteintrag");
            });

            modelBuilder.Entity<TblDokumenteintrag>(entity =>
            {
                entity.ToTable("tblDokumenteintrag");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GültigBis).HasColumnType("datetime");

                entity.Property(e => e.GültigVon).HasColumnType("datetime");

                entity.Property(e => e.Idordner).HasColumnName("IDOrdner");

                entity.Property(e => e.Notiz)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotizRtf)
                    .HasColumnName("NotizRTF")
                    .HasColumnType("image");

                entity.Property(e => e.Wichtigkeit)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblDokumenteneintragSchlagwörter>(entity =>
            {
                entity.ToTable("tblDokumenteneintragSchlagwörter");

                entity.HasIndex(e => new { e.Idschlagwort, e.Iddokumenteneintrag })
                    .HasName("IX_tblDokumenteneintragSchlagwörter")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iddokumenteneintrag).HasColumnName("IDDokumenteneintrag");

                entity.Property(e => e.Idschlagwort).HasColumnName("IDSchlagwort");

                entity.HasOne(d => d.IddokumenteneintragNavigation)
                    .WithMany(p => p.TblDokumenteneintragSchlagwörter)
                    .HasForeignKey(d => d.Iddokumenteneintrag)
                    .HasConstraintName("FK_tblDokumenteneintragSchlagwörter_tblDokumenteintrag");

                entity.HasOne(d => d.IdschlagwortNavigation)
                    .WithMany(p => p.TblDokumenteneintragSchlagwörter)
                    .HasForeignKey(d => d.Idschlagwort)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDokumenteneintragSchlagwörter_tblSchlagwörter");
            });

            modelBuilder.Entity<TblFach>(entity =>
            {
                entity.ToTable("tblFach");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idschrank).HasColumnName("IDSchrank");

                entity.HasOne(d => d.IdschrankNavigation)
                    .WithMany(p => p.TblFach)
                    .HasForeignKey(d => d.Idschrank)
                    .HasConstraintName("FK_tblFach_tblSchrank");
            });

            modelBuilder.Entity<TblFortbildungBenutzer>(entity =>
            {
                entity.ToTable("tblFortbildungBenutzer");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgeschlossenAm).HasColumnType("datetime");

                entity.Property(e => e.Anmeldedatum).HasColumnType("datetime");

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Erfolg).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Idbenutzer).HasColumnName("IDBenutzer");

                entity.Property(e => e.Idfortbildung).HasColumnName("IDFortbildung");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuErneuernAm).HasColumnType("datetime");

                entity.HasOne(d => d.IdbenutzerNavigation)
                    .WithMany(p => p.TblFortbildungBenutzer)
                    .HasForeignKey(d => d.Idbenutzer)
                    .HasConstraintName("FK_tblFortbildungBenutzer_Benutzer");

                entity.HasOne(d => d.IdfortbildungNavigation)
                    .WithMany(p => p.TblFortbildungBenutzer)
                    .HasForeignKey(d => d.Idfortbildung)
                    .HasConstraintName("FK_tblFortbildungBenutzer_tblFortbildungen");
            });

            modelBuilder.Entity<TblFortbildungen>(entity =>
            {
                entity.ToTable("tblFortbildungen");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnzahlFreiePlätze).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AnzahlStunden).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Beginn).HasColumnType("datetime");

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ende).HasColumnType("datetime");

                entity.Property(e => e.Idveranstalter).HasColumnName("IDVeranstalter");

                entity.Property(e => e.Veranstaltungsort)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Voraussetzungen)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vortragender)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zertifikat)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdveranstalterNavigation)
                    .WithMany(p => p.TblFortbildungen)
                    .HasForeignKey(d => d.Idveranstalter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFortbildungen_tblVeranstalter");
            });

            modelBuilder.Entity<TblInterop>(entity =>
            {
                entity.ToTable("tblInterop");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbPar)
                    .IsRequired()
                    .HasColumnName("dbPar")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DoAt)
                    .HasColumnName("doAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Done).HasColumnName("done");

                entity.Property(e => e.DoneAt)
                    .HasColumnName("doneAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromClient)
                    .IsRequired()
                    .HasColumnName("fromClient")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromUser)
                    .IsRequired()
                    .HasColumnName("fromUser")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReplyError)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReplyTxt)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReplyTxtDetail)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypAction)
                    .IsRequired()
                    .HasColumnName("typAction")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblMedArchiv>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK_tblMedArchiv_1");

                entity.ToTable("tblMedArchiv", "qs2");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocId)
                    .IsRequired()
                    .HasColumnName("DocID")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Document64)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentInfoHl7)
                    .IsRequired()
                    .HasColumnName("DocumentInfo_HL7");

                entity.Property(e => e.DocumentVersion).HasColumnName("Document_Version");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idapplication)
                    .IsRequired()
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.IdguidObject).HasColumnName("IDGuidObject");

                entity.Property(e => e.IdobjectGuid).HasColumnName("IDObjectGuid");

                entity.Property(e => e.Idparticipant)
                    .IsRequired()
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(150);

                entity.Property(e => e.Idstay).HasColumnName("IDStay");

                entity.Property(e => e.IdstayGuid).HasColumnName("IDStayGuid");

                entity.Property(e => e.Participant)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdguidObjectNavigation)
                    .WithMany(p => p.TblMedArchiv)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.IdguidObject)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblMedArchiv_tblObject");

                entity.HasOne(d => d.IdstayGu)
                    .WithMany(p => p.TblMedArchiv)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.IdstayGuid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblMedArchiv_tblStay");
            });

            modelBuilder.Entity<TblNachricht>(entity =>
            {
                entity.ToTable("tbl_Nachricht");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdbenutzerFrom).HasColumnName("IDBenutzerFrom");

                entity.Property(e => e.IdbenutzerTo).HasColumnName("IDBenutzerTo");

                entity.Property(e => e.IdberufsstandFrom).HasColumnName("IDBerufsstandFrom");

                entity.Property(e => e.IdberufsstandTo).HasColumnName("IDBerufsstandTo");

                entity.Property(e => e.Ideintrag).HasColumnName("IDEintrag");

                entity.Property(e => e.IdpflegePlan).HasColumnName("IDPflegePlan");

                entity.Property(e => e.Nachricht)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.Zeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.Zeitstempel).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblObject>(entity =>
            {
                entity.ToTable("tblObject", "qs2");

                entity.HasIndex(e => e.Domain)
                    .HasName("IX_tblObject_8");

                entity.HasIndex(e => e.ExtId)
                    .HasName("IX_tblObject_9")
                    .IsUnique();

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_tblObject")
                    .IsUnique();

                entity.HasIndex(e => e.IsImported)
                    .HasName("IX_tblObject_2");

                entity.HasIndex(e => e.NameCombination)
                    .HasName("IX_tblObject_6");

                entity.HasIndex(e => e.Sort)
                    .HasName("IX_tblObject_5");

                entity.HasIndex(e => e.UserNameDomain)
                    .HasName("IX_tblObject_7");

                entity.HasIndex(e => new { e.UserName, e.UserShort })
                    .HasName("IX_tblObject_3");

                entity.HasIndex(e => new { e.IsPatient, e.IsPersonal, e.IsUser })
                    .HasName("IX_tblObject_4");

                entity.HasIndex(e => new { e.LastName, e.FirstName, e.NameCombination })
                    .HasName("IX_tblObject_1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bpkz)
                    .IsRequired()
                    .HasColumnName("BPKZ")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bpkz1)
                    .IsRequired()
                    .HasColumnName("BPKZ1")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bpkz2)
                    .IsRequired()
                    .HasColumnName("BPKZ2")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CongenitalData)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserId)
                    .IsRequired()
                    .HasColumnName("CreatedUserID")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtId)
                    .IsRequired()
                    .HasColumnName("ExtID")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtIdnr)
                    .HasColumnName("ExtIDNr")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Gender).HasDefaultValueSql("((0))");

                entity.Property(e => e.Icd9)
                    .IsRequired()
                    .HasColumnName("ICD9")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idparticipant)
                    .IsRequired()
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.IsJehova).HasDefaultValueSql("((-1))");

                entity.Property(e => e.KavVidierungPwd)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaidenName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MtCause).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MtCauseDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MtDate).HasColumnType("datetime");

                entity.Property(e => e.MtStat).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Mtlocatn)
                    .HasColumnName("MTLocatn")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.NameCombination)
                    .IsRequired()
                    .HasMaxLength(700)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatOrigin).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Race).HasDefaultValueSql("((0))");

                entity.Property(e => e.Role).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserNameDomain)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserShort)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblObjectApplications>(entity =>
            {
                entity.ToTable("tblObjectApplications", "qs2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idapplication)
                    .IsRequired()
                    .HasColumnName("IDApplication")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdobjectGuid).HasColumnName("IDObjectGuid");

                entity.HasOne(d => d.IdobjectGu)
                    .WithMany(p => p.TblObjectApplications)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.IdobjectGuid)
                    .HasConstraintName("FK_tblObjectApplications_tblObject");
            });

            modelBuilder.Entity<TblObjectRel>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("tblObjectRel", "qs2");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdguidObject).HasColumnName("IDGuidObject");

                entity.Property(e => e.IdguidObjectSub).HasColumnName("IDGuidObjectSub");

                entity.HasOne(d => d.IdguidObjectNavigation)
                    .WithMany(p => p.TblObjectRelIdguidObjectNavigation)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.IdguidObject)
                    .HasConstraintName("FK_tblObjectRel_tblObject");

                entity.HasOne(d => d.IdguidObjectSubNavigation)
                    .WithMany(p => p.TblObjectRelIdguidObjectSubNavigation)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.IdguidObjectSub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblObjectRel_tblObject1");
            });

            modelBuilder.Entity<TblObjekt>(entity =>
            {
                entity.ToTable("tblObjekt");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Benutzer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datenbank)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdGuid).HasColumnName("ID_guid");

                entity.Property(e => e.IdInt).HasColumnName("ID_int");

                entity.Property(e => e.IdStr)
                    .HasColumnName("ID_str")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Iddokumenteintrag).HasColumnName("IDDokumenteintrag");

                entity.Property(e => e.Idtyp).HasColumnName("IDTyp");

                entity.Property(e => e.Passwort)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Server)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddokumenteintragNavigation)
                    .WithMany(p => p.TblObjekt)
                    .HasForeignKey(d => d.Iddokumenteintrag)
                    .HasConstraintName("FK_tblObjekt_tblDokumenteintrag");
            });

            modelBuilder.Entity<TblOrdner>(entity =>
            {
                entity.ToTable("tblOrdner");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Icon).HasColumnType("image");

                entity.Property(e => e.Idfach).HasColumnName("IDFach");

                entity.Property(e => e.Idsystemordner)
                    .HasColumnName("IDSystemordner")
                    .HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<TblParameter>(entity =>
            {
                entity.HasKey(e => e.Bezeichnung);

                entity.ToTable("tblParameter");

                entity.Property(e => e.Bezeichnung)
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SqlParameter)
                    .IsRequired()
                    .HasColumnName("sqlParameter")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TextParameter).HasColumnName("textParameter");
            });

            modelBuilder.Entity<TblParticipants>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("tblParticipants", "qs2");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdobjectGuid).HasColumnName("IDObjectGuid");

                entity.Property(e => e.Participant)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdobjectGu)
                    .WithMany(p => p.TblParticipants)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.IdobjectGuid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblParticipants_tblObject");
            });

            modelBuilder.Entity<TblPfad>(entity =>
            {
                entity.HasKey(e => e.Archivpfad);

                entity.ToTable("tblPfad");

                entity.Property(e => e.Archivpfad)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblProvKonfig>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("tblProvKonfig");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblQueriesDef>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("tblQueriesDef", "qs2");

                entity.HasIndex(e => e.ControlType)
                    .HasName("IX_tblQueriesDef_2");

                entity.HasIndex(e => e.IdselList)
                    .HasName("IX_tblQueriesDef");

                entity.HasIndex(e => e.Sort)
                    .HasName("IX_tblQueriesDef_4");

                entity.HasIndex(e => e.Typ)
                    .HasName("IX_tblQueriesDef_3");

                entity.HasIndex(e => new { e.CriteriaApplication, e.ParticipantOwn })
                    .HasName("IX_tblQueriesDef_1");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplicationOwn)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Combination)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CombinationEnd)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComboAsDropDownCondition)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ControlType).HasMaxLength(50);

                entity.Property(e => e.CriteriaApplication).HasMaxLength(30);

                entity.Property(e => e.CriteriaFldShort).HasMaxLength(60);

                entity.Property(e => e.FreeSql)
                    .IsRequired()
                    .HasColumnName("freeSql")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdselList).HasColumnName("IDSelList");

                entity.Property(e => e.IsSqlserverField).HasColumnName("IsSQLServerField");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Max)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxIdres)
                    .IsRequired()
                    .HasColumnName("MaxIDRes")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParticipantOwn)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.QryColumn)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QryTable)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecialDefinition)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecialDefinitionMax)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValueMin)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValueMinIdres)
                    .IsRequired()
                    .HasColumnName("ValueMinIDRes")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdselListNavigation)
                    .WithMany(p => p.TblQueriesDef)
                    .HasForeignKey(d => d.IdselList)
                    .HasConstraintName("FK_tblQueriesDef_tblSelListEntries");

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.TblQueriesDef)
                    .HasForeignKey(d => new { d.CriteriaFldShort, d.CriteriaApplication })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblQueriesDef_tblCriteria");
            });

            modelBuilder.Entity<TblQueryJoinsTemp>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK_tbQueriesJoinTemp");

                entity.ToTable("tblQueryJoinsTemp", "qs2");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AlwaysDoJoin).HasColumnName("alwaysDoJoin");

                entity.Property(e => e.FromColumn)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromTable)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Order).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ToColumn)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToTable)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypJoin)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblRechteOrdner>(entity =>
            {
                entity.ToTable("tblRechteOrdner");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idgruppe).HasColumnName("IDGruppe");

                entity.Property(e => e.Idordner).HasColumnName("IDOrdner");

                entity.HasOne(d => d.IdordnerNavigation)
                    .WithMany(p => p.TblRechteOrdner)
                    .HasForeignKey(d => d.Idordner)
                    .HasConstraintName("FK_tblRechteOrdner_tblOrdner");
            });

            modelBuilder.Entity<TblRedist>(entity =>
            {
                entity.ToTable("tblRedist");

                entity.HasIndex(e => e.PortNr)
                    .HasName("PK_tblRedist_PortNr")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActivatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InstallDir)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastActivation)
                    .HasColumnName("lastActivation")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastCall).HasColumnType("datetime");

                entity.Property(e => e.LastInstall).HasColumnName("lastInstall");

                entity.Property(e => e.PortNr).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(600)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sort).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Wcfurl)
                    .IsRequired()
                    .HasColumnName("WCFUrl")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblRelationship>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK_tblRelationship_1");

                entity.ToTable("tblRelationship", "qs2");

                entity.HasIndex(e => e.Idkey)
                    .HasName("IX_tblRelationship_3");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_tblRelationship_2");

                entity.HasIndex(e => new { e.FldShortParent, e.IdapplicationParent })
                    .HasName("IX_tblRelationship");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Conditions)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConditionsSub)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FldShortChild).HasMaxLength(60);

                entity.Property(e => e.FldShortParent)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.IdapplicationChild)
                    .HasColumnName("IDApplicationChild")
                    .HasMaxLength(30);

                entity.Property(e => e.IdapplicationParent)
                    .IsRequired()
                    .HasColumnName("IDApplicationParent")
                    .HasMaxLength(30);

                entity.Property(e => e.Idkey)
                    .IsRequired()
                    .HasColumnName("IDKey")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sort).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeSub)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.TblCriteria)
                    .WithMany(p => p.TblRelationshipTblCriteria)
                    .HasForeignKey(d => new { d.FldShortChild, d.IdapplicationChild })
                    .HasConstraintName("FK_tblRelationship_tblCriteria1");

                entity.HasOne(d => d.TblCriteriaNavigation)
                    .WithMany(p => p.TblRelationshipTblCriteriaNavigation)
                    .HasForeignKey(d => new { d.FldShortParent, d.IdapplicationParent })
                    .HasConstraintName("FK_tblRelationship_tblCriteria");
            });

            modelBuilder.Entity<TblSchlagwörter>(entity =>
            {
                entity.ToTable("tblSchlagwörter");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idthema).HasColumnName("IDThema");

                entity.Property(e => e.Schlagwort)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdthemaNavigation)
                    .WithMany(p => p.TblSchlagwörter)
                    .HasForeignKey(d => d.Idthema)
                    .HasConstraintName("FK_tblSchlagwörter_tblThemen");
            });

            modelBuilder.Entity<TblSchrank>(entity =>
            {
                entity.ToTable("tblSchrank");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblSelListEntries>(entity =>
            {
                entity.ToTable("tblSelListEntries", "qs2");

                entity.HasIndex(e => e.Idgroup)
                    .HasName("IX_tblSelListEntries");

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_tblSelListEntries_5")
                    .IsUnique();

                entity.HasIndex(e => e.IdownInt)
                    .HasName("IX_tblSelListEntries_1");

                entity.HasIndex(e => e.Idressource)
                    .HasName("IX_SelListEntrys_1")
                    .IsUnique();

                entity.HasIndex(e => e.Private)
                    .HasName("IX_tblSelListEntries_3");

                entity.HasIndex(e => e.Sort)
                    .HasName("IX_tblSelListEntries_4");

                entity.HasIndex(e => new { e.Created, e.CreatedUser })
                    .HasName("IX_tblSelListEntries_2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FldShortColumn)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdownInt).HasColumnName("IDOwnInt");

                entity.Property(e => e.IdownStr)
                    .IsRequired()
                    .HasColumnName("IDOwnStr")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idparticipant)
                    .IsRequired()
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idressource)
                    .IsRequired()
                    .HasColumnName("IDRessource")
                    .HasMaxLength(150);

                entity.Property(e => e.LicenseKey)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Sql)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Table)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeQry)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeStr)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Uitype)
                    .IsRequired()
                    .HasColumnName("UIType")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VersionNrFrom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VersionNrTo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdgroupNavigation)
                    .WithMany(p => p.TblSelListEntries)
                    .HasForeignKey(d => d.Idgroup)
                    .HasConstraintName("FK_tblSelListEntrys_tblSelListGroup");
            });

            modelBuilder.Entity<TblSelListEntriesObj>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("tblSelListEntriesObj", "qs2");

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_tblSelListEntriesObj_3")
                    .IsUnique();

                entity.HasIndex(e => e.Idobject)
                    .HasName("IX_SelListEntrysObj");

                entity.HasIndex(e => e.IdselListEntry)
                    .HasName("IX_SelListEntrysObj_1");

                entity.HasIndex(e => e.IdselListEntrySublist)
                    .HasName("IX_tblSelListEntriesObj_2");

                entity.HasIndex(e => e.TypIdgroup)
                    .HasName("IX_tblSelListEntriesObj_1");

                entity.HasIndex(e => new { e.FldShort, e.Idapplication })
                    .HasName("IX_tblSelListEntriesObj");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FldShort).HasMaxLength(60);

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.IdapplicationStay)
                    .HasColumnName("IDApplicationStay")
                    .HasMaxLength(30);

                entity.Property(e => e.Idclassification)
                    .IsRequired()
                    .HasColumnName("IDClassification")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idobject).HasColumnName("IDObject");

                entity.Property(e => e.IdobjectGuid).HasColumnName("IDObjectGuid");

                entity.Property(e => e.IdownInt).HasColumnName("IDOwnInt");

                entity.Property(e => e.Idparticipant)
                    .IsRequired()
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdparticipantStay)
                    .HasColumnName("IDParticipantStay")
                    .HasMaxLength(150);

                entity.Property(e => e.IdselListEntry).HasColumnName("IDSelListEntry");

                entity.Property(e => e.IdselListEntrySublist).HasColumnName("IDSelListEntrySublist");

                entity.Property(e => e.Idstay).HasColumnName("IDStay");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NVisible)
                    .HasColumnName("nVisible")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.Property(e => e.Transfered).HasColumnType("datetime");

                entity.Property(e => e.TypIdgroup)
                    .IsRequired()
                    .HasColumnName("typIDGroup")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdobjectNavigation)
                    .WithMany(p => p.TblSelListEntriesObj)
                    .HasForeignKey(d => d.Idobject)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblSelListEntriesObj_tblObject");

                entity.HasOne(d => d.IdselListEntrySublistNavigation)
                    .WithMany(p => p.TblSelListEntriesObj)
                    .HasForeignKey(d => d.IdselListEntrySublist)
                    .HasConstraintName("FK_tblSelListEntriesObj_tblSelListEntries1");

                entity.HasOne(d => d.TblCriteria)
                    .WithMany(p => p.TblSelListEntriesObj)
                    .HasForeignKey(d => new { d.FldShort, d.Idapplication })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblSelListEntriesObj_tblCriteria");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TblSelListEntriesObj)
                    .HasForeignKey(d => new { d.Idstay, d.IdparticipantStay, d.IdapplicationStay })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblSelListEntriesObj_tblStay");
            });

            modelBuilder.Entity<TblSelListEntriesSort>(entity =>
            {
                entity.ToTable("tblSelListEntriesSort", "qs2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idparticipant)
                    .IsRequired()
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdselListEntry).HasColumnName("IDSelListEntry");

                entity.Property(e => e.Sort).HasDefaultValueSql("((-1))");

                entity.HasOne(d => d.IdselListEntryNavigation)
                    .WithMany(p => p.TblSelListEntriesSort)
                    .HasForeignKey(d => d.IdselListEntry)
                    .HasConstraintName("FK_tblSelListEntriesSort_tblSelListEntries");
            });

            modelBuilder.Entity<TblSelListGroup>(entity =>
            {
                entity.ToTable("tblSelListGroup", "qs2");

                entity.HasIndex(e => e.IdgroupStr)
                    .HasName("IX_tblSelListGroup_1");

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_tblSelListGroup_3")
                    .IsUnique();

                entity.HasIndex(e => e.Idressource)
                    .HasName("IX_SelListGroup");

                entity.HasIndex(e => e.Sublist)
                    .HasName("IX_tblSelListGroup_2");

                entity.HasIndex(e => e.Sys)
                    .HasName("IX_SelListGroup_1");

                entity.HasIndex(e => new { e.IdgroupStr, e.Idapplication, e.Idparticipant })
                    .HasName("IX_tblSelListGroup")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idapplication)
                    .IsRequired()
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.IdgroupStr)
                    .IsRequired()
                    .HasColumnName("IDGroupStr")
                    .HasMaxLength(50);

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idparticipant)
                    .IsRequired()
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('ALL')");

                entity.Property(e => e.Idressource)
                    .IsRequired()
                    .HasColumnName("IDRessource")
                    .HasMaxLength(160)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortColumn)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublist)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sys).HasColumnName("sys");

                entity.Property(e => e.TypeEnum)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VersionNrFrom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VersionNrTo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblSideLogic>(entity =>
            {
                entity.HasKey(e => e.Idguid);

                entity.ToTable("tblSideLogic", "qs2");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Chapter)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FldShort).HasMaxLength(60);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblStatistics>(entity =>
            {
                entity.ToTable("tblStatistics", "qs2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CusumavgObsMort).HasColumnName("CUSUMAvgObsMort");

                entity.Property(e => e.CusumcumDeads).HasColumnName("CUSUMCumDeads");

                entity.Property(e => e.CusumimprovementAlarm).HasColumnName("CUSUMImprovementAlarm");

                entity.Property(e => e.CusumimprovementAlert).HasColumnName("CUSUMImprovementAlert");

                entity.Property(e => e.CusumworseningAlarm).HasColumnName("CUSUMWorseningAlarm");

                entity.Property(e => e.CusumworseningAlert).HasColumnName("CUSUMWorseningAlert");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.SurgDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([datetime],'1900/01/01',(0)))");

                entity.Property(e => e.SurgId).HasColumnName("SurgID");

                entity.Property(e => e.SurgName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vlad).HasColumnName("VLAD");
            });

            modelBuilder.Entity<TblStay>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Idparticipant, e.Idapplication })
                    .HasName("PK_tblStay_1");

                entity.ToTable("tblStay", "qs2");

                entity.HasIndex(e => e.Idapplication)
                    .HasName("IX_tblStay_1");

                entity.HasIndex(e => e.Idguid)
                    .HasName("IX_tblStay")
                    .IsUnique();

                entity.HasIndex(e => e.IdstayParent)
                    .HasName("IX_tblStay_2");

                entity.HasIndex(e => e.MedRecN)
                    .HasName("IX_tblStay_4");

                entity.HasIndex(e => e.Optyp)
                    .HasName("IX_tblStay_5");

                entity.HasIndex(e => e.PatExtId)
                    .HasName("IX_tblStay_6");

                entity.HasIndex(e => e.PatIdguid)
                    .HasName("IX_tblStay_7");

                entity.HasIndex(e => e.StayComplete)
                    .HasName("IX_tblStay_9");

                entity.HasIndex(e => e.StayTyp)
                    .HasName("IX_tblStay_8");

                entity.HasIndex(e => new { e.SurgDtStart, e.SurgDtEnd })
                    .HasName("IX_tblStay_10");

                entity.HasIndex(e => new { e.Idapplication, e.Idparticipant, e.MedRecN, e.Incidence })
                    .HasName("IX_tblStay_3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idparticipant)
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(150);

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.AdmitDt).HasColumnType("datetime");

                entity.Property(e => e.Anaesthesist).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AnaesthesistAssist1)
                    .HasColumnName("Anaesthesist_Assist1")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Bmigroup)
                    .HasColumnName("BMIGroup")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Bpkz)
                    .IsRequired()
                    .HasColumnName("BPKZ")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bpkzdone)
                    .HasColumnName("BPKZDone")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Bpkzok).HasColumnName("BPKZOK");

                entity.Property(e => e.Bpkzstatus)
                    .IsRequired()
                    .HasColumnName("BPKZStatus")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CongenitalData)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Consultant).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.DataVrsn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisLocatn).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DischDt).HasColumnType("datetime");

                entity.Property(e => e.Fupdt)
                    .HasColumnName("FUPDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FupdtPlan)
                    .HasColumnName("FUPDtPlan")
                    .HasColumnType("datetime");

                entity.Property(e => e.HasComplications).HasDefaultValueSql("((-1))");

                entity.Property(e => e.IdapplicationParent)
                    .HasColumnName("IDApplicationParent")
                    .HasMaxLength(30);

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdparticipantParent)
                    .HasColumnName("IDParticipantParent")
                    .HasMaxLength(150);

                entity.Property(e => e.IdstayParent).HasColumnName("IDStayParent");

                entity.Property(e => e.Idvendor)
                    .IsRequired()
                    .HasColumnName("IDVendor")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'S2')");

                entity.Property(e => e.Incidence).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAquired)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.MedRecN)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mt30Stat).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MtDcstat)
                    .HasColumnName("MtDCStat")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.MtOpD).HasDefaultValueSql("((-1))");

                entity.Property(e => e.OpenSince).HasColumnType("datetime");

                entity.Property(e => e.Optyp).HasColumnName("OPTyp");

                entity.Property(e => e.OrgUnitStay)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatBmi)
                    .HasColumnName("PatBMI")
                    .HasColumnType("numeric(8, 5)");

                entity.Property(e => e.PatCity)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatCountry)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatCountryId)
                    .HasColumnName("PatCountryID")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.PatExtId)
                    .IsRequired()
                    .HasColumnName("PatExtID")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatHeight).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.PatIdguid).HasColumnName("PatIDGuid");

                entity.Property(e => e.PatOrigin).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PatStreet)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatTel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatWeight).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.PatZip)
                    .IsRequired()
                    .HasColumnName("PatZIP")
                    .HasMaxLength(70)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Perfusionist).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PerfusionistAssist1)
                    .HasColumnName("Perfusionist_Assist1")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Resident).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ScrubNurse).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.Property(e => e.SoftVrsn)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SoftVrsnTo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SurgAssist1)
                    .HasColumnName("Surg_Assist1")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.SurgAssist2)
                    .HasColumnName("Surg_Assist2")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.SurgAssumption)
                    .HasColumnName("Surg_Assumption")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.SurgDtEnd).HasColumnType("datetime");

                entity.Property(e => e.SurgDtStart).HasColumnType("datetime");

                entity.Property(e => e.SurgPartim)
                    .HasColumnName("Surg_Partim")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.SurgReOp)
                    .HasColumnName("Surg_ReOp")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Surgeon).HasDefaultValueSql("((-1))");

                entity.HasOne(d => d.PatIdgu)
                    .WithMany(p => p.TblStay)
                    .HasPrincipalKey(p => p.Idguid)
                    .HasForeignKey(d => d.PatIdguid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStay_tblObject");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.InverseIdNavigation)
                    .HasForeignKey(d => new { d.IdstayParent, d.IdparticipantParent, d.IdapplicationParent })
                    .HasConstraintName("FK_tblStay_tblStay");
            });

            modelBuilder.Entity<TblStayAdditions>(entity =>
            {
                entity.HasKey(e => e.Idguid)
                    .HasName("PK_tblStayAdditions_1");

                entity.ToTable("tblStayAdditions", "qs2");

                entity.HasIndex(e => e.IdstayParent)
                    .HasName("IX_tblStayAdditions_6");

                entity.HasIndex(e => e.Typ)
                    .HasName("IX_tblStayAdditions_2");

                entity.Property(e => e.Idguid)
                    .HasColumnName("IDGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idapplication)
                    .IsRequired()
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdapplicationStayChild)
                    .HasColumnName("IDApplicationStayChild")
                    .HasMaxLength(30);

                entity.Property(e => e.IdapplicationStayParent)
                    .IsRequired()
                    .HasColumnName("IDApplicationStayParent")
                    .HasMaxLength(30);

                entity.Property(e => e.Idobject).HasColumnName("IDObject");

                entity.Property(e => e.IdparticipantStayChild)
                    .HasColumnName("IDParticipantStayChild")
                    .HasMaxLength(150);

                entity.Property(e => e.IdparticipantStayParent)
                    .IsRequired()
                    .HasColumnName("IDParticipantStayParent")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('ALL')");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.IdselList).HasColumnName("IDSelList");

                entity.Property(e => e.IdselListFirst).HasColumnName("IDSelListFirst");

                entity.Property(e => e.IdstayChild).HasColumnName("IDStayChild");

                entity.Property(e => e.IdstayParent).HasColumnName("IDStayParent");

                entity.Property(e => e.Sort).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasColumnName("typ")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdselListNavigation)
                    .WithMany(p => p.TblStayAdditionsIdselListNavigation)
                    .HasForeignKey(d => d.IdselList)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblStayAdditions_tblSelListEntries");

                entity.HasOne(d => d.IdselListFirstNavigation)
                    .WithMany(p => p.TblStayAdditionsIdselListFirstNavigation)
                    .HasForeignKey(d => d.IdselListFirst)
                    .HasConstraintName("FK_tblStayAdditions_tblSelListEntries1");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TblStayAdditions)
                    .HasForeignKey(d => new { d.IdstayParent, d.IdparticipantStayParent, d.IdapplicationStayParent })
                    .HasConstraintName("FK_tblStayAdditions_tblStay");
            });

            modelBuilder.Entity<TblSturzprotokoll>(entity =>
            {
                entity.ToTable("tblSturzprotokoll");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AnalyseEingeschränkteMobilität)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalyseErnährung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalyseInkontinenz)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalyseKrankheitsbilder)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalyseMaßnahmen)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalyseMedikamente)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalyseSchwindel)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Anmerkungen)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DatumUnterschriftPflegedienstleitung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DatumUnterschriftPflegekraft)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesundheitBlutzucker).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.GesundheitErgebnis)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesundheitErstversorgung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesundheitErstversorgungJn).HasColumnName("GesundheitErstversorgungJN");

                entity.Property(e => e.GesundheitMental)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesundheitPuls).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.GesundheitSchäden)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesundheitSchädenJn).HasColumnName("GesundheitSchädenJN");

                entity.Property(e => e.GesundheitTransferKrankenhaus)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GesundheitTransferKrankenhausJn).HasColumnName("GesundheitTransferKrankenhausJN");

                entity.Property(e => e.HergangKonnteBewohnerSchildern)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HergangSchilderungBewohner)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HergangSchilderungBewohnerJn).HasColumnName("HergangSchilderungBewohnerJN");

                entity.Property(e => e.HergangWoZuletztGesehen)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idstandardprozedur).HasColumnName("IDStandardprozedur");

                entity.Property(e => e.InformationArzt)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InformationArztJn).HasColumnName("InformationArztJN");

                entity.Property(e => e.InformationArztPflegepersonHatInformiert)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InformationKontaktperson)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InformationKontaktpersonJn).HasColumnName("InformationKontaktpersonJN");

                entity.Property(e => e.InformationPdlvonWemInformiert)
                    .IsRequired()
                    .HasColumnName("InformationPDLVonWemInformiert")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InformationPdlzeitpunkt)
                    .HasColumnName("InformationPDLZeitpunkt")
                    .HasColumnType("datetime");

                entity.Property(e => e.InformationPflegepersonKontakt)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NamePatient)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PatGebDat).HasColumnType("datetime");

                entity.Property(e => e.SituationGehilfen)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SituationKleidung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SituationSchuhe)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SituationWie)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SturzDatum).HasColumnType("datetime");

                entity.Property(e => e.SturzErstellt)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SturzOrt)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SturzStellung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeBewohnervsrschulden)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeBewohnervsrschuldenJn).HasColumnName("UmständeBewohnervsrschuldenJN");

                entity.Property(e => e.UmständeFixierung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeFixierungJn).HasColumnName("UmständeFixierungJN");

                entity.Property(e => e.UmständeFremdverschulden)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeFremdverschuldenJn).HasColumnName("UmständeFremdverschuldenJN");

                entity.Property(e => e.UmständeHilfebedarf)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeKlingelJn).HasColumnName("UmständeKlingelJN");

                entity.Property(e => e.UmständeKlinikVerschulden)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeKlinikVerschuldenJn).HasColumnName("UmständeKlinikVerschuldenJN");

                entity.Property(e => e.UmständePflegekräfteAnwesend)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeSachgerechteNutzung)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeVorereignis)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UmständeVorereignisJn).HasColumnName("UmständeVorereignisJN");

                entity.Property(e => e.Wohnbereich)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zimmer)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdstandardprozedurNavigation)
                    .WithMany(p => p.TblSturzprotokoll)
                    .HasForeignKey(d => d.Idstandardprozedur)
                    .HasConstraintName("FK_tblSturzprotokoll_SP");
            });

            modelBuilder.Entity<TblSuchtgiftschrankSchlüssel>(entity =>
            {
                entity.ToTable("tblSuchtgiftschrankSchlüssel");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Am).HasColumnType("datetime");

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idabteilung).HasColumnName("IDAbteilung");

                entity.Property(e => e.UserÜbergeber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserÜbergeberPool)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserÜbernehmer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserÜbernehmerPool)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblTextTemplates>(entity =>
            {
                entity.ToTable("tblTextTemplates");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.An)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bcc)
                    .IsRequired()
                    .HasColumnName("BCC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Betreff)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cc)
                    .IsRequired()
                    .HasColumnName("CC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromPostfach)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstCategories)
                    .IsRequired()
                    .HasColumnName("lstCategories")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstIdbenutzer)
                    .IsRequired()
                    .HasColumnName("lstIDBenutzer")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LstIdpatienten)
                    .IsRequired()
                    .HasColumnName("lstIDPatienten")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Txt)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblTextTemplatesFiles>(entity =>
            {
                entity.ToTable("tblTextTemplatesFiles");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdtextTemplate).HasColumnName("IDTextTemplate");

                entity.HasOne(d => d.IdtextTemplateNavigation)
                    .WithMany(p => p.TblTextTemplatesFiles)
                    .HasForeignKey(d => d.IdtextTemplate)
                    .HasConstraintName("FK_tblTextTemplatesFiles_tblTextTemplatesFiles");
            });

            modelBuilder.Entity<TblThemen>(entity =>
            {
                entity.ToTable("tblThemen");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ErstelltAm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Thema)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblUidefinitions>(entity =>
            {
                entity.ToTable("tblUIDefinitions");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DbColumn)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DbTable)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElementHeigth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ElementType)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElementWidth).HasDefaultValueSql("((-1))");

                entity.Property(e => e.LabelTxt)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Uitype)
                    .IsRequired()
                    .HasColumnName("UIType")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblUserAccounts>(entity =>
            {
                entity.ToTable("tblUserAccounts");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdrFrom)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdrTo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idaccount).HasColumnName("IDAccount");

                entity.Property(e => e.LastReceive)
                    .HasColumnName("lastReceive")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutlookWebApi).HasColumnName("OutlookWebAPI");

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PwdAuthentication)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Server)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ssl).HasColumnName("SSL");

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasColumnName("typ")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Usr)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsrAuthentication)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblVeranstalter>(entity =>
            {
                entity.ToTable("tblVeranstalter");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idadresse).HasColumnName("IDAdresse");

                entity.Property(e => e.Idkontakt).HasColumnName("IDKontakt");

                entity.HasOne(d => d.IdadresseNavigation)
                    .WithMany(p => p.TblVeranstalter)
                    .HasForeignKey(d => d.Idadresse)
                    .HasConstraintName("FK_tblVeranstalter_Adresse");

                entity.HasOne(d => d.IdkontaktNavigation)
                    .WithMany(p => p.TblVeranstalter)
                    .HasForeignKey(d => d.Idkontakt)
                    .HasConstraintName("FK_tblVeranstalter_Kontakt");
            });

            modelBuilder.Entity<TblVersions>(entity =>
            {
                entity.HasKey(e => e.VersionNr);

                entity.ToTable("tblVersions", "qs2");

                entity.Property(e => e.VersionNr)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Classification).IsRequired();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedFrom)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.Idapplication)
                    .HasColumnName("IDApplication")
                    .HasMaxLength(30);

                entity.Property(e => e.Idparticipant)
                    .HasColumnName("IDParticipant")
                    .HasMaxLength(150);

                entity.Property(e => e.To).HasColumnType("datetime");
            });

            modelBuilder.Entity<Textbausteine>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Berufsgruppen)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.ErstelltVon)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Kurzbezeichnung)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TextRtf)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Unterbringung>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AerztlDokumentArzt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AerztlDokumentArztTitel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AerztlDokumentArztVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AerztlDokumentDatum).HasColumnType("datetime");

                entity.Property(e => e.Aktion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AngeordnetAm).HasColumnType("datetime");

                entity.Property(e => e.AngeordnetVon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AngeordnetVonTitel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AngeordnetVonVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Anmerkung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AnmerkungGutachten2016)
                    .HasColumnName("AnmerkungGutachten_2016")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnmerkungVerhalten2016)
                    .HasColumnName("AnmerkungVerhalten_2016")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AufgehobenAm).HasColumnType("datetime");

                entity.Property(e => e.AufgehobenVon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AufgehobenVonTitel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AufgehobenVonVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaulicheMassnahmen).HasMaxLength(1024);

                entity.Property(e => e.Beginn).HasColumnType("datetime");

                entity.Property(e => e.CodierungJn).HasColumnName("CodierungJN");

                entity.Property(e => e.Dauermedikation2016)
                    .HasColumnName("Dauermedikation_2016")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DauermedikationJn2016)
                    .HasColumnName("DauermedikationJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DrehknopfJn).HasColumnName("DrehknopfJN");

                entity.Property(e => e.EdiBenutzer).HasColumnName("EDI_Benutzer");

                entity.Property(e => e.EdiDatum)
                    .HasColumnName("EDI_Datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.EdiProtokoll)
                    .IsRequired()
                    .HasColumnName("EDI_Protokoll")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EingriffUnerlaesslichBeschreibung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EingriffUnerlaesslichJn).HasColumnName("EingriffUnerlaesslichJN");

                entity.Property(e => e.Einrichtungsleiter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EinrichtungsleiterTitel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EinrichtungsleiterVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Einzelfallmedikation2016)
                    .HasColumnName("Einzelfallmedikation_2016")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EinzelfallmedikationJn2016)
                    .HasColumnName("EinzelfallmedikationJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ElektronischesUeberwachungJn).HasColumnName("ElektronischesUeberwachungJN");

                entity.Property(e => e.EndeangeordnetVon)
                    .HasColumnName("ENDEAngeordnetVon")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Endeberufsgruppe).HasColumnName("ENDEBerufsgruppe");

                entity.Property(e => e.EndegesendetAnBewohnervertreterJn).HasColumnName("ENDEGesendetAnBewohnervertreterJN");

                entity.Property(e => e.EndegesendetAnGesetzVertreterJn).HasColumnName("ENDEGesendetAnGesetzVertreterJN");

                entity.Property(e => e.EndegesendetAnSelbstGewVertreterJn).HasColumnName("ENDEGesendetAnSelbstGewVertreterJN");

                entity.Property(e => e.EndegesendetAnVertrauenspersonJn).HasColumnName("ENDEGesendetAnVertrauenspersonJN");

                entity.Property(e => e.ErheblicheFremdgefaehrdungJn).HasColumnName("ErheblicheFremdgefaehrdungJN");

                entity.Property(e => e.ErheblicheSelbstgefaehrdungJn).HasColumnName("ErheblicheSelbstgefaehrdungJN");

                entity.Property(e => e.GefahrFuerLebenGesundheitJn).HasColumnName("GefahrFuerLebenGesundheitJN");

                entity.Property(e => e.GeistigeBehinderungJn).HasColumnName("GeistigeBehinderungJN");

                entity.Property(e => e.GesendetAnBewohnervertreterJn).HasColumnName("GesendetAnBewohnervertreterJN");

                entity.Property(e => e.GesendetAnGesetzVertreterJn).HasColumnName("GesendetAnGesetzVertreterJN");

                entity.Property(e => e.GesendetAnSelbstGewVertreterJn).HasColumnName("GesendetAnSelbstGewVertreterJN");

                entity.Property(e => e.GesendetAnVertrauenspersonJn).HasColumnName("GesendetAnVertrauenspersonJN");

                entity.Property(e => e.Grund)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.HindernBereichAndereJn2016)
                    .HasColumnName("HindernBereichAndereJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernBereichBarriereJn2016)
                    .HasColumnName("HindernBereichBarriereJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernBereichFesthaltenJn2016)
                    .HasColumnName("HindernBereichFesthaltenJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernBereichHinderAmFortbewegenJn2016)
                    .HasColumnName("HindernBereichHinderAmFortbewegenJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernBereichVersperrterBereichJn2016)
                    .HasColumnName("HindernBereichVersperrterBereichJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernBereichVersperrtesZimmerJn2016)
                    .HasColumnName("HindernBereichVersperrtesZimmerJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernBettVerlassen).HasMaxLength(1024);

                entity.Property(e => e.HindernRollstuhTherapietischJn).HasColumnName("HindernRollstuhTherapietischJN");

                entity.Property(e => e.HindernRollstuhTischJn).HasColumnName("HindernRollstuhTischJN");

                entity.Property(e => e.HindernRollstuhl)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.HindernRollstuhlBremsenJn).HasColumnName("HindernRollstuhlBremsenJN");

                entity.Property(e => e.HindernRollstuhlGurtenJn).HasColumnName("HindernRollstuhlGurtenJN");

                entity.Property(e => e.HindernRollstuhlSitzhoseJn).HasColumnName("HindernRollstuhlSitzhoseJN");

                entity.Property(e => e.HindernSitzgelAndereJn2016)
                    .HasColumnName("HindernSitzgelAndereJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernSitzgelBauchgurtJn2016)
                    .HasColumnName("HindernSitzgelBauchgurtJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernSitzgelBrustgurtJn2016)
                    .HasColumnName("HindernSitzgelBrustgurtJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernSitzgelFussBeingurte2016)
                    .HasColumnName("HindernSitzgelFussBeingurte_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernSitzgelGurtenJn).HasColumnName("HindernSitzgelGurtenJN");

                entity.Property(e => e.HindernSitzgelHandArmgurte2016)
                    .HasColumnName("HindernSitzgelHandArmgurte_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernSitzgelSitzhoseJn)
                    .IsRequired()
                    .HasColumnName("HindernSitzgelSitzhoseJN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HindernSitzgelTherapietischJn).HasColumnName("HindernSitzgelTherapietischJN");

                entity.Property(e => e.HindernSitzgelTischJn).HasColumnName("HindernSitzgelTischJN");

                entity.Property(e => e.HindernSitzgelegenheit).HasMaxLength(1024);

                entity.Property(e => e.HindernVerlassenBettAndereJn2016)
                    .HasColumnName("HindernVerlassenBettAndereJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernVerlassenBettBauchgurtJn2016)
                    .HasColumnName("HindernVerlassenBettBauchgurtJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernVerlassenBettElektronischJn2016)
                    .HasColumnName("HindernVerlassenBettElektronischJN_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernVerlassenBettFussBeingurte2016)
                    .HasColumnName("HindernVerlassenBettFussBeingurte_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernVerlassenBettGurtenJn).HasColumnName("HindernVerlassenBettGurtenJN");

                entity.Property(e => e.HindernVerlassenBettHandArmgurte2016)
                    .HasColumnName("HindernVerlassenBettHandArmgurte_2016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HindernVerlassenBettHandmanschettenJn).HasColumnName("HindernVerlassenBettHandmanschettenJN");

                entity.Property(e => e.HindernVerlassenBettSeitenteilenJn).HasColumnName("HindernVerlassenBettSeitenteilenJN");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.KlientZustimmungJn).HasColumnName("KlientZustimmungJN");

                entity.Property(e => e.LabyrinthJn).HasColumnName("LabyrinthJN");

                entity.Property(e => e.MedDiagnIcd)
                    .HasColumnName("MedDiagnICD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MedikBezeichnung)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.MedikFreihBeschraenkungJn).HasColumnName("MedikFreihBeschraenkungJN");

                entity.Property(e => e.MedizinischeDiagnose).HasMaxLength(1024);

                entity.Property(e => e.PsychischekrankheitJn).HasColumnName("PsychischekrankheitJN");

                entity.Property(e => e.TatsaechlicheEnde).HasColumnType("datetime");

                entity.Property(e => e.VerschlosseneTuerJn).HasColumnName("VerschlosseneTuerJN");

                entity.Property(e => e.VoraussichtlichesEnde).HasColumnType("datetime");

                entity.Property(e => e.Zeitraum)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZurueckhaltensandrohungJn).HasColumnName("ZurueckhaltensandrohungJN");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.Unterbringung)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .HasConstraintName("FK_Unterbringung_Aufenthalt");
            });

            modelBuilder.Entity<UrlaubVerlauf>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piUrlaubVerlauf")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.EndeDatum).HasColumnType("datetime");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZeitpunktBlisterlisteBeginn).HasColumnType("datetime");

                entity.Property(e => e.ZeitpunktBlisterlisteEnde).HasColumnType("datetime");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.UrlaubVerlauf)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UrlaubVerlauf_Aufenthalt");
            });

            modelBuilder.Entity<Vo>(entity =>
            {
                entity.ToTable("VO");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BestaetigtVon)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DatumErstellt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumVerordnetAb)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumVerordnetBis).HasColumnType("date");

                entity.Property(e => e.Einheit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hinweis)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HinweisLieferant)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idaufenthalt).HasColumnName("IDAufenthalt");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzerGeaendert");

                entity.Property(e => e.Idmedikament).HasColumnName("IDMedikament");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdaufenthaltNavigation)
                    .WithMany(p => p.Vo)
                    .HasForeignKey(d => d.Idaufenthalt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_Aufenthalt");

                entity.HasOne(d => d.IdmedikamentNavigation)
                    .WithMany(p => p.Vo)
                    .HasForeignKey(d => d.Idmedikament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_Medikament");
            });

            modelBuilder.Entity<VoBestelldaten>(entity =>
            {
                entity.ToTable("VO_Bestelldaten");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DatumErstellt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumNaechsterAnspruch).HasColumnType("date");

                entity.Property(e => e.Dauer).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Einheit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GueltigAb).HasColumnType("date");

                entity.Property(e => e.GueltigBis).HasColumnType("date");

                entity.Property(e => e.HinweisLieferant)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.Idbenutzergeaendert).HasColumnName("IDBenutzergeaendert");

                entity.Property(e => e.Idmedikament).HasColumnName("IDMedikament");

                entity.Property(e => e.Idverordnung).HasColumnName("IDVerordnung");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NTenMonat).HasColumnName("nTenMonat");

                entity.Property(e => e.SerienterminEndetAm).HasColumnType("datetime");

                entity.Property(e => e.SerienterminType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TagWochenMonat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wochentage)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.VoBestelldaten)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_Bestelldaten_Benutzer");

                entity.HasOne(d => d.IdmedikamentNavigation)
                    .WithMany(p => p.VoBestelldaten)
                    .HasForeignKey(d => d.Idmedikament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_Bestelldaten_Medikament");

                entity.HasOne(d => d.IdverordnungNavigation)
                    .WithMany(p => p.VoBestelldaten)
                    .HasForeignKey(d => d.Idverordnung)
                    .HasConstraintName("FK_VO_Bestelldaten_VO");
            });

            modelBuilder.Entity<VoBestellpostitionen>(entity =>
            {
                entity.ToTable("VO_Bestellpostitionen");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anmerkung)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BemerkungLieferung)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DatumBestellung)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumBestellungPlan).HasColumnType("date");

                entity.Property(e => e.DatumErstellt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumLieferung).HasColumnType("date");

                entity.Property(e => e.EinheitBestellung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EinheitLieferung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HinweisLieferant)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzerGeaendert");

                entity.Property(e => e.IdbestelldatenVo).HasColumnName("IDBestelldaten_VO");

                entity.Property(e => e.Idmedikament).HasColumnName("IDMedikament");

                entity.Property(e => e.IdmedikamentGeliefert).HasColumnName("IDMedikamentGeliefert");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbestelldatenVoNavigation)
                    .WithMany(p => p.VoBestellpostitionen)
                    .HasForeignKey(d => d.IdbestelldatenVo)
                    .HasConstraintName("FK_VO_Bestellpostitionen_VO_Bestelldaten");

                entity.HasOne(d => d.IdmedikamentNavigation)
                    .WithMany(p => p.VoBestellpostitionen)
                    .HasForeignKey(d => d.Idmedikament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_Bestellpostitionen_Medikament");
            });

            modelBuilder.Entity<VoLager>(entity =>
            {
                entity.ToTable("VO_Lager");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumErstellt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzerGeaendert");

                entity.Property(e => e.Idvo).HasColumnName("IDVO");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Seriennummer)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zustand)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdvoNavigation)
                    .WithMany(p => p.VoLager)
                    .HasForeignKey(d => d.Idvo)
                    .HasConstraintName("FK_VOLager_VO");
            });

            modelBuilder.Entity<VoMedizinischeDaten>(entity =>
            {
                entity.ToTable("VO_MedizinischeDaten");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumErstellt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzerGeaendert");

                entity.Property(e => e.IdmedizinischeDaten).HasColumnName("IDMedizinischeDaten");

                entity.Property(e => e.Idverordnung).HasColumnName("IDVerordnung");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.VoMedizinischeDatenIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_MedizinischeDaten_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.VoMedizinischeDatenIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_MedizinischeDaten_Benutzer1");

                entity.HasOne(d => d.IdmedizinischeDatenNavigation)
                    .WithMany(p => p.VoMedizinischeDaten)
                    .HasForeignKey(d => d.IdmedizinischeDaten)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_MedizinischeDaten_MedizinischeDaten");

                entity.HasOne(d => d.IdverordnungNavigation)
                    .WithMany(p => p.VoMedizinischeDaten)
                    .HasForeignKey(d => d.Idverordnung)
                    .HasConstraintName("FK_VO_MedizinischeDaten_VO");
            });

            modelBuilder.Entity<VoPflegeplanPdx>(entity =>
            {
                entity.ToTable("VO_PflegeplanPDX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumEsrstellt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzerGeaendert");

                entity.Property(e => e.IduntertaegigeGruppe).HasColumnName("IDUntertaegigeGruppe");

                entity.Property(e => e.Idverordnung).HasColumnName("IDVerordnung");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.VoPflegeplanPdxIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_VO_PflegeplanPDX_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.VoPflegeplanPdxIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_PflegeplanPDX_Benutzer1");

                entity.HasOne(d => d.IdverordnungNavigation)
                    .WithMany(p => p.VoPflegeplanPdx)
                    .HasForeignKey(d => d.Idverordnung)
                    .HasConstraintName("FK_VO_PflegeplanPDX_VO");
            });

            modelBuilder.Entity<VoWunde>(entity =>
            {
                entity.ToTable("VO_Wunde");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumErstellt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumGeaendert)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzerErstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzerGeaendert");

                entity.Property(e => e.Idverordnung).HasColumnName("IDVerordnung");

                entity.Property(e => e.IdwundeKopf).HasColumnName("IDWundeKopf");

                entity.Property(e => e.LoginNameFreiErstellt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoginNameFreiGeaendert)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbenutzerErstelltNavigation)
                    .WithMany(p => p.VoWundeIdbenutzerErstelltNavigation)
                    .HasForeignKey(d => d.IdbenutzerErstellt)
                    .HasConstraintName("FK_VO_WundeKopf_Benutzer");

                entity.HasOne(d => d.IdbenutzerGeaendertNavigation)
                    .WithMany(p => p.VoWundeIdbenutzerGeaendertNavigation)
                    .HasForeignKey(d => d.IdbenutzerGeaendert)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VO_WundeKopf_Benutzer1");

                entity.HasOne(d => d.IdverordnungNavigation)
                    .WithMany(p => p.VoWunde)
                    .HasForeignKey(d => d.Idverordnung)
                    .HasConstraintName("FK_VO_WundeKopf_VO");
            });

            modelBuilder.Entity<WundeKopf>(entity =>
            {
                entity.HasIndex(e => e.IdaufenthaltPdx)
                    .HasName("IX_WundeKopf")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BekanntSeit).HasColumnType("datetime");

                entity.Property(e => e.BisherigeBehandlung)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClickedImage).HasColumnType("image");

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.Dekuskala)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdaufenthaltPdx).HasColumnName("IDAufenthaltPDx");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.Wundart)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WundeEntstanden)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<WundePos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.Erhebungszeitpunkt).HasColumnType("datetime");

                entity.Property(e => e.Erreger)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FistelnTaschen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('nein')");

                entity.Property(e => e.Heilungstext)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.IdwundeKopf).HasColumnName("IDWundeKopf");

                entity.Property(e => e.Infektionszeichen)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NekroseJn).HasColumnName("NekroseJN");

                entity.Property(e => e.Schmerzqualitaet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sekretionsmenge)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Wundbelag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Kein Belag')");

                entity.Property(e => e.WundeFreiliegendeStrukturen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('keine')");

                entity.Property(e => e.Wundgeruch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wundgrund)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wundheilungsphase)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WundrandOedemoesWulstig)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('nein')");

                entity.Property(e => e.WundrandUnterminiertZerklueftet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('nein')");

                entity.Property(e => e.Wundsekretion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('keine')");

                entity.Property(e => e.Wundumgebung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WundumgebungEkzemOedemRoetung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('nein')");

                entity.Property(e => e.WundumgebungTrockenPergamentartig)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('trocken')");

                entity.Property(e => e.Wundzustand)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdwundeKopfNavigation)
                    .WithMany(p => p.WundePos)
                    .HasForeignKey(d => d.IdwundeKopf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WundePos_WundeKopf");
            });

            modelBuilder.Entity<WundePosBilder>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.DruckenJn).HasColumnName("druckenJN");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.IdwundePos).HasColumnName("IDWundePos");

                entity.Property(e => e.Thumbnail)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.ZeitpunktBild).HasColumnType("datetime");

                entity.HasOne(d => d.IdwundePosNavigation)
                    .WithMany(p => p.WundePosBilder)
                    .HasForeignKey(d => d.IdwundePos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WundePosBilder_WundePos");
            });

            modelBuilder.Entity<WundeTherapie>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgesetztAm).HasColumnType("datetime");

                entity.Property(e => e.AbgesetztVon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AngeordnetVon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellt).HasColumnType("datetime");

                entity.Property(e => e.DatumGeaendert).HasColumnType("datetime");

                entity.Property(e => e.Debridement)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fixierung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Freillagerung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hautpflege)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hyperkeratoseentfernung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdbenutzerErstellt).HasColumnName("IDBenutzer_Erstellt");

                entity.Property(e => e.IdbenutzerGeaendert).HasColumnName("IDBenutzer_Geaendert");

                entity.Property(e => e.IdwundeKopf).HasColumnName("IDWundeKopf");

                entity.Property(e => e.Kompression)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Reinigung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sekundaerverband)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Therapie)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.VerordnetAm).HasColumnType("datetime");

                entity.Property(e => e.VidiertAm).HasColumnType("datetime");

                entity.Property(e => e.VidiertJn).HasColumnName("VidiertJN");

                entity.Property(e => e.VidiertVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VorgeschlagenVon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vwintervall)
                    .IsRequired()
                    .HasColumnName("VWIntervall")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wundabstrich)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wundauflage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wundrandschutz)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zusatzernährung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdwundeKopfNavigation)
                    .WithMany(p => p.WundeTherapie)
                    .HasForeignKey(d => d.IdwundeKopf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WundTherapie_WundeKopf");
            });

            modelBuilder.Entity<Zeitbereich>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bis)
                    .HasColumnName("bis")
                    .HasColumnType("datetime");

                entity.Property(e => e.Von)
                    .HasColumnName("von")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ZeitbereichSerien>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idzeitbereich0).HasColumnName("IDZeitbereich0");

                entity.Property(e => e.Idzeitbereich1).HasColumnName("IDZeitbereich1");

                entity.Property(e => e.Idzeitbereich2).HasColumnName("IDZeitbereich2");

                entity.Property(e => e.Idzeitbereich3).HasColumnName("IDZeitbereich3");

                entity.Property(e => e.Idzeitbereich4).HasColumnName("IDZeitbereich4");

                entity.Property(e => e.Idzeitbereich5).HasColumnName("IDZeitbereich5");

                entity.Property(e => e.Idzeitbereich6).HasColumnName("IDZeitbereich6");

                entity.Property(e => e.Idzeitbereich7).HasColumnName("IDZeitbereich7");

                entity.HasOne(d => d.Idzeitbereich0Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich0Navigation)
                    .HasForeignKey(d => d.Idzeitbereich0)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich");

                entity.HasOne(d => d.Idzeitbereich1Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich1Navigation)
                    .HasForeignKey(d => d.Idzeitbereich1)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich1");

                entity.HasOne(d => d.Idzeitbereich2Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich2Navigation)
                    .HasForeignKey(d => d.Idzeitbereich2)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich2");

                entity.HasOne(d => d.Idzeitbereich3Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich3Navigation)
                    .HasForeignKey(d => d.Idzeitbereich3)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich3");

                entity.HasOne(d => d.Idzeitbereich4Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich4Navigation)
                    .HasForeignKey(d => d.Idzeitbereich4)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich4");

                entity.HasOne(d => d.Idzeitbereich5Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich5Navigation)
                    .HasForeignKey(d => d.Idzeitbereich5)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich5");

                entity.HasOne(d => d.Idzeitbereich6Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich6Navigation)
                    .HasForeignKey(d => d.Idzeitbereich6)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich6");

                entity.HasOne(d => d.Idzeitbereich7Navigation)
                    .WithMany(p => p.ZeitbereichSerienIdzeitbereich7Navigation)
                    .HasForeignKey(d => d.Idzeitbereich7)
                    .HasConstraintName("FK_ZeitbereichSerien_Zeitbereich7");
            });

            modelBuilder.Entity<ZusatzEintrag>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piZusatzEintrag")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ElgaCode)
                    .IsRequired()
                    .HasColumnName("ELGA_Code")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaCodeSystem)
                    .IsRequired()
                    .HasColumnName("ELGA_CodeSystem")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaDisplayName)
                    .IsRequired()
                    .HasColumnName("ELGA_DisplayName")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElgaId).HasColumnName("ELGA_ID");

                entity.Property(e => e.ElgaUnit)
                    .IsRequired()
                    .HasColumnName("ELGA_Unit")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FeldNr).ValueGeneratedOnAdd();

                entity.Property(e => e.ListenEintraege).HasColumnType("text");
            });

            modelBuilder.Entity<ZusatzGruppe>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piZusatzGruppe")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ZusatzGruppeEintrag>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piZusatzGruppeEintrag")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdzusatzGruppe, e.IdzusatzEintrag, e.Idobjekt, e.Idfilter })
                    .HasName("uiZusatzGruppeEintrag")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DruckenJn).HasColumnName("DruckenJN");

                entity.Property(e => e.Idfilter).HasColumnName("IDFilter");

                entity.Property(e => e.Idobjekt).HasColumnName("IDObjekt");

                entity.Property(e => e.IdzusatzEintrag)
                    .HasColumnName("IDZusatzEintrag")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdzusatzGruppe)
                    .HasColumnName("IDZusatzGruppe")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.OptionalJn).HasColumnName("OptionalJN");

                entity.HasOne(d => d.IdzusatzEintragNavigation)
                    .WithMany(p => p.ZusatzGruppeEintrag)
                    .HasForeignKey(d => d.IdzusatzEintrag)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ZusatzGruppeEintrag_ZusatzEintrag");

                entity.HasOne(d => d.IdzusatzGruppeNavigation)
                    .WithMany(p => p.ZusatzGruppeEintrag)
                    .HasForeignKey(d => d.IdzusatzGruppe)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ZusatzGruppeEintrag_ZusatzGruppe");
            });

            modelBuilder.Entity<ZusatzWert>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("piZusatzWert")
                    .IsUnique();

                entity.HasIndex(e => new { e.Idobjekt, e.IdzusatzGruppeEintrag })
                    .HasName("_dta_index_ZusatzWert_5_357576312__K3_K2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idobjekt).HasColumnName("IDObjekt");

                entity.Property(e => e.IdzusatzGruppeEintrag).HasColumnName("IDZusatzGruppeEintrag");

                entity.Property(e => e.RawFormat).HasColumnType("image");

                entity.Property(e => e.Wert).HasColumnType("text");

                entity.HasOne(d => d.IdzusatzGruppeEintragNavigation)
                    .WithMany(p => p.ZusatzWert)
                    .HasForeignKey(d => d.IdzusatzGruppeEintrag)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ZusatzWert_ZusatzGruppeEintrag");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}