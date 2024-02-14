using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.Time)]
    public DateTime? TimeIni { get; set; }
    [DataType(DataType.Time)]
    public DateTime? TimeEnd { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
