namespace GenericOperationsUtility.String
{
    public class CalculationUtility : ICalculationUtility<string>
    {
        public string Add(string a, string b) => a + b;

        public string Subtract(string a, string b)
        {
            throw new NotSupportedException("Subtraction is not supported for strings.");
        }

        public string Multiply(string a, string b)
        {
            throw new NotSupportedException("Multiplication is not supported for strings.");
        }

        public string Divide(string a, string b, out string quotient, out string remainder)
        {
            throw new NotSupportedException("Division is not supported for strings.");
        }
    }
}
