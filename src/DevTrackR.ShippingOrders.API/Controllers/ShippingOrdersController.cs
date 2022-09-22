using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-orders")]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _service;

        public ShippingOrdersController(IShippingOrderService service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code) {
            var shippingOrder = await _service.GetByCode(code);

            if (shippingOrder == null)
                return NotFound();
                
            return Ok(shippingOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderInputModel model) {
            var code = await _service.Add(model);

            return CreatedAtAction(
                nameof(GetByCode),
                new { code },
                model
            );
        }
    }
}