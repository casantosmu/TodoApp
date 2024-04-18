using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Todo
{
    public int TodoId { get; init; }

    [StringLength(60)]
    public required string Name { get; init; }

    public bool Done { get; set; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}