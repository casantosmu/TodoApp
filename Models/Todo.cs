using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Todo
{
    public int TodoId { get; init; }

    [StringLength(60)]
    public required string Name { get; init; }

    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.Now);

    public bool Done { get; set; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}