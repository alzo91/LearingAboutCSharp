using System.Collections.Generic;
// using System.Text.Json;
// using System.Text.Json.Serialization;

namespace PersonTasks.Domain.Models
{
    public class Person
    {
        // public Person(string name, string lastName, string email){
        //     this.name = name;
        //     this.lastName = lastName;
        //     this.email = email;
        // }

        public int id {get; set;} 

        public string name {get; set;} = string.Empty;
        public string lastName {get; set;} = string.Empty;
        public string email {get; set;}= string.Empty;

        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Boolean? isBlocked {get; set;} = false;

        // [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? createdAt { get; set;} = DateTime.Now; 
        
        public ICollection<Todo> todos {get; set;}
        // public ICollection<PersonTodos> personTodos {get; set;}
        
    }
}