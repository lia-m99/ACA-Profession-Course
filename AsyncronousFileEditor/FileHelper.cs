using System.Text;

namespace AsyncronousFileEditor
{
    public class FileHelper : IFileHelper
    {
        public async Task<string> ReadFileAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteFileAsync(string filePath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}
