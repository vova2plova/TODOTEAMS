using Data.Models;
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
    public partial class MyPlansPage : ContentPage
    {
        MyPlansViewModel _vm = new MyPlansViewModel();
        public MyPlansPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }
            
        protected override void OnAppearing()
        {
            _vm.GetPersonalPlans();
            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            _vm.RedirectToAddPlansPage();
        }
    }
}