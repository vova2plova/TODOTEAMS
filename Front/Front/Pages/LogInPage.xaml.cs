using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrontEnd.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        private LogInPageViewModel _vm = new LogInPageViewModel();
        public LogInPage()
        {
            BindingContext = _vm;
            InitializeComponent();
        }

        private void LogIn_Clicked(object sender, EventArgs e)
        {
            _vm.LogIn(Login.Text, Password.Text);
            Login.Text = "";
            Password.Text = "";
        }

        private void ToRegisterPage_Clicked(object sender, EventArgs e)
        {
            _vm.ToRegisterPage();
        }
    }
}