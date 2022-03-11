using Data.Models;
using Front.Pages;
using Front.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Front.ViewModel
{
    internal class TaskEditViewModel
    {
        public ImageSource ConvertToImage(bool IsComplited)
        {
            return IsComplited ?
                  ImageSource.FromFile("CheckBoxTrue")
                : ImageSource.FromFile("CheckBoxFalse");
        }

        public async void DeleteTask(TaskModel task)
        {
            if (await new TaskService().DeleteTasks(task.Id))
                await Application.Current.MainPage.Navigation.PopAsync();
            else
            {
                new UserDialog().Toast("Произошла ошибка");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async void UpdateTask(TaskModel task)
        {
            if (await new TaskService().EditTasks(task))
                await Application.Current.MainPage.Navigation.PopAsync();
            else
            {
                new UserDialog().Toast("Произошла ошибка");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

    }
}
