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
            return db.Task.Where(t => t.IdPlan == id).ToListAsync();
        }
    }
}