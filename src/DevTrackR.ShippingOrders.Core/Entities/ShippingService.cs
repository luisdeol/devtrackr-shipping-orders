namespace DevTrackR.ShippingOrders.Core.Entities
{
    public class ShippingService : EntityBase
    {
        public ShippingService(string title, decimal pricePerKg, decimal fixedPrice) : base()
        {
            Title = title;
            PricePerKg = pricePerKg;
            FixedPrice = fixedPrice;
        }

        public string Title { get; private set; }
        public decimal PricePerKg { get; private set; }
        public decimal FixedPrice { get; private set; }
    }
}