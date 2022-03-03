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
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm = new MainPageViewModel();
        public MainPage()
        {
            BindingContext = _vm;
            InitializeComponent();
        }

        private void MyPlans_Clicked(object sender, EventArgs e)
        {
            _vm.RedirectToMyPlans();
        }

        private void FoundTeamate_Clicked(object sender, EventArgs e)
        {

        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            _vm.RedirectToLogin();
        }
    }
}