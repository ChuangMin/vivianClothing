using System.Data.Entity;


namespace vivianClothing.Models
{

    public class VivianclothingContext : DbContext
    {
        public VivianclothingContext()
            : base("name=DefaultConnection")        
        { 
        
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<OrderHeader> Orders { get; set; }
        public DbSet<OrderDetail> orderDetailItems { get; set; }

    }
}