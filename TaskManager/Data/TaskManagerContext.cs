using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskManagerContext : DbContext
    {

        public DbSet<Notes> Notes {  get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Activity> Activitys { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        public TaskManagerContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = $"Filename={DbPath.GetPath("TaskManager.db")}";
            optionsBuilder.UseSqlite(connection);
        }
    }
}
