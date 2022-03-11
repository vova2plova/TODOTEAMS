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
    [Route("app/Task")]
    public class TaskController : ControllerBase
    {
        private DataContext db;

        public TaskController(DataContext context)
        {
            db = context;
        }

        [HttpGet("GetTasks/{id}")]
        public Task<List<TaskModel>> GetTasks(int id)
        {
            return db.Task.Where(t => t.PlanId == id).ToListAsync();
        }

        [HttpPut("EditTask")]
        public async Task<ActionResult> EditTask(TaskModel task)
        {
            var _task = db.Task.FirstOrDefault(t => t.Id == task.Id);
            if (_task != null)
            {
                _task.Name = task.Name;
                _task.IsComplited = task.IsComplited;
                await db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = db.Task.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                db.Task.Remove(task);
                await db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}