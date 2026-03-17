# Vehicle Price Calculator - DASOF Coding Challenge

[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/10.0)
[![xUnit Testing](https://img.shields.io/badge/Tests-xUnit-green.svg)](https://xunit.net/)
[![Swagger/OpenAPI](https://img.shields.io/badge/Docs-Swagger-brightgreen.svg)](https://swagger.io/)

This project is an **implementation of a coding challenge provided by DASOF** during the candidate selection phase. It features a professional .NET 10 Web API solution designed to calculate vehicle prices (base costs and additional equipment) with flexible VAT handling, demonstrating modern development patterns and clean architecture.

## 🚀 Key Features

-   **Precise Calculations**: Handles Net-to-Gross and Gross-to-Net conversions using `decimal` types for financial accuracy.
-   **Clean Architecture**: Separation of concerns between the API layer and the Core business logic layer.
-   **Robust Validation**: Uses `DataAnnotations` to enforce business rules (e.g., preventing negative prices or invalid VAT rates).
-   **Interactive Documentation**: Fully integrated **Swagger (OpenAPI)** with XML summaries providing detailed descriptions of models and endpoints.
-   **Automated Testing**: Comprehensive **xUnit** suite covering standard calculations, edge cases (zero values), and rounding logic.

## 🛠 Tech Stack

-   **Framework**: ASP.NET Core 10.0 (Web API)
-   **Logic Layer**: C# Class Library (.NET 10.0)
-   **Testing**: xUnit, Moq (for Controller unit tests)
-   **Documentation**: Swashbuckle (Swagger UI)
-   **Tooling**: `.http` files for rapid API testing within Visual Studio/VS Code.

## 📂 Project Structure

-   **`VehiclePriceCalculator.Core`**: The "Heart" of the app. Contains Interfaces, Models, and the `PriceService` where all calculations happen.
-   **`VehiclePriceCalculator.Api`**: The "Entry Point". Handles HTTP requests, Dependency Injection configuration, and Swagger middleware.
-   **`VehiclePriceCalculator.Tests`**: The "Shield". Contains Unit Tests to ensure the math stays correct during future updates.

## Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
