using OnlineBookShop.Appilcation.Common.Interfaces;
using OnlineBookShop.Appilcation.Extensions;
using OnlineBookShop.Appilcation.Profiles;
using OnlineBookShop.Appilcation.Services;
using OnlineBookShop.Infrastructure.Extensions;

namespace OnlineBookShop.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(BookProfile));
            builder.Services.AddApplication();
            builder.Services.AddScoped<IBookService, BookService>();
        }
    }
}
