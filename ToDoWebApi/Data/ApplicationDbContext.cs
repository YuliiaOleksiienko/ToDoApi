using Microsoft.EntityFrameworkCore;
using ToDoWebApi.Models;


namespace ToDoWebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoItems> TodoItems { get; set; }
    }
}
