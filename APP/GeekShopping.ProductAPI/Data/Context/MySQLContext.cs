using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Domain.Product> Products { get; set; }
    }
}
