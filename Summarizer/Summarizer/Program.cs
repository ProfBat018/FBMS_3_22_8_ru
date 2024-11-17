using Azure;
using Azure.AI.TextAnalytics;
using Summarizer;

Console.WriteLine(
    """
        Welcome to Document summarizer...
        1. Select file from path
        2. Exit
    """);

Uri endpoint = new("https://morningaihub6465450877.cognitiveservices.azure.com/");
AzureKeyCredential credential = new("FCUpRydvrL87BDZyAEk3JeR9aCNd2a0HzbJpqoxEidXy2xafcvzbJQQJ99AKAC5RqLJXJ3w3AAAAACOGhPS3");
TextAnalyticsClient client = new(endpoint, credential);

int mainChoice = 0;

bool res = Int32.TryParse(Console.ReadLine(), out mainChoice);

if (res)
{
    switch (mainChoice)
    {
        case 1:
            Console.WriteLine("Enter file path:");
            
            string filePath = Console.ReadLine();
            var document =  new List<string>(await DocumentService.ExtractStringFromFile(filePath));
            
            AbstractiveSummarizeOperation operation = await client.AbstractiveSummarizeAsync(WaitUntil.Completed, document);

            await foreach (AbstractiveSummarizeResultCollection documentsInPage in operation.Value)
            {
                Console.WriteLine($"Abstractive Summarize, model version: \"{documentsInPage.ModelVersion}\"");
                Console.WriteLine();

                foreach (AbstractiveSummarizeResult documentResult in documentsInPage)
                {
                    if (documentResult.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                        Console.WriteLine($"  Message: {documentResult.Error.Message}");
                        continue;
                    }

                    Console.WriteLine($"  Produced the following abstractive summaries:");
                    Console.WriteLine();

                    foreach (AbstractiveSummary summary in documentResult.Summaries)
                    {
                        Console.WriteLine($"  Text: {summary.Text.Replace("\n", " ")}");
                        Console.WriteLine($"  Contexts:");

                        foreach (AbstractiveSummaryContext context in summary.Contexts)
                        {
                            Console.WriteLine($"    Offset: {context.Offset}");
                            Console.WriteLine($"    Length: {context.Length}");
                        }

                        Console.WriteLine();
                    }
                }
            }
            break;
        case 2:
            break;
        default:
            break;
    }
}
