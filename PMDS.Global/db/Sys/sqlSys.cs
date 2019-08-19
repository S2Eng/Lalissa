using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PMDS.Global.db.Sys
{

    public partial class sqlSys : Component
    {
        
        public string daSelRessourcenITSCont = "";
        public enum eTypeRessourcenITSCont
        {
            IDRes = 0

        }

        public bool isInitialized = false;






        public sqlSys()
        {
            InitializeComponent();
        }

        public sqlSys(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        public void initControl()
        {
            try
            {
                if (!this.isInitialized)
                {
                    this.daSelRessourcenITSCont = this.daRessourcenITSCont.SelectCommand.CommandText;

                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sqlSys.initControl: " + ex.ToString());
            }
        }


        public bool getRessourcenITSCont(string IDRes, eTypeRessourcenITSCont TypeSelRessourcen, ref dsRessourcenITSCont ds,
                                        ref System.Data.OleDb.OleDbConnection connITSCont)
        {
            try
            {
                this.daRessourcenITSCont.SelectCommand.CommandText = this.daSelRessourcenITSCont;
                this.daRessourcenITSCont.SelectCommand.Parameters.Clear();
                this.daRessourcenITSCont.SelectCommand.Connection = connITSCont;

                if (TypeSelRessourcen == eTypeRessourcenITSCont.IDRes)
                {
                    string sqlWhere = " where IDRes='" + IDRes.Trim() + "' ";

                    this.daRessourcenITSCont.SelectCommand.CommandText += sqlWhere + " order by IDRes asc";
                }
                else
                {
                    throw new Exception("sqlSys.getRessourcenITSCont: TypeSelRessourcen '" + TypeSelRessourcen.ToString() + "' not supported!");
                }
                this.daRessourcenITSCont.Fill(ds.RessourcenITSCont);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlSys.getRessourcenITSCont: " + ex.ToString());
            }
        }


    }

}
