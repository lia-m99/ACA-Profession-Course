using FileProcessing.Exceptions;
using FileProcessing.Logger;

namespace FileProcessing.Calculator
{
    public class AvarageCalculator : IAvarageCalculator
    {
        public double Calculate(double[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                throw new LoggedFormatException("The array must not be null or empty.", FileLogger.GetInstance("error_log.txt"));
            }

            double sum = 0;

            foreach (var num in nums)
            {
                sum += num;
            }

            return sum / nums.Length;
        }
    }
}
