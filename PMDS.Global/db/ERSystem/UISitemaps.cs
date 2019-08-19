using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace PMDS.Global.db.ERSystem
{


    public class UISitemaps
    {
                public class cParFormular
        {
            public System.Collections.Generic.List<string> lstFormularNames = new List<string>();
            public Nullable<Guid> IDAbteilung_current = null;
            public Nullable<Guid> IDAufenthalt_current = null;
            public Nullable<Guid> IDBereich_current = null;
            public Nullable<Guid> IDKlient_current = null;
            public Nullable<Guid> IDKlinik_current = null;
            public Nullable<Guid> IDUser_current = null;
            public Nullable<DateTime> f_DatumErstelltVon = null;
            public Nullable<DateTime> f_DatumErstelltBis = null;

            public PMDS.Global.db.ERSystem.dsFormular dsFormularAssessment = new dsFormular();
            public string ReportFile = "";
        }


        public void getListGuidFromString(string StrBySemikolon, ref System.Collections.Generic.List<Guid> lstGuidReturn)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<string> lst = qs2.core.generic.readStrVariables(StrBySemikolon.Trim());
                if (lst.Count > 0)
                {
                    foreach (string IDStr in lst)
                    {
                        lstGuid.Add(new Guid(IDStr));
                    }
                    lstGuidReturn = lstGuid;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("UISitemaps.getListGuidFromString: " + ex.ToString());
            }
        }
        public void getListIntFromString(string StrBySemikolon, ref System.Collections.Generic.List<int> lstIntReturn)
        {
            try
            {
                System.Collections.Generic.List<int> lstInt = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lst = qs2.core.generic.readStrVariables(StrBySemikolon.Trim());
                if (lst.Count > 0)
                {
                    foreach (string IDStr in lst)
                    {
                        lstInt.Add(System.Convert.ToInt32(IDStr));
                    }
                    lstIntReturn = lstInt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("UISitemaps.getListIntFromString: " + ex.ToString());
            }
        }
        public void getListStringFromString(string StrBySemikolon, ref System.Collections.Generic.List<string> lstStringReturn)
        {
            try
            {
                System.Collections.Generic.List<string> lstStr = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> lst = qs2.core.generic.readStrVariables(StrBySemikolon.Trim());
                if (lst.Count > 0)
                {
                    foreach (string IDStr in lst)
                    {
                        lstStr.Add(IDStr.Trim());
                    }
                    lstStringReturn = lstStr;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("UISitemaps.getListStringFromString: " + ex.ToString());
            }
        }
    }
}
