using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoWebApi.Data;
using ToDoWebApi.Models;

namespace ToDoWebApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public List<TodoItem> TodoItems { get; set; } = new();

        
        [BindProperty]
        public string NewTaskTitle { get; set; } = string.Empty;

        
        public async Task OnGetAsync()
        {
            TodoItems = await _context.TodoItems
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                var todo = new TodoItem
                {
                    Title = NewTaskTitle,
                    IsCompleted = false
                };
                _context.TodoItems.Add(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

        
        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

        
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
    

