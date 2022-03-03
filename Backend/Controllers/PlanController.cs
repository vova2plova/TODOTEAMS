using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Data.Models;
using Backend;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("app/Plan")]
    public class PlanController : ControllerBase
    {
        private DataContext db;

        public PlanController(DataContext context)
        {
            db = context;
        }

        [HttpGet("GetAllPlans/{id}")]
        public Task<List<Plan>> GetAllPersonalPlans(int id)
        {
            var plan = db.Plan.Where(p => p.IdUser == id).ToListAsync();
            return plan;
        }

        [HttpPost("AddNewPlan")]
        public void AddPlan(Plan plan)
        {
            var user = db.User.FirstOrDefault(u => u.Id == plan.IdUser);
            if (user.PersonalPlans == null)
                user.PersonalPlans = new List<Plan>();
            user.PersonalPlans.Add(plan);
            db.SaveChanges();
        }
    }
}