using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages;

public class IndexModel(TodoAppContext context) : PageModel
{
    public IList<Todo> Todos { get; set; } = default!;

    [BindProperty]
    public Todo? Todo { get; set; }

    [BindProperty(SupportsGet = true)]
    [DataType(DataType.Date)]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public async Task OnGetAsync()
    {
        Todos = await GetTodosByDate();
    }

    public async Task<IActionResult> OnPostToggleDoneAsync(int id)
    {
        Todo? todo = await context.Todo.FindAsync(id);

        if (todo is not null)
        {
            todo.Done = !todo.Done;
            await context.SaveChangesAsync();
        }

        return RedirectToPage(new { Date = Date.ToString("o") });
    }

    public async Task<IActionResult> OnPostDeleteTodoAsync(int id)
    {
        Todo? todo = await context.Todo.FindAsync(id);

        if (todo is not null)
        {
            context.Todo.Remove(todo);
            await context.SaveChangesAsync();
        }

        return RedirectToPage(new { Date = Date.ToString("o") });
    }

    public async Task<IActionResult> OnPostAddTodoAsync()
    {
        if (!ModelState.IsValid)
        {
            Todos = await GetTodosByDate();
            return Page();
        }

        if (Todo is not null)
        {
            Todo todo = new() { Name = Todo.Name, Date = Date };
            context.Todo.Add(todo);
            await context.SaveChangesAsync();
        }

        return RedirectToPage(new { Date = Date.ToString("o") });
    }

    private async Task<IList<Todo>> GetTodosByDate()
    {
        return await context.Todo.Where(todo => todo.Date == Date).AsNoTracking().ToListAsync();
    }
}