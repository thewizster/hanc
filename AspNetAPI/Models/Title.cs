using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hanc.AspNetAPI.Models
{
    [Hanc.Common.HancModel]
    [Table("Titles")]
    public class Title
    {
        public int TitleID { get; set; }
        public string Name { get; set; }
        public string ForEntityName { get; set; }
    }
}
