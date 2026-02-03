namespace CalculatorClassExample.Domain.Entities;

public class Calculator
{
    public decimal CurrentValue { get; private set; }
    public string LastOperation { get; private set; } = string.Empty;
    
    public Calculator(decimal initialValue = 0)
    {
        CurrentValue = initialValue;
    }
    
    public void Clear()
    {
        CurrentValue = 0;
        LastOperation = "Cleared";
    }
}