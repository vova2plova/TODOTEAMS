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
    public partial class PlanPage : ContentPage
    {
        PlanPageViewModel _vm = new PlanPageViewModel();
        public PlanPage()
        {
            BindingContext = _vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            _vm.LoadTasks(Task_List);
            base.OnAppearing();
        }

        private void SettingPlans_Tapped(object sender, EventArgs e)
        {
            _vm.ToEditPlan();
        }
    }
}