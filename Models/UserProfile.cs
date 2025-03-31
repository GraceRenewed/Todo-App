using System.ComponentModel.DataAnnotations;

namespace Todo_App.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
