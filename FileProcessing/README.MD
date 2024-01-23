# File Processing Console Application

This is a C# console application designed to read data from a text file, perform some operations, and write the results to an output file. Robust exception handling has been implemented to address potential errors during file operations.

## Project Structure

### `FileProcessing.Calculator.AverageCalculator`

This class calculates the average of an array of doubles. It throws a `LoggedFormatException` if the input array is null or empty.

### `FileProcessing.Converter.StringToDoubleConverter`

This class converts an array of strings to an array of doubles. It throws a `LoggedFormatException` if the input array is null or contains non-numeric data.

### `FileProcessing.Exceptions`

This namespace contains custom exception classes that extend the standard .NET exceptions and implement the `ILoggedException` interface. Each exception logs an error message using the `FileLogger` when constructed.

- `LoggedFileNotFoundException`: Logs a "File not found" error.
- `LoggedFormatException`: Logs a "Format exception" error.
- `LoggedIOException`: Logs an "IO exception" error.

### `FileProcessing.FileProcessor.FileHelper`

This class implements the `IFileProcessor` interface and provides methods for reading from and writing to text files. It handles exceptions using try-catch blocks and logs errors using the `FileLogger`.

### `FileProcessing.Logger.FileLogger`

This class implements the `ILogger` interface and is responsible for logging messages to a file. It is a singleton class, ensuring a single instance throughout the application. The log file is specified when obtaining an instance through `GetInstance`.

### `Program`

This is the entry point of the application. It demonstrates the usage of the classes and handles exceptions as specified in the requirements.

## Usage

1. Clone the repository.
2. Run the application.
3. Check the console output for the calculated average.
4. View the `output.txt` file for the result.
5. Check the `error_log.txt` file for any encountered exceptions.

Feel free to customize the input data in `input.txt` to test different scenarios.

For any issues, refer to the error log for detailed information.

**Note:** Ensure that the running directory is appropriately set for file access and logging.
