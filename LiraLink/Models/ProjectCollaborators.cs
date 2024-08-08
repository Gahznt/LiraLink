using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ProjectCollaborators
{
    [Key]
    public int Id { get; set; }
    public int CollaboratorId { get; set; }
    [ForeignKey("CollaboratorId")]
    public required CollaboratorsModel Collaborators{ get; set; }
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public required ProjectsModel Projects{ get; set; }
    public required string ParticipationStatus { get; set; }
    public int Performance { get; set; }
    public int ProcessesDisciplinaryNumber { get; set; }
    public int WarningSheetQuantity { get; set; }
}
