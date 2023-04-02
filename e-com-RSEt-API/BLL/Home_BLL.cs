using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.BLL
{
    public class Home_BLL
    {
        private readonly M_SHOP_DBContext _db;

        public Home_BLL(M_SHOP_DBContext db)
        {
            _db = db;
        }

      

    

        //public void saveAntivirusGard(AntivirusGard antivirus)
        //{
        //    HomeDAL homeDAL = new HomeDAL(_db);
        //    homeDAL.saveAntivirusGard(antivirus);
        //}

       
       


        
    }
}
