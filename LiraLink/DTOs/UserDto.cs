using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.DTOs;

public class UserDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [MaxLength(100, ErrorMessage = "The email cannot be longer than 100 characters")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(100, ErrorMessage = "The password cannot be longer than 100 characters")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [NotMapped]
    public string Password { get; set; }
}
