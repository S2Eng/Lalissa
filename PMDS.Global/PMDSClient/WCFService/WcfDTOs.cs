using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMDS.Global.PMDSClient.WCFService
{

    public class WcfDTOs
    {

        private static ConcurrentDictionary<DateTime, WCFServicePMDS.BAL.Main.StammdatenDTO.lastStammdaten> _sd = new ConcurrentDictionary<DateTime, WCFServicePMDS.BAL.Main.StammdatenDTO.lastStammdaten>();
        private static ConcurrentDictionary<DateTime, List<WCFServicePMDS.BAL.Main.BenutzerMainDTO.BenutzerDt>> _ben = new ConcurrentDictionary<DateTime, List<WCFServicePMDS.BAL.Main.BenutzerMainDTO.BenutzerDt>>();
        private static WCFServicePMDS.BAL.Main.BenutzerMainDTO.lastBenutzer _benTables = new WCFServicePMDS.BAL.Main.BenutzerMainDTO.lastBenutzer();
        private static ConcurrentDictionary<DateTime, List<WCFServicePMDS.BAL.Main.PatientMainDTO.PatientDt>> _pat = new ConcurrentDictionary<DateTime, List<WCFServicePMDS.BAL.Main.PatientMainDTO.PatientDt>>();
        private static WCFServicePMDS.BAL.Main.PatientMainDTO.lastPatienten _patTables = new WCFServicePMDS.BAL.Main.PatientMainDTO.lastPatienten();




        public static ConcurrentDictionary<DateTime, WCFServicePMDS.BAL.Main.StammdatenDTO.lastStammdaten> sd
        {
            get => _sd;
            set => _sd = value;

        }
        public static ConcurrentDictionary<DateTime, List<WCFServicePMDS.BAL.Main.BenutzerMainDTO.BenutzerDt>> ben
        {
            get => _ben;
            set => _ben = value;
        }
        public static WCFServicePMDS.BAL.Main.BenutzerMainDTO.lastBenutzer benTables
        {
            get => _benTables;
            set => _benTables = value;
        }
        public static ConcurrentDictionary<DateTime, List<WCFServicePMDS.BAL.Main.PatientMainDTO.PatientDt>> pat
        {
            get => _pat;
            set => _pat = value;
        }
        public static WCFServicePMDS.BAL.Main.PatientMainDTO.lastPatienten patTables
        {
            get => _patTables;
            set => _patTables = value;
        }
    }


}
