using Microsoft.EntityFrameworkCore;
using Todo_App.Models;

namespace Todo_App
{
    public class Todo_AppDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public Todo_AppDbContext(DbContextOptions<Todo_AppDbContext> context) : base(context)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().HasData(new ToDoItem[]
            {
                new ToDoItem { Id = 101, Task = "Make Grocery List", IsCompleted = true},
                new ToDoItem { Id = 102, Task = "Buy groceries", IsCompleted = false },
                new ToDoItem { Id = 103, Task = "Finish C# project", IsCompleted = false },
                new ToDoItem { Id = 104, Task = "Call mom", IsCompleted = true },
                new ToDoItem { Id = 105, Task = "Schedule dentist appointment", IsCompleted = false },
                new ToDoItem { Id = 106, Task = "Read 10 pages of a book", IsCompleted = true },
                new ToDoItem { Id = 107, Task = "Go for a 30-minute walk", IsCompleted = false },
                new ToDoItem { Id = 108, Task = "Reply to emails", IsCompleted = false },
                new ToDoItem { Id = 109, Task = "Plan weekend trip", IsCompleted = false },
                new ToDoItem { Id = 110, Task = "Organize workspace", IsCompleted = true },
                new ToDoItem { Id = 111, Task = "Meal prep for the week", IsCompleted = false }
            });
            modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
            {
                new UserProfile { Id = 201, Name = "Penny"}
            });
        }
    }
}
