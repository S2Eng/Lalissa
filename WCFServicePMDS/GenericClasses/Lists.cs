using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    public class Lists
    {

        public static List<T> getFirstFromDict<T>(List<KeyValuePair<DateTime, List<T>>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "Fct. getFirstFromDict: The Collection cannot be null");

            var valPair = collection.OrderByDescending(v => v.Key).First();
            return valPair.Value;
        }

        public static KeyValuePair<DateTime, List<T>> getFirstFromDict2<T>(List<KeyValuePair<DateTime, List<T>>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "Fct. getFirstFromDict2: The Collection cannot be null");

            var valPair = collection.OrderByDescending(v => v.Key).First();
            return valPair;
        }

        public static List<T> getFirstFromDictList<T>(System.Collections.Concurrent.ConcurrentDictionary<DateTime, List<T>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "Fct. getFirstFromDictList: The Collection cannot be null");

            var valPair = collection.OrderByDescending(v => v.Key).First();
            return valPair.Value;
        }
        
        public static DateTime getFirstFromDictKey<T>(System.Collections.Concurrent.ConcurrentDictionary<DateTime, List<T>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "Fct. getFirstFromDictKey: The Collection cannot be null");

            var valPair = collection.OrderByDescending(v => v.Key).First();
            return valPair.Key;
        }
        public static DateTime getFirstFromDictKey<T>(System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<T>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "Fct. getFirstFromDictKey: The Collection cannot be null");

            var valPair = collection.OrderByDescending(v => v.Key).First();
            return valPair.Key;
        }
        public static ConcurrentBag<T> getFirstFromDictConcBag<T>(System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<T>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection", "Fct. getFirstFromDictList: The Collection cannot be null");

            var valPair = collection.OrderByDescending(v => v.Key).First();
            return valPair.Value;
        }

    }

}

