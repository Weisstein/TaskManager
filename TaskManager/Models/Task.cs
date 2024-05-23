using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public int ActivityId { get; set; }
        public bool IsCompleted { get; set; }
        [ForeignKey(nameof(ActivityId))]
        public Activity? Activitys { get; set; }
        public List<SubTask>? SubTasks { get; set; }
    }
}
