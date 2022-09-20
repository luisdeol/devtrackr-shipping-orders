using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-services")]
    public class ShippingServicesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok();
        }
    }
}