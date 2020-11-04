using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Concurrent;

namespace WCFServicePMDS
{




    public class PropertyCopier<TParent, TChild> where TParent : class
                                    where TChild : class
    {
        public static void Copy(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }
    }


    public class Mapping
    {

        private const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty;


        public static List<T> MergeListData<T>(List<object> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Collection", "The Collection that you are copying to cannot be null");

            List<T> result = new List<T>();

            for (int x = 0; x < collection.Count; x++)
            {
                var target = (T)Activator.CreateInstance(typeof(T));
                var propInfos = collection[x].GetType().GetProperties(flags);
                for (int i = 0; i < propInfos.Length; i++)
                {
                    try
                    {
                        PropertyInfo _propinfo = target.GetType().GetProperty(propInfos[i].Name, flags);

                        if (_propinfo != null)
                        {
                            _propinfo.SetValue(target, propInfos[i].GetValue(collection[x]));
                            //_propinfo.SetValue(target, Nullable.GetUnderlyingType(propInfos[i].PropertyType) ?? propInfos[i].GetValue(collection[x]));
                        }
                    }
                    //catch (ArgumentException aex) { if (!string.IsNullOrEmpty(aex.Message)) continue; }
                    //catch (Exception ex) { if (!string.IsNullOrEmpty(ex.Message)) return default(List<T>); }
                    catch (ArgumentException aex) { throw aex; }
                    catch (Exception ex) { throw ex; }
                }
                result.Add(target);
            }
            return result;
        }

        public static ConcurrentBag<T> MergeListData2<T>(List<object> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Collection", "The Collection that you are copying to cannot be null");

            ConcurrentBag<T> result = new ConcurrentBag<T>();

            for (int x = 0; x < collection.Count; x++)
            {
                var target = (T)Activator.CreateInstance(typeof(T));
                var propInfos = collection[x].GetType().GetProperties(flags);
                for (int i = 0; i < propInfos.Length; i++)
                {
                    try
                    {
                        PropertyInfo _propinfo = target.GetType().GetProperty(propInfos[i].Name, flags);

                        if (_propinfo != null)
                        {
                            _propinfo.SetValue(target, propInfos[i].GetValue(collection[x]));
                            //_propinfo.SetValue(target, Nullable.GetUnderlyingType(propInfos[i].PropertyType) ?? propInfos[i].GetValue(collection[x]));
                        }
                    }
                    //catch (ArgumentException aex) { if (!string.IsNullOrEmpty(aex.Message)) continue; }
                    //catch (Exception ex) { if (!string.IsNullOrEmpty(ex.Message)) return default(List<T>); }
                    catch (ArgumentException aex) { throw aex; }
                    catch (Exception ex) { throw ex; }
                }
                result.Add(target);
            }
            return result;

        }
        public static void setValProp<T>(T o, string sVar, string sValue, bool decrypt = false)
        {
            qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();

            //var target = (T)Activator.CreateInstance(typeof(T));
            var propInfos = o.GetType().GetProperties(flags);
            for (int i = 0; i < propInfos.Length; i++)
            {
                try
                {
                    string propertyName = propInfos[i].Name;
                    if (propertyName.Equals(sVar, StringComparison.OrdinalIgnoreCase))
                    {
                        PropertyInfo propertyInfo = o.GetType().GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                            if (t == typeof(bool))
                            {
                                bool oVal;
                                if (sValue.Equals("1"))
                                    propertyInfo.SetValue(o, true, null);
                                else if (sValue.Equals("0"))
                                    propertyInfo.SetValue(o, false, null);
                                else if (sValue.Trim().ToLower().Equals("on"))
                                    propertyInfo.SetValue(o, true, null);
                                else if (sValue.Trim().ToLower().Equals("off"))
                                    propertyInfo.SetValue(o, false, null);
                                else
                                {
                                    if (bool.TryParse(sValue, out oVal))
                                        propertyInfo.SetValue(o, oVal, null);
                                    else
                                        propertyInfo.SetValue(o, false, null);
                                }
                            }
                            else if (t == typeof(string))
                            {
                                if (!string.IsNullOrEmpty(sValue))
                                    if (decrypt)
                                        propertyInfo.SetValue(o, Encryption1.StringDecrypt(sValue.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings), null);
                                    else
                                        propertyInfo.SetValue(o, sValue.Trim(), null);
                                else
                                    propertyInfo.SetValue(o, "", null);
                            }
                            else if (t == typeof(int))
                            {
                                int oVal;
                                if (int.TryParse(sValue, out oVal))
                                    propertyInfo.SetValue(o, oVal, null);
                                else
                                    propertyInfo.SetValue(o, 0, null);
                            }
                            else if (t == typeof(double))
                            {
                                double oVal;
                                if (double.TryParse(sValue, out oVal))
                                    propertyInfo.SetValue(o, oVal, null);
                                else
                                    propertyInfo.SetValue(o, 0, null);
                            }
                            else if (t == typeof(decimal))
                            {
                                decimal oVal;
                                if (decimal.TryParse(sValue, out oVal))
                                    propertyInfo.SetValue(o, oVal, null);
                                else
                                    propertyInfo.SetValue(o, 0, null);
                            }
                            else
                                throw new TypeAccessException("typeof(T) '" + typeof(T).ToString() + "' not allowed", new Exception("Error function setValProp<T>("));


                            //object safeValue = (sValue == null) ? null : System.Convert.ChangeType(sValue, t);
                            //propertyInfo.SetValue(o, safeValue, null);
                        }
                    }
                }
                catch (ArgumentException aex) { throw aex; }
                catch (Exception ex) { throw ex; }
            }
        }







        public static TOut Convert<TOut, TIn>(TIn fromRecord) where TOut : new()
        {
            var toRecord = new TOut();
            PropertyInfo[] fromFields = null;
            PropertyInfo[] toFields = null;

            fromFields = typeof(TIn).GetProperties();
            toFields = typeof(TOut).GetProperties();

            foreach (var fromField in fromFields)
            {
                foreach (var toField in toFields)
                {
                    if (fromField.Name == toField.Name)
                    {
                        toField.SetValue(toRecord, fromField.GetValue(fromRecord, null), null);
                        break;
                    }
                }

            }
            return toRecord;
        }

        public bool ReflectiveEquals(object first, object second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            Type firstType = first.GetType();
            if (second.GetType() != firstType)
            {
                return false; // Or throw an exception
            }
            // This will only use public properties. Is that enough?
            foreach (PropertyInfo propertyInfo in firstType.GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    object firstValue = propertyInfo.GetValue(first, null);
                    object secondValue = propertyInfo.GetValue(second, null);
                    if (!object.Equals(firstValue, secondValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void IterateProperties(Type t1, Type t2)
        {
            PropertyInfo[] properties1 = t1.GetProperties();
            PropertyInfo[] properties2 = t2.GetProperties();

            foreach (PropertyInfo pi1 in properties1)
            {
                foreach (PropertyInfo pi2 in properties2)
                {
                    if (pi1.Name.Equals(pi2.Name))
                    {

                    }
                }
            }


            //foreach (Benutzer r in varBen)
            //{
            //    string txtTmp = r.Vorname.Trim();
            //    PropertyInfo[] rProp = r.GetType().GetProperties();
            //    BenutzerDTO rNewBen = new BenutzerDTO();
            //    PropertyInfo[] rNewProp = rNewBen.GetType().GetProperties();
            //    foreach (PropertyInfo rPropInfo in rProp)
            //    {
            //        object rPropVal = rPropInfo.GetValue(r);
            //        //rNewProp.SetValue(rPropVal, )

            //        rNewProp

            //        foreach (PropertyInfo rPropNew in rNewProp)
            //        {
            //            if (rPropInfo.Name.Equals(rPropNew.Name))
            //            {

            //            }
            //        }
            //    }
            //    benDto.Add(rNewBen);
            //}

            //List<BenutzerDTO> targetList3 = varBen.Select(o => new BenutzerDTO()).ToList();
            //List<BenutzerDTO> targetList4 = new List<BenutzerDTO>(varBen.Cast<BenutzerDTO>());
            //benDto = varBen.ConvertAll(x => (BenutzerDTO)x);


            //Mapper.Initialize();
            //benDto = (List<BenutzerDTO>)Mapper.Map(varBen, typeof(List<Benutzer>), typeof(List<BenutzerDTO>));


            //DbModelBuilder modelBuilder = new DbModelBuilder();
            //Mapper.Map<Address, AddressDTO>();
            //Mapping.Convert(benDto, varBen);

        }

    }

}
