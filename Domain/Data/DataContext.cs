using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.SqlServer;
using PersonTasks.Domain.Models;

namespace PersonTasks.Domain.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Person> person {get; set;}

        public DbSet<Todo> Todos {get;set;}

        // public DbSet<PersonTodos> FkPersonTodos { get; set;}

         protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            
            // builder.Entity<PersonTodos>().ToTable("person_todos");
            // builder.Entity<PersonTodos>().HasKey(key => new {key.PersonId,key.TodoId});
            // builder.Entity<PersonTodos>().HasOne<Person>(p => p.person).WithMany(t => t.personTodos);
            // builder.Entity<PersonTodos>().HasOne<Todo>(t => t.todo).WithMany(o => o.todosPerson); //.WithMany(e => e.)

            builder.Entity<Todo>().ToTable("Todos");
            builder.Entity<Todo>().HasKey(todo => todo.id);
            builder.Entity<Todo>().Property(todo => todo.title).IsRequired().HasMaxLength(255);
            builder.Entity<Todo>().Property(todo => todo.description).IsRequired();
            builder.Entity<Todo>().Property(todo => todo.status).HasDefaultValue(-1);
            builder.Entity<Todo>().Property(todo => todo.isSolved).HasDefaultValue(false);
            builder.Entity<Todo>()
                .HasMany(t => t.person)
                .WithMany(p => p.todos)
                .UsingEntity(ue => ue.ToTable("person_todos"));
            // builder.Entity<Todo>().HasMany(t => t.todosPerson).WithOne(p => p.todo).HasForeignKey(key => key.TodoId);
            
            // builder.Entity<Todo>().HasOne(rel => rel.personFK).WithMany(p => p.todos).HasPrincipalKey(rKey => rKey.id);

            builder.Entity<Person>().ToTable("person");
            builder.Entity<Person>()
                .HasMany( p => p.todos)
                .WithMany( t => t.person)
                .UsingEntity( ue => ue.ToTable("person_todos"));

            // builder.Entity<Person>().HasMany(p => p.personTodos).WithOne(t => t.person).HasForeignKey(rel => rel.PersonId);
            
        }
    }
}