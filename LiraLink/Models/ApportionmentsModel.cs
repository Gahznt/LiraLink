using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ApportionmentsModel
{
    [Key]
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public required DepartmentsModel Department { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public required ProjectsModel Project { get; set; }

    public int IndicatorId { get; set; }
    [ForeignKey("IndicatorId")]
    public required IndicatorsModel Indicators { get; set; }
    public float Percentual { get; set; }
}
