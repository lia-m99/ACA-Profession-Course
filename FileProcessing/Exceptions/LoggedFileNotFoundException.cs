using FileProcessing.Logger;

namespace FileProcessing.Exceptions
{
    public class LoggedFileNotFoundException : FileNotFoundException, ILoggedException
    {
        private readonly ILogger _logger;

        public LoggedFileNotFoundException(string message, ILogger logger)
            : base(message)
        {
            _logger = logger;

            LogException();
        }

        public void LogException()
        {
            _logger.Error($"File not found: {FileName}", this);
        }
    }
}
