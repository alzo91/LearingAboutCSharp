using Microsoft.AspNetCore.Mvc;
using PersonTasks.Domain.Models;
using PersonTasks.Domain.Dtos;

namespace PersonTasks.Controllers
{
    // private readonly List<Person> = new List<Person>;
    
    [ApiController]
    [Route("[controller]")]

    public class PersonController : ControllerBase
    {
        private static List<Person> people = new List<Person>{
            new Person { id = 0, name=  "Ana", lastName = "Zotarelli",email = "ana@gmail.com" },
        };

        private readonly ILogger<PersonController> _logger;
        private readonly DataContext _context;

        public PersonController(DataContext context, ILogger<PersonController> logger)
        {
            _context = context;
            _logger = logger;

        }

        [HttpGet(Name = "GetAllPerson")]
        public async Task<ActionResult<List<Person>>> Get(){
            var foundPeople = await _context.person.ToListAsync();
            return Ok(foundPeople);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create([FromBody] PersonDTO person){
            if(person.name == null) return BadRequest("You should need to inform your name");
            if(person.email == null) return BadRequest("You should need to inform your email");
            if(person.lastName == null) return BadRequest("You should need to inform your lastName");
            //
            var existPerson = await _context.person.FirstOrDefaultAsync(p => p.email == person.email);
            if (existPerson != null) return BadRequest("Exist other person who is using this email."); 
            // var user = new Person(person.name, person.lastName, person.email);
            var newPerson = new Person { name= person.name, lastName = person.lastName, email=person.email};
            //people.Add(newPerson);
            await _context.person.AddAsync(newPerson);
            await _context.SaveChangesAsync();
            return Ok(newPerson);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Detail(int id){
            _logger.LogInformation("Current person ..." + id + ". Detail it!");
            var foundPerson = await _context.person.FindAsync(id); // people.Find(p => p.id == id);
            if (foundPerson==null) return BadRequest("It's not possible to find this person");
            return Ok(foundPerson);
        }
        
        [HttpPatch("{id}")]
        public async Task<ActionResult<Person>> Update(int id,[FromBody] UpdatePersonDTO person){
            _logger.LogInformation("Current Id by URL..." + id + " Update ");
            var foundPerson = await _context.person.FindAsync(id);  //people.Find(p => p.id == id);
            if (foundPerson==null) return BadRequest("It's not possible to find this person");

            foundPerson.name = person.name;
            foundPerson.lastName = person.lastName;
            foundPerson.isBlocked = person.isBlocked;
            
            _context.person.Update(foundPerson);
            await _context.SaveChangesAsync();
            return Ok(foundPerson);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Current Id by URL..." + id + " DELETE ");
            var foundPerson = await _context.person.FindAsync(id);  // var foundPerson = people.Find(p => p.id == id);
            if (foundPerson==null) return BadRequest("It's not possible to find this person");

            // people.Remove(foundPerson);
            _context.person.Remove(foundPerson);
            await _context.SaveChangesAsync();
            
            return Ok("Item was removed!");
        }
    } 
}