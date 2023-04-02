using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.BLL
{
    public class MarketingAndSale_BLL
    {
        private readonly M_SHOP_DBContext _db;
        public MarketingAndSale_BLL(M_SHOP_DBContext db)
        {
            _db = db;
        }

        internal void AddNewComputerReq(ComputerOder dto)
        {
            MarketingAndSale_DAL homeDAL = new MarketingAndSale_DAL(_db);
            homeDAL.AddNewComputerReq(dto);

        }

    }
}
