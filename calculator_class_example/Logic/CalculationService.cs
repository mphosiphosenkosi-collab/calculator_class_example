using CalculatorDomainDemo;
using CalculatorDomainDemo.Domain;
using CalculatorDomainDemo.Persistence;

namespace CalculatorDomain.Logic
{
    public class CalculatorService
    {
        private readonly ICalculationStore _store;

        public CalculatorService(ICalculationStore store)
        {
            _store = store;
        }

        public async Task<Calculation> CalculateAsync(CalculationRequest request)
        {
            if (request.Operation == OperationType.Divide && request.right == 0)
                throw new InvalidOperationException("Division by zero is not allowed.");

            double result = request.Operation switch
            {
                OperationType.Add => request.left + request.right,
                OperationType.Subtract => request.left - request.right,
                OperationType.Multiply => request.left * request.right,
                OperationType.Divide => request.left / request.right,
                _ => throw new InvalidOperationException("Unsupported operation.")
            };

            var calculation = new Calculation(
                request.left,
                request.right,
                request.Operation,
                result);

            await _store.SaveAsync(calculation);

            return calculation;
        }

        public async Task<IReadOnlyList<Calculation>> LoadAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Calculation>();

            string json = await File.ReadAllTextAsync(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Calculation>();

            List<Calculation> calculations = JsonSerializer.Deserialize<List<Calculation>>(json)
            ?? new List<Calculation>();

            return calculations;
        }
    }
}