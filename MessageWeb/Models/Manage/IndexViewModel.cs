using System.ComponentModel.DataAnnotations;

namespace Possible.MessageWeb.Models.Manage
{
    public class IndexViewModel
    {
        [Display(Name = "Hide me from the lists")]
        public bool HideMeFromList { get; set; }        
    }
}