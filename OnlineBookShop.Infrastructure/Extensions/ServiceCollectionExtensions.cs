using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookShop.Appilcation.Common.Interfaces;
using OnlineBookShop.Infrastructure.Persistance;

namespace OnlineBookShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OnlineBookShopDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("OnlineBookShopDbContext"));
            });
            services.AddScoped<IRepository, GenericRepository>();

            return services;
        }
    }
}
