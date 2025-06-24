using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;
using QD_API.Models;


namespace QD_API
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<City> city{ get; set; }
        public DbSet<CityGetList> cityGetLists { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<DocumentType> documentType { get; set; } 
        public DbSet<StandardSize> standardSize { get; set; }
        public DbSet<ProductImage> productImage { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<DetailInvoice> detailInvoice { get; set; }
        public DbSet<SaleInvoice> saleInvoice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

    }
}