namespace VehiclePriceCalculator.Core.Models
{
    /// <summary>
    /// Represents the result of the vehicle price calculation, 
    /// containing costs for the vehicle, equipment, and total.
    /// </summary>
    public class PriceCalculationResponse
    {
        /// <summary>
        /// Gets or sets the calculated net and gross prices for the base vehicle.
        /// </summary>
        public required PriceResult BaseVehiclePrice { get; set; }

        /// <summary>
        /// Gets or sets the calculated net and gross prices for the additional equipment.
        /// Returns null if no equipment was provided in the request.
        /// </summary>
        public PriceResult? AdditionalEquipment { get; set; }

        /// <summary>
        /// Gets or sets the final calculated total price (sum of base vehicle and equipment) 
        /// in both net and gross formats.
        /// </summary>
        public PriceResult? TotalVehiclePrice { get; set; }
    }
}
