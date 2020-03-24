using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API
{
    public class FootballContext:DbContext
    {
        public System.Data.Entity.DbSet<teams> Teams { get; set; }
        public System.Data.Entity.DbSet<coaches> Coaches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FootbalDB;Trusted_Connection=True;");
        }
    }
}
