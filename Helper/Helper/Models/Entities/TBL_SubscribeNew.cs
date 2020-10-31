using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{

    /// <summary>
    /// جدول خبرنامه ها
    /// </summary>
    public class TBL_SubscribeNew : BaseEntity<int>
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "EmailFormat")]
        public string Email { get; set; }
    }
}
