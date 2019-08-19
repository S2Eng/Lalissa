using PMDS.Data.Global;
using PMDS.Global.db.Global;
using RBU;
using System;
using System.ComponentModel;

namespace PMDS.DB.Global
{
    public partial class DBPatientAerzte : Component
    {
        public DBPatientAerzte()
        {
            InitializeComponent();
        }

        public DBPatientAerzte(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsPatientAerzte PatientAerzte
        {
            get { return dsPatientAerzte1; }
        }

        public void Read(Guid IDPatient)
        {
            dsPatientAerzte1.PatientAerzte.Clear();
            daPatientAerzte.SelectCommand.Parameters[0].Value = IDPatient;
            DataBase.Fill(daPatientAerzte, dsPatientAerzte1.PatientAerzte);
        }

        public dsPatientAerzte AllAktivePatientHausAerzte         
        {            
            get 
            { 
               
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();            
                cmd.CommandText = ("SELECT     PatientAerzte.ID, PatientAerzte.IDPatient, PatientAerzte.IDAerzte, PatientAerzte.HausarztJN, PatientAerzte.ZuweiserJN, PatientAerzte.AufnahmearztJN," +
                      "PatientAerzte.BehandelnderFAJN, PatientAerzte.Von, PatientAerzte.Bis " +
                        "FROM         Aufenthalt INNER JOIN " +
                      "PatientAerzte INNER JOIN " +
                      "Patient ON PatientAerzte.IDPatient = Patient.ID ON Aufenthalt.IDPatient = Patient.ID " +
                    "WHERE     (PatientAerzte.HausarztJN = 1) AND (Aufenthalt.Entlassungszeitpunkt IS NULL)");

                System.Data.OleDb.OleDbDataAdapter daPatientAerzteAll = new System.Data.OleDb.OleDbDataAdapter(cmd);                
               
                dsPatientAerzte1.PatientAerzte.Clear();
                DataBase.Fill(daPatientAerzteAll, dsPatientAerzte1.PatientAerzte);

                return dsPatientAerzte1;
            }
        }

        public dsGUIDListe AllAktivePatientHausAerzteByPatient(Guid IDPatient)
        {     
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = ("SELECT   DISTINCT  PatientAerzte.IDAerzte as ID,'Name' as Text " +
                            "FROM         Aufenthalt INNER JOIN " +
                          "PatientAerzte INNER JOIN " +
                          "Patient ON PatientAerzte.IDPatient = Patient.ID ON Aufenthalt.IDPatient = Patient.ID " +
                        "WHERE  PatientAerzte.IDPatient = ? ");


                cmd.Parameters.Add("", System.Data.OleDb.OleDbType.Guid).Value = IDPatient;
                System.Data.OleDb.OleDbDataAdapter daHausaerzteByPatient = new System.Data.OleDb.OleDbDataAdapter(cmd);
                dsGUIDListe GUIDListe = new dsGUIDListe();    
            
                GUIDListe.IDListe.Clear();                
                DataBase.Fill(daHausaerzteByPatient, GUIDListe.IDListe);
                return GUIDListe;
        }




        public dsPatientAerzte.PatientAerzteRow New(Guid IDPatient, Guid IDAerzte)
        {
            dsPatientAerzte.PatientAerzteRow r = dsPatientAerzte1.PatientAerzte.NewPatientAerzteRow();
            r.ID = Guid.NewGuid();
            r.IDPatient = IDPatient;
            r.IDAerzte = IDAerzte;
            r.AufnahmearztJN = false;
            r.BehandelnderFAJN = false;
            r.HausarztJN = false;
            r.ZuweiserJN = false;
            dsPatientAerzte1.PatientAerzte.AddPatientAerzteRow(r);
            return r;
        }

        public void Write()
        {
            DataBase.Update(daPatientAerzte, dsPatientAerzte1);
        }
    }
}
