using GenericOperationsUtility;

using numericCalculatorUtility = GenericOperationsUtility.Numeric.CalculationUtility;
using stringCalculatorUtility = GenericOperationsUtility.String.CalculationUtility;

class Program
{
    static void Main()
    {
        ICalculationUtility<int> numericCalculator = new numericCalculatorUtility();
        PerformNumericCalculations(numericCalculator);

        Console.WriteLine();

        ICalculationUtility<string> stringCalculator = new stringCalculatorUtility();
        PerformStringCalculations(stringCalculator);
    }

    static void PerformNumericCalculations(ICalculationUtility<int> calculator)
    {
        int num1 = 10, num2 = 5;

        Console.WriteLine($"Numeric Addition: {calculator.Add(num1, num2)}");
        Console.WriteLine($"Numeric Subtraction: {calculator.Subtract(num1, num2)}");
        Console.WriteLine($"Numeric Multiplication: {calculator.Multiply(num1, num2)}");

        int quotient, remainder;
        Console.WriteLine($"Numeric Division: {calculator.Divide(num1, num2, out quotient, out remainder)}");
        Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");
    }

    static void PerformStringCalculations(ICalculationUtility<string> calculator)
    {
        string str1 = "Hello", str2 = "World";

        Console.WriteLine($"String Concatenation: {calculator.Add(str1, str2)}");

        PerformStringOperationWithErrorHandling("Subtraction", () => calculator.Subtract(str1, str2));
        PerformStringOperationWithErrorHandling("Multiplication", () => calculator.Multiply(str1, str2));
        PerformStringDivision(calculator, str1, str2);
    }

    static void PerformStringOperationWithErrorHandling(string operation, Action operationAction)
    {
        try
        {
            operationAction.Invoke();
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"String {operation} Error: {ex.Message}");
        }
    }

    static void PerformStringDivision(ICalculationUtility<string> calculator, string str1, string str2)
    {
        try
        {
            string result = calculator.Divide(str1, str2, out string quotientStr, out string remainderStr);
            Console.WriteLine($"String Division: {result}");
            Console.WriteLine($"Quotient: {quotientStr}, Remainder: {remainderStr}");
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"String Division Error: {ex.Message}");
        }
    }
}
