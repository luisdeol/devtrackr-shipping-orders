using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Repositories;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingOrderService : IShippingOrderService
    {
        private readonly IShippingOrderRepository _repository;
        public ShippingOrderService(IShippingOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Add(AddShippingOrderInputModel model)
        {
            var shippingOrder = model.ToEntity();
            var shippingServices = model
                .Services
                .Select(s => s.ToEntity())
                .ToList();

            shippingOrder.SetupServices(shippingServices);

            await _repository.AddAsync(shippingOrder);

            return shippingOrder.TrackingCode;
        }

        public async Task<ShippingOrderViewModel> GetByCode(string trackingCode)
        {
            var shippingOrder = await _repository.GetByCodeAsync(trackingCode);

            return ShippingOrderViewModel.FromEntity(shippingOrder);
        }
    }
}