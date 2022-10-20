using DevTrackR.ShippingOrders.Core.Entities;
using MongoDB.Driver;

namespace DevTrackR.ShippingOrders.Infrastructure.Persistence
{
    public class DbSeed
    {
        private readonly IMongoCollection<ShippingService> _collection;
        private List<ShippingService> _shippingServices = new List<ShippingService> {
            new ShippingService("Envio estadual", 3.75m, 12),
            new ShippingService("Envio internacional", 5.25m, 15),
            new ShippingService("Caixa tamanho P", 0, 5),
        };

        public DbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public void Populate() {
            if (_collection.CountDocuments(c => true) == 0)
                _collection.InsertMany(_shippingServices);
        }
    }
}