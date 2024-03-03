namespace ImgurService.Services.Interfaces;

public interface IAlbumService
{
    public Task<string> CreateAlbumAsync(string albumTitle, string albumDescription);
    public Task DeleteAlbumAsync();
}