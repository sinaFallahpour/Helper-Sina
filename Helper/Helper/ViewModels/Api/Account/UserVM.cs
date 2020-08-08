using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Account
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhotoAddress { get; set; }
    }
}
