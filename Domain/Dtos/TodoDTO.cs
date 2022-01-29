namespace PersonTasks.Domain.Dtos
{
    public class TodoDto
    {
        public string title { get; set;} = string.Empty;        
        public string description { get; set;} = string.Empty;

        public override string ToString(){
            return this.title + ", " + this.description;
        }
    }
}