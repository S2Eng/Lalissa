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



    public partial class DBVerwaltung : Component
    {

        public string selObjektKatalog = "";

        public enum eTypeObjKatalog
        {
            WichtigFür = 0,

        }
        public enum eTypeSelObjKatalog
        {
            Type = 0,

        }


        public DBVerwaltung()
        {
            InitializeComponent();
        }

        public DBVerwaltung(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }





        public void initControl()
        {
            try
            {
                this.selObjektKatalog = this.daObjektKatalog.SelectCommand.CommandText;


            }
            catch (Exception ex)
            {
                throw new Exception("DBVerwaltung.initControl: " + ex.ToString());
            }
        }

        public bool getObjektKatalog(ref dsVerwaltung ds, ref eTypeSelObjKatalog TypeSelObjKatalog, ref eTypeObjKatalog TypeObjKatalog,
                                    ref System.Guid IDPflegeintrag, ref System.Guid IDBeruf)
        {
            try
            {
                this.daObjektKatalog.SelectCommand.CommandText = this.selObjektKatalog;
                this.daObjektKatalog.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daObjektKatalog, RBU.DataBase.CONNECTION);

                if (TypeSelObjKatalog == eTypeSelObjKatalog.Type)
                {
                    string sWhere = "";
                    string sOrderBy = "";
                    sWhere = "";
                    this.daObjektKatalog.SelectCommand.Parameters.Add(new OleDbParameter("xy", null));

                    this.daObjektKatalog.SelectCommand.CommandText += sWhere + "" + sOrderBy;
                }
                else
                {
                    throw new Exception("DBVerwaltung.getObjektKatalog: TypeSelObjKatalog '" + TypeSelObjKatalog .ToString()+ "' not supported!");
                }

                this.daObjektKatalog.Fill(ds.ObjektKatalog);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("DBVerwaltung.getObjektKatalog: " + ex.ToString());
            }
        }

        public dsVerwaltung.ObjektKatalogRow getNewObjektKatalog(dsVerwaltung ds)
        {
            dsVerwaltung.ObjektKatalogRow rNew = (dsVerwaltung.ObjektKatalogRow)ds.ObjektKatalog.NewRow();
            rNew.ID = System.Guid.NewGuid();
            rNew.SetIDPflegeintragNull();
            rNew.SetIDBerufNull();
            rNew.Main = false;
            rNew.SetVonNull();
            rNew.SetBisNull();
            rNew.TypeObj = "";
            rNew.Classification = "";
            rNew.Sort = -1;

            ds.ObjektKatalog.Rows.Add(rNew);

            return rNew;
        }


    }
}
