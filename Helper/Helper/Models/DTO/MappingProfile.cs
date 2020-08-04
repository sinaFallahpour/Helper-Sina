using AutoMapper;
using Helper.Models.DTO.News;
using Helper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<TBL_NewsArticleVideo, ActivityDto>();
            CreateMap<TBL_NewsArticleVideo, ListNewsDTO>()
                                 .ForMember(d => d.isLiked, o => o.MapFrom<LikeResolver>());
                                 //.BeforeMap((s, d) => d.isLiked = false);
                 




                //.ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                //.ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                //.ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))
                //.ForMember(d => d.isLiked, o => o.MapFrom<FollowingResolver>());

                // .ForMember(d => d.is, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))

        }
    }
}
