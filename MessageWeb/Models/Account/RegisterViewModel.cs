using System.ComponentModel.DataAnnotations;

namespace Possible.MessageWeb.Models.Account
{
    /// <summary>
    /// Represents the model for the Registration view (Account controller)
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [RegularExpression(@"[\w_\-\.]{3,12}", ErrorMessage = "The username can only contain letters and numbers and _ - . characters. And must be between 3-12 characters long.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Phone number (optinal)")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+\d{8,12}", ErrorMessage = "The phone number needs to be of format: +XXXXXXXXXX the X being a number.")]
        public string PhoneNumber { get; set; }
    }
}