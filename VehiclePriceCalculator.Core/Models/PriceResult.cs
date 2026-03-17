namespace VehiclePriceCalculator.Core.Models
{
    /// <summary>
    /// Represents a price value in net and gross.
    /// </summary>
    public class PriceResult
    {
        /// <summary>
        /// Gets or sets the price amount without VAT.
        /// </summary>
        public decimal Net { get; set; }

        /// <summary>
        /// Gets or sets the price amount with VAT.
        /// </summary>
        public decimal Gross { get; set; }
    }
}