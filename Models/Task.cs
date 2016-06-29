namespace Webdev.TeamFoxesGreen.App.Models
{
    public class Task {
        public int Id {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public TaskPriority Priority {get;set;}
        public bool Completed {get;set;}
    }

    public enum TaskPriority {
        Low = 0,
        Moderate = 1,
        High = 2
    }
}