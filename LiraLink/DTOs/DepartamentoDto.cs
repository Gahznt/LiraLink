using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class DepartamentoDto
{
    [Required(ErrorMessage = "The field nome is required")]
    public string nome { get; set; }
}
