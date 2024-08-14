using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class UsariosModel
{
    [Key]
    public int id { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public int cargo_id { get; set; }
    [ForeignKey("cargo_id")]
    public required CargoModel cargo { get; set; }
    public byte[] senha { get; set; }
    public byte[] salt { get; set; }
    public PerfilEnum perfil { get; set; } = PerfilEnum.Colaborador;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}
