namespace DevTrackR.ShippingOrders.Application.ViewModels
{
    public class ShippingServiceViewModel
    {
        public ShippingServiceViewModel(Guid id, string title, decimal pricePerKg, decimal fixedPrice)
        {
            Id = id;
            Title = title;
            PricePerKg = pricePerKg;
            FixedPrice = fixedPrice;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public decimal PricePerKg { get; private set; }
        public decimal FixedPrice { get; private set; }
    }
}