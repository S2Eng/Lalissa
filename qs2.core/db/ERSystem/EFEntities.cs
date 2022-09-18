using PMDS.Global.db.ERSystem;
using PMDS.db.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace qs2.core.db.ERSystem
{

    public class EFEntities
    {

        private static IEnumerable<PMDS.db.Entities.tblSelListGroup> _tblSelListGroup = null;

        public static IEnumerable<PMDS.db.Entities.tblSelListGroup> tblSelListGroup
        {
            get
            {
                return EFEntities._tblSelListGroup;
            }
            set
            {
                EFEntities._tblSelListGroup = value;
            }
        }
        
        public static tblSelListGroup newtblSelListGroup(ERModellPMDSEntities db)
        {
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.tblSelListGroup newtblSelListGroup = new PMDS.db.Entities.tblSelListGroup();
                EFEntities1.EfNewRow(ref EFEntities.lstEfTables, db, newtblSelListGroup, newtblSelListGroup.GetType().Name, EFEntities.tblSelListGroup);
                return newtblSelListGroup;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.newtblSelListGroup: " + ex.ToString());
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblSelListEntries> _tblSelListEntries = null;

        public static IEnumerable<PMDS.db.Entities.tblSelListEntries> tblSelListEntries
        {
            get
            {
                return EFEntities._tblSelListEntries;
            }
            set
            {
                EFEntities._tblSelListEntries = value;
            }
        }
        
        public static tblSelListEntries newtblSelListEntries(ERModellPMDSEntities db)
        {
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.tblSelListEntries newtblSelListEntries = new PMDS.db.Entities.tblSelListEntries();
                EFEntities1.EfNewRow(ref EFEntities.lstEfTables, db, newtblSelListEntries, newtblSelListEntries.GetType().Name, EFEntities.tblSelListEntries);
                return newtblSelListEntries;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.newtblSelListEntries: " + ex.ToString());
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblSelListEntriesObj> _tblSelListEntriesObj = null;

        public static IEnumerable<PMDS.db.Entities.tblSelListEntriesObj> tblSelListEntriesObj
        {
            get
            {
                return EFEntities._tblSelListEntriesObj;
            }
            set
            {
                EFEntities._tblSelListEntriesObj = value;
            }
        }
        
        public static tblSelListEntriesObj newtblSelListEntriesObj(ERModellPMDSEntities db)
        {
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.tblSelListEntriesObj newtblSelListEntriesObj = new PMDS.db.Entities.tblSelListEntriesObj();
                EFEntities1.EfNewRow(ref EFEntities.lstEfTables, db, newtblSelListEntriesObj, newtblSelListEntriesObj.GetType().Name, EFEntities.tblSelListEntriesObj);
                return newtblSelListEntriesObj;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.newtblSelListEntriesObj: " + ex.ToString());
            }
        }

        private static IEnumerable<PMDS.db.Entities.Ressourcen> _Ressourcen = null;

        public static IEnumerable<PMDS.db.Entities.Ressourcen> Ressourcen
        {
            get
            {
                return EFEntities._Ressourcen;
            }
            set
            {
                EFEntities._Ressourcen = value;
            }
        }
        
        public static Ressourcen newRessourcen(ERModellPMDSEntities db)
        {
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.Ressourcen newRessourcen = new PMDS.db.Entities.Ressourcen();
                EFEntities1.EfNewRow(ref EFEntities.lstEfTables, db, newRessourcen, newRessourcen.GetType().Name, EFEntities.Ressourcen);
                return newRessourcen;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.newRessourcen: " + ex.ToString());
            }
        }

        private static IEnumerable<PMDS.db.Entities.tblCriteria> _tblCriteria = null;

        public static IEnumerable<PMDS.db.Entities.tblCriteria> tblCriteria
        {
            get
            {
                return EFEntities._tblCriteria;
            }
            set
            {
                EFEntities._tblCriteria = value;
            }
        }
        
        public static tblCriteria NewtblCriteria(ERModellPMDSEntities db)
        {
            try
            {
                EFEntities EFEntities1 = new ERSystem.EFEntities();
                PMDS.db.Entities.tblCriteria newCriteria = new PMDS.db.Entities.tblCriteria();
                EFEntities1.EfNewRow(ref EFEntities.lstEfTables, db, newCriteria, newCriteria.GetType().Name, EFEntities.tblCriteria);
                return newCriteria;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.newRessourcen: " + ex.ToString());
            }
        }




        public static System.Collections.Generic.Dictionary<string, efTable> lstEfTables = new System.Collections.Generic.Dictionary<string, efTable>();
        
        public static PMDS.db.Entities.ERModellPMDSEntities db = null;

        public static bool Isinitialized = false;

        public enum eTypeCol
        {
            tString = 0,
            tBoolean = 1,
            tInteger = 2,
            tDecimal1 = 3,
            tDateTime = 4,
            tGuid = 5,
            tImage = 6,
            tBinary = 7,
            tFloat = 8,
            tNumeric = 9,
        }



        public void Init2()
        {
            try
            {
                if (Isinitialized)
                    return;

                ERHelper helper = new ERHelper();

                EFEntities.db = businessFramework.getDBContext();
                this.InitMetadata(ref EFEntities.lstEfTables, db);
                
                EFEntities.Isinitialized = true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.init2: " + ex.ToString());
            }
        }

        public void InitMetadata(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
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
                    }
                    else
                    {
                        //lstTables.Add(tableName);
                    }
                }

                var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                var entityProps = (from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType);
                foreach (var entity in entityProps)
                {
                    var personRightStorageMetadata2 = (from m in entityProps where m.Name == entity.Name select m).Single();

                    efTable NewEfTable = new efTable();
                    NewEfTable.TableName = entity.Name;
                    NewEfTable.EntityType = entity;
                    lstTables.Add(NewEfTable.TableName, NewEfTable);

                    foreach (System.Data.Entity.Core.Metadata.Edm.EdmProperty infoCol in personRightStorageMetadata2.Properties)
                    {
                        eTypeCol TypeCol = new eTypeCol();
                        string tableName = "";
                        string colName = infoCol.Name;
                        bool IsNullable = infoCol.Nullable;

                        if (infoCol.Nullable)
                        {
                            IsNullable = true;
                        }

                        if (infoCol.PrimitiveType.ToString().EndsWith("varchar", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("varchar(max)", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("nchar", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("char", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("nvarchar(max)", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.PrimitiveType.ToString().EndsWith("text", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tString;
                        }
                        else if (infoCol.TypeName.EndsWith("bit", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tBoolean;
                        }
                        else if (infoCol.TypeName.EndsWith("int", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tInteger;
                        }
                        else if (infoCol.TypeName.EndsWith("float", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tFloat;
                        }
                        else if (infoCol.TypeName.EndsWith("numeric", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tNumeric;
                        }
                        else if (infoCol.TypeName.EndsWith("decimal", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDecimal1;
                        }
                        else if (infoCol.TypeName.EndsWith("datetime", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDateTime;
                        }
                        else if (infoCol.TypeName.EndsWith("datetime2", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDateTime;
                        }
                        else if (infoCol.TypeName.EndsWith("date", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tDateTime;
                        }
                        else if (infoCol.TypeName.EndsWith("uniqueidentifier", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tGuid;
                        }
                        else if (infoCol.TypeName.EndsWith("image"))
                        {
                            TypeCol = eTypeCol.tImage;
                        }
                        else if (infoCol.TypeName.EndsWith("varbinary(max)", StringComparison.CurrentCultureIgnoreCase))
                        {
                            TypeCol = eTypeCol.tBinary;
                        }
                        else
                        {
                            throw new Exception("Type '' not possible for Field '" + colName + "' in Table '" + tableName + "'!");
                            //bool TypeNotDefined = true;
                        }

                        efColumn newEfColumn = new efColumn();
                        newEfColumn.ColumnName = colName;
                        newEfColumn.IsNullable = IsNullable;
                        newEfColumn.typeCol = TypeCol;
                        newEfColumn.EdmProperty = infoCol;
                        NewEfTable.lstCols.Add(newEfColumn);
                    }
                }

                bool bOK = true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.initMetadata: " + ex.ToString());
            }
        }
        
        public void EfNewRow<T>(ref System.Collections.Generic.Dictionary<string, efTable> lstTables, PMDS.db.Entities.ERModellPMDSEntities db,
                                object itm, string TableName, IEnumerable<T> items,
                                System.Collections.Generic.Dictionary<string, string> lstColsChange = null)
        {
            try
            {
                ERHelper ERHelper = new ERHelper();
                efTable efTable;
                bool bFound = lstTables.TryGetValue(TableName, out efTable);
                if (!bFound)
                {
                    throw new Exception("EFEntities.efNewRow: Table '" + TableName.ToString() + "' not found!");
                }
                var properties = typeof(T).GetProperties();

                foreach (efColumn efColumn in efTable.lstCols)
                {
                    string ColNameTmp = efColumn.ColumnName;
                    if (lstColsChange != null)
                    {
                        string ColNameEF = "";
                        bool bFoundCol = lstColsChange.TryGetValue(ColNameTmp, out ColNameEF);
                        if (bFoundCol)
                        {
                            ColNameTmp = ColNameEF;
                        }
                    }

                    if (efColumn.IsNullable)
                    {
                        ERHelper.SetValueColumn6(null, itm, ColNameTmp, properties);
                    }
                    else
                    {
                        if (efColumn.typeCol == eTypeCol.tGuid)
                        {
                            System.Guid gEmptyGuid = new Guid("00100000-0000-1000-1000-123456789123");
                            ERHelper.SetValueColumn6(gEmptyGuid, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tString)
                        {
                            ERHelper.SetValueColumn6("", itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tInteger)
                        {
                            ERHelper.SetValueColumn6(0, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tDecimal1)
                        {
                            ERHelper.SetValueColumn6((Decimal)0, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tFloat)
                        {
                            ERHelper.SetValueColumn6((float)0, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tNumeric)
                        {
                            ERHelper.SetValueColumn6(0, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tBoolean)
                        {
                            ERHelper.SetValueColumn6(false, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tDateTime)
                        {
                            DateTime dat1900 = new DateTime(1900, 1, 1, 0, 0, 0);
                            ERHelper.SetValueColumn6(dat1900, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tImage)
                        {
                            Byte[] bytes = null;
                            ERHelper.SetValueColumn6(bytes, itm, ColNameTmp, properties);
                        }
                        else if (efColumn.typeCol == eTypeCol.tBinary)
                        {
                            Byte[] bytes = null;
                            ERHelper.SetValueColumn6(bytes, itm, ColNameTmp, properties);
                        }
                        else
                        {
                            throw new Exception("Type '' not possible for Field '" + ColNameTmp + "' in Table '" + efTable.TableName + "'!");
                        }
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("EFEntities.efNewRow: " + ex.ToString());
            }
        }

    }


    public class efTable
    {
        public string TableName = "";
        public System.Data.Entity.Core.Metadata.Edm.EntityType EntityType = null;
        public System.Collections.Generic.List<efColumn> lstCols = new List<efColumn>();
    }
    public class efColumn
    {
        public string ColumnName = "";
        public bool IsNullable = false;
        public EFEntities.eTypeCol typeCol;
        public System.Data.Entity.Core.Metadata.Edm.EdmProperty EdmProperty = null;
    }

}
