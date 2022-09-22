
using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Core.Repositories
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllAsync();
    }
}