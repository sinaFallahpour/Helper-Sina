using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class SubscribeNewsVM
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "EmailFormat")]
        public string Email { get; set; }
    }
}
