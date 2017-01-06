using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webextant.Security.Cryptography;
using Microsoft.Extensions.Options;
using Hanc.Common.Options;

namespace Hanc.Common.Data.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SecretOptions _optionsAccessor;

        public ValuesController(IOptions<SecretOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Mac mac = new Mac(_optionsAccessor.MacSecret);
            var token = mac.GenerateToken("Hello World!");
            return new string[] { "Hello", "World", token };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
