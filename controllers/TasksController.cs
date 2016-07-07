using Webdev.TeamFoxesGreen.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Webdev.TeamFoxesGreen.App.Data;
using System.Net;
using System.Net.Http;

namespace Webdev.TeamFoxesGreen.App.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller {

        private readonly GreenFoxesDbContext _db;
        public TasksController(GreenFoxesDbContext db){
            _db = db;
        }
        
        // private List<Task> _tasks =new List<Task>{
        //         new Task { Id = 1, Title = "Walk the dog", Description="Stay out of the creek", Priority=TaskPriority.Low, Completed = false},
        //         new Task { Id = 2, Title = "Accept commendations", Description="For service above and beyond", Priority=TaskPriority.Low, Completed = false},
        //         new Task { Id = 3, Title = "Perform song/dance routine", Description="Uhn tiss", Priority=TaskPriority.Low, Completed = false}
        //     }; 

        [HttpGet]
        public IEnumerable<Task> Get(){
            return _db.Tasks.AsEnumerable();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            //just a check to make sure our id is valid
            if (id <= 0) return BadRequest();

            //find the task in our static collection
            var task = _db.Tasks.FirstOrDefault(t=>t.Id==id);

            //early return if we can't find a task
            if (task==null) return NotFound();

            //return the matching task
            return new ObjectResult(task);
        }

        [HttpPost]
        public IActionResult Create([FromBody]NewTaskViewModel data){

            //return an error if our model is invalid
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //add task to the database
            _db.Tasks.Add(new Task {
                Title = data.Title,
                Description = data.Description,
                Priority = data.Priority
            });

            _db.SaveChanges();

            return Ok();
        }
        
        //Edit action for task listing
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Task task)
        {
            if(id <= 0) return BadRequest();
            
            var taskToUpdate = _db.Tasks.FirstOrDefault(t=> t.Id == id);

            if (taskToUpdate == null) return NotFound();

            taskToUpdate.Description = task.Description;
            taskToUpdate.Priority = task.Priority;
            taskToUpdate.Completed = task.Completed;

            //commit changes to database
            _db.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            if (id <= 0) return BadRequest();

            var task = _db.Tasks.FirstOrDefault(t=>t.Id==id);

            if (task == null) return NotFound();

            _db.Tasks.Remove(task);

            return Ok();
        }

    }
}