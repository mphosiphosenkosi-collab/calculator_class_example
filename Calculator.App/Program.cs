using System;

namespace Calculator.App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== CALCULATOR APP ===");
            Console.WriteLine("Using Calculator class methods\n");
            
            bool running = true;
            
            while (running)
            {
                ShowMenu();
                
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        RunCalculatorMethod1(); // Method 1: Using object
                        break;
                    case "2":
                        RunCalculatorMethod2(); // Method 2: Using static methods
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("\nGoodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
        
        static void ShowMenu()
        {
            Console.WriteLine("\n════════════ MENU ════════════");
            Console.WriteLine("1. Use Calculator Object");
            Console.WriteLine("2. Use Static Methods");
            Console.WriteLine("0. Exit");
            Console.WriteLine("══════════════════════════════");
        }
        
        // Method 1: Using Calculator object
        static void RunCalculatorMethod1()
        {
            Console.WriteLine("\n--- USING CALCULATOR OBJECT ---");
            
            // Create calculator object
            Calculator calc = new Calculator();
            
            // Get numbers from user
            Console.Write("Enter first number: ");
            calc.Number1 = double.Parse(Console.ReadLine());
            
            Console.Write("Enter second number: ");
            calc.Number2 = double.Parse(Console.ReadLine());
            
            // Show operation menu
            Console.WriteLine("\nChoose operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.Write("Choice: ");
            
            string opChoice = Console.ReadLine();
            
            try
            {
                switch (opChoice)
                {
                    case "1":
                        double addResult = calc.Add();
                        calc.DisplayResult("+", addResult);
                        break;
                    case "2":
                        double subResult = calc.Subtract();
                        calc.DisplayResult("-", subResult);
                        break;
                    case "3":
                        double mulResult = calc.Multiply();
                        calc.DisplayResult("×", mulResult);
                        break;
                    case "4":
                        double divResult = calc.Divide();
                        calc.DisplayResult("÷", divResult);
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        // Method 2: Using Calculator static methods
        static void RunCalculatorMethod2()
        {
            Console.WriteLine("\n--- USING STATIC METHODS ---");
            
            // Get numbers from user
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());
            
            // Show operation menu
            Console.WriteLine("\nChoose operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.Write("Choice: ");
            
            string opChoice = Console.ReadLine();
            
            try
            {
                switch (opChoice)
                {
                    case "1":
                        double result = Calculator.Add(num1, num2);
                        Console.WriteLine($"\n{num1} + {num2} = {result}");
                        break;
                    case "2":
                        result = Calculator.Subtract(num1, num2);
                        Console.WriteLine($"\n{num1} - {num2} = {result}");
                        break;
                    case "3":
                        result = Calculator.Multiply(num1, num2);
                        Console.WriteLine($"\n{num1} × {num2} = {result}");
                        break;
                    case "4":
                        result = Calculator.Divide(num1, num2);
                        Console.WriteLine($"\n{num1} ÷ {num2} = {result}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}