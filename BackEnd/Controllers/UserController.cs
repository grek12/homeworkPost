using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private DatabaseContext db;
        public UserController(DatabaseContext context)
        {
            db = context;
        }
        [HttpGet("GetAllUser")]
        public List<User> GetAllProducts()
        {
            return db.Users.ToList();
        }


        [HttpPost("AddUser")]
        public ActionResult<User> SignUp(User user)
        {
            var _user = db.Users.FirstOrDefault(x => x.Name == user.Name);
            if (_user == null)
            {
                var newUser = new User { Name = user.Name, LastName = user.LastName };
                db.Users.Add(newUser);
                db.SaveChanges();
                return Ok(newUser);
            }
            return BadRequest("Пользователь с такими данными уже зарегистрирован");
        }
    }
}
