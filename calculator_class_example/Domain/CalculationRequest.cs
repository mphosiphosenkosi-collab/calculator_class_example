namespace Calculator_Class_Example.Domain;
public record CalculationRequest(
    double left,
    double right,
    OperationType Operation
);