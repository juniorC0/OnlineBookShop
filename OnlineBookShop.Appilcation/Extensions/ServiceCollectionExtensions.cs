﻿using Microsoft.Extensions.DependencyInjection;

namespace OnlineBookShop.Appilcation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
