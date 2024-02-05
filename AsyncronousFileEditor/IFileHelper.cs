namespace AsyncronousFileEditor
{
    public interface IFileHelper
    {
        Task<string> ReadFileAsync(string filePath);

        Task WriteFileAsync(string filePath, string content);
    }
}
