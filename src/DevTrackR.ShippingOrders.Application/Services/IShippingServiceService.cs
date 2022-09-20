using DevTrackR.ShippingOrders.Application.ViewModels;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public interface IShippingServiceService
    {
        Task<List<ShippingServiceViewModel>> GetAll();
    }
}