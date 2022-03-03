using Data.Models;
using Front.Pages;
using Front.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class MyPlansViewModel
    {
        public ObservableCollection<Plan> Plans { get; set; } = new ObservableCollection<Plan>();
 
        public async void GetPersonalPlans()
        {
            Plans = await new PlanService().GetPlans();
        }
        public Command<int> SelectPlanCommand => new Command<int>(id =>
        {
            Preferences.Set("current_plan", id);
            Application.Current.MainPage.Navigation.PushAsync(new TaskPage());
        });

        public void RedirectToAddPlansPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddPlanPage());
        }

    }
}
