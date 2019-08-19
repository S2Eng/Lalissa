using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{


    public partial class DBSturz : Component
    {



        public DBSturz()
        {
            InitializeComponent();
        }

        public DBSturz(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        public bool getSturzByID(dsVerwaltung ds, System.Guid IDSP)
        {
            this.daSturzByID.SelectCommand.Parameters[0].Value = IDSP;
            DataBase.Fill(this.daSturzByID, ds.tblSturzprotokoll);
            if (ds.tblSturzprotokoll.Rows.Count > 1)
            {
                throw new Exception("getSturzByID: Error ds.tblSturzprotokoll.Rows.Count > 1!");
            }  

            return true;
        }

        public dsVerwaltung.tblSturzprotokollRow getNewSturz(dsVerwaltung ds)
        {
            dsVerwaltung.tblSturzprotokollRow rNew = (dsVerwaltung.tblSturzprotokollRow)ds.tblSturzprotokoll.NewRow();

            rNew.ID = System.Guid.NewGuid();
	        rNew.IDStandardprozedur = System.Guid.NewGuid();
	        rNew.IDPatient = System.Guid.NewGuid();
	        rNew.NamePatient = "";
            rNew.SetPatGebDatNull();
	        rNew.Wohnbereich = "";
	        rNew.Zimmer = "";
            rNew.SetSturzDatumNull();
	        rNew.SturzOrt = "";
	        rNew.SturzStellung  = "";
	        rNew.SturzErstellt = "";
	        rNew.SituationWie = "";
	        rNew.SituationGehilfen = "";
	        rNew.SituationKleidung = "";
	        rNew.SituationSchuhe = "";
	        rNew.HergangWoZuletztGesehen = "";
	        rNew.HergangKonnteBewohnerSchildern = "";
	        rNew.HergangSchilderungBewohnerJN  = false;
	        rNew.HergangSchilderungBewohner = "";
	        rNew.UmständeHilfebedarf = "";
	        rNew.UmständeSachgerechteNutzung = "";
	        rNew.UmständeFixierungJN = false;
	        rNew.UmständeFixierung = "";
	        rNew.UmständePflegekräfteAnwesend = "";
	        rNew.UmständeKlingelJN = false;
	        rNew.UmständeBewohnervsrschuldenJN = false;
	        rNew.UmständeBewohnervsrschulden = "";
	        rNew.UmständeKlinikVerschuldenJN = false;
	        rNew.UmständeKlinikVerschulden = "";
	        rNew.UmständeFremdverschuldenJN = false;
	        rNew.UmständeFremdverschulden = "";
	        rNew.UmständeVorereignisJN = false;
            rNew.UmständeVorereignis = "";
	        rNew.GesundheitSchädenJN = false;
	        rNew.GesundheitSchäden = "";
	        rNew.GesundheitBlutzucker = 0;
	        rNew.GesundheitBlutdruckSystolisch = 0;
            rNew.GesundheitBlutdruckDiastolisch= 0;
	        rNew.GesundheitPuls = 0;
	        rNew.GesundheitMental = "";
	        rNew.GesundheitErstversorgungJN = false;
	        rNew.GesundheitErstversorgung = "";
	        rNew.GesundheitErgebnis = "";
            rNew.GesundheitTransferKrankenhausJN = false;
	        rNew.GesundheitTransferKrankenhaus = "";
	        rNew.InformationKontaktpersonJN = false;
            rNew.InformationKontaktperson = "";
            rNew.InformationPflegepersonKontakt = "";
            rNew.SetInformationPDLZeitpunktNull();
	        rNew.InformationPDLVonWemInformiert = "";
            rNew.InformationArztJN = false;
	        rNew.InformationArzt = "";
	        rNew.InformationArztPflegepersonHatInformiert = "";
            rNew.AnalyseMedikamente = "";
	        rNew.AnalyseKrankheitsbilder = "";
	        rNew.AnalyseInkontinenz = "";
	        rNew.AnalyseEingeschränkteMobilität = "";
	        rNew.AnalyseSchwindel = "";
	        rNew.AnalyseErnährung = "";
	        rNew.AnalyseMaßnahmen = "";
	        rNew.Anmerkungen = "";
	        rNew.DatumUnterschriftPflegedienstleitung = "";
	        rNew.DatumUnterschriftPflegekraft = "";

            ds.tblSturzprotokoll.Rows.Add(rNew);
            return rNew;
        }


    }
}
