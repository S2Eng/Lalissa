//13.04.2007 MDA
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.PflegePlan;
using RBU;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
    public partial class DBPflegemodelle : Component
    {
        public DBPflegemodelle()
        {
            InitializeComponent();
        }

        public DBPflegemodelle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsPflegemodelle.PflegemodelleDataTable Pflegemodelle
        {
            get { return dsPflegemodelle1.Pflegemodelle; }
        }

        public void Read()
        {
            dsPflegemodelle1.Pflegemodelle.Clear();
            DataBase.Fill(daPflegemodelle, dsPflegemodelle1);
        }

        public dsPflegemodelle.PflegemodelleRow New()
        {
            dsPflegemodelle.PflegemodelleRow row = dsPflegemodelle1.Pflegemodelle.NewPflegemodelleRow();
            row.ID = Guid.NewGuid();
            row.Modell = "";
            row.ModellgruppeKlartext = "";
            row.Modellgruppe = -1;
            row.Reihenfolge = 0;

            dsPflegemodelle1.Pflegemodelle.AddPflegemodelleRow(row);
            return row;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            DataBase.Update(daPflegemodelle, dsPflegemodelle1);
        }

        public dsPflegemodelle.PflegemodelleRow[] GetAllModelle()
        {
            List<dsPflegemodelle.PflegemodelleRow> list = new List<dsPflegemodelle.PflegemodelleRow>();
            string modell = "";

            foreach (dsPflegemodelle.PflegemodelleRow r in Pflegemodelle)
            {
                if (modell != r.Modell.Trim())
                {
                    modell = r.Modell.Trim();
                    list.Add(r);
                }
            }

            return list.ToArray();
        }

        public dsPflegemodelle.PflegemodelleRow[] GetAllModellegruppenToModel(string modell)
        {
            return (dsPflegemodelle.PflegemodelleRow[])Pflegemodelle.Select("Modell='" + modell + "'");
        } 
    }
}
