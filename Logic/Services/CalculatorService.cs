using CalculatorClassExample.Logic.Interfaces;

namespace CalculatorClassExample.Logic.Services;

public class CalculatorService : ICalculatorService
{
    public decimal Add(decimal a, decimal b) => a + b;
    public decimal Subtract(decimal a, decimal b) => a - b;
    public decimal Multiply(decimal a, decimal b) => a * b;
    
    public decimal Divide(decimal a, decimal b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }
    
    public decimal Calculate(string operation, decimal a, decimal b)
    {
        return operation.ToLower() switch
        {
            "+" or "add" => Add(a, b),
            "-" or "subtract" => Subtract(a, b),
            "*" or "multiply" => Multiply(a, b),
            "/" or "divide" => Divide(a, b),
            _ => throw new ArgumentException($"Invalid operation: {operation}")
        };
    }
}