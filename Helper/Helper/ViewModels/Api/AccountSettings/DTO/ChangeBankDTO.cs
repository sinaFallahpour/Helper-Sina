using Helper.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.AccountSettings.DTO
{
    public class ChangeBankDTO
    {
        public string Id { get; set; }

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


        public UserVM CurrentUser { get; set; }
    }
}
