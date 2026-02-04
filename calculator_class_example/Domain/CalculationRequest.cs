namespace Calculator_Class_Example.Domain
{
    public class CalculationRequest
    {
        public double Left { get; set; }
        public double Right { get; set; }
        public OperationType Operation { get; set; }

        // Constructor MUST be INSIDE the class
        public CalculationRequest(double left, double right, OperationType operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }
        
        // Optional: Add a parameterless constructor for JSON deserialization
        public CalculationRequest()
        {
        }
    }
}