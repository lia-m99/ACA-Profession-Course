using FileProcessing.Logger;

namespace FileProcessing.Exceptions
{
    public class LoggedFormatException : FormatException, ILoggedException
    {
        private readonly ILogger _logger;

        public LoggedFormatException(string message, ILogger logger)
            : base(message)
        {
            _logger = logger;

            LogException();
        }

        public void LogException()
        {
            _logger.Error($"Format exception: {Message}", this);
        }
    }
}
