using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<TaskModel> Task { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
