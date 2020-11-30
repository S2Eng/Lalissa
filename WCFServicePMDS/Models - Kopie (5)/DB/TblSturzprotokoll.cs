﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblSturzprotokoll
    {
        public Guid Id { get; set; }
        public Guid Idstandardprozedur { get; set; }
        public Guid Idpatient { get; set; }
        public string NamePatient { get; set; }
        public DateTime? PatGebDat { get; set; }
        public string Wohnbereich { get; set; }
        public string Zimmer { get; set; }
        public DateTime? SturzDatum { get; set; }
        public string SturzOrt { get; set; }
        public string SturzStellung { get; set; }
        public string SturzErstellt { get; set; }
        public string SituationWie { get; set; }
        public string SituationGehilfen { get; set; }
        public string SituationKleidung { get; set; }
        public string SituationSchuhe { get; set; }
        public string HergangWoZuletztGesehen { get; set; }
        public string HergangKonnteBewohnerSchildern { get; set; }
        public bool HergangSchilderungBewohnerJn { get; set; }
        public string HergangSchilderungBewohner { get; set; }
        public string UmständeHilfebedarf { get; set; }
        public string UmständeSachgerechteNutzung { get; set; }
        public bool UmständeFixierungJn { get; set; }
        public string UmständeFixierung { get; set; }
        public string UmständePflegekräfteAnwesend { get; set; }
        public bool UmständeKlingelJn { get; set; }
        public bool UmständeBewohnervsrschuldenJn { get; set; }
        public string UmständeBewohnervsrschulden { get; set; }
        public bool UmständeKlinikVerschuldenJn { get; set; }
        public string UmständeKlinikVerschulden { get; set; }
        public bool UmständeFremdverschuldenJn { get; set; }
        public string UmständeFremdverschulden { get; set; }
        public bool UmständeVorereignisJn { get; set; }
        public string UmständeVorereignis { get; set; }
        public bool GesundheitSchädenJn { get; set; }
        public string GesundheitSchäden { get; set; }
        public decimal GesundheitBlutzucker { get; set; }
        public int GesundheitBlutdruckSystolisch { get; set; }
        public int GesundheitBlutdruckDiastolisch { get; set; }
        public decimal GesundheitPuls { get; set; }
        public string GesundheitMental { get; set; }
        public bool GesundheitErstversorgungJn { get; set; }
        public string GesundheitErstversorgung { get; set; }
        public string GesundheitErgebnis { get; set; }
        public bool GesundheitTransferKrankenhausJn { get; set; }
        public string GesundheitTransferKrankenhaus { get; set; }
        public bool InformationKontaktpersonJn { get; set; }
        public string InformationKontaktperson { get; set; }
        public string InformationPflegepersonKontakt { get; set; }
        public DateTime? InformationPdlzeitpunkt { get; set; }
        public string InformationPdlvonWemInformiert { get; set; }
        public bool InformationArztJn { get; set; }
        public string InformationArzt { get; set; }
        public string InformationArztPflegepersonHatInformiert { get; set; }
        public string AnalyseMedikamente { get; set; }
        public string AnalyseKrankheitsbilder { get; set; }
        public string AnalyseInkontinenz { get; set; }
        public string AnalyseEingeschränkteMobilität { get; set; }
        public string AnalyseSchwindel { get; set; }
        public string AnalyseErnährung { get; set; }
        public string AnalyseMaßnahmen { get; set; }
        public string Anmerkungen { get; set; }
        public string DatumUnterschriftPflegedienstleitung { get; set; }
        public string DatumUnterschriftPflegekraft { get; set; }

        public virtual Sp IdstandardprozedurNavigation { get; set; }
    }
}