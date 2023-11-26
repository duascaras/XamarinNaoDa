using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNaoDa.Views;

namespace XamarinNaoDa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}