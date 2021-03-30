using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "نام ")]
        public string Nickname { get; set; }
        [Display(Name = "تاریخ درج")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "شهر")]
       public string City { get; set; }
        [Display(Name = "وضعیت حساب")]
        public bool Islocked { get; set; }
        [Display(Name = "تصویر")]
        public string PhotoAddress { get; set; }
        [Display(Name = "نقش")]
        public string RoleName { get; set; }

    }
}
