namespace CalculatorClassExample.Domain.Entities;

public class CalculationOperation
{
    public decimal Operand1 { get; set; }
    public decimal Operand2 { get; set; }
    public string Operator { get; set; } = string.Empty;
    public decimal Result { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}