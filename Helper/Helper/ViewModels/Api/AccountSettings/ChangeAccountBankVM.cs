﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.AccountSettings
{
    public class ChangeAccountBankVM
    {


        /// <summary>
        ///نام بانک
        /// </summary>
        [MaxLength(150, ErrorMessage = "حداکثر 150 کاراکتر ")]
        public string BankName { get; set; }


        /// <summary>
        /// نام صاحب حساب بانک
        /// </summary>
        [MaxLength(60,ErrorMessage ="حداکثر 60 کاراکتر ")]
        public string AccountOwner { get; set; }

        
        /// <summary>
        /// شماره کارت
        /// </summary>
        [StringLength(16, MinimumLength = 16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        //[RegularExpression(@"^-?[0-9]\d{0,2}(\.\d{0,1})?$", ErrorMessage = "فقط عدد وارد کنید")]
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        [StringLength(16, MinimumLength = 16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        //[RegularExpression(@"^-?[0-9]\d{0,2}(\.\d{0,1})?$", ErrorMessage = "فقط عدد وارد کنید")]
        public string ShabaNumber { get; set; }


        /// <summary>
        /// شماره ویزا یا مسترکارد
        /// </summary>
        [StringLength(16, MinimumLength = 16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        //[RegularExpression(@"^-?[0-9]\d{0,2}(\.\d{0,1})?$", ErrorMessage = "فقط عدد وارد کنید")]
        public string VisaNumber { get; set; }
    }
}
