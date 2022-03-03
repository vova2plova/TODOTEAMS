using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontEnd.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrontEnd.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private RegisterViewModel _viewModel = new RegisterViewModel();
        public RegisterPage()
        {
            BindingContext = _viewModel;
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await _viewModel.Register(Login.Text, Password.Text, Name.Text) == false)
            {
                Login.Text = "";
                Password.Text = "";
            }
        }
    }
}