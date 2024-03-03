using ImgurService.Services.Interfaces;

namespace ImgurService.Services.Classes;

public class ImageService : IImageService
{
    private readonly HttpClient _client;
    private readonly HttpRequestMessage _request;
    private readonly MultipartFormDataContent _content;

    public ImageService()
    {
        _client = new();
        _request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/image");
        _request.Headers.Add("Authorization", "Client-ID {{clientId}}");
        _content = new();
    }

    public async Task<string> UploadPhotoAsync(string path, string title, string description)
    {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(File.OpenRead(path)), "image", path);
        content.Add(new StringContent("image"), "type");
        content.Add(new StringContent(title), "title");
        content.Add(new StringContent(description), "description");
        _request.Content = content;
        var response = await _client.SendAsync(_request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public Task<byte[]> DownloadPhotoAsync()
    {
        throw new NotImplementedException();
    }
}