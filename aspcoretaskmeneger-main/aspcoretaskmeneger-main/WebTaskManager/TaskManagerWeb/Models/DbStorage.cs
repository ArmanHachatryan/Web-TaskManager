using Microsoft.EntityFrameworkCore;

namespace TaskManagerWeb.Models
{
    public class DbStorage : DbContext
    {
        public DbSet<Task> Tasks { get; set; } = null!;

        public DbStorage(DbContextOptions<DbStorage> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
