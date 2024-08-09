using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "The field email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Field password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
