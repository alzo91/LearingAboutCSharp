using System.Collections.Generic;

namespace PersonTasks.Domain.Models
{
    public class Todo 
    {
        public int id {get; set;}
        public string title { get; set;} = string.Empty;

        public string description { get; set;} =  string.Empty;

        public int status { get; set;} = -1;

        public Boolean isSolved { get; set;} = false;

        public int userId {get; set;}
        public DateTime createdAt { get; set; } = DateTime.Now;

        public ICollection<Person> person {get;set;}
        // public ICollection<PersonTodos> todosPerson {get;set;}
    }
}