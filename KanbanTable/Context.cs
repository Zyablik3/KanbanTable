using Microsoft.EntityFrameworkCore;
using KanbanTable.Entities;
namespace KanbanTable
{
    public class Context : DbContext
    {
        public Context()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
#if (!DEBUG)
            Database.Migrate();
#endif
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=KanbanDB;username=postgres;password=1475");
          
        }



        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<TaskKanban> TaskKanbans { get; set; } = null!;
        public DbSet<ProjectKanban> ProjectKanbans { get; set; } = null!;
        public DbSet<StatusTask> TaskStatuses { get; set; } = null;
    }
}
