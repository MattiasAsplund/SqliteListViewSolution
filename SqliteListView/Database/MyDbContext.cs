using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteListView.Database
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=people.db");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Person> People { get; set; }
    }
}
