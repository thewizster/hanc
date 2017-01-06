using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hanc.AspNetAPI.Models
{
    /// <summary>
    /// Example composable model. Auto loaded into HancContext.
    /// See Hanc.Common.Data.HancContext for details
    /// </summary>
    [Hanc.Common.HancModel]
    [Table("Hellos")]
    public class Hello
    {
        public int ID { get; set; }
        public string Message { get; set; }
    }
}
