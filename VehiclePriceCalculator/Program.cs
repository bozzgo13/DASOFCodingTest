using System.Reflection;
using VehiclePriceCalculator.Core.Interfaces; 
using VehiclePriceCalculator.Core.Services;   

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddControllers();

// Registering the Swagger generator
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Vehicle Price Calculator API",
        Description = "An ASP.NET Core Web API for calculating vehicle net and gross prices."
    });

    // Use the XML comments (summaries)
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Enable Swagger UI in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
