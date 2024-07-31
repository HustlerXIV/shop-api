using Microsoft.EntityFrameworkCore;
using shop_api.Models;

namespace shop_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}