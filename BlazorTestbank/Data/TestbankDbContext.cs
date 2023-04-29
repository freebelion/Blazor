using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorTestbank.Data
{
    public class TestbankDbContext : DbContext
    {
        public TestbankDbContext() : base()
        {
            Database.EnsureCreated();
        }

        public TestbankDbContext(DbContextOptions<TestbankDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Testbank> Testbanks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"DataSource=testbanks.db;");
        }
    }
}
