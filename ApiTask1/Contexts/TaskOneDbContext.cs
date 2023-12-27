using ApiTask1.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTask1.Contexts
{
    public class TaskOneDbContext : DbContext
    {
        public TaskOneDbContext (DbContextOptions<TaskOneDbContext> options) : base(options) { } 
        
        public DbSet<Student> Students { get; set; }
    }
}
