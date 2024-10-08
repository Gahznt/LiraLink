﻿using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class PositionDto
{
    [Required(ErrorMessage = "The field nome is required")]
    public string nome { get; set; }
}
