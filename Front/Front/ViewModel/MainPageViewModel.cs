using FrontEnd.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class MainPageViewModel
    {
        public async void RedirectToMyPlans()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MyPlansPage());
        }

        public async void RedirectToTeammates()
        {
            /*await Application.Current.MainPage.Navigation.PushAsync(new MyPlansPage());*/
        }

        public async void RedirectToLogin()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LogInPage());
        }
    }
}
