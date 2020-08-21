using AutoMapper;
using Helper.Models;
using Helper.Models.Entities;
using Helper.ViewModels.Api.AccountSettings.DTO;
using Helper.ViewModels.Api.Plan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TBL_NewsArticleVideo, Newse>()
                               .ForMember(d => d.isLiked, o => o.MapFrom<LikeNewseResolver>());



            /*  1 طرفه */
            CreateMap<ApplicationUser, AccountSettingsVM>()
                     .ForMember(d => d.AccountOwner, o => o.MapFrom(s => s.BankInfo.AccountOwner))
                     .ForMember(d => d.BankName, o => o.MapFrom(s => s.BankInfo.BankName))
                     .ForMember(d => d.CardNumber, o => o.MapFrom(s => s.BankInfo.CardNumber))
                     .ForMember(d => d.ShabaNumber, o => o.MapFrom(s => s.BankInfo.ShabaNumber))
                     .ForMember(d => d.VisaNumber, o => o.MapFrom(s => s.BankInfo.VisaNumber))
                ;

            //CreateMap< ProfileDTO ,ApplicationUser > ()
            //       .ForMember(d => d.BankInfo.AccountOwner, o => o.MapFrom(s => s.AccountOwner))
            //       .ForMember(d => d.BankInfo.BankName , o => o.MapFrom(s => s.BankName))
            //       .ForMember(d => d.BankInfo.CardNumber, o => o.MapFrom(s => s.CardNumber ))
            //       .ForMember(d => d.BankInfo.ShabaNumber, o => o.MapFrom(s => s.ShabaNumber  ))
            //       .ForMember(d => d.BankInfo.VisaNumber, o => o.MapFrom(s => s.VisaNumber ))
            //  ;


        }
    }
}
