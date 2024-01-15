using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class RegisterDto
{
    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";

    [Required]
    public string Username { get; set; } = "";
}