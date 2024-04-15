using Microsoft.EntityFrameworkCore;

using TodoApp.Models;

namespace TodoApp.Data;

public class TodoAppContext : DbContext
{
    public TodoAppContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "TodoAppContext.db");
    }

    public DbSet<Todo> Todo { get; init; } = default!;

    private string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}