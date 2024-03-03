using System.Diagnostics;
using ImgurService.Services.Interfaces;

namespace ImgurService.Services.Classes;

public class AlbumService : IAlbumService
{
    private readonly HttpClient _client;
    private readonly HttpRequestMessage _request;
    private readonly MultipartFormDataContent _content;
    
    public AlbumService()
    {
        _client = new();
        _request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/album");
        _request.Headers.Add("Authorization", "Bearer {{accessToken}}");
        _content = new();

    }
    
    public async Task<string> CreateAlbumAsync(string albumTitle, string albumDescription)
    {
        _content.Add(new StringContent(albumTitle), "title");
        _content.Add(new StringContent(albumDescription), "description");
        _request.Content = _content;
        
        var response =  await _client.SendAsync(_request);
       
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task DeleteAlbumAsync()
    {
        throw new NotImplementedException();
    }
}
