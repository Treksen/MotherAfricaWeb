using System.ComponentModel.DataAnnotations;

namespace web.Models.Auth
{
    public class CreateAccountModel
    {
        [Required(ErrorMessage = "First name required.")]
        [Display(Name = "First Name")]
        [MaxLength(30, ErrorMessage = "Exceeded length requirement")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "Last name required")]
        [Display(Name = "Last Name")]
        [MaxLength(30, ErrorMessage = "Exceeded length requirement")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "Email address required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = default!;
    }
}
