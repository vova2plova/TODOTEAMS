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
    public partial class PlanEditPage : ContentPage
    {
        Plan _plan;
        PlanEditViewModel _vm = new PlanEditViewModel();
        public PlanEditPage()
        {
            InitializeComponent();
            LoadPlanToFrom();
            BindingContext = _vm;
        }

        public async void LoadPlanToFrom()
        {
            _plan = await _vm.LoadPlan();
            if (_plan.PlanTasks != null)
                _vm.Tasks = new Queue<TaskModel>(_plan.PlanTasks);
            PlanTitle.Text = _plan.Title;
            IsPrivate.Source = _vm.ConvertToImage(_plan.IsPrivate);
            IsComplited.Source = _vm.ConvertToImage(_plan.IsComplited);
        }
        private void ShowTeammates_Clicked(object sender, EventArgs e)
        {
            
        }
        private void EditIsPrivate_Tapped(object sender, EventArgs e)
        {
            _plan.IsPrivate = !_plan.IsPrivate;
            IsPrivate.Source = _vm.ConvertToImage(_plan.IsPrivate);
        }
        private void EditIsComplited_Tapped(object sender, EventArgs e)
        {
            _plan.IsComplited = !_plan.IsComplited;
            IsComplited.Source = _vm.ConvertToImage(_plan.IsComplited);
        }

        private void ShowTasks_Tapped(object sender, EventArgs e)
        {
            _vm.ShowTasks();
        }

        private void AddTask_Tapped(object sender, EventArgs e)
        {
            if (TaskName.Text != "")
                _vm.AddTask(TaskName.Text);
            else
                new UserDialog().Toast("Поле названия задачи не может быть пустым");
        }

        private void DeletePlan_Clicked(object sender, EventArgs e)
        {
            _vm.DeletePlan(_plan);
        }

        private void SavePlan_Clicked(object sender, EventArgs e)
        {
            if (PlanTitle.Text != "")
            {
                _plan.Title = PlanTitle.Text;
                _vm.SavePlan(_plan);
            }
            else
                new UserDialog().Toast("Поле названия плана не может быть пустым");
        }
    }
}