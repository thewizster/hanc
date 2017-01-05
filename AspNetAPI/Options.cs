using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanc.AspNetAPI
{
    /// <summary>
    /// The options pattern uses custom options classes to represent a group of related settings.
    /// See Startup.cs and ValuesController.cs for implimentation code
    /// </summary>
    public class SecretOptions
    {
        public SecretOptions()
        {
            MacSecret = "default_secret";
        }
        public string MacSecret { get; set; }
        public string AppId { get; set; }
        public bool RequireApiAuthToken { get; set; }
    }
    /// <summary>
    /// The options pattern uses custom options classes to represent a group of related settings.
    /// See Startup.cs and HelloController.cs for implimentation code
    /// </summary>
    public class HelloOptions
    {
        public HelloOptions()
        {
            HelloValue = "...";
        }
        public string HelloValue { get; set; }
    }
}
