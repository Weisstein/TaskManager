using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Project
    {
       [Key]
       public int Id {  get; set; }
       public string? Title { get; set; }
       public List<Activity>? Activities { get; set; }
    }
}
