using Helper.Areas.Admin.Models.ViewModels.AboutUs;
using Helper.Data;
using Helper.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        /// Get AboutUS By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<TBL_AboutUs> GetById(int Id)
        {
            return await _db.TBL_AboutUs.FindAsync(Id);
        }



        /// <summary>
        /// get all AbouUs
        /// </summary>
        /// <returns></returns>

        public async Task<List<TBL_AboutUs>> GetAll()
        {
            return await _db.TBL_AboutUs.OrderByDescending(c => c.IsMain).AsNoTracking().ToListAsync();
        }







        /// <summary>
        /// افزودن درباره ما
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAboutUs(TBL_AboutUs model)
        {
            if (model == null) return false;

            if (model.IsMain)
            {
                foreach (var item in _db.TBL_AboutUs)
                {
                    item.IsMain = false;
                }
            }
            var CreatedUser = _db.TBL_AboutUs.Add(model);

            try
            {
                var result = _db.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }







        /// <summary>
        /// آپدیت  درباره ما
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateAboutUs(TBL_AboutUs model)
        {
            if (model == null) return false;
            var aboutUs = _db.TBL_AboutUs.Find(model.Id);
            if (aboutUs == null) return false;

            if (model.IsMain)
            {
                foreach (var item in _db.TBL_AboutUs)
                {
                    item.IsMain = false;
                }
            }

            aboutUs.Title = model.Title;
            aboutUs.Description = model.Description;
            aboutUs.IsMain = model.IsMain;


            try
            {
                var result = _db.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }




        /// <summary>
        /// حذف درباره ما
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeleteAboutUsViewModel Delete(int Id)
        {
            var aboutUs = _db.TBL_AboutUs.Find(Id);
            if (aboutUs == null)
                return new DeleteAboutUsViewModel(null, false);

            _db.TBL_AboutUs.Remove(aboutUs);
            try
            {
                var result = _db.SaveChanges();
                if (result > 0)
                    //var result = _unitOfWork.Complete();
                    //if (result > 0)
                    return new DeleteAboutUsViewModel(aboutUs, true);

                return new DeleteAboutUsViewModel(aboutUs, false);
            }
            catch (Exception ex)
            {
                return new DeleteAboutUsViewModel(aboutUs, false);
            }
        }


    }
}
