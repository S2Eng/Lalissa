using System;
using System.Collections.Generic;


namespace PMDS.Global.db.ERSystem
{

    public class ERHelper
    {

        public object GetValueColumn<T>(object item, string columName, IEnumerable<T> items)
        {
            try
            {
                //System.Type t = item.GetType();
                var properties = typeof(T).GetProperties();
                object oValue = null;
                foreach (var prop in properties)
                {
                    if (prop.Name.Equals(columName))
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
        
        public bool SetValueColumn<T>(object valueToSet, object item, string columName, IEnumerable<T> items)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    if (prop.Name.Equals(columName))
                    {
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setValueColumn: columName '" + columName + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setValueColumn: " + ex.ToString());
            }
        }
        
        public bool SetValueColumn6(object valueToSet, object item, string columName, System.Reflection.PropertyInfo[] properties)
        {
            try
            {
                foreach (var prop in properties)
                {
                    if (prop.Name.Equals(columName))
                    {
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setValueColumn: columName '" + columName + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setValueColumn: " + ex.ToString());
            }
        }
        
        public bool SetValueColumn2<T>(object valueToSet, object item, string columName, IEnumerable<T> items)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    if (prop.Name.Equals(columName))
                    {
                        //object[] arrObj = new object[] { valueToSet };
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setValueColumn: columName '" + columName + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setValueColumn: " + ex.ToString());
            }
        }
        
        public bool SetDefaultValueColumn<T>(object valueToSet, object item, string columName, IEnumerable<T> items, System.Data.Entity.Core.Metadata.Edm.EdmProperty col)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    if (prop.Name.Equals(columName))
                    {
                        prop.SetValue(item, valueToSet, null);
                        return true;
                    }
                }

                throw new Exception("setDefaultValueColumn: columName '" + columName + "' not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.setDefaultValueColumn: " + ex.ToString());
            }
        }

        public object ConvertTo<T>(IEnumerable<T> items)
        {
            try
            {
                var properties = typeof(T).GetProperties();

                object oValue = null;
                foreach (var item in items)
                {
                    foreach (var prop in properties)
                    {
                        string actColName = prop.Name;
                        var itemValue = prop.GetValue(item, new object[] { });
                        //row[prop.Name] = itemValue;
                    }
                }

                return oValue;

            }
            catch (Exception ex)
            {
                throw new Exception("ERHelper.convertTo: " + ex.ToString());
            }
        }

    }

}
