using PMDS.db.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using PMDS.db;



namespace PMDS.Global.db.ERSystem
{


    public class ERHelper
    {


        public object getValueColumn<T>(object item, string columName, IEnumerable<T> items)
        {
            try
            {
                //System.Type t = item.GetType();
                var properties = typeof(T).GetProperties();
                object oValue = null;
                foreach (var prop in properties)
                {
                    if (prop.Name.Trim().ToLower().Equals(columName.Trim().ToLower()))
                    {
                        string actColName = prop.Name;
                        var itemValue = prop.GetValue(item, new object[] { });
                        oValue = itemValue;
                        return oValue;
                        
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.getValueColumn: " + ex.ToString());
            }
        }
        public bool setValueColumn<T>(object valueToSet, object item, string columName, IEnumerable<T> items)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    if (prop.Name.Trim().ToLower().Equals(columName.Trim().ToLower()))
                    {
                        //object[] arrObj = new object[] { valueToSet };
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setValueColumn: columName '" + columName.Trim() + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setValueColumn: " + ex.ToString());
            }
        }
        public bool setValueColumn6(object valueToSet, object item, string columName, System.Reflection.PropertyInfo[] properties)
        {
            try
            {
                foreach (var prop in properties)
                {
                    if (prop.Name.Trim().ToLower().Equals(columName.Trim().ToLower()))
                    {
                        //object[] arrObj = new object[] { valueToSet };
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setValueColumn: columName '" + columName.Trim() + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setValueColumn: " + ex.ToString());
            }
        }
        public bool setValueColumn2<T>(object valueToSet, object item, string columName, IEnumerable<T> items)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    if (prop.Name.Trim().ToLower().Equals(columName.Trim().ToLower()))
                    {
                        //object[] arrObj = new object[] { valueToSet };
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setValueColumn: columName '" + columName.Trim() + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setValueColumn: " + ex.ToString());
            }
        }
        public bool setDefaultValueColumn<T>(object valueToSet, object item, string columName, IEnumerable<T> items, System.Data.Entity.Core.Metadata.Edm.EdmProperty col)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    if (prop.Name.Trim().ToLower().Equals(columName.Trim().ToLower()))
                    {
                        //object[] arrObj = new object[] { valueToSet };
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setDefaultValueColumn: columName '" + columName.Trim() + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setDefaultValueColumn: " + ex.ToString());
            }
        }


        public object convertTo<T>(IEnumerable<T> items)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                //var result = new DataTable();
                //foreach (var prop in properties)
                //{
                //    result.Columns.Add(prop.Name, prop.PropertyType);
                //}

                object oValue = null;
                foreach (var item in items)
                {
                    //var row = result.NewRow();
                    foreach (var prop in properties)
                    {
                        string actColName = prop.Name;
                        var itemValue = prop.GetValue(item, new object[] { });
                        //row[prop.Name] = itemValue;
                    }
                    //result.Rows.Add(row);
                }

                return oValue;

            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.convertTo: " + ex.ToString());
            }
        }

        public void getInfoTable(string TableName)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                    var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                    var entityProps = (from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType);
                    var personRightStorageMetadata = (from m in entityProps where m.Name == TableName.Trim() select m).Single();
                    foreach (System.Data.Entity.Core.Metadata.Edm.EdmProperty item in personRightStorageMetadata.Properties)
                    {
                        string Name = item.Name;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.getInfoTable: " + ex.ToString());
            }
        }

        public void getInfoColumns(string TableNameTmp, ref System.Collections.Generic.List<System.Data.Entity.Core.Metadata.Edm.EdmProperty> cols)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                    var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                    var entityProps = (from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType);
                    foreach (var item in entityProps)
                    {
                        string xyxy = "";
                    }
                    var personRightStorageMetadata = (from m in entityProps where m.Name == TableNameTmp.Trim() select m).Single();
                    foreach (System.Data.Entity.Core.Metadata.Edm.EdmProperty item in personRightStorageMetadata.Properties)
                    {
                        cols.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.getInfoColumns: " + ex.ToString());
            }
        }










        public System.Data.Entity.Infrastructure.DbRawSqlQuery<Recht> TemplateSqlCommandInEntityFramework(int right, Guid IDBenutzer, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                DbParameter[] args = new DbParameter[]
                {
                    //new SqlParameter {ParameterName="Recht", Value=right.ToString(), DbType= DbType.Int32, SourceColumn= "@ID"}
                };
                string strSQl = "SELECT r.id FROM Benutzer b " +
                                    "INNER JOIN BenutzerGruppe bg ON b.ID = bg.IDBenutzer " +
                                    "INNER JOIN Gruppe g ON bg.IDGruppe = g.ID " +
                                    "INNER JOIN Gruppenrecht gr ON gr.IDGruppe = g.ID " +
                                    "INNER JOIN Recht r ON gr.IDRecht = r.ID " +
                                    "WHERE r.ID = " + right.ToString() + " AND b.ID = '" + IDBenutzer.ToString() + "'";
                System.Data.Entity.Infrastructure.DbRawSqlQuery<Recht> resTRecht = db.Database.SqlQuery<Recht>(strSQl, args);
                return resTRecht;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.TemplateSqlCommandInEntityFramework: " + ex.ToString());
            }
        }
        public void TemplateSqlCommandInEntityFramework2(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string strSQl = "Select ID, Benutzer from Benutzer where Eintrittsdatum=@Eintrittsdatum";  //"SELECT nr, year FROM dbo.rechNr where nr=@nr";
                DateTime dat = new DateTime(2015, 4, 23, 0, 0, 0);
                DbParameter[] pars = new DbParameter[]
                {
                    new SqlParameter {ParameterName="Eintrittsdatum", Value=dat, DbType= DbType.Date, SourceColumn= "@Eintrittsdatum"}
                };
                IEnumerable<vBenutzer> t = db.Database.SqlQuery<vBenutzer>(strSQl, pars);
                foreach (vBenutzer r in t)
                {
                    string xyxy = "";
                }

                bool bOK = true;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusiness.TemplateSqlCommandInEntityFramework: " + ex.ToString());
            }
        }

        public void testMetyEF(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            string FctName = "PMDSBusiness.testMetyEF";
            int FctNr = 257000950;
            try
            {
                System.Collections.Generic.List<string> lstTables = new List<string>();

                var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;
                var tables = metadata.GetItemCollection(DataSpace.SSpace)
                    .GetItems<EntityContainer>()
                    .Single()
                    .BaseEntitySets
                    .OfType<EntitySet>()
                    .Where(s => !s.MetadataProperties.Contains("Type")
                    || s.MetadataProperties["Type"].ToString() == "Tables");

                foreach (var table in tables)
                {
                    var tableName = table.MetadataProperties.Contains("Table")
                        && table.MetadataProperties["Table"].Value != null
                        ? table.MetadataProperties["Table"].Value.ToString()
                        : table.Name;

                    if (table.MetadataProperties["Schema"].Value != null)
                    {
                        var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
                        lstTables.Add(tableSchema + "." + tableName);
                        if (tableName.Trim() == "ZusatzWert")
                        {
                            bool sStop = true;
                        }
                    }
                    else
                    {
                        lstTables.Add(tableName);
                    }
                }
                foreach (string TableName in lstTables)
                {
                    object oType2 = typeof(PMDS.db.Entities.Patient);
                    var infoPatient2 = typeof(PMDS.db.Entities.Patient).GetProperties();

                    var entityProperty6 = db.GetType().GetProperties().Where(t => t.Name == TableName);
                    if ((entityProperty6 != null))
                    {
                        foreach (System.Reflection.PropertyInfo propTable in entityProperty6)
                        {
                            string xy = propTable.Name;
                            var infoPatientxy = propTable.GetType().GetProperties();
                            foreach (System.Reflection.PropertyInfo infoCol in infoPatientxy)
                            {
                                string xyxyxy = "";
                            }
                        }
                    }
                }


                var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                var entityProps = (from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType);
                foreach (var item in entityProps)
                {
                    string xyxy = "";
                    var personRightStorageMetadata2 = (from m in entityProps where m.Name == item.Name.Trim() select m).Single();
                    foreach (System.Data.Entity.Core.Metadata.Edm.EdmProperty item2 in personRightStorageMetadata2.Properties)
                    {

                    }
                }



                System.Guid newGuid = System.Guid.NewGuid();
                IEnumerable<PMDS.db.Entities.Patient> tPatientTmp1 = (IEnumerable<PMDS.db.Entities.Patient>)(from p in db.Patient.AsEnumerable()
                                                                                                             where p.ID == newGuid
                                                                                                             select p);

                object oType = typeof(PMDS.db.Entities.Patient);
                var infoPatient4 = typeof(PMDS.db.Entities.Patient).GetProperties();
                var infoPatient = tPatientTmp1.GetType().GetProperties();            //typeof(PMDS.db.Entities.Patient).GetProperties();

                var entityProperty4 = db.GetType().GetProperties().Where(t => t.Name == "Patient");
                if ((entityProperty4 != null))
                {
                    foreach (System.Reflection.PropertyInfo propTable in entityProperty4)
                    {
                        string xy = "";
                    }
                }


                PMDS.Global.db.ERSystem.ERHelper ERHelper1 = new PMDS.Global.db.ERSystem.ERHelper();
                //ERHelper1.getInfoTable("Patient");
                System.Collections.Generic.List<System.Data.Entity.Core.Metadata.Edm.EdmProperty> cols = new List<System.Data.Entity.Core.Metadata.Edm.EdmProperty>();
                ERHelper1.getInfoColumns("Patient", ref cols);

                IEnumerable<PMDS.db.Entities.Patient> tPatientTmp = (IEnumerable<PMDS.db.Entities.Patient>)(from p in db.Patient.AsEnumerable()
                                                                                                            where p.ID == System.Guid.NewGuid()
                                                                                                            select p);
                PMDS.db.Entities.Patient newPatient = new PMDS.db.Entities.Patient();
                foreach (System.Data.Entity.Core.Metadata.Edm.EdmProperty col in cols)
                {
                    string sGuid = System.Guid.NewGuid().ToString();
                    ERHelper1.setValueColumn2(sGuid, newPatient, col.Name.Trim(), tPatientTmp);
                }

                PMDS.db.Entities.Patient pat = new PMDS.db.Entities.Patient();
                System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatient = db.Patient.Where(o => o.Nachname != "xy");
                foreach (PMDS.db.Entities.Patient rPatient in tPatient)
                {
                    string sGuid = System.Guid.NewGuid().ToString();
                    var oValCol = ERHelper1.getValueColumn(rPatient, "Nachname", tPatient);
                    ERHelper1.setValueColumn(sGuid, rPatient, "Nachname", tPatient);
                    string xy = "OK";
                }
                ERHelper1.convertTo(tPatient);

                IEnumerable<PMDS.db.Entities.Patient> iPatient = (IEnumerable<PMDS.db.Entities.Patient>)(from p in db.Patient.AsEnumerable()
                                                                                                         where p.Nachname != "xy"
                                                                                                         select p);
                foreach (PMDS.db.Entities.Patient rPatient in iPatient)
                {
                    var oValCol = ERHelper1.getValueColumn(rPatient, "Nachname", iPatient);
                    string xy = "OK";
                }

                System.Collections.Generic.List<PMDS.db.Entities.Patient> result = tPatient.ToList();
                IDictionary<Guid, string> dic = tPatient.ToDictionary(row => row.ID, row => row.Nachname);
                DbSet<PMDS.db.Entities.Patient> entities = db.Patient;


                string sResult = "OK";
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }

        public void getDbObjectes_old(PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                var metadata = ((IObjectContextAdapter)DBContext).ObjectContext.MetadataWorkspace;
                //var query = from meta in metadata.GetItemCollection(DataSpace.SSpace)
                //            where meta.BuiltInTypeKind == BuiltInTypeKind.EntityType
                //            select (meta as EntityType).Name;

                //var queryxyxy = from meta in metadata.GetItems(DataSpace.OSpace)
                //    .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                //                let properties = meta is EntityType ? (meta as EntityType).Properties : null
                //                select new
                //                {
                //                    TableName = (meta as EntityType).Name,
                //                    Fields = from p in properties
                //                             select new
                //                             {
                //                                 FielName = p.Name,
                //                                 DbType = p.TypeUsage.EdmType.Name
                //                             }
                //                };

                var infoInterventionen = typeof(PMDS.db.Entities.Patient).GetProperties();
                foreach (System.Reflection.PropertyInfo infoCol in infoInterventionen)
                {

                    string ab = infoCol.Name;
                    string xType = infoCol.Name.GetType().Name;

                }


                string abxy = "";

                //IEnumerable<FieldList> properties = from p in typeof(T).GetProperties()
                //                                    where (from a in p.GetCustomAttributes(false)
                //                                           where a is EdmScalarPropertyAttribute
                //                                           select true).FirstOrDefault()
                //                                    select new FieldList
                //                                    {
                //                                        FieldName = p.Name,
                //                                        FieldType = p.PropertyType,
                //                                        FieldPK = p.GetCustomAttributes(false).Where(a => a is EdmScalarPropertyAttribute && ((EdmScalarPropertyAttribute)a).EntityKeyProperty).Count() > 0
                //                                    }; 

                //pmds context = new DataClasses1DataContext();
                //var datamodel = context.Mapping;

                DbSet<PMDS.db.Entities.Patient> entities = DBContext.Patient;

                //string parmList = "Surname, Firstname, Address.Postcode";
                //var customers = entities.Select("Address.Postcode");

                //foreach (var r in datamodel.GetTables())
                //{

                //    if (r.TableName.Equals("dbo.Person", StringComparison.InvariantCultureIgnoreCase))
                //    {
                //        foreach (var r1 in r.RowType.DataMembers)
                //        {
                //            string xy = r1.MappedName;
                //        }
                //    }

                //}

                //var tables = metadata.GetItemCollection(DataSpace.OCSpace)
                //  .GetItems<EntityContainer>()
                //  .Single()
                //  .BaseEntitySets
                //  .OfType<EntitySet>()
                //  .Where(s => !s.MetadataProperties.Contains("Type")
                //    || s.MetadataProperties["Type"].ToString() == "Tables");

                //foreach (var table in tables)
                //{
                //    var tableName = table.MetadataProperties.Contains("Table")
                //        && table.MetadataProperties["Table"].Value != null
                //      ? table.MetadataProperties["Table"].Value.ToString()
                //      : table.Name;

                //    var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
                //    string sTableName = tableSchema + "." + tableName;

                //    var result = metadata.GetItems<EntityType>(DataSpace.OSpace);
                //    var obj = result.Single(x => x.Name == tableName);
                //    foreach (object col in obj.Members)
                //    {
                //        string xyxy = "";
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.getDbObjectes: " + ex.ToString());
            }
        }

        public DataTable ConvertToDataTable2(object obj)
        {
            // Retrieve the entities property info of all the properties
            PropertyInfo[] pInfos = obj.GetType().GetProperties();

            // Create the new DataTable
            var table = new DataTable();

            // Iterate on all the entities' properties
            foreach (PropertyInfo pInfo in pInfos)
            {
                // Create a column in the DataTable for the property
                table.Columns.Add(pInfo.Name, pInfo.GetType());
            }

            // Create a new row of values for this entity
            DataRow row = table.NewRow();
            // Iterate again on all the entities' properties
            foreach (PropertyInfo pInfo in pInfos)
            {
                // Copy the entities' property value into the DataRow
                row[pInfo.Name] = pInfo.GetValue(obj, null);
            }

            // Return the finished DataTable
            return table;
        }
        //public DataTable CopyGenericToDataTable<T>(this IEnumerable<T> items)
        //{
        //    var properties = typeof(T).GetProperties();
        //    var result = new DataTable();

        //    //Build the columns
        //    foreach (var prop in properties)
        //    {
        //        result.Columns.Add(prop.Name, prop.PropertyType);
        //    }

        //    //Fill the DataTable
        //    foreach (var item in items)
        //    {
        //        var row = result.NewRow();

        //        foreach (var prop in properties)
        //        {
        //            var itemValue = prop.GetValue(item, new object[] { });
        //            row[prop.Name] = itemValue;
        //        }

        //        result.Rows.Add(row);
        //    }

        //    return result;
        //}

    }

}
