using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class IndicatorsModel
{
    [Key]
    public int Id { get; set; }
    public int IndicatorTypeId { get; set; }
    [ForeignKey("IndicatorTypeId")]
    public required IndicatorsModel Indicators { get; set; }
    public required string Name { get; set; }
}
