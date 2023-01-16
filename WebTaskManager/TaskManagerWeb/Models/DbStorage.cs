using Microsoft.EntityFrameworkCore;

namespace TaskManagerWeb.Models
{
    public class DbStorage : DbContext
    {
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<TaskStatus> Statuses { get; set; } = null!;

        public DbStorage(DbContextOptions<DbStorage> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskStatus>().HasData(
                    new TaskStatus { Id = 1, DivplayValue = "В плане" },
                    new TaskStatus { Id = 2, DivplayValue = "Выполняется" },
                    new TaskStatus { Id = 3, DivplayValue = "Остановлено" },
                    new TaskStatus { Id = 4, DivplayValue = "Завершено" }
            );
        }
    }
}
