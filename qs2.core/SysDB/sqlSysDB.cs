using System;
using System.ComponentModel;




namespace qs2.core.SysDB
{


    public partial class sqlSysDB : Component
    {
        

        public enum eTypSelColumns
        { 
            all = 0,
            table = 1,
            likeTableName = 2,
            ColumnTablenameLike = 3
        }

        public static string Sel_daTables = "";
        public static string Sel_daColumns= "";
        public static qs2.core.SysDB.dsSysDB dsSysDBAll;
        public static bool allColumnsLoaded = false;
        public static string sel_daSysAllPrimaryKeys = "";
        public static string sel_daSysAllForeignKeys = "";
        public static string sel_daSysComputedColumns = "";
        public static string sel_daSysIdentityColumns = "";
        

        



        public sqlSysDB()
        {
            InitializeComponent();
        }
        public sqlSysDB(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        

        public void initControl()
        {
            SysDB.sqlSysDB.allColumnsLoaded = false;
            SysDB.sqlSysDB.Sel_daColumns = this.daColumns.SelectCommand.CommandText;
            SysDB.sqlSysDB.Sel_daTables = this.daTables.SelectCommand.CommandText;
            SysDB.sqlSysDB.sel_daSysAllPrimaryKeys = this.daSysPrimaryKeys.SelectCommand.CommandText;
            SysDB.sqlSysDB.sel_daSysAllForeignKeys = this.daSysForeignKeys.SelectCommand.CommandText;
            SysDB.sqlSysDB.sel_daSysComputedColumns = this.daSysComputedColumns.SelectCommand.CommandText;
            SysDB.sqlSysDB.sel_daSysIdentityColumns = this.daSysIdentityColumns.SelectCommand.CommandText;
        }
        public void loadAllSysDatabase()
        {
            SysDB.sqlSysDB.allColumnsLoaded = false;
            qs2.core.SysDB.sqlSysDB.dsSysDBAll = new dsSysDB();

            this.getSysColumns("", sqlSysDB.dsSysDBAll, eTypSelColumns.all);
            this.getTables(sqlSysDB.dsSysDBAll, eTypSelColumns.all, "");
            this.getSysAllPrimaryKeys(sqlSysDB.dsSysDBAll.SysKeyColumnUsage);
            this.getSysAllForeignKeys(sqlSysDB.dsSysDBAll.SysForeignKeys);
            this.getSysComputedColumns(sqlSysDB.dsSysDBAll.SysComputedColumns);
            this.getSysAllIdentityColumns(sqlSysDB.dsSysDBAll.SysIdentityColumns);

            SysDB.sqlSysDB.allColumnsLoaded = true;
        }

        public static dsSysDB.COLUMNSRow getSysColumnRow(string TABLE_NAME, string COLUMN_NAME, dsSysDB ds, bool doException)
        {
            dsSysDB.COLUMNSRow[] arrColumns = (dsSysDB.COLUMNSRow[])ds.COLUMNS.Select(ds.COLUMNS.TABLE_NAMEColumn.ColumnName + "='" + TABLE_NAME + "'" + sqlTxt.and + ds.COLUMNS.COLUMN_NAMEColumn.ColumnName + "='" + COLUMN_NAME + "'");
            if (arrColumns.Length == 1)
                return arrColumns[0];
            else
                if (doException)
                {
                    throw new Exception("sqlSysDB.getSysColumnRow: No Definition found for Column '" + COLUMN_NAME + "' in Table '" + TABLE_NAME + "'");
                }
                else
                    return null;
        }
        public static dsSysDB.COLUMNSRow[] getAllSysColumnsForTable(string TABLE_NAME, dsSysDB ds)
        {
            dsSysDB.COLUMNSRow[] arrColumns = (dsSysDB.COLUMNSRow[])ds.COLUMNS.Select(ds.COLUMNS.TABLE_NAMEColumn.ColumnName + "='" + TABLE_NAME + "'");
            return arrColumns;
        }
        public static bool IsKeyInDb(string TABLE_NAME, string COLUMN_NAME, dsSysDB ds)
        {
            dsSysDB.SysKeyColumnUsageRow[] arrColumnIsKey = (dsSysDB.SysKeyColumnUsageRow[])ds.SysKeyColumnUsage.Select(ds.SysKeyColumnUsage.TABLE_NAMEColumn.ColumnName + "='" + TABLE_NAME + "'" + sqlTxt.and + ds.SysKeyColumnUsage.COLUMN_NAMEColumn.ColumnName + "='" + COLUMN_NAME + "'");
            if (arrColumnIsKey.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void getSysColumns(string tableName, dsSysDB ds, eTypSelColumns typSel, string ColumnName = "", string Application = "")
        {
            this.daColumns.SelectCommand.CommandText = sqlSysDB.Sel_daColumns;
            qs2.core.dbBase.setConnection(ref this.daColumns);
            this.daColumns.SelectCommand.Parameters.Clear();

            if (typSel == eTypSelColumns.table)
            {
                if (!tableName.Trim().Equals(""))
                {
                    string sWhere = sqlTxt.where + sqlTxt.getColWhere(ds.COLUMNS.TABLE_NAMEColumn.ColumnName);
                    this.daColumns.SelectCommand.CommandText += sWhere + " order by " + ds.COLUMNS.COLUMN_NAMEColumn .ColumnName + " asc";
                    this.daColumns.SelectCommand.Parameters.AddWithValue(ds.COLUMNS.TABLE_NAMEColumn.ColumnName, tableName);
                }
            }
            else if (typSel == eTypSelColumns.ColumnTablenameLike)
            {
                string sWhere = " where (TABLE_NAME like 'tblStay_" + Application.Trim() + "%' or TABLE_NAME='tblStay') and COLUMN_NAME = '" + ColumnName.Trim()  + "' ";
                string sOrderBy = " order by COLUMN_NAME asc, TABLE_NAME asc ";
                this.daColumns.SelectCommand.CommandText += sWhere + sOrderBy;
            }

            this.daColumns.Fill(ds.COLUMNS);
        }

        public void getTables(dsSysDB ds, eTypSelColumns typSel, string TableName)
        {
            this.daTables.SelectCommand.CommandText = sqlSysDB.Sel_daTables;
            qs2.core.dbBase.setConnection(ref this.daTables);

            if (typSel == eTypSelColumns.all)
            {
                string xy = "";
            }
            else if (typSel == eTypSelColumns.likeTableName)
            {
                string sWhere = " where TABLE_NAME like 'tblStay_" + TableName.Trim() + "%'";
                string sOrderBy = " order by TABLE_NAME asc ";
                this.daTables.SelectCommand.CommandText += sWhere + sOrderBy;
            }

            this.daTables.SelectCommand.Parameters.Clear();
            this.daTables.Fill(ds.TablesCatalog);

        }

        public void getSysAllPrimaryKeys(dsSysDB.SysKeyColumnUsageDataTable tSysPrimaryKeys)
        {
            this.daSysPrimaryKeys.SelectCommand.CommandText = sqlSysDB.sel_daSysAllPrimaryKeys;
            qs2.core.dbBase.setConnection(ref this.daSysPrimaryKeys);
            this.daSysPrimaryKeys.SelectCommand.Parameters.Clear();
            string sOrderBy = " ORDER BY T.TABLE_NAME asc, K.ORDINAL_POSITION asc ";
            this.daSysPrimaryKeys.SelectCommand.CommandText += sOrderBy;
            this.daSysPrimaryKeys.Fill(tSysPrimaryKeys);
        }
        public void getSysAllForeignKeys(dsSysDB.SysForeignKeysDataTable tSysForeignKeys)
        {
            this.daSysForeignKeys.SelectCommand.CommandText = sqlSysDB.sel_daSysAllForeignKeys;
            qs2.core.dbBase.setConnection(ref this.daSysForeignKeys);
            this.daSysForeignKeys.SelectCommand.Parameters.Clear();
            string sOrderBy = " order by 1,2,4";
            this.daSysForeignKeys.SelectCommand.CommandText += sOrderBy;
            this.daSysForeignKeys.Fill(tSysForeignKeys);
        }
        public void getSysComputedColumns(dsSysDB.SysComputedColumnsDataTable tSysComputedColumns)
        {
            this.daSysComputedColumns.SelectCommand.CommandText = sqlSysDB.sel_daSysComputedColumns;
            qs2.core.dbBase.setConnection(ref this.daSysComputedColumns);
            this.daSysComputedColumns.SelectCommand.Parameters.Clear();
            string sOrderBy = "";
            this.daSysComputedColumns.SelectCommand.CommandText += sOrderBy;
            this.daSysComputedColumns.Fill(tSysComputedColumns);
        }
        public void getSysAllIdentityColumns(dsSysDB.SysIdentityColumnsDataTable tSysIdentityColumns)
        {
                this.daSysIdentityColumns.SelectCommand.CommandText = sqlSysDB.sel_daSysIdentityColumns;
                qs2.core.dbBase.setConnection(ref this.daSysIdentityColumns);
                this.daSysIdentityColumns.SelectCommand.Parameters.Clear();
                string sOrderBy = " order by table_name asc, column_name asc ";
                this.daSysIdentityColumns.SelectCommand.CommandText += sOrderBy;
                this.daSysIdentityColumns.Fill(tSysIdentityColumns);
        }
    }
}
