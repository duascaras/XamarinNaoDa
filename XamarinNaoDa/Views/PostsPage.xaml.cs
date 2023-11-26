using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNaoDa.Models;

namespace XamarinNaoDa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsPage : ContentPage
    {
        public PostsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPostAsync();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Postagem postagem = (Postagem)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(MainPage)}?{nameof(MainPage.PostId)}={postagem.ID}");
            }
        }

        private async void AddBarClicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}