using Data.Models;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Front.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlanPage : ContentPage
    {
        AddPlanViewModel _vm = new AddPlanViewModel();
        List<User> teammates;
        List<TaskModel> tasks;
        public AddPlanPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }

        private void AddTask_Clicked(object sender, EventArgs e)
        {
            var task = new TaskModel
            {
                IsComplited = false,
                Name = TaskName.Text
            };
            TaskName.Text = "";
            _vm.AddNewTask(task);
        }

        private void AddPlan_Clicked(object sender, EventArgs e)
        {
            var plan = new Plan
            {
                UserId = Preferences.Get("current_user_id", 0),
                IsComplited = false,
                IsPrivate = !IsPrivate.IsChecked,
                PlanTasks = tasks,
                Teammates = teammates,
                Title = PlanName.Text
            };
            _vm.AddNewPlan(plan);
        }

        private void TasksShow_Clicked(object sender, EventArgs e)
        {
            _vm.ShowTask();
        }
    }
}