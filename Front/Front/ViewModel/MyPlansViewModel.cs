using Data.Models;
using Front.Pages;
using Front.Services;
using FrontEnd.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class MyPlansViewModel
    {
        public ObservableCollection<Plan> Plans { get; set; } = new ObservableCollection<Plan>();
        public async void GetPersonalPlans(StackLayout plan_list)
        {
            Plans = new ObservableCollection<Plan>((await new PlanService().GetPlans()).OrderBy(p => p.IsComplited));
            BindableLayout.SetItemsSource(plan_list, Plans);
        }
        public Command<Plan> SelectPlanCommand => new Command<Plan>(plan =>
        {
            Preferences.Set("current_plan", plan.Id);
            Application.Current.MainPage.DisplayAlert("Selected Plan", "название плана : " + plan.Title, "Ok");
            Application.Current.MainPage.Navigation.PushAsync(new PlanPage());
        });

        public void RedirectToAddPlansPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddPlanPage());
        }

    }
}
