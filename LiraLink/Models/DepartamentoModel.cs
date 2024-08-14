using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class DepartamentoModel
{
    [Key]
    public int id { get; set; }
    public required string nome { get; set; }
}
