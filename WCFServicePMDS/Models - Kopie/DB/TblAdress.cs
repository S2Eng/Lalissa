using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblAdress
    {
        public Guid Idguid { get; set; }
        public int CountryId { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhonePrivat { get; set; }
        public string PhoneBusiness { get; set; }
        public string PhoneMobil { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Fax { get; set; }
        public bool IsMainAdress { get; set; }
        public Guid IdguidObject { get; set; }

        public virtual TblObject IdguidObjectNavigation { get; set; }
    }
}