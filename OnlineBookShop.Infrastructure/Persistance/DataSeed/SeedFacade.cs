using Microsoft.EntityFrameworkCore;

namespace OnlineBookShop.Infrastructure.Persistance.DataSeed
{
    public class SeedFacade
    {
        public static async Task SeedData(OnlineBookShopDbContext dbContext)
        {
            dbContext.Database.Migrate();

            await BooksSeed.Seed(dbContext);
        }
    }
}
