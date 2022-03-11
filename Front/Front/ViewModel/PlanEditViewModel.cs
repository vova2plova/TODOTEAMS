using Data.Models;
using Front.Services;
using FrontEnd.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class PlanEditViewModel
    {
        public Queue<TaskModel> Tasks { get; set; } = new Queue<TaskModel> ();

        public ImageSource ConvertToImage(bool value)
        {
            return value ?
                  ImageSource.FromFile("CheckBoxTrue")
                : ImageSource.FromFile("CheckBoxFalse");
        }
        public Task<Plan> LoadPlan()
        {
            var plan = new PlanService().GetPlan();
            return plan;
        }
        public void AddTask(string taskName)
        {
            var task = new TaskModel { IsComplited = false, Name = taskName };
            Tasks.Enqueue(task);
        }
        public void ShowTasks()
        {
            string TasksList = "";
            foreach (TaskModel task in Tasks)
                TasksList += $"▶ {task.Name}\n";
            Application.Current.MainPage.DisplayAlert("Задачи:", TasksList, "Ok");
        }
        public async void DeletePlan(Plan plan)
        {
            if (await new PlanService().DeletePlan(plan.Id))
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
                await Application.Current.MainPage.Navigation.PushAsync(new MyPlansPage());
            }
            else
            {
                new UserDialog().Toast("Произошла ошибка");
                Application.Current.MainPage = new NavigationPage(new MainPage());
                await Application.Current.MainPage.Navigation.PushAsync(new MyPlansPage());
            }
        }
        public async void SavePlan(Plan plan)
        {
            plan.PlanTasks = new List<TaskModel>(Tasks);
            if (await new PlanService().EditPlan(plan))
                await Application.Current.MainPage.Navigation.PopAsync();
            else
            {
                new UserDialog().Toast("Произошла ошибка");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
