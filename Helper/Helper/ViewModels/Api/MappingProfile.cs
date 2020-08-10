using AutoMapper;
using Helper.Models;
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
            CreateMap<ApplicationUser, Helper.ViewModels.Api.Profiles.DTO.ProfilesDTO>();

        }
    }
}
