using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.AccountSettings.DTO
{
    public class ProfileDTO
    {

        public string Id { get; set; }


        public string UserName { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }


        /// <summary>
        /// زبان سایت
        /// </summary>
        public SiteLanguage SiteLanguage { get; set; }


        /// <summary>
        ///نام بانک
        /// </summary>
        public string BankName { get; set; }


        /// <summary>
        /// نام صاحب حساب بانک
        /// </summary>
        public string AccountOwner { get; set; }


        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }


        /// <summary>
        /// شماره ویزا یا مسترکارد
        /// </summary>
        public string VisaNumber { get; set; }

    }
}
