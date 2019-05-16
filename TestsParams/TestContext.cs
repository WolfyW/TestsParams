using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TestsParams.Model;


namespace TestsParams
{
    public partial class TestContext : DbContext
    {
        public TestContext() : base("name=TestsDB")
        {
        }

        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parameters>()
                .Property(e => e.RequiredValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Parameters>()
                .Property(e => e.MeasuredValue)
                .HasPrecision(18, 0);
        }
    }
}
