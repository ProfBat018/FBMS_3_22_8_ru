using HttpClient client = new();


for (int i = 379; i < 624; i++)
{
    try
    {
        string imageUrl = $"https://zoomgroup.com/training/india/free-ebooks/cybersecurity-professional-lab-manual-view/content/medium/page{i}.jpg";
        byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
        string fileName = $"page{i + 1}.jpg"; // Change the file name as needed

        await System.IO.File.WriteAllBytesAsync(fileName, imageBytes);
        Console.WriteLine($"Image downloaded successfully. Saved as: {fileName}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}



