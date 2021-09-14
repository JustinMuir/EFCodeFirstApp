using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFCodeFirstWebApp.DataLayer
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EFContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}