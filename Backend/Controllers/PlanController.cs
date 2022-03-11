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

        [HttpGet("GetPlanById/{id}")]
        public ActionResult<Plan> GetPlanById(int id)
        {
            var plan = db.Plan.FirstOrDefault(p => p.Id == id);
            plan.PlanTasks = db.Task.Where(t => t.PlanId == id).ToList();
            if (plan != null)
                return Ok(plan);
            return NotFound();
        }

        [HttpGet("GetAllPersonalPlans/{id}")]
        public Task<List<Plan>> GetAllPersonalPlans(int id)
        {
            var plan = db.Plan.Where(p => p.UserId == id).ToListAsync();
            return plan;
        }

        [HttpPost("AddNewPlan")]
        public void AddPlan(Plan plan)
        {
            var user = db.User.FirstOrDefault(u => u.Id == plan.UserId);
            if (user.PersonalPlans == null)
                user.PersonalPlans = new List<Plan>();
            user.PersonalPlans.Add(plan);
            db.SaveChanges();
        }

        [HttpPut("EditPlan")]
        public async Task<ActionResult> EditPlan(Plan plan)
        {
            var _plan = db.Plan.FirstOrDefault(p => p.Id == plan.Id);
            if (_plan != null)
            {
                _plan.Title = plan.Title;
                _plan.Teammates = plan.Teammates;
                _plan.IsPrivate = plan.IsPrivate;
                _plan.PlanTasks = plan.PlanTasks;
                _plan.IsComplited = plan.IsComplited;
                await db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("DeletePlan/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var plan = db.Plan.FirstOrDefault(p => p.Id == id);
            if (plan != null)
            {
                db.Plan.Remove(plan);
                await db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}