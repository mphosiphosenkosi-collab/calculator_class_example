namespace CalculatorClassExample.Logic.Interfaces;

public interface ICalculatorService
{
    decimal Add(decimal a, decimal b);
    decimal Subtract(decimal a, decimal b);
    decimal Multiply(decimal a, decimal b);
    decimal Divide(decimal a, decimal b);
    decimal Calculate(string operation, decimal a, decimal b);
}