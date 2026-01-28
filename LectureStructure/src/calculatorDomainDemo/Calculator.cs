using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorDomainDemo;

public class Calculator
{
    private readonly string _name;
    private readonly List<CalculationRequest> _history = new();
    
    public Calculator(string name)
    {
        _name = name;
    }
    
    public void Calculate(decimal a, decimal b, OperationType operation)
    {
        var result = PerformCalculation(a, b, operation);
        var request = new CalculationRequest(a, b, operation);
        _history.Add(request);
        
        Console.WriteLine($"{_name}: {a} {operation} {b} = {result}");
    }
    
    private decimal PerformCalculation(decimal a, decimal b, OperationType operation)
    {
        return operation switch
        {
            OperationType.Add => a + b,
            OperationType.Subtract => a - b,
            OperationType.Multiply => a * b,
            OperationType.Divide => b != 0 ? a / b : throw new DivideByZeroException(),
            _ => throw new ArgumentException("Invalid operation")
        };
    }
    
    // DEFENSIVE COPY: Return a copy of the list to protect internal state
    public List<CalculationRequest> GetHistory()
    {
        return new List<CalculationRequest>(_history);
    }
    
    public bool HasUsedDivision()
    {
        return _history.Any(r => r.Operation == OperationType.Divide);
    }
    
    public CalculationRequest? GetLastCalculation()
    {
        if (_history.Count == 0)
            return null;
            
        return _history.Last();
    }
    
}
