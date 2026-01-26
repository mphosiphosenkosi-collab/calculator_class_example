using System;

namespace Calculator.App
{
    public class Calculator
    {
        // Properties to store numbers
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        
        // Constructor
        public Calculator()
        {
            Number1 = 0;
            Number2 = 0;
        }
        
        // Constructor with parameters
        public Calculator(double num1, double num2)
        {
            Number1 = num1;
            Number2 = num2;
        }
        
        // Add method
        public double Add()
        {
            return Number1 + Number2;
        }
        
        // Subtract method
        public double Subtract()
        {
            return Number1 - Number2;
        }
        
        // Multiply method
        public double Multiply()
        {
            return Number1 * Number2;
        }
        
        // Divide method
        public double Divide()
        {
            if (Number2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
            return Number1 / Number2;
        }
        
        // Static method version (can call without creating object)
        public static double Add(double a, double b)
        {
            return a + b;
        }
        
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
            return a / b;
        }
        
        // Display result
        public void DisplayResult(string operation, double result)
        {
            Console.WriteLine($"\n{Number1} {operation} {Number2} = {result}");
        }
    }
}