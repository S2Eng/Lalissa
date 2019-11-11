using PMDS.Data.Global;
using PMDS.DB.Global;
using PMDS.Global.db.Global;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Patient;
using System;
using System.Data;


namespace PMDS.BusinessLogic
{
    

    public class Depotgeldkonto
    {



        DBTaschengeld _db;


        public Depotgeldkonto()
        {
            _db = new DBTaschengeld();
        }

        public dsTaschengeld TASCHENGELD
        {
            get { return _db.TASCHENGELD; }
        }

        public void Read(Guid IDPatient, DateTime von, DateTime bis, System.Guid IDKlinik )
        {
            _db.Read(IDPatient, von, bis, IDKlinik );
        }

        public void Write()
        {
            _db.Write();
        }

        public dsTaschengeld.TaschengeldRow New(Guid IDPatient, DateTime Datum, System.Guid IDKlinik)
        {
            return _db.New(IDPatient, Datum, IDKlinik);
        }

        public dsGUIDListe.IDListeDataTable GetListKostentraeger(Guid IDPatient, System.Guid IDKlinik)
        {
            return _db.GetListKostentraeger(IDPatient, IDKlinik);
        }

        public dsPrintTaschengeld GetPrintableDataset(Guid IDpatient, DateTime from, DateTime to, System.Guid  IDKlinik)
        {
            dsTaschengeld.TaschengeldRow[] rows = (dsTaschengeld.TaschengeldRow[])TASCHENGELD.Taschengeld.Select("Datum >= '" + from.ToString() +
                    "' and Datum <= '" + to.ToString() + "'", "Datum");

            dsPrintTaschengeld ds = new dsPrintTaschengeld();
            dsPrintTaschengeld.TaschengeldRow tr;
            foreach (dsTaschengeld.TaschengeldRow r in rows)
            {
                if (r.IDKlinik.Equals(IDKlinik))
                {
                    tr = ds.Taschengeld.AddTaschengeldRow(r.ID, r.IDPatient, r.IsBelegNrNull() ? "" : r.BelegNr, r.Datum, r.IsGrundNull() ? "" : r.Grund,
                                                        0.0, 0.0, 0.0, r.IsLieferantNull() ? "" : r.Lieferant, r.IsBemerkungNull() ? "" : r.Bemerkung, "");

                    if (r.IsEinzahlungNull())
                        tr.SetEinzahlungNull();
                    else
                        tr.Einzahlung = r.Einzahlung;

                    if (r.IsAuszahlungNull())
                        tr.SetAuszahlungNull();
                    else
                        tr.Auszahlung = r.Auszahlung;

                    if (r.IsSaldoNull())
                        tr.SetSaldoNull();
                    else
                        tr.Saldo = r.Saldo;

                    tr.SetZahlartNull();
                }

            }

            string name = "";
            Patient p = new Patient(IDpatient);

            string sTitel = p.Titel;
            string sAnrede = "";
            if (p.Sexus.Contains("eib"))
                sAnrede = "Frau";
            else if (p.Sexus.Contains("nn"))
                sAnrede = "Herr";
            name = (sAnrede + " " + sTitel + "" + p.Vorname + " " + p.Nachname).Trim();
            
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

            PMDS.DB.DBAdresse DBAdresse1 = new PMDS.DB.DBAdresse();
            dsAdresse.AdresseRow rAdresse = DBAdresse1.loadAdresseKlinik(rKlinikActuell.IDAdresse, true);

            PMDS.DB.Global.DBBank DBBank1 = new PMDS.DB.Global.DBBank();
            dsBank.BankRow rBank = DBBank1.loadBankKlinik(rKlinikActuell.ID, true);

            PMDS.DB.DBKontakt DBKontakt1 = new PMDS.DB.DBKontakt();
            dsKontakt.KontaktRow rKontakt = DBKontakt1.loadKontaktKlinik(rKlinikActuell.IDKontakt , true);
            //string bank = GetBankVerbindung(k);
            string sBank = Tools.GetBankVerbindung(rBank);

            ds.Klient.AddKlientRow(IDpatient, name, rAdresse.Strasse, rAdresse.Plz, rAdresse.Ort);

            dsPrintTaschengeld.HeimInfoRow hRow = ds.HeimInfo.AddHeimInfoRow(rKlinikActuell.Bezeichnung, rAdresse.Strasse, rAdresse.Plz, rAdresse.Ort, rKontakt.Tel,
                  rKontakt.Fax, rKontakt.Email, "", sBank, rKlinikActuell.ZVR.Trim(), "", "", "", new byte[1] { 0 }, "");
            Tools.FillHeimLogo((DataRow)hRow, ds.HeimInfo.LogoColumn.ColumnName);
            ds.AcceptChanges();
            return ds;
        }

    }
}
