using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.DAL
{
    public class Security_DAL
    {
        private readonly M_SHOP_DBContext _db;



        public Security_DAL(M_SHOP_DBContext db)
        {
            _db = db;
        }
    }
}
