using AutoMapper;
using Helper.Models;
using Helper.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.AccountSettings.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ProfileDTO>();

            CreateMap<ApplicationUser, ChangeBankDTO>();

            CreateMap<ApplicationUser, ChangePrsonalInfoDTO>();


        }
    }
}
