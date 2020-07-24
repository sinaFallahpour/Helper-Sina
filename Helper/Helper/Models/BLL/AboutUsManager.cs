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
        /// get all AbouUs
        /// </summary>
        /// <returns></returns>
        public Task<List<TBL_AboutUs>> GetAll()
        {
            return  _repo.GetAll();
        }




    }
}
