using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.DAL
{
    public class MarketingAndSale_DAL
    {
        private readonly M_SHOP_DBContext _db;



        public MarketingAndSale_DAL(M_SHOP_DBContext db)
        {
            _db = db;
        }
        internal void AddNewComputerReq(ComputerOder dto)
        {
            _db.ComputerOders.Add(dto);
            _db.SaveChanges();
        }
    }
}
