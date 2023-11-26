using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinNaoDa.Models;

// OOPS! NO F1 HELP MATCH WAS FOUND
// MUITO BOM CODAR AQUI!!!!!

namespace XamarinNaoDa
{
    public partial class MainPage : ContentPage
    {
        private string capturedPhotoPath;

        public MainPage()
        {
            InitializeComponent();
        }

        // Load Picture
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            var stream = await result.OpenReadAsync();
            resultImage.Source = ImageSource.FromStream(() => stream);
        }

        // Take Picture
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);

                capturedPhotoPath = result.FullPath;
            }
        }

        // Add to Database
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comentarioEntry.Text))
            {
                await App.Database.SavePostAsync(new Postagem
                {
                    DataPostagem = DateTime.UtcNow.Date,
                    Comentario = comentarioEntry.Text,
                    Foto = capturedPhotoPath
                });
            }
            comentarioEntry.Text = string.Empty;
            resultImage.Source = new FileImageSource { File = "" };
        }

        //async void OnDeleteButtonClicked(object sender, EventArgs e)
        //{
        //    var post = await App.Database.GetPostAsync()
        //    await App.Database.DeletePostAsync(post);

        //    // Navigate backwards
        //    await Shell.Current.GoToAsync("..");
        //}
    }
}