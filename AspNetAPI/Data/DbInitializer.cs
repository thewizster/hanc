using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hanc.AspNetAPI.Data;

namespace Hanc.AspNetAPI.Models
{
    public class DbInitializer
    {
        /// <summary>
        /// Ensures the database is created and seeded
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(HancContext context)
        {
            context.Database.EnsureCreated();

            if (context.Titles.Any())
            {
                return; // DB has already been seeded
            }

            var titles = new Title[] {
                new Title { Name="Contact", ForEntityName="Person" },
                new Title { Name="Employee", ForEntityName="Person" },
                new Title { Name="Manager", ForEntityName="Person"},
                new Title { Name="Salesperson", ForEntityName="Person"},
                new Title { Name="Lead", ForEntityName="Person"},
                new Title { Name="User", ForEntityName="Person"},
                new Title { Name="Customer", ForEntityName="Organization"},
                new Title { Name="Client", ForEntityName="Organization"},
                new Title { Name="Lead", ForEntityName="Organization"},
                new Title { Name="Business", ForEntityName="Organization"}
            };
            context.Titles.AddRange(titles);
            context.SaveChanges();

        }
    }
}
