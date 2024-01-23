namespace FileProcessing.Converter
{
    public interface IStringToDoubleConverter
    {
        public double ToDouble(string value);

        public double[] ConvertToDoubleArray(string[] value);
    }
}
