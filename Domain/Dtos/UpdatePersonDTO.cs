namespace PersonTasks.Domain.Dtos
{
    public class UpdatePersonDTO
    {
        public string name {get; set;} = string.Empty;
        public string lastName {get; set;} = string.Empty;
        public Boolean? isBlocked {get; set;} = false;
    }
}