namespace CalculatorDomainDemo;

public class CalculationRequest
{
    public decimal A { get; set; }
    public decimal B { get; set; }
    public OperationType Operation { get; set; }
    
    public CalculationRequest(decimal a, decimal b, OperationType operation)
    {
        A = a;
        B = b;
        Operation = operation;
    }
}
