using Microsoft.Win32.SafeHandles;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace qs2.core.BAL
{
    public class ImpExpStayKey : IDisposable
    {
        private bool Disposed { get; set; } = false;
        private SafeHandle Handle { get; } = new SafeFileHandle(IntPtr.Zero, true);
        private SqlConnection Connection { get; set; }
        private SqlServerCompiler Compiler { get; set; } = new SqlServerCompiler();
        private QueryFactory Db { get; set; }
        private string IDApplication { get; set; }
        private string IDParticipant { get; set; }
        private const string DBSchema = "qs2.";

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                Handle.Dispose();
            }
            Disposed = true;
        }

        public void Init(string pIDApplication, string pIDParticipant)
        {
            qs2.core.db.ERSystem.businessFramework b = new qs2.core.db.ERSystem.businessFramework();
            Connection = new SqlConnection(b.GetConnectionString());
            Db = new QueryFactory(Connection, Compiler);
            IDApplication = pIDApplication;
            IDParticipant = pIDParticipant;
        }

        public int SetValue(int ID, string FldShort, string NewValue)
        {
            return Db.Query(GetSourceTable(FldShort)).Where("ID", ID).Where("IDApplication", IDApplication).Where("IDParticipant", IDParticipant).Update(new Dictionary<string, object>() { { FldShort, NewValue } });
        }

        public object GetValue(int ID, string FldShort)
        {

            dynamic tblRow = Db.Query(GetSourceTable(FldShort)).Select(FldShort).Where("ID", ID).Where("IDApplication", IDApplication).Where("IDParticipant", IDParticipant).Get();
            foreach (var rows in tblRow)
            {
                var fields = rows as IDictionary<string, object>;
                return fields[FldShort];
            }
            return null;
        }

        private string GetSourceTable(string FldShort)
        {
            dynamic tblNameRow = Db.Query("qs2.tblCriteria").Select("SourceTable").Where("FldShort", FldShort).Where("IDApplication", IDApplication).Get();

            if (tblNameRow.Count == 0)
                tblNameRow = Db.Query("qs2.tblCriteria").Select("SourceTable").Where("FldShort", FldShort).Where("IDApplication", "ALL").Get();

            if (tblNameRow.Count == 1)
            {
                foreach (var rows in tblNameRow)
                {
                    var fields = rows as IDictionary<string, object>;
                    return DBSchema + fields["SourceTable"];
                }
            }

            return DBSchema + "tblStay";   //Default
        }
    }
}
