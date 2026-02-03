using System.Text.Json;
using Calculator_Class_Example.Domain;

namespace Calculator_Class_Example.Persistence  // NO SEMICOLON
{
    public class FileCalculationStore
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public FileCalculationStore(string filePath = "Data/calculation.json")
        {
            _filePath = filePath;
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task SaveAsync(Calculation calculation)
        {
            var calculations = await LoadAllAsync();
            calculations.Add(calculation);
            
            string json = JsonSerializer.Serialize(calculations, _jsonOptions);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<List<Calculation>> LoadAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Calculation>();

            string json = await File.ReadAllTextAsync(_filePath);

            if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]")
                return new List<Calculation>();

            return JsonSerializer.Deserialize<List<Calculation>>(json, _jsonOptions)
                ?? new List<Calculation>();
        }
    }
}