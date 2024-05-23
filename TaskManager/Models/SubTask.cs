using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class SubTask
    {
        [Key]
        public int Id {  get; set; }
        public string? Title { get; set; }
        public bool IsComplited { get; set; }
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public Tasks? Task { get; set; }
    }
}
