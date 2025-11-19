using System.ComponentModel.DataAnnotations;

namespace web.Models.Admin
{
    public class AdminRegistrationModel(string username)
    {
        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; } = username;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public required string ConfirmPassword { get; set; }
    }

}


