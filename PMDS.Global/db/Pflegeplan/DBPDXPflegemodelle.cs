//13.04.2007 MDA
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using RBU;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
    public partial class DBPDXPflegemodelle : Component
    {
        public DBPDXPflegemodelle()
        {
            InitializeComponent();
        }

        public DBPDXPflegemodelle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsPDXPflegemodelle.PDXPflegemodelleDataTable PDXPflegemodelle
        {
            get { return dsPDXPflegemodelle1.PDXPflegemodelle; }
        }

        public void Read()
        {
            dsPDXPflegemodelle1.PDXPflegemodelle.Clear();
            DataBase.Fill(daPDXPflegemodelle, dsPDXPflegemodelle1);
        }

        public void ReadOneByPDX(Guid IDPDX)
        {
            daPDXPflegemodelleByPDX.SelectCommand.Parameters[0].Value = IDPDX;
            dsPDXPflegemodelle1.PDXPflegemodelle.Clear();
            DataBase.Fill(daPDXPflegemodelleByPDX, dsPDXPflegemodelle1);
        }

        public dsPDXPflegemodelle.PDXPflegemodelleRow New()
        {
            dsPDXPflegemodelle.PDXPflegemodelleRow row = dsPDXPflegemodelle1.PDXPflegemodelle.NewPDXPflegemodelleRow();
            row.ID = Guid.NewGuid();
            row.IDPDX = Guid.Empty;
            row.IDPflegemodelle = Guid.Empty;

            dsPDXPflegemodelle1.PDXPflegemodelle.AddPDXPflegemodelleRow(row);
            return row;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            DataBase.Update(daPDXPflegemodelle, dsPDXPflegemodelle1);
        }

        public void PDXPflegemodelleToDB(PDXDef def)
        {
            bool found;

            //Gelöschte PDXPflegemodelle löschen
            foreach (dsPDXPflegemodelle.PDXPflegemodelleRow r in dsPDXPflegemodelle1.PDXPflegemodelle)
            {
                found = false;

                foreach (PDXPflegemodellDef pdxPflDef in def.PDXPflegemodelle)
                {
                    if (pdxPflDef.ID == r.ID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    r.Delete();
            }

            //Neue PDXPflegemodelle hinzufügen
            foreach (PDXPflegemodellDef pdxPflDef in def.PDXPflegemodelle)
            {
                found = false;

                foreach (dsPDXPflegemodelle.PDXPflegemodelleRow r in dsPDXPflegemodelle1.PDXPflegemodelle)
                {
                    if (r.RowState != System.Data.DataRowState.Deleted && r.ID == pdxPflDef.ID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dsPDXPflegemodelle.PDXPflegemodelleRow row = New();
                    row.ID              = pdxPflDef.ID;
                    row.IDPDX           = pdxPflDef.IDPDX;
                    row.IDPflegemodelle = pdxPflDef.IDPflegemodelle;
                }
            }

            Write();
        }

        public List<PDXPflegemodellDef> GetPflegemodelleToPDX()
        {
            List<PDXPflegemodellDef> list = new List<PDXPflegemodellDef>();

            PDXPflegemodellDef pdxPflegemodellDef;

            foreach (dsPDXPflegemodelle.PDXPflegemodelleRow r in dsPDXPflegemodelle1.PDXPflegemodelle)
            {
                pdxPflegemodellDef = new PDXPflegemodellDef();
                pdxPflegemodellDef.ID = r.ID;
                pdxPflegemodellDef.IDPDX = r.IDPDX;
                pdxPflegemodellDef.IDPflegemodelle = r.IDPflegemodelle;
                list.Add(pdxPflegemodellDef);
            }

            return list;
        }
    }
}
