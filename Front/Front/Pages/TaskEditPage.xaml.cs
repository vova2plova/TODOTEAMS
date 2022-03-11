using Data.Models;
using Front.Converter;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Front.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskEditPage : ContentPage
    {
        TaskEditViewModel _vm = new TaskEditViewModel();
        TaskModel _task = new TaskModel();
        public TaskEditPage(TaskModel task)
        {
            InitializeComponent();
            BindingContext = _vm;
            TaskName.Text = task.Name;
            TaskIsComplited.Source = _vm.ConvertToImage(task.IsComplited);
            _task = task;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            _task.IsComplited = !_task.IsComplited;
            TaskIsComplited.Source = _vm.ConvertToImage(_task.IsComplited);
        }

        private void DeleteTask_Clicked(object sender, EventArgs e)
        {
            _vm.DeleteTask(_task);
        }

        private void SaveTask_Clicked(object sender, EventArgs e)
        {
            if (TaskName.Text != "")
                _task.Name = TaskName.Text;
            else
                new UserDialog().Toast("Поле для ввода названия плана не может быть пустым");
            _vm.UpdateTask(_task);
        }
    }
}