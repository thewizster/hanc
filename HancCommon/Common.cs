using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanc.Common
{
    /// <summary>
    /// Models with this attribute will be auto loaded into HancContext
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HancModel : Attribute
    {
    }
}

namespace Hanc.Common.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyModel;
    using Microsoft.DotNet.InternalAbstractions;
    using System.Reflection;

    /// <summary>
    /// Default DbContext
    /// </summary>
    public class HancContext : DbContext
    {
        public HancContext(DbContextOptions<HancContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use reflection to load all the data models with the HancModel attribute
            var entityMethod = typeof(ModelBuilder).GetMethod("Entity", true);
            var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
            var assemblies = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);

            foreach (var assembly in assemblies)
            {
                var ass = Assembly.Load(assembly);

                var entityTypes = ass
                  .GetTypes()
                  .Where(t =>
                    t.GetTypeInfo().GetCustomAttributes(typeof(HancModel), inherit: true)
                    .Any());

                foreach (var type in entityTypes)
                {
                    entityMethod.MakeGenericMethod(type)
                      .Invoke(modelBuilder, new object[] { });
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Used for retreiving generic methods using reflection
    /// </summary>
    public static class TypeExtensions
    {
        public static MethodInfo GetMethod(this Type type, string name, bool generic)
        {
            if (type != null || !String.IsNullOrEmpty(name))
            {
                return type.GetMethods().FirstOrDefault(method => method.Name == name && method.IsGenericMethod == generic);
            }
            else {
                throw new ArgumentNullException();
            }
        }
    }
}

namespace Hanc.Common.Options
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
}

