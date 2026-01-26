#!/bin/bash
echo "=== Simulating GitHub Actions ==="

# Clean first
echo "1. Cleaning..."
rm -rf Calculator.App/bin Calculator.App/obj 2>/dev/null

# Run YML commands
echo "2. Restoring dependencies..."
dotnet restore Calculator.App/Calculator.App.csproj

echo "3. Building..."
dotnet build Calculator.App/Calculator.App.csproj --no-restore --verbosity minimal

# Check result
if [ $? -eq 0 ]; then
    echo "‚úÖ SUCCESS: Build passed!"
    echo "Ìæâ Ready for GitHub Actions!"
else
    echo "‚ùå FAILED: Build error"
    exit 1
fi
