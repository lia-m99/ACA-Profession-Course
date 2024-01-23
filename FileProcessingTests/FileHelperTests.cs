using NUnit.Framework.Internal;
using FileProcessing.FileProcessor;
using FileProcessing.Exceptions;
using FileProcessing.Logger;

namespace FileProcessing.Tests
{
    [TestFixture]
    public class FileHelperTests
    {
        private static string _rootPath = AppDomain.CurrentDomain.BaseDirectory;

        private static string _testFilePath = string.Concat(_rootPath, "test_file.txt");

        // Check the file content after executing the tests.
        private FileHelper _fileHelper = new FileHelper(FileLogger.GetInstance("../../../test_log.txt"));

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Read_ValidFile_ContentReadSuccessfully()
        {
            File.WriteAllText(_testFilePath, "1\n2\n3");

            var content = _fileHelper.Read(_testFilePath);

            Assert.That(content, Is.Not.Null);
            Assert.That(content.Length, Is.EqualTo(3));
            Assert.That(content[0], Is.EqualTo("1"));
            Assert.That(content[1], Is.EqualTo("2"));
            Assert.That(content[2], Is.EqualTo("3"));
        }

        [Test]
        public void Read_FileNotFound_ThrowsLoggedFileNotFoundException()
        {
            var ex = Assert.Throws<LoggedFileNotFoundException>(() => _fileHelper.Read("nonexistent_file.txt"));
        }

        [Test]
        public void Read_IOException_ThrowsLoggedIOException()
        {
            // Trying to reed directory path instead of file
            var ex = Assert.Throws<LoggedIOException>(() => _fileHelper.Read(_rootPath));
        }

        [Test]
        public void Write_ValidContentToFile_ContentWrittenSuccessfully()
        {
            File.WriteAllText(_testFilePath, "1\n2\n3");

            string[] content = { "4", "5", "6" };

            _fileHelper.Write(_testFilePath, content);

            Assert.IsTrue(File.Exists(_testFilePath));
            var fileContent = File.ReadAllLines(_testFilePath);
            Assert.That(fileContent.Length, Is.EqualTo(3));
            Assert.That(fileContent[0], Is.EqualTo("4"));
            Assert.That(fileContent[1], Is.EqualTo("5"));
            Assert.That(fileContent[2], Is.EqualTo("6"));
        }

        [Test]
        public void Write_FileAlreadyExists_LoggerWarns()
        {
            File.WriteAllText(_testFilePath, "1\n2\n3");
            string[] content = { "4", "5", "6" };

            _fileHelper.Write(_testFilePath, content);
        }

        [Test]
        public void Write_IOException_ThrowsLoggedIOException()
        {
            // Trying to write to directory path instead of file
            var ex = Assert.Throws<LoggedIOException>(() => _fileHelper.Write(_rootPath, new[] { "4", "5", "6" }));
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}
