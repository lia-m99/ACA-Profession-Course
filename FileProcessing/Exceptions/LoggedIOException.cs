using FileProcessing.Logger;

namespace FileProcessing.Exceptions
{
    public class LoggedIOException : IOException, ILoggedException
    {
        private readonly ILogger _logger;

        public LoggedIOException(string message, ILogger logger)
            : base(message)
        {
            _logger = logger;

            LogException();
        }

        public void LogException()
        {
            _logger.Error($"IO exception: {Message}", this);
        }
    }
}
