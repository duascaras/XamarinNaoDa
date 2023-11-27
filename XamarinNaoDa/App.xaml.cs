using System;
using System.IO;
using Xamarin.Forms;
using XamarinNaoDa.Data;

namespace XamarinNaoDa
{
    public partial class App : Application
    {
        private static PostDatabase database;

        public static PostDatabase Database
        {
            get
            {
                // Early return >>
                if (database != null)
                {
                    return database;
                }

                return database = new PostDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "postagem.db3"));
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}