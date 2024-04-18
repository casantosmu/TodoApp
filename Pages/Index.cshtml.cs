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
    public Todo? NewTodo { get; set; }

    public async Task OnGetAsync()
    {
        Todos = await context.Todo.ToListAsync();
    }

    public async Task<IActionResult> OnPostToggleDoneAsync(int id)
    {
        Todo? todo = await context.Todo.FindAsync(id);

        if (todo is not null)
        {
            todo.Done = !todo.Done;
            await context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteTodoAsync(int id)
    {
        Todo? todo = await context.Todo.FindAsync(id);

        if (todo is not null)
        {
            context.Todo.Remove(todo);
            await context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostAddTodoAsync()
    {
        if (!ModelState.IsValid)
        {
            Todos = await context.Todo.ToListAsync();
            return Page();
        }

        if (NewTodo is not null)
        {
            context.Todo.Add(new Todo { Name = NewTodo.Name });
            await context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}