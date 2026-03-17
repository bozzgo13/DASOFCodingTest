using VehiclePriceCalculator.Core.Models;
using VehiclePriceCalculator.Core.Services;

namespace VehiclePriceCalculator.Tests;

public class PriceServiceTests
{
    private readonly PriceService _service;

    public PriceServiceTests()
    {
         _service = new PriceService();
    }

    [Fact]
    public void CalculatePrices_StandardScenario_ReturnsCorrectNetAndGross()
    {
        // Arrange: Prepare data based on the provided example
        var request = new PriceCalculationRequest
        {
            VatRate = 22,
            BaseVehiclePrice = new PriceInput { Amount = 10000, IsGross = false }, // 10,000 EUR Net
            AdditionalEquipment = new PriceInput { Amount = 122, IsGross = true }   // 122 EUR Gross
        };

        // Act: Execute the calculation
        var result = _service.CalculatePrices(request);

        // Assert: Verify Base Price (Net 10,000 -> Gross 12,200)
        Assert.Equal(10000, result.BaseVehiclePrice.Net);
        Assert.Equal(12200, result.BaseVehiclePrice.Gross);

        // Assert: Verify Equipment Price (Gross 122 -> Net 100)
        Assert.Equal(100, result.AdditionalEquipment.Net);
        Assert.Equal(122, result.AdditionalEquipment.Gross);

        // Assert: Verify Totals (Net 10,100, Gross 12,322)
        Assert.Equal(10100, result.TotalVehiclePrice.Net);
        Assert.Equal(12322, result.TotalVehiclePrice.Gross);
    }

    [Fact]
    public void CalculatePrices_WithZeroAmount_ReturnsZeroTotals()
    {
        // Arrange
        var request = new PriceCalculationRequest
        {
            VatRate = 22,
            BaseVehiclePrice = new PriceInput { Amount = 0, IsGross = false },
            AdditionalEquipment = new PriceInput { Amount = 0, IsGross = true }
        };

        // Act
        var result = _service.CalculatePrices(request);

        // Assert
        Assert.Equal(0, result.TotalVehiclePrice.Net);
        Assert.Equal(0, result.TotalVehiclePrice.Gross);
    }

    [Fact]
    public void CalculatePrices_WithZeroVatRate_NetAndGrossAreSame()
    {
        // Arrange: 0% VAT (e.g., export scenarios)
        var request = new PriceCalculationRequest
        {
            VatRate = 0,
            BaseVehiclePrice = new PriceInput { Amount = 15000, IsGross = false },
            AdditionalEquipment = new PriceInput { Amount = 500, IsGross = false }
        };

        // Act
        var result = _service.CalculatePrices(request);

        // Assert: At 0% VAT, Net must equal Gross
        Assert.Equal(result.TotalVehiclePrice.Net, result.TotalVehiclePrice.Gross);
        Assert.Equal(15500, result.TotalVehiclePrice.Gross);
    }

    [Fact]
    public void CalculatePrices_WithSmallAmounts_RoundsToNearestCent()
    {
        // Arrange: Testing precision with 1 cent inputs
        var request = new PriceCalculationRequest
        {
            VatRate = 22,
            BaseVehiclePrice = new PriceInput { Amount = 0.01m, IsGross = false }, // 1 cent net
            AdditionalEquipment = new PriceInput { Amount = 0.01m, IsGross = true }  // 1 cent gross
        };

        // Act
        var result = _service.CalculatePrices(request);

        // Assert:
        // 0.01 * 1.22 = 0.0122 -> rounds to 0.01
        Assert.Equal(0.01m, result.BaseVehiclePrice.Gross);
        // 0.01 / 1.22 = 0.00819... -> rounds to 0.01
        Assert.Equal(0.01m, result.AdditionalEquipment.Net);
    }

    [Fact]
    public void CalculatePrices_WithHighVatRate_CalculatesCorrectlyWithoutOverflow()
    {
        // Arrange: Testing extreme VAT rates and large numbers
        var request = new PriceCalculationRequest
        {
            VatRate = 99,
            BaseVehiclePrice = new PriceInput { Amount = 1000000000, IsGross = false }, 
            AdditionalEquipment = new PriceInput { Amount = 1000000000, IsGross = false }
        };

        // Act
        var result = _service.CalculatePrices(request);

        // Assert: (1B + 1B) * 1.99 = 3.98 Billion
        Assert.Equal(3980000000, result.TotalVehiclePrice.Gross);
    }
}