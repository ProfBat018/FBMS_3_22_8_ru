using ImgurService.Models;
using ImgurService.Services.Classes;
using ImgurService.Services.Interfaces;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImgurPresentation
{
    public partial class MainWindow : Window
    {

        private readonly IImageService _imageService;
        private readonly IAlbumService _albumService;

        public MainWindow()
        {
            InitializeComponent();

            _imageService = new ImageService();
            _albumService = new AlbumService();
        }

        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            openFileDialog.Title = "Select image";

            openFileDialog.CheckFileExists = true;

            openFileDialog.ShowDialog();

            var fileName = openFileDialog.FileName;

            string json = await _imageService.UploadPhotoAsync(fileName, "New Photo", "Elnur ❤️");

            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

            var response = await JsonSerializer.DeserializeAsync<ImageUploadResponse>(ms);

            MessageBox.Show(response.data.link);

            Clipboard.SetText(response.data.link);

        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateAlbum_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAlbum_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}