using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Data.Models;
using Backend;
using System.Linq;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("app/User")]
    public class UserController : ControllerBase
    {
        private DataContext db;

        public UserController(DataContext context)
        {
            db = context;
        }


        [HttpPost("registration")]
        public async Task<ActionResult<User>> AddNewUser(User body)
        {
            var _user = db.User.FirstOrDefault(u => u.Login == body.Login);
            if (_user == null)
            {
                var newUser = new User { Login = body.Login, Password = body.Password, Name = body.Name };
                await db.User.AddAsync(newUser);
                await db.SaveChangesAsync();
                var currentUser = db.User.FirstOrDefault(u => u.Login == newUser.Login);
                return currentUser;
            }
            return BadRequest("Данный пользователь уже зарегистрирован");
        }

        [HttpGet("login/{login}/{password}")]
        public ActionResult<User> LogIn(string login, string password)
        {
            var user = db.User.FirstOrDefault(u => u.Login == login &&
                                            u.Password == password);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        /*[HttpGet("GetAllUsersWithout/{id}")]
        public List<User> Get(int id)
        {
            var users = new List<User>(db.User);
            users.Remove(users.FirstOrDefault(x => x.Id == id));
            return users;
        }

       [HttpGet("GetUserById/{id}")]
       public ActionResult<User> GetUserById(int id)
        {
            var user = db.User.FirstOrDefault(u => u.Id == id);
            if (user != null)
                return Ok(user);
            return NotFound("Пользователь не найден");
        }*/
    }
}