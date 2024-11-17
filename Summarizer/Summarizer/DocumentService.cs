namespace Summarizer;

public static class DocumentService
{

    public static async Task<string[]> ExtractStringFromFile(string path)
    {
        string[] lines = await File.ReadAllLinesAsync(path);
        
        Console.WriteLine($"Lines read: {lines.Length}");

        return lines;
    }
}