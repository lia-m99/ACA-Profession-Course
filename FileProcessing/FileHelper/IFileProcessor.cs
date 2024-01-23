namespace FileProcessing.FileProcessor
{
    public interface IFileProcessor
    {
        string[] Read(string path);

        void Write(string path, string[] content);
    }
}
