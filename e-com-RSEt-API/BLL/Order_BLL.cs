using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.BLL
{
    public class Order_BLL
    {
        private readonly M_SHOP_DBContext _db;
        public Order_BLL(M_SHOP_DBContext db)
        {
            _db = db;
        }

    }
}
