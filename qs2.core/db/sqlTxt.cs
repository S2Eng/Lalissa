using System;

namespace qs2.core
{
    public class sqlTxt
    {

        public static  string   orderBy         =       " order by ";
        public static string    where           =       " where ";
        public static string    asc             =       " asc ";
        public static string    like            =       " like ";
        public static string    likePerc        =       " like '%";
        public static string    likePercEnd     =       "%' ";
        public static string    or              =       " or ";
        public static string    and             =       " and ";
        public static string    from            =       " from ";
        public static string    select          =       " Select ";
        public static string    countAll        =       " Count(*) as Number ";
        public static string    In              =       " In ";
        public static string    NotIn           =       " Not In ";
        public static string    sMonkey         =       "@";                // Spider Monkey
        public static string    equalsMonkey    =       " = @";
        public static string    delete          =       " delete from ";
        public static string    not             =       " not ";
        public static string    columnID        =       "ID";
        public static string    equals          =       " = ";
        public static string    notEquals       =       " <> ";
        public static string    smaller         =       " < ";
        public static string    smallerEquals   =       " <= ";
        public static string    greater         =       " > ";
        public static string    greaterEquals   =       " >= ";
        public static string    between         =       " Between ";
        public static string    notBetween      =       " Not Between ";
        public static string    isNull          =       " Is Null ";
        public static string    isNotNull       =       " Is Not Null ";
        public static string    ClampRight      =       " ( ";
        public static string    ClampLeft       =       " ) ";
        public static string errTxtNoCriteriaRow = "No rCriteria exists for Field ";
        public static string errTxtNoCriteriaSourceTable = "No rCriteria.SourceTable exists for Field ";

        public static string getColWhere(string columnName)
        {
            return " " + columnName.Trim() + "=" + sqlTxt.sMonkey.Trim() + columnName.Trim() + " ";
        }

        public static string getWhereString(string columnName, string sValue)
        {
            return " " + columnName.Trim() + "='" + sValue + "' ";
        }

        public static string getWhereInt(string columnName, int iValue)
        {
            return " " + columnName.Trim() + "=" + iValue.ToString() + " ";
        }

        public static string getColWhereClamp(string columnName)
        {
            return " [" + columnName.Trim() + "]=" + sqlTxt.sMonkey.Trim() + columnName.Trim() + " ";
        }
        
        public static string getColWhere(string columnName, string condition)
        {
            return " " + columnName.Trim() + " " + condition.Trim() + " " + sqlTxt.sMonkey.Trim() + columnName.Trim() + " ";
        }
        
        public static string getColWherePost(string columnName, string condition, string PostfixColumn)
        {
            return " " + columnName.Trim() + " " + condition.Trim() + " " + sqlTxt.sMonkey.Trim() + columnName.Trim() + PostfixColumn.Trim() + " ";
        }
        
        public static string getColWhere(string columnName, string tableName, string condition)
        {
            return " " + tableName.Trim() + "." + columnName.Trim() + " " + condition + " " + sqlTxt.sMonkey.Trim() + columnName.Trim() + " ";
        }
        
        public static string getColWhere(string columnName, string tableName, string condition, string ParameterName)
        {
            return " " + tableName.Trim() + "." + columnName.Trim() + " " + condition + " " + sqlTxt.sMonkey.Trim() + ParameterName.Trim() + " ";
        }
        
        public static string getColWhereNoMonkeyxy(string columnName, string tableName, string condition)
        
        {
            return " " +  columnName.Trim() + " " + condition + " " + " ";
        }
        
        public static string getColWhereBetween(string columnName, string condition)
        {
            return " " + columnName.Trim() + " " + condition.Trim() + " " + sqlTxt.sMonkey.Trim() + columnName.Trim() + "From " + qs2.core.sqlTxt.and.Trim() + " " + sqlTxt.sMonkey + columnName.Trim() + "To" + " ";
        }
        
        public static string getColWhereBetween(string columnName, string tableName, string condition)
        {
            return " " + tableName.Trim() + "." + columnName.Trim() + " " + condition.Trim() + " " + sqlTxt.sMonkey.Trim() + columnName.Trim() + "From " + qs2.core.sqlTxt.and.Trim() + " " + sqlTxt.sMonkey.Trim() + columnName.Trim() + "To " + " ";
        }
        
        public static string getColWhereBetween(string columnName, string tableName, string condition, string ParameterNameFrom, string ParameterNameTo)
        {
            return " " + tableName.Trim() + "." + columnName.Trim() + " " + condition.Trim() + " " + sqlTxt.sMonkey.Trim() + ParameterNameFrom.Trim() + " " + qs2.core.sqlTxt.and.Trim() + " " + sqlTxt.sMonkey.Trim() + ParameterNameTo  + " ";
        }
        
        public static string getColWhereBetweenNoMonkeyxy(string columnName, string tableName, string condition)
        {
            return " " + columnName.Trim() + " " + condition.Trim() + " {0} " + qs2.core.sqlTxt.and.Trim() + " {1} ";
        }

        public static string getColPar(string columnName)
        {
            return sqlTxt.sMonkey + columnName;
        }

        public static void throwExeptionMoreThanOneRow(string functName, string id)
        {
            throw new Exception(functName + ": More than one Row for id '" + id + "' found!");
        }
    }
}
