using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hanc.AspNetAPI.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        private readonly HelloOptions _optionsAccessor;

        public HelloController(IOptions<HelloOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        // GET: /<controller>/
        public string Index()
        {
            return _optionsAccessor.HelloValue;
        }
    }
}
