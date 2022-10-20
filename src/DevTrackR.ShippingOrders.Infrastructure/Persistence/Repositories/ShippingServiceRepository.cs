using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.Repositories;
using MongoDB.Driver;

namespace DevTrackR.ShippingOrders.Infrastructure.Persistence.Repositories
{
    public class ShippingServiceRepository : IShippingServiceRepository
    {
        private readonly IMongoCollection<ShippingService> _collection;
        public ShippingServiceRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public async Task<List<ShippingService>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }
    }
}