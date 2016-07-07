using System.ComponentModel.DataAnnotations;

namespace Webdev.TeamFoxesGreen.App.Models
{
    public class NewTaskViewModel {
        [Required]
        [MinLengthAttribute(3)]
        public string Title {get;set;}
        public string Description {get;set;}

        [Required]
        public TaskPriority Priority {get;set;}
    }

}