using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingServiceService : IShippingServiceService
    {
        public Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = new List<ShippingService> {
                new ShippingService("Selo", 0, 1.2m),
                new ShippingService("Envio com Registro", 2.2m, 5),
                new ShippingService("Envio sem Registro", 1, 3)
            };

            return Task.FromResult(
                shippingServices
                    .Select(s => new ShippingServiceViewModel(s.Id, s.Title, s.PricePerKg, s.FixedPrice))
                    .ToList()
            );
        }
    }
}