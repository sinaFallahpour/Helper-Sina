using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Profiles.DTO
{
    public class EducationHistoryDTO
    {
        /// <summary>
        /// مقطع
        /// </summary>
        public string MaghTa { get; set; }
        public string UnivercityName { get; set; }
        public string EnterDate { get; set; }
        public string ExitDate { get; set; }

    }
}
