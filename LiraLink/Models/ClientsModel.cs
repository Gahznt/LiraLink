using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class ClientsModel
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
}
