using VehiclePriceCalculator.Core.Interfaces;
using VehiclePriceCalculator.Core.Models;

namespace VehiclePriceCalculator.Core.Services
{
    public  class PriceService : IPriceService
    {
        public PriceCalculationResponse CalculatePrices(PriceCalculationRequest request)
        {
            var vatFactor = 1 + (request.VatRate / 100);

            var basePrice = CalculatePriceResult(request.BaseVehiclePrice, vatFactor);
            var equipmentPrice = CalculatePriceResult(request.AdditionalEquipment, vatFactor);

            return new PriceCalculationResponse
            {
                BaseVehiclePrice = basePrice,
                AdditionalEquipment = equipmentPrice,
                TotalVehiclePrice = new PriceResult
                {
                    Net = basePrice.Net + equipmentPrice.Net,
                    Gross = basePrice.Gross + equipmentPrice.Gross
                }
            };
        }

        /// <summary>
        /// Calculates both net and gross prices for a given input component based on the provided VAT factor.
        /// </summary>
        /// <param name="input">The price input containing the amount and its type (Net/Gross). Can be null.</param>
        /// <param name="vatFactor">The multiplier used for VAT calculations (e.g., 1.22 for 22% VAT).</param>
        /// <returns>
        /// A <see cref="PriceResult"/> containing the calculated Net and Gross amounts. 
        /// Returns zeroed values if the input is null.
        /// </returns>
        private PriceResult CalculatePriceResult(PriceInput? input, decimal vatFactor)
        {
            if (input == null)
                return new PriceResult { Net = 0, Gross = 0 };

            decimal grossPrice = input.Amount;
            decimal netPrice = input.Amount;

            if (input.IsGross)
            {
                // If the input is Gross, calculate the Net price by dividing by the VAT factor
                netPrice = Math.Round(input.Amount / vatFactor, 2);
            }
            else
            {
                // If the input is Net, calculate the Gross price by multiplying by the VAT factor
                grossPrice = Math.Round(input.Amount * vatFactor, 2);
            }

            return new PriceResult
            {
                Gross = grossPrice,
                Net = netPrice
            };
        }
    }
}
