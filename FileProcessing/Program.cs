using FileProcessing.Calculator;
using FileProcessing.Converter;
using FileProcessing.FileProcessor;
using FileProcessing.Logger;

class Program
{
    // If the running directory is nested such as "FileProcessing\bin\Debug\net[version]"
    // Then "../../../" will create the files in the root directory such as "FileProcessing"
    private const string _inputFile = "../../../input.txt";
    private const string _outputFile = "../../../output.txt";

    static void Main()
    {
        IFileProcessor fileHelper = new FileHelper(FileLogger.GetInstance("../../../error_log.txt"));

        try
        {
            MainConversionLogic(fileHelper);

            shouldFailFileNotFound(fileHelper);

            shouldFailInvalidFormat(fileHelper);

            shouldFailIO(fileHelper);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled Exception occured. {ex.Message}");
        }
    }

    private static void MainConversionLogic(IFileProcessor fileHelper)
    {
        var stringArray = fileHelper.Read(_inputFile);
        var doubleArray = fromStringArray(stringArray);

        var average = CalculateAvarage(doubleArray);

        var loggedText = $"The Calculated avarage is {average}\n\n";
        Console.WriteLine(loggedText);

        fileHelper.Write(_outputFile, new[] { loggedText });
    }

    private static void shouldFailFileNotFound(IFileProcessor fileHelper)
    {
        try
        {
            fileHelper.Read("unknown_file.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File not found. Please make sure the file exists. {ex.Message}. \n Check error_log.txt for more details.\n\n");
        }
    }

    private static void shouldFailInvalidFormat(IFileProcessor fileHelper)
    {
        try
        {
            File.WriteAllText("tmp_file.txt", "aa 1\n2\n3");

            var content = fileHelper.Read("tmp_file.txt");

            var doubles = fromStringArray(content);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: Invalid format in the input file. {ex.Message}. \n Check error_log.txt for more details.\n\n");
        }
    }

    private static void shouldFailIO(IFileProcessor fileHelper)
    {
        try
        {
            fileHelper.Read("../../../"); // directory path.
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: An IO exception occurred while processing the file. {ex.Message} . \n Check error_log.txt for more details.\n\n");
        }
    }

    private static double[] fromStringArray(string[] stringArray)
    {
        IStringToDoubleConverter converter = new StringToDoubleConverter();

        return converter.ConvertToDoubleArray(stringArray);
    }

    private static double CalculateAvarage(double[] doubles)
    {
        IAvarageCalculator calculator = new AvarageCalculator();
        return calculator.Calculate(doubles);
    }
}