using System.ComponentModel.DataAnnotations;

namespace Possible.MessageWeb.Models.Messages
{
    public class NewMessageViewModel
    {
        [Required(ErrorMessage = "Please specify the username to send it to")]
        [Display(Name = "To (username)")]
        public string UserNameTo { get; set; }

        [Required(ErrorMessage = "Please ented the message to send")]
        [Display(Name = "Your message")]
        public string Contents { get; set; }
    }
}