using AutoMapper;
using Helper.Models;
using Helper.Models.Entities;
using Helper.ViewModels.Api.AccountSettings.DTO;
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
            CreateMap<ApplicationUser, ProfileDTO>();

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


        }
    }
}
