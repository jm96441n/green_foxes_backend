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
            //var task = _tasks.FirstOrDefault(t=>t.Id==id);
            
            //using db
            Task task = db.Tasks.Find(id)

            //early return if we can't find a task
            if (task==null) return NotFound();

            //return the matching task
            return new ObjectResult(task);
        }

        [HttpPost]
        public void Create([FromBody]Task data){
            var id = (_tasks[_tasks.Count - 1]).Id + 1;

            Task taskToAdd = new Task { Id = id, Title = data.Title, Description = data.Description, Priority = data.Priority, Completed = false};

            db.Tasks.Add(taskToAdd);
            db.SaveChanges();

        }
        
        //Edit action for task listing
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Task task)
        {
            if(id <= 0) return BadRequest();
            
            Task taskToUpdate = db.Tasks.Find(id);

            if(TryUpdateModel(taskToUpdate, '', new string[] {"Title","Description","Priority","Completed"}))
            {
                db.SaveChanges();
            }

            // taskToUpdate.Description = task.Description;
            // taskToUpdate.Priority = task.Priority;
            // taskToUpdate.Completed = task.Completed;

            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            if (id <= 0) return BadRequest();

            Task task = db.Tasks.Find(id);

            if (task == null) return NotFound();

            db.Tasks.Remove(task);
            db.SaveChanges();

            return new NoContentResult();
        }

    }
}