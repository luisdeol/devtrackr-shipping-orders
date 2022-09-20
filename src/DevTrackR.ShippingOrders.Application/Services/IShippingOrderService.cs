using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.ViewModels;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public interface IShippingOrderService
    {
        Task<string> Add(AddShippingOrderInputModel model);
        Task<ShippingOrderViewModel> GetByCode(string trackingCode);
    }
}