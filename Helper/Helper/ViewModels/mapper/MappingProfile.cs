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

        }
    }
}
