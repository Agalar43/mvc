using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public String? UserName { get; init; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public String? Email { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }


    }
}