using System.ComponentModel.DataAnnotations;
using Calculator_Class_Example.Domain;

public class CreateCalculationDto
{
    public class CalculationRequest
    {
        [Required]
        public double Left { get; set; }
        [Required]
        public double Right { get; set; }
        [Required]
        public OperationType Operand { get; set; }
    }
}