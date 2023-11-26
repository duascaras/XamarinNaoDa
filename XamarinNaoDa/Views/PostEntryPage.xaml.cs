using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinNaoDa.Models;

// OOPS! NO F1 HELP MATCH WAS FOUND
// MUITO BOM CODAR AQUI!!!!!

namespace XamarinNaoDa
{
    [QueryProperty(nameof(PostId), nameof(PostId))]
    public partial class MainPage : ContentPage
    {
        private string _capturedPhotoPath;

        public string PostId
        {
            set
            {
                LoadPost(value);
            }
        }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new Postagem();
        }

        private async void LoadPost(string postId)
        {
            try
            {
                int id = Convert.ToInt32(postId);

                Postagem postagem = await App.Database.GetPostAsync(id);
                BindingContext = postagem;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        // Load Picture
        private async void PickImageClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            var stream = await result.OpenReadAsync();
            resultImage.Source = ImageSource.FromStream(() => stream);
        }

        // Take Picture
        private async void TakeImageClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);

                _capturedPhotoPath = result.FullPath;
            }
        }

        // Add to Database
        private async void AddToDatabaseClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comentarioEntry.Text))
            {
                await App.Database.SavePostAsync(new Postagem
                {
                    DataPostagem = DateTime.UtcNow.Date,
                    Comentario = comentarioEntry.Text,
                    Foto = _capturedPhotoPath
                });
            }

            comentarioEntry.Text = string.Empty;
            resultImage.Source = new FileImageSource { File = "" };
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var post = (Postagem)BindingContext;
            await App.Database.DeletePostAsync(post);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}