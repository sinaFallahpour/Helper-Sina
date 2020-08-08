using Helper.Models.Enums;
using Helper.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.AccountSettings.DTO
{
    public class ChangePrsonalInfoDTO
    {
    
        public string Id { get; set; }
      
        public string UserName { get; set; }

       
        public string Email { get; set; }
      
        public string Phone { get; set; }


        /// <summary>
        /// زبان سایت
        /// </summary>
        public SiteLanguage SiteLanguage { get; set; }


        public UserVM CurrentUser { get; set; }
    }
}
