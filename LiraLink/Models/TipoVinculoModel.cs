using System.ComponentModel.DataAnnotations;

namespace LiraLink.Models;

public class TipoVinculoModel
{
    [Key]
    public int id { get; set; }
    public required int nome { get; set; }
}
