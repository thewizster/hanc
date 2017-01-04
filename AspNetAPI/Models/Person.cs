using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanc.AspNetAPI.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public int? OrganizationID { get; set; }
        public Organization Organization { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
