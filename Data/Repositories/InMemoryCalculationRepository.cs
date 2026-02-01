using CalculatorClassExample.Domain.Entities;

namespace CalculatorClassExample.Data.Repositories;

public class InMemoryCalculationRepository : ICalculationRepository
{
    private readonly List<CalculationOperation> _history = new();
    
    public void SaveCalculation(CalculationOperation operation)
    {
        _history.Add(operation);
    }
    
    public IEnumerable<CalculationOperation> GetHistory()
    {
        return _history.AsReadOnly();
    }
    
    public void ClearHistory()
    {
        _history.Clear();
    }
}