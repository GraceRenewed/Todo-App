using System.ComponentModel.DataAnnotations;

namespace Todo_App.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        
        [Required]
        public required string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
