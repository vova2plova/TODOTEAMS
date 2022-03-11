using Data.Models;
using Front.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class AddPlanViewModel
    {
        private Queue<TaskModel> tasks = new Queue<TaskModel>();
        public void AddNewTask(TaskModel task)
        {
            tasks.Enqueue(task);
        }

        public void ShowTask()
        {
            string TasksList = "";
            foreach (TaskModel task in tasks)
                TasksList += $"▶ {task.Name}\n";
            Application.Current.MainPage.DisplayAlert("Задачи:", TasksList, "Ok");
        }

        public async void AddNewPlan(Plan plan)
        {
            plan.PlanTasks = tasks.ToList();
            var response = await new PlanService().AddNewPlan(plan);
            if (response == true)
            {
                new UserDialog().Toast("План успешно создан!");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                new UserDialog().Toast("Произошла ошибка");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
