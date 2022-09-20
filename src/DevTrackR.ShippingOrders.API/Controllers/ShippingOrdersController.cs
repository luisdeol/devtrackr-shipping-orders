using DevTrackR.ShippingOrders.Application.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-orders")]
    public class ShippingOrdersController : ControllerBase
    {
        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code) {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderInputModel model) {
            return CreatedAtAction(
                nameof(GetByCode),
                new { code = "ABCDE12345" },
                model
            );
        }
    }
}