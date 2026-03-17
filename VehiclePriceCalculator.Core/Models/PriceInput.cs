using System.ComponentModel.DataAnnotations;

namespace VehiclePriceCalculator.Core.Models
{
    /// <summary>
    /// Represents a price input component for the vehicle calculation.
    /// </summary>
    public class PriceInput
    {
        /// <summary>
        /// Gets or sets the price value of the vehicle component.
        /// </summary>
        [Required(ErrorMessage = "The amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The amount must be greater than 0.")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the provided amount includes VAT (Gross) or not (Net).
        /// Set to true for Gross, and false for Net.
        /// </summary>
        [Required]
        public bool IsGross { get; set; }
    }
}
