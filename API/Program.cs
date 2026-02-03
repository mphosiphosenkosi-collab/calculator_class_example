using Calculator_Class_Example.Domain;
using Calculator_Class_Example.Persistence;
using Calculator_Class_Example.Logic;

var builder = WebApplication.CreateBuilder(args);

// Build the correct data directory path
var dataDirectory = Path.Combine(
    Directory.GetCurrentDirectory(),
    "..",
    "calculator_class_example", 
    "Data"
);

// Create directory if it doesn't exist
Directory.CreateDirectory(dataDirectory);

var jsonFilePath = Path.Combine(dataDirectory, "calculation.json");

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // Required for Swagger
builder.Services.AddSwaggerGen();

// Register FileCalculationStore as singleton with the correct path
builder.Services.AddSingleton<ICalculationStore>(provider =>
    new FileCalculationStore(jsonFilePath));

// Register CalculationService as singleton


var app = builder.Build();

// Map controllers
app.MapControllers();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Note: HTTPS redirection is commented out in Skye's version
// app.UseHttpsRedirection();

app.Run();