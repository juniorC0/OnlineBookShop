using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Infrastructure.Persistance
{
    public class OnlineBookShopDbContext : DbContext
    {
        public OnlineBookShopDbContext(DbContextOptions<OnlineBookShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }   
    }
}
