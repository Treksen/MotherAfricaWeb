using System.ComponentModel.DataAnnotations;

namespace web.Models.Auth
{
  
    public class SignInEmployeeModel
    {

        [Required(ErrorMessage = "checknumber/password incorrect")]
        public string CheckNumber { get; set; } = default!;
        [Required(ErrorMessage = "checknumber/password incorrect")]
        public string Password { get; set; } = default!;
    }
}