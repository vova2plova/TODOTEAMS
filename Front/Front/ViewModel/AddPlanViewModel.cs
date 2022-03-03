using Data.Models;
using Front.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Front.ViewModel
{
    internal class AddPlanViewModel
    {
        public Task<bool> AddNewPlan(Plan plan)
        {
            return new PlanService().AddNewPlan(plan);
        }
    }
}
