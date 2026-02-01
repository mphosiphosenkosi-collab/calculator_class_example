using CalculatorClassExample.Domain.Entities;

namespace CalculatorClassExample.Data.Repositories;

public interface ICalculationRepository
{
    void SaveCalculation(CalculationOperation operation);
    IEnumerable<CalculationOperation> GetHistory();
    void ClearHistory();
}