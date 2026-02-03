# <div align="center">

## 🧮 BitCube Pro Calculator v4.0.0 - Layered Architecture Edition

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/)
[![C# 12.0](https://img.shields.io/badge/C%23-12.0-blue)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Architecture](https://img.shields.io/badge/Architecture-Layered-orange)](https://learn.microsoft.com/en-us/dotnet/architecture/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)
[![Build](https://img.shields.io/badge/build-passing-brightgreen)](https://github.com/mphosiphosenkosi-collab/calculator_class_example/actions)

A professional .NET 8 C# calculator with **Layered Architecture** and **Domain-Driven Design**, built for enterprise applications and professional portfolio demonstrations.

### Transformed from simple console app to enterprise-grade layered architecture

</div>

## 📖 Table of Contents

- [🎯 About](#-about)
- [✨ Features](#-features)
- [🏗️ Architecture](#-architecture)
- [🚀 Quick Start](#-quick-start)
- [💻 Usage](#-usage)
- [📁 Project Structure](#-project-structure)
- [🧪 Testing](#-testing)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)

## 🎯 About

**BitCube Pro Calculator v4.0** represents a significant architectural evolution from basic console application to enterprise-ready layered architecture. This version demonstrates:

- **Layered Architecture Pattern** with clear separation of concerns
- **Domain-Driven Design** principles applied to a calculator domain
- **Professional C# Development** with modern .NET 8 features
- **Repository & Service Patterns** for maintainable, testable code

### Educational Purpose

This project serves as a comprehensive learning tool for:

- **.NET 8 & C# 12** modern features and best practices
- **Layered Architecture** implementation in real-world applications
- **Domain-Driven Design** principles with practical examples
- **Professional C# Development** patterns and practices
- **Clean Code** principles and SOLID design

## ✨ Features

### 🏗️ **Core Architecture**

- **Layered Architecture** - Clear separation: Domain, Logic, Data, Persistence
- **Domain-Driven Design** - Rich domain models with business rules
- **Repository Pattern** - Abstract data access layer
- **Service Layer** - Encapsulated business logic
- **SOLID Principles** - Maintainable, extensible design

### 🔢 **Calculator Capabilities**

- **Basic Operations** - Addition, Subtraction, Multiplication, Division
- **Comprehensive Validation** - Input validation and error handling
- **Calculation History** - Complete tracking with timestamps
- **Real-time Statistics** - Operation analytics and insights
- **Safe Operations** - Division by zero protection

### 🛠️ **Technical Excellence**

- **.NET 8 Performance** - High-performance execution
- **Professional Documentation** - XML documentation throughout
- **Test-Ready Structure** - Designed for unit testing
- **Clean Console UI** - User-friendly interface with menu system
- **GitHub Ready** - Proper .gitignore and project structure

## 🏗️ Architecture

### Layer Breakdown

| Layer | Responsibility | Key Components |
|-------|----------------|----------------|

| **Domain** | Business entities and rules | `Calculator`, `CalculationOperation` |
| **Logic** | Business services and interfaces | `ICalculatorService`, `CalculatorService` |
| **Data** | Data access and repositories | `ICalculationRepository`, `InMemoryCalculationRepository` |
| **Persistence** | Database configurations | Configurations (future-ready) |
| **Presentation** | User interface | `Program.cs` (Console Application) |

### Architecture Flow

User Input → Presentation Layer (Program.cs)
↓
Logic Layer (CalculatorService)
↓
Domain Layer (Entities/Value Objects)
↓
Data Layer (Repositories)
↓
Persistence Layer (Configurations)

text

## 🚀 Quick Start

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Git for version control
- Visual Studio Code or Visual Studio 2022

### Installation

```bash
# Clone the repository
git clone https://github.com/mphosiphosenkosi-collab/calculator_class_example.git
cd calculator_class_example

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
Development Setup
bash
# Install recommended VS Code extensions (optional)
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.csdevkit

💻 Usage

Running the Application
When you run the application, you'll see:

text
=========================================
  LAYERED ARCHITECTURE CALCULATOR
=========================================

╔═══════════════════════════════════════╗
║         NEW CALCULATION              ║
╚═══════════════════════════════════════╝

Enter first number: 10
Enter operation (+, -, *, /): +
Enter second number: 5

✅ RESULT: 10 + 5 = 15

╔═══════════════════════════════════════╗
║            MENU OPTIONS              ║
╚═══════════════════════════════════════╝
[H] - View Calculation History
[C] - Clear History
[S] - Show Statistics
[Enter] - Continue Calculating
Code Examples
Using the Service Layer
csharp
// Initialize services
ICalculatorService calculatorService = new CalculatorService();
ICalculationRepository repository = new InMemoryCalculationRepository();

// Perform calculation
decimal result = calculatorService.Calculate("+", 10, 5);

// Save to repository
var calculation = new CalculationOperation
{
    Operand1 = 10,
    Operand2 = 5,
    Operator = "+",
    Result = result
};
repository.SaveCalculation(calculation);
Accessing History

// Get calculation history
var history = repository.GetHistory();

foreach (var calc in history)
{
    Console.WriteLine($"{calc.Operand1} {calc.Operator} {calc.Operand2} = {calc.Result}");
}

📁 Project Structure

./
├── calculator_class_example.csproj    # Main solution file
├── calculator_class_example.sln       # Visual Studio solution
├── LICENSE                           # MIT License
├── README.md                         # This documentation
│
├── API/                              # Web API Layer (ASP.NET Core)
│   ├── API.csproj                    # API project configuration
│   ├── Program.cs                    # API entry point
│   ├── appsettings.json              # Configuration
│   ├── appsettings.Development.json  # Development configuration
│   ├── Controllers/                  # API Controllers
│   │   └── CalculationController.cs  # Calculator API endpoints
│   └── Properties/                   # Launch settings
│       └── launchSettings.json       # Debug/launch profiles
│
├── calculator_class_example/          # Core Domain Project (like CalculatorDomainDemo)
│   ├── calculator_class_example.csproj # Domain project configuration
│   │
│   ├── Domain/                       # Domain Layer - Core business entities
│   │   ├── Calculation.cs            # Main Calculation domain model
│   │   ├── CalculationRequest.cs     # Request DTO for calculations
│   │   └── OperationType.cs          # Enum for operations (Add, Subtract, etc.)
│   │
│   ├── Logic/                        # Business Logic Layer
│   │   ├── CalculationService.cs     # Core calculation business logic
│   │   └── CalculationHistoryException.cs # Custom domain exceptions
│   │
│   ├── Persistence/                  # Data Access Layer
│   │   ├── ICalculationStore.cs      # Repository interface (abstraction)
│   │   └── FileCalculationStore.cs   # File-based implementation
│   │
│   └── Data/                         # Data Storage
│       └── calculation.json          # JSON file for calculation history
│
├── bin/                              # Build outputs (gitignored)
└── obj/                              # Intermediate objects (gitignored)

Architecture Layer Breakdown
Layer	Location	Purpose	Skye's Equivalent
Presentation	API/	Web API interface	API/CalculatorDomainDemo/
Domain	calculator_class_example/Domain/	Business entities & enums	Domain/
Logic	calculator_class_example/Logic/	Business rules & services	Logic/
Persistence	calculator_class_example/Persistence/	Data access abstraction	Persistence/
Data Storage	calculator_class_example/Data/	Physical storage	Data/
Key Architectural Patterns
Layered Architecture - Clear separation of concerns

Repository Pattern - ICalculationStore abstraction

Dependency Injection - Services depend on interfaces

Domain-Driven Design - Rich domain model with business rules

Web API Layer - RESTful endpoints for calculator operations

Build & Run Commands
bash
# Build the entire solution
dotnet build calculator_class_example.sln

# Run the Web API
cd API
dotnet run

# Run the domain project tests
cd calculator_class_example
dotnet test



🧪 Testing
Running Tests

# Build and run tests (test project to be added)
dotnet test

# Run with specific configuration
dotnet test --configuration Release
Test Structure Example
csharp
// Example test for CalculatorService
[Fact]
public void CalculatorService_Add_TwoNumbers_ReturnsCorrectSum()
{
    // Arrange
    var service = new CalculatorService();
    decimal expected = 15;
    
    // Act
    decimal result = service.Calculate("+", 10, 5);
    
    // Assert
    Assert.Equal(expected, result);
}

[Fact]
public void CalculatorService_Divide_ByZero_ThrowsException()
{
    // Arrange
    var service = new CalculatorService();
    
    // Act & Assert
    Assert.Throws<DivideByZeroException>(() => 
        service.Calculate("/", 10, 0));
}

🤝 Contributing
We welcome contributions to enhance the layered architecture!

Development Workflow
Fork the repository

Create a feature branch: git checkout -b feature/enhance-layer

Commit changes: git commit -m "feat: add validation service layer"

Push to branch: git push origin feature/enhance-layer

Open a Pull Request

Architecture Guidelines
Maintain clear layer boundaries

Add interfaces before implementations

Keep domain models pure (no dependencies)

Use dependency injection patterns

Write tests for new features

Branch Strategy
main - Production-ready code

develop - Integration branch for features

feature/* - New architectural features

refactor/* - Architecture improvements

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

MIT License
Copyright (c) 2024 BitCube Training Program

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
🔄 Migration Notes
From v3.0 to v4.0 (Layered Architecture)
This version represents a complete architectural transformation:

v3.0 (Previous)	v4.0 (Current)	Benefit
Basic Console App	Layered Architecture	Better separation of concerns
Monolithic Structure	Domain-Driven Design	More maintainable, testable
Limited Abstraction	Repository & Service Patterns	Easier to extend and modify
Direct Data Access	Abstracted Data Layer	Future database integration ready
Simple Error Handling	Structured Validation	Professional error management
Learning Journey
This project demonstrates the evolution from:

Basic C# Console Application → Layered Architecture

Simple Calculator → Domain-Driven Calculator Domain

Direct Code → Patterns & Best Practices

Learning Project → Portfolio-Ready Application

<div align="center">
Built with precision • Architected for scale • Designed for learning

Part of the BitCube Professional Software Development Training Program

🎓 Demonstrating Enterprise .NET Development with Layered Architecture

</div> ```
./
    calculator_class_example.csproj
    calculator_class_example.sln
    LICENSE
    README.md
.git/
API/
    API/API.csproj
    API/appsettings.Development.json
    API/appsettings.json
    API/Program.cs
API/bin/
API/bin/Debug/
API/bin/Debug/net8.0/
API/Controllers/
    API/Controllers/CalculationController.cs
API/obj/
API/obj/Debug/
API/obj/Debug/net8.0/
    API/obj/Debug/net8.0/.NETCoreApp,Version=v8.0.AssemblyAttributes.cs
    API/obj/Debug/net8.0/API.AssemblyInfo.cs
    API/obj/Debug/net8.0/API.GlobalUsings.g.cs
API/obj/Debug/net8.0/ref/
API/obj/Debug/net8.0/refint/
API/Properties/
    API/Properties/launchSettings.json
bin/
calculator_class_example/
    calculator_class_example/calculator_class_example.csproj
calculator_class_example/Data/
    calculator_class_example/Data/calculation.json
calculator_class_example/Domain/
    calculator_class_example/Domain/Calculation.cs
    calculator_class_example/Domain/CalculationRequest.cs
    calculator_class_example/Domain/OperationType.cs
calculator_class_example/Entities/
    calculator_class_example/Entities/CalculationOperation.cs
    calculator_class_example/Entities/Calculator.cs
calculator_class_example/Logic/
    calculator_class_example/Logic/CalculationHistoryException.cs
    calculator_class_example/Logic/CalculationService.cs
calculator_class_example/Persistance/
    calculator_class_example/Persistance/FileCalculationStore.cs
    calculator_class_example/Persistance/ICalculationStore.cs
obj/
    obj/CalculatorDomainDemo.csproj.nuget.dgspec.json
    obj/project.assets.json
```
# File Structure

```
./
    calculator_class_example.csproj
    calculator_class_example.sln
    LICENSE
    README.md
.git/
API/
    API/API.csproj
    API/appsettings.Development.json
    API/appsettings.json
    API/Program.cs
API/bin/
API/bin/Debug/
API/bin/Debug/net8.0/
API/Controllers/
    API/Controllers/CalculationController.cs
API/obj/
API/obj/Debug/
API/obj/Debug/net8.0/
    API/obj/Debug/net8.0/.NETCoreApp,Version=v8.0.AssemblyAttributes.cs
    API/obj/Debug/net8.0/API.AssemblyInfo.cs
    API/obj/Debug/net8.0/API.GlobalUsings.g.cs
API/obj/Debug/net8.0/ref/
API/obj/Debug/net8.0/refint/
API/Properties/
    API/Properties/launchSettings.json
bin/
calculator_class_example/
    calculator_class_example/calculator_class_example.csproj
calculator_class_example/Data/
    calculator_class_example/Data/calculation.json
calculator_class_example/Domain/
    calculator_class_example/Domain/Calculation.cs
    calculator_class_example/Domain/CalculationRequest.cs
    calculator_class_example/Domain/OperationType.cs
calculator_class_example/Entities/
    calculator_class_example/Entities/CalculationOperation.cs
    calculator_class_example/Entities/Calculator.cs
calculator_class_example/Logic/
    calculator_class_example/Logic/CalculationHistoryException.cs
    calculator_class_example/Logic/CalculationService.cs
calculator_class_example/Persistance/
    calculator_class_example/Persistance/FileCalculationStore.cs
    calculator_class_example/Persistance/ICalculationStore.cs
obj/
    obj/CalculatorDomainDemo.csproj.nuget.dgspec.json
    obj/project.assets.json
```
