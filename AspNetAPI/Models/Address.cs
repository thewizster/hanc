using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanc.AspNetAPI.Models
{
    public enum AddressType
    {
        Business, Residential
    }
    public class Address
    {
        public int AddressID { get; set; }
        public int? PersonID { get; set; }
        public int? OrganizationID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string PostOfficeBoxNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postalcode { get; set; }
        public AddressType? Type { get; set; }
        public Person Person { get; set; }
        public Organization Organization { get; set; }
    }
}
