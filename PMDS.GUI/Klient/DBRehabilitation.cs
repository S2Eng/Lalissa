using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;

namespace PMDS.Klient
{


    public partial class DBRehabilitation : Component
    {
        private Guid _idPatient = Guid.NewGuid();

        public DBRehabilitation()
        {
            InitializeComponent();
        }

        public DBRehabilitation(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen
        /// </summary>
        public dsRehabilitation ALL
        {
            get { return dsRehabilitation1; }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen einlesen
        /// </summary>
        public void Read()
        {
            dsRehabilitation1.Rehabilitation.Clear();
            daRehablilitation.SelectCommand.Parameters[0].Value = _idPatient;
            RBU.DataBase.Fill(daRehablilitation, dsRehabilitation1);
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daRehablilitation, dsRehabilitation1);
        }

        /// <summary>
        /// Neue Rehabilitation einfügen
        /// </summary>
        public void New(bool maßnahmeJN, object Von, object Bis, string Beschreibung, string Ziel,
                        string Institution, string EndeGrund, string Bemerkung)
        {
            dsRehabilitation.RehabilitationRow r = dsRehabilitation1.Rehabilitation.NewRehabilitationRow();
            r.ID = Guid.NewGuid();
            r.IDPatient = IDPatient;
            r.MassnahmeJN = maßnahmeJN;

            if(Von != null)
                r.Von = (DateTime)Von;

            if (Bis != null)
                r.Bis = (DateTime)Bis;

            if (Beschreibung != "")
                r.Beschreibung = Beschreibung;

            if (Ziel != "")
                r.Ziel = Ziel;

            if (Institution != "")
                r.Institution = Institution;

            if (EndeGrund != "")
                r.EndeGrund = EndeGrund;

            if (Bemerkung != "")
                r.Bemerkung = Bemerkung;
            
            dsRehabilitation1.Rehabilitation.AddRehabilitationRow(r);
        }
    }
}
