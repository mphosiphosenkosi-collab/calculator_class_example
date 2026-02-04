using Calculator_Class_Example.Domain;
using Calculator_Class_Example.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Calculator_Class_Example.Logic
{
    public class CalculationService
    {
        private readonly ICalculationStore _store;

        public CalculationService(ICalculationStore store)
        {
            _store = store;
        }

        public async Task<Calculation> CalculateAsync(double left, double right, OperationType operation)
        {
            double result = operation switch
            {
                OperationType.Add => left + right,
                OperationType.Subtract => left - right,
                OperationType.Multiply => left * right,
                OperationType.Divide => right != 0 ? left / right : throw new DivideByZeroException("Cannot divide by zero"),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };

            var calculation = new Calculation(left, right, operation, result);
            await _store.SaveAsync(calculation);
            return calculation;
        }

        public async Task<List<Calculation>> GetHistoryAsync()
        {
            var history = await _store.LoadAllAsync();
            return history.ToList();
        }
    }
}