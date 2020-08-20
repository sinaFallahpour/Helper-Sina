using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helper.ViewModels.mapper
{
    public class LikeNewseResolver : IValueResolver<TBL_NewsArticleVideo, Newse, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LikeNewseResolver(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }



        public bool Resolve(TBL_NewsArticleVideo source, Newse destination, bool destMember, ResolutionContext context)
        {

            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            //we shoud return bool  (not Task<bool>) becasue of this we use 'Resule' after SingleOrDefaultAsync
            var currentUser = _context.Users
                .SingleOrDefaultAsync(x => x.UserName == currentUsername).Result;

            if (currentUser == null)
                return false;
            if (_context.TBL_NewsLike.Where(c => c.UserId == currentUser.Id && c.NewsId == source.Id).Any())
                return true;
            return false;
        }

    }
}
