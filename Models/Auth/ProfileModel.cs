using System.ComponentModel.DataAnnotations;

namespace web.Models.Auth
{
    public class ProfileModel
    {
        [Required(ErrorMessage = "First name required.")]
        public string FirstName { get; set; } = default!;
        [Required(ErrorMessage = "Last name required.")]
        public string LastName { get; set; } = default!;
        [Required(ErrorMessage = "Email address required.")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "National ID required.")]
        public int NationalId { get; set; } = default!;
        [Required(ErrorMessage = "Date of birth required.")]
        public DateTime DOB { get; set; } = DateTime.Today.AddYears(-18);
    }
}
