using Microsoft.EntityFrameworkCore;
using ToDoWebApi.Models;


namespace ToDoWebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
