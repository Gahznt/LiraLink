using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "The field email is required")]
    [DataType(DataType.EmailAddress)]
    public string email { get; set; }

    [Required(ErrorMessage = "Field senha is required")]
    [DataType(DataType.Password)]
    public string senha { get; set; }

}
