using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Hanc.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Hanc.AspNetAPI.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        private readonly HelloOptions _optionsAccessor;
        private readonly HancContext _context;
        private readonly DbSet<Models.Hello> _hellos;

        public HelloController(IOptions<HelloOptions> optionsAccessor, HancContext context)
        {
            _optionsAccessor = optionsAccessor.Value;
            _context = context;
            _hellos = context.Set<Models.Hello>();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Models.Hello> messages = new List<Models.Hello>();
            // add options value from appsettings.json
            messages.Add(new Models.Hello { Message = _optionsAccessor.HelloValue });
            // Add values from dbcontext
            messages.AddRange(_hellos.ToList());

            return Ok(messages);
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Models.Hello hello)
        {
            var newHello =_hellos.Add(hello);
            _context.SaveChanges();
            return Ok(newHello.Entity);
        }
    }
}
