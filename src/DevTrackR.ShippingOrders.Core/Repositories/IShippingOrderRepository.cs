using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Core.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetByCodeAsync(string code);
        Task AddAsync(ShippingOrder shippingOrder);
    }
}