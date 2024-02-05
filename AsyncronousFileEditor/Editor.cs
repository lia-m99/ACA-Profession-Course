namespace AsyncronousFileEditor
{
    public class Editor
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public static async Task EditTextFileAsync(string filePath)
        {
            try
            {
                await semaphore.WaitAsync();
                FileHelper fileHelper = new FileHelper();
                string content = await fileHelper.ReadFileAsync(filePath);

                Console.WriteLine($"\nCurrent content of the file:\n{content}");

                Console.Write("\nEnter the new text: ");
                string? newText = Console.ReadLine();

                await fileHelper.WriteFileAsync(filePath, newText ?? "");

                Console.WriteLine("File successfully updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                semaphore.Release();
            }
        }

        public static async Task PrintTextFileAsync(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    char[] buffer = new char[4096];
                    int bytesRead;

                    Console.WriteLine("Reading and printing file content asynchronously:");

                    while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        string chunk = new string(buffer, 0, bytesRead);
                        Console.Write(chunk);
                    }

                    Console.WriteLine("\nFile reading completed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static async Task ConcurrentEditingAsync()
        {
            try
            {
                Console.WriteLine("Enter paths of text files to edit (comma-separated): ");
                string? filePathsInput = Console.ReadLine();

                if (filePathsInput == null)
                {
                    throw new Exception("Paths are required");
                }

                string[] filePaths = filePathsInput.Split(',');

                List<Task> editingTasks = new List<Task>();

                Console.WriteLine("Enter the new text:\n");

                string? newText = Console.ReadLine();

                var fileHelper = new FileHelper();

                foreach (var filePath in filePaths)
                {
                    editingTasks.Add(fileHelper.WriteFileAsync(filePath.Trim(), newText ?? ""));
                }

                await Task.WhenAll(editingTasks);

                Console.WriteLine("Concurrent editing sessions completed.");
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine($"An error occurred: {innerEx.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static string GetPath()
        {
            Console.Write("Enter the path of the text file: ");
            string? filePath = Console.ReadLine();

            if (filePath == null)
            {
                throw new Exception("File path is required!");
            }
            return filePath;
        }
    }
}
