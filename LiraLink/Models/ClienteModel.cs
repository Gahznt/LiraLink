using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class ClienteModel
{
    [Key]
    public int id { get; set; }
    public required string nome { get; set; }
}
