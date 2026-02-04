namespace Calculator_Class_Example.Domain
{
    public class CalculationRequest
    {
        public double Left { get; set; }
        public double Right { get; set; }
        public OperationType Operation { get; set; }
    }
}
