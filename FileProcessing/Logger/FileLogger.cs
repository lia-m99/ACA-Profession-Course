namespace FileProcessing.Logger
{
    public class FileLogger : ILogger
    {
        private static FileLogger? _instance;
        private readonly string _logFilePath;

        private FileLogger(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            _logFilePath = filePath;
        }

        public static FileLogger GetInstance(string filePath)
        {
            if (_instance == null)
            {
                lock (typeof(FileLogger))
                {
                    if (_instance == null)
                    {
                        _instance = new FileLogger(filePath);
                    }
                }
            }

            return _instance;
        }

        public void Info(string message)
        {
            Log("INFO", message);
        }

        public void Warn(string message)
        {
            Log("WARN", message);
        }

        public void Error(string message, Exception exception)
        {
            Log("ERROR", $"{message}{Environment.NewLine}{exception}");
        }

        private void Log(string logLevel, string message)
        {
            string logEntry = $"{DateTime.Now} [{logLevel}] {message}";

            lock (this)
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
        }
    }
}
