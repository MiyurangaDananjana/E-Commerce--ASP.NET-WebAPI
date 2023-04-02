using e_com_RSEt_API.Models;
using System.Linq;

namespace e_com_RSEt_API.DAL
{
    public class HomeDAL
    {
        private readonly M_SHOP_DBContext _db;



        public HomeDAL(M_SHOP_DBContext db)
        {
            _db = db;
        }
      

       

        //public void saveAntivirusGard(AntivirusGard antivirus)
        //{

        //    _db.AntivirusGards.Add(antivirus);
        //    _db.SaveChanges();
        //}
       
       
    }
}
