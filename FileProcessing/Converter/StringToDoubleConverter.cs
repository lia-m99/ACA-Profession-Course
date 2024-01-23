using FileProcessing.Exceptions;
using FileProcessing.Logger;

namespace FileProcessing.Converter
{
    public class StringToDoubleConverter : IStringToDoubleConverter
    {
        public double[] ConvertToDoubleArray(string[] stringArray)
        {
            if (stringArray == null)
            {
                throw new LoggedFormatException("The input array must not be null.", FileLogger.GetInstance("error_log.txt"));
            }

            double[] doubleArray = new double[stringArray.Length];

            for (int i = 0; i < stringArray.Length; ++i)
            {

                doubleArray[i] = ToDouble(stringArray[i]);
            }

            return doubleArray;
        }

        public double ToDouble(string value)
        {
            if (!double.TryParse(value, out double convertedValue))
            {
                throw new LoggedFormatException($"Invalid double value {value}", FileLogger.GetInstance("error_log.txt"));
            }

            return convertedValue;
        }
    }
}