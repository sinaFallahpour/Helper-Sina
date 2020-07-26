using Helper.Areas.Admin.Models.ViewModels.AboutUs;
using Helper.Models.DAL;
using Helper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.BLL
{
    public class AboutUsManager
    {
        private AboutUsRepository _repo;
        public AboutUsManager(AboutUsRepository Repo)
        {
            _repo = Repo;
        }







        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<TBL_AboutUs> GetById(int? Id)
        {
            if (Id == null)
                return null;
            return _repo.GetById((int)Id);
        }




        /// <summary>
        /// get all AbouUs
        /// </summary>
        /// <returns></returns>
        public Task<List<TBL_AboutUs>> GetAll()
        {
            return _repo.GetAll();
        }





        /// <summary>
        /// افزودن درباره ما
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(TBL_AboutUs model)
        {
            if (model == null) return false;

            return _repo.AddAboutUs(model);
        }





        /// <summary>
        /// آپدیت  درباره ما
        /// </summary>
        /// <param name="model"></param>
        public bool Update(TBL_AboutUs model)
        {
            if (model == null) return false;
            return _repo.UpdateAboutUs(model);
        }





        /// <summary>
        /// حذف درباره ما
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeleteAboutUsViewModel Delete(int? id)
        {
            if (id == null)
                return new DeleteAboutUsViewModel(null, false);
            return _repo.Delete((int)id);
        }





    }
}
