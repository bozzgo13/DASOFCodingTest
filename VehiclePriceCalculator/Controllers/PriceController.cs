using Microsoft.AspNetCore.Mvc;
using VehiclePriceCalculator.Core.Interfaces;
using VehiclePriceCalculator.Core.Models;

namespace VehiclePriceCalculator.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpPost("calculate")]
        public ActionResult<PriceCalculationResponse> Calculate([FromBody] PriceCalculationRequest request)
        {
            var result = _priceService.CalculatePrices(request);
            return Ok(result);
        }
    }
}


