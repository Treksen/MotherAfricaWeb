using System.ComponentModel.DataAnnotations;

namespace web.Models.Auth
{
    /// <summary>
    ///  TODO : Understand how models map UI files with Controllers, hence (MVC)
    /// </summary>
    public class SignInModel
    {
        [Required(ErrorMessage = "Username/password incorrect")]
        public string Username { get; set; } = default!;
        [Required(ErrorMessage = "Username/password incorrect")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}
