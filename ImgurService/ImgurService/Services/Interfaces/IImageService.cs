namespace ImgurService.Services.Interfaces;

public interface IImageService
{
    public Task<string> UploadPhotoAsync(string path, string title, string description);
    public Task<byte[]> DownloadPhotoAsync();
}