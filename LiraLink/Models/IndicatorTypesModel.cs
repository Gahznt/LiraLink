using System.ComponentModel.DataAnnotations;
namespace LiraLink.Models;

public class IndicatorTypesModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
