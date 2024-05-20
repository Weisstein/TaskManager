using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "Заголовок";
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
