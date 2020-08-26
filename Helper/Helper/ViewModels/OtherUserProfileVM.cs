using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class OtherUserProfileVM
    {

        public string Id { get; set; }

       
        [Display(Name = "UserName")]
        public string UserName { get; set; }

       
      


         
        [Display(Name = "نام")]
        public string Nickname { get; set; }


     


        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }


        
        
        public string Descriptions { get; set; }


       
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }


         public string LanguageKnowing { get; set; }


        [Display(Name = "جنسیت")]
        public UserGender Gender { get; set; } = UserGender.Man;

        [Display(Name = "وضعیت ")]
        public UserMarriedType MarriedType { get; set; }


         public string City { get; set; }



        /// <summary>
        /// آدرس عکس
        /// </summary>
        public string PhotoAddress { get; set; }








        /*  اطلاعات تحصیلی  */

        [Display(Name = "مقطع ")]
        public string MaghTa { get; set; }

         [Display(Name = "نام دانشگاه")]
        public string UnivercityName { get; set; }

         [Display(Name = "  از تاریخ ")]
        public string EduEnterDate { get; set; }

         [Display(Name = "تا تاریخ")]
        public string EduExitDate { get; set; }
 






        /* اطلاعات کاری */
 
        [Display(Name = " شرکت")]
        public string CompanyName { get; set; }

         
        [Display(Name = "سمت")]
        public string Semat { get; set; }

       
        [Display(Name = " تاریخ ورود ")]
        public string WorkEnterDate { get; set; }

     
        public string WorkExitDate { get; set; }


         [Display(Name = "توضیحات")]

        public string WorkDescriptions { get; set; }
 



    }
}
