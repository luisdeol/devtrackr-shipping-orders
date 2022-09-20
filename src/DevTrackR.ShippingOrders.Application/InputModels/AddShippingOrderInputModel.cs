namespace DevTrackR.ShippingOrders.Application.InputModels
{
    public class AddShippingOrderInputModel
    {
        public string Description { get; set; }
        public decimal WeightInKg { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public List<ShippingServiceInputModel> Services { get; set; }
    }

    public class DeliveryAddressInputModel {
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class ShippingServiceInputModel {
        public string Title { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal FixedPrice { get; set; }
    }
}