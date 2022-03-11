using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Front.Pages;
using FrontEnd.Pages;
using Xamarin.Essentials;

namespace Front
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Preferences.Get("current_user_id", 0) != 0)
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new LogInPage());
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
