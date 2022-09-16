using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.OleDb;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global.db.Global;




namespace PMDS.DB.Global
{
    public partial class DBPatientbewerber : Component
    {
        public DBPatientbewerber()
        {
            InitializeComponent();
        }

        public DBPatientbewerber(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Bewerber zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPatientBewerber PatientBewerber
        {
            get { return dsPatientBewerber1; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Klienten, die kein Bewerber sind, zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPatientBereich ListKlienten
        {
            get { return dsPatientBereich1; }
        }

        public void Read()
        {
            dsPatientBewerber1.Patient.Clear();
            RBU.DataBase.Fill(daBewerber, dsPatientBewerber1.Patient);
        }

        public void Write()
        {
            RBU.DataBase.Update(daBewerber, dsPatientBewerber1);
        }

        //Neu nach 05.07.2007 MDA
        public dsPatientBewerber.PatientRow ReadByID(Guid IDPatient)
        {
            dsPatientBewerber.PatientRow row = null;
            dsPatientBewerber1.Patient.Clear();
            daPatientByID.SelectCommand.Parameters[0].Value = IDPatient;
            RBU.DataBase.Fill(daPatientByID, dsPatientBewerber1.Patient);

            if (dsPatientBewerber1.Patient.Count > 0)
                row = dsPatientBewerber1.Patient[0];

            return row;
        }

        public void ReadByFilter2(string patient, DateTime bewerberVon, DateTime bewerberBis, DateTime einzzugswuschVon,
                                          DateTime einzzugswuschBis, string prioritaet, string pflegeart, Guid IDAbteilung,
                                          string Konfision, string Sexus, Guid IDBereich, Guid IDKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            StringBuilder sbWhere = new StringBuilder();

            // normaler Filter
            if (patient != null && patient != "")
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("(Nachname + ' ' + Vorname) like ? ");
                cmd.Parameters.Add("Name", OleDbType.VarChar).Value = "%" + patient + "%";
            }

            if (bewerberVon != DateTime.MinValue)
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("BewerbungDatum >= ?");
                cmd.Parameters.Add(new OleDbParameter { ParameterName = "BewerbungDatum", OleDbType = OleDbType.Date, Value = bewerberVon });
            }

            if (bewerberBis != DateTime.MinValue)
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("BewerbungDatum <= ?");
                cmd.Parameters.Add(new OleDbParameter { ParameterName = "BewerbungDatum", OleDbType = OleDbType.Date, Value = bewerberBis });
            }

            if (einzzugswuschVon != DateTime.MinValue)
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("EinzugswunschDatum >= ?");
                cmd.Parameters.Add(new OleDbParameter { ParameterName = "EinzugswunschDatum", OleDbType = OleDbType.Date, Value = einzzugswuschVon });
            }

            if (einzzugswuschBis != DateTime.MinValue)
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("EinzugswunschDatum <= ?");
                cmd.Parameters.Add(new OleDbParameter { ParameterName = "EinzugswunschDatum", OleDbType = OleDbType.Date, Value = einzzugswuschBis });
            }

            if (prioritaet != null && prioritaet != "")
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("Prioritaet like ? ");
                cmd.Parameters.Add("Prioritaet", OleDbType.VarChar).Value = "%" + prioritaet + "%";
            }
            if (Sexus != null && Sexus != "")
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("Sexus like ? ");
                cmd.Parameters.Add("Sexus", OleDbType.VarChar).Value = "%" + Sexus.Trim() + "%";
            }
            if (Konfision != null && Konfision != "")
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("Konfision like ? ");
                cmd.Parameters.Add("Konfision", OleDbType.VarChar).Value = "%" + Konfision.Trim() + "%";
            }
            if (pflegeart != null && pflegeart != "")
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("PflegeArt like ? ");
                cmd.Parameters.Add("PflegeArt", OleDbType.VarChar).Value = "%" + pflegeart + "%";
            }

            if (IDKlinik != Guid.Empty)
            {
                string SqlWhereKlinik = " and IDAbteilung IN (Select ID from Abteilung where IDKlinik='" + IDKlinik.ToString() + "') ";
                sbWhere.Append(SqlWhereKlinik);
            }
            if (IDAbteilung != Guid.Empty)
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("IDAbteilung = ? ");
                cmd.Parameters.Add("IDAbteilung", OleDbType.Guid).Value = IDAbteilung;
            }
            if (IDBereich != Guid.Empty)
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("IDBereich = ? ");
                cmd.Parameters.Add("IDBereich", OleDbType.Guid).Value = IDBereich;
            }

            if (sbWhere.Length == 0)
            {
                Read();
                return;
            }

            sbWhere.Append(" ORDER BY Nachname, Vorname");
            cmd.CommandText = daBewerber.SelectCommand.CommandText + sbWhere.ToString();

            dsPatientBewerber1.Patient.Clear();
            RBU.DataBase.Fill(da, dsPatientBewerber1.Patient);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Klienten, die kein Bewerber sind, aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void KlientByFilter(string patient)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            StringBuilder sbWhere = new StringBuilder();

            if (patient != null && patient != "")
            {
                sbWhere.Append(" AND ");
                sbWhere.Append("(Nachname + ' ' + Vorname) like ? ");
                cmd.Parameters.Add("Name", OleDbType.VarChar).Value = "%" + patient + "%";
            }

            sbWhere.Append(" ORDER BY Name, Aufenthalt.Aufnahmezeitpunkt DESC");
            cmd.CommandText = daPatientBereich.SelectCommand.CommandText + sbWhere.ToString();

            dsPatientBereich1.Patient.Clear();
            RBU.DataBase.Fill(da, dsPatientBereich1.Patient);
        }
    }
}
