using System;
using System.Collections.Generic;




namespace qs2.core.print
{



    public class print
    {


        public enum eQueryType
        {
            SimpleView = 0,
            SimpleFunction = 1,
            FullMode = 100
        }



        public void getQueryTypes(ref System.Collections.Generic.List<KeyValuePair<string, string>> lstTypeQueries)
        {
            foreach (int val in Enum.GetValues(typeof(eQueryType)))
            {
                string sApp = Enum.GetName(typeof(eQueryType), val);
                string Translated = qs2.core.language.sqlLanguage.getRes(sApp);
                if (Translated.Trim() == "")
                {
                    Translated = sApp;
                }
                KeyValuePair<string, string> itm = new KeyValuePair<string, string>(sApp, Translated.Trim());
                lstTypeQueries.Add(itm);
            }

        }

        public dsSimpleQuerySelection.SimpleTablesRow newRowSimpleQuery(ref dsSimpleQuerySelection  ds)
        {
            dsSimpleQuerySelection.SimpleTablesRow rNew = (dsSimpleQuerySelection.SimpleTablesRow)ds.SimpleTables.NewRow();
            rNew.ID = System.Guid.NewGuid();
            rNew.TranslationTableName = "";
            rNew.TableName = "";
            rNew.Classification = "";
            rNew.Description = "";
            ds.SimpleTables.Rows.Add(rNew);
            return rNew;
        }


    }
}
