using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
