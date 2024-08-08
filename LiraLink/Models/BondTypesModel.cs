using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class BondTypesModel
{
    [Key]
    public int Id { get; set; }
    public required int Name { get; set; }
}
