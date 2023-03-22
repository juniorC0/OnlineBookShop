using OnlineBookShop.Infrastructure.Persistance;
using OnlineBookShop.Infrastructure.Persistance.DataSeed;

namespace OnlineBookShop.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<OnlineBookShopDbContext>();

                await SeedFacade.SeedData(context);
            }
        }
    }
}
