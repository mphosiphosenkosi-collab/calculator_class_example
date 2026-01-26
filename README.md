</div> ```
🧮 BitCube Pro Calculator v3.0.0 - .NET 8 C# Edition
https://img.shields.io/badge/.NET-8.0-purple
https://img.shields.io/badge/C%2523-12.0-blue
https://img.shields.io/badge/build-passing-brightgreen
https://img.shields.io/badge/license-MIT-green
https://img.shields.io/badge/code%2520style-Microsoft%2520C%2523-blue

A professional .NET 8 C# calculator with SOLID architecture, built for enterprise applications and professional portfolio demonstrations.

📖 Table of Contents
🎯 About

✨ Features

🚀 Quick Start

⚙️ Installation

💻 Usage

🏗️ Project Structure

🧪 Testing

🔄 CI/CD Pipeline

🤝 Contributing

📄 License

📞 Support

🎯 About
BitCube Pro Calculator .NET Edition is a professional-grade C# application demonstrating modern .NET 8 development, SOLID principles, and enterprise software engineering best practices. Built with clean architecture, it features a robust console interface with full operation history tracking — portfolio-ready for internships and technical demonstrations.

Educational Purpose
This project serves as a learning tool for:

.NET 8 and C# 12 modern features

SOLID principles and clean architecture

Professional C# development patterns

Git/GitHub collaboration workflows

CI/CD pipeline implementation with GitHub Actions

Unit testing with xUnit

✨ Features
Core Architecture
🏗️ SOLID Principles - Clean separation of concerns

🔧 Dependency Inversion - Interface-based design

📦 Modular Design - Easy to extend and maintain

🎯 Clean Architecture - Domain, Application, Infrastructure separation

Calculator Features
➕ Basic Operations - Addition, Subtraction, Multiplication, Division

🔢 Advanced Operations - Power, Square Root (easily extendable)

📊 Operation History - Full tracking with timestamps

✅ Error Handling - Comprehensive validation and error messages

🚫 Division by Zero Protection - Safe mathematical operations

Technical Features
⚡ .NET 8 Performance - High-performance calculations

📚 Professional Documentation - XML documentation comments

🧪 Test-Driven Development - xUnit test suite ready

🔄 CI/CD Ready - GitHub Actions pipeline included

🎨 Console UI - Clean, user-friendly interface with color support

🚀 Quick Start
Prerequisites
.NET 8 SDK or later

Visual Studio Code or Visual Studio 2022

Git for version control

Method 1: Using VS Code
bash
# Clone the repository
git clone https://github.com/mphosiphosenkosi-collab/git-fundamentals-practice.git
cd git-fundamentals-practice

# Restore dependencies and build
dotnet restore
dotnet build

# Run the calculator
dotnet run --project Calculator.App
Method 2: Using Visual Studio
Open ProfessionalCalculator.sln in Visual Studio 2022

Set Calculator.App as startup project

Press F5 to run

⚙️ Installation
Step-by-Step Setup
bash
# 1. Clone repository
git clone https://github.com/mphosiphosenkosi-collab/git-fundamentals-practice.git
cd git-fundamentals-practice

# 2. Verify .NET installation
dotnet --version  # Should show 8.0+

# 3. Restore dependencies
dotnet restore

# 4. Build the solution
dotnet build

# 5. Run the application
dotnet run --project Calculator.App
Development Environment Setup
bash
# Install VS Code extensions (if using VS Code)
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.csdevkit
code --install-extension ms-dotnettools.vscodeintellicode
💻 Usage
Console Application
When you run the application, you'll see:

text
=== Professional Calculator ===
Built with .NET 8 | Professional Scrum Practices

=== Main Menu ===
1. Addition (+)
2. Subtraction (-)
3. Multiplication (*)
4. Division (/)
5. Power (^)
6. Square Root (√)
8. View History
0. Exit

Select operation: 1
Enter operand(s) for Addition: 10 20

✓ Result: 30
  Operation: Addition
  Timestamp: 2024-01-15 14:30:45
Available Operations
csharp
// Sample usage through code
var calculator = new CalculatorService();

// Basic operations
var result = calculator.Calculate(OperationType.Add, 10, 20);
// Result: 30

// Advanced operations
var powerResult = calculator.Calculate(OperationType.Power, 2, 3);
// Result: 8

var sqrtResult = calculator.Calculate(OperationType.SquareRoot, 16);
// Result: 4
Operation History
Access complete history with statistics:

text
=== Operation History ===
Total Operations: 5
Successful: 4
Failed: 1

✓ Addition       | Result: 30            | 14:30:45
✓ Subtraction    | Result: 10            | 14:31:22
✗ Division       | N/A                   | 14:32:10
   Error: Cannot divide by zero
✓ Multiplication | Result: 50            | 14:33:45
✓ Power          | Result: 8             | 14:34:20
🏗️ Project Structure
text
ProfessionalCalculator/
├── 📁 Calculator.Core/                # Core domain and business logic
│   ├── 📁 Models/                    # Data models and DTOs
│   │   ├── CalculatorResult.cs       # Operation result model
│   │   └── OperationType.cs          # Operation enum
│   ├── 📁 Contracts/                 # Interfaces and abstractions
│   │   └── IOperation.cs             # Operation contract
│   ├── 📁 Operations/                # Operation implementations
│   │   ├── BaseOperation.cs          # Abstract base class
│   │   ├── AdditionOperation.cs      # Addition implementation
│   │   ├── SubtractionOperation.cs   # Subtraction implementation
│   │   └── ... (other operations)    # Other mathematical operations
│   └── 📁 Services/                  # Business services
│       ├── ICalculatorService.cs     # Service interface
│       └── CalculatorService.cs      # Main calculator service
├── 📁 Calculator.App/                # Console application
│   └── Program.cs                    # Application entry point
├── 📁 Calculator.Tests/              # Unit test project (to add)
│   ├── UnitTest1.cs                  # Sample test
│   └── Calculator.Tests.csproj       # Test project file
├── 📁 .github/workflows/             # GitHub Actions workflows
│   └── dotnet.yml                    # .NET CI/CD pipeline
├── 📄 ProfessionalCalculator.sln     # Solution file
├── 📄 README.md                      # This documentation
├── 📄 LICENSE                        # MIT License
├── 📄 .gitignore                     # Git ignore rules
└── 📄 .editorconfig                  # Code style configuration
Architecture Overview
Domain Layer (Calculator.Core/Models/) - Business entities

Application Layer (Calculator.Core/Contracts/, Calculator.Core/Services/) - Business logic

Infrastructure Layer (Calculator.Core/Operations/) - Implementation details

Presentation Layer (Calculator.App/) - User interface

🧪 Testing
Setting Up Tests
bash
# Create test project
dotnet new xunit --name Calculator.Tests --framework net8.0
dotnet sln add Calculator.Tests/
cd Calculator.Tests
dotnet add reference ../Calculator.Core/
Running Tests
bash
# Run all tests
dotnet test

# Run specific test project
dotnet test Calculator.Tests/

# Run with coverage (requires coverlet)
dotnet test --collect:"XPlat Code Coverage"
Sample Test Structure
csharp
// Calculator.Tests/CalculatorServiceTests.cs
public class CalculatorServiceTests
{
    private readonly ICalculatorService _calculator;
    
    public CalculatorServiceTests()
    {
        _calculator = new CalculatorService();
    }
    
    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectSum()
    {
        // Arrange
        var expected = 15;
        
        // Act
        var result = _calculator.Calculate(OperationType.Add, 10, 5);
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
    }
    
    [Fact]
    public void Divide_ByZero_ReturnsError()
    {
        // Act
        var result = _calculator.Calculate(OperationType.Divide, 10, 0);
        
        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Cannot divide by zero", result.ErrorMessage);
    }
}
🔄 CI/CD Pipeline
GitHub Actions Workflow (.github/workflows/dotnet.yml)
yaml
name: .NET CI/CD

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main ]

jobs:
  build-and-test:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
        
    - name: Restore dependencies
      run: dotnet restore
      
    - name: Build
      run: dotnet build --no-restore
      
    - name: Test
      run: dotnet test --no-build --verbosity normal
      
    - name: Publish
      run: dotnet publish -c Release -o ./publish
      
    - name: Upload artifact
      uses: actions/upload-artifact@v3
      with:
        name: calculator-app
        path: ./publish
Pipeline Features
✅ Automated builds on every push

✅ Unit test execution for quality assurance

✅ Artifact generation for deployment

✅ Multi-branch support (main, develop)

✅ Pull request validation

🤝 Contributing
Development Workflow
Fork the repository

Create feature branch: git checkout -b feature/new-operation

Commit changes: git commit -m "feat: add trigonometric functions"

Push: git push origin feature/new-operation

Create Pull Request

Commit Convention
bash
# Format: type(scope): description
feat(calculator): add exponentiation support
fix(operations): resolve division by zero handling
docs(readme): update installation instructions
test(services): add calculator service tests
refactor(architecture): implement repository pattern
Code Standards
Follow Microsoft C# Coding Conventions

Use XML documentation comments for public members

Implement proper error handling and validation

Write unit tests for new features

Update documentation as needed

Branch Strategy
main - Production-ready code

develop - Integration branch

feature/* - New features

bugfix/* - Bug fixes

release/* - Release preparation

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

text
MIT License
Copyright (c) 2024 BitCube Training Program

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
📞 Support
Project Contacts
Role	Contact	Responsibilities
Maintainer	[Your Name]	Architecture, code reviews
Testing Lead	[Team Member]	Test suite maintenance
Documentation	[Team Member]	API documentation, guides
DevOps	[Team Member]	CI/CD pipeline management
Getting Help
Issues: GitHub Issues

Discussions: GitHub Discussions

Email: [your-email]@bitcube.tech

Classroom Context
Course: .NET 8 & C# Professional Development

Module: SOLID Principles & Clean Architecture

Instructor: [Instructor Name]

Term: 2026 Q1

Tech Stack: .NET 8, C# 12, xUnit, GitHub Actions

Learning Path
Week 1: C# Fundamentals & .NET SDK

Week 2: Object-Oriented Design & SOLID Principles

Week 3: Clean Architecture & Design Patterns

Week 4: Testing & CI/CD Implementation

Week 5: Advanced Features & Portfolio Preparation

<div align="center">
Built with precision • Designed for learning • Ready for portfolios

Part of the BitCube Professional Software Development Training Program

Transitioning from Python to Enterprise .NET Development

</div>
Migration Notes
This .NET 8 version builds upon the original Python project with:

✅ Enhanced type safety with C#'s strong typing

✅ Better performance with .NET 8's optimizations

✅ Enterprise-ready architecture with SOLID principles

✅ Improved scalability with modular design

✅ Professional tooling with Visual Studio/VS Code ecosystem