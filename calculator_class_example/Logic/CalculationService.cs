using Calculator_Class_Example.Domain;
namespace Calculator_Class_Example.Logic;
using System.Text.Json;

namespace Calculator_Class_Example.Logic  // Use YOUR namespace
{
    public class CalculationService
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;
        
        public CalculationService(string filePath = "Data/calculation.json")
        {
            _filePath = filePath;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        
        public async Task<IReadOnlyList<Calculation>> LoadAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Calculation>();

            string json = await File.ReadAllTextAsync(_filePath);

            if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                return new List<Calculation>();

            return JsonSerializer.Deserialize<List<Calculation>>(json, _jsonOptions)
                ?? new List<Calculation>();
        }
        
        public async Task SaveCalculationAsync(Calculation calculation)
        {
            var calculations = (await LoadAllAsync()).ToList();
            calculations.Add(calculation);
            
            string json = JsonSerializer.Serialize(calculations, _jsonOptions);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}