using Webdev.TeamFoxesGreen.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Webdev.TeamFoxesGreen.App.Controllers
{
        [Route("api/users/[controller]")]
        public class UsersController : Controller {
            
            [HttpGet("{id}")]

            public IActionResult Get(int id){
                if (id <= 0) return BadRequest();

                var currentUser = _users.FirstOrDefault(u=> u.Id == id );

                if (currentUser == null) return NotFound();

                return new ObjectResult(currentUser);
            }

            [HttpPost]
            public void Create([FromBody]User data){
                var newUser = new User {Username = data.Username};

            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody]User user)
            {
                if (id <= 0) return BadRequest();

                var userToUpdate = _users.FirstOrDefault(u=> u.Id == id);

                userToUpdate.Username = user.Username;

                return new NoContentResult();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id){
                if (id <= 0) return BadRequest();

                var userToDelete = _users.FirstOrDefault(u => u.Id == id);
                
                if (userToDelete == null) return NotFound();

                _users.Remove(userToDelete);

                return new NoContentResult();
            }

        }
}