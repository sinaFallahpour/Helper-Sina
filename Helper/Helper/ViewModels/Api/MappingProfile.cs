using AutoMapper;
using Helper.Models;
using Helper.Models.Entities;
using Helper.ViewModels.Api.AccountSettings.DTO;
using Helper.ViewModels.Api.Plan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ProfileDTO>()
                     .ForMember(d => d.AccountOwner, o => o.MapFrom(s => s.BankInfo.AccountOwner))
                     .ForMember(d => d.BankName, o => o.MapFrom(s => s.BankInfo.BankName))
                     .ForMember(d => d.CardNumber, o => o.MapFrom(s => s.BankInfo.CardNumber))
                     .ForMember(d => d.ShabaNumber, o => o.MapFrom(s => s.BankInfo.ShabaNumber))
                     .ForMember(d => d.VisaNumber, o => o.MapFrom(s => s.BankInfo.VisaNumber))
                ;

            CreateMap<ApplicationUser, ChangeBankDTO>();

            CreateMap<ApplicationUser, ChangePrsonalInfoDTO>();

            CreateMap<ApplicationUser, Helper.ViewModels.Api.Profiles.DTO.ProfilesDTO>()
            .ForMember(d => d.EducationHistryDTO, o => o.MapFrom(s => s.EducationHistry))
              .ForMember(d => d.WorkExperienceDTO, o => o.MapFrom(s => s.WorkExperience));


            //CreateMap<Helper.ViewModels.Api.Profiles.DTO.ProfilesDTO, ApplicationUser>();




            //بایند 2 طرفه
            CreateMap<TBL_EducationalHistory, Helper.ViewModels.Api.Profiles.DTO.EducationHistoryDTO>();
            CreateMap<Helper.ViewModels.Api.Profiles.DTO.EducationHistoryDTO, TBL_EducationalHistory>();

            //بایند 2 طرفه
            CreateMap<TBL_WorkExperience, Helper.ViewModels.Api.Profiles.DTO.WorkExperienceDTO>();
            CreateMap<Helper.ViewModels.Api.Profiles.DTO.WorkExperienceDTO, TBL_WorkExperience>();



            /* plan */
            //بایند 2 طرفه
            CreateMap<TBL_Plans, PlanDTO>()
                  .ForMember(d => d.PlanMonyUnitDTO, o => o.MapFrom(s => s.PlansMonyUnit));

            CreateMap<TBL_Plane_MonyUnit, PlanMonyUnitDTO>();

        }
    }
}
