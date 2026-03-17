using VehiclePriceCalculator.Core.Models;

namespace VehiclePriceCalculator.Core.Interfaces
{
    public interface IPriceService
    {
        PriceCalculationResponse CalculatePrices(PriceCalculationRequest request);
    }
}
