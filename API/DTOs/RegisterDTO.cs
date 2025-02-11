using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDTO
{
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [StringLength(12, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}
