using Calculator_Class_Example.Domain;

namespace Calculator_Class_Example.Persistence
{
    public interface ICalculationStore
    {
        Task SaveAsync(Calculation calculation);
        Task<IReadOnlyList<Calculation>> LoadAllAsync();
    }
}