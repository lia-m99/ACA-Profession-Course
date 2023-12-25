namespace GenericOperationsUtility.Numeric
{
    public class CalculationUtility : ICalculationUtility<int>
    {
        public int Add(int a, int b) => a + b;

        public int Subtract(int a, int b) => a - b;

        public int Multiply(int a, int b) => a * b;

        public int Divide(int a, int b, out int quotient, out int remainder)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            quotient = a / b;
            remainder = a % b;
            return quotient;
        }
    }
}
