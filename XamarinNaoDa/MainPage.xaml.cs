using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

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
        async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            var stream = await result.OpenReadAsync();
            resultImage.Source = ImageSource.FromStream(() => stream);
        }   

        // Take Picture
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);

                capturedPhotoPath = result.FullPath;
            }
            //resultImage.Source = ImageSource.FromStream(() => stream);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPostAsync();
        }

        // Add to Database
        async void Button_Clicked_2(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comentarioEntry.Text))
            {
                await App.Database.SavePostAsync(new Postagem
                {
                    DataPostagem = DateTime.UtcNow.Date,
                    Comentario = comentarioEntry.Text,
                    Foto = capturedPhotoPath
                });

                comentarioEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPostAsync();
            }
        }
    }
}