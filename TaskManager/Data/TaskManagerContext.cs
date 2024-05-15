using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext()
        {
            if(Database != null)
                Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = $"Filename={DbPath.GetPath("TaskManager.db")}";
            optionsBuilder.UseSqlite(connection);
        }
    }
}
