using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanc.AspNetAPI.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string EmailAddress { get; set; }
    }
}
