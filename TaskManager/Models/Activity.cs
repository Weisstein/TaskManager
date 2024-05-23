using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }
        public List<Tasks>? Tasks { get; set; }
    }
}
