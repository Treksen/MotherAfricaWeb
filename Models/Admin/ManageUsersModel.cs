using System.ComponentModel.DataAnnotations;

namespace web.Models.Admin
{

    public class ManageUsersModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }
        public required string Contact { get; set; }
        public required string Role { get; set; } // Example: Admin, User

        public bool IsActive { get; set; }

        // List or string of actions that can be performed
        public List<string>? Actions { get; set; } // Example: {"Edit", "Delete", "Suspend"}
    }

}
