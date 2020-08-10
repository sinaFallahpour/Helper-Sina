using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_ServiceLevel2 : BaseEntity<int>
    {
        /// <summary>
        /// توضيحات 
        /// </summary>
        public string Title  { get; set; }


        /// <summary>
        /// توضيحات 
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// قيمت
        /// </summary>
        public int Price { get; set; }

       /// <summary>
       /// تعداد ماه 
       /// </summary>
        public int MonthCount { get; set; }
    }
}
