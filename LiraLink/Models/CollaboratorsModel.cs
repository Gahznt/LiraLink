using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class CollaboratorsModel
{
    [Key]
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public DateOnly AdmissionDate { get; set; }
    public int BondTypeId { get; set; }
    [ForeignKey("BondTypeId")]
    public BondTypesModel BondType { get; set; }
}
