using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class AdminListViewModel
    {
        [Key]
        public string Id { get; set; }

        [Display(Name ="نام مستعار")]
        public string Nickname  { get; set; }

        [Display(Name ="نام کامل")]
        public string FullName { get; set; }

        [Display(Name = " جنسیت")]

        public string Gender { get; set; }

        public string PhotoAddress { get; set; }

        public string Username { get; set; }

    }
}
