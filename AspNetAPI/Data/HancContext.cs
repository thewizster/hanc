using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hanc.AspNetAPI.Models;

namespace Hanc.AspNetAPI.Data
{
    public class HancContext : DbContext
    {
        public HancContext(DbContextOptions<HancContext> options) : base(options)
        { }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
