using Webdev.TeamFoxesGreen.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Webdev.TeamFoxesGreen.App.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller {

        private List<Task> _tasks =new List<Task>{
                new Task { Id = 1, Title = "Walk the dog", Description="Stay out of the creek", Priority=TaskPriority.Low, Completed = false},
                new Task { Id = 2, Title = "Accept commendations", Description="For service above and beyond", Priority=TaskPriority.Low, Completed = false},
                new Task { Id = 3, Title = "Perform song/dance routine", Description="Uhn tiss", Priority=TaskPriority.Low, Completed = false}
            }; 

        [HttpGet]
        public IEnumerable<Task> Get(){
            return _tasks;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            //just a check to make sure our id is valid
            if (id <= 0) return BadRequest();

            //find the task in our static collection
            var task = _tasks.FirstOrDefault(t=>t.Id==id);

            //early return if we can't find a task
            if (task==null) return NotFound();

            //return the matching task
            return new ObjectResult(task);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            if (id <= 0) return BadRequest();

            var task = _tasks.FirstOrDefault(t=>.Id==id);

            if (task == null) return NotFound();

            _tasks.Remove(task);

            return _tasks;
        }

        [HttpPost("{newTask}")]
        public IActionResult Post(string[] newTask){
            var id = (_tasks[_tasks.Count - 1]).id + 1;

            var taskToAdd = new Task { id = id, Title = newTask.title, Description = newTask.description, Priority = newTask.priority, Completed = false};

            _tasks.Add(taskToAdd);

            return _tasks;

        }
        
    }
}