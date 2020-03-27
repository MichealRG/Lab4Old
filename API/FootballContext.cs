using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API
{
    public class FootballContext:DbContext
    {
        public DbSet<teams> Teams { get; set; }
        public DbSet<coaches> Coaches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FootbalDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<teams>(eb => eb.HasNoKey());
            //modelBuilder.Entity<teams>()
        //.Property(b => b.id)
        //.HasConversion(
        //    v => JsonConvert.SerializeObject(v),
        //    v => JsonConvert.DeserializeObject<CalendarEvent>(v));

        }
    }
}
