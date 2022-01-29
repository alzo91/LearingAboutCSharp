using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonTasks.Domain.Models;
using PersonTasks.Domain.Dtos;

namespace PersonTasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase 
    {
        private readonly ILogger<TodoController> _logger;
        private readonly DataContext _context;

        public TodoController(DataContext context, ILogger<TodoController> logger){
            _logger = logger;
            _context = context;
        }

        [HttpPost("/create/{userId}")]
        public async Task<ActionResult> CreateTodo(int userId, [FromBody] TodoDto parTodo)
        {
            _logger.LogInformation("todo/create userid = '" + userId + "'");
            var currentPerson = await _context.person.FindAsync(userId);
            if(currentPerson ==null) return NotFound("User was not found!");

            
            
            _logger.LogInformation("param todo => " + parTodo.ToString());

           //
            var todo = new Todo{
                title= parTodo.title,
                description= parTodo.description,
                createdAt = DateTime.Now,
                isSolved = false,
                status = -1,
                userId = currentPerson.id,
                person = new List<Person>(){ currentPerson}
            };

            // todo.todosPerson = new List<PersonTodos>(){ 
            //     new PersonTodos(){
            //         PersonId=userId, 
            //         TodoId = todo.id,
            //         todo = todo,
            //         person = currentPerson
            //     }
            // };
            
            _context.Todos.Add(todo);

            _logger.LogInformation(todo.ToString());
            
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("/findById/{id}")]
        public async Task<ActionResult> GetMyTodos(int id)
        {
            var me = await _context.person.FindAsync(id);
            if (me==null) return NotFound("User didn't find");
            // string sql = "" +
            //     "SELECT p.*, Todos.id as TodoId, Todos.title,Todos.description, Todos.isSolved, Todos.status " +
            //     "FROM person as p " +
            //     "inner join person_todos " +
            //     "on p.id = person_todos.PersonId " +
            //     "inner join Todos " + 
            //     "on p.id = Todos.userId " +
            //     "where p.id = "  +id;
                
            // var res = await _context.person.FromSqlRaw(sql).ToListAsync(); //.Database.ExecuteSqlRawAsync(sql);
                //.SelectMany(p => p.personTodos);
                // .SelectMany<List<Todo>>(pt => pt.todo);

            // var result = await _context.FkPersonTodos.FirstOrDefaultAsync(fk => fk.PersonId == id);
            var result = await _context.person.Where(p => p.id == id).SelectMany(p => p.todos).ToListAsync();
            //  string res = "";
            return Ok(result);
        }
    }    
}