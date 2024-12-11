using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path to the directory or file:");
        string inputPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputPath))
        {
            Console.WriteLine("Invalid input. Please provide a valid path.");
            return;
        }

        string sanitizedDir;

        if (File.Exists(inputPath))
        {
            sanitizedDir = Path.Combine(Path.GetDirectoryName(inputPath) ?? inputPath, "Sanitized Files");
            Directory.CreateDirectory(sanitizedDir);
            ProcessFile(inputPath, sanitizedDir);
        }
        else if (Directory.Exists(inputPath))
        {
            sanitizedDir = Path.Combine(inputPath, "Sanitized Files");
            Directory.CreateDirectory(sanitizedDir);
            string[] files = Directory.GetFiles(inputPath);
            foreach (var file in files)
            {
                ProcessFile(file, sanitizedDir);
            }
        }
        else
        {
            Console.WriteLine("The provided path does not exist.");
            return;
        }

        Console.WriteLine("Processing complete.");
    }

    static void ProcessFile(string filePath, string outputDir)
    {
        try
        {
            string content = File.ReadAllText(filePath);

            if (content.Length >= 83)
            {
                char targetChar = content[82]; // 83rd character (0-based index is 82)
                string sanitizedContent = content.Replace(targetChar, '^');

                string sanitizedFilePath = Path.Combine(outputDir, Path.GetFileName(filePath));
                File.WriteAllText(sanitizedFilePath, sanitizedContent);

                Console.WriteLine($"Processed file: {filePath} -> {sanitizedFilePath}");
            }
            else
            {
                Console.WriteLine($"File skipped (less than 83 characters): {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
        }
    }
}
