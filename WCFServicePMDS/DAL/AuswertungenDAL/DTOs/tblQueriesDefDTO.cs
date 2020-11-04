using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblQueriesDefDTO
    {
        public Guid Idguid { get; set; }
        public bool UserInput { get; set; }
        public bool FunctionPar { get; set; }
        public string Combination { get; set; }
        public string QryTable { get; set; }
        public string QryColumn { get; set; }
        public string CriteriaFldShort { get; set; }
        public string CriteriaApplication { get; set; }
        public bool IsSqlserverField { get; set; }
        public string Label { get; set; }
        public string ControlType { get; set; }
        public string Typ { get; set; }
        public string Condition { get; set; }
        public string ValueMin { get; set; }
        public string Max { get; set; }
        public string ValueMinIdres { get; set; }
        public string MaxIdres { get; set; }
        public string CombinationEnd { get; set; }
        public string FreeSql { get; set; }
        public int Sort { get; set; }
        public int IdselList { get; set; }
        public string ApplicationOwn { get; set; }
        public string ParticipantOwn { get; set; }
        public bool All { get; set; }
        public string SpecialDefinition { get; set; }
        public bool ComboAsDropDown { get; set; }
        public string ComboAsDropDownCondition { get; set; }
        public string SpecialDefinitionMax { get; set; }


    }

}

