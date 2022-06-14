using Chorus.Conductor.Sync;
using Newtonsoft.Json;
using System;

namespace AmcInterception
{
    [JsonObject(Title = "contact")]
    public class TestClass : SyncEntityBase, ISyncEntity
    {
        [JsonProperty(PropertyName = "Firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middlename")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "nickname")]
        public string NickName { get; set; }

        [JsonProperty(PropertyName = "birthdate")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty(PropertyName = "address1_city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "address1_composite")]
        public string FullAddress { get; set; }

        [JsonProperty(PropertyName = "address1_line1")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "address1_line2")]
        public string AddressSecondLine { get; set; }

        [JsonProperty(PropertyName = "address1_postalcode")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "address1_stateorprovince")]
        public string StateOrProvince { get; set; }

        [JsonProperty(PropertyName = "telephone1")]
        public string WorkPhone { get; set; }

        [JsonProperty(PropertyName = "telephone2")]
        public string HomePhone { get; set; }

        [JsonProperty(PropertyName = "mobilephone")]
        public string MobilePhone { get; set; }

        [JsonProperty(PropertyName = "emailaddress1")]
        public string PrimaryEmail { get; set; }

        [JsonProperty(PropertyName = "enc_school_id")]
        public string SchoolId { get; set; }
    }
}
