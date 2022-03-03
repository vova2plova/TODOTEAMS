using Data.Models;
using FrontEnd.Pages;
using FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class LogInPageViewModel
    {
        public async void LogIn(string login, string password)
        {
            var _user = await new UserService().LogIn(new User{ Login = login, Password = password});
            if (_user != null)
            {
                new UserDialog().Toast("Успешно! Перенаправляем на главную");
                Preferences.Set("current_user_id", _user.Id);
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
                new UserDialog().Toast("Неверный логин или пароль");
        }

        public async void ToRegisterPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
