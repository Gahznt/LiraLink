using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class DepartmentsModel
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
}
