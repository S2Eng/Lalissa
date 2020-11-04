using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS.TestUnits
{

    public class TestDTO
    {

        private static ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerDt>> _lAll;
        public static ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerDt>> lAll
        {
            get => _lAll;
            set => _lAll = value;
        }


        [Serializable()]
        public class BenutzerDt  
        {
            public string IDBenutzer;
            public AerztDt aerzt;
            public List<AerztDt> lBereich;

            public DateTime DtoFrom { get; set; }

            public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
            {
                info.AddValue("IDBenutzer", IDBenutzer);
                info.AddValue("aerzt", aerzt);
                info.AddValue("lBereich", lBereich);
            }
        }

        [Serializable()]
        public class AerztDt 
        {
            public DateTime DtoFrom { get; set; }

            public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
            {
                info.AddValue("DtoFrom", DtoFrom);
            }
        }


    }
}
