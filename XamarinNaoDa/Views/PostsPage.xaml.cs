using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private async void ToolbarItem_Clicked_1(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}