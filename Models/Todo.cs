using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }
    [DisplayName("Start")]
    [DataType(DataType.Time)]
    public DateTime? TimeIni { get; set; }
    [DisplayName("End")]
    [DataType(DataType.Time)]
    public DateTime? TimeEnd { get; set; }
    [DataType(DataType.Date)]
    public string Date { get; set; } = DateTime.Today.ToShortDateString();
}
