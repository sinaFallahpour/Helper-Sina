using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helper.ViewModels.mapper
{
    public class PlanResolver : IValueResolver<TBL_Plans, PlanVM, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlanResolver(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }



        public bool Resolve(TBL_Plans source, PlanVM destination, bool destMember, ResolutionContext context)
        {

            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            //we shoud return bool  (not Task<bool>) becasue of this we use 'Resule' after SingleOrDefaultAsync
            var currentUser = _context.Users
                .SingleOrDefaultAsync(x => x.Id == currentUserId).Result;

            if (currentUser == null)
                return false;
            if (currentUser.PlanId == source.Id)
                return true;
            else
                return false;
            //if (_context.TBL_NewsLike.Where(c => c.UserId == currentUser.Id && c.NewsId == source.Id).Any())
            //    return true;
            //return false;
        }
    }
}
