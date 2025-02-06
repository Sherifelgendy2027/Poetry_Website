using System.ComponentModel.DataAnnotations;

namespace Poetry_Api.DTO
{
    public class AddAdminDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,10}$", ErrorMessage = "The email must be like this: name@domain.com")]
        public string Email { get; set; }
        [Required]
        [Length(maximumLength: 50, minimumLength: 8)]
        public string Password { get; set; }
        [Required]
        [Length(maximumLength: 50, minimumLength: 8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
