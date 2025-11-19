using System.ComponentModel.DataAnnotations;

namespace web.Models.Auth
{

        public class Profile2ViewModel
        {
        //[Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; } = default!;

           // [Required(ErrorMessage = "Last name is required.")]
            public string Lastname { get; set; } = default!;

        //[Required(ErrorMessage = "Email address is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Emailaddress { get; set; } = default!;
    }
}
