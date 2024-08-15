using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "nome is required")]
    [MaxLength(100, ErrorMessage = "The nome cannot be longer than 100 characters")]
    public string nome { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [MaxLength(100, ErrorMessage = "The email cannot be longer than 100 characters")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string email { get; set; }

    [Required(ErrorMessage = "Senha is required")]
    [MaxLength(100, ErrorMessage = "The senha cannot be longer than 100 characters")]
    [MinLength(8, ErrorMessage = "Senha must be at least 8 characters long")]
    [NotMapped]
    public string senha { get; set; }

    [Required(ErrorMessage = "cargo_id is required")]
    public int? cargo_id { get; set; }

    [Required(ErrorMessage = "perfil is required")]
    [EnumDataType(typeof(PerfilEnum), ErrorMessage = "Invalid value for perfil.")]
    public PerfilEnum perfil { get; set; } = PerfilEnum.Colaborador;
}
