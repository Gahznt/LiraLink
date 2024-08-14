using System.ComponentModel.DataAnnotations;
namespace LiraLink.Models;

public class TipoIndicadorModel
{
    [Key]
    public int id { get; set; }
    public string nome { get; set; }
}
