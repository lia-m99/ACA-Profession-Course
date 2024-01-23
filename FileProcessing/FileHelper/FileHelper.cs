using FileProcessing.Exceptions;
using FileProcessing.Logger;

namespace FileProcessing.FileProcessor
{
    public class FileHelper : IFileProcessor
    {
        ILogger _logger;

        public FileHelper(ILogger logger)
        {
            _logger = logger;
        }

        public string[] Read(string path)
        {
            string[] content;
            try
            {
                content = File.ReadAllLines(path);
            }
            catch (FileNotFoundException e) {
                throw new LoggedFileNotFoundException(e.Message, _logger);
            }
            catch (IOException e)
            {
                throw new LoggedIOException(e.Message, _logger);
            }

            _logger.Info($"File content read from {path}");

            return content;
        }

        public void Write(string path, string[] content)
        {
            if (File.Exists(path))
            {
                _logger.Warn($"The file {path} already exists. Writing will overwrite existing content.");
            }

            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var number in content)
                    {
                        sw.WriteLine(number);
                    }
                }
            }
            catch (IOException e) {
                throw new LoggedIOException(e.Message, _logger);
            }
        }
    }
}
