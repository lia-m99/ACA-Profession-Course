namespace AsyncronousFileEditor
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                Console.WriteLine("Welcome to the Asynchronous Text File Editor!");

                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Input the path of a text file for editing.");
                    Console.WriteLine("2. Input the path of a text file for reading asynchronously.");
                    Console.WriteLine("3. Input the paths of text files for concurrent editing.");

                    Console.Write("Enter your choice: ");
                    string? choice = Console.ReadLine();

                    if (choice == null)
                    {
                        continue;
                    }

                    switch (choice)
                    {
                        case "1":
                            await Editor.EditTextFileAsync(Editor.GetPath());
                            break;
                        case "2":
                            await Editor.PrintTextFileAsync(Editor.GetPath());
                            break;
                        case "3":
                            await Editor.ConcurrentEditingAsync();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}