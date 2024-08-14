using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class CargoModel
{
    [Key]
    public int id { get; set; }
    public required string nome { get; set; }
}
