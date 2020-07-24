using Helper.Data;
using Helper.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.DAL
{
    public class AboutUsRepository
    {
        //private readonly IGenericRepository<TBL_User> _UserRep;
        private readonly ApplicationDbContext _db;

        public AboutUsRepository(ApplicationDbContext db)
        {
            _db = db;
        }



        /// <summary>
        /// get all AbouUs
        /// </summary>
        /// <returns></returns>

        public async Task<List<TBL_AboutUs>> GetAll()
        {
            return await _db.TBL_AboutUs.OrderBy(c => c.IsMain).ToListAsync();
        }


    }
}
