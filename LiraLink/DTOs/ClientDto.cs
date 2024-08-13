using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class ClientDto
{
    [Required(ErrorMessage = "The field name is required")]
    public string Name { get; set; }
}
