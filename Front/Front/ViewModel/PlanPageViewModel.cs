using Data.Models;
using Front.Pages;
using Front.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class PlanPageViewModel
    {
        public ObservableCollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();

        public async void LoadTasks(StackLayout task_list)
        {
            Tasks = new ObservableCollection<TaskModel>(await new TaskService().GetTasks());
            BindableLayout.SetItemsSource(task_list, Tasks);
        }

        public Command<TaskModel> SelectTaskCommand => new Command<TaskModel>(task =>
        {
            Application.Current.MainPage.Navigation.PushAsync(new TaskEditPage(task));
        });
        public async void ToEditPlan()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PlanEditPage());
        }
    }
}
