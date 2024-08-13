using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class IndicatorsTypeDto
{
    [Required(ErrorMessage = "The field name is required")]
    public string Name { get; set; }
}
