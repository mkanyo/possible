﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Possible.MessageWeb.Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}