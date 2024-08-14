using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class TipoIndicadoreseDto
{
    [Required(ErrorMessage = "The field nome is required")]
    public string nome { get; set; }
}
