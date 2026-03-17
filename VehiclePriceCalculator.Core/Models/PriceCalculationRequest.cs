using System.ComponentModel.DataAnnotations;

namespace VehiclePriceCalculator.Core.Models
{
    /// <summary>
    /// Represents a request for calculating the total vehicle price including base price and equipment.
    /// </summary>
    public class PriceCalculationRequest
    {
        /// <summary>
        /// Gets or sets the base price details of the vehicle. This is a required field.
        /// </summary>
        [Required(ErrorMessage = "Base vehicle price details are missing.")]
        public required PriceInput BaseVehiclePrice { get; set; }

        /// <summary>
        /// Gets or sets the price details for any additional equipment. This field is optional.
        /// </summary>
        public PriceInput? AdditionalEquipment { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate as a percentage (e.g., 22.0).
        /// Default value is 22.0%.
        /// </summary>
        [Required(ErrorMessage = "VAT rate is required.")]
        [Range(0, 100, ErrorMessage = "The VAT rate must be between 0 and 100%.")]
        public decimal VatRate { get; set; } = 22.0m;
    }
}
