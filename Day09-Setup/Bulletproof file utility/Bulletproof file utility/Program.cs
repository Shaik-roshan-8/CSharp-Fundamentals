using System;
using System.Diagnostics.Tracing;
namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== File Utility Menu ===");
                Console.WriteLine("1. Create a file");
                Console.WriteLine("2. Read a file");
                Console.WriteLine("3. Append to a file");
                Console.WriteLine("4. Count lines and words");
                Console.WriteLine("5. Copy a file");
                Console.WriteLine("6. Delete a file");
                Console.WriteLine("7. List a directory");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateFile();
                        break;
                    case "2":
                        ReadFile();
                        break;
                    case "3":
                        AppendFile();
                        break;
                    case "4":
                        CountFile();
                        break;
                    case "5":
                        Copyfile();
                        break;
                    case "6":
                        DeleteFile();
                        break;
                    case "7":
                        ListDirectory();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        public static void CreateFile()
        {
            try
            {
                Console.Write("Enter folder path: ");    // done with path.combine 
                string folder = Console.ReadLine();

                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();

                string path = Path.Combine(folder, fileName);

                Console.Write("Enter content: ");
                string content = Console.ReadLine();

                File.WriteAllText(path, content);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void ReadFile()
        {
            try
            {
                Console.Write("Enter folder path: ");    // done with path.combine 
                string folder = Console.ReadLine();

                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();

                string path = Path.Combine(folder, fileName);


                using (StreamReader reader = new StreamReader(path))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine("File contents:");
                    Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void AppendFile()
        {
            try
            {
                Console.Write("Enter folder path: ");    // done with path.combine 
                string folder = Console.ReadLine();

                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();

                string path = Path.Combine(folder, fileName);


                Console.WriteLine("Enter the text to append");
                string text = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine("Text appended successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void CountFile()
        {
            try
            {
                Console.Write("Enter folder path: ");    // done with path.combine 
                string folder = Console.ReadLine();

                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();

                string path = Path.Combine(folder, fileName);


                string[] lines = File.ReadAllLines(path);
                int linecount = lines.Length;
                int wordcount = 0;

                foreach (string line in lines)
                {
                    wordcount += line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; // doubt here splitting and counting in single step is that possible 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void Copyfile()
        {
            try
            {
                Console.WriteLine("Enter the source folder:");
                string sourceFolder = Console.ReadLine();

                Console.WriteLine("Enter the source file name:");
                string sourceFile = Console.ReadLine();

                // Safely join folder + file name
                string sourcePath = Path.Combine(sourceFolder, sourceFile);

                Console.WriteLine("Enter the destination folder:");
                string destFolder = Console.ReadLine();

                Console.WriteLine("Enter the destination file name:");
                string destFile = Console.ReadLine();

                string destPath = Path.Combine(destFolder, destFile);

                File.Copy(sourcePath, destPath, true);
                Console.WriteLine("Successfully copied");
            
            }
        
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
        public static void DeleteFile()
        {
            try
            {
                Console.Write("Enter folder path: ");    // done with path.combine 
                string folder = Console.ReadLine();

                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();

                string path = Path.Combine(folder, fileName);


                File.Delete(path);
                Console.WriteLine("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static void ListDirectory()
        {
            try
            {
                Console.Write("Enter directory path: ");
                string dir = Console.ReadLine();

                string[] files = Directory.GetFiles(dir);
                string[] dirs = Directory.GetDirectories(dir);

                foreach (string f in files)
                    Console.WriteLine(f);
                foreach (string d in dirs)
                    Console.WriteLine(d);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}