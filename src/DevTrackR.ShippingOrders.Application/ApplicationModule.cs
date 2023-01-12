using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrackR.ShippingOrders.Application.Services;
using DevTrackR.ShippingOrders.Applicaton.Subscribers;
using Microsoft.Extensions.DependencyInjection;

namespace DevTrackR.ShippingOrders.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services
                .AddApplicationServices()
                .AddSubscribers();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IShippingOrderService, ShippingOrderService>();
            services.AddScoped<IShippingServiceService, ShippingServiceService>();

            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services) {
            services.AddHostedService<ShippingOrderCompletedSubscriber>();
            
            return services;
        }
    }
}