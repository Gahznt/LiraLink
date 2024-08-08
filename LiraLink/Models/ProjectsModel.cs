using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ProjectsModel
{
    [Key]
    public int id { get; set; }
    public required string Name { get; set; }
    public int ClientId { get; set; }
    [ForeignKey("ClientId")]
    public required ClientsModel Clients { get; set; }
    public float WorkValue { get; set; }
    public required string InvoiceNumber { get; set; }
}
