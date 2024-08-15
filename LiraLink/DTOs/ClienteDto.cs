using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class ClienteDto
{
    [Required(ErrorMessage = "The field nome is required")]
    public string nome { get; set; }
    [Required(ErrorMessage = "The field telefone is required")]
    public string telefone { get; set; }

    [Required(ErrorMessage = "The field email is required")]
    public string email { get; set; }
}
