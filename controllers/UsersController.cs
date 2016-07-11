using Webdev.TeamFoxesGreen.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Webdev.TeamFoxesGreen.App.Controllers
{
        [Route("api/[controller]")]
        public class UsersController : Controller {
            
            [HttpGet("{id}")]

            public IActionResult Get(int id){
                if (id <= 0) return BadRequest();

                //var currentUser = _users.FirstOrDefault(u=> u.Id == id );

                var currentUser = db.Users.Find(id);

                if (currentUser == null) return NotFound();

                return new ObjectResult(currentUser);
            }

            [HttpPost]
            public void Create([FromBody]User data){
                User newUser = new User {Username = data.Username, FirstName = data.FirstName, LastName = data.LastName, Email = data.Email};
                db.Users.Add(newUser);

            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody]User user)
            {
                if (id <= 0) return BadRequest();

                User userToUpdate = db.Users.Find(id);

                if(TryUpdateModel(userToUpdate,'',new string[] {"Username","FirstName","LastName", "Email"}))
                {
                    db.SaveChanges();
                }

                return new NoContentResult();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id){
                if (id <= 0) return BadRequest();

                User userToDelete = db.Users.Find(id);
                
                if (userToDelete == null) return NotFound();

               db.Users.Remove(userToDelete);
               db.SaveChanges();

                return new NoContentResult();
            }

        }
}