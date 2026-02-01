using CalculatorClassExample.Domain.Entities;
using CalculatorClassExample.Logic.Services;
using CalculatorClassExample.Data.Repositories;
using CalculatorClassExample.Logic.Interfaces;

namespace CalculatorClassExample;

class Program
{
    static void Main()
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("  LAYERED ARCHITECTURE CALCULATOR");
        Console.WriteLine("=========================================\n");
        
        // Initialize services (Dependency Injection pattern)
        ICalculatorService calculatorService = new CalculatorService();
        ICalculationRepository repository = new InMemoryCalculationRepository();
        
        bool continueCalculating = true;
        
        while (continueCalculating)
        {
            try
            {
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║         NEW CALCULATION              ║");
                Console.WriteLine("╚═══════════════════════════════════════╝");
                
                // Get user input
                Console.Write("\nEnter first number: ");
                decimal num1 = GetValidNumber();
                
                Console.Write("Enter operation (+, -, *, /): ");
                string operation = GetValidOperation();
                
                Console.Write("Enter second number: ");
                decimal num2 = GetValidNumber();
                
                // Calculate using the service layer
                decimal result = calculatorService.Calculate(operation, num1, num2);
                
                // Create domain entity
                var calculation = new CalculationOperation
                {
                    Operand1 = num1,
                    Operand2 = num2,
                    Operator = operation,
                    Result = result
                };
                
                // Save to repository (data layer)
                repository.SaveCalculation(calculation);
                
                Console.WriteLine($"\n✅ RESULT: {num1} {operation} {num2} = {result}\n");
                
                // Menu options
                ShowMenu(repository);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}\n");
            }
            
            Console.Write("Perform another calculation? (y/n): ");
            continueCalculating = Console.ReadLine()?.ToLower() == "y";
        }
        
        Console.WriteLine("\n🎯 Thank you for using Layered Architecture Calculator!");
        Console.WriteLine("   Built with: Domain + Logic + Data + Persistence layers");
    }
    
    static decimal GetValidNumber()
    {
        while (true)
        {
            string input = Console.ReadLine() ?? "";
            if (decimal.TryParse(input, out decimal number))
                return number;
            
            Console.Write("Invalid number. Please enter a valid number: ");
        }
    }
    
    static string GetValidOperation()
    {
        string[] validOps = { "+", "-", "*", "/" };
        
        while (true)
        {
            string input = Console.ReadLine()?.Trim() ?? "";
            if (validOps.Contains(input))
                return input;
            
            Console.Write("Invalid operation. Please enter +, -, *, or /: ");
        }
    }
    
    static void ShowMenu(ICalculationRepository repository)
    {
        Console.WriteLine("╔═══════════════════════════════════════╗");
        Console.WriteLine("║            MENU OPTIONS              ║");
        Console.WriteLine("╠═══════════════════════════════════════╣");
        Console.WriteLine("║ [H] - View Calculation History       ║");
        Console.WriteLine("║ [C] - Clear History                  ║");
        Console.WriteLine("║ [S] - Show Statistics                ║");
        Console.WriteLine("║ [Enter] - Continue Calculating       ║");
        Console.WriteLine("╚═══════════════════════════════════════╝");
        Console.Write("\nYour choice: ");
        
        var choice = Console.ReadLine()?.ToUpper();
        
        switch (choice)
        {
            case "H":
                ShowHistory(repository);
                break;
            case "C":
                repository.ClearHistory();
                Console.WriteLine("\n✅ History cleared!");
                break;
            case "S":
                ShowStatistics(repository);
                break;
        }
    }
    
    static void ShowHistory(ICalculationRepository repository)
    {
        var history = repository.GetHistory().ToList();
        
        if (!history.Any())
        {
            Console.WriteLine("\nNo calculations in history.");
            return;
        }
        
        Console.WriteLine("\n═════════════════════════════════════════");
        Console.WriteLine("          CALCULATION HISTORY");
        Console.WriteLine("═════════════════════════════════════════");
        
        for (int i = 0; i < history.Count; i++)
        {
            var calc = history[i];
            Console.WriteLine($"{i + 1}. {calc.Operand1} {calc.Operator} {calc.Operand2} = {calc.Result}");
            Console.WriteLine($"   Time: {calc.Timestamp:HH:mm:ss}");
            Console.WriteLine("   ──────────────────────────────────────");
        }
        
        Console.WriteLine($"\nTotal calculations: {history.Count}");
    }
    
    static void ShowStatistics(ICalculationRepository repository)
    {
        var history = repository.GetHistory().ToList();
        
        if (!history.Any())
        {
            Console.WriteLine("\nNo calculations for statistics.");
            return;
        }
        
        Console.WriteLine("\n═════════════════════════════════════════");
        Console.WriteLine("            STATISTICS");
        Console.WriteLine("═════════════════════════════════════════");
        
        var operationsCount = history.GroupBy(h => h.Operator)
            .Select(g => new { Operation = g.Key, Count = g.Count() });
        
        foreach (var op in operationsCount)
        {
            Console.WriteLine($"   {op.Operation}: {op.Count} times");
        }
        
        Console.WriteLine($"\n   Total calculations: {history.Count}");
        Console.WriteLine($"   Average result: {history.Average(h => h.Result):F2}");
        Console.WriteLine($"   Largest result: {history.Max(h => h.Result)}");
        Console.WriteLine($"   Smallest result: {history.Min(h => h.Result)}");
    }
}