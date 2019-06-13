using DanApiTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanApiTest.Data
{
    public class DanApiContext:DbContext
    {
        public DanApiContext(DbContextOptions<DanApiContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
