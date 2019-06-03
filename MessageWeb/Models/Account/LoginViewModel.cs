using System.ComponentModel.DataAnnotations;

namespace Possible.MessageWeb.Models.Account
{
    /// <summary>
    /// Represents the model for the Login view.
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}